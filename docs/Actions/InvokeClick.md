# Invoke Click (InvokeClick)

[Table of Content](../Home.md)  

~23 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Performs a click on a target element or at the current mouse position when no element is specified.
It supports a conditional click mode that retries the click at a configurable interval until an assertion condition is met or a timeout expires.
This makes it suitable for scenarios that require waiting for a dynamic state change — such as an alert appearing or an attribute reaching a target value — before the workflow continues.

### Key Features and Functionality

| Feature              | Description                                                                                                  |
|----------------------|--------------------------------------------------------------------------------------------------------------|
| Simple Click         | Moves to the target element and performs a left click.                                                       |
| Positional Click     | Clicks at the current mouse position when no element locator is provided.                                    |
| Conditional Click    | Repeats the click until a named assertion condition passes or the timeout elapses.                           |
| Alert Dismissal      | The NoAlert condition automatically closes browser alerts between retries.                                   |
| Configurable Polling | The interval between retries is set by the Polling parameter, defaulting to 1500 ms.                         |
| Configurable Timeout | The maximum wait duration is set by the Timeout parameter, defaulting to the automation LoadTimeout setting. |

### Usages in RPA

| Use Case         | Description                                                                                    |
|------------------|------------------------------------------------------------------------------------------------|
| Form Submission  | Click a submit button after populating form fields to trigger a page transition.               |
| Modal Dismissal  | Click a close button or overlay to dismiss a modal dialog before the workflow continues.       |
| Alert Handling   | Repeatedly click an element and dismiss the resulting alert until the alert no longer appears. |
| Attribute-Driven | Click an element repeatedly until an attribute reaches a target value, then proceed.           |
| Step Navigation  | Click next or continue buttons to advance through multi-step forms or wizards.                 |

### Usages in Automation Testing

| Use Case                  | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| UI Interaction Testing    | Verify that clickable elements respond correctly to user interaction.                                  |
| Conditional State Testing | Test scenarios where a condition must be satisfied after one or more clicks before assertions can run. |
| Alert Presence Testing    | Confirm that an alert appears after clicking a trigger element.                                        |
| Attribute Value Testing   | Click a counter or toggle element and verify that its attribute value changes as expected.             |
| Regression Testing        | Ensure click behavior on interactive elements remains consistent after application updates.            |

## Examples

### Example No.1

### Click an element using a CSS selector

Locates the element matching `#SubmitButton` using the CssSelector strategy and performs a left click.
Use this form for any straightforward single-click interaction on a known stable element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Locator = "CssSelector",
    OnElement = "#SubmitButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setLocator("CssSelector")
    .setOnElement("#SubmitButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    locator: "CssSelector",
    onElement: "#SubmitButton"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "locator": "CssSelector",
    "onElement": "#SubmitButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "locator": "CssSelector",
    "onElement": "#SubmitButton"
}
```
### Example No.2

### Click at the current mouse position

Performs a click at the last known mouse cursor position without locating or targeting any element.
Use this form when mouse position has been set by a preceding move action and no element reference is needed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick"
}
```
### Example No.3

### Click repeatedly until an alert appears

Clicks the element matching `#TriggerAlert` every 1.5 seconds until a browser alert is detected or 15 seconds elapse.
The `Condition:AlertExists` argument causes the action to assert alert presence after each click before deciding whether to stop.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Condition:AlertExists --Polling:1.5 --Timeout:00:00:15}}",
    Locator = "CssSelector",
    OnElement = "#TriggerAlert"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Condition:AlertExists --Polling:1.5 --Timeout:00:00:15}}")
    .setLocator("CssSelector")
    .setOnElement("#TriggerAlert");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Condition:AlertExists --Polling:1.5 --Timeout:00:00:15}}",
    locator: "CssSelector",
    onElement: "#TriggerAlert"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:AlertExists --Polling:1.5 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onElement": "#TriggerAlert"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:AlertExists --Polling:1.5 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onElement": "#TriggerAlert"
}
```
### Example No.4

### Click and dismiss alerts until none remains

Clicks the element with id `PopAlert`, dismisses any browser alert that appears, and repeats every 1 second until a click triggers no alert.
The `Condition:NoAlert` argument activates the alert-dismissal handler, which closes any open alert between retries.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Condition:NoAlert --Polling:1.0 --Timeout:00:00:15}}",
    Locator = "Id",
    OnElement = "PopAlert"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Condition:NoAlert --Polling:1.0 --Timeout:00:00:15}}")
    .setLocator("Id")
    .setOnElement("PopAlert");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Condition:NoAlert --Polling:1.0 --Timeout:00:00:15}}",
    locator: "Id",
    onElement: "PopAlert"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:NoAlert --Polling:1.0 --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:NoAlert --Polling:1.0 --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```
### Example No.5

### Click until an element attribute reaches a target value

Clicks the element matching `#Counter` every 1 second until its `value` attribute equals `10`, or until 15 seconds elapse.
The `Condition:ElementAttribute` and `Equal:10` arguments configure the internal assertion that evaluates the attribute after each click.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Condition:ElementAttribute --Equal:10 --Polling:1.0 --Timeout:00:00:15}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "#Counter"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Condition:ElementAttribute --Equal:10 --Polling:1.0 --Timeout:00:00:15}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("#Counter");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Condition:ElementAttribute --Equal:10 --Polling:1.0 --Timeout:00:00:15}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "#Counter"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:ElementAttribute --Equal:10 --Polling:1.0 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#Counter"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Condition:ElementAttribute --Equal:10 --Polling:1.0 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#Counter"
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

Argument passes parameters to the conditional click mode using the `{{$ --Name:Value}}` macro format.
It accepts Condition, Polling, and Timeout parameters that control retry behavior.
When Argument is absent the action performs a single non-conditional click.

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

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnAttribute names the HTML attribute read from the element when evaluating the conditional assertion.
It is forwarded to the internal Assert rule and controls which attribute value is compared against the condition.
When absent the assertion operates on the element's default value or text content.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to click.
It is evaluated using the strategy defined by the Locator property.
When absent the action clicks at the current mouse position instead.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Condition names the assertion that must pass for the conditional click loop to stop.
When Condition is absent the action performs a single click with no retry loop.
Supplying Condition but leaving its value empty causes a MissingMandatoryParameterException at runtime.

#### Values

##### No Alert

NoAlert repeats the click and dismisses any browser alert that appears until no alert is triggered by the click.
It is also accepted as AlertNotExists or HasNoAlert — all three resolve to the same handler.
Use this condition when an action repeatedly triggers alerts that must be cleared before proceeding.

### Polling (Polling)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1500              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Polling sets the wait duration in milliseconds between click retries in conditional mode.
It controls how frequently the action clicks and re-evaluates the condition.
When absent the default interval of 1500 milliseconds is used.

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Timeout sets the maximum duration the conditional click loop is allowed to run.
When the timeout elapses the loop exits regardless of whether the condition was met.
When absent the automation LoadTimeout setting is used as the timeout value.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-click](https://www.w3.org/TR/webdriver/#element-click)
