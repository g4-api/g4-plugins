# Element Count (ElementCount)

[Table of Content](../Home.md)  

~30 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ElementCount` plugin is designed to validate the number of elements matching a specified locator within automation scripts. 
It provides a robust mechanism to assert that the number of elements meets specific conditions, making it essential for scenarios where the presence of multiple elements needs to be verified.

### Key Features and Functionality

| Feature                    | Description                                                                                                |
|----------------------------|------------------------------------------------------------------------------------------------------------|
| Count Validation           | Validates that the number of elements matching the locator meets the expected condition.                   |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, and numeric comparisons.                    |
| Regular Expression Support | Applies regular expressions to the count value before performing assertions, enabling complex validations. |

### Usages in RPA

| Usage                        | Description                                                                                                                      |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| Presence Validation          | Ensures that a specified number of elements exist, crucial for verifying the presence of items like list entries or form fields. |
| Dynamic Content Verification | Validates that dynamically generated elements match the expected count, preventing errors in automated workflows.                |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification  | Ensures that the expected number of UI elements are present across different environments and test runs.                               |
| Regression Testing           | Validates that changes to the application do not affect the expected count of elements, ensuring consistency in user interfaces.       |
| Performance Data Validation  | Checks that the number of elements loaded on the page matches the expected performance metrics, ensuring optimal application behavior. |

## Examples

### Example No.1

Assert that the count of elements matching the locator `//*[@class='item']` equals `5`. 
This is useful for scenarios where the script needs to ensure that exactly 5 elements with the class `item` are present on the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementCount",
    Argument = "{{$ --Operator:Equal --Expected:5}}",
    OnElement = "//*[@class='item']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementCount")
    .setArgument("{{$ --Operator:Equal --Expected:5}}")
    .setOnElement("//*[@class='item']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementCount",
    argument: "{{$ --Operator:Equal --Expected:5}}",
    onElement: "//*[@class='item']"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementCount",
    "argument": "{{$ --Operator:Equal --Expected:5}}",
    "onElement": "//*[@class='item']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementCount",
    "argument": "{{$ --Operator:Equal --Expected:5}}",
    "onElement": "//*[@class='item']"
}
```
### Example No.2

Ensure that the count of elements matching the locator `//*[@class='active-item']` is greater than `10`. 
This assertion checks if the number of active items on the page exceeds 10, confirming the correct dynamic loading of content.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ElementCount",
    Argument = "{{$ --Operator:Greater --Expected:10}}",
    OnElement = "//*[@class='active-item']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ElementCount")
    .setArgument("{{$ --Operator:Greater --Expected:10}}")
    .setOnElement("//*[@class='active-item']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ElementCount",
    argument: "{{$ --Operator:Greater --Expected:10}}",
    onElement: "//*[@class='active-item']"
};
```

_**JSON**_

```js
{
    "pluginName": "ElementCount",
    "argument": "{{$ --Operator:Greater --Expected:10}}",
    "onElement": "//*[@class='active-item']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ElementCount",
    "argument": "{{$ --Operator:Greater --Expected:10}}",
    "onElement": "//*[@class='active-item']"
}
```
### Example No.3

Perform an assertion to ensure that the count of elements matching the locator `//*[@class='error']` is less than or equal to `3`. 
This is useful for scenarios where the script needs to confirm that the number of error messages displayed does not exceed a specific threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:3}}",
    OnElement = "//*[@class='error']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:3}}")
    .setOnElement("//*[@class='error']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:3}}",
    onElement: "//*[@class='error']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:3}}",
    "onElement": "//*[@class='error']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:3}}",
    "onElement": "//*[@class='error']"
}
```
### Example No.4

Assert that the count of elements matching the CSS selector `.list-item`, after applying the regular expression '\d+', is not equal to `0`. 
This validation ensures that the list contains items, preventing scenarios where the list might be empty unexpectedly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    Locator = "CssSelector",
    OnElement = ".list-item",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}")
    .setLocator("CssSelector")
    .setOnElement(".list-item")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    locator: "CssSelector",
    onElement: ".list-item",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    "locator": "CssSelector",
    "onElement": ".list-item",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    "locator": "CssSelector",
    "onElement": ".list-item",
    "regularExpression": "\d+"
}
```
### Example No.5

Perform an assertion to ensure that the count of elements matching the locator `//*[@data-status='completed']` is greater than or equal to `5`. 
This is useful for validating that the number of completed items on the page meets or exceeds a specific value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:5}}",
    OnElement = "//*[@data-status='completed']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:5}}")
    .setOnElement("//*[@data-status='completed']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:5}}",
    onElement: "//*[@data-status='completed']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:5}}",
    "onElement": "//*[@data-status='completed']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:5}}",
    "onElement": "//*[@data-status='completed']"
}
```
### Example No.6

Assert that the count of elements matching the locator `//*[@class='entry']` is lower than `20`. 
This validation ensures that the number of entries displayed on the page does not exceed a certain limit, confirming the correct pagination or loading behavior.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Lower --Expected:20}}",
    OnElement = "//*[@class='entry']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Lower --Expected:20}}")
    .setOnElement("//*[@class='entry']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Lower --Expected:20}}",
    onElement: "//*[@class='entry']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:20}}",
    "onElement": "//*[@class='entry']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:20}}",
    "onElement": "//*[@class='entry']"
}
```
### Example No.7

Check that the count of elements matching the locator `//*[@id='section']//div` matches the regular expression '\d+', ensuring that the count is purely numeric.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Match --Expected:\d+}}",
    OnElement = "//*[@id='section']//div"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Match --Expected:\d+}}")
    .setOnElement("//*[@id='section']//div");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Match --Expected:\d+}}",
    onElement: "//*[@id='section']//div"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:\d+}}",
    "onElement": "//*[@id='section']//div"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:\d+}}",
    "onElement": "//*[@id='section']//div"
}
```
### Example No.8

Assert that the count of elements matching the locator `//*[@class='active-item']` is not equal to `0`. 
This validation is essential for ensuring that at least one active item is present on the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    OnElement = "//*[@class='active-item']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}")
    .setOnElement("//*[@class='active-item']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    onElement: "//*[@class='active-item']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    "onElement": "//*[@class='active-item']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:0}}",
    "onElement": "//*[@class='active-item']"
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
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected value for the element count.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to identify the target elements on the web page. The default value is 'Xpath'.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the web elements to be counted. This can be defined using a locator strategy, such as Xpath, CSS Selector, etc.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the element count before performing the assertion. 
This allows for more flexible validation of the count values that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the element count.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected count value that the elements matching the locator should meet during the assertion.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-elements](https://www.w3.org/TR/webdriver/#find-elements)
