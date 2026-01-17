using G4.Attributes;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Common.GetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.GetParameter.Manifests.{nameof(GetSessionParameter)}.json")]
    public class GetSessionParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the value of the session parameter
            var onElement = pluginData.Rule.OnElement;
            var value = Invoker.Context.SessionParameters.TryGetValue(onElement, out object valueOut)
                ? $"{valueOut}"
                : string.Empty;

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
