namespace G4.Plugins.Google.Models.Abstraction
{
    /// <summary>
    /// Interface containing additional response-properties which will be added to every schema type which is 
    /// a direct response to a request.
    /// </summary>
    internal interface IDirectResponseSchema
    {
        /// <summary>
        /// The e-tag of this response.
        /// </summary>
        /// <remarks>Will be set by the service deserialization method, or the by json response parser if implemented on service.</remarks>
        public string ETag { get; set; }
    }
}
