/*
 * RESOURCES
 * https://blog.stevex.net/string-formatting-in-csharp/
 * https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
 * https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(FormatNumber)}.json")]
    public class FormatNumber(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve parameters from plugin data
            var culture = pluginData.Parameters.Get("Culture", string.Empty);
            var number = pluginData.Parameters.Get("Number", "0");
            var format = pluginData.Parameters.Get("Format", "None");

            // Create format provider based on specified culture
            var formatProvider = NewFormatProvider(culture);

            // Check if the input number is a double or an integer
            var isDouble = Regex.IsMatch(input: number, @"^-?(?!0\d)\d*(\.\d+)([Ee]-\d+)?$");
            var isInteger = !isDouble && Regex.IsMatch(input: number, @"^-?(?!0)\d+$|^0$");

            // If the input number is neither a double nor an integer, return the original number
            // Format the number according to the specified format
            // If format is "None", return the original number
            // Otherwise, format the number
            if ((!isDouble && !isInteger) || format.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                return this.NewMacroResponse(macroResult: number);
            }

            // Determine the number type based on whether it's a double or specified explicitly in the plugin data
            // If the number is a double, set the number type as "DOUBLE"
            // Otherwise, get the number type from plugin data or default to "Integer"
            var numberType = isDouble
                ? "DOUBLE"
                : pluginData.Parameters.Get("NumberType", "Integer").ToUpper();

            // Format the number based on its type
            // If number type is "BYTE", format as byte
            // If number type is "DOUBLE", format as double
            // If number type is "INTEGER", format as integer
            // If number type is "LONG", format as long
            // If number type is "SBYTE", format as signed byte
            // Default to formatting as integer if number type is not recognized
            var macroResult = numberType switch
            {
                "BYTE" => NewByte(number).ToString(format, formatProvider),
                "DOUBLE" => NewDouble(number).ToString(format, formatProvider),
                "INTEGER" => NewInteger(number).ToString(format, formatProvider),
                "LONG" => NewLong(number).ToString(format, formatProvider),
                "SBYTE" => NewUnsignedByte(number).ToString(format, formatProvider),
                _ => NewInteger(number).ToString(format, formatProvider)
            };

            // Return formatted number as plugin response
            return this.NewMacroResponse(macroResult);
        }

        // Converts the specified string to a byte value.
        private static byte NewByte(string number)
        {
            // Attempt to parse the string to a byte value
            _ = byte.TryParse(number, out byte byteOut);

            // Return the converted byte value, or 0 if conversion fails
            return byteOut;
        }

        // Converts the specified string to a double-precision floating point number.
        private static double NewDouble(string number)
        {
            // Attempt to parse the string to a double value
            _ = double.TryParse(number, out double doubleOut);

            // Return the converted double value, or 0 if conversion fails
            return doubleOut;
        }

        // Creates a CultureInfo object based on the specified culture.
        // If culture is not specified or invalid, returns InvariantCulture.
        private static CultureInfo NewFormatProvider(string culture)
        {
            try
            {
                // Return InvariantCulture if culture is not specified
                // Otherwise, create CultureInfo object with specified culture
                return string.IsNullOrEmpty(culture)
                    ? CultureInfo.InvariantCulture
                    : new CultureInfo(culture, false);
            }
            catch
            {
                // Return InvariantCulture if an exception occurs during CultureInfo creation
                return CultureInfo.InvariantCulture;
            }
        }

        // Converts the specified string to an integer value.
        private static int NewInteger(string number)
        {
            // Attempt to parse the string to an integer value
            _ = int.TryParse(number, out int intOut);

            // Return the converted integer value, or 0 if conversion fails
            return intOut;
        }

        // Converts the specified string to a long value.
        private static long NewLong(string number)
        {
            // Attempt to parse the string to a long value
            _ = long.TryParse(number, out long longOut);

            // Return the converted long value, or 0 if conversion fails
            return longOut;
        }

        // Converts the specified string to a signed byte value.
        private static sbyte NewUnsignedByte(string number)
        {
            // Attempt to parse the string to a signed byte value
            _ = sbyte.TryParse(number, out sbyte byteOut);

            // Return the converted signed byte value, or 0 if conversion fails
            return byteOut;
        }
    }
}
