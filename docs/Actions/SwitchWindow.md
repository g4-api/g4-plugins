# Switch Window (SwitchWindow)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SwitchWindow` plugin automates the process of switching between different browser windows or tabs during web-based automation tasks. 
This functionality is essential for workflows that involve multiple windows or tabs, ensuring that the correct window is focused and interacted with as needed.

### Key Features and Functionality

| Feature                | Description                                                                                        |
|------------------------|----------------------------------------------------------------------------------------------------|
| Index-based Switching  | Allows switching to a window using its index, facilitating navigation among multiple open windows. |
| Handle-based Switching | Enables switching to a window using its handle, providing flexibility in window management.        |

### Usages in RPA

| Usage                                 | Description                                                                                   |
|---------------------------------------|-----------------------------------------------------------------------------------------------|
| Multi-Window Workflows                | Automates the process of switching between multiple windows or tabs during complex workflows. |
| Data Collection from Multiple Sources | Facilitates the collection of data from different windows or tabs simultaneously.             |

### Usages in Automation Testing

| Usage              | Description                                                                                               |
|--------------------|-----------------------------------------------------------------------------------------------------------|
| UI Testing         | Validates the behavior of applications across multiple windows or tabs by switching context as needed.    |
| End-to-End Testing | Ensures comprehensive test coverage by automating window switching as part of user interaction scenarios. |

## Examples

### Example No.1

Switch to the window with index `1`. 
This is useful for navigating to a specific window when multiple windows are open.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchWindow",
    Argument = "1"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchWindow")
    .setArgument("1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchWindow",
    argument: "1"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchWindow",
    "argument": "1"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchWindow",
    "argument": "1"
}
```
### Example No.2

Switch to the window with the handle `CDwindow-1234`. 
This is useful for switching to a window with a known handle, ensuring the correct window is focused.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchWindow",
    Argument = "CDwindow-1234"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchWindow")
    .setArgument("CDwindow-1234");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchWindow",
    argument: "CDwindow-1234"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchWindow",
    "argument": "CDwindow-1234"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchWindow",
    "argument": "CDwindow-1234"
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
| **Value Type**    | String|Expression |

Specifies the identifier for the window to switch to. 
It can be either an index (e.g., `1`) or a window handle (e.g., `CDwindow-1234`).

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#switch-to-window](https://www.w3.org/TR/webdriver/#switch-to-window)
