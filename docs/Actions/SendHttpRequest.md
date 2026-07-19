# Send Http Request (SendHttpRequest)

[Table of Content](../Home.md)  

~942 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Automates sending HTTP requests to web services and REST APIs.
It lets users choose the HTTP method (GET, POST, PUT, DELETE, PATCH, or any other supported method) and set the request URL at run time.
It also lets users customize headers, body content, and query parameters.

### Key Features and Functionality

| Feature                  | Description                                                                                   |
|--------------------------|-----------------------------------------------------------------------------------------------|
| HTTP Method Selection    | Choose methods like GET, POST, PUT, DELETE, PATCH, or any HttpMethod plugin type at run time. |
| URL Configuration        | Set the request URL dynamically during execution.                                             |
| Custom Headers & Payload | Define headers, body content, and query parameters for each request.                          |

### Usages in RPA

| Use Case                | Description                                                 |
|-------------------------|-------------------------------------------------------------|
| Web Service Integration | Let robots connect to external APIs to get or send data.    |
| Workflow Orchestration  | Use API calls alongside other automation steps in one flow. |

### Usages in Automation Testing

| Use Case          | Description                                                         |
|-------------------|---------------------------------------------------------------------|
| API Testing       | Send different requests to check API behavior and validate results. |
| Data Verification | Fetch data from services and compare it with expected values.       |
| Load Testing      | Send many requests at once to see how the system handles traffic.   |

## Examples

### Example No.1

### SendHttpRequest: GET Full Response

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` using the `SendHttpRequest` plugin to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}"
}
```
### Example No.2

### SendHttpRequest: Extract resultCount via Regex

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` and apply the regex `(?<=\"resultCount\":)\d+` to the response body to extract the `resultCount` value.
After execution, the extracted count is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    RegularExpression = "(?<=\"resultCount\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setRegularExpression("(?<=\"resultCount\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    regularExpression: "(?<=\"resultCount\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```
### Example No.3

### SendHttpRequest: Extract First In-Stock XML Element

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` and use the XPath `(//Item[@stockAvailable='true'])[1]` to select the first in-stock `<Item>` element from the XML response.
After execution, that element is available for further attribute or content extraction.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.4

### SendHttpRequest: Extract In-Stock Item Name via Regex

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `(?<=name=")[^"]+` to extract its `name` attribute.
After execution, the extracted name is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "(?<=name=")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("(?<=name=")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "(?<=name=")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```
### Example No.5

### SendHttpRequest: Extract All In-Stock Items via JSONPath

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` and use the JSONPath `$.items[?(@.stockAvailable==true)]` to select all in-stock items from the JSON response.
After execution, the filtered array is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnElement = "$.items[?(@.stockAvailable==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnElement("$.items[?(@.stockAvailable==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onElement: "$.items[?(@.stockAvailable==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```
### Example No.6

### SendHttpRequest: Extract First Item via JSONPath

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` and use the JSONPath `$.items[0]` to select the first item from the JSON response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnElement = "$.items[0]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnElement("$.items[0]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onElement: "$.items[0]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "$.items[0]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onElement": "$.items[0]"
}
```
### Example No.7

### SendHttpRequest: Extract First In-Stock Item Price Attribute

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and extract its `price` attribute.
After execution, the price value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnAttribute = "price",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnAttribute("price")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onAttribute: "price",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.8

### SendHttpRequest: Extract First In-Stock Item ID via Regex

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `\d+` to its `id` attribute to extract digits.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    OnAttribute = "id",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}")
    .setOnAttribute("id")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    onAttribute: "id",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```
### Example No.9

### SendHttpRequest: GET Full Response with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` using the `SendHttpRequest` plugin with the header `Authorization: Basic username:password` to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}"
}
```
### Example No.10

### SendHttpRequest: Extract resultCount via Regex with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password` and apply the regex `(?<=\"resultCount\":)\d+` to the response body to extract the `resultCount` value.
After execution, the extracted count is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    RegularExpression = "(?<=\"resultCount\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setRegularExpression("(?<=\"resultCount\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    regularExpression: "(?<=\"resultCount\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```
### Example No.11

### SendHttpRequest: Extract First In-Stock XML Element with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password` and use the XPath `(//Item[@stockAvailable='true'])[1]` to select the first in-stock `<Item>` element from the XML response.
After execution, that element is available for further attribute or content extraction.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.12

### SendHttpRequest: Extract In-Stock Item Name via Regex with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `(?<=name=")[^"]+` to extract its `name` attribute.
After execution, the extracted name is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "(?<=name=")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("(?<=name=")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "(?<=name=")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```
### Example No.13

### SendHttpRequest: Extract All In-Stock Items via JSONPath with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password` and use the JSONPath `$.items[?(@.stockAvailable==true)]` to select all in-stock items from the JSON response.
After execution, the filtered array is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnElement = "$.items[?(@.stockAvailable==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnElement("$.items[?(@.stockAvailable==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onElement: "$.items[?(@.stockAvailable==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```
### Example No.14

### SendHttpRequest: Extract First Item via JSONPath with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password` and use the JSONPath `$.items[0]` to select the first item from the JSON response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnElement = "$.items[0]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnElement("$.items[0]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onElement: "$.items[0]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "$.items[0]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onElement": "$.items[0]"
}
```
### Example No.15

### SendHttpRequest: Extract First In-Stock Item Price Attribute with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and extract its `price` attribute.
After execution, the price value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnAttribute = "price",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnAttribute("price")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onAttribute: "price",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.16

### SendHttpRequest: Extract First In-Stock Item ID via Regex with Authorization Header

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with the header `Authorization: Basic username:password`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `\d+` to its `id` attribute to extract digits.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    OnAttribute = "id",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}")
    .setOnAttribute("id")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    onAttribute: "id",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Basic username:password --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```
### Example No.17

### SendHttpRequest: GET Full Response with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` using the `SendHttpRequest` plugin with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent` to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}"
}
```
### Example No.18

### SendHttpRequest: Extract resultCount via Regex with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, and apply the regex `(?<=\"resultCount\":)\d+` to the response body to extract the `resultCount` value.
After execution, the extracted count is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    RegularExpression = "(?<=\"resultCount\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setRegularExpression("(?<=\"resultCount\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    regularExpression: "(?<=\"resultCount\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "regularExpression": "(?<=\"resultCount\":)\d+"
}
```
### Example No.19

### SendHttpRequest: Extract First In-Stock XML Element with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, and use the XPath `(//Item[@stockAvailable='true'])[1]` to select the first in-stock `<Item>` element from the XML response.
After execution, that element is available for further attribute or content extraction.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.20

### SendHttpRequest: Extract In-Stock Item Name via Regex with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `(?<=name=")[^"]+` to extract its `name` attribute.
After execution, the extracted name is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "(?<=name=")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("(?<=name=")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "(?<=name=")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "(?<=name=")[^"]+"
}
```
### Example No.21

### SendHttpRequest: Extract All In-Stock Items via JSONPath with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, and use the JSONPath `$.items[?(@.stockAvailable==true)]` to select all in-stock items from the JSON response.
After execution, the filtered array is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnElement = "$.items[?(@.stockAvailable==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnElement("$.items[?(@.stockAvailable==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onElement: "$.items[?(@.stockAvailable==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "$.items[?(@.stockAvailable==true)]"
}
```
### Example No.22

### SendHttpRequest: Extract First Item via JSONPath with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, and use the JSONPath `$.items[0]` to select the first item from the JSON response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnElement = "$.items[0]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnElement("$.items[0]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onElement: "$.items[0]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "$.items[0]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onElement": "$.items[0]"
}
```
### Example No.23

### SendHttpRequest: Extract First In-Stock Item Price Attribute with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and extract its `price` attribute.
After execution, the price value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnAttribute = "price",
    OnElement = "(//Item[@stockAvailable='true'])[1]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnAttribute("price")
    .setOnElement("(//Item[@stockAvailable='true'])[1]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onAttribute: "price",
    onElement: "(//Item[@stockAvailable='true'])[1]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onAttribute": "price",
    "onElement": "(//Item[@stockAvailable='true'])[1]"
}
```
### Example No.24

### SendHttpRequest: Extract First In-Stock Item ID via Regex with Multiple Headers

Send an HTTP GET request to `https://api.example.com/v1/items/search?category=Electronics` with headers `Authorization: Bearer YourAccessToken` and `UserAgent: MyCustomUserAgent`, select the first in-stock `<Item>` element using XPath `(//Item[@stockAvailable='true'])[1]`, and apply the regex `\d+` to its `id` attribute to extract digits.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    OnAttribute = "id",
    OnElement = "(//Item[@stockAvailable='true'])[1]",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}")
    .setOnAttribute("id")
    .setOnElement("(//Item[@stockAvailable='true'])[1]")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    onAttribute: "id",
    onElement: "(//Item[@stockAvailable='true'])[1]",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/search?category=Electronics --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method:Get}}",
    "onAttribute": "id",
    "onElement": "(//Item[@stockAvailable='true'])[1]",
    "regularExpression": "\d+"
}
```
### Example No.25

### SendHttpRequest: POST Full Response with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with the JSON body `{"name":"Premium Widget","price":99.99}` to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}"
}
```
### Example No.26

