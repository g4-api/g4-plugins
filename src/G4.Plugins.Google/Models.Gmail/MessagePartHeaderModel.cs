using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents a header entry within a Gmail message part.
    /// </summary>
    internal class MessagePartHeaderModel : IDirectResponseSchema
    {
        /// <summary>
        /// Gets or sets the entity tag for the message part header resource.
        /// </summary>
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the header name before the <c>:</c> separator.
        /// For example, <c>To</c>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the header value after the <c>:</c> separator.
        /// For example, <c>someuser@example.com</c>.
        /// </summary>
        public string Value { get; set; }
    }
}
