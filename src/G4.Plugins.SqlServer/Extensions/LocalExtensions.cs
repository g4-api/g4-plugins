using G4.Cache;
using G4.Credentials.Models;
using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Models;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace G4.Plugins.SqlServer.Extensions
{
    /// <summary>
    /// Provides the argument resolution and response shaping shared by the SQL Server plugins.
    /// </summary>
    /// <remarks>
    /// Every plugin reads its connection, command, parameters, and switches through these members, so one argument
    /// contract applies to the whole suite and each plugin stays focused on its own SQL operation.
    /// </remarks>
    internal static class LocalExtensions
    {
        #region *** Methods      ***
        extension(PluginDataModel pluginData)
        {
            /// <summary>
            /// Resolves the command text from the <c>CommandText</c> argument or the <c>CommandFile</c> argument.
            /// </summary>
            /// <remarks>
            /// <para>
            /// <c>CommandText</c> wins when both are set. The sequences <c> --</c> and <c>}}</c> end an inline argument
            /// value, so SQL that contains them travels either Base64-encoded in <c>CommandText</c> with the
            /// <c>Base64</c> switch set, or in the UTF-8 file named by <c>CommandFile</c>.
            /// </para>
            /// <para>
            /// The <c>Base64</c> switch decodes only <c>CommandText</c>, as UTF-8; <c>CommandFile</c> content is always
            /// read as plain text. Invalid Base64 fails the step, so encoded text never reaches the server as SQL.
            /// </para>
            /// </remarks>
            /// <returns>The command text.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when neither argument is set, or when the <c>Base64</c> switch is set and <c>CommandText</c> is
            /// not valid Base64.
            /// </exception>
            /// <exception cref="FileNotFoundException">
            /// Thrown when <c>CommandFile</c> points to a missing file.
            /// </exception>
            public string ResolveCommandText()
            {
                // Prefer the inline text so a step can override a shared script file.
                var commandText = pluginData.Parameters.Get(key: "CommandText", defaultValue: string.Empty);

                // Return the inline text, decoding it first when the Base64 switch marks it as encoded, so SQL that
                // carries inline-argument terminators reaches the server exactly as authored.
                if (!string.IsNullOrWhiteSpace(commandText))
                {
                    var isBase64 = pluginData.TestSwitch(name: "Base64");

                    return isBase64 ? ConvertFromBase64CommandText(commandText) : commandText;
                }

                // Fall back to the script file for SQL that cannot travel inside an inline argument; the Base64
                // switch never applies here, so file content is always read as plain text.
                var commandFile = pluginData.Parameters.Get(key: "CommandFile", defaultValue: string.Empty);

                // Reject a step that names no command source so the failure points at the missing argument.
                if (string.IsNullOrWhiteSpace(commandFile))
                {
                    throw new InvalidOperationException("Either 'CommandText' or 'CommandFile' is required.");
                }

                // Read the whole script so the caller receives the complete command text in one value.
                return File.ReadAllText(path: commandFile);
            }

            /// <summary>
            /// Resolves the command timeout, in seconds, from the <c>CommandTimeout</c> argument.
            /// </summary>
            /// <remarks>
            /// Falls back to <see cref="SqlServerClient.DefaultCommandTimeoutSeconds"/> when the argument is missing or
            /// not a non-negative number. The value <c>0</c> means no timeout.
            /// </remarks>
            /// <returns>The command timeout in seconds.</returns>
            public int ResolveCommandTimeout()
            {
                // Read the timeout as text so malformed values fall back instead of failing the step.
                var value = pluginData.Parameters.Get(key: "CommandTimeout", defaultValue: string.Empty);

                // Parse the text so a missing, malformed, or negative value selects the default timeout.
                return ConvertToNonNegativeInteger(value, defaultValue: SqlServerClient.DefaultCommandTimeoutSeconds);
            }

            /// <summary>
            /// Resolves the connection settings from the step arguments.
            /// </summary>
            /// <remarks>
            /// See <see cref="ResolveConnection(string, string, IDictionary{string, string})"/> for the resolution
            /// order.
            /// </remarks>
            /// <returns>The resolved connection settings.</returns>
            public SqlServerConnectionModel ResolveConnection()
            {
                // Read the two baseline inputs and pass every argument as a potential override.
                var credentials = pluginData.Parameters.Get(key: "Credentials", defaultValue: string.Empty);
                var connectionString = pluginData.Parameters.Get(key: "ConnectionString", defaultValue: string.Empty);

                // Route through the shared resolver so the plugin path and the collector path use one order.
                return ResolveConnection(credentials, connectionString, overrides: pluginData.Parameters);
            }

            /// <summary>
            /// Resolves the SQL parameters bound to the command from the <c>Parameters</c> JSON object argument.
            /// </summary>
            /// <remarks>
            /// Each property becomes one parameter; a missing <c>@</c> prefix is added. Strings, booleans, and numbers
            /// keep their type (integers as <see cref="long"/>, other numbers as <see cref="decimal"/>), JSON null
            /// becomes <c>DBNull</c>, and objects or arrays are bound as their JSON text.
            /// </remarks>
            /// <returns>The parameters, empty when the argument is missing.</returns>
            /// <exception cref="FormatException">Thrown when the argument is not a JSON object.</exception>
            public IReadOnlyList<SqlParameter> ResolveSqlParameters()
            {
                // Treat a missing argument as no parameters so parameterless commands need no placeholder.
                var parametersJson = pluginData.Parameters.Get(key: "Parameters", defaultValue: string.Empty);

                if (string.IsNullOrWhiteSpace(parametersJson))
                {
                    return [];
                }

                // Parse the object once so a malformed payload fails before the command runs.
                using var document = JsonDocument.Parse(json: parametersJson);

                if (document.RootElement.ValueKind != JsonValueKind.Object)
                {
                    throw new FormatException("The 'Parameters' argument must be a JSON object.");
                }

                // Map each property to a typed SqlParameter so values are bound, never composed into the command.
                return [.. document
                    .RootElement
                    .EnumerateObject()
                    .Select(i => new SqlParameter(
                        parameterName: ConvertToParameterName(name: i.Name),
                        value: ConvertToParameterValue(element: i.Value)))];
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
            public PluginResponseModel NewSqlServerResponse(
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
        /// Converts a value for a SQL parameter name into its <c>@</c>-prefixed form.
        /// </summary>
        /// <param name="name">The parameter name, with or without the <c>@</c> prefix.</param>
        /// <returns>The prefixed parameter name.</returns>
        public static string ConvertToParameterName(string name)
        {
            // Add the prefix only when missing so both "Id" and "@Id" address the same placeholder.
            return name.StartsWith('@') ? name : $"@{name}";
        }

        /// <summary>
        /// Converts a JSON element into the CLR value bound to a SQL parameter.
        /// </summary>
        /// <param name="element">The JSON element.</param>
        /// <returns>The parameter value; <c>DBNull</c> for JSON null.</returns>
        public static object ConvertToParameterValue(JsonElement element)
        {
            // Map each JSON kind to the closest provider type so SQL Server performs the usual implicit conversions.
            return element.ValueKind switch
            {
                JsonValueKind.Null or JsonValueKind.Undefined => DBNull.Value,
                JsonValueKind.String => element.GetString(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Number when element.TryGetInt64(out var integer) => integer,
                JsonValueKind.Number => element.GetDecimal(),
                _ => element.GetRawText()
            };
        }

        /// <summary>
        /// Resolves the connection settings from a credentials value, a connection string, and discrete overrides.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The baseline comes from <paramref name="credentials"/> first: a matching SQL Server credentials record
        /// supplies its connection; an unmatched value that contains <c>=</c> is a raw connection string; any other
        /// unmatched value is a raw Microsoft Entra access token. Without credentials, the baseline is
        /// <paramref name="connectionString"/>. The <c>Token</c> override sets the access token explicitly.
        /// </para>
        /// <para>
        /// The discrete overrides (<c>Server</c>, <c>Port</c>, <c>Database</c>, <c>Authentication</c>, <c>Username</c>,
        /// <c>Password</c>, <c>Encrypt</c>, and the <c>TrustServerCertificate</c> switch) replace the baseline values
        /// they set, so one stored login can target several databases.
        /// </para>
        /// </remarks>
        /// <param name="credentials">
        /// The credentials name, identifier, raw connection string, or raw access token.
        /// </param>
        /// <param name="connectionString">The connection string used when no credentials are set.</param>
        /// <param name="overrides">The step arguments that hold the discrete overrides.</param>
        /// <returns>The resolved connection settings.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no server is resolved.</exception>
        public static SqlServerConnectionModel ResolveConnection(
            string credentials,
            string connectionString,
            IDictionary<string, string> overrides)
        {
            // Normalize the overrides so the collector path, which has no step arguments, shares this resolver.
            overrides ??= new Dictionary<string, string>();

            // Look up the credentials value as a stored record first, so a record name never reaches the provider.
            var builder = new SqlConnectionStringBuilder();
            var accessToken = overrides.Get(key: "Token", defaultValue: string.Empty);
            var credential = FindCredential(idOrName: credentials);
            var hasCredentials = !string.IsNullOrWhiteSpace(credentials);
            var isRawConnectionString = hasCredentials && credentials.Contains('=');

            // Resolve the baseline: record, raw connection string, raw access token, then the plain connection string.
            if (credential is not null)
            {
                builder = NewConnectionBuilder(credential);
            }
            else if (isRawConnectionString)
            {
                builder.ConnectionString = credentials;
            }
            else if (hasCredentials)
            {
                accessToken = credentials;
            }
            else if (!string.IsNullOrWhiteSpace(connectionString))
            {
                builder.ConnectionString = connectionString;
            }

            // Apply the discrete overrides on top of the baseline; unset overrides leave the baseline untouched.
            var options = new ConnectionPartsOptions
            {
                Authentication = overrides.Get(key: "Authentication", defaultValue: string.Empty),
                Database = overrides.Get(key: "Database", defaultValue: string.Empty),
                Encrypt = overrides.Get(key: "Encrypt", defaultValue: string.Empty),
                Password = overrides.Get(key: "Password", defaultValue: string.Empty),
                Port = ConvertToNonNegativeInteger(
                    value: overrides.Get(key: "Port", defaultValue: string.Empty),
                    defaultValue: 0),
                Server = overrides.Get(key: "Server", defaultValue: string.Empty),
                TrustServerCertificate = overrides.ContainsKey(key: "TrustServerCertificate"),
                Username = overrides.Get(key: "Username", defaultValue: string.Empty)
            };

            SetConnectionParts(builder, options);

            // Require a server so the failure names the missing input instead of a provider network error.
            if (string.IsNullOrWhiteSpace(builder.DataSource))
            {
                var message = "No SQL Server target was resolved. Set 'Credentials', 'ConnectionString', or 'Server'.";
                throw new InvalidOperationException(message);
            }

            // Return the resolved settings; they live only for the calling step and are never cached.
            return new SqlServerConnectionModel
            {
                AccessToken = accessToken,
                ConnectionString = builder.ConnectionString
            };
        }

        // Decodes Base64-encoded command text as UTF-8. Unlike the engine ConvertFromBase64, which returns the input
        // unchanged on a decoding failure, invalid Base64 throws, so encoded text never reaches the server as SQL.
        private static string ConvertFromBase64CommandText(string commandText)
        {
            // Size the buffer for the largest possible decoded payload, then decode the trimmed text without throwing
            // so surrounding whitespace is tolerated and bad input reaches the explicit failure below.
            var buffer = new byte[commandText.Length];
            var encodedText = commandText.Trim();
            var isDecoded = Convert.TryFromBase64String(s: encodedText, bytes: buffer, bytesWritten: out var length);

            // Reject invalid input with a message that names the argument and the switch that caused the decode.
            if (!isDecoded)
            {
                var message = "'CommandText' is not valid Base64. Encode the SQL as UTF-8 Base64 or remove the " +
                    "'Base64' switch.";
                throw new InvalidOperationException(message);
            }

            // Return only the written bytes as UTF-8 text so the unused buffer tail never reaches the command.
            return Encoding.UTF8.GetString(bytes: buffer, index: 0, count: length);
        }

        // Finds the SQL Server credentials record whose id or name matches the value, reading only the SQL Server
        // partition of the engine credentials cache. The id wins over the name, both compared case-insensitively.
        // Returns null for an empty value or no match, so the caller treats the value as raw credentials input.
        private static SqlServerCredentialModel FindCredential(string idOrName)
        {
            // Report no match for an empty value so the caller falls back to the raw credentials input.
            if (string.IsNullOrWhiteSpace(idOrName))
            {
                return null;
            }

            // Read the SQL Server partition; a missing partition means no SQL Server record is cached.
            var isCached = CacheManager.Instance.CredentialsCache.TryGetValue(
                key: CredentialTypes.SqlServer,
                value: out var partition);

            if (!isCached)
            {
                return null;
            }

            // Narrow the partition to SQL Server records and match the id first, then the name.
            var credentials = partition.Values.OfType<SqlServerCredentialModel>().ToArray();

            return credentials.FirstOrDefault(i => string.Equals(i.Id, idOrName, StringComparison.OrdinalIgnoreCase))
                ?? credentials.FirstOrDefault(i => string.Equals(i.Name, idOrName, StringComparison.OrdinalIgnoreCase));
        }

        // Creates a connection-string builder from a credentials record: the record connection string is the
        // baseline and the record discrete parts that are set override it. Compute-only: the record is read, never
        // mutated, and the returned builder is owned by the caller.
        private static SqlConnectionStringBuilder NewConnectionBuilder(SqlServerCredentialModel credential)
        {
            // Start from the stored connection string when present so complex keywords survive.
            var builder = new SqlConnectionStringBuilder(connectionString: credential.ConnectionString ?? string.Empty);

            // Apply the stored discrete parts on top of the stored connection string.
            var options = new ConnectionPartsOptions
            {
                Authentication = credential.Authentication,
                Database = credential.Database,
                Encrypt = credential.Encrypt,
                Password = credential.Password,
                Port = credential.Port,
                Server = credential.Server,
                TrustServerCertificate = credential.TrustServerCertificate,
                Username = credential.Username
            };

            SetConnectionParts(builder, options);

            return builder;
        }

        // Applies the discrete connection parts that are set to the builder, leaving unset parts untouched so they
        // never erase baseline values. Mutates only the caller-owned builder. The Integrated authentication value maps
        // to Integrated Security, and the TrustServerCertificate flag can only turn certificate trust on.
        private static void SetConnectionParts(SqlConnectionStringBuilder builder, ConnectionPartsOptions options)
        {
            // Compose the data source from the server and the optional port. A port without a server re-targets the
            // baseline host, replacing any port the baseline data source already carries.
            var hasServer = !string.IsNullOrWhiteSpace(options.Server);
            var hasPort = options.Port > 0;
            var host = hasServer ? options.Server : builder.DataSource.Split(',')[0];
            var isDataSourceSet = !string.IsNullOrWhiteSpace(host) && (hasPort || hasServer);

            if (isDataSourceSet)
            {
                builder.DataSource = hasPort ? $"{host},{options.Port}" : host;
            }

            // Select the initial database.
            if (!string.IsNullOrWhiteSpace(options.Database))
            {
                builder.InitialCatalog = options.Database;
            }

            // Select the authentication method; Integrated uses the Windows identity instead of a keyword value.
            var isIntegrated = string.Equals(
                options.Authentication,
                SqlServerAuthenticationTypes.Integrated,
                StringComparison.OrdinalIgnoreCase);

            if (isIntegrated)
            {
                builder.IntegratedSecurity = true;
            }
            else if (!string.IsNullOrWhiteSpace(options.Authentication))
            {
                builder["Authentication"] = options.Authentication;
            }

            // Apply the login and the transport encryption mode.
            if (!string.IsNullOrWhiteSpace(options.Username))
            {
                builder.UserID = options.Username;
            }

            if (!string.IsNullOrEmpty(options.Password))
            {
                builder.Password = options.Password;
            }

            if (!string.IsNullOrWhiteSpace(options.Encrypt))
            {
                builder["Encrypt"] = options.Encrypt;
            }

            // Trust the server certificate only when requested, so an unset flag keeps the baseline value.
            if (options.TrustServerCertificate)
            {
                builder.TrustServerCertificate = true;
            }
        }
        #endregion

        #region *** Nested Types ***
        // Carries the discrete connection parts applied on top of a connection baseline, either from the step
        // arguments or from a stored credentials record. Empty strings, a zero port, and a false flag mean "not set".
        private sealed class ConnectionPartsOptions
        {
            /// <summary>
            /// Gets or sets the authentication method; empty keeps the baseline method.
            /// </summary>
            public string Authentication { get; set; }

            /// <summary>
            /// Gets or sets the initial database; empty keeps the baseline database.
            /// </summary>
            public string Database { get; set; }

            /// <summary>
            /// Gets or sets the transport encryption mode; empty keeps the baseline mode.
            /// </summary>
            public string Encrypt { get; set; }

            /// <summary>
            /// Gets or sets the login password; empty keeps the baseline password.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets the TCP port; <c>0</c> keeps the baseline port unless a server is set.
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// Gets or sets the server host; empty keeps the baseline host.
            /// </summary>
            public string Server { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether to trust the server certificate; <c>false</c> keeps the
            /// baseline.
            /// </summary>
            public bool TrustServerCertificate { get; set; }

            /// <summary>
            /// Gets or sets the login name; empty keeps the baseline login.
            /// </summary>
            public string Username { get; set; }
        }
        #endregion
    }
}
