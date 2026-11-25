# Add Key Down (AddKeyDown)

[Table of Content](../Home.md)

~16 min · InputAction Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

AddKeyDown presses one keyboard key and keeps it down.
It runs only inside InvokeInputActions, which sends the press together with the other actions of the gesture.
Flows use it to hold Control or Shift during clicks and to build keyboard shortcuts key by key.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Named keys | Accepts key names such as Control, Shift, Alt, Enter, Tab, Escape, and ArrowDown. |
| Single characters | Accepts one character, such as `a` or `5`, as the key. |
| Held state | Keeps the key down until an AddKeyUp action releases it. |
| Checked before sending | Fails on an unknown key name, and the container then sends nothing. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Multi-selection | Hold Control or Shift while later actions click several items. |
| Keyboard shortcuts | Start a shortcut such as Ctrl+S by pressing its modifier key first. |
| Modified drags | Hold Alt or Shift while a drag gesture runs. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Shortcut checks | Verify that a key combination triggers the expected command. |
| Key-hold behavior | Verify how a page reacts while a key stays down. |
| Modifier checks | Verify that a click with a modifier key extends a selection or opens a link in a new tab. |

### Platform

This plugin currently supports **Web** only.
Desktop and mobile drivers are not supported yet.

## Examples

### Example No.1

### Press and hold the Control key

The plain argument names the key.
The press is added to the sequence of the group, and the key stays down for the actions that follow.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddKeyDown",
    Argument = "Control"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddKeyDown")
    .setArgument("Control");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddKeyDown",
    argument: "Control"
};
```

**JSON:**

```js
{
    "pluginName": "AddKeyDown",
    "argument": "Control"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddKeyDown",
    "argument": "Control"
}
```

### Example No.2

### Press Shift through the Key parameter

The Key parameter names the key in the parameter form of the argument.
Use this form when the key comes from a flow parameter or a macro.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddKeyDown",
    Argument = "{{$ --Key:Shift}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddKeyDown")
    .setArgument("{{$ --Key:Shift}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddKeyDown",
    argument: "{{$ --Key:Shift}}"
};
```

**JSON:**

```js
{
    "pluginName": "AddKeyDown",
    "argument": "{{$ --Key:Shift}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddKeyDown",
    "argument": "{{$ --Key:Shift}}"
}
```

### Example No.3

### Press a character key

