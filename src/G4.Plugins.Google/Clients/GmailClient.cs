/*
 * 
 * RESOURCES:
 * https://developers.google.com/workspace/gmail/api/reference/rest/v1/users.messages
 */
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models;

using System;
using System.Net.Http;

namespace G4.Plugins.Google.Clients
{
    internal class GmailClient(string credentials) : ClientBase(credentials)
    {
        private readonly string _credentials = credentials;

        public MessagesClient Messages => new(_credentials);

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
            /// <returns>A <see cref="MessageListModel"/> containing the messages returned by the Gmail API.</returns>
            public MessageListModel Get(MessageListQueryModel query)
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
                return HttpClient.Send<MessageListModel>(requestMessage);
            }

            /// <summary>
            /// Retrieves a page of Gmail messages for the authenticated user.
            /// </summary>
            /// <returns>A <see cref="MessageListModel"/> containing the messages returned by the Gmail API.</returns>
            public MessageListModel Get()
            {
                // Extract the OAuth access token used to authorize the request.
                var token = Credentials.AccessToken;

                // Build the Gmail API endpoint for retrieving messages.
                var requestUri = new Uri($"{GmailBaseUri}/users/me/messages");

                // Create the HTTP GET request with the authorization header.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the JSON response into MessageListModel.
                return HttpClient.Send<MessageListModel>(requestMessage);
            }
        }
    }
}
