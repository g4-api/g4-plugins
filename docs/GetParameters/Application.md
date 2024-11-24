# Application (Application)

[Table of Content](../Home.md)  

~15 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `GetApplicationParameter` plugin is to fetch application parameters that are shared across all automation instances, providing flexibility in configuration based on different environments. This plugin allows the retrieval of parameters like connection strings, API keys, or other configuration settings essential for automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                               |
|------------------------------- |-----------------------------------------------------------------------------------------------------------|
| Parameter Retrieval            | Fetches application parameters from specified environments.                                               |
| Environment-Based Parameters   | Supports retrieval of parameters specific to different environments (e.g., Prod, Dev).                    |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically use retrieved parameters in various actions. |

### Usages in RPA

| Usage                         | Description                                                                                            |
|------------------------------ |--------------------------------------------------------------------------------------------------------|
| Dynamic Configuration         | Retrieve and use configuration settings dynamically based on the environment.                          |
| Centralized Parameter Storage | Use a centralized location for storing and accessing parameters across different automation instances. |

### Usages in Automation Testing

| Usage                        | Description                                                                                               |
|------------------------------|-----------------------------------------------------------------------------------------------------------|
| Environment-Specific Testing | Retrieve parameters specific to test environments, enabling more accurate and environment-specific tests. |
| Configuration Management     | Simplify configuration management by fetching parameters directly within test scripts.                    |

## Examples

### Example No.1

This example demonstrates the usage of the `Application` plugin to fetch a parameter named `ConnectionString` from the `Prod` environment and use it directly.

| Field      | Description                                                            |
|------------|------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Application`. |
| argument   | Specifies the environment from which to fetch the parameter.           |
| onElement  | Specifies the name of the parameter to be fetched.                     |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Application",
    Argument = "{{$ --Environment:Prod}}",
    OnElement = "ConnectionString"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Application")
    .setArgument("{{$ --Environment:Prod}}")
    .setOnElement("ConnectionString");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Application",
    argument: "{{$ --Environment:Prod}}",
    onElement: "ConnectionString"
};
```

_**JSON**_

```js
{
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod}}",
    "onElement": "ConnectionString"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod}}",
    "onElement": "ConnectionString"
}
```
### Example No.2

This example demonstrates the usage of the `Get-Parameter` macro to fetch a parameter named `ConnectionString` from the `Prod` environment and use it in a `SendKeys` action.

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
    Argument = "{{$Get-Parameter --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:ConnectionString --Scope:Application --Environment:Prod}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates the usage of the `Get-Parameter` macro to fetch a parameter named `ConnectionString` from the default `SystemParameters` environment and use it in a `SendKeys` action.

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
    Argument = "{{$Get-Parameter --Name:ConnectionString --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:ConnectionString --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:ConnectionString --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ConnectionString --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ConnectionString --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Expression        |

The `Argument` property specifies the environment from which to fetch the parameter.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The `OnElement` property specifies the name of the parameter to be retrieved.

## Parameters

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the environment from which to fetch the parameter. If not specified, the `SystemParameters` environment will be used.
