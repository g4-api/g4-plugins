# Element Text Length (ElementTextLength)

[Table of Content](../Home.md)  

~24 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementTextLength` plugin is designed to validate the length of the text content of web elements within automation scripts. 
It provides a robust mechanism to assert that the length of an element's text meets specific conditions, making it essential for scenarios where text length is critical to the workflow.

### Key Features and Functionality

| Feature                    | Description                                                                                                              |
|----------------------------|--------------------------------------------------------------------------------------------------------------------------|
| Text Length Validation     | Validates that the length of the text content of an element matches expected conditions, supporting numeric comparisons. |
| Regular Expression Support | Applies regular expressions to the text content before calculating its length, enabling complex validations.             |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, and numeric comparisons.                                  |

### Usages in RPA

| Usage                       | Description                                                                                                                                      |
|-----------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| Content Length Verification | Ensures that the length of the text content of specific elements meets the expected value, crucial for verifying dynamic content or form inputs. |
| Form Validation             | Validates that the length of text fields is within acceptable limits before submission, ensuring accuracy in automated form submissions.         |

### Usages in Automation Testing

| Usage                       | Description                                                                                                                                  |
|-----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification | Ensures that the length of text content in UI elements remains consistent across different environments and test runs.                       |
| Localization Testing        | Validates that the length of text content in elements matches the expected length for localized text in various languages.                   |
| Error Message Length Check  | Checks that error messages or notifications displayed to the user have the correct length, ensuring they are neither too short nor too long. |

## Examples

### Example No.1

Assert that the length of the text content of an element, after applying the regular expression '\d+', equals '3'. 
This is useful for scenarios where the script needs to extract numeric values from the element's text and validate their length against expected criteria.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementTextLength",
    Argument = "{{$ --Operator:Equal --Expected:3}}",
    OnElement = "//*[@id='numericTextElement']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementTextLength")
    .setArgument("{{$ --Operator:Equal --Expected:3}}")
    .setOnElement("//*[@id='numericTextElement']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementTextLength",
    argument: "{{$ --Operator:Equal --Expected:3}}",
    onElement: "//*[@id='numericTextElement']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementTextLength",
    "argument": "{{$ --Operator:Equal --Expected:3}}",
    "onElement": "//*[@id='numericTextElement']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementTextLength",
    "argument": "{{$ --Operator:Equal --Expected:3}}",
    "onElement": "//*[@id='numericTextElement']",
    "regularExpression": "\d+"
}
```
### Example No.2

Ensure that the length of the text content of an element matches the exact value '11'. 
This assertion checks if the length of the text content of the specified element is exactly as expected.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementTextLength",
    Argument = "{{$ --Operator:Equal --Expected:11}}",
    OnElement = "//*[@id='textLengthElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementTextLength")
    .setArgument("{{$ --Operator:Equal --Expected:11}}")
    .setOnElement("//*[@id='textLengthElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementTextLength",
    argument: "{{$ --Operator:Equal --Expected:11}}",
    onElement: "//*[@id='textLengthElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementTextLength",
    "argument": "{{$ --Operator:Equal --Expected:11}}",
    "onElement": "//*[@id='textLengthElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementTextLength",
    "argument": "{{$ --Operator:Equal --Expected:11}}",
    "onElement": "//*[@id='textLengthElement']"
}
```
### Example No.3

Perform an assertion to ensure that the length of the text content of an element using the CSS selector `.price`, after extracting the numeric part using the regular expression '\d+', is greater than '2'. 
This is useful for scenarios where the script needs to validate that a numeric value extracted from the text content has a length greater than a certain threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".price",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".price")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:2}}",
    locator: "CssSelector",
    onElement: ".price",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".price",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".price",
    "regularExpression": "\d+"
}
```
### Example No.4

Assert that the length of the text content of an element is less than or equal to '50'. 
This validation ensures that the text content length does not exceed a specific upper limit.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:50}}",
    OnElement = "//*[@id='lengthTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:50}}")
    .setOnElement("//*[@id='lengthTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:50}}",
    onElement: "//*[@id='lengthTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:50}}",
    "onElement": "//*[@id='lengthTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:50}}",
    "onElement": "//*[@id='lengthTextElement']"
}
```
### Example No.5

Check that the length of the text content of an element matches the regular expression '\d{2}', ensuring it is exactly two digits long.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:\d{2}}}",
    OnElement = "//*[@id='twoDigitTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:\d{2}}}")
    .setOnElement("//*[@id='twoDigitTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:\d{2}}}",
    onElement: "//*[@id='twoDigitTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:\d{2}}}",
    "onElement": "//*[@id='twoDigitTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:\d{2}}}",
    "onElement": "//*[@id='twoDigitTextElement']"
}
```
### Example No.6

Assert that the length of the text content of an element is greater than or equal to '5'. 
This validation ensures that the text content length meets or exceeds a specific minimum threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:5}}",
    OnElement = "//*[@id='minLengthTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:5}}")
    .setOnElement("//*[@id='minLengthTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:5}}",
    onElement: "//*[@id='minLengthTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:5}}",
    "onElement": "//*[@id='minLengthTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:5}}",
    "onElement": "//*[@id='minLengthTextElement']"
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
| **Value Type**    | String|Expression |

Specifies the condition under which the assertion will pass or fail. 
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected length for the text content.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the web element whose text content length will be validated. This can be defined using a locator strategy, such as Xpath, CSS Selector, etc.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target element on the web page. The default value is 'Xpath'.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the text content before calculating its length. 
This allows for more flexible validation of text lengths that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the length of the element's text content.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected length value that the element's text content should meet during the assertion.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-element-text](https://www.w3.org/TR/webdriver/#get-element-text)
