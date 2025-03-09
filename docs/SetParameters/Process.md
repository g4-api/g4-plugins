# Process (Process)

[Table of Content](../Home.md)  

~18 min · SetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetProcessParameter` plugin is to set process-level parameters that are specific to the running automation process. This allows for flexible configuration management within the process scope, enabling dynamic updates to parameters such as process-specific settings or configurations essential for automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                            |
|--------------------------------|--------------------------------------------------------------------------------------------------------|
| Parameter Setting              | Sets process-level parameters that persist within the running automation process.                      |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically set parameters based on automation needs. |

### Usages in RPA

| Usage                               | Description                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------------|
| Dynamic Configuration               | Set configuration settings dynamically based on process-specific requirements.                 |
| Process-Specific Parameter Storage  | Use a centralized location for storing and setting parameters that persist within the process. |

### Usages in Automation Testing

| Usage                    | Description                                                                                |
|--------------------------|--------------------------------------------------------------------------------------------|
| Process-Specific Testing | Set parameters specific to the process, enabling more accurate and process-specific tests. |
| Configuration Management | Simplify configuration management by setting parameters directly within test scripts.      |

## Examples

### Example No.1

This example demonstrates the usage of the `Process` plugin to set a parameter named `ProcessSetting` directly.

| Field      | Description                                                        |
|------------|--------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Process`. |
| argument   | Specifies the value to set the parameter.                          |
| onElement  | Specifies the name of the parameter to be set.                     |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Process",
    Argument = "{{$ --Value:MyProcessSetting}}",
    OnElement = "ProcessSetting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Process")
    .setArgument("{{$ --Value:MyProcessSetting}}")
    .setOnElement("ProcessSetting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Process",
    argument: "{{$ --Value:MyProcessSetting}}",
    onElement: "ProcessSetting"
};
```

_**JSON**_

```js
{
    "pluginName": "Process",
    "argument": "{{$ --Value:MyProcessSetting}}",
    "onElement": "ProcessSetting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Process",
    "argument": "{{$ --Value:MyProcessSetting}}",
    "onElement": "ProcessSetting"
}
```
### Example No.2

This example demonstrates the usage of the macro to set a parameter named `ProcessSetting` and use it in a `RegisterParameter` action, utilizing the `OnAttribute` property.

| Field       | Description                                                                                             |
|-------------|---------------------------------------------------------------------------------------------------------|
| pluginName  | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument    | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement   | Specifies the target element whose attribute content will be saved as the parameter value.              |
| onAttribute | Specifies the attribute of the element from which the value will be extracted.                          |
| locator     | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:ProcessSetting --Scope:Process}}",
    Locator = "CssSelector",
    OnAttribute = "data-value",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:ProcessSetting --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnAttribute("data-value")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:ProcessSetting --Scope:Process}}",
    locator: "CssSelector",
    onAttribute: "data-value",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ProcessSetting --Scope:Process}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ProcessSetting --Scope:Process}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates setting a parameter named `ProcessSetting` from the text content of an element identified by its CSS selector.

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
    Argument = "{{$ --Name:ProcessSetting --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:ProcessSetting --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:ProcessSetting --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ProcessSetting --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ProcessSetting --Scope:Process}}",
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
    Argument = "{{$ --Name:APIKey --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#apiElement",
    RegularExpression = "^.*(?=\sAPIKey$)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:APIKey --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#apiElement")
    .setRegularExpression("^.*(?=\sAPIKey$)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:APIKey --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#apiElement",
    regularExpression: "^.*(?=\sAPIKey$)"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Process}}",
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