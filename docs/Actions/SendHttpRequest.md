# Send Http Request (SendHttpRequest)

[Table of Content](../Home.md)  

~70 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The primary purpose of the `SendHttpRequest` plugin is to automate the process of sending HTTP requests. 
This is essential for interacting with web services, RESTful APIs, or any other HTTP-based communication.  

The plugin allows for dynamic configuration of the HTTP method (GET, POST, PUT, DELETE, etc.) and the URL. 
This flexibility is crucial in automation scenarios where the target endpoints or the nature of the requests may vary.  

The plugin supports parameterized requests, enabling users to customize the payload, headers, and other parameters of the HTTP request. 
This is valuable when dealing with APIs that require specific data inputs.

### Key Features and Functionality

| Feature                  | Description                                                                                                        |
|--------------------------|--------------------------------------------------------------------------------------------------------------------|
| Dynamic HTTP Method      | Allows configuration of HTTP methods such as GET, POST, PUT, DELETE, etc.                                          |
| URL Configuration        | Supports dynamic URL specification.                                                                                |
| Parameterized Requests   | Enables customization of payload, headers, and other request parameters.                                           |

### Usages in RPA

| Use Case                | Description                                                                                                                                           |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| Web Service Integration | Facilitate integration with external systems or web services by allowing robots to communicate with APIs, retrieve data, or trigger specific actions. |
| Workflow Orchestration  | Part of a larger workflow where data is fetched from web services, processed locally, and then used for subsequent automation steps.                  |

### Usages in Automation Testing

| Use Case                        | Description                                                                                                                        |
|---------------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| API Testing                     | Automate API testing by sending various types of requests (GET, POST, etc.) with different data payloads and validating responses. |
| Data Retrieval and Verification | Fetch data from web services to validate the correctness of a system or to compare it against expected results.                    |
| Load Testing                    | Simulate multiple concurrent HTTP requests to evaluate the system's behavior under load.                                           |

## Examples

### Example No.1

