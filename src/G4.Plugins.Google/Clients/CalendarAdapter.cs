/*
 * RESOURCES:
 * https://developers.google.com/workspace/calendar/api/v3/reference
 */
using G4.Plugins.Google.Extensions;
using G4.Plugins.Google.Models.Calendar;

using System;
using System.Net.Http;

namespace G4.Plugins.Google.Clients
{
    /// <summary>
    /// Provides access to Google Calendar API calendar list operations using the supplied OAuth credentials.
    /// </summary>
    /// <param name="credentials">
    /// The serialized credentials payload used to authenticate requests against the Google Calendar API.
    /// </param>
    internal class CalendarAdapter(string credentials)
    {
        #region *** Fields       ***
        /// <summary>
        /// Stores the credentials used by child API clients created by this adapter.
        /// </summary>
        private readonly string _credentials = credentials;
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the client responsible for working with the authenticated user's calendar list.
        /// </summary>
        public CalendarListClient CalendarList => new(_credentials);
        #endregion
        
        #region *** Nested Types ***
        /// <summary>
        /// Handles requests related to the authenticated user's calendar list.
        /// </summary>
        /// <param name="credentials">The serialized credentials payload used to authenticate API requests.</param>
        public class CalendarListClient(string credentials) : ClientBase(credentials)
        {
            /// <summary>
            /// Retrieves the authenticated user's calendar list using the default request options.
            /// </summary>
            /// <returns>A <see cref="CalendarListModel"/> containing the calendars visible to the authenticated user.</returns>
            public CalendarListModel Get()
            {
                // Delegate to the overload that accepts request options, using the API defaults.
                return Get(options: default);
            }

            /// <summary>
            /// Retrieves the authenticated user's calendar list using the supplied request options.
            /// </summary>
            /// <param name="options">The optional request parameters used to filter, page, or shape the calendar list response.</param>
            /// <returns>A <see cref="CalendarListModel"/> containing the calendars returned by the Google Calendar API.</returns>
            public CalendarListModel Get(CalendarListRequestModel options)
            {
                // Extract the OAuth access token from the resolved credentials.
                var token = Credentials.AccessToken;

                // Convert the request options into a query string, or use an empty string when no options are provided.
                var queryParameters = options?.ConvertToQueryParameters() ?? string.Empty;

                // Build the Google Calendar API endpoint for the authenticated user's calendar list.
                var requestUri = new Uri(uriString: $"{CalendarBaseUrl}/users/me/calendarList{queryParameters}");

                // Create the authorized HTTP GET request message.
                var requestMessage = NewRequest(HttpMethod.Get, requestUri, token);

                // Send the request and deserialize the response body into the target model.
                return HttpClient.Send<CalendarListModel>(requestMessage);
            }
        }
        #endregion
    }
}
