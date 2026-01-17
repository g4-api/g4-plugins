using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Macros.Manifests.{nameof(NewScriptResult)}.json")]
    public class NewScriptResult(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Options for JSON serialization and deserialization.
        private static readonly JsonSerializerOptions s_jsonOptions = new()
        {
            // Allows trailing commas in JSON objects and arrays.
            AllowTrailingCommas = true,

            // Makes property name comparison case-insensitive during deserialization.
            PropertyNameCaseInsensitive = true
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Initialize the macro result string.
            var macroResult = string.Empty;

            try
            {
                // Retrieve the script and script arguments from the plugin data.
                var script = pluginData.Parameters.Get("Src", string.Empty);
                var scriptArguments = GetScriptArguments(pluginData);

                // Invoke the WebDriver script with the provided script and arguments, and convert the result to a string.
                macroResult = $"{WebDriver.InvokeScript(script, scriptArguments)}";
            }
            catch (Exception e)
            {
                // If an exception occurs, create an exception model and add it to the exceptions list.
                var exceptionModel = new G4ExceptionModel(rule: pluginData.Rule, exception: e);
                Exceptions.Add(exceptionModel);
            }

            // Create and return a new macro response with the macro result.
            return this.NewMacroResponse(macroResult);
        }

        // Retrieves the script arguments from the plugin data and converts them to an array of objects.
        private static object[] GetScriptArguments(PluginDataModel pluginData)
        {
            // Get the arguments collection from plugin data, defaulting to an empty array if not found.
            var argumentsCollection = pluginData.Parameters.Get("Arg", "[]");

            // If the arguments collection is empty, return an empty array.
            if (argumentsCollection.Equals("[]"))
            {
                return [];
            }

            // Check if the argumentsCollection starts with '[' and ends with ']'
            // If it does, keep the argumentsCollection as it is
            // If it doesn't, wrap the argumentsCollection with '[' and ']'
            argumentsCollection = argumentsCollection.StartsWith('[') && argumentsCollection.EndsWith(']')
                ? argumentsCollection
                : $"[{argumentsCollection}]";

            // Deserialize the arguments collection to an array of objects.
            var arguments = JsonSerializer.Deserialize<object[]>(argumentsCollection);
            var argumentsResult = new List<object>();

            foreach (var argument in arguments)
            {
                // Convert the argument to a string.
                var argumentStr = $"{argument}";

                // Check if the argument represents a decimal number.
                var isDecimal = ConfirmDecimal(input: argumentStr);

                // Check if the argument represents a JSON.
                var isObject = !isDecimal && argumentStr.AssertJson();

                // Determine if the argument is a string.
                var isString = !isDecimal && !isObject;

                // Process the argument based on its type.
                if (isDecimal)
                {
                    // Convert the argument to a decimal number.
                    var value = ConvertToDecimal(s: argumentStr);
                    argumentsResult.Add(value);
                    continue;
                }

                if (isObject)
                {
                    // Convert the argument to an object.
                    var value = ConvertToObject(s: argumentStr);
                    argumentsResult.Add(value);
                    continue;
                }

                if (isString)
                {
                    // Add the argument as a string.
                    argumentsResult.Add(argumentStr);
                }
            }

            // Return the array of processed arguments.
            return [.. argumentsResult];
        }

        // Confirms whether the input string represents a decimal number.
        private static bool ConfirmDecimal(string input)
        {
            // Regular expression pattern to match decimal numbers.
            const string Pattern = @"^-?(?!0\d)\d*(\.\d+)([Ee]-\d+)?$|^-?(?!0)\d+$|^0$";

            // Check if the input string matches the pattern.
            return Regex.IsMatch(input, Pattern);
        }

        // Converts the specified string to a decimal number.
        private static double ConvertToDecimal(string s)
        {
            // Attempt to parse the string to a double value
            _ = double.TryParse(s, out double result);

            // Return the converted double value, or 0 if conversion fails
            return result;
        }

        // Converts the specified JSON string to an object.
        private static object ConvertToObject(string s)
        {
            // Deserialize the JSON string to an object using the specified options.
            return JsonSerializer.Deserialize<object>(json: s, s_jsonOptions);
        }
    }
}
