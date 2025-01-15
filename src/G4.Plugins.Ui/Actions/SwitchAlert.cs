using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SwitchAlert)}.json")]
    public class SwitchAlert(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Switch to the alert dialog
            var alert = WebDriver.SwitchTo().Alert();

            // If no arguments are provided and no rule argument is specified, dismiss the alert
            if (pluginData.Parameters.Count == 0 && string.IsNullOrEmpty(pluginData.Rule.Argument))
            {
                alert.Close();
                return this.NewPluginResponse();
            }

            // Get the action to be performed on the alert (ACCEPT or DISMISS) from plugin arguments
            var alertAction = pluginData.Parameters.Get("AlertAction", pluginData.Rule.Argument);

            // Get the keys to be sent to the alert, if any, from plugin arguments
            var keys = pluginData.Parameters.Get("Keys", string.Empty);

            // If keys are provided, send them to the alert
            if (!string.IsNullOrEmpty(keys))
            {
                alert.SendKeys(keys);
            }

            // Perform the action based on the provided alert action
            if (alertAction.Equals("ACCEPT", StringComparison.OrdinalIgnoreCase))
            {
                alert.Approve();
            }
            else if (alertAction.Equals("DISMISS", StringComparison.OrdinalIgnoreCase))
            {
                alert.Close();
            }

            // Return a new plugin response
            return this.NewPluginResponse();
        }
    }
}
