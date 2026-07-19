# Convert To Base64 (ConvertToBase64)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Converts text or expression values to Base64 for safe transport, storage, and downstream reuse.
It takes the value of the `Argument` property, optionally filters it with a `RegularExpression`, and encodes the result.
The encoded output is stored in the session as `ConvertToBase64:Result` and exposed through the response entity.

### Key Features and Functionality

| Feature             | Description                                                                                 |
|---------------------|---------------------------------------------------------------------------------------------|
| Base64 Encoding     | Converts the `Argument` value to a Base64 string.                                           |
| Regex Pre-filtering | Applies `RegularExpression` to extract a specific portion of the argument before encoding.  |
| Session Output      | Stores the encoded result in the session as `ConvertToBase64:Result` for downstream access. |

### Usages in RPA

| Use Case            | Description                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------|
| Credential Encoding | Encode a username or password to Base64 for use in HTTP Basic Auth headers.                    |
| Data Transport      | Encode structured text before passing it to a downstream API or system requiring Base64 input. |
| Partial Extraction  | Use a regex to isolate a specific field from a longer string and encode only that portion.     |

### Usages in Automation Testing

| Use Case            | Description                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------|
| Header Construction | Build Base64-encoded authorization headers for API test steps without manual encoding.         |
| Value Verification  | Encode expected values to compare against Base64-encoded API responses in assertions.          |
| Selective Encoding  | Extract a substring with regex and encode it for use in parameterized test data or assertions. |

## Examples

### Example No.1

### Encode a Static String to Base64

Encode a fixed text value to Base64 during automation execution.
It uses the `ConvertToBase64` plugin with the argument set to `Hello, World!`.
No `RegularExpression` is specified, so the full argument value is encoded.
The result is stored in the session as `ConvertToBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertToBase64",
    Argument = "Hello, World!"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertToBase64")
    .setArgument("Hello, World!");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertToBase64",
    argument: "Hello, World!"
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertToBase64",
    "argument": "Hello, World!"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertToBase64",
    "argument": "Hello, World!"
}
```
### Example No.2

### Encode a Regex-Matched Portion to Base64

Extract a specific part of a string with a regular expression and encode only that portion.
It uses the `ConvertToBase64` plugin with the argument `Order-12345-Details` and `regularExpression` set to `\d+`.
The first numeric sequence `12345` is matched and encoded to Base64.
The result is stored in the session as `ConvertToBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertToBase64",
    Argument = "Order-12345-Details",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertToBase64")
    .setArgument("Order-12345-Details")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertToBase64",
    argument: "Order-12345-Details",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertToBase64",
    "argument": "Order-12345-Details",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertToBase64",
    "argument": "Order-12345-Details",
    "regularExpression": "\d+"
}
```
### Example No.3

### Encode a Session Parameter Value to Base64

Encode the runtime value of a session parameter to Base64 during automation execution.
It uses the `ConvertToBase64` plugin with the argument set to `{{$Get-Parameter --Name:Username --Scope:Session}}`.
The G4 expression is resolved at runtime, retrieving the current value of the `Username` session parameter before encoding.
No `RegularExpression` is specified, so the full resolved value is encoded and stored in the session as `ConvertToBase64:Result`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ConvertToBase64",
    Argument = "{{$Get-Parameter --Name:Username --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ConvertToBase64")
    .setArgument("{{$Get-Parameter --Name:Username --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ConvertToBase64",
    argument: "{{$Get-Parameter --Name:Username --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "ConvertToBase64",
    "argument": "{{$Get-Parameter --Name:Username --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ConvertToBase64",
    "argument": "{{$Get-Parameter --Name:Username --Scope:Session}}"
}
```

## Output Parameter

### Convert To Base64 Result (ConvertToBase64:Result)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The session parameter that holds the Base64-encoded result.
The parameter contains the encoded value produced from the argument after optional regex pre-filtering.
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

The value to encode to Base64.
Accepts a fixed string or a G4 expression that resolves at runtime.
If a `RegularExpression` is also set, only the first matched portion of this value is encoded.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

A regular expression applied to the `Argument` before encoding.
Only the first match is encoded; if there is no match, an empty string is encoded.
Omit this property or use `(si).*` to encode the entire argument value.

## Scope

* Any