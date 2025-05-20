using System.Linq;

using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SendHttpRequest)}.json")]
    public class SendHttpRequest(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Constants for keys in the plugin data.
            const string Method = "Method";

            // Retrieve the HTTP method and URL from the plugin data.
            var method = pluginData.Parameters.Get(key: Method, defaultValue: "Get");

            // Create a new action rule model for the HTTP method.
            var httpMethodRule = new ActionRuleModel
            {
                Argument = pluginData.Rule.Argument,
                Iteration = pluginData.Rule.Iteration,
                Locator = pluginData.Rule.Locator,
                OnAttribute = pluginData.Rule.OnAttribute,
                OnElement = pluginData.Rule.OnElement,
                PluginName = method,
                RegularExpression = pluginData.Rule.RegularExpression
            };

            // Set the reference for the action rule, linking it to the job reference and parent reference.
            httpMethodRule.Reference = httpMethodRule.NewReference(jobReference: pluginData.Rule.Reference.JobReference);
            httpMethodRule.Reference.ParentReference = pluginData.Rule.Reference;

            // Send the HTTP request using the chosen HTTP method plugin and return the response.
            return Invoker.Invoke(httpMethodRule).First();
        }
    }
}
