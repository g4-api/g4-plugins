# Set Focus (SetFocus)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetFocus` plugin is to automate the process of setting focus on specific web elements. 
This functionality is crucial in scenarios where user interactions involve input fields or other elements that need to be active for subsequent actions. 
The plugin aims to streamline automation workflows by ensuring that the necessary elements are focused before further interactions.

### Key Features and Functionality

| Feature           | Description                                                                  |
|-------------------|------------------------------------------------------------------------------|
| Element Focusing  | Automates the process of setting focus on specified web elements.            |
| Dynamic Targeting | Supports dynamic targeting of elements using various locators and selectors. |

### Usages in RPA

| Usage                   | Description                                                                                |
|-------------------------|--------------------------------------------------------------------------------------------|
| Form Filling Automation | Ensures input fields are focused before entering data, improving accuracy in form filling. |
| Interactive Workflows   | Automates focus setting for elements in complex interactive workflows.                     |
| Event Triggering        | Sets focus on elements to trigger associated events, such as onfocus or onblur events.     |

### Usages in Automation Testing

| Usage                       | Description                                                                                     |
|-----------------------------|-------------------------------------------------------------------------------------------------|
| UI Interaction Testing      | Verifies that elements can be focused programmatically, ensuring proper UI behavior.            |
| Form Field Validation       | Ensures that input fields can be focused and interacted with during automated tests.            |
| Event Handling Verification | Tests if focus-related events (e.g., onfocus, onblur) are correctly handled by the application. |

## Examples

### Example No.1

Set focus on the HTML element identified by the CSS selector `#TextInput`. 
This is useful for scenarios where focus needs to be set on a specific input field before performing further actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetFocus",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetFocus")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetFocus",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.2

Set focus on the HTML element identified by the XPath `//input[@name='username']`. 
This configuration is useful for scenarios where the element needs to be focused using an XPath locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetFocus",
    OnElement = "//input[@name='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetFocus")
    .setOnElement("//input[@name='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetFocus",
    onElement: "//input[@name='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "SetFocus",
    "onElement": "//input[@name='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetFocus",
    "onElement": "//input[@name='username']"
}
```
### Example No.3

Set focus on the HTML element identified by the CSS selector `#EventElement` to trigger the `onfocus` event. 
This is useful for scenarios where focusing on an element is required to trigger associated events for testing or interaction purposes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetFocus",
    Locator = "CssSelector",
    OnElement = "#EventElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetFocus")
    .setLocator("CssSelector")
    .setOnElement("#EventElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetFocus",
    locator: "CssSelector",
    onElement: "#EventElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#EventElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#EventElement"
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

Specifies the strategy or method used to locate the element on which focus will be set.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the identifier or locator for the element on which the focus action will be performed. 
It indicates the target element where the focus should be set.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
