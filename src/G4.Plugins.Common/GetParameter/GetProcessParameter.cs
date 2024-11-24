using G4.Attributes;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Common.GetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.GetParameter.Manifests.{nameof(GetProcessParameter)}.json")]
    public class GetProcessParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the environment variable for the specified element
            var onElement = pluginData.Rule.OnElement;
            var parameter = Environment.GetEnvironmentVariable(onElement, EnvironmentVariableTarget.Process);

            // Determine the value to return based on whether the environment variable exists
            var value = string.IsNullOrEmpty(parameter)
                ? string.Empty
                : parameter;

            // Create and return a PluginResponseModel with the retrieved value
            return new()
            {
                Entity = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    ["Parameter"] = value
                }
            };
        }
    }
}
