# Get Parameter (Get-Parameter)

[Table of Content](../Home.md)  

~21 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `GetParameter` plugin is an indispensable tool in the realm of Robotic Process Automation (RPA) and automation testing. 
It empowers automation scripts and RPA bots to dynamically retrieve essential parameter values from the environment, facilitating seamless execution of tasks and actions.

### Key Features

| Feature                                  | Description                                                                                                                                                                                                                                                                        |
|------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Environment Parameter Retrieval          | Obtain parameter values from the environment effortlessly, enabling RPA bots and automation scripts to adapt dynamically to various environmental configurations.                                                                                                                  |
| Dynamic Value Injection                  | Inject retrieved parameter values seamlessly into automation steps or actions, ensuring flexibility and customization in automation workflows.                                                                                                                                     |
| Encoding Support                         | Robust support for encoding schemes such as base64 ensures compatibility with encoded parameter values stored in the environment.                                                                                                                                                  |
| Environment-Specific Parameter Retrieval | When utilizing the application scope, the plugin allows for the specification of an 'EnvironmentName' parameter, facilitating the retrieval of values from different environments (e.g., test, prod). If not specified, the plugin defaults to the 'SystemParameters' environment. |

### Usages in RPA

| Usage                           | Description                                                                                                                                                                              |
|---------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Task Orchestration              | Streamline task execution by dynamically retrieving parameters required for different stages of RPA workflows, enhancing efficiency and adaptability.                                    |
| Environment-Specific Automation | Configure RPA bots to operate seamlessly across multiple environments by retrieving environment-specific parameter values, ensuring consistency and reliability in automation processes. |

### Usages in Automation Testing

| Usage                           | Description                                                                                                         |
|---------------------------------|---------------------------------------------------------------------------------------------------------------------|
| Data-Driven Testing             | Fetch test data stored as parameters in the environment, enabling data-driven testing approaches and scenarios, which are fundamental to comprehensive automation testing strategies. |
| Configuration Management        | Retrieve dynamic configuration parameters required for automation testing, enabling flexible and customizable testing frameworks that can adapt to changing testing requirements.     |
| Environment-Based Customization | Customize automation testing behavior based on environmental variables, facilitating environment-specific testing scenarios and enhancing test coverage and reliability.              |

## Examples

### Example No.1

This example configures the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'AppVersion' parameter in the 'SystemParameters' environment within the application scope to a specific element identified by its CSS selector.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the exact action the plugin will undertake.
- **argument**: Specifies the keystrokes to be sent by the `SendKeys` plugin, where the value is dynamically obtained from the 'AppVersion' parameter in the 'SystemParameters' environment within the application scope. For example, `{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}`.
- **onElement**: Indicates the target element on the web page to which the keystrokes will be sent, identified by its CSS selector.
- **locator**: Specifies the type of locator used to identify the target element. In this case, it is set to `CssSelector`.

This example instructs the automation system to utilize the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'AppVersion' parameter in the 'SystemParameters' environment within the application scope to the element identified by its CSS selector. 
The retrieved value will be dynamically inserted into the specified element, allowing for precise interaction within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}",
    Locator = "CssSelector",
    OnElement = "#appVersionInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}")
    .setLocator("CssSelector")
    .setOnElement("#appVersionInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}",
    locator: "CssSelector",
    onElement: "#appVersionInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}",
    "locator": "CssSelector",
    "onElement": "#appVersionInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}",
    "locator": "CssSelector",
    "onElement": "#appVersionInput"
}
```
### Example No.2

This example configures the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'AppVersion' parameter in the default 'SystemParameters' environment within the application scope to a specific element identified by its CSS selector.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the exact action the plugin will undertake.
- **argument**: Specifies the keystrokes to be sent by the `SendKeys` plugin, where the value is dynamically obtained from the 'AppVersion' parameter in the default 'SystemParameters' environment within the application scope. For example, `{{$Get-Parameter --Name:AppVersion --Scope:Application}}`.
- **onElement**: Indicates the target element on the web page to which the keystrokes will be sent, identified by its CSS selector.
- **locator**: Specifies the type of locator used to identify the target element. In this case, it is set to `CssSelector`.

This example instructs the automation system to utilize the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'AppVersion' parameter in the default 'SystemParameters' environment within the application scope to the element identified by its CSS selector. 
The retrieved value will be dynamically inserted into the specified element, allowing for precise interaction within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:AppVersion --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#appVersionInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:AppVersion --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#appVersionInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:AppVersion --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#appVersionInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#appVersionInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:AppVersion --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#appVersionInput"
}
```
### Example No.3

