# Format Number (Format-Number)

[Table of Content](../Home.md)  

~94 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `FormatNumber` macro plugin is to format numbers according to specific culture and format requirements. 
This enables precise numeric representation in various automation tasks.

### Key Features and Functionality

| Feature                     | Description                                                                          |
|-----------------------------|--------------------------------------------------------------------------------------|
| Culture-specific Formatting | Formats numbers based on the specified culture, ensuring accurate representation.    |
| Custom Format               | Supports custom format strings to format numbers according to specific requirements. |

### Usages in RPA

| Usage                 | Description                                                                              |
|-----------------------|------------------------------------------------------------------------------------------|
| Financial Automation  | Format currency values based on local conventions and culture-specific formatting rules. |
| Data Reporting        | Format numeric data for consistent presentation in reports or dashboards.                |

### Usages in Automation Testing

| Usage             | Description                                                                                    |
|-------------------|------------------------------------------------------------------------------------------------|
| Data Validation   | Ensure consistency in numeric data representation during testing by applying specific formats. |
| Result Formatting | Format test results for clear and standardized reporting.                                      |

For more information on standard and custom numeric format strings, please refer to the following links:

- [Standard Numeric Format Strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
- [Custom Numeric Format Strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings)

## Examples

### Example No.1

Format a decimal number using the `R` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `R` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:123456789.12345678 --Format:R}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `123456789.12345678` 
using the `R` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `R` format specifier attempts to ensure that a numeric value, when converted to a string, is parsed back into the same numeric value. 
This format is supported only for the Half, Single, Double, and BigInteger types. 
For both Double and Single values, the `R` format specifier offers relatively poor performance. 
We recommend using the `G17` format specifier for Double values and the `G9` format specifier to successfully round-trip Single values. 
When a BigInteger value is formatted using this specifier, its string representation contains all the significant digits. 
Although you can include a precision specifier, it is ignored, and round trips take precedence over precision. 
The result string is affected by the formatting information of the current NumberFormatInfo object.

The following table lists the NumberFormatInfo properties that control the formatting of the result string.

| NumberFormatInfo property | Description                                                            |
|---------------------------|------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.           |
| NumberDecimalSeparator    | Defines the string that separates integral digits from decimal digits. |
| PositiveSign              | Defines the string that indicates that an exponent is positive.        |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:123456789.12345678 --Format:R}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:123456789.12345678 --Format:R}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:123456789.12345678 --Format:R}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123456789.12345678 --Format:R}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123456789.12345678 --Format:R}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.2

