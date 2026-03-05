/*
 * RESOURCES
 * - https://developers.google.com/workspace/tasks/reference/rest
 */
using G4.Plugins.Google.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace G4.Plugins.Google.Clients
{
    internal class TasksClient(string credentials) : ClientBase(credentials)
    {
        public JsonElement Add(string taskList, string parent, string previous, TaskModel data)
        {
            throw new NotImplementedException();
        }

        public JsonElement Clear(string taskList)
        {
            throw new NotImplementedException();
        }

        public JsonElement Get(string taskList, string task)
        {
            throw new NotImplementedException();
        }

        public JsonElement Get(string taskList, ListTasksQueryModel options)
        {
            throw new NotImplementedException();
        }

        public JsonElement Move(string taskList, string task, MoveTaskQueryModel options)
        {
            throw new NotImplementedException();
        }

        public JsonElement Remove(string taskList, string task)
        {
            throw new NotImplementedException();
        }

        public JsonElement Update(string taskList, string task, TaskModel data)
        {
            throw new NotImplementedException();
        }
    }
}
