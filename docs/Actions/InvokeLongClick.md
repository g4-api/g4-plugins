# Invoke Long Click (InvokeLongClick)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Long-presses an element or the current touch position on a mobile device.
The action presses a touch pointer, holds it for the given duration, then releases it, as one W3C pointer action sequence.
Use it to open context menus, start selection mode or trigger any press-and-hold behavior.
The G4 Android recorder records a long click as this action, with the recorded hold time.

### Key Features and Functionality

| Feature               | Description                                                                  |
| --- | --- |
| Press and Hold        | Presses a touch pointer, pauses for the duration, then releases it.          |
| Configurable Duration | Duration sets the hold time in milliseconds; 1000 is used when it is absent. |
| Element Targeting     | Moves the touch pointer to the element center before the press.              |
| Positional Press      | Long-presses at the current touch position when no element is given.         |

### Usages in RPA

| Use Case             | Description                                                           |
| --- | --- |
| Open Context Menus   | Opens the long-press menu of a list item to copy, share or delete it. |
| Start Selection Mode | Starts multi-select in lists that enter selection on a long press.    |

### Usages in Automation Testing

| Use Case             | Description                                                  |
| --- | --- |
| Long Press Handlers  | Verifies that an element reacts to a press-and-hold gesture. |
| Recorded Flow Replay | Replays a long click captured by the G4 Android recorder.    |

## Examples

### Example No.1

### Long-press a list item for 1.5 seconds

Finds the first list item, presses it with a touch pointer for 1500 milliseconds and releases it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeLongClick",
    Argument = "{{$ --Duration:1500}}",
    OnElement = "(//android.widget.TextView)[1]"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeLongClick")
    .setArgument("{{$ --Duration:1500}}")
    .setOnElement("(//android.widget.TextView)[1]");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeLongClick",
    argument: "{{$ --Duration:1500}}",
    onElement: "(//android.widget.TextView)[1]"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeLongClick",
    "argument": "{{$ --Duration:1500}}",
    "onElement": "(//android.widget.TextView)[1]"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeLongClick",
    "argument": "{{$ --Duration:1500}}",
    "onElement": "(//android.widget.TextView)[1]"
}
```

### Example No.2

### Long-press at the current position

Presses and holds the touch pointer for the default 1000 milliseconds without locating an element.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeLongClick"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeLongClick");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeLongClick"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeLongClick"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeLongClick"
}
```

## Properties

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator selects the strategy used to find the element named by OnElement.
Xpath is used when it is absent.
Locator has an effect only when OnElement is also provided.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement holds the locator expression of the element to long-press.
It is read with the strategy set by the Locator property.
When it is absent, the long press happens at the current touch position instead.

## Parameters

### Duration (Duration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 1000              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Duration sets how long the touch pointer stays pressed, in milliseconds.
A missing, zero, negative or non-numeric value uses the 1000 millisecond default.
Android reports a long click once the hold passes the device long-press timeout, usually about 500 milliseconds.

## Scope

* Mobile Native
* Mobile Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
