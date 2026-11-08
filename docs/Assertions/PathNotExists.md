# Path Not Exists (PathNotExists)

[Table of Content](../Home.md)

~13 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Asserts that neither a file nor a directory exists at the path supplied in `onElement`.
It runs on the machine that executes the automation, so it applies when the G4 Hub or worker and the automation share a machine or can both reach a shared physical location.

### Key Features and Functionality

| Feature            | Description                                                                                           |
| --- | --- |
| File And Directory | Evaluates to true only when no file and no directory exists at the path.                              |
| Path Resolution    | Accepts absolute, UNC, and relative paths; relative paths resolve from the process working directory. |
| Dynamic Paths      | Accepts macros and parameters in `onElement`, such as a path stored in a session parameter.           |

### Usages in RPA

| Use Case             | Description                                                                                |
| --- | --- |
| Duplicate Prevention | Confirms that an output file does not exist yet so a run does not replace earlier results. |
| Lock File Check      | Confirms that a lock file is gone before a process starts.                                 |

### Usages in Automation Testing

| Use Case             | Description                                                                  |
| --- | --- |
| Cleanup Verification | Confirms that temporary files or folders were removed after a workflow step. |
| Precondition Check   | Confirms that a target path is free before a step creates it.                |

### Limitations

An unreachable network share or denied access is reported as a missing path, so the assertion evaluates to true.
Pair it with `PathExists` on the share root when reachability matters.

## Examples

### Example No.1

### Assert that a temporary file was removed

Use the `Assert` plugin with the `PathNotExists` condition and set `onElement` to the file path.
The assertion passes when no file or directory exists at that path.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PathNotExists}}",
    OnElement = "C:\Automation\Temp\session.lock"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PathNotExists}}")
    .setOnElement("C:\Automation\Temp\session.lock");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PathNotExists}}",
    onElement: "C:\Automation\Temp\session.lock"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathNotExists}}",
    "onElement": "C:\Automation\Temp\session.lock"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathNotExists}}",
    "onElement": "C:\Automation\Temp\session.lock"
}
```

### Example No.2

### Assert that an output folder is free before a run

Set `onElement` to a relative directory path resolved from the process working directory.
The assertion passes when the folder does not exist yet.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PathNotExists}}",
    OnElement = ".\output"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PathNotExists}}")
    .setOnElement(".\output");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PathNotExists}}",
    onElement: ".\output"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathNotExists}}",
    "onElement": ".\output"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PathNotExists}}",
    "onElement": ".\output"
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
