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
    public class SetConditionPageTitleTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Page Title: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 20", ".*", "equal"],

            // Page Title: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "Mock G4™ API Page Title 21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "Mock G4™ API Page Title 21", ".*", "notEqual"],

            // Page Title: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "greater"],

            // Page Title: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "lower"],

            // Page Title: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "19", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "19", @"\\d+$", "greaterEqual"],

            // Page Title: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", "21", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", "21", @"\\d+$", "lowerEqual"],

            // Page Title: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],

            // Page Title: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "PageTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "pageTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"],

            // Title: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 20", ".*", "equal"],

            // Title: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "Mock G4™ API Page Title 21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "Mock G4™ API Page Title 21", ".*", "notEqual"],

            // Title: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "greater"],

            // Title: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "lower"],

            // Title: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "19", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "19", @"\\d+$", "greaterEqual"],

            // Title: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", "21", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", "21", @"\\d+$", "lowerEqual"],

            // Title: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],

            // Title: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "Title", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "title", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"],

            // WindowTitle: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 20", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 20", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 20", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 20", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 20", ".*", "equal"],

            // WindowTitle: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "Mock G4™ API Page Title 21", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 21", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 21", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 21", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "Mock G4™ API Page Title 21", ".*", "notEqual"],

            // WindowTitle: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "greater"],

            // WindowTitle: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "lower"],

            // WindowTitle: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "19", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "19", @"\\d+$", "greaterEqual"],

            // WindowTitle: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", "21", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "20", @"\\d+$", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", "21", @"\\d+$", "lowerEqual"],

            // WindowTitle: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", @"^Mock G4™ API Page Title \\d+$", ".*", "match"],

            // WindowTitle: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowTitle", @"^\\d+ Mock G4™ API Page Title$", ".*", "notMatch"]
        ];

        [TestMethod(DisplayName = "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the plugin is correctly instantiated and " +
            "operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that title assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void PageTitleTest(
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

        [TestMethod(DisplayName = "Verify that title value assertions handle WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void PageTitleWebDriverExceptionTest(
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
                ["ExceptionOnTitle"] = true
            });

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }
    }
}
