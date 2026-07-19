# Open Url (OpenUrl)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Navigates the current browser window to a specified URL using the WebDriver navigate-to command.
The URL source depends on whether a target element is provided: when no element is given the `Argument` property is used directly without regex processing; when an element is given the URL is read from the element's text content or a named attribute and `RegularExpression` is then applied to the extracted value.
`RegularExpression` is only active when an element is located — it does not process the direct `Argument` value.

### Key Features and Functionality

| Feature          | Description                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------|
| Direct URL       | Navigates to the URL supplied via `Argument` when no element is specified; regex is not applied.    |
| Element Text URL | Reads the URL from a located element's text content when `OnAttribute` is absent.                   |
| Attribute URL    | Reads the URL from a named element attribute via `OnAttribute` when the element is located.         |
| Regex Filtering  | Applies `RegularExpression` to the element-sourced URL so only the matched portion is navigated to. |
| Current Context  | Always navigates the current browsing context — it does not open a new window or tab.               |

### Usages in RPA

| Use Case             | Description                                                                                     |
|----------------------|-------------------------------------------------------------------------------------------------|
| Data Collection      | Navigate to different URLs in sequence to collect data from multiple sources automatically.     |
| Multi-Page Workflows | Drive workflows that require moving through several pages by navigating programmatically.       |
| Link-Driven Flow     | Extract a URL from a page element and navigate to it without requiring manual URL construction. |

### Usages in Automation Testing

| Use Case              | Description                                                                                  |
|-----------------------|----------------------------------------------------------------------------------------------|
| Functional Testing    | Verify that web applications navigate to the correct URL when triggered programmatically.    |
| Link Verification     | Confirm that element-extracted URLs resolve to the expected destinations.                    |
| Multi-Page UI Testing | Drive multi-page test flows by navigating to each page URL under controlled test conditions. |

## Examples

### Example No.1

### Navigate directly to a URL

Navigates the current browser window to `http://example.com` using the `Argument` property.
No element is involved and `RegularExpression` is not applied — the argument value is passed to `WebDriver.OpenUrl` as-is.

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

### Navigate to a URL read from an element's text content

Locates the element matching `#LinkToOpen` using the CssSelector strategy and reads its text content as the navigation URL.
`RegularExpression` is applied to the text — the default pattern matches the full string so the entire text value is used.
Use this form when the target URL is stored as the visible text of a page element.

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

### Navigate to a URL extracted from an element attribute via regex

Locates the element matching `#LinkToOpen`, reads its `href` attribute, and applies the regular expression `https?://.*` to extract the URL portion.
Calls `WebDriver.OpenUrl` with the matched value to navigate the current window.
Use this form when the attribute value may contain surrounding text and only the URL portion is needed.

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

## Properties

### Argument (Argument)

| Attribute             | Value                 |
|-----------------------|-----------------------|
| **Default Value**     | Null                  |
| **Depends On**        | None                  |
| **Mandatory**         | No                    |
| **Multiple**          | No                    |
| **Value Type**        | String|Uri|Expression |

Argument specifies the URL to navigate to when no element is provided.
This value is used directly as the navigation URL without any regex processing when OnElement is absent or the element cannot be resolved.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target element when `OnElement` is provided.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.
Locator has no effect when OnElement is not set.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnAttribute specifies the element attribute from which the URL is read when an element is located.
When set, `element.GetAttribute(OnAttribute)` is called instead of reading `element.Text`.
OnAttribute has no effect when OnElement is not set.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element from which the URL is extracted.
When absent no element is resolved and the URL is taken from Argument directly without regex processing.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

RegularExpression is applied to the URL extracted from the element via `Regex.Match` and only `match.Value` is passed to `WebDriver.OpenUrl`.
RegularExpression is not applied on the direct-argument path — it only processes element-sourced URLs.
When the pattern does not match, `match.Value` is an empty string and the browser receives an empty URL.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#navigate-to](https://www.w3.org/TR/webdriver/#navigate-to)
