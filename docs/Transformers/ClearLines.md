# Clear Lines (ClearLines)

[Table of Content](../Home.md)  

~12 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `ClearLines` transformer plugin is to remove all line breaks from a given text input.
This is particularly useful in scenarios where text data needs to be cleaned or normalized by eliminating unnecessary carriage return and newline characters.

### Key Features and Functionality

| Feature                   | Description                                                                                |
|---------------------------|--------------------------------------------------------------------------------------------|
| Line Break Removal        | Removes all carriage return (`\r`) and newline (`\n`) characters from the input text.    |
| Regular Expression Usage  | Utilizes regular expressions for efficient pattern matching and text replacement.          |
| Easy Integration          | Simple to incorporate into automation workflows for text data cleaning and transformation. |

### Usages in RPA

| Usage                    | Description                                                                                 |
|--------------------------|---------------------------------------------------------------------------------------------|
| Data Cleaning            | Preprocess text data by removing line breaks before inputting into systems or databases.    |
| Formatting Automation    | Normalize text formats when copying or transferring data between applications.              |
| Logging and Reporting    | Prepare text data for logging or reporting where line breaks might cause formatting issues. |

### Usages in Automation Testing

| Usage                     | Description                                                                  |
|---------------------------|------------------------------------------------------------------------------|
| Test Data Preparation     | Clean test input data to ensure consistency across different test cases.     |
| Validation Testing        | Verify that applications handle text inputs without line breaks as expected. |
| Output Normalization      | Normalize outputs before comparing them to expected results in assertions.   |

## Examples

### Example No.1

Remove all line breaks from a multiline text input.

The `ClearLines` transformer is utilized to remove all carriage return and newline characters from the provided text.
If line breaks are present, they are removed; otherwise, the text remains unchanged.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearLines",
    OnElement = "This is a sample text.
It contains multiple lines.
Some lines end with different line breaks."
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearLines")
    .setOnElement("This is a sample text.
It contains multiple lines.
Some lines end with different line breaks.");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearLines",
    onElement: "This is a sample text.
It contains multiple lines.
Some lines end with different line breaks."
};
```

_**JSON**_

```js
{
    "pluginName": "ClearLines",
    "onElement": "This is a sample text.
It contains multiple lines.
Some lines end with different line breaks."
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearLines",
    "onElement": "This is a sample text.
It contains multiple lines.
Some lines end with different line breaks."
}
```
### Example No.2

Clean the `Location` field extracted from content by removing line breaks and trimming whitespace.

The `ClearLines` transformer is applied to the `Location` field to remove any line breaks.
Subsequently, the `Trim` transformer removes leading and trailing whitespace.
This ensures the `Location` field is clean and ready for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//p[starts-with(.,'Location:')]",
    RegularExpression = "(?<=\w+:).*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//p[starts-with(.,'Location:')]")
    .setRegularExpression("(?<=\w+:).*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//p[starts-with(.,'Location:')]",
    regularExpression: "(?<=\w+:).*"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//p[starts-with(.,'Location:')]",
    "regularExpression": "(?<=\w+:).*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//p[starts-with(.,'Location:')]",
    "regularExpression": "(?<=\w+:).*"
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

The result of the transformation after trimming leading and trailing whitespace or specified characters from the input text.
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

Specifies the text content to be processed. The transformer will remove all line breaks from this input.
In the context of transformers used after a rule execution, `OnElement` refers to the field name from the previous step whose value you want to transform.
