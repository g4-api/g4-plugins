# Set User32 Focus (SetUser32Focus)

[Table of Content](../Home.md)  

~9 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetUser32Focus` plugin is to set focus on a UI element using the Windows User32 API. 
This ensures that the target element becomes active and ready for subsequent user interactions or automated actions.

### Key Features and Functionality

| Feature          | Description                                                                                    |
|------------------|------------------------------------------------------------------------------------------------|
| Set Focus Action | Activates the target UI element by setting focus on it, preparing it for further interactions. |

### Usage in RPA

| Usage              | Description                                                                                         |
|--------------------|-----------------------------------------------------------------------------------------------------|
| Element Activation | Use the plugin to ensure a specific UI element is focused before executing further automated tasks. |

### Usage in Automation Testing

| Usage              | Description                                                                           |
|--------------------|---------------------------------------------------------------------------------------|
| Focus Verification | Confirm that the desired UI element receives focus as expected during test execution. |

### Platform

This plugin is designed to work on **Windows** only.

## Examples

### Example No.1

Set focus on a UI element identified by the XPath `//input[@id='Username']`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetUser32Focus",
    OnElement = "//input[@id='Username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetUser32Focus")
    .setOnElement("//input[@id='Username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetUser32Focus",
    onElement: "//input[@id='Username']"
};
```

_**JSON**_

```js
{
    "pluginName": "SetUser32Focus",
    "onElement": "//input[@id='Username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetUser32Focus",
    "onElement": "//input[@id='Username']"
}
```

## Properties

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy to find the UI element. The only supported locator is `Xpath`.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the XPath for the target UI element on which focus will be set. This property is required to identify the element.

## Scope

* Windows Native