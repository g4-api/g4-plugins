# Invoke Data For Each Loop (InvokeDataForEachLoop)

[Table of Content](../Home.md)  

~24 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Iterates over the records of a JSON or XML payload and runs a set of child rules on each record. Before every iteration the current record's values are injected into the child rules through `{{$ --Field}}`, `{{$ --Path}}`, and `{{$ --Item}}` tokens. It supports nested loops for multi-level, data-driven workflows, making it easier to automate repetitive tasks in RPA and automated testing.

### Key Features and Functionality

| Feature                | Description                                                                     |
|------------------------|---------------------------------------------------------------------------------|
| Record Iteration       | Parses a JSON or XML payload into records and loops through each one.           |
| Value Injection        | Replaces `--Field`, `--Path`, and `--Item` tokens with the current record data. |
| Format Auto-Detection  | Detects JSON or XML automatically and throws when the content matches neither.  |
| Nested Loop Capability | Allows data loops inside loops, each resolving its own tokens per record.       |

### Usages in RPA

| Use Case          | Description                                                                       |
|-------------------|-----------------------------------------------------------------------------------|
| Data Processing   | Process each record in a JSON or XML result by running data entry or validation.  |
| Batch Operations  | Perform a series of tasks on each item returned from a script or an API response. |
| Data-Driven Flows | Drive downstream rules with values taken from each record in turn.                |

### Usages in Automation Testing

| Use Case            | Description                                                                 |
|---------------------|-----------------------------------------------------------------------------|
| Data-Driven Testing | Run the same steps across every record in a data set.                       |
| Fixture Expansion   | Expand a single object or a small array into repeated, parameterized steps. |
| Result Verification | Verify downstream behavior for each record produced by a previous action.   |

## Examples

### Example No.1

### Iterate JSON Objects And Inject A Field

Iterates over each object in the JSON array supplied through the argument and runs a RegisterParameter action for each one.
The child rule uses `{{$ --Field:firstName}}` to inject the current record's `firstName` value into its argument before it runs.
If a record is missing the `firstName` field, the token is kept as-is for the child rule to handle.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "[{"firstName":"Alice","role":"Admin"},{"firstName":"Bob","role":"User"}]",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "RegisterParameter",
            Argument = "{{$ --Name:CurrentUser --Value:{{$ --Field:firstName}}}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("[{"firstName":"Alice","role":"Admin"},{"firstName":"Bob","role":"User"}]")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("RegisterParameter")
            .setArgument("{{$ --Name:CurrentUser --Value:{{$ --Field:firstName}}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "[{"firstName":"Alice","role":"Admin"},{"firstName":"Bob","role":"User"}]",
    rules: [
        {
            pluginName: "RegisterParameter",
            argument: "{{$ --Name:CurrentUser --Value:{{$ --Field:firstName}}}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "[{"firstName":"Alice","role":"Admin"},{"firstName":"Bob","role":"User"}]",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:CurrentUser --Value:{{$ --Field:firstName}}}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "[{"firstName":"Alice","role":"Admin"},{"firstName":"Bob","role":"User"}]",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:CurrentUser --Value:{{$ --Field:firstName}}}}"
        }
    ]
}
```
### Example No.2

### Iterate JSON Objects And Inject A Nested Value With JSONPath

Iterates over each object in the JSON array and runs a RegisterParameter action for each one.
The child rule uses `{{$ --Path:$.user.email}}` to resolve the nested `user.email` value from the current record via JSONPath.
If the path matches no node, the token is kept as-is so a nested data loop can resolve it later.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "[{"user":{"email":"alice@example.com"}},{"user":{"email":"bob@example.com"}}]",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "RegisterParameter",
            Argument = "{{$ --Name:Email --Value:{{$ --Path:$.user.email}}}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("[{"user":{"email":"alice@example.com"}},{"user":{"email":"bob@example.com"}}]")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("RegisterParameter")
            .setArgument("{{$ --Name:Email --Value:{{$ --Path:$.user.email}}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "[{"user":{"email":"alice@example.com"}},{"user":{"email":"bob@example.com"}}]",
    rules: [
        {
            pluginName: "RegisterParameter",
            argument: "{{$ --Name:Email --Value:{{$ --Path:$.user.email}}}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "[{"user":{"email":"alice@example.com"}},{"user":{"email":"bob@example.com"}}]",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:Email --Value:{{$ --Path:$.user.email}}}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "[{"user":{"email":"alice@example.com"}},{"user":{"email":"bob@example.com"}}]",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:Email --Value:{{$ --Path:$.user.email}}}}"
        }
    ]
}
```
### Example No.3

### Iterate A Simple Array And Inject Each Item

