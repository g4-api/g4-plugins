using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Uia;

using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(SwitchKeyboardLayout)}.json")]
    public class SwitchKeyboardLayout(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
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

            // Retrieve the keyboard layout from the plugin data or parameters.
            // Check if 'Keys' argument is present in plugin data and extract the value.
            var keyboardLayout = pluginData.Parameters.Get(key: "KeyboardLayout", defaultValue: string.Empty);

            // Determine the keys to send based on the availability of 'Keys' argument.
            keyboardLayout = !string.IsNullOrEmpty(keyboardLayout)
                ? keyboardLayout
                : pluginData.Rule.Argument;

            // Set the default keyboard layout to 'en-US' if the value is empty or null.
            keyboardLayout = string.IsNullOrEmpty(keyboardLayout) ? "en-US" : keyboardLayout;

            // Send the key inputs using the specified WebDriver, keys, delay, and sticky keys flag.
            SwitchLayout(WebDriver, keyboardLayout);

            // Return a new plugin response indicating that the operation completed successfully.
            return this.NewPluginResponse();
        }

        // Sends a request to switch the keyboard layout.
        private static void SwitchLayout(IWebDriver driver, string keyboardLayout)
        {
            // Define the endpoint route for switching keyboard layouts.
            const string route = "/user32/layouts";

            // Construct the full URL by combining the server address and the route.
            var url = driver.Invoker.ServerAddress.AbsoluteUri.TrimEnd('/') + route;

            // Create an HTTP POST request with the constructed URL.
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Build the request body containing the keyboard layout.
            var body = new
            {
                Layout = keyboardLayout
            };

            // Serialize the request body to JSON using predefined serializer options.
            var json = JsonSerializer.Serialize(body, s_jsonOptions);

            // Create the content for the HTTP request with UTF-8 encoding and JSON media type.
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the HTTP request synchronously and retrieve the response.
            var response = HttpClient.SendAsync(request).GetAwaiter().GetResult();

            // Verify that the response indicates success; throw an exception if not.
            response.EnsureSuccessStatusCode();
        }
    }
}
