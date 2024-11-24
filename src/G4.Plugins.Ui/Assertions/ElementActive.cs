using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementActive)}.json")]
    public class ElementActive(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method to check if the element is active.
            bool ConfirmElementActive() => this
                .FindElement(pluginData.Rule, pluginData.Element)
                .Equals(WebDriver.SwitchTo().ActiveElement());

            // Call the base method to get the assertion response.
            return this.NewAssertResponse(
                pluginData,
                factory: ConfirmElementActive);
        }
    }
}
