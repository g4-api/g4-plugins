# Copy Files (CopyFiles)

[Table of Content](../Home.md)

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Copies a file, a directory, or a wildcard pattern to a destination, mirroring the `cp` and `copy` commands.
It runs on the machine that executes the automation, so it applies when the G4 Hub or worker and the automation share a machine or can both reach a shared physical location.

### Key Features and Functionality

| Feature            | Description                                                                                               |
| --- | --- |
| Single File Copy   | Copies one file onto a new file name, or into an existing folder or a path ending with a separator.       |
| Directory Copy     | Copies the top-level files of a directory, or the complete tree including empty folders with `Recursive`. |
| Wildcard Patterns  | Copies files that match `*` and `?` in the last `Source` segment into the `Destination` folder.           |
| Recursive Patterns | Matches the pattern in every subfolder with `Recursive` and keeps the relative folder structure.          |
| Overwrite Control  | Overwrites existing files by default and preserves them when `NoClobber` is present.                      |
| Path Resolution    | Accepts absolute, UNC, and relative paths; relative paths resolve from the process working directory.     |
| Result Reporting   | Publishes the copied count and paths to the session and the copied and skipped paths to the entity.       |
| Hidden Files       | Copies hidden and system files like any other file, matching the behavior of `cp`.                        |

### Usages in RPA

| Use Case             | Description                                                                            |
| --- | --- |
| Report Distribution  | Copies generated reports or exports to a shared folder where other teams pick them up. |
| Input Staging        | Copies source files into a working folder before a process reads or transforms them.   |
| Backup Before Change | Copies files to a backup folder with `NoClobber` before a step modifies the originals. |

### Usages in Automation Testing

| Use Case            | Description                                                                              |
| --- | --- |
| Test Data Setup     | Copies fixture files or folders into the location the application under test reads from. |
| Artifact Collection | Gathers logs, screenshots, or downloads into one folder after a test run.                |
| Result Archiving    | Copies a complete results tree to a network share for later review.                      |

### Destination Rules

| Source    | Destination Exists As Folder              | Destination Does Not Exist                            |
| --- | --- | --- |
| File      | Copied into the folder with its own name. | Copied to the destination as the new file name.       |
| Directory | Copied into the folder as a child folder. | The destination becomes the copied folder.            |
| Pattern   | Matches are copied into the folder.       | The folder is created when at least one file matches. |

### Failure Behavior

1. An empty `Source` or `Destination` stops the action.
2. A missing source file or directory stops the action.
3. A missing folder that hosts a wildcard pattern stops the action.
4. A pattern that matches no files succeeds and reports a count of zero.
5. Files copied before an error, such as denied access, stay at the destination.

## Examples

### Example No.1

### Copy a single file to a new name

Bind `Source` to a file and `Destination` to a path that does not exist as a folder.
CopyFiles writes the file to that path and creates any missing parent folders.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyFiles",
    Argument = "{{$ --Source:C:\Reports\report.pdf --Destination:C:\Archive\report-copy.pdf}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyFiles")
    .setArgument("{{$ --Source:C:\Reports\report.pdf --Destination:C:\Archive\report-copy.pdf}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "CopyFiles",
    argument: "{{$ --Source:C:\Reports\report.pdf --Destination:C:\Archive\report-copy.pdf}}"
};
```

**JSON:**

```js
{
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Reports\report.pdf --Destination:C:\Archive\report-copy.pdf}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Reports\report.pdf --Destination:C:\Archive\report-copy.pdf}}"
}
```

### Example No.2

### Copy a directory tree to a network share

Enable `Recursive` to copy a directory with all of its subfolders.
CopyFiles mirrors the tree, including empty folders, at the shared destination.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyFiles",
    Argument = "{{$ --Source:C:\Automation\Results --Destination:\\fileserver\share\Results --Recursive}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyFiles")
    .setArgument("{{$ --Source:C:\Automation\Results --Destination:\\fileserver\share\Results --Recursive}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "CopyFiles",
    argument: "{{$ --Source:C:\Automation\Results --Destination:\\fileserver\share\Results --Recursive}}"
};
```

**JSON:**

```js
{
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Automation\Results --Destination:\\fileserver\share\Results --Recursive}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Automation\Results --Destination:\\fileserver\share\Results --Recursive}}"
}
```

### Example No.3

### Collect log files without overwriting existing copies

Use a wildcard pattern with `Recursive` to gather matching files from every subfolder.
Enable `NoClobber` so files that already exist at the destination are skipped and reported.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyFiles",
    Argument = "{{$ --Source:C:\Logs\*.log --Destination:C:\Collected --Recursive --NoClobber}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyFiles")
    .setArgument("{{$ --Source:C:\Logs\*.log --Destination:C:\Collected --Recursive --NoClobber}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "CopyFiles",
    argument: "{{$ --Source:C:\Logs\*.log --Destination:C:\Collected --Recursive --NoClobber}}"
};
```

**JSON:**

```js
{
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Logs\*.log --Destination:C:\Collected --Recursive --NoClobber}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:C:\Logs\*.log --Destination:C:\Collected --Recursive --NoClobber}}"
}
```

### Example No.4

### Copy top-level files using relative paths

Provide relative `Source` and `Destination` paths to resolve them from the process working directory.
Without `Recursive`, CopyFiles copies only the files at the top level of the source directory.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyFiles",
    Argument = "{{$ --Source:.\input --Destination:..\output}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyFiles")
    .setArgument("{{$ --Source:.\input --Destination:..\output}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "CopyFiles",
    argument: "{{$ --Source:.\input --Destination:..\output}}"
};
```

**JSON:**

```js
{
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:.\input --Destination:..\output}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "CopyFiles",
    "argument": "{{$ --Source:.\input --Destination:..\output}}"
}
```

## Output Parameter

### Copy Files Count (CopyFiles:Count)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The number of files copied by the action.
Files skipped because of `NoClobber` are not counted.

### Copy Files Files (CopyFiles:Files)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

A JSON array of the destination paths of every copied file.
It can be referenced by downstream rules, for example to assert or process each copied file.

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the `Source`, `Destination`, `Recursive`, and `NoClobber` parameters through a G4 parameter expression.
Values can come from macros or data columns, so one rule can copy different paths in each run.

## Parameters

### Source (Source)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The source file, directory, or wildcard pattern to copy.
Wildcards `*` and `?` are supported only in the last path segment.
Absolute, UNC, and relative paths are accepted; relative paths resolve from the process working directory.

### Destination (Destination)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The target file or folder using cp-style rules.
An existing folder or a path ending with a separator receives the copy; any other path becomes the new name.
Missing parent folders are created.

### Recursive (Recursive)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Copies directories with all subfolders, including empty ones, when present.
With a wildcard pattern, it also matches files in every subfolder and keeps their relative structure.

### No Clobber (NoClobber)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Skips files that already exist at the destination instead of overwriting them when present.
Skipped destination paths are reported in the entity `Skipped` field.

## Scope

* Any
