using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Tasks;

using System;

namespace G4.Plugins.Google.Actions.Tasks
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Tasks.Manifests.{NameReference}.json")]
    public class MoveGoogleTask(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(MoveGoogleTask);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the source task list identifier or title that contains the task to move.
            var taskListIdOrName = pluginData.Parameters.Get(key: "TaskList", defaultValue: string.Empty);

            // Read the task identifier or title to move.
            var taskIdOrName = pluginData.Parameters.Get(key: "Task", defaultValue: string.Empty);

            // Read optional parent task identifier or title.
            var parentTaskIdOrName = pluginData.Parameters.Get(key: "Parent", defaultValue: string.Empty);

            // Read optional previous task identifier or title used to position the task.
            var previousTaskIdOrName = pluginData.Parameters.Get(key: "Previous", defaultValue: string.Empty);

            // Read optional destination task list identifier or title.
            var destinationTaskListIdOrName = pluginData.Parameters.Get(key: "Destination", defaultValue: string.Empty);

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Resolve the source task list and task from either ids or names provided by the user.
            var tasksListId = adapter.FindTaskList(taskListIdOrName)?.Id;
            var taskId = adapter.FindTask(taskListIdOrName, taskIdOrName)?.Id;

            // Treat missing source list or task as a hard failure.
            if (string.IsNullOrWhiteSpace(tasksListId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
            }

            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new InvalidOperationException(
                    message: $"No matching task found for title or ID: '{taskIdOrName}' in list '{taskListIdOrName}'.");
            }

            // Resolve the optional destination task list id when provided.
            var destination = string.IsNullOrWhiteSpace(destinationTaskListIdOrName)
                ? null
                : adapter.FindTaskList(destinationTaskListIdOrName)?.Id;

            // Resolve the optional previous task id within the source task list when provided.
            var previous = string.IsNullOrWhiteSpace(previousTaskIdOrName)
                ? null
                : adapter.FindTask(taskListIdOrName, previousTaskIdOrName)?.Id;

            // Resolve the optional parent task id within the source task list when provided.
            var parent = string.IsNullOrWhiteSpace(parentTaskIdOrName)
                ? null
                : adapter.FindTask(taskListIdOrName, parentTaskIdOrName)?.Id;

            // Build move options using only resolved identifiers.
            var options = new MoveTaskRequestModel
            {
                DestinationTasklist = destination,
                Parent = parent,
                Previous = previous
            };

            // Move the task and capture the updated task returned by the API.
            var task = adapter.Tasks.Tasks.Move(tasksListId, taskId, options);

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
