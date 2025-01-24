using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.OpenUrl
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Defines a sequence of action rule models to return
            return
            [
                // Action: Opens the URL matching the regular expression in the paragraph
                // element containing the text 'Image A'
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    OnElement = "//p[contains(.,'Image A')]",
                    RegularExpression = "https?://.*",
                },
                // Assert action: Asserts that the page URL matches the expected value (ImageA\\.png$)
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:ImageA\\.png$}}"
                }
            ];
        }
    }
}
