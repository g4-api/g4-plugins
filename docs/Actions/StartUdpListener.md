# Start Udp Listener (StartUdpListener)

[Table of Content](../Home.md)

~19 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

StartUdpListener opens a UDP port and keeps the datagrams (single network messages) that arrive on it, up to the BufferSize limit.
UDP drops a datagram that arrives while no socket is bound, so place this step before the action that makes a sender emit.
Later steps read the buffered datagrams with ReceiveUdpMessage or send through the same socket with SendUdpMessage.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Background capture | Buffers datagrams in memory while the following steps run. |
| Named listeners | Runs several listeners in one flow, each reached by its name. |
| System-assigned port | Binds port 0 to get a free port and publishes the port that was assigned. |
| Multicast | Joins a multicast group for the lifetime of the listener. |
| Bounded buffer | Keeps a set number of datagrams and drops the oldest when the buffer is full. |
| Automatic cleanup | Closes the socket when the automation ends, even without a stop step. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Device monitoring | Collect readings a device sends while the flow operates another system. |
| Event capture | Record the notifications of a service during a long process. |
| Mock servers | Take requests from a client and answer them from the same port. |
| Parallel lanes | Share one listener between lanes that run at the same time. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Emission checks | Capture what the application under test sends when a UI action runs. |
| Traffic recording | Keep the datagrams of a scenario, up to BufferSize, for later assertions. |
| Dynamic ports | Start on a free port and pass the published port to the application under test. |
| Isolation | Give each test its own named listener and port so captures do not mix. |

## Examples

### Example No.1

### Start the default listener on a free port

The rule has no argument, so the listener takes the name `Default`.
The system assigns a free port.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartUdpListener"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartUdpListener");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StartUdpListener"
};
```

**JSON:**

```js
{
    "pluginName": "StartUdpListener"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StartUdpListener"
}
```

### Example No.2

### Start a named listener on a fixed port

The argument names the listener `Telemetry` and binds port 9100.
Datagrams that arrive from now on are buffered for later steps.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartUdpListener",
    Argument = "{{$ --Name:Telemetry --Port:9100}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartUdpListener")
    .setArgument("{{$ --Name:Telemetry --Port:9100}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StartUdpListener",
    argument: "{{$ --Name:Telemetry --Port:9100}}"
};
```

**JSON:**

```js
{
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Telemetry --Port:9100}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Telemetry --Port:9100}}"
}
```

### Example No.3

### Listen on one interface with a larger buffer

The LocalAddress parameter binds one network interface.
The BufferSize parameter keeps up to five thousand datagrams.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartUdpListener",
    Argument = "{{$ --Name:Lab --Port:9100 --LocalAddress:192.168.1.10 --BufferSize:5000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartUdpListener")
    .setArgument("{{$ --Name:Lab --Port:9100 --LocalAddress:192.168.1.10 --BufferSize:5000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StartUdpListener",
    argument: "{{$ --Name:Lab --Port:9100 --LocalAddress:192.168.1.10 --BufferSize:5000}}"
};
```

**JSON:**

```js
{
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Lab --Port:9100 --LocalAddress:192.168.1.10 --BufferSize:5000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Lab --Port:9100 --LocalAddress:192.168.1.10 --BufferSize:5000}}"
}
```

### Example No.4

### Listen to a multicast group

The MulticastGroup parameter joins the group 239.255.0.1 on port 5000.
Datagrams sent to the group are buffered under the name `Discovery`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StartUdpListener",
    Argument = "{{$ --Name:Discovery --Port:5000 --MulticastGroup:239.255.0.1}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StartUdpListener")
    .setArgument("{{$ --Name:Discovery --Port:5000 --MulticastGroup:239.255.0.1}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StartUdpListener",
    argument: "{{$ --Name:Discovery --Port:5000 --MulticastGroup:239.255.0.1}}"
};
```

**JSON:**

```js
{
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Discovery --Port:5000 --MulticastGroup:239.255.0.1}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StartUdpListener",
    "argument": "{{$ --Name:Discovery --Port:5000 --MulticastGroup:239.255.0.1}}"
}
```

## Output Parameter

### Start Udp Listener Name (StartUdpListener:Name)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the name of the started listener.
Pass it to the Listener parameter of ReceiveUdpMessage, SendUdpMessage, or the Name of StopUdpListener.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Start Udp Listener Port (StartUdpListener:Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the port the listener is bound to.
Holds the system-assigned port when the step asked for port 0, so the sender can be pointed at it after decoding.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the arguments of the step, such as `{{$ --Name:Telemetry --Port:9100}}`.
Every argument is optional; a rule without an argument starts the `Default` listener on a free port.

## Parameters

### Buffer Size (BufferSize)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 1000              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many unread datagrams the listener keeps before it drops the oldest.
Defaults to 1000, which 0 also selects; raise it for a long scenario with a busy sender.
A value that is not a whole number fails the step.

### Local Address (LocalAddress)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Binds one local IP address, which selects the network interface on a machine with several; a host name or other text fails the step.
Defaults to every IPv4 interface, and an IPv6 address makes the listener an IPv6 socket.
With an IPv4 MulticastGroup the listener binds every interface and the address selects the interface that joins the group.

### Multicast Group (MulticastGroup)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Joins a multicast group, such as `239.255.0.1`, so datagrams sent to the group reach the listener.
Opens the port for sharing with other multicast receivers that also allow it.
A value that is not an IP address, or not a multicast address, fails the step.

### Name (Name)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Default           |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the listener, so later steps reach it through the Listener parameter of ReceiveUdpMessage and SendUdpMessage, or the Name parameter of StopUdpListener.
Defaults to `Default`, also for an empty value, and case does not matter, so `telemetry` and `Telemetry` are the same listener.
A name already started in the same automation fails the step.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Binds a local port, from 0 to 65535.
Defaults to 0, which lets the system pick a free port that the step then publishes.
Without MulticastGroup, a port another socket holds fails the step.

## Scope

* Any
