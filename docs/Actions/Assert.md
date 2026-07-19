# Assert (Assert)

[Table of Content](../Home.md)  

~894 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Checks that values or page elements match your expectations during automated runs. It highlights any differences and records them so you can review and fix issues later. All assertion results appear in the extractions section of the automation response. This helps teams catch and resolve problems quickly.

### Key Features and Functionality

| Feature          | Description                                                                       |
|------------------|-----------------------------------------------------------------------------------|
| Meta Action      | Automatically builds and runs the correct assertion steps based on your settings. |
| Condition Types  | Checks text, numbers, or element properties against expected values.              |
| Regex Extraction | Uses patterns to find and verify specific parts of text.                          |
| Dynamic Checks   | Repeats checks when data or page content changes during a run.                    |
| Error Logging    | Saves failure details and error messages for easy debugging.                      |
| Context Capture  | Records element locators and related details to help diagnose issues.             |

### Usages in RPA

| Use Case          | Description                                                         |
|-------------------|---------------------------------------------------------------------|
| Data Verification | Checks that required information or fields are present and correct. |

### Usages in Automation Testing

| Use Case                | Description                                             |
|-------------------------|---------------------------------------------------------|
| Functional Verification | Checks that UI elements and workflows work as intended. |
| Regression Verification | Verifies that updates have not introduced new errors.   |
| Data Integrity Checks   | Ensures calculations and data transfers are accurate.   |

## Examples

### Example No.1

### Alert Existence Check

Verifies that an alert is present.
If an alert is detected, the assert evaluates to `true`.

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
### Example No.2

### Alert Absence Check

Verifies that no alert is present.
If no alert is detected, the assert evaluates to `true`.

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
### Example No.3

### Driver Type Validation

Verifies the driver's type using an equality check.
It asserts that the actual driver's type exactly matches the expected value 'G4.WebDriver.Simulator.SimulatorDriver'.
If the actual value exactly equals the expected value, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:Equal}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:Equal}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:Equal}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:Equal}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:Equal}}"
}
```
### Example No.4

### Driver Type Mismatch Validation

Verifies that the driver's type does not match the expected value using a not-equal operator.
It asserts that the actual driver's type is different from 'G4.WebDriver.Simulator.SimulatorDriver'.
If the actual value does not equal the expected value, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:NotEqual}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:NotEqual}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:NotEqual}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:NotEqual}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:G4.WebDriver.Simulator.SimulatorDriver --Operator:NotEqual}}"
}
```
### Example No.5

### Driver Type Regex Match Validation

Verifies that the driver's type matches a regular expression pattern.
It asserts that the actual driver's type conforms to the regex pattern `.*SimulatorDriver` using the Match operator.
If the actual value matches the regular expression, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Expected:.*SimulatorDriver --Operator:Match}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Expected:.*SimulatorDriver --Operator:Match}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Expected:.*SimulatorDriver --Operator:Match}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:.*SimulatorDriver --Operator:Match}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:.*SimulatorDriver --Operator:Match}}"
}
```
### Example No.6

### Driver Type Regex NotMatch Validation

Verifies that the driver's type does not match a regular expression pattern.
It asserts that the actual driver's type does not conform to the regex pattern `.*ChromeDriver` using the NotMatch operator.
If the actual value does not match the regular expression, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:DriverTypeName --Expected:.*ChromeDriver --Operator:NotMatch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:DriverTypeName --Expected:.*ChromeDriver --Operator:NotMatch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:DriverTypeName --Expected:.*ChromeDriver --Operator:NotMatch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:.*ChromeDriver --Operator:NotMatch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:DriverTypeName --Expected:.*ChromeDriver --Operator:NotMatch}}"
}
```
### Example No.7

### Element Active Validation

Verifies that a specific element is active.
The condition `ElementActive` is applied to the element identified by the CSS selector `#ElementActive`.
If the element is active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementActive}}",
    Locator = "CssSelector",
    OnElement = "#ElementActive"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementActive}}")
    .setLocator("CssSelector")
    .setOnElement("#ElementActive");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementActive}}",
    locator: "CssSelector",
    onElement: "#ElementActive"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "locator": "CssSelector",
    "onElement": "#ElementActive"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "locator": "CssSelector",
    "onElement": "#ElementActive"
}
```
### Example No.8

### Element Active Validation Using Xpath

Verifies that a specific element is active.
The condition `ElementActive` is applied to the element identified by the Xpath selector `//*[@id='ElementActive']`.
If the element is active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementActive}}",
    OnElement = "//*[@id='ElementActive']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementActive}}")
    .setOnElement("//*[@id='ElementActive']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementActive}}",
    onElement: "//*[@id='ElementActive']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "onElement": "//*[@id='ElementActive']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "onElement": "//*[@id='ElementActive']"
}
```
### Example No.9

### Element Active Validation Using Id

Verifies that a specific element is active using the Id locator.
It asserts that the condition `ElementActive` is applied to the element with the Id `ElementActive`.
If the element is active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementActive}}",
    Locator = "Id",
    OnElement = "ElementActive"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementActive}}")
    .setLocator("Id")
    .setOnElement("ElementActive");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementActive}}",
    locator: "Id",
    onElement: "ElementActive"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "locator": "Id",
    "onElement": "ElementActive"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementActive}}",
    "locator": "Id",
    "onElement": "ElementActive"
}
```
### Example No.10

### Element Attribute Equality Validation

Verifies that a specified attribute of an element equals a given value.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is equal to `0` using the Equal operator.
If the attribute value exactly equals `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.11

### Element Attribute Equality Validation Using Xpath

Verifies that a specified attribute of an element equals a given value using the Xpath locator.
It asserts that the attribute `index` of the element identified by the Xpath `//*[@id='elementId']` is equal to `0` using the Equal operator.
If the attribute value exactly equals `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.12

### Element Attribute Equality Validation Using Id

Verifies that a specified attribute of an element equals a given value using the Id locator.
It asserts that the attribute `index` of the element with Id `elementId` is equal to `0` using the Equal operator.
If the attribute value exactly equals `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.13

### Element Attribute NotEqual Validation Using CssSelector

Verifies that a specified attribute of an element is not equal to a given value using the NotEqual operator.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is not equal to `0`.
If the attribute value does not equal `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.14

### Element Attribute NotEqual Validation Using Xpath

Verifies that a specified attribute of an element is not equal to a given value using the NotEqual operator.
It asserts that the attribute `index` of the element identified by the Xpath selector `//*[@id='elementId']` is not equal to `0`.
If the attribute value does not equal `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.15

### Element Attribute NotEqual Validation Using Id

Verifies that a specified attribute of an element is not equal to a given value using the NotEqual operator.
It asserts that the attribute `index` of the element with Id `elementId` is not equal to `0`.
If the attribute value does not equal `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.16

### Element Attribute Greater Validation Using CssSelector

Verifies that a specified attribute of an element is greater than a given value.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is greater than `0` using the Greater operator.
If the attribute value is greater than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.17

### Element Attribute Greater Validation Using Xpath

Verifies that a specified attribute of an element is greater than a given value using the Xpath locator.
It asserts that the attribute `index` of the element identified by the Xpath selector `//*[@id='elementId']` is greater than `0` using the Greater operator.
If the attribute value is greater than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.18

### Element Attribute Greater Validation Using Id

Verifies that a specified attribute of an element is greater than a given value using the Id locator.
It asserts that the attribute `index` of the element with Id `elementId` is greater than `0` using the Greater operator.
If the attribute value is greater than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Greater --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.19

### Element Attribute Lower Validation Using CssSelector

Verifies that a specified attribute of an element is lower than a given value.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is lower than `0` using the Lower operator.
If the attribute value is lower than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.20

### Element Attribute Lower Validation Using Xpath

Verifies that a specified attribute of an element is lower than a given value using the Xpath locator.
It asserts that the attribute `index` of the element identified by the Xpath selector `//*[@id='elementId']` is lower than `0` using the Lower operator.
If the attribute value is lower than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.21

### Element Attribute Lower Validation Using Id

Verifies that a specified attribute of an element is lower than a given value using the Id locator.
It asserts that the attribute `index` of the element with Id `elementId` is lower than `0` using the Lower operator.
If the attribute value is lower than `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Lower --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.22

### Element Attribute GreaterEqual Validation Using CssSelector

Verifies that a specified attribute of an element is greater than or equal to a given value.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is greater than or equal to `0` using the GreaterEqual operator.
If the attribute value is greater than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.23

### Element Attribute GreaterEqual Validation Using Xpath

Verifies that a specified attribute of an element is greater than or equal to a given value using the Xpath locator.
It asserts that the attribute `index` of the element identified by the Xpath selector `//*[@id='elementId']` is greater than or equal to `0` using the GreaterEqual operator.
If the attribute value is greater than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.24

### Element Attribute GreaterEqual Validation Using Id

Verifies that a specified attribute of an element is greater than or equal to a given value using the Id locator.
It asserts that the attribute `index` of the element with Id `elementId` is greater than or equal to `0` using the GreaterEqual operator.
If the attribute value is greater than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:GreaterEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.25

### Element Attribute LowerEqual Validation Using CssSelector

Verifies that a specified attribute of an element is lower than or equal to a given value.
It asserts that the attribute `index` of the element identified by the CSS selector `#elementId` is lower than or equal to `0` using the LowerEqual operator.
If the attribute value is lower than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.26

### Element Attribute LowerEqual Validation Using Xpath

Verifies that a specified attribute of an element is lower than or equal to a given value using the Xpath locator.
It asserts that the attribute `index` of the element identified by the Xpath selector `//*[@id='elementId']` is lower than or equal to `0` using the LowerEqual operator.
If the attribute value is lower than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.27

### Element Attribute LowerEqual Validation Using Id

Verifies that a specified attribute of an element is lower than or equal to a given value using the Id locator.
It asserts that the attribute `index` of the element with Id `elementId` is lower than or equal to `0` using the LowerEqual operator.
If the attribute value is lower than or equal to `0`, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:LowerEqual --Expected:0}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.28

### Element Attribute Regex Match Validation Using CssSelector

