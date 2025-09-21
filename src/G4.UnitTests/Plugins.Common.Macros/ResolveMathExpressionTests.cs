using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("ResolveMathExpression")]
    [TestCategory("UnitTest")]
    public class ResolveMathExpressionTests : TestBase
    {
        [TestMethod(displayName: "Verify that the ResolveMathExpression plugin manifest " +
            "complies with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ResolveMathExpression>(pluginName: "Resolve-MathExpression");
        }

        [TestMethod(displayName: "Verify that the ResolveMathExpression plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ResolveMathExpression>();
        }

        [TestMethod(displayName: "Verify that the subtraction operation and absolute value " +
            "calculation in math expressions produce the correct result.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}\"}", "^-8$")]
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}\"}", "^8$")]
        #endregion
        public void MathExpressionAbsoluteValueTest(string ruleJson, string expectedPattern)
        {
            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern);
        }

        [TestMethod(displayName: "Verify that the addition operation in math expressions " +
            "produces the correct result.")]
        public void MathExpressionAddTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:+}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^12$");
        }

        [TestMethod(displayName: "Verify that the division operation in math expressions " +
            "produces the correct result.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}\"}", "^5$")]
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:20 --Y:2 --Operation:\\\\}}\"}", "^10$")]
        #endregion
        public void MathExpressionDivideTest(string ruleJson, string expectedPattern)
        {
            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern);
        }

        [TestMethod(displayName: "Verify that the math expressions plugin handles invalid " +
            "operations correctly and produces an error result.")]
        public void MathExpressionInvalidOperationTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:INVALID}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^Err$");
        }

        [TestMethod(displayName: "Verify that the modulus operation in math expressions " +
            "produces the correct result.")]
        public void MathExpressionModulusTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^1$");
        }

        [TestMethod(displayName: "Verify that the multiplication operation in math " +
            "expressions produces the correct result.")]
        public void MathExpressionMultiplyTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^20$");
        }

        [TestMethod(displayName: "Verify that sorting input in ascending order before " +
            "performing the math operation in math expressions produces the correct result.")]
        public void MathExpressionOrderAscTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^3$");
        }

        [TestMethod(displayName: "Verify that sorting input in descending order before " +
            "performing the math operation in math expressions produces the correct result.")]
        public void MathExpressionOrderDescTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^1$");
        }

        [TestMethod(displayName: "Verify that the power operation in math expressions " +
            "produces the correct result.")]
        public void MathExpressionPowerTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^100$");
        }

        [TestMethod(displayName: "Verify that the result of math expressions can be rounded correctly.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/}}\"}", @"^\d+\.\d{3,}$")]
        [DataRow("{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}\"}", @"^\d+\.\d{2}$")]
        #endregion
        public void MathExpressionRoundTest(string ruleJson, string expectedPattern)
        {
            Invoke(testBase: this, ruleJson, expectedPattern);
        }

        [TestMethod(displayName: "Verify that the subtraction operation with decimal numbers " +
            "in math expressions produces the correct result.")]
        public void MathExpressionSubtractDecimalTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:0.5 --Operation:-}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^9.5$");
        }

        [TestMethod(displayName: "Verify that the subtraction operation in math expressions " +
            "produces the correct result.")]
        public void MathExpressionSubtractTest()
        {
            // Initialize the rule JSON for the test case
            const string ruleJson = "{\"argument\":\"{{$Resolve-MathExpression --X:10 --Y:2 --Operation:-}}\"}";

            // Invoke the action and assert the response contains the macro
            Invoke(testBase: this, ruleJson, expectedPattern: "^8$");
        }

        // Invoke the action and assert the response contains the macro
        // result and matches the expected pattern using regex
        private static void Invoke(
            TestBase testBase,
            string ruleJson,
            [StringSyntax(StringSyntaxAttribute.Regex)] string expectedPattern)
        {
            // Invoke the action and retrieve the actual response
            var actual = testBase
                .Invoke<ResolveMathExpression>(ruleJson)
                .Response;

            // Assert that the response contains the macro result
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the actual result matches the expected pattern using regex
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: expectedPattern));
        }
    }
}
