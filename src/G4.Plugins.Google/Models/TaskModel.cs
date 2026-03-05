using System;
using System.Collections.Generic;

namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents a Google Tasks resource returned by the Tasks API.
    /// </summary>
    internal class TaskModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Output only. Context information for assigned tasks.
        /// Populated for tasks assigned to the current user. This field is read-only.
        /// </summary>
        public AssignmentInfoModel AssignmentInfo { get; set; }

        /// <summary>
        /// Completion date of the task (RFC 3339). Omitted if not completed.
        /// </summary>
        public DateTimeOffset? Completed { get; set; }

        /// <summary>
        /// Flag indicating whether the task has been deleted. Default is false.
        /// For assigned tasks this field is read-only.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Scheduled date for the task (RFC 3339). Optional.
        /// Note: only date information is recorded; time is discarded when setting this field.
        /// </summary>
        public DateTimeOffset? Due { get; set; }

        /// <summary>
        /// ETag of the resource.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Flag indicating whether the task is hidden. Default is false. Output only / read-only.
        /// </summary>
        public bool? Hidden { get; set; }

        /// <summary>
        /// Task identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Output only. Type of the resource. This is always "tasks#task".
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Output only. Collection of links. Read-only.
        /// </summary>
        public List<TaskLinkModel> Links { get; set; }

        /// <summary>
        /// Notes describing the task. Optional. Max length: 8192.
        /// Tasks assigned from Google Docs cannot have notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Output only. Parent task identifier. Omitted if top-level. Read-only.
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Output only. Position of the task among siblings/top-level. Read-only.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Output only. URL pointing to this task. Used to retrieve, update, or delete this task.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// Status of the task. Either "needsAction" or "completed".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Title of the task. Max length: 1024.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Output only. Last modification time (RFC 3339).
        /// </summary>
        public DateTimeOffset? Updated { get; set; }

        /// <summary>
        /// Output only. Absolute link to the task in the Google Tasks Web UI.
        /// </summary>
        public string WebViewLink { get; set; }
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// Represents a read-only link entry attached to a Google Tasks task.
        /// </summary>
        public sealed class TaskLinkModel
        {
            /// <summary>
            /// The description (might be empty).
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The URL.
            /// </summary>
            public string Link { get; set; }

            /// <summary>
            /// Type of the link, e.g. "email", "generic", "chat_message", "keep_note".
            /// </summary>
            public string Type { get; set; }
        }
        #endregion
    }
}
