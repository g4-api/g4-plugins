using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SaveScreenshot
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Get directory from test parameters or use default value Environment.CurrentDirectory
            var directory = environment.TestParameters.Get(key: "directory", defaultValue: Environment.CurrentDirectory);

            // Get fileName from test parameters or use default value ElementScreenshot.png
            var fileName = environment.TestParameters.Get(key: "fileName", defaultValue: "ElementScreenshot.png");

            // Returns a collection of action rule models with a default pluginName of "SaveScreenshot"
            return
            [
                // SaveScreenshot action: Saves a screenshot of the specified element.
                new ActionRuleModel
                {
                    PluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "SaveScreenshot"),
                    Argument = "{{$ --Directory:" + directory + " --FileName:" + fileName + "}}",
                    OnElement = "#ClickButton",
                    Locator = "CssSelector"
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
