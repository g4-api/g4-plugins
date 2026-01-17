using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods.Abstraction;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(StartJenkinsJob)}.json")]
    public class StartJenkinsJob(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Pre-computed Jenkins configuration and parameters derived from pluginData.
            var jenkinsPlugin = new JenkinsPluginModel(pluginData);

            // Start the Jenkins job (enqueue it and get the queue item response).
            var responseMessage = StartJob(plugin: this, pluginData, jenkinsPlugin);

            // If the caller does NOT want to wait for the build to finish, return immediately.
            if (!jenkinsPlugin.WaitForCompletion)
            {
                return NewPluginResponse(plugin: this, pluginData, responseMessage, wait: false);
            }

            // Jenkins returns a queue item URL in the Location header.
            // Poll the queue until it is assigned an executable build URL.
            var queueUrl = responseMessage.Headers.Location.AbsoluteUri.TrimEnd('/');
            var jobUrl = GetJobUrl(
                url: queueUrl,
                authentication: jenkinsPlugin.Authentication,
                timeout: jenkinsPlugin.Timeout);

            // Poll the build status until it finishes or the timeout is reached.
            var timeout = DateTime.UtcNow + jenkinsPlugin.Timeout;

            // Continue polling until either the job finishes or the timeout expires.
            while (DateTime.UtcNow < timeout)
            {
                // Prepare a reusable GET request for the build status endpoint.
                using var statusRequest = new HttpRequestMessage(
                    method: HttpMethod.Get,
                    requestUri: $"{jobUrl}/api/json");

                // Attach authentication to the status request.
                statusRequest.Headers.Authorization = jenkinsPlugin.Authentication;

                // Send the status request and read the response.
                var statusResponse = HttpClient
                    .SendAsync(statusRequest)
                    .GetAwaiter()
                    .GetResult();

                // Read the response content as a string.
                var statusResponseContent = statusResponse
                    .Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                // Parse the response JSON to inspect build state.
                using var statusResponseDocument = JsonDocument.Parse(statusResponseContent);
                var statusResponseJson = statusResponseDocument.RootElement;

                // Jenkins build JSON has "building" (bool) and "result" (string or null).
                // When "building" is false, the job has finished.
                if (statusResponseJson.TryGetProperty("building", out var building) && !building.GetBoolean())
                {
                    return NewPluginResponse(plugin: this, pluginData, statusResponse, wait: true);
                }

                // Wait before polling again.
                Thread.Sleep(jenkinsPlugin.PollingInterval);
            }

            // If we exit the loop, the job did not complete within the configured timeout window.
            throw new TimeoutException(
                message: "Timed out waiting for Jenkins job to finish.");
        }

        // Polls a Jenkins job until its executable.url becomes available,
        // or until the specified timeout is reached.
        private static string GetJobUrl(string url, AuthenticationHeaderValue authentication, TimeSpan timeout)
        {
            // Calculate the end time so the loop remains time-bounded.
            var end = DateTime.UtcNow + timeout;

            // Continue polling until either:
            // 1. The job receives an "executable" object from Jenkins, or
            // 2. The timeout expires.
            while (DateTime.UtcNow < end)
            {
                // Build the GET request for the job status API.
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/api/json");
                request.Headers.Authorization = authentication;

                // Execute the request synchronously and read the response body.
                var responseContent = HttpClient
                    .SendAsync(request)
                    .GetAwaiter()
                    .GetResult()
                    .Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                // Parse the returned JSON to inspect Jenkins job metadata.
                var json = JsonDocument.Parse(responseContent);

                // The "executable" object is present only after the job has been scheduled.
                var isExecutable = json
                    .RootElement
                    .TryGetProperty("executable", out JsonElement value);

                // If no executable object yet, continue polling.
                if (!isExecutable)
                {
                    continue;
                }

                try
                {
                    // Extract the executable URL and normalize by trimming trailing slashes.
                    return value.GetProperty("url").GetString().TrimEnd('/');
                }
                catch
                {
                    // Silent: if property extraction fails but executable object exists,
                    // loop again and wait for a more complete response.
                }
            }

            // If the loop exits, the job never provided an executable URL in time.
            throw new TimeoutException(
                message: "Timed out waiting for Jenkins to provide an executable URL.");
        }

        // Creates a PluginResponseModel after invoking a Jenkins job,
        // optionally parsing the HTTP response body and storing job metadata in session parameters.
        private static PluginResponseModel NewPluginResponse(
            PluginBase plugin,
            PluginDataModel pluginData,
            HttpResponseMessage responseMessage,
            bool wait)
        {
            // Extracts a portion of a job response JSON using a JSONPath expression.
            string FormatJobResponse(string jobResponse)
            {
                try
                {
                    // Retrieve the JSONPath expression (e.g., "data.result.id")
                    var jsonPath = pluginData.Rule.OnElement.Trim();

                    // Parse the raw response string into a JObject for querying
                    var responseJsonObject = Newtonsoft.Json.Linq.JObject.Parse(jobResponse);

                    // If no JSONPath was defined, return the full raw response
                    // Otherwise evaluate the JSONPath; throw if no match is found
                    return string.IsNullOrEmpty(jsonPath)
                        ? jobResponse
                        : responseJsonObject.SelectToken(jsonPath, errorWhenNoMatch: true)?.ToString();
                }
                catch (Exception e)
                {
                    // Capture and store the exception in the plugin's diagnostic pipeline
                    var exception = new G4ExceptionModel(pluginData.Rule, e);
                    plugin.Exceptions.Add(exception);
                }

                // Return the original response as a fallback on any error
                return jobResponse;
            }

            // Attempts to retrieve a named property from a JSON document's root element.
            (JsonElement Property, bool PropertyExists) GetProperty(
                JsonDocument document,
                string propertyName)
            {
                try
                {
                    // Attempt to access the property by name from the root element
                    var property = document
                        .RootElement
                        .GetProperty(propertyName);

                    // Property was successfully found and returned
                    return (property, true);
                }
                catch (Exception e)
                {
                    // Wrap and log the exception into the plugin's exception collection for diagnostics
                    var exception = new G4ExceptionModel(pluginData.Rule, e);
                    plugin.Exceptions.Add(exception);
                }

                // Return default element and false flag if property is missing or access failed
                return (default, false);
            }

            // Short-hand reference to the current session parameters bag.
            var sessionParameters = plugin.Invoker.Context.SessionParameters;

            // If the caller does not want to wait, capture only the HTTP status code and return.
            if (!wait)
            {
                sessionParameters["JenkinsJobStatusCode"] = (int)responseMessage.StatusCode;
                return plugin.NewPluginResponse();
            }

            // Read the full HTTP response body as text (synchronously in this context).
            var responseBody = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            // Optionally reduce/transform the response JSON based on the rule's JSON path (OnElement).
            var jobResponse = FormatJobResponse(jobResponse: responseBody);

            // Parse the (possibly transformed) JSON to extract specific fields.
            var responseDocument = JsonDocument.Parse(json: jobResponse);

            // Try to get the "duration" property from the root of the JSON document.
            var (durationProperty, durationPropertyExists) = GetProperty(responseDocument, "duration");

            // Try to get the "url" property from the root of the JSON document.
            var (urlProperty, urlPropertyExists) = GetProperty(responseDocument, "url");

            // Store the HTTP status code and parsed Jenkins job metadata into session parameters.
            sessionParameters["JenkinsJobStatusCode"] = (int)responseMessage.StatusCode;
            sessionParameters["JenkinsJobDuration"] = durationPropertyExists ? durationProperty.GetInt64() : 0;
            sessionParameters["JenkinsJobUrl"] = urlPropertyExists ? urlProperty.GetString() : string.Empty;

            // Apply the configured regular expression to the job response,
            // take the first match (if any), and store it as a Base64-encoded string.
            sessionParameters["JenkinsJobResponse"] = Regex
                .Match(input: jobResponse, pattern: pluginData.Rule.RegularExpression)?
                .Value
                .ConvertToBase64() ?? string.Empty;

            // Return a new plugin response object, after session parameters have been updated.
            return plugin.NewPluginResponse();
        }

        // Sends a POST request to start a remote job using the provided plugin and authentication.
        private static HttpResponseMessage StartJob(
            PluginBase plugin,
            PluginDataModel pluginData,
            JenkinsPluginModel jenkinsPlugin)
        {
            // Calculate the absolute timeout deadline for the operation.
            var timeout = DateTime.UtcNow + jenkinsPlugin.Timeout;

            // Continue attempting to start the job until either it succeeds or the timeout expires.
            while (DateTime.UtcNow < timeout)
            {
                // Create a helper that knows how to build the appropriate HttpContent
                // based on the plugin's method type (POST, PUT, DELETE, etc.)
                var methodBase = new HttpMethodPlugin(plugin);

                // Build the HTTP content/body using plugin-specific serialization logic
                using var content = methodBase.NewContent(pluginData);

                // Construct the outgoing POST request with body
                using var request = new HttpRequestMessage(HttpMethod.Post, requestUri: jenkinsPlugin.Url)
                {
                    Content = content
                };

                // Attach the provided authentication header (Basic/Bearer/etc.)
                request.Headers.Authorization = jenkinsPlugin.Authentication;

                // Send synchronously (blocking). The caller expects a completed result here.
                var response = HttpClient
                    .SendAsync(request)
                    .GetAwaiter()
                    .GetResult();

                // Throw an exception if the server responded with a non-success HTTP code
                response.EnsureSuccessStatusCode();

                // Read the response content as a string for analysis
                var responseContent = response
                    .Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                // Check if the response indicates that the item already exists in the queue
                var isItemExists = Regex.IsMatch(
                    input: responseContent,
                    pattern: "(?i)(item exists|already in the queue)");

                // Check if the response contains a Location header (indicating a redirect)
                var isLocation = response.Headers.Location != null;

                // Check if the response appears to be an HTML document (error page)
                var isHtmlResponse = Regex.IsMatch(
                    input: responseContent,
                    pattern: "(?is)<html.*?>.*?</html>");

                // Check if the response status code is 200 OK
                var is200Ok = response.StatusCode == System.Net.HttpStatusCode.OK;

                // Determine if we need to retry based on the response analysis
                var retry = isItemExists || (isHtmlResponse && (is200Ok || !isLocation));

                // If the item already exists, clean up and retry after a delay
                if (retry)
                {
                    // Clean up resources before the next iteration
                    response.Dispose();

                    // Wait before retrying to start the job
                    Thread.Sleep(jenkinsPlugin.PollingInterval);

                    // Continue to the next iteration of the loop
                    continue;
                }

                // Return the successful response object to the caller
                return response;
            }

            // If we exit the loop, the job could not be started within the timeout window.
            throw new TimeoutException(
                message: "Timed out while attempting to start the Jenkins job.");
        }

        /// <summary>
        /// Represents a strongly-typed, precomputed Jenkins request configuration
        /// derived from the plugin parameters.
        /// </summary>
        private sealed class JenkinsPluginModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="JenkinsPluginModel"/> class
            /// using values taken from the provided <paramref name="pluginData"/>.
            /// </summary>
            /// <param name="pluginData">The plugin data providing Jenkins connection and job parameters.</param>
            public JenkinsPluginModel(PluginDataModel pluginData)
            {
                // Extract basic parameters from the plugin configuration.
                var jobPath = pluginData.Parameters.Get(key: "JobPath", "").TrimEnd('/');
                var parameterizedJob = pluginData.Parameters.ContainsKey(key: "Field");
                var password = pluginData.Parameters.Get(key: "Token", "");
                var username = pluginData.Parameters.Get(key: "Username", "");
                var jobUrl = FormatUrl(pluginData, jobPath, parameterizedJob);

                // Create the Authentication header for Basic Auth using the provided credentials.
                Authentication = NewAuthenticationHeader(username, password);

                // Store the raw job path (without trailing slash).
                JobPath = jobPath;

                // Store credentials as provided by the plugin parameters.
                Password = password;
                Username = username;

                // Indicates whether this job expects parameters (buildWithParameters).
                ParameterizedJob = parameterizedJob;

                // Polling interval for build status, converted from a millisecond-based value.
                PollingInterval = pluginData
                    .Parameters
                    .Get(key: "PollingInterval", defaultValue: "5000")
                    .ConvertToTimeSpan();

                // Overall timeout for waiting on the Jenkins job, also converted from milliseconds.
                Timeout = pluginData
                    .Parameters
                    .Get(key: "Timeout", defaultValue: "600000")
                    .ConvertToTimeSpan();

                // Fully formatted trigger URL for this job (build or buildWithParameters).
                Url = jobUrl;

                // Whether the caller requested to wait for job completion.
                WaitForCompletion = pluginData.Parameters.ContainsKey("Wait");
            }

            /// <summary>
            /// Gets or sets the HTTP authentication header used for Jenkins requests.
            /// </summary>
            public AuthenticationHeaderValue Authentication { get; set; }

            /// <summary>
            /// Gets or sets the Jenkins job path (relative to the Jenkins base URL).
            /// </summary>
            public string JobPath { get; set; }

            /// <summary>
            /// Gets or sets the password or token used for authentication.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this job is parameterized
            /// (uses <c>buildWithParameters</c> instead of <c>build</c>).
            /// </summary>
            public bool ParameterizedJob { get; set; }

            /// <summary>
            /// Gets or sets the polling interval between status checks.
            /// </summary>
            public TimeSpan PollingInterval { get; set; }

            /// <summary>
            /// Gets or sets the maximum time to wait for the job to complete.
            /// </summary>
            public TimeSpan Timeout { get; set; }

            /// <summary>
            /// Gets or sets the fully formatted Jenkins job trigger URL.
            /// </summary>
            public string Url { get; set; }

            /// <summary>
            /// Gets or sets the username used for authentication.
            /// </summary>
            public string Username { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the caller wants to wait
            /// for the Jenkins job to complete.
            /// </summary>
            public bool WaitForCompletion { get; set; }

            // Builds the full Jenkins URL for triggering a job, including the appropriate
            // endpoint (build or buildWithParameters).
            private static string FormatUrl(PluginDataModel pluginData, string jobPath, bool parameterizedJob)
            {
                // Determine the trigger endpoint based on whether the job is parameterized.
                var trigger = parameterizedJob ? "buildWithParameters" : "build";

                // Normalize the base Jenkins URL by trimming any trailing slash.
                var url = pluginData.Parameters.Get(key: "Url", "").TrimEnd('/');

                // Compose the full trigger URL for this job.
                return $"{url}/job/{jobPath}/{trigger}";
            }

            // Creates a new HTTP AuthenticationHeaderValue for Basic Authentication.
            private static AuthenticationHeaderValue NewAuthenticationHeader(string username, string password)
            {
                // Basic Auth requires the value to be "username:password" encoded as Base64
                var token = $"{username}:{password}";

                // Convert the raw token into ASCII bytes
                var tokenBytes = Encoding.ASCII.GetBytes(s: token);

                // Encode the bytes into a Base64 string as required by RFC 7617
                var tokenBase64 = Convert.ToBase64String(inArray: tokenBytes);

                // Create the AuthenticationHeaderValue using the "Basic" scheme
                return new AuthenticationHeaderValue(scheme: "Basic", parameter: tokenBase64);
            }
        }
    }
}
