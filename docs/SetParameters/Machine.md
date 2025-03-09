# Machine (Machine)

[Table of Content](../Home.md)  

~18 min · SetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]
> This plugin is supported on Windows machines only.

### Purpose

The primary purpose of the `SetMachineParameter` plugin is to set machine-level parameters that are specific to the machine where the automation is running. 
This allows for persistent configuration management, enabling dynamic updates to parameters such as machine-specific settings or configurations essential for automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                            |
|--------------------------------|--------------------------------------------------------------------------------------------------------|
| Parameter Setting              | Sets machine-level parameters that persist across automation sessions on the same machine.             |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically set parameters based on automation needs. |

### Usages in RPA

| Usage                        | Description                                                                                |
|------------------------------|--------------------------------------------------------------------------------------------|
| Dynamic Configuration        | Set configuration settings dynamically based on machine-specific requirements.             |
| Persistent Parameter Storage | Use a centralized location for storing and setting parameters that persist on the machine. |

### Usages in Automation Testing

| Usage                    | Description                                                                                |
|--------------------------|--------------------------------------------------------------------------------------------|
| Machine-Specific Testing | Set parameters specific to the machine, enabling more accurate and machine-specific tests. |
| Configuration Management | Simplify configuration management by setting parameters directly within test scripts.      |

## Examples

### Example No.1

This example demonstrates the usage of the `Machine` plugin to set a parameter named `MachineSetting` directly.

| Field      | Description                                                              |
|------------|--------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Machine`.       |
| argument   | Specifies the value to set the parameter.                                |
| onElement  | Specifies the name of the parameter to be set.                           |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Machine",
    Argument = "{{$ --Value:MyMachineSetting}}",
    OnElement = "MachineSetting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Machine")
    .setArgument("{{$ --Value:MyMachineSetting}}")
    .setOnElement("MachineSetting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Machine",
    argument: "{{$ --Value:MyMachineSetting}}",
    onElement: "MachineSetting"
};
```

_**JSON**_

```js
{
    "pluginName": "Machine",
    "argument": "{{$ --Value:MyMachineSetting}}",
    "onElement": "MachineSetting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Machine",
    "argument": "{{$ --Value:MyMachineSetting}}",
    "onElement": "MachineSetting"
}
```
### Example No.2

This example demonstrates the usage of the macro to set a parameter named `MachineSetting` and use it in a `RegisterParameter` action, utilizing the `OnAttribute` property.

| Field        | Description                                                                                             |
|------------- |---------------------------------------------------------------------------------------------------------|
| pluginName   | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument     | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement    | Specifies the target element whose attribute content will be saved as the parameter value.              |
| onAttribute  | Specifies the attribute of the element from which the value will be extracted.                          |
| locator      | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:MachineSetting --Scope:Machine}}",
    Locator = "CssSelector",
    OnAttribute = "data-value",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:MachineSetting --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnAttribute("data-value")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:MachineSetting --Scope:Machine}}",
    locator: "CssSelector",
    onAttribute: "data-value",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:MachineSetting --Scope:Machine}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:MachineSetting --Scope:Machine}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates setting a parameter named `MachineSetting` from the text content of an element identified by its CSS selector.

| Field      | Description                                                                                             |
|------------|---------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument   | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement  | Specifies the target element whose text content will be saved as the parameter value.                   |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:MachineSetting --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:MachineSetting --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:MachineSetting --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:MachineSetting --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:MachineSetting --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```
### Example No.4

This example demonstrates setting a parameter named `APIKey` from the text content of an element identified by its CSS selector and using a regular expression to extract part of the text.

| Field             | Description                                                                                             |
|-------------------|---------------------------------------------------------------------------------------------------------|
| pluginName        | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument          | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement         | Specifies the target element whose text content will be saved as the parameter value.                   |
| regularExpression | Specifies the regular expression to apply to the text content before saving the parameter value.        |
| locator           | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:APIKey --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#apiElement",
    RegularExpression = "^.*(?=\sAPIKey$)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:APIKey --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#apiElement")
    .setRegularExpression("^.*(?=\sAPIKey$)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:APIKey --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#apiElement",
    regularExpression: "^.*(?=\sAPIKey$)"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
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

Specifies the name of the parameter to be set.

## Parameters

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value to be set for the parameter.

## Scope

* Any