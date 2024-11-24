# Invoke While Loop (InvokeWhileLoop)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `InvokeWhileLoop` plugin serves a crucial purpose in both Robotic Process Automation (RPA) and automation testing contexts. 
Its primary objective is to enable dynamic and repetitive execution of actions within automation scripts, providing a versatile solution for handling iterative tasks based on specified conditions.

### Key Features and Functionality

| Feature                           | Description                                                                                                                                                                   |
|-----------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Iteration                 | Enables dynamic iteration over a series of actions, allowing automation scripts to adapt to changing conditions during runtime.                                               |
| Conditional Execution             | Governs the while loop with user-defined conditions, making it ideal for scenarios where actions need to be repeated until a specific state is achieved.                      |
| Timeout Handling                  | Provides a mechanism to specify a timeout for the loop, preventing infinite loops and allowing for graceful termination if conditions are not met within a defined timeframe. |
| Extraction and Performance Points | Seamlessly integrates with the automation framework to synchronize extractions and performance points during each iteration, enhancing insights into the execution flow.      |
| Session Parameter Management      | Efficiently handles session parameters, ensuring adaptability to changes in the environment during runtime and enhancing the flexibility of automation scripts.               |

### Usages in RPA

| Use Case                   | Description                                                                                                                                                                  |
|----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Data Validation            | Utilize the `InvokeWhileLoop` plugin for iterating through datasets, performing validation checks until specific data conditions are met.                                    |
| Dynamic Process Automation | Employ the while loop to automate repetitive tasks within a business process, dynamically responding to changing conditions and ensuring robust and adaptable RPA solutions. |
| Conditional Flow Control   | Integrate the plugin for conditional flow control in RPA scenarios, allowing automation scripts to dynamically respond to varying conditions during execution.               |

### Usages in Automation Testing

| Use Case                   | Description                                                                                                                                                                              |
|----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Dynamic Testing            | In automated testing, leverage the `InvokeWhileLoop` plugin to iteratively interact with an application until a desired state is achieved, accommodating dynamic UI changes.             |
| Repetitive Task Automation | Automate repetitive tasks in automation testing by utilizing the while loop to execute a set of actions until predefined conditions are satisfied, ensuring comprehensive test coverage. |
| Conditional Flow Testing   | Enhance automation testing scenarios by integrating the plugin for conditional flow testing, allowing dynamic responses to changing conditions during the test execution process.        |

## Examples

### Example No.1

