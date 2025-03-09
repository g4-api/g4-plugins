# Resolve Math Expression (Resolve-MathExpression)

[Table of Content](../Home.md)  

~46 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

In the context of Robotic Process Automation (RPA) and automation testing, the ResolveMathExpression plugin serves a crucial role in resolving mathematical expressions dynamically.

### Purpose

The primary purpose of the ResolveMathExpression plugin is to dynamically resolve mathematical expressions, allowing for flexible computation within automation workflows. By supporting a variety of mathematical operations, sorting options, rounding, and absolute value functionality, this plugin enhances the capabilities of automated systems to perform complex calculations.

### Key Features

| Feature                        | Description                                                                                                        |
|--------------------------------|--------------------------------------------------------------------------------------------------------------------|
| Dynamic Expression Resolution  | Resolve mathematical expressions dynamically based on input parameters.                                            |
| Support for Various Operations | Perform addition, subtraction, multiplication, division, exponentiation, and modulus operations.                   |
| Flexible Input Handling        | Accept input parameters for numerical values, sorting options, rounding precision, and absolute value computation. |

### Usages in RPA

| Usage                             | Description                                                                                                      |
|-----------------------------------|------------------------------------------------------------------------------------------------------------------|
| Mathematical Computations         | Perform complex mathematical computations within RPA processes.                                                  |
| Dynamic Input Handling            | Dynamically calculate numerical values based on changing conditions or input parameters.                         |
| Enhanced Calculation Capabilities | Enhance the calculation capabilities of automated systems by supporting a wide range of mathematical operations. |

### Usages in Automation Testing

| Usage                        | Description                                                                                      |
|------------------------------|--------------------------------------------------------------------------------------------------|
| Data Validation              | Validate numerical calculations and results within automation test scripts.                      |
| Dynamic Test Case Generation | Generate test cases with dynamically calculated input values.                                    |
| Enhanced Test Coverage       | Increase test coverage by incorporating mathematical computations into automated test scenarios. |

### Conclusion

The ResolveMathExpression plugin provides essential functionality for dynamically resolving mathematical expressions within RPA and automation testing workflows. By supporting a variety of operations and input options, it enhances the computational capabilities of automated systems, contributing to the efficiency and accuracy of automation initiatives.

## Examples

### Example No.1

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                   |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                          |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                            |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                       |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to calculate the subtraction of 10 from 2 and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.2

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                   |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                          |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                            |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                       |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to calculate the division of 10 by 2 and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.3

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                   |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                          |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                            |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                       |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to calculate the modulus of 10 divided by 3 and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.4

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                   |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                          |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                            |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                       |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to calculate the multiplication of 10 by 2 and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.5

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression after sorting the input numbers in ascending order, and then send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                                                                      |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                             |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically after sorting the input numbers in ascending order. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                               |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                          |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to first sort the input numbers (10, 3) in ascending order, calculate the modulus of 3 divided by 10, and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.6

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression after sorting the input numbers in descending order, and then send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                                                                       |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                              |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically after sorting the input numbers in descending order. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                           |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to first sort the input numbers (3, 10) in descending order, calculate the modulus of 10 divided by 3, and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.7

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of raising a number to a power and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                                                    |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                           |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically for raising 10 to the power of 2. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                             |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                        |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to raise 10 to the power of 2, and send the result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.8

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression, round it to 2 decimal places, and send it as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                                                                                    |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                                           |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically for dividing 10 by 3 and rounding the result to 2 decimal places. The calculated result will be sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                             |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                        |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to divide 10 by 3, round the result to 2 decimal places, and send the rounded result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.9

This example demonstrates the usage of the `ResolveMathExpression` plugin to dynamically calculate the result of a mathematical expression, subtracting 10 from 2, and then taking the absolute value of the result. The absolute value is then sent as keystrokes using the `SendKeys` plugin.

| Field      | Description                                                                                                                                                                                                                         |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                                                |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically, subtracting 10 from 2, and then taking the absolute value of the result. The absolute value is then sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                                  |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                             |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to subtract 10 from 2, take the absolute value of the result, and send the absolute value as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.10

This example demonstrates the usage of nested `ResolveMathExpression` plugins to dynamically calculate the result of a mathematical expression and use it as an input parameter for another expression. Here, we perform addition and then division.

| Field      | Description                                                                                                                                                                                                                                                              |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                                                                                     |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to first calculate the result of adding 2 and 3, and then use the result as the `X` parameter for another `ResolveMathExpression` plugin to divide by 5. The final result of the division is sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                                                                       |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                                                                  |

