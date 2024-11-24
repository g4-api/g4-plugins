# Element Not Exists (ElementNotExists)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementNotExists` plugin is designed to assert that a specified web element does not exist within an application or web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the non-existence of elements, which is crucial for scenarios where the absence of specific elements must be confirmed before proceeding.

### Key Features and Functionality

| Feature                     | Description                                                                  |
|-----------------------------|------------------------------------------------------------------------------|
| Element Non-Existence Check | Validates that the specified web element does not exist during execution.    |
| Seamless Integration        | Integrates smoothly with automation workflows to ensure elements are absent. |
| Reliable Validation         | Provides reliable assertion to confirm the non-existence of web elements.    |

### Usages in RPA

| Usage                | Description                                                                                   |
|----------------------|-----------------------------------------------------------------------------------------------|
| Absence Verification | Confirms that specific elements are absent, ensuring they do not interfere with the workflow. |
| Process Continuity   | Validates that elements do not exist to proceed with the workflow without interruptions.      |

### Usages in Automation Testing

| Usage                       | Description                                                                                              |
|-----------------------------|----------------------------------------------------------------------------------------------------------|
| Non-Existence State Testing | Ensures that specific elements do not exist during test scenarios, validating user interaction flows.    |
| Workflow Validation         | Confirms that workflows proceed with the correct elements being absent, ensuring accurate test outcomes. |

## Examples

### Example No.1

Assert that a specific web element does not exist during the execution of automated tasks. 
This is useful for validating scenarios where the absence of elements is expected to prevent interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementNotExists",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementNotExists")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementNotExists",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementNotExists",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementNotExists",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element does not exist, validating the absence of the element during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element does not exist, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotExists}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotExists}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotExists}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
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

Specifies the web element that is being validated for its non-existence. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the non-existence validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
