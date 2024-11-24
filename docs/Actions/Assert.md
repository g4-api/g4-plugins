# Assert (Assert)

[Table of Content](../Home.md)  

~46 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Assert` plugin is a crucial component in the world of Robotic Process Automation (RPA) and automation testing.
Its primary purpose is to facilitate the validation of expected conditions during the execution of automation scripts.
By asserting specific conditions, it ensures that the application or system under test behaves as anticipated, contributing to the overall reliability and accuracy of automated processes.

### Key Features and Functionality

| Feature                             | Description                                                                                               |
|-------------------------------------|-----------------------------------------------------------------------------------------------------------|
| Meta Action                         | Creates and sends appropriate assertion plugins based on the provided data.                               |
| Flexible Assertions                 | Supports various conditions, operators, and expected values for assertions.                               |
| Data Extraction                     | Can apply regular expressions and handle element attributes for precise data extraction before assertion. |
| Dynamic Assertion Handling          | Handles dynamic conditions during automation.                                                             |
| Exception Handling                  | Captures and manages exceptions during the assertion process, preventing script failures.                 |
| Extractions and Context Information | Captures and manages context information and supports data extractions. |

### Usages in RPA

| Use Case                   | Description                                                                                                                              |
|----------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| Process Validation         | Ensure automated processes execute successfully by validating key conditions, such as form submission success or expected data presence. |
| Error Handling and Logging | Captures exceptions and logs relevant information for diagnosing issues and understanding failures.                                      |

### Usages in Automation Testing

| Use Case           | Description                                                                                                     |
|--------------------|---------------------------------------------------------------------------------------------------------------- |
| Functional Testing | Validate the correctness of application features, such as element presence or data display.                     |
| Regression Testing | Verify that changes do not adversely impact expected outcomes, ensuring existing functionalities remain intact. |
| Data Validation    | Assert the correctness of data manipulations, calculations, or transfers within the application.                |

## Examples

### Example No.1

Assert that the Text condition equals 'Success'.

The Assert plugin is utilized to perform this validation, taking the actual value from the 'OnElement' property which can be a parameter, data row, or some other dynamic data. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Success}}",
    OnElement = "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Equal --Expected:Success}}")
    .setOnElement("{{$Get-Parameter --Name:MyParam --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Equal --Expected:Success}}",
    onElement: "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:Success}}",
    "onElement": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:Success}}",
    "onElement": "{{$Get-Parameter --Name:MyParam --Scope:Session}}"
}
```

### Example No.2

Assert that an alert exists.

The Assert plugin is utilized to perform this validation. 
If an alert exists, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:AlertExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:AlertExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:AlertExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

### Example No.3

Assert that the text of the element identified by the CSS selector '#greeting' matches the regular expression '^Hello.*'.

The Assert plugin is utilized to perform this validation, providing a means to check the text content of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Hello.*}}",
    Locator = "CssSelector",
    OnElement = "#greeting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Hello.*}}")
    .setLocator("CssSelector")
    .setOnElement("#greeting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Hello.*}}",
    locator: "CssSelector",
    onElement: "#greeting"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Hello.*}}",
    "locator": "CssSelector",
    "onElement": "#greeting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Hello.*}}",
    "locator": "CssSelector",
    "onElement": "#greeting"
}
```

### Example No.4

Assert that the 'class' attribute of the element identified by the CSS selector '#elementId' does not match the regular expression '^hidden$'.

The Assert plugin is utilized to perform this validation, providing a means to check attribute values of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^hidden$}}",
    Locator = "CssSelector",
    OnAttribute = "class",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^hidden$}}")
    .setLocator("CssSelector")
    .setOnAttribute("class")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^hidden$}}",
    locator: "CssSelector",
    onAttribute: "class",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^hidden$}}",
    "locator": "CssSelector",
    "onAttribute": "class",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^hidden$}}",
    "locator": "CssSelector",
    "onAttribute": "class",
    "onElement": "#elementId"
}
```

### Example No.5

Assert that the text length of the element identified by the CSS selector '#description' is greater than 5.

The Assert plugin is utilized to perform this validation, providing a means to check the text length of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:5}}",
    Locator = "CssSelector",
    OnElement = "#description"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:5}}")
    .setLocator("CssSelector")
    .setOnElement("#description");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:5}}",
    locator: "CssSelector",
    onElement: "#description"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:5}}",
    "locator": "CssSelector",
    "onElement": "#description"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:5}}",
    "locator": "CssSelector",
    "onElement": "#description"
}
```

### Example No.6

Assert that the element identified by the CSS selector '#hiddenElement' is visible.

The Assert plugin is utilized to perform this validation, providing a means to check the visibility state of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementVisible}}",
    Locator = "CssSelector",
    OnElement = "#hiddenElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementVisible}}")
    .setLocator("CssSelector")
    .setOnElement("#hiddenElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementVisible}}",
    locator: "CssSelector",
    onElement: "#hiddenElement"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "CssSelector",
    "onElement": "#hiddenElement"
}
```

### Example No.7

Assert that the numeric value of the element identified by the CSS selector '#price' is less than or equal to 100.