Verifies that the attribute `index` of an element matches the regex pattern `^\d+$`.
It asserts that the attribute value conforms to the pattern using the Match operator.
If the attribute value matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.29

### Element Attribute Regex Match Validation Using Xpath

Verifies that the attribute `index` of an element matches the regex pattern `^\d+$`.
It asserts that the attribute value conforms to the pattern using the Match operator with an Xpath locator.
If the attribute value matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.30

### Element Attribute Regex Match Validation Using Id

Verifies that the attribute `index` of an element matches the regex pattern `^\d+$`.
It asserts that the attribute value for the element with Id `elementId` conforms to the pattern using the Match operator.
If the attribute value matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:^\d+$}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.31

### Element Attribute NotMatch Regex Validation Using CssSelector

Verifies that the attribute `index` of an element does not match the regex pattern `^[a-zA-Z]+$`.
It asserts that the attribute value fails to conform to the pattern using the NotMatch operator.
If the attribute value does not match the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    Locator = "CssSelector",
    OnAttribute = "index",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("index")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    locator: "CssSelector",
    onAttribute: "index",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "locator": "CssSelector",
    "onAttribute": "index",
    "onElement": "#elementId"
}
```
### Example No.32

### Element Attribute NotMatch Regex Validation Using Xpath

Verifies that the attribute `index` of an element does not match the regex pattern `^[a-zA-Z]+$`.
It asserts that the attribute value fails to conform to the pattern using the NotMatch operator with an Xpath locator.
If the attribute value does not match the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    OnAttribute = "index",
    OnElement = "//*[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}")
    .setOnAttribute("index")
    .setOnElement("//*[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    onAttribute: "index",
    onElement: "//*[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "onAttribute": "index",
    "onElement": "//*[@id='elementId']"
}
```
### Example No.33

### Element Attribute NotMatch Regex Validation Using Id

Verifies that the attribute `index` of an element does not match the regex pattern `^[a-zA-Z]+$`.
It asserts that the attribute value for the element with Id `elementId` fails to conform to the pattern using the NotMatch operator.
If the attribute value does not match the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    Locator = "Id",
    OnAttribute = "index",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}")
    .setLocator("Id")
    .setOnAttribute("index")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    locator: "Id",
    onAttribute: "index",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:^[a-zA-Z]+$}}",
    "locator": "Id",
    "onAttribute": "index",
    "onElement": "elementId"
}
```
### Example No.34

### Element Count Equal Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is exactly 2.
If the element count equals 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.35

### Element Count Equal Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is exactly 2.
If the element count equals 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.36

### Element Count Equal Validation Using TagName

Verifies that the number of elements matching the TagName selector is exactly 2.
It asserts that the element count for elements with tag name `button` equals 2.
If the element count equals 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Equal --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.37

### Element Count NotEqual Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is not equal to 2.
If the element count is different from 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.38

### Element Count NotEqual Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is not equal to 2.
If the element count is different from 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.39

### Element Count NotEqual Validation Using TagName

Verifies that the number of elements matching the TagName selector for `button` is not equal to 2.
If the element count is different from 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.40

### Element Count Greater Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is greater than 2.
If the element count exceeds 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.41

### Element Count Greater Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is greater than 2.
If the element count exceeds 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.42

### Element Count Greater Validation Using TagName

Verifies that the number of elements with the tag name `button` is greater than 2.
If the element count exceeds 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Greater --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.43

### Element Count Lower Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is lower than 2.
If the element count is less than 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.44

### Element Count Lower Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is lower than 2.
If the element count is less than 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.45

### Element Count Lower Validation Using TagName

Verifies that the number of elements matching the TagName selector for `button` is lower than 2.
If the element count is less than 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Lower --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.46

### Element Count GreaterEqual Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is greater than or equal to 2.
If the element count is greater than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.47

### Element Count GreaterEqual Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is greater than or equal to 2.
If the element count is greater than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.48

### Element Count GreaterEqual Validation Using TagName

Verifies that the number of elements with the tag name `button` is greater than or equal to 2.
If the element count is greater than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:GreaterEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.49

### Element Count LowerEqual Validation Using CssSelector

Verifies that the number of elements matching the CSS selector `.primary-button` is lower than or equal to 2.
If the element count is lower than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.50

### Element Count LowerEqual Validation Using Xpath

Verifies that the number of elements matching the Xpath selector `//button` is lower than or equal to 2.
If the element count is lower than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "onElement": "//button"
}
```
### Example No.51

### Element Count LowerEqual Validation Using TagName

Verifies that the number of elements with the tag name `button` is lower than or equal to 2.
If the element count is lower than or equal to 2, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:LowerEqual --Expected:2}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.52

### Element Count Regex Match Validation Using CssSelector

Verifies that the element count for the selector `.primary-button` matches the regex pattern `^[1-9][0-9]*$`.
It asserts that the element count is a positive integer using the Match operator.
If the element count matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.53

### Element Count Regex Match Validation Using Xpath

Verifies that the element count for the Xpath selector `//button` matches the regex pattern `^[1-9][0-9]*$`.
It asserts that the element count is a positive integer using the Match operator.
If the element count matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "onElement": "//button"
}
```
### Example No.54

### Element Count Regex Match Validation Using TagName

Verifies that the element count for elements with the tag name `button` matches the regex pattern `^[1-9][0-9]*$`.
It asserts that the element count is a positive integer using the Match operator.
If the element count matches the regex pattern, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:Match --Expected:^[1-9][0-9]*$}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.55

### Element Count NotMatch Regex Validation Using CssSelector

Verifies that the element count for the selector `.primary-button` is strictly numeric by confirming the absence of alphabetic characters.
It asserts that the element count does not match the regex pattern `.*[a-zA-Z]+.*` using the NotMatch operator.
If the element count is strictly numeric, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    Locator = "CssSelector",
    OnElement = ".primary-button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}")
    .setLocator("CssSelector")
    .setOnElement(".primary-button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    locator: "CssSelector",
    onElement: ".primary-button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "locator": "CssSelector",
    "onElement": ".primary-button"
}
```
### Example No.56

### Element Count NotMatch Regex Validation Using Xpath

Verifies that the element count for the Xpath selector `//button` is strictly numeric by confirming the absence of alphabetic characters.
It asserts that the element count does not match the regex pattern `.*[a-zA-Z]+.*` using the NotMatch operator.
If the element count is strictly numeric, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    OnElement = "//button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}")
    .setOnElement("//button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    onElement: "//button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "onElement": "//button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "onElement": "//button"
}
```
### Example No.57

### Element Count NotMatch Regex Validation Using TagName

Verifies that the element count for elements with the tag name `button` is strictly numeric by confirming the absence of alphabetic characters.
It asserts that the element count does not match the regex pattern `.*[a-zA-Z]+.*` using the NotMatch operator.
If the element count is strictly numeric, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    Locator = "TagName",
    OnElement = "button"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}")
    .setLocator("TagName")
    .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    locator: "TagName",
    onElement: "button"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "locator": "TagName",
    "onElement": "button"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementCount --Operator:NotMatch --Expected:.*[a-zA-Z]+.*}}",
    "locator": "TagName",
    "onElement": "button"
}
```
### Example No.58

### Element Disabled Validation Using CssSelector

Verifies that the element identified by the CSS selector `#username` is disabled.
If the element is disabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementDisabled}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementDisabled}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementDisabled}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.59

### Element Disabled Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='username']` is disabled.
If the element is disabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementDisabled}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementDisabled}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementDisabled}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.60

### Element Disabled Validation Using Id

Verifies that the element with the Id `username` is disabled.
If the element is disabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementDisabled}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementDisabled}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementDisabled}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementDisabled}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.61

### Element Enabled Validation Using CssSelector

Verifies that the element identified by the CSS selector `#username` is enabled.
If the element is enabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementEnabled}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementEnabled}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementEnabled}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.62

### Element Enabled Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='username']` is enabled.
If the element is enabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementEnabled}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementEnabled}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementEnabled}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.63

### Element Enabled Validation Using Id

Verifies that the element with the Id `username` is enabled.
If the element is enabled, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementEnabled}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementEnabled}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementEnabled}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementEnabled}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.64

### Element Exists Validation Using CssSelector

Verifies that an element identified by the CSS selector `#username` exists in the DOM.
If the element exists, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementExists}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementExists}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementExists}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.65

### Element Exists Validation Using Xpath

Verifies that an element identified by the Xpath selector `//input[@id='username']` exists in the DOM.
If the element exists, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementExists}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementExists}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementExists}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.66

### Element Exists Validation Using Id

Verifies that an element with the Id `username` exists in the DOM.
If the element exists, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementExists}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementExists}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementExists}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementExists}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.67

### Element Not Active Validation Using CssSelector

Verifies that the element identified by the CSS selector `#username` is not active.
If the element is not active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotActive}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotActive}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotActive}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.68

### Element Not Active Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='username']` is not active.
If the element is not active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotActive}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotActive}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotActive}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.69

### Element Not Active Validation Using Id

Verifies that the element with the Id `username` is not active.
If the element is not active, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotActive}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotActive}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotActive}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotActive}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.70

### Element Not Exists Validation Using CssSelector

Verifies that an element identified by the CSS selector `#username` does not exist in the DOM.
If the element is absent, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotExists}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotExists}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotExists}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.71

### Element Not Exists Validation Using Xpath

Verifies that an element identified by the Xpath selector `//input[@id='username']` does not exist in the DOM.
If the element is absent, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotExists}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotExists}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotExists}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.72

### Element Not Exists Validation Using Id

Verifies that an element with the Id `username` does not exist in the DOM.
If the element is absent, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotExists}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotExists}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotExists}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotExists}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.73

### Element Not Selected Validation Using CssSelector

