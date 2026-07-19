using G4.Exceptions;
using G4.Plugins.Ui.Actions.User32;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeUser32ContextClick")]
    [TestCategory("UnitTest")]
    public class InvokeUser32ContextClickTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that InvokeUser32ContextClick performs a context click " +
            "at valid viewport coordinates.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --X:120 --Y:240}}""}")]
        [DataRow(@"{""argument"":""{{$ --X:-20 --Y:140}}""}")]
        #endregion
        public void ContextClickAtCoordinatesTest(string ruleJson)
        {
            // Act: invoke coordinate mode through the User32-capable simulator to exercise pointer movement and right-click dispatch.
            var response = Invoke<InvokeUser32ContextClick>(ruleJson).Response;

            // Assert: successful coordinate configurations complete without plugin or WebDriver exceptions.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32ContextClick reports invalid numeric " +
            "coordinate parameters.")]
        public void ContextClickInvalidCoordinateTest()
        {
            // Arrange: provide a non-numeric X value so parameter parsing fails before any pointer action is dispatched.
            const string ruleJson = @"{""argument"":""{{$ --X:invalid --Y:240}}""}";

            // Act and Assert: the normal plugin pipeline surfaces the exact numeric parameter format failure.
            Assert.Throws<FormatException>(() => Invoke<InvokeUser32ContextClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32ContextClick reports a missing target " +
            "when coordinates and an element are absent.")]
        public void ContextClickMissingTargetTest()
        {
            // Arrange: omit both coordinate parameters and OnElement to exercise explicit target validation.
            const string ruleJson = @"{""pluginName"":""InvokeUser32ContextClick""}";

            // Act and Assert: a User32-capable driver reports the domain validation error before element resolution.
            Assert.Throws<MissingMandatoryParameterException>(() => Invoke<InvokeUser32ContextClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32ContextClick returns without errors " +
            "when no User32 driver is available.")]
        public void ContextClickWithoutUser32DriverTest()
        {
            // Arrange: request the test framework's null-driver mode to represent an unsupported automation session.
            var capabilities = new Dictionary<string, object>
            {
                ["NullDriver"] = true
            };
            const string ruleJson = @"{""pluginName"":""InvokeUser32ContextClick""}";

            // Act: invoke the action without a driver so the compatibility guard returns before target validation.
            var response = Invoke<InvokeUser32ContextClick>(ruleJson, capabilities).Response;

            // Assert: unsupported sessions preserve the sibling User32 no-op contract without recording an exception.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that the InvokeUser32ContextClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the User32 resource namespace and satisfies G4 validation.
            AssertManifest<InvokeUser32ContextClick>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeUser32ContextClick plugin is registered " +
            "and can be created.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its approved setup-model constructor.
            AssertPlugin<InvokeUser32ContextClick>();
        }
    }
}
