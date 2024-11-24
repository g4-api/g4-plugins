# Wait Flow (WaitFlow)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `WaitFlow` plugin is essential for managing the execution flow in both Robotic Process Automation (RPA) and automation testing. 
Its primary objective is to pause the execution of an automation script until a specified condition is met or a timeout duration has elapsed.

### Key Features and Functionality

| Feature                     | Description                                                                                              |
|-----------------------------|----------------------------------------------------------------------------------------------------------|
| Conditional Waiting         | Waits until a specified condition is met, allowing for dynamic flow control based on runtime conditions. |
| Timeout Handling            | Implements simple delays using specified timeout durations, ensuring controlled execution timing.        |
| Meta Action                 | Creates, sends, and evaluates assertion plugins to determine whether to proceed based on conditions.     |
| Integration with Assertions | Utilizes assertion plugins to evaluate conditions, ensuring flexible and dynamic waiting logic.          |

### Usages in RPA

| Usage                    | Description                                                                                        |
|--------------------------|--------------------------------------------------------------------------------------------------- |
| Conditional Flow Control | Pause execution until specific conditions are met, ensuring proper sequencing in automation tasks. |
| Timed Delays             | Implement delays in the workflow to avoid race conditions or ensure timing between steps.          |
| Dynamic Task Management  | Manage dynamic tasks that require waiting for certain conditions to be true before proceeding.     |

### Usages in Automation Testing

| Usage                       | Description                                                                                                           |
|-----------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Wait for Element Visibility | Wait for elements to become visible on the page before interacting with them, ensuring stable and reliable tests.     |
| Synchronization Points      | Introduce synchronization points in test scripts, waiting for specific conditions to be met before continuing.        |
| Handle Asynchronous Events  | Manage asynchronous events by waiting for conditions to be met, ensuring tests adapt to dynamic application behavior. |

## Examples

### Example No.1

Wait for the element with the CSS selector `#loading` to become visible, with a maximum timeout of 10 seconds.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementVisible --Timeout:10000}}",
    Locator = "CssSelector",
    OnElement = "#loading"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementVisible --Timeout:10000}}")
    .setLocator("CssSelector")
    .setOnElement("#loading");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementVisible --Timeout:10000}}",
    locator: "CssSelector",
    onElement: "#loading"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:10000}}",
    "locator": "CssSelector",
    "onElement": "#loading"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementVisible --Timeout:10000}}",
    "locator": "CssSelector",
    "onElement": "#loading"
}
```
### Example No.2

Pause execution for 5 seconds before proceeding to the next action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "00:00:05"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("00:00:05");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "00:00:05"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "00:00:05"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "00:00:05"
}
```
### Example No.3

Wait for the attribute `class` of the element with the XPath `//div[@id='status']` to match the regular expression `completed`, with a timeout of 15 seconds.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:completed --Timeout:15000}}",
    OnAttribute = "class",
    OnElement = "//div[@id='status']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:completed --Timeout:15000}}")
    .setOnAttribute("class")
    .setOnElement("//div[@id='status']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:completed --Timeout:15000}}",
    onAttribute: "class",
    onElement: "//div[@id='status']"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:completed --Timeout:15000}}",
    "onAttribute": "class",
    "onElement": "//div[@id='status']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:completed --Timeout:15000}}",
    "onAttribute": "class",
    "onElement": "//div[@id='status']"
}
```
### Example No.4

Wait for a specific text `Success` to be present in the element with the CSS selector `#result` before proceeding.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:Success}}",
    Locator = "CssSelector",
    OnElement = "#result"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("{{$ --Condition:ElementText --Operator:Equal --Expected:Success}}")
    .setLocator("CssSelector")
    .setOnElement("#result");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "{{$ --Condition:ElementText --Operator:Equal --Expected:Success}}",
    locator: "CssSelector",
    onElement: "#result"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Success}}",
    "locator": "CssSelector",
    "onElement": "#result"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "{{$ --Condition:ElementText --Operator:Equal --Expected:Success}}",
    "locator": "CssSelector",
    "onElement": "#result"
}
```
### Example No.5

Pause execution for 3 seconds before proceeding to the next action.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WaitFlow",
    Argument = "3000"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WaitFlow")
    .setArgument("3000");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WaitFlow",
    argument: "3000"
};
```

_**JSON**_

```js
{
    "pluginName": "WaitFlow",
    "argument": "3000"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WaitFlow",
    "argument": "3000"
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

Defines the duration to wait or the condition to evaluate, based on the type of wait specified. For time-based waits, it takes a `TimeSpan` format. For condition-based waits, it specifies the condition and parameters.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies how elements should be located on a webpage or within an application.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute of the target element that will be interacted with or evaluated during automation.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target element on which conditions will be evaluated during the automation process.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Assert            |

Specifies the criteria or state that must be evaluated or met during the execution of a plugin or action.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Specifies the value or pattern that the automation script expects to find or match during the execution of a condition.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Specifies the type of comparison or operation to be performed when evaluating a condition.

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Specifies the maximum duration the automation script should wait for a condition to be met before proceeding with the next step, after which it will terminate.
