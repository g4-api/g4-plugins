# Element Stale (ElementStale)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementStale` plugin is designed to assert that a specified web element has become stale in the context of a web page during automated tasks. 
This plugin is essential for scenarios where verifying that an element is no longer attached to the DOM is necessary to ensure accurate automation flows.

### Key Features and Functionality

| Feature              | Description                                                                              |
|----------------------|------------------------------------------------------------------------------------------|
| Staleness Validation | Validates that the specified web element is no longer attached to the DOM.               |
| Workflow Assurance   | Ensures that workflows correctly handle elements that are no longer present on the page. |
| Reliable Assertion   | Provides a reliable mechanism to confirm the staleness of web elements.                  |

### Usages in RPA

| Usage                  | Description                                                                                          |
|------------------------|------------------------------------------------------------------------------------------------------|
| Ensure Element Removal | Confirms that specific elements have been removed from the DOM, enabling accurate workflow control.  |
| Process Flow Control   | Validates that elements are stale to ensure correct handling of dynamic content in automation flows. |

### Usages in Automation Testing

| Usage                 | Description                                                                                               |
|-----------------------|-----------------------------------------------------------------------------------------------------------|
| Staleness Validation  | Ensures that elements become stale as expected during test scenarios, validating dynamic content updates. |
| Workflow Verification | Confirms that workflows proceed with the correct handling of stale elements, ensuring accurate results.   |

## Examples

### Example No.1

Assert that a specific web element has become stale during the execution of automated tasks. 
This is useful for validating scenarios where the element's removal from the DOM is crucial for the workflow's success.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementStale",
    Locator = "CssSelector",
    OnElement = "#staleElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementStale")
    .setLocator("CssSelector")
    .setOnElement("#staleElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementStale",
    locator: "CssSelector",
    onElement: "#staleElement"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementStale",
    "locator": "CssSelector",
    "onElement": "#staleElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementStale",
    "locator": "CssSelector",
    "onElement": "#staleElement"
}
```
### Example No.2

Perform an assertion to ensure a specific web element has become stale, validating that it is no longer attached to the DOM during the execution of the automation script. 
The `Assert` plugin is used to check this condition, and if the element is stale, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementStale}}",
    Locator = "CssSelector",
    OnElement = "#staleElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementStale}}")
    .setLocator("CssSelector")
    .setOnElement("#staleElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementStale}}",
    locator: "CssSelector",
    onElement: "#staleElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "CssSelector",
    "onElement": "#staleElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "CssSelector",
    "onElement": "#staleElement"
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

Specifies the web element that is being validated for its staleness. 
This can be a CSS selector, XPath, or other locator strategy to identify the element.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the element for the staleness validation. 
Common strategies include CSS selectors, XPath, ID, and others.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-element](https://www.w3.org/TR/webdriver/#find-element)