Verifies that the element identified by the CSS selector `#acceptTerms` is not selected.
If the element is not selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotSelected}}",
    Locator = "CssSelector",
    OnElement = "#acceptTerms"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotSelected}}")
    .setLocator("CssSelector")
    .setOnElement("#acceptTerms");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotSelected}}",
    locator: "CssSelector",
    onElement: "#acceptTerms"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "CssSelector",
    "onElement": "#acceptTerms"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "CssSelector",
    "onElement": "#acceptTerms"
}
```
### Example No.74

### Element Not Selected Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='acceptTerms']` is not selected.
If the element is not selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotSelected}}",
    OnElement = "//input[@id='acceptTerms']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotSelected}}")
    .setOnElement("//input[@id='acceptTerms']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotSelected}}",
    onElement: "//input[@id='acceptTerms']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "onElement": "//input[@id='acceptTerms']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "onElement": "//input[@id='acceptTerms']"
}
```
### Example No.75

### Element Not Selected Validation Using Id

Verifies that the element with the Id `acceptTerms` is not selected.
If the element is not selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotSelected}}",
    Locator = "Id",
    OnElement = "acceptTerms"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotSelected}}")
    .setLocator("Id")
    .setOnElement("acceptTerms");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotSelected}}",
    locator: "Id",
    onElement: "acceptTerms"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "Id",
    "onElement": "acceptTerms"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotSelected}}",
    "locator": "Id",
    "onElement": "acceptTerms"
}
```
### Example No.76

### Element Not Visible Validation Using CssSelector

Verifies that the element identified by the CSS selector `#username` is not visible in the DOM.
Visibility may be determined by properties such as `display: none`, `visibility: hidden`, or off-screen positioning.
If the element is not visible, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotVisible}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotVisible}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotVisible}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.77

### Element Not Visible Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='username']` is not visible in the DOM.
Visibility may be determined by properties such as `display: none`, `visibility: hidden`, or off-screen positioning.
If the element is not visible, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotVisible}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotVisible}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotVisible}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.78

### Element Not Visible Validation Using Id

Verifies that the element with the Id `username` is not visible in the DOM.
Visibility may be determined by properties such as `display: none`, `visibility: hidden`, or off-screen positioning.
If the element is not visible, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementNotVisible}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementNotVisible}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementNotVisible}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementNotVisible}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.79

### Element Selected Validation Using CssSelector

Verifies that the element identified by the CSS selector `#acceptTerms` is selected.
The ElementSelected condition only applies to elements such as `<input type="checkbox">`, `<input type="radio">`, or `<option selected>`.
If the element is selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementSelected}}",
    Locator = "CssSelector",
    OnElement = "#acceptTerms"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementSelected}}")
    .setLocator("CssSelector")
    .setOnElement("#acceptTerms");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementSelected}}",
    locator: "CssSelector",
    onElement: "#acceptTerms"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "CssSelector",
    "onElement": "#acceptTerms"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "CssSelector",
    "onElement": "#acceptTerms"
}
```
### Example No.80

### Element Selected Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='acceptTerms']` is selected.
The ElementSelected condition only applies to elements such as `<input type="checkbox">`, `<input type="radio">`, or `<option selected>`.
If the element is selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementSelected}}",
    OnElement = "//input[@id='acceptTerms']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementSelected}}")
    .setOnElement("//input[@id='acceptTerms']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementSelected}}",
    onElement: "//input[@id='acceptTerms']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "onElement": "//input[@id='acceptTerms']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "onElement": "//input[@id='acceptTerms']"
}
```
### Example No.81

### Element Selected Validation Using Id

Verifies that the element with the Id `acceptTerms` is selected.
The ElementSelected condition only applies to elements such as `<input type="checkbox">`, `<input type="radio">`, or `<option selected>`.
If the element is selected, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementSelected}}",
    Locator = "Id",
    OnElement = "acceptTerms"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementSelected}}")
    .setLocator("Id")
    .setOnElement("acceptTerms");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementSelected}}",
    locator: "Id",
    onElement: "acceptTerms"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "Id",
    "onElement": "acceptTerms"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementSelected}}",
    "locator": "Id",
    "onElement": "acceptTerms"
}
```
### Example No.82

### Element Stale Validation Using CssSelector

Verifies that the element identified by the CSS selector `#username` is stale.
If the element is stale, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementStale}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementStale}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementStale}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.83

### Element Stale Validation Using Xpath

Verifies that the element identified by the Xpath selector `//input[@id='username']` is stale.
If the element is stale, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementStale}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementStale}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementStale}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.84

### Element Stale Validation Using Id

Verifies that the element with the Id `username` is stale.
If the element is stale, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementStale}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementStale}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementStale}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementStale}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.85

### Element Text Length Equal Validation Using CssSelector

Verifies that the text length of the element identified by the CSS selector `#content` is exactly 255 characters.
The computed text length excludes HTML tags and counts only the visible text as returned by the WebDriver Get Element Text endpoint. For nested HTML, the length is determined by concatenating the visible text from all child elements.
If the text length equals 255, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.86

### Element Text Length Equal Validation Using Xpath

Verifies that the text length of the element identified by the Xpath selector `//div[@id='content']` is exactly 255 characters.
The computed text length excludes HTML tags and counts only the visible text as returned by the WebDriver Get Element Text endpoint. For nested HTML, the length is determined by concatenating the visible text from all child elements.
If the text length equals 255, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.87

### Element Text Length Equal Validation Using Id

Verifies that the text length of the element with the Id `content` is exactly 255 characters.
The computed text length excludes HTML tags and counts only the visible text as returned by the WebDriver Get Element Text endpoint. For nested HTML, the length is determined by concatenating the visible text from all child elements.
If the text length equals 255, the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.88

### Element Text Length Equal with Regex Validation Using CssSelector

Verifies that the visible text length of the element identified by the CSS selector `#content` is exactly 100 characters.
The text length is computed by excluding HTML tags and counting only the visible text as returned by the WebDriver Get Element Text endpoint.
A regular expression `(?s)^(.{0,100})` is applied to extract up to 100 characters from the visible text.
The assertion evaluates to `true` only if the length of the extracted string is exactly 100. If the element contains fewer than 100 visible characters, the regex match group will capture fewer than 100 characters, causing the assertion to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    locator: "CssSelector",
    onElement: "#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.89

### Element Text Length Equal with Regex Validation Using Xpath

Verifies that the visible text length of the element identified by the Xpath selector `//div[@id='content']` is exactly 100 characters.
The computed text length excludes HTML tags and counts only the visible text as provided by the WebDriver Get Element Text endpoint.
A regular expression `(?s)^(.{0,100})` is applied to extract up to 100 characters from the visible text.
The assertion evaluates to `true` only if the extracted string is exactly 100 characters long. If the element contains fewer than 100 visible characters, the regex match group will capture fewer than 100 characters, causing the assertion to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.90

### Element Text Length Equal with Regex Validation Using Id

Verifies that the visible text length of the element with the Id `content` is exactly 100 characters.
The text length is calculated by excluding HTML tags and considering only the visible text as returned by the WebDriver Get Element Text endpoint.
A regular expression `(?s)^(.{0,100})` is applied to extract up to 100 characters from the visible text.
The assertion evaluates to `true` only if the extracted string is exactly 100 characters long. If the element contains fewer than 100 visible characters, the regex match group will capture fewer than 100 characters, causing the assertion to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.91

### Input Value Text Length Equal Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` is exactly 150 characters.
The text length is computed solely from the value attribute, excluding any HTML markup.
If the value attribute contains exactly 150 characters (regardless of visual presentation), the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```
### Example No.92

### Input Value Text Length Equal Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` is exactly 150 characters.
The text length is computed solely from the value attribute, excluding any HTML markup.
If the value attribute contains exactly 150 characters (regardless of visual presentation), the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    onAttribute: "value",
    onElement: "//input[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```
### Example No.93

### Input Value Text Length Equal Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` is exactly 150 characters.
The text length is computed solely from the value attribute, excluding any HTML markup.
If the value attribute contains exactly 150 characters (regardless of visual presentation), the assert evaluates to `true`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.94

### Input Value Text Length Equal Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` is exactly 100 characters.
The text length is computed solely from the attribute value, excluding any HTML markup.
A regular expression `(?s)^(.{0,100})` is used to extract up to 100 characters, and the assertion passes only if exactly 100 characters are captured.
If the extracted match is shorter than 100 characters, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.95

### Input Value Text Length Equal Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` is exactly 100 characters.
The text length is computed solely from the attribute value, excluding any HTML markup.
A regular expression `(?s)^(.{0,100})` is used to extract up to 100 characters, and the assertion passes only if exactly 100 characters are captured.
If the extracted match is shorter than 100 characters, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.96

### Input Value Text Length Equal Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` is exactly 100 characters.
The text length is computed solely from the attribute value, excluding any HTML markup.
A regular expression `(?s)^(.{0,100})` is used to extract up to 100 characters, and the assertion passes only if exactly 100 characters are captured.
If the extracted match is shorter than 100 characters, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Equal --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.97

### Element Text Length NotEqual Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` does not equal 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is different from 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.98

### Element Text Length NotEqual Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` does not equal 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is different from 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.99

### Element Text Length NotEqual Validation Using Id

Verifies that the visible text content of the element with the Id `content` does not equal 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is different from 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.100

### Element Text Length NotEqual with Regex Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` is not exactly 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if fewer than 100 characters are captured or if no match occurs; it fails if exactly 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    locator: "CssSelector",
    onElement: "#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.101

### Element Text Length NotEqual with Regex Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` is not exactly 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if fewer than 100 characters are captured or if no match occurs; it fails if exactly 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.102

### Element Text Length NotEqual with Regex Validation Using Id

Verifies that the visible text content of the element with the Id `content` is not exactly 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if fewer than 100 characters are captured or if no match occurs; it fails if exactly 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.103

### Input Value Text Length NotEqual Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` does not equal 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is not exactly 150 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```
### Example No.104

### Input Value Text Length NotEqual Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` does not equal 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is not exactly 150 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    onAttribute: "value",
    onElement: "//input[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```
### Example No.105

### Input Value Text Length NotEqual Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` does not equal 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is not exactly 150 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.106

### Input Value Text Length NotEqual Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` is not exactly 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if the length of the regex capture group is not exactly 100; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.107

