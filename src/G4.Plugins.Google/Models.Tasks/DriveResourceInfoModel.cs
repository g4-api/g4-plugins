using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Tasks
{
    /// <summary>
    /// Drive file reference details associated with a task.
    /// </summary>
    internal class DriveResourceInfoModel : IDirectResponseSchema
    {
        /// <summary>
        /// Output only. Identifier of the file in the Drive API.
        /// </summary>
        public string DriveFileId { get; set; }

        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Output only. Resource key required to access files shared via a shared link.
        /// Not required for all files.
        /// See also: developers.google.com/drive/api/guides/resource-keys
        /// </summary>
        public string ResourceKey { get; set; }
    }
}
