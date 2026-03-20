using G4.Plugins.Google.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Google
{
    [Ignore]
    [TestClass]
    [TestCategory("GmailMail")]
    [TestCategory("UnitTest")]
    public class GmailMailTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GmailMail plugins comply with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ReadGmailMail>();
        }

        [TestMethod(DisplayName = "Verify that the GmailMail plugins are correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ReadGmailMail>();
        }

        [TestMethod(DisplayName = "Verify that the ReadGmailMail plugin " +
            "reads emails correctly.")]
        public void ReadMailTest()
        {
            // Plugin name used as the namespace prefix for session output keys.
            const string pluginName = nameof(ReadGmailMail);

            // Resolve the credential record name/id from the test configuration.
            // This value is injected into the rule so the plugin can authenticate
            // and read mail from the target Gmail account.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            // The rule invokes the ReadGmailMail plugin using the configured credentials.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ReadGmailMail",
                "argument": "{{$ --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name);

            // Execute the rule and capture the invocation result.
            // The plugin writes its outputs into the workflow session parameters
            // using the pattern: <PluginName>:<Property>.
            var session = Invoke(ruleJson);
            var sessionParameters = session.GetEnvironment().SessionParameters;

            // Verify that the plugin completed without reporting execution exceptions.
            Assert.IsEmpty(session.GetExceptions());

            // Verify that the plugin returned the Bcc header.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:Bcc"]?.ToString());

            // Verify that the plugin returned the Cc header.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:CC"]?.ToString());

            // Verify that the plugin returned the decoded mail body content.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:Content"]?.ToString());

            // Verify that the plugin returned the From header.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:From"]?.ToString());

            // Verify that the plugin returned the Gmail message id.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:Id"]?.ToString());

            // Verify that the plugin returned the Subject header.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:Subject"]?.ToString());

            // Verify that the plugin returned the To header.
            Assert.IsNotNull(value: sessionParameters[$"{pluginName}:To"]?.ToString());
        }
    }
}
