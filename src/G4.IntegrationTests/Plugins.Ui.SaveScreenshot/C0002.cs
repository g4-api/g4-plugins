using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SaveScreenshot
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Get fileName from test parameters or use default value PageScreenshot.png
            var fileName = environment.TestParameters.Get(key: "fileName", defaultValue: "PageScreenshot.png");

            // Returns a collection of action rule models
            return
            [
                // SaveScreenshot action: Saves a screenshot of the page with the specified file name.
                new ActionRuleModel
                {
                    PluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "SaveScreenshot"),
                    Argument = "{{$ --FileName: " + fileName + "}}"
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
