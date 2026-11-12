using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Provides one MongoDB deployment, running in Docker, shared by every MongoDB plugin test in the test run.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The first call to <see cref="ConnectionString"/> starts a disposable <c>mongo</c> container on a free loopback
    /// port, initiates it as a single-member replica set, and waits until it reports a writable primary. The container
    /// is removed when the test process exits. Docker is the common runtime: Docker on Linux CI runners and Docker
    /// (Desktop or WSL) on Windows development machines.
    /// </para>
    /// <para>
    /// The replica set is deliberate: MongoDB rejects multi-document transactions on a standalone server, so the
    /// <c>Transaction</c> switch of the plugins could not be tested against one. The container publishes its port
    /// unchanged (host port equals container port), because a replica-set member advertises the address it was
    /// initiated with, and that address must resolve both inside the container and on the host.
    /// </para>
    /// <para>
    /// Set <c>G4_MONGODB_CONNECTION</c> to use an existing deployment instead (the URI must point to a database the
    /// tests may write to, and to a replica set or a sharded cluster for the transaction tests). When Docker is not
    /// available, dependent tests report Inconclusive unless <c>G4_MONGODB_REQUIRED</c> is <c>true</c>, in which case
    /// they fail, so CI never skips them silently.
    /// </para>
    /// </remarks>
    public static class MongoDbTestContainer
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the database the tests write to inside the container.
        /// </summary>
        public const string DatabaseName = "G4Tests";

        /// <summary>
        /// Specifies the name of the replica set the container is initiated with.
        /// </summary>
        public const string ReplicaSetName = "rs0";

        // Names the MongoDB image; the 8.0 line is the current production release.
        private const string Image = "mongo:8";

        // Bounds the wait for the deployment to report a writable primary after the container starts.
        private const int StartupTimeoutSeconds = 180;

        // Starts the container once per process, thread-safely, because MSTest runs test classes in parallel.
        private static readonly Lazy<string> Connection = new(
            valueFactory: NewConnectionString,
            mode: LazyThreadSafetyMode.ExecutionAndPublication);
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the connection URI of the test database, starting the container on first use.
        /// </summary>
        /// <remarks>
        /// Reports the calling test as Inconclusive (or failed when <c>G4_MONGODB_REQUIRED</c> is <c>true</c>) when no
        /// deployment can be provided.
        /// </remarks>
        public static string ConnectionString
        {
            get
            {
                try
                {
                    // Reuse the single shared deployment for every caller.
                    return Connection.Value;
                }
                catch (Exception exception) when (!TestRequired())
                {
                    // Report the missing runtime as Inconclusive so machines without Docker are not red.
                    var message = $"MongoDB test container is not available: {exception.GetBaseException().Message}";
                    Assert.Inconclusive(message);

                    return null;
                }
            }
        }
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Counts the documents of a test collection.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so assertions observe committed state only.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <returns>The document count.</returns>
        public static long Count(string collection)
        {
            // Route through the complete overload so both forms share one read path.
            return Count(collection, filter: null);
        }

        /// <summary>
        /// Counts the documents of a test collection that match a filter.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so assertions observe committed state only.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <param name="filter">The filter, or <c>null</c> to count every document.</param>
        /// <returns>The document count.</returns>
        public static long Count(string collection, BsonDocument filter)
        {
            // Open a short-lived client so the read never shares a session with the plugin under test.
            using var client = NewClient();

            return client
                .GetDatabase(DatabaseName)
                .GetCollection<BsonDocument>(collection)
                .CountDocuments(filter ?? []);
        }

        /// <summary>
        /// Drops a test collection, so a scenario starts from a known state.
        /// </summary>
        /// <remarks>
        /// Dropping a collection that does not exist is not an error, so cleanup stays idempotent.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        public static void Drop(string collection)
        {
            // Open a short-lived client so setup never shares a session with the plugin under test.
            using var client = NewClient();
            client.GetDatabase(DatabaseName).DropCollection(collection);
        }

        /// <summary>
        /// Reads the documents of a test collection.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so assertions observe committed state only.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <returns>The documents of the collection.</returns>
        public static List<BsonDocument> Find(string collection)
        {
            // Route through the complete overload so both forms share one read path.
            return Find(collection, filter: null);
        }

        /// <summary>
        /// Reads the documents of a test collection that match a filter.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so assertions observe committed state only.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <param name="filter">The filter, or <c>null</c> to read every document.</param>
        /// <returns>The matching documents.</returns>
        public static List<BsonDocument> Find(string collection, BsonDocument filter)
        {
            // Open a short-lived client so the read never shares a session with the plugin under test.
            using var client = NewClient();

            return client
                .GetDatabase(DatabaseName)
                .GetCollection<BsonDocument>(collection)
                .Find(filter ?? [])
                .ToList();
        }

        /// <summary>
        /// Reads the index names of a test collection.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so assertions observe committed state only.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <returns>The index names, including the default identifier index.</returns>
        public static List<string> GetIndexNames(string collection)
        {
            // Open a short-lived client so the read never shares a session with the plugin under test.
            using var client = NewClient();

            var indexes = client
                .GetDatabase(DatabaseName)
                .GetCollection<BsonDocument>(collection)
                .Indexes
                .List();

            // Materialize the names so the cursor is consumed before the client is disposed.
            var names = new List<string>();

            while (indexes.MoveNext())
            {
                foreach (var index in indexes.Current)
                {
                    names.Add($"{index.GetValue(name: "name", defaultValue: BsonString.Empty)}");
                }
            }

            return names;
        }

        /// <summary>
        /// Inserts documents into a test collection.
        /// </summary>
        /// <remarks>
        /// Opens and disposes its own client, so test setup never shares state with the plugin under test.
        /// </remarks>
        /// <param name="collection">The collection name inside the test database.</param>
        /// <param name="documents">The documents to insert.</param>
        public static void Insert(string collection, IEnumerable<BsonDocument> documents)
        {
            // Open a short-lived client so setup never shares a session with the plugin under test.
            using var client = NewClient();

            client
                .GetDatabase(DatabaseName)
                .GetCollection<BsonDocument>(collection)
                .InsertMany(documents);
        }

        /// <summary>
        /// Creates a client for the shared test deployment.
        /// </summary>
        /// <remarks>
        /// The caller owns and disposes the returned client.
        /// </remarks>
        /// <returns>The client.</returns>
        public static MongoClient NewClient()
        {
            // Create the client from the shared URI so every helper reaches the same deployment.
            return new MongoClient(ConnectionString);
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
        // missing or the command fails, unless the caller opts out for best-effort cleanup and polling.
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

        // Resolves the shared connection URI: the configured external deployment, or a new Docker container.
        // Registers the container removal on process exit, so a crashed run leaves at most one container behind.
        private static string NewConnectionString()
        {
            // Prefer an explicitly configured deployment so CI or developers can reuse a running instance.
            var configured = Environment.GetEnvironmentVariable("G4_MONGODB_CONNECTION");

            if (!string.IsNullOrWhiteSpace(configured))
            {
                return configured;
            }

            // Publish the container port unchanged, because the replica-set member advertises this exact address and
            // it must resolve both inside the container and on the host.
            var port = GetFreePort();
            var containerName = $"g4-mongodb-tests-{Guid.NewGuid():N}"[..32];

            var runArguments = $"run -d --rm --name {containerName} " +
                $"-p 127.0.0.1:{port}:{port} {Image} " +
                $"mongod --replSet {ReplicaSetName} --port {port} --bind_ip_all";

            InvokeDocker(arguments: runArguments);

            // Remove the container when the test process exits; --rm deletes it once stopped.
            var removeArguments = $"rm -f {containerName}";

            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
                InvokeDocker(arguments: removeArguments, throwOnError: false);

            // Wait until the server answers, initiate the replica set, and wait for the writable primary.
            WaitForServer(containerName, port);

            // Point the shared URI at the test database of the initiated replica set.
            return $"mongodb://127.0.0.1:{port}/{DatabaseName}?replicaSet={ReplicaSetName}";
        }

        // Runs a mongosh expression inside the container and returns its output. Reports failures to the caller only
        // when asked, so the polling stages can retry a server that is not up yet.
        private static string NewShellResult(ShellOptions options)
        {
            // Quote the expression once so the CLI passes it to mongosh as a single argument.
            var arguments = $"exec {options.ContainerName} mongosh --quiet --port {options.Port} " +
                $"--eval \"{options.Expression}\"";

            return InvokeDocker(arguments, options.ThrowOnError);
        }

        // Tests whether the run requires a MongoDB deployment, so a missing one fails instead of reporting
        // Inconclusive.
        private static bool TestRequired()
        {
            // Read the switch on every call so a test run can set it without rebuilding the fixture.
            var required = Environment.GetEnvironmentVariable("G4_MONGODB_REQUIRED");

            return string.Equals(required, "true", StringComparison.OrdinalIgnoreCase);
        }

        // Polls the container until mongod answers, initiates the single-member replica set, and polls until the
        // member reports itself as the writable primary. Every failed attempt waits one second.
        private static void WaitForServer(string containerName, int port)
        {
            // Bound the polling by the startup budget and keep the latest output for the timeout diagnostic.
            var deadline = DateTime.UtcNow.AddSeconds(StartupTimeoutSeconds);
            var lastResult = string.Empty;

            // Describe the shell calls once; only the expression changes between the polling stages.
            var options = new ShellOptions
            {
                ContainerName = containerName,
                Expression = "db.adminCommand({ ping: 1 }).ok",
                Port = port,
                ThrowOnError = false
            };

            // Stage 1: wait until mongod answers a ping, which it does before the replica set exists.
            while (DateTime.UtcNow < deadline)
            {
                lastResult = NewShellResult(options);

                if (lastResult.Contains('1'))
                {
                    break;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            // Stage 2: initiate the replica set with the address the host also reaches, so the driver can discover
            // a member it can connect to. An already-initiated set reports an error, which the next stage settles.
            options.Expression = $"try {{ rs.initiate({{ _id: '{ReplicaSetName}', members: " +
                $"[{{ _id: 0, host: '127.0.0.1:{port}' }}] }}) }} catch (e) {{ e.codeName }}";

            lastResult = NewShellResult(options);

            // Stage 3: wait until the member finished the election and accepts writes.
            options.Expression = "db.hello().isWritablePrimary";

            while (DateTime.UtcNow < deadline)
            {
                lastResult = NewShellResult(options);

                if (lastResult.Contains("true"))
                {
                    return;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            // Report the exhausted startup budget with the latest shell output as the cause.
            var message = $"MongoDB did not report a writable primary within {StartupTimeoutSeconds} seconds. " +
                $"Last shell output: {lastResult}";
            throw new TimeoutException(message);
        }
        #endregion

        #region *** Nested Types ***
        // Carries one mongosh call: the container, its port, the expression to evaluate, and whether a CLI failure
        // reaches the caller or lets the polling stage retry.
        private sealed class ShellOptions
        {
            /// <summary>
            /// Gets or sets the name of the running container.
            /// </summary>
            public string ContainerName { get; set; }

            /// <summary>
            /// Gets or sets the expression mongosh evaluates.
            /// </summary>
            public string Expression { get; set; }

            /// <summary>
            /// Gets or sets the port mongod listens on inside the container.
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether a CLI failure is reported to the caller.
            /// </summary>
            public bool ThrowOnError { get; set; }
        }
        #endregion
    }
}
