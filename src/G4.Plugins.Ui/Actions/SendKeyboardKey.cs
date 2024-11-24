using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;

using System;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SendKeyboardKey)}.json")]
    public class SendKeyboardKey(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if native clear is requested
            var isNativeClear = pluginData.Parameters.ContainsKey("NativeClear");

            // Check if standard clear is requested
            var isClear = pluginData.Parameters.ContainsKey("Clear");

            // Get the keyboard input data
            var keysData = pluginData.Parameters.Get("Key", pluginData.Rule.Argument);

            // Deserialize the keys data as an array of strings or use a single string
            var keys = keysData.AssertJson()
                ? JsonSerializer.Deserialize<string[]>(keysData)
                : [keysData];

            // Get the delay data or use the default search timeout as a fallback
            var delayData = pluginData.Parameters.Get("Delay", "0");
            var delay = delayData.ConvertToTimeSpan(defaultValue: TimeSpan.Zero);

            // Get the web element to interact with
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // If the element is not found, log the exception and return an empty response
            if (element == null)
            {
                // Create a new exception for the missing element
                var driverException = new NoSuchElementException();

                // Create a G4ExceptionModel to encapsulate the exception along with plugin data
                var G4Exception = new G4ExceptionModel(pluginData.Rule, driverException);

                // Add the exception to the list of exceptions for later analysis or reporting
                Exceptions.Add(G4Exception);

                // Return an empty response, indicating that the action could not be performed
                return this.NewPluginResponse();
            }

            // Perform native clear if requested
            if (isNativeClear)
            {
                SendNativeClear(plugin: this, pluginData, element);
            }
            // Otherwise, perform standard clear if requested
            else if (isClear)
            {
                element.Clear();
            }

            // Iterate through each key and send it to the element
            foreach (var key in keys)
            {
                // Get the corresponding keyboard key
                var keyboardKey = GetKeyboardKey(key);

                // Send the key to the element with or without delay based on the configuration
                element.SendKeys(keyboardKey, delay);
            }

            // Return a response indicating successful execution
            return this.NewPluginResponse();
        }

        // Clears the content of an HTML input element by simulating backspace key presses.
        private static void SendNativeClear(PluginBase plugin, PluginDataModel pluginData, IWebElement element)
        {
            try
            {
                // Call the SendNativeClear extension method to clear the element using backspaces
                element.SendNativeClear();
            }
            catch (Exception e)
            {
                // An error occurred during native clear, encapsulate the error in an exception model
                var exception = new G4ExceptionModel(rule: pluginData.Rule, exception: e.GetBaseException());

                // Log the exception using the plugin instance
                plugin.AddExceptions(exception);
            }
        }
    }
}
