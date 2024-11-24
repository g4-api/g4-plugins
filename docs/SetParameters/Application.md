# Application (Application)

[Table of Content](../Home.md)  

~18 min · SetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SetApplicationParameter` plugin is to set application parameters that are shared across all automation instances. This allows for flexible configuration management, enabling dynamic updates to parameters such as connection strings, API keys, or other configuration settings essential for automation workflows.

### Key Features and Functionality

| Feature                        | Description                                                                                            |
|------------------------------- |--------------------------------------------------------------------------------------------------------|
| Parameter Setting              | Sets application parameters in a specified environment.                                                |
| Environment-Based Parameters   | Supports setting parameters specific to different environments (e.g., Prod, Dev).                      |
| Integration with Other Plugins | Can be used in conjunction with other plugins to dynamically set parameters based on automation needs. |

### Usages in RPA

| Usage                         | Description                                                                                          |
|------------------------------ |----------------------------------------------------------------------------------------------------- |
| Dynamic Configuration         | Set configuration settings dynamically based on the environment.                                     |
| Centralized Parameter Storage | Use a centralized location for storing and setting parameters across different automation instances. |

### Usages in Automation Testing

| Usage                        | Description                                                                                          |
|------------------------------|------------------------------------------------------------------------------------------------------|
| Environment-Specific Testing | Set parameters specific to test environments, enabling more accurate and environment-specific tests. |
| Configuration Management     | Simplify configuration management by setting parameters directly within test scripts.                |

## Examples

### Example No.1

This example demonstrates the usage of the `Application` plugin to set a parameter named `ConnectionString` in the `Prod` environment directly.

| Field      | Description                                                              |
|------------|--------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Application`.   |
| argument   | Specifies the environment and value to set the parameter.                |
| onElement  | Specifies the name of the parameter to be set.                           |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Application",
    Argument = "{{$ --Environment:Prod --Value:MyConnectionString}}",
    OnElement = "ConnectionString"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Application")
    .setArgument("{{$ --Environment:Prod --Value:MyConnectionString}}")
    .setOnElement("ConnectionString");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Application",
    argument: "{{$ --Environment:Prod --Value:MyConnectionString}}",
    onElement: "ConnectionString"
};
```

_**JSON**_

```js
{
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod --Value:MyConnectionString}}",
    "onElement": "ConnectionString"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod --Value:MyConnectionString}}",
    "onElement": "ConnectionString"
}
```
### Example No.2

This example demonstrates the usage of the macro to set a parameter named `ConnectionString` in the `Prod` environment and use it in a `RegisterParameter` action, utilizing the `OnAttribute` property.

| Field        | Description                                                                                             |
|------------- |---------------------------------------------------------------------------------------------------------|
| pluginName   | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument     | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement    | Specifies the target element whose attribute content will be saved as the parameter value.              |
| onAttribute  | Specifies the attribute of the element from which the value will be extracted.                          |
| locator      | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    Locator = "CssSelector",
    OnAttribute = "data-value",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:ConnectionString --Scope:Application --Environment:Prod}}")
    .setLocator("CssSelector")
    .setOnAttribute("data-value")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    locator: "CssSelector",
    onAttribute: "data-value",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ConnectionString --Scope:Application --Environment:Prod}}",
    "locator": "CssSelector",
    "onAttribute": "data-value",
    "onElement": "#someElement"
}
```
### Example No.3

This example demonstrates setting a parameter named `ConnectionString` from the text content of an element identified by its CSS selector, using the default `SystemParameters` environment.

| Field      | Description                                                                                             |
|------------|---------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument   | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement  | Specifies the target element whose text content will be saved as the parameter value.                   |
| locator    | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:ConnectionString --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#someElement"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:ConnectionString --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#someElement");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:ConnectionString --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#someElement"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ConnectionString --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:ConnectionString --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#someElement"
}
```
### Example No.4

This example demonstrates setting a parameter named `APIKey` from the text content of an element identified by its CSS selector and using a regular expression to extract part of the text.

| Field             | Description                                                                                             |
|-------------------|---------------------------------------------------------------------------------------------------------|
| pluginName        | Identifies the specific plugin being utilized, which is `RegisterParameter`.                            |
| argument          | Specifies the use of the macro to set the parameter value dynamically.                                  |
| onElement         | Specifies the target element whose text content will be saved as the parameter value.                   |
| regularExpression | Specifies the regular expression to apply to the text content before saving the parameter value.        |
| locator           | Specifies the locator type used to identify the target element, which is `CssSelector` in this example. |

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:APIKey --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#apiElement",
    RegularExpression = "^.*(?=\sAPIKey$)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:APIKey --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#apiElement")
    .setRegularExpression("^.*(?=\sAPIKey$)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:APIKey --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#apiElement",
    regularExpression: "^.*(?=\sAPIKey$)"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:APIKey --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#apiElement",
    "regularExpression": "^.*(?=\sAPIKey$)"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the name of the parameter to be set.

## Parameters

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the environment in which to set the parameter. If not specified, the `SystemParameters` environment will be used.

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value to be set for the parameter.
