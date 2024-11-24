# Element Not Selected (ElementNotSelected)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementNotSelected` plugin is designed to assert that a specified web element is not selected within an application or web browser during automated tasks. 
This plugin is crucial for scenarios where ensuring an element is not selected is necessary before proceeding with automation workflows.

### Key Features and Functionality

| Feature                  | Description                                                                         |
|--------------------------|-------------------------------------------------------------------------------------|
| Non-Selection Validation | Validates that the specified web element is not selected during execution.          |
| Seamless Integration     | Integrates smoothly with automation workflows to ensure elements remain unselected. |
| Reliable Assertion       | Provides a reliable mechanism to confirm the non-selection of web elements.         |

### Usages in RPA

| Usage                   | Description                                                                                         |
|-------------------------|-----------------------------------------------------------------------------------------------------|
| Ensure Unselected State | Confirms that specific elements are not selected, preventing unintended actions in workflows.       |
| Process Flow Control    | Validates that elements remain unselected to ensure the correct progression of automated processes. |

### Usages in Automation Testing

| Usage                         | Description                                                                                            |
|-------------------------------|--------------------------------------------------------------------------------------------------------|
| Non-Selected State Validation | Ensures that specific elements are not selected during test scenarios, validating user interactions.   |
| Workflow Verification         | Confirms that workflows proceed with the correct elements unselected, ensuring accurate test outcomes. |

## Examples

### Example No.1

Assert that a specific web element is not selected during the execution of automated tasks. 
This is useful for validating scenarios where an element should remain unselected to prevent unwanted interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementNotSelected",
    Locator = "CssSelector",
    OnElement = "#checkboxElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementNotSelected")
    .setLocator("CssSelector")
    .setOnElement("#checkboxElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementNotSelected",
    locator: "CssSelector",
    onElement: "#checkboxElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementNotSelected",
    "locator": "CssSelector",
    "onElement": "#checkboxElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementNotSelected",
    "locator": "CssSelector",
    "onElement": "#checkboxElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is not selected, validating that it remains unselected during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element is not selected, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotSelected}}",
    Locator = "CssSelector",
    OnElement = "#checkboxElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotSelected}}")
    .setLocator("CssSelector")
    .setOnElement("#checkboxElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotSelected}}",
    locator: "CssSelector",
    onElement: "#checkboxElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "CssSelector",
    "onElement": "#checkboxElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "CssSelector",
    "onElement": "#checkboxElement"
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

Specifies the web element that is being validated for its non-selection. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the non-selection validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#is-element-selected](https://www.w3.org/TR/webdriver/#is-element-selected)
