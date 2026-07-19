# Get Parameter (Get-Parameter)

[Table of Content](../Home.md)  

~25 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Fetches configuration and secret values from defined storage scopes at runtime.
It instantly substitutes placeholders with live data so automation flows keep moving without manual edits.
It can safely decode or decrypt values that were stored in base-64 or encrypted form by the RegisterParameter plugin.
This keeps configuration handling secure, consistent, and environment-aware across robots, tests, and services.

### Key Features and Functionality

| Feature                     | Description                                                                             |
|-----------------------------|-----------------------------------------------------------------------------------------|
| Environment-Scope Retrieval | Pulls parameters from Application, User, Machine, Process, or Session scopes.           |
| Environment Targeting       | Directs lookups to specific stores such as test, staging, or prod for clean separation. |
| Dynamic Injection           | Replaces tokens in workflow inputs or outputs on the fly to keep data current.          |
| Encoding Support            | Decodes or encodes base-64 strings to ensure safe transport and storage.                |
| Encryption Support          | Decrypts values protected by RegisterParameter when given a valid EncryptionKey.        |

### Usages in RPA

| Use Case                        | Description                                                                          |
|---------------------------------|--------------------------------------------------------------------------------------|
| Task Orchestration              | Supplies critical runtime parameters so multi-step bots execute with the right data. |
| Environment-Specific Automation | Adapts bots to different environments by pulling the matching configuration set.     |

### Usages in Automation Testing

| Use Case                        | Description                                                                            |
|---------------------------------|----------------------------------------------------------------------------------------|
| Data-Driven Testing             | Retrieves test data parameters to generate scenarios on demand.                        |
| Configuration Management        | Injects current runtime settings so tests adjust automatically to changing conditions. |
| Environment-Based Customization | Pulls environment-specific values to tailor test runs for accurate coverage.           |

## Examples

### Example No.1

### Retrieve parameter value and inject it into an input

The example fetches the text from the AppVersion parameter stored in the Application scope of the SystemParameters environment.
A macro invocation {{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}} is applied to the argument attribute.
The SendKeys plugin consumes the macro’s output and sends the resulting text to the element located by the CSS selector #appVersionInput.
The action passes when the input receives the expected version string.

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

### Retrieve parameter value and inject it into an input

The example fetches the text from the `AppVersion` parameter stored in the *Application* scope of the `SystemParameters` environment.
A macro invocation `{{$Get-Parameter --Name:AppVersion --Scope:Application --Environment:SystemParameters}}` is applied to the `argument` attribute.
The `SendKeys` plugin consumes the macro’s output and sends the resulting text to the element located by the CSS selector `#appVersionInput`.
The action passes when the input receives the expected version string.

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
### Example No.3

### Retrieve parameter value and inject it into an input

The example fetches the text from the Email parameter stored in the User scope.
A macro invocation {{$Get-Parameter --Name:Email --Scope:User}} is applied to the argument attribute.
The SendKeys plugin consumes the macro’s output and sends the resulting text to the element located by the CSS selector #emailInput.
The action passes when the input receives the expected email address.

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

### Retrieve parameter value and inject it into an input

The example fetches the text from the `MachineName` parameter stored in the *Machine* scope.
A macro invocation `{{$Get-Parameter --Name:MachineName --Scope:Machine}}` is applied to the `argument` attribute.
The `SendKeys` plugin consumes the macro’s output and sends the resulting text to the element located by the CSS selector `#machineNameInput`.
The action passes when the input receives the expected machine name.

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

### Retrieve parameter value and inject it into an input

The example fetches the text from the ProcessId parameter stored in the Process scope.
A macro invocation {{$Get-Parameter --Name:ProcessId --Scope:Process}} is applied to the argument attribute.
The SendKeys plugin consumes the macro’s output and sends the resulting text to the element located by the CSS selector #processIdInput.
The action passes when the input receives the expected process ID.

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
### Example No.6

### Retrieve and decrypt parameter value, then inject it into an input

The example fetches the encrypted text from the SecretParam parameter stored in the Application scope of the SystemParameters environment.
A macro invocation {{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}} is applied to the argument attribute.
The macro evaluates to the decrypted secret string, which the SendKeys plugin consumes and sends to the element located by the CSS selector #secretInput.
The action passes when the input receives the expected secret value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}}",
    Locator = "CssSelector",
    OnElement = "#secretInput"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}}")
    .setLocator("CssSelector")
    .setOnElement("#secretInput");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}}",
    locator: "CssSelector",
    onElement: "#secretInput"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#secretInput"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Get-Parameter --Name:SecretParam --Scope:Application --Environment:SystemParameters --EncryptionKey:myEncryptionKey}}",
    "locator": "CssSelector",
    "onElement": "#secretInput"
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

Identifies the parameter whose value you want to fetch.
Accurate naming ensures the plugin locates the correct stored value.

### Scope (Scope)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Session           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | GetParameter      |

Indicates the storage scope to search for the parameter.
Accepts ‘Application’, ’User’, ‘Machine’, ’Process’, or ‘Session’.
Omit this property to fall back to the ‘Session’ scope.

### Environment (Environment)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Designates the environment collection that holds the parameter.
Defaults to ‘SystemParameters’ when the property is not supplied.

### Encryption Key (EncryptionKey)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Provides the symmetric key used to decrypt secure parameter values.
Include this key only when the value was encrypted by the RegisterParameter plugin.

## Scope

* Any