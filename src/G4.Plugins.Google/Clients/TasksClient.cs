/*
 * RESOURCES
 * - https://developers.google.com/workspace/tasks/reference/rest
 */
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models;

using System;
using System.Net.Http;

namespace G4.Plugins.Google.Clients
{
    internal class TasksClient(string credentials) : ClientBase(credentials)
    {
        /// <summary>
        /// Creates a new task in the specified Google Tasks list.
        /// </summary>
        /// <param name="taskList">The identifier of the task list where the task will be created.</param>
        /// <param name="requestBody">A <see cref="TaskModel"/> containing the task fields to create.</param>
        /// <returns>A <see cref="TaskModel"/> representing the task returned by the Google Tasks API.</returns>
        public TaskModel Add(string taskList, TaskModel requestBody)
        {
            return Add(taskList, requestBody, options: default);
        }

        /// <summary>
        /// Creates a new task in the specified Google Tasks list with optional query parameters.
        /// </summary>
        /// <param name="taskList">The identifier of the task list where the task will be created.</param>
        /// <param name="requestBody">A <see cref="TaskModel"/> containing the task fields to create.</param>
        /// <param name="options">Optional query parameters controlling the insert operation (for example destination position or parent task).</param>
        /// <returns>A <see cref="TaskModel"/> representing the created task returned by the Google Tasks API.</returns>
        public TaskModel Add(string taskList, TaskModel requestBody, InsertTaskQueryModel options)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Convert optional insert parameters into URL query parameters.
            var queryParameters = options?.ConvertToQueryParameters();

            // Build the endpoint URI for creating a new task.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks{queryParameters}";
            var requestUri = new Uri(uriString);

            // Create the HTTP POST request with the JSON payload and authorization header.
            var requestMessage = NewRequest(HttpMethod.Post, requestUri, token, requestBody);

            // Send the request and deserialize the JSON response into TaskModel.
            return HttpClient.Send<TaskModel>(requestMessage);
        }

        /// <summary>
        /// Clears all completed tasks from the specified Google Tasks list.
        /// </summary>
        /// <param name="taskList">Task list identifier to clear completed tasks from.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> returned by the API. The caller is responsible for disposing the response.</returns>
        public HttpResponseMessage Clear(string taskList)
        {
            // Access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Build the endpoint URI for clearing completed tasks from the list.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks/clear";
            var requestUri = new Uri(uriString);

            // The Google Tasks "clear" operation is a POST with no request body.
            var requestMessage = NewRequest(HttpMethod.Post, requestUri, token);

            // Send the request. The API commonly returns 204 No Content on success.
            return HttpClient.ConfirmResponse(requestMessage);
        }

        /// <summary>
        /// Retrieves a specific task from a Google Tasks list.
        /// </summary>
        /// <param name="taskList">The identifier of the task list that contains the task.</param>
        /// <param name="task">The identifier of the task to retrieve.</param>
        /// <returns>A <see cref="TaskModel"/> representing the task returned by the Google Tasks API.</returns>
        public TaskModel Get(string taskList, string task)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Build the endpoint URI for retrieving the specified task.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks/{task}";
            var requestUri = new Uri(uriString);

            // Create the HTTP GET request with the authorization header.
            var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

            // Send the request and deserialize the JSON response into TaskModel.
            return HttpClient.Send<TaskModel>(requestMessage);
        }

        /// <summary>
        /// Retrieves tasks from a specific Google Tasks list.
        /// </summary>
        /// <param name="taskList">The identifier of the task list from which tasks should be retrieved.</param>
        /// <param name="options">Optional query parameters used to filter or control the returned task collection.</param>
        /// <returns>A <see cref="TaskListResponseModel"/> containing the tasks returned by the Google Tasks API.</returns>
        public TaskListResponseModel Get(string taskList, ListTasksQueryModel options)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Convert the query model into URL query parameters (e.g. "?maxResults=100").
            var queryParameters = options?.ConvertToQueryParameters();

            // Build the full endpoint URI for retrieving tasks from the specified list.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks{queryParameters}";
            var requestUri = new Uri(uriString);

            // Create the HTTP GET request with authorization headers.
            var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

            // Send the request and deserialize the JSON response into TaskListResponseModel.
            return HttpClient.Send<TaskListResponseModel>(requestMessage);
        }

        /// <summary>
        /// Moves a task to a different position or destination list.
        /// </summary>
        /// <param name="taskList">The identifier of the source task list containing the task.</param>
        /// <param name="task">The identifier of the task to move.</param>
        /// <param name="options">Query parameters controlling the move operation (for example destination list or previous task).</param>
        /// <returns>A <see cref="TaskModel"/> representing the moved task returned by the Google Tasks API.</returns>
        public TaskModel Move(string taskList, string task, MoveTaskQueryModel options)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Convert the query model into URL query parameters (e.g. "?destination=xyz&previous=abc").
            var queryParameters = options?.ConvertToQueryParameters();

            // Build the endpoint URI for moving the specified task.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks/{task}/move{queryParameters}";
            var requestUri = new Uri(uriString);

            // Create the HTTP POST request with the authorization header.
            var requestMessage = NewRequest(HttpMethod.Post, requestUri, token);

            // Send the request and deserialize the JSON response into TaskModel.
            return HttpClient.Send<TaskModel>(requestMessage);
        }

        /// <summary>
        /// Deletes a specific task from a Google Tasks list.
        /// </summary>
        /// <param name="taskList">The identifier of the task list that contains the task.</param>
        /// <param name="task">The identifier of the task to delete.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> returned by the Google Tasks API.</returns>
        public HttpResponseMessage Remove(string taskList, string task)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Build the endpoint URI for deleting the specified task.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks/{task}";
            var requestUri = new Uri(uriString);

            // Create the HTTP DELETE request with the authorization header.
            var requestMessage = NewRequest(HttpMethod.Delete, requestUri, token);

            // Send the request and return the HTTP response.
            return HttpClient.ConfirmResponse(requestMessage);
        }

        /// <summary>
        /// Updates an existing task in a Google Tasks list.
        /// </summary>
        /// <param name="taskList">The identifier of the task list containing the task.</param>
        /// <param name="task">The identifier of the task to update.</param>
        /// <param name="requestBody">A <see cref="TaskModel"/> containing the updated task fields. Only provided properties are applied by the Google Tasks API.</param>
        /// <returns>A <see cref="TaskModel"/> representing the updated task returned by the Google Tasks API.</returns>
        public TaskModel Update(string taskList, string task, TaskModel requestBody)
        {
            // Extract the OAuth access token used to authorize the request.
            var token = Credentials.AccessToken;

            // Build the endpoint URI for updating the specified task.
            var uriString = $"{TasksBaseUri}/lists/{taskList}/tasks/{task}";
            var requestUri = new Uri(uriString);

            // Create the HTTP PATCH request with the JSON payload and authorization header.
            var requestMessage = NewRequest(HttpMethod.Patch, requestUri, token, requestBody);

            // Send the request and deserialize the JSON response into TaskModel.
            return HttpClient.Send<TaskModel>(requestMessage);
        }
    }
}
