namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents a date/time for a calendar event start or end.
    /// Use <see cref="DateTime"/> for timed events (ISO 8601) or <see cref="Date"/> for all-day events (YYYY-MM-DD).
    /// </summary>
    internal class CalendarEventTimeModel
    {
        #region *** Properties ***
        /// <summary>
        /// The date in YYYY-MM-DD format used for all-day events.
        /// When set, <see cref="DateTime"/> should be omitted.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// The date and time in ISO 8601 format used for timed events.
        /// When set, <see cref="Date"/> should be omitted.
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// The IANA time zone identifier (e.g., "America/New_York") applied to <see cref="DateTime"/>.
        /// Optional. When omitted, the calendar's default time zone is used.
        /// </summary>
        public string TimeZone { get; set; }
        #endregion
    }
}
