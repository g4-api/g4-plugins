# Add File (AddFile)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Reads a file from the path in the rule argument and returns its content as Base64 in the response.
Lets an automation carry a file inside the flow, for example to attach it to a mail, post it to an API, or store it with test evidence.
Treats text and binary files differently, so text can be filtered with a regular expression while binary bytes stay exact.

### Key Features and Functionality

| Feature                 | Description                                                                                                                   |
| --- | --- |
| Base64 response         | Returns the file content as Base64 in the `File` response entity key.                                                         |
| Text regex filter       | Applies the rule regular expression to text files and returns only the matched text, or an empty string when nothing matches. |
| Whole text by default   | Uses the `(?s).*` pattern when no regular expression is set, so the whole text is returned.                                   |
| Exact binary bytes      | Ignores the regular expression for binary files and returns the raw bytes, so images and archives stay valid.                 |
| Content-based detection | Treats a file as text when it starts with a UTF-8 or UTF-16 byte order mark, or when it has no zero byte and is valid UTF-8.  |
| No disk write           | Only reads the file; the result lives in the response and the session.                                                        |
| Session list            | Appends every value to the `AddFile:Files` session parameter, so several files can be collected in one session.               |

### Usages in RPA

| Use Case         | Description                                                                                       |
| --- | --- |
| Mail attachments | Add a report or invoice file so a later step can send it as a mail attachment.                    |
| API uploads      | Embed a document as Base64 in the body of an HTTP request to a service that accepts Base64 files. |
| Value extraction | Pull one value, such as an order number, out of a text export with a regular expression.          |

### Usages in Automation Testing

| Use Case              | Description                                                                        |
| --- | --- |
| Evidence capture      | Add log files or downloaded files to the response so the test report carries them. |
| Content checks        | Extract a line from a generated text file and assert on the decoded value.         |
| Download verification | Return a downloaded binary file as Base64 to compare it with an expected file.     |

### Notes

Text in a legacy code page, such as Windows-1252 with accented characters, is not valid UTF-8 and is returned as exact bytes without the regular expression.
The whole file is loaded into memory, so very large files increase memory use and response size.

## Examples

### Example No.1

### Add a whole text file to the response as Base64

The argument is the path of a CSV export, and no regular expression is set.
The whole text is encoded as UTF-8 Base64 and returned in the `File` entity key.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddFile",
    Argument = "C:\Data\orders.csv"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddFile")
    .setArgument("C:\Data\orders.csv");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddFile",
    argument: "C:\Data\orders.csv"
};
```

**JSON:**

```js
{
    "pluginName": "AddFile",
    "argument": "C:\Data\orders.csv"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddFile",
    "argument": "C:\Data\orders.csv"
}
```

### Example No.2

### Extract an invoice number from a text file with a regex

The argument is the path of a text invoice, and the regular expression keeps only the digits after `Invoice: `.
Only the matched number is encoded as Base64, so a later step gets the value without parsing the file.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddFile",
    Argument = "C:\Data\invoice.txt",
    RegularExpression = "(?<=Invoice: )\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddFile")
    .setArgument("C:\Data\invoice.txt")
    .setRegularExpression("(?<=Invoice: )\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddFile",
    argument: "C:\Data\invoice.txt",
    regularExpression: "(?<=Invoice: )\d+"
};
```

**JSON:**

```js
{
    "pluginName": "AddFile",
    "argument": "C:\Data\invoice.txt",
    "regularExpression": "(?<=Invoice: )\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddFile",
    "argument": "C:\Data\invoice.txt",
    "regularExpression": "(?<=Invoice: )\d+"
}
```

### Example No.3

### Attach an image file as Base64 for a later step

The argument is the path of a PNG chart, which is a binary file.
The exact bytes are returned as Base64, ready to attach to a mail or embed in an HTTP request.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddFile",
    Argument = "C:\Reports\chart.png"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddFile")
    .setArgument("C:\Reports\chart.png");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddFile",
    argument: "C:\Reports\chart.png"
};
```

**JSON:**

```js
{
    "pluginName": "AddFile",
    "argument": "C:\Reports\chart.png"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddFile",
    "argument": "C:\Reports\chart.png"
}
```

### Example No.4

### Read a file from a relative path into the session list

The argument is a relative path, which is resolved against the working directory of the run.
The value is appended to `AddFile:Files`, so several AddFile steps build one list of files.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddFile",
    Argument = "Resources/settings.json"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddFile")
    .setArgument("Resources/settings.json");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddFile",
    argument: "Resources/settings.json"
};
```

**JSON:**

```js
{
    "pluginName": "AddFile",
    "argument": "Resources/settings.json"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddFile",
    "argument": "Resources/settings.json"
}
```

## Output Parameter

### Add File Files (AddFile:Files)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

A JSON array with the Base64 value of every AddFile call in the session, in call order.
Each call appends its value, so several files can be collected and handed to one later step.
The session value itself is Base64-encoded, so decode it before reading the array.

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

The path of the file to add, such as `C:\Data\invoice.txt` or `Resources/settings.json`.
A relative path is resolved against the working directory, and a missing file fails the step.
The path is the whole argument, so it needs no `--` switch and may contain spaces.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | (?si).*           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Filters the decoded text of a text file and returns only the first match, such as `(?<=Invoice: )\d+` for an invoice number.
Defaults to a pattern that matches the whole text, and a pattern that does not match returns an empty string.
Binary files ignore this property and always return their exact bytes.

## Scope

* Any
