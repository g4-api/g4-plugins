using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Utilities.Udp;

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{NameReference}.json")]
    public class ReceiveUdpMessage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as ReceiveUdpMessage:<Name>.
        private const string NameReference = nameof(ReceiveUdpMessage);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the source of the datagrams: a named listener that is already buffering, or a port this step
            // binds for the length of its own wait.
            var listenerName = pluginData.Parameters.Get(key: "Listener", defaultValue: string.Empty).Trim();
            var isShared = !string.IsNullOrEmpty(listenerName);
            var hasPort = pluginData.Parameters.ContainsKey(key: "Port");
            var isSourceMissing = !isShared && !hasPort;

            // Require one of the two sources, because a step cannot guess where the datagrams arrive.
            if (isSourceMissing)
            {
                throw new InvalidOperationException("Set the 'Listener' or the 'Port' argument.");
            }

            // Validate the output format now, so a bad value fails the step before it waits for datagrams.
            _ = pluginData.ResolveFormat(name: "ResponseFormat");

            // Resolve the count, the wait, and the match rules before opening a socket.
            var count = Math.Max(pluginData.ResolveInteger(name: "Count", defaultValue: 1), 1);
            var timeout = pluginData.ResolveTimeout();
            var options = new UdpListener.ReceiveOptions
            {
                Filter = NewFilter(pluginData),
                Maximum = count,
                Minimum = count,
                Timeout = timeout
            };

            // Read from the named listener, or bind the port now and receive what arrives during the wait.
            var listener = isShared
                ? UdpListenerRegistry.Get(invoker: Invoker, name: listenerName)
                : NewListener(pluginData);

            try
            {
                // Wait for the requested number of matching datagrams; they leave the buffer only when all arrived.
                var datagrams = listener.Receive(options);

                // Report a listener another step stopped during the wait as a stop, not as a timeout.
                var isStopped = datagrams.Count < count && isShared && listener.IsStopped;

                if (isStopped)
                {
                    var message = $"The UDP listener '{listenerName}' was stopped while the step was waiting; " +
                        $"{datagrams.Count} of {count} UDP datagram(s) arrived.";
                    throw new InvalidOperationException(message);
                }

                // Fail the step when too few arrived, and say how many did, so a slow sender is easy to spot.
                if (datagrams.Count < count)
                {
                    var milliseconds = timeout.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                    var message = $"Received {datagrams.Count} of {count} UDP datagram(s) on port {listener.Port} " +
                        $"within {milliseconds} ms.";
                    throw new TimeoutException(message);
                }

                // Publish the first datagram, the count, the full list, and the sender of the first datagram.
                var outputs = pluginData.NewDatagramOutputs(datagrams, name: "Message");

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

        // Creates the test a datagram must pass to count, from the RemoteHost, RemotePort, and Pattern arguments.
        // Returns null when the step sets none of them, which accepts every datagram. The host is resolved and the
        // pattern is compiled here, before the wait, so a bad value fails the step at once and the test itself only
        // compares and matches. The listener runs the test outside its gate.
        private static Func<UdpDatagramModel, bool> NewFilter(PluginDataModel pluginData)
        {
            // Read the three optional match rules; an empty value means "any".
            var remoteHost = pluginData.Parameters.Get(key: "RemoteHost", defaultValue: string.Empty).Trim();
            var remotePort = pluginData.ResolvePort(name: "RemotePort", defaultValue: 0);
            var pattern = pluginData.Parameters.Get(key: "Pattern", defaultValue: string.Empty);
            var encoding = pluginData.ResolveEncoding();

            // Skip the filter when no rule is set, so the listener hands over datagrams in arrival order.
            var isAnyHost = string.IsNullOrEmpty(remoteHost);
            var isAnyPort = remotePort == 0;
            var isAnyText = string.IsNullOrEmpty(pattern);

            if (isAnyHost && isAnyPort && isAnyText)
            {
                return null;
            }

            // Resolve the host to its addresses now; a datagram reports its sender as an address, not as a name.
            var addresses = isAnyHost
                ? []
                : UdpExtensions
                    .ResolveAddresses(host: remoteHost)
                    .Select(i => $"{i}")
                    .ToArray();

            // Compile the pattern now, so a malformed expression fails the step before it waits.
            var expression = isAnyText
                ? null
                : UdpExtensions.NewPattern(pattern);

            return datagram =>
            {
                // Compare the sender first, because it is cheaper than decoding and matching the payload.
                var comparer = StringComparer.OrdinalIgnoreCase;
                var isHost = isAnyHost || addresses.Contains(datagram.RemoteAddress, comparer);
                var isPort = isAnyPort || datagram.RemotePort == remotePort;

                if (!isHost || !isPort)
                {
                    return false;
                }

                // Match the pattern against the payload as text in the encoding of the step.
                return isAnyText || TestPattern(expression, input: encoding.GetString(datagram.Data));
            };
        }

        // Opens the socket of a step that names no listener, bound to the Port argument and the optional
        // LocalAddress, and joined to the optional MulticastGroup. The caller owns the listener and disposes it
        // before the step returns.
        private static UdpListener NewListener(PluginDataModel pluginData)
        {
            // Resolve the socket settings first, so an address error is reported before the port rule.
            var options = new UdpListener.ListenerOptions
            {
                LocalAddress = pluginData.ResolveAddress(name: "LocalAddress"),
                MulticastGroup = pluginData.ResolveAddress(name: "MulticastGroup"),
                Name = NameReference,
                Port = pluginData.ResolvePort(name: "Port", defaultValue: 0)
            };

            // Reject port 0, because the system then picks a port that no sender can know.
            if (options.Port == 0)
            {
                var message = $"The 'Port' argument must be a port from 1 to {UdpExtensions.MaximumPort}.";
                throw new InvalidOperationException(message);
            }

            // Bind the port the sender targets; datagrams that arrive before this point are lost.
            return new UdpListener(options);
        }

        // Tests one datagram text against the Pattern expression. A match that runs past the regular expression
        // timeout fails the step with a message that names the argument, instead of a runtime timeout message.
        private static bool TestPattern(Regex expression, string input)
        {
            try
            {
                // Match the decoded payload; the expression carries the match timeout of the step.
                return expression.IsMatch(input);
            }
            catch (RegexMatchTimeoutException exception)
            {
                // Name the argument and the limit, so the flow author knows which pattern to simplify.
                var message = $"The 'Pattern' argument took longer than {exception.MatchTimeout} to match a datagram.";
                throw new InvalidOperationException(message, exception);
            }
        }
    }
}
