# Close Browser (CloseBrowser)

[Table of Content](../Home.md)  

~9 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `CloseBrowser` plugin is to close the currently active browser window. This is useful for ending browser sessions cleanly and ensuring that resources are properly released.

### Key Features and Functionality

| Feature             | Description                                                                |
|---------------------|----------------------------------------------------------------------------|
| Browser Control     | Closes the currently active browser window.                                |
| Resource Management | Ensures that the WebDriver instance is properly disposed of after closing. |

### Usages in RPA

| Usage                      | Description                                                                       |
|----------------------------|-----------------------------------------------------------------------------------|
| End of Automation Session  | Close the browser at the end of an automation session to clean up resources.      |
| Error Handling             | Use to close the browser in case of errors or exceptions to ensure a clean state. |

### Usages in Automation Testing

| Usage                          | Description                                                                                   |
|--------------------------------|-----------------------------------------------------------------------------------------------|
| Test Cleanup                   | Close the browser at the end of tests to ensure no browser windows remain open between tests. |
| Resource Management in Testing | Ensures that the WebDriver instance is disposed of properly after each test run.              |

## Examples

### Example No.1

Use the `CloseBrowser` plugin to close the currently active browser window.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "CloseBrowser"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("CloseBrowser");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "CloseBrowser"
};
```

_**JSON**_

```js
{
    "pluginName": "CloseBrowser"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "CloseBrowser"
}
```

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#delete-session](https://www.w3.org/TR/webdriver/#delete-session)
