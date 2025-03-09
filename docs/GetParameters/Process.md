# Process (Process)

[Table of Content](../Home.md)  

~12 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `GetProcessParameter` plugin is to fetch environment variables that are specific to the current process. This allows for the dynamic retrieval of parameters that may vary during the execution of a process, such as temporary paths, session-specific tokens, or other environment-specific settings.

### Key Features and Functionality

| Feature                        | Description                                                                                               |
|------------------------------- |-----------------------------------------------------------------------------------------------------------|
| Parameter Retrieval            | Fetches environment variables specific to the current process.                                            |
| Dynamic Parameter Handling     | Retrieves process-specific parameters that can change during runtime.                                     |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically use retrieved parameters in various actions. |

### Usages in RPA

| Usage                  | Description                                                                                                 |
|------------------------|-------------------------------------------------------------------------------------------------------------|
| Dynamic Configuration  | Retrieve and use process-specific environment variables dynamically based on the process execution context. |
| Temporary Data Storage | Use process-level environment variables for temporary data storage and retrieval within a process.          |

### Usages in Automation Testing

| Usage                      | Description                                                                                          |
|----------------------------|------------------------------------------------------------------------------------------------------|
| Session-Specific Testing   | Retrieve parameters specific to the test session, enabling more accurate and session-specific tests. |
| Dynamic Test Configuration | Simplify test configuration by fetching process-specific parameters directly within test scripts.    |

## Examples

### Example No.1

This example demonstrates the usage of the `Process` plugin to fetch a parameter named `TempPath` directly.

| Field      | Description                                                        |
|------------|--------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Process`. |
| onElement  | Specifies the name of the parameter to be fetched.                 |

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
### Example No.2

This example demonstrates the usage of the `Get-Parameter` macro to fetch a parameter named `TempPath` from the process environment and use it in a `SendKeys` action.

| Field      | Description                                                                                             |
|------------|---------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`.                                     |
| argument   | Specifies the use of the `Get-Parameter` macro to fetch the parameter value dynamically.                |
| onElement  | Specifies the target element on which the keystrokes will be sent, identified by its CSS selector.      |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:TempPath --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:TempPath --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:TempPath --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:TempPath --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:TempPath --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
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

Specifies the name of the environment variable to be fetched from the process environment.

## Scope

* Any