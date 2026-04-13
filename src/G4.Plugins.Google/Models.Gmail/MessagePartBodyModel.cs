using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents the body content metadata for a Gmail message part.
    /// </summary>
    internal class MessagePartBodyModel : IDirectResponseSchema
    {
        /// <summary>
        /// Gets or sets the attachment identifier used to retrieve the attachment body separately.
        /// </summary>
        public string AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the body data encoded as a base64url string.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the entity tag for the message part body resource.
        /// </summary>
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the size of the message part body in bytes.
        /// </summary>
        public int? Size { get; set; }
    }
}