Format an integer number using the `B` format. 
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number with the `B` format within an automation workflow. 
Here`s the breakdown:  

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:42 --Format:B}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `42` using the `B` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The binary (`B`) format specifier converts a number to a string of binary digits.
This format is supported only for integral types and only on .NET 8+.
The precision specifier indicates the minimum number of digits desired in the resulting string.
If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.
The result string is affected by the formatting information of the current NumberFormatInfo object.

The following table lists the NumberFormatInfo properties that control the formatting of the returned string.

| NumberFormatInfo property | Description                                                                                                                                                           |
|---------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                                                                                                     |
| CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |
| NegativeSign              | Defines the negative sign used if CurrencyNegativePattern indicates that parentheses are not used.                                                                    |
| CurrencySymbol            | Defines the currency symbol.                                                                                                                                          |
| CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.This value can be overridden by using the precision specifier.                                       |
| CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits.                                                                                                        |
| CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers.                                                                                                         |
| CurrencyGroupSizes        | Defines the number of integer digits that appear in a group.                                                                                                          |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#BFormatString).

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

Format an integer number using the `b16` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number with the `b16` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:255 --Format:b16}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `255` using the `b16` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The binary (`b16`) format specifier converts a number to a string of binary digits, with a precision specifier indicating the minimum number of digits desired in the resulting string.
If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.

The binary (`b`) format specifier converts a number to a string of binary digits.
This format is supported only for integral types and only on .NET 8+.
The precision specifier indicates the minimum number of digits desired in the resulting string.
If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.
The result string is affected by the formatting information of the current NumberFormatInfo object.

The following table lists the NumberFormatInfo properties that control the formatting of the returned string.

| NumberFormatInfo property | Description                                                                                                                                                           |
|---------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                                                                                                     |
| CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |
| NegativeSign              | Defines the negative sign used if CurrencyNegativePattern indicates that parentheses are not used.                                                                    |
| CurrencySymbol            | Defines the currency symbol.                                                                                                                                          |
| CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.This value can be overridden by using the precision specifier.                                       |
| CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits.                                                                                                        |
| CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers.                                                                                                         |
| CurrencyGroupSizes        | Defines the number of integer digits that appear in a group.                                                                                                          |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#BFormatString).

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

Format an integer number using the `D` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number with the `D` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:1234 --Format:D}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `1234` using the `D` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `D` (or decimal) format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign if the number is negative. This format is supported only for integral types.
The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier. If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.
The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, a single property affects the formatting of the result string.

| NumberFormatInfo property | Description                                                  |
|---------------------------|--------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#DFormatString).

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

Format an integer number using the `D6` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number with the `D6` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:-1234 --Format:D6}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `-1234` using the `D6` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `D6` format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign if the number is negative. This format is supported only for integral types.
The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier. If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.
In this example, `D6` specifies that the resulting string should have a minimum length of 6 digits, padding with zeros if necessary.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, a single property affects the formatting of the result string.

| NumberFormatInfo property | Description                                                  |
|---------------------------|--------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#DFormatString).

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

Format an integer number as a byte using the `X` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number as a byte with the `X` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and number type to be used for formatting. For example, `{{$Format-Number --Number:255 --Format:X --NumberType:Byte}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `255` as a byte using the `X` format as keystrokes to the element specified by the `CssSelector` value.
The formatted byte number will be sent to the targeted element within the automation workflow.

The `X` format specifier converts a number to a string of hexadecimal digits (0-9, A-F).
The number type `Byte` specifies that the input number should be treated as an unsigned byte (8-bit integer).

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, a single property affects the formatting of the result string.

| NumberFormatInfo property | Description                                                  |
|---------------------------|--------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#XFormatString).

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

Format an integer number using the `X8` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format an integer number with the `X8` format within an automation workflow.
Here`s the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:132190 --Format:X8}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted integer number `132190` using the `X8` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `X8` format specifier converts a number to a string of hexadecimal digits (0-9, A-F).
The precision specifier `8` indicates that the resulting string should have a minimum length of 8 digits, padding with zeros if necessary.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, a single property affects the formatting of the result string.

| NumberFormatInfo property | Description                                                  |
|---------------------------|--------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#XFormatString).

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

Format a decimal number using the `C` format and French culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `C` format and French culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:123.456 --Format:C --Culture:fr-FR}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `123.456` using the `C` format and French culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `C` format specifier converts a number to a string that represents the currency format for the specified culture. The currency symbol, decimal separator, and group separator are based on the culture.
In this example, the French culture (`fr-FR`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                       |
|---------------------------|-----------------------------------------------------------------------------------|
| CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                 |
| CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values.                 |
| NegativeSign              | Defines the string that indicates that a number is negative.                      |
| CurrencySymbol            | Defines the currency symbol.                                                      |
| CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.                 |
| CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits in currency values. |
| CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers in currency values.  |
| CurrencyGroupSizes        | Defines the number of integer digits that appear in a group in currency values.   |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#CFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a negative decimal number using the `C3` format and Japanese culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a negative decimal number with the `C3` format and Japanese culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted negative decimal number `-123.456` using the `C3` format and Japanese culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `C3` format specifier converts a number to a string that represents the currency format with three decimal places for the specified culture. The currency symbol, decimal separator, and group separator are based on the culture.
In this example, the Japanese culture (`ja-JP`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                       |
|---------------------------|-----------------------------------------------------------------------------------|
| CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                 |
| CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values.                 |
| NegativeSign              | Defines the string that indicates that a number is negative.                      |
| CurrencySymbol            | Defines the currency symbol.                                                      |
| CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.                 |
| CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits in currency values. |
| CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers in currency values.  |
| CurrencyGroupSizes        | Defines the number of integer digits that appear in a group in currency values.   |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#CFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a decimal number using the `E` format and English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `E` format and English (United States) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:1052.0329112756 --Format:E --Culture:en-US}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `1052.0329112756` using the `E` format and English (United States) culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `E` format specifier converts a number to a string of the form '-d.ddd...E+ddd' or '-d.ddd...e+ddd', where each 'd' indicates a digit (0-9).
The number is rounded to seven digits if it has more than five digits, and the format specifier includes six or more '0' characters after the decimal point.

In this example, the English (United States) culture (`en-US`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                                        |
|---------------------------|----------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative for both the coefficient and exponent. |
| NumberDecimalSeparator    | Defines the string that separates the integral digit from decimal digits in the coefficient.       |
| PositiveSign              | Defines the string that indicates that an exponent is positive.                                    |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#EFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a negative decimal number using the `e2` format and English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a negative decimal number with the `e2` format and English (United States) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted negative decimal number `-1052.0329112756` using the `e2` format and English (United States) culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `e2` format specifier converts a number to a string of the form '-d.dddde±dd', where each 'd' indicates a digit (0-9) and '±' indicates either a positive or negative exponent symbol.
The number is rounded to two decimal places and formatted using exponential notation with two digits in the exponent.

In this example, the English (United States) culture (`en-US`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                                        |
|---------------------------|----------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative for both the coefficient and exponent. |
| NumberDecimalSeparator    | Defines the string that separates the integral digit from decimal digits in the coefficient.       |
| PositiveSign              | Defines the string that indicates that an exponent is positive.                                    |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#EFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a decimal number using the `F` format and German (Germany) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `F` format and German (Germany) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:1234.567 --Format:F --Culture:de-DE}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `1234.567` using the `F` format and German (Germany) culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `F` format specifier converts a number to a string of the form '-dddd.dddd', where each 'd' indicates a digit (0-9).
The number is rounded to two decimal places and formatted using fixed-point notation.

In this example, the German (Germany) culture (`de-DE`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                  |
|---------------------------|--------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                 |
| NumberDecimalSeparator    | Defines the string that separates integral digits from decimal digits.                                       |
| NumberDecimalDigits       | Defines the default number of decimal digits. This value can be overridden by using the precision specifier. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#FFormatString) and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a decimal number using the `F4` format and English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `F4` format and English (United States) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `-1234.56` using the `F4` format and English (United States) culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `F4` format specifier converts a number to a string of the form '-dddd.dddd', where each 'd' indicates a digit (0-9).
The number is rounded to four decimal places and formatted using fixed-point notation.

In this example, the English (United States) culture (`en-US`) is used to format the number.

The result string is affected by the formatting information of the current NumberFormatInfo object. As the following table shows, several properties affect the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                  |
|---------------------------|--------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                 |
| NumberDecimalSeparator    | Defines the string that separates integral digits from decimal digits.                                       |
| NumberDecimalDigits       | Defines the default number of decimal digits. This value can be overridden by using the precision specifier. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#FFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a decimal number using the `G` format.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `G` format within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:-123.456 --Format:G}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `-123.456` 
using the `G` format as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `G` format specifier converts a number to a more compact representation of either fixed-point or scientific notation, 
depending on the type of the number and whether a precision specifier is present. 
The precision specifier defines the maximum number of significant digits that can appear in the result string.

If the precision specifier is omitted or zero, the type of the number determines the default precision.
The following table shows the default precision for each numeric type:

| Numeric type     | Default precision                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------------|
|  BigInteger      |  Unlimited(same as `R`)                                                                                   |
|  Byte or SByte   |  3 digits                                                                                                 |
|  Decimal         |  Smallest round-trippable number of digits to represent the number                                        |
|  Double          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G15 is the default) |
|  Half            |  Smallest round-trippable number of digits to represent the number                                        |
|  Int16 or UInt16 |  5 digits                                                                                                 |
|  Int32 or UInt32 |  10 digits                                                                                                |
|  Int64           |  19 digits                                                                                                |
|  Single          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G7 is the default)  |
|  UInt64          |  20 digits                                                                                                |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a decimal number using the `G` format with a specific precision and culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `G` format, a precision specifier, and a specific culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, precision, and culture to be used for formatting. For example, `{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `123.4546` 
using the `G` format with a precision of 4 and the Swedish culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `G` format specifier converts a number to a more compact representation of either fixed-point or scientific notation, 
depending on the type of the number and the precision specifier provided. 
If the precision specifier is omitted or zero, the type of the number determines the default precision.

The following table shows the default precision for each numeric type:

| Numeric type     | Default precision                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------------|
|  BigInteger      |  Unlimited(same as `R`)                                                                                   |
|  Byte or SByte   |  3 digits                                                                                                 |
|  Decimal         |  Smallest round-trippable number of digits to represent the number                                        |
|  Double          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G15 is the default) |
|  Half            |  Smallest round-trippable number of digits to represent the number                                        |
|  Int16 or UInt16 |  5 digits                                                                                                 |
|  Int32 or UInt32 |  10 digits                                                                                                |
|  Int64           |  19 digits                                                                                                |
|  Single          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G7 is the default)  |
|  UInt64          |  20 digits                                                                                                |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:123.4546 --Format:G4™ --Culture:sv-SE}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.16

