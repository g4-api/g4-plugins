using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("NewDate")]
    [TestCategory("UnitTest")]
    public class NewDateTests : TestBase
    {
        [TestMethod(displayName: "Verify that the NewDate plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NewDate>(pluginName: "New-Date");
        }

        [TestMethod(displayName: "Verify that the NewDate plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NewDate>();
        }

        [TestMethod(displayName: "Verify that the NewDate plugin correctly adds the specified " +
            "time to the current date.")]
        public void NewDateAddTimeTest()
        {
            // Invoke the action and retrieve the response model.
            var macroResult = Invoke<NewDate>(ruleJson: "{\"argument\":\"{{$New-Date --AddTime:24.00:00:00}}\"}")
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Get the current date and time.
            var actual = DateTime.UtcNow;

            // Parse the expected date and time from the macro result.
            var expected = DateTime.Parse(macroResult, CultureInfo.InvariantCulture);

            // Assert that the difference in days between expected and actual is at least 23.
            Assert.IsTrue(Math.Round((expected - actual).TotalDays, 0) >= 23);
        }

        [TestMethod(displayName: "Verify that the NewDate plugin correctly formats the date " +
            "and matches the specified pattern.")]
        public void NewDatePatternTest()
        {
            // Invoke the action and retrieve the response model.
            var actual = Invoke<NewDate>(ruleJson: "{\"argument\":\"{{$New-Date --Format:yyyy-MM-dd --Pattern:\\\\d{2}}}\"}").Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting date string matches the expected pattern.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: @"^\d{2}$"));
        }

        [TestMethod(displayName: "Verify that the NewDate plugin correctly subtracts the " +
            "specified time from the current date.")]
        public void NewDateSubtractTimeTest()
        {
            // Invoke the action and retrieve the response model.
            var macroResult = Invoke<NewDate>(ruleJson: "{\"argument\":\"{{$New-Date --SubtructTime:24.00:00:00}}\"}")
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Get the current date and time.
            var actual = DateTime.UtcNow;

            // Parse the expected date and time from the macro result.
            var expected = DateTime.Parse(macroResult, CultureInfo.InvariantCulture);

            // Assert that the difference in days between expected and actual is at least 23.
            Assert.IsTrue(Math.Round((actual - expected).TotalDays, 0) >= 23);
        }

        [TestMethod(displayName: "Verify that the NewDate plugin correctly handles various " +
            "date formats, parts, and patterns.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$date}}\"}", @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{6}[+-]\d{2}:\d{2}$")]
        [DataRow("{\"argument\":\"{{$New-Date --Format:yyyy-MM-dd}}\"}", @"^\d{4}-\d{2}-\d{2}$")]
        [DataRow("{\"argument\":\"{{$New-Date --Format:yyyy-MM-dd --Utc}}\"}", @"^\d{4}-\d{2}-\d{2}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Year}}\"}", @"^\d{4}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Month}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Day}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Hour}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Minute}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Second}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Millisecond}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Nanosecond}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Microsecond}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --DatePart:Ticks}}\"}", @"^\d{1,}$")]
        [DataRow("{\"argument\":\"{{$New-Date --UnixEpoch}}\"}", @"^\d{10}$")]
        [DataRow("{\"argument\":\"{{$New-Date --OaDate}}\"}", @"^\d+\.\d+$")]
        #endregion
        public void NewDateTest(string ruleJson, string expectedPattern)
        {
            // Invoke the action and retrieve the response model.
            var actual = Invoke<NewDate>(ruleJson).Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting date string matches the expected pattern.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: expectedPattern));
        }
    }
}
