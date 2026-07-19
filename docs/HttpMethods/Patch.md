# Patch (Patch)

[Table of Content](../Home.md)  

~28 min · HttpMethod Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The Patch plugin lets automation workflows update only the parts of a resource they need on a server or API.
It uses the standard HTTP PATCH method to apply partial changes, so you don't have to send the whole resource every time.
This plugin makes building partial updates simple and reliable across different automation tasks.

### Key Features and Functionality

| Feature                    | Description                                                                     |
|----------------------------|---------------------------------------------------------------------------------|
| Data Update                | Sends HTTP PATCH requests to partially update data on servers or APIs.          |
| Dynamic Requests           | Builds request URLs dynamically and lets you send different payloads as needed. |
| Custom Headers             | Lets you include any custom headers in the request.                             |
| Content Types and Encoding | Supports different data formats and encoding options in the request body.       |
| Response Handling          | Captures status code, headers, and body of responses for further processing.    |

### Usages in RPA

| Use Case             | Description                                                                                         |
|----------------------|-----------------------------------------------------------------------------------------------------|
| Data Management      | Partially update records in other systems or APIs, like updating user profiles or inventory counts. |
| Workflow Adjustments | Use updated data to decide the next steps in your automation flow.                                  |

### Usages in Automation Testing

| Use Case                       | Description                                                                         |
|--------------------------------|-------------------------------------------------------------------------------------|
| API Data Update                | Use PATCH requests in tests to set up or modify test data on the server.            |
| Data Integrity Checks          | Confirm that only the intended fields were changed on the server.                   |
| Regression Testing for Updates | Check that partial update features keep working after code changes or new releases. |

## Examples

### Example No.1

### PATCH request with request body and content type

Use the `Patch` plugin to send an HTTP PATCH request with a request body and content type.
Specify the endpoint URL via the `--Url` option in the `argument` field.
Provide the request body with the `--Body` option containing a JSON object.
Set the content type header with the `--ContentType` option.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
}
```
### Example No.2

### PATCH request with encoding

Use the `Patch` plugin to send an HTTP PATCH request with a specified encoding.
Specify the endpoint URL via the `--Url` option in the `argument` field.
Provide the request body with the `--Body` option containing a JSON object.
Set the content type header with the `--ContentType` option.
Set the request encoding using the `--Encoding` option.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json --Encoding:UTF8}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json --Encoding:UTF8}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json --Encoding:UTF8}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json --Encoding:UTF8}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json --Encoding:UTF8}}"
}
```
### Example No.3

### PATCH request with form fields

Use the `Patch` plugin to send an HTTP PATCH request with form fields.
Specify the endpoint URL via the `--Url` option in the `argument` field.
Provide form fields using the `--Field` option with key=value pairs.
Include multiple form fields by repeating the `--Field` option.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
}
```
### Example No.4

### PATCH request with response extraction

Use the `Patch` plugin to send an HTTP PATCH request and extract a specific attribute from the response.
Specify the endpoint URL via the `--Url` option in the `argument` field.
Provide the request body with the `--Body` option containing a JSON object.
Set the content type header with the `--ContentType` option.
Extract the attribute by setting `onElement` to the target element path and `onAttribute` to the attribute name.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}",
    OnAttribute = "status",
    OnElement = "//response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}")
    .setOnAttribute("status")
    .setOnElement("//response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}",
    onAttribute: "status",
    onElement: "//response"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Body:{"status":"updated"} --ContentType:application/json}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```
### Example No.5

### PATCH request targeting elements

Use the `Patch` plugin to send an HTTP PATCH request and target response elements using an XPath expression.
Specify the endpoint URL and form fields via the `--Url` and `--Field` options in the `argument` field.
Set the XPath expression for element targeting with the `onElement` field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    OnElement = "//response/status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}")
    .setOnElement("//response/status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    onElement: "//response/status"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    "onElement": "//response/status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    "onElement": "//response/status"
}
```
### Example No.6

### PATCH request targeting elements with JSONPath

Use the `Patch` plugin to send an HTTP PATCH request and target response elements using a JSONPath expression.
Specify the endpoint URL and form fields via the `--Url` and `--Field` options in the `argument` field.
Set the JSONPath expression for element targeting with the `onJsonPath` field.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}"
}
```
### Example No.7

### PATCH request with regex extraction

