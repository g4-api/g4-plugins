# Invoke User32 Drag And Drop (InvokeUser32DragAndDrop)

[Table of Content](../Home.md)

~23 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

InvokeUser32DragAndDrop drags with the left mouse button in a Windows desktop application. The drag starts on an element or at a screen point, and ends on another element, at a screen point, or a number of pixels away.
It asks the UIA driver for the screen point of the source, and of the target when one is set, presses the left button on the source, moves the cursor in short steps, and releases over the target or at the end of the offset.
Flows use it to move items between lists, to reorder rows, and to move splitters and slider handles.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Target element | Drops on a point of the element named by the Target XPath. |
| Alignment points | Grabs and drops at the center, an edge, or a corner of each element, shifted by pixel offsets. |
| Drag by offset | Moves the element by DeltaX and DeltaY screen pixels when the rule names no target. |
| Stepped path | Moves the cursor in short steps, 10 by default, so applications that wait for the Windows drag threshold start the drag. |
| Paced moves | Spreads the moves over Duration, 300 milliseconds by default. |
| Release on failure | Releases the left button when the driver refuses the drag, so it does not stay pressed on the desktop. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| List transfers | Move an item from one list or tree to another in a desktop application. |
| Row order | Reorder rows of a grid that supports dragging. |
| Layout handles | Move a splitter or a slider handle by an exact number of pixels. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Drop checks | Verify that a dropped item appears in its new list. |
| Order checks | Verify that a grid keeps the order a drag sets. |
| Handle limits | Verify that a splitter or a slider stops at its allowed range. |

### Platform

This plugin works on **Windows** only, with the UIA driver.
It moves the real cursor, so the application window must be visible, and it drags with the left button without modifier keys.

## Examples

### Example No.1

### Move an item to another list

The `onElement` value names the list item, and Target names the list to drop on.
Both points are element centers, and the cursor moves in 10 steps over 300 milliseconds.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DragAndDrop",
    Argument = "{{$ --Target://List[@AutomationId='DoneList']}}",
    OnElement = "//ListItem[@Name='Invoice 7']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DragAndDrop")
    .setArgument("{{$ --Target://List[@AutomationId='DoneList']}}")
    .setOnElement("//ListItem[@Name='Invoice 7']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeUser32DragAndDrop",
    argument: "{{$ --Target://List[@AutomationId='DoneList']}}",
    onElement: "//ListItem[@Name='Invoice 7']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://List[@AutomationId='DoneList']}}",
    "onElement": "//ListItem[@Name='Invoice 7']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://List[@AutomationId='DoneList']}}",
    "onElement": "//ListItem[@Name='Invoice 7']"
}
```

### Example No.2

### Drop at the top of a target

TargetAlignment and TargetOffsetY place the drop point 4 pixels below the top center of the target row.
Use it when an application inserts above or below a row depending on where the item is dropped.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DragAndDrop",
    Argument = "{{$ --Target://DataItem[@Name='Row 2'] --TargetAlignment:TopCenter --TargetOffsetX:0 --TargetOffsetY:4}}",
    OnElement = "//DataItem[@Name='Row 5']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DragAndDrop")
    .setArgument("{{$ --Target://DataItem[@Name='Row 2'] --TargetAlignment:TopCenter --TargetOffsetX:0 --TargetOffsetY:4}}")
    .setOnElement("//DataItem[@Name='Row 5']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeUser32DragAndDrop",
    argument: "{{$ --Target://DataItem[@Name='Row 2'] --TargetAlignment:TopCenter --TargetOffsetX:0 --TargetOffsetY:4}}",
    onElement: "//DataItem[@Name='Row 5']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://DataItem[@Name='Row 2'] --TargetAlignment:TopCenter --TargetOffsetX:0 --TargetOffsetY:4}}",
    "onElement": "//DataItem[@Name='Row 5']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://DataItem[@Name='Row 2'] --TargetAlignment:TopCenter --TargetOffsetX:0 --TargetOffsetY:4}}",
    "onElement": "//DataItem[@Name='Row 5']"
}
```

### Example No.3

### Move a splitter by an offset

