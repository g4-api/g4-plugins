using G4.Plugins.Google.Models.Abstraction;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents a reminder for an event, specifying how and when the reminder should be delivered.
    /// </summary>
    /// <remarks>
    /// Use this class to configure reminders for events, including the delivery method and the time
    /// before the event when the reminder should occur. The reminder can be delivered via email or as a popup
    /// notification, and the trigger time is specified in minutes before the event starts.
    /// </remarks>
    internal class EventReminderModel : IDirectResponseSchema
    {
        /// <summary>
        /// ETag of the collection.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The method used by this reminder. Possible values are:
        /// - "email" - Reminders are sent via email.
        /// - "popup" - Reminders are sent via a UI popup.
        /// </summary>
        [Required]
        public string Method { get; set; }

        /// <summary>
        /// Number of minutes before the start of the event when the reminder should trigger. Valid values are between 0
        /// and 40320 (4 weeks in minutes). Required when adding a reminder.
        /// </summary>
        public int? Minutes { get; set; }
    }
}
