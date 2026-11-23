using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Runs a UDP peer on the loopback interface for the UDP plugin tests.
    /// </summary>
    /// <remarks>
    /// The server records every datagram it receives and answers each one with the replies a test supplies, so a
    /// test controls both sides of an exchange without a network. It binds a system-assigned port, which keeps
    /// tests that run at the same time apart. Disposing the server closes its socket and ends its receive loop; a
    /// second dispose does nothing.
    /// </remarks>
    public sealed class UdpTestServer : IDisposable
    {
        #region *** Constants    ***
        // Bounds the wait for the receive loop to end after the socket closes, so disposing never stalls a test.
        private const int StopTimeoutMilliseconds = 2000;
        #endregion

        #region *** Fields       ***
        // Ends the receive loop when the server is disposed.
        private readonly CancellationTokenSource _cancellation = new();

        // The loopback socket the server receives on and replies from.
        private readonly UdpClient _client;

        // Supplies the replies to one request from its 1-based number and its payload.
        private readonly Func<int, byte[], IEnumerable<byte[]>> _handler;

        // The background receive loop; Dispose waits for it so no read outlives the test.
        private readonly Task _receiveTask;

        // Set once by Dispose, so a second dispose returns without touching the disposed resources.
        private bool _isDisposed;
        #endregion

        #region *** Constructors ***
        /// <summary>
        /// Initializes a new instance of the <see cref="UdpTestServer"/> class that records requests and never replies.
        /// </summary>
        public UdpTestServer()
            : this(handler: (_, _) => [])
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UdpTestServer"/> class that answers each request with the
        /// replies of a handler.
        /// </summary>
        /// <param name="handler">
        /// Receives the 1-based number of the request and its payload, and returns the replies to send to the sender.
        /// A handler that throws ends the receive loop, so the test sees missing replies.
        /// </param>
        public UdpTestServer(Func<int, byte[], IEnumerable<byte[]>> handler)
        {
            // Require the handler, because the receive loop calls it for every request.
            ArgumentNullException.ThrowIfNull(argument: handler);

            // Keep the handler that answers each request.
            _handler = handler;

            // Bind a free loopback port so the server never collides with another test.
            _client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Loopback, port: 0));
            Port = ((IPEndPoint)_client.Client.LocalEndPoint).Port;

            // Start receiving before the test sends its first datagram.
            var cancellationToken = _cancellation.Token;
            _receiveTask = Task.Run(() => ReceiveRequestsAsync(server: this, cancellationToken));
        }
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the loopback port the server listens on.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Gets the requests the server received, in arrival order, with the endpoint of each sender.
        /// </summary>
        public ConcurrentQueue<(byte[] Data, IPEndPoint RemoteEndPoint)> Requests { get; } = new();
        #endregion

        #region *** Methods      ***
        /// <inheritdoc />
        public void Dispose()
        {
            // Return on a second dispose, because the token source and the socket are already released.
            if (_isDisposed)
            {
                return;
            }

            // Mark the server disposed before releasing resources, so a second call returns at the guard.
            _isDisposed = true;

            // Stop the loop and close the socket, then wait briefly so the loop ends before the test returns.
            _cancellation.Cancel();
            _client.Dispose();
            _receiveTask.Wait(millisecondsTimeout: StopTimeoutMilliseconds);
            _cancellation.Dispose();
        }

        /// <summary>
        /// Finds a UDP port that is free on every interface at the time of the call.
        /// </summary>
        /// <remarks>
        /// The port is released before the method returns, so another process can take it before the code under
        /// test binds it; the window is short and the tests accept that risk.
        /// </remarks>
        /// <returns>The free port.</returns>
        public static int GetFreePort()
        {
            // Let the system assign a port, then release it for the code under test to bind.
            using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Any, port: 0));

            return ((IPEndPoint)client.Client.LocalEndPoint).Port;
        }

        /// <summary>
        /// Sends one datagram to a loopback port from a new socket.
        /// </summary>
        /// <param name="port">The destination port on the loopback interface.</param>
        /// <param name="data">The payload.</param>
        /// <returns>The source port the system assigned to the sending socket.</returns>
        /// <exception cref="SocketException">
        /// Thrown when the sending socket cannot be bound or the datagram cannot be sent.
        /// </exception>
        public static int SendDatagram(int port, byte[] data)
        {
            // Use a socket of its own so every call has a distinct source port.
            using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Loopback, port: 0));
            var remoteEndPoint = new IPEndPoint(address: IPAddress.Loopback, port);
            client.Send(dgram: data, bytes: data.Length, endPoint: remoteEndPoint);

            return ((IPEndPoint)client.Client.LocalEndPoint).Port;
        }

        /// <summary>
        /// Waits until the server received a number of requests.
        /// </summary>
        /// <param name="count">The number of requests to wait for.</param>
        /// <param name="timeout">The longest time to wait.</param>
        /// <returns><c>true</c> when the requests arrived in time; otherwise <c>false</c>.</returns>
        public bool WaitForRequests(int count, TimeSpan timeout)
        {
            // Poll the queue, because the loop adds requests from a background task.
            return SpinWait.SpinUntil(condition: () => Requests.Count >= count, timeout);
        }

        // Receives requests until the server is disposed, records each one, and sends the replies of the handler
        // to its sender. The loop ends on any other failure, including a handler that throws, so its task always
        // completes without an exception and the test sees the missing replies.
        private static async Task ReceiveRequestsAsync(UdpTestServer server, CancellationToken cancellationToken)
        {
            // Count requests from 1, so a handler can answer the n-th request differently.
            var number = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Record the request first, so a test sees it even when the handler sends no reply.
                    var request = await server._client.ReceiveAsync(cancellationToken);
                    server.Requests.Enqueue((request.Buffer, request.RemoteEndPoint));
                    number++;

                    // Answer the sender with every reply the test supplied for this request.
                    foreach (var reply in server._handler(number, request.Buffer))
                    {
                        var remoteEndPoint = request.RemoteEndPoint;
                        await server._client.SendAsync(datagram: reply, endPoint: remoteEndPoint, cancellationToken);
                    }
                }
                catch (SocketException exception) when (exception.SocketErrorCode == SocketError.ConnectionReset)
                {
                    // Windows reports a reply to a closed port as a reset on the next receive; keep serving.
                }
                catch (Exception)
                {
                    // The socket closed with the test, or the handler failed; end the loop.
                    break;
                }
            }
        }
        #endregion
    }
}
