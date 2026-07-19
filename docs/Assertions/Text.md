# Text (Text)

[Table of Content](../Home.md)  

~33 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The Text plugin returns a piece of text—either a fixed value or one built at run time—for use in assertion workflows. It supplies the ‘Actual’ value that assertion plugins compare against an expected value. As an assertion-type plugin, it can be passed as a parameter to other plugins that perform checks.

### Key Features and Functionality

| Feature                 | Description                                                                                         |
|-------------------------|-----------------------------------------------------------------------------------------------------|
| Static and Dynamic Text | Provide a fixed text string or build text on the fly using macros or data provider values.          |
| Macro Support           | Use macro expressions (e.g., `{{$Get-Parameter ...}}`) to assemble or modify text at run time.      |
| Data Provider Binding   | Pull values directly from data provider columns (e.g., `{{$ Columns.ColumnName }}`) for text input. |

### Usages in RPA

| Use Case          | Description                                                                       |
|-------------------|-----------------------------------------------------------------------------------|
| Provide Assertion | Supply a static or generated text value as the Actual parameter for an assertion. |
| Parameter Binding | Return a parameter’s value as text so other plugins can feed it into assertions.  |

### Usages in Automation Testing

| Use Case            | Description                                                                                                   |
|---------------------|---------------------------------------------------------------------------------------------------------------|
| Assertion Input     | Provide the Actual text value that assertion plugins will compare to an Expected value.                       |
| Data-Driven Testing | Feed text from macros or data provider into assertion steps so tests validate different inputs automatically. |

## Examples

### Example No.1

### Assert Order Confirmation Number Equals Expected Value

This example demonstrates how to assert that the order confirmation number retrieved from the session parameter `ActualOrderID` matches the expected order ID from test data.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}` and argument `{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}`.
The assertion passes only if the session parameter value, when compared as a string, equals the expected value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}",
    OnElement = "{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}")
    .setOnElement("{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}",
    onElement: "{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}",
    "onElement": "{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:{{$ Columns.ExpectedOrderID }}}}",
    "onElement": "{{$Get-Parameter --Name:ActualOrderID --Scope:Session}}"
}
```
### Example No.2

### Assert Error Message Is Not Default Placeholder

This example demonstrates how to assert that the error message stored in the session parameter `LastErrorMessage` is not the default placeholder value `Error occurred`.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}` and argument `{{$ --Operator:NotEqual --Expected:Error occurred}}`.
The assertion passes only if the session parameter value, when compared as a string, does not equal the placeholder.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:NotEqual --Expected:Error occurred}}",
    OnElement = "{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:NotEqual --Expected:Error occurred}}")
    .setOnElement("{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:NotEqual --Expected:Error occurred}}",
    onElement: "{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotEqual --Expected:Error occurred}}",
    "onElement": "{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotEqual --Expected:Error occurred}}",
    "onElement": "{{$Get-Parameter --Name:LastErrorMessage --Scope:Session}}"
}
```
### Example No.3

### Assert Session Parameter SSN Matches Valid Format

This example demonstrates how to assert that the Social Security Number stored in the session parameter `UserSSN` matches the valid SSN format (XXX-XX-XXXX).
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:UserSSN --Scope:Session}}` and applies the operator `Match` with the regular expression `\d{3}-\d{2}-\d{4}` to extract and validate the SSN format.
A regular expression `\d{3}-\d{2}-\d{4}` is applied to the parameter value to ensure it conforms to the expected pattern.
The assertion passes only if the session parameter value, when compared as a string, matches the pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "{{$Get-Parameter --Name:UserSSN --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("{{$Get-Parameter --Name:UserSSN --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "{{$Get-Parameter --Name:UserSSN --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "{{$Get-Parameter --Name:UserSSN --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Match --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "{{$Get-Parameter --Name:UserSSN --Scope:Session}}"
}
```
### Example No.4

### Assert Placeholder SSN Does Not Match Valid Format

