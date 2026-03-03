using G4.Cache;
using G4.Credentials;
using G4.Credentials.Extensions;
using G4.Credentials.Models;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Google.Actions.Abstraction
{
    /// <summary>
    /// Base plugin for Google plugins.
    /// </summary>
    internal class GooglePlugin(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        /// <summary>
        /// Obtains a fresh Google OAuth access token using a stored credential record.
        /// </summary>
        /// <param name="idOrName">The credential identifier or credential name used to locate the record in the credentials cache.</param>
        /// <returns>A <see cref="TokenResponseModel"/> containing a newly issued access token (and related metadata).</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the credential record cannot be found.</exception>
        public static TokenResponseModel NewAccessToken(string idOrName)
        {
            // Resolve the provider token endpoint (defaulting to Google's public OAuth token URL).
            _ = CredentialsManager.Providers.Get(
                key: "google",
                defaultValue: "https://oauth2.googleapis.com/token");

            // Find a credential record by id or by name from the in-memory credentials cache.
            var credentials = CacheManager
                .Instance
                .CredentialsCache
                .Values
                .FirstOrDefault(i => i.Name == idOrName || i.Id == idOrName)
                    ?? throw new KeyNotFoundException(
                        $"Unknown Google credentials '{idOrName}'. Ensure the record exists in the credentials cache.");

            // Extract and decrypt required credential fields.
            var clientId = credentials.ClientId;
            var clientSecret = credentials.ClientSecret.Unprotect();
            var refreshToken = credentials.RefreshToken.Unprotect();

            // Exchange refresh token for a new access token using the credential's provider key.
            return CredentialsManager.ConvertRefreshToken(
                clientId: clientId,
                clientSecret: clientSecret,
                refreshToken: refreshToken,
                provider: credentials.Provider);
        }
    }
}
