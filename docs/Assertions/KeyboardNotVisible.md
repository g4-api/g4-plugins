# Keyboard Not Visible (KeyboardNotVisible)

[Table of Content](../Home.md)  

~15 min · Assertion Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `KeyboardNotVisible` plugin is designed to validate that the on-screen keyboard is not visible on a mobile device within automation scripts. 
It ensures that the keyboard is hidden, making it essential for scenarios where the visibility of the on-screen keyboard needs to be confirmed before proceeding with further actions.

### Key Features and Functionality

| Feature                     | Description                                                                                                            |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------|
| Keyboard Visibility Check   | Validates that the on-screen keyboard is not visible, ensuring that it is hidden before proceeding with other actions. |
| Mobile Device Compatibility | Works across various mobile platforms and devices, making it a versatile tool in mobile automation workflows.          |
| Flexible Assertions         | Supports a range of operators, including equality, inequality, and pattern matching for flexible validations.          |

### Usages in RPA

| Usage                       | Description                                                                                                               |
|-----------------------------|---------------------------------------------------------------------------------------------------------------------------|
| Pre-Action Validation       | Ensures that the on-screen keyboard is hidden before performing actions that require a clear view of the screen.          |
| Post-Interaction Validation | Confirms that the keyboard is no longer visible after text input or form interactions, ensuring a smooth user experience. |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| UI Consistency Verification  | Ensures that the on-screen keyboard is not visible during specific test scenarios, validating the correctness of UI behavior.          |
| Regression Testing           | Confirms that changes to the application do not affect the expected behavior of hiding the on-screen keyboard.                         |
| Performance Testing          | Validates that the keyboard visibility state transitions correctly, ensuring optimal application behavior during input and navigation. |

## Examples

### Example No.1

Assert that the on-screen keyboard is not visible on the mobile device. 
This is useful for scenarios where the script needs to ensure that the keyboard is hidden before proceeding with other actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "KeyboardNotVisible"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("KeyboardNotVisible");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "KeyboardNotVisible"
};
```

_**JSON**_

```js
{
    "pluginName": "KeyboardNotVisible"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "KeyboardNotVisible"
}
```
### Example No.2

Ensure that the on-screen keyboard is hidden after interacting with an input field. 
This assertion checks if the keyboard is not visible, confirming that it has been successfully dismissed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "KeyboardNotVisible"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("KeyboardNotVisible");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "KeyboardNotVisible"
};
```

_**JSON**_

```js
{
    "pluginName": "KeyboardNotVisible"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "KeyboardNotVisible"
}
```
### Example No.3

Perform an assertion using the `Assert` plugin to ensure that the on-screen keyboard is not visible on the mobile device. 
This validation is essential for scenarios where further user interactions require the keyboard to be hidden.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Assert",
    Argument = "{{$ --Condition:KeyboardNotVisible}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Assert")
    .setArgument("{{$ --Condition:KeyboardNotVisible}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Assert",
    argument: "{{$ --Condition:KeyboardNotVisible}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Assert",
    "argument": "{{$ --Condition:KeyboardNotVisible}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Assert",
    "argument": "{{$ --Condition:KeyboardNotVisible}}"
}
```

## See Also

apiDocumentation: [https://appium.readthedocs.io/en/latest/en/commands/device/keys/is-keyboard-shown/#http-api-specifications](https://appium.readthedocs.io/en/latest/en/commands/device/keys/is-keyboard-shown/#http-api-specifications)
