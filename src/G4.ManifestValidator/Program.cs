using G4.Attributes;

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// Exit gracefully on Ctrl+C
Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, args) => Environment.Exit(0));

// JSON serializer options
JsonSerializerOptions options = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    IgnoreReadOnlyProperties = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNameCaseInsensitive = true
};

// Display header
WriteHeader();

// Continuous loop for manifest validation
while (true)
{
    #region *** Interactive Wizard ***
    // Prompt user for input
    Console.WriteLine("Paste the minified JSON body or the file path > ");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    #endregion

    // Read user input
    var input = Console.ReadLine();

    // Reset console color
    Console.ForegroundColor = ConsoleColor.Gray;

    // Check if the input is a file path
    // If it's a file, read the content
    // If not, use the input as-is
    var manifest = File.Exists(input)
        ? await File.ReadAllTextAsync(input)
        : input;

    try
    {
        // Deserialize and validate G4PluginAttribute from the manifest
        JsonSerializer.Deserialize<G4PluginAttribute>(manifest, options);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("Manifest validation successful. The G4™ manifest is valid.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
    }
    catch (Exception e)
    {
        // Display validation failure
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("Manifest validation failed. Please review the manifest for errors.");
        Console.WriteLine();
        Console.WriteLine(e.Message);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
    }
}

// This method displays the G4™ logo and version information,
// along with instructions for using the tool.
static void WriteHeader()
{
    // G4™ logo ASCII art
    var logo = new[]
    {
        "    ____ _  _     __  __             _  __           _         ",
        "   / ___| || |   |  \\/  | __ _ _ __ (_)/ _| ___  ___| |_      ",
        "  | |  _| || |_  | |\\/| |/ _` | '_ \\| | |_ / _ \\/ __| __|   ",
        "  | |_| |__   _| | |  | | (_| | | | | |  _|  __/\\__ \\ |_     ",
        "   \\____|_ |_| __|_| _|_|\\__,_|_| |_|_|_|  \\___||___/\\__|  ",
        "        \\ \\   / /_ _| (_) __| | __ _| |_ ___  _ __           ",
        "         \\ \\ / / _` | | |/ _` |/ _` | __/ _ \\| '__|         ",
        "          \\ V / (_| | | | (_| | (_| | || (_) | |              ",
        "           \\_/ \\__,_|_|_|\\__,_|\\__,_|\\__\\___/|_|         ",
        "                                                               ",
        "                            G4™ - Automation as a Service      ",
        "                                    Powered by G4™-Engine      ",
        "                                                               ",
        "  Version: v4.0.0.0                                            ",
        "  Project: https://github.com/g4-api                           ",
        "                                                               ",
        "                                                               "
    };

    // Set the console output encoding to UTF-8 to support Unicode characters.
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    // Display the logo
    Console.WriteLine(string.Join("\n", logo));

    // Display informational messages
    Console.WriteLine("  This tool helps you validate and ensure the correctness of G4™ manifests.");
    Console.WriteLine("  Manifests play a crucial role in defining application behavior. " +
        "Let's ensure yours adheres to G4's specifications.");
    Console.WriteLine("  To validate a manifest, simply paste the minified JSON body or the file path once the tool is running.");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine("  Note: It is recommended to ** minify ** your JSON");
    Console.WriteLine("  before pasting it into the command line.");
    Console.Write("  You can use tools like ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("https://www.minifyjson.org/");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine();
    Console.WriteLine("  Press Ctrl+C to exit at any time.");
    Console.WriteLine();
}
