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
        [TestMethod(displayName: "Verify that the BodyHtmlExtractionScope, ElementsExtractionScope, " +
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

        [TestMethod(displayName: "Verify that the BodyHtmlExtractionScope, ElementsExtractionScope, " +
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

        [TestMethod(displayName: "Verify that the ExportData action rule extracts data " +
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
            Assert.AreEqual(expected: 2, actual: extractions.Count);
        }
    }
}
