namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents a Gmail label resource.
    /// </summary>
    internal sealed class LabelModel
    {
        /// <summary>
        /// The color settings for the label.
        /// </summary>
        public LabelColorModel Color { get; set; }

        /// <summary>
        /// The immutable ID of the label.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Visibility of the label in the label list in the Gmail web interface.
        /// </summary>
        public string LabelListVisibility { get; set; }

        /// <summary>
        /// Visibility of messages with this label in the Gmail message list.
        /// </summary>
        public string MessageListVisibility { get; set; }

        /// <summary>
        /// The display name of the label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The total number of messages with this label.
        /// </summary>
        public int MessagesTotal { get; set; }

        /// <summary>
        /// The number of unread messages with this label.
        /// </summary>
        public int MessagesUnread { get; set; }

        /// <summary>
        /// The total number of threads with this label.
        /// </summary>
        public int ThreadsTotal { get; set; }

        /// <summary>
        /// The number of unread threads with this label.
        /// </summary>
        public int ThreadsUnread { get; set; }

        /// <summary>
        /// The type of label, typically SYSTEM or USER.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Represents the color object of a Gmail label.
        /// </summary>
        internal sealed class LabelColorModel
        {
            /// <summary>
            /// The background color of the label, as a hex string.
            /// </summary>
            public string BackgroundColor { get; set; }

            /// <summary>
            /// The text color of the label, as a hex string.
            /// </summary>
            public string TextColor { get; set; }
        }
    }
}
