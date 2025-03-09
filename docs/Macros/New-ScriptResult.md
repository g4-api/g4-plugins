# New Script Result (New-ScriptResult)

[Table of Content](../Home.md)  

~18 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `New-ScriptResult` macro plugin is designed to execute custom scripts within automation workflows, providing flexibility and customization for various tasks. 
This plugin retrieves data from a specific script element on the web page and sends it as keystrokes to an element within the automation workflow.

### Key Features and Functionality

| Feature                | Description                                                                                                           |
|------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Script Execution       | Executes custom scripts defined by users, enabling a wide range of automation actions.                                |
| Parameterization       | Supports passing parameters to scripts for dynamic behavior, allowing adaptable automation workflows.                 |
| Regex Pattern Matching | Includes support for regex pattern matching to extract specific portions of the script result for further processing. |

### Usages in RPA

| Usage            | Description                                                                             |
|------------------|-----------------------------------------------------------------------------------------|
| Custom Scripting | Integrate custom scripts into RPA workflows for specialized automation tasks.           |
| Dynamic Behavior | Use parameterized scripts to handle dynamic elements or scenarios within RPA workflows. |

### Usages in Automation Testing

| Usage                     | Description                                                                                                    |
|---------------------------|----------------------------------------------------------------------------------------------------------------|
| Custom Validation         | Execute custom validation scripts during automated testing, allowing for specific checks and verifications.    |
| Dynamic Testing Scenarios | Use parameterized scripts to adapt to various testing scenarios, ensuring thorough and accurate test coverage. |

## Examples

### Example No.1

Use the `New-ScriptResult` macro plugin to execute a custom script that retrieves text from a script element and sends it as keystrokes to an input field identified by a CSS selector.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim(); --Pattern:"^\d+"}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim(); --Pattern:"^\d+"}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim(); --Pattern:"^\d+"}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim(); --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim(); --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

Use the `New-ScriptResult` macro plugin to execute a custom script that multiplies a given number by a provided argument and sends the result as keystrokes to an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5 --Pattern:"^\d+"}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5 --Pattern:"^\d+"}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5 --Pattern:"^\d+"}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5 --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5 --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.3

Use the `New-ScriptResult` macro plugin to execute a custom script that multiplies a number by two provided arguments and sends the result as keystrokes to an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2 --Pattern:"^\d+"}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2 --Pattern:"^\d+"}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2 --Pattern:"^\d+"}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2 --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2 --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.4

Use the `New-ScriptResult` macro plugin to execute a custom script that multiplies a number by two arguments provided as an object and sends the result as keystrokes to an input field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{"num1":5,"num2":2} --Pattern:"^\d+"}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{"num1":5,"num2":2} --Pattern:"^\d+"}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{"num1":5,"num2":2} --Pattern:"^\d+"}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{"num1":5,"num2":2} --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{"num1":5,"num2":2} --Pattern:"^\d+"}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

## Parameters

### Arg (Arg)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | Yes               |
| **Value Type**    | Any               |

Specifies the arguments to be passed to the custom script.

### Src (Src)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the custom script to be executed.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies a regex pattern used to match and extract the desired portion of the script result.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
