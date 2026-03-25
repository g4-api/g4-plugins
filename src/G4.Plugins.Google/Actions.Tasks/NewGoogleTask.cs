using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System;

namespace G4.Plugins.Google.Actions.Tasks
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Tasks.Manifests.{NameReference}.json")]
    public class NewGoogleTask(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(NewGoogleTask);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve Title: use provided value or fall back to a timestamped default for traceability.
            var key = "Title";
            var defaultTitle = $"New Task {DateTime.UtcNow.ToString(GoogleAdapter.Iso)}";
            var title = pluginData.Parameters.Get(key, defaultValue: defaultTitle);

            // Read task fields from plugin parameters.
            var taskListIdOrName = pluginData.Parameters.Get(key: "TaskList", defaultValue: string.Empty);
            var notes = pluginData.Parameters.Get(key: "Notes", defaultValue: string.Empty);
            var due = pluginData.Parameters.Get(key: "Due", defaultValue: string.Empty);

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Resolve the target list id from either the list title or list id provided by the user.
            // This allows users to pass "My Tasks" or the actual list id interchangeably.
            var tasksListId = adapter.FindTaskList(taskListIdOrName)?.Id;

            // Treat missing list id as a hard failure (otherwise the request URI becomes invalid).
            if (string.IsNullOrEmpty(tasksListId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
            }

            // Parse Due only when provided. Google Tasks accepts RFC3339/ISO timestamps.
            // If Due is empty, omit it so the API uses its default behavior.
            string dueIso = null;

            if (!string.IsNullOrWhiteSpace(due))
            {
                dueIso = DateTime.Parse(due).ToUniversalTime().ToString(GoogleAdapter.Iso);
            }

            // Create the task in the resolved list.
            var task = adapter.Tasks.Add(tasksListId, new()
            {
                Title = title,
                Notes = notes,
                Due = dueIso,
                Status = "needsAction"
            });

            // Persist response details in session parameters (Base64-encoded).
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: task.Id);
            this.AddSessionParameter(@namespace: NameReference, name: "Title", value: task.Title);
            this.AddSessionParameter(@namespace: NameReference, name: "SelfLink", value: task.SelfLink);
            this.AddSessionParameter(@namespace: NameReference, name: "Position", value: task.Position);
            this.AddSessionParameter(@namespace: NameReference, name: "Status", value: task.Status);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
