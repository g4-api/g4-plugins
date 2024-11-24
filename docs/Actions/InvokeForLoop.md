# Invoke For Loop (InvokeForLoop)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `InvokeForLoop` plugin serves as a fundamental tool in both Robotic Process Automation (RPA) and automation testing contexts. 
Its primary objective is to enable efficient and controlled iteration over a predefined set of actions within automation scripts, providing a flexible solution for handling repetitive tasks with a specified number of iterations.

### Key Features and Functionality

| Feature                 | Description                                                                                                                                                                 |
|-------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Controlled Iteration    | Allows for controlled iteration over a series of actions, executing a predefined number of iterations as specified by the user.                                             |
| Sequential Execution    | Executes actions sequentially within the loop, ensuring orderly and predictable execution of tasks.                                                                         |
| Parameterized Iteration | Employ parameterized iteration to dynamically control loop variables based on changing conditions or input values, enhancing adaptability and flexibility in RPA solutions. |

### Usages in RPA

| Use Case                | Description                                                                                                                                                                 |
|-------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Data Processing         | Utilize the `InvokeForLoop` plugin for processing datasets with a fixed number of iterations, performing actions on each data entry or record.                              |
| Batch Processing        | Automate batch processing tasks within RPA workflows by leveraging the for loop to execute a series of actions on a predefined set of data or inputs.                       |
| Parameterized Iteration | Employ parameterized iteration to dynamically control loop variables based on changing conditions or input values, enhancing adaptability and flexibility in RPA solutions. |

### Usages in Automation Testing

| Use Case            | Description                                                                                                                                                                                                         |
|---------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Test Case Iteration | In automated testing, leverage the `InvokeForLoop` plugin to iteratively execute test cases with a specified number of iterations, ensuring comprehensive test coverage.                                            |
| Data-Driven Testing | Utilize parameterized iteration to perform data-driven testing, iterating over datasets or input values to validate application behavior under various conditions.                                                  |
| Load Testing        | Employ the for loop to simulate concurrent user interactions or load scenarios in automation testing, executing a series of actions with a predefined number of iterations to assess system performance under load. |

## Examples

### Example No.1

Instructs the automation script to execute the `Click` action on the HTML element with the CSS selector `#NextBtn1` five times in sequential order.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForLoop",
    Argument = "5",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "#NextBtn1"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForLoop")
    .setArgument("5")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#NextBtn1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForLoop",
    argument: "5",
    rules: [
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "#NextBtn1"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#NextBtn1"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#NextBtn1"
        }
    ]
}
```
### Example No.2

This configuration represents a usage of the `InvokeForLoop` plugin along with other actions in an automation scenario.

1. **For Loop:**
   - The loop is initiated by the `InvokeForLoop` plugin.
   - It specifies that the enclosed actions will be executed a total of 2 times.

2. **Nested Actions:**
   - Within the loop, three actions are defined.
   - The first action is another instance of the `InvokeForLoop` plugin, creating a nested loop.
   - This nested loop also specifies 2 iterations and contains a single action to click on the element with the CSS selector `#NextBtn2`.

3. **Next Actions:**
   - After the nested loop completes its iterations, the script proceeds to the next action outside the loop, which is to click on the element with the CSS selector `#FirstBtn2`.
   - Following this, another action is performed to click on the element with the CSS selector `#NextBtn1`.

In summary, this configuration orchestrates a scenario where a set of actions is repeated a specific number of times within a loop structure created by the `InvokeForLoop` plugin. 
The nested usage of the plugin demonstrates the flexibility to create complex automation workflows with repetitive actions executed in a controlled manner.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForLoop",
    Argument = "2",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "InvokeForLoop",
            Argument = "2",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "Click",
                    Locator = "CssSelector",
                    OnElement = "#NextBtn2"
                }
            }
        },
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "#FirstBtn2"
        }
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "#NextBtn1"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForLoop")
    .setArgument("2")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("InvokeForLoop")
            .setArgument("2")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("Click")
                    .setLocator("CssSelector")
                    .setOnElement("#NextBtn2"),

        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#FirstBtn2"))
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#NextBtn1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForLoop",
    argument: "2",
    rules: [,
        {
            pluginName: "InvokeForLoop",
            argument: "2",
            rules: [
                {
                    pluginName: "Click",
                    locator: "CssSelector",
                    onElement: "#NextBtn2"
                }
            ]
        },
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "#FirstBtn2"
        }
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "#NextBtn1"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForLoop",
    "argument": "2",
    "rules": [,
        {
            "pluginName": "InvokeForLoop",
            "argument": "2",
            "rules": [
                {
                    "pluginName": "Click",
                    "locator": "CssSelector",
                    "onElement": "#NextBtn2"
                }
            ]
        },
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#FirstBtn2"
        }
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#NextBtn1"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForLoop",
    "argument": "2",
    "rules": [,
        {
            "pluginName": "InvokeForLoop",
            "argument": "2",
            "rules": [
                {
                    "pluginName": "Click",
                    "locator": "CssSelector",
                    "onElement": "#NextBtn2"
                }
            ]
        },
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#FirstBtn2"
        }
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#NextBtn1"
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
| **Value Type**    | Number|Expression |

Specifies the number of iterations the loop will execute. 
This property indicates the fixed number of times the loop will iterate, providing control over the repetitive execution of actions within the loop. 
Each action defined within the loop will be executed for the specified number of iterations, allowing for controlled and predictable automation workflows.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Define a sequence of actions or instructions to be executed within a loop or under specific conditions.
