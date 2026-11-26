# G4 Plugins

> The official, production-grade plugin collection maintained by the G4 team.

Welcome to G4 Plugins. This repository contains the plugins that bring reusable actions, assertions, integrations,
data operations, and user-interface automation to the G4 ecosystem.

If you use G4 Hub or [G4 Sandbox](https://github.com/g4-api/g4-sandbox), you already have these plugins. They ship as
part of the G4 experience, so there is nothing extra to download or configure before you start building automation
workflows.

The repository is also a practical place to learn how G4 plugins are built. Explore it for production-tested
implementations, working examples, reusable patterns, and ideas for your own extensions.

## Why this repository exists

- **Use trusted building blocks.** The plugins are maintained by the G4 team and exercised by unit and integration
  test suites as part of the release workflow.
- **Learn from real implementations.** Each plugin demonstrates how source code, manifests, parameters, and tests fit
  together in a working G4 extension.
- **Discover what G4 can do.** Browse ready-made capabilities for general automation, user-interface interactions, and
  Google services.
- **Build with confidence.** Use the repository as a reference when creating a custom plugin or embedding G4 plugins in
  your own implementation.

## Plugin packages

The collection is organized into three NuGet packages:

| Package | What it provides | Source | NuGet |
| --- | --- | --- | --- |
| `G4.Plugins.Common` | Platform-agnostic actions, assertions, data collectors, HTTP methods, parameters, macros, operators, and transformers. | [Common source](./src/G4.Plugins.Common) | [Common package](https://www.nuget.org/packages/G4.Plugins.Common/) |
| `G4.Plugins.Ui` | Browser, mobile, and Windows user-interface actions, assertions, content readers, and extraction scopes. | [UI source](./src/G4.Plugins.Ui) | [UI package](https://www.nuget.org/packages/G4.Plugins.Ui/) |
| `G4.Plugins.Google` | Integrations for Google Calendar, Gmail messages, and Google Tasks. | [Google source](./src/G4.Plugins.Google) | [Google package](https://www.nuget.org/packages/G4.Plugins.Google/) |

## Use G4 Plugins

### With G4 Hub or G4 Sandbox

No installation is required. G4 Hub and G4 Sandbox include the plugin collection and make it available to your G4
automation environment.

Open the [plugin documentation](./docs/Home.md) to browse the available capabilities and find the plugin that matches
your workflow.

### In a custom implementation

The packages target .NET 10 and are available from NuGet. Add one or more packages when you are building a custom host,
integration, or extension outside the standard G4 Hub and G4 Sandbox distributions:

```powershell
dotnet add package G4.Plugins.Common
dotnet add package G4.Plugins.Ui
dotnet add package G4.Plugins.Google
```

The commands intentionally omit a version so NuGet can select the current stable release that is compatible with your
project. Install only the packages your implementation needs.

## Explore the plugin catalog

The [API documentation](./docs/Home.md) is the best starting point when you want to discover a capability. Its catalog
includes:

- Actions for browser control, input, navigation, flow control, HTTP requests, logging, and parameters.
- Assertions for pages, elements, windows, alerts, keyboards, and text.
- Data collectors for CSV, JSON, and XML sources.
- Macros, operators, transformers, content readers, and extraction scopes.

Each catalog entry links to focused documentation for that plugin, making it easy to move from an idea to the relevant
building block.

## Learn from the source

Plugin authors can use the source as a set of implementation references rather than starting from a blank project. The
package folders show the conventions used by the G4 team for plugin classes, manifests, supporting abstractions, and
tests.

Start with the package closest to your use case, compare its implementation with the matching documentation, and use
the same patterns as a foundation for your own plugin. The examples here are production code, but they are also meant
to be read, adapted, and learned from.

## Build and test locally

You do not need to clone this repository to use the plugins. Clone it only when you want to inspect the implementation,
experiment with changes, or run the test suites yourself. You will need Git and the .NET 10 SDK.

1. Clone the repository.

    ```powershell
    git clone https://github.com/g4-api/g4-plugins.git
    cd g4-plugins
    ```

2. Run the unit tests with the repository settings.

    ```powershell
    dotnet test ./src/G4.UnitTests/G4.UnitTests.csproj --settings ./test/Settings/Default.runsettings
    ```

3. Configure any required browser, grid, or external-service values in
   [`Default.runsettings`](./test/Settings/Default.runsettings), then run the integration tests.

    ```powershell
    dotnet test ./src/G4.IntegrationTests/G4.IntegrationTests.csproj --settings ./test/Settings/Default.runsettings
    ```

The automated [release pipeline](./.github/workflows/release-pipeline.yml) builds the solution and runs unit and
Microsoft Edge integration tests before publishing the NuGet packages. A failed test stops the release.

### Local-only tests

Tests that need something a hosted runner does not have carry `[TestCategory("LocalOnly")]`. The release pipeline
excludes them with `TestCategory!=LocalOnly`; run them on your workstation.

| Tests | What they need |
| --- | --- |
| Machine-scope cases of `CopyParameter`, `GetParameter` and `RegisterParameter` | An elevated (administrator) prompt, because they write Machine environment variables. |
| Live UIA tests (`UiaDriver` category) | A running UIA driver server (2026.11.26.46 or later) and a Windows desktop. Set `Uia.DriverServer`, and the test application paths `Uia.ClickApplication` and `Uia.DragAndDropApplication`, in the run settings. Without them the tests report Inconclusive. |

The live UIA tests drive two small test applications in `test/Apps`. Build them once and point the run settings at
the executables:

| Application | Run setting | Used by |
| --- | --- | --- |
| `test/Apps/UiaClickLab` (Windows Forms) | `Uia.ClickApplication` | `User32ClickLiveTests` |
| `test/Apps/UiaDragDropLab` (WPF) | `Uia.DragAndDropApplication` | The live `InvokeUser32DragAndDrop` tests |

```powershell
dotnet build ./test/Apps/UiaClickLab/UiaClickLab.csproj
dotnet build ./test/Apps/UiaDragDropLab/UiaDragDropLab.csproj
```

```xml
<Parameter name="Uia.DriverServer" value="http://localhost:5555" />
<Parameter name="Uia.ClickApplication" value="<repository>\test\Apps\UiaClickLab\bin\Debug\net10.0-windows\UiaClickLab.exe" />
<Parameter name="Uia.DragAndDropApplication" value="<repository>\test\Apps\UiaDragDropLab\bin\Debug\net10.0-windows\UiaDragDropLab.exe" />
```

Each application writes what it received to a log next to its executable (`clicks.log`, `events.log`), which shows
whether an input reached the window when a live test fails.

```powershell
dotnet test ./src/G4.UnitTests/G4.UnitTests.csproj --settings ./test/Settings/Local.runsettings --filter "TestCategory=LocalOnly"
```

## G4 ecosystem

G4 Plugins is one part of a broader collection of automation tools:

| Project | Where to go |
| --- | --- |
| G4 repositories | [Explore the official G4 organization](https://github.com/orgs/g4-api/repositories) |
| G4 Services | [Manage templates, environments, integrations, and automation workflows](https://github.com/g4-api/g4-services) |
| G4 Sandbox | [Create reproducible local G4 environments](https://github.com/g4-api/g4-sandbox) |

Whether you are using the built-in plugins, studying their implementation, or designing something new, you are welcome
to explore the code and make it part of your G4 journey.

## License

G4 Plugins is available under the [Apache License 2.0](./LICENSE).

## Contributing and builds

Build and test the solution from the `src/` folder with the .NET 10 SDK. The unit tests need the settings file:
`dotnet test --settings test/Settings/Local.runsettings`. The release pipeline publishes the NuGet packages from the
`main` branch. Notable changes are listed in the [changelog](./docs/CHANGELOG.md).
