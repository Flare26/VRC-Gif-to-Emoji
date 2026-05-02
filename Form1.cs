using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRC_GIF_to_Emoji
{
    public partial class Form1 : Form
    {
        // VRChat caps animated emoji at 64 frames and 64 fps.
        private const int MaxFrames = 64;

        private readonly GifProject _project = new GifProject();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            preview.Bind(_project);
            _project.Changed += (s, ev) => RefreshUi();
            SetUrlPlaceholder("Paste a GIF/PNG URL…");
            RefreshUi();
        }

        // --- Source / import ---

        private async void OnLoadUrlClick(object sender, EventArgs e)
        {
            var url = txtUrl.Text?.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
            await LoadFromAsync(url);
        }

        private async void OnBrowseClick(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog
            {
                Filter = "Images|*.gif;*.png;*.jpg;*.jpeg;*.webp;*.bmp|All files|*.*"
            })
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    await LoadFromAsync(dlg.FileName);
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private async void OnDragDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || files.Length == 0) return;
            await LoadFromAsync(files[0]);
        }

        private async Task LoadFromAsync(string source)
        {
            try
            {
                SetStatus("Loading…");
                UseWaitCursor = true;
                Enabled = false;
                var frames = await GifLoader.LoadAsync(source);
                _project.Replace(frames);
                preview.ResetCrop();

                var nameGuess = Path.GetFileNameWithoutExtension(source);
                if (!string.IsNullOrWhiteSpace(nameGuess))
                {
                    txtName.Text = SanitizeName(nameGuess);
                    _project.Name = txtName.Text;
                }
                SetStatus($"Loaded {frames.Count} frame(s) from {source}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Load failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Load failed");
            }
            finally
            {
                UseWaitCursor = false;
                Enabled = true;
            }
        }

        // --- Frames tab ---

        private void OnFrameListSelected(object sender, EventArgs e) { /* could scrub preview later */ }

        private void OnDeleteFrameClick(object sender, EventArgs e)
        {
            int i = lstFrames.SelectedIndex;
            if (i >= 0) _project.RemoveAt(i);
        }

        private void OnReverseClick(object sender, EventArgs e) => _project.Reverse();

        private void OnKeepEveryClick(object sender, EventArgs e)
            => _project.KeepEveryNth((int)numKeepEvery.Value);

        private void OnTrimClick(object sender, EventArgs e)
            => _project.Trim((int)numTrimStart.Value, (int)numTrimEnd.Value);

        // --- Effects tab ---

        private void OnRotateLeftClick(object sender, EventArgs e)
            => _project.RotateFlipAll(RotateFlipType.Rotate270FlipNone);

        private void OnRotateRightClick(object sender, EventArgs e)
            => _project.RotateFlipAll(RotateFlipType.Rotate90FlipNone);

        private void OnFlipHClick(object sender, EventArgs e)
            => _project.RotateFlipAll(RotateFlipType.RotateNoneFlipX);

        private void OnFlipVClick(object sender, EventArgs e)
            => _project.RotateFlipAll(RotateFlipType.RotateNoneFlipY);

        private void OnResetCropClick(object sender, EventArgs e)
            => preview.ResetCrop();

        // --- Speed tab ---

        private void OnFpsChanged(object sender, EventArgs e)
        {
            var v = (int)numFps.Value;
            if (trkFps.Value != v) trkFps.Value = v;
            _project.TargetFps = v;
            _project.RaiseChanged();
        }

        private void OnFpsTrackScroll(object sender, EventArgs e)
        {
            if (numFps.Value != trkFps.Value) numFps.Value = trkFps.Value;
        }

        // --- Output tab ---

        private void OnNameChanged(object sender, EventArgs e)
        {
            _project.Name = txtName.Text;
            RefreshFileNameLabel();
        }

        private void OnAutoGridChanged(object sender, EventArgs e)
        {
            _project.AutoGrid = chkAutoGrid.Checked;
            numCols.Enabled = !chkAutoGrid.Checked;
            numRows.Enabled = !chkAutoGrid.Checked;
            _project.RaiseChanged();
        }

        private void OnGridChanged(object sender, EventArgs e)
        {
            _project.GridCols = (int)numCols.Value;
            _project.GridRows = (int)numRows.Value;
            _project.RaiseChanged();
        }

        private void OnShowGridChanged(object sender, EventArgs e)
            => preview.ShowGrid = chkShowGrid.Checked;

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (_project.Frames.Count == 0)
            {
                MessageBox.Show(this, "Load some frames first.", "Nothing to save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_project.Frames.Count > MaxFrames)
            {
                MessageBox.Show(this,
                    $"VRChat allows at most {MaxFrames} frames per emoji. " +
                    $"You currently have {_project.Frames.Count}.\n\n" +
                    "Use the Frames tab to Trim or Keep-every-Nth before saving.",
                    "Too many frames",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var dlg = new SaveFileDialog
            {
                Filter = "PNG|*.png",
                FileName = _project.ResolveFileName()
            })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    using (var sheet = SpriteSheetBuilder.Build(_project))
                        sheet.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    SetStatus($"Saved {dlg.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Save failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- helpers ---

        private void RefreshUi()
        {
            lstFrames.BeginUpdate();
            lstFrames.Items.Clear();
            for (int i = 0; i < _project.Frames.Count; i++)
                lstFrames.Items.Add($"#{i:000}  {_project.Frames[i].DurationMs} ms");
            lstFrames.EndUpdate();

            numTrimStart.Maximum = Math.Max(0, _project.Frames.Count);
            numTrimEnd.Maximum = Math.Max(0, _project.Frames.Count);
            if (numTrimEnd.Value == 0 && _project.Frames.Count > 0)
                numTrimEnd.Value = _project.Frames.Count;

            RefreshFileNameLabel();
        }

        private void RefreshFileNameLabel()
        {
            var (cols, rows, cell) = _project.ResolveGrid();
            string warning = _project.Frames.Count > MaxFrames
                ? $"   ⚠ {_project.Frames.Count} frames — VRChat max is {MaxFrames}"
                : "";
            lblFileName.Text =
                $"Output: {_project.ResolveFileName()}   ({cols}×{rows} grid, {cell}×{cell} cells){warning}";
            lblFileName.ForeColor = _project.Frames.Count > MaxFrames
                ? System.Drawing.Color.Firebrick
                : System.Drawing.SystemColors.ControlText;
        }

        private void SetStatus(string s) => statusLabel.Text = s;

        private static string SanitizeName(string s)
        {
            foreach (var c in Path.GetInvalidFileNameChars()) s = s.Replace(c, '_');
            return s.Replace(' ', '_');
        }

        // EM_SETCUEBANNER fallback so we get placeholder text on .NET Framework 4.7.2
        private const int EM_SETCUEBANNER = 0x1501;
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private void SetUrlPlaceholder(string text)
        {
            SendMessage(txtUrl.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }
    }
}
