using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // WaitFlow action: Waits until the alert does not exist for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:AlertNotExists --Timeout:00:00:15}}"
                },
                // Assert action: Asserts that the alert does not exist
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:AlertNotExists}}"
                }
            ];
        }
    }
}
