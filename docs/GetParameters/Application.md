# Application (Application)

[Table of Content](../Home.md)  

~12 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The GetApplicationParameter plugin retrieves shared settings used by automation tasks, such as connection strings and API keys. It supports different environments like Dev and Prod, ensuring each workflow uses the right configuration. By centralizing parameters, it keeps setups consistent and easy to manage.

### Key Features and Functionality

| Feature             | Description                                                      |
|---------------------|------------------------------------------------------------------|
| Parameter Retrieval | Fetches settings like connection strings, API keys, and more.    |
| Environment Support | Gets parameters tailored to each environment (Dev, Prod, etc.).  |
| Plugin Integration  | Works with other plugins to apply parameters in various actions. |

### Usages in RPA

| Use Case                | Description                                                       |
|-------------------------|-------------------------------------------------------------------|
| Dynamic Configuration   | Load settings at runtime to adapt workflows for different stages. |
| Central Parameter Store | Keep all automation instances using the same source for settings. |

### Usages in Automation Testing

| Use Case                     | Description                                                       |
|------------------------------|-------------------------------------------------------------------|
| Environment-Specific Testing | Load test environment settings to run accurate, real-world tests. |
| Test Script Configuration    | Fetch parameters directly within test scripts to simplify setup.  |

## Examples

### Example No.1

### Retrieve ConnectionString Parameter

This example demonstrates how to retrieve the 'ConnectionString' parameter using the Application plugin’s GetParameter action with the argument `--Environment:Prod`.
It targets the `ConnectionString` parameter name and invokes the plugin in production scope.
The argument `--Environment:Prod` specifies the production environment for the parameter retrieval.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Application",
    Argument = "{{$ --Environment:Prod}}",
    OnElement = "ConnectionString"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Application")
    .setArgument("{{$ --Environment:Prod}}")
    .setOnElement("ConnectionString");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Application",
    argument: "{{$ --Environment:Prod}}",
    onElement: "ConnectionString"
};
```

_**JSON**_

```js
{
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod}}",
    "onElement": "ConnectionString"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Application",
    "argument": "{{$ --Environment:Prod}}",
    "onElement": "ConnectionString"
}
```
### Example No.2

### Retrieve ConnectionString Parameter with Default Environment

The retrieved ConnectionString value is trimmed to remove whitespace.
This example demonstrates how to retrieve the 'ConnectionString' parameter using the Application plugin’s GetParameter action, defaulting to the SystemParameters environment.
It targets the `ConnectionString` parameter name without specifying an environment argument, relying on the default environment.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Application",
    OnElement = "ConnectionString"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Application")
    .setOnElement("ConnectionString");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Application",
    onElement: "ConnectionString"
};
```

_**JSON**_

```js
{
    "pluginName": "Application",
    "onElement": "ConnectionString"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Application",
    "onElement": "ConnectionString"
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

Argument tells the system where to look for your setting so it finds the correct value.
Picking the right location helps you avoid missing or wrong information.
A wrong location can cause errors when the system tries to retrieve your data.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement tells the system which parameter you want so it can provide you with the right value.
Choosing the correct name helps you get accurate data.
A wrong name can lead to missing or incorrect results.

## Parameters

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Environment sets which list of values to use so you get parameters from the right place and avoid missing information.
Leaving it blank picks SystemParameters so you still get a basic set of values and avoid surprises.

## Scope

* Any