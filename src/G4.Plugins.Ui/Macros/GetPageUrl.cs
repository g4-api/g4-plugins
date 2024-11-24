using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Macros.Manifests.{nameof(GetPageUrl)}.json")]
    public class GetPageUrl(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            try
            {
                // Get the current URL from the WebDriver's navigation and apply the specified regex pattern
                var macroResult = WebDriver.Navigate().Url;

                // Create a response with the extracted URL
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