### SendHttpRequest: Extract message via Regex with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and apply the regex `(?<="message":")[^"]+` to the response body to extract the `message` value.
After execution, the extracted message is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    RegularExpression = "(?<="message":")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setRegularExpression("(?<="message":")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    regularExpression: "(?<="message":")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```
### Example No.27

### SendHttpRequest: Select updatedItem via JSONPath with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.28

### SendHttpRequest: Extract updatedItem ID via Regex with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<="id":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<="id":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<="id":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<="id":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```
### Example No.29

### SendHttpRequest: Extract Status Text via XPath with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and use the XPath `//Status` to select the `<Status>` element text from the XML response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.30

### SendHttpRequest: Extract Status Text via Regex with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}`, select the `<Status>` element using XPath `//Status`, and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.31

### SendHttpRequest: Extract Response status Attribute with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}`, select the `<Response>` element using XPath `//Response`, and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.32

### SendHttpRequest: Extract Response status via Regex with JSON Body

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}`, select the `<Response>` element using XPath `//Response`, and apply the regex `success|failure` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.33

### SendHttpRequest: POST Full Response with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with the JSON body `{"name":"Premium Widget","price":99.99}` and the header `Authorization: Basic username:password` to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}"
}
```
### Example No.34

### SendHttpRequest: Extract message via Regex with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then apply the regex `(?<="message":")[^"]+` to the response body to extract the `message` value.
After execution, the extracted message is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    RegularExpression = "(?<="message":")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setRegularExpression("(?<="message":")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    regularExpression: "(?<="message":")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```
### Example No.35

### SendHttpRequest: Select updatedItem via JSONPath with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.36

### SendHttpRequest: Extract updatedItem ID via Regex with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<="id":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<="id":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<="id":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<="id":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```
### Example No.37

### SendHttpRequest: Extract Status Text via XPath with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then use the XPath `//Status` to select the `<Status>` element text from the XML response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.38

### SendHttpRequest: Extract Status Text via Regex with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.39

### SendHttpRequest: Extract Response status Attribute with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.40

### SendHttpRequest: Extract Response status via Regex with JSON Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|failure` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.41

### SendHttpRequest: POST Full Response with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent` to retrieve the full JSON response.
After execution, the entire JSON payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
}
```
### Example No.42

### SendHttpRequest: Extract message via Regex with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then apply the regex `(?<="message":")[^"]+` to the response body to extract the `message` value.
After execution, the extracted message is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    RegularExpression = "(?<="message":")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setRegularExpression("(?<="message":")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    regularExpression: "(?<="message":")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```
### Example No.43

### SendHttpRequest: Select updatedItem via JSONPath with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.44

### SendHttpRequest: Extract updatedItem ID via Regex with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<="id":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<="id":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<="id":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<="id":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<="id":)\d+"
}
```
### Example No.45

### SendHttpRequest: Extract Status Text via XPath with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the XPath `//Status` to select the `<Status>` element text from the XML response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.46

### SendHttpRequest: Extract Status Text via Regex with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.47

### SendHttpRequest: Extract Response status Attribute with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.48

### SendHttpRequest: Extract Response status via Regex with JSON Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with the JSON body `{"name":"Premium Widget","price":99.99}` and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|failure` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.49

### SendHttpRequest: POST Full Response with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}"
}
```
### Example No.50

### SendHttpRequest: Extract Status Code via Regex with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99`, then apply the regex `(?<=Status: )\d{3}` to extract a three-digit status code from the response.
After execution, the extracted code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.51

### SendHttpRequest: Select updatedItem via JSONPath with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.52

### SendHttpRequest: Extract updatedItem ID via Regex with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<=\"id\":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.53

### SendHttpRequest: Extract Status Text via XPath with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.54

### SendHttpRequest: Extract Status Text via Regex with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, select the `<Status>` element using XPath `//Status`, and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.55

### SendHttpRequest: Extract Response status Attribute with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.56

### SendHttpRequest: Extract Response status via Regex with Text/Plain Body

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain` and the body `Name=PremiumWidget;Price=99.99;Stock=150`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.57

### SendHttpRequest: POST Full Response with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and the header `Authorization: Basic username:password` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}"
}
```
### Example No.58

### SendHttpRequest: Extract Status Code via Regex with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and the header `Authorization: Basic username:password`, then apply the regex `(?<=Status: )\d{3}` to extract a three-digit status code from the response.
After execution, the extracted code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.59

### SendHttpRequest: Select updatedItem via JSONPath with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.60

### SendHttpRequest: Extract updatedItem ID via Regex with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<=\"id\":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.61

### SendHttpRequest: Extract Status Text via XPath with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.62

### SendHttpRequest: Extract Status Text via Regex with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.63

### SendHttpRequest: Extract Response status Attribute with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.64

### SendHttpRequest: Extract Response status via Regex with Text/Plain Body and Header

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and the header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.65

### SendHttpRequest: POST Full Response with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}"
}
```
### Example No.66

### SendHttpRequest: Extract Status Code via Regex with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then apply the regex `(?<=Status: )\d{3}` to extract a three-digit status code from the response.
After execution, the extracted code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.67

### SendHttpRequest: Select updatedItem via JSONPath with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.68

### SendHttpRequest: Extract updatedItem ID via Regex with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<=\"id\":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.69

### SendHttpRequest: Extract Status Text via XPath with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.70

### SendHttpRequest: Extract Status Text via Regex with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.71

### SendHttpRequest: Extract Response status Attribute with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.72

### SendHttpRequest: Extract Response status via Regex with Text/Plain Body and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.73

### SendHttpRequest: POST Full Response with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and encoding `ASCII` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}"
}
```
### Example No.74

### SendHttpRequest: Extract Status Code via Regex with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, and encoding `ASCII`, then apply the regex `(?<=Status: )\d{3}` to extract the status code from the response.
After execution, the extracted code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.75

### SendHttpRequest: Select updatedItem via JSONPath with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.76

### SendHttpRequest: Extract updatedItem ID via Regex with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<=\"id\":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.77

### SendHttpRequest: Extract Status Text via XPath with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.78

### SendHttpRequest: Extract Status Text via Regex with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.79

### SendHttpRequest: Extract Response status Attribute with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.80

### SendHttpRequest: Extract Response status via Regex with Text/Plain Body and ASCII Encoding

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, and encoding `ASCII`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.81

### SendHttpRequest: POST Full Response with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```
### Example No.82

### SendHttpRequest: Extract Status Code via Regex with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then apply the regex `(?<=Status: )\d{3}` to extract the status code from the response.
After execution, the extracted code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.83

### SendHttpRequest: Select updatedItem via JSONPath with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the JSONPath `$.updatedItem` to select the `updatedItem` object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.84

### SendHttpRequest: Extract updatedItem ID via Regex with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, select the `updatedItem` object using JSONPath `$.updatedItem`, and apply the regex `(?<=\"id\":)\d+` to extract its `id` value.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.85

### SendHttpRequest: Extract Status Text via XPath with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.86

### SendHttpRequest: Extract Status Text via Regex with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.87

### SendHttpRequest: Extract Response status Attribute with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.88

### SendHttpRequest: Extract Response status via Regex with Text/Plain Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.89

### SendHttpRequest: POST Plain-Text Body with ASCII Encoding and Basic Auth

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, encoding `ASCII`, and the header `Authorization: Basic username:password` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}"
}
```
### Example No.90

### SendHttpRequest: Extract Status Code via Regex from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then apply the regex `(?<=Status: )\d{3}` to extract the three-digit status code from the response.
After execution, the extracted status code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.91

### SendHttpRequest: Select updatedItem via JSONPath from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then use the JSONPath `$.updatedItem` to select the updated item object from the JSON response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.92

### SendHttpRequest: Extract updatedItem ID via Regex from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then select the updated item via JSONPath `$.updatedItem` and apply the regex `(?<=\"id\":)\d+` to extract its numeric ID.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.93

### SendHttpRequest: Extract <Status> Text via XPath from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then use the XPath `//Status` to select the `<Status>` element text from the XML response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.94

### SendHttpRequest: Extract <Status> Text via Regex from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.95

### SendHttpRequest: Extract Response status Attribute from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.96

### SendHttpRequest: Extract and Validate Response status via Regex from Plain-Text ASCII Response

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/plain`, the body `Name=PremiumWidget;Price=99.99;Stock=150`, encoding `ASCII`, and the header `Authorization: Basic username:password`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute for validation.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.97

### SendHttpRequest: POST Form-URLencoded Fields with ASCII Encoding and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget` and `Price=99.99`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```
### Example No.98

### SendHttpRequest: Extract Status Code via Regex with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget` and `Price=99.99`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then apply the regex `(?<=Status: )\d{3}` to extract the three-digit status code from the response.
After execution, the extracted status code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.99

### SendHttpRequest: Select updatedItem via JSONPath with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the JSONPath `$.updatedItem` to select the updated item object from the response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.100

### SendHttpRequest: Extract updatedItem ID via Regex with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the updated item via JSONPath `$.updatedItem` and apply the regex `(?<=\"id\":)\d+` to extract its numeric ID.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.101

### SendHttpRequest: Extract <Status> Text via XPath with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.102

### SendHttpRequest: Extract <Status> Text via Regex with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.103

### SendHttpRequest: Extract Response status Attribute via XPath with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.104

### SendHttpRequest: Extract and Validate Response status via Regex with Form-URLencoded Fields, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `x-www-form-urlencoded`, fields `Name=PremiumWidget`, `Price=99.99`, and `Stock=150`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute for validation.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Field:Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.105

### SendHttpRequest: POST XML Body with ASCII Encoding and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` using the `SendHttpRequest` plugin with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}"
}
```
### Example No.106

### SendHttpRequest: Extract Status Code via Regex with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then apply the regex `(?<=Status: )\d{3}` to extract the three-digit status code from the response.
After execution, the extracted status code is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.107

### SendHttpRequest: Select updatedItem via JSONPath with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the JSONPath `$.updatedItem` to select the updated item object from the JSON response.
After execution, that object is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem"
}
```
### Example No.108

