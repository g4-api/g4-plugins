namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents a paged response from the Google Tasks Tasks API (<c>Tasks: list</c>).
    /// Contains response metadata (kind/etag), an optional continuation token (nextPageToken) for pagination,
    /// and the collection of returned tasks (<c>items[]</c>).
    /// </summary>
    internal class TaskListResponseModel
    {
        /// <summary>
        /// ETag of the resource.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Collection of tasks.
        /// </summary>
        public TaskModel[] Items { get; set; }

        /// <summary>
        /// Type of the resource. This is always "tasks#tasks".
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Token that can be used to request the next page of this result.
        /// </summary>
        public string NextPageToken { get; set; }
    }
}
