using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Linq;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementCount)}.json")]
    public class ElementCount(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory function to retrieve the element count as a string.
            string GetElementsCount() => this
                .FindElements(pluginData.Rule, pluginData.Element)
                .Count()
                .ToString();

            // Use the factory function to get the element count and create an assertion response.
            return this.NewAssertResponse(pluginData, factory: GetElementsCount);
        }
    }
}
