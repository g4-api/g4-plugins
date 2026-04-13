using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents a Gmail message returned by the Gmail API.
    /// </summary>
    internal class MessageModel : IDirectResponseSchema
    {
        /// <summary>
        /// Gets or sets the classification labels associated with the message.
        /// </summary>
        public List<ClassificationLabelValueModel> ClassificationLabelValues { get; set; }

        /// <summary>
        /// Gets or sets the entity tag for the message resource.
        /// </summary>
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the last history record that modified the message.
        /// </summary>
        public string HistoryId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the message.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the internal message creation date as epoch milliseconds.
        /// </summary>
        public string InternalDate { get; set; }

        /// <summary>
        /// Gets or sets the label identifiers currently applied to the message.
        /// </summary>
        public List<string> LabelIds { get; set; }

        /// <summary>
        /// Gets or sets the MIME payload structure of the message.
        /// </summary>
        public MessagePartModel Payload { get; set; }

        /// <summary>
        /// Gets or sets the entire email message in RFC 2822 format encoded as a base64url string.
        /// </summary>
        public string Raw { get; set; }

        /// <summary>
        /// Gets or sets the estimated size of the message in bytes.
        /// </summary>
        public int SizeEstimate { get; set; }

        /// <summary>
        /// Gets or sets the short message snippet returned by the Gmail API.
        /// </summary>
        public string Snippet { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the thread that contains the message.
        /// </summary>
        public string ThreadId { get; set; }
    }
}
