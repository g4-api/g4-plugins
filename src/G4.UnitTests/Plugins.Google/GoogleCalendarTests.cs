using G4.Plugins.Google.Actions.Calendar;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Google
{
    [TestClass]
    [TestCategory("GoogleCalendar")]
    [TestCategory("UnitTest")]
    public class GoogleCalendarTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GoogleCalendar plugins comply with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ExportGoogleCalendarList>();
        }

        [TestMethod(DisplayName = "Verify that the GoogleCalendar plugins are correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ExportGoogleCalendarList>();
        }

        //[Ignore(message: "Runs as part of the GoogleTaskListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the NewGoogleTaskList plugin creates a " +
            "new tasks list correctly.")]
        public void ExportGoogleCalendarListTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(ExportGoogleCalendarList);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ExportGoogleCalendarList"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var result = session[$"{pluginName}:Result"]?.ToString();

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(result));
        }
    }
}
