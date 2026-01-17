/*
 * RESOURCES
 * https://appium.readthedocs.io/en/latest/en/commands/device/keys/is-keyboard-shown/#http-api-specifications
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote.Appium;

namespace G4.Plugins.Ui.Assertions.Mobile
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Mobile.Manifests.{nameof(KeyboardVisible)}.json")]
    public class KeyboardVisible(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a local function to check if the mobile device keyboard is visible.
            bool ConfirmMobileKeyboardVisibility()
            {
                // Check if the WebDriver type implements the IMobileDeviceKeyboard interface.
                // If not, return false as the keyboard visibility cannot be determined.
                if (WebDriver is not IMobileDeviceKeyboard)
                {
                    return false;
                }

                // If the WebDriver implements IMobileDeviceKeyboard, check if the on-screen keyboard is visible.
                return ((IMobileDeviceKeyboard)WebDriver).IsOnScreenKeyboardVisible;
            }

            // Use the SetAssertResponse method to handle the assertion response.
            // The condition and revertCondition parameters are related to the keyboard visibility.
            return this.NewAssertResponse(pluginData, factory: ConfirmMobileKeyboardVisibility);
        }
    }
}
