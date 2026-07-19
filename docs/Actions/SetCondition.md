# Set Condition (SetCondition)

[Table of Content](../Home.md)  

~18 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Lets automation scripts choose between two paths based on a condition, similar to an if/else. It checks a condition using an assertion plugin and then runs one set of actions if the condition is true or another set if it is false. This makes it easy to handle decisions and control flow without extra steps.

### Key Features and Functionality

| Feature                | Description                                                            |
|------------------------|------------------------------------------------------------------------|
| True/False Branching   | Run one group of actions when a condition is true, another when false. |
| Assertion-Based Checks | Use assertion plugins to evaluate expressions reliably.                |
| Meta Plugin Creation   | Build and send assertion actions to decide which branch to execute.    |

### Usages in RPA

| Use Case            | Description                                                                      |
|---------------------|----------------------------------------------------------------------------------|
| Conditional Actions | Perform steps under one branch if data meets criteria, else run alternate steps. |
| Dynamic Workflows   | Direct workflow into different paths based on real-time checks.                  |
| Error Handling      | Run recovery actions when an error flag is set, skip them otherwise.             |

### Usages in Automation Testing

| Use Case              | Description                                                                   |
|-----------------------|-------------------------------------------------------------------------------|
| Conditional Test Runs | Execute one set of tests when prerequisites are met, else run fallback tests. |
| Dynamic Test Flows    | Switch between test steps based on the outcome of prior assertions.           |
| Validation Branching  | Perform extra checks if initial assertions pass, or log issues if they fail.  |

## Examples

### Example No.1

### Check Welcome Message and Click “Proceed” if Present

Verify that the welcome message displays “Welcome back!” and, if it does, click the “Proceed” button.
It uses a `SetCondition` step with `ElementText` comparison against `Welcome back!` on the element located by CSS selector `#welcomeMessage`. If the condition is true, it executes a `Click` action on the element `#proceedButton`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Welcome back!}}",
    Locator = "CssSelector",
    OnElement = "#welcomeMessage"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Welcome back!}}")
    .setLocator("CssSelector")
    .setOnElement("#welcomeMessage");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Welcome back!}}",
    locator: "CssSelector",
    onElement: "#welcomeMessage"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Welcome back!}}",
    "locator": "CssSelector",
    "onElement": "#welcomeMessage"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Welcome back!}}",
    "locator": "CssSelector",
    "onElement": "#welcomeMessage"
}
```
### Example No.2

### Check for Cookie Consent Banner and Type “Accept” if Present

Detect whether a cookie consent banner is displayed and, if so, type “Accept” into the consent input field.
It uses a `SetCondition` step with `AlertExists`. If true, it executes a `SendKeys` action with argument “Accept” on the element located by CSS selector `#cookieConsentInput`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:AlertExists}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:AlertExists}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:AlertExists}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:AlertExists}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:AlertExists}}"
}
```
### Example No.3

### Check Dashboard Page and Click “Go to Dashboard” if Present

Verify whether the current page URL matches the dashboard page, and if it does, click the “Go to Dashboard” button.
It uses a `SetCondition` step with `PageUrl` and the `NotMatch` operator against `https://myapp.com/dashboard/*` (the `NotMatch` operator causes the `false` branch to run when there is a match). If the condition is false, it executes a `Click` action on the element located by XPath `//a[@id='goToDashboard']`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://myapp.com/dashboard/*}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://myapp.com/dashboard/*}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://myapp.com/dashboard/*}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://myapp.com/dashboard/*}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://myapp.com/dashboard/*}}"
}
```
### Example No.4

### Check Shopping Cart Page and Search or Click “Checkout”

Verify whether the current page URL matches the shopping cart page and, if it does not, type “laptop” into the search box; otherwise, click the “Checkout” button.
It uses a `SetCondition` step with `PageUrl` and the `NotMatch` operator against `https://shop.example.com/cart`. If the condition is true, it executes a `SendKeys` action with argument “laptop” on the element located by ID `searchBox`; if the condition is false, it executes a `Click` action on the element located by XPath `//button[@id='checkoutButton']`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetCondition",
    Argument = "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://shop.example.com/cart}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetCondition")
    .setArgument("{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://shop.example.com/cart}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetCondition",
    argument: "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://shop.example.com/cart}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://shop.example.com/cart}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetCondition",
    "argument": "{{$ --Condition:PageUrl --Operator:NotMatch --Expected:https://shop.example.com/cart}}"
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
| **Value Type**    | Expression        |

A rule that tells the plugin what to check and how to check it.
It includes the condition and any settings needed for that check.
Clear instructions help the plugin determine if the check passes.

### Branches (Branches)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Object            |

A set of steps or instructions that run when the check succeeds.
These steps define what happens after the condition is met.
Organized actions ensure the plugin follows the correct flow.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

How the plugin finds items on a webpage or in an app.
XPath is used by default when no other method is given.
Picking the right method makes sure the plugin targets the correct item.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A property of the element that the system will read or use during the process.
It tells the system which part of the element holds the needed information.
Choosing the correct property ensures the right data is captured.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The element where the system will check conditions or perform actions.
It tells the system which part of the page or app to focus on.
Pointing to the right element ensures accurate results.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

A pattern that filters the element or attribute value before it is checked.
Only text that matches the pattern will be kept for evaluation.
Using a clear pattern helps the system work with the exact text needed.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

The list of conditions updates automatically when new ones are added.
A rule that tells the system what must be true before running additional steps.
It decides whether the next actions will execute.
Clear conditions help keep the automation on the right path.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

The value used to check against the actual result.
It defines what outcome counts as correct.
Precise expected values help avoid errors.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

The list of comparison types updates automatically when new ones are added.
The way the system compares actual results to the expected value.
It can check for equality, greater than, or other comparisons.
Choosing the right comparison type ensures proper decision making.

## Scope

* Any