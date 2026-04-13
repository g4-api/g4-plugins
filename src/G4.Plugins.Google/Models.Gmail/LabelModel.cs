using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents a Gmail label resource.
    /// </summary>
    internal sealed class LabelModel : IDirectResponseSchema
    {
        /// <summary>
        /// The color settings for the label.
        /// </summary>
        public LabelColorModel Color { get; set; }

        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The immutable ID of the label.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Visibility of the label in the label list in the Gmail web interface.
        /// </summary>
        public string LabelListVisibility { get; set; }

        /// <summary>
        /// Visibility of messages with this label in the Gmail message list.
        /// </summary>
        public string MessageListVisibility { get; set; }

        /// <summary>
        /// The display name of the label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The total number of messages with this label.
        /// </summary>
        public int? MessagesTotal { get; set; }

        /// <summary>
        /// The number of unread messages with this label.
        /// </summary>
        public int? MessagesUnread { get; set; }

        /// <summary>
        /// The total number of threads with this label.
        /// </summary>
        public int? ThreadsTotal { get; set; }

        /// <summary>
        /// The number of unread threads with this label.
        /// </summary>
        public int? ThreadsUnread { get; set; }

        /// <summary>
        /// The type of label, typically SYSTEM or USER.
        /// </summary>
        public string Type { get; set; }
    }
}
