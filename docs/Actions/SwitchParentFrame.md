# Switch Parent Frame (SwitchParentFrame)

[Table of Content](../Home.md)  

~9 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The `SwitchParentFrame` plugin is designed to automate the process of switching from a child frame back to its parent frame within a web page. 
It streamlines navigation in web automation workflows, ensuring that scripts can efficiently interact with elements outside of nested frames.

### Key Features and Functionality

| Feature          | Description                                                               |
|------------------|---------------------------------------------------------------------------|
| Switch to Parent | Switches from a child frame to the parent frame, facilitating navigation. |

### Usages in RPA

| Usage            | Description                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------|
| Frame Navigation | Automates the process of switching back to the parent frame within a web page.                |
| Data Extraction  | Facilitates data extraction from multiple frames by allowing movement to parent frame.        |
| Form Interaction | Allows RPA bots to interact with elements in the parent frame after working in a child frame. |

### Usages in Automation Testing

| Usage                | Description                                                                                                       |
|----------------------|-------------------------------------------------------------------------------------------------------------------|
| UI Testing           | Enables automated tests to navigate back to the parent frame, ensuring comprehensive coverage.                    |
| Frame Verification   | Helps in verifying the functionality of switching back to parent frames during tests.                             |
| Multi-Frame Handling | Supports testing scenarios involving multiple frames, ensuring each frame and parent frame interaction is tested. |

## Examples

### Example No.1

Switch from the current child frame back to its parent frame. 
This is useful for navigating out of a nested frame to continue interactions with elements in the parent frame.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SwitchParentFrame"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SwitchParentFrame");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SwitchParentFrame"
};
```

_**JSON**_

```js
{
    "pluginName": "SwitchParentFrame"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SwitchParentFrame"
}
```

## Scope

* Mobile Web
* Web
## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#switch-to-parent-frame](https://www.w3.org/TR/webdriver/#switch-to-parent-frame)
