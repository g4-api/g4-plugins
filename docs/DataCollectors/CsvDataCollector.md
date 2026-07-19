# Csv Data Collector (CsvDataCollector)

[Table of Content](../Home.md)  

~12 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The CsvDataCollector plugin takes data from your extraction rules and saves it into a CSV file. It opens or creates the file you name, adds a header row based on your data fields, and then writes each record either as it’s found or all at once at the end of the run. This makes it easy to keep your data organized in a simple format that anyone can read or use for further steps.

### Key Features and Functionality

| Feature                | Description                                                                                    |
|------------------------|------------------------------------------------------------------------------------------------|
| Extraction Integration | Works with your extraction rules so every item you collect goes straight to the CSV file.      |
| Write Modes            | Lets you write each record in real time or save all of them at once at the end of the run.     |
| Unified Data Storage   | Merges information from web pages, APIs, databases, or files into a single CSV table.          |
| Custom Columns         | Infers column headers from your data or lets you pick which fields to include and their order. |

### Usages in RPA

| Use Case                | Description                                                                                   |
|-------------------------|-----------------------------------------------------------------------------------------------|
| Web Scraping            | Sends lists of products, articles, or other page data directly into a CSV for later review.   |
| In-Process Data Capture | Records items like invoices or customer records during a workflow and saves them immediately. |
| Data Aggregation        | Gathers data from multiple targets into a single CSV for unified output.                      |
| System Interchange      | Creates a common CSV file that other automation steps or external systems can read.           |

### Usages in Automation Testing

| Use Case            | Description                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------|
| Test Result Logging | Records pass/fail status and error details in a CSV for easy review and audit.                 |
| Performance Metrics | Captures timing and resource usage during tests and exports the results to a CSV for analysis. |

## Examples

### Example No.1

### Extract Hotel Location with Immediate Write

This example demonstrates how to extract the hotel location value from each matching element and immediately save it to a CSV file.
It locates each `<div class='hotel'>` using the XPath `//div[@class='hotel']`, processes each element node (extractionScope `Elements`), and applies a nested Content rule to the `<p>` element starting with `Location:`.
A regular expression `(?<=\w+:).*` is applied to the visible text to capture the content after the colon and strip the `Location:` prefix.
By default, line breaks and leading/trailing whitespace are preserved.
Records are written individually to `DataFile.csv` as each location is extracted.
Immediate writes avoid high memory usage when scraping large pages.

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
            RegularExpression = "(?<=\w+:).*"
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
            .setRegularExpression("(?<=\w+:).*");
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
            regularExpression: "(?<=\w+:).*"
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
            "regularExpression": "(?<=\w+:).*"
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
            "regularExpression": "(?<=\w+:).*"
        }
    ]
}
```
### Example No.2

### Extract Hotel Location with Bulk Write

This example demonstrates how to extract the hotel location value from all matching elements and save them in bulk after extraction.
It selects every `<div class='hotel'>` using the XPath `//div[@class='hotel']`, processes each element node (extractionScope `Elements`), and applies a nested Content rule to the `<p>` element starting with `Location:`.
A regular expression `(?<=\w+:).*` is applied to the visible text to capture the content after the colon and strip the `Location:` prefix.
By default, line breaks and leading/trailing whitespace are preserved.
All records are written together to `DataFile.csv` once extraction completes.
Bulk writes minimize I/O calls for small datasets.

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
            RegularExpression = "(?<=\w+:).*"
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
            .setRegularExpression("(?<=\w+:).*");
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
            regularExpression: "(?<=\w+:).*"
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
            "regularExpression": "(?<=\w+:).*"
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
            "regularExpression": "(?<=\w+:).*"
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

ForEntity determines whether each item is saved immediately or stored until the end of the run.
It lets you see data in the file as it arrives instead of waiting until everything is collected.

### Source (Source)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

A path that tells where to save the data file.
It creates the file automatically if it does not exist.

### Type (Type)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Type sets the kind of collector to use for saving data.
Only CsvDataCollector is valid for this plugin.
New collector options appear automatically when they are added.

## Scope

* Any