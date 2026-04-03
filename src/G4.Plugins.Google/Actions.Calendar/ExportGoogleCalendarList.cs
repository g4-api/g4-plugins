using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Calendar;

using System.Text.Json;

namespace G4.Plugins.Google.Actions.Calendar
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Calendar.Manifests.{NameReference}.json")]
    public class ExportGoogleCalendarList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The plugin name used as the namespace for session parameter storage.
        private const string NameReference = nameof(ExportGoogleCalendarList);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the effective credentials for the request.
            // If multiple credential sources are available, the platform's resolution rules apply.
            var credentials = pluginData.ResolveCredentials();

            // Create the Google API adapter using the resolved credentials.
            var adapter = new GoogleAdapter(credentials);

            // Build the Calendar List request options from the incoming plugin parameters.
            var options = NewOptions(pluginData);

            // Retrieve the calendar list from Google Calendar.
            var response = adapter.Calendar.CalendarList.Get(options);

            // Serialize the full response to JSON so it can be safely persisted in session state.
            var value = JsonSerializer.Serialize(response, PluginDataModel.JsonOptions);

            // Store the serialized result in session parameters for later workflow steps.
            this.AddSessionParameter(@namespace: NameReference, name: "Result", value);

            // Return a successful plugin response.
            return this.NewPluginResponse();
        }

        // Builds a CalendarListRequestModel from the supplied plugin parameters.
        private static CalendarListRequestModel NewOptions(PluginDataModel pluginData)
        {
            // Read the maximum number of calendar entries to return.
            var maxResults = pluginData.Parameters.Get(key: "MaxResults", defaultValue: 100);

            // Read the minimum access role filter, if provided.
            var minAccessRole = pluginData.Parameters.Get(key: "MinAccessRole", defaultValue: default(string));

            // Read the paging token used to continue a previous paged request.
            var pageToken = pluginData.Parameters.Get(key: "PageToken", defaultValue: default(string));

            // Treat the presence of these flags as enabled.
            var showDeleted = pluginData.Parameters.ContainsKey(key: "ShowDeleted");
            var showHidden = pluginData.Parameters.ContainsKey(key: "ShowHidden");

            // Read the sync token used for incremental synchronization, if provided.
            var syncToken = pluginData.Parameters.Get(key: "SyncToken", defaultValue: default(string));

            // Return the fully populated request model.
            return new()
            {
                MaxResults = maxResults,
                MinAccessRole = minAccessRole,
                PageToken = pageToken,
                ShowDeleted = showDeleted,
                ShowHidden = showHidden,
                SyncToken = syncToken
            };
        }
    }
}
