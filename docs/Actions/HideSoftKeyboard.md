# Hide Soft Keyboard (HideSoftKeyboard)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `HideSoftKeyboard` plugin is to provide automation scripts with the capability to hide the on-screen keyboard on a mobile device. 
This functionality is crucial in scenarios where user interactions involve input fields, and a clear view of the application's interface is required post-input. 
The plugin aims to optimize mobile automation flows by seamlessly managing the visibility of the on-screen keyboard.

### Key Features and Functionality

| Feature                                           | Description                                                                                                                                                                                                                                       |
|---------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Configuration                             | Allows dynamic configuration through a `HideKeyboardModel`, which includes parameters such as `key`, `key code`, `key name`, and `strategy`. This ensures precise control over how the keyboard is hidden based on specific automation scenarios. |
| Compatibility Check                               | Verifies if the WebDriver in use supports hiding the keyboard as a mobile device, ensuring the plugin's functionality is invoked only in supported environments.                                                                                  |
| Integration with Mobile Device Keyboard Interface | Integrates with the `HideKeyboard` method if the WebDriver supports hiding the keyboard as a mobile device, enabling precise configuration for hiding the keyboard.                                                                               |

### Usages in RPA

| Usage                             | Description                                                                                                                |
|-----------------------------------|----------------------------------------------------------------------------------------------------------------------------|
| Enhancing Human-Like Interactions | Simulates human-like interactions by hiding the on-screen keyboard after data entry, aligning with natural user behavior.  |
| Optimizing Automation Flows       | Ensures a clear view of the application interface post-input, optimizing automation flows by managing keyboard visibility. |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                                                        |
|------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Comprehensive Test Scenarios | Controls keyboard visibility dynamically, leading to comprehensive test coverage, especially in scenarios involving input fields.                                  |
| Ensuring UI Stability        | Ensures UI remains stable and visible for subsequent validations post-user interactions, accurately assessing the impact of user input on the application's state. |

## Examples

### Example No.1

Hide the on-screen keyboard in a mobile automation scenario. 
The absence of specific arguments implies that the plugin will use default strategies or configurations to hide the keyboard.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HideSoftKeyboard"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HideSoftKeyboard");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HideSoftKeyboard"
};
```

_**JSON**_

```js
{
    "pluginName": "HideSoftKeyboard"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HideSoftKeyboard"
}
```
### Example No.2

Hide the on-screen keyboard using the `swipeDown` strategy. 
This tailored approach provides flexibility in adapting the automation script to the desired user interaction patterns.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HideSoftKeyboard",
    Argument = "{{$ --Strategy:swipeDown}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HideSoftKeyboard")
    .setArgument("{{$ --Strategy:swipeDown}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HideSoftKeyboard",
    argument: "{{$ --Strategy:swipeDown}}"
};
```

_**JSON**_

```js
{
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:swipeDown}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:swipeDown}}"
}
```
### Example No.3

Hide the on-screen keyboard using the `pressKey` strategy with `KeyCode:4`. 
This configuration simulates pressing a specific key (key code 4) to hide the on-screen keyboard after interacting with an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HideSoftKeyboard",
    Argument = "{{$ --Strategy:pressKey --KeyCode:4}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HideSoftKeyboard")
    .setArgument("{{$ --Strategy:pressKey --KeyCode:4}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HideSoftKeyboard",
    argument: "{{$ --Strategy:pressKey --KeyCode:4}}"
};
```

_**JSON**_

```js
{
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --KeyCode:4}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --KeyCode:4}}"
}
```
### Example No.4

Hide the on-screen keyboard using the `pressKey` strategy with `KeyName:Back`. 
This configuration simulates pressing the `Back` key to hide the on-screen keyboard after interacting with an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HideSoftKeyboard",
    Argument = "{{$ --Strategy:pressKey --KeyName:Back}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HideSoftKeyboard")
    .setArgument("{{$ --Strategy:pressKey --KeyName:Back}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HideSoftKeyboard",
    argument: "{{$ --Strategy:pressKey --KeyName:Back}}"
};
```

_**JSON**_

```js
{
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --KeyName:Back}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --KeyName:Back}}"
}
```
### Example No.5

Hide the on-screen keyboard using the `pressKey` strategy with `Key:Back`. 
This configuration simulates pressing the `Back` key to hide the on-screen keyboard after interacting with an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "HideSoftKeyboard",
    Argument = "{{$ --Strategy:pressKey --Key:Back}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("HideSoftKeyboard")
    .setArgument("{{$ --Strategy:pressKey --Key:Back}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "HideSoftKeyboard",
    argument: "{{$ --Strategy:pressKey --Key:Back}}"
};
```

_**JSON**_

```js
{
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --Key:Back}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "HideSoftKeyboard",
    "argument": "{{$ --Strategy:pressKey --Key:Back}}"
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

Used to pass additional information or instructions to the `HideSoftKeyboard` plugin beyond what may be specified by default or through other properties.

## Parameters

### Strategy (Strategy)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The method or strategy employed to hide the on-screen keyboard on a mobile device. It supports different strategies to accommodate variations in mobile platforms and environments.  

If the `Strategy` parameter is not explicitly specified, the plugin may employ a default strategy for hiding the keyboard. 
The default strategy can vary based on the implementation, and it is recommended to consult the plugin documentation or source code for details.

#### Values

##### Swipe Down

This strategy simulates a downward swipe gesture on the screen. 
The swipe action triggers the dismissal of the on-screen keyboard.
##### Press Key

This strategy involves pressing a specific key to hide the keyboard. 
The key to be pressed can be specified using either the `KeyCode` or `KeyName` parameter.
##### Tap Outside

This strategy simulates a tap outside the current input field or keyboard area. 
The tap action triggers the keyboard to hide.
##### Press

Similar to the `PressKey` strategy, the `Press` strategy involves pressing a specific key to hide the keyboard. 
It provides an alternative to specifying the key using either the `KeyCode` or `KeyName` parameter.
##### Tap Out

Similar to the `TapOutside` strategy, the `TapOut` strategy simulates tapping outside the current input field or keyboard area to hide the keyboard. 
It provides an alternative term for the same action.

### Key Code (KeyCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

A specific [key code](https://www.temblast.com/ref/akeyscode.htm) on the device's keyboard that should be pressed to trigger the action of hiding the on-screen keyboard.

### Key Name (KeyName)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A specific key name on the device's keyboard that should be pressed to trigger the action of hiding the on-screen keyboard.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A specific key on the device's keyboard that should be pressed to trigger the action of hiding the on-screen keyboard.

## Scope

* Mobile Native
* Mobile Web
## See Also

apiDocumentation: [https://appium.readthedocs.io/en/latest/en/commands/device/keys/hide-keyboard/#http-api-specifications](https://appium.readthedocs.io/en/latest/en/commands/device/keys/hide-keyboard/#http-api-specifications)
