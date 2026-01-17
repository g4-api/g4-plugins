using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeScript)}.json")]
    public class InvokeScript(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // JSON serialization options for customizing the behavior of the JSON serializer.
        private static readonly JsonSerializerOptions s_jsonSerializerOptions = new()
        {
            // Allow trailing commas in JSON objects and arrays.
            AllowTrailingCommas = true,

            // Specify that properties marked with JsonIgnore attribute should never be ignored.
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,

            // Allow the use of named floating-point literals in JSON, e.g., NaN, Infinity.
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,

            // Make property name comparison case-insensitive during deserialization.
            PropertyNameCaseInsensitive = true
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the script block from the plugin data, defaulting to the rule's argument if not specified
            var script = pluginData
                .Parameters
                .Get(key: "ScriptBlock", defaultValue: pluginData.Rule.Argument);

            // Retrieve the target element based on the rule and element specified in the plugin data
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Extract and deserialize the arguments data, defaulting to null if not provided or invalid JSON
            var argumentsData = pluginData.Parameters.Get("Arguments", defaultValue: default(string));
            var arguments = !string.IsNullOrEmpty(argumentsData) && argumentsData.AssertJson()
                ? JsonSerializer.Deserialize<object[]>(argumentsData, s_jsonSerializerOptions)
                : [];

            // If both element and arguments are present, prepend the element to the arguments array
            arguments = element != null
                ? [element, .. arguments]
                : arguments;

            // Invoke the script with the specified arguments using the WebDriver
            // Store the script result in the session parameters for future reference
            Invoker.Context.SessionParameters["ScriptResult"] = WebDriver.InvokeScript(script, arguments);

            // Create and return a new PluginResponseModel
            return this.NewPluginResponse();
        }
    }
}
