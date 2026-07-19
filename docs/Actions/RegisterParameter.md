# Register Parameter (RegisterParameter)

[Table of Content](../Home.md)  

~367 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Saves and manages named data in automation workflows. Captures values from user input or elements, stores them in a chosen scope such as session or application, and generates a `SetParameter` action so the data can be reused in downstream steps.

### Key Features and Functionality

| Feature             | Description                                                                        |
|---------------------|------------------------------------------------------------------------------------|
| Parameter Capture   | Get a value from a user argument or an element.                                    |
| Scope Selection     | Choose where to store the value (session, application, machine, user, or process). |
| Environment Targets | Handle parameters across different environments.                                   |
| Value Filtering     | Apply a regular expression to extract or transform parts of the value.             |
| Value Encoding      | Convert the final value into Base64 format.                                        |
| Action Creation     | Generate and send the SetParameter command for the stored value.                   |
| Value Encryption    | Optionally encrypt the value using a provided encryption key.                      |

### Usages in RPA

| Use Case             | Description                                                        |
|----------------------|--------------------------------------------------------------------|
| Data Handoff         | Save data from one automation step to use in later steps.          |
| Environment Setup    | Register settings like URLs or credentials before running actions. |
| Value Extraction     | Use regex to filter and store data from web pages.                 |
| Secure Data Handling | Encrypt and save sensitive values within the workflow.             |

### Usages in Automation Testing

| Use Case                  | Description                                                  |
|---------------------------|--------------------------------------------------------------|
| Test Data Setup           | Store input values needed for automated test cases.          |
| Environment Configuration | Register URLs or credentials for test environments.          |
| Runtime Parameterization  | Save variables at runtime to drive different test scenarios. |
| Sensitive Data Handling   | Encrypt and manage tokens or keys for secure test execution. |

## Examples

### Example No.1

### RegisterParameter: Application Scope

Register a parameter named `parameterName` with the value `parameterValue` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Application}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Application}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Application}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application}}"
}
```
### Example No.2

### RegisterParameter: Application Scope with Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Application --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.3

### RegisterParameter: Application Scope with Development Environment

Register a parameter named `parameterName` with the value `parameterValue` in the `Application` scope for the `Development` environment.
After execution, the parameter is available in the Application scope for subsequent actions.

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
### Example No.4

### RegisterParameter: Application Scope with Development Environment and Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.5

### RegisterParameter: Machine Scope

Register a parameter named `parameterName` with the value `parameterValue` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Machine}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine}}"
}
```
### Example No.6

### RegisterParameter: Machine Scope with Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Machine --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Machine --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.7

### RegisterParameter: Process Scope

Register a parameter named `parameterName` with the value `parameterValue` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Process}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Process}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Process}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Process}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Process}}"
}
```
### Example No.8

### RegisterParameter: Process Scope with Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Process --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Process --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Process --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Process --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Process --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.9

### RegisterParameter: Session Scope

Register a parameter named `parameterName` with the value `parameterValue` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

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
### Example No.10

### RegisterParameter: Session Scope with Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:Session --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:Session --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:Session --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Session --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:Session --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.11

### RegisterParameter: User Scope

Register a parameter named `parameterName` with the value `parameterValue` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:User}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:User}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:User}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:User}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:User}}"
}
```
### Example No.12

### RegisterParameter: User Scope with Encryption

Register a parameter named `parameterName` with the value `parameterValue` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Value:parameterValue --Scope:User --EncryptionKey:myEncryptionKey}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Value:parameterValue --Scope:User --EncryptionKey:myEncryptionKey}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Value:parameterValue --Scope:User --EncryptionKey:myEncryptionKey}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:User --EncryptionKey:myEncryptionKey}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Value:parameterValue --Scope:User --EncryptionKey:myEncryptionKey}}"
}
```
### Example No.13

### RegisterParameter: Application Scope via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.14

### RegisterParameter: Application Scope via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.15

### RegisterParameter: Application Scope via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.16

### RegisterParameter: Application Scope via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.17

### RegisterParameter: Application Scope via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.18

### RegisterParameter: Application Scope via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.19

### RegisterParameter: Application Scope with Development Environment via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope for the `Development` environment.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.20

### RegisterParameter: Application Scope with Development Environment via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.21

### RegisterParameter: Application Scope with Development Environment via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope for the `Development` environment.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.22

### RegisterParameter: Application Scope with Development Environment via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.23

### RegisterParameter: Application Scope with Development Environment via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope for the `Development` environment.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.24

### RegisterParameter: Application Scope with Development Environment via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.25

### RegisterParameter: Machine Scope via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.26

### RegisterParameter: Machine Scope via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.27

### RegisterParameter: Machine Scope via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.28

### RegisterParameter: Machine Scope via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.29

### RegisterParameter: Machine Scope via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.30

### RegisterParameter: Machine Scope via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.31

### RegisterParameter: Process Scope via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.32

### RegisterParameter: Process Scope via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.33

### RegisterParameter: Process Scope via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.34

### RegisterParameter: Process Scope via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.35

### RegisterParameter: Process Scope via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.36

### RegisterParameter: Process Scope via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.37

### RegisterParameter: Session Scope via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.38

### RegisterParameter: Session Scope via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.39

### RegisterParameter: Session Scope via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.40

### RegisterParameter: Session Scope via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.41

### RegisterParameter: Session Scope via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.42

### RegisterParameter: Session Scope via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.43

### RegisterParameter: User Scope via CSS Selector

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

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
### Example No.44

### RegisterParameter: User Scope via CSS Selector with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId"
}
```
### Example No.45

