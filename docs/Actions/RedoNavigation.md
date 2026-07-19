# Redo Navigation (RedoNavigation)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Automates forward browser navigation, equivalent to clicking the browser's built-in forward button.
It provides a structured way to advance through session history with configurable repeat counts and optional delays between steps.

### Key Features and Functionality

| Feature             | Description                                                                                                                  |
|---------------------|------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Repeats     | Configures how many times the browser navigates forward in a single action invocation.                                       |
| Configurable Delays | Introduces a pause between each forward step, in milliseconds or time span format, to control navigation pace.               |
| Legacy Argument     | Accepts a plain integer directly as the repeat count for backwards-compatible usage.                                         |
| Delay Safeguard     | Logs a warning and resets the delay to zero when the configured value exceeds the maximum allowed integer millisecond range. |

### Usages in RPA

| Use Case             | Description                                                                                               |
|----------------------|-----------------------------------------------------------------------------------------------------------|
| Multi-Step Traversal | Advances through a sequence of previously visited pages in a single action without manual forward clicks. |
| State Restoration    | Navigates forward to restore a known browser state after automated back navigation.                       |

### Usages in Automation Testing

| Use Case                | Description                                                                                                    |
|-------------------------|----------------------------------------------------------------------------------------------------------------|
| Browser History Testing | Verifies that the browser correctly restores pages when navigating forward after a programmatic back sequence. |
| Navigation Flow Testing | Simulates realistic forward navigation patterns with controlled delays for performance test accuracy.          |

## Examples

### Example No.1

### Default single forward navigation

Navigates the browser forward by one step using default settings.
No repeat count or delay is configured, so the action executes once immediately.

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

### Forward navigation using an integer argument

Navigates the browser forward three times by passing `3` as a plain integer argument.
The integer is interpreted directly as the repeat count without requiring parameter expression syntax.

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

### Forward navigation with repeat count and delay

Navigates the browser forward three times, pausing 1000 milliseconds between each step.
The `{{$ --Repeat:3 --Delay:1000}}` argument expression sets both the repeat count and the inter-step delay in a single value.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Expression |

Provides the primary input for the forward navigation action.
Accepts either a plain integer as the repeat count or a parameter expression such as `{{$ --Repeat:3 --Delay:1000}}` for combined repeat and delay control.
When a plain integer is supplied and no `Repeat` parameter is present, the integer is used directly as the repeat count.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Controls the pause between each forward navigation step.
Accepts a value in milliseconds or a time span string such as `00:00:01` for one second.
When the configured delay exceeds the maximum allowed integer millisecond value, a warning is logged and the delay resets to zero.

### Repeat (Repeat)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many times the browser navigates forward in one action invocation.
Useful when advancing through multiple pages is required without issuing separate forward commands.
When no valid value is provided, the browser navigates forward exactly once.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#forward](https://www.w3.org/TR/webdriver/#forward)
