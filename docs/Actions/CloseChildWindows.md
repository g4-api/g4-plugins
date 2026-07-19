# Close Child Windows (CloseChildWindows)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Closes all child browser windows or tabs while always preserving the main window at index zero.
An optional integer Argument limits closure to an exact number of children; omitting it closes all of them.
After all targeted windows are closed the driver focus is returned to the main window, leaving the session in a consistent, single-window state.

### Key Features and Functionality

| Feature                   | Description                                                                                                     |
|---------------------------|-----------------------------------------------------------------------------------------------------------------|
| Selective Closure         | Optional Argument limits closure to an exact number of child windows; omit to close all children.               |
| Main Window Preservation  | The window at index zero is always retained and receives driver focus after all closures complete.              |
| Reverse-Order Processing  | Child handles are iterated in reverse order for consistent stack-based closing behavior.                        |
| Per-Window Error Capture  | Exceptions thrown during individual window closures are captured and stored without aborting the overall loop.  |
| Paced Execution           | A 100 ms delay between each closure reduces race conditions with the browser window management layer.           |
| Single-Window No-Op Guard | When only one window handle exists the action returns immediately, making it safe to call in any session state. |

### Usages in RPA

| Use Case       | Description                                                                                             |
|----------------|---------------------------------------------------------------------------------------------------------|
| Popup Cleanup  | Remove advertisement or notification popups spawned during a workflow before continuing processing.     |
| Tab Management | Reduce open tabs to the primary context after a subprocess opens temporary browser windows.             |
| Session Reset  | Enforce a single-window state at the start of each automation iteration without restarting the session. |

### Usages in Automation Testing

| Use Case                    | Description                                                                                            |
|-----------------------------|--------------------------------------------------------------------------------------------------------|
| Post-Test Window Teardown   | Remove all child windows left open by a test step to prevent state leakage into the next test case.    |
| Partial Window Cleanup      | Close a known subset of popup windows opened during a test flow without closing the main test session. |
| Window State Assertion Prep | Reset to a single-window state before asserting the expected window count in a multi-window flow test. |

## Examples

### Example No.1

### Close all child browser windows

Closes every child window or tab beyond the main window.
Execution continues even if individual window closures fail.

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

### Close a specific number of child browser windows

Closes a defined number of child windows based on the provided argument.
Values outside the valid range are normalized automatically.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseChildWindows",
    Argument = "{{$ --Argument:3}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseChildWindows")
    .setArgument("{{$ --Argument:3}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseChildWindows",
    argument: "{{$ --Argument:3}}"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseChildWindows",
    "argument": "{{$ --Argument:3}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseChildWindows",
    "argument": "{{$ --Argument:3}}"
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

Argument specifies the maximum number of child browser windows to close.
When omitted or non-numeric, all child windows beyond the main window are closed.
A value greater than the number of available children is silently clamped to that count.
A negative value is normalized to zero, resulting in no closures.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)
