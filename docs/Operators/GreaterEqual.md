# Greater Equal (GreaterEqual)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the GreaterEqualOperator plugin is to compare two numeric values and determine if the first value is greater than or equal to the second value, using a numerical comparison.

### Key Features

| Feature              | Description                                               |
|----------------------|-----------------------------------------------------------|
| Numerical Comparison | Performs a numerical comparison of two values.            |
| Integration          | Can be used under condition expressions by other plugins. |

### Usages in RPA

| Usage              | Description                                                                      |
|--------------------|----------------------------------------------------------------------------------|
| Numeric Comparison | Validate if one numeric value is greater than or equal to another numeric value. |
| Conditional Logic  | Use in conditional expressions to control workflow logic based                   |

### Usages in Automation Testing

| Usage              | Description                                                               |
|--------------------|---------------------------------------------------------------------------|
| Validation         | Validate output or state by comparing expected and actual numeric values. |
| Dynamic Conditions | Create dynamic conditions based on numeric comparisons.                   |

## Examples

### Example No.1

This example demonstrates the usage of the `GreaterEqual` plugin to compare two numeric values and determine if the first value is greater than or equal to the second value.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `GreaterEqual`. This signifies the action of comparing two numeric values. |
| LeftHand   | Specifies the first numeric value to be compared. For example, `10`.                                                               |
| RightHand  | Specifies the second numeric value to be compared. For example, `5`.                                                               |

This example instructs the automation system to utilize the `GreaterEqual` plugin to compare `10` and `5` and determine if `10` is greater than or equal to `5`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GreaterEqual",
    Argument = "{{$ --LeftHand:10 --RightHand:5}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GreaterEqual")
    .setArgument("{{$ --LeftHand:10 --RightHand:5}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "GreaterEqual",
    argument: "{{$ --LeftHand:10 --RightHand:5}}"
};
```

_**JSON**_

```js
{
    "pluginName": "GreaterEqual",
    "argument": "{{$ --LeftHand:10 --RightHand:5}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "GreaterEqual",
    "argument": "{{$ --LeftHand:10 --RightHand:5}}"
}
```
### Example No.2

This example demonstrates the usage of the `GreaterEqualOperator` plugin within another plugin, such as `Assert`, to compare two numeric values and determine if the first value is greater than or equal to the second value.

| Field     | Description                                                                                                                                  |
|-----------|----------------------------------------------------------------------------------------------------------------------------------------------|
| Condition | Identifies the specific operator being utilized, which is `GreaterEqualOperator`. This signifies the action of comparing two numeric values. |
| LeftHand  | Specifies the first numeric value to be compared. For example, `10`.                                                                         |
| RightHand | Specifies the second numeric value to be compared. For example, `5`.                                                                         |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:GreaterEqual --LeftHand:10 --RightHand:5}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:GreaterEqual --LeftHand:10 --RightHand:5}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:GreaterEqual --LeftHand:10 --RightHand:5}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:GreaterEqual --LeftHand:10 --RightHand:5}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:GreaterEqual --LeftHand:10 --RightHand:5}}"
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

Specifies the first numeric value to be compared in the greater than or equal to check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the second numeric value to be compared in the greater than or equal to check.