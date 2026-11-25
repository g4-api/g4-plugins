using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeScroll")]
    [TestCategory("UnitTest")]
    public class InvokeScrollTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeScroll plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the Actions resource namespace and satisfies G4 validation.
            AssertManifest<InvokeScroll>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its setup-model constructor.
            AssertPlugin<InvokeScroll>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with exception elements throws a WebDriverException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//exception"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithExceptionElementTest(string ruleJson)
        {
            // Act and Assert: a parent element that fails in the driver surfaces the WebDriver failure before any script runs.
            Assert.Throws<WebDriverException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with invalid elements throws a WebDriverTimeoutException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//stale"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//none"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --Top:10}}""}")]
        [DataRow(@"{""onElement"":""//exception"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithInvalidElementTest(string ruleJson)
        {
            // Act and Assert: a page-level element that never becomes available ends the element wait with a timeout.
            Assert.Throws<WebDriverTimeoutException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: false));
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with nested valid elements works as expected.")]
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
            // Act and Assert: absolute element scrolling inside a resolved parent completes without exceptions.
            InvokeScrollTest(testBase: this, ruleJson, onElement: true);
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with no elements throws a NoSuchElementException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//none"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithNoElementTest(string ruleJson)
        {
            // Act and Assert: a missing child element surfaces the driver lookup failure before any script runs.
            Assert.Throws<NoSuchElementException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with null elements throws a WebDriverException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//null"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithNullElementTest(string ruleJson)
        {
            // Act and Assert: a null child element surfaces the WebDriver failure before any script runs.
            Assert.Throws<WebDriverException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method with stale elements throws a StaleElementReferenceException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//stale"",""argument"":""{{$ --Top:10}}""}")]
        #endregion
        public void ScrollWithStaleElementTest(string ruleJson)
        {
            // Act and Assert: a stale child element surfaces the stale-reference failure before any script runs.
            Assert.Throws<StaleElementReferenceException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method works with valid arguments.")]
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
            // Act and Assert: absolute page scrolling completes without exceptions for every axis and behavior combination.
            InvokeScrollTest(testBase: this, ruleJson, onElement: false);
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method scrolls the page by relative offsets.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Top:240 --Relative}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:-240 --Relative}}""}")]
        [DataRow(@"{""argument"":""{{$ --Left:100 --Relative}}""}")]
        [DataRow(@"{""argument"":""{{$ --Top:240 --Left:100 --Relative --Behavior:smooth}}""}")]
        [DataRow(@"{""argument"":""{{$ --Relative}}""}")]
        #endregion
        public void ScrollRelativePositiveTest(string ruleJson)
        {
            // Act and Assert: relative page scrolling completes without exceptions, including the no-offset case that does nothing.
            InvokeScrollTest(testBase: this, ruleJson, onElement: false);
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method scrolls nested elements by relative offsets.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:240 --Relative}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Left:-10 --Relative}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Top:10 --Left:10 --Relative --Behavior:instant}}""}")]
        #endregion
        public void ScrollRelativeNestedPositiveTest(string ruleJson)
        {
            // Act and Assert: relative element scrolling inside a resolved parent completes without exceptions.
            InvokeScrollTest(testBase: this, ruleJson, onElement: true);
        }

        [TestMethod(DisplayName = "Verify that the InvokeScroll method in relative mode with stale elements " +
            "throws a StaleElementReferenceException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//stale"",""argument"":""{{$ --Top:10 --Relative}}""}")]
        #endregion
        public void ScrollRelativeWithStaleElementTest(string ruleJson)
        {
            // Act and Assert: element resolution still runs first in relative mode, so a stale element fails the step.
            Assert.Throws<StaleElementReferenceException>(()
                => InvokeScrollTest(testBase: this, ruleJson, onElement: true));
        }

        // Invokes InvokeScroll with or without a custom parent element and asserts that the response has no exceptions.
        private static void InvokeScrollTest(TestBase testBase, string ruleJson, bool onElement)
        {
            // Act: resolve the rule inside the custom positive parent for element scenarios, or against the page otherwise.
            var responseModel = onElement
                ? testBase.Invoke<InvokeScroll>(ruleJson, by: By.Custom.Positive()).Response
                : testBase.Invoke<InvokeScroll>(ruleJson).Response;

            // Assert: a successful scroll records no plugin or WebDriver exceptions in the response.
            Assert.IsEmpty(responseModel.Exceptions);
        }
    }
}
