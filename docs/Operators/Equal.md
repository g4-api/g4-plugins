# Equal (Equal)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the EqualOperator plugin is to compare two strings and determine if they are exactly equal, using a case-sensitive comparison.

### Key Features

| Feature                   | Description                                               |
|---------------------------|---------------------------------------------------------- |
| Case-Sensitive Comparison | Performs a case-sensitive comparison of two strings.      |
| Integration               | Can be used under condition expressions by other plugins. |

### Usages in RPA

| Usage             | Description                                                     |
|-------------------|-----------------------------------------------------------------|
| String Comparison | Validate if two string values are identical.                    |
| Conditional Logic | Use in conditional expressions to control workflow logic based  |

### Usages in Automation Testing

| Usage              | Description                                                      |
|--------------------|------------------------------------------------------------------|
| Validation         | Validate output or state by comparing expected and actual values.|
| Dynamic Conditions | Create dynamic conditions based on string comparisons.           |

## Examples

### Example No.1

This example demonstrates the usage of the `Equal` plugin to compare two strings and determine if they are equal.

| Field      | Description                                                                                                          |
|------------|----------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Equal`. This signifies the action of comparing two strings. |
| LeftHand   | Specifies the first string to be compared. For example, `String1`.                                                   |
| RightHand  | Specifies the second string to be compared. For example, `String2`.                                                  |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Equal",
    Argument = "{{$ --LeftHand:String1 --RightHand:String2}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Equal")
    .setArgument("{{$ --LeftHand:String1 --RightHand:String2}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Equal",
    argument: "{{$ --LeftHand:String1 --RightHand:String2}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Equal",
    "argument": "{{$ --LeftHand:String1 --RightHand:String2}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Equal",
    "argument": "{{$ --LeftHand:String1 --RightHand:String2}}"
}
```
### Example No.2

This example demonstrates the usage of the `EqualOperator` plugin within another plugin, such as `Assert`, to compare two strings and determine if they are equal.

| Field       | Description                                                                                                                    |
|-------------|--------------------------------------------------------------------------------------------------------------------------------|
| Condition   | Identifies the specific operator being utilized, which is `EqualOperator`. This signifies the action of comparing two strings. |
| LeftHand    | Specifies the first string to be compared. For example, `String1`.                                                             |
| RightHand   | Specifies the second string to be compared. For example, `String2`.                                                            |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Equal --LeftHand:String1 --RightHand:String2}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Equal --LeftHand:String1 --RightHand:String2}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Equal --LeftHand:String1 --RightHand:String2}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Equal --LeftHand:String1 --RightHand:String2}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Equal --LeftHand:String1 --RightHand:String2}}"
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

Specifies the first string to be compared in the equality check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the second string to be compared in the equality check.
