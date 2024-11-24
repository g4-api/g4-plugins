# Text (Text)

[Table of Content](../Home.md)  

~33 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Text` plugin is designed to perform text assertions within automation scripts. 
Its primary objective is to validate that a given text input, which can be either static or dynamically retrieved from a parameter, meets the expected conditions.

### Key Features and Functionality

| Feature                    | Description                                                                                              |
|----------------------------|----------------------------------------------------------------------------------------------------------|
| Static and Dynamic Input   | Supports both static text and text retrieved dynamically from parameters for assertions.                 |
| Flexible Assertions        | Provides a range of operators to validate text conditions, including equality, inequality, and patterns. |
| Regular Expression Support | Allows applying regular expressions to the text before performing the assertion.                         |

### Usages in RPA

| Usage             | Description                                                                              |
|-------------------|------------------------------------------------------------------------------------------|
| Validate Text     | Ensure that a static or dynamic text value matches the expected conditions.              |
| Data Verification | Verify data integrity by asserting that parameter values meet specified text conditions. |

### Usages in Automation Testing

| Usage               | Description                                                                                               |
|---------------------|-----------------------------------------------------------------------------------------------------------|
| Functional Testing  | Validate that text inputs in various test scenarios meet the expected conditions.                         |
| Regression Testing  | Ensure that changes in the application do not affect the expected text values in the system.              |
| Data-Driven Testing | Dynamically retrieve and assert text values from test data parameters to ensure accuracy and consistency. |

## Examples

### Example No.1

Assert that the text `{{$Get-Parameter --Name:MyParameter --Scope:Session}}` is equal to the expected value provided by a dynamic parameter.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Equal --Expected:ExpectedValue}}",
    OnElement = "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Equal --Expected:ExpectedValue}}")
    .setOnElement("{{$Get-Parameter --Name:MyParameter --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Equal --Expected:ExpectedValue}}",
    onElement: "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:ExpectedValue}}",
    "onElement": "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:ExpectedValue}}",
    "onElement": "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
}
```
### Example No.2

Assert that the text `Static Text` is not equal to the expected value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:NotEqual --Expected:Static Text}}",
    OnElement = "Static Text"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:NotEqual --Expected:Static Text}}")
    .setOnElement("Static Text");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:NotEqual --Expected:Static Text}}",
    onElement: "Static Text"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotEqual --Expected:Static Text}}",
    "onElement": "Static Text"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotEqual --Expected:Static Text}}",
    "onElement": "Static Text"
}
```
### Example No.3

Assert that the text `123-45-6789` matches the regular expression `\d{3}-\d{2}-\d{4}`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "123-45-6789"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("123-45-6789");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "123-45-6789"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```
### Example No.4

Assert that the text `123-45-6789` does not match the regular expression `\d{3}-\d{2}-\d{4}`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "123-45-6789"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("123-45-6789");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "123-45-6789"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```
### Example No.5

Assert that the text `20` is greater than the value `10`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Greater --Expected:10}}",
    OnElement = "20"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Greater --Expected:10}}")
    .setOnElement("20");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Greater --Expected:10}}",
    onElement: "20"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Greater --Expected:10}}",
    "onElement": "20"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Greater --Expected:10}}",
    "onElement": "20"
}
```
### Example No.6

Assert that the text `5` is less than the value `10`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Lower --Expected:10}}",
    OnElement = "5"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Lower --Expected:10}}")
    .setOnElement("5");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Lower --Expected:10}}",
    onElement: "5"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Lower --Expected:10}}",
    "onElement": "5"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Lower --Expected:10}}",
    "onElement": "5"
}
```
### Example No.7

Assert that the text `10` is greater than or equal to the value `10`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:GreaterEqual --Expected:10}}",
    OnElement = "10"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:GreaterEqual --Expected:10}}")
    .setOnElement("10");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:GreaterEqual --Expected:10}}",
    onElement: "10"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:GreaterEqual --Expected:10}}",
    "onElement": "10"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:GreaterEqual --Expected:10}}",
    "onElement": "10"
}
```
### Example No.8

Assert that the text `10` is less than or equal to the value `10`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:LowerEqual --Expected:10}}",
    OnElement = "10"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:LowerEqual --Expected:10}}")
    .setOnElement("10");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:LowerEqual --Expected:10}}",
    onElement: "10"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:LowerEqual --Expected:10}}",
    "onElement": "10"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:LowerEqual --Expected:10}}",
    "onElement": "10"
}
```
### Example No.9

Assert that the text `1000` matches a regular expression to extract numbers before comparison.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Equal --Expected:1000}}",
    OnElement = "1000",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Equal --Expected:1000}}")
    .setOnElement("1000")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Equal --Expected:1000}}",
    onElement: "1000",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:1000}}",
    "onElement": "1000",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:1000}}",
    "onElement": "1000",
    "regularExpression": "\d+"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the actual text value that will be compared against the expected value. This can be a static text or a dynamic value retrieved using a CLI expression.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the text value before performing the assertion.

## Parameters

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value or pattern that the automation script expects to find or match during the execution of a condition.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating a condition.
