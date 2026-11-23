using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Utilities.Udp;

using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{NameReference}.json")]
    public class StopUdpListener(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as StopUdpListener:<Name>.
        private const string NameReference = nameof(StopUdpListener);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the listener name; a step without one stops the default listener.
            var name = pluginData.ResolveListenerName();

            // Close the socket and drop the datagrams no step read. A name that is not started is not a failure,
            // so a cleanup step is safe to run after an earlier step already stopped the listener.
            var isStopped = UdpListenerRegistry.Remove(invoker: Invoker, name);

            // Publish the name and whether a listener was open, so a flow can tell the two outcomes apart.
            var outputs = new Dictionary<string, string>
            {
                ["Name"] = name,
                ["Stopped"] = isStopped ? "true" : "false"
            };

            return this.NewUdpResponse(nameReference: NameReference, outputs, noEntity: false);
        }
    }
}
