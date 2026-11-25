# Convert Number (Convert-Number)

[Table of Content](../Home.md)

~43 min · Macro Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Converts a whole number from one base to another at runtime: binary (`Bin`), octal (`Oct`), decimal (`Dec`), and hexadecimal (`Hex`).
The source base is detected from the number prefix or named explicitly, and the result is returned as text.

### Key Features and Functionality

| Feature                  | Description                                                                              |
| --- | --- |
| Base Conversion          | Converts between binary, octal, decimal, and hexadecimal in any direction.               |
| Automatic Base Detection | Reads `0x` or `#` as hexadecimal, `0b` as binary, and `0o` or a leading zero as octal.   |
| Output Formatting        | Adds an optional base prefix, sets the letter case, and pads the digits with zeros.      |
| Two's Complement         | Writes negative numbers as 8, 16, 32, or 64-bit two's complement values with `BitWidth`. |
| Unlimited Length         | Converts whole numbers of any length without overflow.                                   |
| Safe Fallback            | Returns the original number unchanged when the input or an argument is invalid.          |

### Usages in RPA

| Use Case            | Description                                                                 |
| --- | --- |
| Data Transformation | Converts hexadecimal codes, color values, or bit masks between systems.     |
| Device Integration  | Prepares register and address values for devices that expect another base.  |

### Usages in Automation Testing

| Use Case          | Description                                                                |
| --- | --- |
| Data Validation   | Compares values shown in one base with expected values in another base.    |
| Test Data Entry   | Types numbers into fields that expect binary, octal, or hexadecimal input. |

### Additional Resources

- [Radix](https://en.wikipedia.org/wiki/Radix)
- [Two's Complement](https://en.wikipedia.org/wiki/Two%27s_complement)

## Examples

### Example No.1

### Convert a decimal number to hexadecimal

The `Convert-Number` macro reads `255` as a decimal number, because it has no base prefix, and writes it in hexadecimal as `FF`.
The `SendKeys` plugin then types `FF` into the element selected by the CSS selector `#inputField`.
Macros do not perform actions; they only generate values. The result replaces the macro token and can be used wherever a literal value is accepted.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:255 --To:Hex}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:255 --To:Hex}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:255 --To:Hex}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:255 --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:255 --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.2

### Convert a hexadecimal number to binary

The `Convert-Number` macro detects the `0x` prefix of `0xFF`, reads the number as hexadecimal, and writes it in binary as `11111111`.
The `SendKeys` plugin then types the binary digits into the element selected by `#inputField`.
Macros do not perform actions; they only generate values. The result replaces the macro token and can be used wherever a literal value is accepted.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:0xFF --To:Bin}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:0xFF --To:Bin}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:0xFF --To:Bin}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:0xFF --To:Bin}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:0xFF --To:Bin}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.3

### Convert an octal number to hexadecimal

The `Convert-Number` macro reads `777` as an octal number because `From` is `Oct`, and writes it in hexadecimal as `1FF`.
Neither the source nor the target base is decimal, so the conversion runs directly between two non-decimal bases.
The `SendKeys` plugin then types `1FF` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:777 --From:Oct --To:Hex}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:777 --From:Oct --To:Hex}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:777 --From:Oct --To:Hex}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:777 --From:Oct --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:777 --From:Oct --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.4

### Convert a grouped binary number to decimal

The `Convert-Number` macro removes the `_` separator from `1010_1100`, reads the digits as binary because `From` is `Bin`, and writes the decimal value `172`.
`To` is omitted, so the result is written in decimal, which is the default target base.
The `SendKeys` plugin then types `172` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:1010_1100 --From:Bin}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:1010_1100 --From:Bin}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:1010_1100 --From:Bin}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:1010_1100 --From:Bin}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:1010_1100 --From:Bin}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.5

### Write a padded lowercase hexadecimal value with a prefix

The `Convert-Number` macro writes `255` in hexadecimal with lowercase letter digits (`Case` is `Lower`).
`Width` pads the digits with zeros to four characters, and the `Prefix` switch adds `0x` in front, so the result is `0x00ff`.
The `SendKeys` plugin then types `0x00ff` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.6

### Write a negative number as a 16-bit two's complement value

The `Convert-Number` macro reads `-1` as a decimal number and, because `BitWidth` is `16`, writes its 16-bit two's complement bit pattern in hexadecimal as `FFFF`.
A 16-bit register accepts values from `-32768` to `65535`; any other value returns the original number unchanged.
The `SendKeys` plugin then types `FFFF` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.7