### SendHttpRequest: Extract updatedItem ID via Regex with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the updated item via JSONPath `$.updatedItem` and apply the regex `(?<=\"id\":)\d+` to extract its numeric ID.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.109

### SendHttpRequest: Extract <Status> Text via XPath with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then use the XPath `//Status` to select the `<Status>` element text from the response.
After execution, that text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status"
}
```
### Example No.110

### SendHttpRequest: Extract <Status> Text via Regex with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Status>` element using XPath `//Status` and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.111

### SendHttpRequest: Extract Response status Attribute via XPath with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.112

### SendHttpRequest: Extract and Validate Response status via Regex with XML Body, ASCII Encoding, and Multiple Headers

Send an HTTP POST request to `https://api.example.com/v1/items` with content type `text/xml`, the body `<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, encoding `ASCII`, and headers `Authorization: Basic username:password` and `UserAgent: MyCustomUserAgent`, then select the `<Response>` element using XPath `//Response` and apply the regex `success|error` to its `status` attribute for validation.
After execution, the extracted status is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Post}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.113

### SendHttpRequest: DELETE Full Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with no additional parameters to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}"
}
```
### Example No.114

### SendHttpRequest: Extract message via Regex from DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, then apply the regex `(?<=\"message\":\")[^\"]+` to extract the `message` field from the JSON response.
After execution, the extracted message is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    RegularExpression = "(?<="message":")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setRegularExpression("(?<="message":")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    regularExpression: "(?<="message":")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```
### Example No.115

### SendHttpRequest: Select <Status> Element via XPath from DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, then use the XPath `//Status` to select the `<Status>` element from the XML response.
After execution, that element is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "//Status"
}
```
### Example No.116

### SendHttpRequest: Extract <Status> Text via Regex from DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, select the `<Status>` element via XPath `//Status`, and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.117

### SendHttpRequest: Select deleted Results via JSONPath from DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, then use the JSONPath `$.results[?(@.deleted==true)]` to select all items marked as deleted in the JSON response.
After execution, the filtered array is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnElement = "$.results[?(@.deleted==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnElement("$.results[?(@.deleted==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onElement: "$.results[?(@.deleted==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```
### Example No.118

### SendHttpRequest: Extract First Result ID via Regex from DELETE Response JSONPath

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, select the first element via JSONPath `$.results[0]`, and apply the regex `(?<=\"id\":)\d+` to extract its `id`.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnElement = "$.results[0]",
    RegularExpression = "(?<="id":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnElement("$.results[0]")
    .setRegularExpression("(?<="id":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onElement: "$.results[0]",
    regularExpression: "(?<="id":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<="id":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<="id":)\d+"
}
```
### Example No.119

### SendHttpRequest: Extract status Attribute from <Item> via XPath in DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, then use the XPath `//Item` to select the first `<Item>` element and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnAttribute = "status",
    OnElement = "//Item"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnAttribute("status")
    .setOnElement("//Item");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onAttribute: "status",
    onElement: "//Item"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```
### Example No.120

### SendHttpRequest: Extract <Item> ID via Regex from Attribute in DELETE Response

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin, then use the XPath `//Item` to select the first `<Item>` element and apply the regex `\d+` to its `id` attribute to extract digits.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    OnAttribute = "id",
    OnElement = "//Item",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}")
    .setOnAttribute("id")
    .setOnElement("//Item")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    onAttribute: "id",
    onElement: "//Item",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Method:Delete}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```
### Example No.121

### SendHttpRequest: DELETE Full Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password` to retrieve the full response.
After execution, the raw response payload is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}"
}
```
### Example No.122

### SendHttpRequest: Extract message via Regex from DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, then apply the regex `(?<=\"message\":\")[^\"]+` to extract the `message` field from the JSON response.
After execution, the extracted message is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    RegularExpression = "(?<="message":")[^"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setRegularExpression("(?<="message":")[^"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    regularExpression: "(?<="message":")[^"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "regularExpression": "(?<="message":")[^"]+"
}
```
### Example No.123

### SendHttpRequest: Select <Status> Element via XPath from DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, then use the XPath `//Status` to select the `<Status>` element from the response.
After execution, that element is available for subsequent extraction or validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "//Status"
}
```
### Example No.124

### SendHttpRequest: Extract <Status> Text via Regex from DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, select the `<Status>` element via XPath `//Status`, and apply the regex `(?<=<Status>).*?(?=</Status>)` to extract its text.
After execution, the extracted text is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.125

### SendHttpRequest: Select deleted Results via JSONPath from DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, then use the JSONPath `$.results[?(@.deleted==true)]` to select all items marked as deleted in the JSON response.
After execution, the filtered array is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnElement = "$.results[?(@.deleted==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnElement("$.results[?(@.deleted==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onElement: "$.results[?(@.deleted==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```
### Example No.126

### SendHttpRequest: Extract First Result ID via Regex from JSONPath in DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, select the first element via JSONPath `$.results[0]`, and apply the regex `(?<=\"id\":)\d+` to extract its `id`.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnElement = "$.results[0]",
    RegularExpression = "(?<="id":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnElement("$.results[0]")
    .setRegularExpression("(?<="id":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onElement: "$.results[0]",
    regularExpression: "(?<="id":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<="id":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<="id":)\d+"
}
```
### Example No.127

### SendHttpRequest: Extract status Attribute from <Item> via XPath in DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, then use the XPath `//Item` to select the first `<Item>` element and extract its `status` attribute.
After execution, the attribute value is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnAttribute = "status",
    OnElement = "//Item"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnAttribute("status")
    .setOnElement("//Item");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onAttribute: "status",
    onElement: "//Item"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```
### Example No.128

### SendHttpRequest: Extract <Item> ID via Regex from Attribute in DELETE Response with Authorization Header

Send an HTTP DELETE request to `https://api.example.com/v1/items/567` using the `SendHttpRequest` plugin with header `Authorization: Basic username:password`, then use the XPath `//Item` to select the first `<Item>` element and apply the regex `\d+` to its `id` attribute to extract digits.
After execution, the extracted ID is available for subsequent actions.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    OnAttribute = "id",
    OnElement = "//Item",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}")
    .setOnAttribute("id")
    .setOnElement("//Item")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    onAttribute: "id",
    onElement: "//Item",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Basic username:password --Method:Delete}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```
### Example No.129

### Delete Full Response

This example returns the complete response body of an HTTP DELETE request to `https://api.example.com/v1/items/567` by specifying `onElement: responseBody` and using `--Method=DELETE` with the URL and headers.
No extraction options are applied so downstream steps can process the raw response data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "responseBody"
}
```
### Example No.130

### Extract Message Field

This example extracts the `message` field value by applying the regular expression `(?<=\"message\":\")[^\"]+` to the full response body with `onElement: responseBody`.
Conversion to string ensures reliable pattern matching.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "responseBody",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.131

### Extract Status Element Text

This example retrieves the text content of the `<Status>` element from an XML response using XPath locator `//Status`.
Extracted text enables validation or processing of status values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "//Status"
}
```
### Example No.132

### Extract Status Element Content with Regex

This example retrieves the inner text of the `<Status>` element from an XML response using XPath locator `//Status` and applies the regular expression `(?<=<Status>).*?(?=</Status>)` to capture its content without surrounding tags.
Regex improves performance by focusing on core content and conversion to string ensures reliable pattern matching.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.133

### Select Deleted Items with JSONPath

