namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Drive file reference details associated with a task.
    /// </summary>
    internal class DriveResourceInfoModel
    {
        /// <summary>
        /// Output only. Identifier of the file in the Drive API.
        /// </summary>
        public string DriveFileId { get; set; }

        /// <summary>
        /// Output only. Resource key required to access files shared via a shared link.
        /// Not required for all files.
        /// See also: developers.google.com/drive/api/guides/resource-keys
        /// </summary>
        public string ResourceKey { get; set; }
    }
}