Format a decimal number using the `N` format with a specific culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a decimal number with the `N` format and a specific culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:1234.567 --Format:N --Culture:ru-RU}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted decimal number `1234.567` 
using the `N` format with the Russian culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `N` format specifier converts a number to a string that represents the number in a specific culture's numeric format. 
It includes commas as thousands separators and a period as the decimal separator, with optional negative sign.

The result string is affected by the formatting information of the current `NumberFormatInfo` object.
The following table lists the `NumberFormatInfo` properties that control the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                                                |
|---------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                                               |
| NumberDecimalDigits       | Defines the default number of decimal digits.This value can be overridden by using a precision specifier.                                  |
| NumberDecimalSeparator    | Defines the string that separates integral and decimal digits.                                                                             |
| NumberGroupSeparator      | Defines the string that separates groups of integral numbers.                                                                              |
| NumberGroupSizes          | Defines the number of integral digits that appear between group separators.                                                                |
| NumberNegativePattern     | Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#NFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format a negative decimal number using the `N3` format with the English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format a negative decimal number with the `N3` format and the English (United States) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted negative decimal number `-1,234.560` 
using the `N3` format with the English (United States) culture as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `N3` format specifier converts a number to a string that represents the number in a specific culture's numeric format with three decimal digits.

