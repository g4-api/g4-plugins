# New Google Calendar Event (NewGoogleCalendarEvent)

[Table of Content](../Home.md)

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Creates a new event on a Google Calendar.
Schedules meetings, blocks time, or records events from automation workflows.
Supports timed events (ISO 8601 dateTime) and all-day events (YYYY-MM-DD date), optional attendees with invitation notifications, and per-timezone start and end times.
Authenticates via a direct OAuth access token or a stored credentials reference exchanged for a fresh token.
Key event fields from the API response are stored in session parameters for downstream access.

### Key Features and Functionality

| Feature                    | Description                                                                                                              |
| --- | --- |
| Create timed event         | Creates an event with an ISO 8601 dateTime start and end.                                                                |
| Create all-day event       | Creates an all-day event using YYYY-MM-DD date values for start and end.                                                 |
| Calendar targeting         | Targets any accessible calendar by CalendarId; defaults to the authenticated user's primary calendar.                   |
| Attendee invitations       | Accepts a comma-separated list of attendee emails and controls notification delivery via SendUpdates.                    |
| Time zone support          | Accepts an IANA time zone identifier for start and end independently.                                                    |
| Token authentication       | Accepts a raw OAuth Bearer access token.                                                                                 |
| Credentials authentication | Accepts a credentials id/name and exchanges it for a fresh access token.                                                 |
| Result session storage     | Stores created event fields in namespaced session parameters (NewGoogleCalendarEvent:) as Base64-encoded values.         |

### Usages in RPA

| Use Case                              | Description                                                                                       |
| --- | --- |
| Schedule automated follow-ups         | Create a calendar event when a form submission or lead is detected.                               |
| Block focus time automatically        | Add focus or out-of-office blocks to a calendar based on workload thresholds.                     |
| Sync external events to Google        | Mirror events from an external system into a shared Google Calendar.                              |
| Send meeting invitations from bots    | Create meetings with attendees and send invitations directly from automation workflows.            |
| Record SLA deadlines                  | Create an all-day event on the day a deadline is due.                                             |

## Examples

### Example No.1

### NewGoogleCalendarEvent: Create minimal timed event using access token

Create a timed event on the primary calendar by supplying Start and End in ISO 8601 dateTime format and a direct OAuth Bearer token.
CalendarId defaults to 'primary' so no explicit calendar targeting is needed.
NewGoogleCalendarEvent:Id, NewGoogleCalendarEvent:HtmlLink, NewGoogleCalendarEvent:Status, and NewGoogleCalendarEvent:HangoutLink are stored as session parameters for downstream steps.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleCalendarEvent",
    Argument = "{{$ --Start:2026-05-01T10:00:00Z --End:2026-05-01T11:00:00Z --Summary:Team Standup --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleCalendarEvent")
    .setArgument("{{$ --Start:2026-05-01T10:00:00Z --End:2026-05-01T11:00:00Z --Summary:Team Standup --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleCalendarEvent",
    argument: "{{$ --Start:2026-05-01T10:00:00Z --End:2026-05-01T11:00:00Z --Summary:Team Standup --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --Start:2026-05-01T10:00:00Z --End:2026-05-01T11:00:00Z --Summary:Team Standup --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --Start:2026-05-01T10:00:00Z --End:2026-05-01T11:00:00Z --Summary:Team Standup --Token:ya29...}}"
}
```

### Example No.2

### NewGoogleCalendarEvent: Create full event with attendees using stored credentials

Create a timed event on a secondary calendar with explicit IANA time zones, attendee emails, and immediate invitation delivery.
Stored credentials are exchanged at runtime for a fresh OAuth access token, avoiding hardcoded token expiry issues.
NewGoogleCalendarEvent:Id, NewGoogleCalendarEvent:HtmlLink, NewGoogleCalendarEvent:Status, and NewGoogleCalendarEvent:HangoutLink are stored in session parameters after the event is created.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleCalendarEvent",
    Argument = "{{$ --CalendarId:team@group.calendar.google.com --Summary:Sprint Review --Description:End of sprint demo --Location:Conference Room A --Start:2026-05-15T14:00:00 --End:2026-05-15T15:00:00 --StartTimeZone:America/New_York --EndTimeZone:America/New_York --Attendees:alice@example.com,bob@example.com --SendUpdates:all --Credentials:my-google-creds}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleCalendarEvent")
    .setArgument("{{$ --CalendarId:team@group.calendar.google.com --Summary:Sprint Review --Description:End of sprint demo --Location:Conference Room A --Start:2026-05-15T14:00:00 --End:2026-05-15T15:00:00 --StartTimeZone:America/New_York --EndTimeZone:America/New_York --Attendees:alice@example.com,bob@example.com --SendUpdates:all --Credentials:my-google-creds}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleCalendarEvent",
    argument: "{{$ --CalendarId:team@group.calendar.google.com --Summary:Sprint Review --Description:End of sprint demo --Location:Conference Room A --Start:2026-05-15T14:00:00 --End:2026-05-15T15:00:00 --StartTimeZone:America/New_York --EndTimeZone:America/New_York --Attendees:alice@example.com,bob@example.com --SendUpdates:all --Credentials:my-google-creds}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --CalendarId:team@group.calendar.google.com --Summary:Sprint Review --Description:End of sprint demo --Location:Conference Room A --Start:2026-05-15T14:00:00 --End:2026-05-15T15:00:00 --StartTimeZone:America/New_York --EndTimeZone:America/New_York --Attendees:alice@example.com,bob@example.com --SendUpdates:all --Credentials:my-google-creds}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --CalendarId:team@group.calendar.google.com --Summary:Sprint Review --Description:End of sprint demo --Location:Conference Room A --Start:2026-05-15T14:00:00 --End:2026-05-15T15:00:00 --StartTimeZone:America/New_York --EndTimeZone:America/New_York --Attendees:alice@example.com,bob@example.com --SendUpdates:all --Credentials:my-google-creds}}"
}
```

