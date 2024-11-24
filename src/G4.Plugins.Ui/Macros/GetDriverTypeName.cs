using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Macros.Manifests.{nameof(GetDriverTypeName)}.json")]
    public class GetDriverTypeName(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            try
            {
                // Get the full name of the WebDriver's type.
                var macroResult = WebDriver.GetType().FullName;

                // Create a new response using the extracted driver type name.
                return this.NewMacroResponse(macroResult);
            }
            catch (Exception e)
            {
                // If an exception occurs, create an G4ExceptionModel to capture the details.
                var exception = new G4ExceptionModel(pluginData.Rule, e.GetBaseException());

                // Add the exception to the list of exceptions.
                Exceptions.Add(exception);

                // Return an empty response in case of an exception.
                return this.NewMacroResponse(string.Empty);
            }
        }
    }
}
