# Sq Light Data Collector (SqLightDataCollector)

[Table of Content](../Home.md)  

~12 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

SqLightDataCollector takes your extraction-rule outputs and writes them into a SQLite database table. It uses the provided connection string to open or create the database file, creates the target table if it doesn’t exist, and inserts each record either immediately or in bulk at the end of the run.

### Key Features and Functionality

| Feature                | Description                                                                                         |
|------------------------|-----------------------------------------------------------------------------------------------------|
| Extraction Integration | Hooks into your extraction rules so every item becomes a row in a SQLite table.                     |
| Write Modes            | Supports streaming inserts (`ForEntity=true`) or bulk inserts (`ForEntity=false`) in a transaction. |
| Automatic Creation     | Creates the SQLite database file and table automatically if they don’t already exist.               |

### Usages in RPA

| Use Case           | Description                                                                          |
|--------------------|--------------------------------------------------------------------------------------|
| Web Scraping       | Inserts scraped items directly into a SQLite table for local persistence.            |
| Real-Time Capture  | Streams each record as an INSERT for immediate storage and minimal memory footprint. |
| Data Aggregation   | Buffers records then commits them in a single transaction for efficiency.            |
| System Interchange | Produces a local database that other steps or services can query directly.           |

### Usages in Automation Testing

| Use Case            | Description                                                                         |
|---------------------|-------------------------------------------------------------------------------------|
| Test Result Logging | Records pass/fail status and error details into a test results table for reporting. |
| Metrics Collection  | Captures timing and resource usage metrics in a table for offline analysis.         |

## Examples

### Example No.1

### Stream Hotel Locations to SQLite

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and stream each as an INSERT into the `HotelLocations` table in `Data.db` in real time.
It uses `extractionScope: "Elements"` with XPath `//div[@class='hotel']`, applies a nested rule to the `<p>` elements starting with `Location:`, and sets `forEntity` to `true` for streaming inserts.
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

### Bulk Hotel Locations to SQLite

Text is trimmed to remove whitespace, converted to a string, then regex-extracted (up to 100 characters).
This example demonstrates how to extract hotel locations from each `<div class='hotel'>` element and insert them all in one transaction into the `HotelLocations` table in `Data.db` upon completion.
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

Set to “true” to save each entry as soon as it arrives so you can see results right away.
Set to “false” to save all entries at the end so you can review everything together without delays.

### Repository (Repository)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Type the name of the table where your data will be stored so you can find it later.
A new table is created automatically if it does not exist so you do not have to prepare it yourself.

### Source (Source)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Enter the details the system uses to open your data file so it can access your information.
A correct entry makes sure your information is read and written without issues.

### Type (Type)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Enter “SqLightDataCollector” so the system knows how to handle your data correctly and save it here.
Choosing a different option will make the system use something else and may keep your data from saving in this place.
The list of options updates automatically when you add new ones so you always have the latest choices.

## Scope

* Any