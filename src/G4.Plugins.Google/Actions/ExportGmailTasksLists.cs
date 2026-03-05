using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System.Text.Json;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{NameReference}.json")]
    public class ExportGmailTasksLists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(ExportGmailTasksLists);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // If both a raw token and credentials reference are
            // provided, prioritize the credentials reference.
            var credentials = pluginData.ResolveCredentials();

            // Initialize the Google API adapter with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Get the lists from Google using the plugin's static method,
            // which handles both token and credentials scenarios.
            var response = adapter.TaskLists.Get();
            var value = JsonSerializer.Serialize(response, PluginDataModel.JsonOptions);

            // Persist the exported lists in session parameters (Base64-encoded for safe transport/storage).
            this.AddSessionParameter(@namespace: NameReference, name: "Result", value);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
