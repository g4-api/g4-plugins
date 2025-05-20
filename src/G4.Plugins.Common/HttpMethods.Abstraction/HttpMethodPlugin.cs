using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

using G4.Extensions;
using G4.Models;

using Microsoft.Extensions.Logging;

namespace G4.Plugins.Common.HttpMethods.Abstraction
{
    /// <summary>
    /// Plugin that handles sending HTTP requests using the provided setup configuration.
    /// </summary>
    internal class HttpMethodPlugin(PluginBase plugin)
    {
        private readonly PluginBase _plugin = plugin;

        /// <summary>
        /// Sends an HTTP request based on the provided <paramref name="pluginData"/> and 
        /// pre-constructed <paramref name="requestMessage"/>, then processes and returns the response.
        /// </summary>
        /// <param name="pluginData">Data and parameters provided to the plugin for this invocation.</param>
        /// <param name="requestMessage">An <see cref="HttpRequestMessage"/> configured with method and URL.</param>
        /// <returns>A <see cref="PluginResponseModel"/> containing status, headers, and extracted content.</returns>
        public PluginResponseModel SendMessage(PluginDataModel pluginData, HttpRequestMessage requestMessage)
        {
            // Extract URL and headers from plugin data.
            var headers = FormatFields(fieldName: "Header", pluginData);

            // Add authorization header to the request message.
            AddAuthorizationHeader(requestMessage, headers);

            // Add additional headers to the request message.
            AddHeaders(requestMessage, headers);

            // Send the HTTP request and receive the response.
            var responseMessage = PluginBase.HttpClient.Send(requestMessage);

            // Read the response body.
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;

            // Check if the response contains a specific element.
            var isElement = !string.IsNullOrEmpty(pluginData.Rule.OnElement);
            var input = responseBody;

            // If no specific element is specified, create a plugin response with the entire response.
            if (!isElement)
            {
                return NewPluginResponse(plugin: _plugin, pluginData, responseMessage, input);
            }

            // If the response body confirms JSON format, extract the specified element.
            if (responseBody.AssertJson())
            {
                input = GetJsonData(plugin: _plugin, responseBody, pluginData.Rule);
            }
            // If the response body confirms XML format, extract the specified element.
            else if (responseBody.AssertXml())
            {
                input = GetXmlData(plugin: _plugin, responseBody, pluginData.Rule);
            }

            // Create and return a new plugin response with the processed data.
            return NewPluginResponse(plugin: _plugin, pluginData, responseMessage, input);
        }

        #region *** Methods: Protected ***
        /// <summary>
        /// Adds an authorization header to the HTTP request message.
        /// </summary>
        /// <param name="requestMessage">The HTTP request message to which the header should be added.</param>
        /// <param name="headers">A collection of headers, including the authorization header.</param>
        protected virtual void AddAuthorizationHeader(
            HttpRequestMessage requestMessage, IDictionary<string, string> headers)
        {
            // Retrieve the 'Authorization' header value from the provided headers.
            var authorization = headers.Get(key: "Authorization", defaultValue: string.Empty);

            // Create an authentication header if the 'Authorization' header value is not empty.
            // If it is empty, set 'authentication' to null.
            var authentication = string.IsNullOrEmpty(authorization)
                ? null
                : NewAuthenticationHeader(headerValue: authorization);

            // Set the 'Authorization' header of the request message to the 'authentication' value.
            requestMessage.Headers.Authorization = authentication;
        }

