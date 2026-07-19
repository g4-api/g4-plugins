# Xml Data Collector (XmlDataCollector)

[Table of Content](../Home.md)  

~12 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

XmlDataCollector takes your extraction-rule outputs and saves them into an XML file. It opens or creates the specified file, wraps records in a default root element, and either appends each record element as it’s extracted or writes the full document at the end of the run. This format simplifies integration with XML-based services and tools.

### Key Features and Functionality

| Feature                | Description                                                                             |
|------------------------|-----------------------------------------------------------------------------------------|
| Extraction Integration | Hooks into your extraction rules so every item becomes an XML element.                  |
| Write Modes            | Supports streaming (`ForEntity=true`) or bulk writes (`ForEntity=false`) at end of run. |

### Usages in RPA

| Use Case           | Description                                                                |
|--------------------|----------------------------------------------------------------------------|
| Web Scraping       | Serializes scraped items into XML for legacy system ingestion or analysis. |
| Real-Time Capture  | Streams each record as an XML element for live dashboards.                 |
| Data Aggregation   | Collects outputs from multiple sources into a single XML document.         |
| System Interchange | Produces XML files consumable by other services or microservices.          |

### Usages in Automation Testing

| Use Case           | Description                                                           |
|--------------------|-----------------------------------------------------------------------|
| Test Result Export | Records pass/fail status as XML elements for CI systems or reporting. |
| Metrics Collection | Captures timing and resource usage in XML for downstream analysis.    |

## Examples

### Example No.1

### Stream Hotel Locations to XML

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and stream each as an XML element into `DataFile.xml` in real time.
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

### Bulk Hotel Locations to XML

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and write them all as XML elements under a `<Records>` root in `DataFile.xml` upon completion.
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

Set to “true” to write each record as soon as it is ready so you can see results right away and start using them without waiting.
Set to “false” to wait until all records are ready before writing so you can view everything at once and keep your file complete.

### Source (Source)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Enter the path where your XML file will be saved so you know where to find it later and keep your files organized.
If the file does not exist, a new one is created at that location so you do not have to set it up yourself.

### Type (Type)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Use the value “XmlDataCollector” so the system writes your file in the correct format and avoids errors.
Choosing a different value will use another process and may store your data in the wrong place.
The list of values updates on its own when new options are added so you always have the latest choices.

## Scope

* Any