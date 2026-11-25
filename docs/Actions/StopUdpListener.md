# Stop Udp Listener (StopUdpListener)

[Table of Content](../Home.md)

~13 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

StopUdpListener closes a listener that StartUdpListener opened.
The port becomes free when the step returns, and datagrams (network messages) no step read are discarded.
Flows use it to end a capture, to reuse a port within one run, and to clean up in a final step.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Stop by name | Closes the listener with the given name, or the `Default` listener. |
| Port release | Frees the port so a later step can bind it again. |
| Repeat-safe | Passes when no listener has the name and reports that nothing was stopped. |
| Multicast leave | Closing the socket ends the group membership the listener joined. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Scenario cleanup | Close the capture at the end of a process step. |
| Port reuse | Free a port before another tool or flow step binds it. |
| Loop iterations | Stop and start a listener inside a loop so each iteration begins with an empty buffer. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Test teardown | Close listeners in a final step so the next test starts clean. |
| Capture windows | End a capture at a known point, so later traffic is not counted. |
| Negative checks | Close the port so later steps can check how the application behaves when nothing listens. |

## Examples

### Example No.1

### Stop the default listener

The rule has no argument, so it stops the listener named `Default`.
The port is free when the step returns.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StopUdpListener"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StopUdpListener");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StopUdpListener"
};
```

**JSON:**

```js
{
    "pluginName": "StopUdpListener"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StopUdpListener"
}
```

### Example No.2

### Stop a named listener

The Name parameter selects the listener named `Telemetry`.
Other listeners of the flow keep running.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "StopUdpListener",
    Argument = "{{$ --Name:Telemetry}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("StopUdpListener")
    .setArgument("{{$ --Name:Telemetry}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "StopUdpListener",
    argument: "{{$ --Name:Telemetry}}"
};
```

**JSON:**

```js
{
    "pluginName": "StopUdpListener",
    "argument": "{{$ --Name:Telemetry}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "StopUdpListener",
    "argument": "{{$ --Name:Telemetry}}"
}
```

## Output Parameter

### Stop Udp Listener Name (StopUdpListener:Name)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the name of the listener the step addressed.
Use it in a log line to show which capture ended.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Stop Udp Listener Stopped (StopUdpListener:Stopped)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores `true` when a listener was open and is now closed, and `false` when none had the name.
Branch on it to tell a real stop from a repeated cleanup.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Properties

### Argument (Argument)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Holds the arguments of the step, such as `{{$ --Name:Telemetry}}`.
A rule without an argument stops the `Default` listener.

## Parameters

### Name (Name)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Default            |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names the listener to stop, among the listeners of the same automation.
Defaults to `Default`, also for an empty value, and case does not matter, so `telemetry` stops `Telemetry`.
When no listener has the name, the step still passes and stores `false` in Stopped.

## Scope

* Any
