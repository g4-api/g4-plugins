# Export Google Calendar (ExportGoogleCalendar)

[Table of Content](../Home.md)

~15 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The ExportGoogleCalendar plugin retrieves a single calendar entry from the Google Calendar API by its unique identifier.
It targets the authenticated user's primary calendar by default when no CalendarId is specified, or fetches any accessible calendar when a CalendarId is provided.
The plugin supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
All properties of the retrieved calendar are exposed on the response entity, and the calendar Id is stored in a session parameter for downstream workflow steps.

### Key Features and Functionality

| Feature                    | Description                                                                                                   |
| --- | --- |
| Single Calendar Export     | Retrieves a single calendar entry from the Google Calendar API by its unique identifier.                      |
| Primary Calendar Default   | Defaults CalendarId to 'primary' when not specified, targeting the authenticated user's primary calendar.     |
| Token Authentication       | Accepts a direct OAuth Bearer access token for API access.                                                    |
| Credentials Authentication | Uses a stored credential record to generate a fresh access token at runtime.                                  |
| Response Entity Population | Exposes all CalendarListEntryModel properties on the response entity for downstream access.                   |
| Session Parameter Storage  | Stores the retrieved calendar's Id in the ExportGoogleCalendar:Id session parameter for later workflow steps. |

### Usages in RPA

| Use Case                   | Description                                                                                                          |
| --- | --- |
| Retrieve Primary Calendar  | Fetch the authenticated user's primary calendar to read its Id or metadata for downstream workflow use.              |
| Retrieve Specific Calendar | Supply a known calendar identifier to read metadata for a secondary or shared calendar.                              |
| Capture Calendar Id        | Use ExportGoogleCalendar:Id to pass the calendar identifier to subsequent workflow steps without repeating the call. |
| Verify Calendar Existence  | Attempt to retrieve a calendar by CalendarId to confirm it is accessible before using it in further operations.      |
| Read Calendar Time Zone    | Access the TimeZone entity property to determine the calendar's configured time zone for scheduling logic.           |
| Read Calendar Access Role  | Access the AccessRole entity property to confirm the authenticated user's permission level on the calendar.          |

## Examples

### Example No.1

### ExportGoogleCalendar: Export primary calendar using access token

Retrieve the authenticated user's primary Google Calendar entry using a direct OAuth access token.
CalendarId is omitted so the plugin defaults to 'primary', resolving to the user's primary calendar.
The calendar's Id is stored in ExportGoogleCalendar:Id and all calendar properties are available on the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendar",
    Argument = "{{$ --Token:ya29.A0...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendar")
    .setArgument("{{$ --Token:ya29.A0...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendar",
    argument: "{{$ --Token:ya29.A0...}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Token:ya29.A0...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Token:ya29.A0...}}"
}
```

### Example No.2

### ExportGoogleCalendar: Export specific calendar using stored credentials

Retrieve a specific Google Calendar entry by supplying its unique identifier as CalendarId.
Resolve a stored credentials reference at runtime to obtain an OAuth access token before calling the API.
The calendar's Id is stored in ExportGoogleCalendar:Id and all calendar properties are available on the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendar",
    Argument = "{{$ --Credentials:my-google-creds --CalendarId:example@group.calendar.google.com}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendar")
    .setArgument("{{$ --Credentials:my-google-creds --CalendarId:example@group.calendar.google.com}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendar",
    argument: "{{$ --Credentials:my-google-creds --CalendarId:example@group.calendar.google.com}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Credentials:my-google-creds --CalendarId:example@group.calendar.google.com}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Credentials:my-google-creds --CalendarId:example@group.calendar.google.com}}"
}
```

### Example No.3

### ExportGoogleCalendar: Export specific calendar using access token

Retrieve a specific Google Calendar entry by supplying both a direct OAuth access token and an explicit CalendarId.
This demonstrates token-based authentication targeting a non-default calendar, covering the combination not shown in the other examples.
The calendar's Id is stored in ExportGoogleCalendar:Id and all calendar properties are available on the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendar",
    Argument = "{{$ --Token:ya29.A0... --CalendarId:example@group.calendar.google.com}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendar")
    .setArgument("{{$ --Token:ya29.A0... --CalendarId:example@group.calendar.google.com}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendar",
    argument: "{{$ --Token:ya29.A0... --CalendarId:example@group.calendar.google.com}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Token:ya29.A0... --CalendarId:example@group.calendar.google.com}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendar",
    "argument": "{{$ --Token:ya29.A0... --CalendarId:example@group.calendar.google.com}}"
}
```

## Output Parameter

### Export Google Calendar Id (ExportGoogleCalendar:Id)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the unique identifier of the calendar retrieved by the Google Calendar API.
Set from the Id property of the CalendarListEntryModel returned by the API call.
Allows later workflow steps to reference the calendar identifier without repeating the API call.

## Parameters

### Calendar Id (CalendarId)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the unique identifier of the calendar to retrieve from the Google Calendar API.
Defaults to 'primary' when not provided, which resolves to the authenticated user's primary calendar.
Accepts any valid calendar identifier, including secondary calendar IDs in email-address format.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies the identifier or name of a stored credential record used to obtain an OAuth access token at runtime.
Avoids hard-coding short-lived access tokens by exchanging stored credentials for a fresh token when needed.
Takes precedence over the Token parameter when both are provided so authentication remains consistent and renewable.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies an OAuth Bearer access token used to authenticate requests to the Google Calendar API.
Allows direct API access without retrieving credentials from a stored record.
Is ignored when the Credentials parameter is supplied because stored credentials take precedence.

## Scope

* Any