The result string is affected by the formatting information of the current `NumberFormatInfo` object.
The following table lists the `NumberFormatInfo` properties that control the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                                                |
|---------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                                               |
| NumberDecimalDigits       | Defines the default number of decimal digits. This value can be overridden by using a precision specifier.                                 |
| NumberDecimalSeparator    | Defines the string that separates integral and decimal digits.                                                                             |
| NumberGroupSeparator      | Defines the string that separates groups of integral numbers.                                                                              |
| NumberGroupSizes          | Defines the number of integral digits that appear between group separators.                                                                |
| NumberNegativePattern     | Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#NFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number 1 as a percentage with the French (France) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 1 as a percentage with the French (France) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:1 --Format:P --Culture:fr-FR}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `100,00 %` 
as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `P` format specifier converts a number to a string representing a percentage.

The result string is affected by the formatting information of the current `NumberFormatInfo` object.
The following table lists the `NumberFormatInfo` properties that control the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                                       |
|---------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                                      |
| PercentDecimalDigits      | Defines the default number of decimal digits in a percentage value. This value can be overridden by using the precision specifier. |
| PercentDecimalSeparator   | Defines the string that separates integral and decimal digits.                                                                    |
| PercentGroupSeparator     | Defines the string that separates groups of integral numbers.                                                                     |
| PercentGroupSizes         | Defines the number of integer digits that appear in a group.                                                                      |
| PercentNegativePattern    | Defines the placement of the percent symbol and the negative symbol for negative values.                                          |
| PercentPositivePattern    | Defines the placement of the percent symbol for positive values.                                                                  |
| PercentSymbol             | Defines the percent symbol.                                                                                                       |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#PFormatString) and 
[this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number -0.39678 as a percentage with one decimal place and the English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number -0.39678 as a percentage with one decimal place and the English (United States) culture within an automation workflow.
Here's the breakdown:

- **pluginName**: Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.
- **argument**: Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}`.
- **locator**: Specifies the locator mechanism to identify the target element. For example, `CssSelector`.
- **onElement**: Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `-39.7 %` 
as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `P1` format specifier converts a number to a string representing a percentage with one decimal place.

The result string is affected by the formatting information of the current `NumberFormatInfo` object.
The following table lists the `NumberFormatInfo` properties that control the formatting of the result string.

| NumberFormatInfo property | Description                                                                                                                       |
|---------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| NegativeSign              | Defines the string that indicates that a number is negative.                                                                      |
| PercentDecimalDigits      | Defines the default number of decimal digits in a percentage value. This value can be overridden by using the precision specifier. |
| PercentDecimalSeparator   | Defines the string that separates integral and decimal digits.                                                                    |
| PercentGroupSeparator     | Defines the string that separates groups of integral numbers.                                                                     |
| PercentGroupSizes         | Defines the number of integer digits that appear in a group.                                                                      |
| PercentNegativePattern    | Defines the placement of the percent symbol and the negative symbol for negative values.                                          |
| PercentPositivePattern    | Defines the placement of the percent symbol for positive values.                                                                  |
| PercentSymbol             | Defines the percent symbol.                                                                                                       |

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#PFormatString) and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number 0.45678 with the custom format specifier 00.0000 and the English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 0.45678 with the custom format specifier 00.0000 and the English (United States) culture within an automation workflow.
Here's the breakdown:

| Field      | Description                                                                                                                                               |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument   | Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}`. |
| locator    | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                               |
| onElement  | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                             |
| pluginName | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                        |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `00.4568` 
as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `0` custom format specifier serves as a zero-placeholder symbol. If the value being formatted has a digit in the position where the zero appears in the format string, that digit is copied to the result string; otherwise, a zero appears in the result string. The position of the leftmost zero before the decimal point and the rightmost zero after the decimal point determines the range of digits that are always present in the result string.

