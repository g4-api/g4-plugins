/*
 * 
 * RESOURCES:
 * https://developers.google.com/workspace/gmail/api/reference/rest/v1/users.messages
 * https://developers.google.com/workspace/gmail/api/reference/rest/v1/users.labels
 */
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Gmail;

using System;
using System.Net.Http;

namespace G4.Plugins.Google.Clients
{
    /// <summary>
    /// Provides a client for accessing Gmail API functionality for an authenticated user.
    /// </summary>
    /// <param name="credentials">The credentials used to authenticate requests to the Gmail API.</param>
    internal class GmailClient(string credentials) : ClientBase(credentials)
    {
        // Store the credentials in a private readonly field to be used by the nested clients.
        private readonly string _credentials = credentials;

        /// <summary>
        /// Gets the client used to manage and interact with labels.
        /// </summary>
        public LabelsClient Labels => new(_credentials);

        /// <summary>
        /// Gets the client for sending and receiving messages.
        /// </summary>
        public MessagesClient Messages => new(_credentials);

        /// <summary>
        /// A client for interacting with the Gmail API's messages endpoints,
        /// allowing retrieval and management of Gmail messages for the authenticated user.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate with the Gmail API.</param>
        public class MessagesClient(string credentials) : ClientBase(credentials)
        {
            /// <summary>
            /// Retrieves a specific Gmail message for the authenticated user.
            /// </summary>
            /// <param name="id">The identifier of the Gmail message to retrieve.</param>
            /// <returns>A <see cref="MessageModel"/> representing the message returned by the Gmail API.</returns>
            public MessageModel Get(string id)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for retrieving the specified message.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages/{id}");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into MessageModel.
                return HttpClient.Send<MessageModel>(requestMessage);
            }

            /// <summary>
            /// Retrieves a page of Gmail messages for the authenticated user using the specified query parameters.
            /// </summary>
            /// <param name="query">Query parameters used to filter, page, or shape the returned message list.</param>
            /// <returns>A <see cref="ListMessagesResponseModel"/> containing the messages returned by the Gmail API.</returns>
            public ListMessagesResponseModel Get(ListMessagesRequestModel query)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Convert the query model into URL query parameters when provided.
                var queryParameters = query?.ConvertToQueryParameters() ?? string.Empty;

                // Build the Gmail API endpoint for retrieving messages with optional query parameters.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages{queryParameters}");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into MessageListModel.
                return HttpClient.Send<ListMessagesResponseModel>(requestMessage);
            }

            /// <summary>
            /// Retrieves a page of Gmail messages for the authenticated user.
            /// </summary>
            /// <returns>A <see cref="ListMessagesResponseModel"/> containing the messages returned by the Gmail API.</returns>
            public ListMessagesResponseModel Get()
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for retrieving messages.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into MessageListModel.
                return HttpClient.Send<ListMessagesResponseModel>(requestMessage);
            }

            /// <summary>
            /// Sends the specified message to the recipients in the To, Cc, and Bcc headers.
            /// </summary>
            /// <param name="message">The message to send.</param>
            /// <returns>A <see cref="MessageModel"/> representing the sent message returned by the Gmail API.</returns>
            public MessageModel Send(MessageModel message)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for sending a message.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages/send");
                
                // Create the HTTP POST request with the authorization header and request body.
                var requestMessage = NewRequest(
                    HttpMethod.Post,
                    requestUri,
                    token,
                    requestBody: message);
                
                // Send the request and deserialize the JSON response into MessageModel.
                return HttpClient.Send<MessageModel>(requestMessage);
            }

            /// <summary>
            /// Modifies the labels on the specified message.
            /// </summary>
            /// <param name="id">The ID of the message to modify.</param>
            /// <returns>A <see cref="MessageModel"/> representing the message returned by the Gmail API.</returns>
            public MessageModel UpdateMessageLabels(string id, ModifyMessageRequestModel request)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for modifying the labels on the specified message.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages/{id}/modify");

                // Create the HTTP POST request with the authorization header and request body.
                var requestMessage = NewRequest(HttpMethod.Post, requestUri, token, requestBody: request);

                // Send the request and deserialize the JSON response into MessageModel.
                return HttpClient.Send<MessageModel>(requestMessage);
            }
        }

        /// <summary>
        /// A client for interacting with the Gmail API's labels endpoints,
        /// allowing retrieval and management of Gmail labels for the authenticated user.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate with the Gmail API.</param>
        public class LabelsClient(string credentials) : ClientBase(credentials)
        {
            /// <summary>
            /// Retrieves all Gmail labels for the authenticated user.
            /// </summary>
            /// <returns>A <see cref="ListLabelsResponseModel"/> representing the labels returned by the Gmail API.</returns>
            public ListLabelsResponseModel Get()
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for retrieving all labels.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/labels");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into LabelsResponseModel.
                return HttpClient.Send<ListLabelsResponseModel>(requestMessage);
            }

            /// <summary>
            /// Retrieves a specific Gmail label for the authenticated user.
            /// </summary>
            /// <param name="id">The identifier of the Gmail label to retrieve.</param>
            /// <returns>A <see cref="LabelModel"/> representing the label returned by the Gmail API.</returns>
            public LabelModel Get(string id)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for retrieving the specified label.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/labels/{id}");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into LabelModel.
                return HttpClient.Send<LabelModel>(requestMessage);
            }

            /// <summary>
            /// Creates a new Gmail label for the authenticated user.
            /// </summary>
            /// <param name="label">The label to create.</param>
            /// <returns>A <see cref="LabelModel"/> representing the label returned by the Gmail API.</returns>
            public LabelModel New(LabelModel label)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for creating a new label.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/labels");

                // Create the HTTP POST request with the authorization header and request body.
                var requestMessage = NewRequest(HttpMethod.Post, requestUri, token, requestBody: label);

                // Send the request and deserialize the JSON response into LabelModel.
                return HttpClient.Send<LabelModel>(requestMessage);
            }

            /// <summary>
            /// Deletes a specific Gmail label for the authenticated user.
            /// </summary>
            /// <param name="id">The identifier of the Gmail label to delete.</param>
            /// <returns>An <see cref="HttpResponseMessage"/> representing the response from the Gmail API.</returns>
            public HttpResponseMessage Remove(string id)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for deleting the specified label.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/labels/{id}");

                // Create the HTTP DELETE request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Delete, requestUri, token);

                // Send the request and return the HTTP response.
                return HttpClient.Send(requestMessage);
            }

            /// <summary>
            /// Updates an existing Gmail label for the authenticated user.
            /// </summary>
            /// <param name="id">The identifier of the Gmail label to update.</param>
            /// <param name="label">The label data to update.</param>
            /// <returns>A <see cref="LabelModel"/> representing the updated label returned by the Gmail API.</returns>
            public LabelModel Update(string id, LabelModel label)
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for updating the specified label.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/labels/{id}");

                // Create the HTTP PATCH request with the authorization header and request body.
                var requestMessage = NewRequest(HttpMethod.Patch, requestUri, token, requestBody: label);

                // Send the request and deserialize the JSON response into LabelModel.
                return HttpClient.Send<LabelModel>(requestMessage);
            }
        }
    }
}
