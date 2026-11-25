# Receive Udp Message (ReceiveUdpMessage)

[Table of Content](../Home.md)

~37 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

ReceiveUdpMessage waits for UDP datagrams, single network messages, and stores what arrived.
It binds a port for the length of its own wait, or reads the buffer of a listener that was started earlier.
Flows use it to verify that an application or a device emitted the expected datagram, and to read its content.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Direct receive | Binds a port and waits for datagrams that arrive during the step. |
| Listener receive | Reads datagrams a started listener buffered while earlier steps ran. |
| Count and timeout | Waits for a set number of datagrams and fails the step when too few arrive in time. |
| Sender and content filters | Counts only datagrams that pass every filter set: sender host, sender port, and a text pattern. |
| Multicast | Joins a multicast group, an address many receivers share, for the length of a direct receive. |
| Text and binary output | Publishes datagrams as plain, hexadecimal, or Base64 text. |
| Message refinement | Reads one field of a JSON message, or one element or attribute of an XML message, and keeps a regular-expression match. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Device readings | Read a measurement a scale, sensor, or scanner sends over UDP. |
| Event triggers | Hold a flow, up to the timeout, until a system announces that a job finished. |
| Heartbeat monitoring | Confirm that a service still emits its periodic heartbeat. |
| Mock servers | Take a request on a listener and reply through the same listener with SendUdpMessage. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Emission checks | Assert that a UI action made the application send a telemetry or syslog datagram. |
| Content checks | Compare the fields of a received datagram with expected values. |
| Negative checks | Treat the timeout failure as the pass condition to prove that no matching datagram arrived. |
| Throughput checks | Require a number of datagrams within a time window. |

## Examples

### Example No.1

### Receive one datagram on a port

The step binds port 9100 and waits up to ten seconds for one datagram.
The socket closes when the step ends.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Port:9100 --Timeout:10000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Port:9100 --Timeout:10000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Port:9100 --Timeout:10000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:9100 --Timeout:10000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:9100 --Timeout:10000}}"
}
```

### Example No.2

### Read a datagram a listener buffered

The Listener parameter reads from the listener named `Telemetry`.
The step returns at once when a datagram is already buffered, and waits up to five seconds otherwise.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry --Timeout:5000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry --Timeout:5000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry --Timeout:5000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Timeout:5000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Timeout:5000}}"
}
```

### Example No.3

### Wait for several datagrams

The Count parameter requires three datagrams within fifteen seconds.
The step returns as soon as the third one arrives.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry --Count:3 --Timeout:15000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry --Count:3 --Timeout:15000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry --Count:3 --Timeout:15000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Count:3 --Timeout:15000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Count:3 --Timeout:15000}}"
}
```

### Example No.4

### Receive only a matching datagram from one sender

The RemoteHost and RemotePort parameters accept datagrams from one device and source port only.
The Pattern parameter accepts only text that starts with `ALARM`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry --RemoteHost:192.168.1.50 --RemotePort:5005 --Pattern:^ALARM}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry --RemoteHost:192.168.1.50 --RemotePort:5005 --Pattern:^ALARM}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry --RemoteHost:192.168.1.50 --RemotePort:5005 --Pattern:^ALARM}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --RemoteHost:192.168.1.50 --RemotePort:5005 --Pattern:^ALARM}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --RemoteHost:192.168.1.50 --RemotePort:5005 --Pattern:^ALARM}}"
}
```

### Example No.5

### Receive a multicast datagram

The step binds port 5000 and joins the multicast group 239.255.0.1 on the interface 192.168.1.10.
It waits up to ten seconds for one datagram sent to the group.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Port:5000 --MulticastGroup:239.255.0.1 --LocalAddress:192.168.1.10 --Timeout:10000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Port:5000 --MulticastGroup:239.255.0.1 --LocalAddress:192.168.1.10 --Timeout:10000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Port:5000 --MulticastGroup:239.255.0.1 --LocalAddress:192.168.1.10 --Timeout:10000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:5000 --MulticastGroup:239.255.0.1 --LocalAddress:192.168.1.10 --Timeout:10000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:5000 --MulticastGroup:239.255.0.1 --LocalAddress:192.168.1.10 --Timeout:10000}}"
}
```

### Example No.6

### Receive a binary datagram as hexadecimal text

The ResponseFormat parameter publishes the bytes as hexadecimal text.
The step binds port 9100 and waits for one datagram.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Port:9100 --ResponseFormat:Hex}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Port:9100 --ResponseFormat:Hex}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Port:9100 --ResponseFormat:Hex}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:9100 --ResponseFormat:Hex}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Port:9100 --ResponseFormat:Hex}}"
}
```

### Example No.7

### Read text in a legacy encoding and keep it out of the entity

The Encoding parameter reads the datagram bytes as Latin1 text.
The NoEntity switch publishes the outputs as session parameters only.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry --Encoding:Latin1 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry --Encoding:Latin1 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry --Encoding:Latin1 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Encoding:Latin1 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Encoding:Latin1 --NoEntity}}"
}
```

### Example No.8

### Read one field of a JSON datagram

The step reads a buffered JSON datagram and selects the `reading.value` field through the JSONPath in `onElement`.
The full datagram stays available in `ReceiveUdpMessage:Messages`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry}}",
    OnElement = "$.reading.value"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry}}")
    .setOnElement("$.reading.value");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry}}",
    onElement: "$.reading.value"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry}}",
    "onElement": "$.reading.value"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry}}",
    "onElement": "$.reading.value"
}
```

### Example No.9

### Keep one value of a text datagram

