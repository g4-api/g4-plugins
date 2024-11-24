# Trim End (TrimEnd)

[Table of Content](../Home.md)  

~15 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `TrimEnd` transformer plugin is to remove trailing whitespace or specified characters from the end of a given text input.
This is particularly useful in scenarios where text data needs to be cleaned or normalized by eliminating unnecessary spaces or specific unwanted characters at the end of the text.

### Key Features and Functionality

| Feature               | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Trailing Whitespace Removal | Removes all trailing whitespace characters from the input text.                      |
| Custom Character Trim | Removes specified characters from the end of the input text.                               |
| Easy Integration      | Simple to incorporate into automation workflows for text data cleaning and transformation. |

### Usages in RPA

| Usage                 | Description                                                                                                                    |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Data Cleaning         | Preprocess text data by trimming trailing whitespace or specific characters before inputting into systems or databases.        |
| Formatting Automation | Normalize text formats when copying or transferring data between applications.                                                 |
| Logging and Reporting | Prepare text data for logging or reporting where extra spaces or specific characters at the end might cause formatting issues. |

### Usages in Automation Testing

| Usage                  | Description                                                                                             |
|------------------------|---------------------------------------------------------------------------------------------------------|
| Test Data Preparation  | Clean test input data to ensure consistency across different test cases.                                |
| Validation Testing     | Verify that applications handle text inputs without trailing spaces or specific characters as expected. |
| Output Normalization   | Normalize outputs before comparing them to expected results in assertions.                              |

## Examples

### Example No.1

Remove all trailing whitespace from a text input.

The `TrimEnd` transformer is utilized to remove all trailing whitespace characters from the provided text.
If whitespace is present at the end, it is removed; otherwise, the text remains unchanged.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TrimEnd",
    OnElement = "This is a sample text with spaces at the end.   "
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TrimEnd")
    .setOnElement("This is a sample text with spaces at the end.   ");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "TrimEnd",
    onElement: "This is a sample text with spaces at the end.   "
};
```

_**JSON**_

```js
{
    "pluginName": "TrimEnd",
    "onElement": "This is a sample text with spaces at the end.   "
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "TrimEnd",
    "onElement": "This is a sample text with spaces at the end.   "
}
```
### Example No.2

Trim specific characters from the end of the `FileName` field extracted from content.

The `TrimEnd` transformer is applied to the `FileName` field to remove specified characters from the end of the text.
This ensures the `FileName` field is clean and free from unwanted trailing characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//span[@id='FileName']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//span[@id='FileName']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//span[@id='FileName']"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//span[@id='FileName']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//span[@id='FileName']"
}
```
### Example No.3

Remove trailing line breaks and whitespace from the `Description` field.

The `TrimEnd` transformer is used to remove any trailing whitespace and line breaks from the `Description` field.
This ensures the `Description` field does not have unnecessary blank lines or spaces at the end.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//div[@id='Description']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//div[@id='Description']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//div[@id='Description']"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//div[@id='Description']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//div[@id='Description']"
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

The result of the transformation after trimming trailing whitespace or specified characters from the input text.
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

Specifies the text content to be processed. The transformer will trim trailing whitespace or specified characters from this input.
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

Specifies the characters to be trimmed from the end of the input text.
If not provided, the transformer will trim whitespace characters by default.
