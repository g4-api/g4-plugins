using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(GetSessionId)}.json")]
    public class GetSessionId(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the session ID from the current WebDriver instance.
            var sessionId = WebDriver.GetSession().OpaqueKey;

            // Create and return a new PluginResponseModel containing the session ID.
            return this.NewMacroResponse(sessionId);
        }
    }
}