The result string is affected by the formatting information of the current `NumberFormatInfo` object.

For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-0-custom-specifier) 
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number 1234567890 using the `#` format specifier to display it as a phone number in the format `(###) ###-####`.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 1234567890 as a phone number with the format `(###) ###-####`.
Here's the breakdown:

| Field       | Description                                                                                                                               |
|-------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| argument    | Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}`. |
| locator     | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                               |
| onElement   | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                             |
| pluginName  | Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.        |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `(123) 456-7890` as keystrokes to the element specified by the `CssSelector` value.
The formatted phone number will be sent to the targeted element within the automation workflow.

The `#` custom format specifier serves as a digit-placeholder symbol, where a digit in the position of the `#` symbol in the format string is copied to the result string.
The `##` format string causes the value to be rounded to the nearest digit preceding the decimal, where rounding away from zero is always used.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier).

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

Format the number 0.45678 using the `.` format specifier to insert a localized decimal separator into the result string with a precision of two decimal places and the French (France) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 0.45678 with a precision of two decimal places and the French (France) culture using the `.` format specifier.
Here's the breakdown:

| Field     | Description                                                                                                                                            |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}`. |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                            |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                          |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                     |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `0,46` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `.` custom format specifier inserts a localized decimal separator into the result string, and the precision of two decimal places is specified by `0.00`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-1) 
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number 2,147,483,647 using the `,` format specifier to insert group separators and number scaling with the Spanish (Spain) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 2,147,483,647 using the `,` format specifier to insert group separators and number scaling with the Spanish (Spain) culture.
Here's the breakdown:

| Field     | Description                                                                                                                                                |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}`. |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                                |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                              |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                         |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `2.147.483.647` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `,` format specifier is used to insert group separators and number scaling. In this example, the number is formatted as `2,147,483.647`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-2) 
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:2147483647 --Format:#,#,, --Culture:es-ES}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.24

Format the number 0.3697 as a percentage with two decimal places using the `%` format specifier with the English (United States) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 0.3697 as a percentage with two decimal places using the `%` format specifier with the English (United States) culture.
Here's the breakdown:

