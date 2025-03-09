# Alert Not Exists (AlertNotExists)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `AlertNotExists` plugin is designed to assert that no alert dialog is present within a web browser during automated tasks. 
Its primary goal is to ensure that automation scripts can validate the absence of alert dialogs, which is crucial for scenarios where the presence of alerts would indicate an issue or interruption.

### Key Features and Functionality

| Feature              | Description                                                                               |
|----------------------|-------------------------------------------------------------------------------------------|
| Alert Absence Check  | Validates that no alert dialog is present during the execution of automated tasks.        |
| Seamless Integration | Integrates smoothly with automation workflows to ensure the absence of unexpected alerts. |
| Reliable Validation  | Provides reliable assertion to confirm the non-existence of alert dialogs.                |

### Usages in RPA

| Usage              | Description                                                                                             |
|--------------------|---------------------------------------------------------------------------------------------------------|
| Error Detection    | Confirms the absence of alert dialogs to ensure smooth execution of RPA processes.                      |
| Process Continuity | Validates that no alerts are disrupting the workflow, ensuring continuous and uninterrupted automation. |

### Usages in Automation Testing

| Usage                  | Description                                                                 |
|------------------------|-----------------------------------------------------------------------------|
| Alert Absence Testing  | Ensures that no unexpected alert dialogs are present during test scenarios. |
| Workflow Validation    | Confirms that workflows proceed without interruption from alert dialogs.    |

## Examples

### Example No.1

Assert that no alert dialog is present during the execution of automated tasks. 
This is useful for validating scenarios where the absence of alert dialogs is expected.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AlertNotExists"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AlertNotExists");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "AlertNotExists"
};
```

_**JSON**_

```js
{
    "pluginName": "AlertNotExists"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "AlertNotExists"
}
```
### Example No.2

Perform an assertion to ensure no alert dialog exists, validating the absence of alerts during the execution of the automation script. 
The `Assert` plugin is utilized to check this condition, and if no alert dialog is found, the assertion passes.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:AlertNotExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:AlertNotExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:AlertNotExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertNotExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertNotExists}}"
}
```

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#user-prompts](https://www.w3.org/TR/webdriver/#user-prompts)
