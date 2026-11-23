# Send Udp Message (SendUdpMessage)

[Table of Content](../Home.md)

~40 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

SendUdpMessage sends one UDP datagram, a single network message, to a host and port.
It can wait for the reply, send again when none arrives, and collect several replies to a broadcast.
Flows use it to command devices, post metrics or log lines, and query services that answer over UDP.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Text and binary payloads | Sends plain text, hexadecimal bytes, Base64 bytes, or the unchanged bytes of a file. |
| Request and reply | Waits for a reply from the destination address, or from any sender with AnySender, and fails the step when none arrives within the timeout. |
| Retries | Sends the datagram again while no reply arrives, up to a set number of times. |
| Broadcast discovery | Sends to a broadcast address and collects replies until MaxResponses arrive or the timeout ends. |
| Fixed source endpoint | Binds a local port or address for devices that reply to a fixed port. |
| Shared listener socket | Sends through a started listener, so replies the step does not wait for stay buffered for later steps. |
| Reply refinement | Reads one field of a JSON reply, or one element or attribute of an XML reply, and keeps a regular-expression match. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Device control | Send a command packet to a printer, a scale, an industrial controller (PLC), or a lab instrument. |
| Metrics and logs | Post a metric counter (StatsD) or a log line (syslog) from a running process. |
| Device discovery | Broadcast a discovery request and list the devices that answer. |
| Service triggers | Notify a UDP service that a batch or a file is ready. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Protocol checks | Send a request and assert the reply of a UDP service. |
| Negative checks | Treat the timeout failure as the pass condition to prove a closed or filtered port sent no reply. |
| Test stimulus | Inject datagrams into the application under test while another step watches the UI. |
| Mock servers | Reply through the same listener to the sender a ReceiveUdpMessage step captured. |

## Examples

### Example No.1

### Send a text datagram

The argument names the destination and the text to send.
The step sends one datagram and returns without waiting for a reply.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}"
}
```

### Example No.2

### Send a binary packet written as hexadecimal

The Format parameter reads the message as hexadecimal bytes.
The spaces between the bytes are ignored, so the packet reads the way a protocol document prints it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Format:Hex --Message:AA 55 01 00}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Format:Hex --Message:AA 55 01 00}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Format:Hex --Message:AA 55 01 00}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Format:Hex --Message:AA 55 01 00}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Format:Hex --Message:AA 55 01 00}}"
}
```

### Example No.3

### Send a request and wait for the reply

The WaitForResponse switch keeps the step waiting for a reply.
The step sends the request again up to two times when no reply arrives within two seconds.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --Timeout:2000 --Retries:2}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --Timeout:2000 --Retries:2}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --Timeout:2000 --Retries:2}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --Timeout:2000 --Retries:2}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --Timeout:2000 --Retries:2}}"
}
```

### Example No.4

### Discover devices with a broadcast

The Broadcast switch allows the subnet broadcast address 192.168.1.255, which the system rejects without it.
The step collects up to ten replies and returns after three seconds or after the tenth reply.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.255 --Port:3702 --Message:DISCOVER --Broadcast --WaitForResponse --MaxResponses:10 --Timeout:3000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.255 --Port:3702 --Message:DISCOVER --Broadcast --WaitForResponse --MaxResponses:10 --Timeout:3000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.255 --Port:3702 --Message:DISCOVER --Broadcast --WaitForResponse --MaxResponses:10 --Timeout:3000}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.255 --Port:3702 --Message:DISCOVER --Broadcast --WaitForResponse --MaxResponses:10 --Timeout:3000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.255 --Port:3702 --Message:DISCOVER --Broadcast --WaitForResponse --MaxResponses:10 --Timeout:3000}}"
}
```

### Example No.5

### Send through a started listener

The Listener parameter sends the datagram from the socket of the listener named `Telemetry`.
Replies arrive on the listener port and stay buffered for a later ReceiveUdpMessage step.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:START --Listener:Telemetry}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:START --Listener:Telemetry}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:START --Listener:Telemetry}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:START --Listener:Telemetry}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:START --Listener:Telemetry}}"
}
```

### Example No.6

### Send Base64 bytes from a fixed source port

The message holds Base64 bytes and leaves from port 5006 of the interface 192.168.1.10.
The reply is published as hexadecimal text.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Format:Base64 --Message:qlUBAA== --LocalAddress:192.168.1.10 --LocalPort:5006 --WaitForResponse --ResponseFormat:Hex}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Format:Base64 --Message:qlUBAA== --LocalAddress:192.168.1.10 --LocalPort:5006 --WaitForResponse --ResponseFormat:Hex}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Format:Base64 --Message:qlUBAA== --LocalAddress:192.168.1.10 --LocalPort:5006 --WaitForResponse --ResponseFormat:Hex}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Format:Base64 --Message:qlUBAA== --LocalAddress:192.168.1.10 --LocalPort:5006 --WaitForResponse --ResponseFormat:Hex}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Format:Base64 --Message:qlUBAA== --LocalAddress:192.168.1.10 --LocalPort:5006 --WaitForResponse --ResponseFormat:Hex}}"
}
```

