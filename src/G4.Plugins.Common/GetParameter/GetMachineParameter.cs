﻿using G4.Attributes;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Common.GetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.GetParameter.Manifests.{nameof(GetMachineParameter)}.json")]
    public class GetMachineParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the environment variable value for the specified element (variable name)
            var onElement = pluginData.Rule.OnElement;
            var parameter = Environment.GetEnvironmentVariable(onElement, EnvironmentVariableTarget.Machine);

            // If the retrieved parameter is null or empty, set the value to an empty string
            var value = string.IsNullOrEmpty(parameter)
                ? string.Empty
                : parameter;

            // Create a PluginResponseModel with the retrieved parameter as an entity
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
