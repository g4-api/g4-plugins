# Invoke User32 Context Click (InvokeUser32ContextClick)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs a native Windows context click at viewport coordinates or on a UI Automation element.
It opens context menus and other right-click interactions in desktop automation workflows.
Element alignment and pixel offsets provide precise control over the click location.

### Key Features and Functionality

| Feature              | Description                                                                                |
| -------------------- | ------------------------------------------------------------------------------------------ |
| Native Context Click | Sends a Windows right-button press and release through the User32-compatible driver.       |
| Coordinate Targeting | Moves the pointer to absolute viewport coordinates before performing the context click.    |
| Element Targeting    | Locates a UI Automation element and moves to its selected alignment point before clicking. |
| Position Adjustment  | Applies horizontal and vertical pixel offsets to an element alignment point.               |

### Usages in RPA

| Use Case                    | Description                                                                       |
| --------------------------- | --------------------------------------------------------------------------------- |
| Native Context Menus        | Opens context menus in Windows desktop applications for later menu selection.     |
| Coordinate-Only Interfaces  | Right-clicks a known screen location when no stable element locator is available. |
| Precise Element Interaction | Targets a specific area of a large or segmented native control.                   |

### Usages in Automation Testing

| Use Case                   | Description                                                                             |
| -------------------------- | --------------------------------------------------------------------------------------- |
| Context Menu Testing       | Verifies that a native element exposes the expected right-click menu.                   |
| Alignment Testing          | Confirms that different element alignment points trigger the intended interaction area. |
| Desktop Regression Testing | Repeats native context-click behavior after application changes.                        |

## Examples

### Example No.1

### Open a context menu at viewport coordinates

Moves the system pointer to coordinates (120, 240) measured from the viewport origin and performs a native context click.
The `{{$ --X:120 --Y:240}}` expression binds the coordinate parameters before execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32ContextClick",
    Argument = "{{$ --X:120 --Y:240}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32ContextClick")
    .setArgument("{{$ --X:120 --Y:240}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32ContextClick",
    argument: "{{$ --X:120 --Y:240}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32ContextClick",
    "argument": "{{$ --X:120 --Y:240}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32ContextClick",
    "argument": "{{$ --X:120 --Y:240}}"
}
```
### Example No.2

### Open a context menu on an aligned element position

Locates the target button and moves the pointer to its top-left alignment point with horizontal and vertical offsets.
The native context click opens the menu at the adjusted element position.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32ContextClick",
    Argument = "{{$ --Alignment:TopLeft --OffsetX:10 --OffsetY:20}}",
    OnElement = "//Button[@AutomationId='SubmitButton']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32ContextClick")
    .setArgument("{{$ --Alignment:TopLeft --OffsetX:10 --OffsetY:20}}")
    .setOnElement("//Button[@AutomationId='SubmitButton']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32ContextClick",
    argument: "{{$ --Alignment:TopLeft --OffsetX:10 --OffsetY:20}}",
    onElement: "//Button[@AutomationId='SubmitButton']"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32ContextClick",
    "argument": "{{$ --Alignment:TopLeft --OffsetX:10 --OffsetY:20}}",
    "onElement": "//Button[@AutomationId='SubmitButton']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32ContextClick",
    "argument": "{{$ --Alignment:TopLeft --OffsetX:10 --OffsetY:20}}",
    "onElement": "//Button[@AutomationId='SubmitButton']"
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

Argument binds Alignment, OffsetX, OffsetY, X, and Y values into the runtime parameter dictionary.
It matters because the action reads positioning values from that dictionary before selecting its target mode.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator selects the strategy used to resolve the native element named by OnElement.
Xpath is the supported default for UI Automation element targeting.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement identifies the UI Automation element that receives the context click.
It matters because element mode applies alignment and offsets before sending the right-button sequence.

## Parameters

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Alignment selects the reference point inside the target element before the context click.
It matters when the interaction must occur near a specific edge, corner, or center position.
OffsetX and OffsetY adjust the final pointer location after alignment is applied.

#### Values

##### Bottom Center

BottomCenter positions the pointer at the bottom edge and horizontal center of the element.
It helps target controls located along the lower middle boundary.
##### Bottom Left

BottomLeft positions the pointer at the lower-left corner of the element.
It helps target controls located near the lower-left boundary.
##### Bottom Right

BottomRight positions the pointer at the lower-right corner of the element.
It helps target controls located near the lower-right boundary.
##### Middle Center

MiddleCenter positions the pointer at the horizontal and vertical center of the element.
It provides the default location for standard context-click interactions.
##### Middle Left

MiddleLeft positions the pointer at the left edge and vertical center of the element.
It helps target controls located along the middle-left boundary.
##### Middle Right

MiddleRight positions the pointer at the right edge and vertical center of the element.
It helps target controls located along the middle-right boundary.
##### Top Center

TopCenter positions the pointer at the top edge and horizontal center of the element.
It helps target controls located along the upper middle boundary.
##### Top Left

TopLeft positions the pointer at the upper-left corner of the element.
It helps target controls located near the upper-left boundary.
##### Top Right

TopRight positions the pointer at the upper-right corner of the element.
It helps target controls located near the upper-right boundary.

### Offset X (OffsetX)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

OffsetX shifts the context-click position horizontally from the selected alignment point.
Positive values move right and negative values move left.
It matters when the active area is not centered on the alignment point.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

OffsetY shifts the context-click position vertically from the selected alignment point.
Positive values move down and negative values move up.
It matters when the active area is above or below the alignment point.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

X sets the horizontal viewport coordinate used when no element is targeted.
It is measured in pixels from the left edge of the viewport.
A non-zero X value activates coordinate mode when OnElement is absent.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Y sets the vertical viewport coordinate used when no element is targeted.
It is measured in pixels from the top edge of the viewport.
A non-zero Y value activates coordinate mode when OnElement is absent.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
