using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Data;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("NewRandomNumber")]
    [TestCategory("UnitTest")]
    public class NewRandomNumberTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NewRandomNumber>(pluginName: "New-RandomNumber");
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NewRandomNumber>();
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin generates random " +
            "byte numbers within the specified range.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Byte}}\"}", byte.MinValue, byte.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100 --MaxValue:200 --NumberType:Byte}}\"}", (byte)100, (byte)200)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}\"}", (byte)100, byte.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MaxValue:200 --NumberType:Byte}}\"}", byte.MinValue, (byte)200)]
        #endregion
        public void NewRandomByteNumberTest(string ruleJson, byte minValue, byte maxValue)
        {
            // Invoke the action and retrieve the generated random number
            var input = Invoke<NewRandomNumber>(ruleJson)
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Parse the generated random number to a byte
            var actual = byte.Parse(input);

            // Assert that the generated random number is within the specified byte range
            Assert.IsGreaterThanOrEqualTo(minValue, actual);
            Assert.IsLessThanOrEqualTo(maxValue, actual);
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws a FormatException " +
            "for invalid byte number inputs.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Byte --MinValue:NotNumber --MaxValue:255}}\"}")]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Byte --MinValue:0 --MaxValue:NotNumber}}\"}")]
        #endregion
        public void NewRandomByteNumberFormatExceptionTest(string ruleJson)
        {
            // Invoke the action and expect a FormatException to be thrown
            Assert.Throws<FormatException>(() => Invoke<NewRandomNumber>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws an OverflowException " +
            "for invalid byte number range inputs.")]
        public void NewRandomByteNumberOverflowExceptionTest()
        {
            // Initialize the rule JSON with invalid range parameters
            const string ruleJson = "{\"argument\":\"{{$New-RandomNumber --MinValue:-1 --MaxValue:256 --NumberType:Byte}}\"}";

            // Assert that an OverflowException is thrown
            Assert.Throws<OverflowException>(() => Invoke<NewRandomNumber>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin generates random double " +
            "numbers within the specified range.")]
        public void NewRandomDoubleNumberTest()
        {
            // Invoke the action and retrieve the generated random number
            var input = Invoke<NewRandomNumber>(ruleJson: "{\"argument\":\"{{$New-RandomNumber --NumberType:Double}}\"}")
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Parse the generated random number to a double
            var actual = double.Parse(input);

            // Assert that the generated random number is within the specified double range
            Assert.IsGreaterThanOrEqualTo(0.0D, actual); // Ensuring the random double is greater than or equal 0.0
            Assert.IsLessThan(1.0D, actual);             // Ensuring the random double is less than 1.0
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin generates random float " +
            "numbers within the specified range.")]
        public void NewRandomFloatNumberTest()
        {
            // Invoke the action and retrieve the generated random number
            var input = Invoke<NewRandomNumber>(ruleJson: "{\"argument\":\"{{$New-RandomNumber --NumberType:Float}}\"}")
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Parse the generated random number to a float
            var actual = float.Parse(input);

            // Assert that the generated random number is within the specified float range
            Assert.IsGreaterThanOrEqualTo(0.0F, actual); // Ensuring the random float is greater than or equal 0.0
            Assert.IsLessThan(1.0F, actual);             // Ensuring the random float is less than 1.0
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin generates random " +
            "long numbers within the specified range.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Long}}\"}", long.MinValue, long.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100000 --MaxValue:200000 --NumberType:Long}}\"}", 100000L, 200000L)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100000 --NumberType:Long}}\"}", 100000L, long.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MaxValue:200000 --NumberType:Long}}\"}", long.MinValue, 200000L)]
        #endregion
        public void NewRandomLongNumberTest(string ruleJson, long minValue, long maxValue)
        {
            // Invoke the action and retrieve the generated random number
            var input = Invoke<NewRandomNumber>(ruleJson)
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Parse the generated random number to a long
            var actual = long.Parse(input);

            // Assert that the generated random number is within the specified long range
            Assert.IsGreaterThanOrEqualTo(minValue, actual);
            Assert.IsLessThanOrEqualTo(maxValue, actual);
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws a FormatException " +
            "for invalid long number inputs.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Long --MinValue:NotNumber --MaxValue:9223372036854775807}}\"}")]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --NumberType:Long --MinValue:-9223372036854775808 --MaxValue:NotNumber}}\"}")]
        #endregion
        public void NewRandomLongNumberFormatExceptionTest(string ruleJson)
        {
            // Invoke the action and expect a FormatException to be thrown
            Assert.Throws<FormatException>(() => Invoke<NewRandomNumber>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws an OverflowException " +
            "for invalid long number range inputs.")]
        public void NewRandomLongNumberOverflowExceptionTest()
        {
            // Initialize the rule JSON with invalid range parameters
            const string ruleJson = "{\"argument\":\"{{$New-RandomNumber " +
                "--MinValue:-9223372036854775809 " +
                "--MaxValue:9223372036854775808 " +
                "--NumberType:Long}}\"}";

            // Invoke the action and expect an OverflowException to be thrown
            Assert.Throws<OverflowException>(() => Invoke<NewRandomNumber>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin generates random integers within " +
            "the specified range.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$NewRandomNumber}}\"}", int.MinValue, int.MaxValue)]
        [DataRow("{\"argument\":\"{{$rndnum}}\"}", int.MinValue, int.MaxValue)]
        [DataRow("{\"argument\":\"{{$RndNum}}\"}", int.MinValue, int.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber}}\"}", int.MinValue, int.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100 --MaxValue:1000}}\"}", 100, 1000)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100}}\"}", 100, int.MaxValue)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MaxValue:1000}}\"}", int.MinValue, 1000)]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --Seed}}\"}", int.MinValue, int.MaxValue)]
        #endregion
        public void NewRandomNumberTest(string ruleJson, int minValue, int maxValue)
        {
            // Invoke the action and retrieve the generated random number
            var input = Invoke<NewRandomNumber>(ruleJson)
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Parse the generated random number to an integer
            var actual = int.Parse(input);

            // Assert that the generated random number is within the range of integers
            Assert.IsGreaterThanOrEqualTo(minValue, actual);
            Assert.IsLessThanOrEqualTo(maxValue, actual);
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws a FormatException for " +
            "invalid integer number inputs.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:NotNumber --MaxValue:100}}\"}")]
        [DataRow("{\"argument\":\"{{$New-RandomNumber --MinValue:100 --MaxValue:NotNumber}}\"}")]
        #endregion
        public void NewRandomNumberFormatExceptionTest(string ruleJson)
        {
            // Invoke the action and expect a FormatException to be thrown
            Assert.Throws<FormatException>(() => Invoke<NewRandomNumber>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the NewRandomNumber plugin throws an OverflowException " +
            "for invalid integer number range inputs.")]
        public void NewRandomNumberOverflowExceptionTest()
        {
            // Initialize the rule JSON with invalid range parameters
            var ruleJson = "{\"argument\":\"{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648}}\"}";

            // Invoke the action and expect an OverflowException to be thrown
            Assert.Throws<OverflowException>(() => Invoke<NewRandomNumber>(ruleJson));
        }
    }
}
