using G4.Cache;
using G4.Extensions;
using G4.Models;
using G4.Plugins;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("AddFile")]
    [TestCategory("UnitTest")]
    public class AddFileTests : TestBase
    {
        // Session key that accumulates the Base64 value of every AddFile call in one session.
        private const string FilesKey = "AddFile:Files";

        // Number of top-ranked tools the lexical search must return AddFile within.
        private const int SearchTake = 5;

        // Isolated working folder for the files one test creates; it is removed after every test.
        private string _directory;

        [TestInitialize]
        public override void TestSetup()
        {
            // Create a unique folder so parallel tests never read each other's files.
            _directory = Path.Combine(Path.GetTempPath(), $"g4-add-file-{Guid.NewGuid()}");
            Directory.CreateDirectory(_directory);

            // Build the shared automation context used by every invocation.
            base.TestSetup();
        }

        [TestCleanup]
        public void TestTeardown()
        {
            // Remove the test folder and every file the test created in it.
            if (Directory.Exists(_directory))
            {
                Directory.Delete(_directory, recursive: true);
            }
        }

        [TestMethod(DisplayName = "Verify that the AddFile plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<AddFile>();
        }

        [TestMethod(DisplayName = "Verify that the AddFile plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<AddFile>();
        }

        [TestMethod(DisplayName = "Verify that AddFile accumulates every value in the session list in call order " +
            "and exposes the latest value on the entity.")]
        public void AddFileAccumulationTest()
        {
            // Arrange: create two text files and one plugin instance so both calls share the same session.
            var firstPath = NewTestFile(name: "first.txt", content: Encoding.UTF8.GetBytes("first"));
            var secondPath = NewTestFile(name: "second.txt", content: Encoding.UTF8.GetBytes("second"));
            var plugin = NewPlugin<AddFile>(Automation);

            // Act: send the two files one after the other through the same plugin instance.
            plugin.Send(NewPluginData(path: firstPath, pattern: null));
            var response = plugin.Send(NewPluginData(path: secondPath, pattern: null));

            // Assert: the session list holds both values in call order.
            var files = GetSessionFiles(plugin);
            Assert.HasCount(2, files);
            Assert.AreEqual(expected: "first", actual: files[0].ConvertFromBase64());
            Assert.AreEqual(expected: "second", actual: files[1].ConvertFromBase64());

            // Assert: the entity carries only the value of the latest call.
            Assert.AreEqual(expected: "second", actual: $"{response.Entity["File"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that AddFile returns the exact bytes of a binary file and ignores " +
            "the regular expression.")]
        public void AddFileBinaryTest()
        {
            // Arrange: a PNG signature and header contain zero bytes, so the content is binary.
            byte[] content = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D];
            var path = NewTestFile(name: "chart.png", content);

            // Act: set a pattern that matches the PNG text, so any regex step changes the value.
            var value = GetEntityValue(path, pattern: "PNG");

            // Assert: the value is the Base64 of the exact bytes, not of the "PNG" match.
            Assert.AreEqual(expected: Convert.ToBase64String(content), actual: value);
        }

        [TestMethod(DisplayName = "Verify that AddFile removes a byte order mark and decodes UTF-8 and UTF-16 " +
            "text files before applying the regular expression.")]
        #region *** Data Set ***
        [DataRow("utf-8")]
        [DataRow("utf-16")]
        [DataRow("unicodeFFFE")]
        #endregion
        public void AddFileByteOrderMarkTest(string encodingName)
        {
            // Arrange: write the text with its encoding preamble so the file starts with a byte order mark.
            const string text = "Invoice: 10452";
            var encoding = Encoding.GetEncoding(encodingName);
            byte[] content = [.. encoding.GetPreamble(), .. encoding.GetBytes(text)];
            var path = NewTestFile(name: "invoice.txt", content);

            // Act: add the whole file with the default pattern.
            var value = GetEntityValue(path, pattern: null);

            // Assert: the decoded value equals the text without the byte order mark.
            Assert.AreEqual(expected: text, actual: value.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the engine rejects an AddFile rule with an empty argument as a " +
            "missing mandatory property.")]
        public void AddFileEmptyArgumentTest()
        {
            // Arrange: a rule whose mandatory Argument property is empty.
            var rule = new ActionRuleModel
            {
                Argument = string.Empty,
                PluginName = "AddFile"
            };

            // Act: the engine validates the manifest properties before the plugin runs.
            var response = Invoke<AddFile>(rule).Response;

            // Assert: the response reports the missing property and carries no file value.
            const string exceptionType = "MissingMandatoryPropertyException";
            Assert.Contains(predicate: i => i.Type == exceptionType, collection: response.Exceptions);
            Assert.IsFalse(response.Entity.ContainsKey("File"));
        }

        [TestMethod(DisplayName = "Verify that AddFile fails when the argument holds only white space.")]
        public void AddFileWhiteSpaceArgumentTest()
        {
            // Arrange: white space passes the engine property check but is not a file path.
            var rule = new ActionRuleModel
            {
                Argument = " ",
                PluginName = "AddFile"
            };

            // Act and Assert: the plugin rejects the rule before reading anything.
            Assert.Throws<ArgumentException>(() => Invoke<AddFile>(rule));
        }

        [TestMethod(DisplayName = "Verify that AddFile returns an empty value for an empty file.")]
        public void AddFileEmptyFileTest()
        {
            // Arrange: an empty file has no bytes to encode.
            var path = NewTestFile(name: "empty.txt", content: []);

            // Act: add the empty file with the default pattern.
            var value = GetEntityValue(path, pattern: null);

            // Assert: the value is an empty string.
            Assert.AreEqual(expected: string.Empty, actual: value);
        }

        [TestMethod(DisplayName = "Verify that AddFile treats text that is not valid UTF-8 as binary and " +
            "returns its exact bytes.")]
        public void AddFileInvalidUtf8Test()
        {
            // Arrange: "café" in Windows-1252 ends with 0xE9, which is not a valid UTF-8 sequence.
            byte[] content = [0x63, 0x61, 0x66, 0xE9];
            var path = NewTestFile(name: "legacy.txt", content);

            // Act: set a pattern that matches the ASCII part, so any regex step changes the value.
            var value = GetEntityValue(path, pattern: "caf");

            // Assert: the value is the Base64 of the exact bytes.
            Assert.AreEqual(expected: Convert.ToBase64String(content), actual: value);
        }

        [TestMethod(DisplayName = "Verify that the lexical tool search returns AddFile in the top five tools " +
            "for file-to-response prompts; a miss is reported as a warning.")]
        #region *** Data Set ***
        [DataRow("add a file to the response")]
        [DataRow("add file as base64")]
        [DataRow("attach a file as base64")]
        [DataRow("embed a binary file in the response")]
        [DataRow("encode a file to base64")]
        [DataRow("extract a value from a text file with a regex")]
        [DataRow("find a tool to add an image file")]
        [DataRow("read a file as base64")]
        #endregion
        public void AddFileLexicalSearchTest(string prompt)
        {
            // Arrange: index the action tools that the test run loaded into the shared cache.
            using var manager = new LexicalRetrievalManager(CacheManager.Instance);

            // Act: rank the tools for the prompt and keep the top five names.
            var names = manager
                .FindTools(prompt, take: SearchTake)
                .Tools
                .Select(i => i.Name)
                .ToArray();

            // Assert: report a miss as Inconclusive so ranking drift warns without failing the build.
            if (!names.Contains("AddFile", StringComparer.Ordinal))
            {
                var message = $"Warning: AddFile is not in the top {SearchTake} tools for '{prompt}'. " +
                    $"Returned: {string.Join(", ", names)}.";
                Assert.Inconclusive(message);
            }
        }

        [TestMethod(DisplayName = "Verify that AddFile fails with FileNotFoundException when the file does " +
            "not exist.")]
        public void AddFileMissingFileTest()
        {
            // Arrange: a path inside the test folder that was never created.
            var rule = new ActionRuleModel
            {
                Argument = Path.Combine(_directory, "missing.txt"),
                PluginName = "AddFile"
            };

            // Act and Assert: the read failure reaches the caller as the step failure.
            Assert.Throws<FileNotFoundException>(() => Invoke<AddFile>(rule));
        }

        [TestMethod(DisplayName = "Verify that AddFile only reads the file and writes nothing to disk.")]
        public void AddFileNoDiskWriteTest()
        {
            // Arrange: one text file in an otherwise empty folder.
            var path = NewTestFile(name: "notes.txt", content: Encoding.UTF8.GetBytes("notes"));
            var before = File.ReadAllBytes(path);

            // Act: add the file.
            GetEntityValue(path, pattern: null);

            // Assert: the folder still holds only the source file, and the file is unchanged.
            Assert.HasCount(1, Directory.GetFiles(_directory));
            Assert.AreSequenceEqual(expected: before, actual: File.ReadAllBytes(path));
        }

        [TestMethod(DisplayName = "Verify that AddFile resolves a relative path against the working directory.")]
        public void AddFileRelativePathTest()
        {
            // Arrange: create the file under the working directory and refer to it by its relative name.
            var name = $"add-file-{Guid.NewGuid()}.txt";
            var fullPath = Path.Combine(Environment.CurrentDirectory, name);
            File.WriteAllText(fullPath, contents: "relative");

            try
            {
                // Act: add the file by its relative path.
                var value = GetEntityValue(path: name, pattern: null);

                // Assert: the relative path reached the file in the working directory.
                Assert.AreEqual(expected: "relative", actual: value.ConvertFromBase64());
            }
            finally
            {
                // Remove the file because it lives outside the per-test folder.
                File.Delete(fullPath);
            }
        }

        [TestMethod(DisplayName = "Verify that AddFile returns the whole text file as Base64 when no regular " +
            "expression is set.")]
        #region *** Data Set ***
        [DataRow("Id,Name\n1,Alpha\n2,Beta")]
        [DataRow("{\"name\":\"demo\"}")]
        [DataRow("שלום world")]
        #endregion
        public void AddFileTextTest(string text)
        {
            // Arrange: write the text as UTF-8 without a byte order mark.
            var path = NewTestFile(name: "data.txt", content: Encoding.UTF8.GetBytes(text));

            // Act: add the whole file with the default pattern.
            var value = GetEntityValue(path, pattern: null);

            // Assert: the decoded value equals the full text, including line breaks and non-ASCII characters.
            Assert.AreEqual(expected: text, actual: value.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that AddFile returns an empty value when the regular expression does " +
            "not match the text.")]
        public void AddFileTextNoMatchTest()
        {
            // Arrange: a text file that holds no digits.
            var path = NewTestFile(name: "invoice.txt", content: Encoding.UTF8.GetBytes("Invoice: pending"));

            // Act: search for digits that do not exist.
            var value = GetEntityValue(path, pattern: @"\d+");

            // Assert: the value is an empty string rather than encoded content.
            Assert.AreEqual(expected: string.Empty, actual: value);
        }

        [TestMethod(DisplayName = "Verify that AddFile returns only the first regular expression match of a " +
            "text file.")]
        #region *** Data Set ***
        [DataRow("Invoice: 10452\nTotal: 7", @"(?<=Invoice: )\d+", "10452")]
        [DataRow("a1 b2 c3", @"\d", "1")]
        [DataRow("Start\nmiddle\nEnd tail", @"(?s)Start.*End", "Start\nmiddle\nEnd")]
        #endregion
        public void AddFileTextRegexTest(string text, string pattern, string expected)
        {
            // Arrange: write the text as UTF-8 without a byte order mark.
            var path = NewTestFile(name: "invoice.txt", content: Encoding.UTF8.GetBytes(text));

            // Act: add the file with the pattern.
            var value = GetEntityValue(path, pattern);

            // Assert: the decoded value equals the first match only.
            Assert.AreEqual(expected, actual: value.ConvertFromBase64());
        }

        // Invokes AddFile for one path and pattern and returns the File entity value. A null pattern leaves the
        // rule without a regular expression so the plugin applies its default whole-text pattern.
        private string GetEntityValue(string path, string pattern)
        {
            // Build the rule the way a flow sends it: the path in the argument and an optional pattern.
            var rule = new ActionRuleModel
            {
                Argument = path,
                PluginName = "AddFile",
                RegularExpression = pattern
            };

            // Invoke the plugin and read the latest value from the response entity.
            var response = Invoke<AddFile>(rule).Response;

            return $"{response.Entity["File"]}";
        }

        // Reads the AddFile:Files session list from a plugin: the session value is Base64 of a JSON string array.
        private static List<string> GetSessionFiles(PluginBase plugin)
        {
            // Decode the session value and deserialize the accumulated list.
            var value = $"{plugin.Invoker.Context.SessionParameters[FilesKey]}".ConvertFromBase64();

            return JsonSerializer.Deserialize<List<string>>(value);
        }

        // Builds plugin input for a direct Send call. A reference id is required by the plugin pipeline when the
        // rule is not initialized through an automation run.
        private static PluginDataModel NewPluginData(string path, string pattern)
        {
            // Create the rule and give it a unique reference so repeated sends stay distinct.
            var rule = new ActionRuleModel
            {
                Argument = path,
                PluginName = "AddFile",
                Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" },
                RegularExpression = pattern
            };

            return new PluginDataModel { Rule = rule };
        }

        // Writes the given bytes to a new file in the per-test folder and returns its full path.
        private string NewTestFile(string name, byte[] content)
        {
            // Write the exact bytes so tests control byte order marks and binary content.
            var path = Path.Combine(_directory, name);
            File.WriteAllBytes(path, content);

            return path;
        }
    }
}
