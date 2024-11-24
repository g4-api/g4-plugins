using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Common.SetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.SetParameter.Manifests.{nameof(SetMachineParameter)}.json")]
    public class SetMachineParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the name and value from the action rule.
            var name = pluginData.Rule.OnElement;
            var value = pluginData.Parameters.Get("Value", string.Empty);

            // Set the machine-level environment variable.
            Environment.SetEnvironmentVariable(name, $"{value}", EnvironmentVariableTarget.Machine);

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
