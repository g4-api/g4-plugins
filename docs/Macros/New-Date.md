# New Date (New-Date)

[Table of Content](../Home.md)  

~57 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

The NewDate macro plugin serves as a versatile tool for manipulating date and time within automation workflows and testing scenarios.

### Purpose

The primary purpose of the NewDate macro plugin is to provide functionalities for date and time manipulation, including adding or subtracting time, extracting specific date parts, and formatting dates according to custom formats.

### Key Features

| Feature              | Description                                                                 |
|----------------------|-----------------------------------------------------------------------------|
| Date Manipulation    | Add or subtract time from the current date and time.                        |
| Date Formatting      | Format dates according to custom formats.                                   |
| Date Part Extraction | Extract specific parts of the date and time, such as year, month, day, etc. |

### Usages in RPA

| Usage            | Description                                                             |
|------------------|-------------------------------------------------------------------------|
| Date Calculation | Perform calculations involving dates and times in automation workflows. |
| Date Formatting  | Format dates for logging or display purposes.                           |
| Data Processing  | Extract specific date parts for further processing or validation.       |

### Usages in Automation Testing

| Usage             | Description                                                                                |
|-------------------|--------------------------------------------------------------------------------------------|
| Date Verification | Verify date-related behaviors or outputs during automated testing.                         |
| Data Generation   | Generate test data involving dates and times.                                              |
| Test Scheduling   | Schedule tests to run at specific dates or times for regression testing or other purposes. |

## Examples

### Example No.1

This example demonstrates the usage of the `SendKeys` plugin with the `{{$New-Date}}` macro as the argument.

| Field      | Description                                                                                                                                                                       |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to a specified element.                                       |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element where the keystrokes will be sent.                                                    |
| onElement  | Indicates the value of the locator, representing the element where the keystrokes will be sent.                                                                                   |
| argument   | The macro token `{{$NewDate}}` represents the default usage of the `NewDate` macro plugin, which retrieves the current date and time in the format `yyyy-MM-ddTHH:mm:ss.ffffffK`. |

This example instructs the automation system to utilize the `SendKeys` plugin to send the current date and time obtained from the `NewDate` macro to the specified element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date}}",
    Locator = "CssSelector",
    OnElement = ".example-element"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date}}")
    .setLocator("CssSelector")
    .setOnElement(".example-element");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date}}",
    locator: "CssSelector",
    onElement: ".example-element"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date}}",
    "locator": "CssSelector",
    "onElement": ".example-element"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date}}",
    "locator": "CssSelector",
    "onElement": ".example-element"
}
```
### Example No.2

This example demonstrates the usage of the `RegisterParameter` plugin to register a parameter named `DataParameter` with the current date obtained from the `NewDate` macro plugin in the format `yyyy-MM-dd`.

| Field      | Description                                                                                                                                                                                                                                                                                                                                                                         |
|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `RegisterParameter`. This plugin is used to register a parameter for later use in the automation workflow.                                                                                                                                                                                                                  |
| argument   | The macro token `{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}` represents the registration of a parameter named `DataParameter` with the current date obtained from the `NewDate` macro plugin in the format `yyyy-MM-dd`. The parameter's scope is set to `Session`, indicating that it will be available for the duration of the session. |

This example instructs the automation system to utilize the `RegisterParameter` plugin to register the current date with the format `yyyy-MM-dd` as a parameter named `DataParameter` for later use within the session.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}"
};
```

_**JSON**_

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:DataParameter --Value:{{$New-Date --Format:yyyy-MM-dd}} --Scope:Session}}"
}
```
### Example No.3

This example demonstrates the usage of the `WriteLog` plugin to log a meaningful message including the current date obtained from the `NewDate` macro plugin.

| Field      | Description                                                                                                                                                                                                                                                                      |
|------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `WriteLog`. This plugin is used to write information to the host console.                                                                                                                                                 |
| argument   | The macro token `{{$New-Date --Format:yyyy-MM-dd}}` represents the usage of the `NewDate` macro plugin to retrieve the current date in the format `yyyy-MM-dd`. In this example, the argument is used to write a log entry with a meaningful message including the current date. |

This example instructs the automation system to utilize the `WriteLog` plugin to write a log entry including the current date obtained from the `NewDate` macro plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "Log entry created at {{$New-Date --Format:yyyy-MM-dd}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("Log entry created at {{$New-Date --Format:yyyy-MM-dd}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "Log entry created at {{$New-Date --Format:yyyy-MM-dd}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "Log entry created at {{$New-Date --Format:yyyy-MM-dd}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "Log entry created at {{$New-Date --Format:yyyy-MM-dd}}"
}
```
### Example No.4

This example demonstrates the usage of the `SendKeys` plugin with the `{{$New-Date --Format:yyyy-MM-dd --Utc}}` macro as the argument.

