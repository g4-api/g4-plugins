# Invoke For Each Loop (InvokeForEachLoop)

[Table of Content](../Home.md)  

~36 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Finds all elements matching your locator and runs a set of actions on each one. To operate on the entire collection, set onElement to "." and omit the locator. You can also specify a different locator to decide where actions take place. It supports nested loops for multi-level workflows, making it easier to automate repetitive tasks in RPA and automated testing.

### Key Features and Functionality

| Feature                     | Description                                                         |
|-----------------------------|---------------------------------------------------------------------|
| Element Iteration           | Finds all elements matching the locator and loops through each one. |
| Sequential Execution        | Runs actions in order on each element for a clear workflow.         |
| Alternative Locator Support | Lets you specify a different locator for where actions run.         |
| Nested Loop Capability      | Allows loops inside loops for multi-level workflows.                |

### Usages in RPA

| Use Case            | Description                                                                       |
|---------------------|-----------------------------------------------------------------------------------|
| Data Processing     | Process each item in a list by running data entry, validation, or transformation. |
| Batch Operations    | Perform a series of tasks on groups of files, records, or transactions in order.  |
| Dynamic Interaction | Work with UI items created at runtime by clicking, typing, or checking content.   |

### Usages in Automation Testing

| Use Case               | Description                                                                 |
|------------------------|-----------------------------------------------------------------------------|
| Element Verification   | Check each UI element to confirm its state or value matches expectations.   |
| Data-Driven Testing    | Run tests across different data sets by looping through inputs and actions. |
| UI Interaction Testing | Simulate user steps like clicks or form entries on each element.            |

## Examples

### Example No.1

### Click Each Pagination Button Using XPath

Iterates over each button element matching the XPath selector `//ul[@id='Pagination1']/li/button` and performs a Click action on each.
The inner rule uses `.` to refer to the current element in the loop context.
If no buttons are found, an exception is added and the loop is skipped.
If a Click action fails on any element, an exception is recorded and execution continues to the next element.
The overall process does not stop unless explicitly configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//ul[@id='Pagination1']/li/button",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            OnElement = "."
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//ul[@id='Pagination1']/li/button")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement(".");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//ul[@id='Pagination1']/li/button",
    rules: [
        {
            pluginName: "Click",
            onElement: "."
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@id='Pagination1']/li/button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "."
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@id='Pagination1']/li/button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "."
        }
    ]
}
```
### Example No.2

### Click Each Pagination Button Using CSS Selector

Iterates over each button element matching the CSS selector `#Pagination1 > li > button` and performs a Click action on each.
The inner rule uses `.` to refer to the current element in the loop context.
If no buttons are found, an exception is added and the loop is skipped.
If a Click action fails on any element, an exception is recorded and execution continues to the next element.
The overall process does not stop unless explicitly configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    Locator = "CssSelector",
    OnElement = "#Pagination1 > li > button",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            OnElement = "."
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setLocator("CssSelector")
    .setOnElement("#Pagination1 > li > button")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement(".");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    locator: "CssSelector",
    onElement: "#Pagination1 > li > button",
    rules: [
        {
            pluginName: "Click",
            onElement: "."
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": "#Pagination1 > li > button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "."
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": "#Pagination1 > li > button",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "."
        }
    ]
}
```
### Example No.3

### Click Each Pagination Button Using XPath and Relative XPath

Iterates over each `<li>` element matching the XPath selector `//ul[@class='pagination']/li` and performs a Click action on its child button element selected via relative XPath `./button`.
The inner rule uses the XPath `./button` to reference the button within the current list item.
If no elements are found, an exception is logged and the loop is skipped.
If a Click action within any iteration throws an exception, it is recorded and the loop continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//ul[@class='pagination']/li",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            OnElement = "./button"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//ul[@class='pagination']/li")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement("./button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//ul[@class='pagination']/li",
    rules: [
        {
            pluginName: "Click",
            onElement: "./button"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']/li",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "./button"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']/li",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "./button"
        }
    ]
}
```
### Example No.4

### Click Each Pagination Button Using XPath and CSS Selector

Iterates over each `<li>` element matching the XPath selector `//ul[@class='pagination']/li` and performs a Click action on its child button element selected via CSS selector `button`.
The inner rule uses the CSS selector `button` to reference the button within the current list item.
If no elements are found, an exception is logged and the loop is skipped.
If a Click action within any iteration throws an exception, it is recorded and the loop continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//ul[@class='pagination']/li",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "button"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//ul[@class='pagination']/li")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//ul[@class='pagination']/li",
    rules: [
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "button"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']/li",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "button"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']/li",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "button"
        }
    ]
}
```
### Example No.5

### Click Each Pagination Button Using CSS Selector and Relative XPath

Iterates over each `<li>` element matching the CSS selector `.pagination > li` and performs a Click action on its child button element selected via relative XPath `./button`.
The inner rule uses the XPath `./button` to reference the button within the current list item.
If no elements are found, an exception is logged and the loop is skipped.
If a Click action within any iteration throws an exception, it is recorded and the loop continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    Locator = "CssSelector",
    OnElement = ".pagination > li",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            OnElement = "./button"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setLocator("CssSelector")
    .setOnElement(".pagination > li")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setOnElement("./button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    locator: "CssSelector",
    onElement: ".pagination > li",
    rules: [
        {
            pluginName: "Click",
            onElement: "./button"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination > li",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "./button"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination > li",
    "rules": [
        {
            "pluginName": "Click",
            "onElement": "./button"
        }
    ]
}
```
### Example No.6

