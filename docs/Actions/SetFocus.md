# Set Focus (SetFocus)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Programmatically places keyboard focus on a target web element by executing the JavaScript `focus()` method via the W3C Execute Script API.
It is used to activate input fields and interactive controls before subsequent keyboard interactions, and to trigger focus-related DOM events such as `onfocus` and `focusin`.
When the target element cannot be located the action exits silently without raising an exception.

### Key Features and Functionality

| Feature            | Description                                                                              |
|--------------------|------------------------------------------------------------------------------------------|
| JavaScript Focus   | Calls `arguments[0].focus()` on the located element via the W3C Execute Script API.      |
| Event Triggering   | Fires `onfocus` and `focusin` DOM events, activating any handlers bound to those events. |
| Graceful No-Op     | Returns an empty response without throwing when the target element is not found.         |
| Locator Strategies | Supports Xpath, CssSelector, Id, LinkText, and PartialLinkText for element targeting.    |

### Usages in RPA

| Use Case              | Description                                                                                     |
|-----------------------|-------------------------------------------------------------------------------------------------|
| Form Field Activation | Focuses an input field before typed or scripted text entry to ensure keystrokes land correctly. |
| Event-Driven Workflow | Triggers onfocus handlers that load dynamic content, suggestions, or validation feedback.       |
| Multi-Step Forms      | Moves focus to the next field in sequence to simulate natural tab-order navigation.             |

### Usages in Automation Testing

| Use Case                 | Description                                                                                                    |
|--------------------------|----------------------------------------------------------------------------------------------------------------|
| Focus Event Verification | Confirms that onfocus and focusin handlers fire and produce expected UI changes when an element is focused.    |
| Input Readiness Testing  | Verifies that an input element is reachable and focusable before asserting keyboard interaction behavior.      |
| Accessibility Compliance | Tests that interactive elements are programmatically focusable, meeting WCAG keyboard navigation requirements. |

## Examples

### Example No.1

### Focus an input field using XPath

Locates the element matching `//input[@name='email']` using the default Xpath strategy and calls `focus()` on it.
Use this form when an XPath expression uniquely identifies the target input and no explicit locator override is needed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetFocus",
    OnElement = "//input[@name='email']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetFocus")
    .setOnElement("//input[@name='email']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetFocus",
    onElement: "//input[@name='email']"
};
```

_**JSON**_

```js
{
    "pluginName": "SetFocus",
    "onElement": "//input[@name='email']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetFocus",
    "onElement": "//input[@name='email']"
}
```
### Example No.2

### Focus an element using a CSS selector

Locates the element matching `#username` using the CssSelector strategy and calls `focus()` on it.
Use this form when targeting an element by its ID or CSS expression is more convenient or reliable than an XPath.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SetFocus",
    Locator = "CssSelector",
    OnElement = "#username"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SetFocus")
    .setLocator("CssSelector")
    .setOnElement("#username");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SetFocus",
    locator: "CssSelector",
    onElement: "#username"
};
```

_**JSON**_

```js
{
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#username"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SetFocus",
    "locator": "CssSelector",
    "onElement": "#username"
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

Locator specifies the strategy used to find the target element.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to receive focus.
It is evaluated using the strategy defined by the Locator property.
When the element cannot be located the action exits without throwing an exception.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