### Input Value Text Length NotEqual Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` is not exactly 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if the length of the regex capture group is not exactly 100; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.108

### Input Value Text Length NotEqual Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` is not exactly 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if the length of the regex capture group is not exactly 100; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.109

### Element Text Length Greater Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` is greater than 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.110

### Element Text Length Greater Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` is greater than 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.111

### Element Text Length Greater Validation Using Id

Verifies that the visible text content of the element with the Id `content` is greater than 255 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.112

### Input Value Text Length Greater Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.113

### Input Value Text Length Greater Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.114

### Input Value Text Length Greater Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.115

### Textarea Value Text Length Greater Validation Using CssSelector

Verifies that the text length of the value attribute of a textarea with the CSS selector `textarea#content` is greater than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,200})` is applied to the `value` attribute to extract up to 200 characters into a capture group.
The assertion passes only if the computed length is greater than 150; if exactly 150 characters are captured or fewer, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,200})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,200})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,200})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,200})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,200})"
}
```
### Example No.116

### Textarea Value Text Length Greater Validation Using Xpath

Verifies that the text length of the value attribute of a textarea with the Xpath selector `//textarea[@id='content']` is greater than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,200})` is applied to the `value` attribute to extract up to 200 characters into a capture group.
The assertion passes only if the computed length is greater than 150; if exactly 150 characters are captured or fewer, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,200})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,200})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,200})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,200})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,200})"
}
```
### Example No.117

### Textarea Value Text Length Greater Validation Using Id

Verifies that the text length of the value attribute of a textarea with the Id `content` is greater than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,200})` is applied to the `value` attribute to extract up to 200 characters into a capture group.
The assertion passes only if the computed length is greater than 150; if exactly 150 characters are captured or fewer, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,200})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,200})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,200})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,200})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,200})"
}
```
### Example No.118

### Textarea Value Text Length Greater Validation Using CssSelector

Verifies that the text length of the value attribute of a textarea element identified by the CSS selector `textarea#content` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.119

### Textarea Value Text Length Greater Validation Using Xpath

Verifies that the text length of the value attribute of a textarea element identified by the Xpath selector `//textarea[@id='content']` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.120

### Textarea Value Text Length Greater Validation Using Id

Verifies that the text length of the value attribute of a textarea with the Id `content` is greater than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,110})` is applied to the `value` attribute to extract up to 110 characters into a capture group.
The assertion passes only if more than 100 characters are captured; if exactly 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,110})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,110})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,110})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Greater --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,110})"
}
```
### Example No.121

### Element Text Length GreaterEqual Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` is greater than or equal to 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.122

### Element Text Length GreaterEqual Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` is greater than or equal to 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.123

### Element Text Length GreaterEqual Validation Using Id

Verifies that the visible text content of the element with the Id `content` is greater than or equal to 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.124

### Element Text Length GreaterEqual Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` is greater than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is greater than or equal to 100; if fewer than 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    locator: "CssSelector",
    onElement: "#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.125

### Element Text Length GreaterEqual Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` is greater than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is greater than or equal to 100; if fewer than 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.126

### Element Text Length GreaterEqual Validation Using Id

Verifies that the visible text content of the element with the Id `content` is greater than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is greater than or equal to 100; if fewer than 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.127

### Textarea Value Text Length GreaterEqual Validation Using CssSelector

Verifies that the text length of the value attribute of a textarea element, identified by the CSS selector `textarea#content`, is greater than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.128

### Textarea Value Text Length GreaterEqual Validation Using Xpath

Verifies that the text length of the value attribute of a textarea element, identified by the Xpath selector `//textarea[@id='content']`, is greater than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.129

### Textarea Value Text Length GreaterEqual Validation Using Id

Verifies that the text length of the value attribute of a textarea, with the Id `content`, is greater than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is greater than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.130

### Textarea Value Text Length GreaterEqual Validation Using CssSelector

Verifies that the text length of the value attribute of a textarea element identified by the CSS selector `textarea#content` is greater than or equal to 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,})` is applied to the `value` attribute to extract the full visible text into a capture group.
The assertion passes only if the computed length is greater than or equal to 100 characters; it fails if fewer than 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,})"
}
```
### Example No.131

### Textarea Value Text Length GreaterEqual Validation Using Xpath

Verifies that the text length of the value attribute of a textarea element identified by the Xpath selector `//textarea[@id='content']` is greater than or equal to 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,})` is applied to the `value` attribute to extract the full visible text into a capture group.
The assertion passes only if the computed length is greater than or equal to 100 characters; it fails if fewer than 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,})"
}
```
### Example No.132

### Textarea Value Text Length GreaterEqual Validation Using Id

Verifies that the text length of the value attribute of a textarea with the Id `content` is greater than or equal to 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,})` is applied to the `value` attribute to extract the full visible text into a capture group.
The assertion passes only if the computed length is greater than or equal to 100 characters; it fails if fewer than 100 characters are captured.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:GreaterEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,})"
}
```
### Example No.133

### Element Text Length LowerEqual Validation Using CssSelector

Verifies that the visible text content of the element identified by the CSS selector `#content` is less than or equal to 255 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.134

### Element Text Length LowerEqual Validation Using Xpath

Verifies that the visible text content of the element identified by the Xpath selector `//div[@id='content']` is less than or equal to 255 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.135

### Element Text Length LowerEqual Validation Using Id

Verifies that the visible text content of the element with the Id `content` is less than or equal to 255 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.136

### Element Text Length LowerEqual Validation Using CssSelector

Verifies that the visible text of the element identified by the CSS selector `#content` is less than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(?=.{0,100}$)(.*)$` is applied to the visible text to capture the entire text only if its length is at most 100 characters; if the text exceeds 100 characters, the regex fails to match.
The assertion passes only if the regex successfully captures text and the computed length is less than or equal to 100 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#content",
    RegularExpression = "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#content")
    .setRegularExpression("(?s)^(?=.{0,100}$)(.*)$");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    locator: "CssSelector",
    onElement: "#content",
    regularExpression: "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```
### Example No.137

### Element Text Length LowerEqual Validation Using Xpath

Verifies that the visible text of the element identified by the Xpath selector `//div[@id='content']` is less than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(?=.{0,100}$)(.*)$` is applied to the visible text to capture the entire text only if its length is at most 100 characters; if the text exceeds 100 characters, the regex fails to match.
The assertion passes only if the regex successfully captures text and the computed length is less than or equal to 100 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(?=.{0,100}$)(.*)$");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```
### Example No.138

### Element Text Length LowerEqual Validation Using Id

Verifies that the visible text of the element with the Id `content` is less than or equal to 100 characters.
The length is based solely on the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(?=.{0,100}$)(.*)$` is applied to the visible text to capture the entire text only if its length is at most 100 characters; if the text exceeds 100 characters, the regex fails to match.
The assertion passes only if the regex successfully captures text and the computed length is less than or equal to 100 characters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(?=.{0,100}$)(.*)$");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(?=.{0,100}$)(.*)$"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(?=.{0,100}$)(.*)$"
}
```
### Example No.139

### Input Value Text Length LowerEqual Validation Using CssSelector

Verifies that the text length of the value attribute of an input element (of type text) identified by the CSS selector `input#content` is less than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```
### Example No.140

### Input Value Text Length LowerEqual Validation Using Xpath

Verifies that the text length of the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` is less than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    onAttribute: "value",
    onElement: "//input[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```
### Example No.141

### Input Value Text Length LowerEqual Validation Using Id

Verifies that the text length of the value attribute of an input element (of type text) with the Id `content` is less than or equal to 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.142

### Textarea Value Text Length LowerEqual Validation Using CssSelector

Verifies that the visible text of a textarea's value attribute, identified by the CSS selector `textarea#content`, is less than or equal to 100 characters.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract only the first 100 characters, so that even if the full text is longer, only these 100 characters are evaluated.
The assertion passes only if the computed length from this capture group is less than or equal to 100 characters; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.143

### Textarea Value Text Length LowerEqual Validation Using Xpath

Verifies that the visible text of a textarea's value attribute, identified by the Xpath selector `//textarea[@id='content']`, is less than or equal to 100 characters.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract only the first 100 characters, so that even if the full text is longer, only these 100 characters are evaluated.
The assertion passes only if the computed length from this capture group is less than or equal to 100 characters; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.144

### Textarea Value Text Length LowerEqual Validation Using Id

Verifies that the visible text of a textarea's value attribute, with the Id `content`, is less than or equal to 100 characters.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract only the first 100 characters, so that even if the full text is longer, only these 100 characters are evaluated.
The assertion passes only if the computed length from this capture group is less than or equal to 100 characters; if more than 100 characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:LowerEqual --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.145

### Element Text Length Lower Validation Using CssSelector

Verifies that the visible text of the element identified by the CSS selector `#content` is less than 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 255; if it is greater than or equal to 255, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.146

### Element Text Length Lower Validation Using Xpath

Verifies that the visible text of the element identified by the Xpath selector `//div[@id='content']` is less than 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 255; if it is greater than or equal to 255, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.147

### Element Text Length Lower Validation Using Id

Verifies that the visible text of the element with the Id `content` is less than 255 characters.
The length is computed from the visible text only, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 255; if it is greater than or equal to 255, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:255}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.148

### Element Text Length Lower Validation Using CssSelector

Verifies that the visible text of the element identified by the CSS selector `#content` is less than 100 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    Locator = "CssSelector",
    OnElement = "#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setLocator("CssSelector")
    .setOnElement("#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    locator: "CssSelector",
    onElement: "#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "CssSelector",
    "onElement": "#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.149

### Element Text Length Lower Validation Using Xpath

Verifies that the visible text of the element identified by the Xpath selector `//div[@id='content']` is less than 100 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.150

### Element Text Length Lower Validation Using Id

Verifies that the visible text of the element with the Id `content` is less than 100 characters.
The length is determined solely from the visible text, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the visible text to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.151

### Textarea Value Text Length Lower Validation Using CssSelector

Verifies that the text length of the value attribute of a textarea element identified by the CSS selector `textarea#content` is less than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 150; if 150 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.152

### Textarea Value Text Length Lower Validation Using Xpath

Verifies that the text length of the value attribute of a textarea element identified by the Xpath selector `//textarea[@id='content']` is less than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 150; if 150 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.153

### Textarea Value Text Length Lower Validation Using Id

Verifies that the text length of the value attribute of a textarea with the Id `content` is less than 150 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes only if the computed length is less than 150; if 150 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:150}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.154

