using G4.Models;
using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementCountTests : TestBase
    {
        // Data set for positive test cases
        private static IEnumerable<object[]> PositiveDataSet =>
        [
            // Element Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "equal"],
            // Element Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "notEqual"],
            // Element Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "greater"],
            // Element Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "lower"],
            // Element Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "greaterEqual"],
            // Element Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "lowerEqual"],
            // Element Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^[1-9]+$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^[1-9]+$", "match"],
            // Element Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "notMatch"],
            // Elements Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "equal"],
            // Elements Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "notEqual"],
            // Elements Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "greater"],
            // Elements Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "lower"],
            // Elements Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "greaterEqual"],
            // Elements Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "lowerEqual"],
            // Elements Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^[1-9]+$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^[1-9]+$", "match"],
            // Elements Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "notMatch"],
            // Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "equal"],
            // Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "notEqual"],
            // Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "greater"],
            // Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "lower"],
            // Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "greaterEqual"],
            // Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "lowerEqual"],
            // Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^[1-9]+$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^[1-9]+$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^[1-9]+$", "match"],
            // Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "notMatch"]
        ];

        // Data set for negative test cases
        private static IEnumerable<object[]> NegativeDataSet =>
        [
            // Element Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "equal"],
            // Element Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "2", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "2", "notEqual"],
            // Element Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "greater"],
            // Element Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lower"],
            // Element Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "3", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "3", "greaterEqual"],
            // Element Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lowerEqual"],
            // Element Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "match"],
            // Element Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", @"^\\d+$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", @"^\\d+$", "notMatch"],
            // Elements Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "equal"],
            // Elements Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "2", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "2", "notEqual"],
            // Elements Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "greater"],
            // Elements Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lower"],
            // Elements Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "3", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "3", "greaterEqual"],
            // Elements Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lowerEqual"],
            // Elements Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "match"],
            // Elements Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", @"^\\d+$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", @"^\\d+$", "notMatch"],
            // Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "equal"],
            // Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "2", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "2", "notEqual"],
            // Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "greater"],
            // Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lower"],
            // Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "3", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "3", "greaterEqual"],
            // Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lowerEqual"],
            // Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "match"],
            // Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "Count", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", @"^\\d+$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", @"^\\d+$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", @"^\\d+$", "notMatch"]
        ];

        // Data set for zero count test cases (count = 0)
        private static IEnumerable<object[]> ZeroCountDataSet =>
        [
            // Element Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "equal"],
            // Element Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "notEqual"],
            // Element Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "greater"],
            // Element Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lower"],
            // Element Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "greaterEqual"],
            // Element Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "0", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "0", "lowerEqual"],
            // Element Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^0$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^0$", "match"],
            // Element Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementCount", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementCount", "^ABC$", "notMatch"],
            // Elements Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "equal"],
            // Elements Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "notEqual"],
            // Elements Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "greater"],
            // Elements Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lower"],
            // Elements Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "greaterEqual"],
            // Elements Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "1", "lowerEqual"],
            // Elements Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "0$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "0$", "match"],
            // Elements Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "ElementsCount", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "elementsCount", "^ABC$", "notMatch"],
            // Count: Equal
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Equal"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "eq"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "equal"],
            // Count: NotEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "notEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "NotEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "ne"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "notEqual"],
            // Count: Greater
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "Gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "Greater"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "gt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "greater"],
            // Count: Lower
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lt"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Lower"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lower"],
            // Count: GreaterEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "-1", "greaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "ge"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "GreaterEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "greaterEqual"],
            // Count: LowerEqual
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "1", "lowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "Le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "LowerEqual"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "le"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0", "lowerEqual"],
            // Count: Match
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "0$", "match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0$", "Match"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "0$", "match"],
            // Count: NotMatch
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "Count", "^ABC$", "notMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "NotMatch"],
            [Stubs.RuleJsonNoAttributeOperator, "count", "^ABC$", "notMatch"]
        ];

        [TestMethod(displayName: "Verify that the ElementCount plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementCount>();
        }

        [TestMethod(displayName: "Verify that the ElementCount plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementCount>();
        }

        [TestMethod(displayName: "Verify that element count assertions handle WebDriverException " +
            "correctly for nested elements.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountExceptionNestedTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, ".//exception")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a WebDriverException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));
        }

        [TestMethod(displayName: "Verify that element count assertions handle WebDriverException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountExceptionTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a WebDriverException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));
        }

        [TestMethod(displayName: "Verify that element count negative assertions handle various conditions correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NegativeDataSet))]
        #endregion
        public void ElementCountNegativeTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that element count assertions handle NoSuchElementException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(ZeroCountDataSet))]
        #endregion
        public void ElementCountNoneTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is true (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that element count assertions handle NullReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(ZeroCountDataSet))]
        #endregion
        public void ElementCountNullTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, ".//null")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is true (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that element count assertions handle StaleElementReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountStaleTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a StaleElementReferenceException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is StaleElementReferenceException));
        }

        [TestMethod(displayName: "Verify that element count assertions handle positive scenarios correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is true (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
