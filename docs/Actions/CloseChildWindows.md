# Close Child Windows (CloseChildWindows)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `CloseChildWindows` plugin is to close all child browser windows while keeping the main window open. This is useful for cleaning up and managing browser sessions that involve multiple windows.

### Key Features and Functionality

| Feature              | Description                                                              |
|----------------------|--------------------------------------------------------------------------|
| Close Child Windows  | Closes all child browser windows, retaining only the main window.        |
| Window Management    | Ensures that the main window remains active after closing child windows. |
| Exception Handling   | Handles any exceptions that occur during the window closing process.     |

### Usages in RPA

| Usage             | Description                                                                        |
|-------------------|------------------------------------------------------------------------------------|
| Session Cleanup   | Close all child windows at the end of an automation session to clean up resources. |
| Window Management | Ensure only the main window remains open during the automation process.            |

### Usages in Automation Testing

| Usage               | Description                                                                                 |
|---------------------|---------------------------------------------------------------------------------------------|
| Test Cleanup        | Close all child windows at the end of tests to ensure no windows remain open between tests. |
| Resource Management | Ensure proper management of browser windows during test execution.                          |

## Examples

### Example No.1

Use the `CloseChildWindows` plugin to close all child browser windows, keeping the main window open.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseChildWindows"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseChildWindows");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseChildWindows"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseChildWindows"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseChildWindows"
}
```
### Example No.2

Use the `CloseChildWindows` plugin to close a specified number of child browser windows.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseChildWindows",
    Argument = "2"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseChildWindows")
    .setArgument("2");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseChildWindows",
    argument: "2"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseChildWindows",
    "argument": "2"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseChildWindows",
    "argument": "2"
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
| **Value Type**    | Number            |

The `Argument` property specifies the number of child browser windows to close. 
It accepts a number. If the argument is not provided or is set to a value greater than the number of child windows, all child windows will be closed. 
Providing a negative value will result in no windows being closed.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)
