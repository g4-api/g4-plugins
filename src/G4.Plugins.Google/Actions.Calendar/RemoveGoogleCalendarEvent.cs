/*
 * RESOURCES:
 * https://developers.google.com/workspace/calendar/api/v3/reference/events/delete
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Calendar;

namespace G4.Plugins.Google.Actions.Calendar
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Calendar.Manifests.{nameof(RemoveGoogleCalendarEvent)}.json")]
    public class RemoveGoogleCalendarEvent(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the event identifier to delete.
            var eventId = pluginData.Parameters.Get(key: "EventId", defaultValue: string.Empty);

            // Read the target calendar identifier, defaulting to the primary calendar.
            var calendarId = pluginData.Parameters.Get(key: "CalendarId", defaultValue: "primary");

            // Read the notification delivery setting for attendees.
            var sendUpdates = pluginData.Parameters.Get(key: "SendUpdates", defaultValue: "none");

            // Resolve either a credential reference or raw access token (credentials wins over token).
            var credentials = pluginData.ResolveCredentials();

            // Create an adapter authenticated with the resolved credentials/token.
            var adapter = new GoogleAdapter(credentials);

            // Delete the event from the target calendar via the Google Calendar API.
            adapter.Calendar.Events.Remove(new RemoveEventRequestModel
            {
                CalendarId = calendarId,
                EventId = eventId,
                SendUpdates = sendUpdates
            });

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
