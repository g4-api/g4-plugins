# Greater (Greater)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The GreaterOperator plugin lets you compare two numbers to see if one is larger than another.
This simple comparison is useful in automated workflows and tests to guide decision points.
It ensures that workflow steps only run when the right numerical conditions are met.

### Key Features and Functionality

| Feature              | Description                                                                                          |
|----------------------|------------------------------------------------------------------------------------------------------|
| Numerical Comparison | Performs a numerical comparison of two numeric values to determine if one is greater than the other. |
| Integration          | Can be used within other plugins as a conditional operator in workflows.                             |

### Usages in RPA

| Use Case           | Description                                                    |
|--------------------|----------------------------------------------------------------|
| Numeric Comparison | Stop or continue a process based on numeric thresholds.        |
| Conditional Logic  | Choose different workflow paths when values exceed set limits. |

### Usages in Automation Testing

| Use Case           | Description                                                                   |
|--------------------|-------------------------------------------------------------------------------|
| Validation         | Confirm that test outputs exceed expected numeric benchmarks.                 |
| Dynamic Conditions | Adapt test steps dynamically when numeric conditions change during execution. |

## Examples

### Example No.1

### Positive Greater Plugin Comparison

The Greater plugin uses `{{$ --LeftHand:10 --RightHand:5}}` to compare two values at runtime and returns true because 10 is greater than 5.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Greater",
    Argument = "{{$ --LeftHand:10 --RightHand:5}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Greater")
    .setArgument("{{$ --LeftHand:10 --RightHand:5}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Greater",
    argument: "{{$ --LeftHand:10 --RightHand:5}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Greater",
    "argument": "{{$ --LeftHand:10 --RightHand:5}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Greater",
    "argument": "{{$ --LeftHand:10 --RightHand:5}}"
}
```
### Example No.2

### Equal Greater Plugin Comparison

The Greater plugin uses `{{$ --LeftHand:5 --RightHand:5}}` to compare two values at runtime and returns false because both values are equal.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Greater",
    Argument = "{{$ --LeftHand:5 --RightHand:5}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Greater")
    .setArgument("{{$ --LeftHand:5 --RightHand:5}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Greater",
    argument: "{{$ --LeftHand:5 --RightHand:5}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Greater",
    "argument": "{{$ --LeftHand:5 --RightHand:5}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Greater",
    "argument": "{{$ --LeftHand:5 --RightHand:5}}"
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
| **Value Type**    | Number            |

LeftHand is the first numeric value in a greater than check.
It defines the baseline value that the second number is compared against.
Supplying an accurate LeftHand value ensures the comparison yields correct results.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

RightHand is the second numeric value in a greater than check.
It represents the threshold that the first number must exceed.
Providing a precise RightHand value ensures the comparison works as intended.

## Scope

* Any