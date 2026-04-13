using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System.Text.Json;

namespace G4.Plugins.Google.Actions.Tasks
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Tasks.Manifests.{NameReference}.json")]
    public class ExportGoogleTasks(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(ExportGoogleTasks);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the task list identifier or title whose tasks should be exported.
            var taskListIdOrName = pluginData.Parameters.Get(key: "TaskList", defaultValue: string.Empty);

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Export all tasks from the resolved task list and serialize the result to JSON.
            var response = adapter.ExportTasks(taskListIdOrName);
            var value = JsonSerializer.Serialize(response, PluginDataModel.JsonOptions);

            // Persist the exported task collection in a session parameter (Base64-encoded).
            this.AddSessionParameter(@namespace: NameReference, name: "Result", value);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
