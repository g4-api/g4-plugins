# Invoke User32 Click (InvokeUser32Click)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeUser32Click` plugin is to perform click actions using the Windows User32 API. 
This allows automation scripts to interact with native UI elements in desktop applications, either by clicking at specific coordinates or on a target element with configurable offsets and alignment.

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

Perform a click action at specific coordinates (X: 100, Y: 200) without targeting any element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32Click",
    Argument = "{{$ -X:100 --Y:200}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32Click")
    .setArgument("{{$ -X:100 --Y:200}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeUser32Click",
    argument: "{{$ -X:100 --Y:200}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ -X:100 --Y:200}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeUser32Click",
    "argument": "{{$ -X:100 --Y:200}}"
}
```
### Example No.2

Perform a click action on a UI element identified by the XPath `//button[@id='SubmitButton']`, with an offset of 10 pixels horizontally and 20 pixels vertically, aligned to the TopLeft of the element.

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

Specifies the XPath for the target UI element where the click will be performed. 
This property is used when an element is targeted for the click action.

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the parameters expression for the click action. 
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

Specifies the horizontal offset (in pixels) to adjust the click position relative to the target element.

### Offset Y (OffsetY)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical offset (in pixels) to adjust the click position relative to the target element.

### Alignment (Alignment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the alignment of the click relative to the target element. Choose an alignment that best fits your UI layout.
For example, 'MiddleCenter' will click at the center of the element, while 'TopLeft' will click at the upper left corner.

#### Values

##### Top Left

Click at the top left corner of the element.
##### Top Center

Click at the top center of the element.
##### Top Right

Click at the top right corner of the element.
##### Middle Left

Click at the middle left side of the element.
##### Middle Right

Click at the middle right side of the element.
##### Bottom Left

Click at the bottom left corner of the element.
##### Bottom Center

Click at the bottom center of the element.
##### Bottom Right

Click at the bottom right corner of the element.
##### Middle Center

Click at the center of the element.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the X coordinate for a click action when no target element is provided.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the Y coordinate for a click action when no target element is provided.

## Scope

* Windows Native