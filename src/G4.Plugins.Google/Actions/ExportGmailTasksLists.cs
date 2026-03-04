using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Actions.Abstraction;

namespace G4.Plugins.Google.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Manifests.{nameof(ExportGmailTasksLists)}.json")]
    public class ExportGmailTasksLists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read either a raw access token or a credential record reference.
            var token = pluginData.Parameters.Get(key: "token", defaultValue: string.Empty);
            var credentials = pluginData.Parameters.Get(key: "credentials", defaultValue: string.Empty);

            // Get the lists from Google using the plugin's static method,
            // which handles both token and credentials scenarios.
            var itemsJson = GooglePlugin.ExportTasksLists(token, credentials);

            // Persist the exported lists in session parameters (Base64-encoded for safe transport/storage).
            Invoker.Context.SessionParameters["GmailTasksListsResult"] = string.IsNullOrEmpty(itemsJson)
                    ? "[]".ConvertToBase64()
                    : itemsJson.ConvertToBase64();

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
