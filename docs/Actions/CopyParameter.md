# Copy Parameter (CopyParameter)

[Table of Content](../Home.md)  

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `CopyParameter` plugin facilitates the copying of parameters within automation scripts.
Its primary objective is to enable efficient and controlled copying of parameter values from a source to a target across different scopes.

### Key Features and Functionality

| Feature               | Description                                                                                                                    |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Source to Target Copy | Copies the value of a parameter from a defined source to a defined target across different scopes.                             |
| Scope Management      | Allows for the specification of scopes for both source and target parameters, with default values if not specified.            |
| Dynamic Environment   | Supports the retrieval and setting of parameters within different environments, particularly when using the Application scope. |

### Usages in RPA

| Usage                     | Description                                                                                                                                                                           |
|---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Data Transfer             | Utilize the `CopyParameter` plugin to transfer data between different parts of an automation script. This can help in processes where data needs to be shared across different steps. |
| Session Management        | Efficiently handle session parameters by copying values as needed, ensuring that session-specific data is correctly propagated.                                                       |
| Parameter Synchronization | Synchronize parameters between different automation components or systems to maintain data consistency.                                                                               |

### Usages in Automation Testing

| Usage                     | Description                                                                                                                                                |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Test Data Management      | Use the `CopyParameter` plugin to manage test data by copying values between different test cases or test steps.                                           |
| Environment Configuration | Facilitate the setup of test environments by copying configuration parameters to the required locations.                                                   |
| Dynamic Test Execution    | Enable dynamic test execution by copying runtime parameters that are needed for various test scenarios, ensuring tests are executed with the correct data. |

## Examples

### Example No.1

This configuration copies a parameter from a source within the session scope to a target within the same session scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:targetParam --TargetScope:Session}}",
    OnAttribute = "Session",
    OnElement = "sourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:targetParam --TargetScope:Session}}")
    .setOnAttribute("Session")
    .setOnElement("sourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:targetParam --TargetScope:Session}}",
    onAttribute: "Session",
    onElement: "sourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Session}}",
    "onAttribute": "Session",
    "onElement": "sourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Session}}",
    "onAttribute": "Session",
    "onElement": "sourceParam"
}
```
### Example No.2

This configuration copies a parameter from a source within the application scope to a target within the user scope, using the system parameters environment.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:targetParam --Environment:SystemParameters --TargetScope:User}}",
    OnAttribute = "Application",
    OnElement = "sourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:targetParam --Environment:SystemParameters --TargetScope:User}}")
    .setOnAttribute("Application")
    .setOnElement("sourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:targetParam --Environment:SystemParameters --TargetScope:User}}",
    onAttribute: "Application",
    onElement: "sourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --Environment:SystemParameters --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "sourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --Environment:SystemParameters --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "sourceParam"
}
```
### Example No.3

This configuration copies a parameter from a source within the machine scope to a target within the process scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:targetParam --TargetScope:Process}}",
    OnAttribute = "Machine",
    OnElement = "sourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:targetParam --TargetScope:Process}}")
    .setOnAttribute("Machine")
    .setOnElement("sourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:targetParam --TargetScope:Process}}",
    onAttribute: "Machine",
    onElement: "sourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Process}}",
    "onAttribute": "Machine",
    "onElement": "sourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Process}}",
    "onAttribute": "Machine",
    "onElement": "sourceParam"
}
```
### Example No.4

This configuration copies a parameter from a source within the user scope to a target within the application scope, using the custom environment.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:targetParam --Environment:CustomEnvironment --TargetScope:Application}}",
    OnAttribute = "User",
    OnElement = "sourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:targetParam --Environment:CustomEnvironment --TargetScope:Application}}")
    .setOnAttribute("User")
    .setOnElement("sourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:targetParam --Environment:CustomEnvironment --TargetScope:Application}}",
    onAttribute: "User",
    onElement: "sourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --Environment:CustomEnvironment --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "sourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --Environment:CustomEnvironment --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "sourceParam"
}
```
### Example No.5

This configuration copies a parameter from a source within the process scope to a target within the machine scope.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:targetParam --TargetScope:Machine}}",
    OnAttribute = "Process",
    OnElement = "sourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:targetParam --TargetScope:Machine}}")
    .setOnAttribute("Process")
    .setOnElement("sourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:targetParam --TargetScope:Machine}}",
    onAttribute: "Process",
    onElement: "sourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Machine}}",
    "onAttribute": "Process",
    "onElement": "sourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:targetParam --TargetScope:Machine}}",
    "onAttribute": "Process",
    "onElement": "sourceParam"
}
```

## Properties

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Session           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | GetParameter      |

Specifies the scope of the source parameter. The scope defines where the parameter is stored and can be one of several predefined scopes such as 'Session', 'SystemScope', etc.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the source parameter whose value will be copied.

## Parameters

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the environment in which the parameters are managed. It allows for defining different contexts or environments where the parameters are stored and retrieved from.
This parameter is relevant only when using the Application scope. It allows managing multiple environments that can hold different values while using the same parameter names or a completely different parameter set.

### Target Parameter (TargetParameter)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target parameter to which the value will be copied. This is the parameter that will receive the value from the source parameter.

### Target Scope (TargetScope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | SetParameter      |

Specifies the scope of the target parameter. The scope defines where the parameter is stored and can be one of several predefined scopes such as 'Session', 'UserScope', etc.

## Scope

* Any