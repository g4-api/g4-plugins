using G4.Abstraction.Cli;
using G4.Attributes;
using G4.Cache;
using G4.Extensions;
using G4.Plugins;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

// Writes the introductory message to the console.
WriteHeader();

// Convert command-line arguments to a string representation
var argumentsCli = "{{$ " + string.Join(' ', args) + "}}";

// Convert the command-line arguments to a dictionary
var arguments = new CliFactory().ConvertToDictionary(argumentsCli);

// Get the value of the "OutputDirectory" argument, defaulting to a specified value if not provided
var outputDirectory = arguments.Get(key: "OutputDirectory", defaultValue: Path.Combine(Environment.CurrentDirectory, "G4Api", "Documentation"));

// Get the value of the "DocsBaseDirectory" argument, defaulting to an empty string if not provided
var docsBaseDirectory = arguments.Get(key: "DocsBaseDirectory", string.Empty);

// Check if the "Help" key exists in the arguments dictionary
if (arguments.ContainsKey("Help"))
{
    // Call the WriteHelp method to display help information
    WriteHelp();

    // Return from the method
    return;
}

#region *** Interactive Wizard ***
// Check if the "OutputFolder" key is not present in the arguments dictionary
if (!arguments.ContainsKey("OutputFolder"))
{
    // Prompt the user to specify an output folder or use the default
    Console.Write($"Enter the output folder path or press Enter to use the default ({outputDirectory}) > ");

    // Read user input from the console
    var input = Console.ReadLine();

    // Update the outputFolder variable based on user input, or keep it as default if input is empty
    outputDirectory = string.IsNullOrEmpty(input)
        ? outputDirectory
        : input;

    // Print a blank line to the console
    Console.WriteLine("");
}

// Check if the "DocsFolder" key is not present in the arguments dictionary
if (!arguments.ContainsKey("DocsFolder"))
{
    // Prompt the user to specify an input documents folder or use the default
    Console.Write($"Enter the input documents folder path or press Enter to use the default ({docsBaseDirectory}) > ");

    // Read user input from the console
    var input = Console.ReadLine();

    // Update the docsFolder variable based on user input, or keep it as default if input is empty
    docsBaseDirectory = string.IsNullOrEmpty(input)
        ? docsBaseDirectory
        : input;

    // Print a blank line to the console
    Console.WriteLine("");
}
#endregion

// Inform the user that loading is being performed
Console.WriteLine("Loading manifests...");

// Import types from assemblies and filter plugins based on attributes and base type
var manifests = ReadManifests();

// Inform the user that loading is complete
Console.WriteLine("Manifests loaded successfully.");

// Create manifest documents by selecting each manifest and converting it to Markdown format
var manifestDocuments = manifests
    .Select(i => ConvertToDocument(outputDirectory, manifest: i))
    .GroupBy(i => i.Directory)
    .OrderBy(i => i.Key);

// Call the ReadDocuments method to recursively read documents from the specified directory and its subdirectories
// Store the result in the documents variable
var generalDocuments = ReadDocuments(docsBaseDirectory, docsDirectory:string.Empty, outputDirectory)
    .GroupBy(i => i.Directory)
    .OrderBy(i => i.Key);

// Generate the table of contents for the plugins
var tableOfContent = FormatTableOfContent(outputDirectory, manifestDocuments, generalDocuments);

// Flatten nested lists in manifestDocuments, resulting in a single sequence of document information
// Combine flattened manifestDocuments with flattened generalDocuments
// Add the table of content (assumed to be a list of strings) to the combined documents
var documents = manifestDocuments
  .SelectMany(innerList => innerList.Select(document => document))
  .Concat(generalDocuments.SelectMany(innerList => innerList.Select(document => document)))
  .Concat([tableOfContent]);

// Write the documents to the file system based on the provided information (directory, filename, content)
WriteDocuments(documents);

// Converts the G4™ plugin attribute to a Markdown document.
static (string Directory, string File, string Content) ConvertToDocument(string outputDirectory, G4PluginAttribute manifest)
{
    // Combine output directory and plugin type to form the directory path
    var directory = Path.Combine(outputDirectory, $"{manifest.PluginType}s");

    // Create file name by combining the plugin key and file extension
    var file = $"{manifest.Key}.md";

    // Convert the G4™ plugin attribute to Markdown format, including navigation links
    var content = manifest.ConvertToMarkdown(includeNavigationLinks: true);

    // Return a tuple containing directory, file name, and content of the Markdown document
    return (directory, file, content);
}

// Formats the table of contents for G4™ Documentation.
static (string Directory, string File, string Content) FormatTableOfContent(
    string outputDirectory,
    IEnumerable<IGrouping<string, (string Directory, string File, string Content)>> manifestDocuments,
    IEnumerable<IGrouping<string, (string Directory, string File, string Content)>> documents)
{
    // Initialize the table of content list with the main title and header
    var tableOfContent = new List<string>
    {
        $"{FormatDocumentHeader(title: "G4™ Documentation - Table of Content", depth: 0)}",
        ""
    };

    // Retrieve content for plugins and documents
    var pluginsContent = FormatPluginsTableOfContent(outputDirectory, manifestDocuments).Content;
    var documentsContent = FormatDocumentsTableOfContent(outputDirectory, documents).Content;

    // Add content to the table of contents
    tableOfContent.AddRange([pluginsContent, documentsContent]);

    // Join the lines and return the result
    return (outputDirectory, "Home.md", string.Join("\n", tableOfContent));
}

