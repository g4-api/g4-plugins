# Write Log (WriteLog)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `WriteLog` plugin is designed to write log messages during the execution of automation scripts. 
It is particularly useful for debugging, tracking the flow of execution, and recording important information.

### Key Features and Functionality

| Feature             | Description                                                                                     |
|---------------------|-------------------------------------------------------------------------------------------------|
| Logging Information | Logs the content of the `Argument` property to the log using the logging framework.             |
| Debugging Aid       | Helps in understanding the flow of automation, capturing important events, or debugging issues. |

### Usages in RPA

| Usage               | Description                                                            |
|---------------------|------------------------------------------------------------------------|
| Execution Tracking  | Track the flow of execution by logging key points in the automation.   |
| Debugging           | Capture log messages to help debug issues in the automation process.   |
| Information Logging | Record important information during the execution of automation tasks. |

### Usages in Automation Testing

| Usage               | Description                                                                             |
|---------------------|-----------------------------------------------------------------------------------------|
| Test Execution Logs | Capture logs during test execution to understand the flow and state of tests.           |
| Debugging Tests     | Log messages to help debug test failures or unexpected behavior during automated tests. |
| Recording Test Data | Log test data and results for analysis and verification purposes.                       |

## Examples

### Example No.1

Logs a simple message during the execution of the automation script.

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

Logs the value of a dynamic parameter during the execution of the automation script.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the message or information to be logged. This can be a static message or a dynamic value retrieved from parameters.
