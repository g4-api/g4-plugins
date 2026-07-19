# Stop Flow (StopFlow)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Ends the current automation session by disposing the active WebDriver and removing its handle from the global registry. This prevents resource leaks and avoids accidental reuse of a stale driver in later steps.

### Key Features and Functionality

| Feature               | Description                                                         |
|-----------------------|---------------------------------------------------------------------|
| Safe Teardown         | Disposes the active WebDriver instance and cleans up references.    |
| Idempotent Operation  | Multiple calls are safe; no error if the session is already closed. |
| Registry Cleanup      | Removes the driver from the global registry to prevent later reuse. |
| No Arguments Required | Works on the current session; no configuration needed.              |

### Usages in RPA

| Use Case         | Description                                                            |
|------------------|------------------------------------------------------------------------|
| Flow Termination | Place as the final step to ensure browser and driver are fully closed. |
| Resource Hygiene | Free system resources in long-running robots or shared environments.   |

### Usages in Automation Testing

| Use Case        | Description                                                                    |
|-----------------|--------------------------------------------------------------------------------|
| Test Teardown   | Add to teardown stages to guarantee clean driver disposal between test runs.   |
| Isolation       | Reset state before starting a new test requiring a fresh browser session.      |
| Suite Cleanup   | Close all lingering sessions at the end of a test suite to free resources.     |

### Aliases

| Alias     | Notes                                      |
|-----------|--------------------------------------------|
| Stop      | Interchangeable with StopFlow.             |
| EndFlow   | Interchangeable with StopFlow.             |

## Examples

### Example No.1

### Stop and Dispose Current Session

Disposes the active WebDriver and removes its registry entry. Use at the end of a workflow to guarantee the browser and driver are fully closed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StopFlow"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StopFlow");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "StopFlow"
};
```

_**JSON**_

```js
{
    "pluginName": "StopFlow"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "StopFlow"
}
```
### Example No.2

### Mid-Flow Session Reset Using Stop Alias

Tears down the current browser session mid-workflow using the `Stop` alias before a fresh session is initialized.
Behaviour is identical to `StopFlow`; aliases are interchangeable.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Stop"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Stop");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Stop"
};
```

_**JSON**_

```js
{
    "pluginName": "Stop"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Stop"
}
```
### Example No.3

### Test Teardown Using EndFlow Alias

Disposes the active WebDriver at the end of a test run using the `EndFlow` alias.
Place in the teardown stage to guarantee clean driver disposal between test executions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "EndFlow"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("EndFlow");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "EndFlow"
};
```

_**JSON**_

```js
{
    "pluginName": "EndFlow"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "EndFlow"
}
```

## Scope

* Any