This example configures the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'Email' parameter in the user environment to a specific element identified by its CSS selector.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the exact action the plugin will undertake.
- **argument**: Specifies the keystrokes to be sent by the `SendKeys` plugin, where the value is dynamically obtained from the 'Email' parameter in the user environment. For example, `{{$Get-Parameter --Name:Email --Scope:User}}`.
- **onElement**: Indicates the target element on the web page to which the keystrokes will be sent, identified by its CSS selector.
- **locator**: Specifies the type of locator used to identify the target element. In this case, it is set to `CssSelector`.

This example instructs the automation system to utilize the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'Email' parameter in the user environment to the element identified by its CSS selector. 
The retrieved value will be dynamically inserted into the specified element, allowing for precise interaction within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:Email --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#emailInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:Email --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#emailInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:Email --Scope:User}}",
    locator: "CssSelector",
    onElement: "#emailInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:Email --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#emailInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:Email --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#emailInput"
}
```
### Example No.4

This example configures the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'MachineName' parameter in the machine environment to a specific element identified by its CSS selector.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the exact action the plugin will undertake.
- **argument**: Specifies the keystrokes to be sent by the `SendKeys` plugin, where the value is dynamically obtained from the 'MachineName' parameter in the machine environment. For example, `{{$Get-Parameter --Name:MachineName --Scope:Machine}}`.
- **onElement**: Indicates the target element on the web page to which the keystrokes will be sent, identified by its CSS selector.
- **locator**: Specifies the type of locator used to identify the target element. In this case, it is set to `CssSelector`.

This example instructs the automation system to utilize the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'MachineName' parameter in the machine environment to the element identified by its CSS selector. 
The retrieved value will be dynamically inserted into the specified element, allowing for precise interaction within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:MachineName --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#machineNameInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:MachineName --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#machineNameInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:MachineName --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#machineNameInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:MachineName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#machineNameInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:MachineName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#machineNameInput"
}
```
### Example No.5

This example configures the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'ProcessId' parameter in the process environment to a specific element identified by its CSS selector.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the exact action the plugin will undertake.
- **argument**: Specifies the keystrokes to be sent by the `SendKeys` plugin, where the value is dynamically obtained from the 'ProcessId' parameter in the process environment. For example, `{{$Get-Parameter --Name:ProcessId --Scope:Process}}`.
- **onElement**: Indicates the target element on the web page to which the keystrokes will be sent, identified by its CSS selector.
- **locator**: Specifies the type of locator used to identify the target element. In this case, it is set to `CssSelector`.

This example instructs the automation system to utilize the `SendKeys` plugin to send keystrokes representing the value retrieved from the 'ProcessId' parameter in the process environment to the element identified by its CSS selector. 
The retrieved value will be dynamically inserted into the specified element, allowing for precise interaction within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:ProcessId --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#processIdInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:ProcessId --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#processIdInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:ProcessId --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#processIdInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ProcessId --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#processIdInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:ProcessId --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#processIdInput"
}
```

## Parameters

### Name (Name)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the name of the parameter from which to retrieve the value.

### Scope (Scope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | GetParameter      |

Specifies the scope from which to retrieve the parameter value.
The scope can be 'Application', 'User', 'Machine', 'Process', or 'Session'.
If not specified, the default scope 'Session' will be used.

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the environment name from which to retrieve the parameter value.
If not specified, the default environment name 'SystemParameters' will be used.
