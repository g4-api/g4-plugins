# Path Exists (PathExists)

[Table of Content](../Home.md)

~16 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Asserts that a file or a directory exists at the path supplied in `onElement`.
It runs on the machine that executes the automation, so it applies when the G4 Hub or worker and the automation share a machine or can both reach a shared physical location.

### Key Features and Functionality

| Feature           | Description                                                                                           |
| --- | --- |
| File Or Directory | Evaluates to true when either a file or a directory exists at the path.                               |
| Path Resolution   | Accepts absolute, UNC, and relative paths; relative paths resolve from the process working directory. |
| Dynamic Paths     | Accepts macros and parameters in `onElement`, such as a path stored in a session parameter.           |

### Usages in RPA

| Use Case           | Description                                                               |
| --- | --- |
| Input Availability | Confirms that an input file is present before a process reads it.         |
| Share Availability | Confirms that a shared folder is reachable before files are copied there. |

### Usages in Automation Testing

| Use Case            | Description                                                                        |
| --- | --- |
| Output Verification | Confirms that a report, export, or download was produced at the expected location. |
| Copy Verification   | Confirms that files copied by `CopyFiles` reached their destination.               |

### Limitations

An unreachable network share or denied access is reported as a missing path, so the assertion evaluates to false.

## Examples

### Example No.1

### Assert that an exported report exists

Use the `Assert` plugin with the `PathExists` condition and set `onElement` to the expected file path.
The assertion passes when the file exists.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PathExists}}",
    OnElement = "C:\Automation\Exports\report.csv"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PathExists}}")
    .setOnElement("C:\Automation\Exports\report.csv");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PathExists}}",
    onElement: "C:\Automation\Exports\report.csv"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "C:\Automation\Exports\report.csv"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "C:\Automation\Exports\report.csv"
}
```

### Example No.2

### Assert that a shared results folder exists

Set `onElement` to a UNC directory path to verify that a shared location is available.
The assertion passes when the directory exists and is reachable.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PathExists}}",
    OnElement = "\\fileserver\share\Results"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PathExists}}")
    .setOnElement("\\fileserver\share\Results");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PathExists}}",
    onElement: "\\fileserver\share\Results"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "\\fileserver\share\Results"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "\\fileserver\share\Results"
}
```

### Example No.3

### Assert that a downloaded file stored in a session parameter exists

Resolve the path at run time with the `Get-Parameter` macro.
The assertion passes when the file at the stored path exists.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PathExists}}",
    OnElement = "{{$Get-Parameter --Name:DownloadedFile --Scope:Session}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PathExists}}")
    .setOnElement("{{$Get-Parameter --Name:DownloadedFile --Scope:Session}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PathExists}}",
    onElement: "{{$Get-Parameter --Name:DownloadedFile --Scope:Session}}"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "{{$Get-Parameter --Name:DownloadedFile --Scope:Session}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathExists}}",
    "onElement": "{{$Get-Parameter --Name:DownloadedFile --Scope:Session}}"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

The file or directory path to check.
Absolute, UNC, and relative paths are accepted; relative paths resolve from the process working directory.

## Scope

* Any
