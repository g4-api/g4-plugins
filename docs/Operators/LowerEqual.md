# Lower Equal (LowerEqual)

[Table of Content](../Home.md)  

~13 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The LowerEqualOperator plugin compares two values and checks whether the first value is less than or equal to the second value.
It is used to evaluate numeric conditions in automation workflows.
This helps workflows make decisions based on thresholds, limits, or maximum allowed values.

### Key Features and Functionality

| Feature                       | Description                                                                                 |
|-------------------------------|---------------------------------------------------------------------------------------------|
| Less-than-or-equal comparison | Compares two numeric values using the less-than-or-equal (<=) operator.                     |
| Numeric validation            | Ensures both input values can be safely converted to numbers before comparison.             |
| Boolean evaluation result     | Returns true when the left value is less than or equal to the right value, otherwise false. |
| Operator integration          | Integrates with the operator framework to return a standard comparison result.              |

### Usages in RPA

| Use Case              | Description                                                                   |
|-----------------------|-------------------------------------------------------------------------------|
| Threshold checks      | Verify that a value does not exceed a defined maximum.                        |
| Data validation       | Ensure numeric inputs are within allowed limits before continuing a workflow. |
| Conditional branching | Decide workflow paths based on numeric comparisons.                           |

### Usages in Automation Testing

| Use Case          | Description                                                            |
|-------------------|------------------------------------------------------------------------|
| Assertion logic   | Validate that actual values are less than or equal to expected values. |
| Boundary testing  | Check upper boundary conditions in numeric test scenarios.             |
| Test flow control | Control test execution paths based on comparison outcomes.             |

## Examples

### Example No.1

### Compare two numeric values using LowerEqual

Compare a left-hand numeric value to a right-hand numeric value.
The rule evaluates to true only when the left-hand value is less than or equal to the right-hand value.
A macro produces runtime values that are substituted where the token appears.
The LowerEqual action consumes the macro output to perform the comparison.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "LowerEqual",
    Argument = "{{$--LeftHand:5 --RightHand:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("LowerEqual")
    .setArgument("{{$--LeftHand:5 --RightHand:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "LowerEqual",
    argument: "{{$--LeftHand:5 --RightHand:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "LowerEqual",
    "argument": "{{$--LeftHand:5 --RightHand:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "LowerEqual",
    "argument": "{{$--LeftHand:5 --RightHand:10}}"
}
```
### Example No.2

### Assert a LowerEqual condition

Evaluate a numeric comparison as part of an assertion.
The assertion passes only when the left-hand value is less than or equal to the right-hand value.
A macro produces runtime values that are substituted where the token appears.
The Assert action consumes the macro output and applies the LowerEqual comparison.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$--Condition:LowerEqual --LeftHand:5 --RightHand:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$--Condition:LowerEqual --LeftHand:5 --RightHand:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$--Condition:LowerEqual --LeftHand:5 --RightHand:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$--Condition:LowerEqual --LeftHand:5 --RightHand:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$--Condition:LowerEqual --LeftHand:5 --RightHand:10}}"
}
```

## Parameters

### Left Hand (LeftHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

LeftHand is the value on the left side of the <= comparison.
The value is treated as text and must successfully parse to a double at runtime.
Parsing uses the current machine culture, so decimal separators and formatting must match the environment.
If parsing fails for either side of the comparison, the operator returns false.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

RightHand is the value on the right side of the <= comparison.
The value is treated as text and must successfully parse to a double at runtime.
Parsing uses the current machine culture, so decimal separators and formatting must match the environment.
If parsing fails for either side of the comparison, the operator returns false.

## Scope

* Any