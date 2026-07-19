# Invoke While Loop (InvokeWhileLoop)

[Table of Content](../Home.md)  

~24 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs actions repeatedly while a specified condition remains true and stops when the condition becomes false. It adapts to changing situations during execution and stops automatically if it takes too long. It also records data and performance details for each iteration.

### Key Features and Functionality

| Feature                      | Description                                                         |
|------------------------------|---------------------------------------------------------------------|
| Dynamic Iteration            | Runs steps in a loop that adapts to changing conditions at runtime. |
| Conditional Execution        | Continues looping while your specified condition remains true.      |
| Timeout Handling             | Stops the loop automatically if it exceeds a set time limit.        |
| Execution Insights           | Records data and performance details during each iteration.         |

### Usages in RPA

| Use Case                   | Description                                                     |
|----------------------------|-----------------------------------------------------------------|
| Data Validation            | Checks data repeatedly until it meets your criteria.            |
| Dynamic Process Automation | Automatically repeats tasks based on live conditions.           |
| Conditional Flow Control   | Lets scripts change course by checking conditions during a run. |

### Usages in Automation Testing

| Use Case                   | Description                                                    |
|----------------------------|----------------------------------------------------------------|
| Dynamic Testing            | Keeps testing until the application reaches the desired state. |
| Repetitive Task Automation | Repeats test steps until a condition is satisfied.             |
| Conditional Flow Testing   | Allows tests to adapt on the fly based on changing conditions. |

## Examples

### Example No.1

### Click Next While Not Active Using CSS Selector

Repeatedly checks the `class` attribute of the element matching XPath `//ul[@id='Pagination1']/li/button[.='6']`, and while it does not match the regex `(?i)active`, performs a Click action on the element matching CSS selector `#NextBtn1`.
A regular expression `(?i)active` is applied to the `class` attribute to check for a case‑insensitive match.
The loop continues until the condition no longer holds or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
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
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}")
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
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
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
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
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
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
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

### Click Next While Not Active Using XPath

Repeatedly checks the `class` attribute of the element matching XPath `//ul[@id='Pagination1']/li/button[.='6']`, and while it does not match the regex `(?i)active`, performs a Click action on the element matching XPath `//button[@id='NextBtn1']`.
A regular expression `(?i)active` is applied to the `class` attribute to check for a case‑insensitive match.
The loop continues until the condition no longer holds or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    OnAttribute = "class",
    OnElement = "//ul[@id='Pagination1']/li/button[.='6']",
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

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeWhileLoop")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}")
    .setOnAttribute("class")
    .setOnElement("//ul[@id='Pagination1']/li/button[.='6']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement("//button[@id='NextBtn1']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeWhileLoop",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    onAttribute: "class",
    onElement: "//ul[@id='Pagination1']/li/button[.='6']",
    rules: [
        {
            pluginName: "Click",
            onElement: "//button[@id='NextBtn1']"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "//ul[@id='Pagination1']/li/button[.='6']",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```
### Example No.3

### Click Next While Not Active Using CSS Selector nth-child

Repeatedly checks the `class` attribute of the element matching CSS selector `#Pagination1 > li:nth-child(6) > button`, and while it does not match the regex `(?i)active`, performs a Click action on the element matching CSS selector `#NextBtn1`.
A regular expression `(?i)active` is applied to the `class` attribute to check for a case‑insensitive match.
The loop continues until the condition no longer holds or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    OnAttribute = "class",
    OnElement = "#Pagination1 > li:nth-child(6) > button",
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
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}")
    .setOnAttribute("class")
    .setOnElement("#Pagination1 > li:nth-child(6) > button")
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
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    onAttribute: "class",
    onElement: "#Pagination1 > li:nth-child(6) > button",
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
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "#Pagination1 > li:nth-child(6) > button",
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
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "#Pagination1 > li:nth-child(6) > button",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "#NextBtn1"
        }
    ]
}
```
### Example No.4

### Click Next While Not Active Using CSS Selector with XPath Click

Repeatedly checks the `class` attribute of the element matching CSS selector `#Pagination1 > li:nth-child(6) > button`, and while it does not match the regex `(?i)active`, performs a Click action on the element matching XPath `//button[@id='NextBtn1']`.
A regular expression `(?i)active` is applied to the `class` attribute to check for a case‑insensitive match.
The loop continues until the condition no longer holds or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeWhileLoop",
    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    OnAttribute = "class",
    OnElement = "#Pagination1 > li:nth-child(6) > button",
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

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeWhileLoop")
    .setArgument("{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}")
    .setOnAttribute("class")
    .setOnElement("#Pagination1 > li:nth-child(6) > button")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement("//button[@id='NextBtn1']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeWhileLoop",
    argument: "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    onAttribute: "class",
    onElement: "#Pagination1 > li:nth-child(6) > button",
    rules: [
        {
            pluginName: "Click",
            onElement: "//button[@id='NextBtn1']"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "#Pagination1 > li:nth-child(6) > button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeWhileLoop",
    "argument": "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
    "onAttribute": "class",
    "onElement": "#Pagination1 > li:nth-child(6) > button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "//button[@id='NextBtn1']"
        }
    ]
}
```
### Example No.5

### Nested InvokeWhileLoop for Two-Level Active-Class Validation

First checks the `class` attribute of the element matching XPath `//ul[@id='Pagination1']/li/button[.='3']`, and while it matches the regex `(?i)active`, it enters an inner loop that checks the `class` attribute of elements matching XPath `//ul[@id='Pagination2']/li/button[.='3']` and clicks `#NextBtn2` on each inner iteration.
After the inner loop completes for each outer iteration, it clicks `#FirstBtn2` and then `#NextBtn1`.
A regular expression `(?i)active` is applied to the `class` attribute in both loops to check for a case‑insensitive match.
The loops continue until their conditions no longer hold or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

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
### Example No.6

