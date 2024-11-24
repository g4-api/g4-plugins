# New Random Number (New-RandomNumber)

[Table of Content](../Home.md)  

~84 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

The NewRandomNumber macro plugin generates a new random number within automation workflows, providing flexibility in generating random integer values within specified ranges.

### Purpose

The primary purpose of the NewRandomNumber macro plugin is to generate random integer values, allowing for dynamic data generation within automation workflows.

### Key Features

| Feature                  | Description                                                                                        |
|--------------------------|----------------------------------------------------------------------------------------------------|
| Random Number Generation | Generates random integer values within specified ranges.                                           |
| Automation Integration   | Integrates seamlessly with automation workflows, providing flexibility in generating dynamic data. |

### Usages in RPA

| Usage              | Description                                                                   |
|--------------------|-------------------------------------------------------------------------------|
| Data Generation    | Use generated random numbers for data population in RPA tasks.                |
| Conditional Logic  | Generate random values for conditional branching within automation workflows. |

### Usages in Automation Testing

| Usage              | Description                                                                    |
|--------------------|--------------------------------------------------------------------------------|
| Data-Driven Testing | Utilize random numbers as test data inputs for data-driven testing scenarios. |
| Boundary Testing    | Generate random values to test boundary conditions of software systems.       |

## Examples

### Example No.1

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random integer value within the specified range and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random integer value. For example, `{{$New-RandomNumber}}`.                                                |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random integer value as keystrokes to the specified element within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random integer value within the specified range and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                               |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                             |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random integer value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber}} --Scope:Session}}"
}
```
### Example No.3

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random number within the range of 100 (minimum value) and int.Max and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random number. For example, `{{$New-RandomNumber --MinValue:100}}`.                                        |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random number as keystrokes to the specified element within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MinValue:100}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MinValue:100}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MinValue:100}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.4

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random number within the range of 100 (minimum value) and int.Max and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                             |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                           |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random number value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin within the range of 100 (minimum value) and int.Max. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100}} --Scope:Session}}"
}
```
### Example No.5

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random number within the range of int.Min and 1000 (maximum value) and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random number. For example, `{{$New-RandomNumber --MaxValue:1000}}`.                                       |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random number as keystrokes to the specified element within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MaxValue:1000}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MaxValue:1000}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MaxValue:1000}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:1000}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:1000}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.6

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random number within the range of int.Min and 1000 (maximum value) and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                              |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                            |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random number value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin within the range of int.Min and 1000 (maximum value). The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000}} --Scope:Session}}"
}
```
### Example No.7

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value within the specified range and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random long integer value. For example, `{{$New-RandomNumber --NumberType:Long}}`.                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random long integer value as keystrokes to the specified element within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --NumberType:Long}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --NumberType:Long}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --NumberType:Long}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.8

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value within the specified range and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                      |
|------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                    |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random long integer value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Long}} --Scope:Session}}"
}
```
### Example No.9

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value with a minimum value of 100 and register it as a parameter named 'RandomNumber' with a session scope. The value will be within the range of 100 and the maximum value allowed for a long integer.

