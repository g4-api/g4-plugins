# Patch (Patch)

[Table of Content](../Home.md)  

~31 min · HttpMethod Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `Patch` plugin is to partially update data on a server or API endpoint by sending an HTTP PATCH request. 
This request is a standard method in the HTTP protocol for making partial updates to a specified resource on the server. 
The `Patch` plugin streamlines the process of making programmatically controlled PATCH requests.

### Key Features and Functionality

| Feature                    | Description                                                              |
|----------------------------|--------------------------------------------------------------------------|
| Data Update                | Sends HTTP PATCH requests to partially update data on servers or APIs.   |
| Dynamic Requests           | Supports dynamic URL construction and payload handling.                  |
| Custom Headers             | Allows inclusion of multiple custom headers in the request.              |
| Content Types and Encoding | Supports various content types and encoding methods for payloads.        |
| Response Handling          | Captures HTTP response, headers, and status code for further processing. |

### Usages in RPA

| Usage                | Description                                                                                                           |
|----------------------|-----------------------------------------------------------------------------------------------------------------------|
| Data Management      | Partially update existing data in external systems or APIs, such as updating customer records or product information. |
| Workflow Adjustments | Dynamically adjust actions based on the data updated, triggering subsequent workflow steps.                           |

### Usages in Automation Testing

| Usage                              | Description                                                                                                                                                                                                                                                           |
|------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| API Data Update                    | Automated test scripts can leverage the `Patch` rule to send PATCH requests to API endpoints, updating data needed for testing scenarios. This ensures accurate and up-to-date test data for each test iteration.                                                     |
| Data Integrity Checks              | Automation tests often involve verifying the accuracy of data updates on the server. The `Patch` rule, combined with appropriate validation techniques, allows for precise confirmation that the specified data has been accurately updated, ensuring data integrity. |
| Regression Testing for Data Update | Ensuring that data update functionalities continue to work as expected after updates or changes to external systems.                                                                                                                                                  |

## Examples

### Example No.1

Use the `Patch` plugin to send a simple HTTP PATCH request to a specified URL.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "http://localhost:9002/api/hotels/12345"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("http://localhost:9002/api/hotels/12345");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "http://localhost:9002/api/hotels/12345"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "http://localhost:9002/api/hotels/12345"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "http://localhost:9002/api/hotels/12345"
}
```
### Example No.2

Use the `Patch` plugin to send an HTTP PATCH request with specified headers.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Header:Authorization=Bearer token123 --Header:Custom-Header=CustomValue}}"
}
```
### Example No.3

Use the `Patch` plugin to send an HTTP PATCH request with a request body and content type.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345 --Body:{"status":"updated"} --ContentType:application/json}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Body:{"status":"updated"} --ContentType:application/json}}"
}
```
### Example No.4

Use the `Patch` plugin to send an HTTP PATCH request with a specified encoding.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345 --Encoding:UTF8}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345 --Encoding:UTF8}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345 --Encoding:UTF8}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Encoding:UTF8}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Encoding:UTF8}}"
}
```
### Example No.5

Use the `Patch` plugin to send an HTTP PATCH request with form fields.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345 --Field:status=updated}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345 --Field:status=updated}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345 --Field:status=updated}}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Field:status=updated}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345 --Field:status=updated}}"
}
```
### Example No.6

Use the `Patch` plugin to send an HTTP PATCH request and extract a specific attribute from the response.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    OnAttribute = "status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345}}")
    .setOnAttribute("status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    onAttribute: "status"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "onAttribute": "status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "onAttribute": "status"
}
```
### Example No.7

