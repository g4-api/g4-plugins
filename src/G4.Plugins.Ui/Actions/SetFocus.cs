using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SetFocus)}.json")]
    public class SetFocus(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the element based on the action and provided element
            var onElement = this.GetElement(pluginData.Rule, pluginData.Element);

            // Ensure the element exists before proceeding
            if (onElement == default)
            {
                return this.NewPluginResponse();
            }

            // Move to the element to set focus
            WebDriver.InvokeScript("arguments[0].focus();", onElement);

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
