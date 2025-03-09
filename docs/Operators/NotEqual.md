# Not Equal (NotEqual)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the NotEqualOperator plugin is to compare two string values to determine if they are not equal.

### Key Features

| Feature           | Description                                               |
|-------------------|-----------------------------------------------------------|
| String Comparison | Performs a comparison between two string values.          |
| Integration       | Can be used under condition expressions by other plugins. |

### Usages in RPA

| Usage             | Description                                                                           |
|-------------------|---------------------------------------------------------------------------------------|
| String Comparison | Validate if two string values are not equal.                                          |
| Conditional Logic | Use in conditional expressions to control workflow logic based on string comparisons. |

### Usages in Automation Testing

| Usage              | Description                                                                                |
|--------------------|--------------------------------------------------------------------------------------------|
| Validation         | Validate output or state by comparing expected string values to ensure they are not equal. |
| Dynamic Conditions | Create dynamic conditions based on string comparisons.                                     |

## Examples

### Example No.1

This example demonstrates the usage of the `NotEqual` plugin to compare two string values.

| Field      | Description                                                                                                                   |
|------------|-------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `NotEqual`. This signifies the action of comparing two string values. |
| LeftHand   | Specifies the first string value to be compared. For example, `"value1"`.                                                   |
| RightHand  | Specifies the second string value to be compared against. For example, `"value2"`.                                          |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NotEqual",
    Argument = "{{$ --LeftHand:"value1" --RightHand:"value2"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NotEqual")
    .setArgument("{{$ --LeftHand:"value1" --RightHand:"value2"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NotEqual",
    argument: "{{$ --LeftHand:"value1" --RightHand:"value2"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NotEqual",
    "argument": "{{$ --LeftHand:"value1" --RightHand:"value2"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NotEqual",
    "argument": "{{$ --LeftHand:"value1" --RightHand:"value2"}}"
}
```
### Example No.2

This example demonstrates the usage of the `NotEqualOperator` plugin within another plugin, such as `Assert`, to compare two string values.

| Field     | Description                                                                                                                             |
|-----------|-----------------------------------------------------------------------------------------------------------------------------------------|
| Condition | Identifies the specific operator being utilized, which is `NotEqualOperator`. This signifies the action of comparing two string values. |
| LeftHand  | Specifies the first string value to be compared. For example, `"value1"`.                                                             |
| RightHand | Specifies the second string value to be compared against. For example, `"value2"`.                                                    |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:NotEqual --LeftHand:"value1" --RightHand:"value2"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:NotEqual --LeftHand:"value1" --RightHand:"value2"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:NotEqual --LeftHand:"value1" --RightHand:"value2"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:NotEqual --LeftHand:"value1" --RightHand:"value2"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:NotEqual --LeftHand:"value1" --RightHand:"value2"}}"
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

Specifies the first string value to be compared in the not equal check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the second string value to be compared against the first string value.

## Scope

* Any