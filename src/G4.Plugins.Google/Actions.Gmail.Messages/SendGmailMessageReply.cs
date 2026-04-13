using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace G4.Plugins.Google.Actions.Gmail.Messages
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Gmail.Messages.Manifests.{NameReference}.json")]
    public class SendGmailMessageReply(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(SendGmailMessageReply);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve either a credential reference or a raw access token.
            // Credential-based resolution takes precedence over a direct token value.
            var credentials = pluginData.ResolveCredentials();

            // Read the source Gmail message id that will be replied to.
            var messageId = pluginData.Parameters.Get(key: "MessageId", defaultValue: string.Empty);

            // Read the reply body from the plugin parameters.
            var bodyValue = pluginData.Parameters.Get(key: "Body", defaultValue: string.Empty);

            // Read the primary recipients override from the plugin parameters.
            var toValue = pluginData.Parameters.Get(key: "To", defaultValue: string.Empty);

            // Read the carbon-copy recipients override from the plugin parameters.
            var ccValue = pluginData.Parameters.Get(key: "Cc", defaultValue: string.Empty);

            // Read the blind-carbon-copy recipients override from the plugin parameters.
            var bccValue = pluginData.Parameters.Get(key: "Bcc", defaultValue: string.Empty);

            // Create a Google adapter authenticated with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Read the original Gmail message so reply headers and thread metadata can be reused.
            var message = adapter.Gmail.Messages.Get(id: messageId);

            // Resolve the RFC Message-Id header from the original message for reply threading.
            var rfcMessageId = message.GetMessageId();

            // Resolve the sender from the original message to preserve the reply envelope format.
            var from = message.GetFrom();

            // Normalize all recipient lists from semicolon-separated to comma-separated format.
            var to = toValue.Replace(';', ',');
            var cc = ccValue.Replace(';', ',');
            var bcc = bccValue.Replace(';', ',');

            // Keep the reply body in a local variable for the RFC 2822 payload.
            var body = bodyValue;

            // Build the raw RFC 2822 reply message text to be sent through the Gmail API.
            // The In-Reply-To and References headers preserve conversation threading.
            var textMessage = $"""
            From: {from}
            To: {to}
            Cc: {cc}
            Bcc: {bcc}
            In-Reply-To: {rfcMessageId}
            References: {rfcMessageId}
            Subject: {message.GetSubject()}

            {body}
            """;

            // Encode the raw message in base64url format as required by the Gmail API.
            var raw = textMessage.ConvertToBase64();

            // Send the reply message and include the original thread id so Gmail keeps the reply
            // in the existing conversation.
            message = adapter.Gmail.Messages.Send(message: new()
            {
                Raw = raw,
                ThreadId = message.ThreadId
            });

            // Treat a missing message id as a hard failure because the send result cannot be tracked.
            if (string.IsNullOrEmpty(message?.Id))
            {
                throw new InvalidOperationException(
                    message: "No Gmail messages were returned for the authenticated account.");
            }

            // Extract the key identifiers and label information from the created reply message.
            var id = message.Id;
            var threadId = message.ThreadId;
            var labels = JsonSerializer.Serialize(message.LabelIds ?? []);

            // Persist the sent reply metadata in session parameters for downstream workflow use.
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: id);
            this.AddSessionParameter(@namespace: NameReference, name: "Labels", value: labels);
            this.AddSessionParameter(@namespace: NameReference, name: "ThreadId", value: threadId);

            // Create the plugin response that will expose the reply message metadata to the caller.
            var response = this.NewPluginResponse();

            // Populate the response entity with the returned Gmail reply message fields.
            response.Entity = new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Labels"] = labels,
                ["ThreadId"] = threadId
            };

            // Return the completed plugin response.
            return response;
        }
    }
}
