# User (User)

[Table of Content](../Home.md)  

~12 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]
> This plugin is supported on Windows machines only.

### Purpose

The primary purpose of the `GetUserParameter` plugin is to fetch user-level parameters that are scoped to the current user's environment. This allows for user-specific configuration settings, such as user preferences or user-specific API keys, to be retrieved and used within automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                               |
|--------------------------------|-----------------------------------------------------------------------------------------------------------|
| Parameter Retrieval            | Fetches user-specific parameters from the environment variables of the current user.                      |
| User-Specific Configuration    | Supports retrieval of parameters that are specific to the logged-in user.                                 |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically use retrieved parameters in various actions. |

### Usages in RPA

| Usage                   | Description                                                                            |
|-------------------------|----------------------------------------------------------------------------------------|
| User Preferences        | Retrieve and apply user-specific preferences within automation workflows.              |
| Personalized Automation | Use user-level parameters to personalize automation actions based on the current user. |

### Usages in Automation Testing

| Usage                    | Description                                                                                          |
|--------------------------|------------------------------------------------------------------------------------------------------|
| User-Specific Testing    | Retrieve parameters specific to the logged-in user, enabling personalized and user-specific tests.   |
| Configuration Management | Simplify configuration management by fetching user-specific parameters directly within test scripts. |

## Examples

### Example No.1

This example demonstrates the usage of the `User` plugin to fetch a parameter named `UserApiKey` directly.

| Field      | Description                                                     |
|------------|-----------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `User`. |
| onElement  | Specifies the name of the parameter to be fetched.              |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "User",
    OnElement = "UserApiKey"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("User")
    .setOnElement("UserApiKey");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "User",
    onElement: "UserApiKey"
};
```

_**JSON**_

```js
{
    "pluginName": "User",
    "onElement": "UserApiKey"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "User",
    "onElement": "UserApiKey"
}
```
### Example No.2

This example demonstrates the usage of the `Get-Parameter` macro to fetch a parameter named `UserApiKey` from the user environment and use it in a `SendKeys` action.

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
    Argument = "{{$Get-Parameter --Name:UserApiKey --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:UserApiKey --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:UserApiKey --Scope:User}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:UserApiKey --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:UserApiKey --Scope:User}}",
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

Specifies the name of the user parameter to be fetched.
