# Invoke Double Click (InvokeDoubleClick)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeDoubleClick` plugin is to perform double-click actions on specified web elements.

### Key Features and Functionality

| Feature             | Description                                                     |
|---------------------|-----------------------------------------------------------------|
| Double Click Action | Performs a double-click action on the specified web element.    |
| Element Handling    | Handles web elements based on provided locators and attributes. |

### Usages in RPA

| Usage               | Description                                                                                             |
|---------------------|---------------------------------------------------------------------------------------------------------|
| Element Interaction | Interact with web elements by performing double-click actions as part of automated workflows.           |
| Selection Actions   | Automate actions that require double-clicking on elements to trigger selections or open detailed views. |
| File Management     | Double-click on file icons to open or execute files within a file management system.                    |
| Form Interactions   | Double-click on form fields to activate editing modes or open additional input options.                 |

### Usages in Automation Testing

| Usage                       | Description                                                                                                |
|-----------------------------|------------------------------------------------------------------------------------------------------------|
| UI Testing                  | Perform double-click actions on web elements to test user interface interactions.                          |
| Complex Interaction Testing | Test scenarios where actions depend on double-clicking elements to trigger further interactions.           |
| Regression Testing          | Ensure that double-click functionalities work as expected after changes or updates to the web application. |
| Menu Navigation Testing     | Double-click on menu items to test navigation within an application.                                       |
| Drag and Drop Testing       | Initiate drag and drop actions by double-clicking on draggable elements, ensuring they move as expected.   |
| Content Selection Testing   | Test text or content selection functionalities that are triggered by double-clicking on the content.       |

## Examples

### Example No.1

Perform a `DoubleClick` action on a web element with the `ID` attribute `DoubleClickButton`, using a CSS selector to locate the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDoubleClick",
    Locator = "CssSelector",
    OnElement = "#DoubleClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDoubleClick")
    .setLocator("CssSelector")
    .setOnElement("#DoubleClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDoubleClick",
    locator: "CssSelector",
    onElement: "#DoubleClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDoubleClick",
    "locator": "CssSelector",
    "onElement": "#DoubleClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDoubleClick",
    "locator": "CssSelector",
    "onElement": "#DoubleClickButton"
}
```
### Example No.2

Perform a `DoubleClick` action at the last known mouse location. 
While this approach might be suitable for certain scenarios, it's generally less reliable and less commonly used in automation testing compared to locating and interacting with elements using locators.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDoubleClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDoubleClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDoubleClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDoubleClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDoubleClick"
}
```
### Example No.3

Perform a `DoubleClick` action on a web element with the ID attribute `DoubleClickArea`, using an ID locator to find the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeDoubleClick",
    Locator = "Id",
    OnElement = "DoubleClickArea"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeDoubleClick")
    .setLocator("Id")
    .setOnElement("DoubleClickArea");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeDoubleClick",
    locator: "Id",
    onElement: "DoubleClickArea"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeDoubleClick",
    "locator": "Id",
    "onElement": "DoubleClickArea"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeDoubleClick",
    "locator": "Id",
    "onElement": "DoubleClickArea"
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

Specifies the locator strategy used to find the target element for the double-click action. The default is `Xpath`.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target element for the double-click action, located using the specified locator strategy.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)
