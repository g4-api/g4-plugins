# Delete (Delete)

[Table of Content](../Home.md)  

~31 min · HttpMethod Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The Delete plugin lets automation workflows remove data from servers or APIs by sending HTTP DELETE requests.
It follows the standard HTTP protocol to request the removal of specified resources on a server.
This plugin simplifies programmatic data deletion and ensures consistency in automation processes.

### Key Features and Functionality

| Feature                    | Description                                                              |
|----------------------------|--------------------------------------------------------------------------|
| Data Deletion              | Sends HTTP DELETE requests to remove data from servers or APIs.          |
| Dynamic Requests           | Supports dynamic URL construction and payload handling.                  |
| Custom Headers             | Allows inclusion of custom headers in the request.                       |
| Content Types and Encoding | Supports various content types and encoding methods for payloads.        |
| Response Handling          | Captures HTTP response, headers, and status code for further processing. |

### Usages in RPA

| Use Case            | Description                                                                                                                |
|---------------------|----------------------------------------------------------------------------------------------------------------------------|
| Data Management     | Remove outdated or unnecessary data from external systems or APIs, such as outdated customer records or redundant entries. |
| Workflow Adjustments| Dynamically adjust subsequent workflow actions based on deletion requirements.                                             |

### Usages in Automation Testing

| Use Case                         | Description                                                                                                                                      |
|----------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| API Cleanup in Testing           | Use DELETE requests in automated tests to clean up data created during test execution, ensuring a controlled environment for each test run.      |
| Data Integrity Checks            | Combine deletion requests with validation steps to confirm that specified data has been accurately removed, ensuring system consistency.         |
| Regression Testing for Deletion  | Verify that deletion functionality remains intact after system updates or changes by replaying delete requests and confirming expected outcomes. |

## Examples

### Example No.1

### Simple DELETE request

Use the `Delete` plugin to send an HTTP DELETE request to a specific URL.
Delete the resource at that URL and capture the response.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "http://api.example.com/v1/delete/12345"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("http://api.example.com/v1/delete/12345");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "http://api.example.com/v1/delete/12345"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "http://api.example.com/v1/delete/12345"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "http://api.example.com/v1/delete/12345"
}
```
### Example No.2

### DELETE request with custom headers

Use the `Delete` plugin to send an HTTP DELETE request to a specific URL with custom headers.
Delete the resource at that URL and capture the response.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
}
```
### Example No.3

### DELETE request with JSON body and content type

Send an HTTP DELETE request to the specified URL with a JSON payload in the request body and the appropriate Content-Type header.
Return the response from the server.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete --Body:{"id":12345} --ContentType:application/json}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete --Body:{"id":12345} --ContentType:application/json}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete --Body:{"id":12345} --ContentType:application/json}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete --Body:{"id":12345} --ContentType:application/json}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete --Body:{"id":12345} --ContentType:application/json}}"
}
```
### Example No.4

### DELETE request with specified encoding

Send an HTTP DELETE request to the specified URL using the given encoding for the request.
Return the response from the server.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete/12345 --Encoding:UTF8}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete/12345 --Encoding:UTF8}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete/12345 --Encoding:UTF8}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345 --Encoding:UTF8}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345 --Encoding:UTF8}}"
}
```
### Example No.5

### DELETE request with form fields

Send an HTTP DELETE request to the specified URL with form fields.
If no `--ContentType` flag is provided, the request defaults to `application/json`.
Return the response from the server.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete --Field:id=12345}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete --Field:id=12345}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete --Field:id=12345}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete --Field:id=12345}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete --Field:id=12345}}"
}
```
### Example No.6

### DELETE request with attribute extraction

Send an HTTP DELETE request to the specified URL.
Extract the `status` attribute from the element identified by the XPath `//response` in the XML or HTML response.
Return the extracted attribute value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    OnAttribute = "status",
    OnElement = "//response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete/12345}}")
    .setOnAttribute("status")
    .setOnElement("//response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    onAttribute: "status",
    onElement: "//response"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```
### Example No.7

### DELETE request with JSONPath extraction

Send an HTTP DELETE request to the specified URL.
Extract the value at the JSONPath `$.data.id` from the JSON response using the onElement property.
Return the extracted value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    OnElement = "$.data.id"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete/12345}}")
    .setOnElement("$.data.id");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    onElement: "$.data.id"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "onElement": "$.data.id"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "onElement": "$.data.id"
}
```
### Example No.8

### DELETE request with regex extraction for deleted count

Send an HTTP DELETE request to the specified hotel-booking endpoint.
Extract the number of deleted records from the JSON response using the regular expression `"deletedCount":\s*(\d+)`.
Return the first matching count; ignore any additional matches.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Delete",
    Argument = "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    RegularExpression = "\"deletedCount\":\s*(\d+)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Delete")
    .setArgument("{{$ --Url:http://api.example.com/v1/delete/12345}}")
    .setRegularExpression("\"deletedCount\":\s*(\d+)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Delete",
    argument: "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    regularExpression: "\"deletedCount\":\s*(\d+)"
};
```

_**JSON**_

```js
{
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "regularExpression": "\"deletedCount\":\s*(\d+)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Delete",
    "argument": "{{$ --Url:http://api.example.com/v1/delete/12345}}",
    "regularExpression": "\"deletedCount\":\s*(\d+)"
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

Specifies where to send the HTTP DELETE request and what data to include.
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