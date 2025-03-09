# Switch Alert (SwitchAlert)

[Table of Content](../Home.md)  

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]
> This plugin works only for `alert`, `beforeUnload`, `confirm`, `default`, `prompt`.

### Purpose

The `SwitchAlert` plugin serves the purpose of automating the handling of alert dialogs in web-based automation workflows, particularly in the context of RPA (Robotic Process Automation) and automation testing. 
Its primary goal is to provide a seamless and efficient mechanism for interacting with alert dialogs that may appear during automated processes, ensuring smooth execution and accurate handling of alert messages.

### Key Features and Functionality

| Feature            | Description                                                                                   |
|--------------------|-----------------------------------------------------------------------------------------------|
| Alert Recognition  | Seamlessly identifies and switches to alert dialogs encountered during automation tasks.      |
| Action Flexibility | Offers flexibility in performing actions on alerts, supporting both acceptance and dismissal. |
| Argument Handling  | Efficiently handles plugin arguments, specifying actions and keys to send to the alert.       |
| Error Handling     | Robust error handling mechanisms ensure reliability and resilience of automation processes.   |

### Usages in RPA

| Usage                       | Description                                                                                          |
|-----------------------------|------------------------------------------------------------------------------------------------------|
| Alert Notification Handling | Automates the handling of alert dialogs during RPA tasks, ensuring alerts are managed automatically. |
| Error Recovery              | Handles unexpected alerts, allowing graceful error recovery and continued execution.                 |
| User Notification           | Interacts with alerts similar to human users, facilitating user-driven processes.                    |

### Usages in Automation Testing

| Usage                  | Description                                                                                         |
|------------------------|-----------------------------------------------------------------------------------------------------|
| Alert Testing          | Validates alert handling functionality by simulating alert dialogs and verifying correct responses. |
| Error Scenario Testing | Simulates error conditions triggering alerts for comprehensive testing of application behavior.     |
| End-to-End Testing     | Automates alert handling in user interaction scenarios, ensuring robust application behavior.       |

## Examples

### Example No.1

Handle alert dialogs during automated tasks by defaulting to **dismiss**. 
This ensures the automation process continues smoothly without manual intervention, effectively managing alert dialogs encountered during execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert"
}
```
### Example No.2

Accept any alert dialog that appears during automation, facilitating the seamless execution of tasks by acknowledging the alert.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert",
    Argument = "Accept"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert")
    .setArgument("Accept");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert",
    argument: "Accept"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert",
    "argument": "Accept"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert",
    "argument": "Accept"
}
```
### Example No.3

Ignore any alert dialog that appears during automation, allowing the process to continue without interacting with the alert.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert",
    Argument = "Ignore"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert")
    .setArgument("Ignore");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert",
    argument: "Ignore"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert",
    "argument": "Ignore"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert",
    "argument": "Ignore"
}
```
### Example No.4

Send specific keys `Foo Bar` to the alert dialog, useful for interacting with alerts that require input, such as entering text or responding to prompts.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert",
    Argument = "{{$ --Keys:Foo Bar}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert")
    .setArgument("{{$ --Keys:Foo Bar}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert",
    argument: "{{$ --Keys:Foo Bar}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar}}"
}
```
### Example No.5

Send specific keys `Foo Bar` to the alert dialog and then accept it, useful for scenarios needing input followed by acknowledgment to proceed with tasks.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert",
    Argument = "{{$ --Keys:Foo Bar --AlertAction:Accept}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert")
    .setArgument("{{$ --Keys:Foo Bar --AlertAction:Accept}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert",
    argument: "{{$ --Keys:Foo Bar --AlertAction:Accept}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar --AlertAction:Accept}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar --AlertAction:Accept}}"
}
```
### Example No.6

Send specific keys `Foo Bar` to the alert dialog and then dismiss it, useful for workflows requiring interaction with the alert followed by its dismissal.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchAlert",
    Argument = "{{$ --Keys:Foo Bar --AlertAction:Dismiss}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchAlert")
    .setArgument("{{$ --Keys:Foo Bar --AlertAction:Dismiss}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchAlert",
    argument: "{{$ --Keys:Foo Bar --AlertAction:Dismiss}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar --AlertAction:Dismiss}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchAlert",
    "argument": "{{$ --Keys:Foo Bar --AlertAction:Dismiss}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Dismiss           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

The `Argument` property customizes how the `SwitchAlert` plugin handles alert dialogs. 
It allows you to specify actions like sending keys to the alert or determining whether to accept or dismiss the alert. 

## Parameters

### Alert Action (AlertAction)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Determines the action to be taken when encountering an alert dialog during automation tasks. 
It specifies whether to accept or dismiss the alert.

#### Values

##### Accept

The plugin will interact with the alert dialog in a way that acknowledges it, typically by clicking the `OK` or `Accept` button, if present. 
This action allows the automation process to continue smoothly without any interruptions caused by the alert dialog.
##### Dismiss

The plugin will interact with the alert dialog in a manner that closes it, typically by clicking the `Cancel` or `Dismiss` button, if present. 
This action enables the automation process to proceed without interruptions caused by the alert dialog.
##### Ignore

The plugin will interact with the alert dialog by ignoring it, allowing the automation process to continue without taking any action on the alert dialog.

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The plugin can use the Keys parameter to send specific text or input to the dialog. 
This input can be used to interact with the alert in a customized way, such as entering information or responding to prompts within the dialog.  

For example, if the `Keys` parameter is set to `Username123`, the plugin will send the text `Username123` to the alert dialog, allowing it to interact with any input fields or prompts within the dialog.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#user-prompts](https://www.w3.org/TR/webdriver/#user-prompts)