### InvokeWhileLoop with Timeout for Active-Class Check

Repeatedly checks the `class` attribute of the element matching XPath `//ul[@id='Pagination1']/li/button[.='6']`, and while it matches the regex `(?i)foo`, performs a Click action on the element matching CSS selector `#NextBtn1`.
A regular expression `(?i)foo` is applied to the `class` attribute to check for a case‑insensitive match with a timeout of 5000 milliseconds per iteration.
The loop continues until the condition no longer holds or if configured to stop on error.
All conditions supported by Assert plugins (plugins with `Assert` as their plugin type) can be used here as well to control the loop.

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

Specifies the exact expression to use when asserting a result.
It tells the system what value or pattern to evaluate.
This expression guides whether the assertion is true or false.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines how to locate the element on the screen before running the assertion.
Choices include Xpath, CSS, or ID.
Xpath is used by default.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which part of the element to assert.
Examples include the element's text, link address, or stored value.
The assertion focuses on only that part.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which element to use in the assertion.
It identifies where that element is located in the page or app.
The assertion then runs on that element.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Applies a pattern to element values to test or extract specific parts.
Use it to focus on a substring before the assertion runs.
This makes checks easier by narrowing down to the exact text you need.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Lists the actions the system runs while the condition is true.
Actions run in order as long as the condition stays true.
When the condition becomes false, the loop stops.

## Parameters

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Assertion         |

Tells the system which type of assertion to run.
It updates itself when new assertion options become available.
No manual edits are needed to keep it current.
It keeps checks up to date with the latest options.

### Expected (Expected)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the value you expect the system to assert against.
The system compares this value to the actual result.
Matching values make the assertion return true.
Non-matching values make the assertion return false.

### Operator (Operator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Operator          |

Chooses which comparison to use in an assertion.
It gathers all available options automatically.
Common options include Lower, Equal, and NotEqual.
No manual updates are needed to keep the list current.

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Controls how long the system waits for an assertion to be false before stopping the loop.
Once time runs out, the system gracefully breaks the loop.
It stops the system from hanging if the condition never goes false.

## Scope

* Any