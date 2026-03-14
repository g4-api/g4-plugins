namespace G4.Plugins.Google.Clients
{
    internal class GoogleAdapter(string credentials)
    {
        /// <summary>
        /// Represents the ISO 8601 date and time format string with milliseconds and a UTC designator.
        /// </summary>
        public const string Iso = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public GmailClient Gmail { get; } = new(credentials);

        public TaskListsClient TaskLists { get; } = new(credentials);
        public TasksClient Tasks { get; } = new(credentials);
    }
}
