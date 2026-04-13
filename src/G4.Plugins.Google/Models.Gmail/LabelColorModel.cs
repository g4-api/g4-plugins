using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents the color object of a Gmail label.
    /// </summary>
    internal sealed class LabelColorModel : IDirectResponseSchema
    {
        /// <summary>
        /// The background color of the label, as a hex string.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The text color of the label, as a hex string.
        /// </summary>
        public string TextColor { get; set; }
    }
}
