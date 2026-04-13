using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents the request payload used to create a new calendar event.
    /// </summary>
    /// <remarks>
    /// This model contains the target calendar identifier, the event details,
    /// and the update notification behavior for attendees.
    /// </remarks>
    internal class NewEventRequestModel
    {
        /// <summary>
        /// Gets or sets the identifier of the calendar where the event will be created.
        /// </summary>
        [FromRoute, Required]
        public string CalendarId { get; set; }

        /// <summary>
        /// Gets or sets the event details to create in the target calendar.
        /// </summary>
        public CalendarEventModel EventModel { get; set; }

        /// <summary>
        /// Gets or sets how update notifications should be sent to attendees.
        /// </summary>
        /// <remarks>Allowed values are <c>all</c>, <c>externalOnly</c>, and <c>none</c>. The default value is <c>none</c>.</remarks>
        [AllowedValues("all", "externalOnly", "none")]
        [FromQuery]
        public string SendUpdates { get; set; } = "none";
    }
}
