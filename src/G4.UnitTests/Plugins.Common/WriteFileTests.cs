using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("WriteFile")]
    [TestCategory("UnitTest")]
    public class WriteFileTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the WriteFile plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<WriteFile>();
        }

        [TestMethod(DisplayName = "Verify that the WriteFile plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<WriteFile>();
        }

        [TestMethod(DisplayName = "Verify that WriteFile writes plain text to a full path and " +
            "creates missing parent directories.")]
        public void WriteFileAbsolutePathTest()
        {
            // Arrange: target a file beneath parent directories that do not exist yet.
            const string content = "Hello from WriteFile";
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "nested", "output.txt");

            try
            {
                // Act: execute the plugin through the full automation pipeline.
                var responseModel = Invoke([NewRule(filePath, content)]);

                // Assert: the directory and file are created with the expected content.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(filePath));
                Assert.AreEqual(expected: content, actual: File.ReadAllText(filePath));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile resolves relative paths from the process " +
            "working directory when Relative is specified.")]
        public void WriteFileRelativePathTest()
        {
            // Arrange: create a unique path relative to the current process working directory.
            const string content = "Relative file content";
            var relativeRoot = Path.Combine(nameof(WriteFileTests), Guid.NewGuid().ToString("N"));
            var relativePath = Path.Combine(relativeRoot, "nested", "relative.txt");
            var filePath = Path.GetFullPath(relativePath, Directory.GetCurrentDirectory());
            var directoryPath = Path.GetFullPath(relativeRoot, Directory.GetCurrentDirectory());

            try
            {
                // Act: execute with the Relative switch.
                var responseModel = Invoke([NewRule(relativePath, content, " --Relative")]);

                // Assert: the relative path is resolved from the working directory.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.IsTrue(File.Exists(filePath));
                Assert.AreEqual(expected: content, actual: File.ReadAllText(filePath));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile decodes Base64 content before writing it.")]
        public void WriteFileBase64ContentTest()
        {
            // Arrange: encode the expected text and enable Base64 decoding.
            const string content = "Base64 decoded content";
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "base64.txt");
            var encodedContent = content.ConvertToBase64();

            try
            {
                // Act: execute with Base64-encoded content.
                var responseModel = Invoke([NewRule(filePath, encodedContent, " --Base64")]);

                // Assert: the decoded text, rather than the encoded input, is written.
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: content, actual: File.ReadAllText(filePath));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile encrypts the final content before writing it.")]
        public void WriteFileEncryptedContentTest()
        {
            // Arrange: configure plaintext content and an encryption key.
            const string content = "Sensitive content";
            const string encryptionKey = "g4-test-key";
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "encrypted.txt");

            try
            {
                // Act: execute with the EncryptionKey parameter.
                var responseModel = Invoke([
                    NewRule(filePath, content, $" --EncryptionKey:{encryptionKey}")]);

                // Assert: the file does not contain plaintext and can be decrypted with the key.
                var encryptedContent = File.ReadAllText(filePath);
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreNotEqual(notExpected: content, actual: encryptedContent);
                Assert.AreEqual(expected: content, actual: encryptedContent.Decrypt(encryptionKey));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile decodes Base64 before encrypting the " +
            "resulting content.")]
        public void WriteFileBase64AndEncryptionOrderTest()
        {
            // Arrange: encode plaintext that must be decoded before encryption.
            const string content = "Decode before encryption";
            const string encryptionKey = "g4-order-key";
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "decoded-encrypted.txt");
            var encodedContent = content.ConvertToBase64();

            try
            {
                // Act: request both transformations in the required order.
                var responseModel = Invoke([
                    NewRule(filePath, encodedContent, $" --Base64 --EncryptionKey:{encryptionKey}")]);

                // Assert: decrypting the stored value recovers the decoded plaintext.
                var encryptedContent = File.ReadAllText(filePath);
                Assert.IsEmpty(responseModel.GetExceptions());
                Assert.AreEqual(expected: content, actual: encryptedContent.Decrypt(encryptionKey));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile overwrites a file with the same name.")]
        public void WriteFileOverwriteTest()
        {
            // Arrange: create two rules that target the same file with different content.
            const string originalContent = "Original content";
            const string replacementContent = "Replacement content";
            var directoryPath = NewTestDirectory();
            var filePath = Path.Combine(directoryPath, "overwrite.txt");

            try
            {
                // Act: write the file, then write to the same path again.
                var firstResponse = Invoke([NewRule(filePath, originalContent)]);
                var secondResponse = Invoke([NewRule(filePath, replacementContent)]);

                // Assert: the second write replaces the complete original value.
                Assert.IsEmpty(firstResponse.GetExceptions());
                Assert.IsEmpty(secondResponse.GetExceptions());
                Assert.AreEqual(expected: replacementContent, actual: File.ReadAllText(filePath));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        [TestMethod(DisplayName = "Verify that WriteFile rejects a relative path when Relative is " +
            "not specified.")]
        public void WriteFileRelativePathWithoutSwitchTest()
        {
            // Arrange: provide a relative path without the Relative switch.
            var relativeRoot = Path.Combine(nameof(WriteFileTests), Guid.NewGuid().ToString("N"));
            var relativePath = Path.Combine(relativeRoot, "invalid.txt");
            var directoryPath = Path.GetFullPath(relativeRoot, Directory.GetCurrentDirectory());

            try
            {
                // Act: execute without enabling relative path resolution.
                var responseModel = Invoke([NewRule(relativePath, "Content")]);

                // Assert: the plugin reports the invalid path and does not create the file.
                Assert.IsNotEmpty(responseModel.GetExceptions());
                Assert.IsFalse(File.Exists(Path.GetFullPath(relativePath)));
            }
            finally
            {
                DeleteTestDirectory(directoryPath);
            }
        }

        private static void DeleteTestDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive: true);
            }
        }

        private static ActionRuleModel NewRule(string path, string content, string options = "")
        {
            return new ActionRuleModel
            {
                PluginName = nameof(WriteFile),
                Argument = "{{$ --Path:" + path + " --Content:" + content + options + "}}"
            };
        }

        private static string NewTestDirectory()
        {
            return Path.Combine(
                Path.GetTempPath(),
                nameof(WriteFileTests),
                Guid.NewGuid().ToString("N"));
        }
    }
}
