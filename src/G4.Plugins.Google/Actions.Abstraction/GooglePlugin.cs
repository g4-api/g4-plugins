using G4.Cache;
using G4.Credentials;
using G4.Credentials.Models;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace G4.Plugins.Google.Actions.Abstraction
{
    /// <summary>
    /// Base plugin for Google plugins.
    /// </summary>
    internal class GooglePlugin(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        /// <summary>
        /// Retrieves all Google Tasks lists for the authenticated user.
        /// </summary>
        /// <param name="token">OAuth Bearer access token used to call the Google Tasks API. Ignored when <paramref name="credentials"/> is provided.</param>
        /// <param name="credentials">Optional credential record id or name. When supplied, the method exchanges the stored refresh token for a new access token using <c>NewAccessToken</c>.</param>
        /// <returns>A JSON string containing the Google Tasks lists array returned by the API.</returns>
        /// <exception cref="MissingMandatoryPropertyException">Thrown when the Google Tasks API response does not contain the required <c>items</c> property.</exception>
        public static string ExportTasksLists(string token, string credentials)
        {
            // If credentials were provided, exchange them for a fresh access token.
            if (!string.IsNullOrEmpty(credentials))
            {
                token = NewAccessToken(idOrName: credentials).AccessToken;
            }

            // Google Tasks endpoint that returns all task lists for the authenticated user.
            var requestUri = new Uri("https://tasks.googleapis.com/tasks/v1/users/@me/lists");

            // Create HTTP GET request with OAuth Bearer authentication.
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // Execute the request synchronously (plugin execution model is synchronous).
            using var response = HttpClient
                .SendAsync(requestMessage)
                .GetAwaiter()
                .GetResult();

            // Throw if the API returned a non-success status code.
            response.EnsureSuccessStatusCode();

            // Read the JSON response body.
            var responseContent = response.Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            // Parse the response JSON to validate presence of required
            // properties and to extract the "items" array.
            using var responseJson = JsonDocument.Parse(responseContent);

            // Validate that the response contains the expected "items" property.
            if (!responseJson.RootElement.TryGetProperty("items", out var itemsOut))
            {
                throw new MissingMandatoryPropertyException(
                    message: "Google Tasks API response is missing required property: 'items'.");
            }

            // Return the task lists collection as JSON so downstream steps can consume it directly.
            return JsonSerializer.Serialize(itemsOut);
        }

        /// <summary>
        /// Obtains a fresh Google OAuth access token using a stored credential record.
        /// </summary>
        /// <param name="idOrName">The credential identifier or credential name used to locate the record in the credentials cache.</param>
        /// <returns>A <see cref="TokenResponseModel"/> containing a newly issued access token (and related metadata).</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the credential record cannot be found.</exception>
        public static TokenResponseModel NewAccessToken(string idOrName)
        {
            // Resolve the provider token endpoint (defaulting to Google's public OAuth token URL).
            _ = CredentialsManager.Providers.Get(
                key: "google",
                defaultValue: "https://oauth2.googleapis.com/token");

            // Find a credential record by id or by name from the in-memory credentials cache.
            var credentials = CacheManager
                .Instance
                .CredentialsCache
                .Values
                .FirstOrDefault(i => i.Name == idOrName || i.Id == idOrName)
                    ?? throw new KeyNotFoundException(
                        $"Unknown Google credentials '{idOrName}'. Ensure the record exists in the credentials cache.");

            // Extract and decrypt required credential fields.
            var clientId = credentials.ClientId;
            var clientSecret = credentials.ClientSecret.Unprotect();
            var refreshToken = credentials.RefreshToken.Unprotect();

            // Exchange refresh token for a new access token using the credential's provider key.
            return CredentialsManager.ConvertRefreshToken(
                clientId: clientId,
                clientSecret: clientSecret,
                refreshToken: refreshToken,
                provider: credentials.Provider);
        }
    }
}
