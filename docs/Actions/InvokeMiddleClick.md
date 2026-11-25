# Invoke Middle Click (InvokeMiddleClick)

[Table of Content](../Home.md)

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs a middle-click, a press and release of the middle mouse button, on an element or at the current pointer position.
When an element is given, the action brings it into view and moves the pointer to its center before clicking.
Use it to open a link in a new tab, close a tab, or trigger any behavior bound to the middle mouse button.
For left-clicks use InvokeClick, and for right-clicks use InvokeContextClick.

### Key Features and Functionality

| Feature             | Description                                                                     |
| --- | --- |
| Middle Click        | Presses and releases the middle mouse button through the WebDriver Actions API. |
| Auto Scroll         | Brings the element into view before the pointer moves to it.                    |
| Element Centering   | Moves the pointer to the center of the element, then clicks there.              |
| Positional Click    | Middle-clicks at the current pointer position when no element is given.         |
| Locator Flexibility | Finds the element with Xpath, CssSelector, Id, LinkText, or PartialLinkText.    |

### Usages in RPA

| Use Case                | Description                                                                         |
| --- | --- |
| Open Links in New Tabs  | Opens several result or report links in background tabs to process them one by one. |
| Close Browser Tabs      | Closes a tab by middle-clicking its tab header in applications that support it.     |
| Positional Middle Click | Middle-clicks at a position set by an earlier pointer move step.                    |

### Usages in Automation Testing

| Use Case               | Description                                                                    |
| --- | --- |
| New Tab Link Testing   | Verifies that middle-clicking a link opens it in a new tab and keeps the page. |
| Middle Button Handlers | Confirms that elements react correctly to middle-button events.                |
| Regression Testing     | Checks that middle-click behavior stays the same after application updates.    |

## Examples

### Example No.1

### Middle-click an element located by a CSS selector

Finds the element matching `#ReportLink` with the CssSelector strategy, moves the pointer to its center, and middle-clicks it.
On a link, the browser usually opens the target in a new tab.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMiddleClick",
    Locator = "CssSelector",
    OnElement = "#ReportLink"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMiddleClick")
    .setLocator("CssSelector")
    .setOnElement("#ReportLink");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMiddleClick",
    locator: "CssSelector",
    onElement: "#ReportLink"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMiddleClick",
    "locator": "CssSelector",
    "onElement": "#ReportLink"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMiddleClick",
    "locator": "CssSelector",
    "onElement": "#ReportLink"
}
```

### Example No.2

### Middle-click at the current pointer position

Presses and releases the middle mouse button at the current pointer position without locating an element.
Use it after a step that already moved the pointer to the target.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMiddleClick"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMiddleClick");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMiddleClick"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMiddleClick"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMiddleClick"
}
```

## Properties

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator selects the strategy used to find the element named by OnElement.
Accepted values are Xpath, CssSelector, Id, LinkText, and PartialLinkText, and Xpath is used when it is absent.
Locator has an effect only when OnElement is also provided.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement holds the locator expression of the element to middle-click.
It is read with the strategy set by the Locator property.
When it is absent, the middle-click happens at the current pointer position instead.

## Scope

* Any

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
