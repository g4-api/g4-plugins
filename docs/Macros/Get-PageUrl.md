# Get Page Url (Get-PageUrl)

[Table of Content](../Home.md)  

~12 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Get-PageUrl` plugin is designed to retrieve the URL of the current web page within automation workflows. 
It enables dynamic actions based on the URL, making it a valuable tool for scenarios where navigation and validation of URLs are required.

### Key Features and Functionality

| Feature                | Description                                                                                     |
|------------------------|-------------------------------------------------------------------------------------------------|
| URL Retrieval          | Retrieves the URL of the current web page, allowing automation scripts to interact dynamically. |
| Dynamic Interaction    | Enables dynamic interaction with elements or navigation based on the retrieved URL.             |
| URL Verification       | Verifies that the correct URL is loaded during testing scenarios, ensuring accuracy.            |
| Regex-based Extraction | Supports regex patterns to extract specific portions of the URL for customized actions.         |

### Usages in RPA

| Usage                     | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| Navigation and Validation | Use the retrieved URL to navigate to specific pages and validate content dynamically.                  |
| Dynamic Interaction       | Interact with web elements based on the current URL, enhancing the adaptability of automation scripts. |
| URL Verification          | Ensure that the correct URLs are accessed during automation, improving test coverage and reliability.  |
| Parameterization          | Parameterize test steps based on URLs, providing flexibility in testing various scenarios.             |

### Usages in Automation Testing

| Usage               | Description                                                                              |
|---------------------|------------------------------------------------------------------------------------------|
| URL Logging         | Log the current URL during testing to track navigation and verify test flow accuracy.    |
| Conditional Testing | Perform conditional testing based on the retrieved URL, allowing for dynamic test flows. |

## Examples

### Example No.1

Retrieve the URL of the current web page and utilize it in a navigation scenario. 
This example demonstrates how to use the `Get-PageUrl` plugin with the `OpenUrl` plugin to navigate to the retrieved URL.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "OpenUrl",
    Argument = "{{$Get-PageUrl}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("OpenUrl")
    .setArgument("{{$Get-PageUrl}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "OpenUrl",
    argument: "{{$Get-PageUrl}}"
};
```

_**JSON**_

```js
{
    "pluginName": "OpenUrl",
    "argument": "{{$Get-PageUrl}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "OpenUrl",
    "argument": "{{$Get-PageUrl}}"
}
```
### Example No.2

Retrieve a specific portion of the URL using a custom regex pattern and log the result. 
This example demonstrates how to use the `Get-PageUrl` plugin with the `WriteLog` plugin to log the matched pattern from the URL.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The matched pattern of the URL is {{$Get-PageUrl --Pattern:"^https:\/\/example.com"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The matched pattern of the URL is {{$Get-PageUrl --Pattern:"^https:\/\/example.com"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The matched pattern of the URL is {{$Get-PageUrl --Pattern:"^https:\/\/example.com"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The matched pattern of the URL is {{$Get-PageUrl --Pattern:"^https:\/\/example.com"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The matched pattern of the URL is {{$Get-PageUrl --Pattern:"^https:\/\/example.com"}}"
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

Specifies the regex pattern used to match and extract the desired portion of the URL.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-current-url](https://www.w3.org/TR/webdriver/#get-current-url)
