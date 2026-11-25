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

        [TestMethod(DisplayName = "Verify that the CopyParameter plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<CopyParameter>();
        }

        [TestMethod(DisplayName = "Verify that the CopyParameter plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<CopyParameter>();
        }

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing.")]
        #region *** Data Set ***
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
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

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing during parameter copying between scopes.")]
        #region *** Data Set ***
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
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

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior for successful " +
            "parameter copying between scopes.")]
        #region *** Data Set ***
        [DataRow("Application", "Process")]
        [DataRow("Application", "Session")]
        [DataRow("Application", "User")]
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

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing. " +
            "Machine scope, administrator rights required.")]
        [TestCategory("LocalOnly")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        #endregion
        public void CopyParameterMissingMandatoryArgumentTestMachineScope(string sourceScope, string targetScope)
        {
            // Act and Assert: run the same scenario for the Machine scope, which writes the machine
            // registry and so needs an elevated local session; CI excludes this LocalOnly case.
            CopyParameterMissingMandatoryArgumentTest(sourceScope, targetScope);
        }

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior when a mandatory " +
            "argument is missing during parameter copying between scopes. " +
            "Machine scope, administrator rights required.")]
        [TestCategory("LocalOnly")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        #endregion
        public void CopyParameterMissingMandatoryPropertyTestMachineScope(string sourceScope, string targetScope)
        {
            // Act and Assert: run the same scenario for the Machine scope, which writes the machine
            // registry and so needs an elevated local session; CI excludes this LocalOnly case.
            CopyParameterMissingMandatoryPropertyTest(sourceScope, targetScope);
        }

        [TestMethod(DisplayName = "Verify the CopyParameter action behavior for successful " +
            "parameter copying between scopes. " +
            "Machine scope, administrator rights required.")]
        [TestCategory("LocalOnly")]
        #region *** Data Set ***
        [DataRow("Application", "Machine")]
        [DataRow("Machine", "Process")]
        [DataRow("Machine", "User")]
        [DataRow("Session", "Machine")]
        #endregion
        public void CopyParameterPositiveTestMachineScope(string sourceScope, string targetScope)
        {
            // Act and Assert: run the same scenario for the Machine scope, which writes the machine
            // registry and so needs an elevated local session; CI excludes this LocalOnly case.
            CopyParameterPositiveTest(sourceScope, targetScope);
        }

        // Cleans up the test environment.
        private static void CleanEnvironment()
        {
            // Remove the "ParameterName" environment variable from different targets (Machine, Process, User)
            RemoveMachineVariable("ParameterName");
            Environment.SetEnvironmentVariable("ParameterName", null, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("ParameterName", null, EnvironmentVariableTarget.User);

            // Remove the "CopiedParameterName" environment variable from different targets (Machine, Process, User)
            RemoveMachineVariable("CopiedParameterName");
            Environment.SetEnvironmentVariable("CopiedParameterName", null, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("CopiedParameterName", null, EnvironmentVariableTarget.User);
        }

        // Removes a Machine environment variable. Writing Machine variables needs administrator rights; a run
        // without them cannot have created the variable, so it has nothing to clean and the non-Machine rows still run.
        // The Machine rows carry the LocalOnly category and run only in an elevated local session.
        private static void RemoveMachineVariable(string name)
        {
            try
            {
                Environment.SetEnvironmentVariable(name, null, EnvironmentVariableTarget.Machine);
            }
            catch (System.Security.SecurityException)
            {
                // Not elevated: no Machine variable exists from this run, so there is nothing to remove.
            }
        }
    }
}
