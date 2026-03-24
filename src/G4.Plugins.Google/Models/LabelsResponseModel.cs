namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents the response returned by the Gmail labels list endpoint.
    /// </summary>
    internal class LabelsResponseModel
    {
        /// <summary>
        /// Gets or sets the collection of labels returned by the API.
        /// </summary>
        public LabelModel[] Labels { get; set; }
    }
}