The Assert plugin is utilized to perform this validation. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#price"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#price");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:100}}",
    locator: "CssSelector",
    onElement: "#price"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#price"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#price"
}
```

### Example No.8

Assert that the numeric value of the element identified by the CSS selector '#score' is greater than or equal to 85.

The Assert plugin is utilized to perform this validation. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:85}}",
    Locator = "CssSelector",
    OnElement = "#score"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:85}}")
    .setLocator("CssSelector")
    .setOnElement("#score");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:85}}",
    locator: "CssSelector",
    onElement: "#score"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:85}}",
    "locator": "CssSelector",
    "onElement": "#score"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:85}}",
    "locator": "CssSelector",
    "onElement": "#score"
}
```

### Example No.9

Assert that the value of the `value` attribute of the element with the CSS selector `#ElementActive` is equal to `Foo Bar`.

The Assert plugin is utilized to perform this validation, providing a means to check attribute values of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Foo Bar}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "#ElementActive"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Foo Bar}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("#ElementActive");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Foo Bar}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "#ElementActive"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Foo Bar}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#ElementActive"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Foo Bar}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#ElementActive"
}
```

### Example No.10

Assert that the value of the `value` attribute of the element with the CSS selector `#ElementActive` is equal to `Bar`, applying the regular expression `B.*$` before validation.

The Assert plugin is utilized to perform this validation, providing a means to check attribute values with regular expression patterns. 
If the condition is met post-regular expression application, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Bar}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "#ElementActive",
    RegularExpression = "B.*$"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Bar}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("#ElementActive")
    .setRegularExpression("B.*$");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Bar}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "#ElementActive",
    regularExpression: "B.*$"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Bar}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#ElementActive",
    "regularExpression": "B.*$"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Bar}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#ElementActive",
    "regularExpression": "B.*$"
}
```

### Example No.11

Validate the absence of an alert in the current browser session.

The Assert plugin is utilized to perform this validation, ensuring that no alert is currently present. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:AlertNotExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:AlertNotExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:AlertNotExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertNotExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertNotExists}}"
}
```

### Example No.12

Validate that the text content of the element identified by the CSS selector `#ElementText` is equal to the expected value `ElementText`.

The Assert plugin is utilized to perform this validation, providing a means to check the text content of UI elements. 
If the condition is met, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:ElementText}}",
    Locator = "CssSelector",
    OnElement = "#ElementText"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:ElementText}}")
    .setLocator("CssSelector")
    .setOnElement("#ElementText");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:ElementText}}",
    locator: "CssSelector",
    onElement: "#ElementText"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:ElementText}}",
    "locator": "CssSelector",
    "onElement": "#ElementText"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:ElementText}}",
    "locator": "CssSelector",
    "onElement": "#ElementText"
}
```
### Example No.13

Assert that the numeric text content of the element identified by the CSS selector '#amount' matches the extracted numbers using the regular expression '\d+' and is equal to '100'.

The Assert plugin is utilized to perform this validation, applying a regular expression to extract numbers before asserting the extracted value. 
If the condition is met after the extraction, the assertion passes; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#amount",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#amount")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:100}}",
    locator: "CssSelector",
    onElement: "#amount",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#amount",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#amount",
    "regularExpression": "\d+"
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
| **Value Type**    | Expression        |

Specifies the condition and parameters for the assertion to be performed by a particular plugin. 
It is a key part of the rule definition and influences how the validation or verification is carried out.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies how the automation framework should identify or locate the target element within the UI. 
It defines the strategy or method for selecting the element on which the assertion or action will be performed.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute of the target element on which the assertion or action should be performed. 
It defines which attribute of the identified element will be the focus of the validation or manipulation.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the identifier or selector for the element on which the assertion or action should be performed. 
It essentially points to the target element within the web page or application.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Allows you to apply a regular expression pattern to manipulate or extract specific information from the value of an attribute or the element text before the actual validation or action is performed. 
It is particularly useful when you want to perform more complex checks or extract specific substrings from attribute values.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

Serves as a dynamic specifier for the type of validation or verification to be executed in automation rules. 
This parameter is particularly noteworthy for its adaptability, as its available values are dynamically generated based on the plugins of type `Assertion` within G4™ engine.

### Dynamic Condition Values

The `Condition` parameter allows the rule to express various types of assertions or conditions dynamically. 
These dynamic conditions are derived from the plugins of type `Assertion` available in the G4™ framework. 
Each assertion plugin contributes unique conditions, reflecting diverse validation scenarios.

### Plugin-Driven Flexibility

As new assertion plugins are introduced or existing ones are updated, the `Condition` parameter seamlessly incorporates these changes. 
This ensures that automation rules remain adaptable and can leverage the latest assertion capabilities without requiring explicit modifications to the rule structures.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Defines the value or condition that the automation rule expects to encounter or validate. This value represents the anticipated state of the UI element or the result of an action.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Serves as a dynamic specifier that defines the type of comparison or action to be executed during automation. 
This parameter is particularly noteworthy for its adaptability, as its available values are dynamically generated based on the plugins of type `Operator` within G4™ engine.

### Dynamic Operator Values

The `Operator` parameter dynamically incorporates values based on plugins of type `Operator` within the automation framework. 
Each operator plugin introduces specific operators for use in rule configurations.

### Plugin-Driven Flexibility

As new operator plugins are introduced or existing ones are updated, the `Operator` parameter seamlessly incorporates these changes. 
This ensures that automation rules remain adaptable and can leverage the latest operator capabilities without requiring explicit modifications to the rule structures.
