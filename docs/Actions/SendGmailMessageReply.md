# Send Gmail Message Reply (SendGmailMessageReply)

[Table of Content](../Home.md)

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The SendGmailMessageReply sends a reply to an existing Gmail message while maintaining the conversation thread.
It automatically resolves the original message's thread and subject to ensure the reply is correctly grouped.
This helps automate email interactions within a workflow without breaking conversation history.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Threaded Replies           | Automatically links the reply to the original message and thread using RFC 2822 headers. |
| Recipient Overrides        | Allows specifying To, Cc, and Bcc recipients for the reply.                              |
| Automatic Subject Matching | Automatically uses the original message's subject to maintain the conversation.          |
| Session Parameter Storage  | Stores reply metadata like Id and ThreadId in session parameters for later use.          |

### Usages in RPA

| Use Case                    | Description                                                                                        |
| --- | --- |
| Customer Support Automation | Reply to customer inquiries while keeping the conversation in a single thread for better tracking. |
| Approval Workflows          | Send replies to approval request emails to confirm or reject actions within an automated process.  |
| Order Status Updates        | Automatically reply to customer order emails with status updates or tracking information.          |

### Usages in Automation Testing

| Use Case               | Description                                                                                            |
| --- | --- |
| Email Flow Validation  | Test the ability of a system to correctly receive and reply to emails within a conversation thread.    |
| Notification Testing   | Verify that automated replies are sent with the correct headers and content during integration tests.  |
| Threading Verification | Ensure that the email client or system under test correctly groups replies into the same conversation. |

## Examples

### Example No.1

### Reply to customer inquiry

The `SendGmailMessageReply` action sends a threaded reply to a customer inquiry identified by its unique `MessageId`.
It authenticates using a direct OAuth 2.0 `Token` and delivers the specified `Body` content to the address provided in the `To` parameter.
The action automatically resolves the original thread metadata to ensure the response appears correctly in the customer's conversation history.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendGmailMessageReply",
    Argument = "{{$ --MessageId:msg-98765 --To:customer@example.com --Body:We have received your request and our team is looking into it. --Token:ya29.a0AR...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendGmailMessageReply")
    .setArgument("{{$ --MessageId:msg-98765 --To:customer@example.com --Body:We have received your request and our team is looking into it. --Token:ya29.a0AR...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendGmailMessageReply",
    argument: "{{$ --MessageId:msg-98765 --To:customer@example.com --Body:We have received your request and our team is looking into it. --Token:ya29.a0AR...}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:msg-98765 --To:customer@example.com --Body:We have received your request and our team is looking into it. --Token:ya29.a0AR...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:msg-98765 --To:customer@example.com --Body:We have received your request and our team is looking into it. --Token:ya29.a0AR...}}"
}
```

### Example No.2

### Send approval workflow reply

The `SendGmailMessageReply` action automates the approval process by replying to a specific request email.
It utilizes stored `Credentials` for secure access and delivers the approval confirmation provided in the `Body` parameter to the recipient specified in `To`.
The action preserves conversation integrity by linking the reply to the original message via RFC 2822 headers.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendGmailMessageReply",
    Argument = "{{$ --MessageId:app-554433 --To:approver@example.com --Body:The requested item has been approved and is now being processed. --Credentials:GmailServiceAccount}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendGmailMessageReply")
    .setArgument("{{$ --MessageId:app-554433 --To:approver@example.com --Body:The requested item has been approved and is now being processed. --Credentials:GmailServiceAccount}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendGmailMessageReply",
    argument: "{{$ --MessageId:app-554433 --To:approver@example.com --Body:The requested item has been approved and is now being processed. --Credentials:GmailServiceAccount}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:app-554433 --To:approver@example.com --Body:The requested item has been approved and is now being processed. --Credentials:GmailServiceAccount}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:app-554433 --To:approver@example.com --Body:The requested item has been approved and is now being processed. --Credentials:GmailServiceAccount}}"
}
```

### Example No.3

### Update order status with CC and Bcc

The `SendGmailMessageReply` action sends an order status update as a reply to a customer's order confirmation email.
It overrides the default recipient list using the `To`, `Cc`, and `Bcc` parameters to ensure both the customer and internal stakeholders are informed.
The action correctly threads the reply with the original order email, providing a seamless communication experience.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendGmailMessageReply",
    Argument = "{{$ --MessageId:ord-112233 --To:buyer@example.com --Cc:manager@example.com --Bcc:archive@example.com --Body:Your order #12345 has been shipped and is on its way! --Token:ya29.a0AR...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendGmailMessageReply")
    .setArgument("{{$ --MessageId:ord-112233 --To:buyer@example.com --Cc:manager@example.com --Bcc:archive@example.com --Body:Your order #12345 has been shipped and is on its way! --Token:ya29.a0AR...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "SendGmailMessageReply",
    argument: "{{$ --MessageId:ord-112233 --To:buyer@example.com --Cc:manager@example.com --Bcc:archive@example.com --Body:Your order #12345 has been shipped and is on its way! --Token:ya29.a0AR...}}"
};
```

**JSON:**

```js
{
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:ord-112233 --To:buyer@example.com --Cc:manager@example.com --Bcc:archive@example.com --Body:Your order #12345 has been shipped and is on its way! --Token:ya29.a0AR...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "SendGmailMessageReply",
    "argument": "{{$ --MessageId:ord-112233 --To:buyer@example.com --Cc:manager@example.com --Bcc:archive@example.com --Body:Your order #12345 has been shipped and is on its way! --Token:ya29.a0AR...}}"
}
```

## Output Parameter

### Send Gmail Message Reply Id (SendGmailMessageReply:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Id stores the unique identifier assigned to the sent reply message by Gmail.
It allows subsequent workflow steps to reference and manage the specific reply.

### Send Gmail Message Reply Labels (SendGmailMessageReply:Labels)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Labels captures the list of labels applied to the newly sent reply message.
It provides insight into how the message is categorized within the Gmail mailbox.

### Send Gmail Message Reply Thread Id (SendGmailMessageReply:ThreadId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

ThreadId identifies the conversation thread to which the reply belongs.
It is essential for grouping related messages together in the user's inbox.

## Parameters

### Bcc (Bcc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Bcc identifies blind carbon copy recipients who receive the reply without being visible to others.
It is useful for discreetly archiving or monitoring automated email responses.

### Body (Body)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Body contains the text content of the reply message.
It conveys the actual information or response back to the original sender.

### Cc (Cc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Cc lists the carbon copy recipients who should receive a copy of the reply.
It helps keep relevant stakeholders informed about the ongoing conversation.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Credentials refers to a stored set of authentication details used to access the Gmail API.
It ensures secure and authorized communication with the user's mailbox.

### Message Id (MessageId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

MessageId identifies the specific Gmail message to which the reply is being sent.
It ensures that the automation targets the correct conversation thread.

### To (To)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

To specifies the primary recipients for the reply message.
It allows overriding or supplementing the default recipient list for the reply.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Token provides a direct OAuth 2.0 access token for authentication.
It serves as an alternative to stored credentials for quick or temporary API access.

## Scope

* Any
