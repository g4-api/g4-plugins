using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace G4.Plugins.Common.Udp
{
    /// <summary>
    /// Owns one bound UDP socket, buffers every datagram that arrives on it, and sends datagrams from it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// UDP drops a datagram that arrives while no socket is bound, so the listener starts receiving in its
    /// constructor and keeps the datagrams in memory until a step reads them. A named listener lives in
    /// <see cref="UdpListenerRegistry"/> across steps; a step without a named listener creates a private one and
    /// disposes it before the step returns.
    /// </para>
    /// <para>
    /// The buffer is bounded: when it is full the oldest datagram is dropped. <see cref="Dispose"/> closes the
    /// socket, ends the receive loop, and releases every step that waits in <see cref="Receive(ReceiveOptions)"/>.
    /// </para>
    /// </remarks>
    internal sealed class UdpListener : IDisposable
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the number of datagrams a listener keeps when the step names no buffer size.
        /// </summary>
        public const int DefaultBufferSize = 1000;

        // Bounds the wait for the receive loop to end after the socket closes, so disposing never blocks a flow.
        private const int StopTimeoutMilliseconds = 2000;

        // Caps one wait on the gate, because Monitor.Wait rejects a timeout above int.MaxValue milliseconds; a longer
        // step timeout simply waits again.
        private static readonly TimeSpan MaximumWait = TimeSpan.FromMilliseconds(int.MaxValue);
        #endregion

        #region *** Fields       ***
        // Holds the datagrams that arrived and no step consumed yet, oldest first. Guarded by _gate.
        private readonly List<UdpDatagramModel> _buffer = [];

        // Caps _buffer; the oldest datagram is dropped when one more arrives.
        private readonly int _bufferSize;

        // Ends the receive loop when the listener is disposed.
        private readonly CancellationTokenSource _cancellation = new();

        // The bound socket; the receive loop reads from it and steps send through it.
        private readonly UdpClient _client;

        // Guards _buffer, _sequence, and _isDisposed, and wakes the steps that wait for a datagram.
        private readonly object _gate = new();

        // The background receive loop; Dispose waits for it so no read is left running on a closed socket.
        private readonly Task _receiveTask;

        // Set once by Dispose so waiting steps return and a second Dispose does nothing. Guarded by _gate.
        private bool _isDisposed;

        // The arrival number of the last datagram. Guarded by _gate.
        private long _sequence;
        #endregion

        #region *** Constructors ***
        /// <summary>
        /// Initializes a new instance of the <see cref="UdpListener"/> class, binds its socket, and starts receiving.
        /// </summary>
        /// <param name="options">The name, the local endpoint, and the socket settings of the listener.</param>
        /// <exception cref="SocketException">
        /// Thrown when the local endpoint cannot be bound, for example because another socket holds the port.
        /// </exception>
        public UdpListener(ListenerOptions options)
        {
            // Require the options before reading the endpoint they describe.
            ArgumentNullException.ThrowIfNull(argument: options);

            // Keep the identity and the buffer cap; a non-positive size selects the default.
            Name = options.Name;
            _bufferSize = options.BufferSize > 0 ? options.BufferSize : DefaultBufferSize;

            // Bind the socket and publish the endpoint the system assigned, which matters when the port is 0.
            _client = NewClient(options);
            var localEndPoint = (IPEndPoint)_client.Client.LocalEndPoint;
            LocalAddress = $"{localEndPoint.Address}";
            Port = localEndPoint.Port;

            // Start receiving right away so no datagram is lost between this constructor and the first read.
            var cancellationToken = _cancellation.Token;
            _receiveTask = Task.Run(() => ReceiveDatagramsAsync(listener: this, cancellationToken));
        }
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the address family of the socket, which selects the destination addresses it can reach.
        /// </summary>
        public AddressFamily AddressFamily => _client.Client.AddressFamily;

        /// <summary>
        /// Gets a value indicating whether the listener was stopped.
        /// </summary>
        /// <remarks>
        /// A step that waited on a named listener reads it after <see cref="Receive(ReceiveOptions)"/> returns early,
        /// so it can report a stop by another step instead of a timeout.
        /// </remarks>
        public bool IsStopped
        {
            get
            {
                // Read under the gate, because Dispose sets the flag under the same gate.
                lock (_gate)
                {
                    return _isDisposed;
                }
            }
        }

        /// <summary>
        /// Gets the local IP address the socket is bound to.
        /// </summary>
        public string LocalAddress { get; }

        /// <summary>
        /// Gets the name a step uses to reach the listener.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the local port the socket is bound to.
        /// </summary>
        /// <remarks>
        /// This is the port the system assigned when the listener was started with port 0.
        /// </remarks>
        public int Port { get; }

        /// <summary>
        /// Gets the arrival number of the last datagram the listener received; 0 before the first one.
        /// </summary>
        public long Sequence
        {
            get
            {
                // Read under the gate so the value is consistent with the buffer a step reads next.
                lock (_gate)
                {
                    return _sequence;
                }
            }
        }
        #endregion

        #region *** Methods      ***
        /// <inheritdoc />
        public void Dispose()
        {
            // Mark the listener closed once and wake every waiting step so none waits out its timeout.
            lock (_gate)
            {
                if (_isDisposed)
                {
                    return;
                }

                _isDisposed = true;
                Monitor.PulseAll(_gate);
            }

            // Stop the receive loop and close the socket, which releases the port for the next listener.
            _cancellation.Cancel();
            _client.Dispose();

            // Wait briefly for the loop to end; it handles its own failures, so the wait never throws.
            _receiveTask.Wait(millisecondsTimeout: StopTimeoutMilliseconds);
            _cancellation.Dispose();
        }

        /// <summary>
        /// Allows the socket to send to a broadcast address.
        /// </summary>
        /// <remarks>
        /// The setting stays on for the lifetime of the listener; it does not change what the listener receives.
        /// </remarks>
        public void EnableBroadcast()
        {
            // Set the socket option the system requires before it accepts a broadcast destination.
            _client.EnableBroadcast = true;
        }

        /// <summary>
        /// Waits for buffered datagrams that match the options and removes the ones it returns.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The call returns as soon as <see cref="ReceiveOptions.Maximum"/> matching datagrams are buffered, or when
        /// the timeout ends or the listener is disposed. Matching datagrams are removed from the buffer only when at
        /// least <see cref="ReceiveOptions.Minimum"/> of them are present; otherwise they stay buffered for a later
        /// read and the smaller set is returned so the caller can report how many arrived. Datagrams that do not
        /// match are never removed.
        /// </para>
        /// <para>
        /// <see cref="ReceiveOptions.Filter"/> runs outside the gate, once per datagram and call, so a slow test
        /// never stops the receive loop or another step that reads the same listener. A datagram that another step
        /// takes in the meantime is simply no longer a candidate.
        /// </para>
        /// </remarks>
        /// <param name="options">The match rules, the required and accepted counts, and the timeout.</param>
        /// <returns>The matching datagrams, oldest first.</returns>
        public IList<UdpDatagramModel> Receive(ReceiveOptions options)
        {
            // Require the options and treat a missing filter as "every datagram matches".
            ArgumentNullException.ThrowIfNull(argument: options);
            var filter = options.Filter ?? (_ => true);

            // Start the wait clock before the first look at the buffer, so gate contention counts against the timeout.
            var stopwatch = Stopwatch.StartNew();

            // Remember the verdict of every datagram this call has tested, keyed by its arrival number.
            var verdicts = new Dictionary<long, bool>();

            while (true)
            {
                // Copy the datagrams this call has not tested yet, then test them without holding the gate.
                List<UdpDatagramModel> candidates;

                lock (_gate)
                {
                    candidates = [.. _buffer.Where(i => TestCandidate(datagram: i, options, verdicts))];
                }

                foreach (var candidate in candidates)
                {
                    verdicts[candidate.Sequence] = filter(candidate);
                }

                lock (_gate)
                {
                    // Collect the tested datagrams that matched and are still buffered, in arrival order.
                    var matches = _buffer
                        .Where(i => verdicts.GetValueOrDefault(i.Sequence))
                        .Take(options.Maximum)
                        .ToList();

                    // Stop when the accepted count is reached, the timeout ended, or the listener closed.
                    var remaining = options.Timeout - stopwatch.Elapsed;
                    var isComplete = matches.Count >= options.Maximum;
                    var isTimedOut = remaining <= TimeSpan.Zero;
                    var isFinished = isComplete || isTimedOut || _isDisposed;

                    if (isFinished)
                    {
                        return RemoveMatches(buffer: _buffer, matches, minimum: options.Minimum);
                    }

                    // Forget the verdicts of datagrams that left the buffer on every pass, so a long wait on a busy
                    // listener keeps the map within twice the buffer size.
                    RemoveVerdicts(buffer: _buffer, verdicts);

                    // Test again at once when a datagram arrived while the gate was free, because a wait now misses it.
                    var isUntested = _buffer.Exists(i => TestCandidate(datagram: i, options, verdicts));

                    if (isUntested)
                    {
                        continue;
                    }

                    // Release the gate until the receive loop adds a datagram or the remaining time ends.
                    var wait = remaining < MaximumWait ? remaining : MaximumWait;
                    Monitor.Wait(_gate, timeout: wait);
                }
            }
        }

        /// <summary>
        /// Sends one datagram from the socket of the listener.
        /// </summary>
        /// <remarks>
        /// A reply to the datagram arrives on the same socket, so it lands in the buffer of this listener.
        /// </remarks>
        /// <param name="data">The payload to send.</param>
        /// <param name="remoteEndPoint">The destination address and port.</param>
        /// <returns>The number of bytes sent.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when another step stopped the listener, so the failure names the listener instead of the socket.
        /// </exception>
        public int Send(byte[] data, IPEndPoint remoteEndPoint)
        {
            try
            {
                // Send the whole payload as one datagram; UDP never splits a send across datagrams.
                return _client.Send(dgram: data, bytes: data.Length, endPoint: remoteEndPoint);
            }
            catch (ObjectDisposedException exception)
            {
                // Report a listener another lane or step stopped while this step was using it.
                var message = $"The UDP listener '{Name}' was stopped while a step was sending through it.";
                throw new InvalidOperationException(message, exception);
            }
        }

        // Adds one received datagram to the buffer of the listener and wakes the waiting steps. Runs on the receive
        // loop only; the listener is passed in so the state the helper changes is visible at the call site.
        private static void AddDatagram(UdpListener listener, UdpReceiveResult result)
        {
            lock (listener._gate)
            {
                // Number the datagram so a step can tell the ones that arrived after its own send.
                listener._sequence++;
                listener._buffer.Add(new UdpDatagramModel
                {
                    Data = result.Buffer,
                    ReceivedAt = DateTime.UtcNow,
                    RemoteAddress = $"{result.RemoteEndPoint.Address}",
                    RemotePort = result.RemoteEndPoint.Port,
                    Sequence = listener._sequence
                });

                // Drop the oldest datagram when the buffer is full, so a forgotten listener cannot grow without limit.
                if (listener._buffer.Count > listener._bufferSize)
                {
                    listener._buffer.RemoveAt(index: 0);
                }

                // Wake every waiting step; each one re-checks the buffer against its own match rules.
                Monitor.PulseAll(listener._gate);
            }
        }

        // Joins the multicast group of the options on a bound socket. An IPv4 group is joined on the interface of
        // the local address when the step names one; every other case uses the default interface of the system.
        private static void JoinGroup(UdpClient client, ListenerOptions options)
        {
            // Select the interface by its address, which only the IPv4 form of the join accepts.
            var isInterfaceSelected = options.LocalAddress is not null
                && options.MulticastGroup.AddressFamily == AddressFamily.InterNetwork;

            if (isInterfaceSelected)
            {
                client.JoinMulticastGroup(multicastAddr: options.MulticastGroup, localAddress: options.LocalAddress);
                return;
            }

            // Let the system pick the interface, so the group is joined on its default multicast route.
            client.JoinMulticastGroup(multicastAddr: options.MulticastGroup);
        }

        // Binds a socket to the local endpoint of the options and joins the multicast group when one is named.
        // The socket is disposed when any step of the setup fails, so a failed start never holds the port.
        private static UdpClient NewClient(ListenerOptions options)
        {
            // Bind every interface for a multicast listener, because a socket bound to one unicast address does
            // not receive group traffic on every system; the local address then selects the interface of the join.
            // Any other listener binds the local address of the step, or every IPv4 interface without one.
            var isMulticast = options.MulticastGroup is not null;
            var isIPv6Group = isMulticast && options.MulticastGroup.AddressFamily == AddressFamily.InterNetworkV6;
            var anyAddress = isIPv6Group ? IPAddress.IPv6Any : IPAddress.Any;
            var unicastAddress = options.LocalAddress ?? IPAddress.Any;
            var localAddress = isMulticast ? anyAddress : unicastAddress;

            // Create the socket for the address family of the bind; this method owns it until it returns it.
            var client = new UdpClient(localAddress.AddressFamily);

            try
            {
                // Share the port with other multicast receivers on the machine, which the group requires.
                if (isMulticast)
                {
                    client.Client.SetSocketOption(
                        optionLevel: SocketOptionLevel.Socket,
                        optionName: SocketOptionName.ReuseAddress,
                        optionValue: true);
                }

                // Bind first, because a group can only be joined on a bound socket.
                client.Client.Bind(new IPEndPoint(localAddress, options.Port));

                // Join the group so the system delivers its datagrams to this socket.
                if (isMulticast)
                {
                    JoinGroup(client, options);
                }

                return client;
            }
            catch (Exception)
            {
                // Release the socket before reporting the failure to the step.
                client.Dispose();
                throw;
            }
        }

        // Reads datagrams from the socket of the listener until the listener is disposed. The loop owns every
        // failure of the socket, so the task it runs on always completes without an exception.
        private static async Task ReceiveDatagramsAsync(UdpListener listener, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Wait for the next datagram and buffer it for the steps.
                    var result = await listener._client.ReceiveAsync(cancellationToken).ConfigureAwait(false);
                    AddDatagram(listener, result);
                }
                catch (SocketException exception) when (exception.SocketErrorCode == SocketError.ConnectionReset)
                {
                    // Windows reports an unreachable destination of an earlier send as a reset on the next
                    // receive. The socket is still usable, so the loop keeps receiving.
                }
                catch (Exception)
                {
                    // The socket closed or failed for good; end the loop so Dispose can complete.
                    break;
                }
            }
        }

        // Returns the matches and removes them from the buffer when the required count is present. Runs under the
        // gate of the calling listener; the buffer is passed in so the helper stays static.
        private static List<UdpDatagramModel> RemoveMatches(
            List<UdpDatagramModel> buffer,
            List<UdpDatagramModel> matches,
            int minimum)
        {
            // Leave the datagrams buffered when too few arrived, so a later read can still take them.
            if (matches.Count < minimum)
            {
                return matches;
            }

            // Consume the datagrams the step receives so the next read starts after them.
            foreach (var match in matches)
            {
                buffer.Remove(match);
            }

            return matches;
        }

        // Removes the verdicts whose datagram is no longer buffered, because another step took it or the buffer
        // dropped it. Runs under the gate of the calling listener; it prunes only when the map outgrew twice the buffer.
        private static void RemoveVerdicts(List<UdpDatagramModel> buffer, Dictionary<long, bool> verdicts)
        {
            // Skip the scan while the map is no larger than twice the buffer, which keeps the cost of a wait low.
            if (verdicts.Count <= buffer.Count * 2)
            {
                return;
            }

            // Keep only the arrival numbers that are still buffered.
            var buffered = buffer.Select(i => i.Sequence).ToHashSet();

            foreach (var sequence in verdicts.Keys.Where(i => !buffered.Contains(i)).ToList())
            {
                verdicts.Remove(sequence);
            }
        }

        // Tests whether a buffered datagram is still waiting for its first test in the current Receive call: it arrived
        // after the starting point of the call and has no verdict yet. Runs under the gate, so it only reads.
        private static bool TestCandidate(
            UdpDatagramModel datagram,
            ReceiveOptions options,
            Dictionary<long, bool> verdicts)
        {
            // Skip datagrams from before the starting point and the ones this call already tested.
            var isAfterStart = datagram.Sequence > options.AfterSequence;

            return isAfterStart && !verdicts.ContainsKey(datagram.Sequence);
        }
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// Describes the local endpoint and the socket settings of a new <see cref="UdpListener"/>.
        /// </summary>
        public class ListenerOptions
        {
            #region *** Properties   ***
            /// <summary>
            /// Gets or sets the number of datagrams the listener keeps before it drops the oldest.
            /// </summary>
            /// <remarks>
            /// A value of 0 or less selects <see cref="DefaultBufferSize"/>.
            /// </remarks>
            public int BufferSize { get; set; }

            /// <summary>
            /// Gets or sets the local IP address to bind.
            /// </summary>
            /// <remarks>
            /// Null binds every IPv4 interface. An IPv6 address makes the listener an IPv6 socket. With a
            /// <see cref="MulticastGroup"/> the socket binds every interface and this address selects the interface
            /// the group is joined on.
            /// </remarks>
            public IPAddress LocalAddress { get; set; }

            /// <summary>
            /// Gets or sets the multicast group to join.
            /// </summary>
            /// <remarks>
            /// Null leaves the listener a plain unicast and broadcast receiver.
            /// </remarks>
            public IPAddress MulticastGroup { get; set; }

            /// <summary>
            /// Gets or sets the name a step uses to reach the listener.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the local port to bind.
            /// </summary>
            /// <remarks>
            /// The value 0 lets the system assign a free port, which <see cref="UdpListener.Port"/> then reports.
            /// </remarks>
            public int Port { get; set; }
            #endregion
        }

        /// <summary>
        /// Describes which buffered datagrams one <see cref="UdpListener.Receive(ReceiveOptions)"/> call accepts.
        /// </summary>
        public class ReceiveOptions
        {
            #region *** Properties   ***
            /// <summary>
            /// Gets or sets the arrival number after which datagrams are accepted.
            /// </summary>
            /// <remarks>
            /// The value 0 accepts every buffered datagram. A step that waits for a reply sets the arrival number it
            /// read before sending, so older datagrams are not taken for replies.
            /// </remarks>
            public long AfterSequence { get; set; }

            /// <summary>
            /// Gets or sets the test a datagram must pass to be accepted.
            /// </summary>
            /// <remarks>
            /// Null accepts every datagram. The test runs outside the gate of the listener, once per datagram and
            /// call, so a slow pattern delays only the step that supplied it.
            /// </remarks>
            public Func<UdpDatagramModel, bool> Filter { get; set; }

            /// <summary>
            /// Gets or sets the number of datagrams that ends the wait before the timeout.
            /// </summary>
            public int Maximum { get; set; }

            /// <summary>
            /// Gets or sets the number of datagrams that must be present before any is removed from the buffer.
            /// </summary>
            public int Minimum { get; set; }

            /// <summary>
            /// Gets or sets the longest time to wait for <see cref="Maximum"/> datagrams.
            /// </summary>
            /// <remarks>
            /// Zero or a negative value reads only what is already buffered.
            /// </remarks>
            public TimeSpan Timeout { get; set; }
            #endregion
        }
        #endregion
    }
}
