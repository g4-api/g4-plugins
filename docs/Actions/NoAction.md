# No Action (NoAction)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Does nothing on its own and serves as a placeholder in your automation script. It can wrap other steps without side effects, making it useful for grouping or testing script flow. This helps you organize complex processes and debug workflows more easily.

### Key Features and Functionality

| Feature         | Description                                                  |
|-----------------|--------------------------------------------------------------|
| No Operation    | Runs without performing any action, acting as a placeholder. |
| Rule Invocation | Triggers attached rules when conditions are met.             |
| Logging         | Records execution details for tracking and debugging.        |
| Container       | Groups multiple steps under one logical block.               |

### Usages in RPA

| Use Case         | Description                                                   |
|------------------|---------------------------------------------------------------|
| Placeholder Step | Reserve a spot in a script where actions will be added later. |
| Debug Flow       | Test script logic without executing real operations.          |
| Step Grouping    | Combine related steps into one block for clarity.             |

### Usages in Automation Testing

| Use Case          | Description                                                                |
|-------------------|----------------------------------------------------------------------------|
| Test Setup        | Mark the start of tests and verify the environment before running actions. |
| Flow Verification | Check test logic without performing actual steps.                          |
| Test Grouping     | Organize related test steps under one marker for better readability.       |

## Examples

### Example No.1

### Placeholder Action Using NoAction Plugin

Logs execution points without performing any operations, useful for placeholder or debugging checkpoints.
No action is performed; the plugin simply records the event.
Use this to mark points in the workflow where no actual action is desired.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NoAction",
    Argument = "This is a Placeholder Action"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NoAction")
    .setArgument("This is a Placeholder Action");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NoAction",
    argument: "This is a Placeholder Action"
};
```

_**JSON**_

```js
{
    "pluginName": "NoAction",
    "argument": "This is a Placeholder Action"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NoAction",
    "argument": "This is a Placeholder Action"
}
```
### Example No.2

### Debugging Point Using NoAction Plugin

Logs a debugging point labeled `Debugging Point` without performing any operations.
No action is performed; the plugin simply records the debugging event.
Use this to insert non-invasive debug markers in the workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NoAction",
    Argument = "Debugging Point"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NoAction")
    .setArgument("Debugging Point");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NoAction",
    argument: "Debugging Point"
};
```

_**JSON**_

```js
{
    "pluginName": "NoAction",
    "argument": "Debugging Point"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NoAction",
    "argument": "Debugging Point"
}
```
### Example No.3

### Login Steps Grouping Using NoAction Plugin

Serves as a container to group multiple login actions: sending username, sending password, and clicking the login button.
Each inner action executes in sequence: SendKeys to `#username`, SendKeys to `#password`, then Click `#loginButton`.
NoAction itself performs no operations; it simply orchestrates the contained actions.
Useful for logically grouping related steps in the workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NoAction",
    Argument = "Login Steps",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "SendKeys",
            Argument = "Username",
            Locator = "CssSelector",
            OnElement = "#username"
        },
        new ActionRuleModel
        {
            PluginName = "SendKeys",
            Argument = "Password",
            Locator = "CssSelector",
            OnElement = "#password"
        }
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "#loginButton"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NoAction")
    .setArgument("Login Steps")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("SendKeys")
            .setArgument("Username")
            .setLocator("CssSelector")
            .setOnElement("#username"),

        new ActionRuleModel()        
            .setPluginName("SendKeys")
            .setArgument("Password")
            .setLocator("CssSelector")
            .setOnElement("#password"))
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#loginButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NoAction",
    argument: "Login Steps",
    rules: [,
        {
            pluginName: "SendKeys",
            argument: "Username",
            locator: "CssSelector",
            onElement: "#username"
        },
        {
            pluginName: "SendKeys",
            argument: "Password",
            locator: "CssSelector",
            onElement: "#password"
        }
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "#loginButton"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "NoAction",
    "argument": "Login Steps",
    "rules": [,
        {
            "pluginName": "SendKeys",
            "argument": "Username",
            "locator": "CssSelector",
            "onElement": "#username"
        },
        {
            "pluginName": "SendKeys",
            "argument": "Password",
            "locator": "CssSelector",
            "onElement": "#password"
        }
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#loginButton"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NoAction",
    "argument": "Login Steps",
    "rules": [,
        {
            "pluginName": "SendKeys",
            "argument": "Username",
            "locator": "CssSelector",
            "onElement": "#username"
        },
        {
            "pluginName": "SendKeys",
            "argument": "Password",
            "locator": "CssSelector",
            "onElement": "#password"
        }
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#loginButton"
        }
    ]
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
| **Value Type**    | String            |

Sets the text or data that the plugin will log.
Log entries help you track what happened during execution.
You must provide this value for the plugin to record.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Defines a list of steps that the plugin will perform.
Each step can be a single action or a set of actions.
Groups steps under one logical block without producing side effects.
Nested containers build a hierarchical tree of grouped steps.

## Scope

* Any