### Input Value Text Length Lower Validation Using CssSelector

Verifies that the text from the `value` attribute of an input element identified by the CSS selector `input#content` is less than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.155

### Input Value Text Length Lower Validation Using Xpath

Verifies that the text from the `value` attribute of an input element identified by the Xpath selector `//input[@id='content']` is less than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.156

### Input Value Text Length Lower Validation Using Id

Verifies that the text from the `value` attribute of an input element with the Id `content` is less than 100 characters.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length is less than 100; if 100 or more characters are captured, the assertion fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Lower --Expected:100}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.157

### Element Text Length Match Validation Using CssSelector

Verifies that the visible text of the element identified by the CSS selector `#content` has a length that matches the regular expression pattern `^2\d+$`.
The length is computed from the visible text only, excluding any HTML markup or tags.
The regular expression is used to validate that the computed length (converted to a string) begins with the digit 2 and is followed by one or more digits.
The assertion passes only if the computed length exactly matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.158

### Element Text Length Match Validation Using Xpath

Verifies that the visible text of the element identified by the Xpath selector `//div[@id='content']` has a length that matches the regular expression pattern `^2\d+$`.
The length is computed from the visible text only, excluding any HTML markup or tags.
The regular expression is used to validate that the computed length (as a string) begins with the digit 2 and is followed by one or more digits.
The assertion passes only if the computed length exactly matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.159

### Element Text Length Match Validation Using Id

Verifies that the visible text of the element with the Id `content` has a length that matches the regular expression pattern `^2\d+$`.
The length is computed from the visible text only, excluding any HTML markup or tags.
The regular expression is used to confirm that the computed length (converted to a string) starts with the digit 2 followed by one or more digits.
The assertion passes only if the computed length exactly matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^2\d+$}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.160

### Input Value Text Length Match Validation (Failure Expected) Using CssSelector

Verifies that the computed length of the text from the value attribute of an input element, identified by the CSS selector `input#content`, matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
Because the regex limits the extraction to 100 characters, the computed length will never begin with '15', and therefore the assertion is expected to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.161

### Input Value Text Length Match Validation (Failure Expected) Using Xpath

Verifies that the computed length of the text from the value attribute of an input element, identified by the Xpath selector `//input[@id='content']`, matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
Because the regex restricts the capture to 100 characters, the computed length will never meet the expected pattern, and the assertion is designed to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.162

### Element Text Length Match Validation (Failure Expected) Using Id

Verifies that the computed length of the text from the value attribute of an input element with the Id `content` matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group.
Given that the extraction is capped at 100 characters, the computed length will never fulfill the pattern, causing the assertion to fail.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.163

### Input Value Text Length Match Validation Using CssSelector

Verifies that the computed length of the text from the value attribute of an input element (of type text) identified by the CSS selector `input#content` matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The expected outcome is that the computed length, when converted to a string, will begin with '15' (for example, '150', '151', etc.).
The assertion passes only if the computed length meets this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content"
}
```
### Example No.164

### Input Value Text Length Match Validation Using Xpath

Verifies that the computed length of the text from the value attribute of an input element (of type text) identified by the Xpath selector `//input[@id='content']` matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The expected outcome is that the computed length, when converted to a string, will start with '15' (for example, '150', '151', etc.).
The assertion passes only if the computed length meets this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    onAttribute: "value",
    onElement: "//input[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']"
}
```
### Example No.165

### Element Text Length Match Validation Using Id

Verifies that the computed length of the text from the value attribute of an input element with the Id `content` matches the pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The expected outcome is that the computed length, when converted to a string, will start with '15' (for example, '150', '151', etc.).
The assertion passes only if the computed length meets this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.166

### Input Value Text Length Match Validation Using CssSelector

Verifies that the computed length of the text from the value attribute of an input element, identified by the CSS selector `input#content`, matches the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group. The computed length, when converted to a string, must match the pattern `^1\d+$` (for example, '10', '11', '150', etc.).
The assertion passes only if the computed length matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.167

### Input Value Text Length Match Validation Using Xpath

Verifies that the computed length of the text from the value attribute of an input element, identified by the Xpath selector `//input[@id='content']`, matches the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group. The computed length, when converted to a string, must match the pattern `^1\d+$` (for example, '10', '11', '150', etc.).
The assertion passes only if the computed length matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.168

### Element Text Length Match Validation Using Id

Verifies that the computed length of the text from the value attribute of an input element with the Id `content` matches the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the `value` attribute to extract up to 100 characters into a capture group. The computed length, when converted to a string, must match the pattern `^1\d+$` (for example, '10', '11', '150', etc.).
The assertion passes only if the computed length matches this pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:Match --Expected:^1\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.169

### Element Text Length NotMatch Validation Using CssSelector

Verifies that the computed length of the visible text of the element identified by the CSS selector `#content` does not match the pattern `^2\d+$`.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length, when converted to a string, does not begin with the digit '2'.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    Locator = "CssSelector",
    OnElement = "#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}")
    .setLocator("CssSelector")
    .setOnElement("#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    locator: "CssSelector",
    onElement: "#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "locator": "CssSelector",
    "onElement": "#content"
}
```
### Example No.170

### Element Text Length NotMatch Validation Using Xpath

Verifies that the computed length of the visible text of the element identified by the Xpath selector `//div[@id='content']` does not match the pattern `^2\d+$`.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length, when converted to a string, does not begin with the digit '2'.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.171

### Element Text Length NotMatch Validation Using Id

Verifies that the computed length of the visible text of the element with the Id `content` does not match the pattern `^2\d+$`.
The length is determined solely from the visible text, excluding any HTML markup or tags.
The assertion passes only if the computed length, when converted to a string, does not begin with the digit '2'.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^2\d+$}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.172

### Input Value Text Length NotMatch Validation Using CssSelector

Verifies that the computed length of the text from the value attribute of an input element identified by the CSS selector `input#content` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.173

### Input Value Text Length NotMatch Validation Using Xpath

Verifies that the computed length of the text from the value attribute of an input element identified by the Xpath selector `//input[@id='content']` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.174

### Element Text Length NotMatch Validation Using Id

Verifies that the computed length of the text from the value attribute of an input element with the Id `content` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.175

### Element Text Length NotMatch Validation Using CssSelector

Verifies that the computed length of the text from the value attribute of a textarea element with the CssSelector `textarea#content` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.176

### Element Text Length NotMatch Validation Using Xpath

Verifies that the computed length of the text from the value attribute of a textarea element with the XPath locator `//textarea[@id='content']` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.177

### Element Text Length NotMatch Validation Using Id

Verifies that the computed length of the text from the value attribute of a textarea element with the Id `content` does not match the expected pattern `^15\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^15\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^15\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.178

### Element Text Length NotMatch Validation Using CssSelector

Verifies that the computed length of the text from the value attribute of an input element with the CssSelector `input#content` does not match the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^1\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "input#content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("input#content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "input#content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "input#content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.179

### Element Text Length NotMatch Validation Using Xpath

Verifies that the computed length of the text from the value attribute of an input element with the XPath locator `//input[@id='content']` does not match the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^1\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    OnAttribute = "value",
    OnElement = "//input[@id='content']",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}")
    .setOnAttribute("value")
    .setOnElement("//input[@id='content']")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    onAttribute: "value",
    onElement: "//input[@id='content']",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "onAttribute": "value",
    "onElement": "//input[@id='content']",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.180

### Element Text Length NotMatch Validation Using Id

Verifies that the computed length of the text from the value attribute of an input element with the Id `content` does not match the expected pattern `^1\d+$`.
The length is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,100})` is applied to the value attribute to extract up to 100 characters into a capture group.
The assertion passes only if the computed length, when converted to a string, does not match the pattern `^1\d+$`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,100})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,100})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,100})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementTextLength --Operator:NotMatch --Expected:^1\d+$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,100})"
}
```
### Example No.181

### Element Visible Validation Using CssSelector

Verifies that an element identified by the CSS selector `#username` is visible in the DOM.
Visibility is determined solely based on the element's presence and rendering state, excluding any hidden or collapsed styling.
The assertion passes if the element is visible; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementVisible}}",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementVisible}}")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementVisible}}",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "CssSelector",
    "onElement": "#username"
}
```
### Example No.182

### Element Visible Validation Using Xpath

Verifies that an element identified by the XPath locator `//input[@id='username']` is visible in the DOM.
Visibility is determined solely based on the element's presence and rendering state, excluding any hidden or collapsed styling.
The assertion passes if the element is visible; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementVisible}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementVisible}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementVisible}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.183

### Element Visible Validation Using Id

Verifies that an element identified by the Id `username` is visible in the DOM.
Visibility is determined solely based on the element's presence and rendering state, excluding any hidden or collapsed styling.
The assertion passes if the element is visible; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementVisible}}",
    Locator = "Id",
    OnElement = "username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementVisible}}")
    .setLocator("Id")
    .setOnElement("username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementVisible}}",
    locator: "Id",
    onElement: "username"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "Id",
    "onElement": "username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementVisible}}",
    "locator": "Id",
    "onElement": "username"
}
```
### Example No.184

### Element Text Equal Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    Locator = "CssSelector",
    OnElement = "div#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setLocator("CssSelector")
    .setOnElement("div#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    locator: "CssSelector",
    onElement: "div#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```
### Example No.185

### Element Text Equal Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.186

### Element Text Equal Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.187

### Element Text Equal Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the element's text content to extract up to 10 characters into a capture group.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.188

### Element Text Equal Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the element's text content to extract up to 10 characters into a capture group.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.189

### Element Text Equal Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the element's text content to extract up to 10 characters into a capture group.
The assertion passes if the element text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.190

