# Resolve Online File (ResolveOnlineFile)

[Table of Content](../Home.md)  

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Locates and downloads a file from a direct URL or from a URL resolved via a web element.
It applies optional regex filtering to isolate the exact endpoint, performs an HTTP GET download, Base64-encodes the file bytes, and stores the content together with file name, extension, size, and HTTP status code in dedicated session output parameters.
On failure it clears all stored session data and logs the exception, so downstream steps always encounter either valid data or an explicit failure signal.

### Key Features and Functionality

| Feature                       | Description                                                                      |
|-------------------------------|----------------------------------------------------------------------------------|
| UI Element URL Resolution     | Locate URL from a web element's text or specified attribute.                     |
| Regular Expression Extraction | Extract or filter the exact URL using a provided regex.                          |
| HTTP File Download            | Download the file content via an HTTP GET request.                               |
| Base64 Encoding & Metadata    | Convert file bytes to Base64 and extract name, extension, size, and status code. |
| Session Parameter Management  | Store file data and metadata in session parameters for downstream use.           |
| Error Cleanup & Logging       | Clear session parameters and log exceptions to maintain a clean state.           |

### Usages in RPA

| Use Case                       | Description                                                           |
|--------------------------------|-----------------------------------------------------------------------|
| UI-Driven File Download        | Download files linked in web apps by resolving elements at runtime.   |
| Dynamic URL Extraction         | Fetch resources when URLs are embedded in element text or attributes. |
| Regex-Based Resource Filtering | Use a regex to isolate and download specific URL segments.            |

### Usages in Automation Testing

| Use Case               | Description                                                           |
|------------------------|-----------------------------------------------------------------------|
| Test Asset Retrieval   | Retrieve test documents or binaries from UI elements for validation.  |
| Content Verification   | Download and inspect file contents returned by the system under test. |
| Data-Driven Test Input | Supply downloaded files as inputs for parameterized test runs.        |

## Examples

### Example No.1

### Resolve an Online File URL

