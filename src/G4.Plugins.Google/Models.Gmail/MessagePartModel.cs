using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents a MIME part within a Gmail message payload.
    /// </summary>
    internal class MessagePartModel : IDirectResponseSchema
    {
        /// <summary>
        /// Gets or sets the body metadata and content for the message part.
        /// </summary>
        public MessagePartBodyModel Body { get; set; }

        /// <summary>
        /// Gets or sets the entity tag for the message part resource.
        /// </summary>
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the file name associated with the message part.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the headers associated with the message part.
        /// </summary>
        public List<MessagePartHeaderModel> Headers { get; set; }

        /// <summary>
        /// Gets or sets the MIME type of the message part.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the child MIME parts contained within the current part.
        /// </summary>
        public List<MessagePartModel> Parts { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the message part.
        /// </summary>
        public string PartId { get; set; }
    }
}
