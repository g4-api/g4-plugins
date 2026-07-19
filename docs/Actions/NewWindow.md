# New Window (NewWindow)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Opens a new browser tab or window in the current WebDriver session by calling `WebDriver.SwitchTo().NewWindow()`, the W3C WebDriver native new-window command.
Unlike `NewBrowserWindow`, which uses JavaScript `window.open()`, `NewWindow` uses the browser driver's built-in context-creation mechanism — no URL, element, or JavaScript execution is required.
The new context opens blank and immediately becomes the active WebDriver window handle.
The `Argument` property controls whether a `tab` (default) or a `window` is created.

### Key Features and Functionality

| Feature          | Description                                                                                       |
|------------------|---------------------------------------------------------------------------------------------------|
| Native WebDriver | Uses `WebDriver.SwitchTo().NewWindow()` — the W3C standard command, not JavaScript execution.     |
| Tab or Window    | Opens either a new tab or a new browser window depending on the `Argument` value.                 |
| Default to Tab   | When `Argument` is absent or empty, a new tab is opened automatically.                            |
| Active Context   | The new tab or window immediately becomes the active WebDriver handle after the action completes. |

### Usages in RPA

| Use Case               | Description                                                                                                                                |
|------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Multi-Window Workflows | Open a new tab or window to begin a parallel navigation path while the original context remains reachable by handle.                       |
| Context Isolation      | Isolate a new browsing context from the current page for unrelated data collection or independent interaction.                             |
| Sequential Navigation  | After opening a new tab, switch back to the original handle to continue its workflow, then switch to the new handle when that step begins. |

### Usages in Automation Testing

| Use Case             | Description                                                                                               |
|----------------------|-----------------------------------------------------------------------------------------------------------|
| Multi-Window Testing | Verify that the application correctly handles workflows spanning multiple browser windows or tabs.        |
| Handle Count Testing | Assert that the expected number of window handles is present after opening a new tab or window.           |
| Window Type Testing  | Confirm that passing `tab` opens a tab and `window` opens a separate window, subject to browser behavior. |

## Examples

### Example No.1

### Open a new browser tab (default)

Calls `WebDriver.SwitchTo().NewWindow('tab')` via the W3C new-window command to open a new blank browser tab in the current WebDriver session.
No `Argument` is supplied so the action defaults to `tab`.
The new tab handle is appended to `driver.WindowHandles` and immediately becomes `driver.CurrentWindowHandle`.

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
### Example No.2

### Open a new browser window

Calls `WebDriver.SwitchTo().NewWindow('window')` via the W3C new-window command to open a new separate browser window in the current WebDriver session.
The `Argument` is set to `window` to request a distinct window rather than a tab.
The new window handle is appended to `driver.WindowHandles`, becomes `driver.CurrentWindowHandle`, and all previous handles remain accessible for switching.

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

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | tab               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Argument specifies the type of new browsing context to open.
Accepted values are `tab` and `window`.
When absent or empty the value defaults to `tab`.
The actual behavior for `window` may depend on browser settings — some browsers open a tab regardless of the requested type.

#### Values

##### Tab

Opens a new browser tab in the current WebDriver session.
##### Window

Opens a new browser window separate from the current one.

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#new-window](https://www.w3.org/TR/webdriver/#new-window)
