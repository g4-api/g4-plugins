# Edit Gmail Message (EditGmailMessage)

[Table of Content](../Home.md)

~9 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The EditGmailMessage plugin adds and removes labels on a Gmail message during an automation run.
It helps workflows route, tag, and organize emails automatically without manual inbox work.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It stores the updated message details in session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                    | Description                                                                                                  |
| --- | --- |
| Update message labels      | Adds and removes labels on a Gmail message using the Gmail API (users.messages.modify).                      |
| Label name resolution      | Resolves provided label names to label ids at runtime before applying changes.                               |
| Add labels                 | Adds one or more resolved labels to the target message.                                                      |
| Remove labels              | Removes one or more resolved labels from the target message.                                                 |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                                                |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.                          |
| Credentials precedence     | Uses credentials when both token and credentials are provided.                                               |
| Result session storage     | Stores updated message fields in namespaced session parameters (EditGmailMessage:) as Base64-encoded values. |

### Usages in RPA

| Use Case                         | Description                                                                                      |
| --- | --- |
| Auto-triage incoming mail        | Add labels like Needs Review, Customer, or Urgent based on sender, subject, or content rules.    |
| Move emails through a workflow   | Add and remove labels as a message progresses through stages such as New, In Progress, and Done. |
| Keep shared processes consistent | Apply a standard label taxonomy so teams can search and report reliably.                         |
| Reduce inbox noise               | Remove a routing label after the message was processed, to prevent duplicate handling.           |

## Examples

### Example No.1

### EditGmailMessage: Add and remove labels

This example updates Gmail labels by removing `unread` and `new` and adding `important` and `follow-up`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "EditGmailMessage",
    Argument = "{{$ --MessageId:172ce2c4a72cc353 --Add:important --Add:follow-up --Remove:unread --Remove:new --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("EditGmailMessage")
    .setArgument("{{$ --MessageId:172ce2c4a72cc353 --Add:important --Add:follow-up --Remove:unread --Remove:new --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "EditGmailMessage",
    argument: "{{$ --MessageId:172ce2c4a72cc353 --Add:important --Add:follow-up --Remove:unread --Remove:new --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "EditGmailMessage",
    "argument": "{{$ --MessageId:172ce2c4a72cc353 --Add:important --Add:follow-up --Remove:unread --Remove:new --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "EditGmailMessage",
    "argument": "{{$ --MessageId:172ce2c4a72cc353 --Add:important --Add:follow-up --Remove:unread --Remove:new --Credentials:my-google-creds}}"
}
```

## Output Parameter

### Edit Gmail Message Bcc (EditGmailMessage:Bcc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Bcc recipient list from the Gmail message after label updates are applied.
Preserves hidden recipients so auditing and routing logic can use the same header data Gmail returned.
Helps downstream steps make decisions using the complete set of recipients.

### Edit Gmail Message Cc (EditGmailMessage:Cc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Cc recipient list from the Gmail message after label updates are applied.
Keeps carbon copy recipients available for logging, filtering, and routing rules.
Helps downstream steps evaluate who else received the message.

### Edit Gmail Message Content (EditGmailMessage:Content)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the message body content from the Gmail message after label updates are applied.
Provides the email text so later steps can parse, summarize, or act on the message without another API call.
Supports workflows that need content context while processing label changes.

### Edit Gmail Message From (EditGmailMessage:From)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the sender address from the Gmail message after label updates are applied.
Enables filtering and routing based on who sent the email.
Helps downstream steps validate the source before taking action.

### Edit Gmail Message Id (EditGmailMessage:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Gmail message identifier for the message whose labels were updated.
Provides a stable reference for follow-up actions like fetching details or applying more label changes.
Helps downstream steps target the exact message without ambiguity.

### Edit Gmail Message Labels (EditGmailMessage:Labels)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the resolved label names currently assigned to the message after the update completes.
Provides a JSON list of labels so later steps can verify the final labeling state.
Helps workflows make decisions based on the actual labels without re-fetching the message.

### Edit Gmail Message Subject (EditGmailMessage:Subject)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the subject line from the Gmail message after label updates are applied.
Helps workflows display, log, or classify the message using its subject.
Supports quick filtering when only header information is needed.

### Edit Gmail Message To (EditGmailMessage:To)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the To recipient list from the Gmail message after label updates are applied.
Keeps primary recipients available for routing, filtering, and audit checks.
Helps downstream steps determine whether the message was addressed to the expected target.

## Parameters

### Add (Add)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Defines the list of Gmail label names that will be added to the target message.
Controls how the message is categorized in Gmail so later searches and automations can find it.
Applies no new labels when the list is empty or not provided.

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

### Message Id (MessageId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the Gmail message identifier that will have its labels updated.
Ensures the label changes are applied to the intended message in the mailbox.
Prevents accidental updates by requiring a stable message id before making the API call.

### Remove (Remove)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Array             |

Defines the list of Gmail label names that will be removed from the target message.
Controls how the message is categorized by removing labels that are no longer relevant.
Removes no labels when the list is empty or not provided.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies an OAuth Bearer access token used to call the Gmail API.
Enables direct API access when a stored credential reference is not used.
Is ignored when a credentials reference is provided so stored credentials can take priority.

## Scope

* Any
