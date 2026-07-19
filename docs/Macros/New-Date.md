# New Date (New-Date)

[Table of Content](../Home.md)  

~57 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Provides date and time manipulation, including adding or subtracting time, extracting specific date parts, and formatting dates according to custom formats.

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

### SendKeys Plugin with NewDate Macro

Use the `SendKeys` plugin to send the current date and time to the specified element matching the CSS selector `.example-element`.
Generate the argument by applying the `NewDate` macro (`{{$New-Date}}`), which returns the current local date and time as a string.

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

### RegisterParameter Plugin with NewDate Macro

Evaluate the `NewDate` macro (`{{$New-Date --Format:yyyy-MM-dd}}`) to produce a date string in `yyyy-MM-dd` format.
Pass the verbatim argument string (`{{$ --Name:DataParameter --Value:<date string> --Scope:Session}}`) to the `RegisterParameter` plugin to register a session-scoped parameter named `DataParameter` with the generated date string.

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

### WriteLog Plugin with NewDate Macro

Evaluate the `NewDate` macro (`{{$New-Date --Format:yyyy-MM-dd}}`) to generate the current date string in `yyyy-MM-dd` format.
Pass the message `Log entry created at {{$New-Date --Format:yyyy-MM-dd}}` to the `WriteLog` plugin to write a log entry that includes the generated date.

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

### SendKeys Plugin with NewDate Macro in UTC

Use the `SendKeys` plugin to send the current UTC date to the element matching the CSS selector `.example-element`.
Generate the argument by applying the `NewDate` macro with format and UTC flag (`{{$New-Date --Format:yyyy-MM-dd --Utc}}`).

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

### Click Plugin with NewDate Macro for Year

Evaluate the `NewDate` macro (`{{$New-Date --Format:yyyy}}`) to generate the current year string.
Use the `Click` plugin with the XPath locator string `//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]` so that the plugin evaluates the inline macro call at runtime and clicks the matching button.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Click",
    OnElement = "//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Click")
    .setOnElement("//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Click",
    onElement: "//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]"
};
```

_**JSON**_

```js
{
    "pluginName": "Click",
    "onElement": "//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Click",
    "onElement": "//button[contains(text(), ‘{{$New-Date --Format:yyyy}}’)]"
}
```
### Example No.6

### WriteLog Plugin with NewDate Macro for Unix Epoch

Evaluate the `NewDate` macro (`{{$New-Date --UnixEpoch}}`) to generate the current Unix epoch timestamp.
Pass the argument `{{$New-Date --UnixEpoch}}` to the `WriteLog` plugin so that the plugin evaluates the macro call at runtime and writes a log entry containing the generated timestamp.

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

### SendKeys Plugin with NewDate Macro for OLE Automation Date

Evaluate the `NewDate` macro (`{{$New-Date --OaDate}}`) to generate the current date and time as an OLE Automation date value.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --OaDate}}` so that the plugin inputs the generated OLE Automation date value into the text field.

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

### SendKeys Plugin with NewDate Macro for Year

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Year}}`) to generate the current year string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Year}}` so that the plugin inputs the generated year into the text field.

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

### SendKeys Plugin with NewDate Macro for Month

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Month}}`) to generate the current month string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Month}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated month into the text field.

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

### SendKeys Plugin with NewDate Macro for Day

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Day}}`) to generate the current day string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Day}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated day into the text field.

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

### SendKeys Plugin with NewDate Macro for Hour

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Hour}}`) to generate the current hour string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Hour}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated hour into the text field.

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

### SendKeys Plugin with NewDate Macro for Minute

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Minute}}`) to generate the current minute string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Minute}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated minute into the text field.

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

### SendKeys Plugin with NewDate Macro for Second

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Second}}`) to generate the current second string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Second}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated second into the text field.

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

### SendKeys Plugin with NewDate Macro for Millisecond

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Millisecond}}`) to generate the current millisecond string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Millisecond}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated millisecond into the text field.

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

### SendKeys Plugin with NewDate Macro for Nanosecond

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Nanosecond}}`) to generate the current nanosecond string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Nanosecond}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated nanosecond into the text field.

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

### SendKeys Plugin with NewDate Macro for Microsecond

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Microsecond}}`) to generate the current microsecond string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Microsecond}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated microsecond into the text field.

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

### SendKeys Plugin with NewDate Macro for Ticks

