using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Provides one SQL Server instance, running in Docker, shared by every SQL Server plugin test in the test run.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The first call to <see cref="ConnectionString"/> starts a disposable <c>mcr.microsoft.com/mssql/server</c>
    /// container on a free loopback port, waits until the server accepts logins, and creates the
    /// <see cref="DatabaseName"/> database. The container is removed when the test process exits. Docker is the common
    /// runtime: Docker on Linux CI runners and Docker (Desktop or WSL) on Windows development machines.
    /// </para>
    /// <para>
    /// Set <c>G4_SQLSERVER_CONNECTION</c> to use an existing server instead (the connection string must point to a
    /// database the tests may write to). When Docker is not available, dependent tests report Inconclusive unless
    /// <c>G4_SQLSERVER_REQUIRED</c> is <c>true</c>, in which case they fail, so CI never skips them silently.
    /// </para>
    /// </remarks>
    public static class SqlServerTestContainer
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the database created for the tests inside the container.
        /// </summary>
        public const string DatabaseName = "G4Tests";

        // Names the SQL Server image; the 2022 line supports STRING_AGG and OPENJSON used by the data collector.
        private const string Image = "mcr.microsoft.com/mssql/server:2022-latest";

        // Holds the fixed system administrator password of the disposable container; it satisfies the SQL Server
        // complexity policy and never leaves the loopback-bound test instance.
        private const string SystemAdministratorPassword = "G4!Tests#Sql2022";

        // Bounds the wait for the server to accept logins after the container starts.
        private const int StartupTimeoutSeconds = 180;

        // Creates the test database when missing; a compile-time constant with no runtime values.
        private const string CreateDatabaseCommandText =
            "IF DB_ID(N'" + DatabaseName + "') IS NULL CREATE DATABASE [" + DatabaseName + "];";

        // Starts the container once per process, thread-safely, because MSTest runs test classes in parallel.
        private static readonly Lazy<string> Connection = new(
            valueFactory: NewConnectionString,
            mode: LazyThreadSafetyMode.ExecutionAndPublication);
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the connection string of the test database, starting the container on first use.
        /// </summary>
        /// <remarks>
        /// Reports the calling test as Inconclusive (or failed when <c>G4_SQLSERVER_REQUIRED</c> is <c>true</c>) when
        /// no server can be provided.
        /// </remarks>
        public static string ConnectionString
        {
            get
            {
                try
                {
                    // Reuse the single shared server for every caller.
                    return Connection.Value;
                }
                catch (Exception exception) when (!TestRequired())
                {
                    // Report the missing runtime as Inconclusive so machines without Docker are not red.
                    var message = $"SQL Server test container is not available: {exception.GetBaseException().Message}";
                    Assert.Inconclusive(message);

                    return null;
                }
            }
        }
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Reads the first column of the first row of a static query against the test database.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own connection, so assertions observe committed state only.
        /// </remarks>
        /// <param name="commandText">The static query text.</param>
        /// <returns>The scalar value, or <c>null</c> when the query returns no row.</returns>
        public static object GetScalar(string commandText)
        {
            // Open a short-lived connection so the read never shares a session with the plugin under test.
            using var connection = new SqlConnection(connectionString: ConnectionString);
            connection.Open();

            // Bind the caller's static query text to a command owned by this call.
            using var command = connection.CreateCommand();
            command.CommandText = commandText;

            // Read the scalar; the connection and command are disposed when the method returns.
            return command.ExecuteScalar();
        }

        /// <summary>
        /// Executes a static setup or cleanup command against the test database.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own connection, so test setup never shares state with the plugin under test.
        /// </remarks>
        /// <param name="commandText">The static command text to execute.</param>
        /// <returns>The number of rows affected.</returns>
        public static int InvokeCommand(string commandText)
        {
            // Open a short-lived connection so setup never shares a session with the plugin under test.
            using var connection = new SqlConnection(connectionString: ConnectionString);
            connection.Open();

            // Bind the caller's static command text to a command owned by this call.
            using var command = connection.CreateCommand();
            command.CommandText = commandText;

            // Execute the command; the connection and command are disposed when the method returns.
            return command.ExecuteNonQuery();
        }

        // Returns a loopback port that is free at the time of the call, so parallel runs never collide.
        private static int GetFreePort()
        {
            // Bind port 0 so the operating system assigns a free port, then release it for Docker.
            using var listener = new TcpListener(localaddr: IPAddress.Loopback, port: 0);
            listener.Start();

            return ((IPEndPoint)listener.LocalEndpoint).Port;
        }

        // Runs the Docker CLI and throws when Docker is missing or the command fails.
        private static string InvokeDocker(string arguments)
        {
            // Route through the complete overload with failures reported to the caller.
            return InvokeDocker(arguments, throwOnError: true);
        }

        // Runs the Docker CLI with the given arguments and returns its standard output. Throws when Docker is
        // missing or the command fails, unless the caller opts out for best-effort cleanup.
        private static string InvokeDocker(string arguments, bool throwOnError)
        {
            // Start the CLI without a shell so arguments are passed verbatim on every platform.
            var startInfo = new ProcessStartInfo(fileName: "docker", arguments)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            using var process = Process.Start(startInfo);

            // Drain both streams before waiting so a full pipe buffer never blocks the CLI.
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            // Surface the CLI error so the Inconclusive or failure message explains what is missing.
            var isFailed = process.ExitCode != 0 && throwOnError;

            if (isFailed)
            {
                var message = $"docker {arguments.Split(' ')[0]} failed ({process.ExitCode}): {error.Trim()}";
                throw new InvalidOperationException(message);
            }

            return output.Trim();
        }

        // Resolves the shared connection string: the configured external server, or a new Docker container.
        // Registers the container removal on process exit, so a crashed run leaves at most one container behind.
        private static string NewConnectionString()
        {
            // Prefer an explicitly configured server so CI or developers can reuse a running instance.
            var configured = Environment.GetEnvironmentVariable("G4_SQLSERVER_CONNECTION");

            if (!string.IsNullOrWhiteSpace(configured))
            {
                return configured;
            }

            // Start a disposable container on a free loopback port.
            var port = GetFreePort();
            var containerName = $"g4-sqlserver-tests-{Guid.NewGuid():N}"[..32];

            var runArguments = $"run -d --rm --name {containerName} " +
                $"-e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD={SystemAdministratorPassword} " +
                $"-p 127.0.0.1:{port}:1433 {Image}";

            InvokeDocker(arguments: runArguments);

            // Remove the container when the test process exits; --rm deletes it once stopped.
            var removeArguments = $"rm -f {containerName}";

            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
                InvokeDocker(arguments: removeArguments, throwOnError: false);

            // Wait until the server accepts logins, then create the test database.
            var serverConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = $"127.0.0.1,{port}",
                UserID = "sa",
                Password = SystemAdministratorPassword,
                TrustServerCertificate = true,
                Encrypt = SqlConnectionEncryptOption.Optional,
                ConnectTimeout = 5
            };

            WaitForServer(connectionString: serverConnectionString.ConnectionString);

            // Point the shared connection string at the test database.
            serverConnectionString.InitialCatalog = DatabaseName;

            return serverConnectionString.ConnectionString;
        }

        // Tests whether the run requires a SQL Server, so a missing server fails instead of reporting Inconclusive.
        private static bool TestRequired()
        {
            // Read the switch on every call so a test run can set it without rebuilding the fixture.
            var required = Environment.GetEnvironmentVariable("G4_SQLSERVER_REQUIRED");

            return string.Equals(required, "true", StringComparison.OrdinalIgnoreCase);
        }

        // Polls the server until it accepts a login and creates the test database. SQL Server needs several
        // seconds after the container starts; every failed attempt clears the pools and waits one second.
        private static void WaitForServer(string connectionString)
        {
            // Bound the polling by the startup budget and keep the latest failure for the timeout diagnostic.
            var deadline = DateTime.UtcNow.AddSeconds(StartupTimeoutSeconds);
            Exception lastError = null;

            // Retry until the login succeeds or the startup budget is spent.
            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    // Open a fresh connection; a refused login throws and moves to the retry stage.
                    using var connection = new SqlConnection(connectionString);
                    connection.Open();

                    // Create the test database through the static command once the server accepts logins.
                    using var command = connection.CreateCommand();
                    command.CommandText = CreateDatabaseCommandText;
                    command.ExecuteNonQuery();

                    return;
                }
                catch (SqlException exception)
                {
                    // Remember the latest failure so a timeout reports the real cause, then drop broken pooled
                    // connections before the next attempt.
                    lastError = exception;
                    SqlConnection.ClearAllPools();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }

            // Report the exhausted startup budget with the latest login failure as the inner cause.
            var message = $"SQL Server did not accept logins within {StartupTimeoutSeconds} seconds.";
            throw new TimeoutException(message, lastError);
        }
        #endregion
    }
}
