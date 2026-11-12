using G4.Credentials.Models;

namespace G4.Plugins.MongoDb.Models
{
    /*
     * TEMPORARY SHIM - REMOVE ON THE NEXT G4.CredentialsManager RELEASE
     *
     * The MongoDB credential type is implemented in the engine (G4.Credentials) but the package that carries it is
     * not released yet, so this file stands in for it and keeps the plugins buildable against the published packages.
     *
     * Replacement steps once G4.CredentialsManager and G4.Cache ship the MongoDB type:
     *   1. Delete this file.
     *   2. In Extensions/LocalExtensions.cs, drop the G4.Plugins.MongoDb.Models using for these types, which then
     *      resolve from G4.Credentials.Models, and read the cache partition with CredentialTypes.MongoDb instead of
     *      MongoDbCredentialTypes.MongoDb.
     *
     * The members below mirror the engine model exactly, so the swap is a namespace change and no plugin logic moves.
     * Records seeded by the tests use these types; records read from the engine cache use the engine types. Both
     * shapes satisfy the same resolution code, because the plugin reads the records through this contract only.
     */

    /// <summary>
    /// Stands in for the released MongoDB credential record until the engine package that carries it ships.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The record carries either a complete <see cref="ConnectionString"/> (a <c>mongodb://</c> or
    /// <c>mongodb+srv://</c> URI) or the discrete connection parts. When <see cref="ConnectionString"/> is set,
    /// consumers start from it and apply the discrete parts that are set as overrides; otherwise consumers compose the
    /// connection from the discrete parts alone.
    /// </para>
    /// <para>
    /// Mirrors <c>G4.Credentials.Models.MongoDbCredentialModel</c> member for member. See the file header for the
    /// replacement steps.
    /// </para>
    /// </remarks>
    internal sealed class MongoDbCredentialModel : CredentialModelBase
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets a value indicating whether the client accepts the server certificate without validating its
        /// trust chain.
        /// </summary>
        public bool AllowInvalidCertificates { get; set; }

        /// <summary>
        /// Gets or sets the database that holds the user record used to authenticate (the <c>authSource</c> option).
        /// </summary>
        public string AuthenticationDatabase { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the mechanism used to authenticate with the server (the <c>authMechanism</c> option).
        /// </summary>
        public string AuthenticationMechanism { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the complete MongoDB connection URI used as the connection baseline.
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <inheritdoc />
        public override string CredentialType => MongoDbCredentialTypes.MongoDb;

        /// <summary>
        /// Gets or sets the default database opened by the connection.
        /// </summary>
        public string Database { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the client connects to the named host directly instead of
        /// discovering the topology (the <c>directConnection</c> option).
        /// </summary>
        public bool DirectConnection { get; set; }

        /// <summary>
        /// Gets or sets the MongoDB host or network address.
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password used with password-based authentication mechanisms.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the TCP port of the MongoDB instance; <c>0</c> means the driver default port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the name of the replica set the client requires (the <c>replicaSet</c> option).
        /// </summary>
        public string ReplicaSet { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transport encryption mode negotiated with the server (the <c>tls</c> option).
        /// </summary>
        public string Tls { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the login name used with password-based or principal-based mechanisms.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        #endregion
    }

    /// <summary>
    /// Stands in for the released <c>CredentialTypes.MongoDb</c> value until the engine package that carries it ships.
    /// </summary>
    internal static class MongoDbCredentialTypes
    {
        #region *** Constants    ***
        /// <summary>
        /// Identifies MongoDB connection and sign-in credentials, and names their credentials cache partition.
        /// </summary>
        public const string MongoDb = "MongoDb";
        #endregion
    }

    /// <summary>
    /// Stands in for the released <c>MongoDbAuthenticationMechanisms</c> values until the engine package ships.
    /// </summary>
    /// <remarks>
    /// The values match the <c>authMechanism</c> connection-string option values of the MongoDB drivers, so consumers
    /// can pass them to the driver unchanged.
    /// </remarks>
    internal static class MongoDbAuthenticationMechanisms
    {
        #region *** Constants    ***
        /// <summary>
        /// Signs in with a Kerberos principal.
        /// </summary>
        public const string Gssapi = "GSSAPI";

        /// <summary>
        /// Signs in with AWS Identity and Access Management credentials.
        /// </summary>
        public const string MongoDbAws = "MONGODB-AWS";

        /// <summary>
        /// Signs in with an OpenID Connect access token, such as a workload or workforce identity token.
        /// </summary>
        public const string MongoDbOidc = "MONGODB-OIDC";

        /// <summary>
        /// Signs in with the client TLS certificate instead of a password.
        /// </summary>
        public const string MongoDbX509 = "MONGODB-X509";

        /// <summary>
        /// Signs in through an external LDAP or operating-system directory in plain text over TLS.
        /// </summary>
        public const string Plain = "PLAIN";

        /// <summary>
        /// Signs in with a user name and password over SCRAM using SHA-1, for servers older than 4.0.
        /// </summary>
        public const string ScramSha1 = "SCRAM-SHA-1";

        /// <summary>
        /// Signs in with a user name and password over SCRAM using SHA-256, the modern default.
        /// </summary>
        public const string ScramSha256 = "SCRAM-SHA-256";
        #endregion
    }

    /// <summary>
    /// Stands in for the released <c>MongoDbTlsModes</c> values until the engine package ships.
    /// </summary>
    internal static class MongoDbTlsModes
    {
        #region *** Constants    ***
        /// <summary>
        /// Connects without TLS, which suits a loopback or private-network deployment.
        /// </summary>
        public const string Disabled = "Disabled";

        /// <summary>
        /// Requires TLS encryption for the connection.
        /// </summary>
        public const string Enabled = "Enabled";
        #endregion
    }
}
