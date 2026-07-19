# Post (Post)

[Table of Content](../Home.md)  

~31 min · HttpMethod Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The Post plugin lets your automation workflows send data to a server or API with an HTTP POST request.
It uses the standard POST method to transmit information for processing by a specified resource.
This makes it simple and reliable to automate data submissions across different systems.

### Key Features and Functionality

| Feature                    | Description                                                         |
|----------------------------|---------------------------------------------------------------------|
| Data Submission            | Sends data to a server or API using an HTTP POST request.           |
| Dynamic URLs and Payloads  | Builds requests with changing URLs and data as needed.              |
| Custom Headers             | Lets you add any HTTP headers to control the request.               |
| Content Types and Encoding | Works with different data formats and encodings.                    |
| Response Handling          | Captures status codes, headers, and response bodies for next steps. |

### Usages in RPA

| Use Case         | Description                                                                              |
|------------------|------------------------------------------------------------------------------------------|
| Data Submission  | Submit customer details or form entries to external systems or APIs.                     |
| Workflow Actions | Trigger next steps based on the results of the data submission in an automated workflow. |

### Usages in Automation Testing

| Use Case                               | Description                                                                                |
|----------------------------------------|--------------------------------------------------------------------------------------------|
| API Data Creation                      | Automated tests send POST requests to create or update test data before running scenarios. |
| Data Integrity Checks                  | Tests verify that the server processed the submitted data correctly.                       |
| Regression Testing for Data Submission | Checks that data submission features still work correctly after system changes.            |

## Examples

### Example No.1

### Simple HTTP POST Request

The `Post` plugin sends an HTTP POST request to the specified URL using the `argument` field.
This example does not include a request body or custom headers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "http://api.example.com/v1/connect"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("http://api.example.com/v1/connect");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "http://api.example.com/v1/connect"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "http://api.example.com/v1/connect"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "http://api.example.com/v1/connect"
}
```
### Example No.2

### HTTP POST Request with Headers

The `Post` plugin sends an HTTP POST request to the specified URL and includes headers defined in the `argument` field.
It sets the `Authorization` header using the Basic scheme with credentials formatted as `username:password`.
This example does not include a request body.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/connect --Header:Authorization=Basic username:password}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/connect --Header:Authorization=Basic username:password}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/connect --Header:Authorization=Basic username:password}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/connect --Header:Authorization=Basic username:password}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/connect --Header:Authorization=Basic username:password}}"
}
```
### Example No.3

### HTTP POST Request with Body and Content Type

The `Post` plugin sends an HTTP POST request to the specified URL using the `argument` field.
It includes a JSON-formatted request body and sets the `Content-Type` header accordingly.
This example does not include additional custom headers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --ContentType:application/json}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --ContentType:application/json}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --ContentType:application/json}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --ContentType:application/json}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --ContentType:application/json}}"
}
```
### Example No.4

### HTTP POST Request with Specified Encoding

The `Post` plugin sends an HTTP POST request to the specified URL using the flags in the `argument` field.
It includes a JSON-formatted request body and uses the specified text encoding for the request.
This example sets the encoding to UTF8 and does not include custom headers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Encoding:UTF8}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Encoding:UTF8}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Encoding:UTF8}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Encoding:UTF8}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Encoding:UTF8}}"
}
```
### Example No.5

### HTTP POST Request with Form Fields

The `Post` plugin sends an HTTP POST request to the specified URL with form fields encoded in the request body.
It sets the `Content-Type` header to application/x-www-form-urlencoded and adds fields with the `--Field` flag.
This example does not include a JSON body.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book/encoded --ContentType:application/x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book/encoded --ContentType:application/x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book/encoded --ContentType:application/x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --ContentType:application/x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --ContentType:application/x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite}}"
}
```
### Example No.6

### HTTP POST Request with Attribute Extraction

The `Post` plugin sends an HTTP POST request to the specified URL with the provided JSON body.
It extracts the `status` attribute from the element selected by the XPath `//response` using the `onElement` and `onAttribute` settings.
It returns the value of that attribute.
This example uses no custom headers or content type flags.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    OnAttribute = "status",
    OnElement = "//response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}")
    .setOnAttribute("status")
    .setOnElement("//response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    onAttribute: "status",
    onElement: "//response"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "onAttribute": "status",
    "onElement": "//response"
}
```
### Example No.7

### HTTP POST Request with XPath Element Targeting

The `Post` plugin sends an HTTP POST request to the specified URL with the provided JSON body.
It selects elements matching the XPath `//response/HotelName` using the `onElement` setting and returns their text content.
This example uses no custom headers or content type flags.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    OnElement = "//response/HotelName"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}")
    .setOnElement("//response/HotelName");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    onElement: "//response/HotelName"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "onElement": "//response/HotelName"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "onElement": "//response/HotelName"
}
```
### Example No.8

### HTTP POST Request with Regex Extraction

The `Post` plugin sends an HTTP POST request to the specified URL with the provided JSON body.
It applies the regular expression `<bookingReference>([A-Z0-9]{6})</bookingReference>` to the response text and returns the first captured group, which represents the booking reference code.
This example does not include custom headers or content type flags.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Post",
    Argument = "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    RegularExpression = "<bookingReference>([A-Z0-9]{6})</bookingReference>"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Post")
    .setArgument("{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}")
    .setRegularExpression("<bookingReference>([A-Z0-9]{6})</bookingReference>");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Post",
    argument: "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    regularExpression: "<bookingReference>([A-Z0-9]{6})</bookingReference>"
};
```

_**JSON**_

```js
{
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "regularExpression": "<bookingReference>([A-Z0-9]{6})</bookingReference>"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Post",
    "argument": "{{$ --Url:http://api.example.com/v1/book/encoded --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"}}}",
    "regularExpression": "<bookingReference>([A-Z0-9]{6})</bookingReference>"
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

Specifies where to send the HTTP POST request and what data to include.
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