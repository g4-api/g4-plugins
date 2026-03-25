using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Extensions;

namespace G4.Plugins.Google.Actions.Tasks
{
    [G4Plugin(
        assembly: "G4.Plugins.Google, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Google.Actions.Tasks.Manifests.{nameof(RemoveGoogleTaskList)}.json")]
    public class RemoveGoogleTaskList(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the list id to delete.
            var id = pluginData.Parameters.Get(key: "Id", defaultValue: string.Empty);

            // If both a raw token and credentials reference are
            // provided, prioritize the credentials reference.
            var credentials = pluginData.ResolveCredentials();

            // Remove an existing Gmail Task List using the adapter.
            // The adapter abstracts the underlying API calls, allowing for cleaner and more maintainable code.
            new GoogleAdapter(credentials)
                .TaskLists
                .Remove(taskList: id);

            // Indicate successful completion.
            return this.NewPluginResponse();
        }
    }
}
