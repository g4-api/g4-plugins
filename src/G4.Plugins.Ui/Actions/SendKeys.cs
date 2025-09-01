using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions
{
    // TODO: fix "{{$ --keys:" when keys parameter is empty.
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SendKeys)}.json")]
    public class SendKeys(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if 'Keys' argument is present in plugin data and extract the value.
            var keys = pluginData.Parameters.Get(key: "Keys", defaultValue: string.Empty);

            // Determine the keys to send based on the availability of 'Keys' argument.
            var text = !string.IsNullOrEmpty(keys)
                ? keys
                : pluginData.Rule.Argument;

            // Get the delay data or use the default search timeout as a fallback
            var delayData = pluginData.Parameters.Get("Delay", "0");
            var delay = delayData.ConvertToTimeSpan(defaultValue: TimeSpan.Zero);

            // Check if 'NativeClear' argument is present in plugin data.
            var isNativeClear = pluginData.Parameters.ContainsKey("NativeClear");

            // Check if 'Clear' argument is present in plugin data and not using native clear.
            var isClear = !isNativeClear && pluginData.Parameters.ContainsKey("Clear");

            // Check if 'Modifiers' argument is present in plugin data and extract the value.
            var isModifier = pluginData.Parameters.TryGetValue("Modifier", out var modifiersData);

            // Initialize an empty array of modifiers.
            var modifiers = Array.Empty<string>();

            // If 'Modifiers' argument is present, convert the value to an array of strings.
            if(isModifier)
            {
                modifiers = modifiersData.AssertJson()
                    ? JsonSerializer.Deserialize<string[]>(modifiersData)
                    : [modifiersData];
            }

            // Get the element using provided plugin data.
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

            // Send modified keys if modifiers are specified.
            if (modifiers.Length > 0)
            {
                SendModifiedKeys(plugin: this, pluginData, element, text, modifiers);
                return this.NewPluginResponse();
            }

            // Send the keys to the element.
            element.SendKeys(text, delay);

            // Return new plugin response.
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

        // Sends modified keys to a WebElement, where modifiers are pressed down before sending the actual keys.
        private static void SendModifiedKeys(
            PluginBase plugin, PluginDataModel pluginData,
            IWebElement element,
            string text,
            IEnumerable<string> modifiers)
        {
            try
            {
                // Send modified keys to the element
                element.SendModifiedKeys(text, modifiers);
            }
            catch (Exception e)
            {
                // An error occurred during modified keys, encapsulate the error in an exception model
                var exception = new G4ExceptionModel(rule: pluginData.Rule, exception: e.GetBaseException());

                // Log the exception using the plugin instance
                plugin.AddExceptions(exception);
            }
        }
    }
}
