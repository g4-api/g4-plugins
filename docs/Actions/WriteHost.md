# Write Host (WriteHost)

[Table of Content](../Home.md)

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Prints informational messages during automation execution for immediate visibility.
It takes a given argument and writes it to the console/host output so users can see what happened at each step.
This helps track progress and diagnose issues in real time.

### Key Features and Functionality

| Feature          | Description                                                              |
| --- | --- |
| Console Output   | Write the content of the `Argument` property to the host/console output. |
| Debugging Aid    | Print key events and details to help diagnose and fix issues.            |

### Usages in RPA

| Use Case           | Description                                                                  |
| --- | --- |
| Execution Tracking | Print key points to see the flow of an automated task and confirm steps ran. |
| Debugging          | Print messages that help identify where and why a process failed.            |
| Status Output      | Print important data or status updates during automation.                    |

### Usages in Automation Testing

| Use Case              | Description                                                                          |
| --- | --- |
| Test Execution Output | Print messages during test runs to understand test flow and state.                   |
| Debugging Tests       | Print details that help pinpoint failures or unexpected behavior in automated tests. |
| Recording Test Data   | Print test inputs, outputs, and results for later analysis and verification.         |

## Examples

### Example No.1

### Write a Static Console Message

Print a simple, static message to the console during automation execution.
It uses the `WriteHost` plugin with the argument set to "Writing a simple message".
Host output is produced for visibility during execution.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteHost",
    Argument = "Writing a simple message"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteHost")
    .setArgument("Writing a simple message");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "WriteHost",
    argument: "Writing a simple message"
};
```

**JSON:**

```js
{
    "pluginName": "WriteHost",
    "argument": "Writing a simple message"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "WriteHost",
    "argument": "Writing a simple message"
}
```

### Example No.2

### Write a Dynamic Parameter Value to Console

Retrieve a dynamic, session-scoped parameter and print its value to the console.
It uses the `WriteHost` plugin with the argument set to `{{$Get-Parameter --Name:MyParam --Scope:Session}}`.
Host output is produced for visibility during execution.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteHost",
    Argument = "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteHost")
    .setArgument("{{$Get-Parameter --Name:MyParam --Scope:Session}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "WriteHost",
    argument: "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

**JSON:**

```js
{
    "pluginName": "WriteHost",
    "argument": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "WriteHost",
    "argument": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```

### Example No.3

### Write an Expression-Based Status Message

Print a status message that combines a fixed prefix with a dynamic machine-scoped parameter value.
Uses the `WriteHost` plugin with the argument `Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}`.
The expression is resolved at runtime and the resulting value is printed to the console output.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteHost",
    Argument = "Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteHost")
    .setArgument("Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "WriteHost",
    argument: "Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}"
};
```

**JSON:**

```js
{
    "pluginName": "WriteHost",
    "argument": "Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "WriteHost",
    "argument": "Job: {{$Get-Parameter --Name:JobName --Scope:Machine}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Text or information to print to the console/host output.
It can be a fixed phrase or a value that changes at runtime.
Clear messages help track what the system does in real time.

## Scope

* Any
