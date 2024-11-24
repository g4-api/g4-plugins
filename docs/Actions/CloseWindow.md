# Close Window (CloseWindow)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `CloseWindow` plugin is to close a specific browser window or the active window if no specific window is specified. This is useful for managing browser sessions that involve multiple windows.

### Key Features and Functionality

| Feature               | Description                                                              |
|-----------------------|------------------------------------------------------------------------- |
| Close Specific Window | Closes a browser window specified by its handle or index.                |
| Close Active Window   | Closes the active browser window if no handle or index is specified.     |
| Exception Handling    | Handles any exceptions that occur due to invalid window handle or index. |

### Usages in RPA

| Usage             | Description                                                                   |
|-------------------|-------------------------------------------------------------------------------|
| Window Management | Close specific browser windows during the automation process.                 |
| Session Cleanup   | Ensure proper cleanup of browser windows at the end of an automation session. |

### Usages in Automation Testing

| Usage             | Description                                                                                |
|-------------------|--------------------------------------------------------------------------------------------|
| Test Cleanup      | Close specific windows at the end of tests to ensure no windows remain open between tests. |
| Window Management | Manage browser windows efficiently during test execution.                                  |

## Examples

### Example No.1

This example demonstrates the usage of the `CloseWindow` plugin to close the active browser window. 
If there is no specific window handle or index provided, the plugin will close the window that is currently in focus.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseWindow"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseWindow");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseWindow"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseWindow"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseWindow"
}
```
### Example No.2

This example demonstrates the usage of the `CloseWindow` plugin to close a browser window specified by its index. 
In this case, the window at index 1 (second window) in the list of window handles will be closed. 
This is useful when you know the position of the window you want to close.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseWindow",
    Argument = "1"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseWindow")
    .setArgument("1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseWindow",
    argument: "1"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseWindow",
    "argument": "1"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseWindow",
    "argument": "1"
}
```
### Example No.3

This example demonstrates the usage of the `CloseWindow` plugin to close a browser window specified by its handle. 
Here, the window with the handle `CDwindow-1234` will be closed. 
This is useful when you have the exact handle of the window you want to close, ensuring precision in window management.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseWindow",
    Argument = "CDwindow-1234"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseWindow")
    .setArgument("CDwindow-1234");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseWindow",
    argument: "CDwindow-1234"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseWindow",
    "argument": "CDwindow-1234"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseWindow",
    "argument": "CDwindow-1234"
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
| **Value Type**    | String|Number     |

The `Argument` property specifies which browser window to close. 
It accepts either an index (number) or a window handle (string). 
If no argument is provided, the active window will be closed. 
Providing an invalid index or handle will result in an exception.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)