        /// <summary>
        /// Adds headers to the HTTP request message, excluding the 'Authorization' header.
        /// </summary>
        /// <param name="requestMessage">The HTTP request message to which the headers should be added.</param>
        /// <param name="headers">A collection of headers to be added to the request message.</param>
        protected virtual void AddHeaders(HttpRequestMessage requestMessage, IDictionary<string, string> headers)
        {
            // Iterate through the provided headers.
            foreach (var header in headers)
            {
                // Check if the header key is not 'Authorization' (case-insensitive).
                if (!header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    // Add the header to the request message without validation.
                    requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
        }

        /// <summary>
        /// Creates an HTTP request based on the provided plugin data, URL, and headers.
        /// </summary>
        /// <param name="pluginData">The data containing information for creating the HTTP request.</param>
        /// <param name="url">The URL to which the HTTP request should be sent.</param>
        /// <param name="headers">An enumeration of header name-value pairs to include in the request.</param>
        /// <returns>An instance of <see cref="HttpRequestMessage"/> representing the HTTP request.</returns>
        protected virtual HttpRequestMessage NewRequestMessage(
            PluginDataModel pluginData, string url, IDictionary<string, string> headers)
        {
            return null;
        }
        #endregion

        #region *** Methods: Public    ***
        /// <summary>
        /// This method formats fields from the specified <paramref name="pluginData"/> to be used as HTTP request fields,
        /// such as headers or form data, with the specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing the fields.</param>
        /// <param name="fieldName">The name of the field to format.</param>
        /// <returns>A dictionary containing the formatted fields.</returns>
        public static IDictionary<string, string> FormatFields(PluginDataModel pluginData, string fieldName)
        {
            return FormatFields(fieldName, pluginData);
        }

        /// <summary>
        /// Gets the Encoding object based on the provided encoding name.
        /// If the encoding name is null or empty, it defaults to UTF-8.
        /// If the provided encoding name is not found, it defaults to UTF-8 as well.
        /// </summary>
        /// <param name="encoding">The encoding name.</param>
        /// <returns>The Encoding object based on the provided encoding name, or UTF-8 if not found.</returns>
        public static Encoding GetEncoding(string encoding)
        {
            // If encoding is null or empty, default to UTF-8
            if (string.IsNullOrEmpty(encoding))
            {
                return Encoding.UTF8;
            }

            // Get all public static properties of type Encoding from the Encoding class
            var encodings = typeof(Encoding)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(property => property.PropertyType == typeof(Encoding));

            // Find the Encoding property that matches the provided encoding name (case-insensitive)
            var encodingValue = encodings
                .FirstOrDefault(property => property.Name.Equals(encoding, StringComparison.OrdinalIgnoreCase))
                ?.GetValue(null) as Encoding;

            // If the Encoding property is found, return its value; otherwise, default to UTF-8
            return encodingValue ?? Encoding.UTF8;
        }

        /// <summary>
        /// Determines the media type for the given plugin data.
        /// </summary>
        /// <param name="plugin">The plugin instance used for logging.</param>
        /// <param name="pluginData">The data model containing parameters for the plugin.</param>
        /// <returns>The determined media type as a string.</returns>
        public static string GetMediaType(PluginBase plugin, PluginDataModel pluginData)
        {
            // Check if ContentType is provided
            if (pluginData.Parameters.TryGetValue("ContentType", out string contentType) && !string.IsNullOrEmpty(contentType))
            {
                // Log the specified content type
                plugin.Logger.LogInformation("Content type specified: {ContentType}", contentType);
                return contentType;
            }

            // Check if Fields are present, return "application/x-www-form-urlencoded"
            if (pluginData.Parameters.ContainsKey("Field"))
            {
                // Log the use of form-urlencoded content type
                plugin.Logger.LogInformation("Fields present. Using 'application/x-www-form-urlencoded' content type.");
                return MediaTypeNames.Application.FormUrlEncoded;
            }

            // Get Body if provided
            var body = pluginData.Parameters.Get("Body", string.Empty);

            // Check if JSON format is confirmed
            if (body.AssertJson())
            {
                // Log and return JSON content type
                plugin.Logger.LogInformation("JSON format confirmed. Using 'application/json' content type.");
                return MediaTypeNames.Application.Json;
            }
            // Check if XML format is confirmed
            else if (body.AssertXml())
            {
                // Log and return XML content type
                plugin.Logger.LogInformation("XML format confirmed. Using 'text/xml' content type.");
                return MediaTypeNames.Text.Xml;
            }

            // Default to "text/plain" if no relevant arguments are found
            plugin.Logger.LogInformation("No specific content type or body found. Using 'text/plain' content type by default.");
            return string.IsNullOrEmpty(body)
                ? string.Empty
                : MediaTypeNames.Text.Plain;
        }

        /// <summary>
        /// Creates a new <see cref="HttpContent"/> based on the provided <paramref name="pluginData"/> using the default
        /// media type of <see cref="MediaTypeNames.Application.Json"/> and <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing the data for the HTTP content.</param>
        /// <returns>A new <see cref="HttpContent"/> instance.</returns>
        /// <remarks>
        /// This method supports various media types, including XML, JSON, plain text, and form URL-encoded.
        /// It creates the appropriate <see cref="HttpContent"/> based on the specified media type and plugin data.
        /// </remarks>
        public HttpContent NewContent(PluginDataModel pluginData)
        {
            // Extract encoding from plugin data
            var encodingName = pluginData.Parameters.Get("Encoding", string.Empty);

            // Get encoding based on the encoding name
            var encoding = GetEncoding(encodingName);

            // Get media type from plugin data
            var mediaType = GetMediaType(plugin: _plugin, pluginData);

            // Create and return a new instance of HttpContent
            return NewContent(pluginData, encoding, mediaType);
        }

        /// <summary>
        /// Creates a new <see cref="HttpContent"/> based on the provided <paramref name="pluginData"/> with the specified
        /// <paramref name="mediaType"/> and default <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing the data for the HTTP content.</param>
        /// <param name="mediaType">The media type of the HTTP content.</param>
        /// <returns>A new <see cref="HttpContent"/> instance.</returns>
        /// <remarks>
        /// This method supports various media types, including XML, JSON, plain text, and form URL-encoded.
        /// It creates the appropriate <see cref="HttpContent"/> based on the specified media type and plugin data.
        /// </remarks>
        public static HttpContent NewContent(PluginDataModel pluginData, string mediaType)
        {
            // Extract encoding from plugin data
            var encodingName = pluginData.Parameters.Get("Encoding", string.Empty);

            // Get encoding based on the encoding name
            var encoding = GetEncoding(encodingName);

            // Create and return a new instance of HttpContent
            return NewContent(pluginData, encoding, mediaType);
        }

        /// <summary>
        /// Creates a new <see cref="HttpContent"/> based on the provided <paramref name="pluginData"/> with the specified
        /// <paramref name="mediaType"/> and <paramref name="encoding"/>.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing the data for the HTTP content.</param>
        /// <param name="encoding">The encoding to be used for the HTTP content.</param>
        /// <param name="mediaType">The media type of the HTTP content.</param>
        /// <returns>A new <see cref="HttpContent"/> instance.</returns>
        /// <remarks>
        /// This method supports various media types, including XML, JSON, plain text, and form URL-encoded.
        /// It creates the appropriate <see cref="HttpContent"/> based on the specified media type and plugin data.
        /// </remarks>
        public static HttpContent NewContent(PluginDataModel pluginData, Encoding encoding, string mediaType)
        {
            // Extract the body and fields from the plugin data
            var body = pluginData.Parameters.Get("Body", string.Empty);
            var fields = FormatFields(fieldName: "Field", pluginData);

            // Create new HttpContent based on the provided media type
            return mediaType switch
            {
                // For XML media type, create StringContent with XML media type
                MediaTypeNames.Text.Xml => new StringContent(body, encoding, MediaTypeNames.Text.Xml),

                // For JSON media type, create StringContent with JSON media type
                MediaTypeNames.Application.Json => new StringContent(body, encoding, MediaTypeNames.Application.Json),

                // For plain text media type, create StringContent with plain text media type
                MediaTypeNames.Text.Plain => new StringContent(body, encoding, MediaTypeNames.Text.Plain),

                // For form URL-encoded media type, create FormUrlEncodedContent from the fields
                MediaTypeNames.Application.FormUrlEncoded => new FormUrlEncodedContent(fields),

                // For 'x-www-form-urlencoded', create FormUrlEncodedContent from the fields
                "x-www-form-urlencoded" => new FormUrlEncodedContent(fields),

                // Default to null
                _ => null
            };
        }
        #endregion

        #region *** Methods: Private   ***
        // Retrieves and parses header data from plugin arguments.
        private static Dictionary<string, string> FormatFields(string fieldName, PluginDataModel pluginData)
        {
            // Define regular expression options for parsing.
            const RegexOptions Options = RegexOptions.Singleline | RegexOptions.IgnoreCase;

            // Retrieve the JSON representation of fields from plugin data.
            var fieldsJson = pluginData.Parameters.Get(key: fieldName, defaultValue: "[]").Trim();

            // Deserialize the JSON into an array of strings.
            var fieldsData = Regex.IsMatch(input: fieldsJson, pattern: @"^\[(.*)\]$", RegexOptions.Singleline)
                ? JsonSerializer.Deserialize<string[]>(fieldsJson)
                : [fieldsJson];

            // Initialize a list to store header name-value pairs.
            var fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Iterate through the field data.
            foreach (var headerData in fieldsData)
            {
                // Split the field data into name and value.
                var header = Regex.Match(input: headerData, pattern: "^([^=]+)", Options).Value.Trim();
                var value = Regex.Match(input: headerData, pattern: "(?<==).*", Options).Value.Trim();

                // Skip empty or malformed entries.
                if (!string.IsNullOrEmpty(header))
                {
                    fields[header] = value;
                }
            }

            // Return the parsed header name-value pairs.
            return fields;
        }

        // Extracts data from a JSON string based on a JSON path defined in the provided rule.
        private static string GetJsonData(PluginBase plugin, string json, G4RuleModelBase rule)
        {
            try
            {
                // Parse the JSON string and select the token based on the JSON path from the provided rule.
                var token = Newtonsoft.Json.Linq.JObject.Parse(json);

                // Select and convert the JSON data based on the provided JSON path defined in the rule.
                return $"{token.SelectToken(rule.OnElement)}";
            }
            catch (Exception e)
            {
                // Log any exceptions with a descriptive message using a logger.
                plugin.Logger.LogError(
                    exception: e,
                    message: "An exception occurred while processing JSON data.");
            }

            // Return an empty string if an error occurs during processing.
            return string.Empty;
        }

        // Extracts data from an XML string based on an XML element or attribute defined in the provided rule.
        private static string GetXmlData(PluginBase plugin, string xml, G4RuleModelBase rule)
        {
            try
            {
                // Parse the XML string into an XDocument.
                var document = XDocument.Parse(xml);

                // Check if an attribute is specified in the rule, and select the attribute value if it exists.
                return !string.IsNullOrEmpty(rule.OnAttribute)
                    ? document.XPathSelectElement(rule.OnElement).Attribute(rule.OnAttribute).Value
                    : $"{document.XPathSelectElement(rule.OnElement)}";
            }
            catch (Exception e)
            {
                // Log any exceptions with a descriptive message using a logger.
                plugin.Logger.LogError(
                    exception: e,
                    message: "An exception occurred while processing XML data.");
            }

            // Return an empty string if an error occurs during processing.
            return string.Empty;
        }

        // Parses the authentication header value and returns an instance of AuthenticationHeaderValue.
        private static AuthenticationHeaderValue NewAuthenticationHeader(string headerValue)
        {
            // Define regular expression options to be used in the parsing.
            const RegexOptions Options = RegexOptions.Singleline | RegexOptions.IgnoreCase;

            // Extract the authentication schema from the header value.
            var schema = Regex.Match(headerValue, "^([^ ]+)", Options).Value.Trim();

            // Extract the value part of the header.
            var value = Regex.Match(headerValue, "(?<= ).*", Options).Value.Trim();

            if (schema.Equals("BASIC", StringComparison.OrdinalIgnoreCase))
            {
                // If the schema is "BASIC", convert the value to base64.
                value = value.ConvertToBase64();
            }

            // Create and return an AuthenticationHeaderValue with the parsed schema and value.
            return new AuthenticationHeaderValue(schema, value);
        }

        // Creates a new PluginResponseModel based on the provided plugin,
        // This method processes the HTTP response data, extracts relevant information, and stores it in session parameters
        // of the plugin context. It then returns a new plugin response with the processed data.
        private static PluginResponseModel NewPluginResponse(
            PluginBase plugin, PluginDataModel pluginData, HttpResponseMessage responseMessage, string input)
        {
            // Store the HTTP status code and processed response data in session parameters.
            plugin.Invoker.Context.SessionParameters["HttpStatusCode"] = (int)responseMessage.StatusCode;
            plugin.Invoker.Context.SessionParameters["HttpResponseHeaders"] = responseMessage.Headers.ToDictionary();
            plugin.Invoker.Context.SessionParameters["HttpResponse"] = Regex
                .Match(input, pattern: pluginData.Rule.RegularExpression)?
                .Value
                .ConvertToBase64() ?? string.Empty;

            // Return a new plugin response with the processed data.
            return plugin.NewPluginResponse();
        }
        #endregion
    }
}
