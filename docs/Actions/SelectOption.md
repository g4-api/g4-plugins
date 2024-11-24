# Select Option (SelectOption)

[Table of Content](../Home.md)  

~18 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SelectOption` plugin serves the purpose of automating the selection of options within `<select>` elements on web pages. 
Its primary goal is to streamline and automate the process of interacting with dropdown menus, enhancing the efficiency and accuracy of web-based tasks in RPA and automation testing scenarios.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                                                                                                                               |
|----------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element Validation         | The plugin validates that the targeted element is indeed a `<select>` element before attempting the selection operation, ensuring that the automation process is applied only to appropriate elements.                                                    |
| Multiple Selection Methods | It provides flexibility by offering various methods to select options, including by index, value, partial text, or exact text match. This versatility accommodates different use cases and scenarios encountered in RPA and automation testing workflows. |
| Error Handling             | The plugin incorporates robust error handling mechanisms to capture and handle exceptions that may arise during the selection process, enhancing the reliability and resilience of automation workflows.                                                  |

### Usages in RPA

| Usage            | Description                                                                                                                                                                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Form Submission  | In RPA processes involving form submissions, the `SelectOption` plugin can automate the selection of dropdown menu options, enabling seamless completion of form fields with minimal manual intervention.                                           |
| Data Entry       | When dealing with web applications that utilize dropdown menus for data entry, the plugin automates the selection of predefined options, accelerating data input tasks and reducing processing time.                                                |
| User Interaction | RPA bots can use the `SelectOption` plugin to interact with web interfaces in a manner similar to human users, facilitating the execution of complex workflows that involve selecting options from dropdown menus as part of user-driven processes. |

### Usages in Automation Testing

| Usage                  | Description                                                                                                                                                                                                                                                              |
|------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| User Interface Testing | In automated UI testing scenarios, the `SelectOption` plugin enables testers to validate the behavior of dropdown menus by selecting options based on different criteria such as index, value, or text match.                                                            |
| Form Field Validation  | Automation scripts can utilize the plugin to validate the functionality of form fields that rely on dropdown menus for user input, ensuring that the correct options are selected and processed accurately.                                                              |
| End-to-End Testing     | When conducting end-to-end testing of web applications, the plugin contributes to comprehensive test coverage by automating the selection of dropdown menu options as part of user interaction scenarios, verifying the application's behavior under various conditions. |

## Examples

### Example No.1

Select the option at index 1 (i.e., the second option) from the dropdown menu identified by the CSS selector `#SelectElement`. 
This configuration is useful for automating tasks where the selection of options from dropdown menus needs to be performed based on their positions within the menu.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "1",
    Locator = "CssSelector",
    OnAttribute = "Index",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("1")
    .setLocator("CssSelector")
    .setOnAttribute("Index")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "1",
    locator: "CssSelector",
    onAttribute: "Index",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "1",
    "locator": "CssSelector",
    "onAttribute": "Index",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "1",
    "locator": "CssSelector",
    "onAttribute": "Index",
    "onElement": "#SelectElement"
}
```
### Example No.2

Select the option with a value attribute of `option2` from the dropdown menu identified by the CSS selector `#SelectElement`. 
This configuration is useful when the selection needs to be made based on the values associated with the options in the dropdown menu.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "option2",
    Locator = "CssSelector",
    OnAttribute = "Value",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("option2")
    .setLocator("CssSelector")
    .setOnAttribute("Value")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "option2",
    locator: "CssSelector",
    onAttribute: "Value",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "option2",
    "locator": "CssSelector",
    "onAttribute": "Value",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "option2",
    "locator": "CssSelector",
    "onAttribute": "Value",
    "onElement": "#SelectElement"
}
```
### Example No.3

Select the option from the dropdown menu identified by the CSS selector `#SelectElement`, where the option's text contains the partial text `2`. 
This configuration is useful when the option's text is dynamic or when only a portion of the text is known beforehand.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "2",
    Locator = "CssSelector",
    OnAttribute = "PartialText",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("2")
    .setLocator("CssSelector")
    .setOnAttribute("PartialText")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "2",
    locator: "CssSelector",
    onAttribute: "PartialText",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "2",
    "locator": "CssSelector",
    "onAttribute": "PartialText",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "2",
    "locator": "CssSelector",
    "onAttribute": "PartialText",
    "onElement": "#SelectElement"
}
```
### Example No.4

Select the option from the dropdown menu identified by the CSS selector `#SelectElement`, where the option's text matches exactly `Option 2`. 
This configuration is useful when the exact text of the option to be selected is known in advance.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SelectOption",
    Argument = "Option 2",
    Locator = "CssSelector",
    OnElement = "#SelectElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SelectOption")
    .setArgument("Option 2")
    .setLocator("CssSelector")
    .setOnElement("#SelectElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SelectOption",
    argument: "Option 2",
    locator: "CssSelector",
    onElement: "#SelectElement"
};
```

_**JSON**_

```js
{
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "locator": "CssSelector",
    "onElement": "#SelectElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SelectOption",
    "argument": "Option 2",
    "locator": "CssSelector",
    "onElement": "#SelectElement"
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

The `Argument` property specifies the value that the plugin will use to select an option from a dropdown menu. 
Depending on the specified `OnAttribute` property, the `Argument` can represent different criteria for selecting an option.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of locator used to identify the target dropdown menu element on the web page.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute of the options within the dropdown menu that will be used as the basis for selecting an option. 
It determines how the plugin should interpret the `Argument` property when selecting an option.

#### Values

##### Index

The plugin will interpret the `Argument` property as the index of the option to be selected within the dropdown menu. 
For example, an `Argument` of `2` would select the third option in the menu (assuming zero-based indexing).
##### Partial Text

The plugin will interpret the `Argument` property as the partial text that the option's text content should contain. 
It will select the option whose text contains the specified partial text.
##### Value

The plugin will interpret the `Argument` property as the value attribute of the option to be selected. 
It will search for an option whose value attribute matches the specified argument.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target dropdown menu element on the web page where the selection action will be performed. 
It indicates the HTML element that contains the options within the dropdown menu.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-click](https://www.w3.org/TR/webdriver/#element-click)
