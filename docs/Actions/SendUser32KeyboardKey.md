# Send User32 Keyboard Key (SendUser32KeyboardKey)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SendUser32KeyboardKey` plugin simulates keyboard inputs using the Windows User32 API, targeting native application elements.
It is designed for scenarios where automation must interact with native or legacy Windows applications that lack standard WebDriver support.

### Key Features and Functionality

| Feature                    | Description                                                                                           |
|----------------------------|-------------------------------------------------------------------------------------------------------|
| Native Application Support | Sends keyboard scan codes to native Windows application windows via the User32 API.                   |
| Multi-Key Sequences        | Supports repeating the `Key` parameter to build ordered sequences of key presses.                     |
| Sticky Mode                | Holds all specified keys down simultaneously and releases them together, enabling keyboard shortcuts. |
| Configurable Delay         | Introduces a per-key delay in milliseconds to simulate realistic interaction timing.                  |
| Keyboard Layout Selection  | Maps key names to scan codes using the specified locale, supporting multilingual keyboard inputs.     |

### Usage in RPA

| Usage                 | Description                                                                                                    |
|-----------------------|----------------------------------------------------------------------------------------------------------------|
| Native App Automation | Enables RPA workflows to interact with native application UI via keyboard shortcuts, navigation, and commands. |
| Legacy Systems        | Facilitates automation of legacy systems that cannot be driven through standard WebDriver keyboard APIs.       |

### Usage in Automation Testing

| Usage                   | Description                                                                                                           |
|-------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Application UI Testing  | Validates keyboard-driven interactions with native application elements using realistic OS-level key simulation.      |
| Comprehensive Scenarios | Expands test coverage to keyboard actions inaccessible through standard WebDriver, including shortcuts and modifiers. |

## Examples

### Example No.1

### Single key press via plain Argument

Send a single `F5` key press to the active native application window.
The key name is passed directly as the Argument value without any parameter expression, making this the simplest form of the plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "F5"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("F5");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "F5"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "F5"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "F5"
}
```
### Example No.2

### Sticky keyboard shortcut — Ctrl+C

Simulate pressing `Ctrl + C` simultaneously using sticky mode to send the copy shortcut to the active native application.
The `--Sticky` switch holds all specified keys down at once and releases them together, which is required for modifier-key combinations.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Ctrl --Key:C --Sticky}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Ctrl --Key:C --Sticky}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Ctrl --Key:C --Sticky}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:C --Sticky}}"
}
```

_**Python**_

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

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Tab --Key:Tab --Key:Tab --Delay:300}}"
}
```
### Example No.4

### Sticky layout switch — Alt+Shift with Hebrew keyboard layout

Simulate pressing `Alt + Shift` simultaneously using sticky mode to switch the OS keyboard layout to Hebrew Standard.
The `--KeyboardLayout:he-IL` parameter instructs the server to map key names using the Hebrew Standard scan code table.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:Shift --Sticky --KeyboardLayout:he-IL}}"
}
```
### Example No.5

### Three-key sticky combination — Ctrl+Shift+Esc

Simulate pressing `Ctrl + Shift + Esc` simultaneously using sticky mode to open the Windows Task Manager.
All three keys are held down at once and released together, which is required for this system-level keyboard shortcut.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Ctrl --Key:Shift --Key:Esc --Sticky}}"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Carries the parameter expression or the direct key name to send via the User32 API.
Use the `{{$ --Key:Name}}` expression format to specify key names and options as runtime parameters.
When no parameter expression is used, the raw Argument value is treated as the single key name to press.
This property is the primary input for the plugin when the Key parameter is not specified inline.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Specifies the pause in milliseconds between consecutive key inputs during sequential (non-sticky) key sending.
Accepts a time string (e.g., `00:00:00.300`) or a numeric value representing milliseconds.
Default is `0`, meaning keys are sent back-to-back without any pause.
Use this parameter to simulate realistic human interaction cadence or to ensure the target application processes each key before the next one arrives.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Specifies the keyboard key to press, identified by its key name.
Repeat this parameter for each key in the sequence; each occurrence adds one key to the scan code list sent to the driver.
If not provided, the plugin falls back to the rule Argument value as the key source.
Use the values list to identify supported key names for the target keyboard layout.

#### Values

##### 

Represents the Spacebar key.
##### 

Represents the Apostrophe (`'`) key.
##### 

Represents the Comma (`,`) key.
##### 

Represents the Hyphen (`-`) key.
##### 

