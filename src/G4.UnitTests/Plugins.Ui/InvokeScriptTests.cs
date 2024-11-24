using G4.Extensions;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeScript")]
    [TestCategory("UnitTest")]
    public class InvokeScriptTests : TestBase
    {
        [TestMethod(displayName: "Verify that the InvokeScript plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeScript plugin can be created successfully
            AssertPlugin<InvokeScript>();
        }

        [TestMethod(displayName: "Verify that the InvokeScript plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeScript plugin is correct
            AssertManifest<InvokeScript>();
        }

        [TestMethod(displayName: "Verify the InvokeScript method with no arguments and " +
            "check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""return document.readyState;""}")]
        #endregion
        public void InvokeScriptArgumentTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(displayName: "Verify the InvokeScript method with script block and " +
            "check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptblock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptScriptBlockTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(displayName: "Verify the InvokeScript method with script block and " +
            "arguments, and check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        #endregion
        public void InvokeScriptScriptBlockWithArgumentsTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(displayName: "Verify the behavior of invoking a script with a script block, " +
            "arguments, and an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//negative"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//negative"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//negative"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        #endregion
        public void InvokeScriptScriptBlockWithArgumentsAndElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(displayName: "Verify the behavior of invoking a script with a script block " +
            "and an element for positive cases.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptblock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(displayName: "Verify the behavior of invoking a script with a script block " +
            "and a stale element, expecting a StaleElementReferenceException.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//stale"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithStaleElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(displayName: "Verify the behavior of invoking a script with a script block " +
            "and no element, expecting a NoSuchElementException.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//none"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithNoElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(displayName: "Verify the behavior of invoking a script with a script block " +
            "and an exception element, expecting a WebDriverException.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//exception"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithExceptionElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        // Invokes the script block test with the specified test base and action rule.
        private static void InvokeScriptTest(TestBase testBase, string ruleJson, bool onElement)
        {
            // Invoke the InvokeScript method with the specified action rule and retrieve the response model
            var responseModel = onElement
                ? testBase.Invoke<InvokeScript>(ruleJson, By.Custom.Positive()).Response
                : testBase.Invoke<InvokeScript>(ruleJson).Response;

            // Extract the ScriptResult from the session parameters, defaulting to an empty string if not present
            var scriptResult = responseModel
                .SessionParameters
                .Get(key: "ScriptResult", defaultValue: string.Empty);

            // Use a regex pattern to check if the script result matches certain states of document.readyState
            var actual = Regex.IsMatch(
                input: scriptResult,
                pattern: "uninitialized|loading|loaded|interactive|complete");

            // Assert that the actual result matches the expected pattern
            Assert.IsTrue(actual, "The InvokeScript method did not return the expected document.readyState value.");
        }
    }
}
