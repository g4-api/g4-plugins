# Read Gmail Message (ReadGmailMessage)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose
The ReadGmailMessage plugin reads a Gmail message from the authenticated mailbox during an automation run.
It helps workflows pull email details so bots can route messages, extract information, or trigger follow-up actions.
It first fetches a message id from the mailbox and then retrieves the full message details for that message.
It stores key email fields in session parameters so later steps can reuse the results reliably.

### Key Features and Functionality

| Feature                       | Description                                                                                       |
| --- | --- |
| Read Gmail message            | Retrieves a message id and then fetches the full Gmail message details.                           |
| Most recent message selection | Requests a single message from the Gmail API list call and reads that returned message.           |
| Field extraction              | Extracts common fields such as From, To/Cc/Bcc, Subject, and message content.                     |
| Token authentication          | Accepts a raw OAuth Bearer access token for direct API calls.                                     |
| Credentials authentication    | Accepts a credentials id/name and exchanges it for a fresh access token at runtime.               |
| Result session storage        | Stores message fields in namespaced session parameters (ReadGmailMessage:) as Base64-encoded values. |

### Usages in RPA

| Use Case                  | Description                                                                         |
| --- | --- |
| Auto-triage incoming mail | Read the latest mail and route it to the right workflow based on sender or subject. |
| Create tasks from emails  | Read the mail content and create a Google Tasks item from key details.              |
| Extract structured data   | Parse order numbers, ticket ids, or links from the email body for downstream steps. |
| Notify and escalate       | Read an alert email and forward key details to chat or incident tools.              |

## Examples

### Example No.1

### ReadGmailMessage: Read Gmail message using access token

This example reads the first Gmail message returned by the API using a provided OAuth access token.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadGmailMessage",
    Argument = "{{$ --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadGmailMessage")
    .setArgument("{{$ --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReadGmailMessage",
    argument: "{{$ --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReadGmailMessage",
    "argument": "{{$ --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReadGmailMessage",
    "argument": "{{$ --Token:ya29...}}"
}
```

### Example No.2

### ReadGmailMessage: Read Gmail message using credentials reference

This example reads the first Gmail message returned by the API using a stored credentials reference.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ReadGmailMessage",
    Argument = "{{$ --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ReadGmailMessage")
    .setArgument("{{$ --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ReadGmailMessage",
    argument: "{{$ --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "ReadGmailMessage",
    "argument": "{{$ --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ReadGmailMessage",
    "argument": "{{$ --Credentials:my-google-creds}}"
}
```

## Output Parameter

### Read Gmail Message Bcc (ReadGmailMessage:Bcc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Bcc recipient list extracted from the retrieved Gmail message.
Preserves hidden recipients so auditing and routing logic can use the same header data Gmail returned.
Helps downstream steps make decisions based on the complete set of recipients.

### Read Gmail Message Cc (ReadGmailMessage:Cc)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Cc recipient list extracted from the retrieved Gmail message.
Keeps carbon copy recipients available for logging, filtering, or routing rules.
Helps downstream steps evaluate who else received the message.

### Read Gmail Message Content (ReadGmailMessage:Content)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the message body content extracted from the retrieved Gmail message.
Provides the actual email text so later steps can parse, summarize, or act on the message.
Supports automations that need the email content without making another API call.

### Read Gmail Message From (ReadGmailMessage:From)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the sender address extracted from the retrieved Gmail message.
Enables filtering and routing based on who sent the email.
Helps downstream steps validate the source before taking action.

### Read Gmail Message Id (ReadGmailMessage:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Gmail message identifier returned for the retrieved message.
Provides a stable reference for follow-up actions like fetching details or linking threads.
Helps downstream steps target the exact message without ambiguity.

### Read Gmail Message Rfc Message Id (ReadGmailMessageRfc:MessageId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the RFC Message-ID header value from the retrieved Gmail message.
Enables correct email threading for replies by supplying the value used in In-Reply-To and References headers.
Helps workflows link messages across systems using the standard RFC 5322 identifier.

### Read Gmail Message Rfc Thread Id (ReadGmailMessageRfc:ThreadId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the RFC thread reference value derived from the retrieved Gmail message headers.
Helps maintain reply threading by providing the identifier used to build References chains.
Supports consistent conversation linking when creating follow-up messages.

### Read Gmail Message Subject (ReadGmailMessage:Subject)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the subject line extracted from the retrieved Gmail message.
Helps workflows display, log, or classify the message using its subject.
Supports quick filtering when only header information is needed.

### Read Gmail Message Thread Id (ReadGmailMessage:ThreadId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the thread identifier extracted from the retrieved Gmail message.
Helps workflows track and manage email threads.
Supports actions that need to reference the entire conversation.

### Read Gmail Message To (ReadGmailMessage:To)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the To recipient list extracted from the retrieved Gmail message.
Keeps primary recipients available for routing, filtering, and audit checks.
Helps downstream steps determine whether the message was addressed to the expected target.

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
