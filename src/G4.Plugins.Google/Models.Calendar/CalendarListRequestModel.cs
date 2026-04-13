using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;

namespace G4.Plugins.Google.Models.Calendar
{
    /// <summary>
    /// Represents the parameters for requesting a list of calendar entries, including filtering, pagination, and
    /// synchronization options.
    /// </summary>
    /// <remarks>
    /// This model is used to specify query parameters when retrieving a list of calendar entries
    /// from the API. It allows callers to control the number of results per page, filter by minimum access role,
    /// paginate through results, include or exclude deleted and hidden entries, and perform incremental synchronization
    /// using a sync token. Some parameters have constraints or interactions: for example, 'minAccessRole' cannot be
    /// used together with 'SyncToken', and when using 'SyncToken', both 'ShowDeleted' and 'ShowHidden' must not be set
    /// to false. Refer to the API documentation for further details on supported values and behaviors.
    /// </remarks>
    internal class CalendarListRequestModel
    {
        /// <summary>
        /// Maximum number of entries returned on one result page. By default the value is 100 entries.
        /// The page size can never be larger than 250 entries.
        /// </summary>
        [Range(minimum: 1, maximum: 250)]
        [FromQuery]
        public int? MaxResults { get; set; }

        /// <summary>
        /// The minimum access role for the user in the returned entries.
        /// The default is no restriction.
        /// </summary>
        [AllowedValues("freeBusyReader", "owner", "reader", "writer")]
        [FromQuery]
        public string MinAccessRole {  get; set; }

        /// <summary>
        /// Token specifying which result page to return.
        /// </summary>
        [FromQuery]
        public string PageToken { get; set; }

        /// <summary>
        /// Whether to include deleted calendar list entries in the result.
        /// The default is False.
        /// </summary>
        [FromQuery]
        public bool? ShowDeleted { get; set; }

        /// <summary>
        /// Whether to show hidden entries.
        /// The default is False.
        /// </summary>
        [FromQuery]
        public bool? ShowHidden { get; set; }

        /// <summary>
        /// Token obtained from the nextSyncToken field returned on the last page of
        /// results from the previous list request. It makes the result of this list request
        /// contain only entries that have changed since then. If only read-only fields
        /// such as calendar properties or ACLs have changed, the entry won't be
        /// returned. All entries deleted and hidden since the previous list request will
        /// always be in the result set and it is not allowed to set showDeleted neither
        /// `showHidden` to False.
        /// To ensure client state consistency `minAccessRole` query parameter cannot
        /// be specified together with `nextSyncToken`.
        /// If the `syncToken` expires, the server will respond with a 410 GONE response
        /// code and the client should clear its storage and perform a full
        /// synchronization without any `syncToken`.
        /// The default is to return all entries.
        /// </summary>
        /// <seealso cref="https://developers.google.com/workspace/calendar/api/guides/sync"/>
        [FromQuery]
        public string SyncToken { get; set; }
    }
}
