using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Framework;
using G4.UnitTests.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("RegisterParameter")]
    [TestCategory("UnitTest")]
    public class RegisterParameterTests : TestBase
    {
        [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
        public static void ClearEnvironments()
        {
            // Remove the environment variable "MyParam" from the Machine target.
            Environment.SetEnvironmentVariable("MyParam", null, EnvironmentVariableTarget.Machine);

            // Remove the environment variable "MyParam" from the User target.
            Environment.SetEnvironmentVariable("MyParam", null, EnvironmentVariableTarget.User);

            // Remove the environment variable "MyParam" from the Process target.
            Environment.SetEnvironmentVariable("MyParam", null, EnvironmentVariableTarget.Process);
        }

        [TestMethod(displayName: "Verify that the RegisterParameter plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<RegisterParameter>();
        }

        [TestMethod(displayName: "Verify that the RegisterParameter plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<RegisterParameter>();
        }

        [DoNotParallelize]
        [TestMethod(displayName: "Verify that the application parameter is registered " +
            "correctly with a specific environment name.")]
        public void RegisterApplicationParameterTest()
        {
            // Create a new action rule model for registering a parameter.
            var rule = new ActionRuleModel
            {
                PluginName = "RegisterParameter",
                Argument = "{{$ " +
                    "--Environment:UnitTestsApplication " +
                    "--Name:MyParam " +
                    "--Value:Bar Foo " +
                    "--Scope:Application}}"
            };

            // Invoke the RegisterParameter plugin with the action rule.
            var responseModel = Invoke([rule]);

            // Retrieve the actual value of the parameter from the application parameters.
            var actual = responseModel.GetParameterValue(
                environmentName: "UnitTestsApplication",
                parameterName: "MyParam",
                scope: "Application");

            // Assert that the actual value (Base64 encoded) matches the expected value (Base64 encoded).
            Assert.IsTrue(actual.Equals("Bar Foo".ConvertToBase64(), Comparison));

            // Assert that the expected value matches the actual value (decoded from Base64).
            Assert.IsTrue("Bar Foo".Equals(actual.ConvertFromBase64(), Comparison));
        }

        [DoNotParallelize]
        [TestMethod(displayName: "Verify that the encrypted application parameter is registered " +
            "correctly with a specific environment name.")]
        public void RegisterApplicationEncryptedParameterTest()
        {
            // Create a new action rule model for registering a parameter.
            var rule = new ActionRuleModel
            {
                PluginName = "RegisterParameter",
                Argument = "{{$ " +
                    "--Environment:UnitTestsApplication " +
                    "--Name:MyParam " +
                    "--Value:Bar Foo " +
                    "--Scope:Application " +
                    "--EncryptionKey:g4}}"
            };

            // Invoke the RegisterParameter plugin with the action rule.
            var responseModel = Invoke([rule]);

            // Retrieve the actual value of the parameter from the application parameters.
            var actual = responseModel.GetParameterValue(
                environmentName: "UnitTestsApplication",
                parameterName: "MyParam",
                scope: "Application");

            // Assert that the expected value matches the actual value (decoded from Base64).
            Assert.IsTrue("Bar Foo".Equals(actual.ConvertFromBase64().Decrypt("g4"), Comparison));
        }

        [TestMethod(displayName: "Verify that the machine parameter is registered correctly.")]
        public void RegisterMachineParameterTest()
        {
            Invoke(testBase: this, scope: "Machine");
        }

        [TestMethod(displayName: "Verify that the process parameter is registered correctly.")]
        public void RegisterProcessParameterTest()
        {
            Invoke(testBase: this, scope: "Process");
        }

        [TestMethod(displayName: "Verify that the session parameter is registered correctly.")]
        public void RegisterSessionParameterTest()
        {
            Invoke(testBase: this, scope: "Session");
        }

        [TestMethod(displayName: "Verify that the user parameter is registered correctly.")]
        public void RegisterUserParameterTest()
        {
            Invoke(testBase: this, scope: "User");
        }

        private static void Invoke(TestBase testBase, string scope)
        {
            // Create a new action rule model for registering a parameter.
            var rule = new ActionRuleModel
            {
                PluginName = "RegisterParameter",
                Argument = "{{$ " +
                    "--Name:MyParam " +
                    "--Value:Bar Foo " +
                    "--Scope:" + scope + "}}"
            };

            // Invoke the RegisterParameter plugin with the action rule.
            var responseModel = testBase.Invoke([rule]);

            // Retrieve the actual value of the parameter from the user parameters.
            var actual = responseModel.GetParameterValue(parameterName: "MyParam", scope);

            // Assert that the actual value (Base64 encoded) matches the expected value (Base64 encoded).
            Assert.IsTrue(actual.Equals("Bar Foo".ConvertToBase64(), Comparison));

            // Assert that the expected value matches the actual value (decoded from Base64).
            Assert.IsTrue("Bar Foo".Equals(actual.ConvertFromBase64(), Comparison));
        }
    }
}
