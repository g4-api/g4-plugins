# New Window (NewWindow)

[Table of Content](../Home.md)  

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `NewWindow` plugin is to automate the opening of a new browser window or tab. 
This plugin provides a mechanism to programmatically open a new browser window or tab, which can be part of automated workflows or tests.

### Key Features and Functionality

| Feature             | Description                                                                 |
|---------------------|-----------------------------------------------------------------------------|
| Open New Window/Tab | Automates the opening of a new browser window or tab.                       |
| Customizable Type   | Allows specifying the type of new window to open (e.g., `tab` or `window`). |

### Usages in RPA

| Usage                  | Description                                                                                  |
|------------------------|----------------------------------------------------------------------------------------------|
| Multi-Window Workflows | Automating workflows that require interacting with multiple browser windows or tabs.         |
| Data Collection        | Opening a new tab to collect data from another source while keeping the original tab intact. |
| Navigation Automation  | Navigating to a different URL in a new window or tab as part of an automated process.        |

### Usages in Automation Testing

| Usage                | Description                                                                  |
|----------------------|------------------------------------------------------------------------------|
| Multi-Window Testing | Testing web applications that involve multiple browser windows or tabs.      |
| UI Testing           | Verifying the behavior of web applications when opening new windows or tabs. |
| Functional Testing   | Ensuring that links and buttons correctly open new windows or tabs.          |

## Examples

### Example No.1

Open a new browser tab. 
This action simulates the behavior of a user manually opening a new tab in the browser. 
Useful for scenarios where you need to keep the current page open while navigating to a new page in a separate tab.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewWindow",
    Argument = "tab"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewWindow")
    .setArgument("tab");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewWindow",
    argument: "tab"
};
```

_**JSON**_

```js
{
    "pluginName": "NewWindow",
    "argument": "tab"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewWindow",
    "argument": "tab"
}
```
### Example No.2

Open a new browser window. 
This action is similar to a user opening a completely new browser window, separate from the current one. 
It is helpful for tests or automation workflows that need to interact with multiple browser windows independently.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewWindow",
    Argument = "window"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewWindow")
    .setArgument("window");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewWindow",
    argument: "window"
};
```

_**JSON**_

```js
{
    "pluginName": "NewWindow",
    "argument": "window"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewWindow",
    "argument": "window"
}
```
### Example No.3

Open a new browser tab. 
If no specific argument is provided, the default action is to open a new tab. 
This is useful for creating additional tabs without specifying the type explicitly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewWindow"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewWindow");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "NewWindow"
};
```

_**JSON**_

```js
{
    "pluginName": "NewWindow"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "NewWindow"
}
```

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | tab               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Providing additional instructions or parameters to control the behavior of the window opening action.

## Parameters

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of new window to open (`tab` or `window`).

#### Values

##### Tab

Open a new browser tab.
##### Window

Open a new browser window.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#new-window](https://www.w3.org/TR/webdriver/#new-window)
