# Invoke Double Click (InvokeDoubleClick)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs a double-click on a target element or at the current mouse position when no element is specified.
When an element is provided, the action first moves the mouse cursor to the element to ensure it is scrolled into view before dispatching the double-click via the WebDriver Actions API.
This makes it the primary way to trigger double-click interactions — such as opening items, entering inline edit mode, or activating double-click–driven behaviors — in an automation workflow.
For standard left-click interactions use InvokeClick. For right-click interactions use InvokeContextClick instead.

### Key Features and Functionality

| Feature             | Description                                                                                      |
|---------------------|--------------------------------------------------------------------------------------------------|
| Double Click        | Performs a double-click on the target element using the WebDriver Actions API.                   |
| Auto Scroll         | Calls MoveToElement before clicking to scroll the element into view and ensure interactability.  |
| Positional Click    | Double-clicks at the current mouse position when no element locator is provided.                 |
| Locator Flexibility | Supports Xpath, CssSelector, Id, LinkText, and PartialLinkText locator strategies.               |

### Usages in RPA

| Use Case                | Description                                                                                             |
|-------------------------|---------------------------------------------------------------------------------------------------------|
| File or Item Opening    | Double-click a file, folder, or list item to open it as part of an automated workflow.                  |
| Inline Edit Activation  | Double-click a cell or label to enter inline edit mode in a grid or table.                              |
| Positional Double-Click | Double-click at a scripted mouse position when no stable element reference is available.                |

### Usages in Automation Testing

| Use Case                | Description                                                                                                 |
|-------------------------|-------------------------------------------------------------------------------------------------------------|
| Double-Click Testing    | Verify that double-clickable elements respond correctly to user interaction.                                 |
| Inline Edit Testing     | Confirm that double-clicking a cell or label activates the expected inline edit control.                    |
| Viewport Scroll Testing | Validate that MoveToElement correctly scrolls off-screen elements into view before the double-click occurs. |
| Regression Testing      | Ensure double-click behavior on interactive elements remains consistent after application updates.          |

## Examples

### Example No.1

### Double-click an element using a CSS selector

Locates the element matching `#EditableCell` using the CssSelector strategy, moves the mouse to it, and performs a double-click.
Use this form for any straightforward double-click interaction on a known stable element, such as activating inline edit mode on a table cell.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDoubleClick",
    Locator = "CssSelector",
    OnElement = "#EditableCell"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDoubleClick")
    .setLocator("CssSelector")
    .setOnElement("#EditableCell");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDoubleClick",
    locator: "CssSelector",
    onElement: "#EditableCell"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDoubleClick",
    "locator": "CssSelector",
    "onElement": "#EditableCell"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDoubleClick",
    "locator": "CssSelector",
    "onElement": "#EditableCell"
}
```
### Example No.2

### Double-click at the current mouse position

Performs a double-click at the last known mouse cursor position without locating or targeting any element.
Use this form when the mouse position has been set by a preceding move action and no element reference is needed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDoubleClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDoubleClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDoubleClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDoubleClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDoubleClick"
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

Locator specifies the strategy used to find the target element for the double-click.
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

OnElement provides the locator expression that identifies the element to double-click.
It is evaluated using the strategy defined by the Locator property.
When absent the action performs a double-click at the current mouse position instead.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
