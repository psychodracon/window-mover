# window-mover

[![CI](https://github.com/psychodracon/window-mover/actions/workflows/ci.yaml/badge.svg)](https://github.com/psychodracon/window-mover/actions/workflows/ci.yaml)

A small Windows tray app that puts windows where you want them, every time. Describe a window by its
title, class or process, and Window Mover moves, resizes and restyles it whenever it appears, so your
layout survives docking, undocking, sleep and restarting applications.

It also gives meeting apps global hotkeys: mute your microphone or turn off the camera in a call
without switching to its window first.

## Features

- **Rules per window.** Match by window title (equals, begins with, ends with, contains), window class
  or process name, and optionally by the parent window.
- **Position, size and style.** Each rule can set the position and size, remove the title bar and
  borders, and keep the window always on top.
- **Keeps it there.** Rules are applied again at a set interval, so a window that jumps back is moved
  again.
- **Meeting hotkeys.** Global hotkeys that toggle the microphone, sound or camera in the app a rule
  matches, and press the microphone and camera buttons of the new Microsoft Teams directly.
- **Updates itself** from this repository's releases.

## Requirements

- 64-bit Windows 10 or later. The .NET runtime is included.
- To move the windows of a program that runs as administrator, Window Mover has to run as
  administrator too.

## Installation

Download one of these from the [latest release](https://github.com/psychodracon/window-mover/releases/latest):

- **WindowMover-win-Setup.exe** installs the app and creates the shortcuts.
- **WindowMover-win-Portable.zip** runs from any folder: unpack it and start `WindowMover.exe`.

Window Mover starts in the notification area (tray) and offers new versions when it starts. Settings
are saved in `%LOCALAPPDATA%\WindowMover`.

## Usage

### Pin a window

1. Arrange the window the way you want it, and note its title, or find its class and process name with
   a tool such as Spy++ or Task Manager.
2. Right-click the tray icon, choose **Settings** and, on **Handle list**, click **Add**.
3. Give the rule a name, and under **Search using following attributes** tick and fill in what
   identifies the window, for example **Window name** *contains* `Visual Studio Code`.
4. Under **Modify window parameters**, tick **Change position** and **Change size** and enter the
   coordinates and size in pixels, and tick **Remove borders** or **Always on top** if you want them.
5. Click **OK**, then **Apply**.

The window moves on the next pass. **Set positions** in the tray menu turns all rules on or off, and
the **Active** column turns one rule off. **Others → Window position recovery frequency** sets how
often, in milliseconds, rules are applied again.

### Meeting hotkeys

1. In **Settings → Others → Hotkey settings**, click **Record** next to **Toggle mute**, **Toggle
   sound** or **Toggle camera** and press the global key combination you want.
2. In a rule that matches your meeting app, tick the same toggle and record the meeting app's own
   shortcut for it (for example `Ctrl+Shift+M` for mute).

Pressing the global hotkey sends the app's shortcut to its window and gives focus back to the window
you were in. For the new Microsoft Teams, tick **Enable Microsoft Teams support** under **Others**
instead; Window Mover then presses Teams' microphone and camera buttons.

## Development

Needs Windows and the .NET SDK from `global.json`.

```sh
dotnet build WindowMover.slnx
dotnet run --project WindowMover/WindowMover.csproj
```

## Releases

Each release is published on the [releases](https://github.com/psychodracon/window-mover/releases) page
with its changes; [CHANGELOG.md](CHANGELOG.md) lists them all.

## License

Copyright (C) Kamil Ganczarek. Licensed under the GNU General Public License, version 3 or (at your
option) any later version. See [LICENSE](LICENSE).
