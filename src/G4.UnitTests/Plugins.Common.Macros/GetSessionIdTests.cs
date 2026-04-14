using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("GetSessionId")]
    [TestCategory("UnitTest")]
    public class GetSessionIdTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GetSessionId plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<GetSessionId>(pluginName: "Get-SessionId");
        }

        [TestMethod(DisplayName = "Verify that the GetSessionId plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<GetSessionId>();
        }

        [TestMethod(DisplayName = "Verify that the GetSessionId plugin returns the active WebDriver session ID.")]
        public void GetSessionIdTest()
        {
            // Invoke the GetSessionId macro with no parameters and retrieve the response.
            var actual = Invoke<GetSessionId>(ruleJson: "{\"argument\":\"{{$Get-SessionId}}\"}").Response;

            // Assert that the response contains the MacroResult key.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Retrieve the session ID value from the macro result.
            var sessionId = $"{actual.Entity[MacroResultKey]}";

            // Assert that the session ID is not null or empty.
            Assert.IsFalse(string.IsNullOrEmpty(sessionId));
        }

        [TestMethod(DisplayName = "Verify that the GetSessionId plugin returns a session ID " +
            "matching the simulator driver format.")]
        public void GetSessionIdFormatTest()
        {
            // Invoke the GetSessionId macro and retrieve the response.
            var actual = Invoke<GetSessionId>(ruleJson: "{\"argument\":\"{{$Get-SessionId}}\"}").Response;

            // Retrieve the session ID string from the macro result.
            var sessionId = $"{actual.Entity[MacroResultKey]}";

            // Assert that the session ID matches the simulator driver format: simulator-<guid>
            Assert.IsTrue(
                Regex.IsMatch(sessionId, @"^simulator-\w{8}-(\w{4}-){3}\w{12}$"),
                $"Session ID '{sessionId}' does not match the expected simulator driver format.");
        }

        [TestMethod(DisplayName = "Verify that the GetSessionId plugin returns the same session ID " +
            "as the underlying WebDriver instance.")]
        public void GetSessionIdMatchesDriverTest()
        {
            // Invoke the GetSessionId macro and retrieve the test result.
            var result = Invoke<GetSessionId>(ruleJson: "{\"argument\":\"{{$Get-SessionId}}\"}");

            // Retrieve the session ID returned by the macro.
            var macroSessionId = $"{result.Response.Entity[MacroResultKey]}";

            // Retrieve the session ID directly from the plugin's WebDriver instance.
            var driverSessionId = ((IWebDriverSession)result.Plugin.WebDriver).Session.OpaqueKey;

            // Assert that both session IDs are equal.
            Assert.AreEqual(driverSessionId, macroSessionId);
        }
    }
}
