using G4.Plugins.Google.Models.Abstraction;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Describes a collection of calendar list entries returned by the Google Calendar API.
    /// This model corresponds to the response from the "calendarList.list" endpoint, which
    /// retrieves the list of calendars on a user's calendar list. It includes metadata about
    /// the collection, such as the ETag, kind, and pagination tokens for navigating through
    /// large result sets. Each entry in the "items" list represents a single calendar on the
    /// user's calendar list, containing details about that calendar and the user's access level to it.
    /// </summary>
    internal class CalendarListModel : IDirectResponseSchema
    {
        /// <summary>
        /// ETag of the collection.
        /// </summary>
        [JsonPropertyName(name: "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Calendars that are present on the user's calendar list.
        /// </summary>
        public List<CalendarListEntryModel> Items { get; set; }

        /// <summary>
        /// Type of the collection ("calendar#calendarList").
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Token used to access the next page of this result. Omitted if no further results are available, in which
        /// case nextSyncToken is provided.
        /// </summary>
        public string NextPageToken { get; set; }

        /// <summary>
        /// Token used at a later point in time to retrieve only the entries that have changed since this result was
        /// returned. Omitted if further results are available, in which case nextPageToken is provided.
        /// </summary>
        public string NextSyncToken { get; set; }
    }
}