This example selects all objects in the `results` array with `deleted` equal to true from a JSON response using JSONPath locator `$.results[?(@.deleted==true)]`.
This enables direct retrieval of relevant items for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "$.results[?(@.deleted==true)]"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("$.results[?(@.deleted==true)]");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "$.results[?(@.deleted==true)]"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "$.results[?(@.deleted==true)]"
}
```
### Example No.134

### Extract ID from First Result with Regex

This example selects the first object in the `results` array using JSONPath locator `$.results[0]` and applies the regular expression `(?<=\"id\":)\d+` to its JSON string to extract the `id` value.
Conversion to string ensures reliable pattern matching.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnElement = "$.results[0]",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnElement("$.results[0]")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onElement: "$.results[0]",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onElement": "$.results[0]",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.135

### Extract Status Attribute from Item Element

This example retrieves the value of the `status` attribute from each `<Item>` element in an XML response using XPath locator `//Item` with `onAttribute: status`.
Extracted attribute values can drive validation or conditional logic.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnAttribute = "status",
    OnElement = "//Item"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnAttribute("status")
    .setOnElement("//Item");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onAttribute: "status",
    onElement: "//Item"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onAttribute": "status",
    "onElement": "//Item"
}
```
### Example No.136

### Extract Item ID Attribute with Regex

This example retrieves the `id` attribute text from each `<Item>` element in an XML response using XPath locator `//Item` with `onAttribute: id` and applies the regular expression `\d+` to capture numeric characters.
Conversion to string ensures reliable pattern matching.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    OnAttribute = "id",
    OnElement = "//Item",
    RegularExpression = "\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}")
    .setOnAttribute("id")
    .setOnElement("//Item")
    .setRegularExpression("\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    onAttribute: "id",
    onElement: "//Item",
    regularExpression: "\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Header:Authorization=Bearer YourAccessToken --Header:UserAgent=MyCustomUserAgent --Method=DELETE}}",
    "onAttribute": "id",
    "onElement": "//Item",
    "regularExpression": "\d+"
}
```
### Example No.137

### Update Item Full Response

This example returns the complete response body of an HTTP PUT request to `https://api.example.com/v1/items/567` using `--Method=PUT` and `--Body:{"name":"Premium Widget","price":99.99}` with `onElement: responseBody`, allowing downstream steps to process raw data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "responseBody"
}
```
### Example No.138

### Extract Message via Regex

This example applies the regular expression `(?<=\"message\":\")[^\"]+` to the full response body using `onElement: responseBody` to extract the `message` field reliably without parsing the entire JSON.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "responseBody",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.139

### Select Updated Item via JSONPath

This example locates the `updatedItem` object in the JSON response using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem`, enabling direct access to the updated data for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```
### Example No.140

### Extract Updated Item ID via Regex

This example selects `updatedItem` using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem` and applies the regular expression `(?<=\"id\":)\d+` to its JSON string to extract the `id` value for validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.141

### Extract Status Element Text via XPath

This example retrieves the text content of the `<Status>` element from an XML response using XPath locator `//Status` with `onElement: //Status`, enabling evaluation of status values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "//Status"
}
```
### Example No.142

### Extract Status Content via Regex

This example selects the `<Status>` element using XPath locator `//Status` with `onElement: //Status` and applies the regular expression `(?<=<Status>).*?(?=</Status>)` to capture its inner content without tags for performance.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.143

### Extract Response Status Attribute via XPath

This example retrieves the `status` attribute from each `<Response>` element in an XML response using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, enabling conditional logic based on attribute values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.144

### Extract Response Status via Regex

This example locates the `status` attribute on `<Response>` elements using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, then applies the regular expression `success|failure` to validate outcome values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.145

### Update Item Full Response

This example returns the complete response body of an HTTP PUT request to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--Body:{"name":"Premium Widget","price":99.99}`, and `--Header:Authorization=Basic username:password` with `onElement: responseBody`, allowing downstream steps to process raw data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody"
}
```
### Example No.146

### Extract Message via Regex

This example applies the regular expression `(?<=\"message\":\")[^\"]+` to the full response body using `onElement: responseBody` to extract the `message` field reliably without parsing the entire JSON.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "responseBody",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.147

### Select Updated Item via JSONPath

This example locates the `updatedItem` object in the JSON response using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem`, enabling direct access to the updated data for further processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```
### Example No.148

### Extract Updated Item ID via Regex

This example selects `updatedItem` using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem` and applies the regular expression `(?<=\"id\":)\d+` to its JSON string to extract the `id` value for validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.149

### Extract Status Element Text via XPath

This example retrieves the text content of the `<Status>` element from an XML response using XPath locator `//Status` with `onElement: //Status`, enabling evaluation of status values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status"
}
```
### Example No.150

### Extract Status Content via Regex

This example selects the `<Status>` element using XPath locator `//Status` with `onElement: //Status` and applies the regular expression `(?<=<Status>).*?(?=</Status>)` to capture its inner content without tags for performance.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.151

### Extract Response Status Attribute via XPath

This example retrieves the `status` attribute from each `<Response>` element in an XML response using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, enabling conditional logic based on attribute values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.152

### Extract Response Status via Regex

This example locates the `status` attribute on `<Response>` elements using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, then applies the regular expression `success|failure` to validate outcome values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.153

### Update Item Full Response

This example returns the complete response body of an HTTP PUT request to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--Body:{"name":"Premium Widget","price":99.99}`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, with `onElement: responseBody` so downstream steps can process the raw data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody"
}
```
### Example No.154

### Extract Message via Regex

This example applies the regular expression `(?<=\"message\":\")[^\"]+` to the full response body with `onElement: responseBody` to extract the `message` field reliably.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "responseBody",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.155

### Select Updated Item via JSONPath

This example locates the `updatedItem` object in the JSON response using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem` to enable direct access to the updated data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```
### Example No.156

### Extract Updated Item ID via Regex

This example locates the `updatedItem` object using JSONPath locator `$.updatedItem` with `onElement: $.updatedItem` and applies the regular expression `(?<=\"id\":)\d+` to extract the numeric `id` value.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.157

### Extract Status Element Text via XPath

This example retrieves the text content of the `<Status>` element from an XML response using XPath locator `//Status` with `onElement: //Status` to evaluate status values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status"
}
```
### Example No.158

### Extract Status Content via Regex

This example locates the `<Status>` element using XPath locator `//Status` with `onElement: //Status` and applies the regular expression `(?<=<Status>).*?(?=</Status>)` to capture inner content without tags for performance.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.159

### Extract Response Status Attribute via XPath

This example retrieves the `status` attribute from each `<Response>` element in an XML response using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status` for conditional logic.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.160

### Extract Response Status via Regex

This example locates the `status` attribute on `<Response>` elements using XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, then applies the regular expression `success|failure` to validate outcome values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.161

### Update Item with Plain-Text Payload

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then returns the complete response body with `onElement: responseBody` for downstream processing to ensure raw text parsing works even when the service returns non-JSON data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody"
}
```
### Example No.162

### Extract Status Code via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then applies the regular expression `(?<=Status: )\d{3}` to the full response body with `onElement: responseBody` to extract the numeric status code, using regex to avoid full payload parsing and focus only on the status line.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "responseBody",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.163

### Select Updated Item via JSONPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then locates the `updatedItem` object via JSONPath locator `$.updatedItem` with `onElement: $.updatedItem`, using JSONPath to directly target the relevant node without manual string manipulation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```
### Example No.164

### Extract Updated Item ID via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then applies the regular expression `(?<=\"id\":)\d+` to the `updatedItem` object via `onElement: $.updatedItem` to extract its numeric `id` value, avoiding full JSON parsing and focusing on the identifier.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.165

### Extract Status Element Text via XPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then retrieves the text content of the `<Status>` element via XPath locator `//Status` with `onElement: //Status`, using XPath to directly target the relevant element for validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status"
}
```
### Example No.166

### Extract Status Content via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then applies the regular expression `(?<=<Status>).*?(?=</Status>)` to the `<Status>` element via `onElement: //Status` to capture its inner content without tags, avoiding capturing surrounding tags and improving performance by focusing on core content.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.167

### Extract Response Status Attribute via XPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then retrieves the `status` attribute from the `<Response>` element via XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, using XPath to extract the attribute directly for conditional logic.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.168

### Extract Response Status via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization=Basic username:password`, and `--Header:UserAgent=MyCustomUserAgent`, then applies the regular expression `success|error` to the `status` attribute of the `<Response>` element via `onElement: //Response` and `onAttribute: status` to validate outcome values without manual parsing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.169

### Update Item with Plain-Text Payload

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, and `--Header:Authorization=Basic username:password`, then returns the complete response body with `onElement: responseBody` for downstream processing to ensure raw text parsing works even when the service returns non-JSON data.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "responseBody"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("responseBody");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "responseBody"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody"
}
```
### Example No.170

### Extract Status Code via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, and `--Header:Authorization=Basic username:password`, then applies the regular expression `(?<=Status: )\d{3}` to the full response body with `onElement: responseBody` to extract the numeric status code, using regex to avoid full payload parsing and focus only on the status line.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "responseBody",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("responseBody")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "responseBody",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "responseBody",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.171

### Select Updated Item via JSONPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then locates the `updatedItem` object via JSONPath locator `$.updatedItem` with `onElement: $.updatedItem`, using JSONPath to directly target the relevant node without manual string manipulation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem"
}
```
### Example No.172

