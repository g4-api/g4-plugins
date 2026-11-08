# Update Google Task (UpdateGoogleTask)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The UpdateGoogleTask plugin updates an existing Google Tasks task in a chosen task list during an automation run.
It helps workflows keep task details in sync when titles, notes, due dates, or status change over time.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It saves the updated task details into session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                    | Description                                                                                               |
| --- | --- |
| Update task                | Updates a task using the Google Tasks API (Tasks: update).                                                |
| List resolution            | Resolves the target list by id or by matching the provided list title.                                    |
| Task resolution            | Resolves the target task by id or by matching the provided task title.                                    |
| Optional field updates     | Updates only the provided fields, such as Title, Notes, Due, and Status.                                  |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                                             |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.                       |
| Result session storage     | Stores updated task fields in namespaced session parameters (UpdateGoogleTask:*) as Base64-encoded values. |

### Usages in RPA

| Use Case                  | Description                                                            |
| --- | --- |
| Reschedule follow-ups     | Update the due date when a meeting is moved or an SLA changes.         |
| Enrich tasks with context | Append notes from CRM, ticketing systems, or call summaries.           |
| Reflect workflow state    | Update task status when a related approval is completed or rejected.   |
| Standardize task titles   | Rename tasks to match a naming convention used across automation runs. |

## Examples

### Example No.1

### UpdateGoogleTask: Update task using access token

This example updates a task by title in the `My Tasks` list, changing its title, notes, due date, and status.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdateGoogleTask",
    Argument = "{{$ --Task:Pay electricity --TaskList:My Tasks --Title:Pay electricity bill --Notes:updated by automation --Due:2026-03-10T09:00:00Z --Status:needsAction --token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdateGoogleTask")
    .setArgument("{{$ --Task:Pay electricity --TaskList:My Tasks --Title:Pay electricity bill --Notes:updated by automation --Due:2026-03-10T09:00:00Z --Status:needsAction --token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "UpdateGoogleTask",
    argument: "{{$ --Task:Pay electricity --TaskList:My Tasks --Title:Pay electricity bill --Notes:updated by automation --Due:2026-03-10T09:00:00Z --Status:needsAction --token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "UpdateGoogleTask",
    "argument": "{{$ --Task:Pay electricity --TaskList:My Tasks --Title:Pay electricity bill --Notes:updated by automation --Due:2026-03-10T09:00:00Z --Status:needsAction --token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "UpdateGoogleTask",
    "argument": "{{$ --Task:Pay electricity --TaskList:My Tasks --Title:Pay electricity bill --Notes:updated by automation --Due:2026-03-10T09:00:00Z --Status:needsAction --token:ya29...}}"
}
```

### Example No.2

### UpdateGoogleTask: Update task using credentials reference

This example updates a task using a stored credentials record and a task list id.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "UpdateGoogleTask",
    Argument = "{{$ --Task:task-id --TaskList:task-list-id --Title:Follow up with vendor --Notes:moved to next sprint --Status:completed --credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("UpdateGoogleTask")
    .setArgument("{{$ --Task:task-id --TaskList:task-list-id --Title:Follow up with vendor --Notes:moved to next sprint --Status:completed --credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "UpdateGoogleTask",
    argument: "{{$ --Task:task-id --TaskList:task-list-id --Title:Follow up with vendor --Notes:moved to next sprint --Status:completed --credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "UpdateGoogleTask",
    "argument": "{{$ --Task:task-id --TaskList:task-list-id --Title:Follow up with vendor --Notes:moved to next sprint --Status:completed --credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "UpdateGoogleTask",
    "argument": "{{$ --Task:task-id --TaskList:task-list-id --Title:Follow up with vendor --Notes:moved to next sprint --Status:completed --credentials:my-google-creds}}"
}
```

## Output Parameter

### Update Google Task Id (UpdateGoogleTaskId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the task identifier returned by Google Tasks after the task update is completed.
Helps later workflow steps reference the exact updated task for follow-up actions.
Improves reliability by keeping a stable identifier even if other task fields change.

### Update Google Task Title (UpdateGoogleTaskTitle)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the final task title after the update has been applied in Google Tasks.
Helps downstream steps display or verify the updated title without fetching the task again.
Keeps automation output consistent when the title was calculated from expressions or defaults.

### Update Google Task Self Link (UpdateGoogleTaskSelfLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the self link URL returned by Google Tasks for the updated task.
Provides a direct reference to the exact updated task resource for troubleshooting and auditing.
Helps confirm that the update was applied to the intended task record.

### Update Google Task Position (UpdateGoogleTaskPosition)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the position value returned by Google Tasks for the updated task.
Preserves ordering metadata that affects where the task appears within the list.
Supports workflows that need to keep or validate task ordering after updates.

### Update Google Task Status (UpdateGoogleTaskStatus)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the status returned by Google Tasks for the updated task.
Captures the resulting state so later steps can make decisions without reloading the task.
Helps verify that the update did not unintentionally change the task state.

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

### Due (Due)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional due date and time to apply to the task during the update.
Helps schedule the task and supports reminders or sorting in Google Tasks clients.
Converts the provided value to an ISO 8601 UTC format before sending it to the Google Tasks API.

### Notes (Notes)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides optional notes that are stored as the task description when the task is updated.
Adds extra context such as details, links, or instructions that help complete the task.
Improves task clarity without changing the task identity or the target list.

### Status (Status)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional status value to apply to the task during the update.
Controls whether the task is treated as needing action or completed in Google Tasks clients.
Helps workflows drive correct behavior by storing the intended task state in the update request.

#### Values

##### Completed

Indicates the task has been completed in Google Tasks.
Helps workflows mark the task as done so clients can display it as finished.
Reduces confusion by clearly separating completed tasks from active ones.

##### Needs Action

Indicates the task requires action and is not yet completed.
Represents the normal state for an open task that still needs work.
Helps workflows treat the task as active and pending.

### Task (Task)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the task identifier or task title that should be updated in the resolved Google Tasks list.
Ensures the plugin targets the intended task by matching against both the task id and the task title.
Prevents accidental updates to the wrong task by requiring an exact match before applying changes.

### Task List (TaskList)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the Google Tasks list identifier or list title that contains the task to update.
Ensures the update is applied in the correct list by resolving the list id from the provided value.
Reduces mistakes by matching against both list id and list title before searching for the target task.

### Title (Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the updated task title that will be applied during the update.
Controls how the task appears to users and helps keep the task easy to find and understand.
Uses a timestamped default title when no value is provided to avoid leaving the title empty.

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
