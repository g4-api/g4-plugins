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
        manifest: $"G4.Plugins.Google.Actions.Manifests.{NameReference}.json")]
    public class NewGmailTask(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(NewGmailTask);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Adds a session parameter with Base64 encoding and namespacing.
            void AddSessionParameter(string name, string value)
            {
                // Namespace the session keys with the plugin name reference to avoid collisions.
                name = $"{NameReference}:{name}";

                // Store values as Base64 to keep session transport predictable and safe for JSON/escaping.
                value = value?.ConvertToBase64() ?? string.Empty;

                // Persist into the workflow session scope.
                Invoker.Context.SessionParameters[name] = value;
            }

            // Resolve Title: use provided value or fall back to a timestamped default for traceability.
            var key = "Title";
            var defaultTitle = $"New Task {DateTime.UtcNow.ToString(GooglePlugin.Iso)}";
            var title = pluginData.Parameters.Get(key, defaultValue: defaultTitle);

            // Read task fields.
            var tasksList = pluginData.Parameters.Get(key: "TasksList", defaultValue: string.Empty);
            var notes = pluginData.Parameters.Get(key: "Notes", defaultValue: string.Empty);
            var due = pluginData.Parameters.Get(key: "Due", defaultValue: string.Empty);

            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "credentials", defaultValue: string.Empty);

            // If credentials were provided, exchange them for a fresh access token.
            if (!string.IsNullOrEmpty(credentials))
            {
                token = GooglePlugin.NewAccessToken(idOrName: credentials).AccessToken;
            }

            // Resolve the target list id from either the list title or list id provided by the user.
            var tasksListId = GooglePlugin
                .FindTasksList(token, credentials, tasksList)
                .GetProperty("id")
                .GetString();

            // Treat missing list id as a hard failure (otherwise the request URI becomes invalid).
            if (string.IsNullOrEmpty(tasksListId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task list found for title or ID: '{tasksList}'.");
            }

            // Build request JSON payload for creating a task in the list.
            // Notes: "status" is set to needsAction so the task starts as not completed.
            var requestBody = new
            {
                title,
                notes,
                // Convert due date to ISO 8601 (UTC, Z-suffix) to match Google Tasks expectations.
                due = DateTime.Parse(due).ToString(GooglePlugin.Iso),
                status = "needsAction"
            };

            // Serialize request body to JSON and prepare HTTP content with appropriate headers.
            using var stringContent = new StringContent(
                content: JsonSerializer.Serialize(requestBody),
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json);

            // Google Tasks endpoint for creating a task inside a specific list:
            // POST https://tasks.googleapis.com/tasks/v1/lists/{tasklist}/tasks
            var requestUri = new Uri($"https://tasks.googleapis.com/tasks/v1/lists/{tasksListId}/tasks");

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

            // Throw on non-success (includes 4xx/5xx).
            response.EnsureSuccessStatusCode();

            // Parse response JSON.
            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            using var responseJson = JsonDocument.Parse(responseContent);

            // Validate presence of required properties in the response.
            // These are used by downstream workflow steps via session parameters.
            if (!responseJson.RootElement.TryGetProperty("id", out var idOut) ||
                !responseJson.RootElement.TryGetProperty("selfLink", out var selfLinkOut) ||
                !responseJson.RootElement.TryGetProperty("position", out var positionOut) ||
                !responseJson.RootElement.TryGetProperty("status", out var statusOut))
            {
                throw new MissingMandatoryPropertyException(
                    message: "Google Tasks API response is missing required properties: 'id' or 'selfLink'.");
            }

            // Extract values from JSON properties.
            var id = idOut.GetString();
            var selfLink = selfLinkOut.GetString();
            var position = positionOut.GetString();
            var status = statusOut.GetString();

            // Persist response details in session parameters (Base64-encoded).
            AddSessionParameter(name: "Id", value: id);
            AddSessionParameter(name: "Title", value: title);
            AddSessionParameter(name: "SelfLink", value: selfLink);
            AddSessionParameter(name: "Position", value: position);
            AddSessionParameter(name: "Status", value: status);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