### Extract Updated Item ID via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then applies the regular expression `(?<=\"id\":)\d+` to the `updatedItem` object via `onElement: $.updatedItem` to extract its numeric `id` value, avoiding full JSON parsing and focusing on the identifier.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.173

### Extract Status Element Text via XPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then retrieves the text content of the `<Status>` element via XPath locator `//Status` with `onElement: //Status`, using XPath to directly target the relevant element for validation.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status"
}
```
### Example No.174

### Extract Status Content via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then applies the regular expression `(?<=<Status>).*?(?=</Status>)` to the `<Status>` element via `onElement: //Status` to capture its inner content without tags, avoiding capturing surrounding tags and improving performance by focusing on core content.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.175

### Extract Response Status Attribute via XPath

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then retrieves the `status` attribute from the `<Response>` element via XPath locator `//Response` with `onElement: //Response` and `onAttribute: status`, using XPath to extract the attribute directly for conditional logic.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.176

### Extract Response Status via Regex

This example sends an HTTP PUT to `https://api.example.com/v1/items/567` using `--Method=PUT`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Authorization=Basic username:password`, then applies the regular expression `success|error` to the `status` attribute of the `<Response>` element via `onElement: //Response` and `onAttribute: status` to validate outcome values without manual parsing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Method=PUT}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.177

### Update Item – Full Response Retrieval

Update an item by sending an HTTP PUT request with a plain-text body and capture the full response body.
It configures the request using `--Method:Put`, `--ContentType:text/plain`, and custom headers, then returns the raw response body unchanged.
Values are converted to strings to ensure consistent processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}"
}
```
### Example No.178

### Extract Status Code with Regex

Update an item by sending an HTTP PUT request with a plain-text body and extract the three-digit status code from the response body.
It applies a regular expression `(?<=Status: )\d{3}` to the response body to capture the status code.
Values are converted to strings so downstream steps handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.179

### Extract updatedItem via JSONPath

Update an item by sending an HTTP PUT request with a plain-text body and extract the value of `updatedItem` from the JSON response.
It uses a JSONPath expression `$.updatedItem` to select the updatedItem node.
Values are converted to strings for reliable processing across different data types.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.180

### Extract id with Regex from JSONPath

Update an item by sending an HTTP PUT request with a plain-text body and extract the numeric `id` value from the `updatedItem` node in the JSON response.
It uses a JSONPath expression `$.updatedItem` to select the node and applies a regular expression `(?<=\"id\":)\d+` to extract the numeric ID.
Values are converted to strings so that logging and validation remain consistent.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.181

### Extract Status Element via XPath

Update an item by sending an HTTP PUT request with a plain-text body and extract the text content of the `Status` element from the XML response.
It applies an XPath expression `//Status` to select the element.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.182

### Extract Status Text with Regex via XPath

Update an item by sending an HTTP PUT request with a plain-text body and validate the content of the `Status` element from the XML response using a regular expression.
It applies an XPath expression `//Status` to select the element and then applies a regular expression `(?<=<Status>)(success|error)(?=</Status>)` to extract only `success` or `error`.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>)(success|error)(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```
### Example No.183

### Extract Status Attribute via XPath

Update an item by sending an HTTP PUT request with a plain-text body and extract the `status` attribute value of the `Response` element from the XML response.
It applies an XPath expression `//Response` to select the element and retrieves the `status` attribute value.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.184

### Extract Status Attribute with Regex via XPath

Update an item by sending an HTTP PUT request with a plain-text body and validate the `status` attribute value of the `Response` element from the XML response using a regular expression.
It applies an XPath expression `//Response` to select the element and retrieves the `status` attribute value, then applies a regular expression `success|error` to validate and extract the status.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.185

### Update Item – Full Response Retrieval with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and capture the full response body.
It configures the request using `--Method:Put`, `--ContentType:text/plain`, and `--Encoding:ASCII`, then returns the raw response body unchanged.
Values are converted to strings to ensure consistent processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}"
}
```
### Example No.186

### Extract Status Code with Regex and ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and extract the three-digit status code from the response body.
It applies a regular expression `(?<=Status: )\d{3}` to the response body to capture the status code.
Values are converted to strings so downstream steps handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.187

### Extract updatedItem via JSONPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and extract the value of `updatedItem` from the JSON response.
It uses a JSONPath expression `$.updatedItem` to select the updatedItem node.
Values are converted to strings for reliable processing across data types.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.188

### Extract id with Regex from JSONPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and extract the numeric `id` value from the `updatedItem` node in the JSON response.
It uses a JSONPath expression `$.updatedItem` to select the node and applies a regular expression `(?<=\"id\":)\d+` to extract the numeric ID.
Values are converted to strings so logging and validation remain consistent.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.189

### Extract Status Element via XPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and extract the text content of the `Status` element from the XML response.
It applies an XPath expression `//Status` to select the element.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.190

### Extract Status Text with Regex via XPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and validate the content of the `Status` element from the XML response using a regular expression.
It applies an XPath expression `//Status` to select the element and then applies a regular expression `(?<=<Status>)(success|error)(?=</Status>)` to extract only `success` or `error`.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>)(success|error)(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```
### Example No.191

### Extract Status Attribute via XPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and extract the `status` attribute value of the `Response` element from the XML response.
It applies an XPath expression `//Response` to select the element and retrieves the `status` attribute value.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.192

### Extract Status Attribute with Regex via XPath with ASCII Encoding

Update an item by sending an HTTP PUT request with an ASCII-encoded, plain-text body and validate the `status` attribute value of the `Response` element from the XML response using a regular expression.
It applies an XPath expression `//Response` to select the element and retrieves the `status` attribute value, then applies a regular expression `success|error` to validate and extract the status.
It converts values to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.193

### Update Item – Plain-Text PUT with ASCII Encoding

Update an item's name and price by sending an HTTP PUT request with an ASCII-encoded, plain-text body.
It uses `--Method:Put`, `--ContentType:text/plain`, `--Encoding:ASCII`, and authorization headers, then returns the full response body unchanged.
A regular expression is not applied in this example; all values are simply converted to strings for consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}"
}
```
### Example No.194

### Extract Status Code with Regex and ASCII Encoding

Extract the three-digit HTTP status code from a plain-text response line after sending an ASCII-encoded PUT request.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.195

### Extract updatedItem via JSONPath with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an ASCII-encoded PUT request.
It uses a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings so downstream processes handle JSON data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.196

### Extract id with Regex from JSONPath with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an ASCII-encoded PUT request.
It uses a JSONPath expression `$.updatedItem` and applies a regular expression `(?<=\"id\":)\d+` to capture the ID.
A regular expression `(?<=\"id\":)\d+` is applied to the JSON text; the assertion passes only if the extracted string matches this numeric pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.197

### Extract Status Element via XPath with ASCII Encoding

Select the `<Status>` element from an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Status` and retrieves the element's text content.
Values are converted to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.198

### Extract Status Text with Regex via XPath with ASCII Encoding

Extract the inner text of the `<Status>` element in an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>)(success|error)(?=</Status>)` to capture the content.
A regular expression `(?<=<Status>)(success|error)(?=</Status>)` is applied to the element's visible text; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>)(success|error)(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```
### Example No.199

### Extract status Attribute via XPath with ASCII Encoding

Retrieve the `status` attribute from the `<Response>` element in an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Response` and reads the `status` attribute value.
Values are converted to strings so downstream processes handle data uniformly.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.200

### Validate status Attribute with Regex via XPath with ASCII Encoding

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Response` and then a regular expression `success|error` to assert the attribute value.
A regular expression `success|error` is applied to the attribute; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization=Basic username:password --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.201

### Update Item – Plain-Text PUT with ASCII Encoding and Custom Headers

Update an item's name and price by sending an HTTP PUT request with an ASCII-encoded, plain-text body and custom authorization and user-agent headers.
It uses `--Method:Put`, `--ContentType:text/plain`, `--Encoding:ASCII`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```
### Example No.202

### Extract Status Code with Regex and ASCII Encoding

Extract the three-digit HTTP status code from a plain-text response line after sending an ASCII-encoded PUT request.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.203

### Extract updatedItem via JSONPath with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an ASCII-encoded PUT request.
It uses a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.204

### Extract id with Regex from JSONPath with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an ASCII-encoded PUT request.
It uses a JSONPath expression `$.updatedItem` and applies a regular expression `(?<=\"id\":)\d+` to capture the ID.
A regular expression `(?<=\"id\":)\d+` is applied to the JSON text; the assertion passes only if the extracted string matches this numeric pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.205

### Extract Status Element via XPath with ASCII Encoding

Select the `<Status>` element from an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Status` and retrieves the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.206

### Extract Status Text with Regex via XPath with ASCII Encoding

Extract the inner text of the `<Status>` element in an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>)(success|error)(?=</Status>)` to capture the content.
A regular expression `(?<=<Status>)(success|error)(?=</Status>)` is applied to the element's visible text; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>)(success|error)(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```
### Example No.207

### Extract status Attribute via XPath with ASCII Encoding

Retrieve the `status` attribute from the `<Response>` element in an XML response after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Response` and reads the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.208

### Validate status Attribute with Regex via XPath with ASCII Encoding

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an ASCII-encoded PUT request.
It applies an XPath expression `//Response` and then a regular expression `success|error` to assert the attribute value.
A regular expression `success|error` is applied to the attribute; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.209

### Update Item – Form-Encoded PUT with ASCII Encoding and Custom Headers

Update an item's name and price by sending an HTTP PUT request with an ASCII-encoded, x-www-form-urlencoded body and custom authorization and user-agent headers.
It uses `--Method:Put`, `--ContentType:x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Encoding:ASCII`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```
### Example No.210

### Extract Status Code with Regex and ASCII Encoding for Form-Encoded Request

Extract the three-digit HTTP status code from a plain-text response line after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.211

### Extract updatedItem via JSONPath with Form-Encoded PUT and ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It uses a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.212

### Extract id with Regex from JSONPath with Form-Encoded PUT and ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It uses a JSONPath expression `$.updatedItem` and applies a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.213

### Extract Status Element via XPath with Form-Encoded PUT and ASCII Encoding

Select the `<Status>` element from an XML response after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It applies an XPath expression `//Status` to retrieve the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.214

### Extract Status Text with Regex via XPath with Form-Encoded PUT and ASCII Encoding

Extract the inner text of the `<Status>` element in an XML response after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It applies an XPath expression `//Status` and then applies a regular expression `(?<=<Status>)(success|error)(?=</Status>)` to capture the content.
A regular expression `(?<=<Status>)(success|error)(?=</Status>)` is applied to the element's visible text; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>)(success|error)(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>)(success|error)(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>)(success|error)(?=</Status>)"
}
```
### Example No.215

### Extract status Attribute via XPath with Form-Encoded PUT and ASCII Encoding

Retrieve the `status` attribute from the `<Response>` element in an XML response after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It applies an XPath expression `//Response` and reads the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.216

### Validate status Attribute with Regex via XPath with Form-Encoded PUT and ASCII Encoding

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an ASCII-encoded, x-www-form-urlencoded PUT request.
It applies an XPath expression `//Response` and then applies a regular expression `success|error` to assert the attribute value.
A regular expression `success|error` is applied to the attribute; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.217

### Update Item – XML Body PUT with ASCII Encoding and Custom Headers

Update an item's name and price by sending an HTTP PUT request with an ASCII-encoded XML body and custom authorization and user-agent headers.
It uses `--Method:Put`, `--ContentType:text/xml`, `--Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, `--Encoding:ASCII`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}"
}
```
### Example No.218

### Extract Status Code with Regex and ASCII Encoding for XML Request

Extract the three-digit HTTP status code from a plain-text response line after sending an ASCII-encoded PUT request with an XML body.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.219

### Extract updatedItem via JSONPath with XML Request and ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an ASCII-encoded PUT request with an XML body.
It uses a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem"
}
```
### Example No.220

### Extract id with Regex from JSONPath with XML Request and ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an ASCII-encoded PUT request with an XML body.
It uses a JSONPath expression `$.updatedItem` and applies a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.221

### Extract Status Element via XPath with XML Body PUT and ASCII Encoding

Select the `<Status>` element from an XML response after sending an ASCII-encoded PUT request with an XML body.
It applies an XPath expression `//Status` to retrieve the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status"
}
```
### Example No.222

### Extract Status Text with Regex via XPath with XML Body PUT and ASCII Encoding

Extract the inner text of the `<Status>` element in an XML response after sending an ASCII-encoded PUT request with an XML body.
It applies an XPath expression `//Status` and then applies a regular expression `(?<=<Status>).*?(?=</Status>)` to capture the content.
A regular expression `(?<=<Status>).*?(?=</Status>)` is applied to the element's visible text; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.223

