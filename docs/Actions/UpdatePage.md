# Update Page (UpdatePage)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Automates refreshing the current browser page, equivalent to pressing F5 or clicking the browser's refresh button.
It provides a structured way to perform the refresh action with configurable repeat counts and optional delays between iterations.

### Key Features and Functionality

| Feature             | Description                                                                                                                  |
|---------------------|------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Repeats     | Configures how many times the page is refreshed in a single action invocation.                                               |
| Configurable Delays | Introduces a pause between each refresh, in milliseconds or time span format, to control the reload pace.                    |
| Legacy Argument     | Accepts a plain integer directly as the repeat count for backwards-compatible usage.                                         |
| Delay Safeguard     | Logs a warning and resets the delay to zero when the configured value exceeds the maximum allowed integer millisecond range. |

### Usages in RPA

| Use Case         | Description                                                                                                    |
|------------------|----------------------------------------------------------------------------------------------------------------|
| Periodic Updates | Automates periodic page reloads to ensure the automation script is working with fresh content from the server. |
| Error Recovery   | Returns the browser to a clean page state before retrying a failed automation sequence.                        |

### Usages in Automation Testing

| Use Case                 | Description                                                                                                              |
|--------------------------|--------------------------------------------------------------------------------------------------------------------------|
| Browser State Management | Manages the browser DOM state during complex tests by issuing controlled refreshes to reset page-level JavaScript state. |
| Performance Testing      | Measures page load behavior under repeated refresh scenarios with controlled delays to produce realistic timing data.    |

## Examples

### Example No.1

### Default single page refresh

Refreshes the current browser page once using default settings.
No repeat count or delay is configured, so the action executes immediately and completes after a single reload.

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

### Multiple page refreshes using an integer argument

Refreshes the current browser page three times by passing `3` as a plain integer argument.
The integer is interpreted directly as the repeat count without requiring parameter expression syntax.

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

### Multiple page refreshes with repeat count and delay

Refreshes the current browser page three times, pausing 1000 milliseconds between each refresh.
The `{{$ --Repeat:3 --Delay:1000}}` argument expression sets both the repeat count and the inter-refresh delay in a single value.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Expression |

Provides the primary input for the page refresh action.
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

Controls the pause between each page refresh.
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

Sets how many times the page is refreshed in one action invocation.
Useful when multiple consecutive reloads are required without issuing separate refresh commands.
When no valid value is provided, the page is refreshed exactly once.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#refresh](https://www.w3.org/TR/webdriver/#refresh)
