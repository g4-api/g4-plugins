using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote.Uia;

using System;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(SendUser32Keys)}.json")]
    public class SendUser32Keys(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the WebDriver instance from the plugin data and check if it is a UiaDriver.
            // Exit the plugin if the WebDriver is not a UiaDriver.
            if (WebDriver is not IUser32Driver driver)
            {
                return this.NewPluginResponse();
            }

            // Check if 'Keys' argument is present in plugin data and extract the value.
            var keys = pluginData.Parameters.Get(key: "Keys", defaultValue: string.Empty);

            // Determine the keys to send based on the availability of 'Keys' argument.
            var text = !string.IsNullOrEmpty(keys)
                ? keys
                : pluginData.Rule.Argument;

            // Get the delay data or use the default search timeout as a fallback
            var delayData = pluginData.Parameters.Get("Delay", "0");
            var delay = delayData.ConvertToTimeSpan(defaultValue: TimeSpan.Zero);

            // Get the element to send keys to. If no element is specified, set the element to null.
            var element = string.IsNullOrEmpty(pluginData.Rule.OnElement)
                ? null
                : this.GetUser32Element(pluginData);

            // If the element found, set focus to the element.
            try
            {
                element?.SetFocus();
                driver.SendKeys(text, delay);
            }
            catch
            {
                // Silently ignore the exception.
            }

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