### Element Text Equal Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the element identified by the CssSelector `textarea#content` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes if the text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.191

### Element Text Equal Validation Using Xpath

Verifies that the computed text from the `value` attribute of the element identified by the XPath locator `//textarea[@id='content']` is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes if the text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.192

### Element Text Equal Validation Using Id

Verifies that the computed text from the `value` attribute of the element identified by the Id `content` is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
The assertion passes if the text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.193

### Element Text Equal Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the element identified by the CssSelector `textarea#content` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.194

### Element Text Equal Validation Using Xpath

Verifies that the computed text from the `value` attribute of the element identified by the XPath locator `//textarea[@id='content']` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.195

### Element Text Equal Validation Using Id

Verifies that the computed text from the `value` attribute of the element identified by the Id `content` is equal to the expected text 'Lorem ipsu'.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text exactly matches the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.196

### Element Text NotEqual Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is not equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    Locator = "CssSelector",
    OnElement = "div#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setLocator("CssSelector")
    .setOnElement("div#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    locator: "CssSelector",
    onElement: "div#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```
### Example No.197

### Element Text NotEqual Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is not equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.198

### Element Text NotEqual Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is not equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
The assertion passes if the element text does not exactly match the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.199

### Element Text NotEqual Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.200

### Element Text NotEqual Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.201

### Element Text NotEqual Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.202

### Element Text NotEqual Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.203

### Element Text NotEqual Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.204

### Element Text NotEqual Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not match the expected value exactly; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.205

### Element Text NotEqual Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not exactly match the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.206

### Element Text NotEqual Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not exactly match the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.207

### Element Text NotEqual Validation Using Id

Verifies that the computed text from the element identified by the Id `content` is not equal to the expected text 'Lorem ipsu'.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the text content to extract up to 10 characters into a capture group.
The assertion passes if the extracted text does not exactly match the expected value; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotEqual --Expected:Lorem ipsu}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.208

### Element Text Greater Validation Using CssSelector

Verifies that the numeric value extracted from the visible text content of the element identified by the CssSelector `div#content` is greater than the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```
### Example No.209

### Element Text Greater Validation Using Xpath

Verifies that the numeric value extracted from the visible text content of the element identified by the XPath locator `//div[@id='content']` is greater than the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    onElement: "//div[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.210

### Element Text Greater Validation Using Id

Verifies that the numeric value extracted from the visible text content of the element identified by the Id `content` is greater than the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.211

### Element Text Greater Validation Using CssSelector

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the CssSelector `textarea#content` is greater than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the text content to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```
### Example No.212

### Element Text Greater Validation Using Xpath

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the XPath locator `//textarea[@id='content']` is greater than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the text content to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.213

### Element Text Greater Validation Using Id

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the Id `content` is greater than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the text content to extract a numeric value.
The assertion passes if the extracted numeric value is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Greater --Expected:42}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Greater --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.214

### Element Text GreaterEqual Validation Using CssSelector

Verifies that the numeric value extracted from the visible text content of the element identified by the CssSelector `div#content` is greater than or equal to the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```
### Example No.215

### Element Text GreaterEqual Validation Using Xpath

Verifies that the numeric value extracted from the visible text content of the element identified by the XPath locator `//div[@id='content']` is greater than or equal to the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    onElement: "//div[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.216

### Element Text GreaterEqual Validation Using Id

Verifies that the numeric value extracted from the visible text content of the element identified by the Id `content` is greater than or equal to the expected value 42.
The visible text content is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.217

### Element Text GreaterEqual Validation Using CssSelector

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the CssSelector `textarea#content` is greater than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```
### Example No.218

### Element Text GreaterEqual Validation Using Xpath

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the XPath locator `//textarea[@id='content']` is greater than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.219

### Element Text GreaterEqual Validation Using Id

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the Id `content` is greater than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:GreaterEqual --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.220

### Element Text Lower Validation Using CssSelector

Verifies that the numeric value extracted from the visible text content of the element identified by the CssSelector `div#content` is lower than the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```
### Example No.221

### Element Text Lower Validation Using Xpath

Verifies that the numeric value extracted from the visible text content of the element identified by the XPath locator `//div[@id='content']` is lower than the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    onElement: "//div[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.222

### Element Text Lower Validation Using Id

Verifies that the numeric value extracted from the visible text content of the element identified by the Id `content` is lower than the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.223

### Element Text Lower Validation Using CssSelector

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the CssSelector `textarea#content` is lower than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```
### Example No.224

### Element Text Lower Validation Using Xpath

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the XPath locator `//textarea[@id='content']` is lower than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.225

### Element Text Lower Validation Using Id

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the Id `content` is lower than the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Lower --Expected:42}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Lower --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.226

### Element Text LowerEqual Validation Using CssSelector

Verifies that the numeric value extracted from the visible text content of the element identified by the CssSelector `div#content` is lower than or equal to the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "\d+"
}
```
### Example No.227

### Element Text LowerEqual Validation Using Xpath

Verifies that the numeric value extracted from the visible text content of the element identified by the XPath locator `//div[@id='content']` is lower than or equal to the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    onElement: "//div[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.228

### Element Text LowerEqual Validation Using Id

Verifies that the numeric value extracted from the visible text content of the element identified by the Id `content` is lower than or equal to the expected value 42.
The visible text is processed using the regular expression `\d+` to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.229

### Element Text LowerEqual Validation Using CssSelector

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the CssSelector `textarea#content` is lower than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "\d+"
}
```
### Example No.230

### Element Text LowerEqual Validation Using Xpath

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the XPath locator `//textarea[@id='content']` is lower than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "\d+"
}
```
### Example No.231

### Element Text LowerEqual Validation Using Id

Verifies that the numeric value extracted from the text of the `value` attribute of the textarea element identified by the Id `content` is lower than or equal to the expected value 42.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `\d+` is applied to the attribute text to extract a numeric value.
The assertion passes if the extracted numeric value is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:LowerEqual --Expected:42}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "\d+"
}
```
### Example No.232

### Element Text Match Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a match.
The assertion passes only if the element text matches the pattern; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    Locator = "CssSelector",
    OnElement = "div#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("CssSelector")
    .setOnElement("div#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    locator: "CssSelector",
    onElement: "div#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```
### Example No.233

### Element Text Match Validation Using Xpath

Verifies that the computed text from the element identified by the XPath locator `//div[@id='content']` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a match.
The assertion passes only if the element text matches the pattern; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.234

### Element Text Match Validation Using Id

Verifies that the computed text from the element identified by the Id `content` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a match.
The assertion passes only if the element text matches the pattern; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.235

### Element Text Match Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted text to test for an exact match.
The assertion passes only if the extracted text matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.236

### Element Text Match Validation Using Xpath

Verifies that the computed text from the element identified by the Xpath locator `//div[@id='content']` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted text to test for an exact match.
The assertion passes only if the extracted text matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.237

### Element Text Match Validation Using Id

Verifies that the computed text from the element identified by the Id `content` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted text to test for an exact match.
The assertion passes only if the extracted text matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.238

### Element Text Match Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the textarea element identified by the CssSelector `textarea#content` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.239

### Element Text Match Validation Using Xpath

Verifies that the computed text from the `value` attribute of the textarea element identified by the Xpath locator `//textarea[@id='content']` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.240

### Element Text Match Validation Using Id

Verifies that the computed text from the `value` attribute of the textarea element identified by the Id `content` matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.241

### Element Text Match Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the textarea element identified by the CssSelector `textarea#content` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for an exact match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.242

### Element Text Match Validation Using Xpath

Verifies that the computed text from the `value` attribute of the textarea element identified by the Xpath locator `//textarea[@id='content']` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for an exact match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.243

### Element Text Match Validation Using Id

Verifies that the computed text from the `value` attribute of the textarea element identified by the Id `content` matches the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for an exact match.
The assertion passes only if the text from the `value` attribute matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:Match --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.244

### Element Text NotMatch Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a non-match.
The assertion passes only if the text does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    Locator = "CssSelector",
    OnElement = "div#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("CssSelector")
    .setOnElement("div#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    locator: "CssSelector",
    onElement: "div#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onElement": "div#content"
}
```
### Example No.245

### Element Text NotMatch Validation Using Xpath

Verifies that the computed text from the element identified by the Xpath locator `//div[@id='content']` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a non-match.
The assertion passes only if the text does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    OnElement = "//div[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setOnElement("//div[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    onElement: "//div[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "onElement": "//div[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "onElement": "//div[@id='content']"
}
```
### Example No.246

### Element Text NotMatch Validation Using Id

Verifies that the computed text from the element identified by the Id `content` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the visible text to test for a non-match.
The assertion passes only if the text does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    Locator = "Id",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("Id")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    locator: "Id",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onElement": "content"
}
```
### Example No.247

### Element Text NotMatch Validation Using CssSelector

Verifies that the computed text from the element identified by the CssSelector `div#content` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the extracted 10-character capture group does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    Locator = "CssSelector",
    OnElement = "div#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setLocator("CssSelector")
    .setOnElement("div#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    locator: "CssSelector",
    onElement: "div#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onElement": "div#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.248

### Element Text NotMatch Validation Using Xpath

Verifies that the computed text from the element identified by the Xpath locator `//div[@id='content']` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the extracted 10-character capture group does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    OnElement = "//div[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setOnElement("//div[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    onElement: "//div[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "onElement": "//div[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.249

### Element Text NotMatch Validation Using Id

Verifies that the computed text from the element identified by the Id `content` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the element's visible text content, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the visible text to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the extracted 10-character capture group does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    Locator = "Id",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setLocator("Id")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    locator: "Id",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.250

### Element Text NotMatch Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the textarea element identified by the CssSelector `textarea#content` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content"
}
```
### Example No.251

### Element Text NotMatch Validation Using Xpath

Verifies that the computed text from the `value` attribute of the textarea element identified by the Xpath locator `//textarea[@id='content']` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']"
}
```
### Example No.252

### Element Text NotMatch Validation Using Id

Verifies that the computed text from the `value` attribute of the textarea element identified by the Id `content` does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the text from the `value` attribute to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content"
}
```
### Example No.253

