using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Remote.Uia;

using System.Net.Http;

using System.Text;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(InvokeUser32DoubleClick)}.json")]
    public class InvokeUser32DoubleClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if the current WebDriver supports the IUser32Driver interface.
            // If not, return an empty plugin response.
            if (WebDriver is not IUser32Driver)
            {
                return this.NewPluginResponse();
            }

            // Retrieve offset and coordinate parameters from pluginData.
            var offsetX = int.Parse(pluginData.Parameters.Get("OffsetX", defaultValue: "0"));
            var offsetY = int.Parse(pluginData.Parameters.Get("OffsetY", defaultValue: "0"));
            var x = int.Parse(pluginData.Parameters.Get("X", defaultValue: "0"));
            var y = int.Parse(pluginData.Parameters.Get("Y", defaultValue: "0"));
            var alignment = pluginData.Parameters.Get("Alignment", defaultValue: "MiddleCenter");

            // Determine if offset or coordinate based movements should be applied.
            var isCoordinates = x != 0 || y != 0;

            // Check if the plugin data indicates there is no associated element.
            var noElement = pluginData.AssertHasNoElement();

            // If absolute coordinates are provided, move to those coordinates on the viewport.
            if (isCoordinates && noElement)
            {
                InvokeClickByCoordinates(plugin: this, x, y);
                return this.NewPluginResponse();
            }

            // Retrieve the User32 element from plugin data.
            var element = this.GetUser32Element(pluginData);

            // Create a mouse position data model with the specified alignment and offsets.
            var positionData = new MousePositionInputModel
            {
                Alignment = alignment,
                OffsetX = offsetX,
                OffsetY = offsetY
            };

            // Move the mouse pointer to the specified location within the element.
            MoveByElement(WebDriver, (UiaElement)element, positionData);

            // Invoke a click action at the last known mouse position.
            new ActionSequence(WebDriver).AddDoubleClick().Invoke();

            // Return the plugin response after processing the move action.
            return this.NewPluginResponse();
        }

        // Invoke a click action at the specified coordinates.
        private static void InvokeClickByCoordinates(PluginBase plugin, int x, int y)
        {
            // Create a new action sequence using the current WebDriver.
            var actions = new ActionSequence(plugin.WebDriver);

            // Add move and click actions to the sequence.
            actions.AddMoveMouseCursor(x, y, origin: "viewport").AddPauseAction(20).AddDoubleClick().Invoke();
        }

        // TODO: This is a workaround for now until we can refactor the WebDriver to fix the current API.
        // Moves the system mouse cursor to the coordinates of a specified UI element using the WebDriver's custom command.
        private static void MoveByElement(IWebDriver driver, UiaElement element, MousePositionInputModel inputModel)
        {
            // Retrieve the predefined command configuration for "MoveUser32MouseToElement"
            // from the driver's internal command invoker.
            var command = driver.Invoker.Commands["MoveUser32MouseToElement"];

            // Obtain the current WebDriver session ID (opaque key).
            var session = driver.GetSession().OpaqueKey;

            // Build the full HTTP route by replacing placeholders with actual session and element identifiers.
            var route = command.Route
                .Replace("$[session]", session)
                .Replace("$[element]", element.Id);

            // Construct the full address for the request.
            var requestUri = driver.Invoker.ServerAddress.AbsoluteUri.TrimEnd('/') + route;

            // Serialize the mouse movement parameters into JSON.
            var content = JsonSerializer.Serialize(inputModel);

            // Prepare the HTTP request body with appropriate content type.
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Create a POST request to send to the remote automation server.
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri)
            {
                Content = stringContent
            };

            // Execute the request synchronously.
            // Note: .Result is used here for simplicity, but consider async/await in production.
            var response = HttpClient.SendAsync(request).GetAwaiter().GetResult();

            // Validate the response from the automation server.
            if (!response.IsSuccessStatusCode)
            {
                // Read the error response content for diagnostics.
                var responseBody = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                // Throw an exception with the full response body for debugging.
                throw new HttpRequestException(responseBody);
            }
        }
    }
}
