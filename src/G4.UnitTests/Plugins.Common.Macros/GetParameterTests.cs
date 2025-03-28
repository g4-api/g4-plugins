using G4.Models;
using G4.Plugins.Common.Macros;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass, DoNotParallelize]
    [TestCategory("GetParameter")]
    [TestCategory("UnitTest")]
    public class GetParameterTests : TestBase
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

        [TestMethod(displayName: "Verify that the GetParameter plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<GetParameter>(pluginName: "Get-Parameter");
        }

        [TestMethod(displayName: "Verify that the GetParameter plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<GetParameter>();
        }

        [TestMethod(displayName: "Verify that the GetParameter plugin retrieves the correct " +
            "parameter value for different scopes.")]
        #region *** Data Set ***
        [DataRow("Session")]
        [DataRow("Application")]
        [DataRow("Process")]
        [DataRow("Machine")]
        [DataRow("User")]
        #endregion
        public void GetParameterPositiveTest(string scope)
        {
            // Define the rules for registering and retrieving the parameter.
            var rules = new[]
            {
                // Rule for registering the parameter with the specified scope.
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:MyParam --Value:Foo Bar --Scope:" + scope + "}}",
                },
                // Rule for retrieving the parameter with the specified scope.
                new ActionRuleModel
                {
                    PluginName = "GetParameter",
                    Argument = "{{$ --Name:MyParam --Scope:" + scope + "}}"
                }
            };

            // Invoke the action rules and get the response.
            var response = Invoke(rules);

            // Retrieve the actual value of the parameter from the response.
            var actual = response.GetParameterValue(parameterName: "MyParam", scope);

            // Assert that the actual value (Base64 encoded) matches the expected value.
            Assert.AreEqual(expected: "Rm9vIEJhcg==", actual);
        }

        [TestMethod(displayName: "Verify that the GetParameter plugin retrieves the correct " +
            "parameter value for different scopes with encryption.")]
        #region *** Data Set ***
        [DataRow("Session")]
        [DataRow("Application")]
        [DataRow("Process")]
        [DataRow("Machine")]
        [DataRow("User")]
        #endregion
        public void GetParameterNegativeTest(string scope)
        {
            // Define the rules for registering and retrieving the parameter.
            var rules = new[]
            {
                // Rule for registering the parameter with the specified scope.
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:MyParam --Value:Foo Bar --Scope:" + scope + " --EncryptionKey:g4}}",
                },
                // Rule for retrieving the parameter with the specified scope.
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:MyDecryptedParam --Value:{{$Get-Parameter --Name:MyParam --Scope:" + scope + " --EncryptionKey:g4}} --Scope:" + scope + "}}"
                }
            };

            // Invoke the action rules and get the response.
            var response = Invoke(rules);

            // Retrieve the actual value of the parameter from the response.
            var actual = response.GetParameterValue(parameterName: "MyDecryptedParam", scope);

            // Assert that the actual value (Base64 encoded) matches the expected value.
            Assert.AreEqual(expected: "Rm9vIEJhcg==", actual);
        }
    }
}