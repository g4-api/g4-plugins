# No Action (NoAction)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `NoAction` plugin represents a plugin that performs no action. It is used primarily as a placeholder, a container for other plugins, or for testing purposes within automation scripts.

### Key Features and Functionality

| Feature             | Description                                                                                                   |
|---------------------|---------------------------------------------------------------------------------------------------------------|
| No Operation        | Executes without performing any action, serving as a placeholder or a test step.                              |
| Rule Invocation     | Sets the invoke rules to true, allowing the rules under this action to be invoked.                            |
| Logging             | Logs the execution of the action with its name and argument for debugging and tracking purposes.              |
| Container for Rules | Can be used as a container to organize other plugins, wrapping multiple steps into a single logical grouping. |

### Usages in RPA

| Usage               | Description                                                                                                                                                                          |
|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Placeholder Step    | Use the `NoAction` plugin as a placeholder step in automation scripts where an action might be added later.                                                                          |
| Debugging           | Employ the `NoAction` plugin to test the flow of automation scripts without performing any actual operations.                                                                        |
| Container for Steps | Utilize the `NoAction` plugin to group multiple steps into a single logical unit, such as wrapping all login steps under a single `NoAction` plugin with the argument 'Login Steps'. |

### Usages in Automation Testing

| Usage               | Description                                                                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Test Initialization | Use the `NoAction` plugin at the beginning of tests to ensure the setup is correct before performing actual actions.                           |
| Flow Verification   | Utilize the `NoAction` plugin to verify the logical flow of test scripts without executing real actions.                                       |
| Grouping Test Steps | Organize related test steps under a single `NoAction` plugin to create a logical grouping, making the test script easier to read and maintain. |

## Examples

### Example No.1

This configuration uses the `NoAction` plugin as a placeholder within an automation script.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NoAction",
    Argument = "Placeholder Argument"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NoAction")
    .setArgument("Placeholder Argument");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NoAction",
    argument: "Placeholder Argument"
};
```

_**JSON**_

```js
{
    "pluginName": "NoAction",
    "argument": "Placeholder Argument"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NoAction",
    "argument": "Placeholder Argument"
}
```
### Example No.2

This configuration uses the `NoAction` plugin for debugging purposes, logging the execution without performing any operations.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NoAction",
    Argument = "Debugging Argument"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NoAction")
    .setArgument("Debugging Argument");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NoAction",
    argument: "Debugging Argument"
};
```

_**JSON**_

```js
{
    "pluginName": "NoAction",
    "argument": "Debugging Argument"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NoAction",
    "argument": "Debugging Argument"
}
```
### Example No.3

This configuration uses the `NoAction` plugin as a container to group login steps.

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
            OnElement = "#username"
        },
        new ActionRuleModel
        {
            PluginName = "SendKeys",
            Argument = "Password",
            OnElement = "#password"
        }
        new ActionRuleModel
        {
            PluginName = "Click",
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
            .setOnElement("#username"),

        new ActionRuleModel()        
            .setPluginName("SendKeys")
            .setArgument("Password")
            .setOnElement("#password"))
        new ActionRuleModel()        
            .setPluginName("Click")
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
            onElement: "#username"
        },
        {
            pluginName: "SendKeys",
            argument: "Password",
            onElement: "#password"
        }
        {
            pluginName: "Click",
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
            "onElement": "#username"
        },
        {
            "pluginName": "SendKeys",
            "argument": "Password",
            "onElement": "#password"
        }
        {
            "pluginName": "Click",
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
            "onElement": "#username"
        },
        {
            "pluginName": "SendKeys",
            "argument": "Password",
            "onElement": "#password"
        }
        {
            "pluginName": "Click",
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

Specifies the argument value that will be logged during the execution of the plugin.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Specifies an array of rules (steps) that will be invoked by this plugin. Each rule can represent an action or a sequence of actions. When the `NoAction` plugin executes, it can serve as a container for these defined rules, organizing multiple steps under a single logical grouping.

## Scope

* Any