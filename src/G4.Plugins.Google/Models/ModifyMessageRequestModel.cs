namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Represents a request to modify labels on an existing Gmail message.
    /// </summary>
    internal class ModifyMessageRequestModel
    {
        /// <summary>
        /// Gets or sets the collection of label IDs to add to the message.
        /// </summary>
        public string[] AddLabelIds { get; set; }

        /// <summary>
        /// Gets or sets the collection of label IDs to remove from the message.
        /// </summary>
        public string[] RemoveLabelIds { get; set; }
    }
}