### Element Text NotMatch Validation Using CssSelector

Verifies that the computed text from the `value` attribute of the textarea element identified by the CssSelector `textarea#content` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "textarea#content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("textarea#content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "textarea#content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "textarea#content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.254

### Element Text NotMatch Validation Using Xpath

Verifies that the computed text from the `value` attribute of the textarea element identified by the Xpath locator `//textarea[@id='content']` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    OnAttribute = "value",
    OnElement = "//textarea[@id='content']",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setOnAttribute("value")
    .setOnElement("//textarea[@id='content']")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    onAttribute: "value",
    onElement: "//textarea[@id='content']",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "onAttribute": "value",
    "onElement": "//textarea[@id='content']",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.255

### Element Text NotMatch Validation Using Id

Verifies that the computed text from the `value` attribute of the textarea element identified by the Id `content` does not match the expected pattern `^Lorem ipsu$`.
The validation is based solely on the text from the `value` attribute, excluding any HTML markup or tags.
A regular expression `(?s)^(.{0,10})` is applied to the `value` attribute to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the text from the `value` attribute does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    Locator = "Id",
    OnAttribute = "value",
    OnElement = "content",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setLocator("Id")
    .setOnAttribute("value")
    .setOnElement("content")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    locator: "Id",
    onAttribute: "value",
    onElement: "content",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:ElementText --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "locator": "Id",
    "onAttribute": "value",
    "onElement": "content",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.256

### Page Title Equal Validation

Verifies that the computed page title is equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the page title, excluding any HTML markup or tags.
The assertion passes only if the page title exactly matches the expected text; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
}
```
### Example No.257

### Page Title Equal Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the computed page title, after extracting up to 10 characters, matches the expected text 'Lorem ipsu'.
A regular expression `(?s)^(.{0,10})` is applied to the page title to extract up to 10 characters into a capture group.
The assertion passes only if the extracted 10-character capture group exactly matches 'Lorem ipsu'; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsu}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsu}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsu}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsu}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Equal --Expected:Lorem ipsu}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.258

### Page Title NotEqual Validation

Verifies that the computed page title is not equal to the expected text 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.'.
The validation is based solely on the page title, excluding any HTML markup or tags.
The assertion passes only if the page title differs from the expected text; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsum dolor sit amet, consectetur adipiscing elit. 42.}}"
}
```
### Example No.259

### Page Title NotEqual Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the computed page title, after extracting up to 10 characters, does not equal the expected text 'Lorem ipsu'.
A regular expression `(?s)^(.{0,10})` is applied to the page title to extract up to 10 characters into a capture group.
The assertion passes only if that extracted 10-character capture group does not equal 'Lorem ipsu'; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsu}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsu}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsu}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsu}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotEqual --Expected:Lorem ipsu}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.260

### Page Title Greater Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the numeric value extracted from the page title is greater than the expected value 42.
A regular expression `\d+` is applied to the page title to extract the first numeric sequence into a capture group.
The assertion passes only if that extracted number is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Greater --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Greater --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Greater --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.261

### Page Title Greater Equal Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the numeric value extracted from the page title is greater than or equal to the expected value 42.
A regular expression `\d+` is applied to the page title to extract the first numeric sequence into a capture group.
The assertion passes only if that extracted number is greater than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:GreaterEqual --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:GreaterEqual --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:GreaterEqual --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:GreaterEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:GreaterEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.262

### Page Title Lower Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the numeric value extracted from the page title is lower than the expected value 42.
A regular expression `\d+` is applied to the page title to extract the first numeric sequence into a capture group.
The assertion passes only if that extracted number is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Lower --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Lower --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Lower --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Lower --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Lower --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.263

### Page Title Lower Equal Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the numeric value extracted from the page title is lower than or equal to the expected value 42.
A regular expression `\d+` is applied to the page title to extract the first numeric sequence into a capture group.
The assertion passes only if that extracted number is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:LowerEqual --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:LowerEqual --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:LowerEqual --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:LowerEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:LowerEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.264

### Page Title Match Validation

Verifies that the computed page title matches the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the page title, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the page title to test for a match.
The assertion passes only if the page title matches the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsum dolor.*}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsum dolor.*}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsum dolor.*}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsum dolor.*}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsum dolor.*}}"
}
```
### Example No.265

### Page Title Match Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the computed page title, after extracting up to 10 characters, matches the expected pattern `^Lorem ipsu$`.
A regular expression `(?s)^(.{0,10})` is applied to the page title to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for an exact match.
The assertion passes only if the extracted 10-character capture group matches the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsu$}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsu$}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsu$}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsu$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:Match --Expected:^Lorem ipsu$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.266

### Page Title NotMatch Validation

Verifies that the computed page title does not match the expected pattern `^Lorem ipsum dolor.*`.
The validation is based solely on the page title, excluding any HTML markup or tags.
A regular expression `^Lorem ipsum dolor.*` is applied to the page title to test for a non-match.
The assertion passes only if the page title does not match the pattern `^Lorem ipsum dolor.*`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsum dolor.*}}"
}
```
### Example No.267

### Page Title NotMatch Validation With Extraction

The validation is based solely on the page title, excluding any HTML markup or tags.
Verifies that the computed page title, after extracting up to 10 characters, does not match the expected pattern `^Lorem ipsu$`.
A regular expression `(?s)^(.{0,10})` is applied to the page title to extract up to 10 characters into a capture group.
A regular expression `^Lorem ipsu$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the extracted 10-character capture group does not match the pattern `^Lorem ipsu$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsu$}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageTitle --Operator:NotMatch --Expected:^Lorem ipsu$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.268

### Page URL Equal Validation

Verifies that the current page URL is equal to the expected URL `https://example42.com/page/`.
The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
The assertion passes only if the page URL exactly matches `https://example42.com/page/`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://example42.com/page/}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Equal --Expected:https://example42.com/page/}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://example42.com/page/}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://example42.com/page/}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://example42.com/page/}}"
}
```
### Example No.269

### Page URL Equal Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the current page URL, after extracting up to 10 characters, matches the expected value `https://ex`.
A regular expression `(?s)^(.{0,10})` is applied to the page URL to extract up to 10 characters into a capture group.
The assertion passes only if that extracted 10-character capture group exactly matches `https://ex`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://ex}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Equal --Expected:https://ex}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://ex}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://ex}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Equal --Expected:https://ex}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.270

### Page URL NotEqual Validation

Verifies that the current page URL is not equal to the expected URL `https://example42.com/page/`.
The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
The assertion passes only if the page URL differs from `https://example42.com/page/`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://example42.com/page/}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://example42.com/page/}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://example42.com/page/}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://example42.com/page/}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://example42.com/page/}}"
}
```
### Example No.271

### Page URL NotEqual Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the current page URL, after extracting up to 10 characters, does not match the expected value `https://ex`.
A regular expression `(?s)^(.{0,10})` is applied to the page URL to extract up to 10 characters into a capture group.
The assertion passes only if the extracted 10-character capture group does not match `https://ex`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://ex}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://ex}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://ex}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://ex}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotEqual --Expected:https://ex}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.272

### Page URL Greater Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the numeric value extracted from the page URL is greater than the expected value 42.
A regular expression `\d+` is applied to the page URL to extract the first numeric sequence into a capture group.
The assertion passes only if the extracted number is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.273

### Page URL Greater Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the numeric value extracted from the page URL is greater than the expected value 42.
A regular expression `\d+` is applied to the page URL to extract the first numeric sequence into a capture group.
The assertion passes only if the extracted number is greater than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Greater --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.274

### Page URL Lower Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the numeric value extracted from the page URL is lower than the expected value 42.
A regular expression `\d+` is applied to the page URL to extract the first numeric sequence into a capture group.
The assertion passes only if the extracted number is lower than 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Lower --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Lower --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Lower --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Lower --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Lower --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.275

### Page URL LowerEqual Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected value.
Verifies that the numeric value extracted from the page URL is lower than or equal to the expected value 42.
A regular expression `\d+` is applied to the page URL to extract the first numeric sequence into a capture group.
The assertion passes only if the extracted number is lower than or equal to 42; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:LowerEqual --Expected:42}}",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:LowerEqual --Expected:42}}")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:LowerEqual --Expected:42}}",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:LowerEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:LowerEqual --Expected:42}}",
    "regularExpression": "\d+"
}
```
### Example No.276

### Page URL Match Validation

Verifies that the current page URL matches the expected pattern `^https://example42.com/page/$`.
The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected pattern.
A regular expression `^https://example42.com/page/$` is applied to the page URL to test for a match.
The assertion passes only if the page URL matches the pattern `^https://example42.com/page/$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://example42.com/page/$}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Match --Expected:^https://example42.com/page/$}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://example42.com/page/$}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://example42.com/page/$}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://example42.com/page/$}}"
}
```
### Example No.277

### Page URL Match Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected pattern.
Verifies that the current page URL, after extracting up to 10 characters, matches the expected pattern `^https://ex$`.
A regular expression `(?s)^(.{0,10})` is applied to the page URL to extract up to 10 characters into a capture group.
A regular expression `^https://ex$` is then applied to the extracted 10-character capture group to test for an exact match.
The assertion passes only if the extracted 10-character capture group matches the pattern `^https://ex$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://ex$}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:Match --Expected:^https://ex$}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://ex$}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://ex$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:Match --Expected:^https://ex$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.278

### Page URL NotMatch Validation

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected pattern.
Verifies that the current page URL does not match the expected pattern `^https://example42.com/page/$`.
A regular expression `^https://example42.com/page/$` is applied to the page URL to test for a non-match.
The assertion passes only if the page URL does not match the pattern `^https://example42.com/page/$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://example42.com/page/$}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://example42.com/page/$}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://example42.com/page/$}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://example42.com/page/$}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://example42.com/page/$}}"
}
```
### Example No.279

### Page URL NotMatch Validation With Extraction

