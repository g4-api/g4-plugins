using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(CopyFiles)}.json")]
    public class CopyFiles(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Wildcard characters that turn the last Source segment into a file-name pattern instead of a literal name.
        private static readonly char[] s_wildcardCharacters = ['*', '?'];

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the source and destination paths together with the optional cp-style switches.
            var source = pluginData.Parameters.Get(key: "Source", defaultValue: string.Empty);
            var destination = pluginData.Parameters.Get(key: "Destination", defaultValue: string.Empty);
            var isRecursive = pluginData.Parameters.ContainsKey(key: "Recursive");
            var isNoClobber = pluginData.Parameters.ContainsKey(key: "NoClobber");

            // Assert both mandatory paths before touching the file system so an incomplete rule has no side effects.
            AssertParameters(source, destination);

            // Resolve relative paths from the process working directory and normalize full and UNC paths in place.
            var workingDirectory = Directory.GetCurrentDirectory();
            var sourcePath = Path.GetFullPath(source, workingDirectory);
            var destinationPath = Path.GetFullPath(destination, workingDirectory);

            // Build the complete plan up front so a recursive copy into its own subtree never re-enumerates new files.
            var (directories, files) = NewCopyPlan(sourcePath, destinationPath, isRecursive);

            // Create every planned directory first so empty source directories are mirrored like cp -r.
            foreach (var directory in directories)
            {
                Directory.CreateDirectory(directory);
            }

            // Copy each planned file, skipping existing targets under NoClobber and overwriting them otherwise.
            var copiedFiles = new List<string>();
            var skippedFiles = new List<string>();

            foreach (var (sourceFile, targetFile) in files)
            {
                // Preserve an existing target under NoClobber so the caller can audit what was left untouched.
                var isSkipped = isNoClobber && File.Exists(targetFile);

                if (isSkipped)
                {
                    skippedFiles.Add(targetFile);
                    continue;
                }

                // Create the target parent directory when necessary, then replace any existing file at that path.
                var targetDirectory = Path.GetDirectoryName(targetFile);

                if (!string.IsNullOrEmpty(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                File.Copy(sourceFile, targetFile, overwrite: true);
                copiedFiles.Add(targetFile);
            }

            // Serialize the destination paths as JSON arrays so downstream rules and ETL receive a stable shape.
            var copiedFilesJson = JsonSerializer.Serialize(copiedFiles);
            var skippedFilesJson = JsonSerializer.Serialize(skippedFiles);

            // Store the copy results in the session context so later rules can reference them by namespaced key.
            Invoker.Context.SessionParameters["CopyFiles:Count"] = copiedFiles.Count;
            Invoker.Context.SessionParameters["CopyFiles:Files"] = copiedFilesJson;

            // Expose the same results, plus the skipped targets, through the unnamespaced response entity.
            var pluginResponse = this.NewPluginResponse();

            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Count"] = copiedFiles.Count,
                ["Files"] = copiedFilesJson,
                ["Skipped"] = skippedFilesJson
            };

            return pluginResponse;

            // Asserts that both mandatory paths were supplied before the parent method resolves or touches any path.
            // The helper does not mutate state; each missing value fails the rule with a message naming the parameter.
            static void AssertParameters(string source, string destination)
            {
                // Require a source because every copy plan starts from a file, directory, or pattern.
                if (string.IsNullOrWhiteSpace(source))
                {
                    throw new ArgumentException(message: "The Source parameter is required and cannot be empty.");
                }

                // Require a destination because cp-style target resolution depends on it.
                if (string.IsNullOrWhiteSpace(destination))
                {
                    throw new ArgumentException(message: "The Destination parameter is required and cannot be empty.");
                }
            }
        }

        // Maps a path beneath the source root to the same relative location beneath the target root.
        // The helper is pure string composition and never touches the file system.
        private static string GetTargetPath(string sourceRoot, string targetRoot, string path)
        {
            return Path.Combine(targetRoot, Path.GetRelativePath(sourceRoot, path));
        }

        // Creates the enumeration options shared by pattern and directory sources.
        // Hidden and system files are included to mirror cp, and Recursive controls subdirectory traversal.
        private static EnumerationOptions NewEnumerationOptions(bool isRecursive) => new()
        {
            AttributesToSkip = FileAttributes.None,
            IgnoreInaccessible = false,
            MatchType = MatchType.Simple,
            RecurseSubdirectories = isRecursive
        };

        // Resolves the source kind and returns the directories to create and the file pairs to copy.
        // The helper only reads the file system; it throws when the source or the pattern root is missing.
        private static (string[] Directories, (string Source, string Target)[] Files) NewCopyPlan(
            string sourcePath,
            string destinationPath,
            bool isRecursive)
        {
            // Detect a wildcard in the last segment so the source is handled as a file-name pattern.
            var sourceName = Path.GetFileName(sourcePath);
            var isPattern = sourceName.IndexOfAny(s_wildcardCharacters) >= 0;

            if (isPattern)
            {
                return NewPatternPlan(sourcePath, destinationPath, isRecursive);
            }

            // Copy a single file into an existing or separator-terminated folder, or onto the destination path itself.
            if (File.Exists(sourcePath))
            {
                var isExistingFolder = Directory.Exists(destinationPath);
                var isFolderPath = Path.EndsInDirectorySeparator(destinationPath);
                var isFolderTarget = isExistingFolder || isFolderPath;
                var targetFile = isFolderTarget
                    ? Path.Combine(destinationPath, sourceName)
                    : destinationPath;

                return ([], [(sourcePath, targetFile)]);
            }

            // Copy a directory into an existing destination folder, or create the destination as the copy.
            if (Directory.Exists(sourcePath))
            {
                return NewDirectoryPlan(sourcePath, destinationPath, isRecursive);
            }

            // Report a missing source so the rule fails instead of silently copying nothing.
            var message = $"The source path '{sourcePath}' does not exist.";
            throw new FileNotFoundException(message, fileName: sourcePath);
        }

        // Plans a directory copy with cp-style naming: an existing destination receives a child named after the source.
        // Without Recursive only top-level files are planned; with Recursive every subdirectory is mirrored.
        private static (string[] Directories, (string Source, string Target)[] Files) NewDirectoryPlan(
            string sourcePath,
            string destinationPath,
            bool isRecursive)
        {
            // Name the target root after the source directory when copying into an existing folder.
            var sourceDirectoryName = Path.GetFileName(Path.TrimEndingDirectorySeparator(sourcePath));
            var targetRoot = Directory.Exists(destinationPath)
                ? Path.Combine(destinationPath, sourceDirectoryName)
                : destinationPath;

            // Enumerate subdirectories eagerly so the plan is fixed before any copy starts.
            var options = NewEnumerationOptions(isRecursive);
            var subdirectories = isRecursive
                ? Directory.GetDirectories(sourcePath, "*", options)
                : [];

            // Map the target root and every subdirectory so empty directories exist after the copy.
            var directories = subdirectories
                .Select(subdirectory => GetTargetPath(sourceRoot: sourcePath, targetRoot, path: subdirectory))
                .Prepend(targetRoot)
                .ToArray();

            // Map each source file to the same relative location beneath the target root.
            var files = Directory
                .GetFiles(sourcePath, "*", options)
                .Select(file => (file, GetTargetPath(sourceRoot: sourcePath, targetRoot, path: file)))
                .ToArray();

            return (directories, files);
        }

        // Plans a pattern copy where the destination is always a folder and matches keep their relative structure.
        // A pattern that matches nothing yields an empty plan; a missing pattern root throws so the rule fails.
        private static (string[] Directories, (string Source, string Target)[] Files) NewPatternPlan(
            string sourcePath,
            string destinationPath,
            bool isRecursive)
        {
            // Split the pattern from its hosting directory so the directory can be validated before matching.
            var pattern = Path.GetFileName(sourcePath);
            var sourceRoot = Path.GetDirectoryName(sourcePath);
            var isRootMissing = string.IsNullOrEmpty(sourceRoot) || !Directory.Exists(sourceRoot);

            // Report a missing pattern root so a mistyped folder fails the rule instead of copying nothing.
            if (isRootMissing)
            {
                var message = $"The source directory '{sourceRoot}' for pattern '{pattern}' does not exist.";
                throw new DirectoryNotFoundException(message);
            }

            // Match files in the root, or in every subdirectory under Recursive, keeping paths relative to the root.
            var files = Directory
                .GetFiles(sourceRoot, pattern, NewEnumerationOptions(isRecursive))
                .Select(file => (file, GetTargetPath(sourceRoot, targetRoot: destinationPath, path: file)))
                .ToArray();

            // Plan no directories so a pattern that matches nothing leaves the destination untouched.
            return ([], files);
        }
    }
}