| Field      | Description                                                                                                                                                                                               |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.                                                                        |
| locator    | Specifies the locating mechanism, such as CSS selector, XPath, etc., for the target element where the keystrokes will be sent.                                                                            |
| onElement  | Indicates the value of the locator, representing the element where the keystrokes will be sent.                                                                                                           |
| argument   | The macro token `{{$New-Date --Format:yyyy-MM-dd --Utc}}` represents the usage of the `NewDate` macro plugin to retrieve the current date in the format `yyyy-MM-dd` in UTC (Coordinated Universal Time). |

This example instructs the automation system to utilize the `SendKeys` plugin to send the current date obtained from the `NewDate` macro plugin in UTC format to the specified element.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --Format:yyyy-MM-dd --Utc}}",
    Locator = "CssSelector",
    OnElement = ".example-element"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --Format:yyyy-MM-dd --Utc}}")
    .setLocator("CssSelector")
    .setOnElement(".example-element");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --Format:yyyy-MM-dd --Utc}}",
    locator: "CssSelector",
    onElement: ".example-element"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --Format:yyyy-MM-dd --Utc}}",
    "locator": "CssSelector",
    "onElement": ".example-element"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --Format:yyyy-MM-dd --Utc}}",
    "locator": "CssSelector",
    "onElement": ".example-element"
}
```
### Example No.5

This example demonstrates the usage of the `Click` plugin to click on a button containing the current year as its value, using the `{{$New-Date --Format:yyyy}}` macro as part of the XPath locator.

| Field      | Description                                                                                                                                |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `Click`. This plugin is used to perform a click action on a specified element.     |
| locator    | Specifies the locating mechanism, which is XPath in this case, for the target element where the click action will be performed.            |
| onElement  | Indicates the value of the locator, representing the XPath expression that identifies the button containing the current year as its value. |

This example instructs the automation system to utilize the `Click` plugin to click on a button containing the current year as its value, using the `{{$New-Date --Format:yyyy}}` macro to dynamically construct the XPath locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Click",
    OnElement = "//button[contains(text(), '{{$New-Date --Format:yyyy}}')]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Click")
    .setOnElement("//button[contains(text(), '{{$New-Date --Format:yyyy}}')]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Click",
    onElement: "//button[contains(text(), '{{$New-Date --Format:yyyy}}')]"
};
```

_**JSON**_

```js
{
    "pluginName": "Click",
    "onElement": "//button[contains(text(), '{{$New-Date --Format:yyyy}}')]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Click",
    "onElement": "//button[contains(text(), '{{$New-Date --Format:yyyy}}')]"
}
```
### Example No.6

This example demonstrates the usage of the `WriteLog` plugin to log the current date and time in Unix epoch format, obtained from the `NewDate` macro plugin.

| Field      | Description                                                                                                                                                |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `WriteLog`. This plugin is used to write information to the host console.                           |
| argument   | The macro token `{{$New-Date --UnixEpoch}}` represents the usage of the `NewDate` macro plugin to retrieve the current date and time in Unix epoch format. |

