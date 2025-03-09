# Page Title (PageTitle)

[Table of Content](../Home.md)  

~21 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `PageTitle` plugin is designed to validate the title of the current web page in automation scripts. 
It ensures that the title of the page meets specific conditions, such as matching a given text, pattern, or numerical value. 
This plugin is essential for verifying that the correct page is loaded, especially in scenarios where accurate navigation is critical.

### Key Features and Functionality

| Feature                    | Description                                                                                                                              |
|----------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| Title Validation           | Validates that the title of the current web page matches expected conditions, including exact text, patterns, and numerical comparisons. |
| Flexible Assertions        | Supports various operators like equality, inequality, pattern matching, and more, providing robust validation options.                   |
| Regular Expression Support | Allows applying regular expressions to the page title before performing assertions, enabling complex title validations.                  |

### Usages in RPA

| Usage                        | Description                                                                                                                     |
|------------------------------|---------------------------------------------------------------------------------------------------------------------------------|
| Page Load Verification       | Ensures that the web page title matches the expected value, verifying that the correct page has been navigated to in workflows. |
| Dynamic Content Verification | Validates that dynamically generated page titles conform to expected formats, preventing errors in automated processes.         |

### Usages in Automation Testing

| Usage                       | Description                                                                                                                          |
|-----------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification | Verifies that page titles remain consistent across different environments and test scenarios, ensuring a uniform user experience.    |
| Localization Testing        | Ensures that the page title matches the expected localized version, crucial for testing multi-language support.                      |
| SEO Testing                 | Confirms that the page title adheres to SEO best practices, such as containing specific keywords and adhering to length constraints. |

## Examples

### Example No.1

Assert that the title of the current web page equals 'Welcome to My Site'. 
This is useful for scenarios where the script needs to validate that the page title exactly matches the expected value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageTitle",
    Argument = "{{$ --Operator:Equal --Expected:Welcome to My Site}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageTitle")
    .setArgument("{{$ --Operator:Equal --Expected:Welcome to My Site}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageTitle",
    argument: "{{$ --Operator:Equal --Expected:Welcome to My Site}}"
};
```

_**JSON**_

```js
{
    "pluginName": "PageTitle",
    "argument": "{{$ --Operator:Equal --Expected:Welcome to My Site}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageTitle",
    "argument": "{{$ --Operator:Equal --Expected:Welcome to My Site}}"
}
```
### Example No.2

Ensure that the title of the current web page matches the pattern '.*My Site'. 
This assertion checks if the title ends with 'My Site', useful for validating dynamic titles.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageTitle",
    Argument = "{{$ --Operator:Match --Expected:.*My Site}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageTitle")
    .setArgument("{{$ --Operator:Match --Expected:.*My Site}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageTitle",
    argument: "{{$ --Operator:Match --Expected:.*My Site}}"
};
```

_**JSON**_

```js
{
    "pluginName": "PageTitle",
    "argument": "{{$ --Operator:Match --Expected:.*My Site}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageTitle",
    "argument": "{{$ --Operator:Match --Expected:.*My Site}}"
}
```
### Example No.3

Perform an assertion to ensure that the title of the current web page, after applying the regular expression '\w+', contains only word characters. 
This is useful for scenarios where the script needs to ensure that the title is alphanumeric.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Match --Expected:\w+}}",
    RegularExpression = "\w+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Match --Expected:\w+}}")
    .setRegularExpression("\w+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Match --Expected:\w+}}",
    regularExpression: "\w+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:\w+}}",
    "regularExpression": "\w+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:\w+}}",
    "regularExpression": "\w+"
}
```
### Example No.4

Assert that the title of the current web page is not equal to 'Error Page'. 
This validation ensures that the script does not navigate to an error page during execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Error Page}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Error Page}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Error Page}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Error Page}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Error Page}}"
}
```
### Example No.5

Check that the title of the current web page does not match the regular expression '\d+', ensuring it does not contain numeric characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:\d+}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotMatch --Expected:\d+}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:\d+}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:\d+}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:\d+}}"
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
This property allows users to define the operator of the condition (e.g., `Equal`, `Greater`, `Match`) and the expected value for the page title.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regular expression to be applied to the page title before performing the assertion. 
This allows for more flexible validation of titles that may require pattern matching.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the page title.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected title value that the page title should meet during the assertion.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-title](https://www.w3.org/TR/webdriver/#get-title)
