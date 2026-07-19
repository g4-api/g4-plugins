# Read Json (ReadJson)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Extracts specific values from JSON data in a simple and reliable way.
It can read JSON either from a file path or directly from inline content.
Helps automation workflows reuse structured data without custom code.
It is useful when JSON responses need to be filtered, transformed, or passed to later steps.

### Key Features and Functionality

| Feature                        | Description                                                                      |
|--------------------------------|----------------------------------------------------------------------------------|
| File or Inline JSON Input      | Reads JSON from a file if the path exists, or treats the input as raw JSON text. |
| JSONPath Selection             | Extracts one or more values using a JSONPath expression.                         |
| Automatic Result Normalization | Returns a single object or an array, depending on how many values are matched.   |
| Regular Expression Filtering   | Applies an optional regular expression to the extracted JSON content.            |
| Base64 Encoding                | Encodes the final extracted value to Base64 for safe transport and storage.      |
| Session Storage                | Saves the result in session parameters for use by downstream plugins.            |

### Usages in RPA

| Use Case                   | Description                                                             |
|----------------------------|-------------------------------------------------------------------------|
| API Response Parsing       | Extract specific fields from API JSON responses during automation runs. |
| Configuration Reading      | Read values from JSON configuration files used by bots.                 |
| Dynamic Decision Making    | Use extracted JSON values to drive conditional workflow logic.          |
| Data Passing Between Steps | Store JSON-derived values in session parameters for later actions.      |

### Usages in Automation Testing

| Use Case              | Description                                                   |
|-----------------------|---------------------------------------------------------------|
| Test Data Extraction  | Read expected values from JSON test data files.               |
| API Validation        | Extract and validate fields from JSON API responses in tests. |
| Assertion Preparation | Prepare filtered JSON values for comparison and assertions.   |
| Test Context Sharing  | Share parsed JSON values across multiple test steps.          |

## Examples

### Example No.1

### Extract a Single JSON Property

Provide inline JSON content through the `argument` property.
Select a single value using a JSONPath expression defined in `OnElement`.
The selected value is serialized as JSON before further processing.
A regular expression `"[^"]+"` is applied to the value attribute to extract the inner string.
The extracted value is converted to Base64 and stored in the session parameter `ReadJson:ReadJsonResult`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadJson",
    Argument = "{"name":"alpha","count":3}",
    OnElement = "$.name",
    RegularExpression = ""[^"]+""
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadJson")
    .setArgument("{"name":"alpha","count":3}")
    .setOnElement("$.name")
    .setRegularExpression(""[^"]+"");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ReadJson",
    argument: "{"name":"alpha","count":3}",
    onElement: "$.name",
    regularExpression: ""[^"]+""
};
```

_**JSON**_

```js
{
    "pluginName": "ReadJson",
    "argument": "{"name":"alpha","count":3}",
    "onElement": "$.name",
    "regularExpression": ""[^"]+""
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ReadJson",
    "argument": "{"name":"alpha","count":3}",
    "onElement": "$.name",
    "regularExpression": ""[^"]+""
}
```
### Example No.2

### Extract Multiple Values from a JSON Array

Load JSON content from a file path provided in the `argument` property.
Use a JSONPath expression in `OnElement` to select multiple values.
The selected tokens are serialized into a JSON array.
A regular expression `\d+` is applied to the value attribute to extract numeric content.
The matched value is converted to Base64 and written to the session parameter `ReadJson:ReadJsonResult`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadJson",
    Argument = "data.json",
    OnElement = "$.items[*].id",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadJson")
    .setArgument("data.json")
    .setOnElement("$.items[*].id")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ReadJson",
    argument: "data.json",
    onElement: "$.items[*].id",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "ReadJson",
    "argument": "data.json",
    "onElement": "$.items[*].id",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ReadJson",
    "argument": "data.json",
    "onElement": "$.items[*].id",
    "regularExpression": "\d+"
}
```
### Example No.3

### Extract JSON Data without a Regular Expression

Supply inline JSON using the `argument` property.
Select a nested object using the JSONPath expression defined in `OnElement`.
The selected result is serialized as JSON.
No filtering is applied because no regular expression is provided.
The serialized JSON is converted to Base64 and saved in the session parameter `ReadJson:ReadJsonResult`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadJson",
    Argument = "{"config":{"enabled":true,"level":"high"}}",
    OnElement = "$.config"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadJson")
    .setArgument("{"config":{"enabled":true,"level":"high"}}")
    .setOnElement("$.config");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ReadJson",
    argument: "{"config":{"enabled":true,"level":"high"}}",
    onElement: "$.config"
};
```

_**JSON**_

```js
{
    "pluginName": "ReadJson",
    "argument": "{"config":{"enabled":true,"level":"high"}}",
    "onElement": "$.config"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ReadJson",
    "argument": "{"config":{"enabled":true,"level":"high"}}",
    "onElement": "$.config"
}
```

## Output Parameter

### Read Json Read Json Result (ReadJson:ReadJsonResult)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

The session parameter that holds the extracted JSON value.
The parameter contains the final result produced from the selected JSON content.
Its value can be referenced by other parameters or expressions in the workflow.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the JSON input to be read and processed by the plugin.
The value can be either a file path pointing to a JSON file or raw JSON content provided inline.
This flexibility allows workflows to read JSON from disk or from dynamically generated data.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the JSONPath expression used to select specific elements from the input JSON.
The expression controls which parts of the JSON structure are extracted for further processing.
Using a precise path ensures only the relevant data is read and passed to later steps.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies an optional regular expression applied to the extracted JSON content.
The expression is used to match and isolate a specific portion of the selected JSON.
This allows fine-grained filtering before the result is converted and stored.

## Scope

* Any