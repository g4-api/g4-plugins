using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [DoNotParallelize]
    [TestCategory("CopyParameter")]
    [TestCategory("UnitTest")]
    public class CopyParameterTests : TestBase
    {
        /// <summary>
        /// Cleans up the test environment before the test execution.
        /// </summary>
        [TestInitialize]
        public override void TestSetup()
        {
            // Delegate environment cleanup to the CleanEnvironment method
            CleanEnvironment();

            // Call the base class's TestSetup method
            base.TestSetup();
        }

        /// <summary>
        /// Cleans up the test environment after the test execution.
        /// </summary>
        [TestCleanup]
        public void TestTeardown()
        {
            // Delegate environment cleanup to the CleanEnvironment method
            CleanEnvironment();
        }

        [TestMethod(displayName: "Verify that the CopyParameter plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<CopyParameter>();
        }

        [TestMethod(displayName: "Verify that the CopyParameter plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<CopyParameter>();
        }

        [TestMethod(displayName: "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing.")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        [DataRow("Session", "Process")]
        [DataRow("Session", "Session")]
        [DataRow("Session", "User")]
        [DataRow("User", "Process")]
        #endregion
        public void CopyParameterMissingMandatoryArgumentTest(string sourceScope, string targetScope)
        {
            // Create a list of action rules to register and copy a parameter
            var rules = new List<ActionRuleModel>
            {
                // Rule to register a parameter with a specified scope
                new()
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:ParameterName --Value:Foo Bar --Scope:" + sourceScope + "}}",
                },
                // Rule to copy the parameter with a specified target scope, but missing mandatory arguments
                new()
                {
                    PluginName = "CopyParameter",
                    Argument = "{{$ " + $"--TargetScope:{targetScope}" + "}}",
                    OnElement = "ParameterName",
                    OnAttribute = sourceScope
                }
            };

            // Invoke the test with the initialized rules collection.
            var resultModel = Invoke(rules);

            // Retrieve the expected and actual parameter values from the response.
            var notExpected = resultModel.GetParameterValue(parameterName: "ParameterName", scope: sourceScope);
            var actual = resultModel.GetParameterValue(parameterName: "CopiedParameterName", scope: targetScope);

            // Assert that the copied parameter value does not match the expected value.
            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod(displayName: "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing during parameter copying between scopes.")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        [DataRow("Session", "Process")]
        [DataRow("Session", "Session")]
        [DataRow("Session", "User")]
        [DataRow("User", "Process")]
        #endregion
        public void CopyParameterMissingMandatoryPropertyTest(string sourceScope, string targetScope)
        {
            // Define a set of actions, including registering a parameter and copying it between scopes.
            var rules = new[]
            {
                // Action to register a parameter with a specified scope
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:ParameterName --Value:Foo Bar --Scope:" + sourceScope + "}}",
                },
                // Action to copy the parameter with a specified target scope and target parameter name,
                // but missing mandatory properties
                new ActionRuleModel
                {
                    PluginName = "CopyParameter",
                    Argument = "{{$ " +
                        "--TargetParameter:CopiedParameterName " +
                        $"--TargetScope:{targetScope}" + "}}",
                    OnAttribute = sourceScope
                }
            };

            // Invoke the test with the initialized rules collection.
            var resultModel = Invoke(rules);

            // Retrieve the expected and actual parameter values from the response.
            var notExpected = resultModel.GetParameterValue(parameterName: "ParameterName", scope: sourceScope);
            var actual = resultModel.GetParameterValue(parameterName: "CopiedParameterName", scope: targetScope);

            // Assert that the copied parameter value does not match the expected value.
            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod(displayName: "Verify the CopyParameter action behavior for successful " +
            "parameter copying between scopes.")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        [DataRow("Session", "Process")]
        [DataRow("Session", "Session")]
        [DataRow("Session", "User")]
        [DataRow("User", "Process")]
        #endregion
        public void CopyParameterPositiveTest(string sourceScope, string targetScope)
        {
            // Define a set of actions, including registering a parameter and copying it between scopes
            var rules = new[]
            {
                // Action to register a parameter with a specified scope
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:ParameterName --Value:Foo Bar --Scope:" + sourceScope + "}}",
                },
                // Action to copy the parameter with a specified target scope and target parameter name
                new ActionRuleModel
                {
                    PluginName = "CopyParameter",
                    Argument = "{{$ " +
                        "--TargetParameter:CopiedParameterName " +
                        $"--TargetScope:{targetScope}" + "}}",
                    OnElement = "ParameterName",
                    OnAttribute = sourceScope
                }
            };

            // Invoke the test with the initialized rules collection.
            var resultModel = Invoke(rules);

            // Retrieve the expected and actual parameter values from the response.
            var expected = resultModel.GetParameterValue(parameterName: "ParameterName", scope: sourceScope);
            var actual = resultModel.GetParameterValue(parameterName: "CopiedParameterName", scope: targetScope);

            // Assert that the copied parameter value matches the expected value.
            Assert.AreEqual(expected, actual);
        }

        // Cleans up the test environment.
        private static void CleanEnvironment()
        {
            // Remove the "ParameterName" environment variable from different targets (Machine, Process, User)
            Environment.SetEnvironmentVariable("ParameterName", null, EnvironmentVariableTarget.Machine);
            Environment.SetEnvironmentVariable("ParameterName", null, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("ParameterName", null, EnvironmentVariableTarget.User);

            // Remove the "CopiedParameterName" environment variable from different targets (Machine, Process, User)
            Environment.SetEnvironmentVariable("CopiedParameterName", null, EnvironmentVariableTarget.Machine);
            Environment.SetEnvironmentVariable("CopiedParameterName", null, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("CopiedParameterName", null, EnvironmentVariableTarget.User);
        }
    }
}
