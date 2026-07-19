# Send Keys (SendKeys)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Types text into a target web element such as input fields or text areas with configurable typing speed, content clearing, and keyboard modifier combinations.
The text to send is supplied via the Keys parameter or directly as the Argument value when Keys is absent.

### Key Features and Functionality

| Feature              | Description                                                                |
|----------------------|----------------------------------------------------------------------------|
| Text Input           | Sends keystrokes to the element with configurable delay between characters |
| Clear Before Typing  | Supports native backspace clear and standard WebDriver clear               |
| Modifier Keys        | Press Ctrl, Alt, Shift, or Meta while sending text for shortcuts           |
| Flexible Text Source | Accepts text from the Keys parameter or rule argument                      |

### Usages in RPA

| Use Case          | Description                                 |
|-------------------|---------------------------------------------|
| Form Field Entry  | Automatically fill text inputs in web forms |
| Search Box Input  | Type search queries into search fields      |
| Text Area Content | Enter multi-line text into text areas       |

### Usages in Automation Testing

| Use Case           | Description                                     |
|--------------------|-------------------------------------------------|
| Input Validation   | Test form fields with various text inputs       |
| Keyboard Shortcuts | Test Ctrl+A, Ctrl+C type combinations           |
| Type Speed Testing | Verify typing behavior with configurable delays |

## Examples

### Example No.1

### Send text to an input field

The rule targets an input element using XPath and sends the text 'Hello World' to it.
The element is located using the default Xpath locator strategy.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello World}}",
    OnElement = "//input[@id='username']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello World}}")
    .setOnElement("//input[@id='username']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello World}}",
    onElement: "//input[@id='username']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World}}",
    "onElement": "//input[@id='username']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World}}",
    "onElement": "//input[@id='username']"
}
```
### Example No.2

### Clear and type new content

The rule clears the target element using native backspace simulation before sending the new text.
This is useful when replacing existing content in an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:New Text --NativeClear}}",
    OnElement = "//textarea[@name='description']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:New Text --NativeClear}}")
    .setOnElement("//textarea[@name='description']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:New Text --NativeClear}}",
    onElement: "//textarea[@name='description']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:New Text --NativeClear}}",
    "onElement": "//textarea[@name='description']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:New Text --NativeClear}}",
    "onElement": "//textarea[@name='description']"
}
```
### Example No.3

### Send keys with a modifier

The rule holds the Ctrl modifier while sending 'a' to trigger a Select All keyboard shortcut.
The modifier is provided as a JSON array containing Control.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:a --Modifier:Control}}",
    OnElement = "//div[@contenteditable='true']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:a --Modifier:Control}}")
    .setOnElement("//div[@contenteditable='true']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:a --Modifier:Control}}",
    onElement: "//div[@contenteditable='true']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:a --Modifier:Control}}",
    "onElement": "//div[@contenteditable='true']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:a --Modifier:Control}}",
    "onElement": "//div[@contenteditable='true']"
}
```
### Example No.4

### Send a key with multiple modifiers

The rule holds the Control and Alt modifiers while sending the key `a` to the target element.
The repeated `--Modifier` parameters are converted into an array at runtime and applied together during the key send.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:a --Modifier:Control --Modifier:Alt}}",
    OnElement = "//div[@contenteditable='true']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:a --Modifier:Control --Modifier:Alt}}")
    .setOnElement("//div[@contenteditable='true']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:a --Modifier:Control --Modifier:Alt}}",
    onElement: "//div[@contenteditable='true']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:a --Modifier:Control --Modifier:Alt}}",
    "onElement": "//div[@contenteditable='true']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:a --Modifier:Control --Modifier:Alt}}",
    "onElement": "//div[@contenteditable='true']"
}
```
### Example No.5

### Type text with character delay

The rule sends text to an element with a 100ms delay between each keystroke.
This simulates human typing speed for applications that require realistic input timing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Slow Type --Delay:00:00:00.100}}",
    OnElement = "//input[@id='search']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Slow Type --Delay:00:00:00.100}}")
    .setOnElement("//input[@id='search']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Slow Type --Delay:00:00:00.100}}",
    onElement: "//input[@id='search']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Slow Type --Delay:00:00:00.100}}",
    "onElement": "//input[@id='search']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Slow Type --Delay:00:00:00.100}}",
    "onElement": "//input[@id='search']"
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
| **Value Type**    | String            |

Argument provides the keystroke text as a fallback when the Keys parameter is not set.
It allows passing text directly to the element without using a named parameter.
When both Argument and Keys parameter are present, Keys takes precedence.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator determines the strategy for finding the target element.
It defaults to Xpath for element location.
Supported locators include Xpath, CssSelector, Id, LinkText, and PartialLinkText.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement specifies the target element for sending keystrokes.
It is required for identifying which element receives the keyboard input.
The value format depends on the selected locator strategy.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?si).*           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

RegularExpression filters element matching using pattern matching on element attributes.
It defaults to '(?si).*' to match all elements.
Use this to narrow down element selection when multiple elements match the locator.

## Parameters

### Clear (Clear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Clear triggers a standard WebDriver clear operation before sending keys.
It removes existing content from input fields when present.
Use NativeClear for custom controls that do not respond to standard clear.

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Delay sets the time interval between each keystroke.
Accepts TimeSpan format like 00:00:00.100 for 100ms delay between characters.
Set to 00:00:00 for instant typing without any delay.

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Keys specifies the text string to send to the element.
This is the primary way to provide input text via parameter macro syntax.
When empty, the rule argument is used as the text to send.

### Modifier (Modifier)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Modifier specifies one or more keyboard modifier keys to hold while the key value is sent to the target element.
It accepts repeated parameter values that are converted into an array at runtime, such as `--Modifier:Control --Modifier:Alt`.
Use Modifier for keyboard combinations like Control+A, Shift+Tab, or multi-modifier shortcuts.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

NativeClear triggers a native backspace-based clear before sending keys.
It provides better compatibility with custom input controls.
Use this instead of Clear for elements that do not respond to standard clearing.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)
