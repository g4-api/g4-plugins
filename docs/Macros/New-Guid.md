# New Guid (New-Guid)

[Table of Content](../Home.md)  

~24 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Generates a unique GUID at runtime for use in automation workflows.
Each GUID is one-of-a-kind, avoiding conflicts and making element or process tracking straightforward.
Multiple formatting options are available to fit different system requirements.
A custom regex pattern can be applied to extract specific parts of the generated GUID.

### Key Features and Functionality

| Feature                      | Description                                                                           |
|------------------------------|---------------------------------------------------------------------------------------|
| Unique Identifier Generation | Creates a new GUID for use as a unique reference in workflows.                        |
| Format Options               | Offers multiple output formats (D, N, B, P, X) to meet different system requirements. |
| Pattern-Based Extraction     | Allows custom regex patterns to extract specific parts of the GUID as needed.         |
| Workflow Integration         | Integrates GUID generation seamlessly into automation steps at runtime.               |

### Usages in RPA

| Use Case               | Description                                                                       |
|------------------------|-----------------------------------------------------------------------------------|
| Element Identification | Assigns unique IDs to UI elements for reliable selection and interaction.         |
| Transaction Tracking   | Tags transactions or records with GUIDs to ensure accurate tracking and auditing. |

### Usages in Automation Testing

| Use Case             | Description                                                                      |
|----------------------|----------------------------------------------------------------------------------|
| Test Data Generation | Produces unique data values to avoid duplicates in test scenarios.               |
| Test Case Management | Uses GUIDs to label and manage test cases for better organization and reporting. |

## Examples

### Example No.1

### Generate and Send Plain GUID

Invoke `New-Guid` to obtain a GUID value in `N` format (32 digits) at runtime and send it as keystrokes using the `SendKeys` plugin.
Target the element specified by the `CssSelector` `#inputField`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:N}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:N}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:N}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:N}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:N}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

### Generate and Send Hyphenated GUID

Invoke `New-Guid` to obtain a GUID value in `D` format (32 digits separated by hyphens) at runtime and send it as keystrokes using the `SendKeys` plugin.
Target the element specified by the `CssSelector` `#inputField`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:D}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:D}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:D}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.3

### Generate and Send Braced GUID

Invoke `New-Guid` to obtain a GUID value in `B` format (32 digits separated by hyphens, enclosed in braces) at runtime and send it as keystrokes using the `SendKeys` plugin.
Target the element specified by the `CssSelector` `#inputField`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:B}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:B}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:B}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.4

### Generate and Send Parenthesized GUID

Invoke `New-Guid` to obtain a GUID value in `P` format (32 digits separated by hyphens, enclosed in parentheses) at runtime and send it as keystrokes using the `SendKeys` plugin.
Target the element specified by the `CssSelector` `#inputField`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:P}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:P}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:P}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:P}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:P}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.5

### Generate and Send Formatted GUID

Invoke `New-Guid` to obtain a GUID value in `X` format (four hexadecimal values enclosed in braces) at runtime and send it as keystrokes using the `SendKeys` plugin.
Target the element specified by the `CssSelector` `#inputField`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$New-Guid --Format:X}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$New-Guid --Format:X}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$New-Guid --Format:X}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:X}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$New-Guid --Format:X}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.6

### Extract and Log GUID Prefix

Invoke `New-Guid` to obtain a new GUID value at runtime.
Apply the regular expression `^\w{8}` to the GUID value in the `argument` attribute.
Extract the first eight alphanumeric characters of the GUID.
Log the extracted GUID prefix using the `WriteLog` plugin.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
};
```

_**JSON**_

```js
{
    "pluginName": "WriteLog",
    "argument": "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\w{8}}}"
}
```

## Parameters

### Format (Format)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | D                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Determines how the GUID value is formatted in string form.
Format options let you include or exclude hyphens and wrap the value in braces, parentheses, or keep it compact.
Selecting a compatible format ensures the GUID meets the requirements of different APIs and data stores.

#### Values

##### B

Formats the GUID as 32 hexadecimal digits separated by hyphens and enclosed in braces.
Output looks like {123e4567-e89b-12d3-a456-426614174000}.
Enclosing braces are useful in environments that require explicit GUID delimiters.
##### D

Formats the GUID as 32 hexadecimal digits separated by hyphens.
Output looks like 123e4567-e89b-12d3-a456-426614174000.
That pattern is commonly used in API requests and logging scenarios.
##### N

Formats the GUID as 32 continuous hexadecimal digits without any separators.
Output looks like 123e4567e89b12d3a456426614174000.
Compact representation helps when string length needs to be minimized.
##### P

Formats the GUID as 32 hexadecimal digits separated by hyphens and enclosed in parentheses.
Output looks like (123e4567-e89b-12d3-a456-426614174000).
Parentheses help indicate the GUID as a grouped identifier in certain contexts.
##### X

Formats the GUID as four hexadecimal values wrapped in braces and separated by commas.
Output looks like {0x123e4567,0x89b1,0x2d3a,{0x45,0x64,0x26,0x61,0x41,0x74,0x00,0x00}}.
That detailed representation is useful for low-level programming tasks requiring precise byte-level control.

### Pattern (Pattern)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Defines the regex that identifies and extracts a specific part of the generated GUID.
Applying the correct pattern ensures you retrieve the exact portion you need.
Using pattern matching helps keep data formatting consistent across different systems.

## Scope

* Any