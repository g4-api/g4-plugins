using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models;

using System;
using System.Linq;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{nameof(RemoveGmailTask)}.json")]
    public class RemoveGmailTask(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the task identifier or title to delete.
            var taskIdOrName = pluginData.Parameters.Get(key: "Task", defaultValue: string.Empty);

            // Read the task list identifier or title that contains the task.
            var taskListIdOrName = pluginData.Parameters.Get(key: "TaskList", defaultValue: string.Empty);

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Resolve the task list id from either the list title or list id provided by the user.
            // This allows users to pass "My Tasks" or the actual list id interchangeably.
            var taskListId = adapter
                .TaskLists
                .Get()
                .Items
                .FirstOrDefault(i =>
                    string.Equals(i.Id, taskListIdOrName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(i.Title, taskListIdOrName, StringComparison.OrdinalIgnoreCase))?
                .Id;

            // Treat a missing list id as a hard failure to avoid sending invalid requests.
            if (string.IsNullOrWhiteSpace(taskListId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
            }

            // Find the task to delete by id or by title.
            // This iterates pages (when present) and stops after a short timeout to avoid hanging.
            var nextPageToken = string.Empty;
            var taskId = string.Empty;
            var timeout = DateTime.UtcNow.AddSeconds(30);

            do
            {
                // Initialize the query options with the next page token
                // when present to iterate through pages of tasks.
                var options = string.IsNullOrEmpty(nextPageToken)
                    ? new ListTasksQueryModel { MaxResults = 100 }
                    : new ListTasksQueryModel { MaxResults = 100, PageToken = nextPageToken };

                // Get a page of tasks from the adapter.
                var tasksPage = adapter.Tasks.Get(taskListId, options);

                // Look for a matching task in the current page of results
                // by comparing both the id and title
                var task = tasksPage.Items
                    .FirstOrDefault(i =>
                        string.Equals(i.Id, taskIdOrName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(i.Title, taskIdOrName, StringComparison.OrdinalIgnoreCase));

                // If a matching task is found, capture the id and break out of the loop to delete it.
                if (!string.IsNullOrWhiteSpace(task?.Id))
                {
                    taskId = task.Id;
                    break;
                }

                // Update the next page token to get the next page of
                // results on the next iteration.
                nextPageToken = tasksPage.NextPageToken;
            }
            while (!string.IsNullOrWhiteSpace(nextPageToken) && DateTime.UtcNow < timeout);

            // Treat a missing task as a hard failure to avoid deleting the wrong item or calling with null ids.
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task found for title or ID: '{taskIdOrName}' in list '{taskListIdOrName}'.");
            }

            // Delete the task using the adapter.
            adapter.Tasks.Remove(taskListId, taskId);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
