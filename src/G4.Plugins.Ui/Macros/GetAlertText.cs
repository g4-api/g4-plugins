using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Macros.Manifests.{nameof(GetAlertText)}.json")]
    public class GetAlertText(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            try
            {
                // Attempt to retrieve the text of the alert dialog
                var macroResult = WebDriver.SwitchTo().Alert().Text;

                // Create a response with the retrieved text
                return this.NewMacroResponse(macroResult);
            }
            catch (Exception e)
            {
                // Create a G4ExceptionModel to capture information about the exception
                var exception = new G4ExceptionModel(pluginData.Rule, e.GetBaseException());

                // Add the exception to the plugin's Exceptions collection for further analysis
                Exceptions.Add(exception);

                // Create a response with an empty result in case of exception
                return this.NewMacroResponse(string.Empty);
            }
        }
    }
}