This example demonstrates how to assert that the placeholder SSN value `000-00-0000` does not match the valid SSN format (XXX-XX-XXXX).
It uses the `Text` plugin with `onElement` set to `000-00-0000` and applies the operator `NotMatch` with the regular expression `\d{3}-\d{2}-\d{4}` to validate that the placeholder is rejected.
A regular expression `\d{3}-\d{2}-\d{4}` is applied to the literal value to ensure it does not conform to the SSN pattern.
The assertion passes only if the value, when compared as a string, does not match the pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    OnElement = "000-00-0000"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}")
    .setOnElement("000-00-0000");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    onElement: "000-00-0000"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "000-00-0000"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:NotMatch --Expected:\d{3}-\d{2}-\d{4}}}",
    "onElement": "000-00-0000"
}
```
### Example No.5

### Assert Total Order Amount Exceeds Free-Shipping Threshold

This example demonstrates how to assert that the total order amount stored in the session parameter `TotalOrderAmount` exceeds the minimum free-shipping threshold of 50.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}` and argument `{{$ --Operator:Greater --Expected:50}}`.
The assertion passes only if the session parameter value, when compared as a number, is greater than 50.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Greater --Expected:50}}",
    OnElement = "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Greater --Expected:50}}")
    .setOnElement("{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Greater --Expected:50}}",
    onElement: "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Greater --Expected:50}}",
    "onElement": "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Greater --Expected:50}}",
    "onElement": "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
}
```
### Example No.6

### Assert Available Stock Is Below Reorder Threshold

This example demonstrates how to assert that the available stock level stored in the session parameter `AvailableStock` is below the reorder threshold of 20 units.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:AvailableStock --Scope:Session}}` and argument `{{$ --Operator:Lower --Expected:20}}`.
The assertion passes only if the session parameter value, when compared as a number, is less than 20.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Lower --Expected:20}}",
    OnElement = "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Lower --Expected:20}}")
    .setOnElement("{{$Get-Parameter --Name:AvailableStock --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Lower --Expected:20}}",
    onElement: "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Lower --Expected:20}}",
    "onElement": "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Lower --Expected:20}}",
    "onElement": "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
}
```
### Example No.7

### Assert Total Order Amount Meets Free-Shipping Threshold

This example demonstrates how to assert that the total order amount stored in the session parameter `TotalOrderAmount` is at least the free shipping threshold defined in test data.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}` and argument `{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}`.
The assertion passes only if the session parameter value, when compared as a number, is greater than or equal to the expected threshold.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}",
    OnElement = "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}")
    .setOnElement("{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}",
    onElement: "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}",
    "onElement": "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:GreaterEqual --Expected:{{$ Columns.FreeShippingThreshold }}}}",
    "onElement": "{{$Get-Parameter --Name:TotalOrderAmount --Scope:Session}}"
}
```
### Example No.8

### Assert Available Stock Does Not Exceed Warehouse Capacity

This example demonstrates how to assert that the available stock level stored in the session parameter `AvailableStock` does not exceed the warehouse capacity defined in test data.
It uses the `Text` plugin with `onElement` set to `{{$Get-Parameter --Name:AvailableStock --Scope:Session}}` and argument `{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}`.
The assertion passes only if the session parameter value, when compared as a number, is less than or equal to the expected capacity.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}",
    OnElement = "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}")
    .setOnElement("{{$Get-Parameter --Name:AvailableStock --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}",
    onElement: "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}",
    "onElement": "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:LowerEqual --Expected:{{$ Columns.WarehouseCapacity }}}}",
    "onElement": "{{$Get-Parameter --Name:AvailableStock --Scope:Session}}"
}
```
### Example No.9

### Extract Numeric Value from Price and Assert Equality

This example demonstrates how to extract the numeric value from the static price string `$1,000.00` using a regular expression and then assert that it equals `1000`.
It uses the `Text` plugin with `onElement` set to `$1,000.00`, applies the regex `\d+(?:,\d{3})*` (configured in the rule’s `regularExpression` field) to extract the numeric portion (ignoring commas), and then uses the operator `Equal` against the expected value `1000`.
The assertion passes only if the extracted numeric value, when compared as a string, equals `1000`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Equal --Expected:1000}}",
    OnElement = "$1,000.00",
    RegularExpression = "\d+(?:,\d{3})*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Equal --Expected:1000}}")
    .setOnElement("$1,000.00")
    .setRegularExpression("\d+(?:,\d{3})*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Equal --Expected:1000}}",
    onElement: "$1,000.00",
    regularExpression: "\d+(?:,\d{3})*"
};
```

_**JSON**_

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:1000}}",
    "onElement": "$1,000.00",
    "regularExpression": "\d+(?:,\d{3})*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:1000}}",
    "onElement": "$1,000.00",
    "regularExpression": "\d+(?:,\d{3})*"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Text value that will be compared to the expected result.
It can be a fixed phrase or a value provided by an expression at runtime.
Accurate values ensure the comparison works correctly.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Pattern used to process the text before comparison.
Only the parts that match the pattern are kept for checking.
Pattern matching helps focus the comparison on relevant text.

## Parameters

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Value or pattern the script looks for when checking a condition.
Defines what result counts as a match.
Clear expected values help avoid missed matches or false positives.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Method the system uses to compare actual results to expected values.
Operators include checks like equals, greater than, or less than.
Choosing the right operator ensures accurate decision making.

## Scope

* Any