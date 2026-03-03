using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Actions.Abstraction;

using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{nameof(RemoveGmailTasksList)}.json")]
    public class RemoveGmailTasksList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the list id to delete.
            var id = pluginData.Parameters.Get(key: "Id", defaultValue: string.Empty);

            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "credentials", defaultValue: string.Empty);

            // If credentials were provided, exchange them for a fresh access token.
            if (!string.IsNullOrEmpty(credentials))
            {
                token = GooglePlugin.NewAccessToken(idOrName: credentials).AccessToken;
            }

            // Build the Google Tasks API endpoint for deleting a task list.
            var requestUri = new Uri($"https://tasks.googleapis.com/tasks/v1/users/@me/lists/{id}");

            // Construct HTTP DELETE request with Bearer authorization.
            using var requestMessage = new HttpRequestMessage(method: HttpMethod.Delete, requestUri);

            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue(scheme: "Bearer", parameter: token);

            // Send the request (synchronous/blocking by design).
            using var response = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();

            // Throw on non-success (includes 4xx/5xx).
            response.EnsureSuccessStatusCode();

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
