using G4.Attributes;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Common.GetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.GetParameter.Manifests.{nameof(GetUserParameter)}.json")]
    public class GetUserParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the user-level environment parameter
            var onElement = pluginData.Rule.OnElement;
            var parameter = Environment.GetEnvironmentVariable(onElement, EnvironmentVariableTarget.User);

            // Check if the parameter is null or empty
            var value = string.IsNullOrEmpty(parameter)
                ? string.Empty
                : parameter;

            // Create a response model with the retrieved parameter value
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
