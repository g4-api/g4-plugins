# Close Browser (CloseBrowser)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Terminates the current browser session by closing the browser window and disposing of the WebDriver instance.
It ensures that all browser resources are properly released, preventing orphaned processes from consuming system memory.
The action performs both a session quit and a resource disposal, guaranteeing a clean teardown regardless of the session state.

### Key Features and Functionality

| Feature             | Description                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------|
| Session Termination | Calls the WebDriver Quit method to end the active browser session.                             |
| Resource Disposal   | Disposes of the WebDriver instance to release all associated system resources.                 |
| Safe Teardown       | Uses a finally block to ensure disposal occurs even if the quit operation encounters an error. |

### Usages in RPA

| Use Case            | Description                                                                                       |
|---------------------|---------------------------------------------------------------------------------------------------|
| Workflow Completion | Closing the browser at the end of a robotic process to free resources for the next scheduled run. |
| Resource Management | Preventing orphaned browser processes from accumulating during long-running automation cycles.    |

### Usages in Automation Testing

| Use Case           | Description                                                                                            |
|--------------------|--------------------------------------------------------------------------------------------------------|
| Test Teardown      | Ensuring each test ends with a properly closed session to avoid state leakage between test cases.      |
| Parallel Execution | Releasing browser instances promptly so that parallel test runners do not exhaust available resources. |

## Examples

### Example No.1

### Terminate browser session and release resources

The CloseBrowser action closes the active browser window and disposes of the underlying WebDriver instance.
It calls Quit to end the session and Dispose to free all associated system resources.
No parameters or element targeting are required because the action operates on the current session directly.
This is the standard teardown step placed at the end of an automation workflow or test execution to prevent orphaned browser processes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseBrowser"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseBrowser");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseBrowser"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseBrowser"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseBrowser"
}
```
### Example No.2

### Terminate browser session using alias QuitSession

Closes the active browser session using the `QuitSession` alias, which resolves to the same implementation as `CloseBrowser`.
Use either alias interchangeably — the underlying Quit and Dispose sequence is identical.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "QuitSession"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("QuitSession");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "QuitSession"
};
```

_**JSON**_

```js
{
    "pluginName": "QuitSession"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "QuitSession"
}
```

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#delete-session](https://www.w3.org/TR/webdriver/#delete-session)
