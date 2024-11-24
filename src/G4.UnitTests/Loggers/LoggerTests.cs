using G4.Abstraction.Logging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace G4.UnitTests.Loggers
{
    [TestClass]
    [TestCategory("Logger")]
    [TestCategory("UnitTest")]
    public class LoggerTests
    {
        [TestMethod(displayName: "Verify the creation of a new logger with the configuration " +
            "specified in the appsettings.json file and environment variables.")]
        public void NewLoggerTest()
        {
            // Build the configuration from appsettings.json and environment variables
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Retrieve logging settings from the configuration
            var addDebug = configuration.GetSection("Logging:G4Logger:AddDebug").Get<bool>();
            var addConsole = configuration.GetSection("Logging:G4Logger:AddConsole").Get<bool>();

            // Create a LoggerFactory with the retrieved settings
            var factory = LoggerFactory.Create(builder =>
            {
                // Add configuration section for logging
                builder.AddConfiguration(configuration.GetSection("Logging"));

                // Add custom G4Logger
                builder.AddG4Logger();

                // Conditionally add console logging
                if (addConsole)
                {
                    builder.AddConsole();
                }

                // Conditionally add debug logging
                if (addDebug)
                {
                    builder.AddDebug();
                }
            });

            // Create a logger instance with the name "Testing"
            var log = factory.CreateLogger("Testing");

            // Log an information message
            log.LogInformation("Warning Settings");

            // Assert that debug and console logging are not added
            Assert.IsFalse(addDebug || addConsole);
        }
    }
}
