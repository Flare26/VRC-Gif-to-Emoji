using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace VRC_GIF_to_Emoji
{
    public static class GifLoader
    {
        // PropertyTagFrameDelay: array of 4-byte ints, hundredths-of-a-second per frame.
        private const int PropertyTagFrameDelay = 0x5100;

        private static readonly HttpClient Http = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("VRC-GIF-to-Emoji/1.0");
            return client;
        }

        public static async Task<List<GifFrame>> LoadAsync(string source)
        {
            byte[] data;
            if (Uri.TryCreate(source, UriKind.Absolute, out var uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                data = await Http.GetByteArrayAsync(uri).ConfigureAwait(false);
            }
            else
            {
                if (!File.Exists(source))
                    throw new FileNotFoundException("Could not find file", source);
                data = File.ReadAllBytes(source);
            }
            return DecodeFrames(data);
        }

        private static List<GifFrame> DecodeFrames(byte[] data)
        {
            var result = new List<GifFrame>();
            using (var ms = new MemoryStream(data))
            using (var img = Image.FromStream(ms))
            {
                int frameCount = SafeFrameCount(img);
                int[] delays = TryReadDelays(img, frameCount);

                if (frameCount <= 1)
                {
                    result.Add(new GifFrame(CloneFrame(img), 100));
                    return result;
                }

                for (int i = 0; i < frameCount; i++)
                {
                    img.SelectActiveFrame(FrameDimension.Time, i);
                    int delay = delays != null && i < delays.Length ? delays[i] * 10 : 100;
                    if (delay <= 0) delay = 100;
                    result.Add(new GifFrame(CloneFrame(img), delay));
                }
            }
            return result;
        }

        private static int SafeFrameCount(Image img)
        {
            try { return img.GetFrameCount(FrameDimension.Time); }
            catch { return 1; }
        }

        private static Bitmap CloneFrame(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            return bmp;
        }

        private static int[] TryReadDelays(Image img, int count)
        {
            try
            {
                var prop = img.GetPropertyItem(PropertyTagFrameDelay);
                if (prop?.Value == null || prop.Value.Length < count * 4) return null;
                var delays = new int[count];
                for (int i = 0; i < count; i++)
                    delays[i] = BitConverter.ToInt32(prop.Value, i * 4);
                return delays;
            }
            catch
            {
                return null;
            }
        }
    }
}
