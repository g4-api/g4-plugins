# Remove Google Task (RemoveGoogleTask)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The RemoveGoogleTask plugin deletes a task from a Google Tasks list during an automation run.
It helps workflows clean up completed, cancelled, or mistaken tasks without manual work in Google Tasks.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It reduces accidental deletions by resolving the target list first and deleting only a task that matches the provided id or title.

### Key Features and Functionality

| Feature                    | Description                                                                              |
| --- | --- |
| Delete task                | Deletes a task using the Google Tasks API (Tasks: delete).                               |
| Task match by id or title  | Locates the task by exact id match or exact title match (case-insensitive).              |
| List match by id or title  | Resolves the target task list by exact id match or exact title match (case-insensitive). |
| Task paging support        | Pages through tasks in the list until a matching task is found.                          |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                            |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.      |
| Credentials precedence     | Uses credentials when both token and credentials are provided.                           |
| Fail-fast validation       | Fails when the task list cannot be resolved or when no matching task exists.             |

### Usages in RPA

| Use Case                    | Description                                                                               |
| --- | --- |
| Remove completed work items | Delete tasks that were completed after confirmation from another system.                  |
| Clean up duplicates         | Delete the first matching duplicate task created by a retry or a manual mistake.          |
| Cancel outdated reminders   | Remove tasks when a meeting is cancelled or a due date is no longer relevant.             |
| Enforce task list hygiene   | Delete tasks that match a clean-up rule, such as a specific title prefix or tag in notes. |

## Examples

### Example No.1

### RemoveGoogleTask: Delete by task id using access token

This example deletes a task by its id from the list `My Tasks` using a provided OAuth access token.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleTask",
    Argument = "{{$ --Task:dGFrZS10YXNrLWlk --TaskList:My Tasks --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleTask")
    .setArgument("{{$ --Task:dGFrZS10YXNrLWlk --TaskList:My Tasks --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleTask",
    argument: "{{$ --Task:dGFrZS10YXNrLWlk --TaskList:My Tasks --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleTask",
    "argument": "{{$ --Task:dGFrZS10YXNrLWlk --TaskList:My Tasks --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleTask",
    "argument": "{{$ --Task:dGFrZS10YXNrLWlk --TaskList:My Tasks --Token:ya29...}}"
}
```

### Example No.2

### RemoveGoogleTask: Delete by task title using credentials reference

This example deletes a task by its title using a stored credentials record, after resolving the list by id.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleTask",
    Argument = "{{$ --Task:Pay electricity --TaskList:task-list-id --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleTask")
    .setArgument("{{$ --Task:Pay electricity --TaskList:task-list-id --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleTask",
    argument: "{{$ --Task:Pay electricity --TaskList:task-list-id --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleTask",
    "argument": "{{$ --Task:Pay electricity --TaskList:task-list-id --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleTask",
    "argument": "{{$ --Task:Pay electricity --TaskList:task-list-id --Credentials:my-google-creds}}"
}
```

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

### Task (Task)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the task identifier or task title that should be deleted from the resolved Google Tasks list.
Ensures the plugin targets the intended task by matching against both the task id and the task title without case sensitivity.
Prevents accidental deletion of the wrong item by requiring an exact match before the delete request is sent.

### Task List (TaskList)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the Google Tasks list identifier or list title that contains the task to delete.
Ensures the delete operation is applied in the correct list by resolving the list id from the provided value without case sensitivity.
Reduces mistakes by matching against both list id and list title before searching for the target task.

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
