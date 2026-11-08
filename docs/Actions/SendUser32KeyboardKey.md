# Send User32 Keyboard Key (SendUser32KeyboardKey)

[Table of Content](../Home.md)

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sends keyboard keys and shortcuts to the active native Windows application through the User32 API.
It drives native or legacy applications that cannot be controlled through standard WebDriver keyboard input.

### Key Features and Functionality

| Feature                    | Description                                                                    |
| --- | --- |
| Native Application Support | Sends hardware scan codes to the active native Windows application.            |
| Multi-Key Sequences        | Repeats the `Key` parameter to press several keys in order.                    |
| Sticky Mode                | Holds all keys down together and releases them in reverse order for shortcuts. |
| Configurable Delay         | Sets the pause between keys; a value of 0 uses 100 milliseconds.               |
| Keyboard Layout Selection  | Switches between the `en-US` and `he-IL` layouts before sending keys.          |
| Alternate Key Names        | Accepts common spellings such as `Delete`, `PageDown`, and `Space`.            |

### Usages in RPA

| Use Case              | Description                                                                                   |
| --- | --- |
| Native App Automation | Drives native application menus, dialogs, and commands with keyboard shortcuts.               |
| Legacy Systems        | Automates legacy applications that cannot be driven through standard WebDriver keyboard APIs. |

### Usages in Automation Testing

| Use Case                     | Description                                                                                     |
| --- | --- |
| Keyboard Interaction Testing | Verifies keyboard-driven behavior of native applications with operating-system-level key input. |
| Shortcut Coverage            | Tests shortcuts and modifier combinations that standard WebDriver keyboard input cannot reach.  |

### Limitations

An unknown key name is not reported as an error: without `Sticky` it sends nothing, and with `Sticky` it sends an invalid scan code.

## Examples

### Example No.1

### Single key press via plain Argument

Send a single `F5` key press to the active native application window.
The key name is passed directly as the Argument value without any parameter expression, making this the simplest form of the plugin.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "F5"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("F5");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "F5"
};
```

**JSON:**

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "F5"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "F5"
}
```

### Example No.2

### Sticky keyboard shortcut — Ctrl+C

Simulate pressing `Ctrl + C` simultaneously using sticky mode to send the copy shortcut to the active native application.
The `--Sticky` switch holds both keys down and then releases them in reverse order, which modifier-key combinations require.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Ctrl --Key:C --Sticky}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Ctrl --Key:C --Sticky}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Ctrl --Key:C --Sticky}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:C --Sticky}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:C --Sticky}}"
}
```

### Example No.3

### Sequential Tab key presses with delay

Simulate pressing the `Tab` key three times in sequence with a 300-millisecond delay between each press to navigate through input fields in a native application form.
In non-sticky mode each key is pressed and released individually in the order specified.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
}
```

### Example No.4

### Sticky input language switch — Alt+Shift with the Hebrew layout

Select the `he-IL` layout and press `Alt + Shift` together with `Sticky`.
The driver switches to the Hebrew layout first, and Alt+Shift then toggles to the next installed input language.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
}
```

### Example No.5

### Three-key sticky combination — Ctrl+Shift+Esc

Simulate pressing `Ctrl + Shift + Esc` simultaneously using sticky mode to open the Windows Task Manager.
All three keys are held down and then released in reverse order, which this system-level keyboard shortcut requires.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Carries the `{{$ --Key:Name}}` parameter expression or a single key name to send through the User32 API.
When no parameter expression is used, the raw Argument value is sent as one key name.
Use the expression form to send several keys or to set `Sticky`, `Delay`, or `KeyboardLayout`.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Sets the pause between keys in milliseconds, given as a number or a time string such as `00:00:00.300`.
A value of `0`, the default, uses the driver minimum of 100 milliseconds between keys.
With `Sticky`, the pause applies between key presses, and the keys are then released without a pause.
Increase it when the target application needs more time to process each key.

### Key (Key)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Names one key to press, such as `Enter`, `Ctrl`, or `F5`; repeat the parameter to send several keys in order.
When the parameter is omitted, the rule `Argument` value is used as a single key name.
Common alternate spellings, such as `Delete`, `PageDown`, or `Space`, are accepted and converted before sending.
Without `Sticky`, an uppercase letter is sent as Shift plus that letter, so use a lowercase letter for a plain key press.

#### Values

##### Spacebar

Represents the Spacebar key.
Also accepted as `Space`.

Represents the Apostrophe (`'`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Comma (`,`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Hyphen (`-`) key.
It sends the same physical key in every supported layout.

