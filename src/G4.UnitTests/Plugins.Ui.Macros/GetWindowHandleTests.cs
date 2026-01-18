using G4.Plugins.Ui.Macros;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui.Macros
{
    [TestClass]
    [TestCategory("GetWindowHandle")]
    [TestCategory("UnitTest")]
    public class GetWindowHandleTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the macro plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<GetWindowHandle>(pluginName: "Get-WindowHandle");
        }

        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the macro plugin can be instantiated without issues
            AssertPlugin<GetWindowHandle>();
        }

        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin returns an empty result " +
            "when the driver is null.")]
        public void GetWindowHandleExceptionTest()
        {
            // Invoke the macro to get the driver type name with a null driver
            var testResult = Invoke<GetWindowHandle>(capabilities: new Dictionary<string, object>
            {
                ["ExceptionOnHandles"] = true
            });

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(testResult.Response.Exceptions.Any(i => i.Exception is WebDriverException));

            // Assert that the response contains the macro result
            Assert.IsTrue(testResult.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the macro result is empty when the driver is null
            Assert.AreEqual(expected: string.Empty, testResult.Response.Entity[MacroResultKey]);
        }

        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin returns " +
            "the correct window handle when a valid index is specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Index:1}}""}")]
        #endregion
        public void GetWindowHandleByIndexTest(string ruleJson)
        {
            // Apply capabilities to WebDriver
            var driver = new SimulatorDriver().AddCapabilities(new Dictionary<string, object>
            {
                [SimulatorCapabilities.ChildWindows] = 3
            });

            // Define the expected window handle
            var expected = driver.WindowHandles[1];

            // Invoke the macro to get the window handle
            var responseModel = Invoke<GetWindowHandle>(driver, ruleJson).Response;

            // Assert that the response contains the macro result
            Assert.IsTrue(responseModel.Entity.ContainsKey(MacroResultKey));

            // Assert that the window handle matches the expected value
            Assert.AreEqual(expected, responseModel.Entity[MacroResultKey]);
        }

        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin returns " +
            "the correct driver type name.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Index:a}}""}")]
        [DataRow(@"{""argument"":null}")]
        #endregion
        public void GetWindowHandleTest(string ruleJson)
        {
            // Define the expected driver type name
            const string expected = "window-.*";

            // Invoke the macro to get the driver type name
            var responseModel = Invoke<GetWindowHandle>(ruleJson).Response;

            // Assert that the response contains the macro result
            Assert.IsTrue(responseModel.Entity.ContainsKey(MacroResultKey));

            // Assert that the driver type name matches the expected value
            Assert.IsTrue(Regex.IsMatch(input: $"{responseModel.Entity[MacroResultKey]}", pattern: expected));
        }

        [TestMethod(DisplayName = "Verify that the GetWindowHandle macro plugin throws ArgumentOutOfRangeException " +
            "when an invalid index is specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Index:-1}}""}")]
        [DataRow(@"{""argument"":""{{$ --Index:200}}""}")]
        #endregion
        public void GetWindowHandleNegativeTest(string ruleJson)
        {
            // Invoke the GetWindowHandle plugin
            var responseModel = Invoke<GetWindowHandle>(ruleJson).Response;

            // Assert that the returned window handle matches the expected pattern
            Assert.IsTrue(responseModel.Exceptions.Any(i => i.Exception is ArgumentOutOfRangeException));
        }
    }
}
