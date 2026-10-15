using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.IO;

namespace G4.Plugins.Common.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Assertions.Manifests.{nameof(PathExists)}.json")]
    public class PathExists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Return an assertion response whose evaluation reports whether a file or directory exists at OnElement.
            return this.NewAssertResponse(
                pluginData,
                factory: () => TestPathExistence(pluginData.Rule.OnElement));

            // Resolves the OnElement path from the process working directory and checks for a file or directory.
            // An empty path throws so the assertion records an exception and evaluates to false instead of passing.
            static bool TestPathExistence(string onElement)
            {
                // Reject an empty path because existence cannot be evaluated without a target.
                if (string.IsNullOrWhiteSpace(onElement))
                {
                    throw new ArgumentException(message: "The OnElement path is required and cannot be empty.");
                }

                // Normalize absolute, UNC, and relative paths before checking both file and directory existence.
                var path = Path.GetFullPath(onElement, Directory.GetCurrentDirectory());

                return File.Exists(path) || Directory.Exists(path);
            }
        }
    }
}
