# Invoke For Each Loop (InvokeForEachLoop)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `InvokeForEachLoop` plugin is a powerful tool designed for both Robotic Process Automation (RPA) and automation testing. 
Its primary function is to locate multiple elements using a specified locator, iterate through each found element, and execute a predefined collection of actions on them. 
By default, actions are performed on the located elements, but the plugin also offers the flexibility to specify an alternative locator for action execution.

### Key Features and Functionality

| Feature                     | Description                                                                                                                                      |
|-----------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| Element-Based Iteration     | Finds all elements matching the provided locator and iterates through each one to perform actions.                                               |
| Sequential Execution        | Ensures that actions are executed in order on each element, maintaining a predictable and orderly workflow.                                      |
| Alternative Locator Support | Allows specifying a different locator for performing actions, providing flexibility to target different elements based on the iteration context. |
| Nested Loop Capability      | Supports nested `InvokeForEachLoop` instances, enabling complex automation workflows with multiple layers of iteration and action execution.     |

### Usages in RPA

| Use Case            | Description                                                                                                                                             |
|---------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| Data Processing     | Iterate over a collection of data elements, performing actions such as data entry, validation, or transformation on each item.                          |
| Batch Operations    | Execute a series of actions on each element within a batch, such as processing multiple files, records, or transactions sequentially.                   |
| Dynamic Interaction | Interact with dynamically generated UI elements by iterating through them and performing necessary actions like clicking, typing, or verifying content. |

### Usages in Automation Testing

| Use Case               | Description                                                                                                                                                 |
|------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element Verification   | Iterate through UI elements to verify properties, states, or values, ensuring each element meets the expected criteria.                                     |
| Data-Driven Testing    | Perform actions on multiple data sets by iterating through input elements, enabling comprehensive testing across various scenarios and data configurations. |
| UI Interaction Testing | Simulate user interactions on a series of UI components by iterating through them and executing actions like clicks, hovers, or form submissions.           |

## Examples

### Example No.1

Instructs the automation script to execute the `Click` action on the HTML element with the XPath `//positive` five times in sequential order.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//positive",
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
    .setPluginName("InvokeForEachLoop")
    .setOnElement("//positive")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("Click")
            .setLocator("CssSelector")
            .setOnElement("#NextBtn1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//positive",
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
    "pluginName": "InvokeForEachLoop",
    "onElement": "//positive",
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
    "pluginName": "InvokeForEachLoop",
    "onElement": "//positive",
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

This configuration demonstrates a nested `InvokeForEachLoop` within another `InvokeForEachLoop`, allowing for complex iteration scenarios.

1. **Outer ForEach Loop:**
   - Initiated by the first `InvokeForEachLoop` plugin.
   - Locates all elements matching the XPath `//positive`.

2. **Inner ForEach Loop:**
   - Nested within the outer loop, it also locates elements matching the XPath `//positive`.
   - Performs a `RegisterParameter` action on each nested element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeForEachLoop",
    OnElement = "//positive",
    Rules = new[]
    {
        new ActionRuleModel
        {
            PluginName = "InvokeForEachLoop",
            OnElement = "//positive",
            Rules = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:TestParameter --Value:Foo Bar}}"
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
    .setOnElement("//positive")
    .setActions()
        new ActionRuleModel()        
            .setPluginName("InvokeForEachLoop")
            .setOnElement("//positive")
            .setActions()
                new ActionRuleModel()                
                    .setPluginName("RegisterParameter")
                    .setArgument("{{$ --Name:TestParameter --Value:Foo Bar}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeForEachLoop",
    onElement: "//positive",
    rules: [
        {
            pluginName: "InvokeForEachLoop",
            onElement: "//positive",
            rules: [
                {
                    pluginName: "RegisterParameter",
                    argument: "{{$ --Name:TestParameter --Value:Foo Bar}}"
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
    "onElement": "//positive",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "//positive",
            "rules": [
                {
                    "pluginName": "RegisterParameter",
                    "argument": "{{$ --Name:TestParameter --Value:Foo Bar}}"
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
    "onElement": "//positive",
    "rules": [
        {
            "pluginName": "InvokeForEachLoop",
            "onElement": "//positive",
            "rules": [
                {
                    "pluginName": "RegisterParameter",
                    "argument": "{{$ --Name:TestParameter --Value:Foo Bar}}"
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

Specifies the locator strategy to find the web elements to be iterated. Supported locator types include `CssSelector`, `XPath`, `LinkText`, etc.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator used to find the elements that the loop will iterate over.
This property is mandatory and defines how the plugin identifies the collection of elements to process.

### Rules (Rules)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Defines a sequence of actions or instructions to be executed on each element found by the locator.
Each action can interact with the current element or use an alternative locator as needed.

## Scope

* Any