using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionElementTextLengthTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> TextDataSet =>
        [
            // Element Text Length: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "25", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "25", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "25", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "25", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "25", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "25", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "25", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "25", ".*", "equal"],
            // Element Text Length: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "26", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "26", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "26", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "26", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "26", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "26", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "26", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "26", ".*", "notEqual"],
            // Element Text Length: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "greater"],
            // Element Text Length: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lower"],
            // Element Text Length: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "greaterEqual"],
            // Element Text Length: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lowerEqual"],
            // Element Text Length: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^25$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^25$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^25$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^25$", ".*", "match"],
            // Element Text Length: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^26$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^26$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^26$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^26$", ".*", "notMatch"],
            // Text Length: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "25", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "25", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "25", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "25", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "25", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "25", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "25", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "25", ".*", "equal"],
            // Text Length: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "26", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "26", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "26", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "26", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "26", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "26", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "26", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "26", ".*", "notEqual"],
            // Text Length: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "greater"],
            // Text Length: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lower"],
            // Text Length: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "greaterEqual"],
            // Text Length: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lowerEqual"],
            // Text Length: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^25$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^25$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^25$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^25$", ".*", "match"],
            // Text Length: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^26$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^26$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^26$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^26$", ".*", "notMatch"]
        ];

        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> AttributeDataSet =>
        [
            // Element Text Length: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "12", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "12", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "12", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "12", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "12", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "12", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "12", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "12", ".*", "equal"],
            // Element Text Length: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "13", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "13", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "13", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "13", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "13", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "13", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "13", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "13", ".*", "notEqual"],
            // Element Text Length: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "greater"],
            // Element Text Length: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lower"],
            // Element Text Length: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "1", @"\\d+", "greaterEqual"],
            // Element Text Length: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "3", @"\\d+", "lowerEqual"],
            // Element Text Length: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^12$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^12$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^12$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^12$", ".*", "match"],
            // Element Text Length: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^13$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementTextLength", "^13$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^13$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementtextLength", "^13$", ".*", "notMatch"],
            // Text Length: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "12", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "12", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "12", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "12", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "12", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "12", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "12", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "12", ".*", "equal"],
            // Text Length: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "notEqual"],
            // Text Length: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "greater"],
            // Text Length: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "11", ".*", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "11", ".*", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "11", ".*", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "11", ".*", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "11", ".*", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "11", ".*", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "11", ".*", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "11", ".*", "greater"],
            // Text Length: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lower"],
            // Text Length: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "13", ".*", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "13", ".*", "lower"],
            // Text Length: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "1", @"\\d+", "greaterEqual"],
            // Text Length: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "3", @"\\d+", "lowerEqual"],
            // Text Length: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^12$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^12$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^12$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^12$", ".*", "match"],
            // Text Length: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^13$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "TextLength", "^13$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^13$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "textLength", "^13$", ".*", "notMatch"]
        ];

        [TestMethod(DisplayName = "Verify that element attribute text length assertions handle " +
            "NoSuchElementException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(AttributeDataSet))]
        #endregion
        public void AttributeTextLengthNoSuchElementExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NoSuchElementException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element attribute text length assertions handle " +
            "NullReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(AttributeDataSet))]
        #endregion
        public void AttributeTextLengthNullReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NullReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element attribute text length assertions handle " +
            "StaleElementReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(AttributeDataSet))]
        #endregion
        public void AttributeTextLengthStaleElementReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is StaleElementReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element attribute text length assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(AttributeDataSet))]
        #endregion
        public void AttributeTextLengthTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
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

        [TestMethod(DisplayName = "Verify that element attribute text length assertions handle" +
            " WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(AttributeDataSet))]
        #endregion
        public void AttributeTextLengthWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element text length assertions handle " +
            "NoSuchElementException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(TextDataSet))]
        #endregion
        public void ElementTextLengthNoSuchElementExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NoSuchElementException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element text length assertions handle " +
            "NullReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(TextDataSet))]
        #endregion
        public void ElementTextLengthNullReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NullReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element text length assertions handle " +
            "StaleElementReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(TextDataSet))]
        #endregion
        public void ElementTextLengthStaleElementReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is StaleElementReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element text length assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(TextDataSet))]
        #endregion
        public void ElementTextLengthTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
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

        [TestMethod(DisplayName = "Verify that element text length assertions handle " +
            "WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(TextDataSet))]
        #endregion
        public void ElementTextLengthWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

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
    }
}
