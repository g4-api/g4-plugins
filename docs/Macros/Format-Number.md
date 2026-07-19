# Format Number (Format-Number)

[Table of Content](../Home.md)  

~94 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Formats numbers based on culture settings and custom formats for precise numeric representation.
It ensures consistent number output across automation tasks.

### Key Features and Functionality

| Feature                     | Description                                                                     |
|-----------------------------|---------------------------------------------------------------------------------|
| Culture-specific Formatting | Formats numbers according to the specified culture for accurate representation. |
| Custom Format               | Applies custom format strings to meet specific formatting requirements.         |

### Usages in RPA

| Use Case             | Description                                                                 |
|----------------------|-----------------------------------------------------------------------------|
| Financial Automation | Formats currency values using local conventions and culture-specific rules. |
| Data Reporting       | Standardizes numeric data presentation in reports and dashboards.           |

### Usages in Automation Testing

| Use Case          | Description                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| Data Validation   | Applies specific formats to verify numeric data consistency during testing. |
| Result Formatting | Structures test results in a clear and standardized numeric format.         |

### Additional Resources

- [Standard Numeric Format Strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
- [Custom Numeric Format Strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings)
- [List of .NET Culture Country Codes](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/)

## Examples

### Example No.1

### Format a decimal number with the round-trip (`R`) specifier

The `FormatNumber` macro evaluates `123456789.12345678` with the `R` format specifier.
The resulting text is inserted where the macro token appears, providing a precise string to the `SendKeys` plugin, which then types it into the element selected by the CSS selector `#inputField`.
Macros do not perform actions; they only generate values. Their output can be reused wherever a literal value is accepted, not just with `SendKeys`.
While `R` preserves exact precision, you may prefer `G17` for `Double` or `G9` for `Single` values when performance is critical.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$FormatNumber --Number:123456789.12345678 --Format:R}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$FormatNumber --Number:123456789.12345678 --Format:R}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$FormatNumber --Number:123456789.12345678 --Format:R}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$FormatNumber --Number:123456789.12345678 --Format:R}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$FormatNumber --Number:123456789.12345678 --Format:R}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

### Format an integer with the binary (`B`) specifier

The `Format-Number` macro evaluates the value `42` using the `B` format specifier, producing its binary representation.
That binary string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros do not perform actions; they only supply values and can be reused anywhere a literal value is accepted.
The `B` format specifier converts integral numbers to binary digits and is supported on .NET 8 and later.
When a precision specifier is provided, the result is padded with leading zeros to reach the requested length, following the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:42 --Format:B}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:42 --Format:B}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:42 --Format:B}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:42 --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:42 --Format:B}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.3

### Format an integer with a 16-digit binary (`b16`) specifier

The `Format-Number` macro evaluates the value `255` with the `b16` format specifier, producing its 16-digit binary representation.
That binary string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The binary (`b`) format converts integral numbers to binary digits and is supported on .NET 8 and later.
When a precision specifier is provided, the result is padded with leading zeros to reach the requested length, following the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:255 --Format:b16}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:255 --Format:b16}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:255 --Format:b16}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:255 --Format:b16}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:255 --Format:b16}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.4

### Format an integer with the decimal (`D`) specifier

The `Format-Number` macro evaluates the value `1234` using the `D` format specifier, producing its decimal representation.
That string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The `D` specifier converts integral numbers to decimal digits and is supported for integral types only.
A precision specifier pads the number with leading zeros to reach the requested length, according to the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1234 --Format:D}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1234 --Format:D}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1234 --Format:D}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234 --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234 --Format:D}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.5

### Format an integer with the `D6` decimal specifier

The `Format-Number` macro evaluates the value `-1234` using the `D6` format specifier, producing a six-digit decimal string padded with leading zeros.
That string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The `D` specifier converts integral numbers to decimal digits and is supported for integral types only.
A precision specifier pads the number with leading zeros to reach the requested length, according to the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-1234 --Format:D6}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-1234 --Format:D6}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-1234 --Format:D6}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234 --Format:D6}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234 --Format:D6}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.6