### Example No.7

### Send text in a legacy encoding and keep it out of the entity

The Encoding parameter writes the accented text as Latin1 bytes.
The NoEntity switch publishes the outputs as session parameters only.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:TEMPÉRATURE? --Encoding:Latin1 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:TEMPÉRATURE? --Encoding:Latin1 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:TEMPÉRATURE? --Encoding:Latin1 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:TEMPÉRATURE? --Encoding:Latin1 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:TEMPÉRATURE? --Encoding:Latin1 --NoEntity}}"
}
```

### Example No.8

### Send the bytes of a file

The MessageFile parameter names a file.
The step sends its bytes unchanged as one datagram.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:10.0.0.20 --Port:9000 --MessageFile:C:\Packets\wake.bin}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:10.0.0.20 --Port:9000 --MessageFile:C:\Packets\wake.bin}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:10.0.0.20 --Port:9000 --MessageFile:C:\Packets\wake.bin}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:10.0.0.20 --Port:9000 --MessageFile:C:\Packets\wake.bin}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:10.0.0.20 --Port:9000 --MessageFile:C:\Packets\wake.bin}}"
}
```

### Example No.9

### Read one field of a JSON reply

The step waits for a JSON reply and reads the `temperature` field through the JSONPath in `onElement`.
A regular expression `\d+` is applied to the value attribute of the selected field and keeps its first run of digits, so 21.5 becomes 21.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:READ --WaitForResponse}}",
    OnElement = "$.temperature",
    RegularExpression = "\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:READ --WaitForResponse}}")
    .setOnElement("$.temperature")
    .setRegularExpression("\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:READ --WaitForResponse}}",
    onElement: "$.temperature",
    regularExpression: "\d+"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:READ --WaitForResponse}}",
    "onElement": "$.temperature",
    "regularExpression": "\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:READ --WaitForResponse}}",
    "onElement": "$.temperature",
    "regularExpression": "\d+"
}
```

### Example No.10

### Accept a reply from another address

The AnySender switch counts a reply from any address, not only from 192.168.1.50.
The step waits up to two seconds for the reply of a device that answers from a second network card.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --AnySender --Timeout:2000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --AnySender --Timeout:2000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --AnySender --Timeout:2000}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --AnySender --Timeout:2000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse --AnySender --Timeout:2000}}"
}
```

### Example No.11

### Read one attribute of an XML reply

The step waits for an XML reply and selects the `status` element through the XPath in `onElement`.
The `onAttribute` property keeps the value of its `code` attribute.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendUdpMessage",
    Argument = "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse}}",
    OnAttribute = "code",
    OnElement = "//status"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendUdpMessage")
    .setArgument("{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse}}")
    .setOnAttribute("code")
    .setOnElement("//status");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendUdpMessage",
    argument: "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse}}",
    onAttribute: "code",
    onElement: "//status"
};
```

**JSON:**

```js
{
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse}}",
    "onAttribute": "code",
    "onElement": "//status"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendUdpMessage",
    "argument": "{{$ --Host:192.168.1.50 --Port:5005 --Message:STATUS? --WaitForResponse}}",
    "onAttribute": "code",
    "onElement": "//status"
}
```

## Output Parameter

### Send Udp Message Bytes Sent (SendUdpMessage:BytesSent)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of payload bytes the datagram carried.
Compare it with the expected packet length to confirm the payload was read as intended.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Send Udp Message Remote Address (SendUdpMessage:RemoteAddress)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the IP address of the sender of the first reply.
When the step does not wait for a reply it holds the resolved destination address, which shows how the host name resolved.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Send Udp Message Remote Port (SendUdpMessage:RemotePort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the port of the sender of the first reply.
When the step does not wait for a reply it holds the destination port.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Send Udp Message Response (SendUdpMessage:Response)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the text of the first reply, after OnElement, OnAttribute, and RegularExpression refined it.
The ResponseFormat argument selects plain, hexadecimal, or Base64 text. The session value is Base64-encoded, so decode it before comparing or displaying it.

### Send Udp Message Response Count (SendUdpMessage:ResponseCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of replies the step collected.
Compare it with the expected number to tell a partial result from a full one.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Send Udp Message Responses (SendUdpMessage:Responses)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores every collected reply as a JSON array, oldest first.
Each item holds `Data`, `Length`, `ReceivedAt`, `RemoteAddress`, and `RemotePort`.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the arguments of the step, such as `{{$ --Host:192.168.1.50 --Port:5005 --Message:PING}}`.
Host and Port are required, together with Message or MessageFile.

### Locator (Locator)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Xpath             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the locator type of the rule and stays at its default for this action.
The path in OnElement is read as JSONPath for JSON text and as XPath for XML text, whatever the value is.

### On Attribute (OnAttribute)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names one attribute of the XML element that OnElement selects.
The attribute value replaces the element as the published text, and a missing attribute publishes an empty value.
Ignored for JSON text and when OnElement is empty.

### On Element (OnElement)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects one part of the first reply: a JSONPath such as `$.status` for JSON text, or an XPath such as `//status` for XML text.
The first result is kept: an XML element is published as its markup, and an attribute or a text node, such as `//status/@code`, as its value.
Text that is neither JSON nor XML skips the path, a path that finds nothing publishes an empty value, and a malformed path fails the step.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | (?si).*           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Keeps the first match of the pattern in the first reply, after OnElement was applied.
Defaults to a pattern that keeps the whole text, and a pattern that does not match publishes an empty value.

