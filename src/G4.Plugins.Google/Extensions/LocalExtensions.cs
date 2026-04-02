using G4.Extensions;
using G4.Models;
using G4.Plugins.Google.Clients;
using G4.Plugins.Google.Models.Gmail;
using G4.Plugins.Google.Models.Tasks;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
                    .Tasks
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
                        ? new ListTasksRequestModel { MaxResults = 100 }
                        : new ListTasksRequestModel { MaxResults = 100, PageToken = nextPageToken };

                    // Retrieve the current page of tasks from the resolved list.
                    var tasksPage = adapter.Tasks.Tasks.Get(taskListId, options);

                    // Read the tasks returned in the current page.
                    var tasks = tasksPage.Items;

                    // Stop when the current page does not contain any tasks.
                    if (tasks == null || tasks.Count == 0)
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
            /// Finds Gmail labels whose names match the specified regular expression pattern.
            /// </summary>
            /// <param name="pattern">Regular expression pattern used to match label names.</param>
            /// <returns>A sequence of <see cref="LabelModel"/> items whose names match the specified pattern.</returns>
            public IEnumerable<LabelModel> FindLabels(
                [StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
            {
                // Retrieve all labels from Gmail to search
                // for matches against the specified pattern.
                var response = adapter.Gmail.Labels.Get();

                // Use regex matching to find labels whose
                // names match the specified pattern.
                return response
                    .Labels
                    .Where(i => Regex.IsMatch(input: i.Name.Trim(), pattern));
            }

            /// <summary>
            /// Searches Gmail messages until a subject matches the specified regular expression
            /// or the timeout expires.
            /// </summary>
            /// <param name="pattern">Regular expression pattern used to match the message subject.</param>
            /// <param name="timeout">Maximum amount of time allowed for paging through Gmail messages while searching.</param>
            /// <returns>The first <see cref="MessageModel"/> whose <c>Subject</c> header matches the specified pattern.</returns>
            public MessageModel FindMail(
                [StringSyntax(StringSyntaxAttribute.Regex)] string pattern,
                TimeSpan timeout)
            {
                // Initialize paging state for the Gmail messages list operation.
                // The first request is executed without a page token.
                var nextPageToken = string.Empty;

                // Calculate the absolute expiration time for the search operation.
                var expired = DateTime.UtcNow.Add(timeout);

                do
                {
                    // Request the current page of message identifiers.
                    // When a next-page token exists, continue from that page.
                    var messagesPage = string.IsNullOrWhiteSpace(nextPageToken)
                        ? adapter.Gmail.Messages.Get()
                        : adapter.Gmail.Messages.Get(query: new() { PageToken = nextPageToken });

                    // Stop the search when no messages are returned.
                    if (messagesPage?.Messages == null || messagesPage.Messages.Length == 0)
                    {
                        break;
                    }

                    // Retrieve each full message individually and inspect its Subject header.
                    foreach (var message in messagesPage.Messages)
                    {
                        // Load the complete message model by its identifier.
                        var messageModel = adapter.Gmail.Messages.Get(message.Id);

                        // Read the Subject header from the message metadata.
                        var subject = GetHeader(messageModel: messageModel, name: "Subject");

                        // Return immediately once a matching subject is found.
                        if (Regex.IsMatch(input: subject, pattern))
                        {
                            return messageModel;
                        }
                    }

                    // Advance to the next page, if Gmail returned a continuation token.
                    nextPageToken = messagesPage.NextPageToken;
                }
                while (!string.IsNullOrWhiteSpace(nextPageToken) && DateTime.UtcNow < expired);

                // Fail explicitly when no message matched the requested subject pattern.
                throw new InvalidOperationException(
                    message: $"No matching mail subject was found for pattern: '{pattern}'.");
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
                    .Tasks
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
                        ? new ListTasksRequestModel { MaxResults = 100 }
                        : new ListTasksRequestModel { MaxResults = 100, PageToken = nextPageToken };

                    // Retrieve the current page of tasks from the resolved list.
                    var tasksPage = adapter.Tasks.Tasks.Get(taskListId, options);

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
                        ? new ListTaskListsRequestModel { MaxResults = 1000 }
                        : new ListTaskListsRequestModel { MaxResults = 1000, PageToken = nextPageToken };

                    // Retrieve the current page of task lists.
                    var taskListsPage = adapter.Tasks.TaskLists.Get(options);

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

        extension(MessageModel message)
        {
            /// <summary>
            /// Retrieves the Bcc header value from the message.
            /// </summary>
            /// <returns>The Bcc header value, or an empty string when the header is not present.</returns>
            public string GetBcc()
            {
                return GetHeader(messageModel: message, name: "Bcc");
            }

            /// <summary>
            /// Retrieves the Cc header value from the message.
            /// </summary>
            /// <returns>The Cc header value, or an empty string when the header is not present.</returns>
            public string GetCc()
            {
                return GetHeader(messageModel: message, name: "Cc");
            }

            /// <summary>
            /// Retrieves the From header value from the message.
            /// </summary>
            /// <returns>The From header value, or an empty string when the header is not present.</returns>
            public string GetFrom()
            {
                return GetHeader(messageModel: message, name: "From");
            }

            /// <summary>
            /// Retrieves the Message-Id header value from the message.
            /// </summary>
            /// <returns>The Message-Id header value, or an empty string when the header is not present.</returns>
            public string GetMessageId()
            {
                return GetHeader(messageModel: message, name: "Message-Id");
            }

            /// <summary>
            /// Retrieves the Subject header value from the message.
            /// </summary>
            /// <returns>The Subject header value, or an empty string when the header is not present.</returns>
            public string GetSubject()
            {
                return GetHeader(messageModel: message, name: "Subject");
            }

            /// <summary>
            /// Retrieves the thread identifier associated with the current message.
            /// </summary>
            /// <returns>A string containing the thread identifier if present; otherwise, null.</returns>
            public string GetThreadId()
            {
                return GetHeader(messageModel: message, name: "Thread-Id");
            }

            /// <summary>
            /// Retrieves the To header value from the message.
            /// </summary>
            /// <returns>The To header value, or an empty string when the header is not present.</returns>
            public string GetTo()
            {
                return GetHeader(messageModel: message, name: "To");
            }

            /// <summary>
            /// Reads the message body from the Gmail message payload.
            /// </summary>
            /// <returns>The decoded message body content. Plain text is preferred when available, otherwise HTML content is returned. Returns an empty string when no body exists.</returns>
            public string Read()
            {
                // Use case-insensitive comparison when matching MIME types because
                // Gmail responses may vary in casing depending on the sender/client.
                const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

                // Gmail messages usually contain their content in the payload parts collection.
                // Each part represents a MIME section such as plain text, HTML, or attachments.
                // We first try to locate a "text/plain" part because it is the safest and most
                // predictable representation of the message content.
                var plainTextPart = message
                    .Payload
                    .Parts?
                    .FirstOrDefault(p => p.MimeType.Equals("text/plain", comparison));

                // If plain text is not available, attempt to locate an HTML body instead.
                // Many emails only include HTML content and omit a plain text alternative.
                var htmlPart = message
                    .Payload
                    .Parts?
                    .FirstOrDefault(p => p.MimeType.Equals("text/html", comparison));

                // When a plain text body is present, decode and return it.
                if (plainTextPart != null)
                {
                    return DecodeBase64(plainTextPart.Body.Data);
                }

                // If plain text is not available but HTML exists, decode and return it instead.
                if (htmlPart != null)
                {
                    return DecodeBase64(htmlPart.Body.Data);
                }

                // When neither plain text nor HTML bodies exist, return an empty string.
                // This can occur for messages containing only attachments or unusual MIME structures.
                return string.Empty;

                // Local helper used to decode Gmail's Base64URL encoded message body content.
                // Gmail replaces '+' with '-' and '/' with '_' in Base64 strings, so we normalize
                // the value before performing the standard Base64 decoding.
                static string DecodeBase64(string base64Data)
                {
                    // Convert Base64URL format to standard Base64 format.
                    var normalized = base64Data
                        .Replace('-', '+')
                        .Replace('_', '/');

                    // Decode the Base64 content into raw bytes.
                    var data = Convert.FromBase64String(normalized);

                    // Convert the decoded byte array into a UTF-8 string.
                    return System.Text.Encoding.UTF8.GetString(data);
                }
            }

            /// <summary>
            /// Resolves the Gmail label names associated with the message based on its label IDs.
            /// </summary>
            /// <param name="adapter">The GoogleAdapter instance used to interact with the Gmail API.</param>
            /// <returns>An enumerable of label names associated with the message.</returns>
            public IEnumerable<string> ResolveLabels(GoogleAdapter adapter)
            {
                return adapter
                    .Gmail
                    .Labels
                    .Get()
                    .Labels
                    .Where(i => message.LabelIds.Contains(i.Id, StringComparer.Ordinal))
                    .Select(i => i.Name);
            }

            // Retrieves a header value from the Gmail message payload.
            private static string GetHeader(MessageModel messageModel, string name)
            {
                // Search the message payload headers for the specified header name.
                return messageModel?
                    .Payload
                    .Headers
                    .FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?
                    .Value ?? string.Empty;
            }
        }
    }
}
