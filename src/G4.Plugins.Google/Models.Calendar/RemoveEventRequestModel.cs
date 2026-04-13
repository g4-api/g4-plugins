using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents the request parameters used to delete a calendar event.
    /// </summary>
    /// <remarks>
    /// This model contains the target calendar identifier, the event identifier,
    /// and the update notification behavior for attendees.
    /// </remarks>
    internal class RemoveEventRequestModel
    {
        /// <summary>
        /// Gets or sets the identifier of the calendar that contains the event to delete.
        /// </summary>
        [FromRoute, Required]
        public string CalendarId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the event to delete.
        /// </summary>
        [FromRoute, Required]
        public string EventId { get; set; }

        /// <summary>
        /// Gets or sets how update notifications should be sent to attendees.
        /// </summary>
        /// <remarks>Allowed values are <c>all</c>, <c>externalOnly</c>, and <c>none</c>. The default value is <c>none</c>.</remarks>
        [AllowedValues("all", "externalOnly", "none")]
        [FromQuery]
        public string SendUpdates { get; set; } = "none";
    }
}
