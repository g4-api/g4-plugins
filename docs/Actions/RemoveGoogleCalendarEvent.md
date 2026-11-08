# Remove Google Calendar Event (RemoveGoogleCalendarEvent)

[Table of Content](../Home.md)

~12 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Deletes a Google Calendar event by its unique identifier from the target calendar.
Targets the authenticated user's primary calendar by default when CalendarId is omitted.
Authenticates via a direct OAuth access token or a stored credentials reference exchanged for a fresh token.
Controls whether attendees are notified of the deletion via SendUpdates.

### Key Features and Functionality

| Feature                    | Description                                                                                           |
| --- | --- |
| Delete event               | Deletes an event by id using the Google Calendar API (Events: delete).                                |
| Calendar targeting         | Targets any accessible calendar by CalendarId; defaults to the authenticated user's primary calendar. |
| Notification control       | Controls whether attendees are notified of the deletion via SendUpdates.                              |
| Token authentication       | Accepts a raw OAuth Bearer access token.                                                              |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token.                              |

### Usages in RPA

| Use Case                             | Description                                                              |
| --- | --- |
| Cancel scheduled meetings            | Delete events that are no longer needed after a workflow decision.       |
| Clean up test events                 | Remove events created during automated testing runs.                     |
| Sync deletions from external systems | Mirror event cancellations from an external system into Google Calendar. |
| Remove outdated calendar blocks      | Delete focus time or out-of-office blocks when conditions change.        |

## Examples

### Example No.1

### RemoveGoogleCalendarEvent: Delete event from primary calendar using access token

Delete a calendar event by its unique identifier from the primary calendar.
CalendarId is omitted so the plugin targets the authenticated user's primary calendar.
SendUpdates is omitted so no cancellation emails are sent to attendees.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleCalendarEvent",
    Argument = "{{$ --EventId:abc123xyz --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleCalendarEvent")
    .setArgument("{{$ --EventId:abc123xyz --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleCalendarEvent",
    argument: "{{$ --EventId:abc123xyz --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleCalendarEvent",
    "argument": "{{$ --EventId:abc123xyz --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleCalendarEvent",
    "argument": "{{$ --EventId:abc123xyz --Token:ya29...}}"
}
```

### Example No.2

### RemoveGoogleCalendarEvent: Delete event from secondary calendar using stored credentials

Delete a calendar event from a secondary calendar by supplying its identifier and CalendarId.
Stored credentials are exchanged at runtime for a fresh OAuth access token, avoiding hardcoded token expiry issues.
SendUpdates:all notifies all attendees of the cancellation immediately.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "RemoveGoogleCalendarEvent",
    Argument = "{{$ --EventId:abc123xyz --CalendarId:team@group.calendar.google.com --SendUpdates:all --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("RemoveGoogleCalendarEvent")
    .setArgument("{{$ --EventId:abc123xyz --CalendarId:team@group.calendar.google.com --SendUpdates:all --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "RemoveGoogleCalendarEvent",
    argument: "{{$ --EventId:abc123xyz --CalendarId:team@group.calendar.google.com --SendUpdates:all --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "RemoveGoogleCalendarEvent",
    "argument": "{{$ --EventId:abc123xyz --CalendarId:team@group.calendar.google.com --SendUpdates:all --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "RemoveGoogleCalendarEvent",
    "argument": "{{$ --EventId:abc123xyz --CalendarId:team@group.calendar.google.com --SendUpdates:all --Credentials:my-google-creds}}"
}
```

## Parameters

### Calendar Id (CalendarId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Unique identifier of the calendar that contains the event to delete.
Defaults to 'primary' when not provided, targeting the authenticated user's primary calendar.
Any valid calendar identifier is accepted, including secondary calendar IDs in email-address format.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Stored credential record id or name used to obtain a fresh access token.
Avoids hardcoding tokens by exchanging the stored refresh token for a new access token when needed.
Use when access tokens may expire between steps.
Takes precedence over the Token parameter when both are provided.

### Event Id (EventId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Unique identifier of the event to delete.
Use the id returned by NewGoogleCalendarEvent or retrieved from the Calendar API.

### Send Updates (SendUpdates)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Controls whether cancellation emails are sent to attendees when the event is deleted.
Accepted values: 'all' (notify all attendees), 'externalOnly' (notify only external attendees), 'none' (send no notifications).
Defaults to 'none' to avoid sending spurious emails during automated runs.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

OAuth Bearer access token used to call the Google Calendar API.
Used when no stored credential record is available.
Ignored when Credentials is provided.

## Scope

* Any
