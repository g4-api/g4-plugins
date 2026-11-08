# Send Gmail Message (SendGmailMessage)

[Table of Content](../Home.md)

~9 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The SendGmailMessage plugin sends a new email message from the authenticated Gmail mailbox during an automation run.
It helps workflows send notifications, confirmations, and reports without manual email work.
It supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
It stores the sent message metadata in session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                    | Description                                                                                                                              |
| --- | --- |
| Send email                 | Sends an email using the Gmail API (users.messages.send).                                                                                |
| RFC 2822 payload           | Builds and sends a raw RFC 2822 email payload, including headers and body.                                                               |
| Multiple recipients        | Supports multiple To, Cc, and Bcc recipients in the message headers.                                                                     |
| Token authentication       | Accepts a raw OAuth Bearer access token for direct API calls.                                                                            |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.                                                      |
| Credentials precedence     | Uses credentials when both token and credentials are provided.                                                                           |
| Result session storage     | Stores message metadata such as Id, ThreadId, and Labels in namespaced session parameters (SendGmailMessage:*) as Base64-encoded values. |

### Usages in RPA

| Use Case                    | Description                                                               |
| --- | --- |
| Send workflow notifications | Email status updates when a job starts, completes, or fails.              |
| Deliver generated reports   | Send a report file link or summary text to a distribution list.           |
| Confirm user actions        | Send confirmation emails after form submissions, approvals, or purchases. |
| Escalate incidents          | Email on-call or support teams with details collected by an automation.   |

## Examples

### Example No.1

### SendGmailMessage: Send email using access token

This example sends a new Gmail message with primary, CC, and BCC recipients using a provided OAuth access token.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendGmailMessage",
    Argument = "{{$ --To:alice@example.com;bob@example.com --Cc:manager@example.com --Bcc:audit@example.com --Subject:Build completed --Body:The nightly build finished successfully. --token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendGmailMessage")
    .setArgument("{{$ --To:alice@example.com;bob@example.com --Cc:manager@example.com --Bcc:audit@example.com --Subject:Build completed --Body:The nightly build finished successfully. --token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendGmailMessage",
    argument: "{{$ --To:alice@example.com;bob@example.com --Cc:manager@example.com --Bcc:audit@example.com --Subject:Build completed --Body:The nightly build finished successfully. --token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendGmailMessage",
    "argument": "{{$ --To:alice@example.com;bob@example.com --Cc:manager@example.com --Bcc:audit@example.com --Subject:Build completed --Body:The nightly build finished successfully. --token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendGmailMessage",
    "argument": "{{$ --To:alice@example.com;bob@example.com --Cc:manager@example.com --Bcc:audit@example.com --Subject:Build completed --Body:The nightly build finished successfully. --token:ya29...}}"
}
```

## Output Parameter

### Send Gmail Message Id (SendGmailMessage:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Gmail message identifier returned after the message is sent successfully.
Provides a stable reference that later steps can use to fetch the message or apply updates.
Helps workflows avoid ambiguity by targeting the exact sent message.

### Send Gmail Message Labels (SendGmailMessage:Labels)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Gmail label identifiers assigned to the sent message as a JSON array.
Helps workflows understand how Gmail categorized the message right after sending.
Supports later filtering and processing based on the labels that were applied.

### Send Gmail Message Thread Id (SendGmailMessageThread:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Gmail thread identifier associated with the sent message.
Enables later steps to group messages in the same conversation or send follow-up replies.
Helps workflows link the sent message to its related thread context.

## Parameters

### Bcc (Bcc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional blind carbon copy recipient list for the email being sent.
Ensures recipients in this list receive the message without being visible to other recipients.
Normalizes semicolon-separated addresses into comma-separated addresses before sending.

### Body (Body)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the body content for the email message being sent.
Supplies the main message text that recipients will read in the email client.
Supports dynamic content by allowing expressions when building automated messages.

### Cc (Cc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional carbon copy recipient list for the email being sent.
Ensures recipients in this list receive the message and are visible to other recipients.
Normalizes semicolon-separated addresses into comma-separated addresses before sending.

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

### From (From)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides an optional From header value to include in the RFC 2822 message headers.
Controls what sender value is written into the raw email payload when a custom From is needed.
Helps ensure the outgoing message headers match the intended sender identity.

### Subject (Subject)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the subject line for the email message being sent.
Helps recipients understand the message purpose and supports search and filtering.
Supports dynamic subject generation by allowing expressions at runtime.

### To (To)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the primary recipient email address list for the email being sent.
Determines who receives the message as direct recipients and supports multiple addresses.
Normalizes semicolon-separated addresses into comma-separated addresses before sending.

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
