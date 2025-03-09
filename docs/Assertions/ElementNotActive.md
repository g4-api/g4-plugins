# Element Not Active (ElementNotActive)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementNotActive` plugin is designed to assert that a specified web element is not active within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the inactive state of elements, which is crucial for scenarios where specific elements must be inactive to proceed.

### Key Features and Functionality

| Feature                  | Description                                                                    |
|--------------------------|--------------------------------------------------------------------------------|
| Element Inactivity Check | Validates that the specified web element is not active during execution.       |
| Seamless Integration     | Integrates smoothly with automation workflows to ensure elements are inactive. |
| Reliable Validation      | Provides reliable assertion to confirm the inactivity of web elements.         |

### Usages in RPA

| Usage                    | Description                                                                                     |
|--------------------------|-------------------------------------------------------------------------------------------------|
| Inactivity Verification  | Confirms that specific elements are inactive, ensuring they are not available for interactions. |
| Process Continuity       | Validates that elements are inactive to proceed with the workflow without interruptions.        |

### Usages in Automation Testing

| Usage                    | Description                                                                                                |
|--------------------------|------------------------------------------------------------------------------------------------------------|
| Inactivity State Testing | Ensures that specific elements are inactive during test scenarios, validating user interaction flows.      |
| Workflow Validation      | Confirms that workflows proceed with the correct elements being inactive, ensuring accurate test outcomes. |

## Examples

### Example No.1

Assert that a specific web element is not active during the execution of automated tasks. 
This is useful for validating scenarios where the inactivity of elements is expected to prevent interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementNotActive",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementNotActive")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementNotActive",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementNotActive",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementNotActive",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is not active, validating the inactivity of the element during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element is not active, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotActive}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotActive}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotActive}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
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

Specifies the web element that is being validated for its inactive state. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the inactivity validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
