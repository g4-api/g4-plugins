# Web Element Content (WebElementContent)

[Table of Content](../Home.md)  

~16 min · Content Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `WebElementContent` plugin extracts content from web elements in a live browser or application session using a variety of WebDriver locators. It allows users to target specific elements or attributes within a web page or application UI and extract their values, optionally applying regular expressions for precise data retrieval.

This plugin supports all WebDriver locators and works with all WebDriver-compliant drivers, including but not limited to mobile and Windows drivers such as Appium and Windows Application Driver. This enables automation across web browsers and native applications on various platforms.

### Key Features and Functionality

| Feature              | Description                                                                                  |
|----------------------|----------------------------------------------------------------------------------------------|
| Element Selection    | Selects elements using any WebDriver locator specified in `OnElement` and `Locator`.         |
| Attribute Extraction | Extracts values from specified attributes or inner text if `OnAttribute` is not provided.    |
| Regular Expression   | Applies a regular expression to the extracted value for precise data extraction.             |
| Data Type Conversion | Converts the extracted value to a specified data type using `DataType`.                      |
| Wide Compatibility   | Works with all WebDriver-compliant drivers, including web, mobile, and desktop applications. |

### Usages in RPA

| Usage                       | Description                                                                                     |
|-----------------------------|-------------------------------------------------------------------------------------------------|
| Web Data Extraction         | Extract specific information from web pages during automated browsing sessions.                 |
| Application Data Extraction | Extract data from native applications using drivers like Appium and Windows Application Driver. |
| Dynamic Content Scraping    | Scrape content that is dynamically loaded or requires user interaction.                         |
| Form Data Retrieval         | Extract values from form fields or other interactive elements on a web page or app.             |

### Usages in Automation Testing

| Usage                  | Description                                                                              |
|------------------------|------------------------------------------------------------------------------------------|
| UI Testing             | Automate testing of UI components by extracting and validating their properties.         |
| Functional Testing     | Verify that applications respond correctly to user interactions by extracting live data. |
| Cross-Platform Testing | Perform tests across web, mobile, and desktop applications using various drivers.        |

## Examples

### Example No.1

Extract the text content of an element using an ID locator.

The `WebElementContent` plugin selects an element by its `id` and extracts its inner text.
This allows you to retrieve specific information from the web page or application during an active session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WebElementContent",
    Locator = "Id",
    OnElement = "productName"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WebElementContent")
    .setLocator("Id")
    .setOnElement("productName");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WebElementContent",
    locator: "Id",
    onElement: "productName"
};
```

_**JSON**_

```js
{
    "pluginName": "WebElementContent",
    "locator": "Id",
    "onElement": "productName"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WebElementContent",
    "locator": "Id",
    "onElement": "productName"
}
```
### Example No.2

Extract the value of an attribute from an element using a locator supported by mobile applications.

The `WebElementContent` plugin selects an element in a mobile application and extracts the value of a specified attribute.
This is useful for retrieving properties from elements in mobile apps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WebElementContent",
    Locator = "MobileLocator",
    OnAttribute = "content-desc",
    OnElement = "accessibilityId:loginButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WebElementContent")
    .setLocator("MobileLocator")
    .setOnAttribute("content-desc")
    .setOnElement("accessibilityId:loginButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WebElementContent",
    locator: "MobileLocator",
    onAttribute: "content-desc",
    onElement: "accessibilityId:loginButton"
};
```

_**JSON**_

```js
{
    "pluginName": "WebElementContent",
    "locator": "MobileLocator",
    "onAttribute": "content-desc",
    "onElement": "accessibilityId:loginButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WebElementContent",
    "locator": "MobileLocator",
    "onAttribute": "content-desc",
    "onElement": "accessibilityId:loginButton"
}
```
### Example No.3

Extract a numeric value from an element's text in a desktop application using a Windows locator.

The `WebElementContent` plugin extracts the inner text of an element in a Windows application and applies a regular expression to retrieve a numeric value.
The extracted value is then converted to the specified data type.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WebElementContent",
    Locator = "WindowsLocator",
    OnElement = "AutomationId:priceLabel",
    RegularExpression = "\d+\.\d{2}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WebElementContent")
    .setLocator("WindowsLocator")
    .setOnElement("AutomationId:priceLabel")
    .setRegularExpression("\d+\.\d{2}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WebElementContent",
    locator: "WindowsLocator",
    onElement: "AutomationId:priceLabel",
    regularExpression: "\d+\.\d{2}"
};
```

_**JSON**_

```js
{
    "pluginName": "WebElementContent",
    "locator": "WindowsLocator",
    "onElement": "AutomationId:priceLabel",
    "regularExpression": "\d+\.\d{2}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WebElementContent",
    "locator": "WindowsLocator",
    "onElement": "AutomationId:priceLabel",
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

Specifies the value used to locate the target element, based on the locator type specified in `Locator`.
Use `.` to select the current element in context.
Supports all WebDriver locators, including those for web, mobile, and desktop applications.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of locator used in `OnElement`. The plugin supports all WebDriver locator strategies.
This determines how the plugin interprets the selector provided.
Examples include `Id`, `Name`, `ClassName`, `TagName`, `LinkText`, `PartialLinkText`, `CssSelector`, `XPath`, `AccessibilityId`, `AutomationId`, etc.

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
| **Default Value** | Null              |
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
## See Also

w3c: [https://www.w3.org/TR/webdriver/](https://www.w3.org/TR/webdriver/)
