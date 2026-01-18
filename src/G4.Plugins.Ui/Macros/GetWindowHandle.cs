using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Macros.Manifests.{nameof(GetWindowHandle)}.json")]
    public class GetWindowHandle(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the index from the arguments, defaulting to 0 if not provided or invalid
            var index = pluginData.Parameters.Get("Index", "0");

            // Try parsing the index from arguments
            _ = int.TryParse(index, out int indexOut);

            try
            {
                // Get the window handle at the specified index
                var handle = WebDriver.WindowHandles[indexOut];

                // Create a response with the retrieved window handle
                return this.NewMacroResponse(handle);
            }
            catch (Exception e)
            {
                // Handle exceptions and create a response with the exception information
                var exception = new G4ExceptionModel(pluginData.Rule, e.GetBaseException());
                Exceptions.Add(exception);

                // Create a response with an empty result in case of exception
                return this.NewMacroResponse(string.Empty);
            }
        }
    }
}