### Format an unsigned byte with the hexadecimal (`X`) specifier

The `Format-Number` macro evaluates the value `255` as an unsigned byte (`Byte`) using the `X` format specifier, producing its two-digit hexadecimal representation (`FF`).
That hex string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The `X` specifier converts integral numbers to hexadecimal digits (0-9, A-F).
Formatting respects the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.7

### Format an integer with the `X8` hexadecimal specifier

The `Format-Number` macro evaluates the value `132190` using the `X8` format specifier, producing an eight-digit hexadecimal string padded with leading zeros.
That string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The `X` specifier converts integral numbers to hexadecimal digits (0-9, A-F), and a precision specifier pads the result to the requested length according to the current `NumberFormatInfo` settings.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:132190 --Format:X8}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:132190 --Format:X8}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:132190 --Format:X8}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:132190 --Format:X8}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:132190 --Format:X8}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.8

### Format a decimal with the currency (`C`) specifier and French culture

The `Format-Number` macro evaluates the value `123.456` with the `C` format specifier and the `fr-FR` culture, producing a currency string such as `123,46 €`.
That string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The `C` specifier formats numbers according to the currency pattern of the chosen culture, including the proper symbol, decimal separator, and grouping.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.9

### Format a negative decimal with the currency (`C3`) specifier and Japanese culture

The `Format-Number` macro evaluates the value `-123.456` with the `C3` format specifier and the `ja-JP` culture.
The `C3` precision specifier **overrides** Japan’s default of zero currency-decimal digits and rounds the value to three fractional places before formatting.
The resulting string is `-¥123.456`, where the minus sign precedes the yen symbol as defined by the Japanese `CurrencyNegativePattern`.
That string replaces the macro token at runtime.
The `SendKeys` plugin then types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
If the source number contains more than three fractional digits (for example, `-123.4567`), it is first rounded to three decimals (`-123.457`) before being formatted.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.10

### Format a decimal with the scientific (E) specifier and US culture

The Format-Number macro evaluates the value 1052.0329112756 with the E format specifier and the en-US culture, producing a scientific-notation string such as 1.052033E+003.
That string replaces the macro token at runtime.
The SendKeys plugin then types the generated string into the element identified by the CSS selector #inputField.
Macros only generate values; they never perform UI actions and can be reused anywhere a literal value is accepted.
The E specifier expresses numbers in scientific notation (d.dddE±ddd), rounding to the appropriate number of significant digits when necessary, and follows the formatting rules of the specified culture.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.11

### Format a negative decimal with the `e2` specifier and US culture

The `Format-Number` macro formats the value `-1052.0329112756` using the `e2` format and the `en-US` culture.
This produces a scientific-notation string such as `-1.05e+03`, with two decimal places and a two-digit exponent.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused in any context where literal values are allowed.
The `e2` specifier formats numbers in exponential form (`d.dddde±dd`) with two digits after the decimal point and two digits in the exponent.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.12

### Format a decimal with the `F` specifier and German culture

The `Format-Number` macro formats the value `1234.567` using the `F` specifier and the `de-DE` culture.
This produces a fixed-point string like `1.234,57`, using a comma as the decimal separator and a period as the thousands separator.
The result string replaces the macro token at runtime.
The `SendKeys` plugin types the generated string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `F` format specifier formats numbers using fixed-point notation and rounds to two decimal places by default.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.13

### Format a negative decimal with the `F4` specifier and US culture

The `Format-Number` macro formats the value `-1234.56` using the `F4` specifier and the `en-US` culture.
This produces a fixed-point string like `-1,234.5600`, with a comma as the thousands separator and four digits after the decimal point.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `F4` specifier formats numbers using fixed-point notation and pads to four decimal places.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.14

