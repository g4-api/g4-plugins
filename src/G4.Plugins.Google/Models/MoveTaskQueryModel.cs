namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Query parameters for moving a task (Tasks: move).
    /// </summary>
    internal class MoveTaskQueryModel
    {
        /// <summary>
        /// Optional. Destination task list identifier.
        /// If set, the task is moved from its current list to this destination list.
        /// Note: Recurrent (repeating) tasks cannot currently be moved between lists.
        /// </summary>
        public string DestinationTasklist { get; set; }

        /// <summary>
        /// Optional. New parent task identifier.
        /// If moving to top level, omit (null).
        /// Parent must exist in the task list and cannot be hidden.
        /// Exceptions:
        /// 1) Assigned and repeating tasks cannot be parent tasks (have subtasks) and cannot be moved under a parent (become subtasks).
        /// 2) Tasks that are both completed and hidden cannot be nested; parent must be empty.
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Optional. New previous sibling task identifier.
        /// If moving to first position among siblings, omit (null).
        /// Previous must exist in the task list and cannot be hidden.
        /// Exception:
        /// Tasks that are both completed and hidden can only be moved to position 0; previous must be empty.
        /// </summary>
        public string Previous { get; set; }
    }
}
