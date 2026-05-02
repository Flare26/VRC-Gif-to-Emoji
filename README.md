# VRC GIF to Emoji

[![Latest Release](https://img.shields.io/github/v/release/Flare26/VRC-Gif-to-Emoji?include_prereleases&sort=semver)](https://github.com/Flare26/VRC-Gif-to-Emoji/releases/latest)
[![Downloads](https://img.shields.io/github/downloads/Flare26/VRC-Gif-to-Emoji/total)](https://github.com/Flare26/VRC-Gif-to-Emoji/releases)
[![Platform](https://img.shields.io/badge/platform-Windows-blue)](#)
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)](#)

A small Windows desktop tool that converts animated GIFs (and static images) into VRChat-compatible animated emoji sprite sheets. It handles the import, frame editing, cropping, and layout into the **1024×1024 power-of-two grid** that VRChat's emoji uploader expects, and auto-names the output to match VRChat's filename convention (`Name_NNframes_FFfps.png`).

Built because the existing online tools either couldn't pick the right grid size, didn't crop how you wanted, or required uploading your assets to a third party.

---

## Features

- **Import** from a local file (browse or drag & drop) or a remote URL
- **Live animated preview** at the configured FPS, with checkerboard transparency
- **Pan & zoom crop** — scroll to zoom (1×–16×), click-drag to pan; what you see is exactly what gets saved
- **Frame editing** — trim a range, reverse, delete individual frames, keep every Nth frame to thin a long GIF
- **Effects** — rotate 90° left/right, flip horizontal/vertical
- **Frame rate control** — 1–60 FPS
- **Auto grid sizing** — picks the smallest VRChat-valid power-of-two grid (2×2, 4×4, 8×8, 16×16, 32×32) so cell edges always land on integer pixel boundaries
- **Manual grid override** when you want a specific layout
- **Optional grid overlay** in the preview to see exactly where each cell lands
- **VRChat-compatible filename** baked in: `Name_NNframes_FFfps.png`

---

## Download

Grab the latest portable build from the [**Releases**](https://github.com/Flare26/VRC-Gif-to-Emoji/releases) page. Extract the zip and run `VRC GIF to Emoji.exe` — no installer.

**Requirements:**
- Windows 10 1803 or newer (ships with .NET Framework 4.7.2 by default)
- ~50 MB disk space

---

## Usage

1. **Load a source.** Drag a GIF/PNG onto the window, paste a URL into the address bar and click *Load URL*, or use *Browse…*
2. **Crop in the preview.** Scroll to zoom in, click-drag to pan. The white border shows the actual square that will be exported — the dimmed area gets cut off. Use the *Reset Pan / Zoom* button on the **Effects** tab to return to a centered view.
3. **Trim or thin frames** on the **Frames** tab if your GIF is too long for VRChat's 64-frame limit. *Keep every Nth* is the fastest way to halve or quarter a long animation.
4. **Set FPS** on the **Speed** tab. VRChat plays your emoji back at this rate.
5. **Pick output settings** on the **Output** tab: emoji name, auto vs manual grid, optional grid overlay.
6. **Save Sprite Sheet…** — the suggested filename already encodes the frame count and FPS the way VRChat parses on upload.

### Uploading to VRChat

1. Sign in at [vrchat.com](https://vrchat.com), open *Inventory* → *Upload A New Emoji*.
2. Upload the saved PNG. VRChat reads the frame count and FPS from the filename suffix.
3. The "Set the frame count and frame rate" preview should show your animation cleanly tiled — if frames look split or shifted, the grid wasn't power-of-two (this app handles that for you).

---

## Known limitations

- **Complex GIF disposal modes**: GIF decoding uses GDI+, which can mishandle some GIFs that use partial-frame updates with transparent backgrounds. If your GIF imports with smearing or wrong colors, re-export it with all-frame disposal from a tool like ezgif's "optimize" feature, or open a fresh issue with the source GIF attached.
- **No manual rectangle crop yet** — only pan/zoom. Most use cases are covered by the existing controls; manual rectangle crop is on the list.
- **No color/effect filters** (brightness, contrast, hue) — out of scope for now.

---

## Building from source

### Prerequisites

- **Visual Studio 2022** or later, with the **.NET desktop development** workload
- **.NET Framework 4.7.2 SDK and targeting pack** (Visual Studio Installer → *Individual Components*)

### Build

```bash
git clone https://github.com/Flare26/VRC-Gif-to-Emoji.git
cd VRC-Gif-to-Emoji
```

Open `VRC GIF to Emoji.slnx` in Visual Studio and press **F5**, or from the command line:

```bash
msbuild "VRC GIF to Emoji.csproj" /t:Build /p:Configuration=Release
```

The output exe lands in `bin\Release\VRC GIF to Emoji.exe`. It's a single self-contained executable with no DLL dependencies beyond the .NET Framework runtime.

### Project layout

```
├─ Program.cs                  Entry point, TLS pin, application bootstrap
├─ Form1.cs / .Designer.cs     Main window: top bar, preview, tools tabs, status
├─ PreviewControl.cs           Animated preview + pan/zoom crop interaction
├─ GifFrame.cs                 Frame model (Bitmap + duration)
├─ GifLoader.cs                URL/file → frames (HttpClient + GDI+ FrameDimension.Time)
├─ GifProject.cs               Project state (frames, name, FPS, grid, crop, rotate/flip)
│                              Owns the auto-grid logic that snaps to VRChat's valid grids.
├─ SpriteSheetBuilder.cs       Composes the final 1024×1024 ARGB PNG
├─ Properties/                 AssemblyInfo, Resources, Settings
└─ .github/workflows/          CI: manual-trigger release pipeline
```

The architecture is a simple owner/event pattern: `GifProject` is the single source of truth, fires a `Changed` event, and the UI subscribes. `SpriteSheetBuilder` is a pure function over `GifProject`.

### Releasing

Releases are built and published by GitHub Actions. The workflow is **manual-trigger only**: go to the **Actions** tab → *Build & Release* → *Run workflow*. It auto-increments the patch version from the latest `v*` tag, stamps it into `AssemblyInfo.cs`, builds Release, packages the portable zip, creates the tag, and publishes a GitHub Release with auto-generated notes.

For minor/major bumps, push a tag like `v1.1.0` or `v2.0.0` first; the next workflow run will increment from there.

---

## Contributing

Contributions are welcome. If it's a small fix, just open a PR. If it's a larger change or new feature, open an issue first to discuss the approach.

**Good first issues:**
- Manual rectangle crop overlay (the `GifProject.Crop` rect plumbing is already in place)
- Color filters (brightness/contrast/saturation) on the **Effects** tab
- Per-frame thumbnails in the frames list
- Replace the GDI+ GIF decoder with a more robust one for complex GIF disposal handling

When opening an issue, please include:
- The source GIF/image (or a link)
- A screenshot of the preview vs. expected result
- Your Windows version

---

## License

This project is released under the [MIT License](LICENSE) — see the LICENSE file for details. (If no LICENSE file is present yet, treat the source as "all rights reserved" pending one being added.)

---

## Acknowledgments

- [VRChat](https://vrchat.com) for the animated emoji feature and the [sprite-sheet spec](https://docs.vrchat.com/docs/animated-emoji)
- The [ezgif.com](https://ezgif.com) toolset, which inspired the editing UX
