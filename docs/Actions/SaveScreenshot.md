# Save Screenshot (SaveScreenshot)

[Table of Content](../Home.md)  

~19 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Captures and saves a PNG screenshot of the browser viewport or a specific element during automation workflows, using the W3C WebDriver `GET /session/{session id}/screenshot` command as its underlying mechanism.
It automatically creates the target directory, enforces the `.png` extension on every output file, generates a unique GUID-based file name when none is provided, and accumulates every saved absolute path in the `SaveScreenshot:Screenshots` session parameter for downstream use.

### Key Features and Functionality

| Feature                 | Description                                                                                                                                                    |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Full-Page Screenshot    | Captures the entire browser viewport as a PNG file when no target element is specified.                                                                        |
| Element Screenshot      | Captures only the specified element when OnElement and Locator are supplied, using the element-level screenshot call.                                          |
| Null-Element Fallback   | Falls back to a full-page screenshot when a locator is supplied but GetElement returns null, making the action unconditionally safe to invoke.                 |
| Auto Directory Creation | Calls Directory.CreateDirectory before writing, creating the target directory and any missing parent directories automatically.                                |
| Auto File Naming        | Generates a unique GUID-based file name when FileName is omitted, preventing accidental overwrites across repeated invocations.                               |
| PNG Enforcement         | Always appends .png to the output file name if it does not already end with .png (case-insensitive), ensuring every saved file is a valid PNG.                |
| Session Output          | Appends each recorded value (file path, or base64 string when Base64 is used) to the SaveScreenshot:Screenshots session parameter, accumulating a complete list across all invocations in the session. |
| Base64 Embedding        | When the Base64 switch is supplied, skips the disk write and records the screenshot as a base64 PNG string, embedding the image in the response via the Screenshot response entity key for downstream processing.            |

### Usages in RPA

| Use Case              | Description                                                                                                                               |
|-----------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| Audit Trail           | Capture screenshots at key workflow steps to create a visual record for compliance review and process documentation.                      |
| Error Documentation   | Take a screenshot when an unexpected state is detected to provide visual evidence that pinpoints the exact failure point for analysis.     |
| Step Evidence Capture | Save a screenshot after a critical form submission or navigation to confirm the application transitioned to the expected state.            |

### Usages in Automation Testing

| Use Case                   | Description                                                                                                                                            |
|----------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| Visual Regression Testing  | Capture screenshots at fixed checkpoints across test runs and compare the accumulated SaveScreenshot:Screenshots paths to detect unintended UI changes. |
| Cross-Browser Verification | Save viewport and element screenshots across browser configurations to confirm consistent rendering and layout behaviour.                              |
| Failure Evidence           | Collect a screenshot immediately at the point of assertion failure to provide a reproducible visual artifact for root-cause analysis.                  |

## Examples

### Example No.1

### Full-page screenshot with custom directory and file name

Captures a screenshot of the full browser viewport and saves it as `PageScreenshot.png` in the `Screenshots` directory.
The saved absolute path is appended to the `SaveScreenshot:Screenshots` session parameter.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
}
```
### Example No.2

### Full-page screenshot with default settings

Captures a screenshot of the full browser viewport using all default settings.
This is the simplest invocation — no directory or file name configuration is required.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot"
}
```
### Example No.3

### Element-level screenshot with CSS selector

Captures a screenshot scoped to the element identified by the CSS selector `#ClickButton` and saves it as `ElementScreenshot.png` in the `Screenshots` directory.
When `OnElement` and `Locator` are provided the plugin calls `element.SaveScreenshot` instead of the full-page capture.
If the element is not found by the locator the plugin falls back to a full-page screenshot.
The saved absolute path is appended to the `SaveScreenshot:Screenshots` session parameter.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```
### Example No.4

### Full-page screenshot returned as base64

Captures a screenshot of the full browser viewport and returns it as a base64-encoded PNG string instead of writing a file to disk.
When the `--Base64` switch is supplied the plugin skips the disk write and records the base64 content as the value.
The base64 string is appended to the `SaveScreenshot:Screenshots` session parameter and exposed as the `Screenshot` key on the plugin response entity, embedding the image in the response for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Base64}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Base64}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Base64}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Base64}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Base64}}"
}
```

## Output Parameter

### Save Screenshot Screenshots (SaveScreenshot:Screenshots)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

A JSON array of the recorded value for every screenshot captured during the automation session.
Each value is an absolute file path by default, or a base64-encoded PNG string when the Base64 switch is supplied.
Each invocation of SaveScreenshot appends the new value to the existing list, so the parameter accumulates values across multiple calls in the same session.
Use this parameter in downstream steps to validate, move, rename, attach, or embed the captured screenshots.

## Properties

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The locator strategy used to find the element specified in OnElement.
When OnElement is absent this property is ignored and the plugin takes a full-page screenshot.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A locator expression that identifies the element to screenshot.
When supplied the plugin captures only that element instead of the full browser viewport.
When the element cannot be found the plugin falls back to a full-page screenshot without raising an error.

## Parameters

### Directory (Directory)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | .                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Uri               |

The directory where the screenshot file is saved.
Defaults to the current working directory when omitted.

### File Name (FileName)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The name of the screenshot file.
When omitted a new GUID string is used as the file name.

### Base64 (Base64)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

When present, the screenshot is returned as a base64-encoded PNG string instead of being written to disk.
The base64 content is exposed as the `Screenshot` key on the plugin response entity and appended to the `SaveScreenshot:Screenshots` session parameter, allowing the embedded image to be carried inside the response for downstream processing.
Downstream plugins can read the image directly from the response entity without relying on the file system.
When omitted the screenshot is saved to disk and the resolved file path is used instead.
This switch is self-contained: it governs the plugin's behavior directly and does not depend on the automation-wide screenshot settings.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#take-screenshot](https://www.w3.org/TR/webdriver/#take-screenshot)
