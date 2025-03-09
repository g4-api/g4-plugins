# Html Content (HtmlContent)

[Table of Content](../Home.md)  

~16 min · Content Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `HtmlContent` plugin extracts content from HTML documents using XPath selectors. It allows users to target specific elements or attributes within an HTML structure and extract their values, optionally applying regular expressions for precise data retrieval.

This plugin works with HTML content from various scopes, such as the page source, outer HTML of an element, or raw HTML, depending on the extraction context.

### Key Features and Functionality

| Feature              | Description                                                                               |
|----------------------|-------------------------------------------------------------------------------------------|
| XPath Selection      | Selects HTML elements using XPath selectors specified in `OnElement`.                     |
| Attribute Extraction | Extracts values from specified attributes or inner text if `OnAttribute` is not provided. |
| Regular Expression   | Applies a regular expression to the extracted value for precise data extraction.          |
| Data Type Conversion | Converts the extracted value to a specified data type using `DataType`.                   |
| Flexible Integration | Easily integrates into automation workflows for data extraction from web content.         |

### Usages in RPA

| Usage                | Description                                                                    |
|----------------------|--------------------------------------------------------------------------------|
| Web Data Extraction  | Extract specific information from web pages for processing or storage.         |
| Content Scraping     | Scrape content from websites by targeting elements and attributes using XPath. |
| Form Data Retrieval  | Extract values from form fields or other interactive elements on a web page.   |

### Usages in Automation Testing

| Usage            | Description                                                                               |
|------------------|-------------------------------------------------------------------------------------------|
| DOM Verification | Validate the presence and content of specific elements within the HTML structure.         |
| Data Validation  | Verify that web applications render content correctly by extracting and asserting values. |
| UI Testing       | Automate testing of UI components by extracting and validating their properties.          |

## Examples

### Example No.1

Extract the text content of an element using an XPath selector.

The `HtmlContent` plugin is used to select an element by its XPath and extract its inner text.
This allows you to retrieve specific information from the HTML document.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HtmlContent",
    OnElement = "//div[@class='product-name']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HtmlContent")
    .setOnElement("//div[@class='product-name']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HtmlContent",
    onElement: "//div[@class='product-name']"
};
```

_**JSON**_

```js
{
    "pluginName": "HtmlContent",
    "onElement": "//div[@class='product-name']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HtmlContent",
    "onElement": "//div[@class='product-name']"
}
```
### Example No.2

Extract the value of an attribute from an element using an XPath selector.

The `HtmlContent` plugin selects an element using an XPath selector and extracts the value of a specified attribute.
This is useful for retrieving properties like URLs from links or source paths from images.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HtmlContent",
    Argument = "{{$}}",
    OnAttribute = "href",
    OnElement = "//a[@class='download-link']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HtmlContent")
    .setArgument("{{$}}")
    .setOnAttribute("href")
    .setOnElement("//a[@class='download-link']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HtmlContent",
    argument: "{{$}}",
    onAttribute: "href",
    onElement: "//a[@class='download-link']"
};
```

_**JSON**_

```js
{
    "pluginName": "HtmlContent",
    "argument": "{{$}}",
    "onAttribute": "href",
    "onElement": "//a[@class='download-link']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HtmlContent",
    "argument": "{{$}}",
    "onAttribute": "href",
    "onElement": "//a[@class='download-link']"
}
```
### Example No.3

Extract a numeric value from an element's text using a regular expression.

The `HtmlContent` plugin extracts the inner text of an element and applies a regular expression to retrieve a numeric value.
The extracted value is then converted to the specified data type.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HtmlContent",
    Argument = "{{$}}",
    OnElement = "//span[@id='price']",
    RegularExpression = "\d+\.\d{2}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HtmlContent")
    .setArgument("{{$}}")
    .setOnElement("//span[@id='price']")
    .setRegularExpression("\d+\.\d{2}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HtmlContent",
    argument: "{{$}}",
    onElement: "//span[@id='price']",
    regularExpression: "\d+\.\d{2}"
};
```

_**JSON**_

```js
{
    "pluginName": "HtmlContent",
    "argument": "{{$}}",
    "onElement": "//span[@id='price']",
    "regularExpression": "\d+\.\d{2}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HtmlContent",
    "argument": "{{$}}",
    "onElement": "//span[@id='price']",
    "regularExpression": "\d+\.\d{2}"
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
| **Value Type**    | String            |

Specifies the XPath selector to locate the target HTML element.
Use `.` to select the first child of the current node.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute name from which to extract the value.
If not provided, the plugin will extract the inner text of the element.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the regular expression pattern to apply to the extracted value.
This allows for precise data extraction from the text or attribute value.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the key under which the extracted data will be stored.
This key can be used to reference the data in subsequent steps.

### Data Type (DataType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the data type to which the extracted value should be converted.
Supported data types include `String`, `Number`, `Boolean` and  `DateTime`.

#### Values

##### String

Textual data.
##### Number

Whole numbers or numeric values with decimal points.
##### Boolean

True or False values.
##### Date Time

Date and/or time values.

## Scope

* Any