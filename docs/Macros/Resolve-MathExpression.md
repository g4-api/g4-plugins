# Resolve Math Expression (Resolve-MathExpression)

[Table of Content](../Home.md)  

~46 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs calculations on numbers at runtime within automation workflows.
Supports addition, subtraction, multiplication, division, exponentiation, and modulus as operations.
Also provides sorting, rounding, and absolute-value options.
Numeric data is handled flexibly and accurately without external calculation tools.

### Key Features and Functionality

| Feature                       | Description                                                                           |
|-------------------------------|---------------------------------------------------------------------------------------|
| Dynamic Expression Resolution | Calculate expressions on the fly within automation steps.                             |
| Arithmetic Operations         | Support addition, subtraction, multiplication, division, exponentiation, and modulus. |
| Input Sorting                 | Arrange numbers in ascending or descending order before computing.                    |
| Rounding Precision            | Round results to a specified number of decimal places.                                |
| Absolute Value Option         | Return the non-negative value of calculation results.                                 |
| Pattern Extraction            | Apply a regex to extract parts of the result for further use.                         |

### Usages in RPA

| Use Case                 | Description                                                  |
|--------------------------|--------------------------------------------------------------|
| Real-Time Calculations   | Perform on-the-fly arithmetic within RPA processes.          |
| Dynamic Data Generation  | Compute values based on inputs that change during execution. |
| Conditional Flow Control | Use computed results to drive decision points in workflows.  |

### Usages in Automation Testing

| Use Case                  | Description                                                |
|---------------------------|------------------------------------------------------------|
| Test Data Generation      | Generate numeric inputs for test scenarios dynamically.    |
| Output Verification       | Validate expected numeric outcomes within automated tests. |
| Parameterized Test Inputs | Create test cases with calculated parameter values.        |

## Examples

### Example No.1

### Compute 2 minus 10 at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=2, Y=10, and Operation ‘-’ to compute 2 minus 10 at runtime, returning only the numeric result without side effects.  
Then have the `SendKeys` plugin consume that result and send it as keystrokes into the element matching the `.result-field` CSS selector.  

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

### Compute 10 divided by 2 at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=10, Y=2, and Operation ‘/’ to compute 10 divided by 2 at runtime, returning only the numeric result without side effects.  
Then have the `SendKeys` plugin consume that result and send it as keystrokes into the element matching the `.result-field` CSS selector.  

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

### Compute 10 modulo 3 at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=10, Y=3, and Operation ‘%’ to compute 10 modulo 3 at runtime, returning only the numeric result without side effects.
Then send that result using the `SendKeys` plugin into the element matching the `.result-field` CSS selector.

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

### Compute the product of 10 and 2 at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=10, Y=2, and Operation ‘*’ to compute 10 multiplied by 2 at runtime, returning only the numeric result without side effects.
Then send that result using the `SendKeys` plugin into the element matching the `.result-field` CSS selector.

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

### Compute the remainder of the smaller number modulo the larger number at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=10, Y=3, Operation ‘%’, and Asc flag to sort inputs ascending, compute 3 modulo 10 at runtime, and return only the numeric result without side effects.
Then send that result using the `SendKeys` plugin into the element matching the `.result-field` CSS selector.

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

### Compute the modulus of sorted inputs at runtime and send the result to a web element

Execute the `ResolveMathExpression` macro with X=10, Y=3, Operation ‘%’, and Asc flag to sort values in ascending order (3, 10), compute their modulus at runtime, and return only the numeric result without side effects.
Then send that result using the `SendKeys` plugin into the element matching the `.result-field` CSS selector.

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
### Example No.7

### Compute a number raised to a power and send the result to a web element

Use the `ResolveMathExpression` macro to raise 10 to the power of 2 at runtime, returning only the numeric result without side effects.  
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.  

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

### Compute a rounded division result and send it to a web element

Use the `ResolveMathExpression` macro to divide 10 by 3 at runtime, round to two decimal places, and return only the numeric result without side effects.
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

### Compute the absolute value of a subtraction result and send it to a web element

Use the `ResolveMathExpression` macro to subtract 10 from 2 at runtime, apply absolute to the result, and return only the numeric value without side effects.
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

### Compute a nested arithmetic expression and send the result to a web element

Use the `ResolveMathExpression` macro to add 2 and 3 at runtime, then divide the sum by 5, returning only the numeric result without side effects.
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

### Compute a nested subtraction and multiplication result and send it to a web element

Use the `ResolveMathExpression` macro to subtract 5 from 10 at runtime, then multiply that result by 3, returning only the numeric value without side effects.
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

### Compute a nested exponentiation and modulus result and send it to a web element

Use the `ResolveMathExpression` macro to raise 2 to the power of 3 at runtime, then compute the modulus of that result with 5, returning only the numeric value without side effects.
Then send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

### Extract the integer part of a multiplication result and send it to a web element

Use the `ResolveMathExpression` macro to multiply 5.5 by 2.5 at runtime and return only the numeric result without side effects.
Next, apply a regular expression `\d+` to extract the integer part of that result.
Finally, send that value as keystrokes into the element matching the `.result-field` CSS selector using the `SendKeys` plugin.

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

Abs instructs the plugin to return the absolute value of the computed result.
Using Abs ensures the output is always non-negative, regardless of the operation’s outcome.
This can be useful in workflows where only the magnitude of the result is relevant.

### Asc (Asc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Asc sorts the input numbers in ascending order before performing the calculation.
Sorting inputs with Asc can change the outcome of operations sensitive to order, such as subtraction or division.
Use Asc to guarantee numbers are always processed from smallest to largest.

### Desc (Desc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Desc sorts the input numbers in descending order before performing the calculation.
With Desc, numbers are always processed from largest to smallest, which can impact operations where order matters.
This is helpful for workflows that require prioritizing the largest values first.

### Operation (Operation)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | +                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Operation specifies the type of mathematical operation to perform on the input numbers.
Choosing an operation determines how X and Y will be combined in the calculation.
Supported operations include addition, subtraction, multiplication, division, exponentiation, and modulus.
Selecting the correct operation is essential for achieving the desired computational result.

#### Values

##### 

Add combines X and Y to produce their sum.
This operation is used when you want to calculate the total of two numbers.
##### 

Subtract finds the difference between X and Y.
Use this operation to determine how much one number exceeds or falls short of the other.
##### 

Multiply computes the product of X and Y.
Choose this to scale a number by another, such as calculating area or repeated addition.
##### 

Divide finds how many times Y fits into X or the ratio of X to Y.
This operation is used for distributing quantities or comparing proportions.
##### 

Exponentiate raises X to the power of Y.
Use this operation for exponential growth, scientific notation, or advanced calculations.
##### 

Modulus returns the remainder when X is divided by Y.
This operation is helpful for cyclic calculations or checking divisibility.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Pattern provides a regular expression to apply to the result of the mathematical operation.
This allows extraction of specific parts of the output for further processing.
Using Pattern can help isolate or validate the numeric result according to custom rules.

### Round (Round)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Round sets how many decimal places the final result should be rounded to.
Applying Round ensures the output has a consistent level of precision.
This can make results easier to read or compare in subsequent automation steps.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

X is the first number used in the mathematical expression.
It acts as the initial operand for operations like addition, subtraction, multiplication, division, exponentiation, and modulus.
Specifying X is required to define the starting point for the calculation.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Y is the second number used in the mathematical expression.
It serves as the next operand for operations such as addition, subtraction, multiplication, division, exponentiation, and modulus.
Supplying Y is essential for completing two-operand calculations.

## Scope

* Any