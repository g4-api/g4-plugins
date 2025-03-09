# Update Page (UpdatePage)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `UpdatePage` plugin is to automate the process of refreshing a web page within a browser. 
It provides a structured and configurable way to perform the `refresh` action, enabling automation scripts to simulate user interactions with precision. 
The plugin caters to scenarios where periodically refreshing a page with optional delays is a requirement.

### Key Features and Functionality

| Feature             | Description                                                                          |
|---------------------|--------------------------------------------------------------------------------------|
| Dynamic Refreshes   | Allows users to specify the number of times the page should be refreshed.            |
| Configurable Delays | Users can introduce delays between each refresh, enhancing the plugin's flexibility. |
| Intuitive Logging   | Logs a warning if the specified delay exceeds the maximum allowed value.             |

### Usages in RPA

| Usage            | Description                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------|
| Periodic Updates | Streamlines automation scripts by automating the periodic refresh of a web page.                    |
| Error Handling   | Utilized in error-handling mechanisms to refresh the page to a known state before retrying actions. |

### Usages in Automation Testing

| Usage                    | Description                                                                                                         |
|--------------------------|---------------------------------------------------------------------------------------------------------------------|
| Browser State Management | Aids in managing the state of the browser during long-running or complex tests by periodically refreshing the page. |
| Performance Testing      | Contributes to realistic performance testing by controlling page refreshes with specified delays.                   |

## Examples

### Example No.1

Perform a default browser page refresh. 
This is useful for simple scenarios where refreshing the current web page is required without specifying additional parameters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdatePage"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdatePage");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UpdatePage"
};
```

_**JSON**_

```js
{
    "pluginName": "UpdatePage"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UpdatePage"
}
```
### Example No.2

Refresh the web page by specifying the number of repetitions. 
The provided argument, `3`, specifies the number of repeats for the refresh action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdatePage",
    Argument = "3"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdatePage")
    .setArgument("3");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UpdatePage",
    argument: "3"
};
```

_**JSON**_

```js
{
    "pluginName": "UpdatePage",
    "argument": "3"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UpdatePage",
    "argument": "3"
}
```
### Example No.3

Refresh the web page by specifying the number of repetitions. 
The argument `--Repeat:3` explicitly designates the number of repetitions for the refresh action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdatePage",
    Argument = "3"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdatePage")
    .setArgument("3");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UpdatePage",
    argument: "3"
};
```

_**JSON**_

```js
{
    "pluginName": "UpdatePage",
    "argument": "3"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UpdatePage",
    "argument": "3"
}
```
### Example No.4

Command the `UpdatePage` plugin to conduct a series of page refreshes in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:1000}}`, precisely dictates three repetitions with a `1000-millisecond` delay between each step. 
This instance exemplifies how the `UpdatePage` plugin can be finely configured with supplementary parameters, granting meticulous control over the refresh process, including the number of repeats and inter-step delays.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdatePage",
    Argument = "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdatePage")
    .setArgument("{{$ --Repeat:3 --Delay:1000}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UpdatePage",
    argument: "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UpdatePage",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UpdatePage",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```
### Example No.5

Command the `UpdatePage` plugin to execute a sequence of page refreshes in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:00:00:01}}`, precisely dictates three repetitions with a `1-second` delay between each step. 
This example showcases how the `UpdatePage` plugin can be meticulously configured with supplementary parameters, offering precise control over the refresh process, including the number of repeats and inter-step delays specified in a time format.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdatePage",
    Argument = "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdatePage")
    .setArgument("{{$ --Repeat:3 --Delay:00:00:01}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UpdatePage",
    argument: "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UpdatePage",
    "argument": "{{$ --Repeat:3 --Delay:00:00:01}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UpdatePage",
    "argument": "{{$ --Repeat:3 --Delay:00:00:01}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Expression |

Allows users to customize the behavior of the plugin by providing supplementary information or instructions. 
It acts as a configurable parameter, enabling users to tailor the plugin's action to meet specific requirements.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Specifies the pause or waiting period between each step of the page refresh process. 
This parameter allows users to specify a duration, either in milliseconds or a formatted time expression, to control the pace of the refresh.

### Repeat (Repeat)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The number of iterations for the page refresh process. 
It is instrumental in scenarios where repetitive refresh actions are essential for achieving specific automation objectives.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#refresh](https://www.w3.org/TR/webdriver/#refresh)
