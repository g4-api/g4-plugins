﻿using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WriteLog
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models to return
            return
            [
                // WriteLog action: Writes a log message with the first 8 alphanumeric characters
                // of the GUID generated by New-Guid plugin
                new ActionRuleModel
                {
                    Argument = "The first 8 alphanumeric characters of the GUID are {{$New-Guid --Pattern:^\\w{8}}}",
                    PluginName = "WriteLog"
                }
            ];
        }
    }
}
