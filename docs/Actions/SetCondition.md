# Set Condition (SetCondition)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SetCondition` plugin facilitates the conditional execution of sub-actions within automation scripts. 
It evaluates specified conditions using assertion plugins and decides whether to run the sub-actions based on the evaluation results.

### Key Features and Functionality

| Feature                    | Description                                                                                                 |
|--------------------------- |-------------------------------------------------------------------------------------------------------------|
| Conditional Execution      | Executes sub-actions only if specified conditions are met, allowing for dynamic control flow in automation. |
| Assertion-Based Evaluation | Utilizes assertion plugins to evaluate conditions, ensuring accurate and reliable decision-making.          |
| Meta Plugin                | Creates, sends, and evaluates assertion plugins to determine the execution of sub-actions.                  |

### Usages in RPA

| Usage               | Description                                                                                        |
|---------------------|--------------------------------------------------------------------------------------------------- |
| Conditional Actions | Perform actions conditionally based on the evaluation of specified conditions.                     |
| Dynamic Workflows   | Enable dynamic workflows by conditionally executing sub-actions based on runtime conditions.       |
| Error Handling      | Implement error handling by conditionally executing recovery actions when certain conditions fail. |

### Usages in Automation Testing

| Usage                       | Description                                                                                                |
|-----------------------------|----------------------------------------------------------------------------------------------------------- |
| Conditional Test Execution  | Execute test cases conditionally based on the evaluation of specific conditions.                           |
| Dynamic Test Scenarios      | Create dynamic test scenarios by conditionally executing steps based on runtime conditions and assertions. |
| Validation and Verification | Perform validation and verification steps conditionally, ensuring accurate and reliable test outcomes.     |

## Examples

### Example No.1

This configuration evaluates a condition and executes sub-actions if the condition is met.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    Locator = "CssSelector",
    OnElement = "#greeting"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}")
    .setLocator("CssSelector")
    .setOnElement("#greeting");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    locator: "CssSelector",
    onElement: "#greeting"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    "locator": "CssSelector",
    "onElement": "#greeting"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Hello World}}",
    "locator": "CssSelector",
    "onElement": "#greeting"
}
```
### Example No.2

This configuration checks if an alert exists and executes sub-actions if no alert is present.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:AlertExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:AlertExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:AlertExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:AlertExists}}"
}
```
### Example No.3

This configuration checks if the page URL does not matche a specific pattern and executes sub-actions accordingly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://example.com/*}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://example.com/*}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://example.com/*}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://example.com/*}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://example.com/*}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Expression        |

Specifies the condition and parameters for the assertion to be performed by a particular plugin.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies how elements should be located on a webpage or within an application.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute of the target element that will be interacted with or evaluated during automation.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target element on which conditions will be evaluated during the automation process.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regular expression to apply on the element/attribute result before the assertion.

### Branches (Branches)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Object            |

Define a sequence of actions or instructions to be executed if the condition is met.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

Specifies the condition to be evaluated to decide whether to execute the sub-actions.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Specifies the expected value to be compared against the actual value when evaluating the condition.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison to be performed when evaluating the condition.

## Scope

* Any