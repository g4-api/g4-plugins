# Equal (Equal)

[Table of Content](../Home.md)  

~10 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Disclaimer

Operator plugins are designed to be called and used only by other plugins that expose an Operator parameter (such as Assert, SetCondition, or InvokeWhileLoop).
They cannot be invoked directly in the workflow; they function only when implemented inside a caller plugin.

### Purpose

The EqualOperator plugin compares two strings to determine if they are exactly equal.
It uses case-sensitive comparison to ensure precise matching.
It returns a Boolean result that can be used in automation workflows and tests to control the flow based on string equality.
This capability is essential for building reliable conditional logic.

### Key Features and Functionality

| Feature                   | Description                                                                                        |
|---------------------------|----------------------------------------------------------------------------------------------------|
| Case-Sensitive Comparison | Performs a case-sensitive comparison of two strings to check for exact equality.                   |
| Integration               | Can be used within conditional expressions by other plugins to enable flexible workflow decisions. |

### Usages in RPA

| Use Case          | Description                                                                           |
|-------------------|---------------------------------------------------------------------------------------|
| String Comparison | Validate that two string values are exactly the same to guide workflow steps.         |
| Conditional Logic | Use the comparison result to control the flow of automation based on string equality. |

### Usages in Automation Testing

| Use Case           | Description                                                                          |
|--------------------|--------------------------------------------------------------------------------------|
| Validation         | Compare expected and actual string values to assert correctness in tests.            |
| Dynamic Conditions | Create test conditions based on string comparisons for more flexible test scenarios. |

## Examples

### Example No.1

### String Equality Comparison

Uses the `Equal` plugin to determine if two strings are exactly equal, such as comparing an actual result with an expected value.
The plugin checks if the values of 'LeftHand' and 'RightHand' match, using a case-sensitive comparison. This comparison is valid only when used inside a caller plugin that supports operator logic.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Equal",
    Argument = "{{$ --LeftHand:ActualResult --RightHand:ExpectedValue}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Equal")
    .setArgument("{{$ --LeftHand:ActualResult --RightHand:ExpectedValue}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Equal",
    argument: "{{$ --LeftHand:ActualResult --RightHand:ExpectedValue}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Equal",
    "argument": "{{$ --LeftHand:ActualResult --RightHand:ExpectedValue}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Equal",
    "argument": "{{$ --LeftHand:ActualResult --RightHand:ExpectedValue}}"
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

Specifies the first input string to be used in the comparison.
This value is compared to another string to determine equality.
Used on the left side of the equality check.
Both strings must match exactly for the result to be true.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the second input string for comparison.
This string is checked against the left-hand value for equality.
Used on the right side of the equality check.
The comparison is case-sensitive and expects an exact match.

## Scope

* Any