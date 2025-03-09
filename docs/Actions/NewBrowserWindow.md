# New Browser Window (NewBrowserWindow)

[Table of Content](../Home.md)  

~18 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `NewBrowserWindow` plugin is to automate the opening of new browser windows or tabs. 
This plugin provides a mechanism to programmatically open one or more new browser windows or tabs with specified URLs, which can be part of automated workflows or tests.

### Key Features and Functionality

| Feature                | Description                                                                                     |
|------------------------|-------------------------------------------------------------------------------------------------|
| Open New Windows/Tabs  | Automates the opening of new browser windows or tabs using specified URLs.                      |
| URL Targeting          | Retrieves URLs from specified web elements or attributes for opening new windows.               |
| Customizable Target    | Allows customization of the target attribute (`_blank`, `_self`, etc.) for new windows or tabs. |
| Multiple Windows/Tabs  | Supports opening multiple browser windows or tabs in a single action.                           |

### Usages in RPA

| Usage                  | Description                                                                               |
|------------------------|-------------------------------------------------------------------------------------------|
| Multi-Window Workflows | Automating workflows that require interacting with multiple browser windows or tabs.      |
| Data Collection        | Opening multiple tabs to collect data from various sources simultaneously.                |
| Navigation Automation  | Navigating to different URLs in separate windows or tabs as part of an automated process. |

### Usages in Automation Testing

| Usage                | Description                                                                                |
|----------------------|--------------------------------------------------------------------------------------------|
| Multi-Window Testing | Testing web applications that involve multiple browser windows or tabs.                    |
| UI Testing           | Verifying the behavior of web applications when links open new windows or tabs.            |
| Functional Testing   | Ensuring that links and buttons correctly open new windows or tabs with specified content. |

## Examples

### Example No.1

Open a new browser window or tab with the URL `http://example.com`. 
The new window or tab will be opened in a new browsing context (`_blank`).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Argument = "{{$ --Url:http://example.com --Amount:1 --Target:_blank}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setArgument("{{$ --Url:http://example.com --Amount:1 --Target:_blank}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    argument: "{{$ --Url:http://example.com --Amount:1 --Target:_blank}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:1 --Target:_blank}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:1 --Target:_blank}}"
}
```
### Example No.2

Open three new browser windows or tabs with the URL `http://example.com`. 
The new windows or tabs will be opened in the same browsing context (`_self`).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Argument = "{{$ --Url:http://example.com --Amount:3 --Target:_self}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setArgument("{{$ --Url:http://example.com --Amount:3 --Target:_self}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    argument: "{{$ --Url:http://example.com --Amount:3 --Target:_self}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:3 --Target:_self}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:3 --Target:_self}}"
}
```
### Example No.3

Open two new browser windows or tabs with the URL `http://example.com`. 
This can be useful for testing the behavior of web applications when multiple new windows or tabs are opened simultaneously.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Argument = "{{$ --Url:http://example.com --Amount:2}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setArgument("{{$ --Url:http://example.com --Amount:2}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    argument: "{{$ --Url:http://example.com --Amount:2}}"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:2}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "argument": "{{$ --Url:http://example.com --Amount:2}}"
}
```
### Example No.4

Open a new browser window or tab using the URL retrieved from the element identified by the CSS selector `#LinkToOpen`. 
The new window or tab will be opened in a new browsing context (`_blank`). 
This example demonstrates the default behavior of opening a single new window or tab.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewBrowserWindow",
    Locator = "CssSelector",
    OnElement = "#LinkToOpen"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewBrowserWindow")
    .setLocator("CssSelector")
    .setOnElement("#LinkToOpen");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewBrowserWindow",
    locator: "CssSelector",
    onElement: "#LinkToOpen"
};
```

_**JSON**_

```js
{
    "pluginName": "NewBrowserWindow",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewBrowserWindow",
    "locator": "CssSelector",
    "onElement": "#LinkToOpen"
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
| **Value Type**    | String            |

Providing additional instructions or parameters to control the behavior of the window opening action.

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifying the type of locator used to identify the target element defined by the `OnElement` property.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Retrieves the URL from the specified attribute of the target element.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifying the target element from which the URL should be retrieved for opening the new browser window or tab.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Uses a regular expression to match and extract the desired part of the URL from the target element.

## Parameters

### Amount (Amount)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the number of new browser windows or tabs to open.

### Target (Target)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | _blank            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target attribute for the new browser windows or tabs. Possible values include `_blank`, `_self`, etc.

#### Values

##### Blank

Open the URL in a new tab or window.
##### Self

Open the URL in the current tab or window.
##### Parent

Open the URL in the parent frame.
##### Top

Open the URL in the topmost frame.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Uri        |

Specifies the URL to open in the new browser window or tab if no element is provided.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)
