using G4.Credentials;
using G4.Credentials.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace G4.Plugins.Google.Clients
{
    internal class GoogleAdapter(string credentials)
    {
        /// <summary>
        /// Represents the ISO 8601 date and time format string with milliseconds and a UTC designator.
        /// </summary>
        public const string Iso = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public TasksClient Tasks { get; } = new(credentials);

        public TaskListsClient TaskLists { get; } = new(credentials);
    }
}
