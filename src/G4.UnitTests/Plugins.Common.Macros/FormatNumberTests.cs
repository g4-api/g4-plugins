using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("FormatNumber")]
    [TestCategory("UnitTest")]
    public class FormatNumberTests : TestBase
    {
        [TestMethod(displayName: "Verify that the FormatNumber plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<FormatNumber>(pluginName: "Format-Number");
        }

        [TestMethod(displayName: "Verify that the FormatNumber plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<FormatNumber>();
        }

        [TestMethod(displayName: "Verify that the FormatNumber plugin correctly formats " +
            "numbers according to specified formats and cultures.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.45678       --Format:0.00   --Culture:en-US}}\"}", @"^0\.46$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.45678       --Format:0.00   --Culture:fr-FR}}\"}", "^0,46$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.45678       --Format:#.##   --Culture:en-US}}\"}", @"^\.46$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.45678       --Format:#.##   --Culture:fr-FR}}\"}", "^,46$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:2147483647    --Format:##,#   --Culture:en-US}}\"}", "^2,147,483,647$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:2147483647    --Format:##,#   --Culture:es-ES}}\"}", "^2.147.483.647$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:2147483647    --Format:#,#,,  --Culture:en-US}}\"}", "^2,147$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:2147483647    --Format:#,#,,  --Culture:es-ES}}\"}", "^2.147$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.3697        --Format:%#0.00 --Culture:en-US}}\"}", "^%36.97$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.3697        --Format:%#0.00 --Culture:el-GR}}\"}", "^%36,97$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.3697        --Format:##.0 % --Culture:en-US}}\"}", @"^37.0 \%$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.3697        --Format:##.0 % --Culture:el-GR}}\"}", @"^37,0 \%$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.03697       --Format:#0.00‰ --Culture:en-US}}\"}", "^36.97‰$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0.03697       --Format:#0.00‰ --Culture:ru-RU}}\"}", "^36,97‰$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.5678     --Format:00000}}\"}", "^01235$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.5678     --Format:#####}}\"}", "^1235$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:987654        --Format:#0.0e0}}\"}", "^98.8e4$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1503.92311    --Format:0.0##e+00}}\"}", @"^1.504e\+03$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1.8901385E-16 --Format:0.0e+00}}\"}", "^1.9e-16$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:987654        --Format:\\\\###00\\\\#}}\"}", "^#987654#$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:68            --Format:# 'degrees'}}\"}", "^68 degrees$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:68            --Format:#' degrees'}}\"}", "^68 degrees$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:12.345        --Format:#0.0#;(#0.0#);-\\\\0-}}\"}", "^12.35$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0             --Format:#0.0#;(#0.0#);-\\\\0-}}\"}", "^-0-$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-12.345       --Format:#0.0#;(#0.0#);-\\\\0-}}\"}", @"^\(12.35\)$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:12.345        --Format:#0.0#;(#0.0#)}}\"}", "^12.35$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:0             --Format:#0.0#;(#0.0#)}}\"}", "^0.0$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-12.345       --Format:#0.0#;(#0.0#)}}\"}", @"^\(12.35\)$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:68            --Format:# °}}\"}", "^68 °$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234567890    --Format:(###) ###-####}}\"}", @"^\(123\) 456-7890$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:42            --Format:My Number = #}}\"}", "^My Number = 42$")]
        #endregion
        public void CustomNumericFormatTest(string ruleJson, string expectedPattern)
        {
            // Invoke the action and retrieve the response model.
            var actual = Invoke<FormatNumber>(ruleJson).Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting number string matches the expected pattern using regular expression.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: expectedPattern));
        }

        [TestMethod(displayName: "Verify that the FormatNumber plugin throws a FormatException " +
            "for invalid numeric formats.")]
        [ExpectedException(typeof(FormatException))]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123456789.12345678 --Format:Z}}\"}")]
        #endregion
        public void StandardNumericFormatExceptionTest(string ruleJson)
        {
            // Invoke the action with the invalid format and expect a FormatException.
            Invoke<FormatNumber>(ruleJson);
        }

        [TestMethod(displayName: "Verify that the FormatNumber plugin correctly formats " +
            "numbers using standard numeric formats for various number formats and cultures.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123456789.12345678   --Format:R}}\"}", "^123456789.12345678$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234567890.12345678 --Format:R}}\"}", "^-1234567890.1234567$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:42                   --Format:B}}\"}", "^101010$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:255                  --Format:b16}}\"}", "^0000000011111111$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234                 --Format:D}}\"}", "^1234$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234                --Format:D6}}\"}", "^-001234$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:255                  --Format:X  --NumberType:Byte}}\"}", "^FF$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1                   --Format:x  --NumberType:SByte}}\"}", "^ff$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:255                  --Format:x4 --NumberType:Byte}}\"}", "^00ff$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1                   --Format:X4 --NumberType:SByte}}\"}", "^00FF$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123.456              --Format:C  --Culture:en-US}}\"}", @"^\$123\.46$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123.456              --Format:C  --Culture:fr-FR}}\"}", "^123,46 €$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123.456              --Format:C  --Culture:ja-JP}}\"}", @"^\W\s?123$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-123.456             --Format:C3 --Culture:en-US}}\"}", @"^-\$123\.456$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-123.456             --Format:C3 --Culture:fr-FR}}\"}", @"^-123,456\s?€$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-123.456             --Format:C3 --Culture:ja-JP}}\"}", @"^-\W\s?123\.456$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1052.0329112756      --Format:E  --Culture:en-US}}\"}", @"^1\.052033E\+003$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1052.0329112756      --Format:e  --Culture:fr-FR}}\"}", @"^1,052033e\+003$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1052.0329112756     --Format:e2 --Culture:en-US}}\"}", @"^-1\.05e\+003$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1052.0329112756     --Format:E2 --Culture:fr-FR}}\"}", @"^-1,05E\+003$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.567             --Format:F  --Culture:en-US}}\"}", @"^1234\.567$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.567             --Format:F  --Culture:de-DE}}\"}", "^1234,567$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234                 --Format:F1 --Culture:en-US}}\"}", @"^1234\.0$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234                 --Format:F1 --Culture:de-DE}}\"}", "^1234,0$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234.56             --Format:F4 --Culture:en-US}}\"}", @"^-1234\.5600$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234.56             --Format:F4 --Culture:de-DE}}\"}", "^-1234,5600$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-123.456             --Format:G  --Culture:en-US}}\"}", "^-123.456$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-123.456             --Format:G  --Culture:sv-SE}}\"}", "^−123,456$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123.4546             --Format:G4 --Culture:en-US}}\"}", "^123.5$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:123.4546             --Format:G4 --Culture:sv-SE}}\"}", "^123,5$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1.234567890e-25     --Format:G  --Culture:en-US}}\"}", "^-1.23456789E-25$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1.234567890e-25     --Format:G  --Culture:sv-SE}}\"}", "^−1,23456789E−25$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.567             --Format:N  --Culture:en-US}}\"}", @"^1,234\.567$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234.567             --Format:N  --Culture:ru-RU}}\"}", @"^1\s234,567$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234                 --Format:N1 --Culture:en-US}}\"}", @"^1,234\.0$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1234                 --Format:N1 --Culture:ru-RU}}\"}", @"^1\s234,0$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234.56             --Format:N3 --Culture:en-US}}\"}", @"^-1,234\.560$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-1234.56             --Format:N3 --Culture:ru-RU}}\"}", @"^-1\s234,560$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1                    --Format:P  --Culture:en-US}}\"}", @"^100\.\d+\s?\%$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:1                    --Format:P  --Culture:fr-FR}}\"}", @"^100,\d+\s?\%$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-0.39678             --Format:P1 --Culture:en-US}}\"}", @"^-39\.7\s?\%$")]
        [DataRow("{\"argument\":\"{{$Format-Number --Number:-0.39678             --Format:P1 --Culture:fr-FR}}\"}", @"^-39,7\s?\%$")]
        #endregion
        public void StandardNumericFormatTest(string ruleJson, string expectedPattern)
        {
            // Invoke the action and retrieve the response model.
            var actual = Invoke<FormatNumber>(ruleJson).Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting number string matches the expected pattern using regular expression.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: expectedPattern));
        }
    }
}
