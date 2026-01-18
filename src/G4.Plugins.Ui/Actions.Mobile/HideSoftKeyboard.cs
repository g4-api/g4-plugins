/*
 * RESOURCES
 * https://appium.readthedocs.io/en/latest/en/writing-running-appium/other/appium-bindings/#hide-keyboard
 * https://appium.readthedocs.io/en/latest/en/commands/device/keys/hide-keyboard/#http-api-specifications
 * https://elementalx.org/button-mapper/android-key-codes/
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote.Appium;
using G4.WebDriver.Remote.Appium.Models;

namespace G4.Plugins.Ui.Actions.Mobile
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Mobile.Manifests.{nameof(HideSoftKeyboard)}.json")]
    public class HideSoftKeyboard(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Create a HideKeyboardModel based on the provided plugin data.
            var hideKeyboardModel = new HideKeyboardModel
            {
                Key = pluginData.Parameters.Get(key: "Key", defaultValue: default(string)),
                KeyCode = pluginData.Parameters.Get(key: "KeyCode", defaultValue: default(string)),
                KeyName = pluginData.Parameters.Get(key: "KeyName", defaultValue: default(string)),
                Strategy = pluginData.Parameters.Get(key: "Strategy", defaultValue: default(string))
            };

            // Check if the WebDriver supports hiding the keyboard as a mobile device.
            if (WebDriver is IMobileDeviceKeyboard mobileDeviceKeyboard)
            {
                // Hide the keyboard using the provided model.
                mobileDeviceKeyboard.HideKeyboard(hideKeyboardModel);
            }

            // Return a new PluginResponseModel.
            return this.NewPluginResponse();
        }
    }
}
