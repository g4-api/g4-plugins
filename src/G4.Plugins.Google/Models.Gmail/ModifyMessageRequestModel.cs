using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents a request to modify labels on an existing Gmail message.
    /// </summary>
    internal class ModifyMessageRequestModel : IDirectResponseSchema
    {
        /// <summary>
        /// Gets or sets the collection of label IDs to add to the message.
        /// </summary>
        public List<string> AddLabelIds { get; set; }

        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the collection of label IDs to remove from the message.
        /// </summary>
        public List<string> RemoveLabelIds { get; set; }
    }
}
