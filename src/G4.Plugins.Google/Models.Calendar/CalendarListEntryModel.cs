using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents an entry in a user's calendar list, including calendar metadata, access roles, notification settings,
    /// and display preferences.
    /// </summary>
    internal class CalendarListEntryModel : IDirectResponseSchema
    {
        #region *** Properties   ***
        /// <summary>
        /// The effective access role that the authenticated user has on the calendar. Read-only. Possible values are:
        /// - "freeBusyReader" - Provides read access to free/busy information.  - "reader" - Provides read access to
        /// the calendar. Private events will appear to users with reader access, but event details will be hidden.  -
        /// "writer" - Provides read and write access to the calendar. Private events will appear to users with writer
        /// access, and event details will be visible.  - "owner" - Provides manager access to the calendar. This role
        /// has all of the permissions of the writer role with the additional ability to see and modify access levels of
        /// other users. Important: the owner role is different from the calendar's data owner. A calendar has a single
        /// data owner, but can have multiple users with owner role.
        /// </summary>
        public string AccessRole { get; set; }

        /// <summary>
        /// Whether this calendar automatically accepts invitations. Only valid for resource calendars. Read-only.
        /// </summary>
        public bool? AutoAcceptInvitations { get; set; }

        /// <summary>
        /// The main color of the calendar in the hexadecimal format "#0088aa". This property supersedes the index-based
        /// colorId property. To set or change this property, you need to specify colorRgbFormat=true in the parameters
        /// of the insert, update and patch methods. Optional.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color of the calendar. This is an ID referring to an entry in the calendar section of the colors
        /// definition (see the colors endpoint). This property is superseded by the backgroundColor and foregroundColor
        /// properties and can be ignored when using these properties. Optional.
        /// </summary>
        public string ColorId { get; set; }

        /// <summary>
        /// Conferencing properties for this calendar, for example what types of conferences are allowed.
        /// </summary>
        public ConferenceProperties ConferenceProperties { get; set; }

        /// <summary>
        /// The email of the owner of the calendar. Set only for secondary calendars. Read-only.
        /// </summary>
        public string DataOwner { get; set; }

        /// <summary>
        /// The default reminders that the authenticated user has for this calendar.
        /// </summary>
        public List<EventReminderModel> DefaultReminders { get; set; }

        /// <summary>
        /// Whether this calendar list entry has been deleted from the calendar list. Read-only. Optional. The default
        /// is False.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Description of the calendar. Optional. Read-only.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ETag of the resource.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// The foreground color of the calendar in the hexadecimal format "#ffffff". This property supersedes the
        /// index-based colorId property. To set or change this property, you need to specify colorRgbFormat=true in the
        /// parameters of the insert, update and patch methods. Optional.
        /// </summary>
        public string ForegroundColor { get; set; }

        /// <summary>
        /// Whether the calendar has been hidden from the list. Optional. The attribute is only returned when the
        /// calendar is hidden, in which case the value is true.
        /// </summary>
        public bool? Hidden { get; set; }

        /// <summary>
        /// Identifier of the calendar.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Type of the resource ("calendar#calendarListEntry").
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Geographic location of the calendar as free-form text. Optional. Read-only.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The notifications that the authenticated user is receiving for this calendar.
        /// </summary>
        public NotificationSettingsData NotificationSettings { get; set; }

        /// <summary>
        /// Whether the calendar is the primary calendar of the authenticated user. Read-only. Optional. The default is
        /// False.
        /// </summary>
        public bool? Primary { get; set; }

        /// <summary>
        /// Whether the calendar content shows up in the calendar UI. Optional. The default is False.
        /// </summary>
        public bool? Selected { get; set; }

        /// <summary>
        /// Title of the calendar. Read-only.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The summary that the authenticated user has set for this calendar. Optional.
        /// </summary>
        public string SummaryOverride { get; set; }

        /// <summary>
        /// The time zone of the calendar. Optional. Read-only.
        /// </summary>
        public string TimeZone { get; set; }
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// The notifications that the authenticated user is receiving for this calendar.
        /// </summary>
        public class NotificationSettingsData
        {
            /// <summary>
            /// The list of notifications set for this calendar.
            /// </summary>
            public List<CalendarNotificationModel> Notifications { get; set; }
        }
        #endregion
    }
}
