# Add Pointer Down (AddPointerDown)

[Table of Content](../Home.md)

~16 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddPointerDown presses one pointer button and keeps it down.
It runs only inside InvokeInputActions, and the press happens where the last AddPointerMove action left the pointer.
Flows use it to start a drag, a long press, or a click that needs a held key or an exact position.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Five buttons | Presses the left, middle, right, back, or forward button. |
| Held state | Keeps the button down until an AddPointerUp action releases it. |
| Position from the last move | Presses at the place the pointer was last moved to. |
| Checked before sending | Fails on an unknown button name, and the container then sends nothing. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Drag and drop | Press on an item before moving it to its target. |
| Long press | Press, pause, and release to open a menu that needs a held button. |
| Selection by dragging | Press at the start of a text range or a canvas area before moving to its end. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Drag handlers | Verify that an item follows the pointer while the button is down. |
| Press states | Verify the pressed style of a button before it is released. |
| Context menus | Verify that the right button opens the expected menu. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Press the left button

A rule without an argument presses the left button.
The press happens where the last pointer move left the pointer, and the button stays down.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerDown"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerDown");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerDown"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerDown"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerDown"
}
```

### Example No.2

### Press the right button through the Button parameter

The Button parameter names the secondary button.
Together with a release it forms a right click at the current pointer position.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerDown",
    Argument = "{{$ --Button:Right}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerDown")
    .setArgument("{{$ --Button:Right}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerDown",
    argument: "{{$ --Button:Right}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerDown",
    "argument": "{{$ --Button:Right}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerDown",
    "argument": "{{$ --Button:Right}}"
}
```

### Example No.3

### Press the middle button with a plain argument

The plain argument names the button without the parameter form.
A middle press and release on a link opens it in a new tab in most browsers.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddPointerDown",
    Argument = "Middle"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddPointerDown")
    .setArgument("Middle");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddPointerDown",
    argument: "Middle"
};
```

**JSON:**

```js
{
    "pluginName": "AddPointerDown",
    "argument": "Middle"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddPointerDown",
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

Names the pointer button to press.
The plain argument of the rule is read as the button when no parameter is used.
Defaults to Left, and any name other than the listed ones fails the step.

#### Values

##### Left

Presses the main button, which a normal click uses.
It is the default when the rule names no button.

##### Middle

Presses the wheel button.
Browsers use it to open a link in a new tab.

##### Right

Presses the secondary button.
Applications use it to open a context menu.

##### Back

Presses the fourth button, found on the side of some mice.
Browsers use it to go back one page.

##### Forward

Presses the fifth button, found on the side of some mice.
Browsers use it to go forward one page.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
