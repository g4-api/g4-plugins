# Session (Session)

[Table of Content](../Home.md)  

~18 min · SetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetSessionParameter` plugin is to set session-level parameters that are specific to the running automation session. 
This allows for flexible configuration management within the session scope, enabling dynamic updates to parameters such as session-specific settings 
or configurations essential for automation workflows. Session parameters are scoped and accessible only within the automation session that is using 
them, allowing for the use of dynamic parameters with the same name across different sessions without conflicts.

### Key Features and Functionality

| Feature                        | Description                                                                                            |
|--------------------------------|------------------------------------------------------------------------------------------------------- |
| Parameter Setting              | Sets session-level parameters that persist within the running automation session.                      |
| Isolation of Parameters        | Allows for dynamic parameters with the same name across different sessions without conflicts.          |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically set parameters based on automation needs. |

### Usages in RPA

| Usage                              | Description                                                                                    |
|------------------------------------|------------------------------------------------------------------------------------------------|
| Dynamic Configuration              | Set configuration settings dynamically based on session-specific requirements.                 |
| Session-Specific Parameter Storage | Use a centralized location for storing and setting parameters that persist within the session. |

### Usages in Automation Testing

| Usage                    | Description                                                                                |
|--------------------------|--------------------------------------------------------------------------------------------|
| Session-Specific Testing | Set parameters specific to the session, enabling more accurate and session-specific tests. |
| Configuration Management | Simplify configuration management by setting parameters directly within test scripts.      |

## Examples

### Example No.1

This example demonstrates the usage of the `Session` plugin to set a parameter named `SessionSetting` directly.

| Field      | Description                                                              |
|------------|--------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Session`.       |
| argument   | Specifies the value to set the parameter.                                |
| onElement  | Specifies the name of the parameter to be set.                           |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Session",
    Argument = "{{$ --Value:MySessionSetting}}",
    OnElement = "SessionSetting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Session")
    .setArgument("{{$ --Value:MySessionSetting}}")
    .setOnElement("SessionSetting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Session",
    argument: "{{$ --Value:MySessionSetting}}",
    onElement: "SessionSetting"
};
```

_**JSON**_

```js
{
    "pluginName": "Session",
    "argument": "{{$ --Value:MySessionSetting}}",
    "onElement": "SessionSetting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Session",
    "argument": "{{$ --Value:MySessionSetting}}",
    "onElement": "SessionSetting"
}
```
### Example No.2

This example demonstrates the usage of the macro to set a parameter named `SessionSetting` and use it in a `RegisterParameter` action, utilizing the `OnAttribute` property.

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
    Argument = "{{$ --Name:SessionSetting --Scope:Session}}",
    Locator = "CssSelector",
    OnAttribute = "data-value",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:SessionSetting --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnAttribute("data-value")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:SessionSetting --Scope:Session}}",
    locator: "CssSelector",
    onAttribute: "data-value",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:SessionSetting --Scope:Session}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:SessionSetting --Scope:Session}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates setting a parameter named `SessionSetting` from the text content of an element identified by its CSS selector.

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
    Argument = "{{$ --Name:SessionSetting --Scope:Session}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:SessionSetting --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:SessionSetting --Scope:Session}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:SessionSetting --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:SessionSetting --Scope:Session}}",
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
    Argument = "{{$ --Name:APIKey --Scope:Session}}",
    Locator = "CssSelector",
    OnElement = "#apiElement",
    RegularExpression = "^.*(?=\sAPIKey$)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:APIKey --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnElement("#apiElement")
    .setRegularExpression("^.*(?=\sAPIKey$)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:APIKey --Scope:Session}}",
    locator: "CssSelector",
    onElement: "#apiElement",
    regularExpression: "^.*(?=\sAPIKey$)"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Session}}",
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
