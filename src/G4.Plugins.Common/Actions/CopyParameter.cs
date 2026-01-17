using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(CopyParameter)}.json")]
    public class CopyParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define the default scope as "Session" for source and target parameters
            const string defaultScope = "Session";

            // Retrieve the source and target parameters from the plugin data arguments
            var sourceParameter = pluginData.Rule.OnElement;
            var targetParameter = pluginData.Parameters.Get("TargetParameter", string.Empty);
            var environment = pluginData.Parameters.Get("Environment", "SystemParameters");

            // Retrieve the source and target scopes from the plugin data arguments,
            // using "defaultScope" as the default value if not specified
            var sourceScope = string.IsNullOrEmpty(pluginData.Rule.OnAttribute)
                ? defaultScope
                : pluginData.Rule.OnAttribute;
            var targetScope = pluginData.Parameters.Get("TargetScope", defaultScope);

            // Create plugin data to retrieve the source parameter value
            var getParameterPluginData = new PluginDataModel
            {
                Rule = new ActionRuleModel
                {
                    Argument = "{{$ --Environment:" + environment + "}}",
                    OnElement = sourceParameter,
                    PluginName = sourceScope
                }
            };

            // Create a new plugin instance to retrieve the value of the source parameter
            var getParameterPlugin = Invoker
                .PluginFactoryAdapter
                .GetParameterPluginFactory
                .NewPlugin(driver: WebDriver, invoker: Invoker, rule: getParameterPluginData.Rule);

            // Send the getParameterPluginData to retrieve the value
            // The retrieved value is stored in the "value" variable for further use
            var value = $"{getParameterPlugin.Send(getParameterPluginData).Entity["Parameter"]}";

            // Create plugin data to set the target parameter with the retrieved value
            var setParameterPluginData = new PluginDataModel
            {
                Rule = new ActionRuleModel
                {
                    Argument = "{{$ --Environment:" + environment + " --Value:" + value + "}}",
                    OnElement = targetParameter,
                    PluginName = targetScope,
                }
            };

            // Create a new plugin instance for setting the target parameter with the retrieved value
            var setParameterPlugin = Invoker
                .PluginFactoryAdapter
                .SetParameterPluginFactory
                .NewPlugin(driver: WebDriver, invoker: Invoker, rule: setParameterPluginData.Rule);

            // Send the setParameterPluginData to set the target parameter with the retrieved value
            var response = setParameterPlugin.Send(pluginData: setParameterPluginData);

            // Create and return a new PluginResponseModel to indicate the success of the operation
            return this.NewPluginResponse(response);
        }
    }
}
