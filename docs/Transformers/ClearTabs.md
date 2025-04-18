# Clear Tabs (ClearTabs)

[Table of Content](../Home.md)  

~15 min · Transformer Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `ClearTabs` transformer plugin is to remove all tab characters (`\t`) from a given text input.
This is particularly useful in scenarios where text data needs to be cleaned or normalized by eliminating unnecessary tab spaces that might affect formatting or data processing.

### Key Features and Functionality

| Feature                  | Description                                                                                |
|--------------------------|--------------------------------------------------------------------------------------------|
| Tab Character Removal    | Removes all tab characters (`\t`) from the input text.                                    |
| Regular Expression Usage | Utilizes regular expressions for efficient pattern matching and text replacement.          |
| Scope Selection          | Allows specifying whether to act on 'Entity' fields or 'Session' parameters.               |
| Easy Integration         | Simple to incorporate into automation workflows for text data cleaning and transformation. |

### Usages in RPA

| Usage                 | Description                                                                                    |
|-----------------------|------------------------------------------------------------------------------------------------|
| Data Cleaning         | Preprocess text data by removing tab characters before inputting into systems or databases.    |
| Formatting Automation | Normalize text formats when copying or transferring data between applications.                 |
| Logging and Reporting | Prepare text data for logging or reporting where tab characters might cause formatting issues. |

### Usages in Automation Testing

| Usage                 | Description                                                                     |
|-----------------------|---------------------------------------------------------------------------------|
| Test Data Preparation | Clean test input data to ensure consistency across different test cases.        |
| Validation Testing    | Verify that applications handle text inputs without tab characters as expected. |
| Output Normalization  | Normalize outputs before comparing them to expected results in assertions.      |

## Examples

### Example No.1

Remove all tab characters from a text input.

The `ClearTabs` transformer is utilized to remove all tab characters from the provided text.
If tab characters are present, they are removed; otherwise, the text remains unchanged.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearTabs",
    OnElement = "This is a	sample text	with tabs."
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearTabs")
    .setOnElement("This is a	sample text	with tabs.");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearTabs",
    onElement: "This is a	sample text	with tabs."
};
```

_**JSON**_

```js
{
    "pluginName": "ClearTabs",
    "onElement": "This is a	sample text	with tabs."
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearTabs",
    "onElement": "This is a	sample text	with tabs."
}
```
### Example No.2

Clean the `Address` field extracted from content by removing tab characters.

The `ClearTabs` transformer is applied to the `Address` field to remove any tab characters.
This ensures the `Address` field is clean and ready for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "contentType",
    OnElement = ".//p[@id='Address']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("contentType")
    .setOnElement(".//p[@id='Address']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "contentType",
    onElement: ".//p[@id='Address']"
};
```

_**JSON**_

```js
{
    "pluginName": "contentType",
    "onElement": ".//p[@id='Address']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "contentType",
    "onElement": ".//p[@id='Address']"
}
```
### Example No.3

Remove tab characters from the `Note` session parameter.

The `ClearTabs` transformer is used to remove any tab characters from the `Note` session parameter.
This ensures the `Note` parameter does not contain unwanted tab spaces.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearTabs",
    OnAttribute = "Session",
    OnElement = "Note"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearTabs")
    .setOnAttribute("Session")
    .setOnElement("Note");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearTabs",
    onAttribute: "Session",
    onElement: "Note"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearTabs",
    "onAttribute": "Session",
    "onElement": "Note"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearTabs",
    "onAttribute": "Session",
    "onElement": "Note"
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

The result of the transformation after removing all tab characters from the input text.
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

Specifies the text content to be processed. The transformer will remove all tab characters from this input.
In the context of transformers, `OnElement` refers to the field name from the previous step whose value you want to transform, or a session parameter if `OnAttribute` is set to 'Session'.

## Scope

* Any