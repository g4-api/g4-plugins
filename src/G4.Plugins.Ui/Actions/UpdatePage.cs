using G4.Attributes;
using G4.Models;
using G4.Plugins.Ui.Actions.Abstraction;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(UpdatePage)}.json")]
    public class UpdatePage(G4PluginSetupModel pluginSetup) : NavigateBase(pluginSetup)
    {
        protected override void InvokeNavigationAction(PluginDataModel pluginData)
        {
            WebDriver.Navigate().Update();
        }
    }
}
