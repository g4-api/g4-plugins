# Move User32 Mouse (MoveUser32Mouse)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `MoveUser32Mouse` plugin moves the mouse pointer using the Windows User32 API.
Automation scripts can control the cursor position for native desktop applications by moving to absolute viewport coordinates, by applying a pixel offset from the current cursor position, or by targeting a specific UI element with configurable alignment and offsets.

### Key Features and Functionality

| Feature                    | Description                                                                                                                          |
|----------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| Coordinate Movement        | Moves the mouse cursor to specific (X, Y) absolute coordinates on the viewport when no element is targeted.                          |
| Pointer-Offset Movement    | Moves the mouse cursor relative to its current position when OffsetX or OffsetY is non-zero and no element is targeted.              |
| Element-Targeted Movement  | Moves the cursor to the alignment point on a target UI element bounding box, adjusted by optional OffsetX and OffsetY pixel offsets. |
| Combined Coordinate+Offset | Applies coordinate movement first, then pointer-offset movement when both X/Y and OffsetX/OffsetY are non-zero without an element.   |

### Usage in RPA

| Usage                   | Description                                                                                                              |
|-------------------------|--------------------------------------------------------------------------------------------------------------------------|
| Desktop Automation      | Integrate with RPA workflows to position the mouse precisely on native desktop UI elements using the Windows User32 API. |
| Precise Pointer Control | Use absolute coordinates or element-relative offsets to position the cursor at runtime-determined locations.             |

### Usage in Automation Testing

| Usage              | Description                                                                                                          |
|--------------------|----------------------------------------------------------------------------------------------------------------------|
| UI Testing         | Simulate hover and focus behaviors by moving the mouse to specific screen areas or within UI elements.               |
| Regression Testing | Validate consistent mouse positioning across application states by automating cursor movements using the User32 API. |

### Platform

This plugin is designed to work on **Windows** only.

## Examples

### Example No.1

### Move mouse to absolute viewport coordinates

The plugin moves the system mouse cursor to position (300, 400) on the viewport.
No element is targeted; the `{{$ --X:300 --Y:400}}` syntax binds X and Y as a parameters dictionary that activates coordinate mode at runtime.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveUser32Mouse",
    Argument = "{{$ --X:300 --Y:400}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveUser32Mouse")
    .setArgument("{{$ --X:300 --Y:400}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveUser32Mouse",
    argument: "{{$ --X:300 --Y:400}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --X:300 --Y:400}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --X:300 --Y:400}}"
}
```
### Example No.2

### Move mouse by offset relative to current cursor position

The plugin moves the system mouse cursor 15 pixels right and 25 pixels down from its current position.
No element is targeted; the `{{$ --OffsetX:15 --OffsetY:25}}` syntax binds the offsets as a parameters dictionary that activates pointer-offset mode at runtime.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveUser32Mouse",
    Argument = "{{$ --OffsetX:15 --OffsetY:25}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveUser32Mouse")
    .setArgument("{{$ --OffsetX:15 --OffsetY:25}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveUser32Mouse",
    argument: "{{$ --OffsetX:15 --OffsetY:25}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:15 --OffsetY:25}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:15 --OffsetY:25}}"
}
```
### Example No.3

### Move mouse to element with alignment and offset

The plugin locates the element at `//div[@id='InteractivePanel']` using the Xpath locator, moves the mouse to the BottomCenter alignment point with a 10-pixel horizontal and 20-pixel vertical offset.
The `{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}` syntax binds the parameters as a dictionary before execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveUser32Mouse",
    Argument = "{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}",
    OnElement = "//div[@id='InteractivePanel']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveUser32Mouse")
    .setArgument("{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}")
    .setOnElement("//div[@id='InteractivePanel']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveUser32Mouse",
    argument: "{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}",
    onElement: "//div[@id='InteractivePanel']"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}",
    "onElement": "//div[@id='InteractivePanel']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:BottomCenter}}",
    "onElement": "//div[@id='InteractivePanel']"
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

Carries the parameter expression used to pass runtime values to the plugin.
Use the `{{$ --Name:Value}}` format to specify Alignment, OffsetX, OffsetY, X, or Y at runtime.
The expression is parsed into a parameters dictionary before the plugin executes.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy used to locate the target UI element before performing the mouse move.
Xpath is the only supported locator strategy for User32 elements in this plugin.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the XPath expression that identifies the target UI element for the mouse move action.
When provided, the plugin resolves the element and moves the cursor to the alignment point adjusted by any OffsetX and OffsetY values.
Omit this property to use coordinate-based or pointer-offset movement with the X, Y, OffsetX, and OffsetY parameters instead.

## Parameters

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Controls the alignment point on the target element where the mouse cursor is positioned during element-targeted movement.
Alignment determines which corner, edge, or center of the element bounding box serves as the movement reference point.
Combine with OffsetX and OffsetY to fine-tune the cursor position relative to the chosen alignment point.
Use MiddleCenter for standard centered positioning or edge and corner values for precise boundary interactions.

#### Values

##### Bottom Center

Positions the cursor at the bottom center of the element bounding box.
Use this alignment when the target position is near the lower middle edge of the element.
##### Bottom Left

Positions the cursor at the bottom left corner of the element bounding box.
Use this alignment when the target position is near the lower left boundary of the element.
##### Bottom Right

Positions the cursor at the bottom right corner of the element bounding box.
Use this alignment when the target position is near the lower right boundary of the element.
##### Middle Center

Positions the cursor at the horizontal and vertical center of the element bounding box.
This is the default alignment and works well for most standard mouse-move interactions.
##### Middle Left

Positions the cursor at the left edge and vertical center of the element bounding box.
Use this alignment when the target position is near the left side of the element.
##### Middle Right

Positions the cursor at the right edge and vertical center of the element bounding box.
Use this alignment when the target position is near the right side of the element.
##### Top Center

Positions the cursor at the top center of the element bounding box.
Use this alignment when the target position is near the upper middle edge of the element.
##### Top Left

Positions the cursor at the top left corner of the element bounding box.
Use this alignment when the target position is near the upper left boundary of the element.
##### Top Right

Positions the cursor at the top right corner of the element bounding box.
Use this alignment when the target position is near the upper right boundary of the element.

### Offset X (OffsetX)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal pixel offset applied to the mouse position.
In element mode, the offset is relative to the alignment point on the target element bounding box; positive values shift right, negative values shift left.
In pointer-offset mode (no element, OffsetX or OffsetY non-zero), the offset is relative to the current cursor position.
Use this parameter when the move must land slightly away from the default alignment or current cursor position.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical pixel offset applied to the mouse position.
In element mode, the offset is relative to the alignment point on the target element bounding box; positive values shift downward, negative values shift upward.
In pointer-offset mode (no element, OffsetX or OffsetY non-zero), the offset is relative to the current cursor position.
Use this parameter when the move must land slightly away from the default alignment or current cursor position.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute horizontal coordinate on the viewport where the cursor will move when no target element is provided.
The coordinate is measured in pixels from the left edge of the viewport.
Set X and Y together to trigger coordinate-based movement without element targeting.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute vertical coordinate on the viewport where the cursor will move when no target element is provided.
The coordinate is measured in pixels from the top edge of the viewport.
Set X and Y together to trigger coordinate-based movement without element targeting.

## Scope

* Windows Native