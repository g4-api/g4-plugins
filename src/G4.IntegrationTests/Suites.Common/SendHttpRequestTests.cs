/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.SendHttpRequest;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Common
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("NonUi")]
    [TestCategory("SendHttpRequest")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to send HTTP requests during automation tasks, So " +
        "that I can interact with web services and APIs and automate web-based actions effectively.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SendHttpRequest plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "HTTP Request Sending Functionality: The plugin effectively sends HTTP requests based on the provided parameters, allowing users to interact with web services and APIs.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during HTTP request sending operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class SendHttpRequestTests : TestBase
    {
        #region *** Delete ***
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP DELETE request with " +
            "an empty body to delete a resource.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP DELETE request to the specified URL with an empty request body.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria("Expected Message: The plugin correctly asserts that the received HTTP response contains the expected message.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data Set ***
        [DataRow(200, "12345", "Booking canceled successfully")]
        [DataRow(400, "54321", "Invalid booking ID")]
        #endregion
        public void T0016P(int expectedStatusCode, string id, string expectedMessage)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedStatusCode", value: expectedStatusCode)
                .AddTestParameter(key: "id", value: id)
                .AddTestParameter(key: "expectedMessage", value: expectedMessage)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0016>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP DELETE request with " +
            "no body to delete a hotel.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "HTTP Request: The plugin successfully sends an HTTP DELETE request to the specified URL with no request body.")]
        [AcceptanceCriteria(criteria: "Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria(criteria: "Expected Message: The plugin correctly asserts that the received HTTP response contains the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data Set ***
        [DataRow(200, "12345", "Booking canceled successfully")]
        [DataRow(400, "54321", "Invalid booking ID")]
        #endregion
        public void T0017P(int expectedStatusCode, string id, string expectedMessage)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedStatusCode", value: expectedStatusCode)
                .AddTestParameter(key: "id", value: id)
                .AddTestParameter(key: "expectedMessage", value: expectedMessage)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0017>(testOptions);
        }
        #endregion

        #region *** Get    ***
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP GET request to find " +
            "hotels when no method is provided.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP GET request to the specified URL when no method is provided.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria("Expected Response Format: The plugin correctly asserts that the received HTTP response matches a specific pattern.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP GET request to find " +
            "hotels using the Url parameter.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP GET request to the specified URL using the Url parameter.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria("Expected Response Format: The plugin correctly asserts that the received HTTP response matches a specific pattern.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0002P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP GET request to find " +
            "hotels in XML format using the Url parameter.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP GET request to the specified URL for XML data using the Url parameter.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria("Expected Response Format: The plugin correctly asserts that the received HTTP response contains a specific XML structure.")]
        [AcceptanceCriteria("Default Behavior: If no method is provided, the plugin defaults to sending an HTTP GET request.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0003P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP GET request with " +
            "basic authentication.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP GET request to the specified URL with basic authentication if no method is provided.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code does not match the expected status code.")]
        [AcceptanceCriteria("Expected Response Format: The plugin correctly asserts that the received HTTP response matches a specific pattern based on the assertion operation.")]
        [AcceptanceCriteria("Assertion Operation: The plugin supports different assertion operations, such as matching, based on the test parameters.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0004P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0004>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin successfully sends an HTTP GET request with" +
            "custom headers.")]
        #region *** Criteria ***
        [AcceptanceCriteria("Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria("HTTP Request: The plugin sends an HTTP GET request to the specified URL with custom headers if no method is provided.")]
        [AcceptanceCriteria("Expected Status Code: The plugin correctly asserts that the received HTTP status code matches the expected status code.")]
        [AcceptanceCriteria("Expected Response Format: The plugin correctly asserts that the received HTTP response matches a specific pattern based on the assertion operation.")]
        [AcceptanceCriteria("Assertion Operation: The plugin supports different assertion operations, such as matching, based on the test parameters.")]
        [AcceptanceCriteria("Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0005P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0005>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "sends an HTTP GET request and extracts relevant data from the response using " +
            "JSONPath expressions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, the plugin sends an HTTP request.")]
        [AcceptanceCriteria(criteria: "Data Extraction: The plugin extracts relevant data from the HTTP response using JSONPath expressions.")]
        [AcceptanceCriteria(criteria: "Response Validation: The extracted data is validated to ensure its accuracy and relevance.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0006P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0006>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL and HTTP GET " +
            "method, sends an HTTP GET request and extracts relevant data from the response using " +
            "JSONPath expressions and a regular expression to extract two-digit numbers.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL and HTTP GET method, the plugin sends an HTTP GET request.")]
        [AcceptanceCriteria(criteria: "Data Extraction: The plugin extracts relevant data from the HTTP response using JSONPath expressions and a regular expression to extract two-digit numbers.")]
        [AcceptanceCriteria(criteria: "Response Validation: The extracted data is validated to ensure its accuracy and relevance.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0007P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Eq");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0007>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL and HTTP GET " +
            "method, sends an HTTP GET request and extracts relevant data from the response using a " +
            "regular expression to extract the pricePerNight value of the Luxury Hotel entry.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL and HTTP GET method, the plugin sends an HTTP GET request.")]
        [AcceptanceCriteria(criteria: "Data Extraction: The plugin extracts relevant data from the HTTP response using a regular expression to extract the pricePerNight value of the Luxury Hotel entry.")]
        [AcceptanceCriteria(criteria: "Response Validation: The extracted data is validated to ensure its accuracy and relevance.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0008P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Eq");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0008>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL and HTTP GET " +
            "method, sends an HTTP GET request and extracts relevant data from the XML response " +
            "using XPath.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL and HTTP GET method, the plugin sends an HTTP GET request.")]
        [AcceptanceCriteria(criteria: "Data Extraction: The plugin extracts relevant data from the XML response using XPath.")]
        [AcceptanceCriteria(criteria: "Response Validation: The extracted data is validated to ensure its accuracy and relevance.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0009P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Eq");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0009>(testOptions);
        }
        #endregion

        #region *** Patch  ***
        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, does not " +
            "retrieve the price of a non-existent hotel and returns an appropriate error message.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, the plugin sends an HTTP request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin correctly handles cases where the requested hotel is not found.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin returns an error message indicating the absence of the requested hotel.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0024N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0024>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL and " +
            "HTTP PATCH method, sends an HTTP PATCH request to update hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, and request body, the plugin sends an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Request Body: The plugin includes a request body containing the hotel name and review information.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0024P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0024>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and content type, returns an appropriate error message " +
            "when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and content type, the plugin attempts to send an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        public void T0025N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0025>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and content type, sends an HTTP PATCH request to " +
            "update hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and content type, the plugin sends an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Request Body: The plugin includes a request body containing the hotel name and review information.")]
        [AcceptanceCriteria(criteria: "Content Type: The plugin specifies the content type of the request as text/plain.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0025P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0025>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and content type as text/plain, returns an appropriate " +
            "error message when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and content type as text/plain, the plugin attempts to send an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        public void T0026N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0026>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and content type as text/plain, sends an HTTP PATCH " +
            "request to update hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and content type as text/plain, the plugin sends an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Request Body: The plugin includes a request body containing the hotel name and review information.")]
        [AcceptanceCriteria(criteria: "Content Type: The plugin specifies the content type of the request as text/plain.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0026P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0026>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and ASCII encoding, returns an appropriate error " +
            "message when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and ASCII encoding, the plugin attempts to send an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        public void T0027N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0027>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request body, and ASCII encoding, sends an HTTP PATCH request to " +
            "update hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request body, and ASCII encoding, the plugin sends an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Request Body: The plugin includes a request body containing the hotel name and review information.")]
        [AcceptanceCriteria(criteria: "Encoding: The plugin specifies ASCII encoding for the request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0027P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0027>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request fields, and encoded parameters, returns an appropriate error " +
            "message when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request fields, and encoded parameters, the plugin attempts to send an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0028N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0028>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with a specific URL, " +
            "HTTP PATCH method, request fields, and encoded parameters, sends an HTTP PATCH request " +
            "to update hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific URL, HTTP PATCH method, request fields, and encoded parameters, the plugin sends an HTTP PATCH request.")]
        [AcceptanceCriteria(criteria: "Request Fields: The plugin includes request fields for the hotel name and review information.")]
        [AcceptanceCriteria(criteria: "Encoding: The plugin encodes the request parameters as part of the URL.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0028P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0028>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PATCH request " +
            "in XML format, returns an appropriate error message when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send an HTTP PATCH request in XML format, the plugin attempts to send the request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0029N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0029>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PATCH request " +
            "in XML format, successfully updates hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send an HTTP PATCH request in XML format, the plugin sends the request.")]
        [AcceptanceCriteria(criteria: "Request Body: The plugin includes the hotel name and review information in XML format.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected message.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0029P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0029>(testOptions);
        }
        #endregion

        #region *** Post   ***
        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with basic authentication " +
            "and POST method, returns an appropriate error message when the assertion operation fails.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with basic authentication and POST method, the plugin sends the request with the provided username and password.")]
        [AcceptanceCriteria(criteria: "Authentication: The plugin includes basic authentication credentials in the request header.")]
        [AcceptanceCriteria(criteria: "HTTP Method: The plugin uses the POST method for sending the request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the HTTP status code is not equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The plugin validates that the response body does not contain the expected content.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle assertion failures.")]
        #endregion
        public void T0010N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0010>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured with basic authentication " +
            "and POST method, successfully connects to the specified URL.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with basic authentication and POST method, the plugin sends the request with the provided username and password.")]
        [AcceptanceCriteria(criteria: "Authentication: The plugin includes basic authentication credentials in the request header.")]
        [AcceptanceCriteria(criteria: "HTTP Method: The plugin uses the POST method for sending the request.")]
        [AcceptanceCriteria(criteria: "Response Validation: The HTTP status code is validated to ensure it equals 200.")]
        [AcceptanceCriteria(criteria: "Response Validation: The response body is validated to contain the expected content.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle exceptions and unexpected responses.")]
        #endregion
        public void T0010P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0010>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a JSON body to book a hotel room with specific details, correctly handles assertion " +
            "failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters and a JSON body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0011N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0011>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a JSON body to book a hotel room with specific details, correctly confirms the " +
            "booking and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters and a JSON body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0011P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0011>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a plain text body to book a hotel room with specific details, correctly confirms " +
            "the booking and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters and a plain text body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0012N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0012>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a plain text body to book a hotel room with specific details, correctly confirms " +
            "the booking and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters and a plain text body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0012P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0012>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a plain text body using ASCII encoding to book a hotel room with specific details, " +
            "correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters, a plain text body, and ASCII encoding.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0013N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0013>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with a plain text body using ASCII encoding to book a hotel room with specific details, " +
            "correctly confirms the booking and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the required parameters, a plain text body, and ASCII encoding.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0013P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0013>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with specified fields and content type to book a hotel, correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the specified fields and content type.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0014N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0014>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "with specified fields and content type to book a hotel, correctly confirms the booking.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint with the specified fields and content type.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0014P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0014>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "in XML format to book a hotel, correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint in XML format.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0015N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0015>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP POST request " +
            "in XML format to book a hotel, correctly confirms the booking.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP POST request to the designated endpoint in XML format.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Booking Confirmation Check: The automation script asserts that the response confirms the booking for the specified hotel and room type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or booking confirmation process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0015P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0015>(testOptions);
        }
        #endregion

        #region *** Put    ***
        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information with a JSON body, correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a JSON body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0018N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0018>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information with a JSON body, correctly updates the hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a JSON body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0018P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0018>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in text format, correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0019N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0019>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in text format, correctly updates the hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0019P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0019>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information without specifying content-type and with a text/plain body, " +
            "correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0020N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0020>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information without specifying content-type and with a text/plain body, " +
            "correctly updates the hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0020P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0020>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in text format with ASCII encoding, correctly handles " +
            "assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Encoding: The HTTP request body is encoded in ASCII.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0021N()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0021>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in text format with ASCII encoding, correctly updates the " +
            "hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters and a text/plain body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Encoding: The HTTP request body is encoded in ASCII.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        public void T0021P()
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match");

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0021>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in encoded format, correctly handles assertion failure.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0022N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0022>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in encoded format, correctly updates the hotel information.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("application/x-www-form-urlencoded")]
        [DataRow("x-www-form-urlencoded")]
        #endregion
        public void T0022P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0022>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information in XML format, correctly handles assertion failure, both " +
            "with and without specifying the content-type.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters, including an XML body.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Request Sending without Specifying Content-Type: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters, including an XML body, and without specifying the content-type.")]
        [AcceptanceCriteria(criteria: "Request Sending with Specified Content-Type: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters, including an XML body, and with specified content-type.")]
        [AcceptanceCriteria(criteria: "Negative Assertion Handling: The automation script detects and handles assertion failure gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0023N(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "NotMatch")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0023>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendHttpRequest plugin, when configured to send an HTTP PUT request " +
            "to update hotel information, correctly updates the hotel information, both with and " +
            "without specifying the content-type and using XML body.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendHttpRequest plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Request Sending: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters, an XML body, and without specifying the content-type.")]
        [AcceptanceCriteria(criteria: "HTTP Status Code Verification: The automation script verifies that the HTTP status code returned is equal to 200.")]
        [AcceptanceCriteria(criteria: "Response Verification: The automation script asserts that the response contains the expected message confirming the update of hotel information.")]
        [AcceptanceCriteria(criteria: "Request Sending with Specified Content-Type: The plugin successfully sends an HTTP PUT request to the designated endpoint with the required parameters, an XML body, and with specified content-type.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the HTTP request or update process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("text/xml")]
        #endregion
        public void T0023P(string contentType)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "assertionOperation", value: "Match")
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options.
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0023>(testOptions);
        }
        #endregion
    }
}
