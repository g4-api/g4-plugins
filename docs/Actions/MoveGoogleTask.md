# Move Google Task (MoveGoogleTask)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The MoveGoogleTask plugin moves a Google Tasks task within a list or to a different list during an automation run.
It helps workflows reorganize tasks as work changes, such as moving an item from an inbox list to a project list.
It supports flexible inputs by resolving lists and tasks using either ids or titles.
It saves the moved task details into session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                     | Description                                                                                           |
| --- | --- |
| Move task                   | Moves a task using the Google Tasks API (Tasks: move).                                                |
| Source list resolution      | Resolves the source list by id or by matching the provided list title.                                |
| Destination list resolution | Resolves the destination list by id or by matching the provided list title.                           |
| Task resolution             | Resolves the task to move by id or by matching the provided task title.                               |
| Optional parent task        | Supports moving the task under a parent task, resolved by id or title when provided.                  |
| Optional previous task      | Supports positioning the moved task after a previous task, resolved by id or title when provided.     |
| Result session storage      | Stores moved task fields in namespaced session parameters (MoveGoogleTask:*) as Base64-encoded values. |

### Usages in RPA

| Use Case             | Description                                                                       |
| --- | --- |
| Triage inbox tasks   | Move new tasks from an inbox list to the right project list based on keywords.    |
| Organize by status   | Move tasks into lists like To Do, In Progress, or Done to reflect workflow state. |
| Group under a parent | Move tasks under a parent task to build simple task hierarchies for a project.    |
| Reorder priorities   | Move a task after another task to reflect priority changes during the day.        |

## Examples

### Example No.1

### MoveGoogleTask: Move task within the same list

This example moves a task within the `My Tasks` list and positions it after another task.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveGoogleTask",
    Argument = "{{$ --TaskList:My Tasks --Task:Pay electricity --Previous:Buy groceries --token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveGoogleTask")
    .setArgument("{{$ --TaskList:My Tasks --Task:Pay electricity --Previous:Buy groceries --token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "MoveGoogleTask",
    argument: "{{$ --TaskList:My Tasks --Task:Pay electricity --Previous:Buy groceries --token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "MoveGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Task:Pay electricity --Previous:Buy groceries --token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "MoveGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Task:Pay electricity --Previous:Buy groceries --token:ya29...}}"
}
```

### Example No.2

### MoveGoogleTask: Move task to another list

This example moves a task from one Google Tasks list to another using a stored credentials reference.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "MoveGoogleTask",
    Argument = "{{$ --TaskList:My Tasks --Task:Follow up --Destination:Work Tasks --credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("MoveGoogleTask")
    .setArgument("{{$ --TaskList:My Tasks --Task:Follow up --Destination:Work Tasks --credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "MoveGoogleTask",
    argument: "{{$ --TaskList:My Tasks --Task:Follow up --Destination:Work Tasks --credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "MoveGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Task:Follow up --Destination:Work Tasks --credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "MoveGoogleTask",
    "argument": "{{$ --TaskList:My Tasks --Task:Follow up --Destination:Work Tasks --credentials:my-google-creds}}"
}
```

## Output Parameter

### Move Google Task Id (MoveGoogleTask:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the task identifier returned by Google Tasks after the task is moved.
Helps downstream steps reference the exact moved task for follow-up actions or verification.
Improves reliability by keeping a stable id even if the task order or list context changes.

### Move Google Task Title (MoveGoogleTask:Title)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the task title after the move operation has completed in Google Tasks.
Helps downstream steps display or verify the moved task without fetching it again.
Keeps a consistent record of the effective title associated with the moved task.

### Move Google Task Self Link (MoveGoogleTask:SelfLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the self link URL returned by Google Tasks for the task after it is moved.
Provides a direct reference to the exact task resource for auditing and troubleshooting.
Helps confirm the move affected the intended task record.

### Move Google Task Position (MoveGoogleTask:Position)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the position value returned by Google Tasks after the move operation.
Preserves ordering metadata that determines where the task appears in the destination list.
Supports workflows that need to validate or use task ordering after a move.

### Move Google Task Status (MoveGoogleTask:Status)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the status returned by Google Tasks for the task after it is moved.
Captures the resulting state so later steps can make decisions without reloading the task.
Helps verify that the move did not unintentionally change the task state.

## Parameters

### Destination (Destination)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Identifies a destination Google Tasks list by id or title for moving the task.
Moves the task into the specified list when a destination value is provided.
Keeps the task in the source list when the destination value is not provided.

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

### Parent (Parent)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies an optional parent task by id or title under which the task should be moved.
Controls the task hierarchy by nesting the moved task under the resolved parent task.
Leaves the task unparented when no parent value is provided.

### Previous (Previous)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies an optional previous task by id or title that is used to position the moved task.
Controls ordering by placing the moved task after the resolved previous task when provided.
Lets Google determine the position when no previous value is provided.

### Task (Task)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the task identifier or task title that should be moved from the source list.
Ensures the plugin targets the intended task by matching against both the task id and the task title.
Prevents moving the wrong task by requiring an exact match before performing the move operation.

### Task List (TaskList)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the source Google Tasks list identifier or list title that currently contains the task.
Ensures the move operation starts from the correct list by resolving the list from the provided value.
Reduces mistakes by tying task resolution to the intended source list.

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
