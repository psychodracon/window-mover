# window-mover

Windows tray app that moves, resizes and restyles windows by rules whenever they appear. C# WinForms,
Windows-only. Features and installation are in [README.md](README.md).

## Commands

```sh
dotnet build WindowMover.slnx --no-incremental
```

Warnings are errors, and incremental builds can wrongly report no warnings. Off Windows, add
`-p:EnableWindowsTargeting=true`; CI on `windows-latest` is the reference build. There are no tests.

## Conventions

- New user-visible strings go into both `WindowMover/Resources/en-US.json` and `pl-PL.json`.
- The `vpk` tool (`.config/dotnet-tools.json`) and the `Velopack` package stay on the same version.

## Git and releases

- On release, git-cliff builds `CHANGELOG.md` from the commit subjects and CI bumps `<Version>` in
  `Directory.Build.props`; edit neither by hand.
- The in-app updater reads this repository's GitHub releases, so the repository must stay public.

## Boundaries

- **Ask first:** changing the settings types in `Classes/Settings.cs` (saved settings must still load);
  changing Velopack or updater configuration.
