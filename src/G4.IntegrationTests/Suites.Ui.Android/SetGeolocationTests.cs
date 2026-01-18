using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SetGeoLocation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Android
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MobileNative")]
    [TestCategory("Android")]
    [TestCategory("SetGeolocation")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to set geolocation coordinates on a mobile device, So " +
        "that I can simulate location-based scenarios and test location-aware features in mobile applications.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SetGeolocation plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Geolocation Setting Functionality: The plugin effectively sets geolocation coordinates on a mobile device, allowing users to simulate location-based scenarios during automation tasks.")]
    [AcceptanceCriteria(criteria: "Customization Options: The plugin provides users with options to customize geolocation coordinates, such as specifying altitude, latitude, and longitude values.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during geolocation setting operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class SetGeolocationTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetGeoLocation plugin correctly sets the geolocation on the device " +
            "to latitude 121.21, longitude 11.56, and altitude 94.23.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetGeoLocation plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "GeoLocation Setting: The plugin successfully sets the geolocation to latitude 121.21, longitude 11.56, and altitude 94.23.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0001(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion);

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0001>(testOptions);
        }
    }
}
