using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VRC_GIF_to_Emoji
{
    public partial class PreviewControl : UserControl
    {
        private Timer _timer;
        private GifProject _project;
        private int _index;
        private bool _showGrid;

        // Pan/zoom crop state (in normalized 0..1 coordinates of the source image).
        private float _cropCenterX = 0.5f;
        private float _cropCenterY = 0.5f;
        private float _cropZoom = 1.0f;

        // Drag tracking.
        private bool _dragging;
        private Point _dragStart;
        private float _dragStartCx, _dragStartCy;

        public PreviewControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw, true);

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            _timer = new Timer { Interval = 100 };
            _timer.Tick += (s, e) =>
            {
                if (_project == null || _project.Frames.Count == 0) return;
                _index = (_index + 1) % _project.Frames.Count;
                Invalidate();
            };
            _timer.Start();
        }

        public bool ShowGrid
        {
            get => _showGrid;
            set { _showGrid = value; Invalidate(); }
        }

        public void Bind(GifProject project)
        {
            if (_project != null) _project.Changed -= OnProjectChanged;
            _project = project;
            _index = 0;
            if (_project != null)
            {
                _project.Changed += OnProjectChanged;
                ApplyFps(_project.TargetFps);
            }
            ResetCrop();
        }

        public void ResetCrop()
        {
            _cropCenterX = 0.5f;
            _cropCenterY = 0.5f;
            _cropZoom = 1.0f;
            PushCropToProject();
            Invalidate();
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            ApplyFps(_project.TargetFps);
            if (_project.Frames.Count == 0) _index = 0;
            else if (_index >= _project.Frames.Count) _index = 0;
            Invalidate();
        }

        private void ApplyFps(int fps)
        {
            if (_timer == null) return;
            _timer.Interval = Math.Max(20, 1000 / Math.Max(1, fps));
        }

        // --- Mouse interaction ---

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && _project != null && _project.Frames.Count > 0)
            {
                _dragging = true;
                _dragStart = e.Location;
                _dragStartCx = _cropCenterX;
                _dragStartCy = _cropCenterY;
                Cursor = Cursors.SizeAll;
                Capture = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!_dragging || _project == null || _project.Frames.Count == 0) return;

            int side = Math.Max(16, Math.Min(Width, Height) - 16);
            float visibleFraction = 1.0f / _cropZoom;

            float dx = (float)(e.X - _dragStart.X) / side;
            float dy = (float)(e.Y - _dragStart.Y) / side;

            _cropCenterX = Clamp(_dragStartCx - dx * visibleFraction, visibleFraction / 2, 1 - visibleFraction / 2);
            _cropCenterY = Clamp(_dragStartCy - dy * visibleFraction, visibleFraction / 2, 1 - visibleFraction / 2);

            PushCropToProject();
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_dragging)
            {
                _dragging = false;
                Cursor = Cursors.Default;
                Capture = false;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (_project == null || _project.Frames.Count == 0) return;

            float factor = e.Delta > 0 ? 1.15f : 1 / 1.15f;
            _cropZoom = Clamp(_cropZoom * factor, 1.0f, 16.0f);

            float visibleFraction = 1.0f / _cropZoom;
            _cropCenterX = Clamp(_cropCenterX, visibleFraction / 2, 1 - visibleFraction / 2);
            _cropCenterY = Clamp(_cropCenterY, visibleFraction / 2, 1 - visibleFraction / 2);

            PushCropToProject();
            Invalidate();
        }

        private void PushCropToProject()
        {
            if (_project == null || _project.Frames.Count == 0)
            {
                if (_project != null) _project.Crop = null;
                return;
            }

            var frame = _project.Frames[0].Image;
            var full = DefaultSquare(frame);

            float visibleFraction = 1.0f / _cropZoom;
            float cropW = full.Width * visibleFraction;
            float cropH = full.Height * visibleFraction;
            float cropX = full.X + full.Width * (_cropCenterX - visibleFraction / 2);
            float cropY = full.Y + full.Height * (_cropCenterY - visibleFraction / 2);

            _project.Crop = new Rectangle(
                (int)Math.Round(cropX),
                (int)Math.Round(cropY),
                (int)Math.Round(cropW),
                (int)Math.Round(cropH));
        }

        private static Rectangle DefaultSquare(Image src)
        {
            int side = Math.Min(src.Width, src.Height);
            int x = (src.Width - side) / 2;
            int y = (src.Height - side) / 2;
            return new Rectangle(x, y, side, side);
        }

        // --- Painting ---

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            DrawCheckerboard(g);

            if (_project == null || _project.Frames.Count == 0)
            {
                using (var b = new SolidBrush(Color.Gainsboro))
                {
                    var text = "Drop a GIF / image here, paste a URL, or click Browse";
                    var size = g.MeasureString(text, Font);
                    g.DrawString(text, Font, b,
                        (Width - size.Width) / 2,
                        (Height - size.Height) / 2);
                }
                return;
            }

            var frame = _project.Frames[_index].Image;
            int side = Math.Max(16, Math.Min(Width, Height) - 16);
            int px = (Width - side) / 2;
            int py = (Height - side) / 2;

            g.InterpolationMode = _cropZoom >= 4 ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var srcRect = _project.Crop ?? DefaultSquare(frame);
            using (var staged = new Bitmap(side, side))
            {
                using (var sg = Graphics.FromImage(staged))
                {
                    sg.InterpolationMode = g.InterpolationMode;
                    sg.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    sg.Clear(Color.Transparent);
                    sg.DrawImage(frame, new Rectangle(0, 0, side, side), srcRect, GraphicsUnit.Pixel);
                }
                if (_project.FlipRotate != RotateFlipType.RotateNoneFlipNone)
                    staged.RotateFlip(_project.FlipRotate);
                g.DrawImage(staged, px, py, side, side);
            }

            if (_showGrid)
            {
                var (cols, rows, _) = _project.ResolveGrid();
                using (var pen = new Pen(Color.FromArgb(160, Color.Cyan), 1))
                {
                    for (int i = 1; i < cols; i++)
                    {
                        int gx = px + (side * i) / cols;
                        g.DrawLine(pen, gx, py, gx, py + side);
                    }
                    for (int i = 1; i < rows; i++)
                    {
                        int gy = py + (side * i) / rows;
                        g.DrawLine(pen, px, gy, px + side, gy);
                    }
                    g.DrawRectangle(pen, px, py, side, side);
                }
            }

            // Dim the area outside the crop square so the boundary is obvious.
            using (var dim = new SolidBrush(Color.FromArgb(160, 0, 0, 0)))
            {
                if (px > 0)
                {
                    g.FillRectangle(dim, 0, 0, px, Height);
                    g.FillRectangle(dim, px + side, 0, Width - px - side, Height);
                }
                if (py > 0)
                {
                    g.FillRectangle(dim, px, 0, side, py);
                    g.FillRectangle(dim, px, py + side, side, Height - py - side);
                }
            }
            using (var border = new Pen(Color.FromArgb(200, 255, 255, 255), 2))
                g.DrawRectangle(border, px, py, side, side);

            // HUD
            using (var bg = new SolidBrush(Color.FromArgb(180, 0, 0, 0)))
            {
                string label = $"Frame {_index + 1}/{_project.Frames.Count}  •  {_project.TargetFps} fps";
                if (_cropZoom > 1.01f)
                    label += $"  •  {_cropZoom:0.0}x zoom";
                var sz = g.MeasureString(label, Font);
                g.FillRectangle(bg, 6, 6, sz.Width + 10, sz.Height + 6);
                g.DrawString(label, Font, Brushes.White, 11, 9);
            }
        }

        private void DrawCheckerboard(Graphics g)
        {
            const int sq = 16;
            using (var b1 = new SolidBrush(Color.FromArgb(60, 60, 60)))
            using (var b2 = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                for (int y = 0; y < Height; y += sq)
                    for (int x = 0; x < Width; x += sq)
                        g.FillRectangle(((x / sq) + (y / sq)) % 2 == 0 ? b1 : b2, x, y, sq, sq);
            }
        }

        private static float Clamp(float v, float min, float max)
        {
            if (v < min) return min;
            if (v > max) return max;
            return v;
        }
    }
}
