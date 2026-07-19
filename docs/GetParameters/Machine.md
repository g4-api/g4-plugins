# Machine (Machine)

[Table of Content](../Home.md)  

~9 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

This plugin lets automation workflows retrieve system-wide settings defined on Windows computers. It reads environment variables defined for every user under the machine scope in the Windows registry. By pulling shared values like paths or feature flags, workflows can run with the correct setup without extra steps.

### Key Features and Functionality

| Feature                | Description                                                           |
|------------------------|-----------------------------------------------------------------------|
| Global variable access | Reads values defined for all users on the Windows machine.            |
| Empty value handling   | Returns an empty string when the variable is missing or has no value. |
| Result output field    | Makes the fetched value available for use in later workflow steps.    |

### Usages in RPA

| Use Case                     | Description                                                                               |
|------------------------------|-------------------------------------------------------------------------------------------|
| Global configuration loading | Loads shared Windows settings like paths or service URLs so workflows match system setup. |
| Live value retrieval         | Gets the latest Windows environment values at runtime for up-to-date workflow behavior.   |
| System health checks         | Reads global settings to verify required variables are set and correct.                   |

### Usages in Automation Testing

| Use Case                 | Description                                                                                 |
|--------------------------|---------------------------------------------------------------------------------------------|
| Test setup configuration | Configures test runs using Windows system-wide settings like API addresses and credentials. |
| Data-driven tests        | Uses Windows environment values to run tests with different inputs automatically.           |
| Pre-run checks           | Verifies required Windows variables exist before starting tests to avoid failures.          |

## Examples

### Example No.1

### Retrieve Machine-Level Environment Variable

This example demonstrates how to retrieve a machine-level environment variable named `MyMachineParam` using the Machine plugin’s GetParameter action.
It returns the raw value of the `MyMachineParam` variable from the machine scope for use in downstream workflows.
The retrieved value is available in the `Result` output field for subsequent steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Machine",
    OnElement = "MyMachineParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Machine")
    .setOnElement("MyMachineParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Machine",
    onElement: "MyMachineParam"
};
```

_**JSON**_

```js
{
    "pluginName": "Machine",
    "onElement": "MyMachineParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Machine",
    "onElement": "MyMachineParam"
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

OnElement names the environment variable to retrieve.
Workflows use this name to find the right value when they run.

## Scope

* Windows