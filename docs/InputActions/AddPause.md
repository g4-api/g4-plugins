# Add Pause (AddPause)

[Table of Content](../Home.md)

~16 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddPause makes the driver wait in the middle of a gesture.
It runs only inside InvokeInputActions, and the wait happens on the driver side, between two actions of the same sequence.
Flows use it to hold a press, to let a hover menu open, and to give a page time to react during a drag.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Timed wait | Waits a whole number of milliseconds, such as `500`, or a time span, such as `00:00:02`. |
| State kept | Leaves pressed keys and buttons down during the wait. |
| Inside the sequence | Waits between two actions of one request, which a separate wait step cannot do. |
| Checked before sending | Fails on text that is not a duration, and the container then sends nothing. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Long press | Hold a button for a second to open a menu that needs a held press. |
| Hover menus | Wait for a menu to open before the pointer moves to an item that is already in the page. |
| Paced drags | Wait over a drop target until it highlights. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Timing checks | Verify that a long press and a short press give different results. |
| Animation checks | Wait for an animation that starts on hover before the next action. |
| Debounce checks | Verify that a page ignores input that arrives faster than its debounce time. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Wait half a second

The plain argument sets the wait in milliseconds.
Keys and buttons that are down stay down during the wait.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPause",
    Argument = "500"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPause")
    .setArgument("500");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPause",
    argument: "500"
};
```

**JSON:**

```js
{
    "pluginName": "AddPause",
    "argument": "500"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPause",
    "argument": "500"
}
```

### Example No.2

### Wait two seconds through the Duration parameter

The Duration parameter sets the wait as a time span.
Use this form when the value comes from a flow parameter or a macro.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPause",
    Argument = "{{$ --Duration:00:00:02}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPause")
    .setArgument("{{$ --Duration:00:00:02}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPause",
    argument: "{{$ --Duration:00:00:02}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddPause",
    "argument": "{{$ --Duration:00:00:02}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPause",
    "argument": "{{$ --Duration:00:00:02}}"
}
```

### Example No.3

### Add an empty step without waiting

A rule without an argument adds a pause of zero milliseconds.
It adds one empty step to the sequence and changes no key or button.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPause"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPause");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPause"
};
```

**JSON:**

```js
{
    "pluginName": "AddPause"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPause"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the wait, as plain text such as `500` or as `{{$ --Duration:500}}`.
A rule without an argument adds a pause of zero milliseconds.

## Parameters

### Duration (Duration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Sets how long the driver waits before the next action.
Accepts a whole number of milliseconds, such as `500`, or a time span, such as `00:00:02`.
Defaults to 0, and a negative value or text that is not a duration fails the step.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
