# Select Option (SelectOption)

[Table of Content](../Home.md)  

~19 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Selects an option from a native HTML `<select>` dropdown element.
The target element is validated as a `<select>` before any selection attempt, and the desired option is located using one of four strategies controlled by the `OnAttribute` property.
Use this action whenever an automation workflow must interact with dropdown menus rendered as standard HTML select elements.

### Key Features and Functionality

| Feature               | Description                                                                                                                                      |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| Element Validation    | Throws `InvalidOperationException` if the target is not a `<select>` element, preventing silent failures on wrong element types.                 |
| Index Selection       | Selects the option at the specified zero-based position. Out-of-range and parse errors are caught and recorded as exceptions without rethrowing. |
| Value Selection       | Selects the option whose `value` attribute matches `Argument` exactly using XPath `./option[@value='…']`.                                        |
| PartialText Selection | Selects the first option whose visible text contains `Argument` as a substring using XPath `./option[contains(.,'…')]`.                          |
| Exact Text Selection  | Default mode. Selects the first option whose full visible text equals `Argument` using XPath `./option[.='…']`.                                  |

### Usages in RPA

| Use Case        | Description                                                                                                    |
|-----------------|----------------------------------------------------------------------------------------------------------------|
| Form Completion | Select a country, state, or category from a dropdown as part of a multi-field form submission workflow.        |
| Data Entry      | Automate selection of predefined options in data-entry screens where dropdown values are process-controlled.   |
| User Simulation | Reproduce exact user interactions with dropdown menus to drive downstream page updates or validation triggers. |

### Usages in Automation Testing

| Use Case              | Description                                                                                                              |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------|
| Dropdown Behavior     | Verify that selecting each option triggers the correct page update, form state, or API call.                             |
| Boundary Testing      | Test index-boundary conditions — first option, last option, and out-of-range index — to confirm error handling behavior. |
| Data-Driven Selection | Drive option selection from a test data set using value attributes to ensure each option is reachable by value.          |

## Examples

### Example No.1

### Select an option by index

Selects the option at zero-based index `1` (the second option) from the dropdown identified by the CSS selector `#SelectElement`.
The `onAttribute` is set to `Index`, so the `argument` is parsed as an integer and used to click the option at that position.
If the argument is not a valid integer or the index is out of range, the exception is caught and recorded without interrupting the workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "1",
    Locator = "CssSelector",
    OnAttribute = "Index",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("1")
    .setLocator("CssSelector")
    .setOnAttribute("Index")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "1",
    locator: "CssSelector",
    onAttribute: "Index",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "1",
    "locator": "CssSelector",
    "onAttribute": "Index",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "1",
    "locator": "CssSelector",
    "onAttribute": "Index",
    "onElement": "#SelectElement"
}
```
### Example No.2

### Select an option by value attribute

Selects the option whose `value` attribute equals `option2` from the dropdown identified by element id `SelectElement`.
The `onAttribute` is set to `Value`, so the action matches against each option's `value` attribute using XPath `./option[@value='option2']`.
Use this mode when the value attribute is stable and predictable, regardless of the option's visible text.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "option2",
    Locator = "Id",
    OnAttribute = "Value",
    OnElement = "SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("option2")
    .setLocator("Id")
    .setOnAttribute("Value")
    .setOnElement("SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "option2",
    locator: "Id",
    onAttribute: "Value",
    onElement: "SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "option2",
    "locator": "Id",
    "onAttribute": "Value",
    "onElement": "SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "option2",
    "locator": "Id",
    "onAttribute": "Value",
    "onElement": "SelectElement"
}
```
### Example No.3

### Select an option by partial text

Selects the first option whose visible text contains the substring `Option 2` from the dropdown located by XPath.
The `onAttribute` is set to `PartialText`, so the action uses XPath `./option[contains(.,'Option 2')]` scoped to the `<select>` element.
Use this mode when only a portion of the option text is known or when option labels are generated dynamically.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "Option 2",
    OnAttribute = "PartialText",
    OnElement = "//select[@id='SelectElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("Option 2")
    .setOnAttribute("PartialText")
    .setOnElement("//select[@id='SelectElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "Option 2",
    onAttribute: "PartialText",
    onElement: "//select[@id='SelectElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "onAttribute": "PartialText",
    "onElement": "//select[@id='SelectElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "onAttribute": "PartialText",
    "onElement": "//select[@id='SelectElement']"
}
```
### Example No.4

### Select an option by exact text (default mode)

Selects the option whose full visible text equals `Option 2` from the dropdown matching the CSS selector `#SelectElement`.
No `onAttribute` is specified, so the action uses the default exact text mode with XPath `./option[.='Option 2']`.
Use this mode when the complete option text is known in advance and must match precisely.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "Option 2",
    Locator = "CssSelector",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("Option 2")
    .setLocator("CssSelector")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "Option 2",
    locator: "CssSelector",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "locator": "CssSelector",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "locator": "CssSelector",
    "onElement": "#SelectElement"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Argument specifies the value used to select an option from the dropdown.
Its meaning depends on the OnAttribute property: an integer for Index mode, a value attribute string for Value mode, a substring for PartialText mode, or a full visible text string for the default exact text mode.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target `<select>` element.
Accepted values are Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnAttribute determines which selection strategy is applied when locating the target option.
When absent or set to any value other than Index, Value, or PartialText, the default exact text match strategy is used.

#### Values

##### Index

Parses `Argument` as a zero-based integer index and clicks the option at that position.
Out-of-range or non-integer values are caught and recorded as plugin exceptions without rethrowing.
##### Value

Selects the first option whose `value` HTML attribute equals `Argument` exactly.
Uses XPath `./option[@value='…']` scoped to the `<select>` element. Matching is case-sensitive.
##### Partial Text

Selects the first option whose visible text contains `Argument` as a substring.
Uses XPath `./option[contains(.,'…')]` scoped to the `<select>` element. Matching is case-sensitive.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the `<select>` element.
The element must be a `<select>` tag — any other tag type causes an `InvalidOperationException` before any selection logic runs.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-click](https://www.w3.org/TR/webdriver/#element-click)