This example instructs the automation system to utilize nested `ResolveMathExpression` plugins to first add 2 and 3, then divide the result by 5, and send the final result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:+}} --Y:5 --Operation:/}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:+}} --Y:5 --Operation:/}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:+}} --Y:5 --Operation:/}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:+}} --Y:5 --Operation:/}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:+}} --Y:5 --Operation:/}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.11

This example demonstrates the usage of nested `ResolveMathExpression` plugins to dynamically calculate the result of a mathematical expression and use it as an input parameter for another expression. Here, we perform subtraction and then multiplication.

| Field      | Description                                                                                                                                                                                                                                                                             |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                                                                                                    |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to first calculate the result of subtracting 5 from 10, and then use the result as the `X` parameter for another `ResolveMathExpression` plugin to multiply by 3. The final result of the multiplication is sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                                                                                      |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                                                                                 |

This example instructs the automation system to utilize nested `ResolveMathExpression` plugins to first subtract 5 from 10, then multiply the result by 3, and send the final result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.12

This example demonstrates the usage of nested `ResolveMathExpression` plugins to dynamically calculate the result of a mathematical expression and use it as an input parameter for another expression. Here, we perform exponentiation and then modulus.

| Field      | Description                                                                                                                                                                                                                                                                                                |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes.                                                                                                                                                                                       |
| argument   | Specifies the use of the `ResolveMathExpression` plugin to first calculate the result of raising 2 to the power of 3, and then use the result as the `X` parameter for another `ResolveMathExpression` plugin to find the modulus with 5. The final result of the modulus operation is sent as keystrokes. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                                                                                                         |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                                                                                                    |

This example instructs the automation system to utilize nested `ResolveMathExpression` plugins to first raise 2 to the power of 3, then find the modulus of the result with 5, and send the final result as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:^}} --Y:5 --Operation:%}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:^}} --Y:5 --Operation:%}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:^}} --Y:5 --Operation:%}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:^}} --Y:5 --Operation:%}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:2 --Y:3 --Operation:^}} --Y:5 --Operation:%}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```
### Example No.13

This example demonstrates the usage of the `ResolveMathExpression` plugin to calculate a mathematical expression dynamically, apply a regular expression pattern to extract the integer part of the result, and send the extracted information as keystrokes to a specific element on a web page.

| Field      | Description                                                                                                                                                                                                                                                        |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `ResolveMathExpression`. This signifies the action of resolving a mathematical expression.                                                                                                                 |
| argument   | Specifies the resolution of the mathematical expression '5.5 * 2.5' and the application of a regular expression pattern '\d+' to extract the integer part of the result. For example, `{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}`. |
| onElement  | Specifies the target element on which the keystrokes will be sent, which is a hypothetical element identified by its CSS selector.                                                                                                                                 |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example.                                                                                                                                                            |

This example instructs the automation system to utilize the `ResolveMathExpression` plugin to resolve the mathematical expression '5.5 * 2.5', apply a regular expression pattern '\d+' to extract the integer part of the result, and send the extracted information as keystrokes to the specified element identified by its CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}",
    Locator = "CssSelector",
    OnElement = ".result-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}")
    .setLocator("CssSelector")
    .setOnElement(".result-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}",
    locator: "CssSelector",
    onElement: ".result-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Resolve-MathExpression --X:5.5 --Y:2.5 --Operation:* --Pattern:\d+}}",
    "locator": "CssSelector",
    "onElement": ".result-field"
}
```

## Parameters

### Abs (Abs)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

The `Abs` switch, when included, instructs the `ResolveMathExpression` plugin to take the absolute value of the result of the mathematical operation.

### Asc (Asc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

The `Asc` switch, when included, instructs the `ResolveMathExpression` plugin to sort the input numbers in ascending order before performing the mathematical operation.

### Desc (Desc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

The `Desc` switch, when included, instructs the `ResolveMathExpression` plugin to sort the input numbers in descending order before performing the mathematical operation.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

The `Pattern` parameter specifies a regular expression pattern that is applied to the result of the mathematical expression. This pattern is used to extract specific information from the result before further processing.

### Round (Round)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The `Round` parameter specifies the number of decimal places to round the result of the mathematical expression to, if rounding is requested.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The `X` parameter represents one of the numerical values used in a mathematical expression. It serves as the first operand in arithmetic operations such as addition, subtraction, multiplication, division, exponentiation, and modulus.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The `Y` parameter represents one of the numerical values used in a mathematical expression. It serves as the second operand in arithmetic operations such as addition, subtraction, multiplication, division, exponentiation, and modulus.

## Scope

* Any