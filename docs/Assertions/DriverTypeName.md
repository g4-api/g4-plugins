# Driver Type Name (DriverTypeName)

[Table of Content](../Home.md)  

~30 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `DriverTypeName` plugin is designed to assert the type name of the WebDriver used during automation tasks. 
This plugin is crucial for validating that the correct driver is in use, ensuring the automation script is running in the expected browser or environment.

### Key Features and Functionality

| Feature                     | Description                                                                                                 |
|-----------------------------|-------------------------------------------------------------------------------------------------------------|
| Driver Type Validation      | Validates that the current WebDriver matches the expected driver type, such as Chrome, Firefox, etc.        |
| Operator Flexibility        | Supports a wide range of operators for flexible validation, including equality, pattern matching, and more. |
| Regular Expression Support  | Allows applying regular expressions to the driver type name before performing the assertion.                |

### Usages in RPA

| Usage                 | Description                                                                             |
|-----------------------|-----------------------------------------------------------------------------------------|
| Driver Validation     | Ensures that the correct WebDriver is in use for executing specific tasks or workflows. |
| Environment Assurance | Confirms that automation scripts are running in the expected environment or browser.    |

### Usages in Automation Testing

| Usage                   | Description                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------|
| Cross-Browser Testing   | Validates that tests are running in the correct browser, ensuring consistency in test coverage.   |
| Environment Consistency | Ensures that the tests are executed in the intended environment, such as a specific browser type. |

## Examples

### Example No.1

Assert that the WebDriver type name equals 'Chrome'. 
This is useful for scenarios where the script must validate that the test is running in the Chrome browser.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "DriverTypeName",
    Argument = "{{$ --Operator:Equal --Expected:Chrome}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("DriverTypeName")
    .setArgument("{{$ --Operator:Equal --Expected:Chrome}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "DriverTypeName",
    argument: "{{$ --Operator:Equal --Expected:Chrome}}"
};
```

_**JSON**_

```js
{
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Equal --Expected:Chrome}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Equal --Expected:Chrome}}"
}
```
### Example No.2

Assert that the WebDriver type name does not equal 'Firefox'. 
This is useful for ensuring the script is not running in Firefox, allowing for browser-specific automation flows.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "DriverTypeName",
    Argument = "{{$ --Operator:NotEqual --Expected:Firefox}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("DriverTypeName")
    .setArgument("{{$ --Operator:NotEqual --Expected:Firefox}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "DriverTypeName",
    argument: "{{$ --Operator:NotEqual --Expected:Firefox}}"
};
```

_**JSON**_

```js
{
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:NotEqual --Expected:Firefox}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:NotEqual --Expected:Firefox}}"
}
```
### Example No.3

Assert that the WebDriver type name matches the regular expression 'Chrome|Firefox'. 
This is useful for validating that the test is running in either Chrome or Firefox.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "DriverTypeName",
    Argument = "{{$ --Operator:Match --Expected:Chrome|Firefox}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("DriverTypeName")
    .setArgument("{{$ --Operator:Match --Expected:Chrome|Firefox}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "DriverTypeName",
    argument: "{{$ --Operator:Match --Expected:Chrome|Firefox}}"
};
```

_**JSON**_

```js
{
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Match --Expected:Chrome|Firefox}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Match --Expected:Chrome|Firefox}}"
}
```
### Example No.4

Assert that the WebDriver type name matches the regular expression pattern '.*Driver' using a regular expression. 
This is useful for scenarios where the driver name contains a specific suffix like 'Driver'.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "DriverTypeName",
    Argument = "{{$ --Operator:Match --Expected:.*Driver}}",
    RegularExpression = ".*Driver"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("DriverTypeName")
    .setArgument("{{$ --Operator:Match --Expected:.*Driver}}")
    .setRegularExpression(".*Driver");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "DriverTypeName",
    argument: "{{$ --Operator:Match --Expected:.*Driver}}",
    regularExpression: ".*Driver"
};
```

_**JSON**_

```js
{
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Match --Expected:.*Driver}}",
    "regularExpression": ".*Driver"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "DriverTypeName",
    "argument": "{{$ --Operator:Match --Expected:.*Driver}}",
    "regularExpression": ".*Driver"
}
```
### Example No.5

Perform an assertion to ensure the WebDriver type name equals 'Chrome' using the `Assert` plugin. 
The `Assert` plugin is used to check this condition, validating that the test is running in the Chrome browser.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Operator:Equal --Expected:Chrome}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Operator:Equal --Expected:Chrome}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Operator:Equal --Expected:Chrome}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:Equal --Expected:Chrome}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:Equal --Expected:Chrome}}"
}
```
### Example No.6

Perform an assertion to ensure the WebDriver type name does not equal 'Firefox' using the `Assert` plugin. 
This validation is crucial for ensuring that the automation is not running in the Firefox browser, allowing for browser-specific workflows.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Operator:NotEqual --Expected:Firefox}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Operator:NotEqual --Expected:Firefox}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Operator:NotEqual --Expected:Firefox}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:NotEqual --Expected:Firefox}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:NotEqual --Expected:Firefox}}"
}
```
### Example No.7

Perform an assertion to ensure the WebDriver type name matches the regular expression 'Chrome|Firefox' using the `Assert` plugin. 
This example validates that the test is running in either Chrome or Firefox, ensuring consistency across browsers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Operator:Match --Expected:Chrome|Firefox}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Operator:Match --Expected:Chrome|Firefox}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Operator:Match --Expected:Chrome|Firefox}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:Match --Expected:Chrome|Firefox}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:Match --Expected:Chrome|Firefox}}"
}
```
### Example No.8

Perform an assertion to ensure the WebDriver type name does not match the regular expression 'IE|Edge' using the `Assert` plugin. 
This validation ensures that the automation is not running in Internet Explorer or Edge, useful for workflows that require different handling for these browsers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:IE|Edge}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:IE|Edge}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:IE|Edge}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:IE|Edge}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:IE|Edge}}"
}
```

## Properties

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the WebDriver type name before performing the assertion. 
This allows for more flexible validation of driver names that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the WebDriver type name.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value or pattern that the WebDriver type name is expected to match during the assertion.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#new-session](https://www.w3.org/TR/webdriver/#new-session)
