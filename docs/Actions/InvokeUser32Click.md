# Invoke User32 Click (InvokeUser32Click)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeUser32Click` plugin is to perform click actions using the Windows User32 API.
Automation scripts can interact with native UI elements in desktop applications by clicking at specific coordinates or on a target element with configurable offsets and alignment.

### Key Features and Functionality

| Feature                   | Description                                                                                              |
|---------------------------|----------------------------------------------------------------------------------------------------------|
| Native Click Action       | Executes click actions using the User32 API for native Windows UI elements.                              |
| Coordinate-based Clicking | Supports clicking at specific (X, Y) coordinates when no target element is provided.                     |
| Element-specific Clicking | Moves the mouse to a target element with configurable offsets and alignment before performing the click. |

### Usage in RPA

| Usage                | Description                                                                                                       |
|----------------------|-------------------------------------------------------------------------------------------------------------------|
| Desktop Automation   | Integrate with RPA workflows to perform click actions on native desktop UI elements using the Windows User32 API. |
| Flexible Interaction | Automate complex scenarios by specifying exact click coordinates or targeting specific UI elements with offsets.  |

### Usage in Automation Testing

| Usage              | Description                                                                                                           |
|--------------------|-----------------------------------------------------------------------------------------------------------------------|
| UI Testing         | Verify the functionality of native UI components by simulating click actions with configurable offsets and alignment. |
| Regression Testing | Ensure consistent behavior of UI elements after updates by automating click sequences using the User32 API.           |

### Platform

This plugin is designed to work on **Windows** only.

## Examples

### Example No.1

### Click at absolute viewport coordinates

The plugin moves the system mouse cursor to position (100, 200) on the viewport and performs a click.
No element is targeted; the `{{$ --X:100 --Y:200}}` syntax binds X and Y as a parameters dictionary that activates coordinate mode at runtime.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32Click",
    Argument = "{{$ --X:100 --Y:200}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32Click")
    .setArgument("{{$ --X:100 --Y:200}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32Click",
    argument: "{{$ --X:100 --Y:200}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ --X:100 --Y:200}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ --X:100 --Y:200}}"
}
```
### Example No.2

### Click on element with alignment and offset

The plugin locates the element at `//button[@id='SubmitButton']` using the Xpath locator, moves the mouse to the TopLeft alignment point with a 10-pixel horizontal and 20-pixel vertical offset, then performs a click.
The `{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}` syntax binds the parameters as a dictionary before execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32Click",
    Argument = "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    OnElement = "//button[@id='SubmitButton']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32Click")
    .setArgument("{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}")
    .setOnElement("//button[@id='SubmitButton']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32Click",
    argument: "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    onElement: "//button[@id='SubmitButton']"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    "onElement": "//button[@id='SubmitButton']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    "onElement": "//button[@id='SubmitButton']"
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
Use the `{{$ --Name:Value}}` format to specify OffsetX, OffsetY, Alignment, X, or Y at runtime.
The expression is parsed into a parameters dictionary before the plugin executes.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy used to locate the target UI element before performing the click.
Xpath is the only supported locator strategy for User32 elements in this plugin.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the XPath expression that identifies the target UI element for the click action.
When provided, the plugin resolves the element, moves the mouse to the aligned position, and performs the click.
Omit this property to use coordinate-based clicking with the X and Y parameters instead.

## Parameters

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Controls the alignment point on the target element where the mouse cursor is positioned before clicking.
Alignment determines which corner, edge, or center of the element bounding box serves as the click reference point.
Combine with OffsetX and OffsetY to fine-tune the click position relative to the chosen alignment point.
Use MiddleCenter for standard centered clicks or edge and corner values for precise boundary interactions.

#### Values

##### Bottom Center

Positions the cursor at the bottom center of the element bounding box.
Use this alignment when the target action is near the lower middle edge of the element.
##### Bottom Left

Positions the cursor at the bottom left corner of the element bounding box.
Use this alignment when the target action is near the lower left boundary of the element.
##### Bottom Right

Positions the cursor at the bottom right corner of the element bounding box.
Use this alignment when the target action is near the lower right boundary of the element.
##### Middle Center

Positions the cursor at the horizontal and vertical center of the element bounding box.
This is the default alignment and works well for most standard click interactions.
##### Middle Left

Positions the cursor at the left edge and vertical center of the element bounding box.
Use this alignment when the target action is near the left side of the element.
##### Middle Right

Positions the cursor at the right edge and vertical center of the element bounding box.
Use this alignment when the target action is near the right side of the element.
##### Top Center

Positions the cursor at the top center of the element bounding box.
Use this alignment when the target action is near the upper middle edge of the element.
##### Top Left

Positions the cursor at the top left corner of the element bounding box.
Use this alignment when the target action is near the upper left boundary of the element.
##### Top Right

Positions the cursor at the top right corner of the element bounding box.
Use this alignment when the target action is near the upper right boundary of the element.

### Offset X (OffsetX)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal pixel offset applied to the mouse position relative to the aligned point on the target element.
Positive values shift the click position to the right; negative values shift it to the left.
Use this parameter when the click must land slightly away from the default alignment point.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical pixel offset applied to the mouse position relative to the aligned point on the target element.
Positive values shift the click position downward; negative values shift it upward.
Use this parameter when the click must land slightly away from the default alignment point.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute horizontal coordinate on the viewport where the click will occur when no target element is provided.
The coordinate is measured in pixels from the left edge of the viewport.
Set X and Y together to trigger coordinate-based clicking without element targeting.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute vertical coordinate on the viewport where the click will occur when no target element is provided.
The coordinate is measured in pixels from the top edge of the viewport.
Set X and Y together to trigger coordinate-based clicking without element targeting.

## Scope

* Windows Native