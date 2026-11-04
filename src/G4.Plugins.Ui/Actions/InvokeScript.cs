using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Remote;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{NameReference}.json")]
    public class InvokeScript(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(InvokeScript);

        // JSON serialization options for customizing the behavior of the JSON serializer.
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
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

            // Decode the script from Base64 when the Base64 switch is provided so a script carrying characters
            // the CLI parser would otherwise split can be supplied safely as a single encoded value.
            // ConvertFromBase64 returns the original text on a decoding failure, leaving invalid input untouched.
            script = pluginData.Parameters.ContainsKey(key: "Base64")
                ? script.ConvertFromBase64()
                : script;

            // Resolve the element to inject as arguments[0]; the context element is passed only on request
            var element = ResolveScriptElement(plugin: this, pluginData);

            // Extract and deserialize the arguments data, defaulting to null if not provided or invalid JSON
            var argumentsData = pluginData.Parameters.Get("Arguments", defaultValue: default(string));
            var arguments = !string.IsNullOrEmpty(argumentsData) && argumentsData.AssertJson()
                ? JsonSerializer.Deserialize<object[]>(argumentsData, _jsonSerializerOptions)
                : [];

            // If both element and arguments are present, prepend the element to the arguments array
            arguments = element != null
                ? [element, .. arguments]
                : arguments;

            // Invoke the script with the specified arguments using the WebDriver
            // Store the script result in the session parameters for future reference
            Invoker.Context.SessionParameters[$"{NameReference}:ScriptResult"] = WebDriver.InvokeScript(script, arguments);

            // Create and return a new PluginResponseModel
            return this.NewPluginResponse();
        }

        // Resolves the element to inject into the script as arguments[0]. An empty OnElement passes no element,
        // even when the rule runs inside a loop or an extraction scope, so a script never receives an inherited
        // element it did not ask for (for example, one from another window after a SwitchWindow). A "." OnElement
        // passes the context element as is, and any other OnElement is located as usual.
        private static IWebElement ResolveScriptElement(PluginBase plugin, PluginDataModel pluginData)
        {
            // The OnElement value that selects the context element.
            const string ContextElement = ".";

            // Read the requested element locator from the rule.
            var onElement = pluginData.Rule.OnElement;

            // Pass no element when none is requested, ignoring any inherited context element.
            if (string.IsNullOrEmpty(onElement))
            {
                return null;
            }

            // Locate any explicit element, relative to the context element when one exists.
            if (!onElement.Equals(ContextElement, StringComparison.Ordinal))
            {
                return plugin.GetElement(pluginData.Rule, pluginData.Element);
            }

            // Pass the context element when one exists.
            if (pluginData.Element != null)
            {
                return pluginData.Element;
            }

            // Fail loudly when the context element is requested outside a loop or an extraction scope.
            var message = "The OnElement value '.' requires a context element, " +
                "but the rule does not run inside a loop or an extraction scope.";
            throw new NoSuchElementException(message);
        }
    }
}
