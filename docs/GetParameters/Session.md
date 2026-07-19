# Session (Session)

[Table of Content](../Home.md)  

~9 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

This plugin lets each automation run fetch values that belong only to its own session, such as temporary paths or tokens.
It keeps these values separate so that parallel runs do not interfere with each other.
This makes sure every run uses the right data without conflicts.

### Key Features and Functionality

| Feature             | Description                                                          |
|---------------------|----------------------------------------------------------------------|
| Parameter retrieval | Reads values specific to the current automation session.             |
| Live updates        | Picks up changes to session parameters during the run.               |
| Plugin integration  | Works with other plugins to pass session values into workflow steps. |

### Usages in RPA

| Use Case               | Description                                                     |
|------------------------|-----------------------------------------------------------------|
| Dynamic configuration  | Loads session values so workflows adapt to each run’s settings. |
| Session data isolation | Keeps each session’s data separate to avoid mixing values.      |

### Usages in Automation Testing

| Use Case               | Description                                                     |
|------------------------|-----------------------------------------------------------------|
| Isolated test sessions | Uses session values to keep data separate during parallel runs. |
| Dynamic test setup     | Fetches session values to configure tests on the fly.           |

## Examples

### Example No.1

### Retrieve Session-Level Environment Variable

This example demonstrates how to retrieve a session-level environment variable named `UserToken` using the Session plugin’s GetParameter action.
It retrieves the raw value of `UserToken` from the session scope for use in downstream workflows.
The retrieved value is available in the `Result` output field for subsequent steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "Session",
    OnElement = "UserToken"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("Session")
    .setOnElement("UserToken");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "Session",
    onElement: "UserToken"
};
```

_**JSON**_

```js
{
    "pluginName": "Session",
    "onElement": "UserToken"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "Session",
    "onElement": "UserToken"
}
```

## Properties

### On Element (OnElement)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

OnElement names the session parameter to fetch.
Workflows use this name to load the correct session value.
Using the right name ensures that workflows get the intended data every time.

## Scope

* Any