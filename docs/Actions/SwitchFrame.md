# Switch Frame (SwitchFrame)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SwitchFrame` plugin is designed to automate the process of switching between different frames or iframes within a web page. 
It simplifies navigating web content contained in frames, ensuring that automation scripts can interact with elements inside these frames effectively.

### Key Features and Functionality

| Feature           | Description                                                                   |
|-------------------|-------------------------------------------------------------------------------|
| Switch by Index   | Switches to a frame using its index, allowing for straightforward navigation. |
| Switch by Element | Switches to a frame using a specified web element, enhancing flexibility.     |

### Usages in RPA

| Usage            | Description                                                                        |
|------------------|------------------------------------------------------------------------------------|
| Frame Navigation | Automates the process of switching to different frames within a web page.          |
| Data Extraction  | Facilitates data extraction from content within frames by ensuring accurate focus. |
| Form Interaction | Allows RPA bots to interact with forms and inputs contained within iframes.        |

### Usages in Automation Testing

| Usage                | Description                                                                                       |
|----------------------|---------------------------------------------------------------------------------------------------|
| UI Testing           | Enables automated tests to interact with elements inside frames, ensuring comprehensive coverage. |
| Frame Verification   | Helps in verifying that frame elements are correctly loaded and interactable during tests.        |
| Multi-Frame Handling | Supports testing scenarios involving multiple frames, ensuring each is tested appropriately.      |

## Examples

### Example No.1

Switch to the frame using its index `0`. 
This is useful for navigating to the first frame on the page to interact with its content.

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

Switch to a frame using a specified element identified by the CSS selector `#frameElement`. 
This allows for precise navigation to a frame using an element locator, enhancing flexibility.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchFrame",
    Locator = "CssSelector",
    OnElement = "#frameElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchFrame")
    .setLocator("CssSelector")
    .setOnElement("#frameElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchFrame",
    locator: "CssSelector",
    onElement: "#frameElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchFrame",
    "locator": "CssSelector",
    "onElement": "#frameElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchFrame",
    "locator": "CssSelector",
    "onElement": "#frameElement"
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

The `Argument` property allows you to specify the frame to switch to by its index. 
If an index is provided, the plugin switches to the frame at that index.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target frame element on the web page where the switching action will be performed.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target frame element defined by the `OnElement` property.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#switch-to-frame](https://www.w3.org/TR/webdriver/#switch-to-frame)
