using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Actions
{
    // TODO: send the method action using Invoker.Invoke() and not directly to "Send"
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SendHttpRequest)}.json")]
    public class SendHttpRequest(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Constants for keys in the plugin data.
            const string Url = "Url";
            const string Method = "Method";

            // Retrieve the HTTP method and URL from the plugin data.
            var method = pluginData.Parameters.Get(key: Method, defaultValue: "Get");
            var url = pluginData.Parameters.Get(key: Url, defaultValue: pluginData.Rule.Argument);

            // Create a new action rule model for the HTTP method.
            var methodRule = new ActionRuleModel
            {
                PluginName = method,
                Iteration = pluginData.Rule.Iteration
            };

            // Set the reference for the action rule, linking it to the job reference and parent reference.
            methodRule.Reference = methodRule.NewReference(jobReference: pluginData.Rule.Reference.JobReference);
            methodRule.Reference.ParentReference = pluginData.Rule.Reference;

            // Create an instance of the appropriate HTTP method plugin based on the specified method.
            var httpMethodPlugin = Invoker
                .PluginFactoryAdapter
                .HttpMethodFactory
                .NewPlugin(driver: WebDriver, invoker: Invoker, rule: methodRule);

            // Update the plugin data with the resolved HTTP method and URL.
            pluginData.Parameters[Method] = method;
            pluginData.Parameters[Url] = url;

            // Send the HTTP request using the chosen HTTP method plugin and return the response.
            return httpMethodPlugin.Send(pluginData);
        }
    }
}
