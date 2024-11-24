using G4.Plugins.Ui.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui.Macros
{
    [TestClass]
    [TestCategory("GetDriverTypeName")]
    [TestCategory("UnitTest")]
    public class GetDriverTypeNameTests : TestBase
    {
        [TestMethod(displayName: "Verify that the GetDriverTypeName macro plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the macro plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<GetDriverTypeName>(pluginName: "Get-DriverTypeName");
        }

        [TestMethod(displayName: "Verify that the GetDriverTypeName macro plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the macro plugin can be instantiated without issues
            AssertPlugin<GetDriverTypeName>();
        }

        [TestMethod(displayName: "Verify that the GetDriverTypeName macro plugin returns an empty result " +
            "when the driver is null.")]
        public void GetDriverTypeNameNegativeTest()
        {
            // Invoke the macro to get the driver type name with a null driver
            var responseModel = Invoke<GetDriverTypeName>(capabilities: new Dictionary<string, object>
            {
                ["NullDriver"] = true
            });

            // Assert that the response contains exceptions when the driver is null
            Assert.IsTrue(responseModel.Response.Exceptions.Any(i => i.Exception is NullReferenceException));

            // Assert that the response contains the macro result
            Assert.IsTrue(responseModel.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the macro result is empty when the driver is null
            Assert.AreEqual(expected: string.Empty, responseModel.Response.Entity[MacroResultKey]);
        }

        [DataTestMethod(displayName: "Verify that the GetDriverTypeName macro plugin returns " +
            "the correct driver type name when a pattern is specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Pattern:[^.]+$}}""}")]
        #endregion
        public void GetDriverTypeNameByPatternTest(string ruleJson)
        {
            // Define the expected driver type name
            const string expected = "SimulatorDriver";

            // Invoke the macro to get the driver type name
            var resultModel = Invoke<GetDriverTypeName>(ruleJson).Response;

            // Assert that the response contains the macro result
            Assert.IsTrue(resultModel.Entity.ContainsKey(MacroResultKey));

            // Assert that the driver type name matches the expected value
            Assert.AreEqual(expected, resultModel.Entity[MacroResultKey]);
        }

        [TestMethod(displayName: "Verify that the GetDriverTypeName macro plugin returns the " +
            "correct driver type name.")]
        public void GetDriverTypeNameTest()
        {
            // Define the expected driver type name
            const string expected = "G4.WebDriver.Simulator.SimulatorDriver";

            // Invoke the macro to get the driver type name
            var resultModel = Invoke<GetDriverTypeName>().Response;

            // Assert that the response contains the macro result
            Assert.IsTrue(resultModel.Entity.ContainsKey(MacroResultKey));

            // Assert that the driver type name matches the expected value
            Assert.AreEqual(expected, resultModel.Entity[MacroResultKey]);
        }
    }
}
