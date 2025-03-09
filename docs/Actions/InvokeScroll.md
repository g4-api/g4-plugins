# Invoke Scroll (InvokeScroll)

[Table of Content](../Home.md)  

~31 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeScroll` plugin is to automate scrolling actions on web pages. 
In both RPA and automation testing, interacting with web pages often involves scrolling to view hidden or off-screen elements, simulate user behavior, or verify the appearance of elements at different scroll positions. 
This plugin provides a mechanism to perform such scrolling actions programmatically as part of automated workflows or tests.

### Key Features and Functionality

| Feature       | Description                                                                                                                                   |
|---------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| Scalability   | The plugin can handle scrolling for both specific elements and entire pages, making it versatile for various automation scenarios.            |
| Customization | It allows customization of scrolling behavior by accepting arguments such as behavior type (smooth, auto, etc.), left offset, and top offset. |
| Reusable      | The plugin encapsulates scrolling logic into reusable components, reducing code duplication and enhancing maintainability.                    |
| Reliability   | By leveraging JavaScript-based scrolling, the plugin ensures reliable scrolling behavior across different web browsers and environments.      |

### Usages in RPA

| Usage                | Description                                                                                                 |
|----------------------|-------------------------------------------------------------------------------------------------------------|
| Data Extraction      | Scrolling through web pages to extract relevant data from tables, lists, or grids.                          |
| Silent Paging        | Navigating through paginated content to collect comprehensive datasets.                                     |
| Multi-Step Workflows | Automating scrolling actions as part of broader RPA processes to navigate through multi-step workflows.     |
| Forms & Data         | Completing forms or interacting with web-based applications that require scrolling beyond the initial view. |

### Usages in Automation Testing

| Usage                        | Description                                                                                                                               |
|------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| Responsive Design Testing    | Simulate scrolling actions on different screen sizes and devices, ensuring application responsiveness across various viewport dimensions. |
| Accessibility Testing        | Scroll through web pages and verify the accessibility of interactive elements for individuals with disabilities.                          |
| Automation Test Scripts      | Integrate scrolling actions into automated test scripts to interact with dynamic web elements effectively.                                |
| Infinite Scroll Handling     | Automate scrolling to test and validate the functionality of infinite scroll features during automated testing.                           |
| Visual Testing               | Scroll through web pages and capture screenshots for visual regression testing.                                                           |
| Dynamic Content Verification | Automate scrolling actions to verify the presence and behavior of dynamically loaded content during automated tests.                      |

## Examples

### Example No.1

Scroll the web page, moving the view to a position where the top offset is 10 pixels from the top of the page. 
This could be useful, for example, if you need to scroll down the page by a specific distance to reveal certain content or elements.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10}}"
}
```
### Example No.2

Scroll the web page, moving the view horizontally to a position where the left offset is 10 pixels from the left edge of the page. 
This could be useful, for instance, if you need to shift the view horizontally to focus on a particular section or element of the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Left:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Left:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Left:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Left:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Left:10}}"
}
```
### Example No.3

Scroll the web page, moving the view both vertically and horizontally to a position where the top offset is 10 pixels from the top of the page and the left offset is 10 pixels from the left edge of the page. 
This could be useful, for example, when you need to precisely position the view to focus on a specific area or element of the page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10 --Left:10}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10 --Left:10}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10 --Left:10}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10}}"
}
```
### Example No.4

Scroll the web page, moving the view both vertically and horizontally to a position where the top offset is 10 pixels from the top of the page and the left offset is 10 pixels from the left edge of the page. 
Additionally, the scrolling action will be performed smoothly with animation. 
This could be useful for creating a more visually appealing scrolling experience for users.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10 --Left:10 --Behavior:smooth}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10 --Left:10 --Behavior:smooth}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10 --Left:10 --Behavior:smooth}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10 --Behavior:smooth}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10 --Behavior:smooth}}"
}
```
### Example No.5

Scroll the content within the overflow element with the ID `TextAreaEnabled`, moving it vertically so that the content shifts down by 10 pixels from its original position. 
This could be useful for scenarios where the content within a specific element overflows, such as in a textarea, and you need to scroll it to reveal additional content or ensure visibility of specific elements within the overflow area.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10}}",
    Locator = "CssSelector",
    OnElement = "#TextAreaEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10}}")
    .setLocator("CssSelector")
    .setOnElement("#TextAreaEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10}}",
    locator: "CssSelector",
    onElement: "#TextAreaEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```
### Example No.6

Scroll the content within the overflow element with the ID `TextAreaEnabled`, moving it horizontally so that the content shifts to the right by 10 pixels from its original position. 
This could be useful for scenarios where the content within a specific element overflows horizontally, such as in a textarea, and you need to scroll it to reveal additional content or ensure visibility of specific elements within the overflow area.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Left:10}}",
    Locator = "CssSelector",
    OnElement = "#TextAreaEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Left:10}}")
    .setLocator("CssSelector")
    .setOnElement("#TextAreaEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Left:10}}",
    locator: "CssSelector",
    onElement: "#TextAreaEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Left:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Left:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```
### Example No.7

Scroll the content within the overflow element with the ID `TextAreaEnabled`, moving it both vertically and horizontally. 
The content will shift down by 10 pixels from its original position (top offset), and it will also shift to the right by 10 pixels from its original position (left offset). 
This could be useful for scenarios where the content within a specific element overflows both vertically and horizontally, such as in a textarea, and you need to scroll it to reveal additional content or ensure visibility of specific elements within the overflow area.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10 --Left:10}}",
    Locator = "CssSelector",
    OnElement = "#TextAreaEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10 --Left:10}}")
    .setLocator("CssSelector")
    .setOnElement("#TextAreaEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10 --Left:10}}",
    locator: "CssSelector",
    onElement: "#TextAreaEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```
### Example No.8

Scroll the content within the overflow element with the ID `TextAreaEnabled`, moving it both vertically and horizontally. 
The content will shift down by 10 pixels from its original position (top offset), and it will also shift to the right by 10 pixels from its original position (left offset). 
Additionally, the scrolling action will be performed smoothly, providing a gradual animation effect. 
This configuration is useful for scenarios where smooth scrolling is desired, enhancing the user experience by providing fluid navigation within the overflow content.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:10 --Left:10 --Behavior:smooth}}",
    Locator = "CssSelector",
    OnElement = "#TextAreaEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:10 --Left:10 --Behavior:smooth}}")
    .setLocator("CssSelector")
    .setOnElement("#TextAreaEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:10 --Left:10 --Behavior:smooth}}",
    locator: "CssSelector",
    onElement: "#TextAreaEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10 --Behavior:smooth}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:10 --Left:10 --Behavior:smooth}}",
    "locator": "CssSelector",
    "onElement": "#TextAreaEnabled"
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
| **Value Type**    | String|Expression |

Provides additional instructions or parameters to control the behavior of the scrolling action.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of locator used to identify the target element defined by the `OnElement` property.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target element to which the scrolling action should be applied.

## Parameters

### Behavior (Behavior)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the scrolling behavior. Possible values are `auto`, `instant`, and `smooth`.

#### Values

##### Auto

Scroll behavior is determined by the computed value of [scroll-behavior](https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior).
##### Instant

Scrolling happens instantly in a single jump.
##### Smooth

Scrolling animates smoothly.

### Left (Left)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal scrolling offset from the left edge of the overflow element or the page to which the scrolling action is applied.

### Top (Top)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical scrolling offset from the top of the overflow element or top of the page to which the scrolling action is applied.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
