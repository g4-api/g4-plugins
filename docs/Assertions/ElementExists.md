# Element Exists (ElementExists)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementExists` plugin is designed to assert that a specified web element exists within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the presence of elements, which is crucial for scenarios where specific elements must be present to proceed.

### Key Features and Functionality

| Feature                 | Description                                                                   |
|-------------------------|-------------------------------------------------------------------------------|
| Element Existence Check | Validates that the specified web element exists during execution.             |
| Seamless Integration    | Integrates smoothly with automation workflows to ensure elements are present. |
| Reliable Validation     | Provides reliable assertion to confirm the existence of web elements.         |

### Usages in RPA

| Usage                 | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Presence Verification | Confirms that specific elements are present, ensuring they are available for interactions. |
| Process Continuity    | Validates that elements are present to proceed with the workflow without interruptions.    |

### Usages in Automation Testing

| Usage                   | Description                                                                                         |
|-------------------------|-----------------------------------------------------------------------------------------------------|
| Existence State Testing | Ensures that specific elements exist during test scenarios, validating user interaction flows.      |
| Workflow Validation     | Confirms that workflows proceed with the correct elements present, ensuring accurate test outcomes. |

## Examples

### Example No.1

Assert that a specific web element exists during the execution of automated tasks. 
This is useful for validating scenarios where the presence of elements is expected to allow interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementExists",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementExists")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementExists",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementExists",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementExists",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element exists, validating the presence of the element during the execution of the automation script. 
The `Assert` plugin is utilized to check this condition, and if the element exists, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementExists}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementExists}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementExists}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
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

Specifies the web element that is being validated for its existence. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the existence validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
