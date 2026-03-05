using System;

namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Query parameters for listing tasks (Tasks: list).
    /// Timestamps are RFC 3339 (use UTC, e.g. 2026-03-04T10:08:34.925Z).
    /// </summary>
    internal class ListTasksQueryModel
    {
        /// <summary>
        /// Upper bound for a task's completion date (RFC 3339). Optional.
        /// </summary>
        public DateTimeOffset? CompletedMax { get; set; }

        /// <summary>
        /// Lower bound for a task's completion date (RFC 3339). Optional.
        /// </summary>
        public DateTimeOffset? CompletedMin { get; set; }

        /// <summary>
        /// Upper bound for a task's due date (RFC 3339). Optional.
        /// </summary>
        public DateTimeOffset? DueMax { get; set; }

        /// <summary>
        /// Lower bound for a task's due date (RFC 3339). Optional.
        /// </summary>
        public DateTimeOffset? DueMin { get; set; }

        /// <summary>
        /// Maximum number of tasks returned on one page. Optional.
        /// Default is 20 (max allowed: 100).
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Token specifying the result page to return. Optional.
        /// </summary>
        public string PageToken { get; set; }

        /// <summary>
        /// Whether tasks assigned to the current user are returned. Optional. Default is false.
        /// </summary>
        public bool? ShowAssigned { get; set; }

        /// <summary>
        /// Whether completed tasks are returned. Optional. Default is true.
        /// Note: showHidden must also be true to show tasks completed in first-party clients.
        /// </summary>
        public bool? ShowCompleted { get; set; }

        /// <summary>
        /// Whether deleted tasks are returned. Optional. Default is false.
        /// </summary>
        public bool? ShowDeleted { get; set; }

        /// <summary>
        /// Whether hidden tasks are returned. Optional. Default is false.
        /// </summary>
        public bool? ShowHidden { get; set; }

        /// <summary>
        /// Lower bound for a task's last modification time (RFC 3339). Optional.
        /// </summary>
        public DateTimeOffset? UpdatedMin { get; set; }
    }
}