## Parameters

### Any Sender (AnySender)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Counts a datagram from any sender as a reply, not only one from the destination address.
Use it for a device that answers from another address, such as a host with several network cards.
Applies only when WaitForResponse is set.

### Broadcast (Broadcast)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Allows the destination to be a broadcast address, such as `192.168.1.255`.
The operating system rejects a subnet broadcast address without it.
The limited broadcast address `255.255.255.255` is accepted with or without the switch.

### Encoding (Encoding)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | UTF8              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the text encoding, such as `UTF8`, `ASCII`, `Unicode`, `UTF32`, `Latin1`, or a code page such as `windows-1252`.
Applies to a Text message and to replies published as text.
Defaults to UTF-8, and a name the runtime does not know fails the step.

### Format (Format)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Text              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the Message value becomes bytes.
Defaults to Text, applies only to Message, and any other value than Text, Hex, or Base64 fails the step.

#### Values

##### Text

Reads the value as plain text in the encoding of the step.
Use it for line protocols such as syslog, StatsD, or a device command.

##### Hex

Reads the value as hexadecimal bytes, such as `AA 55 01 00`.
Spaces, commas, colons, hyphens, and `0x` prefixes between bytes are ignored.

##### Base64

Reads the value as Base64 bytes.
Use it for a binary payload, or for text that contains ` --` or `}}`, which end an inline argument value.

### Host (Host)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the destination as a host name or an IP address, such as `192.168.1.50`.
A host name is resolved before sending, and a name that does not resolve, or has no address of the socket family, fails the step.

### Listener (Listener)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a listener started by StartUdpListener and sends through its socket.
Without WaitForResponse, replies stay in the listener buffer for ReceiveUdpMessage; with it, the replies the step collects are taken from the buffer, and datagrams from other senders stay unless AnySender is set or the destination is a broadcast or multicast address.
A name that is not started fails the step.

### Local Address (LocalAddress)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Binds the source IP address, which selects the network interface on a machine with several.
Defaults to every IPv4 interface, and an IPv6 address makes the socket an IPv6 socket.
Ignored when Listener is set.

### Local Port (LocalPort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Binds the source port of the datagram, from 0 to 65535.
Defaults to 0, which lets the system pick a free port; set it for a device that replies to a fixed port.
Ignored when Listener is set.

### Max Responses (MaxResponses)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the number of replies that ends the wait before the timeout.
Defaults to 1; a higher value collects the answers of several devices to one broadcast.
One reply is enough for the step to pass.

### Message (Message)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the payload of the datagram, read according to Format.
Wins over MessageFile when both are set, and one of the two is required.
A value that contains ` --` or `}}` travels as Hex or Base64, because those sequences end an inline argument value.

### Message File (MessageFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a file whose bytes are sent unchanged as the payload.
Use it for a binary packet kept beside the flow, and a missing file fails the step.

### No Entity (NoEntity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Leaves the response entity empty and publishes the outputs as session parameters only.
Use it when the datagram content must stay out of the extracted data of the flow.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the destination port, from 1 to 65535.
Any other value fails the step before a datagram is sent.

### Response Format (ResponseFormat)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Text              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the bytes of each reply are published.
Defaults to Text, and any other value than Text, Hex, or Base64 fails the step.

#### Values

##### Text

Publishes each datagram as plain text in the encoding of the step.
Use it for text protocols and for JSON or XML payloads.

##### Hex

Publishes each datagram as upper-case hexadecimal text without separators.
Use it to compare a binary packet byte by byte.

##### Base64

Publishes each datagram as Base64 text.
Use it to pass a binary packet to a later step without loss.

### Retries (Retries)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many times the datagram is sent again while no reply arrives.
Defaults to 0, and applies only when WaitForResponse is set.
Each attempt waits the full Timeout.

### Timeout (Timeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 5000              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Time       |

Sets how long to wait for replies after each send when WaitForResponse is set.
Accepts a number of milliseconds, such as `2000`, or a time span, such as `00:00:02`.
Defaults to 5000 milliseconds, which also replaces a value that is neither a number nor a time span.

### Wait For Response (WaitForResponse)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Waits for a reply after sending and fails the step when none arrives within Timeout.
Without it the step sends the datagram and returns at once.
Only datagrams from the destination address count as replies, unless the destination is a broadcast address, meaning any IPv4 address that ends in .255, or a multicast address, or AnySender is set, where every sender counts.

## Scope

* Any
