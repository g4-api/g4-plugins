# Invoke Click (InvokeClick)

[Table of Content](../Home.md)  

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeClick` plugin is to perform click actions on specified web elements. It supports conditional clicks, allowing the action to be retried until a specified condition is met or a timeout occurs.

### Key Features and Functionality

| Feature             | Description                                                                                  |
|---------------------|----------------------------------------------------------------------------------------------|
| Click Action        | Performs a click action on the specified web element.                                        |
| Conditional Click   | Supports conditional clicks, where the action is retried until a specified condition is met. |
| Element Handling    | Handles web elements based on provided locators and attributes.                              |
| Timeout and Polling | Allows specification of timeout and polling intervals for conditional clicks.                |

### Usages in RPA

| Usage               | Description                                                                                                  |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| Element Interaction | Interact with web elements by performing click actions as part of automated workflows.                       |
| Conditional Actions | Automate conditional click actions, ensuring certain conditions are met before proceeding with the workflow. |
| Form Submission     | Automatically submit forms by clicking submit buttons after populating fields.                               |
| Modal Handling      | Close modal dialogs by clicking the close button or overlay.                                                 |
| Navigation          | Navigate through multi-step processes by clicking next buttons or links.                                     |

### Usages in Automation Testing

| Usage                       | Description                                                                                                                                |
|-----------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| UI Testing                  | Perform click actions on web elements to test user interface interactions.                                                                 |
| Conditional Testing         | Test scenarios where actions depend on specific conditions being met, such as waiting for alerts to close or elements to become clickable. |
| Regression Testing          | Ensure that click functionalities work as expected after changes or updates to the web application.                                        |
| Dynamic Content Testing     | Handle dynamic content by clicking on elements that appear or change based on user interactions or server responses.                       |
| Interactive Element Testing | Verify the functionality of interactive elements such as dropdowns, checkboxes, radio buttons, and sliders by performing click actions.    |

## Examples

### Example No.1

Perform a `Click` action on a web element with the `ID` attribute `ClickButton`, using a CSS selector to locate the element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```
### Example No.2

Perform a `Click` action at the last known mouse location. 
While this approach might be suitable for certain scenarios, it's generally less reliable and less commonly used in automation testing compared to locating and interacting with elements using locators.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick"
}
```
### Example No.3

Perform a `Click` action on a web element with the ID attribute `PopAlert`. 
The script is configured to click repeatedly at 1-second intervals until an alert associated with the clicked element exists, allowing a maximum of 15 seconds for the alert to appear. 
This configuration is particularly useful for scenarios where an action triggers an alert, and the automation script needs to wait for that alert to become present before proceeding further.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Polling:1.0 --Condition:AlertExists --Timeout:00:00:15}}",
    Locator = "Id",
    OnElement = "PopAlert"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Polling:1.0 --Condition:AlertExists --Timeout:00:00:15}}")
    .setLocator("Id")
    .setOnElement("PopAlert");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Polling:1.0 --Condition:AlertExists --Timeout:00:00:15}}",
    locator: "Id",
    onElement: "PopAlert"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:AlertExists --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:AlertExists --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```
### Example No.4

Perform a `Click` action on a web element with the ID attribute `PopAlert`. 
The script is configured to repetitively perform the `Click` action at 1-second intervals. 
If an alert associated with the clicked element appears after each click, the automation script will automatically dismiss the alert until it is no longer triggered by the click action. 
The script will continue this process for a maximum duration of 15 seconds. 
This configuration is particularly useful for scenarios where an action's effects are expected to trigger an alert that needs to be handled before proceeding further with the automation test.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Polling:1.0 --Condition:AlertNotExists --Timeout:00:00:15}}",
    Locator = "Id",
    OnElement = "PopAlert"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Polling:1.0 --Condition:AlertNotExists --Timeout:00:00:15}}")
    .setLocator("Id")
    .setOnElement("PopAlert");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Polling:1.0 --Condition:AlertNotExists --Timeout:00:00:15}}",
    locator: "Id",
    onElement: "PopAlert"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:AlertNotExists --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:AlertNotExists --Timeout:00:00:15}}",
    "locator": "Id",
    "onElement": "PopAlert"
}
```
### Example No.5

Perform a `Click` action on a web element identified by the CSS selector `#UntilAttribute`. 
The script is configured to repetitively perform the `Click` action at 1-second intervals until the value of the `value` attribute on the element equals `10`, or until a maximum of 15 seconds has elapsed. 
This configuration is useful for scenarios where the value of a specific attribute on an element needs to be modified by repeated clicking, and the script waits until the desired attribute value is achieved before proceeding further with the automation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeClick",
    Argument = "{{$ --Polling:1.0 --Condition:ElementAttribute --Equal:10 --Timeout:00:00:15}}",
    Locator = "CssSelector",
    OnAttribute = "value",
    OnElement = "#UntilAttribute"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeClick")
    .setArgument("{{$ --Polling:1.0 --Condition:ElementAttribute --Equal:10 --Timeout:00:00:15}}")
    .setLocator("CssSelector")
    .setOnAttribute("value")
    .setOnElement("#UntilAttribute");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeClick",
    argument: "{{$ --Polling:1.0 --Condition:ElementAttribute --Equal:10 --Timeout:00:00:15}}",
    locator: "CssSelector",
    onAttribute: "value",
    onElement: "#UntilAttribute"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:ElementAttribute --Equal:10 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#UntilAttribute"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeClick",
    "argument": "{{$ --Polling:1.0 --Condition:ElementAttribute --Equal:10 --Timeout:00:00:15}}",
    "locator": "CssSelector",
    "onAttribute": "value",
    "onElement": "#UntilAttribute"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the details for the click action, including parameters like timeout, polling interval, and condition. 
It includes a template or variable structure `{{$...}}` to allow dynamic values.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy to find the web element to be clicked. Supported locator types include `CssSelector`, `XPath`, `LinkText`, etc.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the actual element identifier using the locator strategy defined. 
For example, if the locator is `CssSelector`, this would be a CSS selector string.

## Parameters

### Timeout (Timeout)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the timeout duration in milliseconds for the click action. If not specified, the default timeout which is based on the automation 'LoadTimeout' settings, will be used.

### Polling (Polling)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | 1500              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the polling interval in milliseconds for conditional clicks. If not specified, a default polling interval will be used.

### Condition (Condition)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the condition that must be met for the click action to be considered successful. If not specified, the click action will be performed once.

#### Values

##### No Alert

Continue clicking on the specified element and dismissing the alert until it no longer appears.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#element-click](https://www.w3.org/TR/webdriver/#element-click)
