# Copy Parameter (CopyParameter)

[Table of Content](../Home.md)  

~105 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Helps move values from one parameter to another within automation scripts. It makes it easy to share data between steps by copying values across different scopes. You can set or rely on default source and target scopes to keep your data organized. This ensures that scripts run smoothly with the right information in the right place.

### Key Features and Functionality

| Feature               | Description                                                                         |
|-----------------------|-------------------------------------------------------------------------------------|
| Copy Parameter Values | Moves a parameter's value from a source location to a target location.              |
| Scope Management      | Lets you specify or default source and target scopes for parameters.                |
| Environment Support   | Retrieves and sets parameters in various environments, including application scope. |

### Usages in RPA

| Use Case                  | Description                                                     |
|---------------------------|-----------------------------------------------------------------|
| Data Transfer             | Share data between script steps by copying parameter values.    |
| Session Management        | Propagate session-specific values to maintain consistent state. |
| Parameter Synchronization | Keep parameters in sync across different automation components. |

### Usages in Automation Testing

| Use Case           | Description                                                  |
|--------------------|--------------------------------------------------------------|
| Test Data Handling | Copy values between test cases or steps to set up test data. |
| Environment Setup  | Move configuration parameters to prepare test environments.  |
| Dynamic Test Runs  | Transfer runtime values to support varied test scenarios.    |

## Examples

### Example No.1

### Session Parameter Copy Action

Takes the full text value of the session parameter `SourceParam` and stores it into another session parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as-is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Session}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.2

### Session to Application Parameter Copy Action

Takes the full text value of the session parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the application‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.3

### Session to Application Parameter Copy Action

Takes the full text value of the session parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the application‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Application}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.4

### Session to Machine Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the session parameter `SourceParam` and stores it into a machine‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the machine‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Machine}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.5

### Session to User Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the session parameter `SourceParam` and stores it into a user‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the user‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:User}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.6

### Session to Process Parameter Copy Action

Takes the full text value of the session parameter `SourceParam` and stores it into a process‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the process‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    OnAttribute = "Session",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Process}}")
    .setOnAttribute("Session")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    onAttribute: "Session",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Session",
    "onElement": "SourceParam"
}
```
### Example No.7

### Application to Session Parameter Copy Action

Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a session‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Session}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.8

### Application to Application Parameter Copy Action in BotRepository

Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the target environment is valid; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.9

### Application to Application Parameter Copy Action

Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into another application‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Application}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.10

### Application to Machine Parameter Copy Action in BotRepository

Machine scopes are only valid on Windows environments.
Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a machine‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the machine‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Machine}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Machine}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Machine}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Machine}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Machine}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.11

### Application to Machine Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a machine‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the machine‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Machine}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.12

### Application to User Parameter Copy Action in BotRepository

User scopes are only valid on Windows environments.
Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a user‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the user‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:User}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:User}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:User}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.13

### Application to User Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a user‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:User}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.14

### Application to Process Parameter Copy Action in BotRepository

Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a process‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the process‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Process}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Process}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Process}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Process}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Process}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.15

### Application to Process Parameter Copy Action

Takes the full text value of the application‑scoped parameter `SourceParam` and stores it into a process‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    OnAttribute = "Application",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Process}}")
    .setOnAttribute("Application")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    onAttribute: "Application",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Application",
    "onElement": "SourceParam"
}
```
### Example No.16

### Machine to Session Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into a session‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Session}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.17

### Machine to Application Parameter Copy Action in BotRepository

Machine scopes are only valid on Windows environments.
Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the application‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.18

### Machine to Application Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Application}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.19

### Machine to Machine Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into another machine‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Machine}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.20

### Machine to User Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into a user‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:User}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.21

### Machine to Process Parameter Copy Action

Takes the full text value of the machine‑scoped parameter `SourceParam` and stores it into a process‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    OnAttribute = "Machine",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Process}}")
    .setOnAttribute("Machine")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    onAttribute: "Machine",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Machine",
    "onElement": "SourceParam"
}
```
### Example No.22

### User to Session Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into a session‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Session}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.23

### User to Application Parameter Copy Action in BotRepository

User scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the application‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.24

### User to Application Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Application}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.25

### User to Machine Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into a machine‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Machine}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.26

### User to User Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into another user‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:User}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.27

### User to Process Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the user‑scoped parameter `SourceParam` and stores it into a process‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    OnAttribute = "User",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Process}}")
    .setOnAttribute("User")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    onAttribute: "User",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "User",
    "onElement": "SourceParam"
}
```
### Example No.28

### Process to Session Parameter Copy Action

Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into a session‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Session}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Session}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```
### Example No.29

### Process to Application Parameter Copy Action in BotRepository

Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` within the `BotRepository` environment.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists and the application‑scoped target parameter can be written; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --Environment:BotRepository --TargetScope:Application}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```
### Example No.30

### Process to Application Parameter Copy Action

Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into an application‑scoped parameter named `TargetParam` in the default application environment `SystemParameters`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Application}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Application}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```
### Example No.31

### Process to Machine Parameter Copy Action

Machine scopes are only valid on Windows environments.
Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into a machine‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Machine}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Machine}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```
### Example No.32

### Process to User Parameter Copy Action

User scopes are only valid on Windows environments.
Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into a user‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:User}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:User}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```
### Example No.33

### Process to Process Parameter Copy Action

Takes the full text value of the process‑scoped parameter `SourceParam` and stores it into another process‑scoped parameter named `TargetParam`.
The operation uses the complete text value of `SourceParam`, including any whitespace or formatting.
No value transformation occurs; the entire text is copied as‑is.
The action succeeds only if `SourceParam` exists; otherwise, it fails.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyParameter",
    Argument = "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    OnAttribute = "Process",
    OnElement = "SourceParam"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyParameter")
    .setArgument("{{$ --TargetParameter:TargetParam --TargetScope:Process}}")
    .setOnAttribute("Process")
    .setOnElement("SourceParam");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyParameter",
    argument: "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    onAttribute: "Process",
    onElement: "SourceParam"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyParameter",
    "argument": "{{$ --TargetParameter:TargetParam --TargetScope:Process}}",
    "onAttribute": "Process",
    "onElement": "SourceParam"
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

Sets where to find the original value.
Options include Session, User, and others.
New options appear automatically when they are added.
No manual updates are needed to keep the list current.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the source parameter for the value copy.
The system uses this name to locate and copy the value.
Missing this setting stops the operation from running.

## Parameters

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Determines where parameters are stored and retrieved.
Each environment represents a different context for parameter values.
Only applies when Application scope is used.
No manual updates are needed when contexts change.

### Target Parameter (TargetParameter)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the parameter that will receive the copied value.
The system copies the source value into this parameter.
Copy operation cannot run without this parameter.

### Target Scope (TargetScope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | SetParameter      |

Automatically gathers available scope options from SetParameter plugins.
Each plugin adds a new scope like Session or User scope.
Options update on their own when plugins change.
This keeps your list of scopes current without manual updates.

## Scope

* Any