using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Tasks;

using System;
using System.Net.Http;

namespace G4.Plugins.Google.Clients
{
    /// <summary>
    /// Provides authenticated access to Google Tasks and TaskLists APIs for managing tasks and task lists on behalf of
    /// a user.
    /// </summary>
    /// <param name="credentials">The credentials used to authenticate requests to the Google Tasks API. Must not be null or empty.</param>
    internal class TasksAdapter(string credentials)
    {
        #region *** Fields       ***
        // Store the credentials in a private readonly field to be used by the nested clients.
        private readonly string _credentials = credentials;
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets an authenticated TaskLists client instance for accessing Google TaskLists APIs.
        /// </summary>
        public TaskListsClient TaskLists => new(_credentials);

        /// <summary>
        /// Gets an authenticated Tasks client instance for accessing Google Tasks APIs.
        /// </summary>
        public TasksClient Tasks => new(_credentials);
        #endregion

        #region *** Nested Types ***
        /// <summary>
        /// Provides methods for managing tasks in Google Tasks lists using the Google Tasks API.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate requests to the Google Tasks API. Must not be null or empty.</param>
        public class TasksClient(string credentials) : ClientBase(credentials)
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
            public TaskModel Add(string taskList, TaskModel requestBody, AddTaskRequestModel options)
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
            /// <returns>A <see cref="TasksModel"/> containing the tasks returned by the Google Tasks API.</returns>
            public TasksModel Get(string taskList, ListTasksRequestModel options)
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
                return HttpClient.Send<TasksModel>(requestMessage);
            }

            /// <summary>
            /// Moves a task to a different position or destination list.
            /// </summary>
            /// <param name="taskList">The identifier of the source task list containing the task.</param>
            /// <param name="task">The identifier of the task to move.</param>
            /// <param name="options">Query parameters controlling the move operation (for example destination list or previous task).</param>
            /// <returns>A <see cref="TaskModel"/> representing the moved task returned by the Google Tasks API.</returns>
            public TaskModel Move(string taskList, string task, MoveTaskRequestModel options)
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

        /// <summary>
        /// Provides methods for managing task lists for the authenticated user using the Google Tasks API.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate requests to the Google Tasks API. Cannot be null or empty.</param>
        public class TaskListsClient(string credentials) : ClientBase(credentials)
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
            /// Retrieves the list of task lists for the authenticated user from the Google Tasks API.
            /// </summary>
            /// <returns>A <see cref="TaskListsModel"/> containing the user's task lists. The response will be empty if no task lists are found.</returns>
            public TaskListsModel Get()
            {
                // Extract the access token from the credentials for authorization.
                var token = Credentials.AccessToken;

                // Define the Google Tasks API endpoint for creating a new task list.
                var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists");

                // Create the HTTP request message with the appropriate method, URI, and headers.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Return the deserialized response content as a TaskListModel instance.
                return HttpClient.Send<TaskListsModel>(requestMessage);
            }

            /// <summary>
            /// Returns all the authenticated user's task lists.
            /// A user can have up to 2000 lists at a time.
            /// </summary>
            /// <param name="options">The options for listing task lists.</param>
            /// <returns>If successful, the response body contains an instance of <see cref="TaskListsModel"/>.</returns>
            public TaskListsModel Get(ListTaskListsRequestModel options)
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
                return HttpClient.Send<TaskListsModel>(requestMessage);
            }

            /// <summary>
            /// Deletes the authenticated user's specified task list. If the list contains assigned tasks,
            /// both the assigned tasks and the original tasks in the assignment surface (Docs, Chat Spaces) are deleted.
            /// </summary>
            /// <param name="taskList">Task list identifier.</param>
            /// <returns>If successful, the response body is empty.</returns>
            public HttpResponseMessage Remove(string taskList)
            {
                // Extract the access token from the credentials for authorization.
                var token = Credentials.AccessToken;

                // Define the Google Tasks API endpoint for creating a new task list.
                var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists/{taskList}");

                // Create the HTTP request message with the appropriate method, URI, and headers.
                var requestMessage = NewRequest(HttpMethod.Delete, requestUri, token);

                // Send the request and return the raw HTTP response message
                // for successful request (204 No Content).
                return HttpClient.ConfirmResponse(requestMessage);
            }

            /// <summary>
            /// Updates the authenticated user's specified task list. This method supports patch semantics.
            /// </summary>
            /// <param name="taskList">Task list identifier.</param>
            /// <param name="requestBody">The task list data to be updated.</param>
            /// <returns>If successful, the response body contains an instance of <see cref="TaskListModel"/>.</returns>
            public TaskListModel Update(string taskList, TaskListModel requestBody)
            {
                // Extract the access token from the credentials for authorization.
                var token = Credentials.AccessToken;

                // Define the Google Tasks API endpoint for creating a new task list.
                var requestUri = new Uri(uriString: $"{TasksBaseUri}/users/@me/lists/{taskList}");

                // Create the HTTP request message with the appropriate method, URI, headers, and body.
                var requestMessage = NewRequest(
                    HttpMethod.Patch,
                    requestUri,
                    token,
                    requestBody);

                // Return the deserialized response content as a TaskListModel instance.
                return HttpClient.Send<TaskListModel>(requestMessage);
            }
        }
        #endregion
    }
}