Send a default `GET` request to the specified API endpoint `http://localhost:9002/api/hotels/find`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "http://localhost:9002/api/hotels/find"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("http://localhost:9002/api/hotels/find");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "http://localhost:9002/api/hotels/find"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "http://localhost:9002/api/hotels/find"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "http://localhost:9002/api/hotels/find"
}
```
### Example No.2

Send an HTTP `GET` request to the URL `http://localhost:9002/api/hotels/connect` with an Authorization header using Basic authentication.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password}}"
}
```
### Example No.3

Send an HTTP request to `http://localhost:9002/api/hotels/headers`. 
The request includes runtime parameters for dynamic configuration, such as an Authorization header with a Bearer token (`YourAccessToken`), a Content-Type header set to `application/json`, and a User-Agent header set to `MyCustomUserAgent`. 
This configuration allows for sending a flexible HTTP request with specified headers, facilitating scenarios like authenticated requests with a custom user agent and a specific content type. 
If the HTTP method is not explicitly provided, the default behavior is assumed to be a `GET` request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url: http://localhost:9002/api/hotels/headers --Header:Authorization=Bearer YourAccessToken --Header:ContentType=application/json --Header:UserAgent=MyCustomUserAgent}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url: http://localhost:9002/api/hotels/headers --Header:Authorization=Bearer YourAccessToken --Header:ContentType=application/json --Header:UserAgent=MyCustomUserAgent}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url: http://localhost:9002/api/hotels/headers --Header:Authorization=Bearer YourAccessToken --Header:ContentType=application/json --Header:UserAgent=MyCustomUserAgent}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url: http://localhost:9002/api/hotels/headers --Header:Authorization=Bearer YourAccessToken --Header:ContentType=application/json --Header:UserAgent=MyCustomUserAgent}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url: http://localhost:9002/api/hotels/headers --Header:Authorization=Bearer YourAccessToken --Header:ContentType=application/json --Header:UserAgent=MyCustomUserAgent}}"
}
```
### Example No.4

Send an HTTP request to the specified URL `http://localhost:9002/api/hotels/find`. 
The argument includes runtime parameters for dynamic configuration. Additionally, the response is processed with a specified element, extracting the `pricePerNight` of the hotel with the name `Luxury Hotel`. 
The configuration facilitates a flexible HTTP request with the ability to extract specific data from the response, providing valuable information about a particular hotel. 
If the HTTP method is not explicitly provided, the default behavior is assumed to be a `GET` request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    OnElement = "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/find}}")
    .setOnElement("$.hotels[?(@.name=='Luxury Hotel')].pricePerNight");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    onElement: "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    "onElement": "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    "onElement": "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight"
}
```
### Example No.5

Send an HTTP request to the specified URL `http://localhost:9002/api/hotels/find`. 
The argument includes runtime parameters for dynamic configuration. 
Additionally, the response is processed with a specified element, extracting the `pricePerNight` of the hotel with the name `Luxury Hotel`. 
The configured regular expression `\d{2}` is applied to the extracted data, to match two consecutive digits. 
This configuration facilitates a flexible HTTP request with the ability to extract and process specific data from the response, applying a regular expression for further refinement. 
If the HTTP method is not explicitly provided, the default behavior is assumed to be a `GET` request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    OnElement = "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight",
    RegularExpression = "\d{2}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/find}}")
    .setOnElement("$.hotels[?(@.name=='Luxury Hotel')].pricePerNight")
    .setRegularExpression("\d{2}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    onElement: "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight",
    regularExpression: "\d{2}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    "onElement": "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight",
    "regularExpression": "\d{2}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find}}",
    "onElement": "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight",
    "regularExpression": "\d{2}"
}
```
### Example No.6

Send an HTTP request to the specified URL `http://localhost:9002/api/hotels/find/xml`. 
The argument includes runtime parameters for dynamic configuration, indicating an XML response format. 
Additionally, the response is processed with specified instructions, extracting the `PricePerNight` attribute from the XML element identified by the XPath expression '//HotelResult[./Name[.='Luxury Hotel']]'. 
This configuration allows for a flexible HTTP request and extraction of specific data from the XML response, useful for scenarios involving XML-based APIs or services. 
If the HTTP method is not explicitly provided, the default behavior is assumed to be a `GET` request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}",
    OnAttribute = "PricePerNight",
    OnElement = "//HotelResult[./Name[.='Luxury Hotel']]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/find/xml}}")
    .setOnAttribute("PricePerNight")
    .setOnElement("//HotelResult[./Name[.='Luxury Hotel']]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}",
    onAttribute: "PricePerNight",
    onElement: "//HotelResult[./Name[.='Luxury Hotel']]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}",
    "onAttribute": "PricePerNight",
    "onElement": "//HotelResult[./Name[.='Luxury Hotel']]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}",
    "onAttribute": "PricePerNight",
    "onElement": "//HotelResult[./Name[.='Luxury Hotel']]"
}
```
### Example No.7

Send an HTTP `POST` request to the specified URL `http://localhost:9002/api/hotels/connect`. 
The argument includes runtime parameters for dynamic configuration, such as an Authorization header with a Basic authentication scheme, and the HTTP method is explicitly set to `POST`. 
This configuration allows for flexible and authenticated HTTP requests, with runtime values for the URL and credentials. 
If the HTTP method is not explicitly provided, the default behavior is assumed to be a `GET` request.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/connect --Header:Authorization=Basic username:password --Method:Post}}"
}
```
### Example No.8

Send an HTTP `POST` request to the specified URL `http://localhost:9002/api/hotels/book`. 
The argument includes runtime parameters for dynamic configuration, such as the request body containing JSON data with details like the hotel name and room type, and the HTTP method is explicitly set to `POST`. 
This configuration allows for flexible and customizable HTTP requests, particularly useful for scenarios that necessitate sending a payload in the request body, as exemplified by booking a hotel room through an API.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Post}}"
}
```
### Example No.9

Send an HTTP `POST` request to `http://localhost:9002/api/hotels/book/text`. 
The request body is formatted as plain text, containing parameters like HotelName and RoomType separated by semicolons. 
The content type is set to `text/plain`, emphasizing the configuration's focus on sending a specific payload structure in the HTTP request. 
This is particularly useful for scenarios requiring plain text payload, such as booking a hotel room through an API.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Post}}"
}
```
### Example No.10

Send an HTTP `POST` request to `http://localhost:9002/api/hotels/book/text`. 
The request body is formatted as plain text with parameters like HotelName and RoomType separated by semicolons. 
The content type is set to `text/plain`, emphasizing the configuration's focus on sending a specific payload structure. 
The character encoding is specified as `ASCII`. This configuration is particularly useful for scenarios requiring plain text payload with a specific encoding in the HTTP request, as exemplified by booking a hotel room through an API.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Encoding:ASCII --Method:Post}}"
}
```
### Example No.11

Send an HTTP POST request to `http://localhost:9002/api/hotels/book/encoded`. 
The content type is set to `x-www-form-urlencoded`, indicating that the request body is formatted as URL-encoded form data. 
The argument includes runtime parameters for dynamic configuration, specifying form fields such as `HotelName`, `RoomType`, and `Rating` with their corresponding values. 
This configuration is particularly useful for scenarios requiring the submission of form data, as exemplified by booking a hotel room through an API.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/book/encoded --ContentType:x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite --Field:Rating=4.5 --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/book/encoded --ContentType:x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite --Field:Rating=4.5 --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/book/encoded --ContentType:x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite --Field:Rating=4.5 --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/encoded --ContentType:x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite --Field:Rating=4.5 --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/encoded --ContentType:x-www-form-urlencoded --Field:HotelName=Luxury Hotel --Field:RoomType=Suite --Field:Rating=4.5 --Method:Post}}"
}
```
### Example No.12

Send an HTTP POST request to `http://localhost:9002/api/hotels/book/xml`. 
The request body is formatted as XML data, encapsulated in a `HotelBookingRequest` element with child elements specifying details like `HotelName` and `RoomType`. 
The content type is set to `text/xml`, indicating the XML format of the request. 
The argument includes runtime parameters for dynamic configuration, facilitating scenarios requiring XML payload in the HTTP request, as exemplified by booking a hotel room through an API.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/book/xml --Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> --ContentType:text/xml --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/book/xml --Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> --ContentType:text/xml --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/book/xml --Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> --ContentType:text/xml --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/xml --Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> --ContentType:text/xml --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/book/xml --Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> --ContentType:text/xml --Method:Post}}"
}
```
### Example No.13

Send an HTTP DELETE request to `http://localhost:9002/api/hotels/delete/1`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for the resource deletion and the HTTP method as `DELETE`. 
This configuration is particularly useful for scenarios requiring the deletion of a specific resource identified by its ID, as exemplified by the API endpoint for deleting a hotel with ID `1`.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/delete/1 --Method:Delete}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/delete/1 --Method:Delete}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/delete/1 --Method:Delete}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/delete/1 --Method:Delete}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/delete/1 --Method:Delete}}"
}
```
### Example No.14

Send an HTTP PUT request to `http://localhost:9002/api/hotels/edit`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for editing, the request body containing JSON data with details like the new hotel name and room type, and the HTTP method as `PUT`. 
This configuration is particularly useful for scenarios requiring the modification or update of resource details, as exemplified by the API endpoint for editing hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/edit --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/edit --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/edit --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit --Body:{"hotelName":"Luxury Hotel","roomType":"Suite"} --Method:Put}}"
}
```
### Example No.15

Send an HTTP PUT request to `http://localhost:9002/api/hotels/edit/text`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for editing, the request body formatted as plain text with parameters like `HotelName` and `RoomType` separated by semicolons, the content type as `text/plain`, and the HTTP method as `PUT`. 
This configuration is particularly useful for scenarios requiring the modification or update of resource details with a plain text payload, as exemplified by the API endpoint for editing hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/edit/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/edit/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/edit/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit/text --Body:HotelName=Luxury Hotel;RoomType=Suite --ContentType:text/plain --Method:Put}}"
}
```
### Example No.16

Send an HTTP PUT request to `http://localhost:9002/api/hotels/edit/encoded`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for editing, form fields such as `HotelName` and `NewInfo` with their corresponding values. 
This configuration is particularly useful for scenarios requiring the modification or update of resource details using URL-encoded form data, as exemplified by the API endpoint for editing hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/edit/encoded --Field:HotelName=Luxury Hotel --Field:NewInfo=Foo Bar --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/edit/encoded --Field:HotelName=Luxury Hotel --Field:NewInfo=Foo Bar --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/edit/encoded --Field:HotelName=Luxury Hotel --Field:NewInfo=Foo Bar --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit/encoded --Field:HotelName=Luxury Hotel --Field:NewInfo=Foo Bar --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/edit/encoded --Field:HotelName=Luxury Hotel --Field:NewInfo=Foo Bar --Method:Put}}"
}
```
### Example No.17

Send an HTTP PUT request to `http://localhost:9002/api/hotels/edit/xml`. 
The request body is formatted as XML data, encapsulated in a `HotelUpdateRequest` element with child elements specifying details like `HotelName` and `NewInfo`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for editing, the XML data in the request body, and the HTTP method as PUT. 
This configuration is particularly useful for scenarios requiring the modification or update of resource details using XML payload, as exemplified by the API endpoint for editing hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> --Url:http://localhost:9002/api/hotels/edit/xml --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> --Url:http://localhost:9002/api/hotels/edit/xml --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> --Url:http://localhost:9002/api/hotels/edit/xml --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> --Url:http://localhost:9002/api/hotels/edit/xml --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> --Url:http://localhost:9002/api/hotels/edit/xml --Method:Put}}"
}
```
### Example No.18

Send an HTTP PATCH request to `http://localhost:9002/api/hotels/update`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for updating, the request body containing `JSON` data with details like the new hotel name and review, and the HTTP method as `PATCH`. 
This configuration is particularly useful for scenarios requiring a partial update of resource details, as exemplified by the API endpoint for updating hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/update --Body:{"hotelName":"Luxury Hotel","review":"Suite"} --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/update --Body:{"hotelName":"Luxury Hotel","review":"Suite"} --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/update --Body:{"hotelName":"Luxury Hotel","review":"Suite"} --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update --Body:{"hotelName":"Luxury Hotel","review":"Suite"} --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update --Body:{"hotelName":"Luxury Hotel","review":"Suite"} --Method:Patch}}"
}
```
### Example No.19

Send an HTTP PATCH request to `http://localhost:9002/api/hotels/update/text`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for updating, the request body formatted as plain text with parameters like `HotelName` and `Review` separated by semicolons, the content type as `text/plain`, and the HTTP method as `PATCH`. 
This configuration is particularly useful for scenarios requiring a partial update of resource details with a plain text payload, as exemplified by the API endpoint for updating hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/update/text --Body:HotelName=Luxury Hotel;Review=Suite --ContentType:text/plain --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/update/text --Body:HotelName=Luxury Hotel;Review=Suite --ContentType:text/plain --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/update/text --Body:HotelName=Luxury Hotel;Review=Suite --ContentType:text/plain --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update/text --Body:HotelName=Luxury Hotel;Review=Suite --ContentType:text/plain --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update/text --Body:HotelName=Luxury Hotel;Review=Suite --ContentType:text/plain --Method:Patch}}"
}
```
### Example No.20

Send an HTTP PATCH request to `http://localhost:9002/api/hotels/update/encoded`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for updating, form fields such as `HotelName` and `Review` with their corresponding values. 
This configuration is particularly useful for scenarios requiring a partial update of resource details using URL-encoded form data, as exemplified by the API endpoint for updating hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:http://localhost:9002/api/hotels/update/encoded --Field:HotelName=Luxury Hotel --Field:Review=Foo Bar --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:http://localhost:9002/api/hotels/update/encoded --Field:HotelName=Luxury Hotel --Field:Review=Foo Bar --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:http://localhost:9002/api/hotels/update/encoded --Field:HotelName=Luxury Hotel --Field:Review=Foo Bar --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update/encoded --Field:HotelName=Luxury Hotel --Field:Review=Foo Bar --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:http://localhost:9002/api/hotels/update/encoded --Field:HotelName=Luxury Hotel --Field:Review=Foo Bar --Method:Patch}}"
}
```
### Example No.21

Send an HTTP PATCH request to `http://localhost:9002/api/hotels/update/xml`. 
The request body is formatted as XML data, encapsulated in a `HotelReviewRequest` element with child elements specifying details like `HotelName` and `Review`. 
The argument includes runtime parameters for dynamic configuration, specifying the URL for updating, the XML data in the request body, and the HTTP method as PATCH. 
This configuration is particularly useful for scenarios requiring a partial update of resource details using XML payload, as exemplified by the API endpoint for updating hotel information.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> --Url:http://localhost:9002/api/hotels/update/xml --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> --Url:http://localhost:9002/api/hotels/update/xml --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> --Url:http://localhost:9002/api/hotels/update/xml --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> --Url:http://localhost:9002/api/hotels/update/xml --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> --Url:http://localhost:9002/api/hotels/update/xml --Method:Patch}}"
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

