using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents the set of properties related to conference solutions available for a calendar event.
    /// </summary>
    internal class ConferenceProperties : IDirectResponseSchema
    {
        /// <summary>
        /// The types of conference solutions that are supported for this calendar. The possible values are:
        /// - "eventHangout"
        /// - "eventNamedHangout"
        /// - "hangoutsMeet".
        /// </summary>
        public virtual List<string> AllowedConferenceSolutionTypes { get; set; }

        /// <summary>
        /// ETag of the collection.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }
    }
}
