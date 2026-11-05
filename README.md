# window-mover

A small Windows tray app that puts windows where you want them, every time. Describe a window by its
title, class or process, and Window Mover moves, resizes and restyles it whenever it shows up, so your
layout survives docking, undocking and restarting applications.

## What it does

- **Rules per window**: match by title (exact, starts with, ends with, contains), window class, process
  name or text, and optionally by the parent window. Each rule can set the position and size, remove the
  title bar and borders (borderless), and keep the window always on top.
- **Always on**: rules are re-applied continuously, so a window that jumps back is moved again.
- **Hotkeys**: global hotkeys to toggle mute, sound and camera.

## Install

Download from the [releases](https://github.com/psychodracon/window-mover/releases) page:

- **WindowMover-win-Setup.exe**: installs the app and creates the shortcuts.
- **WindowMover-win-Portable.zip**: unpack anywhere and run `WindowMover.exe`.

Requires 64-bit Windows 10 or later; the .NET runtime is bundled. The app updates itself from GitHub
releases. Windows of programs running as administrator can only be moved if Window Mover runs elevated
too.

## Build from source

Needs the .NET SDK from `global.json`.

```sh
dotnet build WindowMover.slnx
dotnet run --project WindowMover/WindowMover.csproj
```

## Releases

A push to `main` bumps the version, updates `CHANGELOG.md` from the conventional commits and publishes
the installer as a GitHub release.

## License

Copyright (C) Kamil Ganczarek. Licensed under the GNU General Public License, version 3 or (at your option) any later version. See [LICENSE](LICENSE).
