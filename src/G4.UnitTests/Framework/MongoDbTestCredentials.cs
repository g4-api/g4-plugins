using G4.Cache;
using G4.Credentials.Models;
using G4.Plugins.MongoDb.Models;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Seeds and removes MongoDB credential records in the engine credentials cache for the MongoDB plugin tests.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Records are written only to the MongoDB partition of <see cref="CacheManager.CredentialsCache"/>, never to the
    /// persistent credentials store, so a test resolves a record by name exactly as a plugin does at runtime. A full
    /// cache synchronization replaces the cache and drops every seeded record; each test removes its own record in its
    /// cleanup stage.
    /// </para>
    /// <para>
    /// The partition is created when missing, because the released engine package does not register the MongoDB
    /// credential type yet and therefore creates no partition for it. Once the engine ships the type, the partition
    /// always exists and this seeding writes into it unchanged.
    /// </para>
    /// </remarks>
    public static class MongoDbTestCredentials
    {
        #region *** Fields       ***
        // Guards the one-time creation of the MongoDB partition against the parallel test classes that seed records.
        private static readonly Lock _partitionSyncRoot = new();
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Adds a MongoDB credential record to the engine credentials cache, or replaces the cached record with the
        /// same name and identifier.
        /// </summary>
        /// <remarks>
        /// A record without an identifier receives a time-based identifier and a record without a creation time
        /// receives the current time, matching the identity the engine credentials manager assigns on save.
        /// </remarks>
        /// <param name="credential">The record to cache; its identity is assigned in place when missing.</param>
        /// <returns>The cached record, including its assigned identity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="credential"/> is <c>null</c>.</exception>
        internal static MongoDbCredentialModel AddCredential(MongoDbCredentialModel credential)
        {
            // Require the record before assigning its identity so a missing argument fails before the cache is touched.
            ArgumentNullException.ThrowIfNull(argument: credential);

            // Assign the identity of a new record so it resolves by id like a persisted engine record.
            if (string.IsNullOrWhiteSpace(credential.Id))
            {
                credential.Id = $"cred_mongo_{Guid.NewGuid():N}";
            }

            // Record the creation time once so a replacement keeps the original timestamp.
            if (credential.CreatedAt == default)
            {
                credential.CreatedAt = DateTimeOffset.UtcNow;
            }

            // Cache the record under the lower-case name;id key the engine uses for every partition.
            GetPartition()[NewKey(credential)] = credential;

            return credential;
        }

        /// <summary>
        /// Removes a MongoDB credential record from the engine credentials cache.
        /// </summary>
        /// <remarks>
        /// Removing a record that is not cached is not an error, so cleanup stays idempotent.
        /// </remarks>
        /// <param name="credential">The record to remove, identified by its name and identifier.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="credential"/> is <c>null</c>.</exception>
        internal static void RemoveCredential(MongoDbCredentialModel credential)
        {
            // Require the record before composing its key so a missing argument fails before the cache is touched.
            ArgumentNullException.ThrowIfNull(argument: credential);

            // Remove the record by the same key it was cached under.
            GetPartition().Remove(key: NewKey(credential));
        }

        // Returns the MongoDB partition of the credentials cache, creating it when the cached engine build does not.
        // The creation is serialized, because MSTest runs test classes in parallel and two unguarded creations would
        // each publish their own partition, dropping the records seeded through the other one.
        private static IDictionary<string, CredentialModelBase> GetPartition()
        {
            // Read the partition first, which is the path once the engine registers the MongoDB credential type.
            var cache = CacheManager.Instance.CredentialsCache;

            if (cache.TryGetValue(key: MongoDbCredentialTypes.MongoDb, value: out var partition))
            {
                return partition;
            }

            // Create the partition under the lock, re-reading it so only the first caller publishes one.
            lock (_partitionSyncRoot)
            {
                if (cache.TryGetValue(key: MongoDbCredentialTypes.MongoDb, value: out partition))
                {
                    return partition;
                }

                // Use the comparer the engine cache builder uses, so keys match either way.
                partition = new ConcurrentDictionary<string, CredentialModelBase>(StringComparer.OrdinalIgnoreCase);
                cache[MongoDbCredentialTypes.MongoDb] = partition;

                return partition;
            }
        }

        // Creates the cache key of a record: the lower-case name;id pair that the engine cache builder composes.
        private static string NewKey(MongoDbCredentialModel credential)
        {
            // Compose the key exactly as the engine does, so seeded and synchronized records share one key space.
            return $"{credential.Name};{credential.Id}".ToLower();
        }
        #endregion
    }
}
