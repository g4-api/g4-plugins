# Move User32 Mouse (MoveUser32Mouse)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `MoveUser32Mouse` plugin moves the mouse pointer using the Windows User32 API. 
This plugin supports both absolute movement to specified viewport coordinates and relative movement within a UI element or viewport using customizable offsets and alignment.

### Key Features and Functionality

| Feature                 | Description                                                                                                                           |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| Absolute Movement       | Moves the mouse cursor to specific (X, Y) coordinates on the viewport when absolute coordinates are provided.                         |
| Relative Movement       | Moves the mouse cursor relative to a target UI element or last known mouse pointer location using configurable offsets and alignment. |
| Dynamic Decision Making | Automatically determines whether to use absolute coordinates or element-relative offsets based on provided parameters.                |

### Usage in RPA

| Usage                    | Description                                                                                                             |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------|
| Desktop Automation       | Integrate with RPA workflows to control the mouse position for native desktop applications using the User32 API.        |
| Precise Pointer Movement | Use absolute coordinates or element-relative offsets to precisely position the mouse cursor as required by the process. |

### Usage in Automation Testing

| Usage               | Description                                                                                                           |
|---------------------|-----------------------------------------------------------------------------------------------------------------------|
| UI Testing          | Simulate user interactions by moving the mouse to specific areas of the screen or within UI elements.                 |
| Regression Testing  | Validate UI layouts and behavior by verifying consistent mouse pointer movements across different application states. |

### Platform

This plugin is designed to work on **Windows** only.

## Examples

### Example No.1

Move the mouse cursor to absolute viewport coordinates (X: 300, Y: 400) without targeting any UI element.

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

Move the mouse cursor relative to a UI element identified by the XPath `//div[@id='InteractiveArea']` with an offset of 15 pixels horizontally and 25 pixels vertically, aligned to the BottomCenter of the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveUser32Mouse",
    Argument = "{{$ --OffsetX:15 --OffsetY:25 --Alignment:BottomCenter}}",
    OnElement = "//div[@id='InteractiveArea']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveUser32Mouse")
    .setArgument("{{$ --OffsetX:15 --OffsetY:25 --Alignment:BottomCenter}}")
    .setOnElement("//div[@id='InteractiveArea']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveUser32Mouse",
    argument: "{{$ --OffsetX:15 --OffsetY:25 --Alignment:BottomCenter}}",
    onElement: "//div[@id='InteractiveArea']"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:15 --OffsetY:25 --Alignment:BottomCenter}}",
    "onElement": "//div[@id='InteractiveArea']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveUser32Mouse",
    "argument": "{{$ --OffsetX:15 --OffsetY:25 --Alignment:BottomCenter}}",
    "onElement": "//div[@id='InteractiveArea']"
}
```
### Example No.3

Move the mouse cursor relative to the last know mouse pointer location with an offset of 15 pixels horizontally and 25 pixels vertically.

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

## Properties

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy to find the UI element. The only supported locator is `Xpath`.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the XPath for the target UI element to which the mouse pointer will be moved.
This property is used when the movement should be relative to a specific UI element.

## Parameters

### Offset X (OffsetX)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal offset (in pixels) to adjust the mouse position relative to the target UI element or to the last known mouse pointer location if the element was not provided.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical offset (in pixels) to adjust the mouse position relative to the target UI element or to the last known mouse pointer location if the element was not provided.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute X coordinate for moving the mouse when no UI element is targeted.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the absolute Y coordinate for moving the mouse when no UI element is targeted.

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the alignment for positioning the mouse relative to the target UI element.
Select an alignment option that best matches the desired click area within the element.

#### Values

##### Top Left

Align the mouse to the top left corner of the element.
##### Top Center

Align the mouse to the top center of the element.
##### Top Right

Align the mouse to the top right corner of the element.
##### Middle Left

Align the mouse to the middle left side of the element.
##### Middle Center

Align the mouse to the center of the element.
##### Middle Right

Align the mouse to the middle right side of the element.
##### Bottom Left

Align the mouse to the bottom left corner of the element.
##### Bottom Center

Align the mouse to the bottom center of the element.
##### Bottom Right

Align the mouse to the bottom right corner of the element.

## Scope

* Windows Native