namespace G4.Plugins.SqlServer.Models
{
    /// <summary>
    /// Represents the resolved settings a SQL Server plugin uses to open one connection.
    /// </summary>
    /// <remarks>
    /// The settings are produced from the step arguments (or the data collector rule) by merging a credentials record,
    /// raw credentials input, and discrete overrides. They live only for one plugin step and are never cached.
    /// </remarks>
    internal sealed class SqlServerConnectionModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets the Microsoft Entra access token that authenticates the connection.
        /// </summary>
        /// <remarks>
        /// Empty when the connection string itself carries the authentication. When set, the connection string must
        /// not carry a password or an <c>Authentication</c> keyword.
        /// </remarks>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the complete ADO.NET connection string.
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;
        #endregion
    }
}
