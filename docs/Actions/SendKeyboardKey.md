# Send Keyboard Key (SendKeyboardKey)

[Table of Content](../Home.md)  

~27 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SendKeyboardKey` plugin is to empower automation scripts with the capability to send keyboard inputs to an element in an application. 
This functionality is vital in scenarios where user interactions involve input fields, and precise control over the keyboard is required to simulate user behavior. 
The plugin aims to streamline automation workflows by facilitating seamless management of keyboard interactions.

### Key Features and Functionality

| Feature                | Description                                                                                                                                                                                                                               |
|------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Configuration  | The plugin supports dynamic configuration through a set of parameters, including `Clear`, `Delay`, `Key`, and `NativeClear`. This flexibility allows precise control over keyboard interactions based on specific automation scenarios.   |
| Error Handling         | The plugin includes robust error handling mechanisms, ensuring that exceptions are caught and logged appropriately. This enhances the reliability of automation scripts by addressing issues that may arise during keyboard interactions. |

### Usage in RPA

| Usage                       | Description                                                                                                                                                                                                                                                |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Simulating User Inputs      | RPA processes involving web interactions benefit from the `SendKeyboardKey` plugin to simulate user-like inputs. Whether filling out forms or navigating through web elements, the plugin ensures accurate emulation of keyboard interactions.             |
| Optimizing Automation Flows | Automation flows in RPA often require the simulation of various keyboard inputs. By strategically using the plugin, RPA developers can optimize automation scripts, ensuring precise control over keyboard actions to align with desired user experiences. |

### Usage in Automation Testing

| Usage                        | Description                                                                                                                                                                                                                                          |
|------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Comprehensive Test Scenarios | In automation testing scenarios for applications, the `SendKeyboardKey` plugin is invaluable. It allows scripts to dynamically control keyboard inputs, leading to more comprehensive test coverage, especially in scenarios involving input fields. |
| Ensuring UI Stability        | Post-user interactions, such as entering text into input fields, the plugin ensures that the UI remains stable for subsequent validations. This is crucial for accurately assessing the impact of keyboard inputs on the application's state.        |

## Examples

### Example No.1

Simulate pressing the `Enter` key on the HTML element identified by the CSS selector `#KeyboardKeyOutcome`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "Enter",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("Enter")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "Enter",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "Enter",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "Enter",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.2

Simulate pressing the `Enter` key on the HTML element identified by the CSS selector `#KeyboardKeyOutcome`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.3

Simulate pressing the `Enter` key followed by the `Backspace` key on the HTML element identified by the CSS selector `#KeyboardKeyOutcome`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --Key:Backspace}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --Key:Backspace}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --Key:Backspace}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.4

Simulate pressing the `Enter` key, followed by the `Backspace` key, with a delay of 4000 milliseconds between them. 
This simulated keyboard input is targeted at the HTML element identified by the CSS selector `#KeyboardKeyOutcome` on a web page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --Key:Backspace --Delay:4000}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --Key:Backspace --Delay:4000}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --Key:Backspace --Delay:4000}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:4000}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:4000}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.5

Simulate pressing the `Enter` key, followed by the `Backspace` key, with a delay of 4000 milliseconds between them. 
This simulated keyboard input is targeted at the HTML element identified by the CSS selector `#KeyboardKeyOutcome` on a web page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --Key:Backspace --Delay:00:00:04}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --Key:Backspace --Delay:00:00:04}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --Key:Backspace --Delay:00:00:04}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:00:00:04}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:00:00:04}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.6

First clear the content of the input element identified by the CSS selector `#KeyboardKeyOutcome` and then simulate pressing the `Enter` key.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --Clear}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --Clear}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --Clear}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Clear}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Clear}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.7

First clear the content of the input element identified by the CSS selector `#KeyboardKeyOutcome` using `NativeClear` functionality and then simulate pressing the `Enter` key.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --NativeClear}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --NativeClear}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --NativeClear}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
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
| **Value Type**    | String            |

Specifies the set of instructions or parameters for the keyboard actions to be simulated during automation. 
It allows you to define a sequence of keyboard interactions, including the keys to be pressed and any additional actions.

### Locator (locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy or method used to locate the element on which the keyboard actions will be simulated during automation.

### On Element (onElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the identifier or locator for the element on which the keyboard actions defined in the plugin's `Argument` property will be simulated during web automation. 
It indicates the target element where the simulated keyboard interactions should take place.

## Parameters

### Clear (Clear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates that a clearing action will consistently be executed before any subsequent keyboard actions on the targeted input element. 
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
This delay ensures a controlled pacing between consecutive key presses during web automation. 
The purpose is to emulate a more human-like interaction flow by allowing specified intervals between keyboard actions.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Used to specify a keyboard key or a sequence of keyboard keys that should be sent to a targeted element during an automation task.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates that a native clearing action will consistently be executed before any subsequent keyboard actions on the targeted input element. 
This flag ensures that the content of the input field is emptied or cleared, simulating the effect of manually erasing any existing text or data.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)
