# Invoke Drag And Drop (InvokeDragAndDrop)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

InvokeDragAndDrop drags one element and drops it on another element, or moves it by a number of pixels.
It presses the left button on the center of the source, moves in short steps, and releases over the center of the target or at the end of the offset, the way a user drags with a mouse.
Flows use it to move cards between columns, to reorder lists, and to move slider handles.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Target element | Drops on the center of the element named by Target, found with TargetLocator. |
| Drag by offset | Moves the element by DeltaX and DeltaY pixels when the rule names no target. |
| Stepped path | Moves in short steps, 10 by default, so pages that wait for the pointer to pass a drag threshold start the drag. |
| Paced moves | Spreads the moves over Duration, 300 milliseconds by default. |
| Native and pointer drags | Works with native HTML drag events and with drag libraries that follow pointer events. |
| One request | Sends the press, the moves, and the release together, and releases the button when the driver rejects the drag. |
| Loop element | Drags the current element of a for-each loop when the rule names none. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Task boards | Move a card to another column of a task board. |
| List order | Reorder rows or items by dragging them into place. |
| Sliders | Move a slider handle by an exact number of pixels. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Drop checks | Verify that a dropped item appears in its new place. |
| Order checks | Verify that a list keeps the order a drag sets. |
| Drop zone rules | Verify that a page refuses a drop on a zone that does not accept the item. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet; use InvokeUser32DragAndDrop for Windows desktop applications.

## Examples

### Example No.1

### Drop a card on another column

The `onElement` value names the card with an XPath, and Target names the column with another XPath.
The card moves in 10 steps over 300 milliseconds and is released over the center of the column.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDragAndDrop",
    Argument = "{{$ --Target://div[@id='done-column']}}",
    OnElement = "//div[@id='card-7']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDragAndDrop")
    .setArgument("{{$ --Target://div[@id='done-column']}}")
    .setOnElement("//div[@id='card-7']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeDragAndDrop",
    argument: "{{$ --Target://div[@id='done-column']}}",
    onElement: "//div[@id='card-7']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target://div[@id='done-column']}}",
    "onElement": "//div[@id='card-7']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target://div[@id='done-column']}}",
    "onElement": "//div[@id='card-7']"
}
```

### Example No.2

### Drop an item found with CSS selectors

The Locator and TargetLocator values switch both searches to CSS selectors.
The item is dropped on the trash zone.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDragAndDrop",
    Argument = "{{$ --Target:#trash --TargetLocator:CssSelector}}",
    Locator = "CssSelector",
    OnElement = "#item-3"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDragAndDrop")
    .setArgument("{{$ --Target:#trash --TargetLocator:CssSelector}}")
    .setLocator("CssSelector")
    .setOnElement("#item-3");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeDragAndDrop",
    argument: "{{$ --Target:#trash --TargetLocator:CssSelector}}",
    locator: "CssSelector",
    onElement: "#item-3"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target:#trash --TargetLocator:CssSelector}}",
    "locator": "CssSelector",
    "onElement": "#item-3"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target:#trash --TargetLocator:CssSelector}}",
    "locator": "CssSelector",
    "onElement": "#item-3"
}
```

### Example No.3

### Move a slider handle by an offset

DeltaX and DeltaY move the handle by pixels instead of onto an element.
The handle moves 120 pixels to the right.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDragAndDrop",
    Argument = "{{$ --DeltaX:120 --DeltaY:0}}",
    OnElement = "//div[@role='slider']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDragAndDrop")
    .setArgument("{{$ --DeltaX:120 --DeltaY:0}}")
    .setOnElement("//div[@role='slider']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeDragAndDrop",
    argument: "{{$ --DeltaX:120 --DeltaY:0}}",
    onElement: "//div[@role='slider']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --DeltaX:120 --DeltaY:0}}",
    "onElement": "//div[@role='slider']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --DeltaX:120 --DeltaY:0}}",
    "onElement": "//div[@role='slider']"
}
```

### Example No.4

### Drag slowly for a page that follows the pointer

Steps and Duration make the path longer and slower.
The row moves in 25 steps over one second, written as a time span.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDragAndDrop",
    Argument = "{{$ --Target://li[@data-slot='3'] --Steps:25 --Duration:00:00:01}}",
    OnElement = "//li[@data-row='8']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDragAndDrop")
    .setArgument("{{$ --Target://li[@data-slot='3'] --Steps:25 --Duration:00:00:01}}")
    .setOnElement("//li[@data-row='8']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeDragAndDrop",
    argument: "{{$ --Target://li[@data-slot='3'] --Steps:25 --Duration:00:00:01}}",
    onElement: "//li[@data-row='8']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target://li[@data-slot='3'] --Steps:25 --Duration:00:00:01}}",
    "onElement": "//li[@data-row='8']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeDragAndDrop",
    "argument": "{{$ --Target://li[@data-slot='3'] --Steps:25 --Duration:00:00:01}}",
    "onElement": "//li[@data-row='8']"
}
```

## Properties

### Argument (Argument)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Holds the parameters of the drag, such as `{{$ --Target://div[@id='done']}}`.
A rule sets either Target or DeltaX and DeltaY, and may add Steps and Duration.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the OnElement value finds the element to drag.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
Defaults to Xpath, and is read only when OnElement is set.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the element to drag, in the form the Locator selects.
The drag starts on the center of this element; inside a for-each loop a rule without it drags the loop element.
An element that is not found fails the step before anything is pressed.

## Parameters

### Delta X (DeltaX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal distance of a drag by offset, in pixels, where a positive value points right.
It is measured from the center of the element being dragged.
Use it instead of Target; setting both, or text that is not a whole number, fails the step.

### Delta Y (DeltaY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical distance of a drag by offset, in pixels, where a positive value points down.
It is measured from the center of the element being dragged.
Use it instead of Target; setting both, or text that is not a whole number, fails the step.

### Duration (Duration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 300               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number\|Time      |

Sets the total time of the moves between the press and the release.
Accepts a whole number of milliseconds, such as `600`, or a time span, such as `00:00:01`.
Defaults to 300 milliseconds, and a negative value or text that is not a duration fails the step.

### Steps (Steps)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 10                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many moves carry the element from the source to the end point.
More steps give a smoother path for applications that follow the pointer closely.
Defaults to 10, and a value outside 1 to 100 fails the step.

### Target (Target)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names the element to drop on, in the form TargetLocator selects.
The drag ends on the center of this element, which is searched in the whole page and waited for like any other element.
Use it instead of DeltaX and DeltaY; setting both, or neither, fails the step.

### Target Locator (TargetLocator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the Target value finds the element to drop on.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
Defaults to Xpath, and is read only when Target is set.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