The step reads the oldest buffered datagram, such as `T=21;H=40`.
A regular expression `(?<=T=)\d+` is applied to the value attribute and keeps the digits after `T=`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry --Timeout:5000}}",
    RegularExpression = "(?<=T=)\\d+"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry --Timeout:5000}}")
    .setRegularExpression("(?<=T=)\\d+");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry --Timeout:5000}}",
    regularExpression: "(?<=T=)\\d+"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Timeout:5000}}",
    "regularExpression": "(?<=T=)\\d+"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry --Timeout:5000}}",
    "regularExpression": "(?<=T=)\\d+"
}
```

### Example No.10

### Read one attribute of an XML datagram

The step reads the oldest buffered XML datagram and selects the `status` element through the XPath in `onElement`.
The `onAttribute` property keeps the value of its `code` attribute.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReceiveUdpMessage",
    Argument = "{{$ --Listener:Telemetry}}",
    OnAttribute = "code",
    OnElement = "//status"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReceiveUdpMessage")
    .setArgument("{{$ --Listener:Telemetry}}")
    .setOnAttribute("code")
    .setOnElement("//status");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReceiveUdpMessage",
    argument: "{{$ --Listener:Telemetry}}",
    onAttribute: "code",
    onElement: "//status"
};
```

**JSON:**

```js
{
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry}}",
    "onAttribute": "code",
    "onElement": "//status"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReceiveUdpMessage",
    "argument": "{{$ --Listener:Telemetry}}",
    "onAttribute": "code",
    "onElement": "//status"
}
```

## Output Parameter

### Receive Udp Message Message (ReceiveUdpMessage:Message)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the text of the first datagram, after OnElement, OnAttribute, and RegularExpression refined it.
The ResponseFormat argument selects plain, hexadecimal, or Base64 text. The session value is Base64-encoded, so decode it before comparing or displaying it.

### Receive Udp Message Message Count (ReceiveUdpMessage:MessageCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of datagrams the step collected.
Compare it with the expected number to tell a partial result from a full one.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Receive Udp Message Messages (ReceiveUdpMessage:Messages)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores every collected datagram as a JSON array, oldest first.
Each item holds `Data`, `Length`, `ReceivedAt`, `RemoteAddress`, and `RemotePort`.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Receive Udp Message Remote Address (ReceiveUdpMessage:RemoteAddress)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the IP address of the sender of the first datagram.
Use it as the Host of a reply.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Receive Udp Message Remote Port (ReceiveUdpMessage:RemotePort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the port of the sender of the first datagram.
Use it as the Port of a reply.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Properties

### Argument (Argument)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | Yes                |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Holds the arguments of the step, such as `{{$ --Listener:Telemetry --Timeout:5000}}`.
Listener or Port is required.

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

Selects one part of the first datagram: a JSONPath such as `$.status` for JSON text, or an XPath such as `//status` for XML text.
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

Keeps the first match of the pattern in the first datagram, after OnElement was applied.
Defaults to a pattern that keeps the whole text, and a pattern that does not match publishes an empty value.

## Parameters

### Count (Count)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 1                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the number of matching datagrams the step waits for.
Defaults to 1, and the step fails when fewer arrive within Timeout, or sooner when another step stops the listener.
With a Listener, datagrams leave the buffer only when the full count arrived.

### Encoding (Encoding)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | UTF8              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the text encoding, such as `UTF8`, `ASCII`, `Unicode`, `UTF32`, `Latin1`, or a code page such as `windows-1252`.
Applies to datagrams published as text and to the Pattern filter.
Defaults to UTF-8, and a name the runtime does not know fails the step.

### Listener (Listener)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names a listener started by StartUdpListener and reads from its buffer.
Datagrams that arrived since the listener started and that no earlier step took are available, oldest first; a full buffer drops the oldest.
A name that is not started fails the step, and a listener another step stops during the wait fails it at once instead of with a timeout.

### Local Address (LocalAddress)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Binds one local IP address, which selects the network interface on a machine with several.
With MulticastGroup the step binds every interface and the address selects where the group is joined.
Defaults to every IPv4 interface, and is ignored when Listener is set.

### Multicast Group (MulticastGroup)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Joins a multicast group, such as `239.255.0.1`, for a step that binds its own Port.
Ignored when Listener is set, because a listener joins its own group, if any, when StartUdpListener starts it.

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

### Pattern (Pattern)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Counts only datagrams whose text matches a regular expression, such as `^ALARM`.
The payload is read as text in the encoding of the step before matching.
Datagrams that do not match stay in the listener buffer for another step.
Combines with RemoteHost and RemotePort; an invalid expression fails the step before it waits, and a match that runs longer than 30 seconds fails it.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Binds a local port, from 1 to 65535, for the length of the step; 0 fails the step, because no sender can know the port the system picks.
Only datagrams that arrive while the step waits are received, so use a Listener when the sender acts earlier.
Listener or Port is required, and Listener wins when both are set.

### Remote Host (RemoteHost)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Counts only datagrams sent from one host name or IP address.
Datagrams from other senders stay in the listener buffer for another step.
A host name is resolved once before waiting, and a name that does not resolve fails the step.

### Remote Port (RemotePort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Counts only datagrams sent from one source port, from 1 to 65535.
Defaults to 0, which accepts every source port.

### Response Format (ResponseFormat)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Text              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the bytes of each datagram are published.
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

### Timeout (Timeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 5000              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number\|Time      |

Sets how long to wait for the requested number of datagrams.
Accepts a number of milliseconds, such as `2000`, or a time span, such as `00:00:02`.
Defaults to 5000 milliseconds, which also replaces a value that is neither a number nor a time span.

## Scope

* Any
