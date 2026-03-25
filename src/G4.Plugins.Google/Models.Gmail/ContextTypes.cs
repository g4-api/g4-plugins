namespace G4.Plugins.Google.Models.Gmail
{
    /// <summary>
    /// The product associated with the task.
    /// String values match the API enum strings.
    /// </summary>
    internal static class ContextTypes
    {
        /// <summary>
        /// Unknown value for this task's context.
        /// </summary>
        public const string ContextTypeUnspecified = "CONTEXT_TYPE_UNSPECIFIED";

        /// <summary>
        /// The task is assigned from a document.
        /// </summary>
        public const string Document = "DOCUMENT";

        /// <summary>
        /// The task is created from Gmail.
        /// </summary>
        public const string Gmail = "GMAIL";

        /// <summary>
        /// The task is assigned from a Chat Space.
        /// </summary>
        public const string Space = "SPACE";
    }
}