The validation is based solely on the page URL, excluding any URL fragments or query parameters unless explicitly part of the expected pattern.
Verifies that the current page URL, after extracting up to 10 characters, does not match the expected pattern `^https://ex$`.
A regular expression `(?s)^(.{0,10})` is applied to the page URL to extract up to 10 characters into a capture group.
A regular expression `^https://ex$` is then applied to the extracted 10-character capture group to test for a non-match.
The assertion passes only if the extracted 10-character capture group does not match the pattern `^https://ex$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://ex$}}",
    RegularExpression = "(?s)^(.{0,10})"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://ex$}}")
    .setRegularExpression("(?s)^(.{0,10})");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://ex$}}",
    regularExpression: "(?s)^(.{0,10})"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://ex$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:^https://ex$}}",
    "regularExpression": "(?s)^(.{0,10})"
}
```
### Example No.280

### Window Count Equal Validation

Verifies that the computed number of open browser windows is equal to the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows is exactly 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Equal --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Equal --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Equal --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Equal --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Equal --Expected:1}}"
}
```
### Example No.281

### Window Count NotEqual Validation

Verifies that the computed number of open browser windows is not equal to the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows differs from 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:NotEqual --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotEqual --Expected:1}}"
}
```
### Example No.282

### Window Count Greater Validation

Verifies that the computed number of open browser windows is greater than the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows is greater than 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Greater --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Greater --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Greater --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Greater --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Greater --Expected:1}}"
}
```
### Example No.283

### Window Count GreaterEqual Validation

Verifies that the computed number of open browser windows is greater than or equal to the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows is greater than or equal to 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:GreaterEqual --Expected:1}}"
}
```
### Example No.284

### Window Count LowerEqual Validation

Verifies that the computed number of open browser windows is lower than or equal to the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows is lower than or equal to 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:LowerEqual --Expected:1}}"
}
```
### Example No.285

### Window Count Lower Validation

Verifies that the computed number of open browser windows is lower than the expected value 1.
The validation is based solely on the count of open browser windows.
The assertion passes only if the number of open windows is lower than 1; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Lower --Expected:1}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Lower --Expected:1}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Lower --Expected:1}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Lower --Expected:1}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Lower --Expected:1}}"
}
```
### Example No.286

### Window Count Match Validation

Verifies that the computed number of open browser windows, when converted to a string, matches the expected pattern `^1\d+?$`.
The validation is based solely on the count of open browser windows, converted to a string.
A regular expression `^1\d+?$` is applied to the string representation of the window count to test for a match.
The assertion passes only if the string representation of the window count matches the pattern `^1\d+?$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:Match --Expected:^1\d+?$}}",
    RegularExpression = "^1\d+?$"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:Match --Expected:^1\d+?$}}")
    .setRegularExpression("^1\d+?$");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:Match --Expected:^1\d+?$}}",
    regularExpression: "^1\d+?$"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Match --Expected:^1\d+?$}}",
    "regularExpression": "^1\d+?$"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:Match --Expected:^1\d+?$}}",
    "regularExpression": "^1\d+?$"
}
```
### Example No.287

### Window Count NotMatch Validation

Verifies that the computed number of open browser windows, when converted to a string, does not match the expected pattern `^1\d+?$`.
The validation is based solely on the count of open browser windows, converted to a string.
A regular expression `^1\d+?$` is applied to the string representation of the window count to test for a non-match.
The assertion passes only if the string representation of the window count does not match the pattern `^1\d+?$`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:WindowCount --Operator:NotMatch --Expected:^1\d+?$}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:WindowCount --Operator:NotMatch --Expected:^1\d+?$}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:WindowCount --Operator:NotMatch --Expected:^1\d+?$}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotMatch --Expected:^1\d+?$}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:WindowCount --Operator:NotMatch --Expected:^1\d+?$}}"
}
```
### Example No.288

### Text Equal Validation Using Session Parameter Value

Verifies that the text value returned by the session parameter `MyParameter` matches the expected value `ExpectedValue`.
The validation uses the full text value returned by the session parameter, including any whitespace or formatting.
The assertion passes only if that parameter value exactly matches `ExpectedValue`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:ExpectedValue}}",
    OnElement = "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Equal --Expected:ExpectedValue}}")
    .setOnElement("{{$Get-Parameter --Name:MyParameter --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Equal --Expected:ExpectedValue}}",
    onElement: "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:ExpectedValue}}",
    "onElement": "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:ExpectedValue}}",
    "onElement": "{{$Get-Parameter --Name:MyParameter --Scope:Session}}"
}
```
### Example No.289

### Text NotEqual Validation With Static Text

Verifies that the provided text value `Static Text` does not equal the expected value `Static Text`.
The validation uses the full provided text string, including any whitespace or formatting.
The assertion passes only if the provided text value differs from `Static Text`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:NotEqual --Expected:Static Text}}",
    OnElement = "Static Text"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:NotEqual --Expected:Static Text}}")
    .setOnElement("Static Text");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:NotEqual --Expected:Static Text}}",
    onElement: "Static Text"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:NotEqual --Expected:Static Text}}",
    "onElement": "Static Text"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:NotEqual --Expected:Static Text}}",
    "onElement": "Static Text"
}
```
### Example No.290

### Text Match Validation With Static Text

Verifies that the provided text value `123-45-6789` matches the expected pattern `\d{3}-\d{2}-\d{4}`.
The validation uses the full provided text string, including any whitespace or formatting.
A regular expression `\d{3}-\d{2}-\d{4}` is applied to the provided text to test for a match.
The assertion passes only if the provided text value matches the pattern `\d{3}-\d{2}-\d{4}`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "123-45-6789"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("123-45-6789");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "123-45-6789"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```
### Example No.291

### Text NotMatch Validation With Static Text

Verifies that the provided text value `123-45-6789` does not match the expected pattern `\d{3}-\d{2}-\d{4}`.
The validation uses the full provided text string, including any whitespace or formatting.
A regular expression `\d{3}-\d{2}-\d{4}` is applied to the provided text to test for a non-match.
The assertion passes only if the provided text value does not match the pattern `\d{3}-\d{2}-\d{4}`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "123-45-6789"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("123-45-6789");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "123-45-6789"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "123-45-6789"
}
```
### Example No.292

### Text Greater Validation With Static Text

Verifies that the provided text value `20` is greater than the expected value 10.
The validation uses the full provided text string, interpreting it as a numeric value.
The assertion passes only if that numeric value is greater than 10; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Greater --Expected:10}}",
    OnElement = "20"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Greater --Expected:10}}")
    .setOnElement("20");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Greater --Expected:10}}",
    onElement: "20"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Greater --Expected:10}}",
    "onElement": "20"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Greater --Expected:10}}",
    "onElement": "20"
}
```
### Example No.293

### Text Lower Validation With Static Text

Verifies that the provided text value `5` is lower than the expected value 10.
The validation uses the full provided text string, interpreting it as a numeric value.
The assertion passes only if that numeric value is lower than 10; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Lower --Expected:10}}",
    OnElement = "5"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Lower --Expected:10}}")
    .setOnElement("5");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Lower --Expected:10}}",
    onElement: "5"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Lower --Expected:10}}",
    "onElement": "5"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Lower --Expected:10}}",
    "onElement": "5"
}
```
### Example No.294

### Text GreaterEqual Validation With Static Text

Verifies that the provided text value `10` is greater than or equal to the expected value 10.
The validation uses the full provided text string, interpreting it as a numeric value.
The assertion passes only if that numeric value is greater than or equal to 10; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:GreaterEqual --Expected:10}}",
    OnElement = "10"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:GreaterEqual --Expected:10}}")
    .setOnElement("10");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:GreaterEqual --Expected:10}}",
    onElement: "10"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:GreaterEqual --Expected:10}}",
    "onElement": "10"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:GreaterEqual --Expected:10}}",
    "onElement": "10"
}
```
### Example No.295

### Text LowerEqual Validation With Static Text

Verifies that the provided text value `10` is lower than or equal to the expected value 10.
The validation uses the full provided text string, interpreting it as a numeric value.
The assertion passes only if that numeric value is lower than or equal to 10; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:LowerEqual --Expected:10}}",
    OnElement = "10"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:LowerEqual --Expected:10}}")
    .setOnElement("10");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:LowerEqual --Expected:10}}",
    onElement: "10"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:LowerEqual --Expected:10}}",
    "onElement": "10"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:LowerEqual --Expected:10}}",
    "onElement": "10"
}
```
### Example No.296

### Text Equal Validation With Extraction

The validation uses the full provided text string, including any whitespace or formatting.
Verifies that the provided text value `1000`, after applying a regular expression, exactly matches the expected value `100`.
A regular expression `\d{3}` is applied to the provided text to extract a three‑digit numeric sequence into a capture group.
The assertion passes only if that extracted capture group matches the pattern `100`; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:100}}",
    OnElement = "1000",
    RegularExpression = "\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Text --Operator:Equal --Expected:100}}")
    .setOnElement("1000")
    .setRegularExpression("\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Text --Operator:Equal --Expected:100}}",
    onElement: "1000",
    regularExpression: "\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:100}}",
    "onElement": "1000",
    "regularExpression": "\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Text --Operator:Equal --Expected:100}}",
    "onElement": "1000",
    "regularExpression": "\d{3}"
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

Specifies the exact expression to use when asserting a result.
It tells the system what value or pattern to evaluate.
This expression guides whether the assertion passes or fails.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines how to locate the element on the screen before running the assertion.
Choices include Xpath, CSS, or ID.
Xpath is used by default.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which part of the element to assert.
Examples include the element's text, link address, or stored value.
The assertion focuses on only that part.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which element to use in the assertion.
It identifies where that element is located in the page or app.
The assertion then runs on that element.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?si).*           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Applies a pattern to element values to test or extract specific parts.
Use it to focus on a substring before the assertion runs.
This makes checks easier by narrowing down to the exact text you need.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

Tells the system which type of assertion to run.
This list updates itself when new assertions become available.
You do not need to make changes by hand.
This keeps your setup up to date with the latest assertions.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the value you expect the system to find.
The system asserts this against what really happened.
Matching values make the assertion pass.
Different values make the assertion fail.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Chooses which comparison the system uses in an assertion.
It pulls all options automatically, so you never have to update it yourself.
Common comparisons include Lower, Equal, and NotEqual.

## Scope

* Any