DeltaX moves the splitter 150 screen pixels to the right.
Steps and Duration slow the move for an application that redraws while it follows the cursor.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DragAndDrop",
    Argument = "{{$ --DeltaX:150 --DeltaY:0 --Steps:20 --Duration:600}}",
    OnElement = "//Thumb[@AutomationId='Splitter']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DragAndDrop")
    .setArgument("{{$ --DeltaX:150 --DeltaY:0 --Steps:20 --Duration:600}}")
    .setOnElement("//Thumb[@AutomationId='Splitter']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeUser32DragAndDrop",
    argument: "{{$ --DeltaX:150 --DeltaY:0 --Steps:20 --Duration:600}}",
    onElement: "//Thumb[@AutomationId='Splitter']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --DeltaX:150 --DeltaY:0 --Steps:20 --Duration:600}}",
    "onElement": "//Thumb[@AutomationId='Splitter']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --DeltaX:150 --DeltaY:0 --Steps:20 --Duration:600}}",
    "onElement": "//Thumb[@AutomationId='Splitter']"
}
```

### Example No.4

### Grab a panel by its title strip

Alignment, OffsetX, and OffsetY grab the panel 20 pixels right of and 8 pixels below its top-left corner, where its title strip is.
The panel is dropped on the center of the right dock area.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DragAndDrop",
    Argument = "{{$ --Target://Pane[@AutomationId='RightDock'] --Alignment:TopLeft --OffsetX:20 --OffsetY:8}}",
    OnElement = "//Pane[@AutomationId='ToolsPanel']"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DragAndDrop")
    .setArgument("{{$ --Target://Pane[@AutomationId='RightDock'] --Alignment:TopLeft --OffsetX:20 --OffsetY:8}}")
    .setOnElement("//Pane[@AutomationId='ToolsPanel']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeUser32DragAndDrop",
    argument: "{{$ --Target://Pane[@AutomationId='RightDock'] --Alignment:TopLeft --OffsetX:20 --OffsetY:8}}",
    onElement: "//Pane[@AutomationId='ToolsPanel']"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://Pane[@AutomationId='RightDock'] --Alignment:TopLeft --OffsetX:20 --OffsetY:8}}",
    "onElement": "//Pane[@AutomationId='ToolsPanel']"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --Target://Pane[@AutomationId='RightDock'] --Alignment:TopLeft --OffsetX:20 --OffsetY:8}}",
    "onElement": "//Pane[@AutomationId='ToolsPanel']"
}
```

### Example No.5

### Drag between two screen points