### Format a decimal with the `G` specifier

The `Format-Number` macro formats the value `-123.456` using the `G` (general) specifier.
This produces a compact string such as `-123.456`, automatically choosing fixed-point or scientific notation based on the value’s magnitude and precision.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `G` specifier returns either fixed-point or exponential notation, preserving up to 15–17 significant digits when no precision specifier is supplied.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-123.456 --Format:G}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-123.456 --Format:G}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-123.456 --Format:G}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-123.456 --Format:G}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-123.456 --Format:G}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.15

### Format a decimal with the `G4` specifier and Swedish culture

The `Format-Number` macro formats `123.4546` using the `G4` specifier and the `sv-SE` culture.
This produces a compact string such as `123,5`, choosing fixed-point notation with four significant digits and a comma as the decimal separator.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `G` specifier returns either fixed-point or exponential notation depending on the number’s magnitude; the precision specifier (`4`) limits the output to four significant digits.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:123.4546 --Format:G4 --Culture:sv-SE}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:123.4546 --Format:G4 --Culture:sv-SE}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:123.4546 --Format:G4 --Culture:sv-SE}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.4546 --Format:G4 --Culture:sv-SE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.4546 --Format:G4 --Culture:sv-SE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.16

### Format a decimal with the `N` specifier and Russian culture

The `Format-Number` macro formats the value `1234.567` using the `N` specifier and the `ru-RU` culture.
This produces a localized string such as `1 234,57`, with a space as the thousands separator and a comma as the decimal separator.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `N` specifier formats numbers with thousands separators and two decimal places by default, following the rules of the specified culture.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.17

### Format a negative decimal with the `N3` specifier and US culture

The `Format-Number` macro formats `-1234.56` using the `N3` specifier and the `en-US` culture.
This produces a localized string such as `-1,234.560`, with a comma as the thousands separator, a period as the decimal separator, and three digits after the decimal point.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `N3` specifier formats numbers with thousands separators and exactly three decimal digits, following the rules of the specified culture.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.18

### Format the number 1 as a percentage with French culture

The `Format-Number` macro formats the value `1` using the `P` (percentage) specifier and the `fr-FR` culture.
This produces a string such as `100,00 %`, where the number is scaled by 100, rounded to two decimal places, uses a comma as the decimal separator, and inserts a non-breaking space before the percent sign.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `P` specifier multiplies the input by 100 and formats it as a localized percentage string according to the specified culture.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.19

### Format a negative decimal with the `P1` specifier and US culture

The `Format-Number` macro formats `-0.39678` using the `P1` (percentage, one decimal) specifier and the `en-US` culture.
This produces a string such as `-39.7 %`, where the number is scaled by 100, rounded to one decimal place, and formatted with a space before the percent sign.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
The `P1` specifier multiplies the input by 100 and formats it as a localized percentage string with exactly one decimal digit.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.20

### Format a decimal with a custom `00.0000` specifier and US culture

The `Format-Number` macro formats `0.45678` with the custom format string `00.0000` and the `en-US` culture.
This produces `00.4568`, padding the integer part with leading zeros and rounding the fractional part to four digits.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
In the format pattern `00.0000`, each `0` is a zero-placeholder symbol:
- Digits appear where present; zeros are inserted where digits are absent.
- Two zeros before the decimal ensure at least two integer digits, padded with leading zeros.
- Four zeros after the decimal guarantee exactly four fractional digits, rounding as needed.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.21

### Format a phone number with the `(###) ###-####` pattern

The `Format-Number` macro formats the value `1234567890` using the custom format string `(###) ###-####`.
This produces a string such as `(123) 456-7890`, where each `#` copies one digit from the source number and the literal characters `(`, `)`, space, and `-` appear unchanged.
The resulting string replaces the macro token at runtime.
The `SendKeys` plugin types this string into the element identified by the CSS selector `#inputField`.
Macros only generate values and can be reused anywhere literal values are accepted.
In the pattern `(###) ###-####`, digit-placeholder symbols (`#`) map the first ten digits of the input to their respective positions, while any extra digits are dropped.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.22

