using System;

namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents a Google Tasks <c>TaskList</c> resource returned by the TaskLists API.
    /// Includes identifying and display fields (id/title), the resource version tag (etag),
    /// and read-only metadata provided by the service (kind/updated/selfLink) for navigation
    /// and concurrency scenarios.
    /// </summary>
    internal class TaskListModel
    {
        /// <summary>
        /// ETag of the resource.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Task list identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Output only. Type of the resource. This is always "tasks#taskList".
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Output only. URL pointing to this task list. Used to retrieve, update, or delete this task list.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// Title of the task list. Max length: 1024.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Output only. Last modification time of the task list (RFC 3339).
        /// </summary>
        public DateTimeOffset? Updated { get; set; }
    }
}
