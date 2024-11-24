# Alert Exists (AlertExists)

[Table of Content](../Home.md)  

~12 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `AlertExists` plugin is designed to perform assertions within automation scripts to check for the presence of alert dialogs.

### Key Features and Functionality

| Feature             | Description                                                                        |
|---------------------|------------------------------------------------------------------------------------|
| Alert Detection     | Validates the presence of alert dialogs during the execution of automation tasks.  |
| Integration Support | Can be seamlessly integrated into automation scripts for efficient alert handling. |
| Error Handling      | Provides robust error handling to manage scenarios where alerts may not appear.    |

### Usages in RPA

| Usage                     | Description                                                                                     |
|---------------------------|-------------------------------------------------------------------------------------------------|
| Alert Presence Validation | Ensures that alerts are correctly triggered during automated processes in RPA workflows.        |
| User Interaction Testing  | Verifies that user-triggered alerts appear as expected, aiding in the validation of user flows. |

### Usages in Automation Testing

| Usage                  | Description                                                                                 |
|------------------------|---------------------------------------------------------------------------------------------|
| Functional Testing     | Confirms that alerts appear under the correct conditions during functional tests.           |
| Error Scenario Testing | Validates the handling of alert dialogs in various error scenarios.                         |
| End-to-End Testing     | Ensures comprehensive test coverage by verifying alert dialogs in end-to-end user journeys. |

## Examples

### Example No.1

Assert the existence of an alert dialog during automated tasks. 
This is useful for verifying that an alert dialog is correctly triggered during the execution of automation scripts.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AlertExists"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AlertExists");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "AlertExists"
};
```

_**JSON**_

```js
{
    "pluginName": "AlertExists"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "AlertExists"
}
```
### Example No.2

Use the `Assert` plugin to check if an alert dialog exists. 
This example ensures that an alert dialog is present during the automation process, called by the `Assert` plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:AlertExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:AlertExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:AlertExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#user-prompts](https://www.w3.org/TR/webdriver/#user-prompts)
