# Add Scroll (AddScroll)

[Table of Content](../Home.md)

~20 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddScroll turns the mouse wheel as one action of a gesture.
It runs only inside InvokeInputActions, and the wheel turns over an element or over a point of the viewport.
Flows use it to scroll a list inside a page, to load more items, and to zoom a map or a chart that listens to the wheel.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Both axes | Scrolls vertically with DeltaY and horizontally with DeltaX. |
| Element origin | Turns the wheel over the center of the element named by OnElement. |
| Viewport origin | Turns the wheel at an X and Y position of the viewport when the rule has no element. |
| Real wheel events | Raises the wheel events of the page, unlike a scroll made by a script. |
| Loop element | Scrolls the current element of a for-each loop when the rule names none. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Inner lists | Scroll a list or a table that has its own scroll bar. |
| Lazy loading | Scroll down until a page loads its next items. |
| Maps and charts | Zoom a map or a chart that reacts to the wheel. |
| Horizontal content | Scroll a carousel or a wide table sideways. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Wheel handlers | Verify that a page reacts to wheel events, such as a zoom or a sticky header. |
| Infinite scroll | Verify that more items load when a list reaches its end. |
| Scroll containers | Verify that the wheel scrolls the element it turns over and not the page. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Scroll the page down

The DeltaY parameter turns the wheel 600 pixels down.
Without an element the wheel turns at the top-left corner of the viewport, which scrolls the page.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddScroll",
    Argument = "{{$ --DeltaY:600}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddScroll")
    .setArgument("{{$ --DeltaY:600}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddScroll",
    argument: "{{$ --DeltaY:600}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:600}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:600}}"
}
```

### Example No.2

### Scroll a list that has its own scroll bar

The `onElement` value names the list with an XPath.
The wheel turns 400 pixels down over the center of the list, so the list scrolls and the page stays.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddScroll",
    Argument = "{{$ --DeltaY:400}}",
    OnElement = "//ul[@id='results']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddScroll")
    .setArgument("{{$ --DeltaY:400}}")
    .setOnElement("//ul[@id='results']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddScroll",
    argument: "{{$ --DeltaY:400}}",
    onElement: "//ul[@id='results']"
};
```

**JSON:**

```js
{
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:400}}",
    "onElement": "//ul[@id='results']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:400}}",
    "onElement": "//ul[@id='results']"
}
```

### Example No.3

### Scroll sideways at a position in the viewport

DeltaX turns the wheel 300 pixels to the right.
X and Y place the wheel 400 pixels from the left edge and 300 pixels from the top edge of the viewport.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddScroll",
    Argument = "{{$ --DeltaX:300 --X:400 --Y:300}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddScroll")
    .setArgument("{{$ --DeltaX:300 --X:400 --Y:300}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddScroll",
    argument: "{{$ --DeltaX:300 --X:400 --Y:300}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaX:300 --X:400 --Y:300}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaX:300 --X:400 --Y:300}}"
}
```

### Example No.4

### Scroll up inside an element found with a CSS selector

The element is found with a CSS selector.
A negative DeltaY turns the wheel 250 pixels up over its center.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddScroll",
    Argument = "{{$ --DeltaY:-250}}",
    Locator = "CssSelector",
    OnElement = "div.chat-history"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddScroll")
    .setArgument("{{$ --DeltaY:-250}}")
    .setLocator("CssSelector")
    .setOnElement("div.chat-history");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddScroll",
    argument: "{{$ --DeltaY:-250}}",
    locator: "CssSelector",
    onElement: "div.chat-history"
};
```

**JSON:**

```js
{
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:-250}}",
    "locator": "CssSelector",
    "onElement": "div.chat-history"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddScroll",
    "argument": "{{$ --DeltaY:-250}}",
    "locator": "CssSelector",
    "onElement": "div.chat-history"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the parameters of the scroll, such as `{{$ --DeltaY:600}}`.
A rule without an argument adds a scroll of zero pixels, which changes nothing.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the OnElement value finds the element to scroll.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
Defaults to Xpath, and is read only when OnElement is set.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the element the wheel turns over, in the form the Locator selects.
The wheel turns at the center of the element, shifted by X and Y when they are set.
An element that is not found fails the step, and the container then sends nothing.
The element is found before the sequence is sent, so it must already be in the page; inside a for-each loop the search starts from the loop element.

## Parameters

### Delta X (DeltaX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how far the wheel scrolls horizontally, in pixels.
A positive value scrolls right and a negative value scrolls left.
Defaults to 0, and text that is not a whole number fails the step.

### Delta Y (DeltaY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how far the wheel scrolls vertically, in pixels.
A positive value scrolls down and a negative value scrolls up.
Defaults to 0, and text that is not a whole number fails the step.

### X (X)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal place of the wheel, in pixels.
With a named or inherited element it is an offset from the element center; otherwise it is measured from the left edge of the viewport.
Defaults to 0, and text that is not a whole number fails the step.

### Y (Y)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical place of the wheel, in pixels.
With a named or inherited element it is an offset from the element center; otherwise it is measured from the top edge of the viewport.
Defaults to 0, and text that is not a whole number fails the step.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
