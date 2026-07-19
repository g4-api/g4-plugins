# Move Mouse Cursor (MoveMouseCursor)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Moves the mouse cursor to a target web element or to a specific coordinate position on the page.
When an element is specified via OnElement it takes priority and the cursor moves directly to that element.
When no element is provided, X and Y coordinates define the target position and the optional Origin parameter controls whether the movement is relative to the current pointer position or to the viewport's top-left corner.

### Key Features and Functionality

| Feature              | Description                                                                                                                                       |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| Element Targeting    | Moves the cursor to a specified web element using any supported locator strategy.                                                                 |
| Coordinate Targeting | Moves the cursor to explicit X and Y coordinates when no element is provided.                                                                     |
| Origin Control       | Accepts 'Pointer' (relative to current cursor position) or 'Viewport' (relative to the viewport top-left corner) as the movement reference point. |
| Locator Flexibility  | Supports Xpath, CssSelector, Id, LinkText, and PartialLinkText locator strategies for element targeting.                                          |

### Usages in RPA

| Use Case              | Description                                                                                             |
|-----------------------|---------------------------------------------------------------------------------------------------------|
| Hover Interaction     | Position the cursor over an element to trigger hover states, tooltips, or dropdown menus in a workflow. |
| Mouse Pre-Positioning | Move the cursor to a known coordinate before a scripted click or drag action.                           |
| Tooltip Data Access   | Hover over elements to reveal hidden data or tooltip content for downstream extraction.                 |

### Usages in Automation Testing

| Use Case                    | Description                                                                                                  |
|-----------------------------|--------------------------------------------------------------------------------------------------------------|
| Hover State Testing         | Verify that hover-triggered elements such as tooltips, dropdowns, or overlays appear correctly.              |
| Coordinate Movement Testing | Validate that cursor movement to absolute or relative coordinates behaves as expected.                       |
| Origin Mode Testing         | Confirm that Pointer-relative and Viewport-relative movements produce distinct and correct cursor positions. |
| Element Targeting Testing   | Ensure that element-based cursor moves correctly locate and reach off-screen or nested elements.             |

## Examples

### Example No.1

### Move the cursor to a web element using a CSS selector

Locates the element matching `#TooltipTarget` using the CssSelector strategy and moves the mouse cursor to it.
Use this form to hover over a specific element to trigger hover states, reveal tooltips, or prepare for a follow-on click or drag action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Locator = "CssSelector",
    OnElement = "#TooltipTarget"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setLocator("CssSelector")
    .setOnElement("#TooltipTarget");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    locator: "CssSelector",
    onElement: "#TooltipTarget"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "locator": "CssSelector",
    "onElement": "#TooltipTarget"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "locator": "CssSelector",
    "onElement": "#TooltipTarget"
}
```
### Example No.2

### Move the cursor to explicit coordinates

Moves the mouse cursor by (150, 250) relative to the current pointer position (the default Origin).
Use this form to position the cursor at a known offset from its current location before a follow-on interaction.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:150 --Y:250}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:150 --Y:250}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:150 --Y:250}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:150 --Y:250}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:150 --Y:250}}"
}
```
### Example No.3

### Move the cursor to viewport-relative coordinates

Moves the mouse cursor to coordinates (400, 300) measured from the top-left corner of the visible viewport by setting Origin to 'Viewport'.
Use this form when target coordinates are calculated relative to the viewport rather than the current cursor position.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:400 --Y:300 --Origin:Viewport}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:400 --Y:300 --Origin:Viewport}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:400 --Y:300 --Origin:Viewport}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:400 --Y:300 --Origin:Viewport}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:400 --Y:300 --Origin:Viewport}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Argument provides the CLI-formatted parameter string for coordinate-based cursor movements.
Accepted parameters are --X, --Y, and --Origin.
Argument is only evaluated when OnElement is absent; it is ignored when an element is targeted.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target element for the cursor move.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.
Locator is only evaluated when OnElement is also provided.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to move the cursor to.
It is evaluated using the strategy defined by the Locator property.
When provided, element targeting takes precedence over X, Y, and Origin.

## Parameters

### Origin (Origin)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the origin reference point for the coordinate-based mouse movement.
Accepted values are 'Pointer' (relative to the current cursor position) and 'Viewport' (relative to the top-left corner of the visible viewport).
Ignored when OnElement is specified.

#### Values

##### Pointer

Movement is relative to the current position of the mouse pointer.
##### Viewport

Movement is relative to the top-left corner of the visible viewport.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal pixel offset for the cursor movement.
Defaults to 0 when not provided.
Ignored when OnElement is specified.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical pixel offset for the cursor movement.
Defaults to 0 when not provided.
Ignored when OnElement is specified.

## Scope

* Mobile Web
* Os Native
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
