# New Guid (New-Guid)

[Table of Content](../Home.md)  

~25 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

The NewGuid macro plugin generates a new GUID (Globally Unique Identifier) within automation workflows, providing a unique identifier for various tasks.

### Purpose

The primary purpose of the NewGuid macro plugin is to generate unique identifiers in the form of GUIDs. These identifiers are crucial for various automation tasks that require unique references or tracking.

### Key Features

| Feature                      | Description                                                                                     |
|------------------------------|-------------------------------------------------------------------------------------------------|
| Unique Identifier Generation | Generates unique GUIDs that can be used as identifiers for elements, transactions, or entities. |
| Automation Integration       | Integrates seamlessly with automation workflows, providing dynamic and unique identifiers.      |

### Usages in RPA

| Usage                  | Description                                                                    |
|------------------------|--------------------------------------------------------------------------------|
| Element Identification | Use generated GUIDs to uniquely identify elements within automation processes. |
| Transaction Tracking   | Track transactions or activities using unique GUIDs for reference.             |

### Usages in Automation Testing

| Usage                | Description                                                                    |
|----------------------|--------------------------------------------------------------------------------|
| Data Generation      | Generate unique test data for testing scenarios.                               |
| Test Case Management | Use GUIDs to manage and track test cases within automation testing frameworks. |

### Conclusion

The NewGuid macro plugin offers a straightforward solution for generating unique identifiers within automation workflows and testing scenarios. By providing GUIDs, it ensures uniqueness and facilitates efficient automation and testing processes.

## Examples

### Example No.1

This example demonstrates the usage of the `NewGuid` macro plugin to generate a new GUID with the `N` format and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated GUID with the `N` format. For example, `{{$New-Guid --Format:N}}`.                                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated GUID with the `N` format (32 digits) as keystrokes to the element specified by the CssSelector value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:N}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:N}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:N}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:N}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:N}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

This example demonstrates the usage of the `NewGuid` macro plugin to generate a new GUID with the `D` format and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated GUID with the `D` format. For example, `{{$New-Guid --Format:D}}`.                                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated GUID with the `D` format (32 digits separated by hyphens) as keystrokes to the element specified by the CssSelector value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:D}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:D}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:D}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.3

This example demonstrates the usage of the `NewGuid` macro plugin to generate a new GUID with the `B` format and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated GUID with the `B` format. For example, `{{$New-Guid --Format:B}}`.                                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated GUID with the `B` format (32 digits separated by hyphens, enclosed in braces) as keystrokes to the element specified by the CssSelector value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:B}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:B}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:B}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.4

This example demonstrates the usage of the `NewGuid` macro plugin to generate a new GUID with the `P` format and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated GUID with the `P` format. For example, `{{$New-Guid --Format:P}}`.                                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated GUID with the `P` format (32 digits separated by hyphens, enclosed in parentheses) as keystrokes to the element specified by the CssSelector value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:P}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:P}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:P}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:P}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:P}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.5

This example demonstrates the usage of the `NewGuid` macro plugin to generate a new GUID with the `X` format and send it as keystrokes to an element within an automation workflow.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element.                                       |
| onElement  | Specifies the value of the locator mechanism used to identify the target element.                                                  |
| argument   | Specifies the generated GUID with the `X` format. For example, `{{$New-Guid --Format:X}}`.                                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the generated GUID with the `X` format (four hexadecimal values enclosed in braces) as keystrokes to the element specified by the CssSelector value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:X}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:X}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:X}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:X}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:X}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.6

This example demonstrates the usage of the `NewGuid` macro plugin with a custom regex pattern to extract the first 8 alphanumeric characters of the GUID.

| Field      | Description                                                                                                                                                                           |
|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `WriteLog`. This signifies the action of writing information to the host.                                                      |
| argument   | Specifies the log message, including the matched pattern of the GUID retrieved by the `NewGuid` plugin with the custom regex pattern. For example, `{{$New-Guid --Pattern:^\w{8}}}`. |

This example instructs the automation system to utilize the `WriteLog` plugin to write information about the matched pattern of the GUID being used to the host.
The retrieved matched pattern, which consists of the first 8 alphanumeric characters of the GUID, will be dynamically inserted into the log message, providing valuable insight into the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
}
```

## Parameters

### Format (Format)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | D                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the format of the generated GUID. If not specified, the default format is 'D'.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regex pattern used to match and extract the desired portion of the generated GUID.

## Scope

* Any