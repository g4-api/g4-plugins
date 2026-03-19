using Microsoft.AspNetCore.Mvc;

namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents query parameters used when listing Gmail messages.
    /// </summary>
    internal class MessageListQueryModel
    {
        /// <summary>
        /// Indicates whether messages in Spam and Trash should be included.
        /// </summary>
        /// <remarks>
        /// When set to <c>true</c>, messages from the Spam and Trash folders
        /// are included in the results.
        /// </remarks>
        [FromQuery]
        public bool IncludeSpamTrash { get; set; }

        /// <summary>
        /// Restricts the returned messages to those with the specified label identifiers.
        /// </summary>
        /// <remarks>
        /// Multiple labels can be supplied. Only messages containing all specified
        /// labels will be returned.
        /// </remarks>
        [FromQuery]
        public string[] LabelIds { get; set; }

        /// <summary>
        /// Maximum number of messages to return in a single response page.
        /// </summary>
        /// <remarks>The Gmail API typically allows up to 500 messages per page.</remarks>
        [FromQuery]
        public int MaxResults { get; set; }

        /// <summary>
        /// Token specifying which result page to return.
        /// </summary>
        /// <remarks>
        /// This value is obtained from the <c>nextPageToken</c> field
        /// of a previous response.
        /// </remarks>
        [FromQuery]
        public string PageToken { get; set; }

        /// <summary>
        /// Gmail search query used to filter messages.
        /// </summary>
        /// <remarks>
        /// Supports the same search syntax used in the Gmail web interface
        /// (for example: <c>from:someone subject:invoice newer_than:7d</c>).
        /// </remarks>
        [FromQuery]
        public string Q { get; set; }
    }
}
