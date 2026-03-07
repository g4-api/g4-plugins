using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace G4.Plugins.Google.Extensions
{
    internal static class LocalExtensions
    {
        // Default JSON serialization settings used when sending requests
        // or serializing payloads for Google APIs. 
        private static readonly JsonSerializerOptions s_jsonOptions = new()
        {
            // Do not include properties with null values in serialized JSON.
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,

            // Convert C# property names (PascalCase) to camelCase for JSON.
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            // Use relaxed escaping to allow special characters in JSON without being escaped.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        extension(GoogleAdapter adapter)
        {
            /// <summary>
            /// Exports all tasks from the specified task list.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <returns>A sequence of <see cref="TaskModel"/> items returned from the resolved task list.</returns>
            public IEnumerable<TaskModel> ExportTasks(string taskListIdOrName)
            {
                return adapter.ExportTasks(
                    taskListIdOrName,
                    timeout: TimeSpan.FromSeconds(30));
            }

            /// <summary>
            /// Exports all tasks from the specified task list.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <param name="timeout">Maximum amount of time allowed for paging through the task list while exporting tasks.</param>
            /// <returns>A sequence of <see cref="TaskModel"/> items returned from the resolved task list.</returns>
            public IEnumerable<TaskModel> ExportTasks(string taskListIdOrName, TimeSpan timeout)
            {
                // Resolve the task list id from either the list id or list title.
                var taskListId = adapter
                    .TaskLists
                    .Get()
                    .Items
                    .FirstOrDefault(i =>
                        string.Equals(i.Id, taskListIdOrName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(i.Title, taskListIdOrName, StringComparison.OrdinalIgnoreCase))?
                    .Id;

                // Treat a missing list id as a hard failure to avoid sending invalid requests.
                if (string.IsNullOrWhiteSpace(taskListId))
                {
                    throw new InvalidOperationException(
                        message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
                }

                // Iterate through task pages until all tasks are collected or the timeout expires.
                var nextPageToken = string.Empty;
                var taskModels = new List<TaskModel>();
                var expired = DateTime.UtcNow.Add(timeout);

                do
                {
                    // Build paging options for the current request.
                    var options = string.IsNullOrEmpty(nextPageToken)
                        ? new ListTasksQueryModel { MaxResults = 100 }
                        : new ListTasksQueryModel { MaxResults = 100, PageToken = nextPageToken };

                    // Retrieve the current page of tasks from the resolved list.
                    var tasksPage = adapter.Tasks.Get(taskListId, options);

                    // Read the tasks returned in the current page.
                    var tasks = tasksPage.Items;

                    // Stop when the current page does not contain any tasks.
                    if (tasks == null || tasks.Length == 0)
                    {
                        break;
                    }

                    // Add the current page of tasks to the overall result set.
                    taskModels.AddRange(tasks);

                    // Move to the next page, if available.
                    nextPageToken = tasksPage.NextPageToken;
                }
                while (!string.IsNullOrWhiteSpace(nextPageToken) && DateTime.UtcNow < expired);

                // Return all collected tasks.
                return taskModels;
            }

            /// <summary>
            /// Finds a task by task id or title within the specified task list.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <param name="taskIdOrName">Task identifier or task title used to locate the target task.</param>
            /// <returns> matching <see cref="TaskModel"/>.</returns>
            /// <remarks>Uses a default timeout of 30 seconds while paging through the task list.</remarks>
            public TaskModel FindTask(string taskListIdOrName, string taskIdOrName)
            {
                return adapter.FindTask(
                    taskListIdOrName,
                    taskIdOrName,
                    timeout: TimeSpan.FromSeconds(30));
            }

            /// <summary>
            /// Finds a task by task id or title within the specified task list.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <param name="taskIdOrName">Task identifier or task title used to locate the target task.</param>
            /// <param name="timeout">Maximum amount of time allowed for paging through the task list while searching.</param>
            /// <returns>The matching <see cref="TaskModel"/>.</returns>
            /// <exception cref="InvalidOperationException">Thrown when the task list cannot be found or when no matching task is found before the timeout expires.</exception>
            public TaskModel FindTask(string taskListIdOrName, string taskIdOrName, TimeSpan timeout)
            {
                // Resolve the task list id from either the list id or list title.
                var taskListId = adapter
                    .TaskLists
                    .Get()
                    .Items
                    .FirstOrDefault(i =>
                        string.Equals(i.Id, taskListIdOrName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(i.Title, taskListIdOrName, StringComparison.OrdinalIgnoreCase))?
                    .Id;

                // Treat a missing list id as a hard failure to avoid sending invalid requests.
                if (string.IsNullOrWhiteSpace(taskListId))
                {
                    throw new InvalidOperationException(
                        message: $"No matching task list found for title or ID: '{taskListIdOrName}'.");
                }

                // Iterate through task pages until a match is found or the timeout expires.
                var nextPageToken = string.Empty;
                TaskModel taskModel = null;
                var expired = DateTime.UtcNow.Add(timeout);

                do
                {
                    // Build paging options for the current request.
                    var options = string.IsNullOrEmpty(nextPageToken)
                        ? new ListTasksQueryModel { MaxResults = 100 }
                        : new ListTasksQueryModel { MaxResults = 100, PageToken = nextPageToken };

                    // Retrieve the current page of tasks from the resolved list.
                    var tasksPage = adapter.Tasks.Get(taskListId, options);

                    // Search the current page by task id or task title.
                    var task = tasksPage.Items
                        .FirstOrDefault(i =>
                            string.Equals(i.Id, taskIdOrName, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(i.Title, taskIdOrName, StringComparison.OrdinalIgnoreCase));

                    // Stop as soon as a matching task is found.
                    if (!string.IsNullOrWhiteSpace(task?.Id))
                    {
                        taskModel = task;
                        break;
                    }

                    // Move to the next page, if available.
                    nextPageToken = tasksPage.NextPageToken;
                }
                while (!string.IsNullOrWhiteSpace(nextPageToken) && DateTime.UtcNow < expired);

                // Treat a missing task as a hard failure so callers do not continue with an invalid result.
                if (taskModel == null)
                {
                    throw new InvalidOperationException(
                        message: $"No matching task found for title or ID: '{taskIdOrName}' in list '{taskListIdOrName}'.");
                }

                // Return the matched task.
                return taskModel;
            }

            /// <summary>
            /// Finds a task list by task list id or title.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <returns>The matching <see cref="TaskListModel"/>.</returns>
            /// <remarks>Uses a default timeout of 30 seconds while paging through task lists.</remarks>
            public TaskListModel FindTaskList(string taskListIdOrName)
            {
                return adapter.FindTaskList(
                    taskListIdOrName,
                    timeout: TimeSpan.FromSeconds(30));
            }

            /// <summary>
            /// Finds a task list by task list id or title.
            /// </summary>
            /// <param name="taskListIdOrName">Task list identifier or task list title used to locate the target list.</param>
            /// <param name="timeout">Maximum amount of time allowed for paging through task lists while searching.</param>
            /// <returns>The matching <see cref="TaskListModel"/>.</returns>
            public TaskListModel FindTaskList(string taskListIdOrName, TimeSpan timeout)
            {
                // Iterate through task list pages until a match is found or the timeout expires.
                var nextPageToken = string.Empty;
                TaskListModel taskListModel = null;
                var expired = DateTime.UtcNow.Add(timeout);

                do
                {
                    // Build paging options for the current request.
                    var options = string.IsNullOrEmpty(nextPageToken)
                        ? new ListTaskListsQueryModel { MaxResults = 1000 }
                        : new ListTaskListsQueryModel { MaxResults = 1000, PageToken = nextPageToken };

                    // Retrieve the current page of task lists.
                    var taskListsPage = adapter.TaskLists.Get(options);

                    // Search the current page by task list id or task list title.
                    var taskList = taskListsPage.Items
                        .FirstOrDefault(i =>
                            string.Equals(i.Id, taskListIdOrName, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(i.Title, taskListIdOrName, StringComparison.OrdinalIgnoreCase));

                    // Stop as soon as a matching task list is found.
                    if (!string.IsNullOrWhiteSpace(taskList?.Id))
                    {
                        taskListModel = taskList;
                        break;
                    }

                    // Move to the next page, if available.
                    nextPageToken = taskListsPage.NextPageToken;
                }
                while (!string.IsNullOrWhiteSpace(nextPageToken) && DateTime.UtcNow < expired);

                // Return the matched task list.
                return taskListModel;
            }
        }

        extension(HttpClient client)
        {
            /// <summary>
            /// Sends an HTTP request and deserializes the JSON response into <typeparamref name="T"/>
            /// using the shared default JSON serializer options.
            /// </summary>
            /// <typeparam name="T">The target CLR type to deserialize the JSON response into.</typeparam>
            /// <param name="requestMessage">The HTTP request message to send.</param>
            /// <returns>The deserialized response body as <typeparamref name="T"/>.</returns>
            public T Send<T>(HttpRequestMessage requestMessage)
            {
                // Use the shared default JSON options for consistent, centralized serialization behavior.
                return client.Send<T>(requestMessage, s_jsonOptions);
            }

            /// <summary>
            /// Sends an HTTP request and deserializes the JSON response into <typeparamref name="T"/>
            /// using the provided JSON serializer options.
            /// </summary>
            /// <typeparam name="T">The target CLR type to deserialize the JSON response into.</typeparam>
            /// <param name="requestMessage">The HTTP request message to send.</param>
            /// <param name="jsonOptions">The JSON serializer options to use when deserializing the response body.</param>
            /// <returns>The deserialized response body as <typeparamref name="T"/>.</returns>
            /// <exception cref="HttpRequestException">Thrown when the response status code is not successful (4xx/5xx).</exception>
            /// <exception cref="InvalidOperationException">Thrown when the response cannot be deserialized into <typeparamref name="T"/>.</exception>
            public T Send<T>(HttpRequestMessage requestMessage, JsonSerializerOptions jsonOptions)
            {
                // Send the HTTP request synchronously and ensure the response is disposed.
                using var response = client.ConfirmResponse(requestMessage);

                // Read the response body as a raw JSON string.
                var responseContent = response
                    .Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                // Deserialize the JSON payload into the requested CLR type.
                // If deserialization returns null (e.g., empty body or mismatched schema), throw a clear error.
                return JsonSerializer.Deserialize<T>(responseContent, jsonOptions)
                    ?? throw new InvalidOperationException(
                        message: $"Failed to deserialize response into {typeof(T).Name}.");
            }

            /// <summary>
            /// Sends an HTTP request and ensures the response indicates success.
            /// </summary>
            /// <param name="requestMessage">The prepared HTTP request to send.</param>
            /// <returns>The <see cref="HttpResponseMessage"/> returned by the server. The caller is responsible for disposing the response.</returns>
            /// <exception cref="HttpRequestException">Thrown when the server returns a non-success HTTP status code.</exception>
            public HttpResponseMessage ConfirmResponse(HttpRequestMessage requestMessage)
            {
                // Send the HTTP request using the configured HTTP client.
                var response = client.Send(requestMessage);

                // Throw an exception for non-success HTTP status codes (4xx/5xx).
                response.EnsureSuccessStatusCode();

                // Return the response so the caller can read the content.
                return response;
            }
        }

        extension(PluginBase plugin)
        {
            /// <summary>
            /// Adds a value to the workflow session parameters using a namespaced key.
            /// </summary>
            /// <param name="namespace">Logical namespace used to prefix the session key (typically the plugin name) to avoid collisions with other session parameters.</param>
            /// <param name="name">The parameter name to store within the specified namespace.</param>
            /// <param name="value">The value to store. The value is Base64-encoded before being persisted.</param>
            public void AddSessionParameter(string @namespace, string name, string value)
            {
                // Prefix the parameter with the namespace (usually the plugin name).
                name = $"{@namespace}:{name}";

                // Encode the value as Base64 to keep storage and transport predictable.
                value = value?.ConvertToBase64() ?? string.Empty;

                // Store the value in the workflow session scope.
                plugin.Invoker.Context.SessionParameters[name] = value;
            }
        }

        extension(PluginDataModel)
        {
            /// <summary>
            /// Gets the default JSON serializer options used for all Google API interactions within the plugin.
            /// </summary>
            public static JsonSerializerOptions JsonOptions => s_jsonOptions;
        }

        extension(PluginDataModel pluginData)
        {
            /// <summary>
            /// Resolves the credential source used for authentication.
            /// </summary>
            /// <returns>A credential reference or raw OAuth access token depending on the provided parameters.</returns>
            public string ResolveCredentials()
            {
                // Read either a raw access token or a credential record reference.
                var token = pluginData.Parameters.Get(key: "Token", defaultValue: string.Empty);
                var credentials = pluginData.Parameters.Get(key: "Credentials", defaultValue: string.Empty);

                // If credentials are provided, use them; otherwise fall back to the raw token.
                return string.IsNullOrEmpty(credentials) ? token : credentials;
            }
        }

        extension<T>(T queryModel) where T : class
        {
            /// <summary>
            /// Converts the current query model into a URL query string.
            /// </summary>
            /// <returns>A query string that starts with <c>?</c> when at least one parameter is produced; otherwise an empty string.</returns>
            public string ConvertToQueryParameters()
            {
                // If no model is provided, there is nothing to convert.
                if (queryModel == null)
                {
                    return string.Empty;
                }

                // Set up reflection flags to access public instance properties of the query model.
                var flags = BindingFlags.Instance | BindingFlags.Public;
                var parts = new List<string>();

                // Include only properties that explicitly opt-in via FromQueryAttribute
                // and whose types are supported for query serialization.
                var properties = queryModel
                    .GetType()
                    .GetProperties(bindingAttr: flags)
                    .Where(i =>
                        i.GetCustomAttribute<FromQueryAttribute>() != null &&
                        AssertType(type: i.PropertyType));

                // Process each eligible property to generate its corresponding query parameter string.
                foreach (var property in properties)
                {
                    // ResolveQueryParameter returns either "name=value" or an empty string
                    // when the value is null/empty/default and should be skipped.
                    var item = ResolveQueryParameter(property, queryModel);

                    // Only include non-empty query parameters in the final output.
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        parts.Add(item);
                    }
                }

                // Prefix with '?' only when at least one query parameter exists.
                return parts.Count == 0
                    ? string.Empty
                    : "?" + string.Join("&", parts);

                // Determines whether the specified type is supported for query parameter formatting.
                // Allow only primitive scalar types that can be reliably serialized
                // and transmitted as query string parameters.
                static bool AssertType(Type type) => type == typeof(string)
                    || type == typeof(bool)
                    || type == typeof(int)
                    || type == typeof(long)
                    || type == typeof(decimal)
                    || type == typeof(double);

                // Formats a model property into a URL query parameter.
                static string ResolveQueryParameter(PropertyInfo property, object queryModel)
                {
                    // Ignore properties that cannot be read or are indexers.
                    if (!property.CanRead || property.GetIndexParameters().Length != 0)
                    {
                        return string.Empty;
                    }

                    // Set up reflection flags and culture for consistent property access and value formatting.
                    var flags = BindingFlags.Instance | BindingFlags.Public;
                    var culture = CultureInfo.InvariantCulture;

                    // Retrieve the property type and value from the query model instance.
                    var type = property.PropertyType;
                    var value = property.GetValue(queryModel);

                    // Determine whether the property has a meaningful value.
                    var isValue = value != null && !(type == typeof(string) && string.IsNullOrWhiteSpace((string)value));
                    var isBooleanFalse = type == typeof(bool) && (bool)value == false;
                    var isIntZero = type == typeof(int) && (int)value == 0;
                    var isLongZero = type == typeof(long) && (long)value == 0L;
                    var isDecimalZero = type == typeof(decimal) && (decimal)value == 0m;
                    var isDoubleZero = type == typeof(double) && (double)value == 0d;

                    // Skip properties with null, empty, or default values.
                    if (!isValue
                        || isBooleanFalse
                        || isIntZero
                        || isLongZero
                        || isDecimalZero
                        || isDoubleZero)
                    {
                        return string.Empty;
                    }

                    // Look for a FromQueryAttribute to determine the query parameter name.
                    var attribute = property
                        .GetCustomAttributes(inherit: true)
                        .FirstOrDefault(a => a.GetType().Name == nameof(FromQueryAttribute));

                    // If the attribute is present, attempt to read its "Name" property for the parameter name.
                    var nameProperty = attribute?
                        .GetType()
                        .GetProperty(name: "Name", bindingAttr: flags);

                    // If the "Name" property exists and has a non-empty value, use it;
                    // otherwise convert the property name to camelCase.
                    var attributeName = nameProperty?.GetValue(attribute) as string;

                    // Use the attribute-defined name if available; otherwise convert the property name to camelCase.
                    var name = string.IsNullOrWhiteSpace(attributeName)
                        ? property.Name.ConvertToCamelCase()
                        : attributeName;

                    // Convert the property value to a string using invariant culture.
                    // Special handling ensures consistent formatting for numeric types.
                    var stringValue = type switch
                    {
                        Type t when t == typeof(bool) => ((bool)value) ? "true" : "false",
                        Type t when t == typeof(double) => ((double)value).ToString("R", culture),
                        Type t when t == typeof(decimal) => ((decimal)value).ToString(culture),
                        _ => Convert.ToString(value, culture) ?? string.Empty
                    };

                    // Return the encoded query parameter pair.
                    return $"{Uri.EscapeDataString(name)}={Uri.EscapeDataString(stringValue)}";
                }
            }
        }
    }
}
