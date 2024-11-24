# Element Active (ElementActive)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementActive` plugin is designed to assert that a specified web element is currently active (focused) within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the active state of elements, which is crucial for scenarios where specific elements need to be interacted with or verified for user interactions.

### Key Features and Functionality

| Feature              | Description                                                                                |
|----------------------|--------------------------------------------------------------------------------------------|
| Active Element Check | Validates that the specified web element is currently active (focused) during execution.   |
| Seamless Integration | Integrates smoothly with automation workflows to ensure elements are in the desired state. |
| Reliable Validation  | Provides reliable assertion to confirm the active state of web elements.                   |

### Usages in RPA

| Usage                  | Description                                                                                            |
|------------------------|--------------------------------------------------------------------------------------------------------|
| Interaction Validation | Confirms that specific elements are active before performing interactions, ensuring smooth automation. |
| Process Continuity     | Validates that elements are in the correct state to proceed with the workflow without interruptions.   |

### Usages in Automation Testing

| Usage                | Description                                                                                         |
|----------------------|-----------------------------------------------------------------------------------------------------|
| Active State Testing | Ensures that specific elements are active during test scenarios, validating user interaction flows. |
| Workflow Validation  | Confirms that workflows proceed with the correct elements active, ensuring accurate test outcomes.  |

## Examples

### Example No.1

Assert that a specific web element is currently active (focused) during the execution of automated tasks. 
This is useful for validating scenarios where the active state of elements is expected before interaction.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementActive",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementActive")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementActive",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementActive",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementActive",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is active, validating the active state of the element during the execution of the automation script. 
The `Assert` plugin is utilized to check this condition, and if the element is active, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementActive}}",
    Locator = "CssSelector",
    OnElement = "#myElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementActive}}")
    .setLocator("CssSelector")
    .setOnElement("#myElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementActive}}",
    locator: "CssSelector",
    onElement: "#myElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "locator": "CssSelector",
    "onElement": "#myElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
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

Specifies the web element that is being validated for its active state. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the active state validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
