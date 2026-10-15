using G4.Models;
using G4.Plugins.Common.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("PathNotExists")]
    [TestCategory("UnitTest")]
    public class PathNotExistsTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the PathNotExists plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<PathNotExists>();
        }

        [TestMethod(DisplayName = "Verify that the PathNotExists plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<PathNotExists>();
        }

        [TestMethod(DisplayName = "Verify that PathNotExists evaluates to false for an existing directory.")]
        public void PathNotExistsDirectoryTest()
        {
            // Arrange: create an isolated directory to check.
            var directoryPath = NewTestDirectory();
            Directory.CreateDirectory(directoryPath);

            try
            {
                // Act: assert the directory path through the Assert plugin.
                var responseModel = Invoke([NewRule(directoryPath)]);

                // Assert: an existing directory fails the absence check.
                Assert.IsFalse(responseModel.GetEvaluation());
            }
            finally
            {
                // Remove the isolated directory so later tests start from a clean file system.
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that PathNotExists evaluates to false when OnElement is empty.")]
        public void PathNotExistsEmptyPathTest()
        {
            // Act: assert an empty path, which cannot identify a target.
            var responseModel = Invoke([NewRule(string.Empty)]);

            // Assert: the empty path never passes the absence check.
            Assert.IsFalse(responseModel.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that PathNotExists evaluates to false for an existing file.")]
        public void PathNotExistsFileTest()
        {
            // Arrange: create an isolated file to check.
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "exists.txt");
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(filePath, "exists");

            try
            {
                // Act: assert the file path through the Assert plugin.
                var responseModel = Invoke([NewRule(filePath)]);

                // Assert: an existing file fails the absence check.
                Assert.IsFalse(responseModel.GetEvaluation());
            }
            finally
            {
                // Remove the isolated directory so later tests start from a clean file system.
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that PathNotExists evaluates to true for a missing path.")]
        public void PathNotExistsMissingPathTest()
        {
            // Arrange: reference a unique path that was never created.
            var missingPath = Path.Combine(NewTestDirectory(), "missing.txt");

            // Act: assert the missing path through the Assert plugin.
            var responseModel = Invoke([NewRule(missingPath)]);

            // Assert: a missing path satisfies the absence check.
            Assert.IsTrue(responseModel.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that PathNotExists resolves a relative path from the process " +
            "working directory.")]
        public void PathNotExistsRelativePathTest()
        {
            // Arrange: create a unique file beneath the current process working directory.
            var relativeRoot = Path.Combine(nameof(PathNotExistsTests), Guid.NewGuid().ToString("N"));
            var relativeFile = Path.Combine(relativeRoot, "relative.txt");
            var directoryPath = Path.GetFullPath(relativeRoot, Directory.GetCurrentDirectory());
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(Path.Combine(directoryPath, "relative.txt"), "relative");

            try
            {
                // Act: assert the relative file path.
                var responseModel = Invoke([NewRule(relativeFile)]);

                // Assert: the relative path resolves against the working directory and is found, so the check fails.
                Assert.IsFalse(responseModel.GetEvaluation());
            }
            finally
            {
                // Remove the relative tree so the working directory stays clean between runs.
                DeleteTestDirectory(directoryPath);
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

        // Builds an Assert rule that evaluates the PathNotExists condition against the supplied path.
        private static ActionRuleModel NewRule(string path)
        {
            return new ActionRuleModel
            {
                PluginName = "Assert",
                Argument = "{{$ --Condition:" + nameof(PathNotExists) + "}}",
                OnElement = path
            };
        }

        // Returns a unique temporary root so tests never share file-system state.
        private static string NewTestDirectory()
        {
            return Path.Combine(
                Path.GetTempPath(),
                nameof(PathNotExistsTests),
                Guid.NewGuid().ToString("N"));
        }
    }
}
