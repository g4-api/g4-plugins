# Write Log (WriteLog)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Records informational messages during automation execution for display and analysis. It takes a given argument and writes it into the system log so users can see what happened at each step. This helps track progress and diagnose issues without worrying about different log levels.

### Key Features and Functionality

| Feature           | Description                                                             |
|-------------------|-------------------------------------------------------------------------|
| Informational Log | Write the content of the `Argument` property as an informational entry. |
| Debugging Aid     | Capture key events and details to help diagnose and fix issues.         |

### Usages in RPA

| Use Case            | Description                                                                |
|---------------------|----------------------------------------------------------------------------|
| Execution Tracking  | Log key points to see the flow of an automated task and confirm steps ran. |
| Debugging           | Capture messages that help identify where and why a process failed.        |
| Information Logging | Record important data or status updates during automation.                 |

### Usages in Automation Testing

| Use Case            | Description                                                                            |
|---------------------|----------------------------------------------------------------------------------------|
| Test Execution Logs | Record messages during test runs to understand test flow and state.                    |
| Debugging Tests     | Log details that help pinpoint failures or unexpected behavior in automated tests.     |
| Recording Test Data | Save test inputs, outputs, and results to the log for later analysis and verification. |

## Examples

### Example No.1

### Write a Static Log Message

Write a simple, static message to the log during automation execution.
It uses the `WriteLog` plugin with the argument set to "Logging a simple message".
The message is written to the system log as an informational entry.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "Logging a simple message"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("Logging a simple message");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "Logging a simple message"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "Logging a simple message"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "Logging a simple message"
}
```
### Example No.2

### Write a Dynamic Parameter Value to Log

Retrieve a dynamic, session-scoped parameter and write its value to the log.
It uses the `WriteLog` plugin with the argument set to `{{$Get-Parameter --Name:MyParam --Scope:Session}}`.
The message is written to the system log as an informational entry.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("{{$Get-Parameter --Name:MyParam --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```
### Example No.3

### Log an Application-Scoped Parameter Using the Log Alias

Write the value of an application-scoped parameter to the log using the `Log` alias.
Uses the `Log` plugin name with the argument `{{$Get-Parameter --Name:AppVersion --Scope:Application}}`.
The `Log` alias is interchangeable with `WriteLog`; the message is written to the system log as an informational entry.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Log",
    Argument = "{{$Get-Parameter --Name:AppVersion --Scope:Application}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Log")
    .setArgument("{{$Get-Parameter --Name:AppVersion --Scope:Application}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Log",
    argument: "{{$Get-Parameter --Name:AppVersion --Scope:Application}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Log",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Log",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application}}"
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

Text or information to record in the log.
It can be a fixed phrase or a value that changes at runtime.
Clear log messages help track what the system does.

## Scope

* Any