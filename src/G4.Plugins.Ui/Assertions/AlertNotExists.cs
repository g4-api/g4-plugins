using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(AlertNotExists)}.json")]
    public class AlertNotExists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            return this.NewAssertResponse(
                pluginData,
                factory: () => WebDriver?.ConfirmAlert() == false);
        }
    }
}
