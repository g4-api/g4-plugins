using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Common.GetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.GetParameter.Manifests.{nameof(GetApplicationParameter)}.json")]
    public class GetApplicationParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Without an explicit --Environment, read from the automation's default environment
            // (as SetApplicationParameter writes to it), falling back to SystemParameters.
            var defaultEnvironment = string.IsNullOrEmpty(Automation?.Settings?.EnvironmentsSettings?.DefaultEnvironment)
                ? "SystemParameters"
                : Automation.Settings.EnvironmentsSettings.DefaultEnvironment;

            // Retrieve the application parameter based on the provided element name
            var parameters = G4Environment.ApplicationParameters;
            var environment = pluginData.Parameters.Get("Environment", defaultEnvironment);

            var value = parameters.TryGetValue(environment, out ApplicationParametersModel valueOut)
                ? valueOut.Parameters.Get(pluginData.Rule.OnElement, default(object))
                : string.Empty;

            // Return the extracted parameter value in the response
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
