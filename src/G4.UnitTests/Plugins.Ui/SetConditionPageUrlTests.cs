using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionPageUrlTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Page URL: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://positive.io/20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://positive.io/20", ".*", "equal"],

            // Page URL: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "http://negative.io/21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "http://negative.io/21", ".*", "notEqual"],

            // Page URL: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "greater"],

            // Page URL: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "lower"],

            // Page URL: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "19", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "19", @"\\d+", "greaterEqual"],

            // Page URL: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", "21", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", "21", @"\\d+", "lowerEqual"],

            // Page URL: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", @"^http://positive\\.io/\\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", @"^http://positive\\.io/\\d+$", ".*", "match"],

            // Page URL: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageUrl", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageUrl", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],

            // Address: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://positive.io/20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://positive.io/20", ".*", "equal"],

            // Address: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "http://negative.io/21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "http://negative.io/21", ".*", "notEqual"],

            // Address: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "greater"],

            // Address: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "lower"],

            // Address: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "19", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "19", @"\\d+", "greaterEqual"],

            // Address: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", "21", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", "21", @"\\d+", "lowerEqual"],

            // Address: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", @"^http://positive\\.io/\\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", @"^http://positive\\.io/\\d+$", ".*", "match"],

            // Address: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Address", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "address", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],

            // Url: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://positive.io/20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://positive.io/20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://positive.io/20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://positive.io/20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://positive.io/20", ".*", "equal"],

            // Url: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "http://negative.io/21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://negative.io/21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://negative.io/21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://negative.io/21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "http://negative.io/21", ".*", "notEqual"],

            // Url: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "greater"],

            // Url: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "lower"],

            // Url: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "19", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "19", @"\\d+", "greaterEqual"],

            // Url: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", "21", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "20", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", "21", @"\\d+", "lowerEqual"],

            // Url: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", @"^http://positive\\.io/\\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", @"^http://positive\\.io/\\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", @"^http://positive\\.io/\\d+$", ".*", "match"],

            // Url: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Url", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", @"^\\d+ http://positive\\.io$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "url", @"^\\d+ http://positive\\.io$", ".*", "notMatch"],
        ];

        [TestMethod(DisplayName = "Verify that the plugin is correctly instantiated and " +
            "operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that URL value assertions handle WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void PageUrlWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, string.Empty)
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson, capabilities: new Dictionary<string, object>
            {
                ["ExceptionOnUrl"] = true
            });

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that URL assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void PageUrlTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, string.Empty)
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that no exceptions were thrown
            Assert.IsFalse(responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }
    }
}
