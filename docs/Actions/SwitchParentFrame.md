# Switch Parent Frame (SwitchParentFrame)

[Table of Content](../Home.md)  

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Switches WebDriver context one level up from the current child frame to its direct parent frame by calling `WebDriver.SwitchTo().ParentFrame()` unconditionally.
It requires no parameters or configuration and always performs a single deterministic switch.

### Key Features and Functionality

| Feature          | Description                                                                                                             |
|------------------|-------------------------------------------------------------------------------------------------------------------------|
| Switch to Parent | Calls `WebDriver.SwitchTo().ParentFrame()` unconditionally, moving context exactly one level up in the frame hierarchy. |

### Usages in RPA

| Usage            | Description                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------|
| Frame Navigation | Switches context back to the parent frame after completing work inside a child frame.         |
| Data Extraction  | Returns the driver to the parent frame so content outside the child frame can be accessed.    |
| Form Interaction | Allows bots to interact with parent-frame elements after completing actions in a child frame. |

### Usages in Automation Testing

| Usage                | Description                                                                                                   |
|----------------------|---------------------------------------------------------------------------------------------------------------|
| UI Testing           | Enables tests to navigate back to the parent frame for assertions or actions outside the current child frame. |
| Frame Verification   | Confirms that frame switching correctly restores context to the parent frame during test execution.           |
| Multi-Frame Handling | Supports step-by-step traversal of nested frame hierarchies by repeatedly switching up one level at a time.   |

## Examples

### Example No.1

### Switch from a child frame back to its parent frame

Switch WebDriver context one level up from the currently active child frame to its direct parent frame.
No configuration is required — the plugin calls `WebDriver.SwitchTo().ParentFrame()` unconditionally.

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
### Example No.2

### Traverse up multiple frame levels

Invoke SwitchParentFrame twice in sequence to move from a doubly nested child frame up to the top-level document context.
Each invocation moves exactly one level up, so the number of calls required equals the nesting depth.

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
