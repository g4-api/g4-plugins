# New Google Task List (NewGoogleTaskList)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The NewGoogleTaskList plugin creates a new Google Tasks list for the authenticated user using the Google Tasks API.
It allows workflows to automatically organize tasks without manual setup in the Google interface.
It supports either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
After creation, it stores the new list details as Base64-encoded session parameters for safe reuse in later steps.

### Key Features and Functionality

| Feature                  | Description                                                                       |
| --- | --- |
| Create Task List         | Creates a new Google Tasks list for the authenticated user.                       |
| Token Support            | Accepts a raw OAuth access token for direct API calls.                            |
| Credentials Reference    | Uses a stored credential record to generate a fresh access token at runtime.      |
| Automatic Title Handling | Uses a provided title or generates a timestamp-based default if none is supplied. |
| Session Storage          | Stores the created list id, title, and selfLink as Base64 session parameters.     |

### Usages in RPA

| Use Case                 | Description                                                          |
| --- | --- |
| Automated Task Setup     | Creates task lists automatically during bot initialization.          |
| Workflow Organization    | Prepares dedicated task lists for specific automation runs.          |
| Dynamic Project Tracking | Generates new task lists per project or ticket during execution.     |
| Multi-User Automation    | Creates user-specific task lists using stored credential references. |

## Examples

### Example No.1

### NewGoogleTaskList: Create using access token

Create a Google Tasks list using an OAuth access token and a custom title.
The macro in the `argument` attribute produces runtime values for `Title` and `token`, and the action consumes those values when calling the Google Tasks API.
On success, the action Base64-encodes the returned `id`, `selfLink`, and `title` values and stores them in Session parameters.
The exact Session parameter names used for these stored values are implementation-defined.
If the request fails or the response is missing required properties, the action fails and does not store Session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleTaskList",
    Argument = "{{$ --Title:My Automation Backlog --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleTaskList")
    .setArgument("{{$ --Title:My Automation Backlog --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleTaskList",
    argument: "{{$ --Title:My Automation Backlog --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleTaskList",
    "argument": "{{$ --Title:My Automation Backlog --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleTaskList",
    "argument": "{{$ --Title:My Automation Backlog --Token:ya29...}}"
}
```

### Example No.2

### NewGoogleTaskList: Create using credentials reference

Create a Google Tasks list by referencing a stored credential record instead of passing a raw access token.
The macro in the `argument` attribute produces runtime values for `Title` and `credentials`, and the action consumes those values to resolve the credential record by id or name.
The action exchanges the stored refresh token for a new access token and then calls the Google Tasks API to create the task list.
On success, the action Base64-encodes the returned `id`, `selfLink`, and `title` values and stores them in Session parameters.
The exact Session parameter names used for these stored values are implementation-defined.
If credential resolution fails, the token exchange fails, or the API response is invalid, the action fails and does not store Session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleTaskList",
    Argument = "{{$ --Title:New Tasks --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleTaskList")
    .setArgument("{{$ --Title:New Tasks --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleTaskList",
    argument: "{{$ --Title:New Tasks --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleTaskList",
    "argument": "{{$ --Title:New Tasks --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleTaskList",
    "argument": "{{$ --Title:New Tasks --Credentials:my-google-creds}}"
}
```

## Output Parameter

### New Google Task List Id (NewGoogleTaskList:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The created Task List `id` returned by Google Tasks API.

### New Google Task List Title (NewGoogleTaskList:Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The effective title used when creating the list.

### New Google Task List Self Link (NewGoogleTaskList:SelfLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

The created Task List `selfLink` returned by Google Tasks API.

## Parameters

### Title (Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the title of the new Google Tasks list to create.
Provides a clear name that helps users recognize and organize their task collections.
Generates a default title in the format New Tasks List yyyyMMddHHmmssfff when no value is supplied.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies an OAuth Bearer access token used to call the Google Tasks API.
Enables direct API access without relying on a stored credential record.
Is ignored when the Credentials parameter is provided, allowing stored credentials to take priority.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Identifies a stored credential record by id or name.
Triggers a runtime exchange to obtain a fresh OAuth access token before calling the Google Tasks API.
Simplifies authentication by reusing securely stored credentials instead of passing raw tokens in each request.

## Scope

* Any
