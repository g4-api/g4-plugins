using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.ResolveOnlineFile;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("ResolveOnlineFile")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA developer, I want a plugin within the G4™ framework that " +
        "can resolve a file link from a URL or page element, apply optional filtering, download the file, and extract its metadata, " +
        "so that I can automate file retrieval and downstream processing.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The ResolveOnlineFile plugin is available in the G4™ platform's plugin set for file resolution tasks.")]
    [AcceptanceCriteria(criteria: "Argument-Based Invocation: The plugin supports downloading files directly from a provided URL argument.")]
    [AcceptanceCriteria(criteria: "Element-Based Invocation: The plugin supports resolving file URLs from page elements by selector and attribute.")]
    [AcceptanceCriteria(criteria: "Regex Filtering: The plugin can apply an optional regular expression to filter or extract the correct file link.")]
    [AcceptanceCriteria(criteria: "Metadata Extraction: The plugin extracts and stores file data, extension, full name, base name, size, status code, and original URI in session parameters.")]
    [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles invalid URLs and download failures, clears stale session data, and logs errors to maintain workflow consistency.")]
    #endregion
    public class ResolveOnlineFileTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "ResolveOnlineFile plugin downloads a file from a URL and populates session parameters with correct " +
            "file details.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ResolveOnlineFile plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "URL Argument: When provided with a valid file URL as Argument, the plugin retrieves the file content.")]
        [AcceptanceCriteria(criteria: "File Data Retrieval: The plugin stores non-empty file data in session parameter 'ResolvedFileData'.")]
        [AcceptanceCriteria(criteria: "Extension Extraction: The plugin correctly extracts 'txt' as the file extension.")]
        [AcceptanceCriteria(criteria: "Full Name Storage: The plugin stores 'Example.txt' as the session parameter 'ResolvedFileFullName'.")]
        [AcceptanceCriteria(criteria: "Name Extraction: The plugin stores 'Example' as the session parameter 'ResolvedFileName'.")]
        [AcceptanceCriteria(criteria: "Size Reporting: The plugin stores a file size greater than 0 in session parameter 'ResolvedFileSize'.")]
        [AcceptanceCriteria(criteria: "Status Code Reporting: The plugin stores HTTP status code 200 in session parameter 'ResolvedFileStatusCode'.")]
        [AcceptanceCriteria(criteria: "URI Recording: The plugin stores the original URL containing 'localhost' in session parameter 'ResolvedFileUri'.")]
        #endregion
        public void T0001()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "ResolveOnlineFile plugin resolves a file link from a page element and extracts its metadata correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ResolveOnlineFile plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Element-Based Invocation: When configured with OnElement targeting a valid link selector, the plugin locates the URL and downloads the file.")]
        [AcceptanceCriteria(criteria: "File Data Retrieval: The plugin stores non-empty file data in the session under 'ResolvedFileData'.")]
        [AcceptanceCriteria(criteria: "Extension Extraction: The plugin extracts and stores the correct file extension (\"txt\").")]
        [AcceptanceCriteria(criteria: "Full Name Extraction: The plugin extracts and stores the full file name (\"Example.txt\").")]
        [AcceptanceCriteria(criteria: "Name Extraction: The plugin extracts and stores the base file name (\"Example\").")]
        [AcceptanceCriteria(criteria: "Size Extraction: The plugin stores a file size greater than zero.")]
        [AcceptanceCriteria(criteria: "Status Code Extraction: The plugin stores the HTTP status code 200.")]
        [AcceptanceCriteria(criteria: "URI Storage: The plugin stores the source URI containing the host (e.g. \"localhost\").")]
        #endregion
        public void T0002()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "ResolveOnlineFile plugin filters a link with a regex, downloads the file, and extracts its metadata correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ResolveOnlineFile plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Regex-Based Invocation: When configured with OnElement targeting a valid link selector and a RegularExpression matching the link pattern, the plugin filters the URL correctly and downloads the file.")]
        [AcceptanceCriteria(criteria: "File Data Retrieval: The plugin stores non-empty file data in the session under 'ResolvedFileData'.")]
        [AcceptanceCriteria(criteria: "Extension Extraction: The plugin extracts and stores the correct file extension (\"txt\").")]
        [AcceptanceCriteria(criteria: "Full Name Extraction: The plugin extracts and stores the full file name (\"Example.txt\").")]
        [AcceptanceCriteria(criteria: "Name Extraction: The plugin extracts and stores the base file name (\"Example\").")]
        [AcceptanceCriteria(criteria: "Size Extraction: The plugin stores a file size greater than zero.")]
        [AcceptanceCriteria(criteria: "Status Code Extraction: The plugin stores the HTTP status code 200.")]
        [AcceptanceCriteria(criteria: "URI Storage: The plugin stores the source URI containing the host (e.g. \"localhost\").")]
        #endregion
        public void T0003()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "ResolveOnlineFile plugin reads a URL from an element attribute, downloads the file, and extracts its " +
            "metadata correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ResolveOnlineFile plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Attribute-Based Invocation: When configured with OnElement targeting a link selector and OnAttribute set to 'href', the plugin reads the URL correctly and downloads the file.")]
        [AcceptanceCriteria(criteria: "File Data Retrieval: The plugin stores non-empty file data in the session under 'ResolvedFileData'.")]
        [AcceptanceCriteria(criteria: "Extension Extraction: The plugin extracts and stores the correct file extension (\"txt\").")]
        [AcceptanceCriteria(criteria: "Full Name Extraction: The plugin extracts and stores the full file name (\"Example.txt\").")]
        [AcceptanceCriteria(criteria: "Name Extraction: The plugin extracts and stores the base file name (\"Example\").")]
        [AcceptanceCriteria(criteria: "Size Extraction: The plugin stores a file size greater than zero.")]
        [AcceptanceCriteria(criteria: "Status Code Extraction: The plugin stores the HTTP status code 200.")]
        [AcceptanceCriteria(criteria: "URI Storage: The plugin stores the source URI containing the host (e.g. \"localhost\").")]
        #endregion
        public void T0004()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "ResolveOnlineFile plugin reads a URL from an element attribute, applies a regex filter, downloads the " +
            "file, and extracts its metadata correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ResolveOnlineFile plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Attribute and Regex-Based Invocation: When configured with OnElement targeting a link selector, OnAttribute set to 'href', and a RegularExpression matching the link pattern, the plugin reads and filters the URL correctly and downloads the file.")]
        [AcceptanceCriteria(criteria: "File Data Retrieval: The plugin stores non-empty file data in the session under 'ResolvedFileData'.")]
        [AcceptanceCriteria(criteria: "Extension Extraction: The plugin extracts and stores the correct file extension (\"txt\").")]
        [AcceptanceCriteria(criteria: "Full Name Extraction: The plugin extracts and stores the full file name (\"Example.txt\").")]
        [AcceptanceCriteria(criteria: "Name Extraction: The plugin extracts and stores the base file name (\"Example\").")]
        [AcceptanceCriteria(criteria: "Size Extraction: The plugin stores a file size greater than zero.")]
        [AcceptanceCriteria(criteria: "Status Code Extraction: The plugin stores the HTTP status code 200.")]
        [AcceptanceCriteria(criteria: "URI Storage: The plugin stores the source URI containing the host (e.g. \"localhost\").")]
        #endregion
        public void T0005()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }
    }
}
