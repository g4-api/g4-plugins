using System.Collections.Generic;

namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// Represents the response returned by the Gmail labels list endpoint.
    /// </summary>
    internal class ListLabelsResponseModel
    {
        /// <summary>
        /// Gets or sets the collection of labels returned by the API.
        /// </summary>
        public List<LabelModel> Labels { get; set; }
    }
}