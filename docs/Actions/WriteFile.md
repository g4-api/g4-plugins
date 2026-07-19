# Write File (WriteFile)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Writes text content to an absolute or explicitly relative file path.
It creates missing parent directories before saving the file.
Files with the same name at the target path are overwritten.

### Key Features and Functionality

| Feature                  | Description                                                                                  |
|--------------------------|----------------------------------------------------------------------------------------------|
| Absolute Paths           | Requires a fully qualified path unless the `Relative` switch is present.                     |
| Relative Paths           | Resolves the path from the process working directory when `Relative` is present.             |
| Directory Creation       | Creates missing parent directories with `Directory.CreateDirectory`.                         |
| Base64 Decoding          | Decodes `Content` with `ConvertFromBase64()` when `Base64` is present.                        |
| Optional Encryption      | Encrypts the final content with `Encrypt(key)` when `EncryptionKey` is provided.              |
| Overwrite Existing Files | Replaces an existing file with the same name instead of appending to it.                      |
| UTF-8 Output             | Writes the final value as UTF-8 text without a byte-order mark.                               |

### Processing Order

1. Resolve and validate the target path.
2. Decode `Content` when `Base64` is present.
3. Encrypt the resulting value when `EncryptionKey` is provided.
4. Create the parent directory when it does not exist.
5. Write or overwrite the target file.

## Examples

### Example No.1

### Write plain text to an absolute path

Bind `Path` and `Content` through the parameter expression to write UTF-8 text.
WriteFile creates missing parent directories and overwrites an existing file at the target path.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteFile",
    Argument = "{{$ --Path:C:\Automation\output.txt --Content:Hello from G4}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteFile")
    .setArgument("{{$ --Path:C:\Automation\output.txt --Content:Hello from G4}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteFile",
    argument: "{{$ --Path:C:\Automation\output.txt --Content:Hello from G4}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\output.txt --Content:Hello from G4}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\output.txt --Content:Hello from G4}}"
}
```
### Example No.2

### Write text to a relative path

Enable `Relative` to resolve `Path` from the process working directory.
WriteFile normalizes the resulting path and creates missing parent directories.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteFile",
    Argument = "{{$ --Path:..\..\docs\output.txt --Content:Hello from G4 --Relative}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteFile")
    .setArgument("{{$ --Path:..\..\docs\output.txt --Content:Hello from G4 --Relative}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteFile",
    argument: "{{$ --Path:..\..\docs\output.txt --Content:Hello from G4 --Relative}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:..\..\docs\output.txt --Content:Hello from G4 --Relative}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:..\..\docs\output.txt --Content:Hello from G4 --Relative}}"
}
```
### Example No.3

### Decode Base64 content before writing

Enable `Base64` to decode `Content` with `ConvertFromBase64()`.
WriteFile writes the decoded value as UTF-8 text.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteFile",
    Argument = "{{$ --Path:C:\Automation\decoded.txt --Content:SGVsbG8gZnJvbSBHNA== --Base64}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteFile")
    .setArgument("{{$ --Path:C:\Automation\decoded.txt --Content:SGVsbG8gZnJvbSBHNA== --Base64}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteFile",
    argument: "{{$ --Path:C:\Automation\decoded.txt --Content:SGVsbG8gZnJvbSBHNA== --Base64}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\decoded.txt --Content:SGVsbG8gZnJvbSBHNA== --Base64}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\decoded.txt --Content:SGVsbG8gZnJvbSBHNA== --Base64}}"
}
```
### Example No.4

### Encrypt content before writing

Provide `EncryptionKey` to encrypt `Content` before writing it.
WriteFile stores the encryption result directly without another Base64 conversion.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteFile",
    Argument = "{{$ --Path:C:\Automation\secret.txt --Content:Sensitive text --EncryptionKey:g4}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteFile")
    .setArgument("{{$ --Path:C:\Automation\secret.txt --Content:Sensitive text --EncryptionKey:g4}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteFile",
    argument: "{{$ --Path:C:\Automation\secret.txt --Content:Sensitive text --EncryptionKey:g4}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\secret.txt --Content:Sensitive text --EncryptionKey:g4}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\secret.txt --Content:Sensitive text --EncryptionKey:g4}}"
}
```
### Example No.5

### Decode and encrypt content before writing

Enable `Base64` and provide `EncryptionKey` to process `Content` in the required order.
WriteFile decodes the value, encrypts the decoded text, and writes the encryption result directly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteFile",
    Argument = "{{$ --Path:C:\Automation\decoded-secret.txt --Content:RGVjb2RlIGJlZm9yZSBlbmNyeXB0aW9u --Base64 --EncryptionKey:g4}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteFile")
    .setArgument("{{$ --Path:C:\Automation\decoded-secret.txt --Content:RGVjb2RlIGJlZm9yZSBlbmNyeXB0aW9u --Base64 --EncryptionKey:g4}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteFile",
    argument: "{{$ --Path:C:\Automation\decoded-secret.txt --Content:RGVjb2RlIGJlZm9yZSBlbmNyeXB0aW9u --Base64 --EncryptionKey:g4}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\decoded-secret.txt --Content:RGVjb2RlIGJlZm9yZSBlbmNyeXB0aW9u --Base64 --EncryptionKey:g4}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteFile",
    "argument": "{{$ --Path:C:\Automation\decoded-secret.txt --Content:RGVjb2RlIGJlZm9yZSBlbmNyeXB0aW9u --Base64 --EncryptionKey:g4}}"
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

Provides the `Path`, `Content`, `Relative`, `Base64`, and `EncryptionKey` parameters through a G4 parameter expression.

## Parameters

### Path (Path)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The target file path.
The path must be fully qualified unless `Relative` is present.

### Content (Content)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The text content to write.
The value is decoded first when `Base64` is present and then encrypted when `EncryptionKey` is provided.

### Relative (Relative)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Treats `Path` as relative to the process working directory when present.

### Base64 (Base64)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Decodes `Content` with `ConvertFromBase64()` before any encryption and file writing.

### Encryption Key (EncryptionKey)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

An optional key used to encrypt the decoded or original content before writing.
The result of `Encrypt(key)` is written directly without additional Base64 encoding.

## Scope

* Any