# Send Keys (SendKeys)

[Table of Content](../Home.md)  

~27 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SendKeys` plugin is to provide automation scripts with the capability to send text inputs to specified elements. 
This is particularly important in scenarios where user interactions involve input fields, requiring precise control over text entry to simulate user behavior. 
The plugin aims to streamline automation workflows by facilitating seamless text inputs.

### Key Features and Functionality

| Feature               | Description                                                                                                |
|-----------------------|------------------------------------------------------------------------------------------------------------|
| Dynamic Configuration | Supports dynamic configuration through parameters such as `Keys`, `Delay`, `Clear`, and `NativeClear`.     |
| Robust Error Handling | Includes mechanisms for handling exceptions, ensuring reliable execution of text inputs.                   |
| Modifier Keys Support | Allows sending text with modifier keys such as `Shift`, `Ctrl`, or `Alt` for complex text entry scenarios. |

### Usage in RPA

| Usage                 | Description                                                                                                               |
|-----------------------|---------------------------------------------------------------------------------------------------------------------------|
| Filling Forms         | Enables RPA processes to simulate user-like text entries, such as filling out forms or entering data into web elements.   |
| Data Entry Automation | Helps in automating data entry tasks, ensuring that text is accurately entered into input fields, reducing manual effort. |
| Triggering Events     | Triggers keyboard events such as `input`, `change`, and `keydown` events, simulating user interactions with the page.     |

### Usage in Automation Testing

| Usage                     | Description                                                                                                                                    |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Form Field Testing        | Allows dynamic control of text inputs, leading to more thorough test coverage in scenarios involving text input fields.                        |
| UI Stability Verification | Ensures that the user interface remains stable after text inputs for accurate validation of input handling by the application.                 |
| Event Handling Testing    | Verifies that keyboard events are properly triggered and handled by the application, ensuring comprehensive testing of event-driven behaviors. |

## Examples

### Example No.1

Send the text `Hello World` to the HTML element identified by the CSS selector `#TextInput`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "Hello World",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("Hello World")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "Hello World",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "Hello World",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "Hello World",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.2

Send the text `Hello World` to the HTML element identified by the CSS selector `#TextInput` using a parameterized argument.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello World}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello World}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello World}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.3

First clear the content of the input element identified by the CSS selector `#TextInput` and then send the text `Hello World`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello World --Clear}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello World --Clear}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello World --Clear}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --Clear}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --Clear}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.4

First clear the content of the input element identified by the CSS selector `#TextInput` using `NativeClear` functionality and then send the text `Hello World`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello World --NativeClear}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello World --NativeClear}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello World --NativeClear}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.5

Send the text `Hello World` to the HTML element identified by the CSS selector `#TextInput` with a delay of 2000 milliseconds between each character.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello World --Delay:2000}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello World --Delay:2000}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello World --Delay:2000}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --Delay:2000}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello World --Delay:2000}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.6

Send the text `Hello` while holding down the `Shift` key to the HTML element identified by the CSS selector `#TextInput`. This will send the text `Hello` with the `Shift` key pressed, resulting in `HELLO` being typed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello --Modifier:Shift}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello --Modifier:Shift}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello --Modifier:Shift}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello --Modifier:Shift}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello --Modifier:Shift}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```
### Example No.7

Send the text `Hello` while holding down both the `Ctrl` and `Alt` keys to the HTML element identified by the CSS selector `#TextInput`. This demonstrates sending text with multiple modifier keys pressed simultaneously.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$ --Keys:Hello --Modifier:Ctrl --Modifier:Alt}}",
    Locator = "CssSelector",
    OnElement = "#TextInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$ --Keys:Hello --Modifier:Ctrl --Modifier:Alt}}")
    .setLocator("CssSelector")
    .setOnElement("#TextInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$ --Keys:Hello --Modifier:Ctrl --Modifier:Alt}}",
    locator: "CssSelector",
    onElement: "#TextInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello --Modifier:Ctrl --Modifier:Alt}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$ --Keys:Hello --Modifier:Ctrl --Modifier:Alt}}",
    "locator": "CssSelector",
    "onElement": "#TextInput"
}
```

## Properties

### Argument (argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the set of instructions or parameters for the text inputs to be simulated during automation. 
It allows you to define a sequence of text interactions, including the text to be entered and any additional actions.

### Locator (locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy or method used to locate the element on which the text inputs will be simulated during automation.

### On Element (onElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the identifier or locator for the element on which the text inputs defined in the plugin's `Argument` property will be simulated during web automation. 
It indicates the target element where the simulated text interactions should take place.

## Parameters

### Clear (Clear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates that a clearing action will consistently be executed before any subsequent text inputs on the targeted input element. 
This flag ensures that the content of the input field is emptied or cleared, simulating the effect of manually erasing any existing text or data.

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Used to introduce a time pause after each simulated keyboard action. 
This delay ensures a controlled pacing between consecutive text inputs during web automation. 
The purpose is to emulate a more human-like interaction flow by allowing specified intervals between keyboard actions.

### Keys (Keys)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Used to specify the text that should be sent to a targeted element during an automation task.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates that a native clearing action will consistently be executed before any subsequent text inputs on the targeted input element. 
This flag ensures that the content of the input field is emptied or cleared, simulating the effect of manually erasing any existing text or data.

### Modifier (Modifier)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Used to specify modifier keys (such as `Shift`, `Ctrl`, `Alt`) to be held down while sending the text inputs. 
This allows for complex text entry scenarios where modifiers are required.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)
