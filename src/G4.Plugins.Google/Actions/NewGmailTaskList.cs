using G4.Attributes;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Actions.Abstraction;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

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
    public class NewGmailTaskList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(NewGmailTaskList);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the list title: rule argument overrides parameter; otherwise generate a timestamped default.
            var key = "Title";
            var defaultTitle = $"New Tasks List {DateTime.UtcNow:yyyyMMddHHmmssfff}";
            var title = pluginData.Parameters.Get(key, defaultValue: defaultTitle);

            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "Token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "Credentials", defaultValue: string.Empty);

            // If both a raw token and credentials reference are provided, prioritize the credentials reference.
            credentials = string.IsNullOrEmpty(credentials) ? token : credentials;

            // Initialize the Google API adapter with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Create a new Gmail Task List using the adapter and capture the response.
            var response = adapter.TaskLists.Add(requestBody: new()
            {
                Title = title
            });

            // Persist created list details in session parameters (Base64-encoded for safe transport/storage).
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: response.Id);
            this.AddSessionParameter(@namespace: NameReference, name: "Title", value: response.Title);
            this.AddSessionParameter(@namespace: NameReference, name: "SelfLink", value: response.SelfLink);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
