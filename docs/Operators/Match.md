# Match (Match)

[Table of Content](../Home.md)  

~12 min · Operator Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the MatchOperator plugin is to compare a string value against a regular expression pattern to determine if they match.

### Key Features

| Feature                     | Description                                                              |
|-----------------------------|--------------------------------------------------------------------------|
| String and Regex Comparison | Performs a comparison between a string and a regular expression pattern. |
| Integration                 | Can be used under condition expressions by other plugins.                |

### Usages in RPA

| Usage                       | Description                                                                          |
|-----------------------------|--------------------------------------------------------------------------------------|
| String and Regex Comparison | Validate if a string matches a regular expression pattern.                           |
| Conditional Logic           | Use in conditional expressions to control workflow logic based on regex comparisons. |

### Usages in Automation Testing

| Usage              | Description                                                                          |
|--------------------|--------------------------------------------------------------------------------------|
| Validation         | Validate output or state by comparing expected string values against regex patterns. |
| Dynamic Conditions | Create dynamic conditions based on regex comparisons.                                |

## Examples

### Example No.1

This example demonstrates the usage of the `Match` plugin to compare a string value against a regular expression pattern.

| Field      | Description                                                                                                                                     |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Match`. This signifies the action of comparing a string value against a regex pattern. |
| LeftHand   | Specifies the string value to be compared. For example, `"hello123"`.                                                                         |
| RightHand  | Specifies the regular expression pattern to be compared against. For example, `"^hello\d+$"`.                                                |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Match",
    Argument = "{{$ --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Match")
    .setArgument("{{$ --LeftHand:"hello123" --RightHand:"^hello\d+$"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Match",
    argument: "{{$ --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Match",
    "argument": "{{$ --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Match",
    "argument": "{{$ --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
}
```
### Example No.2

This example demonstrates the usage of the `MatchOperator` plugin within another plugin, such as `Assert`, to compare a string value against a regular expression pattern.

| Field     | Description                                                                                                                                               |
|-----------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| Condition | Identifies the specific operator being utilized, which is `MatchOperator`. This signifies the action of comparing a string value against a regex pattern. |
| LeftHand  | Specifies the string value to be compared. For example, `"hello123"`.                                                                                   |
| RightHand | Specifies the regular expression pattern to be compared against. For example, `"^hello\d+$"`.                                                          |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:Match --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:Match --LeftHand:"hello123" --RightHand:"^hello\d+$"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:Match --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Match --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:Match --LeftHand:"hello123" --RightHand:"^hello\d+$"}}"
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

Specifies the string value to be compared in the match check.

### Right Hand (RightHand)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regular expression pattern to be compared against the string value.

## Scope

* Any