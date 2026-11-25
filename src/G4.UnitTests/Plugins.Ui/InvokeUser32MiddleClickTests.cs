using G4.Exceptions;
using G4.Plugins.Ui.Actions.User32;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeUser32MiddleClick")]
    [TestCategory("UnitTest")]
    public class InvokeUser32MiddleClickTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that InvokeUser32MiddleClick performs a middle click " +
            "at valid viewport coordinates.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --X:120 --Y:240}}""}")]
        [DataRow(@"{""argument"":""{{$ --X:-20 --Y:140}}""}")]
        [DataRow(@"{""argument"":""{{$ --X:300}}""}")]
        #endregion
        public void MiddleClickAtCoordinatesTest(string ruleJson)
        {
            // Act: invoke coordinate mode through the User32-capable simulator to exercise pointer movement and middle-button dispatch.
            var response = Invoke<InvokeUser32MiddleClick>(ruleJson).Response;

            // Assert: successful coordinate configurations complete without plugin or WebDriver exceptions.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32MiddleClick resolves the element target " +
            "before it moves the pointer.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//none"",""argument"":""{{$ --X:120 --Y:240}}""}")]
        #endregion
        public void MiddleClickOnMissingElementTest(string ruleJson)
        {
            // Act and Assert: element mode takes precedence over coordinates, so a missing element ends the element wait.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<InvokeUser32MiddleClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32MiddleClick reports invalid numeric " +
            "positioning parameters.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --X:invalid --Y:240}}""}")]
        [DataRow(@"{""argument"":""{{$ --X:120 --Y:invalid}}""}")]
        [DataRow(@"{""argument"":""{{$ --OffsetX:invalid}}"",""onElement"":""//positive""}")]
        #endregion
        public void MiddleClickInvalidCoordinateTest(string ruleJson)
        {
            // Act and Assert: the normal plugin pipeline surfaces the numeric parameter format failure before any pointer action.
            Assert.Throws<FormatException>(() => Invoke<InvokeUser32MiddleClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32MiddleClick reports a missing target " +
            "when coordinates and an element are absent.")]
        public void MiddleClickMissingTargetTest()
        {
            // Arrange: omit both coordinate parameters and OnElement to exercise explicit target validation.
            const string ruleJson = @"{""pluginName"":""InvokeUser32MiddleClick""}";

            // Act and Assert: a User32-capable driver reports the domain validation error before element resolution.
            Assert.Throws<MissingMandatoryParameterException>(() => Invoke<InvokeUser32MiddleClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32MiddleClick returns without errors " +
            "when no User32 driver is available.")]
        public void MiddleClickWithoutUser32DriverTest()
        {
            // Arrange: request the test framework's null-driver mode to represent an unsupported automation session.
            var capabilities = new Dictionary<string, object>
            {
                ["NullDriver"] = true
            };
            const string ruleJson = @"{""pluginName"":""InvokeUser32MiddleClick""}";

            // Act: invoke the action without a driver so the compatibility guard returns before target validation.
            var response = Invoke<InvokeUser32MiddleClick>(ruleJson, capabilities).Response;

            // Assert: unsupported sessions preserve the sibling User32 no-op contract without recording an exception.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that the InvokeUser32MiddleClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the User32 resource namespace and satisfies G4 validation.
            AssertManifest<InvokeUser32MiddleClick>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeUser32MiddleClick plugin is registered " +
            "and can be created.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its approved setup-model constructor.
            AssertPlugin<InvokeUser32MiddleClick>();
        }
    }
}
