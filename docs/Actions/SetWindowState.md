# Set Window State (SetWindowState)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sets the browser window to `Maximized`, `Minimized`, or `FullScreen` by calling the corresponding W3C WebDriver window command.
The `Argument` property specifies the target state and is evaluated with `OrdinalIgnoreCase`, so `maximized`, `MAXIMIZED`, and `Maximized` are all valid.
If `Argument` is absent, empty, or does not match any recognized value, the action returns a default response without error — the window state is not changed.

### Key Features and Functionality

| Feature                | Description                                                                                                                  |
|------------------------|------------------------------------------------------------------------------------------------------------------------------|
| Maximize               | Calls `WebDriver.Manage().Window.Maximize()` to expand the browser window to fill the screen.                                |
| Minimize               | Calls `WebDriver.Manage().Window.Minimize()` to collapse the browser window to the taskbar.                                  |
| Full Screen            | Calls `WebDriver.Manage().Window.FullScreen()` to enter true full-screen mode, hiding OS and browser chrome.                 |
| Case-Insensitive Match | State names are compared with `OrdinalIgnoreCase` — `fullscreen`, `FullScreen`, and `FULLSCREEN` all resolve to full screen. |
| Safe No-Op on Mismatch | An unrecognized or absent `Argument` value skips all branches and returns normally without throwing an exception.            |

### Usages in RPA

| Use Case                   | Description                                                                                                            |
|----------------------------|------------------------------------------------------------------------------------------------------------------------|
| Workflow Normalization     | Maximize the browser window before starting a workflow to ensure consistent element visibility and layout.             |
| Background Task Management | Minimize the browser window to move it out of view while other applications or steps are active.                       |
| Kiosk Mode                 | Switch to `FullScreen` to present a page without OS or browser chrome, simulating a kiosk or presentation environment. |

### Usages in Automation Testing

| Use Case                    | Description                                                                                                            |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------|
| Consistent Screenshot State | Maximize the window before taking screenshots to avoid layout shifts caused by non-standard window sizes.              |
| Minimize Interaction Test   | Minimize the window and verify that subsequent element interactions behave as expected when the window is not visible. |
| Full-Screen Layout Test     | Enter full-screen mode to verify that the application layout adapts correctly when OS and browser toolbars are hidden. |

## Examples

### Example No.1

### Maximize the browser window

Sets the browser window to maximized state by calling `WebDriver.Manage().Window.Maximize()`.
The `Argument` value `Maximized` is matched case-insensitively.

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

### Minimize the browser window

Collapses the browser window to the taskbar by calling `WebDriver.Manage().Window.Minimize()`.
The `Argument` value `Minimized` is matched case-insensitively.

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

### Enter full-screen mode

Switches the browser window to full-screen mode by calling `WebDriver.Manage().Window.FullScreen()`.
The `Argument` value `FullScreen` is matched case-insensitively.

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

Argument specifies the target browser window state.
Accepted values are `Maximized`, `Minimized`, and `FullScreen`.
The comparison is case-insensitive — `fullscreen`, `FullScreen`, and `FULLSCREEN` are all valid.
If Argument is absent, empty, or set to an unrecognized value, no state change occurs and the action returns normally without error.

#### Values

##### Maximized

Expands the browser window to fill the screen by calling `WebDriver.Manage().Window.Maximize()`.
##### Minimized

Collapses the browser window to the taskbar by calling `WebDriver.Manage().Window.Minimize()`.
##### Full Screen

Switches the browser window to full-screen mode, hiding OS and browser chrome, by calling `WebDriver.Manage().Window.FullScreen()`.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#resizing-and-positioning-windows](https://www.w3.org/TR/webdriver/#resizing-and-positioning-windows)
