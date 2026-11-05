using G4.Models;
using G4.Plugins.Ui.ExtractionScopes;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("ExportData")]
    [TestCategory("UnitTest")]
    public class ExportDataTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the BodyHtmlExtractionScope, ElementsExtractionScope, " +
            "and PageSourceExtractionScope plugin manifests comply with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the BodyHtmlExtractionScope plugin is correct
            AssertPlugin<BodyHtmlExtractionScope>();

            // Assert that the manifest documentation of the ElementsExtractionScope plugin is correct
            AssertPlugin<ElementsExtractionScope>();

            // Assert that the manifest documentation of the PageSourceExtractionScope plugin is correct
            AssertPlugin<PageSourceExtractionScope>();
        }

        [TestMethod(DisplayName = "Verify that the BodyHtmlExtractionScope, ElementsExtractionScope, " +
            "and PageSourceExtractionScope plugins are correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the BodyHtmlExtractionScope plugin can be created successfully
            AssertPlugin<BodyHtmlExtractionScope>();

            // Assert that the ElementsExtractionScope plugin can be created successfully
            AssertPlugin<ElementsExtractionScope>();

            // Assert that the PageSourceExtractionScope plugin can be created successfully
            AssertPlugin<PageSourceExtractionScope>();
        }

        [TestMethod(DisplayName = "Verify that the ExportData action rule extracts data " +
            "correctly for various extraction scopes.")]
        #region *** Data Set ***
        [DoNotParallelize]
        [DataRow("BodyHtml", "HtmlContent")]
        [DataRow("Elements", "WebElementContent")]
        [DataRow("PageSource", "HtmlContent")]
        #endregion
        public void ExportDataTest(string extractionScope, string contentType)
        {
            // Define the action rule model with the specified extraction scope
            var action = new ActionRuleModel
            {
                PluginName = "NoAction",
                Argument = "Export Data Container",
                Rules =
                [
                    new ExtractionRuleModel
                    {
                        Argument = "{{$ --Scope:" + extractionScope + "}}",
                        OnElement = "//positive",
                        Rules =
                        [
                            new ContentRuleModel
                            {
                                OnElement = ".//positive",
                                Key = "Description",
                                PluginName = contentType
                            }
                        ]
                    }
                ]
            };

            // Invoke the action rule and get the session response
            var session = Invoke([action]).Response.Values.First().Sessions.First().Value;

            // Extract the entities from the session
            var extractions = session.ResponseData.Extractions.First().Entities.ToList();

            // Assert that the number of extractions is 2
            Assert.HasCount(expected: 2, collection: extractions);
        }

        [TestMethod(DisplayName = "Verify that WebElementContent extracts an empty value instead of " +
            "failing when the requested attribute is missing on the element.")]
        [DoNotParallelize]
        public void ExportDataMissingAttributeTest()
        {
            // Arrange: request the "value" attribute, which the simulator reports as missing (null)
            // when the element does not carry it, alongside a regular text content rule.
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
                                OnAttribute = "value",
                                Key = "MissingAttribute",
                                PluginName = "WebElementContent"
                            },
                            new ContentRuleModel
                            {
                                OnElement = ".//positive",
                                Key = "Description",
                                PluginName = "WebElementContent"
                            }
                        ]
                    }
                ]
            };

            // Act: invoke the export and read the extracted entities from the session.
            var session = Invoke([action]).Response.Values.First().Sessions.First().Value;
            var entities = session.ResponseData.Extractions.First().Entities.ToList();

            // Assert: every entity keeps the missing-attribute key with an empty value.
            Assert.HasCount(expected: 2, collection: entities);
            foreach (var entity in entities)
            {
                Assert.IsTrue(entity.Content.ContainsKey("MissingAttribute"));
                Assert.AreEqual(expected: string.Empty, actual: $"{entity.Content["MissingAttribute"]}");
            }
        }
    }
}
