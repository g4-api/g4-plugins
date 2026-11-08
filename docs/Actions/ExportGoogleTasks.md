# Export Google Tasks (ExportGoogleTasks)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The ExportGoogleTasks plugin exports tasks from a Google Tasks list during an automation run.
It helps workflows read the current task list content so bots can report, sync, or make decisions based on tasks.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It stores the exported tasks as Base64-encoded JSON in a session parameter so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                    | Description                                                                                 |
| --- | --- |
| Export tasks               | Retrieves tasks from a resolved Google Tasks list using the Google Tasks API (Tasks: list). |
| List resolution            | Resolves the target list by id or by matching the provided list title.                      |
| Task paging support        | Pages through tasks to export the full collection from the list.                            |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                               |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.         |
| Credentials precedence     | Uses credentials when both token and credentials are provided.                              |
| Result session storage     | Stores the exported task collection in ExportGoogleTasks:Result as Base64-encoded JSON.      |

### Usages in RPA

| Use Case                     | Description                                                                       |
| --- | --- |
| Build daily task reports     | Export tasks and send a summary to email, chat, or a dashboard.                   |
| Sync tasks to another system | Export tasks and upsert them into a CRM, ticketing tool, or database.             |
| Drive decision steps         | Export tasks and branch workflow logic based on status, due dates, or titles.     |
| Prepare clean-up actions     | Export tasks first, then delete or update selected tasks in later workflow steps. |

## Examples

### Example No.1

### ExportGoogleTasks: Export tasks using access token

This example exports all tasks from the `My Tasks` list using a provided OAuth access token.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleTasks",
    Argument = "{{$ --TaskList:My Tasks --token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleTasks")
    .setArgument("{{$ --TaskList:My Tasks --token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleTasks",
    argument: "{{$ --TaskList:My Tasks --token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleTasks",
    "argument": "{{$ --TaskList:My Tasks --token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleTasks",
    "argument": "{{$ --TaskList:My Tasks --token:ya29...}}"
}
```

### Example No.2

### ExportGoogleTasks: Export tasks using credentials reference

This example exports all tasks from a Google Tasks list by resolving the list from its id and authenticating through a stored credentials record.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleTasks",
    Argument = "{{$ --TaskList:task-list-id --credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleTasks")
    .setArgument("{{$ --TaskList:task-list-id --credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleTasks",
    argument: "{{$ --TaskList:task-list-id --credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleTasks",
    "argument": "{{$ --TaskList:task-list-id --credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleTasks",
    "argument": "{{$ --TaskList:task-list-id --credentials:my-google-creds}}"
}
```

## Output Parameter

### Export Google Tasks Result (ExportGoogleTasks:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the exported tasks for the resolved Google Tasks list as a Base64-encoded JSON payload.
Provides the full task collection so downstream steps can parse, filter, and act on the exported data.
Improves workflow reliability by keeping a stable snapshot of the export result in session storage.

## Parameters

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Identifies a stored credential record by id or name so a fresh access token can be obtained at runtime.
Avoids hardcoding short-lived tokens by exchanging stored credentials for a valid access token when needed.
Takes precedence over the token parameter so authentication stays consistent and renewable.

### Task List (TaskList)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the Google Tasks list identifier or list title whose tasks should be exported.
Determines the exact list to export from by resolving the list using its id or its title.
Prevents exporting the wrong list by requiring the resolved list to match the provided value.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies an OAuth Bearer access token used to call the Google Tasks API.
Enables direct API access when a stored credential reference is not used.
Is ignored when a credentials reference is provided so stored credentials can take priority.

## Scope

* Any
