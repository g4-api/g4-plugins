# Element Attribute (ElementAttribute)

[Table of Content](../Home.md)

~31 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementAttribute` plugin is designed to validate the attributes of web elements within automation scripts.
It provides a robust mechanism to assert that an element's attribute meets specific conditions, making it an essential tool for ensuring the correctness of element properties in various automation scenarios.

### Key Features and Functionality

| Feature                    | Description                                                                                                 |
| --- | --- |
| Attribute Validation       | Validates that an element's attribute matches expected conditions, supporting both numeric and text values. |
| Regular Expression Support | Applies regular expressions to attribute values before performing assertions, enabling complex validations. |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, pattern matching, and numeric comparisons.   |

### Usages in RPA

| Usage                      | Description                                                                                                                                 |
| --- | --- |
| Attribute Presence Check   | Verifies that a specific attribute exists on an element and meets the expected value, ensuring accurate data entry in forms.                |
| Dynamic Content Validation | Ensures that dynamically generated content or attributes on a page match expected criteria, preventing errors in automated workflows.       |
| Input Value Verification   | Validates attributes like `value` in text boxes and other input controllers, ensuring that user inputs or default values are correctly set. |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                                                       |
| --- | --- |
| Accessibility Testing        | Validates that accessibility attributes (like `aria-hidden`, `role`, etc.) are correctly set, ensuring compliance with accessibility standards.                   |
| UI Consistency Verification  | Ensures that visual and functional attributes of elements remain consistent across different environments and test runs.                                          |
| Version Control in Elements  | Verifies that version-related attributes (like `data-version`, `version`) meet the expected criteria, ensuring compatibility and correctness.                     |
| Performance Data Validation  | Checks attributes related to performance metrics, like `data-time`, `data-load`, ensuring they fall within acceptable ranges.                                     |
| Input Field Value Assertions | Validates that the `value` attribute of input fields (like text boxes, drop-downs) matches the expected values, crucial for form validation in testing workflows. |

## Examples

### Example No.1

Assert that the 'data-value' attribute of an element, after applying the regular expression '\d+', equals '123'.
This is useful for extracting numeric values from the attribute and ensuring they meet the expected condition.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementAttribute",
    Argument = "{{$ --Operator:Equal --Expected:123}}",
    OnAttribute = "data-value",
    OnElement = "//*[@id='numericElement']",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementAttribute")
    .setArgument("{{$ --Operator:Equal --Expected:123}}")
    .setOnAttribute("data-value")
    .setOnElement("//*[@id='numericElement']")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ElementAttribute",
    argument: "{{$ --Operator:Equal --Expected:123}}",
    onAttribute: "data-value",
    onElement: "//*[@id='numericElement']",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "ElementAttribute",
    "argument": "{{$ --Operator:Equal --Expected:123}}",
    "onAttribute": "data-value",
    "onElement": "//*[@id='numericElement']",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ElementAttribute",
    "argument": "{{$ --Operator:Equal --Expected:123}}",
    "onAttribute": "data-value",
    "onElement": "//*[@id='numericElement']",
    "regularExpression": "\d+"
}
```

### Example No.2

Ensure that the 'class' attribute of an element contains the text 'active'.
This assertion checks if the class attribute matches the exact expected value.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementAttribute",
    Argument = "{{$ --Operator:Equal --Expected:active}}",
    OnAttribute = "class",
    OnElement = "//*[@id='statusElement']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementAttribute")
    .setArgument("{{$ --Operator:Equal --Expected:active}}")
    .setOnAttribute("class")
    .setOnElement("//*[@id='statusElement']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ElementAttribute",
    argument: "{{$ --Operator:Equal --Expected:active}}",
    onAttribute: "class",
    onElement: "//*[@id='statusElement']"
};
```

**JSON:**

```js
{
    "pluginName": "ElementAttribute",
    "argument": "{{$ --Operator:Equal --Expected:active}}",
    "onAttribute": "class",
    "onElement": "//*[@id='statusElement']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ElementAttribute",
    "argument": "{{$ --Operator:Equal --Expected:active}}",
    "onAttribute": "class",
    "onElement": "//*[@id='statusElement']"
}
```

### Example No.3

Perform an assertion to ensure that the 'data-percentage' attribute of an element, after extracting the numeric part using the regular expression '\d+', is greater than '50'.
This is useful for scenarios where the script needs to validate that a percentage value extracted from the attribute exceeds a certain threshold.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:50}}",
    OnAttribute = "data-percentage",
    OnElement = "//*[@id='percentageElement']",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Greater --Expected:50}}")
    .setOnAttribute("data-percentage")
    .setOnElement("//*[@id='percentageElement']")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:50}}",
    onAttribute: "data-percentage",
    onElement: "//*[@id='percentageElement']",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:50}}",
    "onAttribute": "data-percentage",
    "onElement": "//*[@id='percentageElement']",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:50}}",
    "onAttribute": "data-percentage",
    "onElement": "//*[@id='percentageElement']",
    "regularExpression": "\d+"
}
```

