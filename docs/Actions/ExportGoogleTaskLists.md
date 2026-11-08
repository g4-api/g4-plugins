# Export Google Task Lists (ExportGoogleTaskLists)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The ExportGoogleTaskLists plugin retrieves all Google Tasks lists for the authenticated user.
It helps automation workflows discover existing task lists without opening the Google Tasks interface.
The plugin supports either a direct OAuth access token or a stored credentials reference that generates a fresh token at runtime.
The exported lists are stored as a Base64-encoded JSON value in a session parameter so later workflow steps can safely reuse the data.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Export Task Lists      | Retrieves all task lists associated with the authenticated Google account.                       |
| Token Authentication   | Accepts a direct OAuth Bearer access token for API access.                                       |
| Credential Resolution  | Uses a stored credential record to generate a fresh access token at runtime.                     |
| Session Result Storage | Saves the returned lists as Base64-encoded JSON in a session parameter for later workflow steps. |

### Usages in RPA

| Use Case                 | Description                                                                             |
| --- | --- |
| Discover Task Lists      | Retrieve all available Google Tasks lists before selecting one for automation.          |
| Dynamic Workflow Routing | Use the exported lists to decide which list should receive new tasks during execution.  |
| Data Synchronization     | Export task lists so automation workflows can synchronize data with external systems.   |
| Monitoring Automation    | Periodically retrieve task lists to verify that expected lists exist in a user account. |

## Examples

### Example No.1

### ExportGoogleTaskLists: Export using access token

Retrieve all Google Tasks lists for the authenticated user by calling the Google Tasks API with an OAuth access token.
Store the returned JSON array in the ExportGoogleTaskLists:Result Session parameter.
A macro token produces a runtime token value that is substituted where the token appears, and the ExportGoogleTaskLists action uses that substituted value as the request authorization.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleTaskLists",
    Argument = "{{$--token:y26...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleTaskLists")
    .setArgument("{{$--token:y26...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleTaskLists",
    argument: "{{$--token:y26...}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleTaskLists",
    "argument": "{{$--token:y26...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleTaskLists",
    "argument": "{{$--token:y26...}}"
}
```

### Example No.2

### ExportGoogleTaskLists: Export using credentials reference

Retrieve all Google Tasks lists by resolving a stored credentials reference and exchanging it for an OAuth access token at runtime.
Store the returned JSON array in the ExportGoogleTaskLists:Result Session parameter.
A macro token produces a runtime credentials reference value that is substituted where the credentials reference appears, and the ExportGoogleTaskLists action uses that substituted value to obtain the access token and authorize the API request.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleTaskLists",
    Argument = "{{$--credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleTaskLists")
    .setArgument("{{$--credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleTaskLists",
    argument: "{{$--credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleTaskLists",
    "argument": "{{$--credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleTaskLists",
    "argument": "{{$--credentials:my-google-creds}}"
}
```

## Output Parameter

### Export Google Task Lists Result (ExportGoogleTaskLists:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the exported Google Tasks lists returned by the Google Tasks API.
Contains a Base64-encoded JSON array representing all task lists retrieved during the automation run.
Allows later workflow steps to safely decode and reuse the exported lists without repeating the API request.

## Parameters

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an OAuth Bearer access token used to authenticate requests to the Google Tasks API.
Allows an automation workflow to call the API directly without retrieving credentials from a stored record.
Is ignored when the Credentials parameter is supplied because stored credentials take precedence for generating a token.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the identifier or name of a stored credential record used to obtain an OAuth access token.
Triggers a runtime exchange that generates a fresh access token using GooglePlugin.NewAccessToken.
Provides a reusable and safer authentication approach by avoiding hard-coded access tokens in automation steps.

## Scope

* Any
