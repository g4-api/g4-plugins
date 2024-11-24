# Set Window State (SetWindowState)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetWindowState` plugin is to control the state of the browser window, providing options to maximize, minimize, or set the window to full screen.

### Key Features and Functionality

| Feature                | Description                                                        |
|------------------------|--------------------------------------------------------------------|
| Maximize Window Action | Maximizes the browser window to the screen's full size.            |
| Minimize Window Action | Minimizes the browser window to the taskbar or dock.               |
| Full Screen Action     | Sets the browser window to full screen mode for an immersive view. |

### Usages in RPA

| Usage                   | Description                                                                   |
|-------------------------|-------------------------------------------------------------------------------|
| Full View Automation    | Ensures that web elements are fully visible by maximizing the browser window. |
| Background Processing   | Runs browser-based tasks in the background by minimizing the browser window.  |
| Screen Space Management | Frees up screen space for other applications while the browser runs minimized.|

### Usages in Automation Testing

| Usage               | Description                                                                                             |
|---------------------|---------------------------------------------------------------------------------------------------------|
| UI Testing          | Ensures that all UI elements are visible and interactable by maximizing the browser window.             |
| Layout Verification | Verifies that the layout of the web application behaves correctly when the browser window is maximized. |
| Performance Testing | Verifies that the application continues to function correctly when the browser window is minimized.     |
| Regression Testing  | Ensures that changes to the application do not affect functionality when the window state is changed.   |

## Examples

### Example No.1

Perform a `MaximizeWindow` action to ensure the browser window is maximized, providing an optimal view for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowState",
    Argument = "Maximized"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowState")
    .setArgument("Maximized");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowState",
    argument: "Maximized"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowState",
    "argument": "Maximized"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowState",
    "argument": "Maximized"
}
```
### Example No.2

Perform a `MinimizeWindow` action to minimize the browser window, allowing the browser to run in the background without taking up screen space.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowState",
    Argument = "Minimized"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowState")
    .setArgument("Minimized");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowState",
    argument: "Minimized"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowState",
    "argument": "Minimized"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowState",
    "argument": "Minimized"
}
```
### Example No.3

Perform a `FullScreen` action to set the browser window to full screen, providing an immersive view of the web content.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetWindowState",
    Argument = "FullScreen"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetWindowState")
    .setArgument("FullScreen");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetWindowState",
    argument: "FullScreen"
};
```

_**JSON**_

```js
{
    "pluginName": "SetWindowState",
    "argument": "FullScreen"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetWindowState",
    "argument": "FullScreen"
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
| **Value Type**    | String            |

Specifies the desired state of the browser window.

#### Values

##### Maximized

Maximizes the browser window to the screen's full size.
##### Minimized

Minimizes the browser window to the taskbar or dock.
##### Full Screen

Sets the browser window to full screen mode for an immersive view.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#resizing-and-positioning-windows](https://www.w3.org/TR/webdriver/#resizing-and-positioning-windows)
