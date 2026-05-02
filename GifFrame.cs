using System;
using System.Drawing;

namespace VRC_Gif_Maker
{
    public sealed class GifFrame : IDisposable
    {
        public Bitmap Image { get; set; }
        public int DurationMs { get; set; }

        public GifFrame(Bitmap image, int durationMs)
        {
            Image = image;
            DurationMs = durationMs;
        }

        public GifFrame Clone()
        {
            return new GifFrame((Bitmap)Image.Clone(), DurationMs);
        }

        public void Dispose()
        {
            Image?.Dispose();
            Image = null;
        }
    }
}
