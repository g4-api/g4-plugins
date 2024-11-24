# Register Parameter (RegisterParameter)

[Table of Content](../Home.md)  

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `RegisterParameter` plugin facilitates the registration and storage of parameters within automation scripts.
Its primary objective is to save values to a specified scope by creating and sending the appropriate `SetParameter` plugin based on user input.

### Key Features and Functionality

| Feature                     | Description                                                                                                         |
|-----------------------------|---------------------------------------------------------------------------------------------------------------------|
| Parameter Registration      | Registers the value of a specified parameter, which can be directly provided or obtained from a web element.        |
| Scope Management            | Supports defining the scope (`Session`, `Application`, `Machine`, `User`, `Process`) where the parameter is stored. |
| Environment Handling        | Allows specifying different environments where the parameters are managed.                                          |
| Regular Expression Matching | Can apply a regular expression to the value and encode the result in Base64.                                        |
| Meta Action                 | Converts user input into the appropriate `SetParameter` plugin rule and sends it.                                   |

### Usages in RPA

| Usage                 | Description                                                                |
|-----------------------|----------------------------------------------------------------------------|
| Registering Values    | Save values from web elements or arguments within a specified scope.       |
| Parameter Management  | Manage parameters across different sessions, processes, or environments.   |
| Complex Data Handling | Use regular expressions to filter or transform values before storing them. |

### Usages in Automation Testing

| Usage                     | Description                                                                                                                                                   |
|---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Test Data Management      | Use the `RegisterParameter` plugin to manage test data by registering values to different scopes.                                                             |
| Environment Configuration | Facilitate the setup of test environments by registering configuration parameters to the required locations.                                                  |
| Dynamic Test Execution    | Enable dynamic test execution by registering runtime parameters that are needed for various test scenarios, ensuring tests are executed with the correct data.|

## Examples

### Example No.1

This configuration registers a parameter within the session scope with a specified value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Session}}"
}
```
### Example No.2

This configuration registers a parameter within the application scope with a specified value and environment.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development}}"
}
```
### Example No.3

This configuration registers a parameter obtained from a web element within the user scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.4

This configuration registers a parameter by extracting the href attribute from a web element within the session scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.5

This configuration registers a parameter by extracting the src attribute from an image element and storing it within the user scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:imageSrc --Scope:User}}",
    Locator = "CssSelector",
    OnAttribute = "src",
    OnElement = "#imageId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:imageSrc --Scope:User}}")
    .setLocator("CssSelector")
    .setOnAttribute("src")
    .setOnElement("#imageId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:imageSrc --Scope:User}}",
    locator: "CssSelector",
    onAttribute: "src",
    onElement: "#imageId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:imageSrc --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "src",
    "onElement": "#imageId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:imageSrc --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "src",
    "onElement": "#imageId"
}
```
### Example No.6

This configuration registers a parameter by applying a regular expression to the extracted value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the web element from which the parameter value can be obtained if not directly provided.

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the argument value that will be logged and used as the parameter name during the execution of the plugin. This can be a parameter name or a CLI expression.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute of the web element from which the value should be extracted.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regular expression to be applied to the value before storing it. The result will be encoded in Base64.

## Parameters

### Name (Name)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the name of the parameter to be registered. This is used when the `Argument` property is a CLI expression.

### Scope (Scope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | SetParameter      |

Specifies the scope in which the parameter will be registered. The scope defines where the parameter is stored and can be one of several predefined scopes such as 'Application', 'Session', 'Machine', 'User', 'Process'.

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the environment in which the parameters are managed. It allows for defining different contexts or environments where the parameters are stored and retrieved from.

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the value of the parameter to be registered.
