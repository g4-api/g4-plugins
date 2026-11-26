# Changelog

All notable changes to G4 Plugins are documented in this file. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## Unreleased

### Added

- The live UIA tests have their test applications in the repository: `test/Apps/UiaClickLab` for the click tests and
  `test/Apps/UiaDragDropLab` for the drag-and-drop tests. The README shows how to build them and set
  `Uia.ClickApplication` and `Uia.DragAndDropApplication`.

### Changed

- The live click test is split into `InvokeUser32MiddleClickLiveTest` and `InvokeUser32ContextClickLiveTest`, each
  with its own application instance and session. They need UIA driver server 2026.11.26.46 or later, which brings a
  new session's window to the front.
- The test projects use `G4.Api` 2026.11.25.80, which resolves the same engine and plugin versions as the plugins.

## 2026.11.25.178

### Added

- `InvokeLongClick` long-presses an element, or the current touch position, with a W3C touch pointer for
  `--Duration` milliseconds (1000 by default). The G4 Android recorder records long clicks as this action.
- `SwitchActivity` starts an Android activity from `--Package` and `--Activity` through the Appium UiAutomator2
  `mobile: startActivity` command. The G4 Android recorder records activity changes as this action.
- A live UIA test checks that `InvokeUser32MiddleClick` and `InvokeUser32ContextClick` press the middle and the right
  button on an element.

### Changed

- The release pipeline fails when a unit or integration test fails, and publishes only after the tests pass. Before,
  it ignored the test exit code.
- Tests that need administrator rights or a live UIA driver carry the `LocalOnly` category, which the release
  pipeline excludes. The Machine-scope parameter cases are split into their own test methods, and `CopyParameter`
  cleanup no longer fails in a session without administrator rights, so the other parameter tests pass there. The
  live drag-and-drop tests use the category instead of `[Ignore]`, so they can run on a workstation.
- Every generated plugin page in `docs/` is regenerated with the current engine generator.
- The plugins use the engine packages and `G4.Abstraction.WebDriver` 2026.11.25.113 (the WebDriver abstraction now
  ships from the engine), `G4.Abstraction.Cli` and `G4.Abstraction.Logging` 2026.11.25.27, and the test projects use
  `G4.Api` 2026.11.25.78.

### Fixed

- An `Assert` manifest example no longer sets `regularExpression` to `null`, so every manifest validates against the
  plugin manifest schema.

## 2026.11.25.177

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
