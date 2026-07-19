# Convert From Base64 (ConvertFromBase64)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Decodes Base64-encoded text back to its original form for further processing and downstream reuse.
It takes the Base64-encoded value of the `Argument` property, decodes it, and optionally filters the result with a `RegularExpression`.
The decoded output is stored in the session as `ConvertFromBase64:Result` and exposed through the response entity.

### Key Features and Functionality

| Feature              | Description                                                                                      |
|----------------------|--------------------------------------------------------------------------------------------------|
| Base64 Decoding      | Decodes the `Argument` value from Base64 back to its original string.                           |
| Regex Post-filtering | Applies `RegularExpression` to extract a specific portion of the decoded result.                 |
| Session Output       | Stores the decoded result in the session as `ConvertFromBase64:Result` for downstream access.   |

### Usages in RPA

| Use Case               | Description                                                                                           |
|------------------------|-------------------------------------------------------------------------------------------------------|
| Credential Decoding    | Decode Base64-encoded credentials retrieved from a secure store before use in a workflow step.        |
| API Response Decoding  | Decode a Base64-encoded field in an API response before passing its value to subsequent actions.      |
| Partial Extraction     | Use a regex to isolate a specific field from the decoded string and pass only that portion forward.   |

### Usages in Automation Testing

| Use Case              | Description                                                                                              |
|-----------------------|----------------------------------------------------------------------------------------------------------|
| Response Verification | Decode a Base64-encoded API response field and assert its value in a test assertion.                    |
| Test Data Decoding    | Decode Base64-encoded test data stored in session parameters for use in parameterized assertions.       |
| Selective Extraction  | Extract a substring from the decoded value with regex for targeted comparison in test steps.            |

## Examples

### Example No.1

### Decode a Static Base64 String

Decode a fixed Base64 value back to its original text during automation execution.
It uses the `ConvertFromBase64` plugin with the argument set to `SGVsbG8sIFdvcmxkIQ==`.
No `RegularExpression` is specified, so the full decoded value is kept.
The result is stored in the session as `ConvertFromBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertFromBase64",
    Argument = "SGVsbG8sIFdvcmxkIQ=="
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertFromBase64")
    .setArgument("SGVsbG8sIFdvcmxkIQ==");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertFromBase64",
    argument: "SGVsbG8sIFdvcmxkIQ=="
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertFromBase64",
    "argument": "SGVsbG8sIFdvcmxkIQ=="
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertFromBase64",
    "argument": "SGVsbG8sIFdvcmxkIQ=="
}
```
### Example No.2

### Decode Base64 and Extract a Specific Portion

Decode a Base64 string and extract only a specific part of the decoded result using a regular expression.
It uses the `ConvertFromBase64` plugin with the argument `T3JkZXItMTIzNDUtRGV0YWlscw==` and `regularExpression` set to `\d+`.
The argument decodes to `Order-12345-Details` and the first numeric sequence `12345` is extracted.
The result is stored in the session as `ConvertFromBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertFromBase64",
    Argument = "T3JkZXItMTIzNDUtRGV0YWlscw==",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertFromBase64")
    .setArgument("T3JkZXItMTIzNDUtRGV0YWlscw==")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertFromBase64",
    argument: "T3JkZXItMTIzNDUtRGV0YWlscw==",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertFromBase64",
    "argument": "T3JkZXItMTIzNDUtRGV0YWlscw==",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertFromBase64",
    "argument": "T3JkZXItMTIzNDUtRGV0YWlscw==",
    "regularExpression": "\d+"
}
```
### Example No.3

### Decode a Session Parameter Value from Base64

Decode a Base64-encoded value stored in a session parameter during automation execution.
It uses the `ConvertFromBase64` plugin with the argument set to `{{$Get-Parameter --Name:EncodedToken --Scope:Session}}`.
The G4 expression is resolved at runtime, retrieving the current Base64 value of the `EncodedToken` session parameter before decoding.
No `RegularExpression` is specified, so the full decoded value is stored in the session as `ConvertFromBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertFromBase64",
    Argument = "{{$Get-Parameter --Name:EncodedToken --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertFromBase64")
    .setArgument("{{$Get-Parameter --Name:EncodedToken --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertFromBase64",
    argument: "{{$Get-Parameter --Name:EncodedToken --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertFromBase64",
    "argument": "{{$Get-Parameter --Name:EncodedToken --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertFromBase64",
    "argument": "{{$Get-Parameter --Name:EncodedToken --Scope:Session}}"
}
```

## Output Parameter

### Convert From Base64 Result (ConvertFromBase64:Result)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The session parameter that holds the decoded result.
The parameter contains the value produced from the Base64 argument after decoding and optional regex post-filtering.
Its value can be referenced by other parameters or expressions in downstream workflow steps.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

The Base64-encoded value to decode.
Accepts a fixed Base64 string or a G4 expression that resolves to one at runtime.
If a `RegularExpression` is also set, only the first matched portion of the decoded result is kept.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

A regular expression applied to the decoded string after Base64 decoding.
Only the first match is kept; if there is no match, an empty string is stored.
Omit this property or use `(si).*` to keep the entire decoded value.

## Scope

* Any