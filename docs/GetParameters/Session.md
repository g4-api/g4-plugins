# Session (Session)

[Table of Content](../Home.md)  

~12 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `GetSessionParameter` plugin is to fetch session parameters that are scoped and accessible only within the automation session that is using them. This allows for the use of dynamic parameters with the same name across different sessions without causing conflicts.

### Key Features and Functionality

| Feature                        | Description                                                                                               |
|------------------------------- |-----------------------------------------------------------------------------------------------------------|
| Parameter Retrieval            | Fetches session-specific parameters that are unique to the current automation session.                    |
| Scoped Parameters              | Ensures that parameters with the same name in different sessions do not interfere with each other.        |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically use retrieved parameters in various actions. |

### Usages in RPA

| Usage                          | Description                                                                                     |
|--------------------------------|------------------------------------------------------------------------------------------------ |
| Dynamic Configuration          | Retrieve and use session-specific parameters dynamically within the current automation session. |
| Session-Specific Data Handling | Use session-level parameters for handling data that should be isolated to the current session.  |

### Usages in Automation Testing

| Usage                      | Description                                                                                               |
|----------------------------|-----------------------------------------------------------------------------------------------------------|
| Isolated Test Data         | Retrieve parameters specific to the test session, ensuring data isolation between parallel test sessions. |
| Dynamic Test Configuration | Simplify test configuration by fetching session-specific parameters directly within test scripts.         |

## Examples

### Example No.1

This example demonstrates the usage of the `Session` plugin to fetch a parameter named `UserToken` directly.

| Field      | Description                                                        |
|------------|--------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Session`. |
| onElement  | Specifies the name of the parameter to be fetched.                 |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Session",
    OnElement = "UserToken"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Session")
    .setOnElement("UserToken");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Session",
    onElement: "UserToken"
};
```

_**JSON**_

```js
{
    "pluginName": "Session",
    "onElement": "UserToken"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Session",
    "onElement": "UserToken"
}
```
### Example No.2

This example demonstrates the usage of the `Get-Parameter` macro to fetch a parameter named `UserToken` from the session and use it in a `SendKeys` action.

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
    Argument = "{{$Get-Parameter --Name:UserToken --Scope:Session}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:UserToken --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:UserToken --Scope:Session}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:UserToken --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:UserToken --Scope:Session}}",
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

Specifies the name of the session parameter to be fetched.
