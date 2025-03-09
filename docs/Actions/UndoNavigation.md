# Undo Navigation (UndoNavigation)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `UndoNavigation` plugin is to automate the process of navigating backward within a web browser. 
It provides a structured and configurable way to perform the `back` action, enabling automation scripts to simulate user interactions with precision. 
The plugin caters to scenarios where navigating back multiple steps with optional delays between actions is a requirement.

### Key Features and Functionality

| Feature             | Description                                                                                  |
|---------------------|----------------------------------------------------------------------------------------------|
| Dynamic Repeats     | Allows users to specify the number of times the browser should navigate back.                |
| Configurable Delays | Users can introduce delays between each navigation step, enhancing the plugin's flexibility. |
| Intuitive Logging   | Logs a warning if the specified delay exceeds the maximum allowed value.                     |

### Usages in RPA

| Usage                | Description                                                                                      |
|----------------------|--------------------------------------------------------------------------------------------------|
| Multi-Step Processes | Streamlines automation scripts by automating backward navigation through multiple pages.         |
| Error Handling       | Utilized in error-handling mechanisms to navigate back to a known state before retrying actions. |

### Usages in Automation Testing

| Usage                    | Description                                                                                      |
|--------------------------|--------------------------------------------------------------------------------------------------|
| Browser State Management | Aids in managing the state of the browser during complex user journeys in automated test suites. |
| Performance Testing      | Contributes to a more accurate representation of user behavior by controlling navigation delays. |

## Examples

### Example No.1

Perform a default browser back navigation. 
This is useful for simple scenarios where returning to the previous web page is required without specifying additional parameters.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UndoNavigation"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UndoNavigation");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UndoNavigation"
};
```

_**JSON**_

```js
{
    "pluginName": "UndoNavigation"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UndoNavigation"
}
```
### Example No.2

Navigate the web browser back by three steps. 
The provided argument, `3`, specifies the number of repeats for the navigation action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UndoNavigation",
    Argument = "3"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UndoNavigation")
    .setArgument("3");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UndoNavigation",
    argument: "3"
};
```

_**JSON**_

```js
{
    "pluginName": "UndoNavigation",
    "argument": "3"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UndoNavigation",
    "argument": "3"
}
```
### Example No.3

Navigate the web browser back by three steps. 
The argument `--Repeat:3` explicitly designates the number of repetitions for the navigation action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UndoNavigation",
    Argument = "3"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UndoNavigation")
    .setArgument("3");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UndoNavigation",
    argument: "3"
};
```

_**JSON**_

```js
{
    "pluginName": "UndoNavigation",
    "argument": "3"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UndoNavigation",
    "argument": "3"
}
```
### Example No.4

Command the `UndoNavigation` plugin to conduct a series of backward navigations in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:1000}}`, precisely dictates three repetitions with a `1000-millisecond` delay between each step. 
This instance exemplifies how the UndoNavigation plugin can be finely configured with supplementary parameters, granting meticulous control over the backward navigation process, including the number of repeats and inter-step delays.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UndoNavigation",
    Argument = "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UndoNavigation")
    .setArgument("{{$ --Repeat:3 --Delay:1000}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UndoNavigation",
    argument: "{{$ --Repeat:3 --Delay:1000}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UndoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UndoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:1000}}"
}
```
### Example No.5

Command the `UndoNavigation` plugin to execute a sequence of backward navigations in the web browser. 
The provided argument, `{{$ --Repeat:3 --Delay:00:00:01}}`, precisely dictates three repetitions with a `1-second` delay between each step. 
This example showcases how the `UndoNavigation` plugin can be meticulously configured with supplementary parameters, offering precise control over the backward navigation process, including the number of repeats and inter-step delays specified in a time format.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UndoNavigation",
    Argument = "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UndoNavigation")
    .setArgument("{{$ --Repeat:3 --Delay:00:00:01}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "UndoNavigation",
    argument: "{{$ --Repeat:3 --Delay:00:00:01}}"
};
```

_**JSON**_

```js
{
    "pluginName": "UndoNavigation",
    "argument": "{{$ --Repeat:3 --Delay:00:00:01}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "UndoNavigation",
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
| **Value Type**    | String|Expression |

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

Specifies the pause or waiting period between each step of the backward navigation process. 
This parameter allows users to specify a duration, either in milliseconds or a formatted time expression, to control the pace of the navigation.

### Repeat (Repeat)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

The number of iterations for the backward navigation process. 
It is instrumental in scenarios where repetitive navigation actions are essential for achieving specific automation objectives.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#back](https://www.w3.org/TR/webdriver/#back)
