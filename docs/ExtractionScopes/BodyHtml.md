# Body Html (BodyHtml)

[Table of Content](../Home.md)  

~15 min · ExtractionScope Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]  
> This scope creates an internal DOM object and only supports XPath expressions.

### Purpose

The `BodyHtml` extraction scope is designed for web scraping tasks focused on collecting data from the fully rendered, static content within the body of an HTML document. 
It ensures that the extracted data includes all initial dynamic content and represents the web page's state as it appears to the user after all initial client-side processing has completed. 
This scope is particularly valuable for gathering information from standard web pages, offering performance benefits through element caching and being especially useful when dealing with content-heavy websites.

### Key Features and Functionality

| Feature                             | Description                                                                                                                    |
|-------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Capture Fully Rendered Content      | Extracts data from the web page's main content, including all elements fully rendered after the page has loaded.               |
| Extraction After Dynamic Processing | Captures data generated or modified by client-side technologies like JavaScript and AJAX during page load.                     |
| Standard Web Pages                  | Suitable for scraping data from standard web pages with conventional HTML structures within the body.                          |
| XPath-Based Data Collection         | Uses XPath expressions to pinpoint specific elements within the body of the HTML document for data extraction.                 |
| Content Parsing and Analysis        | Ideal for parsing and analyzing textual and structural data within the main content, such as articles or product descriptions. |
| Web Page Snapshot                   | Captures a snapshot of the web page's fully rendered state, allowing work with static data without real-time updates.          |

### Usages in RPA

| Usage                   | Description                                                                                                               |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------|
| Data Collection         | Used to collect and extract data from fully rendered web pages, ensuring that all dynamic content is included.            |
| Automated Reporting     | Ideal for scenarios where data from various web pages needs to be aggregated and analyzed for automated reporting tasks.  |
| Monitoring and Analysis | Suitable for monitoring changes in web content over time, such as tracking updates to a product catalog or news articles. |

### Usages in Automation Testing

| Usage                 | Description                                                                                                                  |
|-----------------------|------------------------------------------------------------------------------------------------------------------------------|
| Page State Validation | Used to validate the final rendered state of a web page in end-to-end tests, ensuring that all content loads as expected.    |
| Regression Testing    | Helps in regression testing by capturing the HTML body content before and after changes to ensure no unintended alterations. |
| Load Testing          | Useful in load testing to ensure that the body content remains consistent and performs well under different loads.           |

### Performance Considerations

An advantage of the `BodyHtml` scope is that it often caches fully rendered elements, which can lead to better performance compared to the `Elements` scope. 
Caching reduces the need to re-fetch or re-render elements, improving data extraction efficiency.

### See Also

- [HTML Agility Pack Documentation](https://html-agility-pack.net/)
- [HTML Agility Pack GitHub Repository](https://github.com/zzzprojects/html-agility-pack)

## Examples

### Example No.1

Extract the text associated with the `Location` label from the `ExportData.html` web page. 
This example demonstrates how to call the `BodyHtml` plugin directly, specifying the `onElement`, `contentRules`, and `dataCollector` properties. 
The `Location` text within a `div` element with the class `hotel` is located, a regular expression is applied to capture the text following the label, and the extracted data is stored in JSON format in the `DataFile.json` file.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "BodyHtml",
    OnElement = "//div[@class='hotel']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("BodyHtml")
    .setOnElement("//div[@class='hotel']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "BodyHtml",
    onElement: "//div[@class='hotel']"
};
```

_**JSON**_

```js
{
    "pluginName": "BodyHtml",
    "onElement": "//div[@class='hotel']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "BodyHtml",
    "onElement": "//div[@class='hotel']"
}
```
### Example No.2

Extract the text associated with the `Location` label from the `ExportData.html` web page as part of an extraction rule within an automation request. 
This example shows how to use the `BodyHtml` plugin within an extraction rule setup. 
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

Specifies the target element within the body of the HTML document from which data is to be extracted. This can be defined using an XPath or other locator strategies.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target elements within the body of the HTML document. The default value is 'Xpath'.

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

apiDocumentation: [https://html-agility-pack.net/documentation](https://html-agility-pack.net/documentation)