It uses the `ResolveOnlineFile` plugin with the argument set to the file URL `http://io.files/g4.pdf`.
Values are returned as binary data (e.g. PDF bytes) for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    Argument = "http://io.files/g4.pdf"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setArgument("http://io.files/g4.pdf");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    argument: "http://io.files/g4.pdf"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "argument": "http://io.files/g4.pdf"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "argument": "http://io.files/g4.pdf"
}
```
### Example No.2

### Resolve an Online File URL and Extract a Link via XPath

It uses the `ResolveOnlineFile` plugin to download the file, then applies the XPath `//a[@data-automation-id='direct-url-link']` to locate the desired link.
Values are returned as strings (e.g. "G4 Tutorial Guide") for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    OnElement = "//a[@data-automation-id='direct-url-link']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setOnElement("//a[@data-automation-id='direct-url-link']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    onElement: "//a[@data-automation-id='direct-url-link']"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "onElement": "//a[@data-automation-id='direct-url-link']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "onElement": "//a[@data-automation-id='direct-url-link']"
}
```
### Example No.3

### Resolve an Online File URL and Extract a Link via CSS Selector

It uses the `ResolveOnlineFile` plugin to download the file from `http://io.files/g4.pdf`, then applies the CSS selector `a.tutorial-link` to locate the desired link.
Values are returned as strings (e.g. link text `G4 Tutorial Guide`) for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    Locator = "CssSelector",
    OnElement = "a.tutorial-link"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setLocator("CssSelector")
    .setOnElement("a.tutorial-link");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    locator: "CssSelector",
    onElement: "a.tutorial-link"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "locator": "CssSelector",
    "onElement": "a.tutorial-link"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "locator": "CssSelector",
    "onElement": "a.tutorial-link"
}
```
### Example No.4

### Resolve an Online File URL and Extract a Matching URL with Regex via XPath

It uses the `ResolveOnlineFile` plugin to download the file, applies the XPath `//a[contains(.,'g4.pdf')]` to locate the link element, then applies the regular expression `https?://[^\s"']+?/g4\.pdf` to extract the precise PDF URL (e.g. `http://io.files/g4.pdf`).
Values are returned as strings for downstream processing.
The `?` quantifier makes the `s` optional in `https`, and the non-greedy `+?` match avoids capturing extra characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    OnElement = "//a[contains(.,'g4.pdf')]",
    RegularExpression = "https?://[^\s"']+?/g4\.pdf"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setOnElement("//a[contains(.,'g4.pdf')]")
    .setRegularExpression("https?://[^\s"']+?/g4\.pdf");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    onElement: "//a[contains(.,'g4.pdf')]",
    regularExpression: "https?://[^\s"']+?/g4\.pdf"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "onElement": "//a[contains(.,'g4.pdf')]",
    "regularExpression": "https?://[^\s"']+?/g4\.pdf"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "onElement": "//a[contains(.,'g4.pdf')]",
    "regularExpression": "https?://[^\s"']+?/g4\.pdf"
}
```
### Example No.5

### Resolve an Online File URL and Extract an Attribute via XPath

It uses the `ResolveOnlineFile` plugin, applies the XPath `//a[contains(.,'g4.pdf')]` to locate the link element, then retrieves its `href` attribute.
Values are returned as strings for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    OnAttribute = "href",
    OnElement = "//a[contains(.,'g4.pdf')]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setOnAttribute("href")
    .setOnElement("//a[contains(.,'g4.pdf')]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    onAttribute: "href",
    onElement: "//a[contains(.,'g4.pdf')]"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "onAttribute": "href",
    "onElement": "//a[contains(.,'g4.pdf')]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "onAttribute": "href",
    "onElement": "//a[contains(.,'g4.pdf')]"
}
```
### Example No.6

### Resolve an Online File URL and Clean an Attribute with Regex via XPath

It uses the `ResolveOnlineFile` plugin to download the file, applies the XPath `//a[contains(.,'g4.pdf')]` to locate the link element, retrieves its `href` attribute, and then applies the regex `[^?\"]+\.pdf` to strip any query parameters (in JSON the quote is double-escaped, but at runtime the pattern is `[^?"]+\.pdf`).
Values are returned as strings for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ResolveOnlineFile",
    OnAttribute = "href",
    OnElement = "//a[contains(.,'g4.pdf')]",
    RegularExpression = "[^?\"]+\.pdf"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ResolveOnlineFile")
    .setOnAttribute("href")
    .setOnElement("//a[contains(.,'g4.pdf')]")
    .setRegularExpression("[^?\"]+\.pdf");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ResolveOnlineFile",
    onAttribute: "href",
    onElement: "//a[contains(.,'g4.pdf')]",
    regularExpression: "[^?\"]+\.pdf"
};
```

_**JSON**_

```js
{
    "pluginName": "ResolveOnlineFile",
    "onAttribute": "href",
    "onElement": "//a[contains(.,'g4.pdf')]",
    "regularExpression": "[^?\"]+\.pdf"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ResolveOnlineFile",
    "onAttribute": "href",
    "onElement": "//a[contains(.,'g4.pdf')]",
    "regularExpression": "[^?\"]+\.pdf"
}
```

## Output Parameter

### Resolve Online File Data (ResolveOnlineFile:Data)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

File content converted into a text format so it can travel safely through systems that handle only text.
Encoded data can be converted back into the original file for use or storage.
Keeping file data in text form helps scripts move it without breaking.

### Resolve Online File Extension (ResolveOnlineFile:Extension)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

File extension without a dot, like “pdf” or “jpg”, that tells you the file type.
Knowing the extension helps scripts choose the right way to open or save the file.
It determines how the file can be processed or displayed.

### Resolve Online File Full Name (ResolveOnlineFile:FullName)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Complete file name including its extension, for example “report.pdf”.
Use this name when saving or displaying the file to keep it recognizable.
It comes directly from the resource's address.

### Resolve Online File Name (ResolveOnlineFile:Name)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

File name without its extension, for example “report” from “report.pdf”.
Using the base name helps when you need a label separate from the file format.
It makes it easier to organize files by name only.

### Resolve Online File Size (ResolveOnlineFile:Size)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Size of the downloaded file in bytes as a text number like “102400”.
Knowing the file size helps workflows decide if the file is too large or small.
Scripts can use this value to enforce limits or display progress information.

### Resolve Online File Status Code (ResolveOnlineFile:StatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

HTTP status code from the download request, such as “200” for success or “404” if not found.
Using the status code lets workflows handle errors or confirm success.
Scripts can check this value to decide what to do next.

### Resolve Online File Uri (ResolveOnlineFile:Uri)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Full address of the requested resource after any filtering or lookup.
Logging the exact address helps track which resource was used or retried.
Using the URI makes auditing and debugging more reliable.

## Properties

### Argument (Argument)

| Attribute             | Value                 |
|-----------------------|-----------------------|
| **Default Value**     | Null                  |
| **Depends On**        | None                  |
| **Mandatory**         | No                    |
| **Multiple**          | No                    |
| **Value Type**        | String|Uri|Expression |

Defines the address used to download the file, which can be text, a web link, or a dynamic expression.
Explicit URLs make file downloads more reliable.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines how to find the element that holds the download link.
XPath is the default method when no other locator is provided.
Choosing the right locator ensures the correct element is used.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Reads the link from a specific attribute on the chosen element.
Use the attribute name to pick which part of the element holds the URL.
Correct attribute selection ensures the right address is captured.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Identifies the element that contains the download link.
Accurate element selection ensures the correct URL is used.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Filters the element's text using a pattern to extract the needed link portion.
Only matching parts are kept before download.
Pattern matching leads to more precise URL extraction.

## Scope

* Any