using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Engine;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
    assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
    manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(StopFlow)}.json")]
    public class StopFlow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Obtain the unique identifier (opaque key) for the current WebDriver session.
            var id = WebDriver.GetSession().OpaqueKey;

            // Dispose the WebDriver instance to release any browser/process resources.
            WebDriver.Dispose();

            // Remove the driver from the global registry so it can't be referenced later.
            // If the key does not exist, TryRemove will return false and the discard (_) ignores the value.
            AutomationInvoker.Drivers.TryRemove(id, out _);

            // Return a standard success response for this plugin action.
            return this.NewPluginResponse();
        }
    }
}
