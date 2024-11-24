# Element Not Visible (ElementNotVisible)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementNotVisible` plugin is designed to assert that a specified web element is not visible within a web browser during automated tasks. 
This plugin is essential for scenarios where ensuring an element is not visible is necessary before proceeding with automation workflows.

### Key Features and Functionality

| Feature               | Description                                                                     |
|-----------------------|---------------------------------------------------------------------------------|
| Visibility Validation | Validates that the specified web element is not visible during execution.       |
| Seamless Integration  | Integrates smoothly with automation workflows to ensure elements remain hidden. |
| Reliable Assertion    | Provides a reliable mechanism to confirm the non-visibility of web elements.    |

### Usages in RPA

| Usage                | Description                                                                                     |
|----------------------|-------------------------------------------------------------------------------------------------|
| Ensure Hidden State  | Confirms that specific elements are not visible, preventing unintended actions in workflows.    |
| Process Flow Control | Validates that elements remain hidden to ensure the correct progression of automated processes. |

### Usages in Automation Testing

| Usage                     | Description                                                                                         |
|---------------------------|-----------------------------------------------------------------------------------------------------|
| Non-Visibility Validation | Ensures that specific elements are not visible during test scenarios, validating user interactions. |
| Workflow Verification     | Confirms that workflows proceed with the correct elements hidden, ensuring accurate test outcomes.  |

## Examples

### Example No.1

Assert that a specific web element is not visible during the execution of automated tasks. 
This is useful for validating scenarios where an element should remain hidden to prevent unwanted interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementNotVisible",
    Locator = "CssSelector",
    OnElement = "#hiddenElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementNotVisible")
    .setLocator("CssSelector")
    .setOnElement("#hiddenElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementNotVisible",
    locator: "CssSelector",
    onElement: "#hiddenElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementNotVisible",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementNotVisible",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is not visible, validating that it remains hidden during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element is not visible, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotVisible}}",
    Locator = "CssSelector",
    OnElement = "#hiddenElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotVisible}}")
    .setLocator("CssSelector")
    .setOnElement("#hiddenElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotVisible}}",
    locator: "CssSelector",
    onElement: "#hiddenElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
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

Specifies the web element that is being validated for its non-visibility. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the non-visibility validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
