# Invoke Scroll (InvokeScroll)

[Table of Content](../Home.md)  

~19 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Scrolls a web page or a specific overflow element to a given pixel position using JavaScript.
When an element is specified via OnElement, the action targets that element with `element.scroll()`; otherwise it scrolls the entire page via `window.scroll()`.
This makes it the primary way to programmatically position the viewport or scroll within overflow containers in automation workflows and test scripts.

### Key Features and Functionality

| Feature           | Description                                                                                                           |
|-------------------|-----------------------------------------------------------------------------------------------------------------------|
| Page Scroll       | Scrolls the entire page to the specified Left and Top pixel offsets using `window.scroll()`.                          |
| Element Scroll    | Scrolls within a specific overflow element using `element.scroll()`, targeting it via any supported locator strategy. |
| Behavior Control  | Accepts `auto`, `instant`, and `smooth` scroll behaviors to control animation.                                        |
| Axis Independence | Left and Top offsets are independently optional — supply one or both depending on the scroll direction required.      |
| No-Op Guard       | When neither Left nor Top is provided the action takes no effect, preventing unintended scroll resets.                |

### Usages in RPA

| Use Case             | Description                                                                                                    |
|----------------------|----------------------------------------------------------------------------------------------------------------|
| Data Extraction      | Scroll through paginated tables or lazy-loaded lists to expose additional rows before data collection.         |
| Form Navigation      | Scroll to a specific section of a long form to bring off-screen fields into view before interaction.           |
| Overflow Navigation  | Scroll within a fixed-height panel, textarea, or scrollable container to reach content below the visible fold. |
| Multi-Step Workflows | Position the viewport as part of a broader workflow that chains scroll with click or extract actions.          |

### Usages in Automation Testing

| Use Case                   | Description                                                                                                          |
|----------------------------|----------------------------------------------------------------------------------------------------------------------|
| Infinite Scroll Testing    | Scroll to the bottom of the page repeatedly to trigger and validate lazy-loaded or infinite-scroll content.          |
| Responsive Design Testing  | Scroll to specific offsets on different viewport sizes to verify element visibility and layout at each position.     |
| Overflow Element Testing   | Scroll within a container to verify that content below the fold is rendered and accessible to assertions.            |
| Visual Regression Testing  | Scroll to a defined position and capture a screenshot to compare layout against a baseline.                          |
| Smooth Scroll Verification | Use Behavior:smooth and assert the scroll offset over time to confirm animated scrolling is functioning as expected. |

## Examples

### Example No.1

### Scroll the page vertically to a specific offset

Scrolls the entire page so the top of the viewport is 500 pixels from the top of the document.
Use this form to bring off-screen content into view or to position the viewport at a known vertical coordinate.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:500}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:500}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:500}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:500}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:500}}"
}
```
### Example No.2

### Scroll the page on both axes with smooth animation

Scrolls the entire page to 300 pixels from the top and 100 pixels from the left using a smooth animated transition.
Use this form when the scroll direction, offset, and animation style all need explicit control.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:300 --Left:100 --Behavior:smooth}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:300 --Left:100 --Behavior:smooth}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:300 --Left:100 --Behavior:smooth}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:300 --Left:100 --Behavior:smooth}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:300 --Left:100 --Behavior:smooth}}"
}
```
### Example No.3

### Scroll within a specific overflow element vertically

Locates the element matching `#ScrollablePanel` using the CssSelector strategy and scrolls its internal content 150 pixels from the top.
Use this form when the scroll target is an overflow container rather than the full page.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScroll",
    Argument = "{{$ --Top:150}}",
    Locator = "CssSelector",
    OnElement = "#ScrollablePanel"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScroll")
    .setArgument("{{$ --Top:150}}")
    .setLocator("CssSelector")
    .setOnElement("#ScrollablePanel");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScroll",
    argument: "{{$ --Top:150}}",
    locator: "CssSelector",
    onElement: "#ScrollablePanel"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:150}}",
    "locator": "CssSelector",
    "onElement": "#ScrollablePanel"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScroll",
    "argument": "{{$ --Top:150}}",
    "locator": "CssSelector",
    "onElement": "#ScrollablePanel"
}
```
### Example No.4

### Scroll within a specific overflow element on both axes with smooth animation

Locates the element matching `#TextAreaEnabled` using the CssSelector strategy and scrolls its content 10 pixels from the top and 10 pixels from the left with smooth animation.
Use this form when element-level scrolling must control both axes and the visual animation style simultaneously.

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
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Argument passes the scroll parameters using the `{{$ --Name:Value}}` macro format.
It accepts the Behavior, Left, and Top parameters that control the scroll target and animation.
When neither Left nor Top is supplied via Argument the action takes no effect.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target element for element-level scrolling.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.
Locator is only evaluated when OnElement is also provided.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the overflow container to scroll.
It is evaluated using the strategy defined by the Locator property.
When absent the action scrolls the entire page via `window.scroll()` instead of a specific element.

## Parameters

### Behavior (Behavior)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the scrolling animation style.
Accepted values are `auto` (default — follows the computed CSS scroll-behavior), `instant` (single-jump, no animation), and `smooth` (animated transition).
When absent the value defaults to `auto`.

#### Values

##### Auto

Scroll behavior is determined by the computed value of the [scroll-behavior](https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior) CSS property on the target.
##### Instant

Scrolling happens instantly in a single jump with no animation.
##### Smooth

Scrolling animates smoothly to the target offset.

### Left (Left)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the horizontal pixel offset from the left edge of the scroll container (the page or the target element) to scroll to.
When absent the horizontal position is not changed.

### Top (Top)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the vertical pixel offset from the top of the scroll container (the page or the target element) to scroll to.
When absent the vertical position is not changed.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
