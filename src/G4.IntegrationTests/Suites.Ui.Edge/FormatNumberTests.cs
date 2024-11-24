using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.FormatNumber;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("FormatNumber")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to format numbers based on culture and specified format, " +
        "So that I can ensure consistency and accuracy in numerical data representation across different locales and " +
        "formats.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The FormatNumber plugin should be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Number Formatting Functionality: The plugin effectively formats numbers based on specified culture and format, supporting various number types such as byte, double, integer, long, and signed byte.")]
    [AcceptanceCriteria(criteria: "Culture Handling: The plugin properly handles culture settings, allowing users to specify culture for number formatting, with fallback to Invariant Culture if no culture is provided or the specified culture is invalid.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during number formatting, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class FormatNumberTests : TestBase
    {
        // The round-trip (`R`) format specifier attempts to ensure that a numeric value that is converted to a string is parsed back into the same numeric value.
        // This format is supported only for the Half, Single, Double, and BigInteger types.
        //
        // For both Double and Single values, the `R` format specifier offers relatively poor performance.
        // Instead, we recommend that you use the `G17` format specifier for Double values and the `G9` format specifier to successfully round-trip Single values.
        //
        // When a BigInteger value is formatted using this specifier, its string representation contains all the significant digits in the BigInteger value.
        //
        // Although you can include a precision specifier, it is ignored.
        // Round trips are given precedence over precision when using this specifier.
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // The following table lists the NumberFormatInfo properties that control the formatting of the result string.
        //
        // | NumberFormatInfo property | Description                                                            |
        // |---------------------------|------------------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative.           |
        // | NumberDecimalSeparator    | Defines the string that separates integral digits from decimal digits. |
        // | PositiveSign              | Defines the string that indicates that an exponent is positive.        |
        // 
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of a decimal number using the 'R' format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'R' format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number ensures that it can be parsed back into the same numeric value when converted to a string.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$FormatNumber  --Number:123456789.12345678   --Format:R}}", "^123456789.12345678$")]
        [DataRow("{{$fmtnum        --Number:-1234567890.12345678 --Format:R}}", "^-1234567890.1234567$")]
        [DataRow("{{$Format-Number --Number:123456789.12345678   --Format:R}}", "^123456789.12345678$")]
        [DataRow("{{$Format-Number --Number:-1234567890.12345678 --Format:R}}", "^-1234567890.1234567$")]
        #endregion
        public void T0001A(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The binary (`B`) format specifier converts a number to a string of binary digits.
        // This format is supported only for integral types and only on .NET 8+.
        //
        // The precision specifier indicates the minimum number of digits desired in the resulting string.
        // If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.
        //
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // The following table lists the NumberFormatInfo properties that control the formatting of the returned string.
        //
        // | NumberFormatInfo property | Description                                                                                                                                                           |
        // |---------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
        // | CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                                                                                                     |
        // | CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |
        // | NegativeSign              | Defines the negative sign used if CurrencyNegativePattern indicates that parentheses are not used.                                                                    |
        // | CurrencySymbol            | Defines the currency symbol.                                                                                                                                          |
        // | CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.This value can be overridden by using the precision specifier.                                       |
        // | CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits.                                                                                                        |
        // | CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers.                                                                                                         |
        // | CurrencyGroupSizes        | Defines the number of integer digits that appear in a group.                                                                                                          |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#BFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of an integer number using the 'B' format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The integer number is correctly formatted using the 'B' format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard binary formatting rules.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:42  --Format:B}}", "^101010$")]
        [DataRow("{{$Format-Number --Number:255 --Format:b16}}", "^0000000011111111$")]
        #endregion
        public void T0001B(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `D` (or decimal) format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign
        // if the number is negative. This format is supported only for integral types.
        //
        // The precision specifier indicates the minimum number of digits desired in the resulting string.
        // If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.
        // If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.
        //
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // As the following table shows, a single property affects the formatting of the result string.
        //
        // | NumberFormatInfo property | Description                                                  |
        // |---------------------------|--------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative. |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#DFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of an integer number using the 'D' format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The integer number is correctly formatted using the 'D' format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard decimal formatting rules.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:1234  --Format:D}}", "^1234$")]
        [DataRow("{{$Format-Number --Number:-1234 --Format:D6}}", "^-001234$")]
        #endregion
        public void T0001C(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The hexadecimal (`X`) format specifier converts a number to a string of hexadecimal digits. The case of the format specifier
        // indicates whether to use uppercase or lowercase characters for hexadecimal digits that are greater than 9. For example,
        // use `X` to produce `ABCDEF`, and `x` to produce `abcdef`. This format is supported only for integral types.
        //
        // The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is
        // padded with zeros to its left to produce the number of digits given by the precision specifier.
        //
        // The result string is not affected by the formatting information of the current NumberFormatInfo object.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#XFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of an integer number using the 'X' format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The integer number is correctly formatted using the 'X' format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard hexadecimal formatting rules.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:255       --Format:X  --NumberType:Byte}}", "^FF$")]
        [DataRow("{{$Format-Number --Number:-1        --Format:x  --NumberType:SByte}}", "^ff$")]
        [DataRow("{{$Format-Number --Number:255       --Format:x4 --NumberType:Byte}}", "^00ff$")]
        [DataRow("{{$Format-Number --Number:-1        --Format:X4 --NumberType:SByte}}", "^00FF$")]
        [DataRow("{{$Format-Number --Number:132190    --Format:X}}", "^2045E$")]
        [DataRow("{{$Format-Number --Number:132190    --Format:x}}", "^2045e$")]
        [DataRow("{{$Format-Number --Number:132190    --Format:X8}}", "^0002045E$")]
        [DataRow("{{$Format-Number --Number:123456789 --Format:X}}", "^75BCD15$")]
        [DataRow("{{$Format-Number --Number:123456789 --Format:X2}}", "^75BCD15$")]
        #endregion
        public void T0001D(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `C` (or currency) format specifier converts a number to a string that represents a currency amount.
        // The precision specifier indicates the desired number of decimal places in the result string.
        // If the precision specifier is omitted, the default precision is defined by the NumberFormatInfo.CurrencyDecimalDigits property.
        //
        // If the value to be formatted has more than the specified or default number of decimal places, the fractional value is
        // rounded in the result string. If the value to the right of the number of specified decimal places is 5 or greater, the
        // last digit in the result string is rounded away from zero.
        //
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // The following table lists the NumberFormatInfo properties that control the formatting of the returned string.
        //
        // | NumberFormatInfo property | Description                                                                                                                                                           |
        // |---------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
        // | CurrencyPositivePattern   | Defines the placement of the currency symbol for positive values.                                                                                                     |
        // | CurrencyNegativePattern   | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |
        // | NegativeSign              | Defines the negative sign used if CurrencyNegativePattern indicates that parentheses are not used.                                                                    |
        // | CurrencySymbol            | Defines the currency symbol.                                                                                                                                          |
        // | CurrencyDecimalDigits     | Defines the default number of decimal digits in a currency value.This value can be overridden by using the precision specifier.                                       |
        // | CurrencyDecimalSeparator  | Defines the string that separates integral and decimal digits.                                                                                                        |
        // | CurrencyGroupSeparator    | Defines the string that separates groups of integral numbers.                                                                                                         |
        // | CurrencyGroupSizes        | Defines the number of integer digits that appear in a group.                                                                                                          |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#CFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of a decimal number as currency using the 'C' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted as currency using the 'C' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard currency formatting rules for culture.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:123.456  --Format:C  --Culture:en-US}}", @"^\$123\.46$")]
        [DataRow("{{$Format-Number --Number:123.456  --Format:C  --Culture:fr-FR}}", "^123,46 €$")]
        [DataRow("{{$Format-Number --Number:123.456  --Format:C  --Culture:ja-JP}}", @"^\W\s?123$")]
        [DataRow("{{$Format-Number --Number:-123.456 --Format:C3 --Culture:en-US}}", @"^-\$123\.456$")]
        [DataRow("{{$Format-Number --Number:-123.456 --Format:C3 --Culture:fr-FR}}", @"^-123,456\s?€$")]
        [DataRow("{{$Format-Number --Number:-123.456 --Format:C3 --Culture:ja-JP}}", @"^-\W\s?123\.456$")]
        #endregion
        public void T0001E(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The exponential (`E`) format specifier converts a number to a string of the form `-d.ddd…E+ddd` or `-d.ddd…e+ddd`,
        // where each `d` indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
        // digit always precedes the decimal point.
        //
        // The precision specifier indicates the desired number of digits after the decimal point.
        // If the precision specifier is omitted, a default of six digits after the decimal point is used.
        //
        // The case of the format specifier indicates whether to prefix the exponent with an `E` or an `e`.
        // The exponent always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros
        // to meet this minimum, if required.
        //
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // The following table lists the NumberFormatInfo properties that control the formatting of the returned string.
        //
        // | NumberFormatInfo property | Description                                                                                        |
        // |---------------------------|----------------------------------------------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative for both the coefficient and exponent. |
        // | NumberDecimalSeparator    | Defines the string that separates the integral digit from decimal digits in the coefficient.       |
        // | PositiveSign              | Defines the string that indicates that an exponent is positive.                                    |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#EFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of a decimal number using the 'E' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'E' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard scientific notation formatting rules for culture.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:1052.0329112756  --Format:E  --Culture:en-US}}", @"^1\.052033E\+003$")]
        [DataRow("{{$Format-Number --Number:1052.0329112756  --Format:e  --Culture:fr-FR}}", @"^1,052033e\+003$")]
        [DataRow("{{$Format-Number --Number:-1052.0329112756 --Format:e2 --Culture:en-US}}", @"^-1\.05e\+003$")]
        [DataRow("{{$Format-Number --Number:-1052.0329112756 --Format:E2 --Culture:fr-FR}}", @"^-1,05E\+003$")]
        #endregion
        public void T0001F(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The fixed-point (`F`) format specifier converts a number to a string of the form `-ddd.ddd…` where each `d`
        // indicates a digit (0-9). The string starts with a minus sign if the number is negative.
        //
        // The precision specifier indicates the desired number of decimal places.
        // If the precision specifier is omitted, the current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
        //
        // The result string is affected by the formatting information of the current NumberFormatInfo object.
        // The following table lists the properties of the NumberFormatInfo object that control the formatting of the result string.
        //
        // | NumberFormatInfo property | Description                                                                                                  |
        // |---------------------------|--------------------------------------------------------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative.                                                 |
        // | NumberDecimalSeparator    | Defines the string that separates integral digits from decimal digits.                                       |
        // | NumberDecimalDigits       | Defines the default number of decimal digits. This value can be overridden by using the precision specifier. |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#FFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the correct formatting of a decimal number using the 'F' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'F' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard fixed-point formatting rules for culture.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:1234.567 --Format:F  --Culture:en-US}}", @"^1234\.567$")]
        [DataRow("{{$Format-Number --Number:1234.567 --Format:F  --Culture:de-DE}}", "^1234,567$")]
        [DataRow("{{$Format-Number --Number:1234     --Format:F1 --Culture:en-US}}", @"^1234\.0$")]
        [DataRow("{{$Format-Number --Number:1234     --Format:F1 --Culture:de-DE}}", "^1234,0$")]
        [DataRow("{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:en-US}}", @"^-1234\.5600$")]
        [DataRow("{{$Format-Number --Number:-1234.56 --Format:F4 --Culture:de-DE}}", "^-1234,5600$")]
        #endregion
        public void T0001G(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The general (`G`) format specifier converts a number to the more compact of either fixed-point or scientific
        // notation, depending on the type of the number and whether a precision specifier is present. The precision
        // specifier defines the maximum number of significant digits that can appear in the result string.
        // If the precision specifier is omitted or zero, the type of the number determines the default precision,
        // as indicated in the following table.
        //
        // | Numeric type     | Default precision                                                                                         |
        // |------------------|-----------------------------------------------------------------------------------------------------------|
        // |  BigInteger      |  Unlimited(same as `R`)                                                                                   |
        // |  Byte or SByte   |  3 digits                                                                                                 |
        // |  Decimal         |  Smallest round-trippable number of digits to represent the number                                        |
        // |  Double          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G15 is the default) |
        // |  Half            |  Smallest round-trippable number of digits to represent the number                                        |
        // |  Int16 or UInt16 |  5 digits                                                                                                 |
        // |  Int32 or UInt32 |  10 digits                                                                                                |
        // |  Int64           |  19 digits                                                                                                |
        // |  Single          |  Smallest round-trippable number of digits to represent the number(in .NET Framework, G7 is the default)  |
        // |  UInt64          |  20 digits                                                                                                |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the 'G' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'G' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard general numeric formatting rules for culture.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:-123.456         --Format:G  --Culture:en-US}}", "^-123.456$")]
        [DataRow("{{$Format-Number --Number:-123.456         --Format:G  --Culture:sv-SE}}", "^−123,456$")]
        [DataRow("{{$Format-Number --Number:123.4546         --Format:G4 --Culture:en-US}}", "^123.5$")]
        [DataRow("{{$Format-Number --Number:123.4546         --Format:G4 --Culture:sv-SE}}", "^123,5$")]
        [DataRow("{{$Format-Number --Number:-1.234567890e-25 --Format:G  --Culture:en-US}}", "^-1.23456789E-25$")]
        [DataRow("{{$Format-Number --Number:-1.234567890e-25 --Format:G  --Culture:sv-SE}}", "^−1,23456789E−25$")]
        #endregion
        public void T0001H(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The numeric (`N`) format specifier converts a number to a string of the form `-d,ddd,ddd.ddd…`, where `-` indicates
        // a negative number symbol if required, `d` indicates a digit (0-9), `,` indicates a group separator, and `.` indicates
        // a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal point.
        // If the precision specifier is omitted, the number of decimal places is defined by the current
        // `NumberFormatInfo.NumberDecimalDigits` property.
        //
        // The result string is affected by the formatting information of the current `NumberFormatInfo` object.
        // The following table lists the `NumberFormatInfo` properties that control the formatting of the result string.
        //
        // | NumberFormatInfo property | Description                                                                                                                                |
        // |---------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative.                                                                               |
        // | NumberDecimalDigits       | Defines the default number of decimal digits.This value can be overridden by using a precision specifier.                                  |
        // | NumberDecimalSeparator    | Defines the string that separates integral and decimal digits.                                                                             |
        // | NumberGroupSeparator      | Defines the string that separates groups of integral numbers.                                                                              |
        // | NumberGroupSizes          | Defines the number of integral digits that appear between group separators.                                                                |
        // | NumberNegativePattern     | Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the NegativeSign property. |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#NFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the 'N' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'N' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard numeric formatting rules for culture, including digit grouping.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:1234.567 --Format:N  --Culture:en-US}}", @"^1,234\.567$")]
        [DataRow("{{$Format-Number --Number:1234.567 --Format:N  --Culture:ru-RU}}", @"^1\s234,567$")]
        [DataRow("{{$Format-Number --Number:1234     --Format:N1 --Culture:en-US}}", @"^1,234\.0$")]
        [DataRow("{{$Format-Number --Number:1234     --Format:N1 --Culture:ru-RU}}", @"^1\s234,0$")]
        [DataRow("{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:en-US}}", @"^-1,234\.560$")]
        [DataRow("{{$Format-Number --Number:-1234.56 --Format:N3 --Culture:ru-RU}}", @"^-1\s234,560$")]
        #endregion
        public void T0001I(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The percent (`P`) format specifier multiplies a number by 100 and converts it to a string that represents a percentage.
        // The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the default
        // numeric precision supplied by the current PercentDecimalDigits property is used.
        //
        // The following table lists the NumberFormatInfo properties that control the formatting of the returned string.
        //
        // | NumberFormatInfo property | Description                                                                                                                       |
        // |---------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
        // | NegativeSign              | Defines the string that indicates that a number is negative.                                                                      |
        // | PercentDecimalDigits      | Defines the default number of decimal digits in a percentage value.This value can be overridden by using the precision specifier. |
        // | PercentDecimalSeparator   | Defines the string that separates integral and decimal digits.                                                                    |
        // | PercentGroupSeparator     | Defines the string that separates groups of integral numbers.                                                                     |
        // | PercentGroupSizes         | Defines the number of integer digits that appear in a group.                                                                      |
        // | PercentNegativePattern    | Defines the placement of the percent symbol and the negative symbol for negative values.                                          |
        // | PercentPositivePattern    | Defines the placement of the percent symbol for positive values.                                                                  |
        // | PercentSymbol             | Defines the percent symbol.                                                                                                       |
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#PFormatString
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the 'P' format specifier " +
            "with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'P' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using the specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows standard percentage formatting rules for culture.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:1        --Format:P  --Culture:en-US}}", @"^100\.\d+\s?\%$")]
        [DataRow("{{$Format-Number --Number:1        --Format:P  --Culture:fr-FR}}", @"^100,\d+\s?\%$")]
        [DataRow("{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:en-US}}", @"^-39\.7\s?\%$")]
        [DataRow("{{$Format-Number --Number:-0.39678 --Format:P1 --Culture:fr-FR}}", @"^-39,7\s?\%$")]
        #endregion
        public void T0001J(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `0` custom format specifier serves as a zero-placeholder symbol. If the value that is being formatted
        // has a digit in the position where the zero appears in the format string, that digit is copied to the result
        // string; otherwise, a zero appears in the result string. The position of the leftmost zero before the decimal
        // point and the rightmost zero after the decimal point determines the range of digits that are always present
        // in the result string.
        //
        // The `00` specifier causes the value to be rounded to the nearest digit preceding the decimal, where rounding
        // away from zero is always used.For example, formatting 34.5 with `00` would result in the value 35.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-0-custom-specifier
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the '00.0000' custom " +
            "format specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the custom '00.0000' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '00.0000'.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:0.45678 --Format:00.0000 --Culture:en-US}}", @"^00\.\d{4}$")]
        [DataRow("{{$Format-Number --Number:0.45678 --Format:0.00    --Culture:fr-FR}}", "^0,46$")]
        #endregion
        public void T0001K(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `#` custom format specifier serves as a digit-placeholder symbol. If the value that is being formatted
        // has a digit in the position where the `#` symbol appears in the format string, that digit is copied to the
        // result string. Otherwise, nothing is stored in that position in the result string.
        //
        // Note that this specifier never displays a zero that is not a significant digit, even if zero is the only digit
        // in the string. It will display zero only if it is a significant digit in the number that is being displayed.
        //
        // The `##` format string causes the value to be rounded to the nearest digit preceding the decimal, where rounding
        // away from zero is always used. For example, formatting 34.5 with `##` would result in the value 35.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the '#' custom format " +
            "specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the custom '#' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '#' with rounding.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:0.45678    --Format:#.##   --Culture:en-US}}", @"^\.46$")]
        [DataRow("{{$Format-Number --Number:0.45678    --Format:#.##   --Culture:fr-FR}}", "^,46$")]
        [DataRow("{{$Format-Number --Number:1234567890 --Format:(###) ###-####}}", @"^\(123\) 456-7890$")]
        #endregion
        public void T0001L(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `.` custom format specifier inserts a localized decimal separator into the result string. The first period in the
        // format string determines the location of the decimal separator in the formatted value; any additional periods are ignored.
        // If the format specifier ends with a `.` only the significant digits are formatted into the result string.
        //
        //The character that is used as the decimal separator in the result string is not always a period; it is determined by the
        //NumberDecimalSeparator property of the NumberFormatInfo object that controls formatting.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-1
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the '.' custom format " +
            "specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the custom '.' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '0.00' with localized decimal separator.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:en-US}}", @"^0\.46$")]
        [DataRow("{{$Format-Number --Number:0.45678 --Format:0.00 --Culture:fr-FR}}", "^0,46$")]
        #endregion
        public void T0001M(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The `,` character serves as both a group separator and a number scaling specifier.
        // ### Group Separator
        //
        // If one or more commas are specified between two digit placeholders(0 or #) that format the integral digits of a number,
        // a group separator character is inserted between each number group in the integral part of the output.
        //
        // The NumberGroupSeparator and NumberGroupSizes properties of the current NumberFormatInfo object determine the character
        // used as the number group separator and the size of each number group.For example, if the string `#,#` and the invariant
        // culture are used to format the number 1000, the output is `1,000`.
        //
        // ### Number Scaling Specifier
        //
        // If one or more commas are specified immediately to the left of the explicit or implicit decimal point, the number to be
        // formatted is divided by 1000 for each comma. For example, if the string `0,,` is used to format the number 100 million,
        // the output is `100`.
        //
        // You can use group separator and number scaling specifiers in the same format string. For example, if the string `#,0,,`
        // and the invariant culture are used to format the number one billion, the output is `1,000`.
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-2
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify the correct formatting of a decimal number using the ',' custom format " +
            "specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the custom ',' format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '##,#' with localized group separator.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:2147483647 --Format:##,#   --Culture:en-US}}", "^2,147,483,647$")]
        [DataRow("{{$Format-Number --Number:2147483647 --Format:##,#   --Culture:es-ES}}", "^2.147.483.647$")]
        [DataRow("{{$Format-Number --Number:2147483647 --Format:#,#,,  --Culture:en-US}}", "^2,147$")]
        [DataRow("{{$Format-Number --Number:2147483647 --Format:#,#,,  --Culture:es-ES}}", "^2.147$")]
        #endregion
        public void T0001N(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // A percent sign (%) in a format string causes a number to be multiplied by 100 before it is formatted. The localized
        // percent symbol is inserted in the number at the location where the % appears in the format string. The percent character
        // used is defined by the PercentSymbol property of the current NumberFormatInfo object.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-3
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the decimal number is correctly multiplied by 100 and formatted as " +
            "a percentage using the '%' custom format specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is multiplied by 100 and correctly formatted as a percentage using the '%' custom format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '%#0.00' with a localized percent symbol.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:0.3697  --Format:%#0.00 --Culture:en-US}}", "^%36.97$")]
        [DataRow("{{$Format-Number --Number:0.3697  --Format:%#0.00 --Culture:el-GR}}", "^%36,97$")]
        [DataRow("{{$Format-Number --Number:0.3697  --Format:##.0 % --Culture:en-US}}", @"^37.0 \%$")]
        [DataRow("{{$Format-Number --Number:0.3697  --Format:##.0 % --Culture:el-GR}}", @"^37,0 \%$")]
        #endregion
        public void T0001O(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // A per mille character (`‰` or `\u2030`) in a format string causes a number to be multiplied by `1000` before it is formatted.
        // The appropriate per mille symbol is inserted in the returned string at the location where the `‰` symbol appears in the
        // format string. The per mille character used is defined by the NumberFormatInfo.PerMilleSymbol property of the object that
        // provides culture-specific formatting information.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--custom-specifier-4
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the decimal number is correctly multiplied by 1000 and formatted " +
            "using the '‰' custom format specifier with a specified culture.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is multiplied by 1000 and correctly formatted using the '‰' custom format specifier.")]
        [AcceptanceCriteria(criteria: "Culture Specification: The formatting is performed using a specified culture.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '#0.00‰' with a localized per mille symbol.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:0.03697 --Format:#0.00‰      --Culture:en-US}}", "^36.97‰$")]
        [DataRow("{{$Format-Number --Number:0.03697 --Format:#0.00‰      --Culture:ru-RU}}", "^36,97‰$")]
        [DataRow("{{$Format-Number --Number:0.03697 --Format:#0.00\u2030 --Culture:en-US}}", "^36.97‰$")]
        [DataRow("{{$Format-Number --Number:0.03697 --Format:#0.00\u2030 --Culture:ru-RU}}", "^36,97‰$")]
        #endregion
        public void T0001P(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // If any of the strings `E`, `E+`, `E-`, `e`, `e+`, or `e-` are present in the format string and are followed immediately
        // by at least one zero, the number is formatted by using scientific notation with an `E` or `e` inserted between the number
        // and the exponent. The number of zeros following the scientific notation indicator determines the minimum number of digits
        // to output for the exponent. The `E+` and `e+` formats indicate that a plus sign or minus sign should always precede the exponent.
        // The `E`, `E-`, `e`, or `e-` formats indicate that a sign character should precede only negative exponents.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-e-and-e-custom-specifiers
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the decimal number is correctly formatted using the scientific " +
            "notation with the 'e' format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The decimal number is correctly formatted using the 'e' format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number follows the specified custom format '#0.0e0'.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:987654        --Format:#0.0e0}}", "^98.8e4$")]
        [DataRow("{{$Format-Number --Number:1503.92311    --Format:0.0##e+00}}", @"^1.504e\+03$")]
        [DataRow("{{$Format-Number --Number:1.8901385E-16 --Format:0.0e+00}}", "^1.9e-16$")]
        [DataRow("{{$Format-Number --Number:86000         --Format:0.###E+0}}", "^8.6E\\+4$")]
        [DataRow("{{$Format-Number --Number:86000         --Format:0.###E+000}}", "^8.6E\\+004$")]
        [DataRow("{{$Format-Number --Number:86000         --Format:0.###E-000}}", "^8.6E004$")]
        #endregion
        public void T0001Q(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The "#", "0", ".", ",", "%", and "‰" symbols in a format string are interpreted as format specifiers rather than as literal
        // characters. Depending on their position in a custom format string, the uppercase and lowercase "E" as well as the + and - symbols
        // may also be interpreted as format specifiers.
        //
        // To prevent a character from being interpreted as a format specifier, you can precede it with a backslash, which is the escape
        // character.The escape character signifies that the following character is a character literal that should be included in the
        // result string unchanged.
        //
        // To include a backslash in a result string, you must escape it with another backslash (\\).
        //
        // > **Note**
        // >  
        // > Some compilers, such as the C++ and C# compilers, may also interpret a single backslash character as an escape character.
        // > To ensure that a string is interpreted correctly when formatting, you can use the verbatim string literal character (the @ character)
        // > before the string in C#, or add another backslash character before each backslash in C# and C++.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--escape-character
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the backslash character is used as an escape character for the " +
            "custom format specifier.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The backslash character is used to escape format specifier characters.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number includes the escaped characters '\\###00\\#'.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:987654  --Format:\\###00\\#}}", "^#987654#$")]
        [DataRow("{{$Format-Number --Number:12.345  --Format:#0.0#;(#0.0#);-\\0-}}", "^12.35$")]
        [DataRow("{{$Format-Number --Number:0       --Format:#0.0#;(#0.0#);-\\0-}}", "^-0-$")]
        [DataRow("{{$Format-Number --Number:-12.345 --Format:#0.0#;(#0.0#);-\\0-}}", @"^\(12.35\)$")]
        #endregion
        public void T0001R(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // The semicolon (`;`) is a conditional format specifier that applies different formatting to a number depending on whether its
        // value is positive, negative, or zero. To produce this behavior, a custom format string can contain up to three sections
        // separated by semicolons. These sections are described in the following table.
        //
        // | Number of sections | Description                                                                                                                          |
        // |--------------------|--------------------------------------------------------------------------------------------------------------------------------------|
        // | One section        | The format string applies to all values.                                                                                             |
        // | Two sections       | The first section applies to positive values and zeros, and the second section applies to negative values.                           |
        // | Three sections     | The first section applies to positive values, the second section applies to negative values, and the third section applies to zeros. |
        //
        // Section separators ignore any preexisting formatting associated with a number when the final value is formatted.
        // For example, negative values are always displayed without a minus sign when section separators are used.
        // If you want the final formatted value to have a minus sign, you should explicitly include the minus sign as part of the
        // custom format specifier.
        //
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the--section-separator
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the conditional format specifier ';' applies different formatting " +
            "to a number based on its value.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The semicolon (';') is used as a conditional format specifier.")]
        [AcceptanceCriteria(criteria: "Expected Format: The expected format for the number includes the conditional sections '#0.0#' and '(#0.0#)'.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:12.345  --Format:#0.0#;(#0.0#)}}", "^12.35$")]
        [DataRow("{{$Format-Number --Number:0       --Format:#0.0#;(#0.0#)}}", "^0.0$")]
        [DataRow("{{$Format-Number --Number:-12.345 --Format:#0.0#;(#0.0#)}}", @"^\(12.35\)$")]
        [DataRow("{{$Format-Number --Number:1234    --Format:##;(##)}}", "^1234$")]
        [DataRow("{{$Format-Number --Number:-1234   --Format:##;(##)}}", @"^\(1234\)$")]
        [DataRow("{{$Format-Number --Number:0       --Format:##;(##);**Zero**}}", @"^\*\*Zero\*\*$")]
        #endregion
        public void T0001S(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        // Format specifiers that appear in a custom numeric format string are always interpreted as formatting characters
        // and never as literal characters. This includes the following characters:
        //
        // - 0
        // - #
        // - %
        // - ‰
        // - '
        // - \
        // - .
        // - ,
        // - E or e, depending on its position in the format string.
        //
        // All other characters are always interpreted as character literals and, in a formatting operation, are included
        // in the result string unchanged.In a parsing operation, they must match the characters in the input string exactly; the
        // comparison is case-sensitive.
        // 
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#character-literals
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that unused characters in the format string appear as literals in the " +
            "final output.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Number Formatting: The characters that are not used for formatting, such as ',' and 'K', appear as literals in the final output.")]
        [AcceptanceCriteria(criteria: "Expected Format: The format string includes the format specifier '#,##0.0K'.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of formatting failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$Format-Number --Number:123.8 --Format:#,##0.0K}}", "^123.8K$")]
        [DataRow("{{$Format-Number --Number:9.3   --Format:##.0\\%}}", "^9.3%$")]
        [DataRow("{{$Format-Number --Number:9.3   --Format:\\'##\\'}}", "^'9'$")]
        #endregion
        public void T0001T(string macro, string expectedPattern)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