### Convert a negative number and keep its sign

The `Convert-Number` macro reads `-255` as a decimal number and writes it in hexadecimal as `-FF`.
`BitWidth` is not set, so the minus sign is kept in front of the digits instead of writing a two's complement value.
The `SendKeys` plugin then types `-FF` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:-255 --To:Hex}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:-255 --To:Hex}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:-255 --To:Hex}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:-255 --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:-255 --To:Hex}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.8

### Convert a color code to decimal

The `Convert-Number` macro detects the `#` prefix of `#1E90FF`, reads the number as hexadecimal, and writes the decimal value `2003199`.
The `SendKeys` plugin then types `2003199` into the element selected by `#inputField`.
Macros do not perform actions; they only generate values. The result replaces the macro token and can be used wherever a literal value is accepted.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:#1E90FF}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:#1E90FF}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:#1E90FF}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:#1E90FF}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:#1E90FF}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

### Example No.9

### Store octal permissions as binary bits

The `Convert-Number` macro detects the `0o` prefix of `0o755`, reads the number as octal, and writes it in binary as `111101101`.
The `RegisterParameter` plugin stores the result in the session parameter `PermissionBits`, so later rules read it with `{{$Get-Parameter --Name:PermissionBits --Scope:Session}}`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RegisterParameter",
    Argument = "{{$ --Name:PermissionBits --Value:{{$Convert-Number --Number:0o755 --To:Bin}} --Scope:Session}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RegisterParameter")
    .setArgument("{{$ --Name:PermissionBits --Value:{{$Convert-Number --Number:0o755 --To:Bin}} --Scope:Session}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RegisterParameter",
    argument: "{{$ --Name:PermissionBits --Value:{{$Convert-Number --Number:0o755 --To:Bin}} --Scope:Session}}"
};
```

**JSON:**

```js
{
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:PermissionBits --Value:{{$Convert-Number --Number:0o755 --To:Bin}} --Scope:Session}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RegisterParameter",
    "argument": "{{$ --Name:PermissionBits --Value:{{$Convert-Number --Number:0o755 --To:Bin}} --Scope:Session}}"
}
```

### Example No.10

### Assert the decimal value of a binary number

The `Convert-Number` macro detects the `0b` prefix of `0b1111`, reads the number as binary, and writes the decimal value `15`.
The `Text` assertion compares the converted value with the expected value `15` using the `Equal` operator.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Text",
    Argument = "{{$ --Operator:Equal --Expected:15}}",
    OnElement = "{{$Convert-Number --Number:0b1111 --To:Dec}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Text")
    .setArgument("{{$ --Operator:Equal --Expected:15}}")
    .setOnElement("{{$Convert-Number --Number:0b1111 --To:Dec}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "Text",
    argument: "{{$ --Operator:Equal --Expected:15}}",
    onElement: "{{$Convert-Number --Number:0b1111 --To:Dec}}"
};
```

**JSON:**

```js
{
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:15}}",
    "onElement": "{{$Convert-Number --Number:0b1111 --To:Dec}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "Text",
    "argument": "{{$ --Operator:Equal --Expected:15}}",
    "onElement": "{{$Convert-Number --Number:0b1111 --To:Dec}}"
}
```

### Example No.11

### Log a number in hexadecimal

