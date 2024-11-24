# User (User)

[Table of Content](../Home.md)  

~18 min · SetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!WARNING]
> This plugin is supported on Windows machines only.

### Purpose

The primary purpose of the `SetUserParameter` plugin is to set user-level parameters that are specific to the user running the automation session. This allows for flexible configuration management, enabling dynamic updates to parameters such as user-specific settings or configurations essential for automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                            |
|------------------------------- |--------------------------------------------------------------------------------------------------------|
| Parameter Setting              | Sets user-level parameters that persist for the user running the automation session.                   |
| User-Specific Parameters       | Allows for dynamic parameters that are specific to the user environment.                               |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically set parameters based on automation needs. |

### Usages in RPA

| Usage                           | Description                                                                              |
|---------------------------------|------------------------------------------------------------------------------------------|
| Dynamic Configuration           | Set configuration settings dynamically based on user-specific requirements.              |
| User-Specific Parameter Storage | Use a centralized location for storing and setting parameters that persist for the user. |

### Usages in Automation Testing

| Usage                    | Description                                                                           |
|--------------------------|---------------------------------------------------------------------------------------|
| User-Specific Testing    | Set parameters specific to the user, enabling more accurate and user-specific tests.  |
| Configuration Management | Simplify configuration management by setting parameters directly within test scripts. |

## Examples

### Example No.1

This example demonstrates the usage of the `User` plugin to set a parameter named `UserSetting` directly.

| Field      | Description                                                              |
|------------|--------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `User`.          |
| argument   | Specifies the value to set the parameter.                                |
| onElement  | Specifies the name of the parameter to be set.                           |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "User",
    Argument = "{{$ --Value:MyUserSetting}}",
    OnElement = "UserSetting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("User")
    .setArgument("{{$ --Value:MyUserSetting}}")
    .setOnElement("UserSetting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "User",
    argument: "{{$ --Value:MyUserSetting}}",
    onElement: "UserSetting"
};
```

_**JSON**_

```js
{
    "pluginName": "User",
    "argument": "{{$ --Value:MyUserSetting}}",
    "onElement": "UserSetting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "User",
    "argument": "{{$ --Value:MyUserSetting}}",
    "onElement": "UserSetting"
}
```
### Example No.2

This example demonstrates the usage of the macro to set a parameter named `UserSetting` and use it in a `RegisterParameter` action, utilizing the `OnAttribute` property.

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
    Argument = "{{$ --Name:UserSetting --Scope:User}}",
    Locator = "CssSelector",
    OnAttribute = "data-value",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:UserSetting --Scope:User}}")
    .setLocator("CssSelector")
    .setOnAttribute("data-value")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:UserSetting --Scope:User}}",
    locator: "CssSelector",
    onAttribute: "data-value",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:UserSetting --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:UserSetting --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates setting a parameter named `UserSetting` from the text content of an element identified by its CSS selector.

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
    Argument = "{{$ --Name:UserSetting --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:UserSetting --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:UserSetting --Scope:User}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:UserSetting --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:UserSetting --Scope:User}}",
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
    Argument = "{{$ --Name:APIKey --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#apiElement",
    RegularExpression = "^.*(?=\sAPIKey$)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:APIKey --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#apiElement")
    .setRegularExpression("^.*(?=\sAPIKey$)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:APIKey --Scope:User}}",
    locator: "CssSelector",
    onElement: "#apiElement",
    regularExpression: "^.*(?=\sAPIKey$)"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:User}}",
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
