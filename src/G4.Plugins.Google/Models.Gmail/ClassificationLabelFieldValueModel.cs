using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Field values for a classification label.
    /// </summary>
    internal class ClassificationLabelFieldValueModel : IDirectResponseSchema
    {
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Required. The field ID for the Classification Label Value. Maps to the ID field of the Google Drive
        /// `Label.Field` object.
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// Selection choice ID for the selection option. Should only be set if the field type is `SELECTION` in the
        /// Google Drive `Label.Field` object. Maps to the id field of the Google Drive `Label.Field.SelectionOptions`
        /// resource.
        /// </summary>
        public string Selection { get; set; }
    }
}
