/*
 * RESOURCES
 * - https://developers.google.com/workspace/tasks/reference/rest
 */
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models;

using System;
using System.Net.Http;
using System.Text.Json;

namespace G4.Plugins.Google.Clients
{
    internal class TaskListsClient(string credentials) : ClientBase(credentials)
    {
        /// <summary>
        /// Creates a new task list and adds it to the authenticated user's task lists.
        /// A user can have up to 2000 lists at a time.
        /// </summary>
        /// <param name="requestBody">The task list data to be added.</param>
        /// <returns>If successful, the response body contains an instance of <see cref="TaskListModel"/>.</returns>
        public TaskListModel Add(TaskListModel requestBody)
        {
            // Extract the access token from the credentials for authorization.
            var token = Credentials.AccessToken;

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists");

            // Create the HTTP request message with the appropriate method, URI, headers, and body.
            var requestMessage = NewRequest(
                HttpMethod.Post,
                requestUri,
                token,
                requestBody);

            // Return the deserialized response content as a TaskListModel instance.
            return HttpClient.Send<TaskListModel>(requestMessage);
        }

        /// <summary>
        /// Returns the authenticated user's specified task list.
        /// </summary>
        /// <param name="taskList">Task list identifier.</param>
        /// <returns>If successful, the response body contains an instance of <see cref="TaskListModel"/>.</returns>
        public TaskListModel Get(string taskList)
        {
            // Extract the access token from the credentials for authorization.
            var token = Credentials.AccessToken;

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists/{taskList}");

            // Create the HTTP request message with the appropriate method, URI, and headers.
            var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

            // Return the deserialized response content as a TaskListModel instance.
            return HttpClient.Send<TaskListModel>(requestMessage);
        }

        /// <summary>
        /// Returns all the authenticated user's task lists.
        /// A user can have up to 2000 lists at a time.
        /// </summary>
        /// <param name="options">The options for listing task lists.</param>
        /// <returns>If successful, the response body contains an instance of <see cref="TaskListsListResponseModel"/>.</returns>
        public TaskListsListResponseModel Get(ListTaskListsQueryModel options)
        {
            // Extract the access token from the credentials for authorization.
            var token = Credentials.AccessToken;

            // Convert the query options to a query string format for the request URI.
            var queryParameters = options.ConvertToQueryParameters();

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists{queryParameters}");

            // Create the HTTP request message with the appropriate method, URI, and headers.
            var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

            // Return the deserialized response content as a TaskListsListResponseModel instance.
            return HttpClient.Send<TaskListsListResponseModel>(requestMessage);
        }

        /// <summary>
        /// Deletes the authenticated user's specified task list. If the list contains assigned tasks,
        /// both the assigned tasks and the original tasks in the assignment surface (Docs, Chat Spaces) are deleted.
        /// </summary>
        /// <param name="taskList">Task list identifier.</param>
        /// <returns>If successful, the response body is empty.</returns>
        public JsonElement Remove(string taskList)
        {
            // Extract the access token from the credentials for authorization.
            var token = Credentials.AccessToken;

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists/{taskList}");

            // Create the HTTP request message with the appropriate method, URI, and headers.
            var requestMessage = NewRequest(HttpMethod.Delete, requestUri, token);

            // Return the deserialized response content as a JsonElement instance.
            return HttpClient.Send<JsonElement>(requestMessage);
        }

        /// <summary>
        /// Updates the authenticated user's specified task list. This method supports patch semantics.
        /// </summary>
        /// <param name="taskList">Task list identifier.</param>
        /// <param name="requestBody">The task list data to be updated.</param>
        /// <returns>If successful, the response body contains an instance of <see cref="TaskListModel"/>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public JsonElement Update(string taskList, TaskListModel requestBody)
        {
            // Extract the access token from the credentials for authorization.
            var token = Credentials.AccessToken;

            // Define the Google Tasks API endpoint for creating a new task list.
            var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists/{taskList}");

            // Create the HTTP request message with the appropriate method, URI, headers, and body.
            var requestMessage = NewRequest(
                HttpMethod.Post,
                requestUri,
                token,
                requestBody);

            // Return the deserialized response content as a JsonElement instance.
            return HttpClient.Send<JsonElement>(requestMessage);
        }
    }
}
