using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

using System.Linq;
using System.Reflection;

namespace G4.Plugins.Google.Actions.Calendar
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Calendar.Manifests.{NameReference}.json")]
    public class ExportGoogleCalendar(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The plugin name used as the namespace for session parameter storage.
        private const string NameReference = nameof(ExportGoogleCalendar);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the effective credentials for the request.
            // If multiple credential sources are available, the platform's resolution rules apply.
            var credentials = pluginData.ResolveCredentials();

            // Create the Google API adapter using the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Extract the calendar ID from plugin parameters, defaulting to "primary" if not provided.
            var id = pluginData.Parameters.Get(key: "CalendarId", defaultValue: "primary");

            // Call the Google Calendar API to get the calendar details for the specified ID.
            var calendar = adapter.Calendar.CalendarList.Get(id);

            // Store the serialized result in session parameters for later workflow steps.
            this.AddSessionParameter(@namespace: NameReference, name: "Id", calendar.Id);

            // Return a successful plugin response.
            var response = this.NewPluginResponse();

            // Serialize the calendar object into a dictionary
            // of property names and values for the response entity.
            response.Entity = calendar
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(k => k.Name, v => v.GetValue(calendar));

            // The response entity now contains all the properties of the calendar object,
            return response;
        }
    }
}
