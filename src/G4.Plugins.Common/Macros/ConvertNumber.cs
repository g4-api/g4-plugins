/*
 * RESOURCES
 * https://en.wikipedia.org/wiki/Radix
 * https://en.wikipedia.org/wiki/Two%27s_complement
 * https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(ConvertNumber)}.json")]
    public class ConvertNumber(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The From value that detects the source base from the number prefix instead of naming it.
        private const string AutoBase = "Auto";

        // The base name for binary numbers (radix 2), written with the optional 0b prefix.
        private const string BinaryBase = "Bin";

        // The base name for decimal numbers (radix 10), which never carry a prefix.
        private const string DecimalBase = "Dec";

        // The base name for hexadecimal numbers (radix 16), written with the optional 0x or # prefix.
        private const string HexadecimalBase = "Hex";

        // The base name for octal numbers (radix 8), written with the optional 0o prefix.
        private const string OctalBase = "Oct";

        // The digit alphabet shared by every supported base; a base uses its first radix characters.
        private const string Digits = "0123456789ABCDEF";

        // The Case value that writes hexadecimal letter digits as lowercase characters.
        private const string LowerCase = "Lower";

        // The Case value that writes hexadecimal letter digits as uppercase characters (the default).
        private const string UpperCase = "Upper";

        // The digit-group separators removed from the input, so 1111_0000 and 1111 0000 read as 11110000.
        private static readonly string[] Separators = ["_", " "];

        // The register sizes, in bits, that BitWidth accepts for two's complement output of negative numbers.
        private static readonly int[] BitWidths = [8, 16, 32, 64];

        // Maps each short base name to its radix; base names are not case-sensitive, so hex and HEX both resolve.
        private static readonly Dictionary<string, int> Radixes = new(StringComparer.OrdinalIgnoreCase)
        {
            [BinaryBase] = 2,
            [OctalBase] = 8,
            [DecimalBase] = 10,
            [HexadecimalBase] = 16
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the macro arguments with their documented defaults so an omitted argument keeps the contract.
            var number = pluginData.Parameters.Get("Number", string.Empty);
            var from = pluginData.Parameters.Get("From", AutoBase);
            var to = pluginData.Parameters.Get("To", DecimalBase);
            var letterCase = pluginData.Parameters.Get("Case", UpperCase);
            var width = pluginData.Parameters.Get("Width", "0");
            var bitWidth = pluginData.Parameters.Get("BitWidth", string.Empty);
            var isPrefix = pluginData.Parameters.ContainsKey("Prefix");

            // Resolve every argument into its working value; each one is null or zero when the argument is invalid.
            var value = ConvertFromText(number, from);
            var radix = GetRadix(to);
            var isWidth = int.TryParse(width, NumberStyles.None, CultureInfo.InvariantCulture, out var digitsWidth);
            var isLowerCase = letterCase.Equals(LowerCase, StringComparison.OrdinalIgnoreCase);
            var isCase = isLowerCase || letterCase.Equals(UpperCase, StringComparison.OrdinalIgnoreCase);

            // Return the original number for any invalid argument so the flow keeps its input instead of failing.
            if (value is null || radix == 0 || !isWidth || !isCase)
            {
                return this.NewMacroResponse(macroResult: number);
            }

            // Apply the requested register size so a negative number becomes its two's complement bit pattern.
            var registerValue = ConvertToBitWidth(value.Value, bitWidth);

            // Return the original number when the value does not fit the requested register size.
            if (registerValue is null)
            {
                return this.NewMacroResponse(macroResult: number);
            }

            // Write the value in the target base with the requested case, width, and prefix.
            var macroResult = FormatValue(registerValue.Value, radix, isLowerCase, digitsWidth, isPrefix);

            // Return the converted number as the macro result.
            return this.NewMacroResponse(macroResult);
        }

        // Parses the macro Number text in the base named by From and returns its signed value, or null when the text
        // is empty, the base name is unknown, or a digit does not exist in the source base. The text is trimmed, digit
        // separators are removed, and a leading + or - sign and a base prefix are accepted before the digits.
        private static BigInteger? ConvertFromText(string number, string from)
        {
            // Remove the surrounding whitespace and digit separators so grouped input parses as one digit run.
            var text = number.Trim();

            foreach (var separator in Separators)
            {
                text = text.Replace(separator, string.Empty, StringComparison.Ordinal);
            }

            // Reject empty input early so the sign and prefix checks always read an existing character.
            if (text.Length == 0)
            {
                return null;
            }

            // Read and remove the optional sign so the prefix and digits are inspected without it.
            var isNegative = text[0] == '-';
            text = text[0] is '-' or '+' ? text[1..] : text;

            // Resolve the source base and the digit run, either from the prefix (Auto) or from the named base.
            var (radix, digits) = from.Equals(AutoBase, StringComparison.OrdinalIgnoreCase)
                ? ResolveAutoSource(text)
                : ResolveNamedSource(text, radix: GetRadix(from));

            // Reject an unknown base and a prefix without digits, because neither names a number.
            if (radix == 0 || digits.Length == 0)
            {
                return null;
            }

            // Accumulate the digits most significant first; BigInteger keeps any length exact without overflow.
            var magnitude = BigInteger.Zero;

            foreach (var character in digits)
            {
                var digit = Digits.IndexOf(char.ToUpperInvariant(character), StringComparison.Ordinal);

                // Reject a digit that the source base does not contain, such as 2 in binary or G in hexadecimal.
                if (digit < 0 || digit >= radix)
                {
                    return null;
                }

                // Shift the accumulated digits one place left in the source base and add the current digit.
                magnitude = (magnitude * radix) + digit;
            }

            // Restore the sign that was read before the prefix.
            return isNegative ? -magnitude : magnitude;
        }

        // Applies the optional BitWidth register size to a signed value. Without BitWidth the value is returned as is,
        // so a negative number keeps its minus sign. With BitWidth the value must fit the signed or unsigned range of
        // that register, and a negative value becomes its two's complement bit pattern; otherwise null is returned.
        private static BigInteger? ConvertToBitWidth(BigInteger value, string bitWidth)
        {
            // Keep the signed value when no register size is requested.
            if (string.IsNullOrEmpty(bitWidth))
            {
                return value;
            }

            // Reject any register size other than the supported 8, 16, 32, and 64 bits.
            var isBits = int.TryParse(bitWidth, NumberStyles.None, CultureInfo.InvariantCulture, out var bits);

            if (!isBits || Array.IndexOf(BitWidths, bits) < 0)
            {
                return null;
            }

            // Reject a value outside the register, which spans the signed minimum to the unsigned maximum.
            var registerSize = BigInteger.One << bits;
            var minimum = -(registerSize >> 1);
            var maximum = registerSize - 1;

            if (value < minimum || value > maximum)
            {
                return null;
            }

            // Wrap a negative value into the register so its digits show the two's complement bit pattern.
            return value < 0 ? value + registerSize : value;
        }

        // Writes a signed value in the given radix. The magnitude is written with uppercase or lowercase letter digits
        // and left-padded with zeros to the requested digit width; the base prefix and the minus sign are written in
        // front of the padded digits, so -255 in hexadecimal with a prefix reads -0xFF.
        private static string FormatValue(BigInteger value, int radix, bool isLowerCase, int width, bool isPrefix)
        {
            // Collect the digits least significant first by repeated division of the magnitude.
            var magnitude = BigInteger.Abs(value);
            var digits = new Stack<char>();

            do
            {
                magnitude = BigInteger.DivRem(magnitude, radix, out var remainder);
                digits.Push(Digits[(int)remainder]);
            }
            while (magnitude > 0);

            // Apply the letter case and the zero padding to the digit run only, never to the sign or prefix.
            var digitText = string.Concat(digits);
            digitText = isLowerCase ? digitText.ToLowerInvariant() : digitText;
            digitText = digitText.PadLeft(width, '0');

            // Write the sign, then the optional base prefix, then the digits.
            var result = new StringBuilder();

            if (value < 0)
            {
                result.Append('-');
            }

            if (isPrefix)
            {
                result.Append(GetPrefix(radix));
            }

            return result.Append(digitText).ToString();
        }

        // Returns the prefix written in front of the digits of a base when the Prefix switch is set. Decimal numbers
        // have no prefix, so an empty string is returned for them.
        private static string GetPrefix(int radix) => radix switch
        {
            2 => "0b",
            8 => "0o",
            16 => "0x",
            _ => string.Empty
        };

        // Returns the radix of a short base name (Bin, Oct, Dec, Hex), ignoring case, or zero for any other name.
        // Zero marks an invalid base, so the caller returns the original number.
        private static int GetRadix(string baseName)
        {
            return Radixes.TryGetValue(baseName, out var radix) ? radix : 0;
        }

        // Detects the source base of an unsigned number from its prefix and returns the base with the digits that
        // follow the prefix: 0x or # is hexadecimal, 0b is binary, 0o or a leading zero is octal, anything else is
        // decimal. The prefix letters are not case-sensitive.
        private static (int Radix, string Digits) ResolveAutoSource(string text)
        {
            // Read the hexadecimal prefixes first, because # and 0x are unambiguous.
            if (text.StartsWith('#'))
            {
                return (16, text[1..]);
            }

            if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                return (16, text[2..]);
            }

            // Read the binary and octal letter prefixes.
            if (text.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
            {
                return (2, text[2..]);
            }

            if (text.StartsWith("0o", StringComparison.OrdinalIgnoreCase))
            {
                return (8, text[2..]);
            }

            // Read a leading zero followed by more digits as octal, following the C convention; a single 0 is decimal.
            return text.Length > 1 && text[0] == '0' ? (8, text[1..]) : (10, text);
        }

        // Returns the given base with the digits of an unsigned number written in that base. The base prefix is
        // optional (0x or # for Hex, 0b for Bin, 0o for Oct) and is removed when present; an unknown base keeps
        // radix zero so the caller rejects it.
        private static (int Radix, string Digits) ResolveNamedSource(string text, int radix)
        {
            // Remove the one-character hexadecimal prefix.
            if (radix == 16 && text.StartsWith('#'))
            {
                return (radix, text[1..]);
            }

            // Remove the two-character prefix that matches the named base.
            var prefix = GetPrefix(radix);
            var isPrefixed = prefix.Length > 0 && text.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);

            // Return the base and the digits that follow the
            // prefix, or the original text when no prefix is present.
            return isPrefixed
                ? (radix, text[prefix.Length..])
                : (radix, text);
        }
    }
}
