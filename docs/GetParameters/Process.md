# Process (Process)

[Table of Content](../Home.md)  

~9 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

This plugin lets automation workflows retrieve parameters stored in the G4 Hub process scope, making values like temporary settings or session tokens available to every workflow on the hub. These values persist until the hub restarts, so workflows can share data without manual steps. It works like machine-level parameters but without OS restrictions, offering a simple cross-workflow sharing mechanism.

### Key Features and Functionality

| Feature                          | Description                                                                         |
|----------------------------------|-------------------------------------------------------------------------------------|
| Hub-level variable access        | Reads values stored at the G4 Hub process level for all workflows until restart.    |
| Temporary machine-level behavior | Acts like machine-scope parameters on any OS and resets when the hub restarts.      |
| Live updates during runtime      | Picks up changes to hub-scoped parameters immediately for running workflows.        |
| Output mapping                   | Exposes the fetched value in the `Result` output field for use by downstream steps. |

### Usages in RPA

| Use Case                         | Description                                                                                  |
|----------------------------------|----------------------------------------------------------------------------------------------|
| Shared settings across workflows | Provides a common source of values for all workflows running on the G4 Hub.                  |
| Dynamic configuration            | Loads temporary hub parameters into tasks so workflows adapt to changing values at runtime.  |
| Cross-workflow data exchange     | Uses hub-scoped variables to pass data between different workflows without external storage. |

### Usages in Automation Testing

| Use Case                 | Description                                                                                |
|--------------------------|--------------------------------------------------------------------------------------------|
| Shared test parameters   | Supplies consistent values to all test workflows on the hub for uniform test runs.         |
| Data-driven test inputs  | Feeds hub-scoped variables into tests to drive different scenarios without script changes. |
| Pre-run parameter checks | Verifies required hub variables are set before test execution to avoid failures.           |

## Examples

### Example No.1

### Retrieve Process-Level Environment Variable

This example demonstrates how to retrieve a process-level environment variable named `TempPath` using the Process plugin’s GetParameter action.
It retrieves the raw value of `TempPath` from the process scope for use in downstream workflows.
The retrieved value is available in the `Result` output field for subsequent steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Process",
    OnElement = "TempPath"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Process")
    .setOnElement("TempPath");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Process",
    onElement: "TempPath"
};
```

_**JSON**_

```js
{
    "pluginName": "Process",
    "onElement": "TempPath"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Process",
    "onElement": "TempPath"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement names the environment variable that workflows will fetch.
Workflows use this name to load the correct value when they run.
Using the right name ensures the workflow finds the intended setting every time.

## Scope

* Any