### Example No.4

Assert that the 'data-price' attribute of an element, after extracting the numeric part using the regular expression '\d+\.\d{2}', is lower than '100.00'.
This validation ensures that the price extracted from the attribute is less than a specific value, confirming that the element meets pricing criteria.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:100.00}}",
    OnAttribute = "data-price",
    OnElement = "//*[@id='priceElement']",
    RegularExpression = "\d+\.\d{2}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Lower --Expected:100.00}}")
    .setOnAttribute("data-price")
    .setOnElement("//*[@id='priceElement']")
    .setRegularExpression("\d+\.\d{2}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:100.00}}",
    onAttribute: "data-price",
    onElement: "//*[@id='priceElement']",
    regularExpression: "\d+\.\d{2}"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:100.00}}",
    "onAttribute": "data-price",
    "onElement": "//*[@id='priceElement']",
    "regularExpression": "\d+\.\d{2}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:100.00}}",
    "onAttribute": "data-price",
    "onElement": "//*[@id='priceElement']",
    "regularExpression": "\d+\.\d{2}"
}
```

### Example No.5

Perform an assertion to ensure the 'version' attribute of an element, after extracting the major version number using the regular expression '\d+', is greater than or equal to '2'.
This is useful for validating that an element's version attribute is at least a certain version.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:2}}",
    OnAttribute = "version",
    OnElement = "//*[@id='versionElement']",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:2}}")
    .setOnAttribute("version")
    .setOnElement("//*[@id='versionElement']")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:2}}",
    onAttribute: "version",
    onElement: "//*[@id='versionElement']",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:2}}",
    "onAttribute": "version",
    "onElement": "//*[@id='versionElement']",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:2}}",
    "onAttribute": "version",
    "onElement": "//*[@id='versionElement']",
    "regularExpression": "\d+"
}
```

### Example No.6

Assert that the 'data-length' attribute of an element, after applying the regular expression '\d+', is less than or equal to '50'.
This ensures that the length value extracted from the attribute does not exceed a specific threshold, confirming correct element configuration.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:50}}",
    OnAttribute = "data-length",
    OnElement = "//*[@id='lengthElement']",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:50}}")
    .setOnAttribute("data-length")
    .setOnElement("//*[@id='lengthElement']")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:50}}",
    onAttribute: "data-length",
    onElement: "//*[@id='lengthElement']",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:50}}",
    "onAttribute": "data-length",
    "onElement": "//*[@id='lengthElement']",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:50}}",
    "onAttribute": "data-length",
    "onElement": "//*[@id='lengthElement']",
    "regularExpression": "\d+"
}
```

### Example No.7

Check that the 'data-type' attribute of an element does not match the regular expression '^[A-Za-z]+$', ensuring the value is not purely alphabetical.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[A-Za-z]+$}}",
    OnAttribute = "data-type",
    OnElement = "//*[@id='typeElement']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[A-Za-z]+$}}")
    .setOnAttribute("data-type")
    .setOnElement("//*[@id='typeElement']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[A-Za-z]+$}}",
    onAttribute: "data-type",
    onElement: "//*[@id='typeElement']"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[A-Za-z]+$}}",
    "onAttribute": "data-type",
    "onElement": "//*[@id='typeElement']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[A-Za-z]+$}}",
    "onAttribute": "data-type",
    "onElement": "//*[@id='typeElement']"
}
```

### Example No.8

Assert that the 'aria-hidden' attribute of an element is set to 'true'.
This validation is essential for ensuring the accessibility state of an element is correctly configured.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:true}}",
    OnAttribute = "aria-hidden",
    OnElement = "//*[@id='hiddenElement']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Equal --Expected:true}}")
    .setOnAttribute("aria-hidden")
    .setOnElement("//*[@id='hiddenElement']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:true}}",
    onAttribute: "aria-hidden",
    onElement: "//*[@id='hiddenElement']"
};
```

**JSON:**

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:true}}",
    "onAttribute": "aria-hidden",
    "onElement": "//*[@id='hiddenElement']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:true}}",
    "onAttribute": "aria-hidden",
    "onElement": "//*[@id='hiddenElement']"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the condition under which the assertion will pass or fail.
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected value for the attribute.

### On Attribute (OnAttribute)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the web element's attribute to be validated. This attribute will be checked against the expected value.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the web element to be validated. This can be defined using a locator strategy, such as Xpath, CSS Selector, etc.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the locator strategy used to identify the target element on the web page. The default value is 'Xpath'.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the attribute value before performing the assertion.
This allows for more flexible validation of attribute values that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the element's attribute value.

### Expected (Expected)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value or pattern that the element's attribute is expected to match during the assertion.

## Scope

* Mobile Web
* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-element-attribute](https://www.w3.org/TR/webdriver/#get-element-attribute)
