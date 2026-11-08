# Encode Base64 (EncodeBase64)

[Table of Content](../Home.md)

~12 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `EncodeBase64` transformer plugin is to encode a given text input to Base64.
This is particularly useful when a value extracted or produced by a previous step must be passed to a system, header, or file that expects Base64 content.

### Key Features and Functionality

| Feature             | Description                                                                                  |
| --- | --- |
| Base64 Encoding     | Encodes the input text to a Base64 string using UTF-8 bytes.                                 |
| Scope Selection     | Transforms either an entity field of the previous step or a session parameter.               |
| Easy Integration    | Simple to chain with other transformers, for example after `Trim` or `ClearLines`.           |

### Usages in RPA

| Usage               | Description                                                                                  |
| --- | --- |
| Data Transport      | Encode extracted text before sending it to an API or system that requires Base64 input.      |
| Credential Encoding | Encode a captured `user:password` value for use in an HTTP Basic Auth header.                |
| Safe Storage        | Encode values that contain line breaks or special characters before storing them.            |

### Usages in Automation Testing

| Usage               | Description                                                                                  |
| --- | --- |
| Value Verification  | Encode extracted values to compare them against Base64-encoded API responses in assertions.  |
| Test Data Handoff   | Pass extracted values to downstream steps or data sources in a Base64-safe format.           |

## Examples

### Example No.1

Encode a text input to Base64.

The `EncodeBase64` transformer is utilized to encode the provided text to a Base64 string.
The text `Hello, World!` is encoded to `SGVsbG8sIFdvcmxkIQ==`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "EncodeBase64",
    OnElement = "Hello, World!"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("EncodeBase64")
    .setOnElement("Hello, World!");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "EncodeBase64",
    onElement: "Hello, World!"
};
```

**JSON:**

```js
{
    "pluginName": "EncodeBase64",
    "onElement": "Hello, World!"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "EncodeBase64",
    "onElement": "Hello, World!"
}
```

### Example No.2

Encode the `Username` field extracted from content.

The `Trim` transformer first removes leading and trailing whitespace from the `Username` field.
Subsequently, the `EncodeBase64` transformer encodes the cleaned value to Base64.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//span[@id='Username']",
    RegularExpression = "(?<=\w+:).*"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//span[@id='Username']")
    .setRegularExpression("(?<=\w+:).*");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//span[@id='Username']",
    regularExpression: "(?<=\w+:).*"
};
```

**JSON:**

```js
{
    "pluginName": "contentType",
    "onElement": ".//span[@id='Username']",
    "regularExpression": "(?<=\w+:).*"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//span[@id='Username']",
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

The result of the transformation after encoding the input text to Base64.
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

Specifies the text content to be processed. The transformer will encode this input to Base64.
In the context of transformers used after a rule execution, `OnElement` refers to the field name from the previous step whose value you want to transform.

## Scope

* Any