// Formats the header for a Markdown document with the specified title and depth.
static string FormatDocumentHeader(string title, int depth)
{
    // Initialize string builders for anchor links
    var homeAnchor = new StringBuilder();
    var contentAnchor = new StringBuilder();

    // Append '../' for each level of depth
    for (int i = 0; i < depth; i++)
    {
        homeAnchor.Append("../");
    }

    // Append '../' for each level of depth except the last one
    for (int i = 0; i < depth - 1; i++)
    {
        contentAnchor.Append("../");
    }

    // Define header content including title and navigation links
    var header = new[]
    {
        $"# {title}",
        "",
        // Include navigation links if depth is greater than 0
        (depth == 0 || string.IsNullOrEmpty(homeAnchor.ToString()) ? string.Empty : $"[Home]({homeAnchor}Home.md) · ") +
        (depth == 0 || string.IsNullOrEmpty(contentAnchor.ToString()) ? string.Empty : $"[Table of Content]({contentAnchor}Home.md) · ") +
        "[G4™ GitHub](https://github.com/g4-api) · [G4™ Docker Hub](https://hub.docker.com/repository/docker/g4api/g4-agent/general) · [G4™ Documentation](https://github.com/g4-api/g4-docs)"
    };

    // Join header lines with newline characters
    return string.Join("\n", header);
}

// Formats the table of contents for the G4™ documentation, listing plugins and their associated Markdown documents.
static (string Directory, string File, string Content) FormatDocumentsTableOfContent(
    string outputDirectory,
    IEnumerable<IGrouping<string, (string Directory, string File, string Content)>> documents)
{
    return FormatTableOfContentItems(title: "Documents", outputDirectory, documents);
}

// Formats the table of contents for the G4™ documentation, listing plugins and their associated Markdown documents.
static (string Directory, string File, string Content) FormatPluginsTableOfContent(
    string outputDirectory,
    IEnumerable<IGrouping<string, (string Directory, string File, string Content)>> manifestDocuments)
{
    return FormatTableOfContentItems(title: "Plugins", outputDirectory, documents: manifestDocuments);
}

// Formats the table of contents for the G4™ documentation.
static (string Directory, string File, string Content) FormatTableOfContentItems(
    string title,
    string outputDirectory,
    IEnumerable<IGrouping<string, (string Directory, string File, string Content)>> documents)
{
    // Return an empty tuple if there are no general documents
    if (documents?.Any() != true)
    {
        return (string.Empty, string.Empty, string.Empty);
    }

    // Initialize the table of content list with the main title and header
    var tableOfContent = new List<string>
    {
        $"## {title}",
        ""
    };

    // Iterate over each group of document documents
    foreach (var group in documents)
    {
        // Extract the base path and plugin type from the group
        var basePath = group.Key;
        var type = Path.GetFileName(basePath);

        // Add the plugin type as a section in the table of content
        tableOfContent.Add($"* _**{type.ConvertToSpaceCase()}**_");

        // Iterate over each document in the group, sorted by file name
        foreach (var document in group.OrderBy(i => i.File))
        {
            // Extract the header value from the document content
            var headerValue = Regex.Match(input: document.Content, pattern: @"(?<=^#\s+)(.+)").Value;

            // If header value is empty, set it to "N/A"
            var header = string.IsNullOrEmpty(headerValue) ? "N/A" : headerValue;

            // Generate the document link relative to the output directory
            var documentLink = $"{document.Directory.Replace(outputDirectory, ".").Replace("\\", "/")}/{document.File}";

            // Construct the table of content entry for the plugin document
            var entry = $"  * [{header.Trim()}]({documentLink})";

            // Add the entry to the table of content
            tableOfContent.Add(entry);
        }

        // Add an empty line after each plugin section
        tableOfContent.Add("");
    }

    // Return a tuple containing the directory, file name, and content of the table of contents document
    return (outputDirectory, "Home.md", string.Join("\n", tableOfContent));
}

