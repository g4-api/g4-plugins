# Get Window Handle (Get-WindowHandle)

[Table of Content](../Home.md)  

~13 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `Get-WindowHandle` plugin is designed to retrieve the unique identifier (window handle) of the current browser window or a specific window based on its index within automation workflows. 
This functionality is crucial for managing and interacting with browser windows or tabs, enabling precise control over multi-window scenarios in browser-based automation tasks.

### Key Features and Functionality

| Feature                 | Description                                                                                            |
|-------------------------|--------------------------------------------------------------------------------------------------------|
| Current Window Handle   | Retrieves the unique identifier (handle) of the current browser window.                                |
| Indexed Window Handle   | Retrieves the window handle of a specific window or tab based on its index.                            |
| Dynamic Window Handling | Facilitates switching and interacting with multiple windows or tabs using the retrieved window handle. |
| Pattern Matching        | Supports regex pattern matching to extract specific portions of the window handle if needed.           |
| Error Handling Support  | Handles scenarios where the specified window handle is unavailable, ensuring robust workflows.         |

### Usages in RPA

| Usage             | Description                                                                                             |
|-------------------|---------------------------------------------------------------------------------------------------------|
| Window Navigation | Navigate through web applications by identifying and interacting with specific browser windows or tabs. |
| Data Extraction   | Extract data from particular browser windows or tabs for processing in RPA workflows.                   |
| Error Recovery    | Handle scenarios where window interactions are disrupted, ensuring smooth continuation of RPA tasks.    |

### Usages in Automation Testing

| Usage                 | Description                                                                                                   |
|-----------------------|---------------------------------------------------------------------------------------------------------------|
| Window Verification   | Verify that expected windows or tabs are opened during test executions.                                       |
| Cross-Browser Testing | Manage window interactions effectively across multiple browsers.                                              |
| Parallel Testing      | Enable simultaneous testing of multiple windows or tabs by accurately identifying and switching between them. |

## Examples

### Example No.1

Retrieve the window handle of the current browser window and log the result. 
This example demonstrates how to use the `Get-WindowHandle` plugin with the `WriteLog` plugin to write the window handle to the host.
You can optionally use the `--Pattern` parameter to match a specific pattern in the window handle.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The window handle is {{$Get-WindowHandle --Pattern:".*"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The window handle is {{$Get-WindowHandle --Pattern:".*"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The window handle is {{$Get-WindowHandle --Pattern:".*"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The window handle is {{$Get-WindowHandle --Pattern:".*"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The window handle is {{$Get-WindowHandle --Pattern:".*"}}"
}
```
### Example No.2

Retrieve the window handle of a specific browser window by index and switch to that window. 
This example shows how to use the `Get-WindowHandle` plugin with the `SwitchWindow` plugin to switch to a browser window identified by the retrieved window handle.
The `--Pattern` parameter can be used to match a specific portion of the window handle.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchWindow",
    Argument = "Switching to the window with handle {{$Get-WindowHandle --Index:1 --Pattern:".*"}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchWindow")
    .setArgument("Switching to the window with handle {{$Get-WindowHandle --Index:1 --Pattern:".*"}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchWindow",
    argument: "Switching to the window with handle {{$Get-WindowHandle --Index:1 --Pattern:".*"}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchWindow",
    "argument": "Switching to the window with handle {{$Get-WindowHandle --Index:1 --Pattern:".*"}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchWindow",
    "argument": "Switching to the window with handle {{$Get-WindowHandle --Index:1 --Pattern:".*"}}"
}
```

## Parameters

### Index (Index)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Specifies the index of the window handle to retrieve. If not provided, the current window handle is retrieved.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Specifies the regex pattern used to match and extract the desired portion of the window handle.

## Scope

* Any
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#get-window-handle](https://www.w3.org/TR/webdriver/#get-window-handle)
