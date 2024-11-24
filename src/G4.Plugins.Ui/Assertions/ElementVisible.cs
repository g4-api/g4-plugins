using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementVisible)}.json")]
    public class ElementVisible(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method to check if the element is displayed.
            bool ConfirmElementVisibility() => this
                .FindElement(pluginData.Rule, pluginData.Element)
                .Displayed;

            // Get the assertion response for ElementVisible condition.
            return this.NewAssertResponse(pluginData, factory: ConfirmElementVisibility);
        }
    }
}
