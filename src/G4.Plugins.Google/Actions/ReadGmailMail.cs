using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System;
using System.Linq;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{NameReference}.json")]
    public class ReadGmailMail(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(ReadGmailMail);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Request a single Gmail message id from the authenticated mailbox.
            // This plugin currently reads the first message returned by the API.
            var list = adapter.Gmail.Messages.Get(query: new()
            {
                MaxResults = 1
            });

            // Extract the first available message id from the returned page.
            var id = list.Messages.FirstOrDefault()?.Id;

            // Treat a missing message id as a hard failure because there is no mail to read.
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidOperationException(
                    message: "No Gmail messages were returned for the authenticated account.");
            }

            // Retrieve the full Gmail message using the resolved message id.
            var message = adapter.Gmail.Messages.Get(id);

            // Persist mail data in session parameters.
            this.AddSessionParameter(@namespace: NameReference, name: "Bcc", value: message.GetBcc());
            this.AddSessionParameter(@namespace: NameReference, name: "Cc", value: message.GetCc());
            this.AddSessionParameter(@namespace: NameReference, name: "Content", value: message.Read());
            this.AddSessionParameter(@namespace: NameReference, name: "From", value: message.GetFrom());
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: message.Id);
            this.AddSessionParameter(@namespace: NameReference, name: "Subject", value: message.GetSubject());
            this.AddSessionParameter(@namespace: NameReference, name: "To", value: message.GetTo());

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
