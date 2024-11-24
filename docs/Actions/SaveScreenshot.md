# Save Screenshot (SaveScreenshot)

[Table of Content](../Home.md)  

~31 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SaveScreenshot` plugin is to capture and save screenshots during automated test scenarios. 
This plugin is essential for quality assurance and RPA processes, allowing users to take snapshots of the application's state at specific points in the automation workflow, providing visual confirmation and aiding in debugging.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                                                                                                     |
|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Verification and Debugging | Screenshots can be used for visual verification, ensuring that the application's interface matches the expected state. This is particularly useful in automated test cases where precise UI details matter.                     |
| Documentation              | Screenshots serve as valuable documentation, providing a visual record of the application's behavior at different stages of the automation process. This aids in creating comprehensive reports for debugging and analysis.     |
| Error Identification       | When an error occurs during the automation process, a saved screenshot at the point of failure can provide insights into the issue, making it easier for developers and testers to identify and address problems.               |
| Visual Regression Testing  | Integral to visual regression testing, where screenshots taken during different test runs are compared to detect any unexpected visual changes in the application.                                                              |
| Cross-Browser Testing      | For web applications, taking screenshots across different browsers helps ensure consistent rendering and user interface across various browser environments.                                                                    |
| Historical Tracking        | By saving screenshots at critical steps, users can create a historical timeline of the application's behavior, facilitating a deeper understanding of how changes in the codebase or environment may impact the user interface. |

### Usages in RPA

| Usage                      | Description                                                                                                                                         |
|----------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------|
| Verification and Debugging | Screenshots can be used for visual verification, ensuring that the application's interface matches the expected state.                              |
| Documentation              | Screenshots serve as valuable documentation, providing a visual record of the application's behavior at different stages of the automation process. |
| Error Identification       | When an error occurs during the automation process, a saved screenshot at the point of failure can provide insights into the issue.                 |

### Usages in Automation Testing

| Usage                     | Description                                                                                                                                                                                                                     |
|---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Visual Regression Testing | Integral to visual regression testing, where screenshots taken during different test runs are compared to detect any unexpected visual changes in the application.                                                              |
| Cross-Browser Testing     | For web applications, taking screenshots across different browsers helps ensure consistent rendering and user interface across various browser environments.                                                                    |
| Historical Tracking       | By saving screenshots at critical steps, users can create a historical timeline of the application's behavior, facilitating a deeper understanding of how changes in the codebase or environment may impact the user interface. |

## Examples

### Example No.1

Capture and save a screenshot with specific parameters. 
The screenshot is stored in the `Screenshots` directory, and the file is named `PageScreenshot.png`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:PageScreenshot.png}}"
}
```
### Example No.2

Capture and save a screenshot without specifying a directory. 
The screenshot is directly stored in the default or current working directory, and it is named `PageScreenshot.png`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --FileName:PageScreenshot.png}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --FileName:PageScreenshot.png}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --FileName:PageScreenshot.png}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --FileName:PageScreenshot.png}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --FileName:PageScreenshot.png}}"
}
```
### Example No.3

Capture and save a screenshot in the `Screenshots` directory without specifying a custom file name. 
The plugin will generate a unique file name, ensuring each screenshot is uniquely identified within the specified directory. 
This is useful when a specific file name is not necessary, and the emphasis is on organizing screenshots in a designated folder.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots}}"
}
```
### Example No.4

Capture and save a screenshot without specifying a custom directory or file name. 
When executed, the plugin will save the screenshot in the current working directory with a dynamically generated file name. 
This is a straightforward way to capture a screenshot without the need for custom naming or directory settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot"
}
```
### Example No.5

Capture and save a screenshot of a specific element with the ID `ClickButton`. 
The screenshot will be saved in the `Screenshots` directory with the specified file name `ElementScreenshot.png`. 
This allows for targeted screenshot capture based on a specific element's appearance.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```
### Example No.6

Capture and save a screenshot of the element with the ID `ClickButton`. 
The screenshot will be saved with the specified file name `ElementScreenshot.png`. 
The absence of the `--Directory` parameter indicates that the screenshot will be saved in the default directory.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --FileName:ElementScreenshot.png}}",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --FileName:ElementScreenshot.png}}")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --FileName:ElementScreenshot.png}}",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --FileName:ElementScreenshot.png}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```
### Example No.7

Capture and save a screenshot of the element with the ID `ClickButton` and save it in the specified directory `Screenshots`. 
The absence of the `--FileName` parameter indicates that the plugin will generate a default file name for the screenshot.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --Directory:Screenshots}}",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --Directory:Screenshots}}")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --Directory:Screenshots}}",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --Directory:Screenshots}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```
### Example No.8

Capture and save a screenshot of the element with the ID `ClickButton`. 
The absence of the `--directory` parameter indicates that the screenshot will be saved in the default directory. 
The absence of the `--fileName` parameter indicates that the plugin will generate a default file name for the screenshot.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SaveScreenshot",
    Argument = "{{$ --directory:Screenshots}}",
    Locator = "CssSelector",
    OnElement = "#ClickButton"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SaveScreenshot")
    .setArgument("{{$ --directory:Screenshots}}")
    .setLocator("CssSelector")
    .setOnElement("#ClickButton");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SaveScreenshot",
    argument: "{{$ --directory:Screenshots}}",
    locator: "CssSelector",
    onElement: "#ClickButton"
};
```

_**JSON**_

```js
{
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --directory:Screenshots}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SaveScreenshot",
    "argument": "{{$ --directory:Screenshots}}",
    "locator": "CssSelector",
    "onElement": "#ClickButton"
}
```

## Output Parameter

### Saved Screenshots (SavedScreenshots)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Serves as a container for maintaining a list of file paths corresponding to screenshots captured during the automation session. 
Each time the `SaveScreenshot` plugin is invoked, the path of the saved screenshot is added to this list.

## Properties

### Locator (Locator)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The type of locator strategy employed when identifying the element specified in the `onElement` property.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies a target HTML element on the page for which a screenshot will be captured. 
When the `SaveScreenshot` plugin is executed with the `onElement` property, it captures a screenshot specifically focused on the identified HTML element.

## Parameters

### Directory (Directory)

| Attribute                 | Value                     |
|---------------------------|---------------------------|
| **Default Value**         | Current working directory |
| **Depends On**            | None                      |
| **Mandatory**             | No                        |
| **Multiple**              | No                        |
| **Value Type**            | Uri                       |

The directory or folder where the screenshot captured by the `SaveScreenshot` plugin will be saved. 
If the specified directory does not exist, the plugin may create it, depending on its implementation.

### File Name (FileName)

| Attribute               | Value                   |
|-------------------------|-------------------------|
| **Default Value**       | Automatically generated |
| **Depends On**          | None                    |
| **Mandatory**           | No                      |
| **Multiple**            | No                      |
| **Value Type**          | String                  |

The name of the screenshot file generated by the `SaveScreenshot` plugin.

## See Also

apiDocumentation: [https://www.w3.org/TR/webdriver/#take-screenshot](https://www.w3.org/TR/webdriver/#take-screenshot)
