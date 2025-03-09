# Switch Keyboard Layout (SwitchKeyboardLayout)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SwitchKeyboardLayout` plugin switches the keyboard layout using the User32 API. It's essential for automation scenarios that require precise control over input languages in native Windows applications.

### Key Features and Functionality

| Feature                 | Description                                                             |
|-------------------------|-------------------------------------------------------------------------|
| Dynamic Switching       | Dynamically switches keyboard layouts based on automation requirements. |
| User32 Integration      | Utilizes User32 API calls to reliably change layouts at the OS level.   |
| Supports Custom Layouts | Supports specifying different keyboard layouts dynamically.             |

### Usage in RPA

| Usage                          | Description                                                    |
|--------------------------------|----------------------------------------------------------------|
| Multilingual Automation        | Facilitates automation scenarios involving multiple languages. |
| Legacy Application Integration | Enables precise keyboard layout control in legacy apps.        |

### Usage in Automation Testing

| Usage               | Description                                                            |
|---------------------|------------------------------------------------------------------------|
| UI Language Testing | Ensures correct keyboard layout during UI tests.                       |
| Input Validation    | Validates multilingual input scenarios with accurate layout switching. |

## Examples

### Example No.1

Switch keyboard layout to Hebrew Standard.

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

Switch keyboard layout to English (US).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchKeyboardLayout",
    Argument = "{{$ --KeyboardLayout:en-US}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchKeyboardLayout")
    .setArgument("{{$ --KeyboardLayout:en-US}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchKeyboardLayout",
    argument: "{{$ --KeyboardLayout:en-US}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchKeyboardLayout",
    "argument": "{{$ --KeyboardLayout:en-US}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchKeyboardLayout",
    "argument": "{{$ --KeyboardLayout:en-US}}"
}
```
### Example No.3

Switch keyboard layout to English (US).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchKeyboardLayout",
    Argument = "en-US"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchKeyboardLayout")
    .setArgument("en-US");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchKeyboardLayout",
    argument: "en-US"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchKeyboardLayout",
    "argument": "en-US"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchKeyboardLayout",
    "argument": "en-US"
}
```
### Example No.4

Switch keyboard layout to Hebrew Standard.

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
### Example No.5

Switch keyboard layout to English (US).

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

Defines the keyboard layout identifier to switch to.

## Parameters

### Keyboard Layout (KeyboardLayout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | en-US             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the keyboard layout to activate.

#### Values

##### En Us

English (US) keyboard layout.
##### He Il

Hebrew Standard keyboard layout.

## Scope

* Windows Native
## See Also

apiDocumentation: [https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadkeyboardlayoutw](https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-loadkeyboardlayoutw)
