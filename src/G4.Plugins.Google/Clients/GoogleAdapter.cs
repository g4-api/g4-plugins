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
        public TasksClient Tasks { get; } = new(credentials);

        public TaskListsClient TaskLists { get; } = new(credentials);
    }
}
