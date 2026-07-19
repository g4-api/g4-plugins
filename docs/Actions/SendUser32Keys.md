# Send User32 Keys (SendUser32Keys)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SendUser32Keys` plugin simulates realistic text typing into native Windows application elements using the Windows User32 API.
It is designed for automation scenarios that require character-by-character text input into native or legacy Windows applications that lack standard WebDriver support.

### Key Features and Functionality

| Feature                    | Description                                                                                                                   |
|----------------------------|-------------------------------------------------------------------------------------------------------------------------------|
| Character-by-Character     | Sends each character of the text string individually, mimicking human typing behavior.                                        |
| Optional Element Targeting | Accepts an `OnElement` locator to focus a specific element before typing; omitting it sends to the currently focused element. |
| Configurable Delay         | Supports a per-character delay in milliseconds to simulate realistic typing speed or satisfy application timing requirements. |
| Keyboard Layout Selection  | Maps characters to User32 key codes using the specified locale, enabling accurate multilingual text input.                    |
| Flexible Text Source       | Accepts text via the `Keys` parameter or falls back to the raw `Argument` value when `Keys` is not provided.                  |

### Limitations

- Does not support special keyboard keys such as `Tab`, `Escape`, or function keys. Use `SendUser32KeyboardKey` for those scenarios.
- Does not support sticky mode or simultaneous key presses. Use `SendUser32KeyboardKey` with the `--Sticky` switch for keyboard shortcuts.

### Usage in RPA

| Usage                 | Description                                                                                                     |
|-----------------------|-----------------------------------------------------------------------------------------------------------------|
| Text Input Automation | Enables RPA workflows to type text realistically into native application input fields, forms, and search boxes. |
| Multilingual Input    | Supports typing in non-Latin scripts such as Hebrew by specifying the appropriate keyboard layout.              |

### Usage in Automation Testing

| Usage                     | Description                                                                                                    |
|---------------------------|----------------------------------------------------------------------------------------------------------------|
| Native UI Text Validation | Validates text input handling in native Windows applications by simulating realistic OS-level character input. |
| Timing-Sensitive Testing  | Uses per-character delay to test application behavior under realistic or throttled typing conditions.          |

## Examples

### Example No.1

### Type text directly into a native element

Send the text `Hello User32` to the native input element identified by the XPath `//input[@id='User32Input']`.
The Argument value is used directly as the text string because no `--Keys` parameter is specified.
The element receives focus automatically before typing begins.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32Keys",
    Argument = "Hello User32",
    OnElement = "//input[@id='User32Input']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32Keys")
    .setArgument("Hello User32")
    .setOnElement("//input[@id='User32Input']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32Keys",
    argument: "Hello User32",
    onElement: "//input[@id='User32Input']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32Keys",
    "argument": "Hello User32",
    "onElement": "//input[@id='User32Input']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32Keys",
    "argument": "Hello User32",
    "onElement": "//input[@id='User32Input']"
}
```
### Example No.2

### Type text with per-character delay into a native element

Send the text `Hello User32` to the native input element identified by the XPath `//input[@id='User32Input']`, with a 500-millisecond delay between each character.
The `--Keys` parameter carries the text and `--Delay:500` sets the inter-character pause inside the `{{$ ...}}` expression.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32Keys",
    Argument = "{{$ --Keys:Hello User32 --Delay:500}}",
    OnElement = "//input[@id='User32Input']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32Keys")
    .setArgument("{{$ --Keys:Hello User32 --Delay:500}}")
    .setOnElement("//input[@id='User32Input']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32Keys",
    argument: "{{$ --Keys:Hello User32 --Delay:500}}",
    onElement: "//input[@id='User32Input']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32Keys",
    "argument": "{{$ --Keys:Hello User32 --Delay:500}}",
    "onElement": "//input[@id='User32Input']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32Keys",
    "argument": "{{$ --Keys:Hello User32 --Delay:500}}",
    "onElement": "//input[@id='User32Input']"
}
```
### Example No.3

### Type Hebrew text into the currently focused element

Send the Hebrew text `שלום` (Hello) into whichever element currently holds focus in the native application, using the Hebrew Standard keyboard layout.
No `onElement` is specified, so the plugin sends keystrokes directly to the focused element without calling `SetFocus`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUser32Keys",
    Argument = "{{$ --Keys:שלום --KeyboardLayout:he-IL}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUser32Keys")
    .setArgument("{{$ --Keys:שלום --KeyboardLayout:he-IL}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendUser32Keys",
    argument: "{{$ --Keys:שלום --KeyboardLayout:he-IL}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendUser32Keys",
    "argument": "{{$ --Keys:שלום --KeyboardLayout:he-IL}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendUser32Keys",
    "argument": "{{$ --Keys:שלום --KeyboardLayout:he-IL}}"
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

Carries the text string to type or a `{{$ ...}}` parameter expression containing the `Keys`, `Delay`, and `KeyboardLayout` options.
When used without a parameter expression, the raw Argument value is treated directly as the text to type.
When a parameter expression is used, the Argument acts as the expression carrier and `Keys` inside the expression provides the text.
This property is the primary input for the plugin when the `Keys` parameter is not specified inline.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy used to find the target element before typing.
Supported strategies include `Xpath`, `CssSelector`, `Id`, `LinkText`, and `PartialLinkText`.
Defaults to `Xpath` when not specified.
This property is only relevant when `OnElement` is also provided.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator expression for the element that should receive the typed text.
When provided, the plugin finds the element and calls `SetFocus` before sending characters.
When omitted, the plugin sends keystrokes to whichever element currently holds focus in the native application.
Pair with the `Locator` property to select the appropriate element-finding strategy.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Specifies the pause in milliseconds between typing each consecutive character.
Accepts a time string (e.g., `00:00:00.500`) or a numeric value representing milliseconds.
Default is `0`, meaning characters are sent back-to-back without any pause.
Use this parameter to simulate realistic human typing cadence or to ensure the target application processes each character before the next one arrives.

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the text string to type into the target element, sent character-by-character.
When this parameter is provided and non-empty, it takes priority over the Argument property value.
When this parameter is not provided, the plugin falls back to the raw Argument value as the text source.
Use the `{{$ --Keys:your text}}` expression syntax to combine this parameter with Delay or KeyboardLayout options.

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the BCP-47 locale identifier used to map characters to OS-level User32 key codes.
Use `en-US` for standard English keyboard input and `he-IL` for Hebrew Standard keyboard layout.
The default layout is `en-US` when this parameter is omitted.
Specifying the correct layout is critical when typing characters on non-English systems or when the target application requires locale-specific input encoding.

#### Values

##### En Us

English (United States) keyboard layout. This is the default.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput)
