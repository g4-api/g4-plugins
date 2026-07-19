# Clear Element Content (ClearElementContent)

[Table of Content](../Home.md)  

~18 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Removes all text and values from a targeted web element, ensuring subsequent interactions start from a clean state.
It prevents errors caused by pre-filled data and provides a native clearing option for elements that do not respond to the standard WebDriver clear method.

### Key Features and Functionality

| Feature        | Description                                                                                |
|----------------|--------------------------------------------------------------------------------------------|
| Standard Clear | Uses the built-in browser clear method to remove element content.                          |
| Native Clear   | Simulates backspace key presses to clear elements that do not respond to standard methods. |
| Delay Support  | Allows specifying a wait time before the clear operation occurs.                           |

### Usages in RPA

| Use Case           | Description                                                                   |
|--------------------|-------------------------------------------------------------------------------|
| Form Reset         | Clearing all input fields in a web form before entering new transaction data. |
| Search Box Cleanup | Removing previous search terms before initiating a new lookup.                |

### Usages in Automation Testing

| Use Case         | Description                                                                  |
|------------------|------------------------------------------------------------------------------|
| Input Validation | Ensuring a field is empty before testing mandatory field constraints.        |
| Data Integrity   | Clearing persistent user profile fields before updating them with test data. |

## Examples

### Example No.1

### Reset form field content

Clears all existing text from the target input element located by a CSS selector.
No additional parameters are passed, so the standard browser clear method is used.
Use this form for straightforward input fields that respond correctly to the WebDriver clear command.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Locator = "CssSelector",
    OnElement = "input[name='user-name']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setLocator("CssSelector")
    .setOnElement("input[name='user-name']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    locator: "CssSelector",
    onElement: "input[name='user-name']"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "input[name='user-name']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "input[name='user-name']"
}
```
### Example No.2

### Clear element using native keyboard events

The `NativeClear` parameter simulates physical keyboard interactions to clear elements that resist the standard browser clear method.
The action sends backspace commands to the content-editable element until all text is removed, bypassing standard clearing limitations.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Argument = "{{$ --NativeClear}}",
    OnElement = "//div[@contenteditable='true']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setArgument("{{$ --NativeClear}}")
    .setOnElement("//div[@contenteditable='true']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    argument: "{{$ --NativeClear}}",
    onElement: "//div[@contenteditable='true']"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear}}",
    "onElement": "//div[@contenteditable='true']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "argument": "{{$ --NativeClear}}",
    "onElement": "//div[@contenteditable='true']"
}
```
### Example No.3

### Clear search box with delay

The rule applies a two-second delay before performing the clear operation on the search input.
The `Delay` parameter is set to `00:00:02` using the `{{$ ...}}` macro format to pass the value at runtime.
It helps synchronize the automation with the application state, ensuring the element is ready to be cleared.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Argument = "{{$ --Delay:00:00:02}}",
    Locator = "Id",
    OnElement = "search-box"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setArgument("{{$ --Delay:00:00:02}}")
    .setLocator("Id")
    .setOnElement("search-box");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    argument: "{{$ --Delay:00:00:02}}",
    locator: "Id",
    onElement: "search-box"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "argument": "{{$ --Delay:00:00:02}}",
    "locator": "Id",
    "onElement": "search-box"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "argument": "{{$ --Delay:00:00:02}}",
    "locator": "Id",
    "onElement": "search-box"
}
```
### Example No.4

### Clear field for input validation

The action clears a mandatory email field to prepare for a validation check.
The element is located using a CSS selector targeting the `#user-email` ID.
It ensures that subsequent steps can verify if the application correctly identifies the missing required data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ClearElementContent",
    Locator = "CssSelector",
    OnElement = "#user-email"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ClearElementContent")
    .setLocator("CssSelector")
    .setOnElement("#user-email");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ClearElementContent",
    locator: "CssSelector",
    onElement: "#user-email"
};
```

_**JSON**_

```js
{
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "#user-email"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ClearElementContent",
    "locator": "CssSelector",
    "onElement": "#user-email"
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

Argument provides the CLI-formatted parameter string for the clearing operation.
Use the macro syntax `{{$ --NativeClear}}` to trigger native backspace-based clearing or `{{$ --Delay:00:00:02}}` to set a wait before the clear.
Both parameters can be combined in a single argument such as `{{$ --NativeClear --Delay:00:00:02}}`.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the targeted element for clearing.
It determines how the automation engine identifies the element on the page.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement defines the unique identifier for the element that will have its content removed.
It points the action to the exact location where the clear operation should occur.

## Parameters

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 00:00:00          |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time              |

Delay specifies the amount of time to wait before the clear operation begins.
It helps ensure that any previous page updates or animations are finished before the content is removed.
Using a delay can improve reliability when interacting with dynamic elements that load asynchronously.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

NativeClear determines whether to use simulated keyboard events to clear the element content.
It matters because some elements may not respond to standard clearing methods due to custom scripts or event listeners.
Enabling this option ensures that the element is thoroughly cleared even in complex scenarios.

## Scope

* Mobile Web
* Web