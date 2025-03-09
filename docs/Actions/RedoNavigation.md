# Redo Navigation (RedoNavigation)

[Table of Content](../Home.md)  

~18 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `RedoNavigation` plugin is to automate the process of navigating forward within a web browser. 
It provides a structured and configurable way to perform the `forward` action, enabling automation scripts to simulate user interactions with precision. 
The plugin caters to scenarios where navigating forward multiple steps with optional delays between actions is a requirement.

### Key Features and Functionality

| Feature             | Description                                                                                                                |
|---------------------|----------------------------------------------------------------------------------------------------------------------------|
| Dynamic Repeats     | Allows specifying the number of times the browser should navigate forward, adapting to various automation needs.           |
| Configurable Delays | Introduces delays between each navigation step, enhancing flexibility and preventing interference with web responsiveness. |
| Intuitive Logging   | Incorporates logging capabilities, providing insights and transparency into the execution process.                         |

### Usages in RPA

| Usage                | Description                                                                                                      |
|----------------------|------------------------------------------------------------------------------------------------------------------|
| Multi-Step Processes | Streamlines multi-step workflows that involve navigating through multiple pages.                                 |
| Error Handling       | Navigates forward to a known state for retrying or taking alternative actions if certain conditions are not met. |

### Usages in Automation Testing

| Usage                    | Description                                                                           |
|--------------------------|---------------------------------------------------------------------------------------|
| Browser State Management | Manages the state of the browser in end-to-end tests involving complex user journeys. |
| Performance Testing      | Simulates realistic user interactions with controlled navigation forward and delays.  |

## Examples

### Example No.1

Perform a default browser forward navigation. 
This is useful for simple scenarios where returning to the previous web page is required without specifying additional parameters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RedoNavigation"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RedoNavigation");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RedoNavigation"
};
```

_**JSON**_

```js
{
    "pluginName": "RedoNavigation"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RedoNavigation"
}
```
### Example No.2

Navigate the web browser forward by three steps. 
The provided argument, `3`, specifies the number of repeats for the navigation action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RedoNavigation",
    Argument = "3"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RedoNavigation")
    .setArgument("3");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RedoNavigation",
    argument: "3"
};
```

_**JSON**_

```js
{
    "pluginName": "RedoNavigation",
    "argument": "3"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RedoNavigation",
    "argument": "3"
}
```
### Example No.3

Command the `RedoNavigation` plugin to conduct a series of forward navigations in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:1000}}`, precisely dictates three repetitions with a `1000-millisecond` delay between each step. 
This configuration grants meticulous control over the forward navigation process, including the number of repeats and inter-step delays.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RedoNavigation",
    Argument = "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RedoNavigation")
    .setArgument("{{$ --Repeat:3 --Delay:1000}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RedoNavigation",
    argument: "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RedoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RedoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```
### Example No.4

Command the `RedoNavigation` plugin to execute a sequence of forward navigations in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:00:00:01}}`, dictates three repetitions with a `1-second` delay between each step. 
This example showcases how the plugin can be configured with supplementary parameters, offering precise control over the navigation process.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RedoNavigation",
    Argument = "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RedoNavigation")
    .setArgument("{{$ --Repeat:3 --Delay:00:00:01}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RedoNavigation",
    argument: "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RedoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:00:00:01}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RedoNavigation",
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

Allow users to customize the behavior of the plugin by providing supplementary information or instructions. 
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

Specifies the pause or waiting period between each step of the forward navigation process. 
This parameter allows users to specify a duration, either in milliseconds or a formatted time expression, to control the pace of the navigation.

### Repeat (Repeat)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The number of iterations for the forward navigation process. 
It is instrumental in scenarios where repetitive navigation actions are essential for achieving specific automation objectives.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#forward](https://www.w3.org/TR/webdriver/#forward)
