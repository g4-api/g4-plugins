# Open Url (OpenUrl)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `OpenUrl` plugin is to automate the navigation to a specified URL within the browser. 
This plugin provides a mechanism to programmatically navigate to a new URL, which can be part of automated workflows or tests.

### Key Features and Functionality

| Feature           | Description                                                                             |
|-------------------|-----------------------------------------------------------------------------------------|
| URL Navigation    | Automates the process of navigating to a specified URL in the browser.                  |
| Element-Based URL | Retrieves URLs from specified web elements or attributes to navigate.                   |
| Regex Extraction  | Supports extracting URLs using regular expressions from the element text or attributes. |

### Usages in RPA

| Usage                | Description                                                                     |
|----------------------|---------------------------------------------------------------------------------|
| Data Collection      | Navigate to different URLs to collect data from multiple sources automatically. |
| Multi-Page Workflows | Automate workflows that require navigation across multiple pages.               |
| Form Submissions     | Navigate to specific URLs after form submissions or other interactions.         |

### Usages in Automation Testing

| Usage                 | Description                                                                         |
|-----------------------|-------------------------------------------------------------------------------------|
| Functional Testing    | Verify that web applications correctly navigate to specified URLs.                  |
| Link Verification     | Ensure that links and buttons direct to the correct URLs.                           |
| Multi-Page UI Testing | Test the UI and functionality across multiple pages by navigating programmatically. |

## Examples

### Example No.1

Navigate to the URL `http://example.com`. 
This example demonstrates how to open a specific URL directly without relying on any web element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Argument = "http://example.com"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setArgument("http://example.com");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    argument: "http://example.com"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "argument": "http://example.com"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "argument": "http://example.com"
}
```
### Example No.2

Navigate to the URL specified by the element identified by the CSS selector `#LinkToOpen`. 
This example shows how to retrieve the URL from the text content or attribute of a specified web element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Locator = "CssSelector",
    OnElement = "#LinkToOpen"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setLocator("CssSelector")
    .setOnElement("#LinkToOpen");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    locator: "CssSelector",
    onElement: "#LinkToOpen"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen"
}
```
### Example No.3

Navigate to the URL specified in the `href` attribute of the element identified by the CSS selector `#LinkToOpen`. 
This example demonstrates how to retrieve the URL from a specific attribute of a web element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#LinkToOpen"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#LinkToOpen");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#LinkToOpen"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#LinkToOpen"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#LinkToOpen"
}
```
### Example No.4

Navigate to the URL extracted from the `href` attribute of the element identified by the CSS selector `#LinkToOpen`, using a regular expression to match and extract the desired URL pattern. 
This example highlights how to use a regular expression to precisely match and extract the URL from an attribute.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#LinkToOpen",
    RegularExpression = "https?://.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#LinkToOpen")
    .setRegularExpression("https?://.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#LinkToOpen",
    regularExpression: "https?://.*"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#LinkToOpen",
    "regularExpression": "https?://.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#LinkToOpen",
    "regularExpression": "https?://.*"
}
```
### Example No.5

Navigate to the URL extracted from the text content of the element identified by the CSS selector `#LinkToOpen`, using a regular expression to match and extract the desired URL pattern. 
This example demonstrates how to use a regular expression to retrieve the URL directly from the text content of a web element without specifying an attribute.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Locator = "CssSelector",
    OnElement = "#LinkToOpen",
    RegularExpression = "https?://.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setLocator("CssSelector")
    .setOnElement("#LinkToOpen")
    .setRegularExpression("https?://.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    locator: "CssSelector",
    onElement: "#LinkToOpen",
    regularExpression: "https?://.*"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen",
    "regularExpression": "https?://.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen",
    "regularExpression": "https?://.*"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the URL to navigate to if no element is provided or if a direct URL is needed.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifying the target element from which the URL should be retrieved for navigation.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifying the type of locator used to identify the target element defined by the `OnElement` property.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Retrieves the URL from the specified attribute of the target element.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Uses a regular expression to match and extract the desired part of the URL from the target element.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#navigate-to](https://www.w3.org/TR/webdriver/#navigate-to)