### Format and send a number localized for French (France)

Convert the number `0.45678` to a string with two decimal places using the French (France) culture, then send it via keystrokes to the specified element.
The `Format-Number` macro uses the format string `0.00` and culture `fr-FR` to produce `0,46`; .NET always requires `.` in the format pattern, which it replaces with the culture-specific decimal separator (`,` for fr-FR).
If the original number were `-0.45678`, the output would be `-0,46`, showing that negative values are handled correctly.
The macro remains side-effect-free, purely outputting the formatted string.
The automation then passes that value to the `SendKeys` plugin, which sends the keystrokes to the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.23

### Format and send a grouped number localized for Spanish (Spain)

Convert the number `2147483647` to a string that inserts thousands separators using the Spanish (Spain) culture, then send it via keystrokes to the specified element.
The `Format-Number` macro applies the pattern `#,#` with culture `es-ES`, so .NET inserts periods (`.`) as group separators, producing `2.147.483.647`.
Using `#,#` avoids the ×1 000 scaling that an extra comma (for example `#,#,,`) would trigger, as documented in the custom numeric format string rules.
The macro remains side-effect-free, only outputting the formatted string.
Automation then passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:2147483647 --Format:#,# --Culture:es-ES}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:2147483647 --Format:#,# --Culture:es-ES}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:2147483647 --Format:#,# --Culture:es-ES}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:2147483647 --Format:#,# --Culture:es-ES}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:2147483647 --Format:#,# --Culture:es-ES}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.24

### Format and send a percentage localized for English (United States)

Convert the number `0.3697` to a percentage string with two decimal places using the English (United States) culture, then send it via keystrokes to the specified element.
The `Format-Number` macro applies the pattern `#0.00%` with culture `en-US`, multiplying the value by 100 and adding a percent symbol, producing `36.97%`.
The macro remains side-effect-free, only outputting the formatted string.
Automation then passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0.3697 --Format:#0.00% --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0.3697 --Format:#0.00% --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0.3697 --Format:#0.00% --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.3697 --Format:#0.00% --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.3697 --Format:#0.00% --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.25

### Format and send a per-mille value localized for Russian (Russia)

Convert the number `0.03697` to a per-mille string with two decimal places using the Russian (Russia) culture, then send it via keystrokes to the specified element.
The `Format-Number` macro applies the pattern `#0.00‰` with culture `ru-RU`, multiplying the value by 1000 and adding the per-mille symbol, producing `36,97‰`.
The format string still uses a period (`.`); .NET automatically replaces it with the culture-specific decimal separator (a comma for Russian).
The per-mille sign (`‰`) is supplied by the culture’s `NumberFormatInfo.PerMilleSymbol` setting.
The macro remains side-effect-free, only outputting the formatted string.
Automation then passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.26

### Format and send a scientific-notation value

Convert the number `1503.92311` to scientific notation with exactly one decimal place, a plus sign, and at least two digits in the exponent, then send it via keystrokes to the specified element.
The `Format-Number` macro applies the pattern `0.0e+00`, where `0.0` forces a single decimal digit, and `e+00` pads the exponent to two digits while always displaying a `+` for positive exponents.
When formatted, the value becomes `1.5e+03`, since 1503.92311 equals 1.5 × 10³ after rounding.
The macro remains side-effect-free, only outputting the formatted string.
Automation then passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1503.92311 --Format:0.0e+00}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1503.92311 --Format:0.0e+00}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1503.92311 --Format:0.0e+00}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1503.92311 --Format:0.0e+00}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1503.92311 --Format:0.0e+00}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.27

### Format and send a number with literal characters

