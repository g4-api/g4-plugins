namespace G4.Plugins.Google.Models
{
    /// <summary>
    /// Information about the Chat Space where a task was assigned from.
    /// </summary>
    internal class SpaceInfoModel
    {
        /// <summary>
        /// Output only. The Chat space where this task originates from.
        /// Format: "spaces/{space}".
        /// </summary>
        public string Space { get; set; }
    }
}
