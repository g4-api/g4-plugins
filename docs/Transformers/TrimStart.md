# Trim Start (TrimStart)

[Table of Content](../Home.md)  

~15 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `TrimStart` transformer plugin is to remove leading whitespace or specified characters from the beginning of a given text input.
This is particularly useful in scenarios where text data needs to be cleaned or normalized by eliminating unnecessary spaces or specific unwanted characters at the start of the text.

### Key Features and Functionality

| Feature               | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Leading Whitespace Removal | Removes all leading whitespace characters from the input text.                        |
| Custom Character Trim | Removes specified characters from the beginning of the input text.                         |
| Easy Integration      | Simple to incorporate into automation workflows for text data cleaning and transformation. |

### Usages in RPA

| Usage                 | Description                                                                                                                      |
|-----------------------|----------------------------------------------------------------------------------------------------------------------------------|
| Data Cleaning         | Preprocess text data by trimming leading whitespace or specific characters before inputting into systems or databases.           |
| Formatting Automation | Normalize text formats when copying or transferring data between applications.                                                   |
| Logging and Reporting | Prepare text data for logging or reporting where extra spaces or specific characters at the start might cause formatting issues. |

### Usages in Automation Testing

| Usage                  | Description                                                                                            |
|------------------------|--------------------------------------------------------------------------------------------------------|
| Test Data Preparation  | Clean test input data to ensure consistency across different test cases.                               |
| Validation Testing     | Verify that applications handle text inputs without leading spaces or specific characters as expected. |
| Output Normalization   | Normalize outputs before comparing them to expected results in assertions.                             |

## Examples

### Example No.1

Remove all leading whitespace from a text input.

The `TrimStart` transformer is utilized to remove all leading whitespace characters from the provided text.
If whitespace is present at the beginning, it is removed; otherwise, the text remains unchanged.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TrimStart",
    OnElement = "   This is a sample text with spaces at the start."
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TrimStart")
    .setOnElement("   This is a sample text with spaces at the start.");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "TrimStart",
    onElement: "   This is a sample text with spaces at the start."
};
```

_**JSON**_

```js
{
    "pluginName": "TrimStart",
    "onElement": "   This is a sample text with spaces at the start."
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "TrimStart",
    "onElement": "   This is a sample text with spaces at the start."
}
```
### Example No.2

Trim specific characters from the beginning of the `UserInput` field extracted from content.

The `TrimStart` transformer is applied to the `UserInput` field to remove specified characters from the start of the text.
This ensures the `UserInput` field is clean and free from unwanted leading characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//input[@id='UserInput']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//input[@id='UserInput']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//input[@id='UserInput']"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//input[@id='UserInput']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//input[@id='UserInput']"
}
```
### Example No.3

Remove leading line breaks and whitespace from the `Comment` field.

The `TrimStart` transformer is used to remove any leading whitespace and line breaks from the `Comment` field.
This ensures the `Comment` field does not have unnecessary blank lines or spaces at the start.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//textarea[@id='Comment']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//textarea[@id='Comment']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//textarea[@id='Comment']"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//textarea[@id='Comment']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//textarea[@id='Comment']"
}
```

## Output Parameter

### Transformer Result (TransformerResult)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

The result of the transformation after trimming leading whitespace or specified characters from the input text.
This value can be of any type, depending on the context in which the transformer is used.

## Properties

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
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
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the text content to be processed. The transformer will trim leading whitespace or specified characters from this input.
In the context of transformers used after a rule execution, `OnElement` refers to the field name from the previous step whose value you want to transform.

## Parameters

### Trim Chars (TrimChars)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the characters to be trimmed from the beginning of the input text.
If not provided, the transformer will trim whitespace characters by default.

## Scope

* Any