### RegisterParameter: User Scope via XPath

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.46

### RegisterParameter: User Scope via XPath with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']"
}
```
### Example No.47

### RegisterParameter: User Scope via Id Locator

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.48

### RegisterParameter: User Scope via Id Locator with Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId"
}
```
### Example No.49

### RegisterParameter: Application Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.50

### RegisterParameter: Application Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.51

### RegisterParameter: Application Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.52

### RegisterParameter: Application Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.53

### RegisterParameter: Application Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.54

### RegisterParameter: Application Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.55

### RegisterParameter: Application Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.56

### RegisterParameter: Application Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.57

### RegisterParameter: Application Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.58

### RegisterParameter: Application Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.59

### RegisterParameter: Application Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Application` scope.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.60

### RegisterParameter: Application Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.61

### RegisterParameter: Machine Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.62

### RegisterParameter: Machine Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.63

### RegisterParameter: Machine Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.64

### RegisterParameter: Machine Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.65

### RegisterParameter: Machine Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Machine` scope.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.66

### RegisterParameter: Machine Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.67

### RegisterParameter: Process Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.68

### RegisterParameter: Process Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.69

### RegisterParameter: Process Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.70

### RegisterParameter: Process Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.71

### RegisterParameter: Process Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Process` scope.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.72

### RegisterParameter: Process Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.73

### RegisterParameter: Session Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

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
### Example No.74

### RegisterParameter: Session Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.75

### RegisterParameter: Session Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.76

### RegisterParameter: Session Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.77

### RegisterParameter: Session Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Session` scope.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.78

### RegisterParameter: Session Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.79

### RegisterParameter: User Scope via CSS Selector (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.80

### RegisterParameter: User Scope via CSS Selector (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by CSS selector `#linkId` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "#linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("#linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "#linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "#linkId"
}
```
### Example No.81

### RegisterParameter: User Scope via XPath (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.82

### RegisterParameter: User Scope via XPath (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by XPath `//a[@id='linkId']` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    OnAttribute = "href",
    OnElement = "//a[@id='linkId']"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setOnAttribute("href")
    .setOnElement("//a[@id='linkId']");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    onAttribute: "href",
    onElement: "//a[@id='linkId']"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onAttribute": "href",
    "onElement": "//a[@id='linkId']"
}
```
### Example No.83

### RegisterParameter: User Scope via Id Locator (href attribute)

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `User` scope.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.84

### RegisterParameter: User Scope via Id Locator (href attribute) with Encryption

Register a parameter named `parameterName` from the href attribute of the element identified by Id `linkId` in the `User` scope and apply encryption using the key `myEncryptionKey`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnAttribute = "href",
    OnElement = "linkId"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnAttribute("href")
    .setOnElement("linkId");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onAttribute: "href",
    onElement: "linkId"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onAttribute": "href",
    "onElement": "linkId"
}
```
### Example No.85

### RegisterParameter: Application Scope via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.86

### RegisterParameter: Application Scope via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.87

### RegisterParameter: Application Scope via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.88

### RegisterParameter: Application Scope via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.89

### RegisterParameter: Application Scope via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.90

### RegisterParameter: Application Scope via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.91

### RegisterParameter: Application Scope with Development Environment via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope for the `Development` environment.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.92

### RegisterParameter: Application Scope with Development Environment via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.93

### RegisterParameter: Application Scope with Development Environment via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope for the `Development` environment.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.94

### RegisterParameter: Application Scope with Development Environment via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.95

### RegisterParameter: Application Scope with Development Environment via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope for the `Development` environment.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.96

### RegisterParameter: Application Scope with Development Environment via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Application` scope for the `Development` environment and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Application scope for the Development environment for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Application --Environment:Development --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.97

