# Close Window (CloseWindow)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Closes a specific browser window identified by its handle or index, or closes the currently active window when no argument is supplied.
It supports three targeting modes — active window, index-based, and handle-based — providing precise window management across multi-window browser sessions.

### Key Features and Functionality

| Feature                    | Description                                                                                                |
|----------------------------|------------------------------------------------------------------------------------------------------------|
| Close Active Window        | Closes the currently focused window when no Argument is provided.                                          |
| Index-Based Targeting      | Accepts a zero-based integer index to close the window at that position in the driver handle list.         |
| Handle-Based Targeting     | Accepts a window handle string and matches it case-insensitively against open windows before closing.      |
| Invalid Argument Detection | Throws NoSuchWindowException immediately when the index is out of range or the handle string is not found. |
| Focus Switch on Closure    | When targeting by index or handle the action switches focus to the target window before closing it.        |

### Usages in RPA

| Use Case         | Description                                                                                                  |
|------------------|--------------------------------------------------------------------------------------------------------------|
| Popup Dismissal  | Close a known popup or advertisement window by index after detecting it was opened by the page.              |
| Session Cleanup  | Close an auxiliary window opened for authentication or file download before continuing the automation flow.  |
| Targeted Closure | When the exact window handle was captured earlier, close it precisely without relying on a positional index. |

### Usages in Automation Testing

| Use Case                  | Description                                                                                                  |
|---------------------------|--------------------------------------------------------------------------------------------------------------|
| Post-Interaction Teardown | Close a window opened by a test step such as a print preview or OAuth popup before proceeding to assertions. |
| Window Count Assertion    | Close specific windows then assert the expected remaining window count for state validation.                 |
| Isolated Window Cleanup   | Close windows by stored handle to ensure the test cleans up exactly the window it opened.                    |

## Examples

### Example No.1

### Close the currently active browser window

Closes whichever browser window currently has WebDriver focus.
Use this mode when the target window is already active and no handle or index tracking is needed.

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

### Close a browser window by its zero-based index

Closes the window at position 1 in the driver window handle list.
Index-based targeting is convenient when the order of window opening is predictable and stable.

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

### Close a browser window by its handle

Closes the window identified by the handle string `CDwindow-1234`.
Handle-based targeting provides index-drift-free closure when the handle was captured at window-open time.

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

Argument specifies which browser window to close.
When omitted or empty the currently active window is closed via WebDriver.Close().
When set to an integer the window at that zero-based index in the driver handle list is switched to and closed.
When set to a non-numeric string it is matched case-insensitively against open window handles and the matching window is switched to and closed.
An out-of-range index or an unrecognized non-empty handle string causes a NoSuchWindowException.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)
