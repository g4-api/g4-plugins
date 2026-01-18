using G4.UnitTests.Attributes;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("OperatorExternal")]
    [TestCategory("UnitTest")]
    public class OperatorExternalTests : TestBase
    {
        [Ignore(IgnoreMessage = "Requires external service not available on CI/CD environment.")]
        [RetryableTestMethod(
            numberOfAttempts: 5,
            DisplayName = "Verify that the ExternalOperator plugin handles exceptions correctly and evaluates the condition.",
            DelayBetweenAttempts = 3000)]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonExternal, "index", "Between", "0", "ElementAttribute", "//positive")]
        [DataRow(Stubs.RuleJsonExternal, "index", "between", "0", "ElementAttribute", "//positive")]
        #endregion
        public void ExternalOperatorExceptionTest(
            string ruleJson,
            string onAttribute,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnPluginName, "Assert")
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Invoke the action rule and get the plugin
            var testResult = Invoke(ruleJson, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["actual"] = "true"
            });

            // Check if the evaluation returns true
            Assert.IsTrue(testResult.GetEvaluation());
        }
    }
}
