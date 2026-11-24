# Add Pointer Move (AddPointerMove)

[Table of Content](../Home.md)

~19 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddPointerMove moves the pointer without pressing or releasing a button.
It runs only inside InvokeInputActions, where it sets the place of the presses, releases, and scrolls that follow it.
Flows use it to hover over a menu, to aim a click at an exact point, and to carry a pressed item to its drop target.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Element target | Moves to the center of the element named by OnElement. |
| Offsets | Shifts the target by X and Y pixels from the element center. |
| Viewport position | Moves to an X and Y position measured from the top-left corner of the viewport. |
| Relative move | Moves by X and Y pixels from the current pointer position. |
| Timed move | Sets how long the driver spends on the move; whether it sends move events along the way depends on the driver, and ChromeDriver sends one at the end. |
| Loop element | Moves to the current element of a for-each loop when the rule names none. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Hover menus | Move over a menu so its items appear, then click an item the menu creates in a following container. |
| Drag and drop | Carry a pressed item from its source to its target. |
| Sliders | Drag a slider handle by an exact number of pixels. |
| Canvas work | Aim at a point of a canvas, a chart, or a map. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Hover states | Verify the tooltip or the style an element shows under the pointer. |
| Drag paths | Verify how a page reacts when an item is moved onto other elements, one AddPointerMove per element. |
| Position accuracy | Verify that a click at an exact offset hits the intended part of an element. |

## Examples

### Example No.1

### Move to the center of an element

The `onElement` value names the element with an XPath.
The pointer moves to its center over the default 250 milliseconds.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerMove",
    OnElement = "//button[@id='menu']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerMove")
    .setOnElement("//button[@id='menu']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerMove",
    onElement: "//button[@id='menu']"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerMove",
    "onElement": "//button[@id='menu']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerMove",
    "onElement": "//button[@id='menu']"
}
```

### Example No.2

### Move to an offset from an element center

The element is found with a CSS selector, and X and Y shift the target from its center.
The move takes 400 milliseconds.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerMove",
    Argument = "{{$ --X:40 --Y:-10 --Duration:400}}",
    Locator = "CssSelector",
    OnElement = "#slider-track"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerMove")
    .setArgument("{{$ --X:40 --Y:-10 --Duration:400}}")
    .setLocator("CssSelector")
    .setOnElement("#slider-track");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerMove",
    argument: "{{$ --X:40 --Y:-10 --Duration:400}}",
    locator: "CssSelector",
    onElement: "#slider-track"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:40 --Y:-10 --Duration:400}}",
    "locator": "CssSelector",
    "onElement": "#slider-track"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:40 --Y:-10 --Duration:400}}",
    "locator": "CssSelector",
    "onElement": "#slider-track"
}
```

### Example No.3

### Move to a position in the viewport

The Origin parameter measures X and Y from the top-left corner of the visible page.
The pointer moves to that point whatever element lies under it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerMove",
    Argument = "{{$ --X:200 --Y:150 --Origin:Viewport}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerMove")
    .setArgument("{{$ --X:200 --Y:150 --Origin:Viewport}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerMove",
    argument: "{{$ --X:200 --Y:150 --Origin:Viewport}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:200 --Y:150 --Origin:Viewport}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:200 --Y:150 --Origin:Viewport}}"
}
```

### Example No.4

### Move by a distance from the current position

X and Y are measured from the current pointer position, which is the default origin.
With a button held by an earlier AddPointerDown, it drags a slider handle 120 pixels to the right.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerMove",
    Argument = "{{$ --X:120 --Y:0 --Duration:00:00:01}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerMove")
    .setArgument("{{$ --X:120 --Y:0 --Duration:00:00:01}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerMove",
    argument: "{{$ --X:120 --Y:0 --Duration:00:00:01}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:120 --Y:0 --Duration:00:00:01}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerMove",
    "argument": "{{$ --X:120 --Y:0 --Duration:00:00:01}}"
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

Holds the parameters of the move, such as `{{$ --X:200 --Y:150 --Origin:Viewport}}`.
A rule without an argument moves to the center of its element over 250 milliseconds.
A plain value such as `500` is ignored; set the time with `--Duration`.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the OnElement value finds the element to move to.
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

Names the element to move to, in the form the Locator selects.
The pointer goes to the center of the element, shifted by X and Y when they are set.
An element that is not found fails the step, and the container then sends nothing.
The element is found before the sequence is sent, so it must already be in the page; inside a for-each loop the search starts from the loop element.

## Parameters

### Duration (Duration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 250               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Sets how long the move takes.
Accepts a whole number of milliseconds, such as `600`, or a time span, such as `00:00:01`.
Whether a longer duration adds move events depends on the driver; ChromeDriver sends one move at the end, so build a path from several AddPointerMove steps.
Defaults to 250 milliseconds, and a negative value or text that is not a duration fails the step.

### Origin (Origin)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Pointer           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Selects where X and Y are measured from when the rule names no element and inherits none from a for-each loop.
Defaults to Pointer, and any value other than Pointer or Viewport fails the step.
Ignored when the rule names or inherits an element.

#### Values

##### Pointer

Measures X and Y from the current pointer position.
Use it for a relative move, such as dragging a slider 120 pixels to the right.

##### Viewport

Measures X and Y from the top-left corner of the visible page.
Use it for an absolute position, such as a point on a full-page canvas.

### X (X)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal distance in pixels, where a positive value points right.
With a named or inherited element it is an offset from the element center; otherwise it is measured from Origin.
Defaults to 0, and text that is not a whole number fails the step.

### Y (Y)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical distance in pixels, where a positive value points down.
With a named or inherited element it is an offset from the element center; otherwise it is measured from Origin.
Defaults to 0, and text that is not a whole number fails the step.

## Scope

* Mobile Web
* Os Native
* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
