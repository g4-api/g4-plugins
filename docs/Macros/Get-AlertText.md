# Get Alert Text (Get-AlertText)

[Table of Content](../Home.md)  

~12 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Get-AlertText` plugin is designed for RPA and automation testing workflows, enabling efficient handling of alert dialogs by retrieving the text content within them. 
It plays a crucial role in capturing alert messages that appear during the execution of automated processes or test scripts, allowing these messages to be validated, responded to, or logged as needed.

### Key Features and Functionality

| Feature                     | Description                                                                                                          |
|-----------------------------|----------------------------------------------------------------------------------------------------------------------|
| Alert Text Retrieval        | Captures the text content of alert dialogs encountered during automation workflows.                                  |
| Integration with Automation | Seamlessly integrates with RPA processes and automation test scripts, enabling dynamic responses to alert messages.  |
| Enhanced Error Handling     | Improves error recovery by capturing and analyzing alert messages, allowing automated systems to respond correctly.  |

### Usages in RPA

| Usage          | Description                                                                                                       |
|----------------|-------------------------------------------------------------------------------------------------------------------|
| Alert Handling | Automatically captures and processes alert messages during RPA workflows, enabling informed decisions or actions. |
| Error Recovery | Supports robust error recovery mechanisms by detecting and handling alert dialogs in real-time.                   |

### Usages in Automation Testing

| Usage              | Description                                                                                                       |
|--------------------|-------------------------------------------------------------------------------------------------------------------|
| Alert Validation   | Validates the text content of alert dialogs during test script execution, ensuring expected behavior in web apps. |
| Exception Handling | Incorporates alert text retrieval into test scripts for handling unexpected conditions or errors.                 |

## Examples

### Example No.1

Retrieve the text content of an alert dialog and register it as a session-scoped parameter named 'AlertText'.
This example demonstrates using the `Get-AlertText` plugin to capture the alert text for later use in the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:AlertText --Value:{{$Get-AlertText}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:AlertText --Value:{{$Get-AlertText}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:AlertText --Value:{{$Get-AlertText}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:AlertText --Value:{{$Get-AlertText}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:AlertText --Value:{{$Get-AlertText}} --Scope:Session}}"
}
```
### Example No.2

Extract specific numeric data from an alert dialog using a regular expression and register it as a session-scoped parameter named 'ExtractedInfo'.
This example shows how to use the `Get-AlertText` plugin with a regex pattern to capture and store specific alert content for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:ExtractedInfo --Value:{{$Get-AlertText --Pattern:\d+}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:ExtractedInfo --Value:{{$Get-AlertText --Pattern:\d+}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:ExtractedInfo --Value:{{$Get-AlertText --Pattern:\d+}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ExtractedInfo --Value:{{$Get-AlertText --Pattern:\d+}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ExtractedInfo --Value:{{$Get-AlertText --Pattern:\d+}} --Scope:Session}}"
}
```

## Parameters

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regular expression pattern to be used for extracting specific information from the text content of alert dialogs.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-alert-text](https://www.w3.org/TR/webdriver/#get-alert-text)
