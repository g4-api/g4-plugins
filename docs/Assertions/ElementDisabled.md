# Element Disabled (ElementDisabled)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementDisabled` plugin is designed to assert that a specified web element is currently disabled within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the disabled state of elements, which is crucial for scenarios where specific elements should not be interactable.

### Key Features and Functionality

| Feature                | Description                                                                                |
|------------------------|--------------------------------------------------------------------------------------------|
| Disabled Element Check | Validates that the specified web element is currently disabled during execution.           |
| Seamless Integration   | Integrates smoothly with automation workflows to ensure elements are in the desired state. |
| Reliable Validation    | Provides reliable assertion to confirm the disabled state of web elements.                 |

### Usages in RPA

| Usage                  | Description                                                                                          |
|------------------------|------------------------------------------------------------------------------------------------------|
| Interaction Prevention | Confirms that specific elements are disabled, ensuring they are not interactable during automation.  |
| Process Continuity     | Validates that elements are in the correct state to proceed with the workflow without interruptions. |

### Usages in Automation Testing

| Usage                  | Description                                                                                           |
|------------------------|-------------------------------------------------------------------------------------------------------|
| Disabled State Testing | Ensures that specific elements are disabled during test scenarios, validating user interaction flows. |
| Workflow Validation    | Confirms that workflows proceed with the correct elements disabled, ensuring accurate test outcomes.  |

## Examples

### Example No.1

Assert that a specific web element is currently disabled during the execution of automated tasks. 
This is useful for validating scenarios where the disabled state of elements is expected to prevent interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementDisabled",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementDisabled")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementDisabled",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementDisabled",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementDisabled",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is disabled, validating the disabled state of the element during the execution of the automation script. 
The `Assert` plugin is utilized to check this condition, and if the element is disabled, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementDisabled}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementDisabled}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementDisabled}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

## Properties

### On Element (onElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the web element that is being validated for its disabled state. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the disabled state validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#is-element-enabled](https://www.w3.org/TR/webdriver/#is-element-enabled)
