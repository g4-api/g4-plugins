# Invoke Script (InvokeScript)

[Table of Content](../Home.md)  

~19 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Executes an environment-specific script within the current WebDriver session.
In a web browser the script is JavaScript; on iOS it is Xcode; on Windows it can be PowerShell.
The script can receive a located web element and custom argument values, making it the primary way to perform DOM manipulation, extract hidden data, or trigger JavaScript-only behaviors that native WebDriver commands cannot reach.
The return value of the script is stored in the session parameter ScriptResult and is immediately available to downstream rules.

### Key Features and Functionality

| Feature           | Description                                                                                            |
|-------------------|--------------------------------------------------------------------------------------------------------|
| Script Execution  | Executes environment-specific scripts synchronously within the current session via WebDriver.          |
| Flexible Input    | Script can be supplied inline as the Argument value or explicitly via the ScriptBlock parameter.       |
| Element Injection | When OnElement is provided the resolved element is prepended to the arguments array as arguments[0].   |
| Custom Arguments  | The Arguments parameter accepts a JSON array whose values are appended to the script's arguments list. |
| Result Storage    | The script return value is stored in SessionParameters["ScriptResult"] for use by downstream rules.  |

### Usages in RPA

| Use Case             | Description                                                                                               |
|----------------------|-----------------------------------------------------------------------------------------------------------|
| DOM Manipulation     | Set element values, trigger events, or change styles that cannot be driven through standard interactions. |
| Data Extraction      | Return hidden attributes, computed properties, or page-level data for downstream processing.              |
| Dynamic Interaction  | Inject values into inputs, scroll elements into view, or simulate events in single-page applications.     |
| JavaScript Utilities | Run reusable JS utilities — date formatters, encoders, or data transforms — within the browser context.   |

### Usages in Automation Testing

| Use Case                | Description                                                                                              |
|-------------------------|----------------------------------------------------------------------------------------------------------|
| DOM State Validation    | Read hidden properties or computed values that are not exposed through standard element APIs.            |
| Pre-condition Setup     | Set initial field values or application state via script to put the UI in the correct starting state.    |
| Script Return Assertion | Capture the ScriptResult session parameter and assert its value with a downstream assertion rule.        |
| Event Simulation        | Dispatch custom browser events to trigger handlers that are difficult to reach through WebDriver clicks. |

## Examples

### Example No.1

### Execute an inline JavaScript script

Passes the JavaScript expression directly as the Argument property and executes it in the browser.
The return value is stored in the ScriptResult session parameter.
Use this form for one-liner scripts that do not require parameterization.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScript",
    Argument = "document.querySelector('#InputEnabled').value='Foo Bar';"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScript")
    .setArgument("document.querySelector('#InputEnabled').value='Foo Bar';");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScript",
    argument: "document.querySelector('#InputEnabled').value='Foo Bar';"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScript",
    "argument": "document.querySelector('#InputEnabled').value='Foo Bar';"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScript",
    "argument": "document.querySelector('#InputEnabled').value='Foo Bar';"
}
```
### Example No.2

### Execute a script block with custom arguments

Specifies the script via the ScriptBlock parameter and passes a JSON array of values via the Arguments parameter.
The script accesses passed values through the `arguments` array — `arguments[0]` is the first entry in the JSON array.
Use this form when the script body and its input values need to vary independently.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScript",
    Argument = "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value=arguments[0]; --Arguments:["Foo Bar"]}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScript")
    .setArgument("{{$ --ScriptBlock:document.querySelector('#InputEnabled').value=arguments[0]; --Arguments:["Foo Bar"]}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScript",
    argument: "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value=arguments[0]; --Arguments:["Foo Bar"]}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value=arguments[0]; --Arguments:["Foo Bar"]}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value=arguments[0]; --Arguments:["Foo Bar"]}}"
}
```
### Example No.3

### Execute a script with a web element as the first argument

