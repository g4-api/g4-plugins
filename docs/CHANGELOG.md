# Changelog

All notable changes to G4 Plugins are documented in this file. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## Unreleased

### Added

- `InvokeMiddleClick` middle-clicks an element, or the current pointer position, through the WebDriver Actions API.
- `InvokeUser32MiddleClick` sends a native Windows middle click at viewport coordinates or on a UI Automation element.
- `InvokeScroll` accepts the `--Relative` switch to scroll by the `Left` and `Top` offsets from the current position.

### Changed

- `SendUser32KeyboardKey` lists the `Win`, `LWin`, and `RWin` Windows keys in its `Key` parameter values.
- The InputActions manifests and `InvokeInputActions` name their current category and icon in their questions and
  answers.
- The generated plugin pages in `docs/` are regenerated from the current manifests.
- The test projects reference `G4.Api` version `2026.11.25.77`.
- The plugins use the engine packages `2026.11.25.111` and the `G4.Abstraction.*` packages `2026.11.25.26`. The
  engine's documentation generator now escapes `|` in table cells and writes no trailing spaces in nested examples,
  so the regenerated pages pass Markdown lint.
- The `SetSwitchCase` use-case table in its manifest description is aligned, so its generated page renders one cell
  per column.
