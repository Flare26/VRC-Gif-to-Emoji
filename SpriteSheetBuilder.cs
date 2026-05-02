using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace VRC_Gif_Maker
{
    public static class SpriteSheetBuilder
    {
        public const int OutputSize = 1024;

        public static Bitmap Build(GifProject project)
        {
            var (cols, rows, cell) = project.ResolveGrid();
            var sheet = new Bitmap(OutputSize, OutputSize, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(sheet))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                int max = Math.Min(project.Frames.Count, cols * rows);
                for (int i = 0; i < max; i++)
                {
                    int col = i % cols;
                    int row = i / cols;
                    DrawFrame(g, project, project.Frames[i], col * cell, row * cell, cell);
                }
            }
            return sheet;
        }

        private static void DrawFrame(Graphics g, GifProject project, GifFrame frame, int x, int y, int cell)
        {
            var src = frame.Image;
            var crop = project.Crop ?? CropToSquare(src);

            // Render to a temp square so RotateFlip can be applied without skewing the destination cell.
            using (var square = new Bitmap(cell, cell, PixelFormat.Format32bppArgb))
            {
                using (var sg = Graphics.FromImage(square))
                {
                    sg.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    sg.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    sg.SmoothingMode = SmoothingMode.HighQuality;
                    sg.Clear(Color.Transparent);
                    sg.DrawImage(src, new Rectangle(0, 0, cell, cell), crop, GraphicsUnit.Pixel);
                }
                if (project.FlipRotate != RotateFlipType.RotateNoneFlipNone)
                    square.RotateFlip(project.FlipRotate);
                g.DrawImage(square, x, y, cell, cell);
            }
        }

        public static Rectangle CropToSquare(Image src)
        {
            int side = Math.Min(src.Width, src.Height);
            int x = (src.Width - side) / 2;
            int y = (src.Height - side) / 2;
            return new Rectangle(x, y, side, side);
        }
    }
}
