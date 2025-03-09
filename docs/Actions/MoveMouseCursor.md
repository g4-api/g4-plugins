# Move Mouse Cursor (MoveMouseCursor)

[Table of Content](../Home.md)  

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `MoveMouseCursor` plugin is to automate mouse cursor movements on web pages. 
This plugin provides a mechanism to move the mouse cursor programmatically to specific coordinates or web elements as part of automated workflows or tests.

### Key Features and Functionality

| Feature              | Description                                                                                                                                                                           |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element Targeting    | Moves the mouse cursor to specified web elements using locators.                                                                                                                      |
| Coordinate Targeting | Moves the mouse cursor to specific X and Y coordinates on the page.                                                                                                                   |
| Versatility          | Handles both web elements and coordinate-based cursor movements, making it suitable for various scenarios.                                                                            |
| Precision            | Enables precise control over cursor positioning for interactive web elements and dynamic content.                                                                                     |
| Origin Parameter     | Specifies the reference point for the cursor movement. Options include 'Pointer' (relative to the current position) and 'Viewport' (relative to the top-left corner of the viewport). |

### Usages in RPA

| Usage               | Description                                                                          |
|---------------------|--------------------------------------------------------------------------------------|
| UI Interaction      | Automating mouse movements to interact with specific elements on web pages.          |
| Workflow Navigation | Navigating through workflows by moving the cursor to specific positions or elements. |
| Data Extraction     | Hovering over elements to reveal hidden data or tooltips for extraction.             |

### Usages in Automation Testing

| Usage                       | Description                                                                                                |
|-----------------------------|------------------------------------------------------------------------------------------------------------|
| UI Testing                  | Performing mouse movements to test interactions with dynamic web elements.                                 |
| Hover Actions               | Testing hover actions and verifying the display of tooltips, dropdowns, or other hover-triggered elements. |
| Interactive Element Testing | Ensuring that interactive elements respond correctly to cursor movements and positioning.                  |

## Examples

### Example No.1

Move the mouse cursor to a web element identified by the CSS selector `#TargetElement`. 
This can be used to interact with or highlight the specified element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Locator = "CssSelector",
    OnElement = "#TargetElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setLocator("CssSelector")
    .setOnElement("#TargetElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    locator: "CssSelector",
    onElement: "#TargetElement"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "locator": "CssSelector",
    "onElement": "#TargetElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "locator": "CssSelector",
    "onElement": "#TargetElement"
}
```
### Example No.2

Move the mouse cursor to the coordinates (100, 200) on the page. 
This can be useful for scenarios where precise cursor positioning is required for interacting with specific areas of the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:100 --Y:200}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:100 --Y:200}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:100 --Y:200}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:100 --Y:200}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:100 --Y:200}}"
}
```
### Example No.3

Move the mouse cursor to the top-left corner of the page (coordinates 0, 0). 
This can be used to reset the cursor position or interact with elements located at the top-left corner of the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:0 --Y:0}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:0 --Y:0}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:0 --Y:0}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:0 --Y:0}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:0 --Y:0}}"
}
```
### Example No.4

Move the mouse cursor to the coordinates (300, 400) with the origin set to 'Pointer'. 
This can be useful for scenarios where the movement should be relative to the current pointer position.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:300 --Y:400 --Origin:Pointer}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:300 --Y:400 --Origin:Pointer}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:300 --Y:400 --Origin:Pointer}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:300 --Y:400 --Origin:Pointer}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:300 --Y:400 --Origin:Pointer}}"
}
```
### Example No.5

Move the mouse cursor to the coordinates (300, 400) with the origin set to 'Viewport'. 
This ensures that the movement is relative to the top-left corner of the viewport.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveMouseCursor",
    Argument = "{{$ --X:300 --Y:400 --Origin:Viewport}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveMouseCursor")
    .setArgument("{{$ --X:300 --Y:400 --Origin:Viewport}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "MoveMouseCursor",
    argument: "{{$ --X:300 --Y:400 --Origin:Viewport}}"
};
```

_**JSON**_

```js
{
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:300 --Y:400 --Origin:Viewport}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "MoveMouseCursor",
    "argument": "{{$ --X:300 --Y:400 --Origin:Viewport}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides additional instructions or parameters to control the behavior of the mouse movement action.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of locator used to identify the target element defined by the `OnElement` property.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target element to which the mouse cursor should be moved.

## Parameters

### Origin (Origin)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the origin point for the mouse movement. Can be either 'Pointer' or 'Viewport'.

#### Values

##### Pointer

The origin is the current position of the pointer.
##### Viewport

The origin is the top-left corner of the viewport.

### X (X)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal coordinate (X) to move the mouse cursor to on the page.

### Y (Y)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical coordinate (Y) to move the mouse cursor to on the page.

## Scope

* Mobile Web
* Os Native
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
