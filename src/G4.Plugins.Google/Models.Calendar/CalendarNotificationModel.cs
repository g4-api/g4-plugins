using G4.Plugins.Google.Models.Abstraction;

using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    internal class CalendarNotificationModel : IDirectResponseSchema
    {
        /// <summary>
        /// The ETag of the item.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The method used to deliver the notification. The possible value is:
        ///   - "email" - Notifications are sent via email.
        /// Required when adding a notification.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The type of notification. Possible values are:
        ///   - "eventCreation" - Notification sent when a new event is put on the calendar.
        ///   - "eventChange" - Notification sent when an event is changed.
        ///   - "eventCancellation" - Notification sent when an event is cancelled.
        ///   - "eventResponse" - Notification sent when an attendee responds to the event invitation.
        ///   - "agenda" - An agenda with the events of the day (sent out in the morning).
        /// Required when adding a notification.
        /// </summary>
        public string Type { get; set; }
    }
}
