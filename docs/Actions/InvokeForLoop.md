# Invoke For Loop (InvokeForLoop)

[Table of Content](../Home.md)

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a set of actions a specified number of times in your automation scripts. It makes repeating tasks simple by letting you define exactly how many loops to perform. This saves time and effort when you need predictable, repeated steps. It works equally well in RPA workflows and automated tests.

### Key Features and Functionality

| Feature                 | Description                                                             |
| --- | --- |
| Controlled Iteration    | Runs actions for a fixed number of loops as defined by the user.        |
| Sequential Execution    | Executes each step in order within the loop for consistent outcomes.    |
| Parameterized Iteration | Adjusts loop variables dynamically based on input values or conditions. |

### Usages in RPA

| Use Case                | Description                                                           |
| --- | --- |
| Data Processing         | Iterate over records or items to enter, validate, or transform data.  |
| Batch Processing        | Perform a series of tasks on a predefined data set within a workflow. |
| Parameterized Iteration | Change loop values at runtime to handle varying input automatically.  |

### Usages in Automation Testing

| Use Case            | Description                                                                          |
| --- | --- |
| Test Case Iteration | Run test steps repeatedly to cover multiple scenarios.                               |
| Data-Driven Testing | Loop through different data sets to verify application behavior under varied inputs. |
| Load Testing        | Simulate repeated user actions to measure system performance under load.             |

## Examples

### Example No.1

### Click Next Button 5 Times Using CSS Selector

Runs a loop 5 times and performs a Click action on the element matching the CSS selector `#NextBtn1` each iteration.
The inner rule uses `#NextBtn1` scoped by CssSelector to locate the target button.
If no element is found, an exception is logged and the iteration continues. If a Click action throws an exception, it is recorded and the loop proceeds. The process does not stop unless configured to stop on error.

**CSharp:**

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

**Java:**

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

**Javascript:**

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

**JSON:**

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

**Python:**

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

### Click Next Button 5 Times Using XPath

Runs a loop 5 times and performs a Click action on the element matching the XPath selector `//button[@id='NextBtn1']` each iteration.
The inner rule uses the XPath `//button[@id='NextBtn1']` to locate the target button.
If no element is found, an exception is logged and the iteration continues. If a Click action throws an exception, it is recorded and the loop proceeds. The process does not stop unless configured to stop on error.

**CSharp:**

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
            OnElement = "//button[@id='NextBtn1']"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForLoop")
    .setArgument("5")
    .setActions()
        new ActionRuleModel()
            .setPluginName("Click")
            .setOnElement("//button[@id='NextBtn1']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeForLoop",
    argument: "5",
    rules: [
        {
            pluginName: "Click",
            onElement: "//button[@id='NextBtn1']"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```

### Example No.3

### Click Next Button 5 Times Using Id Locator

Runs a loop 5 times and performs a Click action on the element with Id `NextBtn1` each iteration.
The inner rule uses `NextBtn1` scoped by Id to locate the target button.
If no element is found, an exception is logged and the iteration continues. If a Click action throws an exception, it is recorded and the loop proceeds. The process does not stop unless configured to stop on error.

**CSharp:**

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
            Locator = "Id",
            OnElement = "NextBtn1"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForLoop")
    .setArgument("5")
    .setActions()
        new ActionRuleModel()
            .setPluginName("Click")
            .setLocator("Id")
            .setOnElement("NextBtn1");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeForLoop",
    argument: "5",
    rules: [
        {
            pluginName: "Click",
            locator: "Id",
            onElement: "NextBtn1"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "Id",
            "onElement": "NextBtn1"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeForLoop",
    "argument": "5",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "Id",
            "onElement": "NextBtn1"
        }
    ]
}
```

### Example No.4

### Nested InvokeForLoop With Mixed Actions

Runs an outer loop 2 times, then within each outer iteration runs an inner loop 2 times to Click `#NextBtn2`, followed by a Click on `//button[@Id='FirstBtn2']`, then a Click on the element with Id `NextBtn1`.
Inner loops use their own argument and selectors as specified.
If any element is missing, an exception is logged and that iteration continues. Click failures record exceptions without stopping the outer loop. The overall process only stops if configured to stop on error.

**CSharp:**

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
            OnElement = "//button[@Id='FirstBtn2']"
        }
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "Id",
            OnElement = "NextBtn1"
        }
    }
};
```

**Java:**

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
            .setOnElement("//button[@Id='FirstBtn2']"))
        new ActionRuleModel()
            .setPluginName("Click")
            .setLocator("Id")
            .setOnElement("NextBtn1");
```

**Javascript:**

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
            onElement: "//button[@Id='FirstBtn2']"
        }
        {
            pluginName: "Click",
            locator: "Id",
            onElement: "NextBtn1"
        }
    ]
};
```

**JSON:**

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
            "onElement": "//button[@Id='FirstBtn2']"
        }
        {
            "pluginName": "Click",
            "locator": "Id",
            "onElement": "NextBtn1"
        }
    ]
}
```

**Python:**

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
            "onElement": "//button[@Id='FirstBtn2']"
        }
        {
            "pluginName": "Click",
            "locator": "Id",
            "onElement": "NextBtn1"
        }
    ]
}
```

### Example No.5

### Click The Button Of A Different Row Each Iteration

Runs a loop 3 times and performs a Click action on the button of the row whose `data-index` attribute matches the index of the running iteration.
The index is published as the session parameter `InvokeForLoop:Iteration` before each iteration starts, and the inner rule reads it with `{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}`. The index is zero-based, so the loop addresses the rows `0`, `1` and `2`.
When loops are nested, the inner loop overwrites the parameter while it runs and gives the enclosing index back when it ends, so a step placed after a nested loop reads the index of its own loop. The parameter is published only while a loop runs and is removed once the outermost loop ends.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForLoop",
    Argument = "3",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            OnElement = "//tr[@data-index='{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}']//button"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForLoop")
    .setArgument("3")
    .setActions()
        new ActionRuleModel()
            .setPluginName("Click")
            .setOnElement("//tr[@data-index='{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}']//button");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeForLoop",
    argument: "3",
    rules: [
        {
            pluginName: "Click",
            onElement: "//tr[@data-index='{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}']//button"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "InvokeForLoop",
    "argument": "3",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//tr[@data-index='{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}']//button"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeForLoop",
    "argument": "3",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//tr[@data-index='{{$Get-Parameter --Name:InvokeForLoop:Iteration --Scope:Session}}']//button"
        }
    ]
}
```

## Output Parameter

### Invoke For Loop Iteration (InvokeForLoop:Iteration)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the zero-based index of the iteration the loop is currently running, published before each iteration starts.
Lets steps inside the loop address a different target, file or record on every pass without a counter of their own.
A nested loop overwrites the value while it runs and restores the enclosing index when it ends, and the parameter is removed once the outermost loop ends.
The session value is Base64-encoded, which the Get-Parameter macro decodes by default.

## Properties

### Argument (Argument)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | Yes                |
| **Multiple**       | No                 |
| **Value Type**     | Number\|Expression |

Sets how many times the loop repeats.
Each step inside the loop runs that many times.
This gives you control over repeated work.
It ensures tasks run the exact number of times you want.

### Rules (Rules)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Lists the steps to run in a loop or when conditions apply.
Each step runs in order to complete the task.

## Scope

* Any
