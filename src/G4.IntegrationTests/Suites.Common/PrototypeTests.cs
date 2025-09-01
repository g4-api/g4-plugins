using G4.Api;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Suites.Common
{
    [TestClass]
    public class PrototypeTests
    {
        [TestMethod]
        public void ScrappingTest()
        {
            var extraction = new ExtractionRuleModel
            {
                Argument = "{{$ --Scope:Elements}}",
                OnElement = "(//ul/li[contains(@ng-repeat,'dynamicCtrl.ViewModel.dataResults')])[1]",
                DataCollector = new G4DataProviderModel
                {
                    Type = "CsvDataCollector",
                    ForEntity = true,
                    Source = "E:\\Garbage\\spokmanship_court.csv"
                },
                Rules =
                [
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//h3",
                    //    Key = "Title",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string"
                    //},
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//span[contains(@ng-bind-html,'item.Data.name_number')]",
                    //    Key = "FileNumber",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string"
                    //},
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//div[./label[.='סוג ההליך']]//span[last()]/span",
                    //    Key = "ProcedureType",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string",
                    //    Transformers =
                    //    [
                    //        new TransformerRuleModel
                    //        {
                    //            OnElement = "ProcedureType",
                    //            PluginName = "Trim",
                    //        }
                    //    ]
                    //},
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//div[./label[.='מחוז']]//span[last()]/span",
                    //    Key = "District",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string",
                    //    Transformers =
                    //    [
                    //        new TransformerRuleModel
                    //        {
                    //            OnElement = "District",
                    //            PluginName = "Trim",
                    //        }
                    //    ]
                    //},
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//div[./label[.='בתי משפט']]//span[last()]",
                    //    Key = "Courts",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string",
                    //    Transformers =
                    //    [
                    //        new TransformerRuleModel
                    //        {
                    //            OnElement = "Courts",
                    //            PluginName = "Trim",
                    //        }
                    //    ]
                    //},
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".//span[contains(@ng-bind-html,'item.Data.doc_create_date')]",
                    //    Key = "IssueDate",
                    //    PluginName = "WebElementContent",
                    //    DataType = "string"
                    //},
                    new ContentRuleModel
                    {
                        OnElement = ".//span[contains(@ng-bind-html,'item.Data.judge')]",
                        Key = "IssuedBy",
                        PluginName = "WebElementContent",
                        DataType = "string",
                        Rules =
                        [
                            new ActionRuleModel
                            {
                                Argument = "{{$ --Name:FileUrl --Scope:Session}}",
                                PluginName = "RegisterParameter",
                                OnElement = ".//a",
                                OnAttribute = "href"
                            },
                            new ActionRuleModel
                            {
                                PluginName = "ResolveOnlineFile",
                                Argument = "{{Get-Parameter --Name:FileUrl --Scope:Session}}"
                            }
                        ]
                    },
                ]
            };

            var actions = new List<G4RuleModelBase>
            {
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "https://www.gov.il/he/Departments/DynamicCollectors/spokmanship_court?skip=0"
                },
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                new ActionRuleModel
                {
                    PluginName = "InvokeWhileLoop",
                    Argument = "{{$ --Condition:ElementExists}}",
                    OnElement = "//a[@title='הבא']",
                    Rules =
                    [
                        new ActionRuleModel
                        {
                            PluginName = "WaitFlow",
                            Argument = "{{$ --Timeout:1500}}"
                        },
                        extraction,
                        new ActionRuleModel
                        {
                            PluginName = "InvokeClick",
                            OnElement = "//a[@title='הבא']"
                        }
                    ]
                },
                new ActionRuleModel
                {
                    PluginName = "CloseBrowser"
                }
            };

            var authentication = new AuthenticationModel
            {
                Token = "3xezq5Yc33laNOPNP8yCsK33vQcQZ87E/zyLNNscYNeqvKTHAm9C3wAEDQV7X9+fuuHPhafDNXbSFgsbKmCncCKm7DRE5A6JtFSd90DNujujbQ3vLG4/4uSVCR76Z6VguIDSvRZ/pJTHCzBc9NNI/eb5fLHcjXyYrilm9NC7VTD/HOlgGC5CL+oFhHoR8s10YuI9QpRioZbyDHysFumpAAv3/PG/p/QBKNoQpjtsUgMytrnqr3m1bgyXITG0u5AUR2VpZLCXQO6MxU7kwLwvdNGXUDfajBVT29KyjXUEWN9dK0R38XmgZFQ7orkKfN2z0x2SMfC5mvTDM6as+/kYWFAvpqOZDhZ95sgQWp/zGig="
            };

            var driverParameters = new Dictionary<string, object>
            {
                ["driver"] = "ChromeDriver",
                ["driverBinaries"] = "http://localhost:4444/wd/hub"
            };

            var job = new G4JobModel
            {
                Reference = new G4JobReferenceModel
                {
                    Name = "Base Stage"
                }
            };

            var stage = new G4StageModel
            {
                Reference = new G4StageReferenceModel
                {
                    Name = "Base Stage"
                }
            };

            job.Rules = actions;
            stage.Jobs = [job];

            var automation = new G4AutomationModel
            {
                Authentication = authentication,
                DriverParameters = driverParameters,
                Stages = [stage]
            };

            var client = new G4Client();
            client.Automation.Invoke(automation);
        }
    }
}
