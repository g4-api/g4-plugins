# Remove Google Task List (RemoveGoogleTaskList)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The RemoveGoogleTaskList plugin deletes an existing Google Tasks list for the authenticated user using the Google Tasks API.
It helps automation workflows clean up task lists that are no longer needed.
It supports either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
After successful execution, the specified task list is permanently removed from the user’s account.

### Key Features and Functionality

| Feature               | Description                                                                |
| --- | --- |
| Delete Task List      | Removes a specific Google Tasks list by its unique identifier.             |
| Token Support         | Accepts a raw OAuth access token for direct API calls.                     |
| Credentials Reference | Uses a stored credential record to obtain a fresh access token at runtime. |
| Error Handling        | Surfaces API errors when the list does not exist or authorization fails.   |

### Usages in RPA

| Use Case              | Description                                                        |
| --- | --- |
| Environment Cleanup   | Deletes temporary task lists created during automation runs.       |
| Workflow Reset        | Removes outdated lists before starting a new automation cycle.     |
| User Offboarding      | Cleans up task lists when disabling or archiving user workflows.   |
| Scheduled Maintenance | Periodically removes unused task lists to keep accounts organized. |

## Examples

### Example No.1

### RemoveGoogleTaskList: Delete using access token

Delete a Google Tasks list using a list id and an OAuth access token.
The `Get-Parameter` macros produce runtime values for `Id` and `Token` from Session parameters, and they are side-effect-free and reusable in any context that accepts literal values.
The action consumes the macro outputs when calling the Google Tasks API.
If the API returns an error, the action fails and does not delete the list.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleTaskList",
    Argument = "{{$ --Id:{{$Get-Parameter --Name:GmailTaskListId --Scope:Session}} --Token:{{$Get-Parameter --Name:AccessToken --Scope:Session}}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleTaskList")
    .setArgument("{{$ --Id:{{$Get-Parameter --Name:GmailTaskListId --Scope:Session}} --Token:{{$Get-Parameter --Name:AccessToken --Scope:Session}}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleTaskList",
    argument: "{{$ --Id:{{$Get-Parameter --Name:GmailTaskListId --Scope:Session}} --Token:{{$Get-Parameter --Name:AccessToken --Scope:Session}}}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleTaskList",
    "argument": "{{$ --Id:{{$Get-Parameter --Name:GmailTaskListId --Scope:Session}} --Token:{{$Get-Parameter --Name:AccessToken --Scope:Session}}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleTaskList",
    "argument": "{{$ --Id:{{$Get-Parameter --Name:GmailTaskListId --Scope:Session}} --Token:{{$Get-Parameter --Name:AccessToken --Scope:Session}}}}"
}
```

### Example No.2

### RemoveGoogleTaskList: Delete using credentials reference

Delete a Google Tasks list by referencing a stored credential record instead of passing a raw access token.
The `argument` attribute contains literal values for `Id` and `credentials`, and the action consumes those values to resolve the credential record by id or name.
The action exchanges the stored refresh token for a new access token and then uses that access token to call the Google Tasks API and delete the specified task list.
If credential resolution fails, the token exchange fails, or the API returns an error, the action fails and does not delete the list.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleTaskList",
    Argument = "{{$ --Id:task-list-id --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleTaskList")
    .setArgument("{{$ --Id:task-list-id --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleTaskList",
    argument: "{{$ --Id:task-list-id --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleTaskList",
    "argument": "{{$ --Id:task-list-id --Credentials:my-google-creds}}"
}
```

## Parameters

### Id (Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the unique identifier of the Google Tasks list to delete.
Targets the exact list that will be removed from the user account.
Ensures the correct resource is affected and prevents accidental deletion of other lists.

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
