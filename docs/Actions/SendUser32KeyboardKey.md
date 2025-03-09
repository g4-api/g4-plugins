# Send User32 Keyboard Key (SendUser32KeyboardKey)

[Table of Content](../Home.md)  

~33 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SendUser32KeyboardKey` plugin is to simulate keyboard inputs using the User32 API, targeting native application elements. This capability is useful for automation scenarios where interactions with native or legacy applications are required.

### Key Features and Functionality

| Feature                    | Description                                                                                                       |
|----------------------------|-------------------------------------------------------------------------------------------------------------------|
| Native Application Support | Supports sending keyboard inputs to elements in native Windows applications using User32 interactions.            |
| Dynamic Configuration      | Enables dynamic control over keyboard inputs with parameters like `Key`, `Delay`, `Sticky`, and `KeyboardLayout`. |
| Robust Interaction         | Ensures accurate simulation of keyboard presses at the OS level, providing reliability in various scenarios.      |

### Usage in RPA

| Usage                 | Description                                                                                                   |
|-----------------------|---------------------------------------------------------------------------------------------------------------|
| Native App Automation | Enables RPA workflows to interact seamlessly with native application UI components via simulated key presses. |
| Legacy Systems        | Facilitates automation interactions with legacy systems that lack direct WebDriver support.                   |

### Usage in Automation Testing

| Usage                   | Description                                                                                                           |
|-------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Application UI Testing  | Enhances test automation by simulating realistic keyboard interactions with native application elements.              |
| Comprehensive Scenarios | Provides broader test coverage by supporting keyboard actions typically inaccessible through standard WebDriver APIs. |

## Examples

### Example No.1

Simulate pressing `Alt + Shift` to switch keyboard layout to Hebrew Standard.

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
### Example No.2

Simulate pressing `Tab` key three times to navigate through input fields in a native application form, with a delay of 300 milliseconds between each press.

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
### Example No.3

Simulate pressing `Ctrl + Shift + Esc` simultaneously to open Windows Task Manager.

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
### Example No.4

Simulate pressing `Alt + F4` to close the currently active native application window using sticky keys mode.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Alt --Key:F4 --Sticky}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Alt --Key:F4 --Sticky}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Alt --Key:F4 --Sticky}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:F4 --Sticky}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Alt --Key:F4 --Sticky}}"
}
```
### Example No.5

Simulate pressing `Ctrl + C` to copy selected text using User32 interactions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Control --Key:C}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Control --Key:C}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Control --Key:C}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Control --Key:C}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Control --Key:C}}"
}
```
### Example No.6

Simulate pressing the sequence `Alt`, `F`, `F` to open the 'Save As' dialog in a Windows application, with a delay of 300 milliseconds between each key.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Control --Key:Alt --Key:S --Delay:300}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Control --Key:Alt --Key:S --Delay:300}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Control --Key:Alt --Key:S --Delay:300}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Control --Key:Alt --Key:S --Delay:300}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Control --Key:Alt --Key:S --Delay:300}}"
}
```
### Example No.7

Simulate pressing the `Arrow Down` key five times with a 150-millisecond delay to scroll through menu items in a native application.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Delay:150}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Delay:150}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Delay:150}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Delay:150}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Key:ArrowDown --Delay:150}}"
}
```
### Example No.8

Simulate pressing `Windows + R` to open the Run dialog box using sticky keys.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32KeyboardKey",
    Argument = "{{$ --Key:Meta --Key:r --Sticky}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32KeyboardKey")
    .setArgument("{{$ --Key:Meta --Key:r --Sticky}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32KeyboardKey",
    argument: "{{$ --Key:Meta --Key:r --Sticky}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Meta --Key:r --Sticky}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32KeyboardKey",
    "argument": "{{$ --Key:Meta --Key:r --Sticky}}"
}
```
### Example No.9

Simulate pressing `F5` to refresh the active native application or window.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Defines the instructions for keyboard interactions to simulate through User32 API.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Introduces a pause between consecutive keyboard inputs, allowing realistic simulation of user interactions.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Specifies keyboard keys to simulate pressing. Supports multiple sequential keys.

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
##### Backspace

Represents the Backspace key.
##### Caps Lock

Represents the Caps Lock key.
##### Center

Represents the Center key.
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
##### Home

Represents the Home key.
##### Ins

Represents the Insert key.
##### Left

Represents the Left arrow key.
##### L Shift

Represents the Left Shift key.
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

If enabled, keys are held down (sticky mode) until all specified keys are pressed, and then released together. Useful for combinations like shortcuts.

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the keyboard layout used to interpret keys when sending scan codes.

#### Values

##### En Us

English (United States) keyboard layout.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput)
