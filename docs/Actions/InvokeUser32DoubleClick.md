# Invoke User32 Double Click (InvokeUser32DoubleClick)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeUser32DoubleClick` plugin is to perform double-click actions using the Windows User32 API. 
This allows automation scripts to interact with native UI elements in desktop applications, either by double-clicking at specific coordinates or on a target element with configurable offsets and alignment.

### Key Features and Functionality

| Feature                       | Description                                                                                                     |
|-------------------------------|-----------------------------------------------------------------------------------------------------------------|
| Native Double-Click Action    | Executes double-click actions using the User32 API for native Windows UI elements.                              |
| Coordinate-based Double-Click | Supports double-clicking at specific (X, Y) coordinates when no target element is provided.                     |
| Element-specific Double-Click | Moves the mouse to a target element with configurable offsets and alignment before performing the double-click. |

### Usage in RPA

| Usage                | Description                                                                                                              |
|----------------------|--------------------------------------------------------------------------------------------------------------------------|
| Desktop Automation   | Integrate with RPA workflows to perform double-click actions on native desktop UI elements using the Windows User32 API. |
| Flexible Interaction | Automate complex scenarios by specifying exact double-click coordinates or targeting specific UI elements with offsets.  |

### Usage in Automation Testing

| Usage              | Description                                                                                                                  |
|--------------------|------------------------------------------------------------------------------------------------------------------------------|
| UI Testing         | Verify the functionality of native UI components by simulating double-click actions with configurable offsets and alignment. |
| Regression Testing | Ensure consistent behavior of UI elements after updates by automating double-click sequences using the User32 API.           |

### Platform

This plugin is designed to work on **Windows** only.

## Examples

### Example No.1

Perform a double-click action at specific coordinates (X: 100, Y: 200) without targeting any element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DoubleClick",
    Argument = "{{$ --X:100 --Y:200}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DoubleClick")
    .setArgument("{{$ --X:100 --Y:200}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32DoubleClick",
    argument: "{{$ --X:100 --Y:200}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32DoubleClick",
    "argument": "{{$ --X:100 --Y:200}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32DoubleClick",
    "argument": "{{$ --X:100 --Y:200}}"
}
```
### Example No.2

Perform a double-click action on a UI element identified by the XPath `//button[@id='SubmitButton']`, with an offset of 10 pixels horizontally and 20 pixels vertically, aligned to the TopLeft of the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DoubleClick",
    Argument = "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    OnElement = "//button[@id='SubmitButton']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DoubleClick")
    .setArgument("{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}")
    .setOnElement("//button[@id='SubmitButton']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32DoubleClick",
    argument: "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    onElement: "//button[@id='SubmitButton']"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32DoubleClick",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    "onElement": "//button[@id='SubmitButton']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32DoubleClick",
    "argument": "{{$ --OffsetX:10 --OffsetY:20 --Alignment:TopLeft}}",
    "onElement": "//button[@id='SubmitButton']"
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

Specifies the XPath for the target UI element where the double-click will be performed.
This property is used when an element is targeted for the double-click action.

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the parameters expression for the double-click action.
Use this expression to dynamically set values such as offsets, alignment, and coordinates.

## Parameters

### Offset X (OffsetX)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal offset (in pixels) to adjust the double-click position relative to the target element.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical offset (in pixels) to adjust the double-click position relative to the target element.

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the alignment of the double-click relative to the target element. Choose an alignment that best fits your UI layout.
For example, 'MiddleCenter' will double-click at the center of the element, while 'TopLeft' will double-click at the upper left corner.

#### Values

##### Top Left

Double-click at the top left corner of the element.
##### Top Center

Double-click at the top center of the element.
##### Top Right

Double-click at the top right corner of the element.
##### Middle Left

Double-click at the middle left side of the element.
##### Middle Right

Double-click at the middle right side of the element.
##### Bottom Left

Double-click at the bottom left corner of the element.
##### Bottom Center

Double-click at the bottom center of the element.
##### Bottom Right

Double-click at the bottom right corner of the element.
##### Middle Center

Double-click at the center of the element.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the X coordinate for a double-click action when no target element is provided.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the Y coordinate for a double-click action when no target element is provided.

## Scope

* Windows Native