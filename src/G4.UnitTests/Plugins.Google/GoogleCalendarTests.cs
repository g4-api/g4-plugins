using G4.Extensions;
using G4.Plugins.Google.Actions.Calendar;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

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
            AssertManifest<ExportGoogleCalendar>();
            AssertManifest<ExportGoogleCalendarList>();
            AssertManifest<NewGoogleCalendarEvent>();
            AssertManifest<RemoveGoogleCalendarEvent>();
        }

        [TestMethod(DisplayName = "Verify that the GoogleCalendar plugins are correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ExportGoogleCalendar>();
            AssertPlugin<ExportGoogleCalendarList>();
            AssertPlugin<NewGoogleCalendarEvent>();
            AssertPlugin<RemoveGoogleCalendarEvent>();
        }

        [Ignore]
        [TestMethod(DisplayName = "Verify that the ExportGoogleCalendarList plugin exports a " +
            "new calendar list correctly.")]
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

        [Ignore]
        [TestMethod(DisplayName = "Verify that the ExportGoogleCalendar plugin exports a " +
            "new calendar correctly.")]
        public void ExportGoogleCalendarTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(ExportGoogleCalendar);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ExportGoogleCalendar"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var result = session[$"{pluginName}:Id"]?.ToString();

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(result));
        }

        [Ignore]
        [TestMethod(DisplayName = "Verify that the RemoveGoogleCalendarEvent plugin removes a " +
            "calendar event correctly.")]
        public void RemoveGoogleCalendarEventTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Generate a date for the event (1 day in the future) to ensure it is always valid.
            var date = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd");

            // Create a temporary event first to obtain a valid event id for the delete operation.
            var createRuleJson =
            """
            {
                "$type": "Action",
                "pluginName": "NewGoogleCalendarEvent",
                "argument": "{{$ --Start:$(date)T10:00:00Z --End:$(date)T11:00:00Z --Summary:Automation Delete Test --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name).Replace("$(date)", date);

            // Invoke the create action and capture the event id from session parameters.
            var createSession = Invoke(createRuleJson).GetEnvironment().SessionParameters;
            var eventId = createSession[$"{nameof(NewGoogleCalendarEvent)}:Id"]?
                .ToString()
                .ConvertFromBase64();

            // Assert the event was created before attempting the delete.
            Assert.IsFalse(condition: string.IsNullOrEmpty(eventId));

            // Build the delete action rule using the captured event id.
            var deleteRuleJson =
            """
            {
                "$type": "Action",
                "pluginName": "RemoveGoogleCalendarEvent",
                "argument": "{{$ --EventId:$(eventId) --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name).Replace("$(eventId)", eventId);

            // Invoke the delete action — success is indicated by no exception being thrown.
            var removeSession = Invoke(deleteRuleJson);

            // Assert no exceptions were recorded in the session.
            Assert.IsEmpty(collection: removeSession.GetExceptions());
        }

        [Ignore]
        [TestMethod(DisplayName = "Verify that the NewGoogleCalendarEvent plugin creates a " +
            "new calendar event correctly.")]
        public void NewGoogleCalendarEventTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(NewGoogleCalendarEvent);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Generate a date for the event (1 day in the future) to ensure it's always valid.
            var date = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd");

            // Build the action rule JSON targeting the primary calendar with a timed event.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "NewGoogleCalendarEvent",
                "argument": "{{$ --Start:$(date)T10:00:00Z --End:$(date)T11:00:00Z --Summary:Automation Test Event --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name).Replace("$(date)", date);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var id = session[$"{pluginName}:Id"]?.ToString();
            var htmlLink = session[$"{pluginName}:HtmlLink"]?.ToString();

            // Assert the event was created and both key outputs are populated.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(htmlLink));
        }
    }
}
