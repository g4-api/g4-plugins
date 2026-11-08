# Update Google Task List (UpdateGoogleTaskList)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The UpdateGoogleTaskList plugin updates an existing Google Tasks list for the authenticated user using the Google Tasks API.
It allows workflows to change list metadata (such as the title) without manual edits in the Google interface.
It supports either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
After updating, it stores the effective list details as Base64-encoded session parameters for safe reuse in later steps.

### Key Features and Functionality

| Feature               | Description                                                                       |
| --- | --- |
| Update Task List      | Updates a specific Google Tasks list by its unique identifier.                    |
| Token Support         | Accepts a raw OAuth access token for direct API calls.                            |
| Credentials Reference | Uses a stored credential record to generate a fresh access token at runtime.      |
| Optional Title Update | Applies a new title when provided; otherwise retains the existing list title.     |
| Session Storage       | Stores the effective list id, title, and selfLink as Base64 session parameters.   |

### Usages in RPA

| Use Case                 | Description                                                          |
| --- | --- |
| Rename for Run Context   | Renames a list to include run metadata (date, ticket, environment).  |
| Workflow Organization    | Updates list titles to match dynamic workflow phases.                |
| Standardization          | Enforces naming conventions across automation-managed task lists.    |
| Multi-User Automation    | Updates user-specific task lists using stored credential references. |

## Examples

### Example No.1

### UpdateGoogleTaskList: Update using access token

Update a Google Tasks list using a list id, an OAuth access token, and an optional new title.
The `argument` attribute contains literal values for `Id`, `Title`, and `Token`, and the action consumes those values when calling the Google Tasks API.
On success, the action Base64-encodes the returned `id`, `selfLink`, and `title` values and stores them in Session parameters.
The exact Session parameter names used for these stored values are implementation-defined.
If the API returns an error or the response is missing required properties, the action fails and does not store Session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdateGoogleTaskList",
    Argument = "{{$ --Id:task-list-id --Title:My Renamed List --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdateGoogleTaskList")
    .setArgument("{{$ --Id:task-list-id --Title:My Renamed List --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "UpdateGoogleTaskList",
    argument: "{{$ --Id:task-list-id --Title:My Renamed List --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "UpdateGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Title:My Renamed List --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "UpdateGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Title:My Renamed List --Token:ya29...}}"
}
```

### Example No.2

### UpdateGoogleTaskList: Update using credentials reference

Update a Google Tasks list by referencing a stored credential record instead of passing a raw access token.
The `argument` attribute contains literal values for `Id`, `Title`, and `Credentials`, and the action consumes those values to resolve the credential record by id or name.
The action exchanges the stored refresh token for a new access token and then calls the Google Tasks API to update the task list.
On success, the action Base64-encodes the returned `id`, `selfLink`, and `title` values and stores them in Session parameters.
The exact Session parameter names used for these stored values are implementation-defined.
If credential resolution fails, the token exchange fails, or the API response is invalid, the action fails and does not store Session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdateGoogleTaskList",
    Argument = "{{$ --Id:task-list-id --Title:New Tasks --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdateGoogleTaskList")
    .setArgument("{{$ --Id:task-list-id --Title:New Tasks --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "UpdateGoogleTaskList",
    argument: "{{$ --Id:task-list-id --Title:New Tasks --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "UpdateGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Title:New Tasks --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "UpdateGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Title:New Tasks --Credentials:my-google-creds}}"
}
```

## Output Parameter

### Update Google Task List Id (UpdateGoogleTaskList:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Task List id returned by the Google Tasks API.
Identifies the exact list that was created, updated, or retrieved.
Enables later actions to reference the same list without calling the API again.

### Update Google Task List Title (UpdateGoogleTaskList:Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the effective title used after the list operation completes.
Reflects either the provided title or the generated default value.
Allows later steps to confirm or reuse the final list name without recalculating it.

### Update Google Task List Self Link (UpdateGoogleTaskList:SelfLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the selfLink value returned by the Google Tasks API.
Provides the direct API URL for the specific task list resource.
Supports traceability and follow-up API calls using the exact resource link.

## Parameters

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

### Id (Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the unique identifier of the Google Tasks list to update.
Targets the exact list that will be modified in the user account.
Ensures the correct resource is affected and prevents accidental updates to other lists.

### Title (Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the new title to apply to the Google Tasks list.
Provides a clear name that helps users recognize and organize their task collections.
When omitted, the list title is not changed and the existing title remains in effect.

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

## Scope

* Any
