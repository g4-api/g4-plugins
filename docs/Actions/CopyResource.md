# Copy Resource (CopyResource)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Downloads files from web elements and saves them to local disk. It reads a URL from an element's text or a named attribute, applies an optional regular expression to extract the exact endpoint, and fetches the content via HTTP, HTTPS, or by decoding an inline data URI. The output directory is created automatically if it does not exist, and every successfully written file path is stored in the CopiedResources session parameter for downstream use.

### Key Features and Functionality

| Feature                 | Description                                                                                   |
|-------------------------|-----------------------------------------------------------------------------------------------|
| Element URL Resolution  | Reads the download URL from a named attribute or element text content.                        |
| Regex URL Extraction    | Applies a regular expression to isolate the exact URL from surrounding text or markup.        |
| HTTP/HTTPS Download     | Fetches file content via an HttpClient GET request and writes bytes directly to disk.         |
| Data URI Support        | Decodes inline base64-encoded data URIs without making any HTTP request.                      |
| Parallel Processing     | Processes elements concurrently using Parallel.ForEach when the Parallel switch is set.       |
| Auto Directory Creation | Creates the target directory automatically if it does not already exist before writing files. |
| Session Output          | Stores all saved file paths in the CopiedResources session parameter for downstream steps.    |

### Usages in RPA

| Use Case            | Description                                                                                            |
|---------------------|--------------------------------------------------------------------------------------------------------|
| Bulk Asset Download | Download images, PDFs, or other files listed on a page into a local folder as part of an RPA workflow. |
| Document Collection | Harvest linked documents from a content portal and store them locally for further processing.          |
| Media Archival      | Capture media files from web pages into a structured archive directory.                                |

### Usages in Automation Testing

| Use Case              | Description                                                                                              |
|-----------------------|----------------------------------------------------------------------------------------------------------|
| Resource Verification | Download advertised resources and verify their content or file size against expected values.             |
| Download Regression   | Confirm that file download links continue to resolve correctly after application changes.                |
| Performance Baseline  | Measure resource download durations against an established baseline using parallel and sequential modes. |

## Examples

### Example No.1

### Download images from src attributes in parallel

Selects all `img` elements with a `src` attribute using an XPath locator, reads the `src` attribute from each, matches the URL with the supplied regular expression, and downloads each image to `/home/user/images` in parallel.
The `--Parallel` switch activates concurrent processing via `Parallel.ForEach`, which is useful when downloading many resources at once.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/images --Parallel}}",
    OnAttribute = "src",
    OnElement = "//img[@src]",
    RegularExpression = "https?://.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/images --Parallel}}")
    .setOnAttribute("src")
    .setOnElement("//img[@src]")
    .setRegularExpression("https?://.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/images --Parallel}}",
    onAttribute: "src",
    onElement: "//img[@src]",
    regularExpression: "https?://.*"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/images --Parallel}}",
    "onAttribute": "src",
    "onElement": "//img[@src]",
    "regularExpression": "https?://.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/images --Parallel}}",
    "onAttribute": "src",
    "onElement": "//img[@src]",
    "regularExpression": "https?://.*"
}
```
### Example No.2

### Download documents from href attributes sequentially

Selects `a` elements whose `href` ends with `.pdf` using a CSS selector, reads the `href` attribute from each, extracts the URL with the regular expression, and saves each document to `/home/user/docs` one at a time.
Sequential mode is the default when `--Parallel` is omitted.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/docs}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "a[href$='.pdf']",
    RegularExpression = "https?://[^\s]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/docs}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("a[href$='.pdf']")
    .setRegularExpression("https?://[^\s]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/docs}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "a[href$='.pdf']",
    regularExpression: "https?://[^\s]+"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/docs}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "a[href$='.pdf']",
    "regularExpression": "https?://[^\s]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/docs}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "a[href$='.pdf']",
    "regularExpression": "https?://[^\s]+"
}
```
### Example No.3

### Download resources extracted from element text content

Selects elements matching the CSS selector `div.resource-link`, reads their visible text, applies the regular expression to extract the embedded URL, and downloads the resolved resource to `/home/user/resources`.
Use this mode when the download URL is embedded in element text rather than an HTML attribute.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/resources}}",
    Locator = "CssSelector",
    OnElement = "div.resource-link",
    RegularExpression = "https?://[^\s]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/resources}}")
    .setLocator("CssSelector")
    .setOnElement("div.resource-link")
    .setRegularExpression("https?://[^\s]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/resources}}",
    locator: "CssSelector",
    onElement: "div.resource-link",
    regularExpression: "https?://[^\s]+"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/resources}}",
    "locator": "CssSelector",
    "onElement": "div.resource-link",
    "regularExpression": "https?://[^\s]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/resources}}",
    "locator": "CssSelector",
    "onElement": "div.resource-link",
    "regularExpression": "https?://[^\s]+"
}
```

## Output Parameter

### Copy Resource Copied Resources (CopyResource:CopiedResources)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

A collection of absolute file paths for every resource successfully downloaded during the action.
Paths for files that failed to download are omitted — only successfully written paths are included.
Use this parameter in downstream steps to validate, move, or further process the downloaded files.

## Properties

### Argument (Argument)

| Attribute             | Value                 |
|-----------------------|-----------------------|
| **Default Value**     | Null                  |
| **Depends On**        | None                  |
| **Mandatory**         | Yes                   |
| **Multiple**          | No                    |
| **Value Type**        | String|Uri|Expression |

The save path used when the Path parameter is not supplied. Accepts a directory path, a file path, or a dynamic expression.
When the Path parameter is present this value is ignored as a save target.
Defaults to the current working directory when this property is also absent.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy used to locate elements from which URLs are resolved.
Defaults to Xpath when not provided.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The name of the HTML attribute to read from each element when resolving the download URL.
When absent the plugin reads the element's visible text content instead.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The locator expression that identifies the elements to iterate over.
Each matched element contributes one download attempt.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

A regular expression applied to the element's text or attribute value to extract the exact download URL.
The first match is used as the endpoint.
Defaults to `(?s).*`, which matches and returns the entire value unchanged.

## Parameters

### Path (Path)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The directory or file path where downloaded resources are saved.
When Path is absent the plugin uses the rule's Argument value as the save location.
If neither provides a usable path the current working directory is used and the filename is derived from the endpoint URI.

### Parallel (Parallel)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

When present, enables parallel processing of all matched elements using Parallel.ForEach with MaxDegreeOfParallelism set to Environment.ProcessorCount.
Omit this switch for sequential processing.
Results are accumulated in a thread-safe ConcurrentBag regardless of mode.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-elements](https://www.w3.org/TR/webdriver/#find-elements)
