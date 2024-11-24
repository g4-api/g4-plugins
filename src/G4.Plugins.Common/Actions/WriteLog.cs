using G4.Attributes;
using G4.Extensions;
using G4.Models;

using Microsoft.Extensions.Logging;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(WriteLog)}.json")]
    public class WriteLog(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Log the plugin data's argument using the logger
            Logger.LogInformation("{Argument}", pluginData.Rule.Argument);

            // Return a new plugin response
            return this.NewPluginResponse();
        }
    }
}