Use the `Patch` plugin to send an HTTP PATCH request and apply a regular expression to extract specific data from the response.
Specify the endpoint URL and form fields via the `--Url` and `--Field` options in the `argument` field.
Set the regular expression for data extraction with the `regularExpression` field.
The regex `"id":\s*"(\d+)"` extracts the numeric ID value from a JSON response.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    RegularExpression = "\"id\":\s*\"(\d+)\""
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}")
    .setRegularExpression("\"id\":\s*\"(\d+)\"");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    regularExpression: "\"id\":\s*\"(\d+)\""
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    "regularExpression": "\"id\":\s*\"(\d+)\""
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://api.example.com/v1/12345 --Field:status=updated}}",
    "regularExpression": "\"id\":\s*\"(\d+)\""
}
```

## Output Parameter

### Http Response (HttpResponse)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the content returned from an HTTP request after any specified extraction or processing rules have been applied.
Provides a way to work with the processed response data instead of the raw body.
Enables automation workflows to access the exact information they need from the HTTP response.

### Http Response Headers (HttpResponseHeaders)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP response headers returned from an HTTP request.
Contains key-value pairs that provide metadata about the response such as content type, date, and length.
Enables workflows to inspect response details for logging or conditional logic.

### Http Status Code (HttpStatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP status code returned from an HTTP request.
Represents the outcome of the request using a three-digit numeric code.
Enables automation flows to check for success or failure of the HTTP operation.
Supports error handling in workflows based on the status code value.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Uri|Expression    |

Specifies where to send the HTTP PATH request and what data to include.
Allows dynamic values through templates or variable placeholders in the format {{$...}}.
Makes it possible to customize the request URL or payload at runtime.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the attribute whose value should be extracted from an element identified by the `OnElement` expression.
Works with XML or HTML responses, returning the value of the given attribute.
Enables precise retrieval of metadata embedded in tags for downstream workflow processing.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Targets specific parts of an API response by using XPath or JSONPath expressions.
Works with both XML and JSON responses.
Adapts to the response format to locate the right element.
Helps ensure the correct data is extracted regardless of the API’s output format.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Defines a pattern for capturing and extracting specific data from a text response.
Uses standard regular expression syntax to match and retrieve the parts you need.
Enables precise extraction of values embedded in the response.
Helps automate parsing of complex text outputs.

## Parameters

### Body (Body)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the data payload sent with a DELETE request.
Includes extra details the server may need to carry out the deletion.
Helps ensure the API has the context required to process the delete operation.

### Content Type (ContentType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Indicates the format of data sent in the request body.
Helps the server understand how to parse and handle the payload.
Supports formats such as JSON, XML, form data, and plain text.

#### Values

##### Applicationjson

Represents JSON data encoded as JavaScript Object Notation.
Allows for structured data that is easy to read and parse.
##### Applicationoctetstream

Denotes a generic binary data stream when the format is unknown.
Enables transferring files or data without predefined structure.
##### Applicationpdf

Identifies Portable Document Format files for documents and forms.
Ensures consistent rendering of printable content.
##### Applicationxml

Marks XML data formatted with Extensible Markup Language.
Provides a generic way to represent structured data.
##### Audiompeg

Specifies MPEG audio encoded in MP3 format.
Offers compressed audio suitable for music and podcasts.
##### Imagejpeg

Indicates JPEG images compressed for photographs.
Balances image quality with file size.
##### Imagepng

Signals PNG images with lossless compression.
Supports transparent backgrounds for web graphics.
##### Multipartformdata

Used for form submissions that include files and text fields.
Allows combining different data types in one request.
##### Textcss

Defines stylesheet content for web page styling in CSS.
Controls layout, colors, and fonts of HTML documents.
##### Texthtml

Represents HTML content to structure web pages.
Defines elements like headings, paragraphs, and links.
##### Textplain

Denotes plain text without special formatting.
Serves simple messages or logs in text form.
##### Applicationxwwwformurlencoded

Encodes URL-encoded form data in key-value pairs.
Pairs are separated by ampersands and percent-encoded if needed.
##### Videomp4

Specifies MP4 multimedia container for video and audio.
Supports subtitles and still images within the file.

### Encoding (Encoding)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Explains how text characters are converted to binary code for transmission.
Ensures the data is encoded and decoded correctly by both sender and receiver.
Allows different encoding standards to maintain compatibility across systems.

#### Values

##### Ascii

Uses 7-bit codes to represent 128 common characters such as letters, digits, and symbols.
Forms the basis for many modern text encoding systems.
Remains compatible with Unicode formats like UTF-8.
##### Big Endian Unicode

Stores each character in 16 bits with the most significant byte first.
Commonly used on platforms that follow big-endian byte ordering.
Ensures consistent decoding when big-endian formats are required.
##### Latin1

Also called ISO-8859-1 and covers many Western European languages.
Uses one byte per character for a total of 256 symbols.
Often used for legacy data but supports fewer characters than Unicode.
##### Unicode

Assigns a unique code point to every character in most writing systems.
Supports global text representation in a single standard.
Forms the foundation for encodings like UTF-8 and UTF-16.
##### Utf7

Encodes text using only 7-bit ASCII characters for safe transmission in restricted systems.
Was originally designed for email use where 8-bit data could be problematic.
Rarely used today because it is less efficient than modern encodings.
##### Utf8

Variable-length encoding that uses one to four bytes per character.
Covers all Unicode code points and is backward-compatible with ASCII.
Widely adopted as the standard text format on the web.
##### Utf32

Uses a fixed four bytes for each character’s code point.
Simplifies text processing by providing a constant width per character.
Consumes more memory but offers straightforward character indexing.

### Field (Field)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | KeyValue          |

Defines a form field to include in the request body using key=value pairs.
Encodes each field correctly so the server can read the data.
Lets you send extra parameters when the server requires them during a delete operation.

### Header (Header)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | KeyValue          |

Enables adding custom headers to an HTTP DELETE request.
Each header uses a name=value format so the server can read it correctly.
Allows you to repeat the parameter to include multiple headers.
Custom headers let you send extra information like authentication tokens or tracing data.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Uri|String        |

Defines the web address where the delete request is sent.
Tells the server which resource should be removed.
Ensures the correct endpoint is targeted for deletion.
Using an accurate URL helps prevent errors or deleting the wrong resource.

## Scope

* Any