Presses at the screen point (300, 200), moves to (640, 420), and releases there, without an element.
Use this form for a drag recorded in coordinate mode, or for a canvas that exposes no elements.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeUser32DragAndDrop",
    Argument = "{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeUser32DragAndDrop")
    .setArgument("{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeUser32DragAndDrop",
    argument: "{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeUser32DragAndDrop",
    "argument": "{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}"
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

Holds the parameters of the drag, such as `{{$ --Target://ListItem[@Name='Archive']}}`.
A rule sets one start, OnElement or X and Y, and one end, Target, TargetX and TargetY, or DeltaX and DeltaY, and may add alignments, offsets, Steps, and Duration.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the OnElement value finds the element to drag.
Xpath is the locator the User32 elements support, and it is the default.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the element to drag, as an XPath.
The drag starts on the point of this element that Alignment, OffsetX, and OffsetY select.
Leave it out to start at the X and Y screen point instead; setting both, or neither, fails the step, and an element that is not found fails it before anything is pressed.

## Parameters

### Alignment (Alignment)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects the point of the dragged element where the drag starts.
The point is a corner, an edge center, or the center of the element bounding box, shifted by the matching offsets.
Defaults to MiddleCenter; an unknown value makes the UIA driver refuse the request.

#### Values

##### Bottom Center

Places the point at the bottom center of the element bounding box.
Use this alignment when the grab or drop point is near the lower middle edge of the element.

##### Bottom Left

Places the point at the bottom left corner of the element bounding box.
Use this alignment when the grab or drop point is near the lower left boundary of the element.

##### Bottom Right

Places the point at the bottom right corner of the element bounding box.
Use this alignment when the grab or drop point is near the lower right boundary of the element.

##### Middle Center

Places the point at the horizontal and vertical center of the element bounding box.
It is the default alignment and suits most drags.

##### Middle Left

Places the point at the left edge and vertical center of the element bounding box.
Use this alignment when the grab or drop point is near the left side of the element.

##### Middle Right

Places the point at the right edge and vertical center of the element bounding box.
Use this alignment when the grab or drop point is near the right side of the element.

##### Top Center

Places the point at the top center of the element bounding box.
Use this alignment when the grab or drop point is near the upper middle edge of the element.

##### Top Left

Places the point at the top left corner of the element bounding box.
Use this alignment when the grab or drop point is near the upper left boundary of the element.

##### Top Right

Places the point at the top right corner of the element bounding box.
Use this alignment when the grab or drop point is near the upper right boundary of the element.

### Delta X (DeltaX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal distance of a drag by offset, in screen pixels, where a positive value points right.
It is measured from the grab point: the point of the OnElement element that Alignment, OffsetX, and OffsetY select, or the X and Y screen point.
Use it instead of Target or TargetX and TargetY; setting more than one end, or text that is not a whole number, fails the step.

### Delta Y (DeltaY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical distance of a drag by offset, in screen pixels, where a positive value points down.
It is measured from the grab point: the point of the OnElement element that Alignment, OffsetX, and OffsetY select, or the X and Y screen point.
Use it instead of Target or TargetX and TargetY; setting more than one end, or text that is not a whole number, fails the step.

### Duration (Duration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 300               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Sets the total time of the moves between the press and the release.
Accepts a whole number of milliseconds, such as `600`, or a time span, such as `00:00:01`.
Defaults to 300 milliseconds, and a negative value or text that is not a duration fails the step.

### Offset X (OffsetX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Shifts the grab point by this many pixels on the horizontal axis.
A positive value moves the point right, measured from the point the matching alignment selects.
Defaults to 0, and text that is not a whole number fails the step.

### Offset Y (OffsetY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Shifts the grab point by this many pixels on the vertical axis.
A positive value moves the point down, measured from the point the matching alignment selects.
Defaults to 0, and text that is not a whole number fails the step.

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

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the element to drop on, as an XPath, the locator the User32 elements support.
The search starts from the root of the session and waits for the element like any other element.
Use it instead of TargetX and TargetY or DeltaX and DeltaY; setting more than one end, or none, fails the step.

### Target Alignment (TargetAlignment)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | MiddleCenter      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects the point of the target element where the drag ends.
The point is a corner, an edge center, or the center of the element bounding box, shifted by the matching offsets.
Defaults to MiddleCenter, and is read only when Target is set.

#### Values

##### Bottom Center

Places the point at the bottom center of the element bounding box.
Use this alignment when the grab or drop point is near the lower middle edge of the element.

##### Bottom Left

Places the point at the bottom left corner of the element bounding box.
Use this alignment when the grab or drop point is near the lower left boundary of the element.

##### Bottom Right

Places the point at the bottom right corner of the element bounding box.
Use this alignment when the grab or drop point is near the lower right boundary of the element.

##### Middle Center

Places the point at the horizontal and vertical center of the element bounding box.
It is the default alignment and suits most drags.

##### Middle Left

Places the point at the left edge and vertical center of the element bounding box.
Use this alignment when the grab or drop point is near the left side of the element.

##### Middle Right

Places the point at the right edge and vertical center of the element bounding box.
Use this alignment when the grab or drop point is near the right side of the element.

##### Top Center

Places the point at the top center of the element bounding box.
Use this alignment when the grab or drop point is near the upper middle edge of the element.

##### Top Left

Places the point at the top left corner of the element bounding box.
Use this alignment when the grab or drop point is near the upper left boundary of the element.

##### Top Right

Places the point at the top right corner of the element bounding box.
Use this alignment when the grab or drop point is near the upper right boundary of the element.

### Target Offset X (TargetOffsetX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Shifts the drop point by this many pixels on the horizontal axis.
A positive value moves the point right, measured from the point the matching alignment selects.
Defaults to 0, and text that is not a whole number fails the step.

### Target Offset Y (TargetOffsetY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Shifts the drop point by this many pixels on the vertical axis.
A positive value moves the point down, measured from the point the matching alignment selects.
Defaults to 0, and text that is not a whole number fails the step.

### Target X (TargetX)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal screen coordinate, in pixels, where the drag ends and the button is released.
Use it with TargetY instead of Target or DeltaX and DeltaY; a missing TargetY counts as zero.
Setting more than one end, or text that is not a whole number, fails the step.

### Target Y (TargetY)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical screen coordinate, in pixels, where the drag ends and the button is released.
Use it with TargetX instead of Target or DeltaX and DeltaY; a missing TargetX counts as zero.
Setting more than one end, or text that is not a whole number, fails the step.

### X (X)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the horizontal screen coordinate, in pixels, where the drag starts when the rule names no OnElement element.
Use it with Y instead of OnElement, for a drag recorded or written as screen points; a missing Y counts as zero.
Setting it together with OnElement, or text that is not a whole number, fails the step.

### Y (Y)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the vertical screen coordinate, in pixels, where the drag starts when the rule names no OnElement element.
Use it with X instead of OnElement, for a drag recorded or written as screen points; a missing X counts as zero.
Setting it together with OnElement, or text that is not a whole number, fails the step.

## Scope

* Windows Native
