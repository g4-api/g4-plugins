using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("ConvertNumber")]
    [TestCategory("UnitTest")]
    public class ConvertNumberTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ConvertNumber>(pluginName: "Convert-Number");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ConvertNumber>();
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin converts between every pair of named bases.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:255 --From:Dec --To:Bin}}", "11111111")]
        [DataRow("{{$Convert-Number --Number:255 --From:Dec --To:Oct}}", "377")]
        [DataRow("{{$Convert-Number --Number:255 --From:Dec --To:Dec}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --From:Dec --To:Hex}}", "FF")]
        [DataRow("{{$Convert-Number --Number:11111111 --From:Bin --To:Oct}}", "377")]
        [DataRow("{{$Convert-Number --Number:11111111 --From:Bin --To:Dec}}", "255")]
        [DataRow("{{$Convert-Number --Number:11111111 --From:Bin --To:Hex}}", "FF")]
        [DataRow("{{$Convert-Number --Number:777 --From:Oct --To:Bin}}", "111111111")]
        [DataRow("{{$Convert-Number --Number:777 --From:Oct --To:Dec}}", "511")]
        [DataRow("{{$Convert-Number --Number:777 --From:Oct --To:Hex}}", "1FF")]
        [DataRow("{{$Convert-Number --Number:1fF --From:Hex --To:Bin}}", "111111111")]
        [DataRow("{{$Convert-Number --Number:1FF --From:Hex --To:Oct}}", "777")]
        [DataRow("{{$Convert-Number --Number:1FF --From:Hex --To:Dec}}", "511")]
        [DataRow("{{$Convert-Number --Number:0 --From:Hex --To:Bin}}", "0")]
        [DataRow("{{$Convert-Number --Number:ff --From:hex --To:dec}}", "255")]
        [DataRow("{{$Convert-Number --Number:255}}", "255")]
        #endregion
        public void ConvertNumberBaseTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the number is written in the target base.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin detects the source base from the number " +
            "prefix and accepts the prefix of a named base.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:0xFF}}", "255")]
        [DataRow("{{$Convert-Number --Number:0XfF}}", "255")]
        [DataRow("{{$Convert-Number --Number:#1E90FF}}", "2003199")]
        [DataRow("{{$Convert-Number --Number:0b1111}}", "15")]
        [DataRow("{{$Convert-Number --Number:0B1111}}", "15")]
        [DataRow("{{$Convert-Number --Number:0o755}}", "493")]
        [DataRow("{{$Convert-Number --Number:017}}", "15")]
        [DataRow("{{$Convert-Number --Number:0}}", "0")]
        [DataRow("{{$Convert-Number --Number:42 --From:Auto}}", "42")]
        [DataRow("{{$Convert-Number --Number:0xFF --From:Hex}}", "255")]
        [DataRow("{{$Convert-Number --Number:#FF --From:Hex}}", "255")]
        [DataRow("{{$Convert-Number --Number:0b101 --From:Bin}}", "5")]
        [DataRow("{{$Convert-Number --Number:0o17 --From:Oct}}", "15")]
        [DataRow("{{$Convert-Number --Number:0B12 --From:Hex}}", "2834")]
        #endregion
        public void ConvertNumberPrefixTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the prefix selects the source base and is not read as a digit.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin applies the prefix, case, and width options " +
            "to the result.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Prefix}}", "0xFF")]
        [DataRow("{{$Convert-Number --Number:5 --To:Bin --Prefix}}", "0b101")]
        [DataRow("{{$Convert-Number --Number:8 --To:Oct --Prefix}}", "0o10")]
        [DataRow("{{$Convert-Number --Number:0xFF --To:Dec --Prefix}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Case:Lower}}", "ff")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Case:upper}}", "FF")]
        [DataRow("{{$Convert-Number --Number:5 --To:Bin --Width:8}}", "00000101")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Width:1}}", "FF")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Prefix --Case:Lower --Width:4}}", "0x00ff")]
        [DataRow("{{$Convert-Number --Number:-255 --To:Hex --Prefix --Width:4}}", "-0x00FF")]
        #endregion
        public void ConvertNumberFormatTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the sign comes first, then the prefix, then the padded digits in the requested case.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin keeps the sign of a negative number and " +
            "writes two's complement values when BitWidth is set.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:-255 --To:Hex}}", "-FF")]
        [DataRow("{{$Convert-Number --Number:+255 --To:Hex}}", "FF")]
        [DataRow("{{$Convert-Number --Number:-0xFF --To:Dec}}", "-255")]
        [DataRow("{{$Convert-Number --Number:-0 --To:Hex}}", "0")]
        [DataRow("{{$Convert-Number --Number:-1 --To:Hex --BitWidth:8}}", "FF")]
        [DataRow("{{$Convert-Number --Number:-128 --To:Bin --BitWidth:8}}", "10000000")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --BitWidth:8}}", "FF")]
        [DataRow("{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16}}", "FFFF")]
        [DataRow("{{$Convert-Number --Number:-1 --To:Dec --BitWidth:32}}", "4294967295")]
        [DataRow("{{$Convert-Number --Number:-1 --To:Hex --BitWidth:64}}", "FFFFFFFFFFFFFFFF")]
        [DataRow("{{$Convert-Number --Number:-1 --To:Hex --BitWidth:16 --Prefix}}", "0xFFFF")]
        #endregion
        public void ConvertNumberSignTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the sign is kept without BitWidth and wrapped into the register with it.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin removes digit separators and converts " +
            "numbers of any length without overflow.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:1010_1100 --From:Bin}}", "172")]
        [DataRow("{{$Convert-Number --Number:1111 0000 --From:Bin --To:Hex}}", "F0")]
        [DataRow("{{$Convert-Number --Number:  0xFF   }}", "255")]
        [DataRow("{{$Convert-Number --Number:0xFFFFFFFFFFFFFFFFFFFF}}", "1208925819614629174706175")]
        [DataRow("{{$Convert-Number --Number:1208925819614629174706175 --To:Hex}}", "FFFFFFFFFFFFFFFFFFFF")]
        #endregion
        public void ConvertNumberLengthTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: separators are ignored and long numbers keep every digit.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin returns the original number when the input " +
            "or an argument is invalid.")]
        #region *** Data Set ***
        [DataRow("{{$Convert-Number --Number:102 --From:Bin}}", "102")]
        [DataRow("{{$Convert-Number --Number:789 --From:Oct}}", "789")]
        [DataRow("{{$Convert-Number --Number:FF --From:Dec}}", "FF")]
        [DataRow("{{$Convert-Number --Number:0xFG}}", "0xFG")]
        [DataRow("{{$Convert-Number --Number:0x}}", "0x")]
        [DataRow("{{$Convert-Number --Number:12.5 --To:Hex}}", "12.5")]
        [DataRow("{{$Convert-Number --Number:abc}}", "abc")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hexadecimal}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --From:Decimal}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Case:Title}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Width:-1}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --Width:two}}", "255")]
        [DataRow("{{$Convert-Number --Number:255 --To:Hex --BitWidth:12}}", "255")]
        [DataRow("{{$Convert-Number --Number:256 --To:Hex --BitWidth:8}}", "256")]
        [DataRow("{{$Convert-Number --Number:-129 --To:Hex --BitWidth:8}}", "-129")]
        #endregion
        public void ConvertNumberInvalidTest(string argument, string expected)
        {
            // Arrange: wrap the macro in the rule shape the engine resolves.
            var ruleJson = NewRuleJson(argument);

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the flow keeps the original number instead of failing.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the ConvertNumber plugin applies the engine Pattern argument to the " +
            "converted number.")]
        public void ConvertNumberPatternTest()
        {
            // Arrange: extract the two most significant hexadecimal digits of the converted number.
            var ruleJson = NewRuleJson(argument: "{{$Convert-Number --Number:65535 --To:Hex --Pattern:^\\\\w{2}}}");

            // Act: resolve the macro.
            var actual = Invoke<ConvertNumber>(ruleJson).Response.Entity[MacroResultKey];

            // Assert: the pattern runs on the converted value, not on the input.
            Assert.AreEqual(expected: "FF", actual: $"{actual}");
        }

        // Wraps a macro argument in the minimal action rule JSON that the test base invokes. The argument is written
        // into a JSON string, so callers escape backslashes for JSON (\\\\w for the regex \w).
        private static string NewRuleJson(string argument)
        {
            return $"{{\"argument\":\"{argument}\"}}";
        }
    }
}
