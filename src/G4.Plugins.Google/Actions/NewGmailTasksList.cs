using G4.Attributes;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Actions.Abstraction;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{nameof(NewGmailTasksList)}.json")]
    public class NewGmailTasksList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the list title: rule argument overrides parameter; otherwise generate a timestamped default.
            var key = "Title";
            var defaultTitle = $"New Tasks List {DateTime.UtcNow:yyyyMMddHHmmssfff}";
            var title = pluginData.Parameters.Get(key, defaultValue: defaultTitle);

            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "credentials", defaultValue: string.Empty);

            // If credentials were provided, exchange them for a fresh access token.
            if (!string.IsNullOrEmpty(credentials))
            {
                token = GooglePlugin.NewAccessToken(idOrName: credentials).AccessToken;
            }

            // Build request JSON payload for "TaskLists: insert".
            var requestBody = new { title };

            // Serialize request body to JSON and prepare HTTP content with appropriate headers.
            using var stringContent = new StringContent(
                content: JsonSerializer.Serialize(requestBody),
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json);

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri("https://tasks.googleapis.com/tasks/v1/users/@me/lists");

            // Construct HTTP request message with JSON content and authorization header.
            using var requestMessage = new HttpRequestMessage(method: HttpMethod.Post, requestUri)
            {
                Content = stringContent
            };

            // Attach Bearer token for authorization.
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue(scheme: "Bearer", parameter: token);

            // Send the request (synchronous/blocking by design).
            using var response = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();

            // Throw with rich HTTP diagnostics on failure.
            response.EnsureSuccessStatusCode();

            // Parse response JSON and extract key fields.
            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            using var responseJson = JsonDocument.Parse(responseContent);

            // Validate presence of required properties in the response.
            if (!responseJson.RootElement.TryGetProperty("id", out var idOut) ||
                !responseJson.RootElement.TryGetProperty("selfLink", out var selfLinkOut))
            {
                throw new MissingMandatoryPropertyException(
                    message:
                        "Google Tasks API response is missing required properties: 'id' or 'selfLink'.");
            }

            // Extract values from JSON properties.
            var id = idOut.GetString();
            var selfLink = selfLinkOut.GetString();

            // Persist created list details in session parameters (Base64-encoded for safe transport/storage).
            Invoker.Context.SessionParameters["GmailTasksListId"] = id?.ConvertToBase64() ?? string.Empty;
            Invoker.Context.SessionParameters["GmailTasksListTitle"] = title?.ConvertToBase64() ?? string.Empty;
            Invoker.Context.SessionParameters["GmailTasksListLink"] = selfLink?.ConvertToBase64() ?? string.Empty;

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