Iteratively click the `Next` button until a specific condition, checking for the presence of the word `active` in the `class` attribute of a designated button element, is met. 
The `InvokeWhileLoop` plugin orchestrates this repetitive clicking action, providing a flexible mechanism for dynamically handling conditions within automation workflows.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    OnAttribute = "class",
    OnElement = "//ul[@id='Pagination1']/li/button[.='6']",
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
    .setPluginName("InvokeWhileLoop")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}")
    .setOnAttribute("class")
    .setOnElement("//ul[@id='Pagination1']/li/button[.='6']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#NextBtn1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeWhileLoop",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    onAttribute: "class",
    onElement: "//ul[@id='Pagination1']/li/button[.='6']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
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

This configuration represents a nested usage of the `InvokeWhileLoop` plugin along with other actions in an automation scenario.

1. **Outer Loop:**
   - The outer loop is initiated by the `InvokeWhileLoop` plugin.
   - It checks a condition: whether the `class` attribute of a button element with text content `3` within an unordered list (`ul`) with id `Pagination1` contains the word `active`.

2. **Outer Loop Action:**
   - If the condition is met, the inner loop is executed.
   - If not, the script proceeds to the next action outside the loop.

3. **Inner Loop:**
   - Within the outer loop, there's another `InvokeWhileLoop` plugin.
   - This inner loop also checks a condition: whether the `class` attribute of a button element with text content `3` within an unordered list (`ul`) with id `Pagination2` contains the word `active`.

4. **Inner Loop Action:**
   - If the condition in the inner loop is met, a click action is performed on the element with the CSS selector `#NextBtn2`.
   - This action is repeated until the condition is no longer satisfied.

5. **Next Action:**
   - If the condition in the inner loop is not met, or after the inner loop completes, the script proceeds to the next action outside the inner loop.

6. **Further Actions:**
   - After the inner loop (and potentially the outer loop) completes, additional actions are performed.
   - These actions include clicking on elements with CSS selectors `#FirstBtn2` and `#NextBtn1`.

In summary, this configuration orchestrates a complex automation scenario where the script iteratively performs actions based on conditions. 
The outer and inner loops, controlled by the `InvokeWhileLoop` plugin, navigate through elements and perform actions dynamically. 
This approach enables the automation script to adapt to changing conditions and execute actions efficiently within the defined workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    OnAttribute = "class",
    OnElement = "//ul[@id='Pagination1']/li/button[.='3']",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "InvokeWhileLoop",
            Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
            OnAttribute = "class",
            OnElement = "//ul[@id='Pagination2']/li/button[.='3']",
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
    .setPluginName("InvokeWhileLoop")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}")
    .setOnAttribute("class")
    .setOnElement("//ul[@id='Pagination1']/li/button[.='3']")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("InvokeWhileLoop")
            .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}")
            .setOnAttribute("class")
            .setOnElement("//ul[@id='Pagination2']/li/button[.='3']")
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
    pluginName: "InvokeWhileLoop",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    onAttribute: "class",
    onElement: "//ul[@id='Pagination1']/li/button[.='3']",
    rules: [,
        {
            pluginName: "InvokeWhileLoop",
            argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
            onAttribute: "class",
            onElement: "//ul[@id='Pagination2']/li/button[.='3']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='3']",
    "rules": [,
        {
            "pluginName": "InvokeWhileLoop",
            "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
            "onAttribute": "class",
            "onElement": "//ul[@id='Pagination2']/li/button[.='3']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='3']",
    "rules": [,
        {
            "pluginName": "InvokeWhileLoop",
            "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
            "onAttribute": "class",
            "onElement": "//ul[@id='Pagination2']/li/button[.='3']",
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
### Example No.3

Repetitively click the `Next` button until a specific condition is met or a timeout period is reached.  

**Condition Evaluation:**  
The condition to be evaluated is specified within the `InvokeWhileLoop` plugin configuration. It checks whether the `class` attribute of a button element with the text content `6` within an unordered list (`ul`) with id `Pagination1` contains the word `foo`. 
This condition is evaluated repeatedly until it is satisfied or a timeout period of **5000 milliseconds** (5 seconds) is reached.

**Target Element:**  
The condition is applied to a button element identified by the XPath expression: `//ul[@id='Pagination1']/li/button[.='6']`.
This XPath expression targets a button with the text content `6` within the context of an unordered list (`ul`) with the id `Pagination1`.

**Plugin Usage:**  
The `InvokeWhileLoop` plugin is invoked to handle the repetitive clicking action until the condition is met or the timeout period is reached. 
This plugin facilitates dynamic iteration over actions based on specified conditions, ensuring efficient script execution.

**Action Rule:**  
Within the loop managed by `InvokeWhileLoop`, there's a rule defined to click the `Next` button (`#NextBtn1`) when the condition is met. 
This click action is performed repeatedly until the condition is satisfied or the timeout period is reached.

**Summary:**  
In essence, this example demonstrates an automation scenario where the script continuously clicks the `Next` button until the class attribute of a specific button element contains the word `foo`, or until a timeout period of **5000 milliseconds** is reached. 
The `InvokeWhileLoop` plugin orchestrates this repetitive clicking behavior, providing a flexible mechanism for dynamically handling conditions within automation workflows, with a specified timeout to ensure efficient script execution.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:5000}}",
    OnAttribute = "class",
    OnElement = "//ul[@id='Pagination1']/li/button[.='6']",
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
    .setPluginName("InvokeWhileLoop")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:5000}}")
    .setOnAttribute("class")
    .setOnElement("//ul[@id='Pagination1']/li/button[.='6']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#NextBtn1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeWhileLoop",
    argument: "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:5000}}",
    onAttribute: "class",
    onElement: "//ul[@id='Pagination1']/li/button[.='6']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:5000}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
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
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:5000}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
    "rules": [
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
| **Value Type**    | Expression        |

Defines a condition or criteria that guides the behavior of a plugin during execution.

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

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Define a sequence of actions or instructions to be executed within a loop or under specific conditions.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

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
