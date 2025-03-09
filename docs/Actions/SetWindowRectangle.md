# Set Window Rectangle (SetWindowRectangle)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SetWindowRectangle` plugin is designed to automate the resizing and repositioning of the browser window within web automation workflows. 
It provides a seamless way to set the window's size and position, ensuring optimal layout and visibility for automated tasks.

### Key Features and Functionality

| Feature              | Description                                                                           |
|----------------------|---------------------------------------------------------------------------------------|
| Window Resizing      | Allows precise control over the height and width of the browser window.               |
| Window Repositioning | Enables setting the X and Y coordinates of the browser window for accurate placement. |

### Usages in RPA

| Usage                   | Description                                                                                        |
|-------------------------|----------------------------------------------------------------------------------------------------|
| Screen Layout           | Optimizes the layout of the browser window for better visibility and interaction during RPA tasks. |
| Multi-Window Management | Manages multiple browser windows by setting specific sizes and positions.                          |
| Data Entry              | Facilitates data entry tasks by ensuring the browser window is appropriately sized and positioned. |

### Usages in Automation Testing

| Usage               | Description                                                                                      |
|---------------------|--------------------------------------------------------------------------------------------------|
| UI Testing          | Ensures consistent testing conditions by setting the window size and position before tests.      |
| Responsive Design   | Tests different window sizes to verify the responsiveness of web applications.                   |
| Layout Verification | Verifies that web application layouts behave correctly under various window sizes and positions. |

## Examples

### Example No.1

Set the browser window size to 1024x768 pixels and position it at coordinates (100, 100). 
This configuration is useful for ensuring that the window is of a specific size and located at a particular position on the screen.

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

Resize the browser window to 800x600 pixels without changing its current position. 
This configuration is useful for testing scenarios that require a specific window size without repositioning the window.

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

Reposition the browser window to coordinates (200, 150) without changing its current size. 
This configuration is useful for organizing multiple windows on the screen by setting their specific positions.

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

Set the browser window width to 1200 pixels and reposition it to the X coordinate 50, keeping the current height and Y position. 
This combination allows for adjusting the window width and horizontal position while maintaining the existing height and vertical position.

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

Set the browser window height to 700 pixels and reposition it to the Y coordinate 300, keeping the current width and X position. 
This combination allows for adjusting the window height and vertical position while maintaining the existing width and horizontal position.

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

The `Argument` property allows for customization of the plugin's behavior by providing specific instructions or parameters. 
In the case of the `SetWindowRectangle` plugin, it defines the height, width, and position coordinates (X, Y) of the browser window. 
This flexibility ensures the plugin's adaptability to various scenarios encountered during automation workflows.

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

### Width (Width)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the width of the browser window in pixels.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the X coordinate of the browser window's position.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the Y coordinate of the browser window's position.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#set-window-rect](https://www.w3.org/TR/webdriver/#set-window-rect)
