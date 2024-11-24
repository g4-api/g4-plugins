using G4.Attributes;
using G4.Extensions;
using G4.Models;

using Microsoft.Extensions.Logging;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(NoAction)}.json")]
    public class NoAction(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Set the invoke rules to true to invoke the rules under the this action.
            pluginData.Rule.SetInvokeRules(true);

            // Log the execution of the action with its name and argument.
            Logger.LogInformation("Executing Action: {Name} with Argument: {Argument}",
                GetType().Name,
                pluginData.Rule.Argument);

            // Return a new plugin response.
            return this.NewPluginResponse();
        }
    }
}
