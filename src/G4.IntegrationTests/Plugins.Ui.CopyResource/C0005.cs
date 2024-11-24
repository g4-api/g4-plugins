using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.CopyResource
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models to return
            return
            [
                // CopyResource action: Copies the resource with the name "TestImages"
                // from the source to the destination
                new ActionRuleModel
                {
                    Argument = "{{$ --Path:TestImages --Parallel}}",
                    OnElement = "//div[not(@class)]/p",
                    PluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "CopyResource"),
                    RegularExpression = "(?!(.*: ))\\w+.*"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Set the RetrunEnvironment property of the EngineConfiguration to true
            automation.Settings.EnvironmentsSettings.ReturnEnvironment = true;
        }
    }
}
