# Send Keyboard Key (SendKeyboardKey)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sends one or more named keyboard keys to a target web element, simulating physical keyboard interactions.
Each key name is resolved against WebDriver key constants and dispatched sequentially to the element.
Use this action wherever a workflow needs to trigger keyboard-driven behavior — such as submitting a form with Enter, deleting content with Backspace, or shifting focus with Tab — on a specific element.

### Key Features and Functionality

| Feature            | Description                                                                                                                                      |
|--------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| Single Key         | Supply a key name directly as the argument for a compact single-key interaction without macro syntax.                                            |
| Multi-Key Sequence | Repeat the --Key parameter to build an ordered sequence of key presses dispatched one at a time.                                                 |
| Per-Key Delay      | The Delay parameter inserts a pause after each key send, accepting milliseconds or TimeSpan format, to emulate human typing pacing.              |
| Browser Clear      | The Clear switch calls the browser's built-in clear method on the element before the key sequence begins.                                        |
| Native Clear       | The NativeClear switch simulates backspace key presses to clear elements that ignore the standard WebDriver clear command.                       |
| Error Recording    | When the target element is not found, a NoSuchElementException is recorded in the plugin exception list and the action returns without throwing. |

### Usages in RPA

| Use Case          | Description                                                                                                |
|-------------------|------------------------------------------------------------------------------------------------------------|
| Form Submission   | Press Enter on an input field to submit a form without clicking a submit button.                           |
| Focus Navigation  | Send Tab or Arrow keys to move focus through interactive controls in a web form.                           |
| Pre-Cleared Entry | Use NativeClear to remove existing content and then send a key such as Enter to confirm the cleared state. |

### Usages in Automation Testing

| Use Case                | Description                                                                                                         |
|-------------------------|---------------------------------------------------------------------------------------------------------------------|
| Keyboard Event Testing  | Verify that an input element correctly handles key events such as Enter triggering form submission or validation.   |
| Backspace Behavior      | Test that Backspace removes characters as expected and the resulting element state matches the expected value.      |
| Sequence State Testing  | Confirm that a multi-key sequence — such as Enter followed by Backspace — produces the correct UI state transition. |

## Examples

### Example No.1

### Send a single keyboard key using a direct argument

Sends the `Enter` key to the element matched by the CSS selector `#KeyboardKeyOutcome`.
The key name is passed directly as the argument with no macro syntax, which is the simplest form of this action.
No clearing or delay is applied — the key is sent immediately to the located element.

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

### Send a multi-key sequence with a per-key delay

Sends `Enter` and then `Backspace` to the element matched by `#KeyboardKeyOutcome`, with a 500 ms pause applied after each key.
The `--Key` parameter is repeated to build an ordered sequence, and `--Delay:500` controls the per-key pacing.
Use this form when the target application requires a brief pause between key events to process each input before the next arrives.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --Key:Backspace --Delay:500}}",
    Locator = "CssSelector",
    OnElement = "#KeyboardKeyOutcome"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --Key:Backspace --Delay:500}}")
    .setLocator("CssSelector")
    .setOnElement("#KeyboardKeyOutcome");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --Key:Backspace --Delay:500}}",
    locator: "CssSelector",
    onElement: "#KeyboardKeyOutcome"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:500}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --Key:Backspace --Delay:500}}",
    "locator": "CssSelector",
    "onElement": "#KeyboardKeyOutcome"
}
```
### Example No.3

### Clear element content natively and then send a key

Clears the content of a `contenteditable` div using native backspace simulation and then sends the `Enter` key.
The `--NativeClear` switch triggers `element.SendNativeClear()` before the key sequence begins, bypassing the standard WebDriver clear method.
Use this form for elements that ignore the standard clear command, such as content-editable divs or inputs with custom event handlers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeyboardKey",
    Argument = "{{$ --Key:Enter --NativeClear}}",
    OnElement = "//div[@contenteditable='true']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeyboardKey")
    .setArgument("{{$ --Key:Enter --NativeClear}}")
    .setOnElement("//div[@contenteditable='true']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeyboardKey",
    argument: "{{$ --Key:Enter --NativeClear}}",
    onElement: "//div[@contenteditable='true']"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --NativeClear}}",
    "onElement": "//div[@contenteditable='true']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeyboardKey",
    "argument": "{{$ --Key:Enter --NativeClear}}",
    "onElement": "//div[@contenteditable='true']"
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

Argument supplies the key name or the macro expression containing the Key, Delay, Clear, and NativeClear parameters.
A plain string is used as the single key name when no --Key parameter is present in the macro.
The macro format {{$ --Key:Enter --Delay:500}} is required when combining multiple parameters.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target element.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to which the keyboard keys are sent.
It is evaluated using the strategy defined by the Locator property.
When the element is not found a NoSuchElementException is recorded and the action returns without sending keys.

## Parameters

### Clear (Clear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Clear indicates that the browser's built-in element clear method should be called before the key sequence is sent.
It ensures that any existing content in the input field is removed before the keyboard interaction begins.
Use Clear for standard input elements that respond to the WebDriver clear command.

### Delay (Delay)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time|Number       |

Delay sets the duration to pause after each individual key send within the sequence.
It accepts a number of milliseconds (e.g., 500) or a TimeSpan string (e.g., 00:00:00.500) to emulate human typing pacing.
When absent or zero, keys are sent back-to-back with no pause between them.

### Key (Key)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Key specifies the name of a keyboard key to send to the target element.
It can be repeated to build a multi-key sequence dispatched in the order the parameters appear.
When Key is absent, the action uses the full argument string as a single key name.

### Native Clear (NativeClear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

NativeClear indicates that element content should be cleared using simulated backspace key presses before the key sequence begins.
It calls element.SendNativeClear(), which is effective for content-editable elements and inputs with custom event handlers that ignore the standard WebDriver clear method.
Any exception raised during native clearing is caught, recorded as a G4ExceptionModel, and the key sequence proceeds regardless.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)
