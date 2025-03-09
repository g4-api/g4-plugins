# Not Match (NotMatch)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the NotMatchOperator plugin is to compare a string value against a regular expression to determine if they do not match.

### Key Features

| Feature                     | Description                                                            |
|---------------------------- |------------------------------------------------------------------------|
| String and Regex Comparison | Performs a comparison between a string value and a regular expression. |
| Integration                 | Can be used under condition expressions by other plugins.              |

### Usages in RPA

| Usage                       | Description                                                                                     |
|-----------------------------|-------------------------------------------------------------------------------------------------|
| String and Regex Comparison | Validate if a string value does not match a regular expression.                                 |
| Conditional Logic           | Use in conditional expressions to control workflow logic based on string and regex comparisons. |

### Usages in Automation Testing

| Usage              | Description                                                                                                  |
|--------------------|--------------------------------------------------------------------------------------------------------------|
| Validation         | Validate output or state by comparing string values against regular expressions to ensure they do not match. |
| Dynamic Conditions | Create dynamic conditions based on string and regex comparisons.                                             |

## Examples

### Example No.1

This example demonstrates the usage of the `NotMatch` plugin to compare a string value against a regular expression.

| Field      | Description                                                                                                                                             |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `NotMatch`. This signifies the action of comparing a string value against a regular expression. |
| LeftHand   | Specifies the string value to be compared. For example, `"value1"`.                                                                                   |
| RightHand  | Specifies the regular expression to be compared against. For example, `"regex_pattern"`.                                                              |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NotMatch",
    Argument = "{{$ --LeftHand:"value1" --RightHand:"regex_pattern"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NotMatch")
    .setArgument("{{$ --LeftHand:"value1" --RightHand:"regex_pattern"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NotMatch",
    argument: "{{$ --LeftHand:"value1" --RightHand:"regex_pattern"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NotMatch",
    "argument": "{{$ --LeftHand:"value1" --RightHand:"regex_pattern"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NotMatch",
    "argument": "{{$ --LeftHand:"value1" --RightHand:"regex_pattern"}}"
}
```
### Example No.2

This example demonstrates the usage of the `NotMatchOperator` plugin within another plugin, such as `Assert`, to compare a string value against a regular expression.

| Field     | Description                                                                                                                                                       |
|-----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Condition | Identifies the specific operator being utilized, which is `NotMatchOperator`. This signifies the action of comparing a string value against a regular expression. |
| LeftHand  | Specifies the string value to be compared. For example, `"value1"`.                                                                                             |
| RightHand | Specifies the regular expression to be compared against. For example, `"regex_pattern"`.                                                                        |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:NotMatch --LeftHand:"value1" --RightHand:"regex_pattern"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:NotMatch --LeftHand:"value1" --RightHand:"regex_pattern"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:NotMatch --LeftHand:"value1" --RightHand:"regex_pattern"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:NotMatch --LeftHand:"value1" --RightHand:"regex_pattern"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:NotMatch --LeftHand:"value1" --RightHand:"regex_pattern"}}"
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

Specifies the string value to be compared in the not match check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regular expression to be compared against the string value.

## Scope

* Any