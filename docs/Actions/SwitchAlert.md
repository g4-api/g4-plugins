# Switch Alert (SwitchAlert)

[Table of Content](../Home.md)  

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Switches WebDriver focus to the active browser alert dialog and performs a configurable action: accept, dismiss, or no-action pass-through.
An optional `Keys` parameter sends text to prompt dialogs before the action is applied.
When invoked with no argument and no parameters, the alert is dismissed by default.

### Key Features and Functionality

| Feature            | Description                                                                                                                                            |
|--------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| Default Dismiss    | Dismisses the alert when invoked with no argument and no parameters (early-exit branch: `Parameters.Count == 0` AND `Argument` is empty).              |
| Accept             | Calls `alert.Approve()` when `AlertAction` resolves to `Accept` (case-insensitive, exact match — whitespace is not trimmed).                           |
| Dismiss            | Calls `alert.Close()` when `AlertAction` resolves to `Dismiss` (case-insensitive, exact match — whitespace is not trimmed).                            |
| Ignore / No-Action | Any `AlertAction` value other than `Accept` or `Dismiss` — including `Ignore` — is a deliberate pass-through; neither accept nor dismiss is performed. |
| Keys Input         | Sends text via `alert.SendKeys()` only when `Keys` is non-null and non-empty; always executed before the accept/dismiss action.                        |

### Usages in RPA

| Usage                       | Description                                                                                                    |
|-----------------------------|----------------------------------------------------------------------------------------------------------------|
| Alert Notification Handling | Automatically accept or dismiss confirmation dialogs triggered during automated form submission or navigation. |
| Prompt Input Automation     | Send dynamic text to prompt dialogs and accept them to satisfy required inputs without manual intervention.    |
| Error Recovery              | Dismiss unexpected alert dialogs to allow the automation process to recover and continue execution.            |

### Usages in Automation Testing

| Usage                  | Description                                                                             |
|------------------------|-----------------------------------------------------------------------------------------|
| Alert Acceptance Tests | Verify that the application responds correctly when alert dialogs are accepted.         |
| Dismiss Behavior       | Confirm that dismissing an alert leaves the application in the expected state.          |
| Prompt Input Testing   | Validate that text entered in prompt dialogs is processed correctly by the application. |

## Examples

### Example No.1

### Dismiss an alert by default (no argument)

Dismiss the active alert dialog without providing any argument or parameters.
When both `Parameters.Count` is 0 and `Argument` is empty, the plugin takes the early-exit dismiss path and calls `alert.Close()` immediately.

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

### Accept an alert dialog

Accept the active alert dialog by setting `Argument` to `Accept`.
The value is compared case-insensitively, so `ACCEPT`, `accept`, and `Accept` all trigger `alert.Approve()`.

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

### Ignore an alert (no-action pass-through)

Switch to the alert dialog without accepting or dismissing it by setting `Argument` to `Ignore`.
Because `Ignore` is neither `Accept` nor `Dismiss`, both action branches are skipped and the alert remains open.
Any value other than `Accept` or `Dismiss` produces the same no-action result.

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

### Send keys to a prompt dialog (no action)

Send the text `Foo Bar` to the active prompt dialog without accepting or dismissing it.
Because no `AlertAction` is specified, only `alert.SendKeys()` is called — the alert remains open after this step.
Pair `Keys` with `AlertAction` in the same invocation when the dialog must also be closed.

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

### Send keys to a prompt and accept

Send the text `Foo Bar` to the active prompt dialog and then accept it.
`alert.SendKeys()` is called first; `alert.Approve()` is called immediately after.

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

### Send keys to a prompt and dismiss

Send the text `Foo Bar` to the active prompt dialog and then dismiss it.
`alert.SendKeys()` is called first; `alert.Close()` is called immediately after.
Use this pattern to verify that the application handles a canceled prompt input correctly.

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

Specifies the alert action or provides named parameters for the `SwitchAlert` plugin.
Accepts a plain action value (`Accept`, `Dismiss`, `Ignore`) or a parameterized expression such as `{{$ --Keys:text --AlertAction:Accept}}`.
When absent, the plugin uses the default dismiss behavior.

## Parameters

### Alert Action (AlertAction)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the action to perform on the active alert dialog.
Resolved from the named `AlertAction` parameter first; falls back to the raw `Argument` string if the named parameter is absent.
Comparison is case-insensitive: `Accept`, `ACCEPT`, and `accept` are all equivalent.

#### Values

##### Accept

Calls `alert.Approve()`, equivalent to clicking the `OK` or `Accept` button on the dialog.
##### Dismiss

Calls `alert.Close()`, equivalent to clicking the `Cancel` or `Dismiss` button on the dialog.
##### Ignore

Neither `alert.Approve()` nor `alert.Close()` is called — the alert dialog remains open.
This is the fallthrough behavior: any `AlertAction` value other than `Accept` or `Dismiss` produces the same no-action result.

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Text to send to the active alert dialog via `alert.SendKeys()` before `AlertAction` is applied.
Intended for prompt dialogs that require text input.
If omitted or empty, no keys are sent.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#user-prompts](https://www.w3.org/TR/webdriver/#user-prompts)