Convert the number `987654` to a string that embeds literal hash symbols using the escape character (`\`) in the custom format string, then send it via keystrokes to the specified element.
The `Format-Number` macro applies the pattern `\###00\#` in JSON. Because JSON doubles backslashes, .NET receives the runtime format string `\###00\#`; each \# escapes the hash so it appears literally in the output. The `###00` portion allows up to three optional digits followed by two required digits, padding with zeros if necessary (for example, `12` formats as `#0012#`).
The pattern contains no group or decimal placeholders, so the output remains the same across cultures; only numeric parsing would respect the current thread culture.
The macro remains side-effect-free, outputting only the formatted string.
Automation then passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:987654 --Format:\###00\#}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:987654 --Format:\###00\#}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:987654 --Format:\###00\#}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:987654 --Format:\###00\#}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:987654 --Format:\###00\#}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.28

### Format and send a number with conditional formatting

Convert the number `0` to a string using a three-section custom format (`##;(##);**Zero**`), then send it via keystrokes to the specified element.
The format string sections are separated by semicolons: the first (`##`) applies to positive numbers, the second (`(##)`) to negatives, and the third (`**Zero**`) to zero values. For an input of `0`, the macro outputs the literal string `**Zero**`.
The macro remains side-effect-free, outputting only the formatted string.
Automation passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.29

### Format and send a number with a literal suffix

Convert the number `123.8` to a string using the custom format `#,##0.0K`, then send it via keystrokes to the specified element.
The format string components are: `#,##0` (forces at least one digit, adds group separators), `.0` (one decimal place), and `K` (a literal character that is emitted unchanged). For the input `123.8`, the macro outputs `123.8K`.
Literal characters cannot be `0`, `#`, `%`, `‰`, `‘`, `\`, `.`, `,`, or `E/e` unless escaped, so `K` may be used without escaping.
The macro remains side-effect-free, outputting only the formatted string.
Automation passes this string to the `SendKeys` plugin, which types it into the element identified by the `CssSelector` locator.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:123.8 --Format:#,##0.0K}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:123.8 --Format:#,##0.0K}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:123.8 --Format:#,##0.0K}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.8 --Format:#,##0.0K}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.8 --Format:#,##0.0K}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

## Parameters

### Culture (Culture)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Culture determines how numbers are formatted according to regional settings.
Different culture codes change decimal and group separators to match local conventions.
Using the correct culture code helps ensure numbers appear correctly for users in various regions.
If no culture is specified, the system uses the invariant culture to provide a consistent format.

### Number (Number)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Number specifies the numeric value to be formatted into a displayable string.
Formatting the number ensures it appears correctly for end users.
Valid numeric input prevents errors during the formatting process.

### Format (Format)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | None              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Format defines how numeric values are represented as text.
Using a format string lets you control decimal places, grouping separators, and overall layout.
Applying the correct format string ensures numbers appear in the expected style for users.
If no format string is provided, the original numeric value is returned without alteration.

### Number Type (NumberType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Integer           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

NumberType determines the numeric data type used for processing and storage.
Selecting the appropriate type ensures values have the correct range and precision.
Preventing errors during conversion improves reliability when handling numeric inputs.
Leaving it unset uses Integer by default to handle whole numbers safely.

#### Values

##### Byte

Byte represents an 8-bit unsigned integer that holds values from 0 to 255.
Using Byte reduces memory usage when only small positive whole numbers are needed.
##### Double

Double provides a 64-bit floating point number with high precision for decimal values.
Supports large and fractional numbers for calculations requiring detail.
##### Integer

Integer stores a 32-bit signed whole number between -2,147,483,648 and 2,147,483,647.
It suits counting, indexing, and scenarios where decimal precision is not required.
##### Long

Long uses 64 bits to represent signed whole numbers in a very large range.
It prevents overflow when Integer cannot hold large values.
##### S Byte

SByte represents an 8-bit signed whole number with a range from -128 to 127.
It saves memory when small integers including negatives are expected.

## Scope

* Any