### RegisterParameter: Machine Scope via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Machine` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.98

### RegisterParameter: Machine Scope via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.99

### RegisterParameter: Machine Scope via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Machine` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.100

### RegisterParameter: Machine Scope via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.101

### RegisterParameter: Machine Scope via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Machine` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.102

### RegisterParameter: Machine Scope via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Machine` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Machine scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Machine --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.103

### RegisterParameter: Process Scope via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Process` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.104

### RegisterParameter: Process Scope via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.105

### RegisterParameter: Process Scope via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Process` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.106

### RegisterParameter: Process Scope via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.107

### RegisterParameter: Process Scope via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Process` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.108

### RegisterParameter: Process Scope via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Process` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Process scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Process --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.109

### RegisterParameter: Session Scope via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Session` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

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
### Example No.110

### RegisterParameter: Session Scope via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.111

### RegisterParameter: Session Scope via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Session` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.112

### RegisterParameter: Session Scope via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.113

### RegisterParameter: Session Scope via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Session` scope.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.114

### RegisterParameter: Session Scope via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `Session` scope and apply encryption using the key `myEncryptionKey`.
A regular expression `\d+` is applied to the inner text to extract matching digits into a capture group.
After execution, the parameter is available in the Session scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:Session --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.115

### RegisterParameter: User Scope via CSS Selector with Regex

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `User` scope using the regex `\d+` to extract digits.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.116

### RegisterParameter: User Scope via CSS Selector with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by CSS selector `#elementId` in the `User` scope, apply encryption using the key `myEncryptionKey`, and extract digits using the regex `\d+`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#elementId",
    "regularExpression": "\d+"
}
```
### Example No.117

### RegisterParameter: User Scope via XPath with Regex

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `User` scope using the regex `\d+` to extract digits.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.118

### RegisterParameter: User Scope via XPath with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by XPath `//a[@id='elementId']` in the `User` scope, apply encryption using the key `myEncryptionKey`, and extract digits using the regex `\d+`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    OnElement = "//a[@id='elementId']",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setOnElement("//a[@id='elementId']")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    onElement: "//a[@id='elementId']",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "onElement": "//a[@id='elementId']",
    "regularExpression": "\d+"
}
```
### Example No.119

### RegisterParameter: User Scope via Id Locator with Regex

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `User` scope using the regex `\d+` to extract digits.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```
### Example No.120

### RegisterParameter: User Scope via Id Locator with Regex and Encryption

Register a parameter named `parameterName` from the inner text of the element identified by Id `elementId` in the `User` scope, apply encryption using the key `myEncryptionKey`, and extract digits using the regex `\d+`.
After execution, the parameter is available in the User scope for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    Locator = "Id",
    OnElement = "elementId",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}")
    .setLocator("Id")
    .setOnElement("elementId")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    locator: "Id",
    onElement: "elementId",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:parameterName --Scope:User --EncryptionKey:myEncryptionKey}}",
    "locator": "Id",
    "onElement": "elementId",
    "regularExpression": "\d+"
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

Use this value to name the data that gets saved.
The name can be a fixed term or a dynamic expression.
A clear name makes it easier to find and reuse the saved data later.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Choose how to find the element that holds the data.
XPath is used when no other method is given.
A precise choice helps capture the correct data.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Pick an attribute that holds the data you need.
It will read the attribute's value from the element.
Choosing the right attribute ensures the correct data is captured.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Select the element that contains the data when no value is given directly.
It will read the data from that element.
Pointing to the right element ensures the correct information is used.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Define a text pattern to run on the value before saving.
Only the parts that match the pattern are kept.
The result is then turned into Base64 so it can be stored safely.

## Parameters

### Name (Name)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Label used to store the parameter value.
Clear labels make it easy to find and update saved data later.
Fixed text or expressions enable dynamic label creation.

### Scope (Scope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | SetParameter      |

Location where the parameter is saved.
Options include session memory, application storage, machine settings, user profile, or process memory.
The list adds new scopes automatically when they become available.
Automatic updates ensure the setup stays current without manual changes.

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | SystemParameters  |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Environment that defines where parameter values apply.
Environments separate settings for different projects or stages.
Separate environments prevent test values from mixing with live data.

### Value (Value)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Value that the plugin saves as a parameter.
Text, numbers, or expressions can be stored as the value.
Correct values ensure scripts can reuse data accurately.

### Encryption Key (EncryptionKey)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Secret key used to encrypt the saved data.
Encryption protects sensitive information during storage.
Data stored without encryption remains in plain text.

## Scope

* Any