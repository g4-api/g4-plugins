# Elements (Elements)

[Table of Content](../Home.md)  

~12 min · ExtractionScope Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Elements` extraction scope is designed for web scraping tasks and automation testing that require real-time interaction with the live DOM structure. 
It provides the most accurate data extraction by accessing the DOM without caching, ensuring that the data is always up-to-date and reflects the current state of the web page.

### Key Features and Functionality

| Feature                              | Description                                                                                                |
|--------------------------------------|------------------------------------------------------------------------------------------------------------|
| Real-time Data Extraction            | Interacts directly with the live DOM structure, providing up-to-date data with every extraction.           |
| No Data Caching                      | Data is not cached, ensuring that every interaction retrieves the current state of the web page.           |
| Precision in Dynamic Pages           | Ideal for dynamic web pages where content frequently changes, ensuring accurate and real-time data.        |
| Trade-off Between Accuracy and Speed | Provides the highest accuracy, though it may be slower compared to caching-based scopes like `PageSource`. |

### Usages in RPA

| Usage                      | Description                                                                                                       |
|----------------------------|-------------------------------------------------------------------------------------------------------------------|
| Dynamic Content Extraction | Used to collect data from web pages where content changes frequently, ensuring the extraction is always accurate. |
| Real-time Data Collection  | Suitable for scenarios where up-to-date data is critical, such as monitoring or real-time analytics.              |
| Precision-based Automation | Ideal for automation tasks that require precise data verification or interaction with specific web elements.      |

### Usages in Automation Testing

| Usage                       | Description                                                                                                        |
|-----------------------------|--------------------------------------------------------------------------------------------------------------------|
| DOM State Validation        | Ensures that the tests interact with the live DOM, validating the current state of elements during test execution. |
| High-Precision Assertions   | Used in scenarios where the accuracy of element states is crucial, such as validating dynamic UI components.       |
| Regression and Load Testing | Ensures that element states remain consistent under different conditions, providing accurate testing results.      |

## Examples

### Example No.1

Extract the text associated with the `Location` label from the `ExportData.html` web page. 
This example demonstrates how to call the `Elements` plugin, specifying the `onElement`, `contentRules`, and `dataCollector` properties. 
The `Location` text within a `div` element with the class `hotel` is located, a regular expression is applied to capture the text following the label, and the extracted data is stored in JSON format in the `DataFile.json` file.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Elements",
    OnElement = "//div[@class='hotel']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Elements")
    .setOnElement("//div[@class='hotel']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Elements",
    onElement: "//div[@class='hotel']"
};
```

_**JSON**_

```js
{
    "pluginName": "Elements",
    "onElement": "//div[@class='hotel']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Elements",
    "onElement": "//div[@class='hotel']"
}
```
### Example No.2

Extract the text associated with the `Location` label from the `ExportData.html` web page as part of an extraction rule within an automation request. 
This example shows how to use the `Elements` plugin within an extraction rule setup. 
It locates the `Location` text within a `div` element with the class `hotel`, applies a regular expression to capture the text following the label, and stores the extracted data in JSON format in the `DataFile.json` file.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "",
    OnElement = "//div[@class='hotel']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("")
    .setOnElement("//div[@class='hotel']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "",
    onElement: "//div[@class='hotel']"
};
```

_**JSON**_

```js
{
    "pluginName": "",
    "onElement": "//div[@class='hotel']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "",
    "onElement": "//div[@class='hotel']"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the target element within the DOM from which data is to be extracted. This can be defined using an XPath or other locator strategies.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target elements on the web page. The default value is 'Xpath'.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Object            |

Defines the rules for extracting content from the specified element, such as applying regular expressions or trimming the extracted data.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the extracted content before further processing. 
This allows for more flexible data extraction by capturing specific patterns within the content.

### Data Collector (DataCollector)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Object            |

Specifies how the extracted data will be collected and stored, such as saving it in JSON format or another supported format.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-elements](https://www.w3.org/TR/webdriver/#find-elements)
