# Read Pdf File (ReadPdfFile)

[Table of Content](../Home.md)  

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Reads PDF and plain text files from a file path and extracts their full text content.
PDF files are processed page by page using PdfPig; all other file types are read directly as plain text.
A regular expression filters the extracted content, and the matched result is converted to Base64 for safe transport and storage.
Makes it straightforward to pull specific data from documents inside automation workflows without custom code.

### Key Features and Functionality

| Feature                      | Description                                                                           |
|------------------------------|---------------------------------------------------------------------------------------|
| PDF Text Extraction          | Reads all pages of a PDF using PdfPig and joins word tokens into a single text block. |
| Plain Text File Reading      | Reads non-PDF files directly using the system default encoding.                       |
| Regular Expression Filtering | Applies a regex to the extracted content to isolate a specific portion of the text.   |
| Base64 Encoding              | Converts the matched content to Base64 for safe transport and reuse.                  |
| Session Storage              | Saves the extracted result in a session parameter for use by downstream steps.        |

### Usages in RPA

| Use Case                 | Description                                                                                 |
|--------------------------|---------------------------------------------------------------------------------------------|
| Invoice Data Extraction  | Pull invoice numbers, totals, or dates from PDF invoices during document processing runs.   |
| Report Parsing           | Read summary sections from generated PDF reports and pass values to downstream steps.       |
| Text File Processing     | Extract specific lines or values from plain text log or configuration files.                |
| Document Content Routing | Read file content and store it in session parameters for further classification or routing. |

### Usages in Automation Testing

| Use Case                 | Description                                                                                       |
|--------------------------|---------------------------------------------------------------------------------------------------|
| PDF Content Assertion    | Verify that a generated PDF contains expected text such as a confirmation number or status label. |
| Report Validation        | Read values from exported PDF reports and compare them against expected test data.                |
| File Output Verification | Check that a workflow-generated text file contains the correct content after processing.          |
| Regex Match Testing      | Confirm that specific patterns are present in extracted file content as part of test assertions.  |

## Examples

### Example No.1

### Extract Full Text from a PDF File

Reads all pages of the PDF at the given path using PdfPig and joins word tokens into a single text block.
No custom regular expression is supplied, so the default `(?si).*` pattern matches all extracted content.
The full text is stored in the session parameter `ReadPdfFile:Content` for use in downstream steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadPdfFile",
    Argument = "C:/Reports/document.pdf"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadPdfFile")
    .setArgument("C:/Reports/document.pdf");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ReadPdfFile",
    argument: "C:/Reports/document.pdf"
};
```

_**JSON**_

```js
{
    "pluginName": "ReadPdfFile",
    "argument": "C:/Reports/document.pdf"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ReadPdfFile",
    "argument": "C:/Reports/document.pdf"
}
```
### Example No.2

### Extract Filtered Content Using a Regular Expression

Reads the file at the given path and applies a regular expression to the extracted text.
A regular expression `Invoice\s+#\d+` is applied to the extracted content to isolate matching invoice identifiers.
The first match is converted to Base64 and stored in the session parameter `ReadPdfFile:Content`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadPdfFile",
    Argument = "C:/Reports/document.pdf",
    RegularExpression = "Invoice\s+#\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadPdfFile")
    .setArgument("C:/Reports/document.pdf")
    .setRegularExpression("Invoice\s+#\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "ReadPdfFile",
    argument: "C:/Reports/document.pdf",
    regularExpression: "Invoice\s+#\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "ReadPdfFile",
    "argument": "C:/Reports/document.pdf",
    "regularExpression": "Invoice\s+#\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "ReadPdfFile",
    "argument": "C:/Reports/document.pdf",
    "regularExpression": "Invoice\s+#\d+"
}
```

## Output Parameter

### Read Pdf File Content (ReadPdfFile:Content)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

ReadPdfFile:Content holds the full text content extracted from the PDF or plain text file.
Reference it in downstream steps to reuse the content without re-reading the source file.
Set every time the plugin runs, regardless of the regular expression configured.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the path to the file to read.
PDF files are processed with PdfPig to extract text from every page.
All other file types are read as plain text using the system default encoding.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?si).*           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Applies a regular expression to the extracted file content to isolate a specific portion.
Defaults to `(?si).*` when omitted, which selects the entire extracted text.
If no match is found, the result is set to an empty string.

## Scope

* Any