Holds the results of the HTTP request after `onElement`, `onAttribute`, and `regularExpression` have been applied. 
If none of these properties are provided, then the entire response body is stored in the `HttpResponse` parameter.  

This means that the `HttpResponse` parameter captures the content resulting from any data extraction or processing performed by the specified properties (`onElement`, `onAttribute`, `regularExpression`). 
It provides a way to access the modified or processed content of the HTTP response within the automation workflow.

### Http Response Headers (HttpResponseHeaders)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP response headers obtained from the HTTP POST request. 
These headers provide additional information about the server's response and are sent along with the actual content of the response.

### Http Status Code (HttpStatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Holds the HTTP status code obtained from the HTTP POST request. 
The HTTP status code is a three-digit numeric code returned by the server indicating the outcome of the request.

## Properties

### Argument (argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Provides a comprehensive and adaptable way to configure an HTTP request. 
It allows for the dynamic inclusion of URLs, request bodies, content types, HTTP methods, headers, and other parameters.

### On Attribute (onAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Used to specify and extract a specific attribute value from an XML element. 
This is particularly relevant when dealing with XML data, where elements can have associated attributes containing additional information.

### On Element (onElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Used to target elements using either XPath or JSONPath expressions, depending on the type of response the API returns (XML or JSON). 
This flexibility allows the rule to handle different response formats appropriately.

### Regular Expression (regularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Used for pattern matching and extraction of specific data from a text response. 
It allows for the definition of a regular expression that captures and extracts relevant information from the content retrieved by the HTTP request.

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

Allows the inclusion of multiple headers in the HTTP POST request. 
Each header is specified as a key-value pair, separated by an equal sign. 
Multiple headers can be added using the syntax `{{$ --Header:header1name=header1value --Header:header2name=header2value ...}}`.

### Method (Method)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | HttpMethod        |

Provides a way to dynamically configure and specify the HTTP method for requests made by the `SendHttpRequest` plugin, offering flexibility and adaptability in interacting with diverse APIs. 
The default behavior assumes a `GET` request if the method is not explicitly provided.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the target URL for the HTTP POST request.