Use the `Patch` plugin to send an HTTP PATCH request and target elements using XPath.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    OnElement = "//response/status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345}}")
    .setOnElement("//response/status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    onElement: "//response/status"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "onElement": "//response/status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "onElement": "//response/status"
}
```
### Example No.8

Use the `Patch` plugin to send an HTTP PATCH request and apply a regular expression to extract specific data from the response.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Patch",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    RegularExpression = "\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Patch")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/12345}}")
    .setRegularExpression("\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Patch",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    regularExpression: "\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "regularExpression": "\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Patch",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/12345}}",
    "regularExpression": "\d{3}"
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

Holds the results of the HTTP request after `OnElement`, `OnAttribute`, and `RegularExpression` have been applied. 
If none of these properties are provided, then the entire response body is stored in the `HttpResponse` parameter.  

This means that the `HttpResponse` parameter captures the content resulting from any data extraction or processing performed by the specified properties (`OnElement`, `OnAttribute`, `RegularExpression`). 
It provides a way to access the modified or processed content of the HTTP response within the automation workflow.

### Http Response Headers (HttpResponseHeaders)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP response headers obtained from the HTTP PATCH request. 
These headers provide additional information about the server's response and are sent along with the actual content of the response.

### Http Status Code (HttpStatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP status code obtained from the HTTP PATCH request. 
The HTTP status code is a three-digit numeric code returned by the server indicating the outcome of the request.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Uri|Expression    |

Specifies the details for the HTTP PATCH request. 
It includes a template or variable structure `{{$...}}` to allow dynamic values.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Used to target elements using either XPath or JSONPath expressions, depending on the type of response the API returns (XML or JSON). 
This flexibility allows the rule to handle different response formats appropriately.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Used for pattern matching and extraction of specific data from a text response. 
It allows for the definition of a regular expression that captures and extracts relevant information from the content retrieved by the HTTP PATCH request.

## Parameters

### Body (Body)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the payload or data that you want to include in the body of the request. 
The request body is typically used to send data to the server when making HTTP requests, especially for operations like `POST` or `PUT`.

### Content Type (ContentType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the type of data that is included in the body of the request. 
It indicates the format or encoding of the content being sent, allowing the server to interpret and process the data appropriately.  

The ContentType parameter is crucial because it tells the server how to parse and handle the incoming data. 
Different types of data, such as JSON, XML, form-urlencoded, or plain text, have different syntax and structures. 
By specifying the content type, you inform the server about the expected format of the data in the request body.

#### Values

##### Applicationjson

JavaScript Object Notation (JSON) is a lightweight data interchange format. 
It is easy for humans to read and write and easy for machines to parse and generate. 
JSON is often used for representing structured data in web applications.
##### Applicationoctetstream

This content type is a generic binary format. 
It is often used when the content type is not known or when transferring arbitrary binary data that doesn't fit into other more specific categories.
##### Applicationpdf

Portable Document Format (PDF) is a file format that captures all the elements of a printed document as an electronic image. 
It is widely used for documents intended for printing, such as brochures, manuals, and forms.
##### Applicationxml

Extensible Markup Language (XML) is a markup language that defines rules for encoding documents in a format that is both human-readable and machine-readable. 
It is often used for representing structured data in a generic way.
##### Audiompeg

MP3 is a widely used audio compression format that allows for the storage of music and audio files with relatively high audio quality in a compact size.
##### Imagejpeg

JPEG (Joint Photographic Experts Group) is a commonly used method of lossy compression for digital images. 
It is suitable for photographs and images with complex colors.
##### Imagepng

PNG (Portable Network Graphics) is a raster graphics file format that supports lossless data compression. 
It is commonly used for images on the web and supports transparent backgrounds.
##### Multipartformdata

This content type is used when submitting forms that contain files or binary data along with other text form fields. 
It allows for the encapsulation of multiple sets of data in a single body.
##### Textcss

Cascading Style Sheets (CSS) is a style sheet language used for describing the look and formatting of a document written in HTML. 
It defines styles for elements, including layout, colors, and fonts.
##### Texthtml

Hypertext Markup Language (HTML) is used to structure content on the web. 
It provides a way to create structured documents by denoting structural semantics for text such as headings, paragraphs, lists, links, quotes, and other items.
##### Textplain

This content type is used for plain, unformatted text. 
It is often used for simple textual data that doesn't require any special formatting or styling.
##### Applicationxwwwformurlencoded

This content type is used for sending form data in the body of an HTTP request. 
Data is URL-encoded, where special characters are replaced with `%` followed by two hexadecimal digits.
##### Videomp4

MP4 (MPEG-4 Part 14) is a multimedia container format commonly used for storing video and audio, as well as other data such as subtitles and still images.

### Encoding (Encoding)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies how text data in the request body is represented as binary code, ensuring accurate interpretation by both the sender and receiver.

#### Values

##### Ascii

ASCII is a basic character encoding standard that represents characters using 7 bits, providing codes for 128 characters.
It includes standard English letters, digits, and some special characters.
ASCII is a subset of UTF-8, and UTF-8 is designed to be backward-compatible with ASCII.
It forms the foundation for many character encodings and is widely used, especially in English-language content.
##### Big Endian Unicode

BigEndianUnicode is a specific form of UTF-16 where the most significant byte is stored first.
It is used in specific platforms, particularly those employing big-endian byte order.
Represents characters using 16-bit code units, with a specific byte order in storage.
##### Latin1

ISO-8859-1, also known as Latin-1, covers a subset of characters from the Latin alphabet, including many Western European languages.
It uses a fixed single-byte encoding.
While not as versatile as UTF-8 for handling diverse character sets, it is used in certain contexts, especially when compatibility with legacy systems is a concern.
##### Unicode

Unicode is a comprehensive character encoding standard assigning a unique code point to every character.
It provides a universal representation of characters from diverse languages and scripts.
Enables global character representation, fostering internationalization and multilingual content in various applications.
##### Utf7

UTF-7 is a variable-length encoding designed for environments restricting the use of 8-bit data.
Although less common today, it finds applications in email.
Utilizes a 7-bit code, making it suitable for environments with limitations on 8-bit data transmission.
##### Utf8

UTF-8 is the most widely used character encoding on the web.
It can represent virtually all characters in the Unicode character set, making it suitable for internationalization and multilingual content.
Each character is represented by a variable number of bytes, with ASCII characters represented by a single byte.
##### Utf32

UTF-32 uses a fixed 32-bit code point to represent each character.
It offers a straightforward mapping of characters but may be less space-efficient compared to UTF-8 and UTF-16.
Provides a direct correspondence between code points and characters, ensuring simplicity in character representation.

### Field (Field)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Key/Value         |

Specifies a form field that you include in the body of the request when making a `POST` or `PUT` request with `form-urlencoded` data.

### Header (Header)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Key/Value         |

Allows the inclusion of multiple headers in the HTTP PATCH request. 
Each header is specified as a key-value pair, separated by an equal sign. 
Multiple headers can be added using the syntax `{{$ --Header:header1name=header1value --Header:header2name=header2value ...}}`.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Uri|String        |

Specifies the target URL for the HTTP PATCH request.

## Scope

* Any