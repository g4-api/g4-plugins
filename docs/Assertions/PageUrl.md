# Page Url (PageUrl)

[Table of Content](../Home.md)  

~27 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `PageUrl` plugin is designed to validate the URL of the current web page against specific conditions. 
It provides a robust mechanism to assert that the page URL meets expected conditions, such as matching a particular pattern, containing specific segments, or being equal to a given URL.

### Key Features and Functionality

| Feature                    | Description                                                                                                         |
|----------------------------|---------------------------------------------------------------------------------------------------------------------|
| URL Validation             | Validates the current page URL against expected conditions, supporting both exact matches and pattern-based checks. |
| Regular Expression Support | Applies regular expressions to the URL before performing assertions, enabling complex validations.                  |
| Flexible Assertions        | Supports a range of operators, including equality, inequality, and pattern matching, for versatile URL validation.  |

### Usages in RPA

| Usage                   | Description                                                                                                                    |
|-------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Navigation Verification | Ensures that the web page navigates to the correct URL during automation workflows, crucial for verifying link correctness.    |
| Dynamic URL Validation  | Validates that the dynamically generated or redirected URLs match expected patterns, preventing errors in automated workflows. |

### Usages in Automation Testing

| Usage                       | Description                                                                                                                                  |
|-----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| SEO Compliance Verification | Ensures that page URLs adhere to SEO best practices, including structure, format, and content relevance.                                     |
| Localization Testing        | Verifies that localized versions of the website navigate to the correct URLs, ensuring consistent behavior across different regions.         |
| Functional Testing          | Validates that user actions lead to the correct pages by checking the resulting URL, ensuring accuracy in navigation and link functionality. |

## Examples

### Example No.1

Ensure that the extracted numeric value from the URL is greater than `100`. 
The regular expression `\d+` is used to extract numeric values from the URL, and the assertion checks that the extracted number exceeds `100`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:Greater --Expected:100}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:Greater --Expected:100}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:Greater --Expected:100}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Greater --Expected:100}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Greater --Expected:100}}",
    "regularExpression": "\d+"
}
```
### Example No.2

Assert that the numeric value extracted from the URL is less than `50`. 
This validation ensures that the extracted numeric value, identified by the regular expression `\d+`, is below `50`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:Lower --Expected:50}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:Lower --Expected:50}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:Lower --Expected:50}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Lower --Expected:50}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Lower --Expected:50}}",
    "regularExpression": "\d+"
}
```
### Example No.3

Validate that the numeric value extracted from the URL is greater than or equal to `200`. 
The regular expression `\d+` extracts the numeric part of the URL, and the assertion confirms that it meets or exceeds `200`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:GreaterEqual --Expected:200}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:GreaterEqual --Expected:200}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:GreaterEqual --Expected:200}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:GreaterEqual --Expected:200}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:GreaterEqual --Expected:200}}",
    "regularExpression": "\d+"
}
```
### Example No.4

Check that the numeric value extracted from the URL is less than or equal to `300`. 
The regular expression `\d+` is applied to extract the number, and the assertion verifies that it does not exceed `300`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:LowerEqual --Expected:300}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:LowerEqual --Expected:300}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:LowerEqual --Expected:300}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:LowerEqual --Expected:300}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:LowerEqual --Expected:300}}",
    "regularExpression": "\d+"
}
```
### Example No.5

Assert that the current page URL is equal to 'https://example.com/home'. 
This is useful for scenarios where the script needs to confirm that the user has navigated to the correct page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:Equal --Expected:https://example.com/home}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:Equal --Expected:https://example.com/home}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:Equal --Expected:https://example.com/home}}"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Equal --Expected:https://example.com/home}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Equal --Expected:https://example.com/home}}"
}
```
### Example No.6

Check that the current page URL does not match the pattern 'https://example.com/404'. 
This ensures that the script has not navigated to an error page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:NotMatch --Expected:https://example.com/404}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:NotMatch --Expected:https://example.com/404}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:NotMatch --Expected:https://example.com/404}}"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:NotMatch --Expected:https://example.com/404}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:NotMatch --Expected:https://example.com/404}}"
}
```
### Example No.7

Ensure that the URL contains the text 'dashboard'. 
This is useful for validating that the user is on the dashboard page or a related section.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "PageUrl",
    Argument = "{{$ --Operator:Match --Expected:dashboard}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("PageUrl")
    .setArgument("{{$ --Operator:Match --Expected:dashboard}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "PageUrl",
    argument: "{{$ --Operator:Match --Expected:dashboard}}"
};
```

_**JSON**_

```js
{
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Match --Expected:dashboard}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "PageUrl",
    "argument": "{{$ --Operator:Match --Expected:dashboard}}"
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

Specifies a regular expression to be applied to the page URL before performing the assertion. 
This allows for more flexible validation of URL patterns.

## Parameters

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating the page URL.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the expected URL or pattern that the current page URL is expected to match during the assertion.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-current-url](https://www.w3.org/TR/webdriver/#get-current-url)
