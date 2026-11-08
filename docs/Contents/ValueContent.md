# Value Content (ValueContent)

[Table of Content](../Home.md)

~16 min · Content Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ValueContent` plugin stores a value passed in the rule's `Argument` as a field of the extracted entity.
It does not read any element: use it to add user data, parameters, macros, or data-source values to an extraction next to fields read from the page.
The argument is resolved by the engine before the plugin runs, so expressions such as `{{$Get-Parameter ...}}` are stored as their runtime values.

### Key Features and Functionality

| Feature                | Description                                                                                       |
| --- | --- |
| Element-Free Content   | Stores the `Argument` value without locating or reading any element.                              |
| Expression Support     | Parameters, macros, and data-source tokens in the argument are resolved before the value is set.  |
| Regex Extraction       | Applies `RegularExpression` to the argument to keep only the matched portion.                     |
| Data Type Conversion   | Converts the value to `String`, `Number`, `Boolean`, or `DateTime`.                               |
| Consistent Fields      | An empty argument is stored as an empty string, so every entity keeps the same fields.            |

### Usages in RPA

| Usage                  | Description                                                                                       |
| --- | --- |
| Record Enrichment      | Add a batch id, user name, or run date to every extracted record.                                 |
| Data Source Values     | Store the current data-source row values next to the data extracted from the page.                |
| Static Columns         | Add fixed values such as a source system name to exported data.                                   |

### Usages in Automation Testing

| Usage                  | Description                                                                                       |
| --- | --- |
| Test Context Columns   | Store the test case id or environment name with every extracted entity.                           |
| Expected Values        | Store expected values next to actual extracted values for later comparison.                       |

## Examples

### Example No.1

Store a fixed value in every extracted entity.

The `ValueContent` plugin stores the argument `Web Shop` under the `Source` key.
No element is read; the value is added next to the fields extracted from the page.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ValueContent",
    Argument = "Web Shop"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ValueContent")
    .setArgument("Web Shop");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ValueContent",
    argument: "Web Shop"
};
```

**JSON:**

```js
{
    "pluginName": "ValueContent",
    "argument": "Web Shop"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ValueContent",
    "argument": "Web Shop"
}
```

### Example No.2

Store the value of a session parameter in every extracted entity.

The `ValueContent` plugin stores the runtime value of the `CustomerName` session parameter under the `Customer` key.
The expression is resolved by the engine before the value is stored.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ValueContent",
    Argument = "{{$Get-Parameter --Name:CustomerName --Scope:Session}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ValueContent")
    .setArgument("{{$Get-Parameter --Name:CustomerName --Scope:Session}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ValueContent",
    argument: "{{$Get-Parameter --Name:CustomerName --Scope:Session}}"
};
```

**JSON:**

```js
{
    "pluginName": "ValueContent",
    "argument": "{{$Get-Parameter --Name:CustomerName --Scope:Session}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ValueContent",
    "argument": "{{$Get-Parameter --Name:CustomerName --Scope:Session}}"
}
```

### Example No.3

Store a numeric part of a value.

The `ValueContent` plugin applies the regular expression to the argument `Order-12345` and keeps `12345`.
The value is converted to a number and stored under the `OrderId` key.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ValueContent",
    Argument = "Order-12345",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ValueContent")
    .setArgument("Order-12345")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ValueContent",
    argument: "Order-12345",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "ValueContent",
    "argument": "Order-12345",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ValueContent",
    "argument": "Order-12345",
    "regularExpression": "\d+"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the value to store.
Accepts a fixed text or an expression that the engine resolves before the plugin runs.
If not provided, an empty string is stored.

### Data Type (DataType)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the data type to which the extracted value should be converted.
Supported data types include `String`, `Number`, `Boolean` and  `DateTime`.

#### Values

##### String

Textual data.

##### Number

Whole numbers or numeric values with decimal points.

##### Boolean

True or False values.

##### Date Time

Date and/or time values.

### Key (Key)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the key under which the extracted data will be stored.
This key can be used to reference the data in subsequent steps.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the regular expression pattern to apply to the argument value.
Only the first match is stored; if there is no match, an empty string is stored.

## Scope

* Any
