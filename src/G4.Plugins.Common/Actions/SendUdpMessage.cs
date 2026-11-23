using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Utilities.Udp;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{NameReference}.json")]
    public class SendUdpMessage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as SendUdpMessage:<Name>.
        private const string NameReference = nameof(SendUdpMessage);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve every argument before opening a socket, so a bad argument sends nothing.
            var host = pluginData.ResolveRequired(name: "Host");
            var port = pluginData.ResolvePort(name: "Port", defaultValue: 0);
            var request = NewRequest(pluginData);
            var listenerName = pluginData.Parameters.Get(key: "Listener", defaultValue: string.Empty).Trim();
            var isShared = !string.IsNullOrEmpty(listenerName);

            // Reject port 0, which is a valid local port but never a destination.
            if (port == 0)
            {
                var message = $"The 'Port' argument must be a port from 1 to {UdpExtensions.MaximumPort}.";
                throw new InvalidOperationException(message);
            }

            // Send through the named listener so replies land in its buffer, or through a socket this step owns.
            var listener = isShared
                ? UdpListenerRegistry.Get(invoker: Invoker, name: listenerName)
                : NewListener(pluginData);

            try
            {
                // Allow broadcast destinations when the step asks for it; the system rejects a subnet broadcast
                // address on a socket without the option. On a named listener the option stays on for later steps.
                if (pluginData.TestSwitch(name: "Broadcast"))
                {
                    listener.EnableBroadcast();
                }

                // Resolve the host for the address family of the socket, then send and collect the replies.
                var addressFamily = listener.AddressFamily;
                request.RemoteEndPoint = UdpExtensions.ResolveEndPoint(host, port, addressFamily);
                var datagrams = SendMessage(listener, request);

                // Publish the replies; without a reply the remote endpoint is the resolved destination.
                var outputs = pluginData.NewDatagramOutputs(datagrams, name: "Response");
                outputs["BytesSent"] = request.Payload.Length.ToString(CultureInfo.InvariantCulture);

                if (datagrams.Count == 0)
                {
                    outputs["RemoteAddress"] = $"{request.RemoteEndPoint.Address}";
                    outputs["RemotePort"] = request.RemoteEndPoint.Port.ToString(CultureInfo.InvariantCulture);
                }

                return this.NewUdpResponse(
                    nameReference: NameReference,
                    outputs,
                    noEntity: pluginData.TestSwitch(name: "NoEntity"));
            }
            finally
            {
                // Close the socket this step opened; a named listener stays open for later steps.
                if (!isShared)
                {
                    listener.Dispose();
                }
            }
        }

        // Opens the socket of a step that names no listener, bound to the optional LocalAddress and LocalPort.
        // The caller owns the listener and disposes it before the step returns.
        private static UdpListener NewListener(PluginDataModel pluginData)
        {
            // Let the system pick the source port unless the device expects a fixed one.
            var options = new UdpListener.ListenerOptions
            {
                LocalAddress = pluginData.ResolveAddress(name: "LocalAddress"),
                Name = NameReference,
                Port = pluginData.ResolvePort(name: "LocalPort", defaultValue: 0)
            };

            return new UdpListener(options);
        }

        // Creates the test that a datagram is a reply to the request. A reply to a unicast destination comes from
        // the destination address, so datagrams from any other sender stay in a shared listener buffer. A broadcast
        // or multicast request is answered by many devices, so every datagram counts. An IPv4 address that ends in
        // 255 is treated as a subnet broadcast, because the subnet mask of the destination is unknown here.
        private static Func<UdpDatagramModel, bool> NewReplyFilter(IPEndPoint remoteEndPoint)
        {
            // Classify the destination: IPv4 broadcast, IPv4 multicast (224.0.0.0/4), or IPv6 multicast.
            var address = remoteEndPoint.Address;
            var bytes = address.GetAddressBytes();
            var isIPv4 = address.AddressFamily == AddressFamily.InterNetwork;
            var isBroadcast = isIPv4 && bytes[^1] == 255;
            var isGroup = isIPv4
                ? (bytes[0] & 0xF0) == 0xE0
                : address.IsIPv6Multicast;

            // Accept every sender for a broadcast or multicast destination.
            if (isBroadcast || isGroup)
            {
                return null;
            }

            // Compare the sender with the destination as text, which is how a datagram reports its sender.
            var destination = $"{address}";

            return datagram => string.Equals(datagram.RemoteAddress, destination, StringComparison.OrdinalIgnoreCase);
        }

        // Reads the payload and the reply settings of the step. Every value is parsed here, before a socket is
        // opened; the destination is added later, because resolving it needs the address family of the socket.
        private static SendRequest NewRequest(PluginDataModel pluginData)
        {
            // Validate the output settings now, so a bad value fails the step before the datagram leaves.
            _ = pluginData.ResolveFormat(name: "ResponseFormat");
            _ = pluginData.ResolveEncoding();

            // Read the payload now; a MessageFile is read from disk here, before any socket opens.
            var payload = pluginData.ResolvePayload();

            // Wait and retry only when the step asks for a reply; a plain send is fire-and-forget.
            var isWaiting = pluginData.TestSwitch(name: "WaitForResponse");

            return new SendRequest
            {
                IsAnySender = pluginData.TestSwitch(name: "AnySender"),
                IsWaiting = isWaiting,
                MaxResponses = Math.Max(pluginData.ResolveInteger(name: "MaxResponses", defaultValue: 1), 1),
                Payload = payload,
                Retries = isWaiting ? pluginData.ResolveInteger(name: "Retries", defaultValue: 0) : 0,
                Timeout = pluginData.ResolveTimeout()
            };
        }

        // Sends the datagram and, when the step waits, collects the replies. Sends again, up to Retries times,
        // while no reply arrives, and fails the step when every attempt ends without one. Returns an empty list
        // for a send that does not wait.
        private static IList<UdpDatagramModel> SendMessage(UdpListener listener, SendRequest request)
        {
            // Accept only replies from the destination (every sender for broadcast or multicast, or when the step
            // sets AnySender), and end the wait at MaxResponses replies; a single reply is enough for the step to pass.
            var options = new UdpListener.ReceiveOptions
            {
                Filter = request.IsAnySender ? null : NewReplyFilter(request.RemoteEndPoint),
                Maximum = request.MaxResponses,
                Minimum = 1,
                Timeout = request.Timeout
            };

            for (var attempt = 0; attempt <= request.Retries; attempt++)
            {
                // Mark the buffer before sending, so only datagrams that arrive after this send count as replies
                // when the socket is a shared listener that already holds older datagrams.
                options.AfterSequence = listener.Sequence;
                listener.Send(data: request.Payload, remoteEndPoint: request.RemoteEndPoint);

                // Return right after a fire-and-forget send.
                if (!request.IsWaiting)
                {
                    return [];
                }

                // Wait for the replies; UDP reports neither a lost request nor a lost reply, so silence means retry.
                var datagrams = listener.Receive(options);

                if (datagrams.Count > 0)
                {
                    return datagrams;
                }
            }

            // Report the destination, the wait, and the attempts, so the failure reads without the flow.
            var milliseconds = request.Timeout.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
            var message = $"No UDP response arrived from {request.RemoteEndPoint} within {milliseconds} ms " +
                $"after {request.Retries + 1} attempt(s).";
            throw new TimeoutException(message);
        }

        // Carries the parsed arguments of one send from OnSend to the send loop, so the loop takes one value
        // instead of a long parameter list.
        private sealed class SendRequest
        {
            // True when a datagram from any sender counts as a reply, for a device that answers from another address.
            public bool IsAnySender { get; set; }

            // True when the step waits for a reply and fails without one.
            public bool IsWaiting { get; set; }

            // The number of replies that ends the wait before the timeout; at least 1.
            public int MaxResponses { get; set; }

            // The bytes of the datagram.
            public byte[] Payload { get; set; }

            // The resolved destination; set after the socket is open, because it depends on its address family.
            public IPEndPoint RemoteEndPoint { get; set; }

            // The number of times the datagram is sent again while no reply arrives.
            public int Retries { get; set; }

            // The wait for replies after each send.
            public TimeSpan Timeout { get; set; }
        }
    }
}