### Extract status Attribute via XPath with XML Body PUT and ASCII Encoding

Retrieve the `status` attribute from the `<Response>` element in an XML response after sending an ASCII-encoded PUT request with an XML body.
It applies an XPath expression `//Response` and reads the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.224

### Validate status Attribute with Regex via XPath with XML Body PUT and ASCII Encoding

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an ASCII-encoded PUT request with an XML body.
It applies an XPath expression `//Response` and then applies a regular expression `success|error` to assert the attribute value.
A regular expression `success|error` is applied to the attribute; the assertion passes only if it matches one of the allowed values.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization=Basic username:password --Header:UserAgent=MyCustomUserAgent --Encoding:ASCII --Method:Put}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.225

### Update Item – JSON Body PATCH

Update an item's name and price by sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, and `--Body:{"name":"Premium Widget","price":99.99}`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}"
}
```
### Example No.226

### Extract Message with Regex

Extract the `message` field from a JSON response after sending an HTTP PATCH request with a JSON body.
A regular expression `(?<=\"message\":\")[^\"]+` is applied to the response body; the assertion passes only if the extracted string matches this pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.227

### Extract updatedItem via JSONPath

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a JSON body.
It uses a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.228

### Extract id with Regex from JSONPath

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a JSON body.
It uses a JSONPath expression `$.updatedItem` and applies a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.229

### Extract `<Status>` Element Text via XPath from XML Response after JSON-Body PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, and `--Body:{"name":"Premium Widget","price":99.99}`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.230

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after JSON-Body PATCH

Extract the inner text of the `<Status>` element in an XML response after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Status` and then applies a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.231

### Extract `status` Attribute via XPath from XML Response after JSON-Body PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, and `--Body:{"name":"Premium Widget","price":99.99}`, then applies an XPath expression `//Response` to retrieve the `status` attribute.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.232

### Validate `status` Attribute with Regex via XPath from XML Response after JSON-Body PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `failure` after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Response` and then applies a regular expression `success|failure` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.233

### Extract `<Status>` Element Text via XPath from XML Response after JSON-Body PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, and `--Body:{"name":"Premium Widget","price":99.99}`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.234

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after JSON-Body PATCH

Extract the inner text of the `<Status>` element in an XML response after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.235

### Extract `status` Attribute via XPath from XML Response after JSON-Body PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, and `--Body:{"name":"Premium Widget","price":99.99}`, then applies an XPath expression `//Response` to retrieve the `status` attribute.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.236

### Validate `status` Attribute with Regex via XPath from XML Response after JSON-Body PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `failure` after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Response` and then a regular expression `success|failure` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.237

### Extract `<Status>` Element Text via XPath from XML Response after JSON-Body PATCH

Extract the `<Status>` element text from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, `--Body:{"name":"Premium Widget","price":99.99}`, `--Header:Authorization:Basic username:password`, and `--Header:Accept:application/xml`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.238

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after JSON-Body PATCH

Extract the inner text of the `<Status>` element from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.239

### Extract `status` Attribute via XPath from XML Response after JSON-Body PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Response` to retrieve the `status` attribute.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.240

### Validate `status` Attribute with Regex via XPath from XML Response after JSON-Body PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response (with `Accept: application/xml`) matches either `success` or `failure` after sending an HTTP PATCH request with a JSON body.
It applies an XPath expression `//Response` and then a regular expression `success|failure` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.241

### Update Item – JSON Body PATCH

Update an item's name and price by sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, `--Body:{"name":"Premium Widget","price":99.99}`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
}
```
### Example No.242

### Extract Confirmation Message with Regex

Extract the confirmation `message` field from a JSON response after sending an HTTP PATCH request with a JSON body.
A regular expression `(?<=\"message\":\")[^\"]+` is applied to the response body; the assertion passes only if the extracted string matches this pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    RegularExpression = "(?<=\"message\":\")[^\"]+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}")
    .setRegularExpression("(?<=\"message\":\")[^\"]+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    regularExpression: "(?<=\"message\":\")[^\"]+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "regularExpression": "(?<=\"message\":\")[^\"]+"
}
```
### Example No.243

### Extract updatedItem via JSONPath

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a JSON body.
It uses `--Method:Patch`, `--ContentType:application/json`, `--Body:{"name":"Premium Widget","price":99.99}`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.244

### Extract Item ID with Regex from JSONPath

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a JSON body.
It applies a JSONPath expression `$.updatedItem` and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.245

### Extract `<Status>` Element Text via XPath from XML Response after JSON-Body PATCH

Extract the `<Status>` element text from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body and custom headers.
It uses `--Method:Patch`, `--ContentType:application/json`, `--Body:{"name":"Premium Widget","price":99.99}`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, and `--Header:Accept:application/xml`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.246

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after JSON-Body PATCH

Extract the inner text of the `<Status>` element from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body and custom headers.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.247

### Extract `status` Attribute via XPath from XML Response after JSON-Body PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a JSON body and custom headers.
It applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.248

### Validate `status` Attribute with Regex via XPath from XML Response after JSON-Body PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response (with `Accept: application/xml`) matches either `success` or `failure` after sending an HTTP PATCH request with a JSON body and custom headers.
It applies an XPath expression `//Response` and then a regular expression `success|failure` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|failure"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|failure");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|failure"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/json --Body:{"name":"Premium Widget","price":99.99} --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|failure"
}
```
### Example No.249

### Update Item – Plain-Text PATCH

Update an item's name and price by sending an HTTP PATCH request with a plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, and `--Body:Name=PremiumWidget;Price=99.99`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}"
}
```
### Example No.250

### Extract Status Code with Regex via Plain-Text PATCH

Extract the three-digit HTTP status code from a plain-text response line after sending an HTTP PATCH request with a plain-text body.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.251

### Extract updatedItem via JSONPath from Plain-Text PATCH

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Accept:application/json`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.252

### Extract id with Regex from JSONPath via Plain-Text PATCH

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a plain-text body.
It applies a JSONPath expression `$.updatedItem`, `--Header:Accept:application/json`, and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.253

### Extract `<Status>` Element Text via XPath from XML Response after Plain-Text PATCH

Extract the `<Status>` element text from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Accept:application/xml`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.254

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.255

### Extract `status` Attribute via XPath from XML Response after Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Response` to retrieve the `status` attribute.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.256

### Validate `status` Attribute with Regex via XPath from XML Response after Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response (with `Accept: application/xml`) matches either `success` or `error` after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Response` and then a regular expression `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.257

### Update Item – Plain-Text PATCH

Update an item's name and price by sending an HTTP PATCH request with a plain-text payload and a basic authorization header.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, and `--Header:Authorization:Basic username:password`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}"
}
```
### Example No.258

### Extract Status Code with Regex via Plain-Text PATCH

Extract the three-digit HTTP status code from a plain-text response after sending an HTTP PATCH request with a plain-text payload and a basic authorization header.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.259

### Extract updatedItem via JSONPath from Plain-Text PATCH

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a plain-text payload and a basic authorization header.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, and `--Header:Accept:application/json`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.260

### Extract Item ID with Regex from JSONPath via Plain-Text PATCH

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a plain-text payload and a basic authorization header.
It applies a JSONPath expression `$.updatedItem` and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.261

### Extract `<Status>` Element Text via XPath from XML Response after Plain-Text PATCH

Extract the `<Status>` element text from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, and `--Header:Accept:application/xml`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.262

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Status` and then a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.263

### Extract `status` Attribute via XPath from XML Response after Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.264

### Validate `status` Attribute with Regex via XPath from XML Response after Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response (with `Accept: application/xml`) matches either `success` or `error` after sending an HTTP PATCH request with a plain-text body.
It applies an XPath expression `//Response` and then a regular expression `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.265

### Update Item – Plain-Text PATCH with Custom Headers

Update an item's name and price by sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, `--Header:Authorization:Basic username:password`, and `--Header:UserAgent:MyCustomUserAgent`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}"
}
```
### Example No.266

### Extract Status Code with Regex via Plain-Text PATCH

Extract the three-digit HTTP status code from a plain-text response after sending an HTTP PATCH request with a plain-text body and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.267

### Extract updatedItem via JSONPath from Plain-Text PATCH

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, and `--Header:Accept:application/json`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.268

### Extract Item ID with Regex from JSONPath via Plain-Text PATCH

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It applies a JSONPath expression `$.updatedItem`, `--Header:Accept:application/json`, and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.269

### Extract `<Status>` Element Text via XPath from XML Response after Plain-Text PATCH

Extract the `<Status>` element text from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, and `--Header:Accept:application/xml`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.270

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.271

### Extract `status` Attribute via XPath from XML Response after Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response (with `Accept: application/xml`) after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.272

### Validate `status` Attribute with Regex via XPath from XML Response after Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response (with `Accept: application/xml`) matches either `success` or `error` after sending an HTTP PATCH request with a plain-text payload and the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It applies an XPath expression `//Response` and then a regular expression `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.273

### Update Item – Plain-Text PATCH with ASCII Encoding

Update an item's name and price by sending an HTTP PATCH request with an ASCII-encoded, plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Encoding:ASCII`, and `--Body:Name=PremiumWidget;Price=99.99`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}"
}
```
### Example No.274

### Extract Status Code with Regex via Plain-Text PATCH with ASCII Encoding

Extract the three-digit HTTP status code from a plain-text response line after sending an HTTP PATCH request with an ASCII-encoded, plain-text body.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.275

### Extract updatedItem via JSONPath from Plain-Text PATCH with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text body.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Encoding:ASCII`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, and `--Header:Accept:application/json`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.276

