using G4.Plugins.Google.Models;

/// <summary>
/// Represents a paged collection of Gmail messages returned by the Gmail API.
/// </summary>
/// <remarks>
/// This model corresponds to the response returned by:
/// <c>GET https://gmail.googleapis.com/gmail/v1/users/{userId}/messages</c>.
/// </remarks>
internal class MessageListModel
{
    /// <summary>
    /// Collection of messages returned in the current page.
    /// </summary>
    /// <remarks>
    /// Each item typically contains minimal metadata (such as the message id and thread id).
    /// Additional message details can be retrieved using the message id with the
    /// Gmail <c>messages.get</c> endpoint.
    /// </remarks>
    public MessageModel[] Messages { get; set; }

    /// <summary>
    /// Token used to retrieve the next page of results.
    /// </summary>
    /// <remarks>
    /// When present, this value should be supplied as the <c>pageToken</c>
    /// query parameter in the next request.
    /// </remarks>
    public string NextPageToken { get; set; }

    /// <summary>
    /// Estimated total number of messages matching the query.
    /// </summary>
    /// <remarks>
    /// This value is an estimate provided by the Gmail API and may not always
    /// reflect the exact number of messages available.
    /// </remarks>
    public int ResultSizeEstimate { get; set; }
}