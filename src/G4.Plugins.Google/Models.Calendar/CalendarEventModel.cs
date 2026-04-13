using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents a Google Calendar event resource as defined by the Calendar API v3.
    /// Used both as the request body for event creation and as the response model returned by the API.
    /// </summary>
    internal class CalendarEventModel : IDirectResponseSchema
    {
        #region *** Properties   ***
        /// <summary>
        /// The attendees of the event. Each entry contains at minimum an email address.
        /// Optional.
        /// </summary>
        public List<AttendeeData> Attendees { get; set; }

        /// <summary>
        /// The creation time of the event (as a RFC 3339 timestamp). Read-only.
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// The creator of the event. Read-only.
        /// </summary>
        public PersonData Creator { get; set; }

        /// <summary>
        /// A description of the event. Can contain HTML. Optional.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The end time of the event. Required when creating an event.
        /// </summary>
        public CalendarEventTimeModel End { get; set; }

        /// <summary>
        /// ETag of the resource.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The type of the event. Possible values: "birthday", "default", "focusTime",
        /// "outOfOffice", "workingLocation". Optional.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// An absolute URL to the Google Meet/Hangouts video conference for this event.
        /// Read-only. Present only when the event has a conference associated with it.
        /// </summary>
        public string HangoutLink { get; set; }

        /// <summary>
        /// An absolute link to this event in the Google Calendar web UI. Read-only.
        /// </summary>
        public string HtmlLink { get; set; }

        /// <summary>
        /// Opaque identifier of the event. Read-only when returned by the API.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Type of the resource ("calendar#event"). Read-only.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Geographic location of the event as free-form text. Optional.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The organizer of the event. Read-only.
        /// </summary>
        public PersonData Organizer { get; set; }

        /// <summary>
        /// The start time of the event. Required when creating an event.
        /// </summary>
        public CalendarEventTimeModel Start { get; set; }

        /// <summary>
        /// Status of the event. Possible values: "confirmed", "tentative", "cancelled". Optional.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Title of the event. Optional.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Whether the event blocks time on the calendar. Possible values: "opaque" (busy), "transparent" (free). Optional.
        /// </summary>
        public string Transparency { get; set; }

        /// <summary>
        /// Last modification time of the event (as a RFC 3339 timestamp). Read-only.
        /// </summary>
        public string Updated { get; set; }

        /// <summary>
        /// Visibility of the event. Possible values: "default", "public", "private", "confidential". Optional.
        /// </summary>
        public string Visibility { get; set; }
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// Represents an attendee of a calendar event.
        /// </summary>
        public class AttendeeData
        {
            /// <summary>
            /// The email address of the attendee.
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// The attendee's response status.
            /// Possible values: "needsAction", "declined", "tentative", "accepted". Read-only.
            /// </summary>
            public string ResponseStatus { get; set; }
        }

        /// <summary>
        /// Represents a person (creator or organizer) associated with the event.
        /// </summary>
        public class PersonData
        {
            /// <summary>
            /// The display name of the person.
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// The email address of the person.
            /// </summary>
            public string Email { get; set; }
        }
        #endregion
    }
}