Evaluate the `NewDate` macro (`{{$New-Date --DatePart:Ticks}}`) to generate the current tick count string.
Use the `SendKeys` plugin with the CSS selector `.text-field` and the argument `{{$New-Date --DatePart:Ticks}}` so that the plugin evaluates the inline macro call at runtime and inputs the generated tick count into the text field.

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

Amount of time to add to the current date and time.
Use positive or negative values to move the timestamp forward or backward.
Supports durations such as days, hours, minutes, and seconds.

### Subtruct Time (SubtructTime)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Time              |

Amount of time to subtract from the current date and time.
Define the duration in units like days, hours, minutes, or seconds.
Creates a past timestamp relative to now.

### Format (Format)

| Attribute                   | Value                       |
|-----------------------------|-----------------------------|
| **Default Value**           | yyyy-MM-ddTHH:mm:ss.ffffffK |
| **Depends On**              | None                        |
| **Mandatory**               | No                          |
| **Multiple**                | No                          |
| **Value Type**              | String                      |

Custom pattern that dictates how the date and time are displayed.
Uses standard .NET format tokens for precise control over order, separators, and precision.
Defaults to `yyyy-MM-ddTHH:mm:ss.ffffffK` when no format is provided.

### Date Part (DatePart)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Choose one element of the date and time, like year, month, or day, when you need only part of the full timestamp.
Selecting ‘Hour’ or ’Minute’ lets you work with the exact time of day for scheduling or logging.
Using ‘Second’, ’Millisecond’, or smaller units helps when you need precise timing in your application.
Specifying ‘Ticks’ returns the raw tick count for very fine measurements and analysis.

#### Values

##### Year

Extracts the year from the date and time input.
Using the year value helps group or filter data by calendar year.
Value appears as a four-digit number like 2025.
##### Month

Extracts the month number from the date and time, where January is 1 and December is 12.
Month values help sort events or data within a single year.
Useful for generating monthly reports or determining seasonal patterns.
##### Day

Extracts the day of the month from the date and time.
Day values range from 1 to 31 depending on the month.
Scheduling or tracking tasks on specific dates becomes easier.
##### Hour

Extracts the hour part of the time using a 24-hour clock.
Hour values range from 0 to 23.
This is useful when you need to trigger actions at a specific hour.
##### Minute

Extracts the minute part of the time, ranging from 0 to 59.
Using minutes allows finer-grained time schedules or logs.
Combining with hours defines precise times like 14:30.
##### Second

Extracts the second part of the time, ranging from 0 to 59.
Seconds allow tracking events at a one-second resolution.
Useful for timestamping or measuring short delays.
##### Millisecond

Extracts the millisecond part of the time, ranging from 0 to 999.
Milliseconds help measure short intervals with high precision.
Essential for applications that record or analyze rapid events.
##### Nanosecond

Extracts the nanosecond component, measuring one billionth of a second.
Nanoseconds provide extremely fine timing for specialized scenarios.
Useful for high-resolution timestamps in scientific or performance analysis.
##### Microsecond

Extracts the microsecond component, measuring one millionth of a second.
Microseconds allow very precise time calculations below the millisecond level.
Helpful for profiling code performance or detailed logging.
##### Ticks

Extracts the total number of ticks from the time value, where each tick is 100 nanoseconds.
Ticks provide the raw count of time intervals for maximum precision.
Useful for comparing or calculating time spans at the lowest resolution.

### Utc (Utc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Records date and time values using Coordinated Universal Time instead of the local time zone.
Standardizing on UTC helps avoid errors caused by time zone differences.
A universal time reference improves consistency when processing timestamps across regions.

### Unix Epoch (UnixEpoch)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Converts date and time values into the number of seconds that have elapsed since January 1, 1970 (the Unix epoch).
Epoch time is a common format for storing and comparing timestamps across systems.
Using a numeric timestamp simplifies interoperability across platforms and languages.

### Oa Date (OaDate)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Transforms date and time values into OLE Automation Date format, which represents dates as floating-point numbers.
The integer part counts days since December 30, 1899 and the fractional part represents the time of day.
Many Microsoft automation tools use this format to maintain compatibility.

### Day Of Year (DayOfYear)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Returns the day number within the year for the given date and time.
Day-of-year values help compute spans and filter data across an annual period.
Continuous day counts support features like annual reports and milestone tracking.

### Day Of Week (DayOfWeek)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Retrieves the day of the week for the provided date and time.
Weekday information helps schedule tasks and enforce business rules.
Calendar views and weekly summaries depend on accurate weekday values.

## Scope

* Any