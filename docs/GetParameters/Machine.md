# Machine (Machine)

[Table of Content](../Home.md)  

~16 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]
> This plugin is supported on Windows machines only.

### Purpose

The primary purpose of the GetMachineParameter plugin is to retrieve machine-level environment variables. This allows for the extraction of environment-specific values within automation workflows.

### Key Features and Functionality

| Feature                    | Description                                                                                      |
|----------------------------|--------------------------------------------------------------------------------------------------|
| Retrieve Environment Value | Retrieves the value of a specified environment variable from the machine's environment settings. |
| Integration                | Can be used within other plugins to dynamically fetch machine-specific parameters.               |

### Usages in RPA

| Usage                      | Description                                                                            |
|----------------------------|----------------------------------------------------------------------------------------|
| Environment Configuration  | Fetch environment-specific configurations for use in automation workflows.             |
| Dynamic Data Handling      | Retrieve machine-level parameters dynamically during automation execution.             |
| System Diagnostics         | Use machine parameters to assess and respond to system state or configuration changes. |
| Security and Compliance    | Access machine environment variables for security settings and compliance checks.      |

### Usages in Automation Testing

| Usage                  | Description                                                                          |
|------------------------|--------------------------------------------------------------------------------------|
| Test Environment Setup | Configure test environments dynamically by retrieving environment variable values.   |
| Parameterized Testing  | Use machine-specific parameters to drive parameterized testing scenarios.            |
| Automated Monitoring   | Automate monitoring of environment variables to ensure consistency across test runs. |
| Resource Management    | Manage and allocate resources efficiently based on machine-level parameters.         |

## Examples

### Example No.1

This example demonstrates the usage of the `GetMachineParameter` plugin to retrieve the value of a machine-level environment variable named `MyMachineParam`.

| Field      | Description                                                                                                         |
|------------|---------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Machine`. This signifies the action of getting the parameter. |
| onElement  | Specifies the name of the environment variable, which is `MyMachineParam`.                                           |

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
### Example No.2

This example demonstrates the usage of the `GetMachineParameter` plugin within an automation flow to send the retrieved parameter value as keystrokes to an element.

| Field      | Description                                                                                                          |
|------------|----------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes. |
| argument   | Specifies the use of the `GetMachineParameter` plugin to fetch the environment variable value dynamically.           |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is identified by its CSS selector.          |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.              |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:MyMachineParam --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:MyMachineParam --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:MyMachineParam --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:MyMachineParam --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:MyMachineParam --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates the usage of the `GetMachineParameter` plugin to retrieve a machine-level environment variable without specifying any additional parameters.

| Field      | Description                                                                                                            |
|------------|------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Machine`. This signifies the action of getting the parameter. |
| onElement  | Specifies the name of the environment variable, which is `DefaultMachineParam`.                                        |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Machine",
    OnElement = "DefaultMachineParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Machine")
    .setOnElement("DefaultMachineParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Machine",
    onElement: "DefaultMachineParam"
};
```

_**JSON**_

```js
{
    "pluginName": "Machine",
    "onElement": "DefaultMachineParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Machine",
    "onElement": "DefaultMachineParam"
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

The `OnElement` property specifies the name of the environment variable to be retrieved.
