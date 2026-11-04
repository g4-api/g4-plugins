using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Contents;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("ValueContent")]
    [TestCategory("Content")]
    [TestCategory("UnitTest")]
    public class ValueContentTests : TestBase
    {
        // The key under which the content rules in these tests store their value.
        private const string ContentKey = "Source";

        [TestMethod(DisplayName = "Verify that the ValueContent plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ValueContent>();
        }

        [TestMethod(DisplayName = "Verify that the ValueContent plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ValueContent>();
        }

        [TestMethod(DisplayName = "Verify that ValueContent converts the argument value to the requested " +
            "data type.")]
        #region *** Data Set ***
        [DataRow("42.5", "Number", 42.5D)]
        [DataRow("true", "Boolean", true)]
        #endregion
        public void ValueContentDataTypeTest(string argument, string dataType, object expected)
        {
            // Arrange: a content rule that converts the argument to the requested data type.
            var rule = new ContentRuleModel
            {
                Argument = argument,
                DataType = dataType,
                Key = ContentKey,
                PluginName = "ValueContent"
            };

            // Act: invoke the content plugin directly.
            var actual = Invoke<ValueContent>(rule).Response.Entity.Get(key: ContentKey, defaultValue: default(object));

            // Assert: the stored value has the converted type and value.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that ValueContent converts the argument value to a DateTime when " +
            "the DateTime data type is requested.")]
        public void ValueContentDateTimeTest()
        {
            // Arrange: a content rule that converts an ISO date argument to a DateTime.
            var rule = new ContentRuleModel
            {
                Argument = "2026-11-04",
                DataType = "DateTime",
                Key = ContentKey,
                PluginName = "ValueContent"
            };

            // Act: invoke the content plugin directly.
            var actual = Invoke<ValueContent>(rule).Response.Entity.Get(key: ContentKey, defaultValue: default(object));

            // Assert: the stored value is the date of the argument.
            Assert.AreEqual(expected: new DateTime(year: 2026, month: 11, day: 4), actual);
        }

        [TestMethod(DisplayName = "Verify that ValueContent stores an empty string when the argument is " +
            "not set.")]
        public void ValueContentEmptyArgumentTest()
        {
            // Arrange: a content rule without an argument.
            var rule = new ContentRuleModel
            {
                Key = ContentKey,
                PluginName = "ValueContent"
            };

            // Act: invoke the content plugin directly.
            var entity = Invoke<ValueContent>(rule).Response.Entity;

            // Assert: the key is still written, with an empty string as its value.
            Assert.IsTrue(entity.ContainsKey(ContentKey), "The content key must be written for an empty argument.");
            Assert.AreEqual(expected: string.Empty, actual: $"{entity[ContentKey]}");
        }

        [TestMethod(DisplayName = "Verify that the ExportData action stores the ValueContent argument in " +
            "every extracted entity next to element content.")]
        public void ValueContentExportDataTest()
        {
            // Arrange: an extraction over two simulator elements, mixing element content with a value content.
            var action = new ActionRuleModel
            {
                PluginName = "NoAction",
                Argument = "Export Data Container",
                Rules =
                [
                    new ExtractionRuleModel
                    {
                        Argument = "{{$ --Scope:Elements}}",
                        OnElement = "//positive",
                        Rules =
                        [
                            new ContentRuleModel
                            {
                                OnElement = ".//positive",
                                Key = "Description",
                                PluginName = "WebElementContent"
                            },
                            new ContentRuleModel
                            {
                                Argument = "Web Shop",
                                Key = ContentKey,
                                PluginName = "ValueContent"
                            }
                        ]
                    }
                ]
            };

            // Act: run the automation through the G4 client.
            var session = Invoke([action]).Response.Values.First().Sessions.First().Value;

            // Retrieve the extracted entities from the session response.
            var entities = session.ResponseData.Extractions.First().Entities.ToList();

            // Assert: both entities hold the element content and the argument value.
            Assert.HasCount(expected: 2, collection: entities);
            foreach (var entity in entities)
            {
                Assert.IsTrue(entity.Content.ContainsKey("Description"), "Every entity must keep its element content.");
                Assert.AreEqual(expected: "Web Shop", actual: $"{entity.Content[ContentKey]}");
            }
        }

        [TestMethod(DisplayName = "Verify that ValueContent stores no value and reports an exception when " +
            "the rule is not a content rule.")]
        public void ValueContentNotContentRuleTest()
        {
            // Arrange: an action rule, which has no content key and is not supported by the content plugin.
            var rule = new ActionRuleModel
            {
                Argument = "Web Shop",
                PluginName = "ValueContent"
            };

            // Act: invoke the content plugin directly.
            var response = Invoke<ValueContent>(rule).Response;

            // Assert: no value is stored and the failure is reported on the response.
            Assert.IsFalse(response.Entity.ContainsKey(ContentKey), "No value may be stored for a non-content rule.");
            Assert.IsNotEmpty(response.Exceptions, "The response must report why the rule was rejected.");
        }

        [TestMethod(DisplayName = "Verify that ValueContent applies the regular expression to the argument " +
            "value before storing it.")]
        public void ValueContentRegularExpressionTest()
        {
            // Arrange: a content rule that keeps only the numeric part of the argument.
            var rule = new ContentRuleModel
            {
                Argument = "Order-12345-Details",
                Key = ContentKey,
                PluginName = "ValueContent",
                RegularExpression = @"\d+"
            };

            // Act: invoke the content plugin directly.
            var actual = Invoke<ValueContent>(rule).Response.Entity.Get(key: ContentKey, defaultValue: default(object));

            // Assert: only the first matched portion of the argument is stored.
            Assert.AreEqual(expected: "12345", actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that ValueContent stores the argument value under the rule key.")]
        public void ValueContentTest()
        {
            // Arrange: a content rule with a plain text argument.
            var rule = new ContentRuleModel
            {
                Argument = "Web Shop",
                Key = ContentKey,
                PluginName = "ValueContent"
            };

            // Act: invoke the content plugin directly.
            var actual = Invoke<ValueContent>(rule).Response.Entity.Get(key: ContentKey, defaultValue: default(object));

            // Assert: the argument value is stored as is.
            Assert.AreEqual(expected: "Web Shop", actual: $"{actual}");
        }
    }
}
