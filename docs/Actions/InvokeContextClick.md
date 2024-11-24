# Invoke Context Click (InvokeContextClick)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeContextClick` plugin is to perform context-click (right-click) actions on specified web elements.

### Key Features and Functionality

| Feature              | Description                                                     |
|----------------------|-----------------------------------------------------------------|
| Context Click Action | Performs a context-click action on the specified web element.   |
| Element Handling     | Handles web elements based on provided locators and attributes. |

### Usages in RPA

| Usage               | Description                                                                                    |
|---------------------|------------------------------------------------------------------------------------------------|
| Element Interaction | Interact with web elements by performing context-click actions as part of automated workflows. |
| Context Menus       | Automate the opening of context menus by right-clicking on specific elements.                  |

### Usages in Automation Testing

| Usage                | Description                                                                                                 |
|----------------------|-------------------------------------------------------------------------------------------------------------|
| UI Testing           | Perform context-click actions on web elements to test user interface interactions.                          |
| Context Menu Testing | Test scenarios where actions depend on context menus being triggered by a right-click.                      |
| Regression Testing   | Ensure that context-click functionalities work as expected after changes or updates to the web application. |

## Examples

### Example No.1

Perform a `ContextClick` action on a web element with the `ID` attribute `RightClickButton`, using a CSS selector to locate the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeContextClick",
    Locator = "CssSelector",
    OnElement = "#RightClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeContextClick")
    .setLocator("CssSelector")
    .setOnElement("#RightClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeContextClick",
    locator: "CssSelector",
    onElement: "#RightClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeContextClick",
    "locator": "CssSelector",
    "onElement": "#RightClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeContextClick",
    "locator": "CssSelector",
    "onElement": "#RightClickButton"
}
```
### Example No.2

Perform a `ContextClick` action at the last known mouse location. 
While this approach might be suitable for certain scenarios, it's generally less reliable and less commonly used in automation testing compared to locating and interacting with elements using locators.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeContextClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeContextClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeContextClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeContextClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeContextClick"
}
```
### Example No.3

Perform a `ContextClick` action on a web element with the ID attribute `RightClickArea`. 
This configuration is useful for scenarios where a context menu needs to be triggered by right-clicking on a specific area of the web page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeContextClick",
    Locator = "Id",
    OnElement = "RightClickArea"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeContextClick")
    .setLocator("Id")
    .setOnElement("RightClickArea");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeContextClick",
    locator: "Id",
    onElement: "RightClickArea"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeContextClick",
    "locator": "Id",
    "onElement": "RightClickArea"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeContextClick",
    "locator": "Id",
    "onElement": "RightClickArea"
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

Specifies the locator strategy to find the web element to be context-clicked. Supported locator types include `CssSelector`, `XPath`, `LinkText`, etc.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the actual element identifier using the locator strategy defined. For example, if the locator is `CssSelector`, this would be a CSS selector string.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
