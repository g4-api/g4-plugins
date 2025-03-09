# Csv Data Collector (CsvDataCollector)

[Table of Content](../Home.md)  

~9 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of a `CsvDataCollector` is to collect data and organize it in a structured format, typically as CSV. 
CSV is a human-readable data interchange format, making it suitable for various applications, including automation and data integration.  

### Key Features and Functionality

| Feature          | Description                                                                                                            |
|------------------|------------------------------------------------------------------------------------------------------------------------|
| Data Storage     | Storing data collected from various sources in a structured format, making it easier to manage, retrieve, and analyze. |
| Data Integration | Facilitating the integration of data from multiple systems or sources into a single, consistent format.                |
| Automation       | Supporting automation and RPA processes by collecting and formatting data for further use in automated workflows.      |

### Usages in RPA

| Usage                            | Description                                                                                                                                                                                                                         |
|----------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Web Scraping and Data Extraction | CsvDataCollectors are often used in web scraping to collect data from websites and save it in CSV format. Data collected from web pages can include product information, news articles, weather data, or any other structured data. |
| RPA Data Management              | In the context of Robotic Process Automation (RPA), data collectors can be used to gather data during automated tasks and workflows. The collected data can then be stored as CSV for further processing or reporting.              |
| Data Aggregation                 | CsvDataCollectors are useful for aggregating data from multiple sources. For example, an e-commerce application might use a CsvDataCollector to gather product details from various suppliers' websites into a single CSV format.   |
| Data Export and Reporting        | Data collected from various sources can be exported to CSV format for reporting and analysis. CSV is commonly used for transmitting data between systems and for generating reports.                                                |

### Usages in Automation Testing

| Usage                | Description                                                                                             |
|----------------------|---------------------------------------------------------------------------------------------------------|
| Test Data Collection | Collect test data generated during test execution and store it in a CSV file for review and analysis.   |
| Result Logging       | Log test results and other relevant information in a structured format for easy access and evaluation.  |
| Data-Driven Testing  | Utilize collected data to drive subsequent test cases, ensuring dynamic and data-driven test execution. |

## Examples

### Example No.1

Defines an extraction rule that extracts location information from a web page. 
The extracted data is labeled as `Location`, and it is collected using a `CsvDataCollector` into a CSV file named `DataFile.csv`. 
The extraction process is defined within a specific scope and starts from a `<div>` element with the class `hotel`. 
The use of regular expressions and XPath expressions allows for precise data extraction and formatting.

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

## Parameters

### Source (Source)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the output destination where the collected data will be saved (e.g., `/Path/To/My/File/DataFile.csv`).

## Scope

* Any