### Extract id with Regex from JSONPath via Plain-Text PATCH with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text body.
It applies a JSONPath expression `$.updatedItem`, `--Header:Accept:application/json`, and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.277

### Extract `<Status>` Element Text via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and an `Accept: application/xml` header.
It applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.278

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and an `Accept: application/xml` header.
It applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.279

### Extract `status` Attribute via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and an `Accept: application/xml` header.
It applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.280

### Validate `status` Attribute with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and an `Accept: application/xml` header.
It applies an XPath expression `//Response` and then a regex `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.281

### Update Item – Plain-Text PATCH with ASCII Encoding

Update an item's name and price by sending an HTTP PATCH request with an ASCII-encoded, plain-text payload.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99`, `--Header:Authorization:Basic username:password`, and `--Encoding:ASCII`, then returns the full response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}"
}
```
### Example No.282

### Extract Status Code with Regex via Plain-Text PATCH with ASCII Encoding

Extract the three-digit HTTP status code from a plain-text response line after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and the header `Authorization:Basic username:password`.
A regular expression `(?<=Status: )\d{3}` is applied to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99 --Header:Authorization:Basic username:password --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.283

### Extract updatedItem via JSONPath from Plain-Text PATCH with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and the headers `Authorization:Basic username:password` and `Accept:application/json`.
It uses `--Method:Patch`, `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Encoding:ASCII`, and `--Header:Accept:application/json`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.284

### Extract Item ID with Regex from JSONPath via Plain-Text PATCH with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload and the headers `Authorization:Basic username:password` and `Accept:application/json`.
It applies a JSONPath expression `$.updatedItem`, and then a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.285

### Extract `<Status>` Element Text via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.286

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.287

### Extract `status` Attribute via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` to retrieve the attribute.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.288

### Validate `status` Attribute with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` and a regex `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.289

### Extract `<Status>` Element Text via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.290

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent` and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.291

### Extract updatedItem via JSONPath from Plain-Text PATCH with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/json`, and `--Method:Patch`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.292

### Extract Item ID with Regex from JSONPath via Plain-Text PATCH with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/json`, and `--Method:Patch`, then applies a JSONPath expression `$.updatedItem` and a regex `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.293

### Extract `<Status>` Element Text via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.294

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.295

### Extract `status` Attribute via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.296

### Validate `status` Attribute with Regex via XPath from XML Response after ASCII-Encoded Plain-Text PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with an ASCII-encoded, plain-text payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/plain`, `--Body:Name=PremiumWidget;Price=99.99;Stock=150`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` and a regex `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:text/plain --Body:Name=PremiumWidget;Price=99.99;Stock=150 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.297

### Update Item – Form-URL-Encoded PATCH with Custom Headers

Update an item's name and price by sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, and `--Method:Patch`, then returns the full HTTP response body unchanged.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}"
}
```
### Example No.298

### Extract Status Code with Regex via Form-URL-Encoded PATCH with ASCII Encoding

Extract the three-digit HTTP status code from a plain-text response line after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password` and `UserAgent:MyCustomUserAgent`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, and `--Method:Patch`, then applies a regular expression `(?<=Status: )\d{3}` to the response body; the assertion passes only if the extracted string matches this three-digit pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}",
    RegularExpression = "(?<=Status: )\d{3}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}")
    .setRegularExpression("(?<=Status: )\d{3}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}",
    regularExpression: "(?<=Status: )\d{3}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Method:Patch}}",
    "regularExpression": "(?<=Status: )\d{3}"
}
```
### Example No.299

### Extract updatedItem via JSONPath from Form-URL-Encoded PATCH with ASCII Encoding

Select the `updatedItem` object from a JSON response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/json`, and `--Method:Patch`, then applies a JSONPath expression `$.updatedItem` to retrieve the node.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem"
}
```
### Example No.300

### Extract Item ID with Regex from JSONPath via Form-URL-Encoded PATCH with ASCII Encoding

Extract the numeric `id` value from the `updatedItem` object in a JSON response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/json`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/json`, and `--Method:Patch`, then applies a JSONPath expression `$.updatedItem` and a regular expression `(?<=\"id\":)\d+` to capture the ID; the assertion passes only if the extracted string matches this numeric pattern.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    OnElement = "$.updatedItem",
    RegularExpression = "(?<=\"id\":)\d+"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}")
    .setOnElement("$.updatedItem")
    .setRegularExpression("(?<=\"id\":)\d+");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    onElement: "$.updatedItem",
    regularExpression: "(?<=\"id\":)\d+"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/json --Method:Patch}}",
    "onElement": "$.updatedItem",
    "regularExpression": "(?<=\"id\":)\d+"
}
```
### Example No.301

### Extract `<Status>` Element Text via XPath from XML Response after Form-URL-Encoded PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.302

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after Form-URL-Encoded PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regex `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.303

