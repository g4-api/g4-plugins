using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Tasks
{
    /// <summary>
    /// Information about the source of the task assignment (Document, Chat Space).
    /// </summary>
    internal class AssignmentInfoModel : IDirectResponseSchema
    {
        /// <summary>
        /// Output only. Information about the Drive file where this task originates from.
        /// Currently, the Drive file can only be a document. This field is read-only.
        /// </summary>
        public DriveResourceInfoModel DriveResourceInfo { get; set; }

        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Output only. An absolute link to the original task in the surface of assignment
        /// (Docs, Chat spaces, etc.).
        /// </summary>
        public string LinkToTask { get; set; }

        /// <summary>
        /// Output only. Information about the Chat Space where this task originates from.
        /// This field is read-only.
        /// </summary>
        public SpaceInfoModel SpaceInfo { get; set; }

        /// <summary>
        /// Output only. The type of surface this assigned task originates from.
        /// Currently limited to DOCUMENT or SPACE.
        /// </summary>
        public string SurfaceType { get; set; }
    }
}
