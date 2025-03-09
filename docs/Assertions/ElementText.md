# Element Text (ElementText)

[Table of Content](../Home.md)  

~33 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementText` plugin is designed to validate the text content of web elements within automation scripts. 
It provides a robust mechanism to assert that the text of an element meets specific conditions, making it essential for scenarios where accurate text content is critical to the workflow.

### Key Features and Functionality

| Feature                    | Description                                                                                                                    |
|----------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Text Validation            | Validates that the text content of an element matches expected conditions, supporting both exact matches and pattern matching. |
| Regular Expression Support | Applies regular expressions to the text content before performing assertions, enabling complex validations.                    |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, and pattern matching.                                           |

### Usages in RPA

| Usage                | Description                                                                                                                       |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| Content Verification | Ensures that the text content of specific elements matches the expected value, crucial for verifying dynamic content or messages. |
| Form Validation      | Validates that text fields contain the correct information before submission, ensuring accuracy in automated form submissions.    |

### Usages in Automation Testing

| Usage                       | Description                                                                                                    |
|-----------------------------|----------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification | Ensures that the text content of UI elements remains consistent across different environments and test runs.   |
| Localization Testing        | Validates that the text content of elements matches the expected localized text in various languages.          |
| Error Message Validation    | Checks that error messages or notifications displayed to the user are accurate and meet the expected criteria. |

## Examples

### Example No.1

Assert that the text content of an element, after applying the regular expression '\d+', equals '123'. 
This is useful for scenarios where the script needs to extract numeric values from the element's text and validate them against expected criteria.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:123}}",
    OnElement = "//*[@id='numericTextElement']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:123}}")
    .setOnElement("//*[@id='numericTextElement']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:123}}",
    onElement: "//*[@id='numericTextElement']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:123}}",
    "onElement": "//*[@id='numericTextElement']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:123}}",
    "onElement": "//*[@id='numericTextElement']",
    "regularExpression": "\d+"
}
```
### Example No.2

Ensure that the text content of an element matches the exact value 'Hello World'. 
This assertion checks if the text content of the specified element is exactly as expected.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    OnElement = "//*[@id='textElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}")
    .setOnElement("//*[@id='textElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    onElement: "//*[@id='textElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    "onElement": "//*[@id='textElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    "onElement": "//*[@id='textElement']"
}
```
### Example No.3

Perform an assertion to ensure that the text content of an element using the CSS selector `.price`, after extracting the numeric part using the regular expression '\d+', is greater than '100'. 
This is useful for scenarios where the script needs to validate that a numeric value extracted from the text content exceeds a certain threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:100}}",
    Locator = "CssSelector",
    OnElement = ".price",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement(".price")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:100}}",
    locator: "CssSelector",
    onElement: ".price",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onElement": ".price",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onElement": ".price",
    "regularExpression": "\d+"
}
```
### Example No.4

Assert that the text content of an element is not equal to 'Error'. 
This validation ensures that the element does not contain an error message, confirming the expected state of the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Error}}",
    OnElement = "//*[@id='statusTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Error}}")
    .setOnElement("//*[@id='statusTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Error}}",
    onElement: "//*[@id='statusTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Error}}",
    "onElement": "//*[@id='statusTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Error}}",
    "onElement": "//*[@id='statusTextElement']"
}
```
### Example No.5

Perform an assertion to ensure that the text content of an element matches the regular expression '^[A-Za-z]+$', validating that it contains only alphabetic characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^[A-Za-z]+$}}",
    OnElement = "//*[@id='alphabeticTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^[A-Za-z]+$}}")
    .setOnElement("//*[@id='alphabeticTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^[A-Za-z]+$}}",
    onElement: "//*[@id='alphabeticTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^[A-Za-z]+$}}",
    "onElement": "//*[@id='alphabeticTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^[A-Za-z]+$}}",
    "onElement": "//*[@id='alphabeticTextElement']"
}
```
### Example No.6

Assert that the text content of an element is lower than '500'. 
This validation ensures that the numeric value represented by the text content does not exceed a certain limit.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:500}}",
    OnElement = "//*[@id='valueTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:500}}")
    .setOnElement("//*[@id='valueTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:500}}",
    onElement: "//*[@id='valueTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:500}}",
    "onElement": "//*[@id='valueTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:500}}",
    "onElement": "//*[@id='valueTextElement']"
}
```
### Example No.7

Check that the text content of an element matches the regular expression '\d+\.\d{2}', ensuring it is a correctly formatted decimal number.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:\d+\.\d{2}}}",
    OnElement = "//*[@id='decimalTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:\d+\.\d{2}}}")
    .setOnElement("//*[@id='decimalTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:\d+\.\d{2}}}",
    onElement: "//*[@id='decimalTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:\d+\.\d{2}}}",
    "onElement": "//*[@id='decimalTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:\d+\.\d{2}}}",
    "onElement": "//*[@id='decimalTextElement']"
}
```
### Example No.8

Assert that the text content of an element is greater than or equal to '10'. 
This validation ensures that the numeric value represented by the text content meets or exceeds a specific threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:10}}",
    OnElement = "//*[@id='thresholdTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:10}}")
    .setOnElement("//*[@id='thresholdTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:10}}",
    onElement: "//*[@id='thresholdTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:10}}",
    "onElement": "//*[@id='thresholdTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:10}}",
    "onElement": "//*[@id='thresholdTextElement']"
}
```
### Example No.9

Ensure that the text content of an element is less than or equal to '50'. 
This is useful for scenarios where the script needs to confirm that the text value does not exceed a certain upper limit.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:50}}",
    OnElement = "//*[@id='limitTextElement']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:50}}")
    .setOnElement("//*[@id='limitTextElement']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:50}}",
    onElement: "//*[@id='limitTextElement']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:50}}",
    "onElement": "//*[@id='limitTextElement']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:50}}",
    "onElement": "//*[@id='limitTextElement']"
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
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected value for the text content.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the web element whose text content will be validated. This can be defined using a locator strategy, such as Xpath, CSS Selector, etc.

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

Specifies a regular expression to be applied to the text content before performing the assertion. 
This allows for more flexible validation of the text values that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the element's text content.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected value or pattern that the element's text content should match during the assertion.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-element-text](https://www.w3.org/TR/webdriver/#get-element-text)
