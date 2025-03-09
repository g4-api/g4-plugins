# Get Driver Type Name (Get-DriverTypeName)

[Table of Content](../Home.md)  

~12 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Get-DriverTypeName` plugin is designed for RPA and automation testing workflows, providing the capability to retrieve the type name of the WebDriver instance in use. 
This plugin is essential for customizing actions or logging details based on the specific WebDriver, enhancing the flexibility and management of automation processes.

### Key Features and Functionality

| Feature                  | Description                                                                                                           |
|--------------------------|-----------------------------------------------------------------------------------------------------------------------|
| WebDriver Type Retrieval | Retrieves the type name of the WebDriver instance, providing insight into the WebDriver used in automation workflows. |
| Dynamic Value Injection  | Enables the insertion of the WebDriver type name into automation steps for customized and adaptable workflows.        |

### Usages in RPA

| Usage                  | Description                                                                                                    |
|------------------------|----------------------------------------------------------------------------------------------------------------|
| Logging and Reporting  | Logs the WebDriver type used in RPA processes, enhancing visibility and debugging capabilities.                |
| Workflow Customization | Customizes automation actions based on the WebDriver type, improving adaptability and dynamic behavior in RPA. |

### Usages in Automation Testing

| Usage              | Description                                                                                                                |
|--------------------|----------------------------------------------------------------------------------------------------------------------------|
| Test Logging       | Logs the WebDriver type during test execution, aiding in debugging and ensuring consistency across different environments. |
| Test Customization | Customizes test steps based on the WebDriver type, allowing for more flexible and robust testing scenarios.                |

## Examples

### Example No.1

Retrieve the WebDriver type name and log it.
This example uses the `Get-DriverTypeName` plugin to log the WebDriver type name within the automation workflow.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The type name of the WebDriver is {{$Get-DriverTypeName}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The type name of the WebDriver is {{$Get-DriverTypeName}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The type name of the WebDriver is {{$Get-DriverTypeName}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The type name of the WebDriver is {{$Get-DriverTypeName}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The type name of the WebDriver is {{$Get-DriverTypeName}}"
}
```
### Example No.2

Retrieve a specific portion of the WebDriver type name using a regex pattern and log it.
This example shows how to use the `Get-DriverTypeName` plugin with a custom regex pattern to log a matched portion of the WebDriver type name.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The matched pattern of the WebDriver type name is {{$Get-DriverTypeName --Pattern:"^Open"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The matched pattern of the WebDriver type name is {{$Get-DriverTypeName --Pattern:"^Open"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The matched pattern of the WebDriver type name is {{$Get-DriverTypeName --Pattern:"^Open"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The matched pattern of the WebDriver type name is {{$Get-DriverTypeName --Pattern:"^Open"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The matched pattern of the WebDriver type name is {{$Get-DriverTypeName --Pattern:"^Open"}}"
}
```

## Parameters

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regex pattern used to match and extract a portion of the WebDriver type name.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#new-session](https://www.w3.org/TR/webdriver/#new-session)