Represents the Period (`.`) key.
##### 

Represents the Slash (`/`) key.
##### 0

Represents the `0` key.
##### 1

Represents the `1` key.
##### 2

Represents the `2` key.
##### 3

Represents the `3` key.
##### 4

Represents the `4` key.
##### 5

Represents the `5` key.
##### 6

Represents the `6` key.
##### 7

Represents the `7` key.
##### 8

Represents the `8` key.
##### 9

Represents the `9` key.
##### 

Represents the Semicolon (`;`) key.
##### 

Represents the Equals (`=`) key.
##### 

Represents the Open bracket (`[`) key.
##### 

Represents the Backslash (`\`) key.
##### 

Represents the Close bracket (`]`) key.
##### 

Represents the Grave accent (`` ` ``) key.
##### A

Represents the `A` key.
##### B

Represents the `B` key.
##### C

Represents the `C` key.
##### D

Represents the `D` key.
##### E

Represents the `E` key.
##### F

Represents the `F` key.
##### G

Represents the `G` key.
##### H

Represents the `H` key.
##### I

Represents the `I` key.
##### J

Represents the `J` key.
##### K

Represents the `K` key.
##### L

Represents the `L` key.
##### M

Represents the `M` key.
##### N

Represents the `N` key.
##### O

Represents the `O` key.
##### P

Represents the `P` key.
##### Q

Represents the `Q` key.
##### R

Represents the `R` key.
##### S

Represents the `S` key.
##### T

Represents the `T` key.
##### U

Represents the `U` key.
##### V

Represents the `V` key.
##### W

Represents the `W` key.
##### X

Represents the `X` key.
##### Y

Represents the `Y` key.
##### Z

Represents the `Z` key.
##### Alt

Represents the Alt key.
##### Arrow Down

Represents the Down arrow key (Arrow prefix form).
##### Arrow Left

Represents the Left arrow key (Arrow prefix form).
##### Arrow Right

Represents the Right arrow key (Arrow prefix form).
##### Arrow Up

Represents the Up arrow key (Arrow prefix form).
##### Backspace

Represents the Backspace key.
##### Caps Lock

Represents the Caps Lock key.
##### Center

Represents the Center key.
##### Control

Represents the Control key (full-name form of Ctrl).
##### Ctrl

Represents the Control (Ctrl) key.
##### Del

Represents the Delete key.
##### Down

Represents the Down arrow key.
##### End

Represents the End key.
##### Enter

Represents the Enter key.
##### Esc

Represents the Escape (Esc) key.
##### F1

Represents the F1 key.
##### F2

Represents the F2 key.
##### F3

Represents the F3 key.
##### F4

Represents the F4 key.
##### F5

Represents the F5 key.
##### F6

Represents the F6 key.
##### F7

Represents the F7 key.
##### F8

Represents the F8 key.
##### F9

Represents the F9 key.
##### F10

Represents the F10 key.
##### F11

Represents the F11 key.
##### F12

Represents the F12 key.
##### Home

Represents the Home key.
##### Ins

Represents the Insert key.
##### Left

Represents the Left arrow key.
##### L Shift

Represents the Left Shift key.
##### Meta

Represents the Windows (Meta/Super) key.
##### Num

Represents the Num Lock key.
##### Pg Dn

Represents the Page Down key.
##### Pg Up

Represents the Page Up key.
##### Prt Sc

Represents the Print Screen key.
##### Right

Represents the Right arrow key.
##### R Shift

Represents the Right Shift key.
##### Scroll

Represents the Scroll Lock key.
##### Shift

Represents the Shift key (generic, applies to either left or right Shift).
##### Tab

Represents the Tab key.
##### Up

Represents the Up arrow key.

### Sticky (Sticky)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

When present, enables sticky mode: all specified keys are pressed down simultaneously and released together at the end of the sequence.
Use sticky mode for keyboard shortcuts that require modifier keys to be held while pressing a regular key, such as `Ctrl+C`, `Alt+F4`, or `Win+R`.
Without this switch, each key is pressed and released individually in the order specified.

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the BCP-47 locale identifier used to map key names to OS-level scan codes.
Use `en-US` for standard English keyboard input and `he-IL` for Hebrew Standard keyboard layout.
The default layout is `en-US` when this parameter is omitted.
Specifying the correct layout is important when sending keys on non-English systems or when triggering OS layout-switch shortcuts.

#### Values

##### En Us

English (United States) keyboard layout. This is the default.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput)
