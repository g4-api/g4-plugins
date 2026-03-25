using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace G4.Plugins.Google.Actions.Gmail.Messages
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Gmail.Messages.Manifests.{NameReference}.json")]
    public class EditGmailMessage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(EditGmailMessage);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve either a credential reference or a raw access token.
            // Credential-based resolution takes precedence over a direct token value.
            var credentials = pluginData.ResolveCredentials();

            // Create a Google adapter authenticated with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Read the target Gmail message id from the plugin parameters.
            var messageId = pluginData.Parameters.Get(key: "MessageId", defaultValue: string.Empty);

            // Read the JSON array of labels to add.
            var add = pluginData.Parameters.Get(key: "Add", defaultValue: "[]");
            add = add.AssertJson()
                ? add
                : JsonSerializer.Serialize(value: new[] { add });

            // Read the JSON array of labels to remove.
            var remove = pluginData.Parameters.Get(key: "Remove", defaultValue: "[]");
            remove = remove.AssertJson()
                ? remove
                : JsonSerializer.Serialize(value: new[] { remove });

            // Remove the requested labels from the target message first.
            RemoveLabels(
                adapter,
                messageId,
                labels: JsonSerializer.Deserialize<string[]>(remove)
            );

            // Add the requested labels to the target message and keep the updated message result.
            var message = AddLabels(
                adapter,
                messageId,
                labels: JsonSerializer.Deserialize<string[]>(add)
            );

            // Extract commonly used fields from the updated Gmail message.
            var bcc = message.GetBcc();
            var cc = message.GetCc();
            var content = message.Read();
            var from = message.GetFrom();
            var id = message.Id;
            var labels = JsonSerializer.Serialize(message.ResolveLabels(adapter));
            var subject = message.GetSubject();
            var to = message.GetTo();

            // Persist the updated message data into session parameters for downstream workflow use.
            this.AddSessionParameter(@namespace: NameReference, name: "Bcc", value: bcc);
            this.AddSessionParameter(@namespace: NameReference, name: "Cc", value: cc);
            this.AddSessionParameter(@namespace: NameReference, name: "Content", value: content);
            this.AddSessionParameter(@namespace: NameReference, name: "From", value: from);
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: id);
            this.AddSessionParameter(@namespace: NameReference, name: "Labels", value: labels);
            this.AddSessionParameter(@namespace: NameReference, name: "Subject", value: subject);
            this.AddSessionParameter(@namespace: NameReference, name: "To", value: to);

            // Create the plugin response that will expose the updated message data to the caller.
            var response = this.NewPluginResponse();

            // Populate the response entity with the extracted Gmail message fields.
            response.Entity = new Dictionary<string, object>
            {
                ["Bcc"] = bcc,
                ["Cc"] = cc,
                ["Content"] = content,
                ["From"] = from,
                ["Id"] = id,
                ["Labels"] = labels,
                ["Subject"] = subject,
                ["To"] = to
            };

            // Return the completed plugin response.
            return response;
        }

        // Adds the specified Gmail labels to the target message.
        private static MessageModel AddLabels(
            GoogleAdapter adapter,
            string messageId,
            params string[] labels)
        {
            // Build a regular expression that matches the provided label names exactly.
            var pattern = $"^{string.Join("|", labels.Select(i => i.Trim()))}$";

            // Resolve the Gmail label ids for all matching label names.
            var ids = adapter.FindLabels(pattern).Select(i => i.Id);

            // Add the resolved label ids to the target Gmail message
            if (ids.Any())
            {
                adapter.Gmail.Messages.UpdateMessageLabels(id: messageId, new()
                {
                    AddLabelIds = [.. ids]
                });
            }

            // Return the updated message.
            return adapter.Gmail.Messages.Get(messageId);
        }

        // Removes the specified Gmail labels from the target message.
        private static MessageModel RemoveLabels(
            GoogleAdapter adapter,
            string messageId,
            params string[] labels)
        {
            // Build a regular expression that matches the provided label names exactly.
            var pattern = $"^{string.Join("|", labels.Select(i => i.Trim()))}$";

            // Resolve the Gmail label ids for all matching label names.
            var ids = adapter.FindLabels(pattern).Select(i => i.Id);

            // Remove the resolved label ids from the target Gmail message.
            if (ids.Any())
            {
                adapter.Gmail.Messages.UpdateMessageLabels(id: messageId, new()
                {
                    RemoveLabelIds = [.. ids]
                });
            }

            // Return the updated message.
            return adapter.Gmail.Messages.Get(messageId);
        }
    }
}
