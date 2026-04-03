using G4.Cache;
using G4.Credentials;
using G4.Credentials.Models;
using G4.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Clients
{
    /// <summary>
    /// Provides shared HTTP client utilities and serialization settings
    /// used by Google API client helpers.
    /// </summary>
    /// <param name="credentials">Credential identifier, credential name, or raw OAuth access token. The value is resolved using <c>NewAccessToken</c>.</param>
    internal abstract class ClientBase(string credentials)
    {
        #region *** Constants    ***
        /// <summary>
        /// The base URL for the Google Calendar API v3.
        /// </summary>
        public const string CalendarBaseUrl = "https://www.googleapis.com/calendar/v3";

        /// <summary>
        /// Base URI for Gmail API endpoints.
        /// </summary>
        public const string GmailBaseUri = "https://gmail.googleapis.com/gmail/v1";

        /// <summary>
        /// Base URI for Google Tasks API endpoints.
        /// </summary>
        public const string TasksBaseUri = "https://tasks.googleapis.com/tasks/v1";
        #endregion

        #region *** Fields       ***
        /// <summary>
        /// Default JSON serialization settings used when sending requests
        /// or serializing payloads for Google APIs. 
        /// </summary>
        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            // Do not include properties with null values in serialized JSON.
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,

            // Use relaxed escaping to allow special characters in JSON without being escaped.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

            // Convert C# property names (PascalCase) to camelCase for JSON.
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        /// <summary>
        /// Shared HTTP client instance used by all Google API clients.
        /// </summary>
        /// <remarks>A single static instance avoids socket exhaustion and improves performance.</remarks>
        public static readonly HttpClient HttpClient = new();
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Current OAuth credentials used for API requests.
        /// </summary>
        public TokenResponseModel Credentials => NewAccessToken(value: credentials);
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Obtains a fresh Google OAuth access token using a stored credential record.
        /// </summary>
        /// <param name="value">Credential identifier or credential name used to locate a record in the credentials cache. If no matching record is found, the value is treated as a raw OAuth access token and returned as-is.
        /// </param>
        /// <returns>A <see cref="TokenResponseModel"/> containing a newly issued access token (and related metadata).</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the credential record cannot be found.</exception>
        public static TokenResponseModel NewAccessToken(string value)
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
                .FirstOrDefault(i => i.Name == value || i.Id == value);

            // If no credential record is found, assume the provided value is a raw access token and return it as-is.
            if (credentials == null)
            {
                return new TokenResponseModel
                {
                    AccessToken = value,
                    TokenType = "Bearer"
                };
            }

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

        /// <summary>
        /// Creates an HTTP request configured with OAuth Bearer authorization and
        /// an optional JSON request body.
        /// </summary>
        /// <param name="method">HTTP method used for the request (GET, POST, PATCH, DELETE, etc.).</param>
        /// <param name="requestUri">Target endpoint URI.</param>
        /// <param name="token">OAuth Bearer access token used to authorize the request.</param>
        /// <returns>A configured <see cref="HttpRequestMessage"/> ready to be sent by an <see cref="HttpClient"/>. The caller is responsible for disposing it.</returns>
        public static HttpRequestMessage NewRequest(
            HttpMethod method, Uri requestUri, string token)
        {
            return NewRequest(method, requestUri, token, requestBody: null);
        }

        /// <summary>
        /// Creates an HTTP request configured with OAuth Bearer authorization and
        /// an optional JSON request body.
        /// </summary>
        /// <param name="method">HTTP method used for the request (GET, POST, PATCH, DELETE, etc.).</param>
        /// <param name="requestUri">Target endpoint URI.</param>
        /// <param name="token">OAuth Bearer access token used to authorize the request.</param>
        /// <param name="requestBody">Optional request payload object. When provided, the object is serialized to JSON using the configured <c>_jsonOptions</c>./param>
        /// <returns>A configured <see cref="HttpRequestMessage"/> ready to be sent by an <see cref="HttpClient"/>. The caller is responsible for disposing it.</returns>
        public static HttpRequestMessage NewRequest(
            HttpMethod method, Uri requestUri, string token, object requestBody)
        {
            // Serialize the request body to JSON only when a payload is provided.
            StringContent stringContent = null;

            if (requestBody != null)
            {
                stringContent = new StringContent(
                    content: JsonSerializer.Serialize(requestBody, JsonOptions),
                    encoding: Encoding.UTF8,
                    mediaType: MediaTypeNames.Application.Json);
            }

            // Create the HTTP request message and attach the JSON payload if present.
            var requestMessage = new HttpRequestMessage(method, requestUri);
            if (stringContent != null)
            {
                requestMessage.Content = stringContent;
            }

            // Add the OAuth Bearer token required by Google APIs.
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // Return the configured request message so the caller can send it.
            return requestMessage;
        }
        #endregion
    }
}