### Example No.3

### NewGoogleCalendarEvent: Create all-day event using access token

Create an all-day event by supplying date-only Start and End values in YYYY-MM-DD format.
When neither value contains 'T', the plugin sends a date field instead of dateTime, producing a full-day block on the calendar.
End is set to the day after the event day because Google Calendar all-day end dates are exclusive.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "NewGoogleCalendarEvent",
    Argument = "{{$ --Start:2026-06-01 --End:2026-06-02 --Summary:Company Holiday --Token:ya29...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("NewGoogleCalendarEvent")
    .setArgument("{{$ --Start:2026-06-01 --End:2026-06-02 --Summary:Company Holiday --Token:ya29...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "NewGoogleCalendarEvent",
    argument: "{{$ --Start:2026-06-01 --End:2026-06-02 --Summary:Company Holiday --Token:ya29...}}"
};
```

**JSON:**

```js
{
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --Start:2026-06-01 --End:2026-06-02 --Summary:Company Holiday --Token:ya29...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "NewGoogleCalendarEvent",
    "argument": "{{$ --Start:2026-06-01 --End:2026-06-02 --Summary:Company Holiday --Token:ya29...}}"
}
```

## Output Parameter

### New Google Calendar Event Hangout Link (NewGoogleCalendarEvent:HangoutLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the Google Meet or Hangouts video conference link for the created event.
Present only when the event has a conference resource attached by the Calendar API.

### New Google Calendar Event Html Link (NewGoogleCalendarEvent:HtmlLink)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the absolute URL to view the created event in the Google Calendar web UI.
Use it to share or log a direct link to the event.

### New Google Calendar Event Id (NewGoogleCalendarEvent:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the unique identifier of the created event as returned by the Google Calendar API.
Use it to target the event for updates, exports, or deletion.

### New Google Calendar Event Status (NewGoogleCalendarEvent:Status)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the status of the created event as returned by the Google Calendar API.
Possible values are 'confirmed', 'tentative', and 'cancelled'.
Use it to branch on the initial event state.

## Parameters

### Attendees (Attendees)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Comma-separated list of email addresses added as attendees to the event.
Each email address is mapped to an attendee entry in the event resource.
Use the SendUpdates parameter to control whether invitation emails are delivered to attendees.

### Calendar Id (CalendarId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Unique identifier of the calendar on which the event will be created.
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

### Description (Description)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Event description. HTML content is supported by the Google Calendar API.
Adds context, agenda items, or instructions visible in the event details.
Omitted from the API request body when left empty.

### End (End)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

End date or date-time of the event.
Use ISO 8601 format (e.g., 2026-05-01T11:00:00Z) for timed events.
Use YYYY-MM-DD format (e.g., 2026-05-02) for all-day events — the value must not contain 'T'.

### End Time Zone (EndTimeZone)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

IANA time zone identifier applied to the End dateTime (e.g., 'America/New_York').
When omitted, the calendar's default time zone is used.
Has no effect when End is a date-only value (all-day event).

### Location (Location)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Geographic location of the event as free-form text.
Displayed in the event details and used by Google Calendar to show map links.
Omitted from the API request body when left empty.

### Send Updates (SendUpdates)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Controls whether notification emails are sent to attendees when the event is created.
Accepted values: 'all' (notify all attendees), 'externalOnly' (notify only external attendees), 'none' (send no notifications).
Defaults to 'none' to avoid sending spurious emails during automated runs.

### Start (Start)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Start date or date-time of the event.
Use ISO 8601 format (e.g., 2026-05-01T10:00:00Z) for timed events.
Use YYYY-MM-DD format (e.g., 2026-05-01) for all-day events — the value must not contain 'T'.

### Start Time Zone (StartTimeZone)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

IANA time zone identifier applied to the Start dateTime (e.g., 'Europe/London').
When omitted, the calendar's default time zone is used.
Has no effect when Start is a date-only value (all-day event).

### Summary (Summary)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

The event title.
Controls how the event appears in the calendar UI.
Uses a timestamped default title when no value is provided to avoid creating untitled events.

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
