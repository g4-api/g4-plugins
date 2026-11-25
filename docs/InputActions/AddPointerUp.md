# Add Pointer Up (AddPointerUp)

[Table of Content](../Home.md)

~16 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddPointerUp releases one pointer button.
It runs only inside InvokeInputActions, and the release happens where the last AddPointerMove action left the pointer.
Flows use it to drop a dragged item, to end a long press, and to complete a click.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Five buttons | Releases the left, middle, right, back, or forward button. |
| Position from the last move | Releases at the place the pointer was last moved to, which is where a drag drops. |
| Release across groups | Releases a button that an earlier group left down, because the driver keeps the pointer state. |
| Checked before sending | Fails on an unknown button name, and the container then sends nothing. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Drag and drop | Release an item over its target to drop it. |
| Long press | Release after a pause to complete a press-and-hold. |
| Clicks at a position | Complete a click that was started at an exact pointer position. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Drop handlers | Verify that an item lands in the target when the button is released. |
| Release states | Verify that a pressed style is removed when the button is released. |
| State reset | Return the pointer to a clean state between test cases. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Release the left button

A rule without an argument releases the left button.
The release happens where the last pointer move left the pointer, which is where a dragged item drops.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerUp"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerUp");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerUp"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerUp"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerUp"
}
```

### Example No.2

### Release the right button through the Button parameter

The Button parameter names the secondary button.
It completes a right click that an AddPointerDown action started.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerUp",
    Argument = "{{$ --Button:Right}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerUp")
    .setArgument("{{$ --Button:Right}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerUp",
    argument: "{{$ --Button:Right}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerUp",
    "argument": "{{$ --Button:Right}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerUp",
    "argument": "{{$ --Button:Right}}"
}
```

### Example No.3

### Release the middle button with a plain argument

The plain argument names the button without the parameter form.
It completes a middle click that an AddPointerDown action started.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerUp",
    Argument = "Middle"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerUp")
    .setArgument("Middle");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerUp",
    argument: "Middle"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerUp",
    "argument": "Middle"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerUp",
    "argument": "Middle"
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

Holds the button, as plain text such as `Right` or as `{{$ --Button:Right}}`.
A rule without an argument uses the left button.

## Parameters

### Button (Button)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Left               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names the pointer button to release.
The plain argument of the rule is read as the button when no parameter is used.
Defaults to Left, and any name other than the listed ones fails the step.

#### Values

##### Left

Releases the main button, which a normal click uses.
It is the default when the rule names no button.

##### Middle

Releases the wheel button.
Browsers use it to open a link in a new tab.

##### Right

Releases the secondary button.
Applications use it to open a context menu.

##### Back

Releases the fourth button, found on the side of some mice.
Browsers use it to go back one page.

##### Forward

Releases the fifth button, found on the side of some mice.
Browsers use it to go forward one page.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