// Recursively reads documents from the specified directory and its subdirectories.
static List<(string Directory, string File, string Content)> ReadDocuments(string baseDirectory, string docsDirectory, string outputDirectory)
{
    // Set docsDirectory to baseDirectory if it's null or empty, otherwise use docsDirectory as is.
    docsDirectory = string.IsNullOrEmpty(docsDirectory)
        ? baseDirectory
        : docsDirectory;

    // Check if the directory path is null or empty
    if (string.IsNullOrEmpty(docsDirectory) || !Directory.Exists(docsDirectory))
    {
        // If so, return an empty list
        return [];
    }

    // Get all files and directories in the specified directory
    var files = Directory.GetFiles(docsDirectory);
    var directories = Directory.GetDirectories(docsDirectory);
    var directoryItems = files.Concat(directories);
    var documents = new List<(string Directory, string File, string Content)>();

    // Iterate through each file or directory
    foreach (var item in directoryItems)
    {
        // Check if the current item is a file
        if (!Directory.Exists(item))
        {
            // Checks if the file extension of the given item path ends with ".md".
            if (!Path.GetFileName(item).EndsWith(".md"))
            {
                // Skip to the next iteration if the file extension is not ".md"
                continue;
            }

            // If it's a file, extract directory, file name, and content
            var directory = Path.GetDirectoryName(item);
            var file = Path.GetFileName(item);
            var content = File.ReadAllText(item);
            var document = ($"{directory}".Replace(baseDirectory, outputDirectory), file, content);

            // Add the document to the list
            documents.Add(document);

            // Continue to the next iteration
            continue;
        }

        // If the current item is a directory, recursively call ReadDocuments on it
        var documentsCollection = ReadDocuments(baseDirectory, item, outputDirectory);

        // Add all documents from the subdirectory to the main list
        documents.AddRange(documentsCollection);
    }

    // Return the list of documents
    return documents;
}

// Reads G4™ plugin manifests by identifying types with G4PluginAttribute and confirming their inheritance from PluginBase.
static G4PluginAttribute[] ReadManifests()
{
    // Determines whether the specified type has a custom attribute of the specified type.
    static bool ConfirmAttribute<T>(Type type) where T : Attribute => type.GetCustomAttribute<T>() != null;

    // Determines whether the specified type inherits from or implements the specified base type or interface.
    static bool ConfirmBase<T>(Type type) => typeof(T).IsAssignableFrom(type);

    // Import types from assemblies
    var types = new AssembliesLoader().ImportTypes().Values;

    // Filter types with G4PluginAttribute and confirm inheritance from PluginBase
    var attributes = types.Where(i => ConfirmAttribute<G4PluginAttribute>(i) && ConfirmBase<PluginBase>(i));

    // Extract G4PluginAttribute instances
    return attributes
        .Select(i => i.GetCustomAttribute<G4PluginAttribute>())
        .ToArray();
}

// Writes documents to specified directories based on provided data.
static void WriteDocuments(IEnumerable<(string Directory, string File, string Content)> documents)
{
    // Group documents by their directory path
    foreach (var group in documents.GroupBy(i => i.Directory))
    {
        // Create the directory if it doesn't exist (only creates once per unique directory)
        Directory.CreateDirectory(group.Key);

        // Loop through each document within the current directory group
        foreach (var (directory, file, content) in group)
        {
            // Combine filename with the existing directory path
            var path = Path.Combine(directory, file);

            // Write the content to the specified file path
            File.WriteAllText(path, content);
        }
    }
}

// Displays the help message explaining the usage and options of the API Documents Generator tool.
static void WriteHelp()
{
    // Display usage and options information
    Console.WriteLine("Usage: G4APIDocumentsGenerator [options]");
    Console.WriteLine("Options:");
    Console.WriteLine("  --DocsBaseDirectory <folderPath>   Specifies an extra markdown documentation folder to include when generating documents.");
    Console.WriteLine("  --OutputDirectory   <folderPath>   Specifies the folder where documents will be generated.");
    Console.WriteLine("  --Help                             Displays this help message.");
    Console.WriteLine("");
}

// Displays an introduction message for the API Documents Generator tool.
static void WriteHeader()
{
    // G4™ logo ASCII art
    var logo = new[]
    {
        "    ____ _  _     ____                                        _               ",
        "   / ___| || |   |  _ \\  ___   ___ _   _ _ __ ___   ___ _ __ | |_ ___        ",
        "  | |  _| || |_  | | | |/ _ \\ / __| | | | '_ ` _ \\ / _ \\ '_ \\| __/ __|    ",
        "  | |_| |__   _| | |_| | (_) | (__| |_| | | | | | |  __/ | | | |_\\__ \\      ",
        "   \\____|  |_|  _|____/ \\___/ \\___|\\__,_|_| |_|_|_|\\___|_| |_|\\__|___/  ",
        "               / ___| ___ _ __   ___ _ __ __ _| |_ ___  _ __                  ",
        "              | |  _ / _ \\ '_ \\ / _ \\ '__/ _` | __/ _ \\| '__|             ",
        "              | |_| |  __/ | | |  __/ | | (_| | || (_) | |                    ",
        "               \\____|\\___|_| |_|\\___|_|  \\__,_|\\__\\___/|_|              ",
        "                                                                              ",
        "                                          G4™ - Automation as a Service        ",
        "                                                  Powered by G4-Engine        ",
        "                                                                              ",
        "  Version: v4.0.0.0                                                           ",
        "  Project: https://github.com/g4-api                                          ",
        "                                                                              ",
        "  This tool is designed to help you generate professional and comprehensive   ",
        "  API documentation from your G4™ plugins.                                     "
    };

    // Display the logo
    Console.WriteLine(string.Join("\n", logo));

    // Display an empty line for better readability
    Console.WriteLine("");
    Console.WriteLine("");
}
