using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeScroll")]
    [TestCategory("UnitTest")]
    public class InvokeScrollTests : TestBase
    {
        [TestMethod(displayName: "Verify that the InvokeScroll plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeScroll plugin is correct
            AssertManifest<InvokeScroll>();
        }

        [TestMethod(displayName: "Verify that the InvokeScroll plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeScroll plugin can be created successfully
            AssertPlugin<InvokeScroll>();
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with exception elements throws a WebDriverException.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//exception"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithExceptionElementTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: true);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with invalid elements throws a WebDriverTimeoutException.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//stale"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//none"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//exception"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithInvalidElementTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: false);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with nested valid elements works as expected.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Left:10}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Behavior:instant}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Behavior:auto}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Left:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Left:10 --Behavior:instant}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Left:10 --Behavior:auto}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Left:10}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Left:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Left:10 --Behavior:instant}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Left:10 --Behavior:auto}}""}")]
        #endregion
        public void ScrollNestedPositiveTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: true);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with no elements throws a NoSuchElementException.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//none"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithNoElementTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: true);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with null elements throws a WebDriverException.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//null"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithNullElementTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: true);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method with stale elements throws a StaleElementReferenceException.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//stale"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithStaleElementTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: true);
        }

        [DataTestMethod(displayName: "Verify that the InvokeScroll method works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""argument"":""{{$ --Left:10}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Behavior:instant}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Behavior:auto}}""}")]
        [DataRow(@"{""argument"":""{{$ --Left:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""argument"":""{{$ --Left:10 --Behavior:instant}}""}")]
        [DataRow(@"{""argument"":""{{$ --Left:10 --Behavior:auto}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Left:10}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Left:10 --Behavior:smooth}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Left:10 --Behavior:instant}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:10 --Left:10 --Behavior:auto}}""}")]
        #endregion
        public void ScrollPositiveTest(string ruleJson)
        {
            // Invoke the scroll test with the specified rule JSON
            InvokeScrollTest(this, ruleJson, onElement: false);
        }

        // Invokes the Scroll test with the specified test base and action rule.
        private static void InvokeScrollTest(TestBase testBase, string ruleJson, bool onElement)
        {
            // Invoke the action based on whether it's on an element or not
            var responseModel = onElement
                ? testBase.Invoke<InvokeScroll>(ruleJson, By.Custom.Positive()).Response
                : testBase.Invoke<InvokeScroll>(ruleJson).Response;

            // Ensure there are no exceptions in the response model
            Assert.IsFalse(responseModel.Exceptions.Any());
        }
    }
}
