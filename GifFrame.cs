using System;
using System.Drawing;

namespace VRC_GIF_to_Emoji
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