Represents the Period (`.`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Slash (`/`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Semicolon (`;`) key.
It sends the same physical key in every supported layout.

Represents the Equals (`=`) key.
It sends the same physical key in every supported layout.

Represents the Open bracket (`[`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Backslash (`\`) key.
It sends the same physical key in every supported layout.

Represents the Close bracket (`]`) key.
In the `he-IL` layout, this name is sent through a different physical key.

Represents the Grave accent (`` ` ``) key.
It sends the same physical key in every supported layout.

##### 0

Represents the `0` key on the main keyboard row.
Also accepted as `Num 0`, which sends the same main-row key.

##### 1

Represents the `1` key on the main keyboard row.
Also accepted as `Num 1`, which sends the same main-row key.

##### 2

Represents the `2` key on the main keyboard row.
Also accepted as `Num 2`, which sends the same main-row key.

##### 3

Represents the `3` key on the main keyboard row.
Also accepted as `Num 3`, which sends the same main-row key.

##### 4

Represents the `4` key on the main keyboard row.
Also accepted as `Num 4`, which sends the same main-row key.

##### 5

Represents the `5` key on the main keyboard row.
Also accepted as `Num 5`, which sends the same main-row key.

##### 6

Represents the `6` key on the main keyboard row.
Also accepted as `Num 6`, which sends the same main-row key.

##### 7

Represents the `7` key on the main keyboard row.
Also accepted as `Num 7`, which sends the same main-row key.

##### 8

Represents the `8` key on the main keyboard row.
Also accepted as `Num 8`, which sends the same main-row key.

##### 9

Represents the `9` key on the main keyboard row.
Also accepted as `Num 9`, which sends the same main-row key.

##### A

Represents the `A` key.
Without `Sticky`, this uppercase name is sent as Shift+A, so use `a` for a plain key press.

##### B

Represents the `B` key.
Without `Sticky`, this uppercase name is sent as Shift+B, so use `b` for a plain key press.

##### C

Represents the `C` key.
Without `Sticky`, this uppercase name is sent as Shift+C, so use `c` for a plain key press.

##### D

Represents the `D` key.
Without `Sticky`, this uppercase name is sent as Shift+D, so use `d` for a plain key press.

##### E

Represents the `E` key.
Without `Sticky`, this uppercase name is sent as Shift+E, so use `e` for a plain key press.

##### F

Represents the `F` key.
Without `Sticky`, this uppercase name is sent as Shift+F, so use `f` for a plain key press.

##### G

Represents the `G` key.
Without `Sticky`, this uppercase name is sent as Shift+G, so use `g` for a plain key press.

##### H

Represents the `H` key.
Without `Sticky`, this uppercase name is sent as Shift+H, so use `h` for a plain key press.

##### I

Represents the `I` key.
Without `Sticky`, this uppercase name is sent as Shift+I, so use `i` for a plain key press.

##### J

Represents the `J` key.
Without `Sticky`, this uppercase name is sent as Shift+J, so use `j` for a plain key press.

##### K

Represents the `K` key.
Without `Sticky`, this uppercase name is sent as Shift+K, so use `k` for a plain key press.

##### L

Represents the `L` key.
Without `Sticky`, this uppercase name is sent as Shift+L, so use `l` for a plain key press.

##### M

Represents the `M` key.
Without `Sticky`, this uppercase name is sent as Shift+M, so use `m` for a plain key press.

##### N

Represents the `N` key.
Without `Sticky`, this uppercase name is sent as Shift+N, so use `n` for a plain key press.

##### O

Represents the `O` key.
Without `Sticky`, this uppercase name is sent as Shift+O, so use `o` for a plain key press.

##### P

Represents the `P` key.
Without `Sticky`, this uppercase name is sent as Shift+P, so use `p` for a plain key press.

##### Q

Represents the `Q` key.
Without `Sticky`, this uppercase name is sent as Shift+Q, so use `q` for a plain key press.

##### R

Represents the `R` key.
Without `Sticky`, this uppercase name is sent as Shift+R, so use `r` for a plain key press.

##### S

Represents the `S` key.
Without `Sticky`, this uppercase name is sent as Shift+S, so use `s` for a plain key press.

##### T

Represents the `T` key.
Without `Sticky`, this uppercase name is sent as Shift+T, so use `t` for a plain key press.

##### U

Represents the `U` key.
Without `Sticky`, this uppercase name is sent as Shift+U, so use `u` for a plain key press.

##### V

Represents the `V` key.
Without `Sticky`, this uppercase name is sent as Shift+V, so use `v` for a plain key press.

##### W

Represents the `W` key.
Without `Sticky`, this uppercase name is sent as Shift+W, so use `w` for a plain key press.

##### X

Represents the `X` key.
Without `Sticky`, this uppercase name is sent as Shift+X, so use `x` for a plain key press.

##### Y

Represents the `Y` key.
Without `Sticky`, this uppercase name is sent as Shift+Y, so use `y` for a plain key press.

##### Z

Represents the `Z` key.
Without `Sticky`, this uppercase name is sent as Shift+Z, so use `z` for a plain key press.

##### Alt

Represents the left Alt key.
Hold it with `Sticky` for shortcuts such as `Alt+F4` or `Alt+Tab`.

##### Backspace

Represents the Backspace key.
Use it to delete the character before the cursor.

##### Caps Lock

Represents the Caps Lock key.
Also accepted as `Caps Lock`.

##### Center

Represents the numeric keypad 5 (Center) key.
It is sent as a keypad key, so its effect depends on the Num Lock state.

##### Ctrl

Represents the left Control key.
Hold it with `Sticky` for shortcuts such as `Ctrl+C` or `Ctrl+S`.

##### Del

Represents the Delete key.
Also accepted as `Delete` or `Num Del`.

##### Down

Represents the Down arrow key.
Use it to move the cursor or selection down.

##### End

Represents the End key.
Use it to move the cursor to the end of a line or list.

##### Enter

Represents the Enter key.
Also accepted as `Num Enter`, which sends the main Enter key.

##### Esc

Represents the Escape key.
Use it to close dialogs or cancel the current operation.

##### F1

Represents the F1 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F2

Represents the F2 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F3

Represents the F3 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F4

Represents the F4 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F5

Represents the F5 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F6

Represents the F6 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F7

Represents the F7 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F8

Represents the F8 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F9

Represents the F9 function key.
Its effect depends on the shortcut the target application assigns to it.

##### F10

Represents the F10 function key.
Its effect depends on the shortcut the target application assigns to it.

##### Home

Represents the Home key.
Use it to move the cursor to the start of a line or list.

##### Ins

Represents the Insert key.
Also accepted as `Insert`.

##### Left

Represents the Left arrow key.
Use it to move the cursor or selection left.

##### L Shift

Represents the Left Shift key.
Hold it with `Sticky` to combine it with another key.

##### Num

Represents the Num Lock key.
Also accepted as `NumLock` or `Num Lock`.

##### Pg Dn

Represents the Page Down key.
Also accepted as `PageDown` or `Page Down`.

##### Pg Up

Represents the Page Up key.
Also accepted as `PageUp` or `Page Up`.

##### Prt Sc

Represents the Print Screen key.
Also accepted as `PrintScreen`, `Print Screen`, or `Prnt Scrn`.

##### Right

Represents the Right arrow key.
Use it to move the cursor or selection right.

##### R Shift

Represents the Right Shift key.
Hold it with `Sticky` to combine it with another key.

##### Scroll

Represents the Scroll Lock key.
Also accepted as `ScrollLock` or `Scroll Lock`.

##### Shift

Represents the Shift key and is sent as the Left Shift key (`LShift`).
Hold it with `Sticky` for shortcuts such as `Ctrl+Shift+Esc`.

##### Tab

Represents the Tab key.
Use it to move focus to the next field or control.

##### Up

Represents the Up arrow key.
Use it to move the cursor or selection up.

### Sticky (Sticky)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Presses all keys in order and holds them, then releases them in reverse order when present.
Use it for shortcuts that need modifier keys held down, such as `Ctrl+C`, `Alt+F4`, or `Alt+Tab`.
Without the switch, each key is pressed and released on its own in the order given.

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the keyboard layout used to switch the system input language and map key names to scan codes.
Use `en-US` for English keys and `he-IL` for the Hebrew Standard layout; the default is `en-US`.
The `he-IL` layout maps Hebrew letters instead of Latin letters and sends `/`, `'`, `,`, `.`, `[`, and `]` through different physical keys.
The driver switches to the selected layout before it sends any key.

#### Values

##### En Us

Selects the English (United States) keyboard layout.
It is used when the parameter is omitted.

##### He Il

Selects the Hebrew Standard keyboard layout.
Latin letter names are not mapped in this layout, so use the Hebrew letters or switch to `en-US` for them.

## Scope

* Windows Native

## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput)
