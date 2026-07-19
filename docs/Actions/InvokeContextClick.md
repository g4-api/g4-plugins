# Invoke Context Click (InvokeContextClick)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs a context-click (right-click) on a target element or at the current mouse position when no element is specified.
When an element is provided, the action first moves the mouse cursor to the element to ensure it is scrolled into view before dispatching the right-click via the WebDriver Actions API.
This makes it the primary way to trigger context menus, secondary actions, and right-click–dependent behaviors in an automation workflow.
For standard left-click interactions, use InvokeClick instead.

### Key Features and Functionality

| Feature             | Description                                                                                     |
|---------------------|-------------------------------------------------------------------------------------------------|
| Context Click       | Performs a right-click on the target element using the WebDriver Actions API.                   |
| Auto Scroll         | Calls MoveToElement before clicking to scroll the element into view and ensure interactability. |
| Positional Click    | Right-clicks at the current mouse position when no element locator is provided.                 |
| Locator Flexibility | Supports Xpath, CssSelector, Id, LinkText, and PartialLinkText locator strategies.              |

### Usages in RPA

| Use Case                 | Description                                                                                            |
|--------------------------|--------------------------------------------------------------------------------------------------------|
| Context Menu Access      | Right-click an element to open its context menu and select an option as part of an automated workflow. |
| Secondary Action Trigger | Trigger secondary actions exposed only through right-click menus, such as copy, paste, or inspect.     |
| Positional Right-Click   | Right-click at a scripted mouse position when no stable element reference is available.                |

### Usages in Automation Testing

| Use Case                | Description                                                                                                |
|-------------------------|------------------------------------------------------------------------------------------------------------|
| Context Menu Testing    | Verify that right-clicking an element opens the expected context menu with the correct options.            |
| UI Interaction Testing  | Confirm that right-click–sensitive elements respond correctly to user interaction.                         |
| Viewport Scroll Testing | Validate that MoveToElement correctly scrolls off-screen elements into view before the right-click occurs. |
| Regression Testing      | Ensure context-click behavior on interactive elements remains consistent after application updates.        |

## Examples

### Example No.1

### Context-click an element using a CSS selector

Locates the element matching `#RightClickButton` using the CssSelector strategy, moves the mouse to it, and performs a right-click.
Use this form for any straightforward context-click interaction on a known stable element to open its context menu.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeContextClick",
    Locator = "CssSelector",
    OnElement = "#RightClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeContextClick")
    .setLocator("CssSelector")
    .setOnElement("#RightClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeContextClick",
    locator: "CssSelector",
    onElement: "#RightClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeContextClick",
    "locator": "CssSelector",
    "onElement": "#RightClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeContextClick",
    "locator": "CssSelector",
    "onElement": "#RightClickButton"
}
```
### Example No.2

### Context-click at the current mouse position

Performs a right-click at the last known mouse cursor position without locating or targeting any element.
Use this form when the mouse position has been set by a preceding move action and no element reference is needed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeContextClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeContextClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeContextClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeContextClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeContextClick"
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

Locator specifies the strategy used to find the target element for the context-click.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.
Locator is only evaluated when OnElement is also provided; it has no effect in positional-click mode.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to context-click.
It is evaluated using the strategy defined by the Locator property.
When absent the action performs a context-click at the current mouse position instead.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
