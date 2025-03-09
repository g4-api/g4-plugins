# Copy Resource (CopyResource)

[Table of Content](../Home.md)  

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

> [!IMPORTANT]
> When interacting with web resources, it's crucial to consider security aspects, such as handling sensitive data, authentication, and secure communication.

### Purpose

The primary purpose of the `CopyResource` plugin is to download data from a specified endpoint and save it to a local file. This can be used to retrieve resources like images, documents, or any other file types from web elements during automated workflows.

### Key Features and Functionality

| Feature             | Description                                                               |
|---------------------|---------------------------------------------------------------------------|
| Data Download       | Downloads data from specified endpoints and saves it to local files.      |
| Parallel Processing | Supports parallel processing to download multiple resources concurrently. |
| Custom Paths        | Allows specification of custom paths for saving downloaded resources.     |
| Regular Expression  | Uses regular expressions to extract and match URLs from web elements.     |

### Usages in RPA

| Usage               | Description                                                                                  |
|---------------------|----------------------------------------------------------------------------------------------|
| Data Collection     | Collect resources like images or documents from web pages for further processing or storage. |
| Workflow Automation | Automate the process of downloading necessary resources as part of a larger workflow.        |

### Usages in Automation Testing

| Usage               | Description                                                                                                    |
|---------------------|----------------------------------------------------------------------------------------------------------------|
| Resource Validation | Download and validate resources to ensure they are correctly served by the web application.                    |
| Performance Testing | Assess the performance of resource download times under different conditions.                                  |
| Regression Testing  | Ensure that resource download functionality works as expected after changes or updates to the web application. |

## Examples

### Example No.1

Use the `CopyResource` plugin to download images from a webpage and save them to a specified directory. The images' URLs are extracted from the `src` attribute of `img` elements matching the provided regular expression.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/downloaded_resources --Parallel:true}}",
    Locator = "CssSelector",
    OnAttribute = "src",
    OnElement = "img",
    RegularExpression = "https?:\/\/.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/downloaded_resources --Parallel:true}}")
    .setLocator("CssSelector")
    .setOnAttribute("src")
    .setOnElement("img")
    .setRegularExpression("https?:\/\/.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/downloaded_resources --Parallel:true}}",
    locator: "CssSelector",
    onAttribute: "src",
    onElement: "img",
    regularExpression: "https?:\/\/.*"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/downloaded_resources --Parallel:true}}",
    "locator": "CssSelector",
    "onAttribute": "src",
    "onElement": "img",
    "regularExpression": "https?:\/\/.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/downloaded_resources --Parallel:true}}",
    "locator": "CssSelector",
    "onAttribute": "src",
    "onElement": "img",
    "regularExpression": "https?:\/\/.*"
}
```
### Example No.2

Use the `CopyResource` plugin to download documents from a webpage in a sequential manner. The URLs are extracted from the `href` attribute of `a` elements.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/downloaded_documents}}",
    Locator = "CssSelector",
    OnAttribute = "href",
    OnElement = "a",
    RegularExpression = "https?:\/\/.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/downloaded_documents}}")
    .setLocator("CssSelector")
    .setOnAttribute("href")
    .setOnElement("a")
    .setRegularExpression("https?:\/\/.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/downloaded_documents}}",
    locator: "CssSelector",
    onAttribute: "href",
    onElement: "a",
    regularExpression: "https?:\/\/.*"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/downloaded_documents}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "a",
    "regularExpression": "https?:\/\/.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/downloaded_documents}}",
    "locator": "CssSelector",
    "onAttribute": "href",
    "onElement": "a",
    "regularExpression": "https?:\/\/.*"
}
```
### Example No.3

Use the `CopyResource` plugin to download all resources from `a` tags on a webpage. The URLs are extracted directly from the text content of the `a` tags.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CopyResource",
    Argument = "{{$ --Path:/home/user/all_resources}}",
    Locator = "CssSelector",
    OnElement = "a",
    RegularExpression = "https?:\/\/.*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CopyResource")
    .setArgument("{{$ --Path:/home/user/all_resources}}")
    .setLocator("CssSelector")
    .setOnElement("a")
    .setRegularExpression("https?:\/\/.*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CopyResource",
    argument: "{{$ --Path:/home/user/all_resources}}",
    locator: "CssSelector",
    onElement: "a",
    regularExpression: "https?:\/\/.*"
};
```

_**JSON**_

```js
{
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/all_resources}}",
    "locator": "CssSelector",
    "onElement": "a",
    "regularExpression": "https?:\/\/.*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CopyResource",
    "argument": "{{$ --Path:/home/user/all_resources}}",
    "locator": "CssSelector",
    "onElement": "a",
    "regularExpression": "https?:\/\/.*"
}
```

## Output Parameter

### Downloaded Files (DownloadedFiles)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Stores the list of file paths for the resources that were successfully downloaded. This allows further processing or validation within the workflow.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Uri|Expression    |

Specifies the details for the `CopyResource` request. 
It includes a template or variable structure `{{$...}}` to allow dynamic values. This allows passing parameters such as `Path` and `Parallel`.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the strategy or method used to locate the elements to use for downloading sources.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Used to specify and extract a specific attribute value from an HTML element. 
This is particularly relevant when dealing with web data, where elements can have associated attributes containing URLs or other relevant information.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Used to target elements using either XPath or CSS selectors, allowing the rule to locate and process specific elements within the HTML content.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Used for pattern matching and extraction of specific data from a text response. 
It allows for the definition of a regular expression that captures and extracts relevant information from the content retrieved by the HTTP request.

## Parameters

### Path (Path)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the path to the directory where the downloaded resources should be saved. If not provided, the current directory is used.

### Parallel (Parallel)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether to process the downloads in parallel. This can significantly speed up the process when downloading multiple resources.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#find-elements](https://www.w3.org/TR/webdriver/#find-elements)
