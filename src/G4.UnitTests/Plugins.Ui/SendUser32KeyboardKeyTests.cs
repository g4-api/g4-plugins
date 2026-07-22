using G4.Plugins.Ui.Actions.User32;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SendUser32KeyboardKey")]
    [TestCategory("UnitTest")]
    public class SendUser32KeyboardKeyTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SendUser32KeyboardKey plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the User32 resource namespace and satisfies G4 validation.
            AssertManifest<SendUser32KeyboardKey>();
        }

        [TestMethod(DisplayName = "Verify that the SendUser32KeyboardKey plugin is registered " +
            "and can be created.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its approved setup-model constructor.
            AssertPlugin<SendUser32KeyboardKey>();
        }

        [TestMethod(DisplayName = "Verify that the SendUser32KeyboardKey action returns without errors " +
            "when no User32 driver is available.")]
        public void SendUser32KeyboardKeyWithoutUser32DriverTest()
        {
            // Arrange: request the test framework's null-driver mode to represent an unsupported automation session.
            var capabilities = new Dictionary<string, object>
            {
                ["NullDriver"] = true
            };
            const string ruleJson = @"{""argument"":""{{$ --Key:Enter}}""}";

            // Act: invoke the action without a driver so the compatibility guard returns before dispatching input.
            var response = Invoke<SendUser32KeyboardKey>(ruleJson, capabilities).Response;

            // Assert: unsupported sessions preserve the User32 no-op contract without recording an exception.
            Assert.IsEmpty(response.Exceptions);
        }
    }
}
