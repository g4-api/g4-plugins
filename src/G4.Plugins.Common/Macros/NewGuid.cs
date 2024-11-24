using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(NewGuid)}.json")]
    public class NewGuid(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the 'Format' argument from pluginData, default to empty string if not found
            var format = pluginData.Parameters.Get("Format", string.Empty);

            // Generate a GUID using the specified format or a default format if none is provided
            var macroResult = string.IsNullOrEmpty(format)
                ? $"{Guid.NewGuid()}"
                : Guid.NewGuid().ToString(format);

            // Create and return a new PluginResponseModel containing the generated GUID macro
            return this.NewMacroResponse(macroResult);
        }
    }
}
