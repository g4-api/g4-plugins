using MongoDB.Driver;

namespace G4.Plugins.MongoDb.Models
{
    /// <summary>
    /// Represents the resolved settings a MongoDB plugin uses to open one client.
    /// </summary>
    /// <remarks>
    /// The settings are produced from the step arguments (or the data collector rule) by merging a credentials record,
    /// raw credentials input, and discrete overrides. They live only for one plugin step and are never cached.
    /// </remarks>
    internal sealed class MongoDbConnectionModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets the resolved client settings, including the hosts, the credential, and the transport options.
        /// </summary>
        public MongoClientSettings ClientSettings { get; set; } = new();

        /// <summary>
        /// Gets or sets the command timeout, in seconds, applied to the server-side execution of one operation.
        /// </summary>
        /// <remarks>
        /// The value <c>0</c> means no timeout, so the operation runs until the server completes it.
        /// </remarks>
        public int CommandTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the name of the database the plugin operates on.
        /// </summary>
        /// <remarks>
        /// Empty when neither the credentials record, the connection string, nor the <c>Database</c> argument names a
        /// database, which fails the step before any operation runs.
        /// </remarks>
        public string Database { get; set; } = string.Empty;
        #endregion
    }
}
