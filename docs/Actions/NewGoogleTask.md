# New Google Task (NewGoogleTask)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The NewGoogleTask plugin creates a new Google Tasks task in a chosen task list during an automation run.
It helps workflows add tasks without opening Google Tasks manually, so bots can capture work items as they happen.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It saves the created task details into session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                    | Description                                                                                            |
| --- | --- |
| Create task                | Creates a new task in a target Google Tasks list using the Google Tasks API (Tasks: insert).           |
| List resolution            | Resolves the target list by id or by matching the provided list title.                                 |
| Optional fields            | Supports optional task fields such as notes and due date/time when provided.                           |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                                          |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.                    |
| Result session storage     | Stores created task fields in namespaced session parameters (NewGoogleTask:) as Base64-encoded values. |

### Usages in RPA

| Use Case                                | Description                                                                           |
| --- | --- |
| Convert incoming messages into tasks    | Create a follow-up task from an email, form submission, or chat message.              |
| Capture leads as tasks                  | Add a new task when a lead is detected in a CRM export or a website scrape result.    |
| Create recurring operational work items | Generate daily or weekly tasks based on schedules and checklist templates.            |
| Post-process job outcomes               | Create a task when a job fails or needs human review, including notes and a due date. |

## Examples

### Example No.1

### NewGoogleTask: Create task using access token

This example creates a new task in a specified task list, with notes and a due date.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleTask",
    Argument = "{{$ --TaskList:My Tasks --Title:Pay electricity --Notes:via automation --Due:2026-03-10T09:00:00Z --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleTask")
    .setArgument("{{$ --TaskList:My Tasks --Title:Pay electricity --Notes:via automation --Due:2026-03-10T09:00:00Z --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleTask",
    argument: "{{$ --TaskList:My Tasks --Title:Pay electricity --Notes:via automation --Due:2026-03-10T09:00:00Z --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Title:Pay electricity --Notes:via automation --Due:2026-03-10T09:00:00Z --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Title:Pay electricity --Notes:via automation --Due:2026-03-10T09:00:00Z --Token:ya29...}}"
}
```

### Example No.2

### NewGoogleTask: Create task using credentials reference

This example creates a new task using a stored credentials record and a target list id.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleTask",
    Argument = "{{$ --TaskList:task-list-id --Title:Follow up --Due:2026-03-10T09:00:00Z --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleTask")
    .setArgument("{{$ --TaskList:task-list-id --Title:Follow up --Due:2026-03-10T09:00:00Z --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleTask",
    argument: "{{$ --TaskList:task-list-id --Title:Follow up --Due:2026-03-10T09:00:00Z --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleTask",
    "argument": "{{$ --TaskList:task-list-id --Title:Follow up --Due:2026-03-10T09:00:00Z --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleTask",
    "argument": "{{$ --TaskList:task-list-id --Title:Follow up --Due:2026-03-10T09:00:00Z --Credentials:my-google-creds}}"
}
```

## Output Parameter

### New Google Task Id (NewGoogleTask:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the unique task identifier returned by the Google Tasks API after a task is created.
Helps later workflow steps target the exact task for updates, lookups, or deletion.
Reduces mistakes by keeping a stable reference to the created task.

### New Google Task Position (NewGoogleTask:Position)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the position value returned by the Google Tasks API for the created task.
Preserves ordering metadata that Google uses to arrange tasks inside the list.
Helps workflows that need to keep or validate task order across runs.

### New Google Task Self Link (NewGoogleTask:SelfLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the self link URL returned by the Google Tasks API for the created task.
Provides a direct resource reference that can help with troubleshooting and auditing.
Helps confirm the automation is pointing to the intended task resource.

### New Google Task Status (NewGoogleTask:Status)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the status returned by the Google Tasks API for the created task.
Confirms the initial state of the task, such as whether it still needs action.
Enables later steps to make decisions based on the stored state without an extra fetch.

### New Google Task Title (NewGoogleTask:Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the final task title that was used when the task was created.
Keeps a reliable record when the title comes from defaults or expressions.
Supports consistent logging, display, and verification in later workflow steps.

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
Avoids hardcoding tokens by exchanging the stored refresh token for a new access token when needed.
Improves reliability for long-running automations where short-lived access tokens may expire.

### Due (Due)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional due date and time for the task being created.
Helps schedule the task and enables reminders or sorting in Google Tasks clients.
Converts the provided value to an ISO 8601 UTC format before sending it to the Google Tasks API.

### Notes (Notes)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides optional notes that are saved as the task description in Google Tasks.
Adds extra context such as details, links, or instructions that help complete the task.
Improves task clarity without changing the task title or destination list.

### Task List (TaskList)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies which Google Tasks list will receive the new task by providing a list id or a list title.
Determines the exact destination for the task so it is created in the intended list.
Supports reliable targeting by resolving the list id from the provided value before creation.

### Title (Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the title for the task that will be created in the target Google Tasks list.
Controls how the task appears to users and helps keep tasks easy to find and understand.
Uses a timestamped default title when no value is provided to avoid creating unnamed tasks.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies an OAuth Bearer access token used to call the Google Tasks API.
Enables direct authentication for the request when no stored credential record is used.
Is ignored when a credentials reference is provided so stored credentials can take priority.

## Scope

* Any