### Click Each Pagination Button Using CSS Selector

Iterates over each `<li>` element matching the CSS selector `.pagination > li` and performs a Click action on its child button element selected via CSS selector `button`.
The inner rule uses the CSS selector `button` to reference the button within the current list item.
If no elements are found, an exception is logged and the loop is skipped.
If a Click action within any iteration throws an exception, it is recorded and the loop continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    Locator = "CssSelector",
    OnElement = ".pagination > li",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "Click",
            Locator = "CssSelector",
            OnElement = "button"
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setLocator("CssSelector")
    .setOnElement(".pagination > li")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("button");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    locator: "CssSelector",
    onElement: ".pagination > li",
    rules: [
        {
            pluginName: "Click",
            locator: "CssSelector",
            onElement: "button"
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination > li",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "button"
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination > li",
    "rules": [
        {
            "pluginName": "Click",
            "locator": "CssSelector",
            "onElement": "button"
        }
    ]
}
```
### Example No.7

### Nested InvokeForEachLoop With XPath Selectors

First locates the `<ul>` element matching the XPath selector `//ul[@class='pagination']`, then within each such `<ul>`, iterates over each child `<li>/button` via `./li/button` and performs a Click action.
The inner loop uses `./li/button` to reference the buttons relative to the current `<ul>` element.
If no outer elements are found, an exception is logged and the outer loop is skipped.
If no inner elements are found, an exception is logged and the inner loop is skipped.
If any Click action throws an exception, it is recorded and execution continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//ul[@class='pagination']",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "InvokeForEachLoop",
            OnElement = "./li/button",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "Click"
                }
            }
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//ul[@class='pagination']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("InvokeForEachLoop")
            .setOnElement("./li/button")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("Click");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//ul[@class='pagination']",
    rules: [
        {
            pluginName: "InvokeForEachLoop",
            onElement: "./li/button",
            rules: [
                {
                    pluginName: "Click"
                }
            ]
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "./li/button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "./li/button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```
### Example No.8

### Nested InvokeForEachLoop With XPath and CSS Selectors

First locates the `<ul>` element matching the XPath selector `//ul[@class='pagination']`, then within each such `<ul>`, iterates over each child `li > button` via CSS selector and performs a Click action.
The inner loop uses the CSS selector `li > button` to reference the button within the current list item.
If no outer elements are found, an exception is logged and the outer loop is skipped.
If no inner elements are found, an exception is logged and the inner loop is skipped.
If any Click action throws an exception, it is recorded and execution continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//ul[@class='pagination']",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "InvokeForEachLoop",
            Locator = "CssSelector",
            OnElement = "li > button",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "Click"
                }
            }
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//ul[@class='pagination']")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("InvokeForEachLoop")
            .setLocator("CssSelector")
            .setOnElement("li > button")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("Click");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//ul[@class='pagination']",
    rules: [
        {
            pluginName: "InvokeForEachLoop",
            locator: "CssSelector",
            onElement: "li > button",
            rules: [
                {
                    pluginName: "Click"
                }
            ]
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "locator": "CssSelector",
            "onElement": "li > button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "onElement": "//ul[@class='pagination']",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "locator": "CssSelector",
            "onElement": "li > button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```
### Example No.9

### Nested InvokeForEachLoop With CSS Selector and Relative XPath

First locates the container matching the CSS selector `.pagination`, then within each container, iterates over child buttons via relative XPath `./li/button` and performs a Click action.
The inner loop uses `./li/button` to reference the buttons relative to the current container.
If no outer elements are found, an exception is logged and the outer loop is skipped.
If no inner elements are found, an exception is logged and the inner loop is skipped.
If any Click action throws an exception, it is recorded and execution continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    Locator = "CssSelector",
    OnElement = ".pagination",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "InvokeForEachLoop",
            OnElement = "./li/button",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "Click"
                }
            }
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setLocator("CssSelector")
    .setOnElement(".pagination")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("InvokeForEachLoop")
            .setOnElement("./li/button")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("Click");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    locator: "CssSelector",
    onElement: ".pagination",
    rules: [
        {
            pluginName: "InvokeForEachLoop",
            onElement: "./li/button",
            rules: [
                {
                    pluginName: "Click"
                }
            ]
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "./li/button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "./li/button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```
### Example No.10

### Nested InvokeForEachLoop With CSS Selectors

First locates the container matching the CSS selector `.pagination`, then within each container, iterates over child buttons via CSS selector `li > button` and performs a Click action.
The inner loop uses the CSS selector `li > button` scoped to the current container.
If no outer elements are found, an exception is logged and the outer loop is skipped.
If no inner elements are found, an exception is logged and the inner loop is skipped.
If any Click action throws an exception, it is recorded and execution continues.
The process does not stop unless configured to stop on error.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    Locator = "CssSelector",
    OnElement = ".pagination",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "InvokeForEachLoop",
            Locator = "CssSelector",
            OnElement = "li > button",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "Click"
                }
            }
        }
    }
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeForEachLoop")
    .setLocator("CssSelector")
    .setOnElement(".pagination")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("InvokeForEachLoop")
            .setLocator("CssSelector")
            .setOnElement("li > button")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("Click");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    locator: "CssSelector",
    onElement: ".pagination",
    rules: [
        {
            pluginName: "InvokeForEachLoop",
            locator: "CssSelector",
            onElement: "li > button",
            rules: [
                {
                    pluginName: "Click"
                }
            ]
        }
    ]
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "locator": "CssSelector",
            "onElement": "li > button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeForEachLoop",
    "locator": "CssSelector",
    "onElement": ".pagination",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "locator": "CssSelector",
            "onElement": "li > button",
            "rules": [
                {
                    "pluginName": "Click"
                }
            ]
        }
    ]
}
```

## Properties

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Chooses the method to find items in the user interface.
Common options include Xpath, CSS, link text, and others.
Default is Xpath unless another method is chosen.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which element to use in the assertion.
It tells the system where to find that element in the user interface.
The assertion then runs on that element.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

List of steps to run on each item.
Each step applies to the current item or uses another method to find it if needed.
The process follows these steps for every item.

## Scope

* Any