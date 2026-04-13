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
    public class SendGmailMessage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(SendGmailMessage);
        
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve either a credential reference or a raw access token.
            // Credential-based resolution takes precedence over a direct token value.
            var credentials = pluginData.ResolveCredentials();

            // Read the message body from the plugin parameters.
            var bodyValue = pluginData.Parameters.Get(key: "Body", defaultValue: string.Empty);

            // Read the message subject from the plugin parameters.
            var subjectValue = pluginData.Parameters.Get(key: "Subject", defaultValue: string.Empty);

            // Read the primary recipients from the plugin parameters.
            var toValue = pluginData.Parameters.Get(key: "To", defaultValue: string.Empty);

            // Read the sender value from the plugin parameters.
            var fromValue = pluginData.Parameters.Get(key: "From", defaultValue: string.Empty);

            // Read the carbon-copy recipients from the plugin parameters.
            var ccValue = pluginData.Parameters.Get(key: "Cc", defaultValue: string.Empty);

            // Read the blind-carbon-copy recipients from the plugin parameters.
            var bccValue = pluginData.Parameters.Get(key: "Bcc", defaultValue: string.Empty);

            // Create a Google adapter authenticated with the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Build the raw RFC 2822 message text that will be sent through the Gmail API.
            // Semicolon-separated recipient lists are normalized to comma-separated values.
            var textMessage = $"""
            From: {fromValue}
            To: {toValue.Replace(';', ',')}
            Cc: {ccValue.Replace(';', ',')}
            Bcc: {bccValue.Replace(';', ',')}
            Subject: {subjectValue}

            {bodyValue}
            """;

            // Encode the raw message in base64url format as required by the Gmail API.
            var raw = textMessage.ConvertToBase64();

            // Send the Gmail message and capture the created message resource returned by the API.
            var message = adapter.Gmail.Messages.Send(message: new()
            {
                Raw = raw
            });

            // Read the created Gmail message id from the API response.
            var messageId = message?.Id;

            // Treat a missing message id as a hard failure because the send result cannot be tracked.
            if (string.IsNullOrEmpty(messageId))
            {
                throw new InvalidOperationException(
                    message: "No Gmail messages were returned for the authenticated account.");
            }

            // Extract the key identifiers and label information from the sent message.
            var id = message.Id;
            var threadId = message?.ThreadId;
            var labels = JsonSerializer.Serialize(message?.LabelIds ?? []);

            // Persist the sent message metadata in session parameters for downstream workflow use.
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: id);
            this.AddSessionParameter(@namespace: NameReference, name: "Labels", value: labels);
            this.AddSessionParameter(@namespace: NameReference, name: "ThreadId", value: threadId);

            // Create the plugin response that will expose the sent message metadata to the caller.
            var response = this.NewPluginResponse();

            // Populate the response entity with the returned Gmail message fields.
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
