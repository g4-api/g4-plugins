using Microsoft.AspNetCore.Mvc;

namespace G4.Plugins.Google.Models.Tasks
{
    /// <summary>
    /// Query parameters for listing task lists (TaskLists: list).
    /// </summary>
    internal class ListTaskListsRequestModel
    {
        /// <summary>
        /// Maximum number of task lists returned on one page. Optional.
        /// Default is 1000 (max allowed: 1000).
        /// </summary>
        [FromQuery]
        public int MaxResults { get; set; }

        /// <summary>
        /// Token specifying the result page to return. Optional.
        /// </summary>
        [FromQuery]
        public string PageToken { get; set; }
    }
}