| Field      | Description                                                                                                                                                                                                                                                                                     |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                                   |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random long integer value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The minimum value is set to 100, and the maximum value will be the maximum value allowed for a long integer. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Long}} --Scope:Session}}"
}
```
### Example No.10

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value with a minimum value of 100 and send it as keystrokes to an element within an automation workflow. The value will be within the range of 100 and the maximum value allowed for a long integer.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random long integer value. For example, `{{$New-RandomNumber --MinValue:100 --NumberType:Long}}`.          |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random long integer value as keystrokes to the specified element within the automation workflow. The minimum value is set to 100, and the maximum value will be the maximum value allowed for a long integer.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MinValue:100 --NumberType:Long}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MinValue:100 --NumberType:Long}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MinValue:100 --NumberType:Long}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.11

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value with a maximum value of 1000 and register it as a parameter named 'RandomNumber' with a session scope. The value will be within the range of the minimum value allowed for a long integer and 1000.

| Field      | Description                                                                                                                                                                                                                                                                                      |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                                    |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random long integer value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The maximum value is set to 1000, and the minimum value will be the minimum value allowed for a long integer. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}} --Scope:Session}}"
}
```
### Example No.12

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value with a maximum value of 1000 and send it as keystrokes to an element within an automation workflow. The value will be within the range of the minimum value allowed for a long integer and 1000.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random long integer value. For example, `{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}`.         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random long integer value as keystrokes to the specified element within the automation workflow. The maximum value is set to 1000, and the minimum value will be the minimum value allowed for a long integer.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.13

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value within the specified range and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                                             |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                      |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                                            |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                                       |
| argument   | Specifies the generated random long integer value. For example, `{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}`. |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random long integer value as keystrokes to the specified element within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.14

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random long integer value within the specified range and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                                                                   |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                                                                 |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random long integer value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin within the specified range. The parameter is registered with a session scope, making it available throughout the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}} --Scope:Session}}"
}
```
### Example No.15

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value between 0 and 255 and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random byte value. For example, `{{$New-RandomNumber --NumberType:Byte}}`.                                 |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random byte value as keystrokes to the specified element within the automation workflow. The byte value generated will be between 0 and 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --NumberType:Byte}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --NumberType:Byte}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --NumberType:Byte}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.16

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value between 0 and 255 and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                              |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                            |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random byte value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The byte value generated will be between 0 and 255.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Byte}} --Scope:Session}}"
}
```
### Example No.17

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value between 100 and 150 and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random byte value. For example, `{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}`.   |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random byte value as keystrokes to the specified element within the automation workflow. The byte value generated will be between 100 and 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.18

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value between 100 and 150 and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                                            |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                                          |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random byte value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The byte value generated will be between 100 and 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
}
```
### Example No.19

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value greater than or equal to 100 and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random byte value. For example, `{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}`.                  |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random byte value as keystrokes to the specified element within the automation workflow. The byte value generated will be greater than or equal to 100.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.20

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value greater than or equal to 100 and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                             |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                           |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random byte value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The byte value generated will be greater than or equal to 100.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MinValue:100 --NumberType:Byte}} --Scope:Session}}"
}
```
### Example No.21

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value less than or equal to 150 and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random byte value. For example, `{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}`.                  |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random byte value as keystrokes to the specified element within the automation workflow. The byte value generated will be less than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.22

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random byte value less than or equal to 150 and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                             |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                           |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random byte value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The byte value generated will be less than or equal to 150.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}} --Scope:Session}}"
}
```
### Example No.23

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random float value between 0 and 1 (exclusive) and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random float value. For example, `{{$New-RandomNumber --NumberType:Float}}`.                               |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random float value as keystrokes to the specified element within the automation workflow. The float value generated will be between 0 and 1 (exclusive).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --NumberType:Float}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --NumberType:Float}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --NumberType:Float}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Float}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Float}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.24

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random float value between 0 and 1 (exclusive) and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                |
|------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                              |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random float value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The float value generated will be between 0 and 1 (exclusive).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Float}} --Scope:Session}}"
}
```
### Example No.25

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random double value between 0 and 1 (exclusive) and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated random double value. For example, `{{$New-RandomNumber --NumberType:Double}}`.                             |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated random double value as keystrokes to the specified element within the automation workflow. The double value generated will be between 0 and 1 (exclusive).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-RandomNumber --NumberType:Double}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-RandomNumber --NumberType:Double}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-RandomNumber --NumberType:Double}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Double}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-RandomNumber --NumberType:Double}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.26

This example demonstrates the usage of the `NewRandomNumber` macro plugin to generate a new random double value between 0 and 1 (exclusive) and register it as a parameter named 'RandomNumber' with a session scope.

| Field      | Description                                                                                                                                                                                                                                                                  |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This signifies the action of registering a parameter for use within the session.                                                                                                                |
| argument   | Specifies the usage of the `RegisterParameter` plugin with custom arguments to register a parameter named 'RandomNumber' with the generated random double value. For example, `{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}`. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register a parameter named 'RandomNumber' with the value generated by the `New-RandomNumber` macro plugin. The parameter is registered with a session scope, making it available throughout the session. The double value generated will be between 0 and 1 (exclusive).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:RandomNumber --Value:{{$New-RandomNumber --NumberType:Double}} --Scope:Session}}"
}
```

## Parameters

### Min Value (MinValue)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the minimum value for generating random numbers. If not specified, the default value is the minimum value of the integer data type.

### Max Value (MaxValue)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the maximum value for generating random numbers. If not specified, the default value is the maximum value of the integer data type.

### Number Type (NumberType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Integer           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of number to generate. If not specified, the default value is 'Integer'.

#### Values

##### Byte

Generates random byte values.
##### Double

Generates random double-precision floating-point values.
##### Float

Generates random single-precision floating-point values.
##### Integer

Generates random integer values.
##### Long

Generates random long integer values.
