# Clear Element Content (ClearElementContent)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `ClearElementContent` plugin automates the process of clearing the content of input elements in automation workflows. 
It provides a seamless and efficient mechanism for resetting input fields, ensuring that the desired elements are properly cleared before proceeding with further actions.

### Key Features and Functionality

| Feature           | Description                                                                              |
|-------------------|------------------------------------------------------------------------------------------|
| Standard Clearing | Clears the content of input elements using the standard clear method.                    |
| Native Clearing   | Clears the content by simulating backspace key presses, mimicking a manual clear action. |
| Delay Handling    | Supports the introduction of delays between key presses during the native clear process. |
| Error Management  | Incorporates robust error handling to manage exceptions during the clearing process.     |

### Usages in RPA

| Usage                       | Description                                                                                     |
|-----------------------------|-------------------------------------------------------------------------------------------------|
| Form Resets                 | Automates the resetting of form fields to ensure clean state before data entry.                 |
| Data Entry Preparation      | Clears input fields in preparation for new data entry tasks, ensuring accuracy and consistency. |
| User Interaction Simulation | Mimics user behavior by simulating manual clear actions through backspace key presses.          |

### Usages in Automation Testing

| Usage                  | Description                                                                                             |
|------------------------|---------------------------------------------------------------------------------------------------------|
| Input Field Testing    | Validates the behavior of input fields by clearing their content before entering new test data.         |
| State Management       | Ensures consistent test conditions by resetting input fields to a known state before test execution.    |
| Error Scenario Testing | Simulates scenarios where input fields need to be cleared as part of error handling and recovery tests. |

## Examples

### Example No.1

Clear the content of the input element identified by the CSS selector `#inputField`. 
This uses the standard clear method to reset the field, ensuring it is empty before further actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

Clear the content of the input element identified by the CSS selector `#inputField` using native clear. 
This mimics manual clearing by sending backspace key presses, effectively resetting the field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Argument = "{{$ --NativeClear}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setArgument("{{$ --NativeClear}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    argument: "{{$ --NativeClear}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.3

Clear the content of the input element identified by the CSS selector `#inputField` using native clear with a delay of 500 milliseconds between key presses. 
This simulates a more realistic user interaction by introducing pauses between backspace key presses.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Argument = "{{$ --NativeClear --Delay:500}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setArgument("{{$ --NativeClear --Delay:500}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    argument: "{{$ --NativeClear --Delay:500}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear --Delay:500}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear --Delay:500}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
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

Allows customization of the clear action by specifying additional instructions. 
Options include introducing a delay between key presses or using native clear actions.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy or method used to locate the element whose content will be cleared during automation.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the identifier or locator for the element whose content will be cleared during automation. 
It indicates the target element where the clear action should be performed.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the delay, in milliseconds, between each key press when performing a native clear action. 
This delay helps to simulate a more realistic user interaction during the clearing process.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates that the content should be cleared by simulating backspace key presses, mimicking a manual clear action. 
This approach is useful for scenarios where a more human-like interaction is needed.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-clear](https://www.w3.org/TR/webdriver/#element-clear)
