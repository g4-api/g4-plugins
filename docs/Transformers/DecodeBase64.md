# Decode Base64 (DecodeBase64)

[Table of Content](../Home.md)

~12 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `DecodeBase64` transformer plugin is to decode a Base64 input back to UTF-8 text.
This is particularly useful when a value extracted or produced by a previous step is Base64-encoded and must be read, compared, or processed as plain text.
If the input is not a valid Base64 value, it is returned unchanged.

### Key Features and Functionality

| Feature              | Description                                                                                  |
| --- | --- |
| Base64 Decoding      | Decodes a Base64 input to text using UTF-8 bytes.                                            |
| Safe Fallback        | Returns the input unchanged when it is not a valid Base64 value.                             |
| Scope Selection      | Transforms either an entity field of the previous step or a session parameter.               |
| Easy Integration     | Simple to chain with other transformers, for example before `Trim` or `ClearLines`.          |

### Usages in RPA

| Usage                | Description                                                                                  |
| --- | --- |
| Data Intake          | Decode Base64 payloads returned by an API or system before using them in later steps.        |
| Content Inspection   | Decode encoded values captured from a page or file to read or log their content.             |
| Data Normalization   | Turn encoded values into plain text before storing them in a database or report.             |

### Usages in Automation Testing

| Usage                | Description                                                                                  |
| --- | --- |
| Value Verification   | Decode Base64 values from API responses and compare the plain text in assertions.            |
| Test Data Handoff    | Decode encoded test data before passing it to downstream steps.                              |

## Examples

### Example No.1

Decode a Base64 input to text.

The `DecodeBase64` transformer is utilized to decode the provided Base64 value to text.
The value `SGVsbG8sIFdvcmxkIQ==` is decoded to `Hello, World!`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "DecodeBase64",
    OnElement = "SGVsbG8sIFdvcmxkIQ=="
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("DecodeBase64")
    .setOnElement("SGVsbG8sIFdvcmxkIQ==");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "DecodeBase64",
    onElement: "SGVsbG8sIFdvcmxkIQ=="
};
```

**JSON:**

```js
{
    "pluginName": "DecodeBase64",
    "onElement": "SGVsbG8sIFdvcmxkIQ=="
}
```

**Python:**

```python
action_rule = {
    "pluginName": "DecodeBase64",
    "onElement": "SGVsbG8sIFdvcmxkIQ=="
}
```

### Example No.2

Decode the `Token` field extracted from content and trim the decoded text.

The `DecodeBase64` transformer is applied to the `Token` field to decode its Base64 value.
Subsequently, the `Trim` transformer removes leading and trailing whitespace from the decoded text.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//span[@id='Token']",
    RegularExpression = "(?<=\w+:).*"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//span[@id='Token']")
    .setRegularExpression("(?<=\w+:).*");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//span[@id='Token']",
    regularExpression: "(?<=\w+:).*"
};
```

**JSON:**

```js
{
    "pluginName": "contentType",
    "onElement": ".//span[@id='Token']",
    "regularExpression": "(?<=\w+:).*"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//span[@id='Token']",
    "regularExpression": "(?<=\w+:).*"
}
```

## Output Parameter

### Transformer Result (TransformerResult)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

The result of the transformation after decoding the Base64 input to text.
This value can be of any type, depending on the context in which the transformer is used.

## Properties

### On Attribute (OnAttribute)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Entity            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the scope of the transformation.
This property allows you to choose whether to transform data from the entity context or the session context.

#### Values

##### Entity

The transformer acts on the entity fields created by the previous action.
This is the default behavior.

##### Session

The transformer acts on a session parameter whose name is specified in the `OnElement` property.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the Base64 content to be processed. The transformer will decode this input to text.
In the context of transformers used after a rule execution, `OnElement` refers to the field name from the previous step whose value you want to transform.

## Scope

* Any
