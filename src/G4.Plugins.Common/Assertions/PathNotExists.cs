using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.IO;

namespace G4.Plugins.Common.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Assertions.Manifests.{nameof(PathNotExists)}.json")]
    public class PathNotExists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Return an assertion response that evaluates to true only when nothing exists at the OnElement path.
            return this.NewAssertResponse(
                pluginData,
                factory: () => TestPathAbsence(pluginData.Rule.OnElement));

            // Resolves the OnElement path from the process working directory and checks that nothing exists there.
            // An empty path throws so the assertion records an exception and evaluates to false instead of passing.
            // An unreachable share or denied access also reports a missing path, so this check passes in those cases.
            static bool TestPathAbsence(string onElement)
            {
                // Reject an empty path because absence cannot be evaluated without a target.
                if (string.IsNullOrWhiteSpace(onElement))
                {
                    throw new ArgumentException(message: "The OnElement path is required and cannot be empty.");
                }

                // Normalize absolute, UNC, and relative paths before checking that no file or directory exists.
                var path = Path.GetFullPath(onElement, Directory.GetCurrentDirectory());

                return !File.Exists(path) && !Directory.Exists(path);
            }
        }
    }
}