Locates the element matching `#InputEnabled` using the CssSelector strategy and injects it as `arguments[0]` in the script.
Use this form when the script must operate directly on a located DOM element rather than re-querying it internally via a selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScript",
    Argument = "{{$ --ScriptBlock:arguments[0].value='Foo Bar';}}",
    Locator = "CssSelector",
    OnElement = "#InputEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScript")
    .setArgument("{{$ --ScriptBlock:arguments[0].value='Foo Bar';}}")
    .setLocator("CssSelector")
    .setOnElement("#InputEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScript",
    argument: "{{$ --ScriptBlock:arguments[0].value='Foo Bar';}}",
    locator: "CssSelector",
    onElement: "#InputEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:arguments[0].value='Foo Bar';}}",
    "locator": "CssSelector",
    "onElement": "#InputEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:arguments[0].value='Foo Bar';}}",
    "locator": "CssSelector",
    "onElement": "#InputEnabled"
}
```
### Example No.4

### Execute a script with a web element and custom arguments

Locates the element matching `#InputEnabled` and injects it as `arguments[0]`.
Values from the Arguments JSON array follow at `arguments[1]` and beyond.
Use this form when the script needs both a DOM element reference and separate data values passed as independent arguments.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScript",
    Argument = "{{$ --ScriptBlock:arguments[0].value=arguments[1]; --Arguments:["Foo Bar"]}}",
    Locator = "CssSelector",
    OnElement = "#InputEnabled"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScript")
    .setArgument("{{$ --ScriptBlock:arguments[0].value=arguments[1]; --Arguments:["Foo Bar"]}}")
    .setLocator("CssSelector")
    .setOnElement("#InputEnabled");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScript",
    argument: "{{$ --ScriptBlock:arguments[0].value=arguments[1]; --Arguments:["Foo Bar"]}}",
    locator: "CssSelector",
    onElement: "#InputEnabled"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:arguments[0].value=arguments[1]; --Arguments:["Foo Bar"]}}",
    "locator": "CssSelector",
    "onElement": "#InputEnabled"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:arguments[0].value=arguments[1]; --Arguments:["Foo Bar"]}}",
    "locator": "CssSelector",
    "onElement": "#InputEnabled"
}
```

## Output Parameter

### Invoke Script Script Result (InvokeScript:ScriptResult)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

InvokeScript:ScriptResult holds the return value produced by the executed script.
It is written to session parameters after the script completes and is immediately available to any downstream rule that needs to read or assert the script output.
The stored value type matches whatever the script returns — a string, number, boolean, object, or null when the script returns undefined.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Argument provides the script to execute or a macro expression that carries the ScriptBlock and Arguments parameters.
When passed as a plain string it is used directly as the script code.
When passed as a macro expression it carries ScriptBlock and Arguments parameters using the {{$ --Name:Value}} format.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Locator specifies the strategy used to find the target element when OnElement is provided.
Accepted values include Xpath, CssSelector, Id, LinkText, and PartialLinkText.
When absent the default Xpath strategy is used.
Locator has no effect when OnElement is not set.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement provides the locator expression that identifies the element to inject into the script as arguments[0].
It is evaluated using the strategy defined by the Locator property.
When absent no element is prepended to the arguments array.

## Parameters

### Arguments (Arguments)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Json       |

Arguments specifies the values to pass to the script as a JSON array string.
The array is deserialized and each entry is appended to the script's arguments list.
When OnElement is also provided the element is prepended first so Arguments entries begin at arguments[1].
When Arguments is absent or not valid JSON an empty array is used and no custom values are passed.

### Script Block (ScriptBlock)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

ScriptBlock specifies the script code to execute.
When ScriptBlock is provided it takes precedence over the raw Argument property value.
When ScriptBlock is absent the engine uses the Argument property value directly as the script string.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#executing-script](https://www.w3.org/TR/webdriver/#executing-script)