### Extract `status` Attribute via XPath from XML Response after Form-URL-Encoded PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.304

### Validate `status` Attribute with Regex via XPath from XML Response after Form-URL-Encoded PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` and a regex `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url=https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url=https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.305

### Extract `<Status>` Element Text via XPath from XML Response after Form-URL-Encoded PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.306

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after Form-URL-Encoded PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.307

### Extract `status` Attribute via XPath from XML Response after Form-URL-Encoded PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.308

### Validate `status` Attribute with Regex via XPath from XML Response after Form-URL-Encoded PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with a form-url-encoded payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:application/x-www-form-urlencoded`, `--Field:Name=PremiumWidget`, `--Field:Price=99.99`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` and a regular expression `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:application/x-www-form-urlencoded --Field:Name=PremiumWidget --Field:Price=99.99 --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```
### Example No.309

### Extract `<Status>` Element Text via XPath from XML Response after PATCH

Extract the `<Status>` element text from an XML response after sending an HTTP PATCH request with an XML payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/xml`, `--Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` to extract the element's text content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status"
}
```
### Example No.310

### Extract `<Status>` Element Inner Text with Regex via XPath from XML Response after PATCH

Extract the inner text of the `<Status>` element from an XML response after sending an HTTP PATCH request with an XML payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/xml`, `--Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Status` and a regular expression `(?<=<Status>).*?(?=</Status>)` to extract the element's inner content.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnElement = "//Status",
    RegularExpression = "(?<=<Status>).*?(?=</Status>)"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnElement("//Status")
    .setRegularExpression("(?<=<Status>).*?(?=</Status>)");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onElement: "//Status",
    regularExpression: "(?<=<Status>).*?(?=</Status>)"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onElement": "//Status",
    "regularExpression": "(?<=<Status>).*?(?=</Status>)"
}
```
### Example No.311

### Extract `status` Attribute via XPath from XML Response after PATCH

Extract the `status` attribute value from the `<Response>` element in an XML response after sending an HTTP PATCH request with an XML payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/xml`, `--Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` to retrieve the `status` attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response"
}
```
### Example No.312

### Validate `status` Attribute with Regex via XPath from XML Response after PATCH

Validate that the `status` attribute of the `<Response>` element in an XML response matches either `success` or `error` after sending an HTTP PATCH request with an XML payload with the headers `Authorization:Basic username:password`, `UserAgent:MyCustomUserAgent`, and `Accept:application/xml`.
It uses `--ContentType:text/xml`, `--Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item>`, `--Header:Authorization:Basic username:password`, `--Header:UserAgent:MyCustomUserAgent`, `--Encoding:ASCII`, `--Header:Accept:application/xml`, and `--Method:Patch`, then applies an XPath expression `//Response` and a regular expression `success|error` to assert the attribute value.
Values are converted to strings to ensure consistent downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendHttpRequest",
    Argument = "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    OnAttribute = "status",
    OnElement = "//Response",
    RegularExpression = "success|error"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendHttpRequest")
    .setArgument("{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}")
    .setOnAttribute("status")
    .setOnElement("//Response")
    .setRegularExpression("success|error");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendHttpRequest",
    argument: "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    onAttribute: "status",
    onElement: "//Response",
    regularExpression: "success|error"
};
```

_**JSON**_

```js
{
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendHttpRequest",
    "argument": "{{$ --Url:https://api.example.com/v1/items/567 --ContentType:text/xml --Body:<Item><Name>PremiumWidget</Name><Price>99.99</Price></Item> --Header:Authorization:Basic username:password --Header:UserAgent:MyCustomUserAgent --Encoding:ASCII --Header:Accept:application/xml --Method:Patch}}",
    "onAttribute": "status",
    "onElement": "//Response",
    "regularExpression": "success|error"
}
```

## Output Parameter

### Send Http Request Http Response (SendHttpRequest:HttpResponse)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Extracted content from the HTTP response body after applying element, attribute, or pattern rules.
When no extraction rules are set, the full response body is available.
Processed content returned by the HTTP call is available through this parameter.

### Send Http Request Http Response Headers (SendHttpRequest:HttpResponseHeaders)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Headers returned by the HTTP response as name–value pairs.
Metadata such as content type, cache directives, and server information included.
Values available as a key–value map within the workflow.

### Send Http Request Http Status Code (SendHttpRequest:HttpStatusCode)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Any               |

Numeric HTTP status code returned by the server.
Common codes include success (200), redirection (3xx), client errors (4xx), and server errors (5xx).
Status code values guide decision flow based on request outcome.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

A single string or expression that covers address, method, headers, body, and other settings for a web request.
It can be a fixed string or an expression that runs at execution time.

### On Attribute (OnAttribute)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

An attribute name used to get information from an XML element.
It only applies to XML data and works alongside element location.
Accurate naming ensures you capture the right value.

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A path expression that finds the right part of XML or JSON data.
XPath works for XML and JSONPath works for JSON responses.
Correct path choice ensures you target the intended data.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

A text pattern that refines data after extraction.
It keeps only the parts that match the pattern.
Refined data makes following steps more accurate.
Pattern matching helps parse or check specific text.

## Parameters

### Body (Body)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Data sent in the body of POST or PUT requests to the server.
It carries information like form entries or JSON payloads.
Correct body content ensures the server receives the intended data.

### Content Type (ContentType)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines how the server should interpret the request body format.
Formats include JSON, XML, plain text, or binary data.
Correct content type ensures the server parses the data correctly.

#### Values

##### Applicationjson

JavaScript Object Notation is a lightweight format for structured data.
It is easy for people to read and machines to parse.
APIs often use JSON for data exchange.
##### Applicationoctetstream

A generic binary format for data without a specific type.
It allows transferring any arbitrary binary content.
Use it when the data format is unknown or varied.
##### Applicationpdf

Portable Document Format preserves document layout and appearance.
It is ideal for forms, manuals, and print-ready documents.
Readers display PDFs consistently across devices.
##### Applicationxml

Extensible Markup Language represents structured data with tags.
It works for both human reading and machine processing.
XML is common for web services and configuration files.
##### Audiompeg

MPEG audio format compresses sound files with good quality.
It is widely used for music and spoken audio online.
MP3 files play on most devices without extra software.
##### Imagejpeg

JPEG image format compresses photos with small file sizes.
It works best for complex images with many colors.
Most web photos use JPEG for balance between quality and size.
##### Imagepng

PNG image format uses lossless compression for clear graphics.
It supports transparency for layered designs.
Web icons and logos often use PNG for sharp detail.
##### Multipartformdata

Multipart form data allows uploading files with form fields.
It bundles text entries and binary files in one request.
Web forms use it to send images, documents, and text together.
##### Textcss

CSS style sheets describe how HTML content looks on a page.
They control layout, colors, fonts, and spacing.
Web pages use CSS to maintain a consistent design.
##### Texthtml

HTML documents structure web content with tags.
They mark headings, paragraphs, links, and lists.
Browsers render HTML to display web pages.
##### Textplain

Plain text format contains unformatted characters only.
It works for simple messages or logs without styling.
Any device or program can read plain text files.
##### Applicationxwwwformurlencoded

URL-encoded form data sends key-value pairs in the request body.
Special characters become percent-encoded codes.
Browsers use it when submitting HTML forms.
##### Videomp4

MP4 container holds video, audio, subtitles, and images.
It is compatible with most players and devices.
Online platforms use MP4 for smooth video streaming.

### Field (Field)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | KeyValue          |

Field name included in form-encoded POST or PUT requests.
It pairs a field name with its value in the request body.
Correct field entries ensure servers receive each form item.

### Header (Header)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | KeyValue          |

Key-value pairs that carry extra information in the request.
Each header uses a name and value separated by an equals sign.
Multiple headers let you pass options like authentication or format.

### Method (Method)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | HttpMethod        |

A list of available HTTP actions like GET, POST, or custom methods.
Values come from HttpMethod plugins and update automatically when new methods are added.
Correct method choice ensures the server handles the request as intended.

### Url (Url)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The address where the HTTP request is sent.
It tells the plugin which server and resource to contact.
Accurate URLs ensure requests reach the intended endpoint.

## Scope

* Any