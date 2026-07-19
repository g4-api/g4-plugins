# New Browser Window (NewBrowserWindow)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Opens one or more new browser windows or tabs by calling `window.open(url, target)` via JavaScript execution within the current WebDriver session.
Unlike `OpenUrl`, which navigates the current browsing context to a new address, `NewBrowserWindow` always opens an additional context without leaving the current page.
There is no URL parameter — the URL is exclusively derived from a located element's text or attribute, or defaults to `about:blank` when no element is provided.
`RegularExpression` is always applied to the extracted URL string; when the pattern matches the full string the complete value is passed to `window.open()`.
The `Target` parameter controls the `window.open()` target context and the `Amount` parameter controls how many times the call is repeated.

### Key Features and Functionality

| Feature              | Description                                                                                                       |
|----------------------|-------------------------------------------------------------------------------------------------------------------|
| Blank Window Opening | Opens a new blank window or tab (`about:blank`) when no element is provided.                                     |
| Element URL Source   | Reads the URL from an element's text content or a named attribute when `OnElement` is specified.                  |
| Regex Filtering      | Always applies `RegularExpression` to the extracted URL so only the matched portion is passed to `window.open()`. |
| Target Control       | Sets the `window.open()` target context — `_blank`, `_self`, `_parent`, or `_top` — via the `Target` parameter.  |
| Repeat Opening       | Calls `window.open()` `Amount` times, opening multiple identical windows or tabs in a single step.               |

### Usages in RPA

| Use Case                   | Description                                                                                                           |
|----------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Multi-Window Workflows     | Open several blank tabs or element-sourced URLs simultaneously as part of a parallel processing workflow.             |
| Link-Driven Navigation     | Programmatically open a URL extracted from a page element in a new tab without navigating away from the current page. |
| Bulk Context Provisioning  | Pre-open a fixed number of blank windows that subsequent steps populate by switching handles and navigating each one. |

### Usages in Automation Testing

| Use Case                | Description                                                                                                                  |
|-------------------------|------------------------------------------------------------------------------------------------------------------------------|
| Multi-Window Testing    | Verify that an application correctly handles workflows that span multiple browser windows or tabs.                            |
| Link Target Testing     | Confirm that element-extracted URLs open in the expected target context (`_blank`, `_self`, etc.) when the action runs.      |
| Window Count Validation | Open a known number of tabs with `Amount` and assert the resulting window handle count to validate multi-window bookkeeping. |

## Examples

### Example No.1

### Open multiple blank browser tabs

Calls `window.open('about:blank', '_blank')` three times to open three new browser tabs.
No element is required — the URL is always `about:blank` when `OnElement` is absent.
Use this form when the goal is to pre-open a set of blank tabs as part of a multi-window workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Argument = "{{$ --Amount:3 --Target:_blank}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setArgument("{{$ --Amount:3 --Target:_blank}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    argument: "{{$ --Amount:3 --Target:_blank}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Amount:3 --Target:_blank}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Amount:3 --Target:_blank}}"
}
```
### Example No.2

### Open a new tab using a URL from element text

Locates the element matching `#OpenLink` using the CssSelector strategy and reads its text content as the URL.
Calls `window.open(url, '_blank')` once to open a new tab at that address.
Use this form when the target URL is stored as the visible text of a page element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Locator = "CssSelector",
    OnElement = "#OpenLink"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setLocator("CssSelector")
    .setOnElement("#OpenLink");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    locator: "CssSelector",
    onElement: "#OpenLink"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "locator": "CssSelector",
    "onElement": "#OpenLink"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "locator": "CssSelector",
    "onElement": "#OpenLink"
}
```
### Example No.3

### Open a URL from an element attribute filtered by regex

Locates the element matching `#OpenLink`, reads its `href` attribute, and applies the regular expression `https?://[^\s]+` to extract only the URL portion.
Calls `window.open(url, '_self')` to load the extracted URL in the current tab.
Use this form when the attribute value contains surrounding text and only the URL portion should be passed to `window.open()`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Argument = "{{$ --Target:_self}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#OpenLink",
    RegularExpression = "https?://[^\s]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setArgument("{{$ --Target:_self}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#OpenLink")
    .setRegularExpression("https?://[^\s]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    argument: "{{$ --Target:_self}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#OpenLink",
    regularExpression: "https?://[^\s]+"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Target:_self}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#OpenLink",
    "regularExpression": "https?://[^\s]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Target:_self}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#OpenLink",
    "regularExpression": "https?://[^\s]+"
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
| **Value Type**    | String|Expression |

Argument carries the `--Amount` and `--Target` parameter values as a CLI macro expression.
When absent both parameters take their default values: Amount = 1 and Target = _blank.

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

OnAttribute specifies the name of the element attribute from which the URL is read.
When set, `element.GetAttribute(OnAttribute)` is called instead of reading `element.Text`.
When absent the element's text content is used as the URL source.
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
When absent no element is resolved and the URL defaults to `about:blank`.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

RegularExpression is applied to the extracted URL string via `Regex.Match` and only the matched portion is passed to `window.open()`.
Use this property to isolate the URL when the element text or attribute contains surrounding content.
When absent the default pattern matches the full string so the complete extracted value is passed as the URL.

## Parameters

### Amount (Amount)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Amount specifies how many times `window.open()` is called.
Each call opens one new browser window or tab.
When absent the value defaults to 1.
When the value cannot be parsed as an integer the call count is 0 and no window is opened.

### Target (Target)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | _blank            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Target specifies the second argument passed to `window.open()`, which controls the browsing context where the new page is loaded.
When absent the value defaults to `_blank`.

#### Values

##### Blank

Opens the URL in a new tab or window.
##### Self

Opens the URL in the current tab or window.
##### Parent

Opens the URL in the parent frame.
##### Top

Opens the URL in the topmost frame.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
