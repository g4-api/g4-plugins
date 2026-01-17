using G4.Attributes;
using G4.Cache;
using G4.Extensions;
using G4.Models;

using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Common.SetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.SetParameter.Manifests.{nameof(SetApplicationParameter)}.json")]
    public class SetApplicationParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract necessary data from the PluginDataModel.
            var defaultEnvironment = string.IsNullOrEmpty(Automation.Settings.EnvironmentsSettings.DefaultEnvironment)
                ? "SystemParameters"
                : Automation.Settings.EnvironmentsSettings.DefaultEnvironment;
            var name = pluginData.Rule.OnElement;
            var value = pluginData.Parameters.Get("Value", string.Empty);
            var environment = pluginData.Parameters.Get("Environment", defaultEnvironment);

            // Get or create a LiteDB collection for ApplicationParametersModel.
            var collection = CacheManager.LiteDatabase.GetCollection<ApplicationParametersModel>(
                name: G4Environment.CollectionName,
                autoId: BsonAutoId.Guid);

            // Retrieve the first or create a new ApplicationParametersModel.
            var document = collection.Find(i => i.Name.Equals(environment, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var parametersModel = document ?? new ApplicationParametersModel
            {
                Id = Guid.NewGuid(),
                Name = environment
            };

            // Update parameters in the ApplicationParametersModel.
            if (parametersModel.Parameters == null)
            {
                // If Parameters is null, initialize a new dictionary and insert into the collection.
                parametersModel.Parameters = new Dictionary<string, object>
                {
                    [name] = value
                };
                collection.Insert(parametersModel);
            }
            else
            {
                // If Parameters already exists, update the specific parameter and update the collection.
                parametersModel.Parameters[name] = value;
                collection.Update(parametersModel);
            }

            // Create and return a new PluginResponseModel.
            return this.NewPluginResponse();
        }
    }
}