A single character is used as the key itself.
Together with a held Control key it forms a shortcut such as Ctrl+A.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "AddKeyDown",
    Argument = "a"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("AddKeyDown")
    .setArgument("a");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "AddKeyDown",
    argument: "a"
};
```

**JSON:**

```js
{
    "pluginName": "AddKeyDown",
    "argument": "a"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "AddKeyDown",
    "argument": "a"
}
```

## Properties

### Argument (Argument)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | Yes                |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Holds the key, as plain text such as `Control` or as `{{$ --Key:Control}}`.
A rule without an argument fails, because a key action needs a key.

## Parameters

### Key (Key)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names the key to press: one of the listed key names, such as `Control`, `Shift`, or `Enter`, or a single character such as `a`.
The listed names are the key constants of the WebDriver client, and letter case is ignored.
The plain argument of the rule is read as the key when no parameter is used.
Text that is neither a listed name nor a single character, such as `Ctrl`, fails the step.

#### Values

##### Null

The NUL key value of the WebDriver key table.
In an input action it does not release other keys; release each held key with AddKeyUp.

##### Cancel

The Cancel key.
Few applications react to it.

##### Help

The Help key.
Some applications open their help with it.

##### Backspace

The Backspace key.
Deletes the character before the caret in a text field.

##### Tab

The Tab key.
Moves the focus to the next element.

##### Clear

The Clear key.
Found on some numeric keypads.

##### Return

The Return key.
A separate key from Enter in the WebDriver key table.

##### Enter

The Enter key.
Submits a form or confirms a dialog.

##### Shift

The Shift key.
A modifier key for capital letters, range selection, and shortcuts.

##### Left Shift

The same key as `Shift`, with the same key value.
Use either name; both resolve to one key.

##### Control

The Control key.
A modifier key for shortcuts and for adding items to a selection.

##### Left Control

The same key as `Control`, with the same key value.
Use either name; both resolve to one key.

##### Alt

The Alt key.
A modifier key for alternate characters and for shortcuts a page defines.

##### Left Alt

The same key as `Alt`, with the same key value.
Use either name; both resolve to one key.

##### Pause

The Pause key.
Few applications react to it.

##### Escape

The Escape key.
Closes a dialog, a menu, or a popup.

##### Space

The Space key.
Types a space, toggles a focused checkbox, or presses a focused button.

##### Page Up

The Page Up key.
Scrolls up by one page.

##### Page Down

The Page Down key.
Scrolls down by one page.

##### End

The End key.
Moves the caret to the end of the line, or scrolls to the end of the page.

##### Home

The Home key.
Moves the caret to the start of the line, or scrolls to the top of the page.

##### Left

The Left Arrow key.
Moves the caret or the selection one step left.

##### Arrow Left

The same key as `Left`, with the same key value.
Use either name; both resolve to one key.

##### Up

The Up Arrow key.
Moves the caret or the selection one step up.

##### Arrow Up

The same key as `Up`, with the same key value.
Use either name; both resolve to one key.

##### Right

The Right Arrow key.
Moves the caret or the selection one step right.

##### Arrow Right

The same key as `Right`, with the same key value.
Use either name; both resolve to one key.

##### Down

The Down Arrow key.
Moves the caret or the selection one step down.

##### Arrow Down

The same key as `Down`, with the same key value.
Use either name; both resolve to one key.

##### Insert

The Insert key.
Switches between insert and overwrite mode in some editors.

##### Delete

The Delete key.
Deletes the character after the caret, or the selected item.

##### Semicolon

The Semicolon key.
Types a semicolon.

##### Equal

The Equal key.
Types an equal sign.

##### Number Pad0

The 0 key of the numeric keypad.
Types 0 from the keypad.

##### Number Pad1

The 1 key of the numeric keypad.
Types 1 from the keypad.

##### Number Pad2

The 2 key of the numeric keypad.
Types 2 from the keypad.

##### Number Pad3

The 3 key of the numeric keypad.
Types 3 from the keypad.

##### Number Pad4

The 4 key of the numeric keypad.
Types 4 from the keypad.

##### Number Pad5

The 5 key of the numeric keypad.
Types 5 from the keypad.

##### Number Pad6

The 6 key of the numeric keypad.
Types 6 from the keypad.

##### Number Pad7

The 7 key of the numeric keypad.
Types 7 from the keypad.

##### Number Pad8

The 8 key of the numeric keypad.
Types 8 from the keypad.

##### Number Pad9

The 9 key of the numeric keypad.
Types 9 from the keypad.

##### Multiply

The Multiply key of the numeric keypad.
Types an asterisk from the keypad.

##### Add

The Add key of the numeric keypad.
Types a plus sign from the keypad.

##### Separator

The Separator key of the numeric keypad.
Found on some keypads only.

##### Subtract

The Subtract key of the numeric keypad.
Types a minus sign from the keypad.

##### Decimal

The Decimal key of the numeric keypad.
Types a period from the keypad.

##### Divide

The Divide key of the numeric keypad.
Types a slash from the keypad.

##### F1

The F1 function key.
Pages receive it as a key event; whether the browser opens its help depends on the driver.

##### F2

The F2 function key.
Many applications start renaming the selected item with it.

##### F3

The F3 function key.
Pages receive it as a key event; whether the browser finds the next match depends on the driver.

##### F4

The F4 function key.
Its meaning depends on the application.

##### F5

The F5 function key.
Pages receive it as a key event; whether the browser reloads depends on the driver.

##### F6

The F6 function key.
Its meaning depends on the application.

##### F7

The F7 function key.
Its meaning depends on the application.

##### F8

The F8 function key.
Its meaning depends on the application.

##### F9

The F9 function key.
Its meaning depends on the application.

##### F10

The F10 function key.
Its meaning depends on the application.

##### F11

The F11 function key.
Pages receive it as a key event; whether the browser switches to full screen depends on the driver.

##### F12

The F12 function key.
Pages receive it as a key event; whether the browser opens its developer tools depends on the driver.

##### Meta

The Meta key: the Windows key, or Command on macOS.
A modifier key for shortcuts a page or an application defines.

##### Command

The same key as `Meta`, with the same key value.
Use either name; both resolve to one key.

##### Zenkaku Hankaku

The Zenkaku/Hankaku key of Japanese keyboards.
Switches between full-width and half-width input.

## Scope

* Web

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
