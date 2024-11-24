using G4.Plugins.Ui.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui.Macros
{
    [TestClass]
    [TestCategory("NewScriptResult")]
    [TestCategory("UnitTest")]
    public class NewScriptResultTests : TestBase
    {
        [TestMethod(displayName: "Verify that the NewScriptResult macro plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the macro plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<NewScriptResult>(pluginName: "New-ScriptResult");
        }

        [TestMethod(displayName: "Verify that the NewScriptResult macro plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the macro plugin can be instantiated without issues
            AssertPlugin<NewScriptResult>();
        }

        [TestMethod(displayName: "Verify that the NewScriptResult macro plugin handles " +
            "exceptions during script execution.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Src:exception --Arg:5 --Arg:Foo Bar}}""}")]
        #endregion
        public void NewScriptResultExceptionTest(string ruleJson)
        {
            // Invoke the macro and retrieve the response model
            var actual = Invoke<NewScriptResult>(ruleJson).Response;

            // Assert that the response model contains the expected result
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that exceptions were caught during script execution
            Assert.IsTrue(actual.Exceptions.Any());
        }

        [TestMethod(displayName: "Verify that the NewScriptResult macro plugin executes " +
            "scripts with different arguments correctly.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Src:readyState --Arg:5 --Arg:Foo Bar}}""}")]
        [DataRow(@"{""argument"":""{{$ --Src:readyState --Arg:5 --arg:Foo Bar}}""}")]
        [DataRow(@"{""argument"":""{{$ --Src:readyState --Arg:{\""key\"":\""value\""} --Arg:Foo Bar}}""}")]
        [DataRow(@"{""argument"":""{{$ --Src:readyState --Arg:[{\""key\"":\""value\""},{\""key\"":\""value1\""}] --Arg:Foo Bar}}""}")]
        #endregion
        public void NewScriptResultPositiveTest(string ruleJson)
        {
            // Invoke the macro and retrieve the response model
            var actual = Invoke<NewScriptResult>(ruleJson).Response;

            // Assert that the response model contains the expected result
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Get the response string from the response model
            var input = $"{actual.Entity[MacroResultKey]}";

            // Assert that the response string matches the expected pattern
            Assert.IsTrue(Regex.IsMatch(input, pattern: "(?i)(uninitialized|loading|loaded|interactive|complete)"));
        }
    }
}