| Field     | Description                                                                                                                                             |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}`. |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                             |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                           |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                      |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `36.97%` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `%` format specifier is used to multiply the number by 100 and format it as a percentage with two decimal places. In this example, the number is formatted as `36.97%`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-3) 
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:0.3697 --Format:%#0.00 --Culture:en-US}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.25

Format the number 0.03697 as a per mille with two decimal places using the `‰` format specifier with the Russian (Russia) culture.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 0.03697 as a per mille with two decimal places using the `‰` format specifier with the Russian (Russia) culture.
Here's the breakdown:

| Field     | Description                                                                                                                                                                     |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number, format, and culture to be used for formatting. For example, `{{$Format-Number --Number:0.03697 --Format:#0.00‰ --Culture:ru-RU}}`.                          |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                                                     |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                                                   |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                                             |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `36.97‰` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `‰` format specifier is used to multiply the number by 1000 and format it as a per mille with two decimal places. In this example, the number is formatted as `36.97‰`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-4) 
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

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

Format the number 1503.92311 using scientific notation with one decimal place and the exponent displayed with at least two digits and a plus sign if positive.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 1503.92311 using scientific notation with one decimal place and the exponent displayed with at least two digits and a plus sign if positive.
Here's the breakdown:

| Field     | Description                                                                                                                          |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}`. |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                          |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                        |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.   |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `1.5e+03` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The `0.0##e+00` format specifier is used to format the number using scientific notation with one decimal place and the exponent displayed with at least two digits and a plus sign if positive. In this example, the number is formatted as `1.5e+03`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-e-and-e-custom-specifiers).
and [this resource](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/).

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

_**JSON**_

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Format-Number --Number:1503.92311 --Format:0.0##e+00}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```
### Example No.27

Format the number 987654 with a custom format string that includes literal characters using the escape character.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 987654 with a custom format string that includes literal characters using the escape character.
Here's the breakdown:

| Field     | Description                                                                                                                        |
|-----------|------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:987654 --Format:\###00\#}}`.  |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                        |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                      |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `\#987654\#` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The format string `\###00\#` includes literal characters `987654` with the escape character (`\`) before each character to ensure they are included in the result string unchanged. In this example, the number is formatted as `\#987654\#`.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--escape-character).

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

Format the number 0 with a custom format string that includes conditional formatting using the semicolon separator.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 0 with a custom format string that includes conditional formatting using the semicolon separator.
Here's the breakdown:

| Field     | Description                                                                                                                        |
|-----------|------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:0 --Format:##;(##);**Zero**}}`. |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                        |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                      |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element. |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `**Zero**` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The format string `##;(##);**Zero**` contains three sections separated by semicolons. 
The first section applies to positive values, the second section applies to negative values, and the third section applies to zeros. In this example, the number is formatted as `**Zero**` since it is zero.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--section-separator).

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

Format the number 123.8 with a custom format string that includes character literals.
This example demonstrates the usage of the `Format-Number` macro plugin to format the number 123.8 with a custom format string that includes character literals.
Here's the breakdown:

| Field     | Description                                                                                                                                                       |
|-----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| argument  | Specifies the number and format to be used for formatting. For example, `{{$Format-Number --Number:123.8 --Format:#,##0.0K}}`.                                  |
| locator   | Specifies the locator mechanism to identify the target element. For example, `CssSelector`.                                                                           |
| onElement | Specifies the value of the locator mechanism used to identify the target element. For example, `#inputField`.                                                         |
| pluginName| Identifies the specific plugin being utilized, which is `SendKeys`. This signifies the action of sending keystrokes to an element.                                 |

This example instructs the automation system to utilize the `SendKeys` plugin to send the formatted number `123.8K` as keystrokes to the element specified by the `CssSelector` value.
The formatted number will be sent to the targeted element within the automation workflow.

The format string `#,##0.0K` includes the character literal `K`, which is interpreted as a literal character and included in the result string unchanged.
Character literals cannot be `0`, `#`, `%`, `‰`, `'`, `\`, `.`, `,`, or `E` or `e`, depending on their position in the format string, unless escaped.
For more details, refer to the [official documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#character-literals).

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

Specifies the culture used for formatting the number. If not specified, defaults to InvariantCulture.
For a list of .NET culture codes, refer to: [List of .NET Culture Country Codes](https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/)

### Number (Number)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the number to be formatted.

### Format (Format)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | None              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the format string used for formatting the number.
If not specified or set to 'None', the original number is returned.
For more information on standard numeric format strings, refer to [this link](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).
For more information on custom numeric format strings, refer to [this link](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings).

### Number Type (NumberType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Integer           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of the number (e.g., 'Byte', 'Double', 'Integer', 'Long', 'SByte'). 
If not specified, defaults to 'Integer'.

#### Values

##### Byte

An 8-bit unsigned integer.
##### Double

A double-precision floating point number.
##### Integer

A 32-bit signed integer.
##### Long

A 64-bit signed integer.
##### S Byte

An 8-bit signed integer.