# Send Smtp Mail (SendSmtpMail)

[Table of Content](../Home.md)  

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sends emails through a standard SMTP server during an automation workflow.
It supports secure connections, login credentials, and sending to multiple recipients.
It is useful for alerts, notifications, and automated reporting.

### Key Features and Functionality

| Feature                   | Description                                                              |
|---------------------------|--------------------------------------------------------------------------|
| SMTP server configuration | Sends email using a configured host and port.                            |
| Secure connection option  | Supports SSL or TLS when enabled.                                        |
| SMTP authentication       | Logs in using a username and password when provided.                     |
| To recipients             | Sends to one or more primary recipients.                                 |
| CC and BCC recipients     | Supports carbon copy and blind carbon copy lists.                        |
| Subject and body content  | Sends a subject and a text or HTML body.                                 |
| Default sender address    | Uses a default From address when none is provided.                       |
| Force sender address      | Overrides the request From address with the default sender when enabled. |

### Usages in RPA

| Use Case                | Description                                                         |
|-------------------------|---------------------------------------------------------------------|
| Send operational alerts | Notifies operators when an automated task fails or needs attention. |
| Email generated reports | Sends daily or weekly reports created by a workflow.                |
| Notify stakeholders     | Sends status updates to business users after a process completes.   |
| Approval handoff        | Emails a person to approve or review a step before continuing.      |

### Usages in Automation Testing

| Use Case                 | Description                                                          |
|--------------------------|----------------------------------------------------------------------|
| Test run summary email   | Sends pass and fail results after a test run completes.              |
| CI failure notifications | Alerts the team when a pipeline test stage fails.                    |
| Smoke test validation    | Sends confirmation when a quick environment check succeeds or fails. |
| Regression monitoring    | Notifies owners when repeated failures appear across builds.         |

## Examples

### Example No.1

### Send a basic SMTP email

Send a plain-text email to one or more recipients using an SMTP server.
The action reads SMTP connection settings and message fields from the Argument string.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendSmtpMail",
    Argument = "{{$ --Host:smtp.mail.io --Port:587 --Username:no-reply@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:no-reply@mail.io --To:user1@mail.io;user2@mail.io --Subject:Build completed --Text:The nightly build finished successfully.}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendSmtpMail")
    .setArgument("{{$ --Host:smtp.mail.io --Port:587 --Username:no-reply@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:no-reply@mail.io --To:user1@mail.io;user2@mail.io --Subject:Build completed --Text:The nightly build finished successfully.}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendSmtpMail",
    argument: "{{$ --Host:smtp.mail.io --Port:587 --Username:no-reply@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:no-reply@mail.io --To:user1@mail.io;user2@mail.io --Subject:Build completed --Text:The nightly build finished successfully.}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:587 --Username:no-reply@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:no-reply@mail.io --To:user1@mail.io;user2@mail.io --Subject:Build completed --Text:The nightly build finished successfully.}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:587 --Username:no-reply@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:no-reply@mail.io --To:user1@mail.io;user2@mail.io --Subject:Build completed --Text:The nightly build finished successfully.}}"
}
```
### Example No.2

### Force the sender address

Always use a fixed sender address regardless of the From value in the request.
The ForceFrom flag forces the action to use DefaultFrom as the final sender.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendSmtpMail",
    Argument = "{{$ --Host:smtp.mail.io --Port:587 --Username:system@mail.io --Password:APP_PASSWORD --EnableSsl --ForceFrom --DefaultFrom:system@mail.io --From:user@mail.io --To:audit@mail.io --Subject:Security alert --Text:A privileged operation was executed.}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendSmtpMail")
    .setArgument("{{$ --Host:smtp.mail.io --Port:587 --Username:system@mail.io --Password:APP_PASSWORD --EnableSsl --ForceFrom --DefaultFrom:system@mail.io --From:user@mail.io --To:audit@mail.io --Subject:Security alert --Text:A privileged operation was executed.}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendSmtpMail",
    argument: "{{$ --Host:smtp.mail.io --Port:587 --Username:system@mail.io --Password:APP_PASSWORD --EnableSsl --ForceFrom --DefaultFrom:system@mail.io --From:user@mail.io --To:audit@mail.io --Subject:Security alert --Text:A privileged operation was executed.}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:587 --Username:system@mail.io --Password:APP_PASSWORD --EnableSsl --ForceFrom --DefaultFrom:system@mail.io --From:user@mail.io --To:audit@mail.io --Subject:Security alert --Text:A privileged operation was executed.}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:587 --Username:system@mail.io --Password:APP_PASSWORD --EnableSsl --ForceFrom --DefaultFrom:system@mail.io --From:user@mail.io --To:audit@mail.io --Subject:Security alert --Text:A privileged operation was executed.}}"
}
```
### Example No.3

### Send an HTML email

