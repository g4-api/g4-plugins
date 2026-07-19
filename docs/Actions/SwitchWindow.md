# Switch Window (SwitchWindow)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Switches WebDriver context to a different browser window or tab.
Mode selection is automatic: at runtime `int.TryParse(pluginData.Rule.Argument, out int index)` determines the path — a successful parse triggers the index path; a failed parse triggers the handle path.
No other parameters exist; the entire switching contract is expressed through a single `Argument` value.

### Key Features and Functionality

| Feature                  | Description                                                                                                                                  |
|--------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| Automatic Mode Selection | `int.TryParse` is the sole gate: integer strings use the index path; all other strings use the handle path. No explicit mode flag is needed. |
| Switch by Index          | When `Argument` parses as an integer, calls `WebDriver.SwitchTo().Window(index)` using the zero-based index — no handle resolution occurs.   |
| Switch by Handle         | When `Argument` is non-integer, calls `WebDriver.SwitchTo().Window(handle)` passing the raw string as a WebDriver window handle.             |

### Usages in RPA

| Usage                          | Description                                                                                                                        |
|--------------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Multi-Window Workflows         | Automates switching to a specific window or tab during complex workflows that span multiple browser contexts.                      |
| Data Collection Across Sources | Focuses driver context on a target window to extract or interact with content before returning to the main session.                |
| Pop-up Handling                | Switches to a newly opened pop-up window triggered by a page action, performs work, and returns to the parent tab.                 |
| Sequential Tab Processing      | Iterates through open tabs by incrementing the index argument, allowing bots to process each tab in order without storing handles. |

### Usages in Automation Testing

| Usage                | Description                                                                                                                            |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| UI Testing           | Validates application behavior across multiple windows or tabs by switching driver context as part of test flows.                      |
| End-to-End Testing   | Ensures comprehensive coverage by automating window switches that mirror real user interactions with the browser.                      |
| Handle-Based Control | Targets a specific window by its known handle for deterministic test isolation when multiple windows are open.                         |
| Window Order Testing | Verifies that the application opens and maintains windows in the expected order by switching via index and asserting content or state. |

## Examples

### Example No.1

### Switch to a window by index

Switch WebDriver context to the second open window or tab by passing its zero-based index `1` as the `Argument`.
When `Argument` parses as an integer, `WebDriver.SwitchTo().Window(index)` is called directly — no handle resolution occurs.
Index `0` targets the first window; `1` the second, and so on.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchWindow",
    Argument = "1"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchWindow")
    .setArgument("1");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchWindow",
    argument: "1"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchWindow",
    "argument": "1"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchWindow",
    "argument": "1"
}
```
### Example No.2

### Switch to a window by handle

Switch WebDriver context to the window identified by the handle `CDwindow-ABCD1234`.
When `Argument` cannot be parsed as an integer, the raw string is passed directly to `WebDriver.SwitchTo().Window(handle)`.
Obtain the handle from `WebDriver.WindowHandles` before invoking this plugin to ensure the value is current and valid.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchWindow",
    Argument = "CDwindow-ABCD1234"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchWindow")
    .setArgument("CDwindow-ABCD1234");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchWindow",
    argument: "CDwindow-ABCD1234"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchWindow",
    "argument": "CDwindow-ABCD1234"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchWindow",
    "argument": "CDwindow-ABCD1234"
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

Specifies the target window to switch to.
When the value parses as an integer, the plugin switches by zero-based window index via `WebDriver.SwitchTo().Window(index)`.
When the value is non-integer, the plugin passes the raw string to `WebDriver.SwitchTo().Window(handle)` as a WebDriver window handle.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#switch-to-window](https://www.w3.org/TR/webdriver/#switch-to-window)
