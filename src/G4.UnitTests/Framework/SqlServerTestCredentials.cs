using G4.Cache;
using G4.Credentials.Models;

using System;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Seeds and removes SQL Server credential records in the engine credentials cache for the SQL Server plugin tests.
    /// </summary>
    /// <remarks>
    /// Records are written only to the in-memory <see cref="CredentialTypes.SqlServer"/> partition of
    /// <see cref="CacheManager.CredentialsCache"/>, never to the persistent credentials store, so a test resolves a
    /// record by name exactly as a plugin does at runtime. A full cache synchronization replaces the cache and drops
    /// every seeded record; each test removes its own record in its cleanup stage.
    /// </remarks>
    public static class SqlServerTestCredentials
    {
        #region *** Methods      ***
        /// <summary>
        /// Adds a SQL Server credential record to the engine credentials cache, or replaces the cached record with the
        /// same name and identifier.
        /// </summary>
        /// <remarks>
        /// A record without an identifier receives a time-based identifier and a record without a creation time
        /// receives the current time, matching the identity the engine credentials manager assigns on save.
        /// </remarks>
        /// <param name="credential">The record to cache; its identity is assigned in place when missing.</param>
        /// <returns>The cached record, including its assigned identity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="credential"/> is <c>null</c>.</exception>
        public static SqlServerCredentialModel AddCredential(SqlServerCredentialModel credential)
        {
            // Require the record before assigning its identity so a missing argument fails before the cache is touched.
            ArgumentNullException.ThrowIfNull(argument: credential);

            // Assign the identity of a new record so it resolves by id like a persisted engine record.
            if (string.IsNullOrWhiteSpace(credential.Id))
            {
                credential.Id = $"cred_sql_{Guid.NewGuid():N}";
            }

            // Record the creation time once so a replacement keeps the original timestamp.
            if (credential.CreatedAt == default)
            {
                credential.CreatedAt = DateTimeOffset.UtcNow;
            }

            // Cache the record under the lower-case name;id key the engine uses for every partition.
            var partition = CacheManager.Instance.CredentialsCache[CredentialTypes.SqlServer];
            partition[NewKey(credential)] = credential;

            return credential;
        }

        /// <summary>
        /// Removes a SQL Server credential record from the engine credentials cache.
        /// </summary>
        /// <remarks>
        /// Removing a record that is not cached is not an error, so cleanup stays idempotent.
        /// </remarks>
        /// <param name="credential">The record to remove, identified by its name and identifier.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="credential"/> is <c>null</c>.</exception>
        public static void RemoveCredential(SqlServerCredentialModel credential)
        {
            // Require the record before composing its key so a missing argument fails before the cache is touched.
            ArgumentNullException.ThrowIfNull(argument: credential);

            // Remove the record by the same key it was cached under.
            var partition = CacheManager.Instance.CredentialsCache[CredentialTypes.SqlServer];
            partition.Remove(key: NewKey(credential));
        }

        // Creates the cache key of a record: the lower-case name;id pair that the engine cache builder composes.
        private static string NewKey(SqlServerCredentialModel credential)
        {
            // Compose the key exactly as the engine does, so seeded and synchronized records share one key space.
            return $"{credential.Name};{credential.Id}".ToLower();
        }
        #endregion
    }
}