This example instructs the automation system to utilize the `WriteLog` plugin to log the current date and time in Unix epoch format.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "{{$New-Date --UnixEpoch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("{{$New-Date --UnixEpoch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "{{$New-Date --UnixEpoch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "{{$New-Date --UnixEpoch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "{{$New-Date --UnixEpoch}}"
}
```
### Example No.7

This example demonstrates the usage of the `SendKeys` plugin to input the current date and time in OLE Automation Date format, obtained from the `NewDate` macro plugin, into a text field.

| Field      | Description                                                                                                                                                      |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.                               |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                                                    |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                                               |
| argument   | The macro token `{{$New-Date --OaDate}}` represents the usage of the `NewDate` macro plugin to retrieve the current date and time in OLE Automation Date format. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current date and time in OLE Automation Date format into a text field.

In OLE Automation, dates are represented as floating-point numbers, where the integer part represents the number of days since December 30, 1899, and the fractional part represents the time of day.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --OaDate}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --OaDate}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --OaDate}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --OaDate}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --OaDate}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.8

This example demonstrates the usage of the `SendKeys` plugin to input the current year obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element. |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                      |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                 |
| argument   | The macro token `{{$New-Date --DatePart:Year}}` represents the usage of the `NewDate` macro plugin to retrieve the current year.   |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current year obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Year}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Year}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Year}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Year}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Year}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.9

This example demonstrates the usage of the `SendKeys` plugin to input the current month obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element. |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                      |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                 |
| argument   | The macro token `{{$New-Date --DatePart:Month}}` represents the usage of the `NewDate` macro plugin to retrieve the current month. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current month obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Month}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Month}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Month}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Month}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Month}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.10

This example demonstrates the usage of the `SendKeys` plugin to input the current day obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element. |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                      |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                 |
| argument   | The macro token `{{$New-Date --DatePart:Day}}` represents the usage of the `NewDate` macro plugin to retrieve the current day.     |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current day obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Day}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Day}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Day}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Day}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Day}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.11

This example demonstrates the usage of the `SendKeys` plugin to input the current hour obtained from the `NewDate` macro plugin into a text field.

| Field       | Description                                                                                                                        |
|-------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName  | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element. |
| locator     | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                      |
| onElement   | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                 |
| argument    | The macro token `{{$New-Date --DatePart:Hour}}` represents the usage of the `NewDate` macro plugin to retrieve the current hour.   |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current hour obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Hour}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Hour}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Hour}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Hour}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Hour}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.12

This example demonstrates the usage of the `SendKeys` plugin to input the current minute obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                          |
|------------|--------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.   |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                        |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                   |
| argument   | The macro token `{{$New-Date --DatePart:Minute}}` represents the usage of the `NewDate` macro plugin to retrieve the current minute. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current minute obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Minute}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Minute}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Minute}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Minute}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Minute}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.13

This example demonstrates the usage of the `SendKeys` plugin to input the current second obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                          |
|------------|--------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.   |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                        |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                   |
| argument   | The macro token `{{$New-Date --DatePart:Second}}` represents the usage of the `NewDate` macro plugin to retrieve the current second. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current second obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Second}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Second}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Second}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Second}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Second}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.14

This example demonstrates the usage of the `SendKeys` plugin to input the current millisecond obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                                    |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.             |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                                  |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                             |
| argument   | The macro token `{{$New-Date --DatePart:Millisecond}}` represents the usage of the `NewDate` macro plugin to retrieve the current millisecond. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current millisecond obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Millisecond}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Millisecond}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Millisecond}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Millisecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Millisecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.15

This example demonstrates the usage of the `SendKeys` plugin to input the current nanosecond obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                                  |
|------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.           |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                                |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                           |
| argument   | The macro token `{{$New-Date --DatePart:Nanosecond}}` represents the usage of the `NewDate` macro plugin to retrieve the current nanosecond. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current nanosecond obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Nanosecond}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Nanosecond}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Nanosecond}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Nanosecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Nanosecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.16

This example demonstrates the usage of the `SendKeys` plugin to input the current microsecond obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                                    |
|------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element.             |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                                  |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                             |
| argument   | The macro token `{{$New-Date --DatePart:Microsecond}}` represents the usage of the `NewDate` macro plugin to retrieve the current microsecond. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current microsecond obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Microsecond}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Microsecond}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Microsecond}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Microsecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Microsecond}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```
### Example No.17

This example demonstrates the usage of the `SendKeys` plugin to input the current ticks obtained from the `NewDate` macro plugin into a text field.

| Field      | Description                                                                                                                        |
|------------|------------------------------------------------------------------------------------------------------------------------------------|
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This plugin is used to send keystrokes to a specified element. |
| locator    | Specifies the locating mechanism for the target text field where the keystrokes will be sent.                                      |
| onElement  | Indicates the value of the locator, representing the text field where the keystrokes will be sent.                                 |
| argument   | The macro token `{{$New-Date --DatePart:Ticks}}` represents the usage of the `NewDate` macro plugin to retrieve the current ticks. |

This example instructs the automation system to utilize the `SendKeys` plugin to input the current ticks obtained from the `NewDate` macro plugin into a text field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Date --DatePart:Ticks}}",
    Locator = "CssSelector",
    OnElement = ".text-field"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Date --DatePart:Ticks}}")
    .setLocator("CssSelector")
    .setOnElement(".text-field");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Date --DatePart:Ticks}}",
    locator: "CssSelector",
    onElement: ".text-field"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Ticks}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Date --DatePart:Ticks}}",
    "locator": "CssSelector",
    "onElement": ".text-field"
}
```

## Parameters

### Add Time (AddTime)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time              |

Specifies the duration to add to or subtract from the current date and time.

### Subtruct Time (SubtructTime)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time              |

Specifies the duration to subtract from the current date and time.

### Format (Format)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the custom format for formatting the date and time. If not provided, the default format is used.

### Date Part (DatePart)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the specific part of the date and time to extract, such as year, month, day, etc.

#### Values

##### Year

The year component of the date and time.
##### Month

The month component of the date and time, where January is represented as 1 and December is represented as 12.
##### Day

The day component of the date and time.
##### Hour

The hour component of the time.
##### Minute

The minute component of the time.
##### Second

The second component of the time.
##### Millisecond

The millisecond component of the time.
##### Nanosecond

The nanosecond component of the time.
##### Microsecond

The microsecond component of the time.
##### Ticks

The number of ticks representing the time interval.

### Utc (Utc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether the date and time should be in UTC (Coordinated Universal Time). If not specified, local time is used.

### Unix Epoch (UnixEpoch)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether the date and time should be converted to Unix epoch time.

### Oa Date (OaDate)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether the date and time should be converted to OLE Automation Date format.

### Day Of Year (DayOfYear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether to retrieve the day of the year.

### Day Of Week (DayOfWeek)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Indicates whether to retrieve the day of the week.
