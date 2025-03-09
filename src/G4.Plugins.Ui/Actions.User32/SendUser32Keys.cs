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
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(SendUser32Keys)}.json")]
    public class SendUser32Keys(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
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
            // Get the WebDriver instance from the plugin data and check if it is a UiaDriver.
            // Exit the plugin if the WebDriver is not a UiaDriver.
            if (WebDriver is not IUser32Driver)
            {
                return this.NewPluginResponse();
            }

            // Check if 'Keys' argument is present in plugin data and extract the value.
            var keys = pluginData.Parameters.Get(key: "Keys", defaultValue: string.Empty);

            // Determine the keys to send based on the availability of 'Keys' argument.
            var text = !string.IsNullOrEmpty(keys)
                ? keys
                : pluginData.Rule.Argument;

            // Retrieve the keyboard layout from the plugin parameters, defaulting to "en-US" if not provided.
            var keyboardLayout = pluginData.Parameters.Get("KeyboardLayout", "en-US");

            // Get the delay data or use the default search timeout as a fallback
            var delayData = pluginData.Parameters.Get("Delay", "0");

            // Get the element to send keys to. If no element is specified, set the element to null.
            var element = string.IsNullOrEmpty(pluginData.Rule.OnElement)
                ? null
                : this.GetUser32Element(pluginData);

            // If the element found, set focus to the element.
            try
            {
                element?.SetFocus();
                SetValue(WebDriver, keyboardLayout, text, int.Parse(delayData));
            }
            catch
            {
                // Silently ignore the exception.
            }

            // Return new plugin response.
            return this.NewPluginResponse();
        }

        // Sends key scan codes to the specified session endpoint via an HTTP POST request.
        private static void SetValue(IWebDriver driver, string keyboardLayout, string keys, int delay)
        {
            // Retrieve the session opaque key from the driver, which uniquely identifies the session.
            var session = ((IWebDriverSession)driver).Session.OpaqueKey;

            // Construct the route for the endpoint using the session key.
            var route = $"/session/{session}/user32/value";

            // Combine the server address and route to form the full URL.
            var url = driver.Invoker.ServerAddress.AbsoluteUri.TrimEnd('/') + route;

            // Create a new HTTP POST request with the constructed URL.
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Build the request body with the keys and options for delay and stickyKeys.
            var body = new
            {
                Text = keys,
                Options = new
                {
                    Delay = delay,
                    KeyboardLayout = keyboardLayout,
                    StickyKeys = false
                }
            };

            // Serialize the request body to JSON using predefined JSON options.
            var json = JsonSerializer.Serialize(body, s_jsonOptions);

            // Create the content of the HTTP request with proper encoding and content type.
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;

            // Send the HTTP request synchronously and wait for the response.
            var response = HttpClient.SendAsync(request).GetAwaiter().GetResult();

            // Ensure that the response indicates a successful status code; otherwise, throw an exception.
            response.EnsureSuccessStatusCode();
        }
    }
}