The `Convert-Number` macro writes the decimal number `404` in hexadecimal, and the `Prefix` switch adds `0x`, so the result is `0x194`.
The `WriteLog` plugin writes the message with the macro token replaced by `0x194`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "WriteLog",
    Argument = "Status code in hexadecimal: {{$Convert-Number --Number:404 --To:Hex --Prefix}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("WriteLog")
    .setArgument("Status code in hexadecimal: {{$Convert-Number --Number:404 --To:Hex --Prefix}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "WriteLog",
    argument: "Status code in hexadecimal: {{$Convert-Number --Number:404 --To:Hex --Prefix}}"
};
```

**JSON:**

```js
{
    "pluginName": "WriteLog",
    "argument": "Status code in hexadecimal: {{$Convert-Number --Number:404 --To:Hex --Prefix}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "WriteLog",
    "argument": "Status code in hexadecimal: {{$Convert-Number --Number:404 --To:Hex --Prefix}}"
}
```

### Example No.12

### Write a number as an 8-digit binary value

The `Convert-Number` macro writes the decimal number `5` in binary as `101`, and `Width` pads it with zeros to eight digits, so the result is `00000101`.
The `SendKeys` plugin then types `00000101` into the element selected by `#inputField`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendKeys",
    Argument = "{{$Convert-Number --Number:5 --To:Bin --Width:8}}",
    Locator = "CssSelector",
    OnElement = "#inputField"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendKeys")
    .setArgument("{{$Convert-Number --Number:5 --To:Bin --Width:8}}")
    .setLocator("CssSelector")
    .setOnElement("#inputField");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendKeys",
    argument: "{{$Convert-Number --Number:5 --To:Bin --Width:8}}",
    locator: "CssSelector",
    onElement: "#inputField"
};
```

**JSON:**

```js
{
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:5 --To:Bin --Width:8}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendKeys",
    "argument": "{{$Convert-Number --Number:5 --To:Bin --Width:8}}",
    "locator": "CssSelector",
    "onElement": "#inputField"
}
```

## Parameters

### Number (Number)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Number is the whole number to convert, written in the source base.
It accepts an optional leading `+` or `-` sign and an optional base prefix (`0x`, `#`, `0b`, `0o`).
Underscores and spaces are digit separators and are removed, so `1111_0000` reads as `11110000`.
Letter digits and prefixes are not case-sensitive. Fractions are not supported.
When the number is invalid for the source base, the macro returns it unchanged.

### From (From)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Auto              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

From names the base the number is written in.
`Auto` detects the base from the prefix: `0x` or `#` is hexadecimal, `0b` is binary, `0o` or a leading zero is octal, and anything else is decimal.
A named base also accepts its own prefix, so `--Number:0xFF --From:Hex` and `--Number:FF --From:Hex` are the same.
Base names are not case-sensitive. An unknown name returns the original number.

#### Values

##### Auto

Detects the source base from the number prefix.
A number without a prefix is read as decimal, and a number with a leading zero, such as `017`, is read as octal.

##### Bin

Binary, base 2, written with the digits 0 and 1.
The optional prefix is `0b`, for example `0b1010`.

##### Oct

Octal, base 8, written with the digits 0 to 7.
The optional prefix is `0o`, for example `0o755`.

##### Dec

Decimal, base 10, written with the digits 0 to 9.
Decimal numbers have no prefix.

##### Hex

Hexadecimal, base 16, written with the digits 0 to 9 and the letters A to F.
The optional prefix is `0x` or `#`, for example `0xFF` or `#FF`.

### To (To)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Dec               |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

To names the base the result is written in.
Base names are not case-sensitive. An unknown name returns the original number.

#### Values

##### Bin

Binary, base 2, written with the digits 0 and 1.
The optional prefix is `0b`, for example `0b1010`.

##### Oct

Octal, base 8, written with the digits 0 to 7.
The optional prefix is `0o`, for example `0o755`.

##### Dec

Decimal, base 10, written with the digits 0 to 9.
Decimal numbers have no prefix.

##### Hex

Hexadecimal, base 16, written with the digits 0 to 9 and the letters A to F.
The optional prefix is `0x` or `#`, for example `0xFF` or `#FF`.

### Case (Case)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Upper             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Case sets how hexadecimal letter digits are written.
It does not affect binary, octal, or decimal results, which have no letter digits.

#### Values

##### Lower

Writes the letter digits as lowercase characters, for example `ff`.

##### Upper

Writes the letter digits as uppercase characters, for example `FF`.

### Prefix (Prefix)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Prefix writes the base prefix in front of the result: `0b` for binary, `0o` for octal, and `0x` for hexadecimal.
Decimal results have no prefix. A minus sign is written before the prefix, for example `-0xFF`.

### Width (Width)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Width is the minimum number of digits in the result; shorter results are left-padded with zeros.
The padding applies to the digits only; the sign and prefix are written in front of it.
A width smaller than the digit count leaves the digits unchanged. A negative or non-numeric width returns the original number.

### Bit Width (BitWidth)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

BitWidth is the register size, in bits, used to write negative numbers as two's complement values.
Without BitWidth a negative number keeps its minus sign, for example `-FF`.
With BitWidth the value must fit the register (from the signed minimum to the unsigned maximum); otherwise the original number is returned.

#### Values

##### 8

8-bit register, values from -128 to 255. `-1` is written as `FF` in hexadecimal.

##### 16

16-bit register, values from -32768 to 65535. `-1` is written as `FFFF` in hexadecimal.

##### 32

32-bit register, values from -2147483648 to 4294967295.

##### 64

64-bit register, values from -9223372036854775808 to 18446744073709551615.

## Scope

* Any
