# Xml Data Collector (XmlDataCollector)

[Table of Content](../Home.md)  

~9 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `XmlDataCollector` is to collect data and organize it in a structured format, typically as XML (Extensible Markup Language). 
XML is a flexible and widely-used data interchange format, making it suitable for various applications, including automation and data integration.

### Key Features and Functionality

| Feature               | Description                                                                                                            |
|-----------------------|------------------------------------------------------------------------------------------------------------------------|
| Data Storage          | Storing data collected from various sources in a structured format, making it easier to manage, retrieve, and analyze. |
| Data Integration      | Facilitating the integration of data from multiple systems or sources into a single, consistent format.                |
| Automation            | Supporting automation and RPA processes by collecting and formatting data for further use in automated workflows.      |

### Usages in RPA

| Usage                            | Description                                                                                                                                                             |
|----------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Web Scraping and Data Extraction | Collect data from websites and save it in XML format. Data collected can include product information, news articles, weather data, etc.                                 |
| RPA Data Management              | Gather data during automated tasks and workflows, storing it as XML for further processing or reporting.                                                                |
| Data Aggregation                 | Aggregate data from multiple sources into a single XML format.                                                                                                          |
| Data Export and Reporting        | Export data collected from various sources to XML format for reporting and analysis. XML is commonly used for transmitting data between systems and generating reports. |

### Usages in Automation Testing

| Usage                  | Description                                                                                                                                    |
|------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Data-Driven Testing    | Use the `XmlDataCollector` plugin to collect test data during test execution and save it in XML format for further analysis.                   |
| Test Data Management   | Manage and store test data in a structured XML format, facilitating easy retrieval and use in various test scenarios.                          |
| Dynamic Test Execution | Enable dynamic test execution by collecting and storing runtime data in XML format, allowing for flexible test configurations and validations. |

## Examples

### Example No.1

Defines an extraction rule that extracts location information from a web page. 
The extracted data is labeled as `Location`, and it is collected using an `XmlDataCollector` into an XML file named `DataFile.xml`. 
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

Specifies the output destination where the collected data will be saved (e.g., `/Path/To/My/File/DataFile.xml`).

## Scope

* Any