Iterates over each value in the simple JSON string array and runs a WriteLog action for each one.
The child rule uses `{{$ --Item}}` to inject the current value, which resolves to the scalar text of a simple-array record.
Complex records injected through `{{$ --Item}}` are emitted as minified JSON or XML instead.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "["apple","banana","cherry"]",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "WriteLog",
            Argument = "{{$ --Item}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("["apple","banana","cherry"]")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("WriteLog")
            .setArgument("{{$ --Item}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "["apple","banana","cherry"]",
    rules: [
        {
            pluginName: "WriteLog",
            argument: "{{$ --Item}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "["apple","banana","cherry"]",
    "rules": [
        {
            "pluginName": "WriteLog",
            "argument": "{{$ --Item}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "["apple","banana","cherry"]",
    "rules": [
        {
            "pluginName": "WriteLog",
            "argument": "{{$ --Item}}"
        }
    ]
}
```
### Example No.4

### Iterate XML Records And Inject A Child Element

Parses the XML payload and iterates over each repeated `<user>` element as a record, running a RegisterParameter action for each one.
The child rule uses `{{$ --Field:name}}` to inject the current record's `name` child element value before it runs.
A non-repeating XML root is instead treated as a single record and iterated exactly once.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "<users><user><name>Alice</name></user><user><name>Bob</name></user></users>",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "RegisterParameter",
            Argument = "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("<users><user><name>Alice</name></user><user><name>Bob</name></user></users>")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("RegisterParameter")
            .setArgument("{{$ --Name:UserName --Value:{{$ --Field:name}}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "<users><user><name>Alice</name></user><user><name>Bob</name></user></users>",
    rules: [
        {
            pluginName: "RegisterParameter",
            argument: "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "<users><user><name>Alice</name></user><user><name>Bob</name></user></users>",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "<users><user><name>Alice</name></user><user><name>Bob</name></user></users>",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
}
```
### Example No.5

### Iterate A Base64-Encoded Payload From DataSource

Reads the payload from the `DataSource` parameter and decodes it from Base64 because the `Base64` switch is present.
The decoded JSON array is iterated, and the child RegisterParameter action injects each record's `name` value through `{{$ --Field:name}}`.
When `Base64` is present and the value is not valid Base64, the action throws.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "{{$ --DataSource:W3sibmFtZSI6IkFsaWNlIn0seyJuYW1lIjoiQm9iIn1d --Base64}}",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "RegisterParameter",
            Argument = "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("{{$ --DataSource:W3sibmFtZSI6IkFsaWNlIn0seyJuYW1lIjoiQm9iIn1d --Base64}}")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("RegisterParameter")
            .setArgument("{{$ --Name:UserName --Value:{{$ --Field:name}}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "{{$ --DataSource:W3sibmFtZSI6IkFsaWNlIn0seyJuYW1lIjoiQm9iIn1d --Base64}}",
    rules: [
        {
            pluginName: "RegisterParameter",
            argument: "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "{{$ --DataSource:W3sibmFtZSI6IkFsaWNlIn0seyJuYW1lIjoiQm9iIn1d --Base64}}",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "{{$ --DataSource:W3sibmFtZSI6IkFsaWNlIn0seyJuYW1lIjoiQm9iIn1d --Base64}}",
    "rules": [
        {
            "pluginName": "RegisterParameter",
            "argument": "{{$ --Name:UserName --Value:{{$ --Field:name}}}}"
        }
    ]
}
```
### Example No.6

### Iterate A Single Object By Wrapping It Into One Record

Accepts a single JSON object and wraps it into a one-item collection so the child rules run exactly once.
The child WriteLog action uses `{{$ --Field:name}}` to inject the object's `name` value.
This tolerance keeps passing a lone object simple when data comes from a script result.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDataForEachLoop",
    Argument = "{"name":"Solo"}",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "WriteLog",
            Argument = "{{$ --Field:name}}"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDataForEachLoop")
    .setArgument("{"name":"Solo"}")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("WriteLog")
            .setArgument("{{$ --Field:name}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDataForEachLoop",
    argument: "{"name":"Solo"}",
    rules: [
        {
            pluginName: "WriteLog",
            argument: "{{$ --Field:name}}"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDataForEachLoop",
    "argument": "{"name":"Solo"}",
    "rules": [
        {
            "pluginName": "WriteLog",
            "argument": "{{$ --Field:name}}"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDataForEachLoop",
    "argument": "{"name":"Solo"}",
    "rules": [
        {
            "pluginName": "WriteLog",
            "argument": "{{$ --Field:name}}"
        }
    ]
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the JSON or XML payload to iterate when the `Base64` switch is absent, as raw content or a file path.
Supersedes `DataSource`, which is only used in Base64 mode.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

The set of child rules to run once per record.
Before each record, the `{{$ --Field}}`, `{{$ --Path}}`, and `{{$ --Item}}` tokens inside these rules are replaced with values from the current record.

## Parameters

### Data Source (DataSource)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The JSON or XML payload to iterate, used only when the `Base64` switch is present.
Accepts a raw Base64 value or a file path whose contents are Base64; the value is decoded from Base64 before parsing.
An invalid Base64 value throws and stops the action.

### Base64 (Base64)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Reads the payload from `DataSource` and decodes it from Base64 before parsing and iterating.
When omitted, the payload is taken from `Argument` as raw content or a file path.
Throws when the resolved value is not valid Base64.

## Scope

* Any