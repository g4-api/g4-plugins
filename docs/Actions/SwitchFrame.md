# Switch Frame (SwitchFrame)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Switches WebDriver context into a nested frame or iframe on the current page.
It supports two mutually exclusive modes selected automatically at runtime: switching by zero-based integer index or by resolving a web element.

### Key Features and Functionality

| Feature           | Description                                                                                                                |
|-------------------|----------------------------------------------------------------------------------------------------------------------------|
| Switch by Index   | When `Argument` parses as an integer, calls `WebDriver.SwitchTo().Frame(index)` directly — no element resolution.          |
| Switch by Element | When `Argument` is absent or non-integer, resolves a frame element via `GetElement` and calls `SwitchTo().Frame(element)`. |

### Usages in RPA

| Usage            | Description                                                                        |
|------------------|------------------------------------------------------------------------------------|
| Frame Navigation | Automates switching into frames by index or element locator during page workflows. |
| Data Extraction  | Focuses the driver context on frame-contained content before extracting data.      |
| Form Interaction | Enables bots to interact with forms and inputs contained within iframes.           |

### Usages in Automation Testing

| Usage                | Description                                                                                 |
|----------------------|---------------------------------------------------------------------------------------------|
| UI Testing           | Enables automated tests to interact with elements inside frames for comprehensive coverage. |
| Frame Verification   | Verifies that frame elements are correctly loaded and interactable during test execution.   |
| Multi-Frame Handling | Supports testing scenarios involving multiple frames by switching context as required.      |

## Examples

### Example No.1

### Switch to the first frame by index

Switch WebDriver context into the first frame on the page by passing its zero-based index `0` as the `Argument`.
When `Argument` parses as an integer, `WebDriver.SwitchTo().Frame(index)` is called directly — no element resolution occurs.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchFrame",
    Argument = "0"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchFrame")
    .setArgument("0");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchFrame",
    argument: "0"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchFrame",
    "argument": "0"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchFrame",
    "argument": "0"
}
```
### Example No.2

### Switch to a frame by element (CSS selector)

Switch WebDriver context into the iframe element identified by the CSS selector `#mainFrame`.
When `Argument` is absent or cannot be parsed as an integer, the plugin resolves the element via `GetElement` using the specified `Locator` and `OnElement` values, then calls `WebDriver.SwitchTo().Frame(element)`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchFrame",
    Locator = "CssSelector",
    OnElement = "#mainFrame"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchFrame")
    .setLocator("CssSelector")
    .setOnElement("#mainFrame");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchFrame",
    locator: "CssSelector",
    onElement: "#mainFrame"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchFrame",
    "locator": "CssSelector",
    "onElement": "#mainFrame"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchFrame",
    "locator": "CssSelector",
    "onElement": "#mainFrame"
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

Specifies the frame to switch to.
When the value parses as an integer, the plugin switches by zero-based frame index via `WebDriver.SwitchTo().Frame(index)`.
When the value is absent or non-integer, the plugin resolves the frame element using `Locator` and `OnElement` instead.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target frame element defined by the `OnElement` property.
Applies only when `Argument` is absent or not parseable as an integer.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the selector expression used to identify the target frame element on the page.
Evaluated using the strategy defined by the `Locator` property.
Applies only when `Argument` is absent or not parseable as an integer.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#switch-to-frame](https://www.w3.org/TR/webdriver/#switch-to-frame)
