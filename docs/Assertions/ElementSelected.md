# Element Selected (ElementSelected)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementSelected` plugin is designed to assert that a specified web element is selected within an application or web browser during automated tasks. 
This plugin is essential for scenarios where ensuring an element is selected is necessary for the correct progression of automation workflows.

### Key Features and Functionality

| Feature              | Description                                                                             |
|----------------------|-----------------------------------------------------------------------------------------|
| Selection Validation | Validates that the specified web element is selected during execution.                  |
| Seamless Integration | Integrates smoothly with automation workflows to ensure elements are properly selected. |
| Reliable Assertion   | Provides a reliable mechanism to confirm the selection state of web elements.           |

### Usages in RPA

| Usage                    | Description                                                                                    |
|--------------------------|------------------------------------------------------------------------------------------------|
| Ensure Correct Selection | Confirms that specific elements are selected as required, enabling accurate workflow control.  |
| Process Flow Control     | Validates that elements are selected to ensure the correct progression of automated processes. |

### Usages in Automation Testing

| Usage                      | Description                                                                                    |
|----------------------------|------------------------------------------------------------------------------------------------|
| Selection State Validation | Ensures that specific elements are selected during test scenarios, validating user inputs.     |
| Workflow Verification      | Confirms that workflows proceed with the correct elements selected, ensuring accurate results. |

## Examples

### Example No.1

Assert that a specific web element is selected during the execution of automated tasks. 
This is useful for validating scenarios where an element's selection state is crucial for the workflow's success.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementSelected",
    Locator = "CssSelector",
    OnElement = "#selectedElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementSelected")
    .setLocator("CssSelector")
    .setOnElement("#selectedElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementSelected",
    locator: "CssSelector",
    onElement: "#selectedElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementSelected",
    "locator": "CssSelector",
    "onElement": "#selectedElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementSelected",
    "locator": "CssSelector",
    "onElement": "#selectedElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element is selected, validating that it remains selected during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element is selected, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementSelected}}",
    Locator = "CssSelector",
    OnElement = "#selectedElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementSelected}}")
    .setLocator("CssSelector")
    .setOnElement("#selectedElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementSelected}}",
    locator: "CssSelector",
    onElement: "#selectedElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "CssSelector",
    "onElement": "#selectedElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "CssSelector",
    "onElement": "#selectedElement"
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

Specifies the web element that is being validated for its selection state. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the selection validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#is-element-selected](https://www.w3.org/TR/webdriver/#is-element-selected)
