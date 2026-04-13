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
    public class UpdateGoogleTaskList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(UpdateGoogleTaskList);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the list id to update.
            var id = pluginData.Parameters.Get(key: "Id", defaultValue: string.Empty);

            // Resolve the list title: rule argument overrides parameter; otherwise generate a timestamped default.
            var key = "Title";
            var defaultTitle = $"Updated Tasks List {DateTime.UtcNow:yyyyMMddHHmmssfff}";
            var title = pluginData.Parameters.Get(key, defaultValue: defaultTitle);

            // If both a raw token and credentials reference are
            // provided, prioritize the credentials reference.
            var credentials = pluginData.ResolveCredentials();

            // Initialize the Google API adapter with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Update an existing Gmail Task List using the adapter and capture the response.
            var response = adapter.Tasks.TaskLists.Update(taskList: id, requestBody: new()
            {
                Title = title
            });

            // Persist updated list details in session parameters (Base64-encoded for safe transport/storage).
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: response.Id);
            this.AddSessionParameter(@namespace: NameReference, name: "Title", value: response.Title);
            this.AddSessionParameter(@namespace: NameReference, name: "SelfLink", value: response.SelfLink);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
