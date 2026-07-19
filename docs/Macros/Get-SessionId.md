# Get Session Id (Get-SessionId)

[Table of Content](../Home.md)  

~12 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Retrieves the WebDriver session ID for the currently active automation session.
The session ID uniquely identifies the running driver instance and is required when performing session-specific operations outside the normal plugin pipeline.

### Key Features and Functionality

| Feature              | Description                                                                                |
|----------------------|--------------------------------------------------------------------------------------------|
| Session ID Retrieval | Returns the opaque session ID string assigned to the current WebDriver session at runtime. |
| No Parameters        | Requires no input — the value is resolved automatically from the active driver instance.   |
| Workflow Integration | Injects the session ID into any argument or action that accepts a macro placeholder.       |

### Usages in RPA

| Use Case                   | Description                                                                                 |
|----------------------------|---------------------------------------------------------------------------------------------|
| Session-Specific API Calls | Supplies the session ID to REST endpoints or scripts that target a specific driver session. |
| Driver Mounting            | Allows a downstream job or stage to attach to an already-running driver by session ID.      |

### Usages in Automation Testing

| Use Case           | Description                                                                               |
|--------------------|-------------------------------------------------------------------------------------------|
| Session Handover   | Passes the session ID between test stages so they share the same browser or app instance. |
| Diagnostic Logging | Logs the active session ID alongside test results for easier debugging and traceability.  |

## Examples

### Example No.1

### Retrieve and Log the Current Session ID

Invoke `Get-SessionId` to obtain the current WebDriver session ID at runtime.
Log the session ID using the `WriteLog` plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "Current session ID is {{$Get-SessionId}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("Current session ID is {{$Get-SessionId}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "Current session ID is {{$Get-SessionId}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "Current session ID is {{$Get-SessionId}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "Current session ID is {{$Get-SessionId}}"
}
```
### Example No.2

### Retrieve Session ID and Send It to an Input

Invoke `Get-SessionId` to obtain the current WebDriver session ID at runtime.
Send the session ID as keystrokes to the element located by the CSS selector `#sessionInput` using the `SendKeys` plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-SessionId}}",
    Locator = "CssSelector",
    OnElement = "#sessionInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-SessionId}}")
    .setLocator("CssSelector")
    .setOnElement("#sessionInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-SessionId}}",
    locator: "CssSelector",
    onElement: "#sessionInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-SessionId}}",
    "locator": "CssSelector",
    "onElement": "#sessionInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-SessionId}}",
    "locator": "CssSelector",
    "onElement": "#sessionInput"
}
```

## Scope

* Any