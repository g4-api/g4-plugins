using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Tasks
{
    /// <summary>
    /// Information about the Chat Space where a task was assigned from.
    /// </summary>
    internal class SpaceInfoModel : IDirectResponseSchema
    {
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Output only. The Chat space where this task originates from.
        /// Format: "spaces/{space}".
        /// </summary>
        public string Space { get; set; }
    }
}
