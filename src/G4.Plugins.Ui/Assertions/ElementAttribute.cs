using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementAttribute)}.json")]
    public class ElementAttribute(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method to get the element attribute.
            string GetElementAttribute()
            {
                // Find the target element based on the action rule and provided element.
                var element = this.FindElement(pluginData.Rule, pluginData.Element);

                // If the attribute is "value", return the value of the element.
                // Otherwise, return the value of the specified attribute of the element.
                return pluginData.Rule.OnAttribute == "value"
                    ? element.GetValue()
                    : element.GetAttribute(pluginData.Rule.OnAttribute);
            }

            // Call the base method to get the assertion response.
            return this.NewAssertResponse(pluginData, factory: GetElementAttribute);
        }
    }
}
