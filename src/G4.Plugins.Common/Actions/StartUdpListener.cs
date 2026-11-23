using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Udp;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{NameReference}.json")]
    public class StartUdpListener(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as StartUdpListener:<Name>.
        private const string NameReference = nameof(StartUdpListener);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the name and the local endpoint before binding, so a bad argument never opens a socket.
            var name = pluginData.ResolveListenerName();
            var options = new UdpListener.ListenerOptions
            {
                BufferSize = pluginData.ResolveInteger(name: "BufferSize", defaultValue: UdpListener.DefaultBufferSize),
                LocalAddress = pluginData.ResolveAddress(name: "LocalAddress"),
                MulticastGroup = pluginData.ResolveAddress(name: "MulticastGroup"),
                Name = name,
                Port = pluginData.ResolvePort(name: "Port", defaultValue: 0)
            };

            // Reject a second listener with the same name before binding, because the first one stays in use.
            if (UdpListenerRegistry.Find(invoker: Invoker, name) is not null)
            {
                var message = UdpListenerRegistry.NewStartedMessage(name);
                throw new InvalidOperationException(message);
            }

            // Bind the socket and start buffering; a port that is in use fails the step here.
            var listener = new UdpListener(options);

            try
            {
                // Hand the listener to the registry, which keeps it for later steps and closes it with the flow.
                UdpListenerRegistry.Add(invoker: Invoker, listener);
            }
            catch (Exception)
            {
                // Registration failed, typically because another lane registered the same name first; release the
                // port this step just bound before reporting the failure.
                listener.Dispose();
                throw;
            }

            // Publish the name and the bound port, which is the system-assigned one when the step asked for port 0.
            var outputs = new Dictionary<string, string>
            {
                ["Name"] = listener.Name,
                ["Port"] = listener.Port.ToString(CultureInfo.InvariantCulture)
            };

            return this.NewUdpResponse(nameReference: NameReference, outputs, noEntity: false);
        }
    }
}
