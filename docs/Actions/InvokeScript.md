# Invoke Script (InvokeScript)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `InvokeScript` plugin is to execute scripts within the context of the current session. 
The type of script executed is determined by the environment; for instance, JavaScript in web browsers, Xcode scripts on iOS, or PowerShell scripts on Windows.

### Key Features and Functionality

| Feature             | Description                                                           |
|---------------------|-----------------------------------------------------------------------|
| Script Execution    | Executes environment-specific scripts within the current session.     |
| Element Interaction | Allows interaction with elements by passing them as script arguments. |
| Custom Arguments    | Supports passing custom arguments to the script.                      |
| Result Storage      | Stores the result of the script execution in session parameters.      |

### Usages in RPA

| Usage               | Description                                                               |
|---------------------|---------------------------------------------------------------------------|
| Custom Actions      | Perform custom actions on elements using environment-specific scripts.    |
| Data Extraction     | Extract data from the environment using custom scripts.                   |
| Dynamic Interaction | Interact with elements dynamically based on the script execution results. |

### Usages in Automation Testing

| Usage                   | Description                                                                                                 |
|-------------------------|-------------------------------------------------------------------------------------------------------------|
| Script Validation       | Validate the execution of scripts and their effects on the environment.                                     |
| Environment Interaction | Test the effects of scripts on the environment (e.g., DOM manipulation in web, system configuration in OS). |
| Custom Test Scenarios   | Create and execute custom test scenarios by running environment-specific scripts.                           |

## Examples

### Example No.1

Execute a JavaScript code that sets the value of the input element with the `ID` `InputEnabled` to `Foo Bar` in a web browser.

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

Execute a JavaScript code block that sets the value of the input element with the `ID` `InputEnabled` to `Foo Bar` using the `ScriptBlock` parameter in a web browser.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeScript",
    Argument = "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value='Foo Bar';}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeScript")
    .setArgument("{{$ --ScriptBlock:document.querySelector('#InputEnabled').value='Foo Bar';}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "InvokeScript",
    argument: "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value='Foo Bar';}}"
};
```

_**JSON**_

```js
{
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value='Foo Bar';}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "InvokeScript",
    "argument": "{{$ --ScriptBlock:document.querySelector('#InputEnabled').value='Foo Bar';}}"
}
```
### Example No.3

Execute a JavaScript code block that sets the value of the input element with the `ID` `InputEnabled` to the value passed in the `Arguments` parameter (`Foo Bar`) in a web browser.

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
### Example No.4

Execute a JavaScript code block that sets the value of the element passed as the first argument (`#InputEnabled`) to the value passed as the second argument (`Foo Bar`) in a web browser.

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
### Example No.5

Execute a JavaScript code block that sets the value of the element identified by the `CSS selector` `#InputEnabled` to `Foo Bar` in a web browser.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the script code to be executed. This can be a direct script or a reference to a script block defined in parameters.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the locator strategy to find the element. Supported locator types include `CssSelector`, `Xpath`, `LinkText`, etc.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the actual element identifier using the locator strategy defined. For example, if the locator is `CssSelector`, this would be a CSS selector string.

## Parameters

### Arguments (Arguments)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Json       |

Specifies the arguments to be passed to the script as a JSON array.

### Script Block (ScriptBlock)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the script code block to be executed.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#executing-script](https://www.w3.org/TR/webdriver/#executing-script)
