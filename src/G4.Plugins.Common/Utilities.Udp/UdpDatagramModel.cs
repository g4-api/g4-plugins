using System;

namespace G4.Plugins.Common.Utilities.Udp
{
    /// <summary>
    /// Represents one datagram a UDP listener received, with the sender and arrival details a flow reports.
    /// </summary>
    /// <remarks>
    /// The receive loop of <see cref="UdpListener"/> creates one instance per datagram and never changes it afterwards,
    /// so a step can read it without a lock once the listener hands it over. The model carries only the values the
    /// UDP plugins publish; socket-level details such as the receiving interface are not modeled.
    /// </remarks>
    internal sealed class UdpDatagramModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets the payload exactly as it arrived.
        /// </summary>
        /// <remarks>
        /// The bytes are never decoded here, because the step that reads the datagram selects the text encoding and
        /// the output format.
        /// </remarks>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the UTC time the listener took the datagram from the socket.
        /// </summary>
        public DateTime ReceivedAt { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the sender.
        /// </summary>
        public string RemoteAddress { get; set; }

        /// <summary>
        /// Gets or sets the port of the sender, which a flow uses as the destination of a reply.
        /// </summary>
        public int RemotePort { get; set; }

        /// <summary>
        /// Gets or sets the arrival number of the datagram within its listener, starting at 1.
        /// </summary>
        /// <remarks>
        /// A step that sends a request through a shared listener keeps the number of the last datagram before the
        /// send, and then accepts only higher numbers as replies.
        /// </remarks>
        public long Sequence { get; set; }
        #endregion
    }
}
