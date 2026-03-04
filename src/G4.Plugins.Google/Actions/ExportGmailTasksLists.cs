using G4.Attributes;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Actions.Abstraction;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{nameof(ExportGmailTasksLists)}.json")]
    public class ExportGmailTasksLists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "credentials", defaultValue: string.Empty);

            // If credentials were provided, exchange them for a fresh access token.
            if (!string.IsNullOrEmpty(credentials))
            {
                token = GooglePlugin.NewAccessToken(idOrName: credentials).AccessToken;
            }

            // Build the Google Tasks API endpoint for listing task lists:
            // GET https://tasks.googleapis.com/tasks/v1/users/@me/lists
            var requestUri = new Uri("https://tasks.googleapis.com/tasks/v1/users/@me/lists");

            // Construct HTTP GET request with Bearer authorization.
            using var requestMessage = new HttpRequestMessage(method: HttpMethod.Get, requestUri);

            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue(scheme: "Bearer", parameter: token);

            // Send the request (synchronous/blocking by design).
            using var response = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();

            // Throw on non-success (includes 4xx/5xx).
            response.EnsureSuccessStatusCode();

            // Parse response JSON and extract key fields.
            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            using var responseJson = JsonDocument.Parse(responseContent);

            // Validate presence of required properties in the response.
            if (!responseJson.RootElement.TryGetProperty("items", out var itemsOut))
            {
                throw new MissingMandatoryPropertyException(
                    message: "Google Tasks API response is missing required property: 'items'.");
            }

            // Serialize the "items" array to JSON so downstream steps can consume it as-is.
            var itemsJson = JsonSerializer.Serialize(itemsOut);

            // Persist the exported lists in session parameters (Base64-encoded for safe transport/storage).
            Invoker.Context.SessionParameters["GmailTasksListsResult"] = string.IsNullOrEmpty(itemsJson)
                    ? "[]".ConvertToBase64()
                    : itemsJson.ConvertToBase64();

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
