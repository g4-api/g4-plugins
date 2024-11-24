# Trim (Trim)

[Table of Content](../Home.md)  

~15 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `Trim` transformer plugin is to remove leading and trailing whitespace or specified characters from a given text input.
This is particularly useful in scenarios where text data needs to be cleaned or normalized by eliminating unnecessary spaces or specific unwanted characters at the beginning or end of the text.

### Key Features and Functionality

| Feature               | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Whitespace Removal    | Removes all leading and trailing whitespace characters from the input text.                |
| Custom Character Trim | Removes specified characters from the beginning and end of the input text.                 |
| Easy Integration      | Simple to incorporate into automation workflows for text data cleaning and transformation. |

### Usages in RPA

| Usage                 | Description                                                                                                         |
|-----------------------|---------------------------------------------------------------------------------------------------------------------|
| Data Cleaning         | Preprocess text data by trimming whitespace or specific characters before inputting into systems or databases.      |
| Formatting Automation | Normalize text formats when copying or transferring data between applications.                                      |
| Logging and Reporting | Prepare text data for logging or reporting where extra spaces or specific characters might cause formatting issues. |

### Usages in Automation Testing

| Usage                  | Description                                                                                                     |
|------------------------|-----------------------------------------------------------------------------------------------------------------|
| Test Data Preparation  | Clean test input data to ensure consistency across different test cases.                                        |
| Validation Testing     | Verify that applications handle text inputs without leading/trailing spaces or specific characters as expected. |
| Output Normalization   | Normalize outputs before comparing them to expected results in assertions.                                      |

## Examples

### Example No.1

Remove all leading and trailing whitespace from a text input.

The `Trim` transformer is utilized to remove all leading and trailing whitespace characters from the provided text.
If whitespace is present at the beginning or end, it is removed; otherwise, the text remains unchanged.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Trim",
    OnElement = "   This is a sample text with spaces.   "
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Trim")
    .setOnElement("   This is a sample text with spaces.   ");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Trim",
    onElement: "   This is a sample text with spaces.   "
};
```

_**JSON**_

```js
{
    "pluginName": "Trim",
    "onElement": "   This is a sample text with spaces.   "
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Trim",
    "onElement": "   This is a sample text with spaces.   "
}
```
### Example No.2

Clean the `Location` field extracted from content by removing line breaks and trimming whitespace.

The `Trim` transformer is applied to the `Location` field to remove any leading and trailing whitespace.
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
### Example No.3

Trim specific characters from the `Username` field extracted from content.

The `Trim` transformer is applied to the `Username` field to remove specified characters from both ends of the text.
This ensures the `Username` field is clean and free from unwanted characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//span[@id='Username']",
    RegularExpression = "(?<=\w+:).*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//span[@id='Username']")
    .setRegularExpression("(?<=\w+:).*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//span[@id='Username']",
    regularExpression: "(?<=\w+:).*"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//span[@id='Username']",
    "regularExpression": "(?<=\w+:).*"
}
```

_**Python**_

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

Specifies the text content to be processed. The transformer will trim leading and trailing whitespace or specified characters from this input.
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

Specifies the characters to be trimmed from the beginning and end of the input text.
If not provided, the transformer will trim whitespace characters by default.
