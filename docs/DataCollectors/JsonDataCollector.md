# Json Data Collector (JsonDataCollector)

[Table of Content](../Home.md)  

~12 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

JsonDataCollector captures the output of your extraction rules and writes it into a JSON file. It opens or creates the specified file, wraps records in a JSON array, and either appends each object as it’s extracted or writes the full array at the end of the run. This format simplifies integration with APIs, databases, and other JSON-based consumers.

### Key Features and Functionality

| Feature                | Description                                                                                |
|------------------------|--------------------------------------------------------------------------------------------|
| Extraction Integration | Hooks into your extraction rules so every item is automatically turned into a JSON object. |
| Write Modes            | Supports streaming (`ForEntity=true`) or bulk writes (`ForEntity=false`) at end of run.    |
| Array Management       | Automatically opens and closes the JSON array wrapper, ensuring valid JSON output.         |

### Usages in RPA

| Use Case               | Description                                                                    |
|------------------------|--------------------------------------------------------------------------------|
| Web Scraping           | Serializes scraped item lists into JSON for API ingestion or analytics.        |
| Real-Time Data Capture | Streams each transaction or record immediately for monitoring dashboards.      |
| Data Aggregation       | Collects outputs from multiple sources into one unified JSON document.         |
| System Interchange     | Produces JSON files that other services or microservices can consume directly. |

### Usages in Automation Testing

| Use Case           | Description                                                                          |
|--------------------|--------------------------------------------------------------------------------------|
| Test Result Export | Records pass/fail status as JSON objects for CI systems or custom reporting tools.   |
| Metrics Collection | Captures timing, resource usage, and custom metrics in JSON for downstream analysis. |

## Examples

### Example No.1

### Stream Hotel Locations to JSON

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and stream each as a JSON object into `DataFile.json` in real time.
It uses `extractionScope: "Elements"` with XPath `//div[@class='hotel']`, applies a nested rule to the `<p>` elements starting with `Location:`, and sets `forEntity` to `true` for streaming writes.
A regular expression `(?<=\\w+:).*` is applied to the text content to extract the substring following the label into a capture group.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "",
    OnElement = "//div[@class='hotel']",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = ".//p[starts-with(.,'Location:')]",
            RegularExpression = "(?<=\\w+:).*"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("")
    .setOnElement("//div[@class='hotel']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement(".//p[starts-with(.,'Location:')]")
            .setRegularExpression("(?<=\\w+:).*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "",
    onElement: "//div[@class='hotel']",
    rules: [
        {
            pluginName: "",
            onElement: ".//p[starts-with(.,'Location:')]",
            regularExpression: "(?<=\\w+:).*"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "",
    "onElement": "//div[@class='hotel']",
    "rules": [
        {
            "pluginName": "",
            "onElement": ".//p[starts-with(.,'Location:')]",
            "regularExpression": "(?<=\\w+:).*"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "",
    "onElement": "//div[@class='hotel']",
    "rules": [
        {
            "pluginName": "",
            "onElement": ".//p[starts-with(.,'Location:')]",
            "regularExpression": "(?<=\\w+:).*"
        }
    ]
}
```
### Example No.2

### Bulk Hotel Locations to JSON

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and write them all in one JSON array to `DataFile.json` upon completion.
It uses `extractionScope: "Elements"` with XPath `//div[@class='hotel']`, applies a nested rule to the `<p>` elements starting with `Location:`, and sets `forEntity` to `false` for bulk buffering.
A regular expression `(?<=\\w+:).*` is applied to the text content to extract the substring following the label into a capture group.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "",
    OnElement = "//div[@class='hotel']",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = ".//p[starts-with(.,'Location:')]",
            RegularExpression = "(?<=\\w+:).*"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("")
    .setOnElement("//div[@class='hotel']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement(".//p[starts-with(.,'Location:')]")
            .setRegularExpression("(?<=\\w+:).*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "",
    onElement: "//div[@class='hotel']",
    rules: [
        {
            pluginName: "",
            onElement: ".//p[starts-with(.,'Location:')]",
            regularExpression: "(?<=\\w+:).*"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "",
    "onElement": "//div[@class='hotel']",
    "rules": [
        {
            "pluginName": "",
            "onElement": ".//p[starts-with(.,'Location:')]",
            "regularExpression": "(?<=\\w+:).*"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "",
    "onElement": "//div[@class='hotel']",
    "rules": [
        {
            "pluginName": "",
            "onElement": ".//p[starts-with(.,'Location:')]",
            "regularExpression": "(?<=\\w+:).*"
        }
    ]
}
```

## Properties

### For Entity (ForEntity)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Turning this on sends each item as it happens so you see results sooner and can start working right away.
Keeping it off waits until everything is ready so you review all items at once and avoid partial updates.

### Source (Source)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Setting this path tells the system where to save your file so you can find it easily later.
Using a new location creates the file automatically and prevents errors from missing files.

### Type (Type)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Use the value “JsonDataCollector” to write your file in JSON format so it matches what this system expects and prevents errors.
Picking a different option starts a different process and may give you results you cannot use.
The list of options updates on its own when you add new ones so you always have the latest choices.

## Scope

* Any