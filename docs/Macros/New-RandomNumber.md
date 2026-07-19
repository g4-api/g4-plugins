# New Random Number (New-RandomNumber)

[Table of Content](../Home.md)  

~84 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Generates random numbers within automation workflows on demand.
MinValue and MaxValue bound the output range; NumberType selects the numeric type — Byte, Integer, Long, Float, or Double.
Produces dynamic test data and drives conditional logic in RPA and automation testing.
Random number support is built directly into workflow rules, removing the need for external scripts.

### Key Features and Functionality

| Feature                  | Description                                                    |
|--------------------------|----------------------------------------------------------------|
| Random Number Generation | Generates random numbers within a user-defined range.          |
| Range Configuration      | Allows specifying MinValue and MaxValue to control limits.     |
| Number Type Selection    | Supports different types: Byte, Integer, Long, Float, Double.  |
| Workflow Integration     | Works directly in automation workflows without external tools. |

### Usages in RPA

| Use Case          | Description                                                       |
|-------------------|-------------------------------------------------------------------|
| Data Generation   | Populate RPA tasks with random numbers for data-driven processes. |
| Conditional Logic | Provide dynamic values for decision-making steps in workflows.    |

### Usages in Automation Testing

| Use Case            | Description                                                         |
|---------------------|---------------------------------------------------------------------|
| Data-Driven Testing | Use random values as inputs to test software with varied datasets.  |
| Boundary Testing    | Generate edge-case values to test system limits and error handling. |

## Examples

### Example No.1

### Generate and Send Random Number

Invoke `New-RandomNumber` to generate a random integer at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Number Parameter with Session Scope

Invoke `New-RandomNumber` to generate a random integer at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Number with Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` to generate a random integer between 100 and int.Max at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Number Parameter with Session Scope and Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` to generate a random integer between 100 and int.Max at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Number with Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:1000` to generate a random integer between int.Min and 1000 at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Number Parameter with Session Scope and Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:1000` to generate a random integer between int.Min and 1000 at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Long Integer

Invoke `New-RandomNumber` with `--NumberType:Long` to generate a random long integer at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated long integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Long Integer Parameter with Session Scope

Invoke `New-RandomNumber` with `--NumberType:Long` to generate a random long integer at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Register Random Long Integer Parameter with Session Scope and Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Long Integer with Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated long integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Long Integer Parameter with Session Scope and Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:1000` and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Long Integer with Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:1000` and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated long integer into the element identified by the CSS selector `#inputField`.  

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

### Generate and Send Random Long Integer with Specified Range

Invoke `New-RandomNumber` with `--MinValue:-2147483649`, `--MaxValue:2147483648`, and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated long integer into the element identified by the CSS selector `#inputField`.  

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

### Register Random Long Integer Parameter with Session Scope and Specified Range

Invoke `New-RandomNumber` with `--MinValue:-2147483649`, `--MaxValue:2147483648`, and `--NumberType:Long` to generate a random long integer at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Byte

Invoke `New-RandomNumber` with `--NumberType:Byte` to generate a random byte value (0–255) at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated byte value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Byte Parameter with Session Scope

Invoke `New-RandomNumber` with `--NumberType:Byte` to generate a random byte value (0–255) at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Byte with Specified Range

Invoke `New-RandomNumber` with `--MinValue:100`, `--MaxValue:150`, and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated byte value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Byte Parameter with Session Scope and Specified Range

Invoke `New-RandomNumber` with `--MinValue:100`, `--MaxValue:150`, and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Byte with Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated byte value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Byte Parameter with Session Scope and Minimum Value

Invoke `New-RandomNumber` with `--MinValue:100` and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Byte with Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:150` and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated byte value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Byte Parameter with Session Scope and Maximum Value

Invoke `New-RandomNumber` with `--MaxValue:150` and `--NumberType:Byte` to generate a random byte value at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Float

Invoke `New-RandomNumber` with `--NumberType:Float` to generate a random float value between 0 and 1 (exclusive) at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated float value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Float Parameter with Session Scope

Invoke `New-RandomNumber` with `--NumberType:Float` to generate a random float value between 0 and 1 (exclusive) at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

### Generate and Send Random Double

Invoke `New-RandomNumber` with `--NumberType:Double` to generate a random double value between 0 and 1 (exclusive) at runtime and pass it to the `SendKeys` plugin.
Use the `SendKeys` plugin to input the generated double value into the element identified by the CSS selector `#inputField`.  

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

### Register Random Double Parameter with Session Scope

Invoke `New-RandomNumber` with `--NumberType:Double` to generate a random double value between 0 and 1 (exclusive) at runtime and pass it to the `RegisterParameter` plugin.
Use the `RegisterParameter` plugin to register a parameter named `RandomNumber` with session scope using the generated value.  

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

MinValue sets the smallest number that can be generated by the random number function.
Defining a lower bound ensures results stay within a known range.
Omitting MinValue causes the function to use the lowest value supported by the integer type.
Specifying MinValue helps prevent values that are too low for the intended use.

### Max Value (MaxValue)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

MaxValue sets the highest number that the random number generator can produce.
Establishing an upper limit ensures outputs stay within a predictable range.
Omitting MaxValue causes the function to use the maximum supported integer value.
Defining MaxValue helps avoid values that exceed intended limits.

### Number Type (NumberType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Integer           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

NumberType determines which numeric format the generator will produce.
Choosing the right type ensures output matches the needed precision and range.
Omitting NumberType results in Integer values by default.
Specifying NumberType prevents unexpected numeric formats in results.

#### Values

##### Byte

Byte generates whole number values between 0 and 255.
Choosing Byte reduces memory use for small-range data.
Using Byte fits scenarios like binary file operations.
##### Double

Double produces floating-point values from 0.0 up to but not including 1.0 with high precision.
Using Double supports tasks requiring about 15 decimal digits of accuracy.
Choosing Double helps in scientific calculations and detailed simulations.
##### Float

Float produces floating-point values from 0.0 up to but not including 1.0 with moderate precision.
Using Float saves memory when about 7 decimal digits of accuracy are sufficient.
Choosing Float is useful for graphics and real-time applications.
##### Integer

Integer generates whole number values without any decimal part.
Using Integer simplifies tasks that require counts or indexing.
##### Long

Long produces whole numbers beyond the standard integer range.
Using Long prevents overflow in large-scale computations.
Choosing Long is ideal for timestamps and very large counters.

## Scope

* Any