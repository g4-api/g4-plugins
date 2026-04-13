using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Classification Labels applied to the email message. Classification Labels are different from Gmail inbox labels.
    /// Only used for Google Workspace accounts. [Learn more about classification labels](https://support.google.com/a/answer/9292382).
    /// </summary>
    internal class ClassificationLabelValueModel : IDirectResponseSchema
    {
        /// <inheritdoc />
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Field values for the given classification label ID.
        /// </summary>
        public List<ClassificationLabelFieldValueModel> Fields { get; set; }


        /// <summary>
        /// Required. The canonical or raw alphanumeric classification label ID. Maps to the ID field of the Google
        /// Drive Label resource.
        public string LabelId { get; set; }
    }
}
