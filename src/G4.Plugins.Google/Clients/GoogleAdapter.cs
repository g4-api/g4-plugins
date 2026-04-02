namespace G4.Plugins.Google.Clients
{
    /// <summary>
    /// Provides authenticated access to Google APIs using the specified credentials.
    /// </summary>
    /// <param name="credentials">The credentials (token or stored credentials name) used to authenticate requests to Google APIs.</param>
    internal class GoogleAdapter(string credentials)
    {
        #region *** Constants  ***
        /// <summary>
        /// Represents the ISO 8601 date and time format string with milliseconds and a UTC designator.
        /// </summary>
        public const string Iso = "yyyy-MM-ddTHH:mm:ss.fffZ";
        #endregion

        #region *** Properties ***
        /// <summary>
        /// Gets an authenticated Gmail client instance for accessing Gmail APIs.
        /// </summary>
        public GmailAdapter Gmail => new(credentials);
        
        /// <summary>
        /// Gets an authenticated Tasks client instance for accessing Google Tasks APIs.
        /// </summary>
        public TasksAdapter Tasks => new(credentials);
        #endregion
    }
}
