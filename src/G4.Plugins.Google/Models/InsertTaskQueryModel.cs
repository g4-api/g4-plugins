using Microsoft.AspNetCore.Mvc;

namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Parameters for inserting a task (Tasks: insert), controlling initial placement
    /// in the hierarchy (parent) and ordering among siblings (previous).
    /// </summary>
    internal class InsertTaskQueryModel
    {
        /// <summary>
        /// Parent task identifier.
        /// If creating at the top level, omit (null).
        /// An assigned task cannot be a parent task, nor can it have a parent.
        /// Setting the parent to an assigned task results in failure of the request. Optional.
        /// </summary>
        [FromQuery]
        public string Parent { get; set; }

        /// <summary>
        /// Previous sibling task identifier.
        /// If creating at the first position among its siblings, omit (null). Optional.
        /// </summary>
        [FromQuery]
        public string Previous { get; set; }
    }
}
