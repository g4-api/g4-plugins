using G4.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("ConvertToCanonicalKey")]
    [TestCategory("UnitTest")]
    public class ConvertToCanonicalKeyTests
    {
        [TestMethod(DisplayName = "Verify that ConvertToCanonicalKey maps recorder and layout key " +
            "spellings to the driver's canonical tokens.")]
        #region *** Data Set ***
        [DataRow("Num Enter", "Enter")]
        [DataRow("num enter", "Enter")]
        [DataRow("Page Up", "PgUp")]
        [DataRow("Page Down", "PgDn")]
        [DataRow("PageDown", "PgDn")]
        [DataRow("Insert", "Ins")]
        [DataRow("Delete", "Del")]
        [DataRow("Num Del", "Del")]
        [DataRow("Num Lock", "Num")]
        [DataRow("Scroll Lock", "Scroll")]
        [DataRow("Caps Lock", "CapsLock")]
        [DataRow("Space", "Spacebar")]
        [DataRow("Shift", "LShift")]
        [DataRow("Num 5", "5")]
        #endregion
        public void ConvertToCanonicalKeyKnownLabelTest(string key, string expected)
        {
            // Act: convert a known display spelling through the shared vocabulary layer.
            var actual = key.ConvertToCanonicalKey();

            // Assert: the display spelling resolves to the driver's canonical token.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertToCanonicalKey returns already-canonical, " +
            "plain-character, and empty labels unchanged.")]
        #region *** Data Set ***
        [DataRow("Enter", "Enter")]
        [DataRow("Tab", "Tab")]
        [DataRow("a", "a")]
        [DataRow("", "")]
        [DataRow(null, null)]
        #endregion
        public void ConvertToCanonicalKeyPassthroughTest(string key, string expected)
        {
            // Act: convert a label that is already canonical, a plain character, or empty/null.
            var actual = key.ConvertToCanonicalKey();

            // Assert: an unmapped label passes through unchanged so canonical tokens and typed text are preserved.
            Assert.AreEqual(expected, actual);
        }
    }
}
