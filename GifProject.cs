using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace VRC_Gif_Maker
{
    public sealed class GifProject
    {
        public string Name { get; set; } = "Emoji";
        public List<GifFrame> Frames { get; } = new List<GifFrame>();
        public int TargetFps { get; set; } = 10;
        public bool AutoGrid { get; set; } = true;
        public int GridCols { get; set; } = 4;
        public int GridRows { get; set; } = 4;
        public Rectangle? Crop { get; set; }
        public RotateFlipType FlipRotate { get; set; } = RotateFlipType.RotateNoneFlipNone;

        public event EventHandler Changed;

        public void RaiseChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Replace(IEnumerable<GifFrame> frames)
        {
            foreach (var f in Frames) f.Dispose();
            Frames.Clear();
            Frames.AddRange(frames);
            Crop = null;
            FlipRotate = RotateFlipType.RotateNoneFlipNone;
            RaiseChanged();
        }

        public void Reverse()
        {
            Frames.Reverse();
            RaiseChanged();
        }

        public void Trim(int startInclusive, int endExclusive)
        {
            startInclusive = Math.Max(0, startInclusive);
            endExclusive = Math.Min(Frames.Count, endExclusive);
            if (startInclusive >= endExclusive) return;

            var keep = Frames.GetRange(startInclusive, endExclusive - startInclusive);
            for (int i = 0; i < Frames.Count; i++)
                if (i < startInclusive || i >= endExclusive) Frames[i].Dispose();
            Frames.Clear();
            Frames.AddRange(keep);
            RaiseChanged();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Frames.Count) return;
            Frames[index].Dispose();
            Frames.RemoveAt(index);
            RaiseChanged();
        }

        public void KeepEveryNth(int n)
        {
            if (n <= 1) return;
            var kept = new List<GifFrame>();
            for (int i = 0; i < Frames.Count; i++)
            {
                if (i % n == 0) kept.Add(Frames[i]);
                else Frames[i].Dispose();
            }
            Frames.Clear();
            Frames.AddRange(kept);
            RaiseChanged();
        }

        public void RotateFlipAll(RotateFlipType op)
        {
            foreach (var f in Frames) f.Image.RotateFlip(op);
            RaiseChanged();
        }

        // VRChat expects NxN grids where N is a power of 2 so that 1024/N is an integer.
        private static readonly int[] ValidGridSizes = { 1, 2, 4, 8, 16, 32 };

        public (int cols, int rows, int cell) ResolveGrid()
        {
            int n = Math.Max(1, Frames.Count);
            int cols, rows;
            if (AutoGrid)
            {
                int dim = 1;
                foreach (var d in ValidGridSizes)
                {
                    dim = d;
                    if (d * d >= n) break;
                }
                cols = dim;
                rows = dim;
            }
            else
            {
                cols = Math.Max(1, GridCols);
                rows = Math.Max(1, GridRows);
            }
            int cell = SpriteSheetBuilder.OutputSize / Math.Max(cols, rows);
            return (cols, rows, cell);
        }

        public string ResolveFileName()
        {
            string safe = string.IsNullOrWhiteSpace(Name) ? "Emoji" : Name.Trim();
            foreach (var c in Path.GetInvalidFileNameChars()) safe = safe.Replace(c, '_');
            return $"{safe}_{Frames.Count}frames_{TargetFps}fps.png";
        }
    }
}
