# Lower (Lower)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the LowerOperator plugin is to compare two numeric values and determine if the first value is less than the second value, using a numerical comparison.

### Key Features

| Feature              | Description                                               |
|----------------------|-----------------------------------------------------------|
| Numerical Comparison | Performs a numerical comparison of two values.            |
| Integration          | Can be used under condition expressions by other plugins. |

### Usages in RPA

| Usage              | Description                                                                            |
|--------------------|----------------------------------------------------------------------------------------|
| Numeric Comparison | Validate if one numeric value is less than another numeric value.                      |
| Conditional Logic  | Use in conditional expressions to control workflow logic based on numeric comparisons. |

### Usages in Automation Testing

| Usage              | Description                                                               |
|--------------------|---------------------------------------------------------------------------|
| Validation         | Validate output or state by comparing expected and actual numeric values. |
| Dynamic Conditions | Create dynamic conditions based on numeric comparisons.                   |

## Examples

### Example No.1

This example demonstrates the usage of the `Lower` plugin to compare two numeric values and determine if the first value is less than the second value.

| Field      | Description                                                                                                                 |
|------------|-----------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Lower`. This signifies the action of comparing two numeric values. |
| LeftHand   | Specifies the first numeric value to be compared. For example, `5`.                                                         |
| RightHand  | Specifies the second numeric value to be compared. For example, `10`.                                                       |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Lower",
    Argument = "{{$ --LeftHand:5 --RightHand:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Lower")
    .setArgument("{{$ --LeftHand:5 --RightHand:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Lower",
    argument: "{{$ --LeftHand:5 --RightHand:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Lower",
    "argument": "{{$ --LeftHand:5 --RightHand:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Lower",
    "argument": "{{$ --LeftHand:5 --RightHand:10}}"
}
```
### Example No.2

This example demonstrates the usage of the `LowerOperator` plugin within another plugin, such as `Assert`, to compare two numeric values and determine if the first value is less than the second value.

| Field     | Description                                                                                                                           |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------|
| Condition | Identifies the specific operator being utilized, which is `LowerOperator`. This signifies the action of comparing two numeric values. |
| LeftHand  | Specifies the first numeric value to be compared. For example, `5`.                                                                   |
| RightHand | Specifies the second numeric value to be compared. For example, `10`.                                                                 |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Lower --LeftHand:5 --RightHand:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Lower --LeftHand:5 --RightHand:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Lower --LeftHand:5 --RightHand:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Lower --LeftHand:5 --RightHand:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Lower --LeftHand:5 --RightHand:10}}"
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

Specifies the first numeric value to be compared in the less than check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the second numeric value to be compared in the less than check.

## Scope

* Any