# Element Enabled (ElementEnabled)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementEnabled` plugin is designed to assert that a specified web element is currently enabled within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the enabled state of elements, which is crucial for scenarios where specific elements should be interactable.

### Key Features and Functionality

| Feature               | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Enabled Element Check | Validates that the specified web element is currently enabled during execution.            |
| Seamless Integration  | Integrates smoothly with automation workflows to ensure elements are in the desired state. |
| Reliable Validation   | Provides reliable assertion to confirm the enabled state of web elements.                  |

### Usages in RPA

| Usage                 | Description                                                                                          |
|-----------------------|------------------------------------------------------------------------------------------------------|
| Interaction Readiness | Confirms that specific elements are enabled, ensuring they are interactable during automation.       |
| Process Continuity    | Validates that elements are in the correct state to proceed with the workflow without interruptions. |

### Usages in Automation Testing

| Usage                 | Description                                                                                          |
|-----------------------|------------------------------------------------------------------------------------------------------|
| Enabled State Testing | Ensures that specific elements are enabled during test scenarios, validating user interaction flows. |
| Workflow Validation   | Confirms that workflows proceed with the correct elements enabled, ensuring accurate test outcomes.  |

## Examples

### Example No.1

Assert that a specific web element is currently enabled during the execution of automated tasks. 
This is useful for validating scenarios where the enabled state of elements is expected to allow interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementEnabled",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementEnabled")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementEnabled",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementEnabled",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementEnabled",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is enabled, validating the enabled state of the element during the execution of the automation script. 
The `Assert` plugin is utilized to check this condition, and if the element is enabled, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementEnabled}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementEnabled}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementEnabled}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
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
| **Value Type**    | String|Expression |

Specifies the web element that is being validated for its enabled state. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the enabled state validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#is-element-enabled](https://www.w3.org/TR/webdriver/#is-element-enabled)
