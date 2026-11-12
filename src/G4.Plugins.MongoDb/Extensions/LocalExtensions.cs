using G4.Cache;
using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Models;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace G4.Plugins.MongoDb.Extensions
{
    /// <summary>
    /// Provides the argument resolution and response shaping shared by the MongoDB plugins.
    /// </summary>
    /// <remarks>
    /// Every plugin reads its connection, payloads, and switches through these members, so one argument contract
    /// applies to the whole suite and each plugin stays focused on its own MongoDB operation.
    /// </remarks>
    internal static class LocalExtensions
    {
        #region *** Methods      ***
        extension(PluginDataModel pluginData)
        {
            /// <summary>
            /// Resolves the command timeout, in seconds, from the <c>CommandTimeout</c> argument.
            /// </summary>
            /// <remarks>
            /// Falls back to <see cref="MongoDbClient.DefaultCommandTimeoutSeconds"/> when the argument is missing or
            /// not a non-negative number. The value <c>0</c> means no timeout.
            /// </remarks>
            /// <returns>The command timeout in seconds.</returns>
            public int ResolveCommandTimeout()
            {
                // Read the timeout as text so malformed values fall back instead of failing the step.
                var value = pluginData.Parameters.Get(key: "CommandTimeout", defaultValue: string.Empty);

                // Parse the text so a missing, malformed, or negative value selects the default timeout.
                return ConvertToNonNegativeInteger(value, defaultValue: MongoDbClient.DefaultCommandTimeoutSeconds);
            }

            /// <summary>
            /// Resolves the primary JSON payload of the step from <c>CommandText</c> or <c>CommandFile</c>.
            /// </summary>
            /// <remarks>
            /// <para>
            /// <c>CommandText</c> wins when both are set. The sequences <c> --</c> and <c>}}</c> end an inline argument
            /// value, so a payload that contains them travels either Base64-encoded in <c>CommandText</c> with the
            /// <c>Base64</c> switch set, or in the UTF-8 file named by <c>CommandFile</c>.
            /// </para>
            /// <para>
            /// The <c>Base64</c> switch decodes only <c>CommandText</c>, as UTF-8; <c>CommandFile</c> content is
            /// always read as plain text. Invalid Base64 fails the step, so encoded text never reaches the server.
            /// </para>
            /// </remarks>
            /// <returns>The payload text; empty when the step sets neither argument.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the <c>Base64</c> switch is set and <c>CommandText</c> is not valid Base64.
            /// </exception>
            /// <exception cref="FileNotFoundException">
            /// Thrown when <c>CommandFile</c> points to a missing file.
            /// </exception>
            public string ResolveCommandText()
            {
                // Route through the shared payload resolver so both payload arguments follow one contract.
                return pluginData.ResolvePayload(
                    inlineName: "CommandText",
                    fileName: "CommandFile",
                    switchName: "Base64");
            }

            /// <summary>
            /// Resolves the secondary JSON payload of the step from <c>Document</c> or <c>DocumentFile</c>.
            /// </summary>
            /// <remarks>
            /// Follows the same contract as <see cref="ResolveCommandText()"/>, with the <c>DocumentBase64</c>
            /// switch in place of <c>Base64</c>. The document argument needs its own switch because an update
            /// document always ends in two closing braces, which end an inline argument value.
            /// </remarks>
            /// <returns>The payload text; empty when the step sets neither argument.</returns>
            public string ResolveDocumentText()
            {
                // Route through the shared payload resolver so both payload arguments follow one contract.
                return pluginData.ResolvePayload(
                    inlineName: "Document",
                    fileName: "DocumentFile",
                    switchName: "DocumentBase64");
            }

            /// <summary>
            /// Resolves one JSON payload from its inline argument, its file argument, and its Base64 switch.
            /// </summary>
            /// <remarks>
            /// The inline argument wins when both are set, the switch decodes only the inline value, and file
            /// content is always read as plain text.
            /// </remarks>
            /// <param name="inlineName">The inline argument name.</param>
            /// <param name="fileName">The file argument name.</param>
            /// <param name="switchName">The switch that marks the inline value as UTF-8 Base64.</param>
            /// <returns>The payload text; empty when the step sets neither argument.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the switch is set and the inline value is not valid Base64.
            /// </exception>
            /// <exception cref="FileNotFoundException">
            /// Thrown when the file argument points to a missing file.
            /// </exception>
            public string ResolvePayload(string inlineName, string fileName, string switchName)
            {
                // Prefer the inline text so a step can override a shared payload file.
                var inlineValue = pluginData.Parameters.Get(key: inlineName, defaultValue: string.Empty);

                // Return the inline text, decoding it first when the switch marks it as encoded, so a payload that
                // carries inline-argument terminators reaches the server exactly as authored.
                if (!string.IsNullOrWhiteSpace(inlineValue))
                {
                    var isBase64 = pluginData.TestSwitch(name: switchName);

                    return isBase64
                        ? ConvertFromBase64Payload(inlineValue, inlineName, switchName)
                        : inlineValue;
                }

                // Fall back to the payload file for JSON that cannot travel inside an inline argument; the switch
                // never applies here, so file content is always read as plain text.
                var file = pluginData.Parameters.Get(key: fileName, defaultValue: string.Empty);

                // Report an empty payload so each plugin decides whether its own payload is optional. A filter, for
                // example, is optional and then matches every document.
                return string.IsNullOrWhiteSpace(file)
                    ? string.Empty
                    : File.ReadAllText(path: file);
            }

            /// <summary>
            /// Resolves the connection settings from the step arguments.
            /// </summary>
            /// <remarks>
            /// See <see cref="ResolveConnection(string, string, IDictionary{string, string})"/> for the
            /// resolution order.
            /// </remarks>
            /// <returns>The resolved connection settings.</returns>
            public MongoDbConnectionModel ResolveConnection()
            {
                // Read the two baseline inputs and pass every argument as a potential override.
                var credentials = pluginData.Parameters.Get(key: "Credentials", defaultValue: string.Empty);
                var connectionString = pluginData.Parameters.Get(key: "ConnectionString", defaultValue: string.Empty);

                // Route through the shared resolver so the plugin path and the collector path use one order.
                return ResolveConnection(credentials, connectionString, overrides: pluginData.Parameters);
            }

            /// <summary>
            /// Resolves a JSON document argument, such as <c>Projection</c>, <c>Sort</c>, or <c>Document</c>.
            /// </summary>
            /// <remarks>
            /// A missing or blank argument yields an empty document, which the caller treats as "not set".
            /// </remarks>
            /// <param name="name">The argument name.</param>
            /// <returns>The parsed document.</returns>
            /// <exception cref="FormatException">Thrown when the argument is not a JSON object.</exception>
            public BsonDocument ResolveDocument(string name)
            {
                // Read the argument as text so the parser reports the argument by name on a shape error.
                var json = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                return MongoDbClient.ConvertToDocument(json, argumentName: name);
            }

            /// <summary>
            /// Resolves a non-negative integer argument, such as <c>Limit</c>, <c>Skip</c>, or <c>BatchSize</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <param name="defaultValue">The value used when the argument is missing or not a non-negative number.</param>
            /// <returns>The resolved value.</returns>
            public int ResolveInteger(string name, int defaultValue)
            {
                // Read the argument as text so malformed values fall back instead of failing the step.
                var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                return ConvertToNonNegativeInteger(value, defaultValue);
            }

            /// <summary>
            /// Resolves the maximum server-side execution time of one operation.
            /// </summary>
            /// <remarks>
            /// Returns <c>null</c> when the resolved command timeout is <c>0</c>, so the operation runs until the
            /// server completes it.
            /// </remarks>
            /// <returns>The maximum execution time, or <c>null</c> for no limit.</returns>
            public TimeSpan? ResolveMaxTime()
            {
                // Read the shared timeout so one argument bounds both the connection and the operation.
                var seconds = pluginData.ResolveCommandTimeout();

                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
            }

            /// <summary>
            /// Resolves a required text argument, such as <c>Collection</c> or <c>Operation</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <returns>The trimmed argument value.</returns>
            /// <exception cref="InvalidOperationException">Thrown when the argument is missing or blank.</exception>
            public string ResolveRequired(string name)
            {
                // Read the argument and reject an empty value so the failure names the missing argument.
                var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException($"The '{name}' argument is required.");
                }

                return value.Trim();
            }

            /// <summary>
            /// Tests whether the step requests one of its switches, such as <c>NoEntity</c> or <c>Transaction</c>.
            /// </summary>
            /// <param name="name">The switch name.</param>
            /// <returns><c>true</c> when the switch is present; otherwise <c>false</c>.</returns>
            public bool TestSwitch(string name)
            {
                // A switch carries no value; its presence alone turns it on.
                return pluginData.Parameters.ContainsKey(key: name);
            }
        }

        extension(PluginBase plugin)
        {
            /// <summary>
            /// Creates the plugin response and publishes the outputs as session parameters and, unless suppressed, as
            /// the response entity.
            /// </summary>
            /// <remarks>
            /// Each output is stored as the session parameter <c>{nameReference}:{name}</c>, Base64-encoded by
            /// <c>AddSessionParameter</c>. The entity carries the same names, unqualified and in plain text, for ETL
            /// and direct data transfer; <paramref name="noEntity"/> omits it.
            /// </remarks>
            /// <param name="nameReference">The plugin key used as the session parameter namespace.</param>
            /// <param name="outputs">The output names and their text values.</param>
            /// <param name="noEntity"><c>true</c> to omit the response entity.</param>
            /// <returns>The plugin response.</returns>
            public PluginResponseModel NewMongoDbResponse(
                string nameReference,
                IDictionary<string, string> outputs,
                bool noEntity)
            {
                // Publish every output to the session so later steps read it through the namespaced parameter.
                foreach (var output in outputs)
                {
                    plugin.AddSessionParameter(@namespace: nameReference, name: output.Key, value: output.Value);
                }

                // Create the response and attach the entity unless the step suppressed it.
                var response = plugin.NewPluginResponse();

                if (!noEntity)
                {
                    response.Entity = outputs.ToDictionary(i => i.Key, i => (object)i.Value);
                }

                return response;
            }
        }

        /// <summary>
        /// Converts an argument text into a non-negative integer, such as a port, a timeout, or a batch size.
        /// </summary>
        /// <remarks>
        /// Step arguments arrive as text, so the value is parsed with the invariant culture instead of being read as a
        /// typed value. A missing, malformed, or negative value returns <paramref name="defaultValue"/>, so a bad
        /// argument never fails the step.
        /// </remarks>
        /// <param name="value">The argument text to parse.</param>
        /// <param name="defaultValue">The value returned when the text is not a non-negative integer.</param>
        /// <returns>The parsed non-negative integer, or <paramref name="defaultValue"/>.</returns>
        public static int ConvertToNonNegativeInteger(string value, int defaultValue)
        {
            // Parse the text with the invariant culture so the result never depends on the host locale.
            var isNumber = int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var number);
            var isValid = isNumber && number >= 0;

            // Select the parsed value only when it is usable, so a bad value falls back instead of failing.
            return isValid ? number : defaultValue;
        }

        /// <summary>
        /// Starts a client session with an open transaction when the step requests one.
        /// </summary>
        /// <remarks>
        /// MongoDB supports multi-document transactions only on a replica set or a sharded cluster, so a standalone
        /// server fails here with a message that names the requirement. The caller owns and disposes the session.
        /// </remarks>
        /// <param name="client">The open client.</param>
        /// <param name="isTransaction"><c>true</c> to start a transaction.</param>
        /// <returns>The session with an open transaction, or <c>null</c> when none was requested.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the deployment does not support transactions.
        /// </exception>
        public static IClientSessionHandle NewTransaction(IMongoClient client, bool isTransaction)
        {
            // Return no session when the step runs without a transaction, so every operation stays unsessioned.
            if (!isTransaction)
            {
                return null;
            }

            // Start the session first; it is cheap and local, so only the transaction below can fail on topology.
            var session = client.StartSession();

            try
            {
                // Open the transaction so a failing operation leaves no partial change.
                session.StartTransaction();

                return session;
            }
            catch (NotSupportedException exception)
            {
                // Release the session and name the deployment requirement, which the driver message only implies.
                session.Dispose();

                var message = "The 'Transaction' switch requires a replica set or a sharded cluster; the connected " +
                    "deployment is standalone.";
                throw new InvalidOperationException(message, exception);
            }
            catch
            {
                // Release the session on every other failure so a failed step never leaks it.
                session.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Resolves the connection settings from a credentials value, a connection string, and discrete overrides.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The baseline comes from <paramref name="credentials"/> first: a matching MongoDB credentials record
        /// supplies its connection; an unmatched value that carries a URI scheme is a raw connection URI, and any
        /// other unmatched value fails the step, because it names a record that does not exist. Without credentials,
        /// the baseline is <paramref name="connectionString"/>.
        /// </para>
        /// <para>
        /// The discrete overrides (<c>Host</c>, <c>Port</c>, <c>Database</c>, <c>ReplicaSet</c>, <c>Username</c>,
        /// <c>Password</c>, <c>AuthenticationDatabase</c>, <c>AuthenticationMechanism</c>, <c>Tls</c>, and the
        /// <c>AllowInvalidCertificates</c> and <c>DirectConnection</c> switches) replace the baseline values they set,
        /// so one stored login can target several databases.
        /// </para>
        /// </remarks>
        /// <param name="credentials">The credentials name, identifier, or raw connection URI.</param>
        /// <param name="connectionString">The connection URI used when no credentials are set.</param>
        /// <param name="overrides">
        /// The step arguments that hold the discrete overrides and the <c>CommandTimeout</c> value; <c>null</c> for
        /// the collector path, which carries no step arguments and therefore uses the default timeout.
        /// </param>
        /// <returns>The resolved connection settings.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no host is resolved, or when the credentials value names no record.
        /// </exception>
        public static MongoDbConnectionModel ResolveConnection(
            string credentials,
            string connectionString,
            IDictionary<string, string> overrides)
        {
            // Normalize the overrides so the collector path, which has no step arguments, shares this resolver.
            overrides ??= new Dictionary<string, string>();

            // Read the timeout from the same arguments, so the resolver keeps one input for every step value.
            var commandTimeoutSeconds = ConvertToNonNegativeInteger(
                value: overrides.Get(key: "CommandTimeout", defaultValue: string.Empty),
                defaultValue: MongoDbClient.DefaultCommandTimeoutSeconds);

            // Look up the credentials value as a stored record first, so a record name never reaches the driver.
            var credential = FindCredential(idOrName: credentials);
            var hasCredentials = !string.IsNullOrWhiteSpace(credentials);
            var isRawUri = hasCredentials && credentials.Contains("://", StringComparison.Ordinal);

            // Resolve the baseline: record, raw URI, then the plain connection string.
            MongoUrlBuilder builder;

            if (credential is not null)
            {
                builder = NewUrlBuilder(credential);
            }
            else if (isRawUri)
            {
                builder = new MongoUrlBuilder(url: credentials);
            }
            else if (hasCredentials)
            {
                // Reject an unmatched value that is not a URI, so a typed record name never reads as a host name.
                var message = $"No MongoDB credentials record matches '{credentials}'. Pass a stored record name or " +
                    "identifier, or a connection URI.";
                throw new InvalidOperationException(message);
            }
            else
            {
                builder = string.IsNullOrWhiteSpace(connectionString)
                    ? new MongoUrlBuilder()
                    : new MongoUrlBuilder(connectionString);
            }

            // Apply the discrete overrides on top of the baseline; unset overrides leave the baseline untouched.
            var options = new ConnectionPartsOptions
            {
                AllowInvalidCertificates = overrides.ContainsKey(key: "AllowInvalidCertificates"),
                AuthenticationDatabase = overrides.Get(key: "AuthenticationDatabase", defaultValue: string.Empty),
                AuthenticationMechanism = overrides.Get(key: "AuthenticationMechanism", defaultValue: string.Empty),
                Database = overrides.Get(key: "Database", defaultValue: string.Empty),
                DirectConnection = overrides.ContainsKey(key: "DirectConnection"),
                Host = overrides.Get(key: "Host", defaultValue: string.Empty),
                Password = overrides.Get(key: "Password", defaultValue: string.Empty),
                Port = ConvertToNonNegativeInteger(
                    value: overrides.Get(key: "Port", defaultValue: string.Empty),
                    defaultValue: 0),
                ReplicaSet = overrides.Get(key: "ReplicaSet", defaultValue: string.Empty),
                Tls = overrides.Get(key: "Tls", defaultValue: string.Empty),
                Username = overrides.Get(key: "Username", defaultValue: string.Empty)
            };

            SetConnectionParts(builder, options);

            // Require an explicit target, because the driver defaults an empty builder to localhost. A step that
            // names no deployment is a configuration error, not a connection to the test machine.
            var hasTarget = credential is not null
                || isRawUri
                || !string.IsNullOrWhiteSpace(connectionString)
                || !string.IsNullOrWhiteSpace(options.Host);

            if (!hasTarget)
            {
                var message = "No MongoDB target was resolved. Set 'Credentials', 'ConnectionString', or 'Host'.";
                throw new InvalidOperationException(message);
            }

            // Bound connecting and server selection by the command timeout, so an unreachable host fails on time.
            if (commandTimeoutSeconds > 0)
            {
                var timeout = TimeSpan.FromSeconds(commandTimeoutSeconds);

                builder.ConnectTimeout = timeout;
                builder.ServerSelectionTimeout = timeout;
            }

            // Return the resolved settings; they live only for the calling step and are never cached.
            return new MongoDbConnectionModel
            {
                ClientSettings = MongoClientSettings.FromUrl(url: builder.ToMongoUrl()),
                CommandTimeoutSeconds = commandTimeoutSeconds,
                Database = builder.DatabaseName ?? string.Empty
            };
        }

        // Decodes a Base64-encoded payload as UTF-8. Unlike the engine ConvertFromBase64, which returns the input
        // unchanged on a decoding failure, invalid Base64 throws, so encoded text never reaches the server.
        private static string ConvertFromBase64Payload(string value, string inlineName, string switchName)
        {
            // Size the buffer for the largest possible decoded payload, then decode the trimmed text without throwing
            // so surrounding whitespace is tolerated and bad input reaches the explicit failure below.
            var buffer = new byte[value.Length];
            var encodedText = value.Trim();
            var isDecoded = Convert.TryFromBase64String(s: encodedText, bytes: buffer, bytesWritten: out var length);

            // Reject invalid input with a message that names the argument and the switch that caused the decode.
            if (!isDecoded)
            {
                var message = $"'{inlineName}' is not valid Base64. Encode the payload as UTF-8 Base64 or remove " +
                    $"the '{switchName}' switch.";
                throw new InvalidOperationException(message);
            }

            // Return only the written bytes as UTF-8 text so the unused buffer tail never reaches the command.
            return Encoding.UTF8.GetString(bytes: buffer, index: 0, count: length);
        }

        // Finds the MongoDB credentials record whose id or name matches the value, reading only the MongoDB partition
        // of the engine credentials cache. The id wins over the name, both compared case-insensitively. Returns null
        // for an empty value or no match, so the caller treats the value as raw credentials input.
        private static MongoDbCredentialModel FindCredential(string idOrName)
        {
            // Report no match for an empty value so the caller falls back to the raw credentials input.
            if (string.IsNullOrWhiteSpace(idOrName))
            {
                return null;
            }

            // Read the MongoDB partition; a missing partition means no MongoDB record is cached.
            var isCached = CacheManager.Instance.CredentialsCache.TryGetValue(
                key: MongoDbCredentialTypes.MongoDb,
                value: out var partition);

            if (!isCached)
            {
                return null;
            }

            // Narrow the partition to MongoDB records and match the id first, then the name.
            var credentials = partition.Values.OfType<MongoDbCredentialModel>().ToArray();

            return credentials.FirstOrDefault(i => string.Equals(i.Id, idOrName, StringComparison.OrdinalIgnoreCase))
                ?? credentials.FirstOrDefault(i => string.Equals(i.Name, idOrName, StringComparison.OrdinalIgnoreCase));
        }

        // Creates a URL builder from a credentials record: the record connection URI is the baseline and the record
        // discrete parts that are set override it. Compute-only: the record is read, never mutated, and the returned
        // builder is owned by the caller.
        private static MongoUrlBuilder NewUrlBuilder(MongoDbCredentialModel credential)
        {
            // Start from the stored URI when present so complex options survive.
            var connectionString = credential.ConnectionString ?? string.Empty;

            var builder = string.IsNullOrWhiteSpace(connectionString)
                ? new MongoUrlBuilder()
                : new MongoUrlBuilder(connectionString);

            // Apply the stored discrete parts on top of the stored URI.
            var options = new ConnectionPartsOptions
            {
                AllowInvalidCertificates = credential.AllowInvalidCertificates,
                AuthenticationDatabase = credential.AuthenticationDatabase,
                AuthenticationMechanism = credential.AuthenticationMechanism,
                Database = credential.Database,
                DirectConnection = credential.DirectConnection,
                Host = credential.Host,
                Password = credential.Password,
                Port = credential.Port,
                ReplicaSet = credential.ReplicaSet,
                Tls = credential.Tls,
                Username = credential.Username
            };

            SetConnectionParts(builder, options);

            return builder;
        }

        // Applies the discrete connection parts that are set to the builder, leaving unset parts untouched so they
        // never erase baseline values. Mutates only the caller-owned builder. The TLS flags can only turn their
        // option on, matching the switch arguments that carry them.
        private static void SetConnectionParts(MongoUrlBuilder builder, ConnectionPartsOptions options)
        {
            // Compose the server address from the host and the optional port. A port without a host re-targets the
            // baseline host, replacing the port the baseline address already carries.
            var hasHost = !string.IsNullOrWhiteSpace(options.Host);
            var hasPort = options.Port > 0;
            var baselineServer = builder.Server ?? builder.Servers?.FirstOrDefault();
            var host = hasHost ? options.Host.Trim() : baselineServer?.Host;
            var isServerSet = !string.IsNullOrWhiteSpace(host) && (hasHost || hasPort);

            if (isServerSet)
            {
                // Keep the baseline port when only the host changes, so a stored port survives a host override.
                var port = hasPort
                    ? options.Port
                    : baselineServer?.Port ?? MongoDbClient.DefaultPort;

                builder.Server = new MongoServerAddress(host, port);
            }

            // Select the default database.
            if (!string.IsNullOrWhiteSpace(options.Database))
            {
                builder.DatabaseName = options.Database.Trim();
            }

            // Require the client to join a named replica set, which also enables transactions.
            if (!string.IsNullOrWhiteSpace(options.ReplicaSet))
            {
                builder.ReplicaSetName = options.ReplicaSet.Trim();
            }

            // Apply the login. The user name alone is enough for a mechanism that needs no password, such as X.509.
            if (!string.IsNullOrWhiteSpace(options.Username))
            {
                builder.Username = options.Username;
            }

            if (!string.IsNullOrEmpty(options.Password))
            {
                builder.Password = options.Password;
            }

            // Select where the user record lives and how the driver proves the identity.
            if (!string.IsNullOrWhiteSpace(options.AuthenticationDatabase))
            {
                builder.AuthenticationSource = options.AuthenticationDatabase.Trim();
            }

            if (!string.IsNullOrWhiteSpace(options.AuthenticationMechanism))
            {
                builder.AuthenticationMechanism = options.AuthenticationMechanism.Trim();
            }

            // Apply the transport encryption mode, which states explicitly what the URI scheme only implies.
            var isTlsEnabled = string.Equals(options.Tls, MongoDbTlsModes.Enabled, StringComparison.OrdinalIgnoreCase);
            var isTlsDisabled = string.Equals(
                options.Tls,
                MongoDbTlsModes.Disabled,
                StringComparison.OrdinalIgnoreCase);

            if (isTlsEnabled || isTlsDisabled)
            {
                builder.UseTls = isTlsEnabled;
            }

            // Trust an unverifiable server certificate only when requested, so an unset flag keeps the baseline.
            if (options.AllowInvalidCertificates)
            {
                builder.AllowInsecureTls = true;
            }

            // Address the named host directly only when requested, so topology discovery stays the default.
            if (options.DirectConnection)
            {
                builder.DirectConnection = true;
            }
        }
        #endregion

        #region *** Nested Types ***
        // Carries the discrete connection parts applied on top of a connection baseline, either from the step
        // arguments or from a stored credentials record. Empty strings, a zero port, and a false flag mean "not set".
        private sealed class ConnectionPartsOptions
        {
            /// <summary>
            /// Gets or sets a value indicating whether to accept an unverifiable server certificate; <c>false</c>
            /// keeps the baseline.
            /// </summary>
            public bool AllowInvalidCertificates { get; set; }

            /// <summary>
            /// Gets or sets the database that holds the user record; empty keeps the baseline source.
            /// </summary>
            public string AuthenticationDatabase { get; set; }

            /// <summary>
            /// Gets or sets the authentication mechanism; empty keeps the baseline mechanism.
            /// </summary>
            public string AuthenticationMechanism { get; set; }

            /// <summary>
            /// Gets or sets the default database; empty keeps the baseline database.
            /// </summary>
            public string Database { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether to connect directly to the host; <c>false</c> keeps the
            /// baseline.
            /// </summary>
            public bool DirectConnection { get; set; }

            /// <summary>
            /// Gets or sets the host; empty keeps the baseline host.
            /// </summary>
            public string Host { get; set; }

            /// <summary>
            /// Gets or sets the login password; empty keeps the baseline password.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets the TCP port; <c>0</c> keeps the baseline port unless a host is set.
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// Gets or sets the required replica set name; empty keeps the baseline topology.
            /// </summary>
            public string ReplicaSet { get; set; }

            /// <summary>
            /// Gets or sets the transport encryption mode; empty keeps the baseline mode.
            /// </summary>
            public string Tls { get; set; }

            /// <summary>
            /// Gets or sets the login name; empty keeps the baseline login.
            /// </summary>
            public string Username { get; set; }
        }
        #endregion
    }
}
