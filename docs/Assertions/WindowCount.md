# Window Count (WindowCount)

[Table of Content](../Home.md)  

~30 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `WindowCount` plugin is designed to validate the number of open browser windows or tabs within automation scripts. 
It provides a robust mechanism to assert that the number of open windows meets specific conditions, making it essential for scenarios where managing multiple windows or tabs is crucial.

### Key Features and Functionality

| Feature                    | Description                                                                                                 |
|----------------------------|-------------------------------------------------------------------------------------------------------------|
| Window Count Validation    | Validates that the number of open browser windows or tabs meets the expected condition.                     |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, and numeric comparisons.                     |
| Regular Expression Support | Applies regular expressions to the window count before performing assertions, enabling complex validations. |

### Usages in RPA

| Usage                    | Description                                                                                                                        |
|--------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Multi-Window Management  | Ensures that the expected number of windows or tabs are open, crucial for verifying workflows involving multiple browser contexts. |
| Dynamic Tab Verification | Validates that dynamically opened or closed windows/tabs match the expected count, ensuring proper browser session management.     |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                                  |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification  | Ensures that the expected number of browser windows or tabs are present across different environments and test runs.                         |
| Regression Testing           | Validates that changes to the application do not affect the expected count of open windows or tabs, ensuring consistency in user interfaces. |
| Performance Data Validation  | Checks that the number of open browser windows/tabs matches the expected performance metrics, ensuring optimal application behavior.         |

## Examples

### Example No.1

Assert that the count of open browser windows equals `2`. 
This is useful for scenarios where the script needs to ensure that exactly 2 windows are open in the browser session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WindowCount",
    Argument = "{{$ --Operator:Equal --Expected:2}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WindowCount")
    .setArgument("{{$ --Operator:Equal --Expected:2}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WindowCount",
    argument: "{{$ --Operator:Equal --Expected:2}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WindowCount",
    "argument": "{{$ --Operator:Equal --Expected:2}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WindowCount",
    "argument": "{{$ --Operator:Equal --Expected:2}}"
}
```
### Example No.2

Ensure that the number of open browser windows is greater than `3`. 
This assertion checks if the number of open windows exceeds 3, confirming that additional windows were opened as expected.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WindowCount",
    Argument = "{{$ --Operator:Greater --Expected:3}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WindowCount")
    .setArgument("{{$ --Operator:Greater --Expected:3}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WindowCount",
    argument: "{{$ --Operator:Greater --Expected:3}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WindowCount",
    "argument": "{{$ --Operator:Greater --Expected:3}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WindowCount",
    "argument": "{{$ --Operator:Greater --Expected:3}}"
}
```
### Example No.3

Perform an assertion to ensure that the number of open browser windows is less than or equal to `5`. 
This is useful for scenarios where the script needs to confirm that the number of open windows does not exceed a specific threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:5}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:5}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:5}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:5}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:5}}"
}
```
### Example No.4

Assert that the count of open browser windows, after applying the regular expression '\d+', is not equal to `0`. 
This validation ensures that at least one window is open, preventing scenarios where the browser might unexpectedly close all windows.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}",
    "regularExpression": "\d+"
}
```
### Example No.5

Perform an assertion to ensure that the number of open browser windows is greater than or equal to `4`. 
This is useful for validating that the number of open windows meets or exceeds a specific value, confirming correct session management.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:4}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:4}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:4}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:4}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:4}}"
}
```
### Example No.6

Assert that the count of open browser windows is less than `10`. 
This validation ensures that the number of open windows does not exceed a certain limit, confirming correct session management or resource usage.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Lower --Expected:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Lower --Expected:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Lower --Expected:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Lower --Expected:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Lower --Expected:10}}"
}
```
### Example No.7

Check that the count of open browser windows matches the regular expression '\d+', ensuring that the count is purely numeric.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Match --Expected:\d+}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Match --Expected:\d+}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Match --Expected:\d+}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Match --Expected:\d+}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Match --Expected:\d+}}"
}
```
### Example No.8

Assert that the number of open browser windows is not equal to `0`. 
This validation is essential for ensuring that at least one window remains open in the browser session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:0}}"
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
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected value for the window count.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the window count before performing the assertion. 
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

Specifies the type of comparison or operation to be performed when evaluating the window count.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected count value that the number of open browser windows should meet during the assertion.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-window-handles](https://www.w3.org/TR/webdriver/#get-window-handles)