Send an email whose body is interpreted as HTML by the mail client.
The IsBodyHtml flag controls whether the message body is treated as HTML.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendSmtpMail",
    Argument = "{{$ --Host:smtp.mail.io --Port:465 --Username:reports@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:reports@mail.io --To:manager@mail.io --Cc:lead@mail.io;qa@mail.io --Subject:Weekly report --IsBodyHtml --Text:<h1>Report</h1><p>All systems operational.</p>}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendSmtpMail")
    .setArgument("{{$ --Host:smtp.mail.io --Port:465 --Username:reports@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:reports@mail.io --To:manager@mail.io --Cc:lead@mail.io;qa@mail.io --Subject:Weekly report --IsBodyHtml --Text:<h1>Report</h1><p>All systems operational.</p>}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendSmtpMail",
    argument: "{{$ --Host:smtp.mail.io --Port:465 --Username:reports@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:reports@mail.io --To:manager@mail.io --Cc:lead@mail.io;qa@mail.io --Subject:Weekly report --IsBodyHtml --Text:<h1>Report</h1><p>All systems operational.</p>}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:465 --Username:reports@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:reports@mail.io --To:manager@mail.io --Cc:lead@mail.io;qa@mail.io --Subject:Weekly report --IsBodyHtml --Text:<h1>Report</h1><p>All systems operational.</p>}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:smtp.mail.io --Port:465 --Username:reports@mail.io --Password:APP_PASSWORD --EnableSsl --DefaultFrom:reports@mail.io --To:manager@mail.io --Cc:lead@mail.io;qa@mail.io --Subject:Weekly report --IsBodyHtml --Text:<h1>Report</h1><p>All systems operational.</p>}}"
}
```
### Example No.4

### Send email using default credentials

Send an email through an internal SMTP relay that does not require explicit authentication.
Omit Username and Password so the action uses default system credentials.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendSmtpMail",
    Argument = "{{$ --Host:mail.internal.local --Port:25 --DefaultFrom:automation@internal.local --To:ops@internal.local --Subject:Service restarted --Text:The service was restarted automatically.}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendSmtpMail")
    .setArgument("{{$ --Host:mail.internal.local --Port:25 --DefaultFrom:automation@internal.local --To:ops@internal.local --Subject:Service restarted --Text:The service was restarted automatically.}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendSmtpMail",
    argument: "{{$ --Host:mail.internal.local --Port:25 --DefaultFrom:automation@internal.local --To:ops@internal.local --Subject:Service restarted --Text:The service was restarted automatically.}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:mail.internal.local --Port:25 --DefaultFrom:automation@internal.local --To:ops@internal.local --Subject:Service restarted --Text:The service was restarted automatically.}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendSmtpMail",
    "argument": "{{$ --Host:mail.internal.local --Port:25 --DefaultFrom:automation@internal.local --To:ops@internal.local --Subject:Service restarted --Text:The service was restarted automatically.}}"
}
```

## Parameters

### Bcc (Bcc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies one or more blind carbon copy recipient email addresses separated by semicolons.
Recipients listed here receive the email without being visible to other recipients.
This parameter is useful for silently notifying additional parties without exposing addresses.

### Cc (Cc)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies one or more carbon copy recipient email addresses separated by semicolons.
Recipients listed here are visible to all other recipients of the email.
This parameter is commonly used to keep stakeholders informed without making them primary recipients.

### Default From (DefaultFrom)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the default sender email address used when no explicit sender is provided.
This value ensures that outgoing emails always have a valid From address.
It helps prevent delivery failures caused by missing sender information.

### Enable Ssl (EnableSsl)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Enables SSL or TLS encryption for the SMTP connection when present.
Secure connections protect credentials and email content during transmission.
This setting is required by most modern SMTP servers.

### Force From (ForceFrom)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Forces the sender address to always use the configured default sender.
Any provided From value in the mail request is ignored when this is enabled.
This helps enforce consistent sender identity and avoid spoofing issues.

### From (From)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the sender email address for the message.
This value is used as the From field unless overridden by configuration rules.
Providing this allows per-message sender customization when permitted.

### Host (Host)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the hostname or IP address of the SMTP server.
This value tells the plugin where to establish the SMTP connection.
Correct configuration is required for successful email delivery.

### Is Body Html (IsBodyHtml)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Indicates whether the email body should be treated as HTML content.
When enabled, the message body is rendered using HTML formatting.
This allows rich text emails with styling and links.

### Password (Password)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the password used to authenticate with the SMTP server.
This is commonly an app-specific password or token rather than a user password.
Secure handling of this value is important to protect email credentials.

### Port (Port)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Integer           |

Defines the port number used to connect to the SMTP server.
Common values include 587 for STARTTLS and 465 for SSL connections.
Using the correct port ensures compatibility with the SMTP server configuration.

### Subject (Subject)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the subject line of the email message.
This text is displayed as the email title in the recipient inbox.
A clear subject improves message visibility and understanding.

### Text (Text)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Defines the main body content of the email message.
This value represents the text or HTML payload sent to recipients.
It contains the primary information conveyed by the email.

### To (To)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies one or more primary recipient email addresses separated by semicolons.
At least one valid recipient is typically required for successful delivery.
These addresses represent the main targets of the email message.

### Username (Username)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies the username used to authenticate with the SMTP server.
This value is often the same as the sender email address.
Providing a username enables authenticated SMTP sessions when required.

## Scope

* Any