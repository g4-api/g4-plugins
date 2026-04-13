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
        manifest: $"G4.Plugins.Google.Actions.Tasks.Manifests.{nameof(RemoveGoogleTask)}.json")]
    public class RemoveGoogleTask(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
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
            var taskListId = adapter.FindTaskList(taskListIdOrName)?.Id;

            // Treat a missing list id as a hard failure to avoid sending invalid requests.
            if (string.IsNullOrWhiteSpace(taskListId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
            }

            // Find the task to delete by id or by title.
            // This iterates pages (when present) and stops after a short timeout to avoid hanging.
            var taskId = adapter.FindTask(taskListIdOrName, taskIdOrName)?.Id;

            // Treat a missing task as a hard failure to avoid deleting the wrong item or calling with null ids.
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task found for title or ID: '{taskIdOrName}' in list '{taskListIdOrName}'.");
            }

            // Delete the task using the adapter.
            adapter.Tasks.Tasks.Remove(taskListId, taskId);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
