# User (User)

[Table of Content](../Home.md)  

~9 min · GetParameter Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

This plugin lets automation workflows get values stored in the environment of the current user. 
It makes per-user settings—like themes or API keys—available without exposing them to other users. 
By keeping user data private, workflows can run with personalized configurations safely.

### Key Features and Functionality

| Feature                 | Description                                                                         |
|-------------------------|-------------------------------------------------------------------------------------|
| Parameter retrieval     | Reads named values from the active user’s environment variables.                    |
| User context isolation  | Keeps values visible only to the current user, preventing cross-user data access.   |
| Dynamic value injection | Passes the retrieved value into following steps for personalized workflow behavior. |

### Usages in RPA

| Use Case                | Description                                                                |
|-------------------------|----------------------------------------------------------------------------|
| User preference loading | Applies per-user settings like themes or shortcuts during automation runs. |
| Personalized workflows  | Drives actions using user-specific data such as API keys or user IDs.      |

### Usages in Automation Testing

| Use Case                 | Description                                                                       |
|--------------------------|-----------------------------------------------------------------------------------|
| User-specific testing    | Runs tests under the correct user context by fetching user-level configurations.  |
| Test configuration setup | Simplifies test setup by pulling user environment parameters directly in scripts. |

## Examples

### Example No.1

### Retrieve User API Key Parameter

This example demonstrates how to retrieve a user-level parameter named `UserApiKey` using the User plugin’s GetParameter action.
It retrieves the raw value of `UserApiKey` from the user scope for use in downstream workflows.
The retrieved value is available in the `Result` output field for subsequent steps.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "User",
    OnElement = "UserApiKey"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("User")
    .setOnElement("UserApiKey");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "User",
    onElement: "UserApiKey"
};
```

_**JSON**_

```js
{
    "pluginName": "User",
    "onElement": "UserApiKey"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "User",
    "onElement": "UserApiKey"
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

OnElement names the user parameter to fetch.
Workflows use this name to load the correct user value when they run.
Using the right name ensures workflows retrieve the intended information for each user.

## Scope

* Windows