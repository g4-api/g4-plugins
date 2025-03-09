# Send User32 Keys (SendUser32Keys)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SendUser32Keys` plugin simulates typing text character-by-character into native Windows application elements using the Windows User32 API. It is designed for scenarios requiring realistic text input automation.

### Key Features and Functionality

| Feature                | Description                                                                                                          |
|------------------------|----------------------------------------------------------------------------------------------------------------------|
| Character-by-Character | Sends each character individually, mimicking human typing behavior.                                                  |
| Configurable Delay     | Supports delays between each character to simulate realistic typing speed.                                           |
| Keyboard Layout        | Supports specifying keyboard layouts to ensure correct character representation, especially for multilingual inputs. |

### Limitations

- Does not support sending special keyboard keys like `Tab`, `Escape`, etc. Use `SendUser32KeyboardKey` plugin for those scenarios.
- Does not support sticky keys or simultaneous key presses.

### Usage in RPA

| Usage                 | Description                                                                                |
|-----------------------|--------------------------------------------------------------------------------------------|
| Text Input Automation | Ideal for automating realistic text entry in forms or input fields in native applications. |

### Usage in Automation Testing

| Usage                     | Description                                                                                  |
|---------------------------|----------------------------------------------------------------------------------------------|
| Native UI Text Validation | Facilitates accurate testing of text input handling by simulating realistic typing behavior. |

### Supported Platform

This plugin is specifically designed for **Windows OS** environments.

## Examples

### Example No.1

Send the text `Hello User32` to the UI element identified by the XPath `//input[@id='User32Input']`.

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

Send the text `Hello User32` with a delay of 500 milliseconds between each character to the UI element identified by XPath `//input[@id='User32Input']`.

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

Send the Hebrew text `שלום` ('Hello') using the Hebrew Standard keyboard layout.

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

Defines the text to send character-by-character to the UI element. Can be a literal string or expression.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy for the target UI element.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the XPath locator for the UI element to type text into. If omitted, text is sent to the currently focused element.

## Parameters

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the text to be typed into the target UI element. If not provided, the plugin uses the rule's Argument.

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Specifies the delay between typing each character, simulating realistic human typing speed.

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the keyboard layout used to interpret characters, essential for multilingual inputs.

#### Values

##### En Us

English (US) keyboard layout.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Any
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendinput)
