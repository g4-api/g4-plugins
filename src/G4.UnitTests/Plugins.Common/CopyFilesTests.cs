using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("CopyFiles")]
    [TestCategory("UnitTest")]
    public class CopyFilesTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the CopyFiles plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<CopyFiles>();
        }

        [TestMethod(DisplayName = "Verify that the CopyFiles plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<CopyFiles>();
        }

        [TestMethod(DisplayName = "Verify that CopyFiles copies a directory recursively into an " +
            "existing folder as a child folder named after the source.")]
        public void CopyFilesDirectoryIntoExistingFolderTest()
        {
            // Arrange: create a source tree and an existing destination folder that receives it.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source", "results");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "nested", "data.txt"), content: "nested");
            Directory.CreateDirectory(destinationPath);

            try
            {
                // Act: copy the directory recursively into the existing folder.
                var responseModel = Invoke([NewRule(sourcePath, destinationPath, options: " --Recursive")]);

                // Assert: the tree lands beneath a child folder that keeps the source directory name.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "results", "nested", "data.txt")));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles mirrors a directory tree, including empty " +
            "folders, when Recursive is specified.")]
        public void CopyFilesDirectoryRecursiveTest()
        {
            // Arrange: create a source tree with a nested file and an empty subfolder.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "top.txt"), content: "top");
            NewFile(Path.Combine(sourcePath, "nested", "deep.txt"), content: "deep");
            Directory.CreateDirectory(Path.Combine(sourcePath, "empty"));

            try
            {
                // Act: copy the directory to a destination that does not exist yet.
                var responseModel = Invoke([NewRule(sourcePath, destinationPath, options: " --Recursive")]);
                var count = GetSessionValue(responseModel, key: "CopyFiles:Count");

                // Assert: the destination becomes the copy, including the nested file and the empty folder.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "top.txt")));
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "nested", "deep.txt")));
                Assert.IsTrue(Directory.Exists(Path.Combine(destinationPath, "empty")));
                Assert.AreEqual(expected: "2", actual: count);
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles copies only top-level files of a directory " +
            "when Recursive is not specified.")]
        public void CopyFilesDirectoryTopLevelTest()
        {
            // Arrange: create a source directory with one top-level file and one nested file.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "top.txt"), content: "top");
            NewFile(Path.Combine(sourcePath, "nested", "deep.txt"), content: "deep");

            try
            {
                // Act: copy the directory without the Recursive switch.
                var responseModel = Invoke([NewRule(sourcePath, destinationPath)]);

                // Assert: only the top-level file is copied and the nested folder is ignored.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "top.txt")));
                Assert.IsFalse(Directory.Exists(Path.Combine(destinationPath, "nested")));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles copies a file into an existing folder using " +
            "the original file name.")]
        public void CopyFilesFileIntoExistingFolderTest()
        {
            // Arrange: create a source file and an existing destination folder.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "source", "report.txt");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(sourceFile, content: "report");
            Directory.CreateDirectory(destinationPath);

            try
            {
                // Act: copy the file onto the existing folder path and read the resulting copy.
                var responseModel = Invoke([NewRule(sourceFile, destinationPath)]);
                var copiedContent = File.ReadAllText(Path.Combine(destinationPath, "report.txt"));

                // Assert: the file is placed inside the folder under its original name.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: "report", actual: copiedContent);
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles treats a destination ending with a directory " +
            "separator as a folder and creates it.")]
        public void CopyFilesFileIntoSeparatorFolderTest()
        {
            // Arrange: target a missing folder path that ends with a directory separator.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "source", "report.txt");
            var destinationPath = Path.Combine(rootPath, "destination") + Path.DirectorySeparatorChar;
            NewFile(sourceFile, content: "report");

            try
            {
                // Act: copy the file onto the separator-terminated destination.
                var responseModel = Invoke([NewRule(sourceFile, destinationPath)]);

                // Assert: the folder is created and receives the file under its original name.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "report.txt")));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles copies a file to a new name, creates missing " +
            "parent folders, and publishes the session outputs.")]
        public void CopyFilesFileToNewNameTest()
        {
            // Arrange: target a new file name beneath parent folders that do not exist yet.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "source", "report.txt");
            var targetFile = Path.Combine(rootPath, "destination", "nested", "report-copy.txt");
            NewFile(sourceFile, content: "report");

            try
            {
                // Act: copy the file and read the namespaced session outputs.
                var responseModel = Invoke([NewRule(sourceFile, targetFile)]);
                var count = GetSessionValue(responseModel, key: "CopyFiles:Count");
                var filesJson = GetSessionValue(responseModel, key: "CopyFiles:Files");
                var files = JsonSerializer.Deserialize<string[]>(filesJson);

                // Assert: the file is copied to the new name and the outputs report that single target.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: "report", actual: File.ReadAllText(targetFile));
                Assert.AreEqual(expected: "1", actual: count);
                Assert.HasCount(1, files);
                Assert.AreEqual(expected: targetFile, actual: files[0]);
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles reports an exception when Source or " +
            "Destination is missing.")]
        #region *** Data Set ***
        [DataRow("{{$ --Destination:C:\\G4\\CopyFilesTests}}")]
        [DataRow("{{$ --Source:C:\\G4\\CopyFilesTests\\missing.txt}}")]
        #endregion
        public void CopyFilesMissingParameterTest(string argument)
        {
            // Arrange: build a rule that omits one of the mandatory parameters.
            var rule = new ActionRuleModel
            {
                PluginName = nameof(CopyFiles),
                Argument = argument
            };

            // Act: execute the incomplete rule through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Assert: the plugin rejects the rule before resolving any path.
            Assert.IsNotEmpty(responseModel.GetExceptions());
        }

        [TestMethod(DisplayName = "Verify that CopyFiles reports an exception when the folder that " +
            "hosts a wildcard pattern does not exist.")]
        public void CopyFilesMissingPatternRootTest()
        {
            // Arrange: point the pattern at a folder that does not exist.
            var rootPath = NewTestDirectory();
            var sourcePattern = Path.Combine(rootPath, "missing", "*.log");
            var destinationPath = Path.Combine(rootPath, "destination");

            try
            {
                // Act: execute the pattern copy.
                var responseModel = Invoke([NewRule(sourcePattern, destinationPath)]);

                // Assert: the missing pattern root fails the rule and nothing is created.
                Assert.IsNotEmpty(responseModel.GetExceptions());
                Assert.IsFalse(Directory.Exists(destinationPath));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles reports an exception when the source path " +
            "does not exist.")]
        public void CopyFilesMissingSourceTest()
        {
            // Arrange: reference a source file that was never created.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "missing.txt");
            var destinationPath = Path.Combine(rootPath, "destination");

            try
            {
                // Act: execute the copy for the missing source.
                var responseModel = Invoke([NewRule(sourceFile, destinationPath)]);

                // Assert: the missing source fails the rule and nothing is created.
                Assert.IsNotEmpty(responseModel.GetExceptions());
                Assert.IsFalse(Directory.Exists(destinationPath));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles preserves existing files and reports them " +
            "in the entity when NoClobber is specified.")]
        public void CopyFilesNoClobberTest()
        {
            // Arrange: create a source file and an existing target with different content.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "source", "report.txt");
            var targetFile = Path.Combine(rootPath, "destination", "report.txt");
            NewFile(sourceFile, content: "replacement");
            NewFile(targetFile, content: "original");

            try
            {
                // Act: invoke the plugin directly so the response entity is available.
                var rule = NewRule(sourceFile, targetFile, options: " --NoClobber");
                var entity = Invoke<CopyFiles>(rule).Response.Entity;
                var skipped = JsonSerializer.Deserialize<string[]>($"{entity["Skipped"]}");
                var files = JsonSerializer.Deserialize<string[]>($"{entity["Files"]}");

                // Assert: the original content survives and the target is listed as skipped, not copied.
                Assert.AreEqual(expected: "original", actual: File.ReadAllText(targetFile));
                Assert.AreEqual(expected: "0", actual: $"{entity["Count"]}");
                Assert.IsEmpty(files);
                Assert.HasCount(1, skipped);
                Assert.AreEqual(expected: targetFile, actual: skipped[0]);
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles overwrites an existing target file by default.")]
        public void CopyFilesOverwriteTest()
        {
            // Arrange: create a source file and an existing target with different content.
            var rootPath = NewTestDirectory();
            var sourceFile = Path.Combine(rootPath, "source", "report.txt");
            var targetFile = Path.Combine(rootPath, "destination", "report.txt");
            NewFile(sourceFile, content: "replacement");
            NewFile(targetFile, content: "original");

            try
            {
                // Act: copy without NoClobber onto the existing target.
                var responseModel = Invoke([NewRule(sourceFile, targetFile)]);

                // Assert: the target now holds the source content.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: "replacement", actual: File.ReadAllText(targetFile));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles succeeds with a zero count when a wildcard " +
            "pattern matches no files.")]
        public void CopyFilesPatternNoMatchTest()
        {
            // Arrange: create a pattern root that holds no matching files.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "readme.txt"), content: "readme");

            try
            {
                // Act: copy a pattern that matches nothing.
                var responseModel = Invoke([NewRule(Path.Combine(sourcePath, "*.log"), destinationPath)]);
                var count = GetSessionValue(responseModel, key: "CopyFiles:Count");

                // Assert: the rule succeeds, reports zero files, and leaves the destination untouched.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: "0", actual: count);
                Assert.IsFalse(Directory.Exists(destinationPath));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles matches a wildcard pattern in every subfolder " +
            "and keeps the relative structure when Recursive is specified.")]
        public void CopyFilesPatternRecursiveTest()
        {
            // Arrange: create matching files at the top level and in a nested folder plus one non-matching file.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "top.log"), content: "top");
            NewFile(Path.Combine(sourcePath, "nested", "deep.log"), content: "deep");
            NewFile(Path.Combine(sourcePath, "nested", "skip.txt"), content: "skip");

            try
            {
                // Act: copy the pattern recursively into a destination folder.
                var sourcePattern = Path.Combine(sourcePath, "*.log");
                var responseModel = Invoke([NewRule(sourcePattern, destinationPath, options: " --Recursive")]);

                // Assert: every match keeps its relative location and the non-matching file is ignored.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "top.log")));
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "nested", "deep.log")));
                Assert.IsFalse(File.Exists(Path.Combine(destinationPath, "nested", "skip.txt")));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles copies only top-level wildcard matches into " +
            "the destination folder when Recursive is not specified.")]
        public void CopyFilesPatternTest()
        {
            // Arrange: create matching files at the top level and in a nested folder.
            var rootPath = NewTestDirectory();
            var sourcePath = Path.Combine(rootPath, "source");
            var destinationPath = Path.Combine(rootPath, "destination");
            NewFile(Path.Combine(sourcePath, "first.log"), content: "first");
            NewFile(Path.Combine(sourcePath, "second.log"), content: "second");
            NewFile(Path.Combine(sourcePath, "nested", "deep.log"), content: "deep");

            try
            {
                // Act: invoke the plugin directly so the entity count is available.
                var sourcePattern = Path.Combine(sourcePath, "*.log");
                var entity = Invoke<CopyFiles>(NewRule(sourcePattern, destinationPath)).Response.Entity;

                // Assert: both top-level matches are copied into the created folder and the nested match is ignored.
                Assert.AreEqual(expected: "2", actual: $"{entity["Count"]}");
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "first.log")));
                Assert.IsTrue(File.Exists(Path.Combine(destinationPath, "second.log")));
                Assert.IsFalse(Directory.Exists(Path.Combine(destinationPath, "nested")));
            }
            finally
            {
                // Remove the isolated tree so later tests start from a clean file system.
                DeleteTestDirectory(rootPath);
            }
        }

        [TestMethod(DisplayName = "Verify that CopyFiles resolves relative source and destination " +
            "paths from the process working directory.")]
        public void CopyFilesRelativePathTest()
        {
            // Arrange: create a unique relative tree beneath the current process working directory.
            var relativeRoot = Path.Combine(nameof(CopyFilesTests), Guid.NewGuid().ToString("N"));
            var relativeSource = Path.Combine(relativeRoot, "source.txt");
            var relativeTarget = Path.Combine(relativeRoot, "copy", "target.txt");
            var rootPath = Path.GetFullPath(relativeRoot, Directory.GetCurrentDirectory());
            NewFile(Path.GetFullPath(relativeSource, Directory.GetCurrentDirectory()), content: "relative");

            try
            {
                // Act: copy using relative paths only and read the resulting copy.
                var responseModel = Invoke([NewRule(relativeSource, relativeTarget)]);
                var copiedContent = File.ReadAllText(Path.Combine(rootPath, "copy", "target.txt"));

                // Assert: the copy is resolved against the working directory.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: "relative", actual: copiedContent);
            }
            finally
            {
                // Remove the relative tree so the working directory stays clean between runs.
                DeleteTestDirectory(rootPath);
            }
        }

        // Deletes a temporary test tree when it exists so each test leaves no file-system residue.
        private static void DeleteTestDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive: true);
            }
        }

        // Reads a session output from the first session of a pipeline result as an invariant string.
        private static string GetSessionValue(
            TestResultModel<IDictionary<string, G4AutomationResponseModel>> responseModel,
            string key)
        {
            return $"{responseModel.GetEnvironment().SessionParameters[key]}";
        }

        // Creates a file with known content, creating parent folders first so fixtures stay one line per file.
        private static void NewFile(string path, string content)
        {
            // Create the parent folder first so nested fixture paths never fail on a missing directory.
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // Write the known content that later assertions compare against.
            File.WriteAllText(path, content);
        }

        // Builds a CopyFiles rule without optional switches by delegating to the complete overload.
        private static ActionRuleModel NewRule(string source, string destination)
        {
            return NewRule(source, destination, options: string.Empty);
        }

        // Builds a CopyFiles rule whose argument binds Source, Destination, and any optional switch text.
        private static ActionRuleModel NewRule(string source, string destination, string options)
        {
            return new ActionRuleModel
            {
                PluginName = nameof(CopyFiles),
                Argument = "{{$ --Source:" + source + " --Destination:" + destination + options + "}}"
            };
        }

        // Returns a unique temporary root so tests never share file-system state.
        private static string NewTestDirectory()
        {
            return Path.Combine(
                Path.GetTempPath(),
                nameof(CopyFilesTests),
                Guid.NewGuid().ToString("N"));
        }
    }
}
