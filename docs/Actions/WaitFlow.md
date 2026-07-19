# Wait Flow (WaitFlow)

[Table of Content](../Home.md)  

~24 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Pauses an automation script until a set condition is true or a timeout occurs.
This helps ensure steps run in the right order and prevents errors when waiting for something to appear or change.

### Key Features and Functionality

| Feature               | Description                                                            |
|-----------------------|------------------------------------------------------------------------|
| Conditional Waiting   | Pause execution until a given condition is met at runtime.             |
| Timeout Handling      | Use a set delay to wait a fixed amount of time before continuing.      |
| Assertion Integration | Use assertion plugins to check conditions and control when to proceed. |
| Meta Action Creation  | Build and run assertion steps dynamically to decide flow.              |

### Usages in RPA

| Use Case                 | Description                                                         |
|--------------------------|---------------------------------------------------------------------|
| Conditional Flow Control | Stop a robot until data or a page element meets a required state.   |
| Timed Delays             | Wait a fixed time between steps to prevent race conditions.         |
| Dynamic Task Management  | Hold off on actions until external events or data become available. |

### Usages in Automation Testing

| Use Case                    | Description                                                               |
|-----------------------------|---------------------------------------------------------------------------|
| Wait for Element Visibility | Pause a test until a page element appears before continuing.              |
| Synchronization Points      | Insert waits to keep tests in sync with the application under test.       |
| Handle Asynchronous Events  | Wait for background actions or data loads before moving to the next step. |

## Examples

### Example No.1

### Wait for Login Form to Become Visible (Millisecond Timeout)

Wait for the login form with the CSS selector `#loginForm` to become visible, using a maximum timeout of 8,000 milliseconds (8 seconds).
It uses the `WaitFlow` plugin with `--Condition:ElementVisible` and `--Timeout:8000`, applied to the element located by CSS selector `#loginForm`. Note that this timeout is specified in milliseconds.
Wait steps do not return a value; they only block execution until the condition is met or the timeout expires.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementVisible --Timeout:8000}}",
    Locator = "CssSelector",
    OnElement = "#loginForm"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementVisible --Timeout:8000}}")
    .setLocator("CssSelector")
    .setOnElement("#loginForm");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementVisible --Timeout:8000}}",
    locator: "CssSelector",
    onElement: "#loginForm"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:8000}}",
    "locator": "CssSelector",
    "onElement": "#loginForm"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:8000}}",
    "locator": "CssSelector",
    "onElement": "#loginForm"
}
```
### Example No.2

### Wait for Login Form to Become Visible (HH:MM:SS Timeout)

Wait for the login form with the CSS selector `#loginForm` to become visible, using a maximum timeout of 00:00:08 (8 seconds).
It uses the `WaitFlow` plugin with `--Condition:ElementVisible` and `--Timeout:00:00:08`, applied to the element located by CSS selector `#loginForm`. Note that this timeout is specified in HH:MM:SS format.
Wait steps do not return a value; they only block execution until the condition is met or the timeout expires.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementVisible --Timeout:00:00:08}}",
    Locator = "CssSelector",
    OnElement = "#loginForm"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementVisible --Timeout:00:00:08}}")
    .setLocator("CssSelector")
    .setOnElement("#loginForm");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementVisible --Timeout:00:00:08}}",
    locator: "CssSelector",
    onElement: "#loginForm"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:00:00:08}}",
    "locator": "CssSelector",
    "onElement": "#loginForm"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:00:00:08}}",
    "locator": "CssSelector",
    "onElement": "#loginForm"
}
```
### Example No.3

### Pause Execution for 4 Seconds

Pause execution for 4 seconds before continuing to the next step.
It uses the `WaitFlow` plugin with an argument of `00:00:04`.
Wait steps do not return a value; they block execution for the specified duration.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "00:00:04"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("00:00:04");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "00:00:04"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "00:00:04"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "00:00:04"
}
```
### Example No.4

### Wait for `data-status` Attribute to Match via XPath (Millisecond Timeout)

Wait for the `data-status` attribute of the `<div id='dataContainer'>` element to match the pattern `data-loaded`, using a maximum timeout of 12,000 milliseconds (12 seconds).
It uses the `WaitFlow` plugin with `--Condition:ElementAttribute`, `--Operator:Match`, `--Expected:data-loaded`, and `--Timeout:12000`, applied to the element’s `data-status` attribute. Note that the timeout is specified in milliseconds.
Wait steps block execution until the condition is met or the timeout expires.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:data-loaded --Timeout:12000}}",
    OnAttribute = "data-status",
    OnElement = "//div[@id='dataContainer']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:data-loaded --Timeout:12000}}")
    .setOnAttribute("data-status")
    .setOnElement("//div[@id='dataContainer']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:data-loaded --Timeout:12000}}",
    onAttribute: "data-status",
    onElement: "//div[@id='dataContainer']"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:data-loaded --Timeout:12000}}",
    "onAttribute": "data-status",
    "onElement": "//div[@id='dataContainer']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:data-loaded --Timeout:12000}}",
    "onAttribute": "data-status",
    "onElement": "//div[@id='dataContainer']"
}
```
### Example No.5

### Wait for Specific Text via CSS Selector

Wait for the text `Order Complete` to appear in the element located by CSS selector `#statusMessage`. It uses the `WaitFlow` plugin with `--Condition:ElementText`, `--Operator:Equal`, and `--Expected:Order Complete` applied to the element. The timeout is specified as the system’s default duration.
Wait steps block execution until the condition is met or the system’s default timeout expires.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Order Complete}}",
    Locator = "CssSelector",
    OnElement = "#statusMessage"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Order Complete}}")
    .setLocator("CssSelector")
    .setOnElement("#statusMessage");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Order Complete}}",
    locator: "CssSelector",
    onElement: "#statusMessage"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Order Complete}}",
    "locator": "CssSelector",
    "onElement": "#statusMessage"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Order Complete}}",
    "locator": "CssSelector",
    "onElement": "#statusMessage"
}
```
### Example No.6

### Pause Execution for 2 Seconds

Pause execution for 2 seconds before continuing to the next step. It uses the `WaitFlow` plugin with an argument of `2000` (milliseconds).
Wait steps block execution for the specified duration.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "2000"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("2000");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "2000"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "2000"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "2000"
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
| **Value Type**    | Number|Expression |

A value that sets how long to pause or what condition to check before continuing.
Fixed waits use a time span format to define the pause duration.
Conditional waits specify what to look for and any needed parameters.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Method used to find an item on a page or in an app.
Common methods include XPath, CSS selectors, or IDs.
Choosing the correct method ensures the right element is found.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Name of the element’s property whose value will be used or checked.
It identifies which piece of the element the system needs.
Picking the correct property ensures the right data is accessed.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which element the system will check or interact with.
It points to the item on a page or in an application where conditions apply.
Targeting the correct element ensures accurate automation behavior.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

A rule that tells the system what must be true for an action to proceed.
It sets the situation or threshold to check before moving on.
Clear conditions help the automation follow the correct path.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

The value or pattern the script looks for when checking a condition.
It defines what outcome counts as a match.
Clear expected values ensure accurate checks.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

How the system compares the actual result to the expected value.
It can check for equality, greater than, or other comparisons.
Picking the right comparison type makes sure decisions are correct.

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

The longest time the script waits for a condition before moving on.
It prevents the process from hanging indefinitely.
After this time, the script moves to the next step even if the condition is not met.

## Scope

* Any