using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Uia;

using Microsoft.AspNetCore.Http;

using System;
using System.Net.Http;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(SendUser32KeyboardKey)}.json")]
    public class SendUser32KeyboardKey(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Provides JSON serialization options with camelCase naming and case-insensitive property matching.
        private static readonly JsonSerializerOptions s_jsonOptions = new()
        {
            // Use camelCase naming policy for JSON properties.
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            // Allow property name matching to be case-insensitive during deserialization.
            PropertyNameCaseInsensitive = true
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Verify that the current WebDriver supports the IUser32Driver interface.
            // If it doesn't, return a new (empty) plugin response indicating no action was performed.
            if (WebDriver is not IUser32Driver)
            {
                return this.NewPluginResponse();
            }

            // Determine if sticky mode is enabled (keys will remain pressed until released at the end).
            var stickyKeys = pluginData.Parameters.ContainsKey("Sticky");

            // Retrieve the keyboard layout from the plugin parameters, defaulting to "en-US" if not provided.
            var keyboardLayout = pluginData.Parameters.Get("KeyboardLayout", "en-US");

            // Retrieve key data from plugin parameters.
            // The "Key" parameter is preferred; if not found, fallback to the rule's argument.
            var keysData = pluginData.Parameters.Get("Key", pluginData.Rule.Argument);

            // Check if the key data is in JSON format.
            // If it is JSON, deserialize it into a string array
            // otherwise, create an array with a single key.
            var keys = keysData.AssertJson()
                ? JsonSerializer.Deserialize<string[]>(keysData)
                : [keysData];

            // Retrieve the delay parameter from the plugin data, defaulting to "0" if not provided.
            var delayData = pluginData.Parameters.Get("Delay", "0");

            // Convert the delay parameter to a TimeSpan.
            // If the conversion fails, use TimeSpan.Zero; then extract the total delay in milliseconds.
            var delay = (int)delayData.ConvertToTimeSpan(defaultValue: TimeSpan.Zero).TotalMilliseconds;

            // Send the key inputs using the specified WebDriver, keys, delay, and sticky keys flag.
            SendInputs(WebDriver, keyboardLayout, keys, delay, stickyKeys);

            // Return a new plugin response indicating that the operation completed successfully.
            return this.NewPluginResponse();
        }

        // Sends key scan codes to the specified session endpoint via an HTTP POST request.
        private static void SendInputs(IWebDriver driver, string keyboardLayout, string[] keys, int delay, bool stickyKeys)
        {
            // Retrieve the session opaque key from the driver, which uniquely identifies the session.
            var session = ((IWebDriverSession)driver).Session.OpaqueKey;

            // Construct the route for the endpoint using the session key.
            var route = $"/session/{session}/user32/inputs";

            // Combine the server address and route to form the full URL.
            var url = driver.Invoker.ServerAddress.AbsoluteUri.TrimEnd('/') + route;

            // Create a new HTTP POST request with the constructed URL.
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Build the request body with the keys and options for delay and stickyKeys.
            var body = new
            {
                ScanCodes = keys,
                Options = new
                {
                    Delay = delay,
                    KeyboardLayout = keyboardLayout,
                    StickyKeys = stickyKeys
                }
            };

            // Serialize the request body to JSON using predefined JSON options.
            var json = JsonSerializer.Serialize(body, s_jsonOptions);

            // Create the content of the HTTP request with proper encoding and content type.
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;

            // Send the HTTP request synchronously and wait for the response.
            var response = HttpClient.SendAsync(request).GetAwaiter().GetResult();

            // Ensure that the response indicates a successful status code; otherwise, throw an exception.
            response.EnsureSuccessStatusCode();
        }
    }
}
