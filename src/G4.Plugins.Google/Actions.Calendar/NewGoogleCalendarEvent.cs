/*
 * RESOURCES:
 * https://developers.google.com/workspace/calendar/api/v3/reference/events/insert
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Calendar;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Google.Actions.Calendar
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Calendar.Manifests.{NameReference}.json")]
    public class NewGoogleCalendarEvent(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The plugin name used as the namespace for session parameter storage.
        private const string NameReference = nameof(NewGoogleCalendarEvent);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve Summary: use the provided value or fall back to a timestamped default.
            var defaultSummary = $"New Event {DateTime.UtcNow.ToString(GoogleAdapter.Iso)}";
            var summary = pluginData.Parameters.Get(key: "Summary", defaultValue: defaultSummary);

            // Read optional event fields from plugin parameters.
            var calendarId = pluginData.Parameters.Get(key: "CalendarId", defaultValue: "primary");
            var description = pluginData.Parameters.Get(key: "Description", defaultValue: string.Empty);
            var location = pluginData.Parameters.Get(key: "Location", defaultValue: string.Empty);
            var start = pluginData.Parameters.Get(key: "Start", defaultValue: string.Empty);
            var end = pluginData.Parameters.Get(key: "End", defaultValue: string.Empty);
            var startTimeZone = pluginData.Parameters.Get(key: "StartTimeZone", defaultValue: string.Empty);
            var endTimeZone = pluginData.Parameters.Get(key: "EndTimeZone", defaultValue: string.Empty);
            var attendees = pluginData.Parameters.Get(key: "Attendees", defaultValue: string.Empty);
            var sendUpdates = pluginData.Parameters.Get(key: "SendUpdates", defaultValue: "none");

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Build the start time model — use date-only for all-day events, dateTime for timed events.
            var startTime = NewEventTime(value: start, timeZone: startTimeZone);

            // Build the end time model — use date-only for all-day events, dateTime for timed events.
            var endTime = NewEventTime(value: end, timeZone: endTimeZone);

            // Parse the comma-separated attendee email list into individual attendee entries.
            var attendeeList = FormatAttendees(attendees);

            // Build the event request body with all provided fields.
            var eventBody = new CalendarEventModel
            {
                Summary = summary,
                Description = string.IsNullOrEmpty(description) ? null : description,
                Location = string.IsNullOrEmpty(location) ? null : location,
                Start = startTime,
                End = endTime,
                Attendees = attendeeList.Count > 0 ? attendeeList : null
            };

            // Create the event on the target calendar via the Google Calendar API.
            var calendarEvent = adapter.Calendar.Events.New(new NewEventRequestModel
            {
                CalendarId = calendarId,
                EventModel = eventBody,
                SendUpdates = sendUpdates
            });

            // Persist response details in session parameters (Base64-encoded).
            this.AddSessionParameter(@namespace: NameReference, name: "Id", value: calendarEvent.Id);
            this.AddSessionParameter(@namespace: NameReference, name: "HtmlLink", value: calendarEvent.HtmlLink);
            this.AddSessionParameter(@namespace: NameReference, name: "Status", value: calendarEvent.Status);
            this.AddSessionParameter(@namespace: NameReference, name: "HangoutLink", value: calendarEvent.HangoutLink ?? string.Empty);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }

        // Parses a comma-separated string of email addresses into a list of AttendeeData objects.
        // Empty entries and whitespace-only values are ignored.
        private static List<CalendarEventModel.AttendeeData> FormatAttendees(string attendees)
        {
            if (string.IsNullOrWhiteSpace(attendees))
            {
                return [];
            }

            return [.. attendees
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(email => !string.IsNullOrWhiteSpace(email))
                .Select(email => new CalendarEventModel.AttendeeData { Email = email })];
        }

        // Builds a CalendarEventTimeModel from a raw string value and an optional IANA time zone.
        // When the value contains 'T', it is treated as a dateTime (timed event).
        // Otherwise it is treated as a date (all-day event).
        private static CalendarEventTimeModel NewEventTime(string value, string timeZone)
        {
            var isAllDay = !value.Contains('T');

            return new CalendarEventTimeModel
            {
                Date = isAllDay ? value : null,
                DateTime = isAllDay ? null : value,
                TimeZone = string.IsNullOrEmpty(timeZone) ? null : timeZone
            };
        }
    }
}
