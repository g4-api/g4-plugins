# Switch Keyboard Layout (SwitchKeyboardLayout)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SwitchKeyboardLayout` plugin switches the active OS-level keyboard layout in native Windows applications using the Windows User32 API.
It is designed for automation workflows that require precise control over input language settings in desktop applications that do not support standard WebDriver keyboard layout control.

### Key Features and Functionality

| Feature                | Description                                                                                                     |
|------------------------|-----------------------------------------------------------------------------------------------------------------|
| OS-Level Layout Switch | Posts a layout change request to the User32 server, activating the specified locale as the active input method. |
| BCP-47 Locale Support  | Accepts standard BCP-47 locale identifiers such as `en-US` and `he-IL` for precise language targeting.          |
| Flexible Input         | Accepts the layout via the `KeyboardLayout` parameter or a raw `Argument` fallback, defaulting to `en-US`.      |
| Safe Guard             | Returns an empty response without error when the WebDriver does not implement `IUser32Driver`.                  |

### Usage in RPA

| Usage                    | Description                                                                                                        |
|--------------------------|--------------------------------------------------------------------------------------------------------------------|
| Multilingual Workflows   | Switches between keyboard layouts during automation flows that process input in multiple languages.                |
| Legacy Application Input | Ensures correct input encoding for legacy Windows applications that require a specific OS keyboard layout setting. |

### Usage in Automation Testing

| Usage                     | Description                                                                                                        |
|---------------------------|--------------------------------------------------------------------------------------------------------------------|
| UI Localization Testing   | Validates application behavior and character rendering when the keyboard layout changes between test scenarios.    |
| Input Encoding Validation | Confirms that the application accepts and displays characters correctly under non-default locale keyboard layouts. |

## Examples

### Example No.1

### Switch to Hebrew Standard layout via parameter expression

Switch the active keyboard layout to Hebrew Standard (`he-IL`) using the `--KeyboardLayout` parameter inside a `{{$ ...}}` expression.
This is the canonical form for explicit layout selection and takes priority over any raw `Argument` value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchKeyboardLayout",
    Argument = "{{$ --KeyboardLayout:he-IL}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchKeyboardLayout")
    .setArgument("{{$ --KeyboardLayout:he-IL}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchKeyboardLayout",
    argument: "{{$ --KeyboardLayout:he-IL}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchKeyboardLayout",
    "argument": "{{$ --KeyboardLayout:he-IL}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchKeyboardLayout",
    "argument": "{{$ --KeyboardLayout:he-IL}}"
}
```
### Example No.2

### Switch to Hebrew Standard layout via direct Argument

Switch the active keyboard layout to Hebrew Standard (`he-IL`) by passing the locale identifier directly as the raw `Argument` value.
This simplified form is equivalent to the parameter-expression form but does not support combining additional options.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchKeyboardLayout",
    Argument = "he-IL"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchKeyboardLayout")
    .setArgument("he-IL");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchKeyboardLayout",
    argument: "he-IL"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchKeyboardLayout",
    "argument": "he-IL"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchKeyboardLayout",
    "argument": "he-IL"
}
```
### Example No.3

### Reset keyboard layout to default (en-US)

Invoke `SwitchKeyboardLayout` without any argument to reset the active keyboard layout to the default `en-US` (English United States).
This is useful at the end of a multilingual input sequence to restore the expected layout for subsequent steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchKeyboardLayout"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchKeyboardLayout");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchKeyboardLayout"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchKeyboardLayout"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchKeyboardLayout"
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

Carries the keyboard layout identifier directly, or a `{{$ --KeyboardLayout:...}}` parameter expression.
When used without a parameter expression, the raw Argument value is treated as the BCP-47 layout identifier.
When the `KeyboardLayout` parameter is supplied inside a `{{$ ...}}` expression, the Argument acts as the expression carrier and the parameter value takes priority.
When both this property and the `KeyboardLayout` parameter are absent or empty, the plugin defaults to `en-US`.

## Parameters

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | en-US             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the BCP-47 locale identifier for the keyboard layout to activate.
When present and non-empty, this parameter takes priority over the raw `Argument` value.
When omitted, the plugin falls back to the `Argument` value, then defaults to `en-US` if that is also empty.
Use `en-US` for English (United States) input and `he-IL` for Hebrew Standard input.

#### Values

##### En Us

English (United States) keyboard layout. This is the default value.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadkeyboardlayoutw](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadkeyboardlayoutw)
