# Set Window Rectangle (SetWindowRectangle)

[Table of Content](../Home.md)  

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Resizes and repositions the browser window by supplying any combination of `Height`, `Width`, `X`, and `Y` parameters.
Omitted parameters are preserved from the current window geometry, allowing size-only, position-only, or full-rect changes in a single call.

### Key Features and Functionality

| Feature               | Description                                                                                                        |
|-----------------------|--------------------------------------------------------------------------------------------------------------------|
| Precise Resizing      | Sets window height and width to exact pixel values using `--Height` and `--Width`.                                 |
| Precise Repositioning | Sets the window's screen position to exact coordinates using `--X` (left edge) and `--Y` (top edge).               |
| Partial Apply         | Omitted parameters fall back to the current window value — one call can change only size, only position, or both.  |
| Flexible Combinations | Any subset of the four parameters is valid, enabling targeted adjustments without disturbing unrelated dimensions. |

### Usages in RPA

| Use Case               | Description                                                                                                  |
|------------------------|--------------------------------------------------------------------------------------------------------------|
| Screen Layout Control  | Position and size the browser window to avoid overlap with other application windows during RPA workflows.   |
| Multi-Window Placement | Tile or stack browser windows at known coordinates for multi-window automation scenarios.                    |
| Pre-Task Normalization | Establish a known window geometry before executing form-fill or scraping steps that rely on full visibility. |

### Usages in Automation Testing

| Use Case                  | Description                                                                                                         |
|---------------------------|---------------------------------------------------------------------------------------------------------------------|
| Responsive Design Testing | Resize the window to standard breakpoints (e.g. 1024×768, 1920×1080) to verify responsive layout rules.             |
| Layout Regression Testing | Enforce a fixed window size before taking screenshots or running visual comparisons.                                |
| Viewport Boundary Tests   | Position the window at edge coordinates to verify element visibility and scroll behaviour near viewport boundaries. |
| Window Geometry Assertion | Resize and then read back the window rect via another action to assert the driver applied the requested dimensions. |

## Examples

### Example No.1

### Set full window geometry — size and position in one call

Resizes the browser window to 1024 × 768 pixels and moves it to screen coordinates (100, 100).
All four parameters are provided, making this the full-rect form that controls both size and position simultaneously.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowRectangle",
    Argument = "{{$ --Height:768 --Width:1024 --X:100 --Y:100}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowRectangle")
    .setArgument("{{$ --Height:768 --Width:1024 --X:100 --Y:100}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowRectangle",
    argument: "{{$ --Height:768 --Width:1024 --X:100 --Y:100}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:768 --Width:1024 --X:100 --Y:100}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:768 --Width:1024 --X:100 --Y:100}}"
}
```
### Example No.2

### Resize the window without changing its position

Resizes the browser window to 800 × 600 pixels while keeping its current screen position.
Use this form when only the window size needs to change and the position should remain where it is.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowRectangle",
    Argument = "{{$ --Height:600 --Width:800}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowRectangle")
    .setArgument("{{$ --Height:600 --Width:800}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowRectangle",
    argument: "{{$ --Height:600 --Width:800}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:600 --Width:800}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:600 --Width:800}}"
}
```
### Example No.3

### Reposition the window without changing its size

Moves the browser window to screen coordinates (200, 150) while keeping its current width and height.
Use this form when only the window position needs to change and the size should remain as-is.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowRectangle",
    Argument = "{{$ --X:200 --Y:150}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowRectangle")
    .setArgument("{{$ --X:200 --Y:150}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowRectangle",
    argument: "{{$ --X:200 --Y:150}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --X:200 --Y:150}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --X:200 --Y:150}}"
}
```
### Example No.4

### Set window width and horizontal position together

Sets the browser window width to 1200 pixels and moves its left edge to X coordinate 50, while leaving the height and Y position unchanged.
Use this form to adjust only the horizontal geometry — width and X — in a single call.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowRectangle",
    Argument = "{{$ --Width:1200 --X:50}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowRectangle")
    .setArgument("{{$ --Width:1200 --X:50}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowRectangle",
    argument: "{{$ --Width:1200 --X:50}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Width:1200 --X:50}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Width:1200 --X:50}}"
}
```
### Example No.5

### Set window height and vertical position together

Sets the browser window height to 700 pixels and moves its top edge to Y coordinate 300, while leaving the width and X position unchanged.
Use this form to adjust only the vertical geometry — height and Y — in a single call.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowRectangle",
    Argument = "{{$ --Height:700 --Y:300}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowRectangle")
    .setArgument("{{$ --Height:700 --Y:300}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowRectangle",
    argument: "{{$ --Height:700 --Y:300}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:700 --Y:300}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowRectangle",
    "argument": "{{$ --Height:700 --Y:300}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Expression        |

Argument provides the CLI-formatted parameter string for setting the window rectangle.
Accepted parameters are --Height, --Width, --X, and --Y.
Any combination of the four parameters is valid; omitted parameters fall back to the current window value read from the driver.

## Parameters

### Height (Height)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the height of the browser window in pixels.
When absent, the current window height is read from the driver and preserved unchanged.

### Width (Width)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the width of the browser window in pixels.
When absent, the current window width is read from the driver and preserved unchanged.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the X coordinate of the browser window's left edge on the screen.
When absent, the current window X position is read from the driver and preserved unchanged.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the Y coordinate of the browser window's top edge on the screen.
When absent, the current window Y position is read from the driver and preserved unchanged.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#set-window-rect](https://www.w3.org/TR/webdriver/#set-window-rect)
