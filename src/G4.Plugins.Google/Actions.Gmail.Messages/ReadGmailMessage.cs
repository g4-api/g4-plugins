using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Google.Actions.Gmail.Messages
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Gmail.Messages.Manifests.{NameReference}.json")]
    public class ReadGmailMessage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(ReadGmailMessage);

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
            var messageId = list.Messages?.FirstOrDefault()?.Id;

            // Treat a missing message id as a hard failure because there is no mail to read.
            if (string.IsNullOrEmpty(messageId))
            {
                throw new InvalidOperationException(
                    message: "No Gmail messages were returned for the authenticated account.");
            }

            // Retrieve the full Gmail message using the resolved message id.
            var message = adapter.Gmail.Messages.Get(messageId);

            // Extract commonly used properties from the Gmail message.
            var bcc = message.GetBcc();
            var cc = message.GetCc();
            var content = message.Read();
            var from = message.GetFrom();
            var id = message.Id;
            var subject = message.GetSubject();
            var threadId = message.ThreadId;
            var to = message.GetTo();

            // Persist mail data in session parameters.
            this.AddSessionParameter(@namespace: NameReference, name: "Bcc", value: bcc);
            this.AddSessionParameter(@namespace: NameReference, name: "Cc", value: cc);
            this.AddSessionParameter(@namespace: NameReference, name: "Content", value: content);
            this.AddSessionParameter(@namespace: NameReference, name: "From", value: from);
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: id);
            this.AddSessionParameter(@namespace: NameReference, name: "Subject", value: subject);
            this.AddSessionParameter(@namespace: NameReference, name: "ThreadId", value: threadId);
            this.AddSessionParameter(@namespace: NameReference, name: "To", value: to);

            // Create a new plugin response to return
            // the extracted mail properties in the response entity.
            var response = this.NewPluginResponse();

            // Initialize the plugin response entity with the extracted mail properties.
            response.Entity = new Dictionary<string, object>
            {
                ["Bcc"] = bcc,
                ["Cc"] = cc,
                ["Content"] = content,
                ["From"] = from,
                ["Id"] = id,
                ["Subject"] = subject,
                ["ThreadId"] = threadId,
                ["To"] = to
            };

            // Return the plugin response.
            return response;
        }
    }
}
