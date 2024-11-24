# Keyboard Visible (KeyboardVisible)

[Table of Content](../Home.md)  

~15 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `KeyboardVisible` plugin is designed to validate that the on-screen keyboard is visible on a mobile device within automation scripts. 
It ensures that the keyboard is displayed when expected, making it essential for scenarios where the visibility of the on-screen keyboard needs to be confirmed before proceeding with further actions.

### Key Features and Functionality

| Feature                     | Description                                                                                                   |
|-----------------------------|---------------------------------------------------------------------------------------------------------------|
| Keyboard Visibility Check   | Validates that the on-screen keyboard is visible, ensuring that it is displayed when required.                |
| Mobile Device Compatibility | Works across various mobile platforms and devices, making it a versatile tool in mobile automation workflows. |
| Flexible Assertions         | Supports a range of operators, including equality, inequality, and pattern matching for flexible validations. |

### Usages in RPA

| Usage                       | Description                                                                                                     |
|-----------------------------|-----------------------------------------------------------------------------------------------------------------|
| Pre-Action Validation       | Ensures that the on-screen keyboard is visible before performing actions that require text input.               |
| Post-Interaction Validation | Confirms that the keyboard is visible after text input or form interactions, ensuring a smooth user experience. |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification  | Ensures that the on-screen keyboard is visible during specific test scenarios, validating the correctness of UI behavior.              |
| Regression Testing           | Confirms that changes to the application do not affect the expected behavior of showing the on-screen keyboard.                        |
| Performance Testing          | Validates that the keyboard visibility state transitions correctly, ensuring optimal application behavior during input and navigation. |

## Examples

### Example No.1

Assert that the on-screen keyboard is visible on the mobile device. 
This is useful for scenarios where the script needs to ensure that the keyboard is displayed before proceeding with text input actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "KeyboardVisible"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("KeyboardVisible");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "KeyboardVisible"
};
```

_**JSON**_

```js
{
    "pluginName": "KeyboardVisible"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "KeyboardVisible"
}
```
### Example No.2

Ensure that the on-screen keyboard is visible after interacting with an input field. 
This assertion checks if the keyboard is displayed, confirming that it has been successfully triggered.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "KeyboardVisible"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("KeyboardVisible");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "KeyboardVisible"
};
```

_**JSON**_

```js
{
    "pluginName": "KeyboardVisible"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "KeyboardVisible"
}
```
### Example No.3

Perform an assertion using the `Assert` plugin to ensure that the on-screen keyboard is visible on the mobile device. 
This validation is essential for scenarios where further user interactions require the keyboard to be visible.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:KeyboardVisible}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:KeyboardVisible}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:KeyboardVisible}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:KeyboardVisible}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:KeyboardVisible}}"
}
```

## See Also

apiDocumentation: [https://appium.readthedocs.io/en/latest/en/commands/device/keys/is-keyboard-shown/#http-api-specifications](https://appium.readthedocs.io/en/latest/en/commands/device/keys/is-keyboard-shown/#http-api-specifications)
