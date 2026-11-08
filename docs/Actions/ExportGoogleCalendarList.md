# Export Google Calendar List (ExportGoogleCalendarList)

[Table of Content](../Home.md)

~16 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

The ExportGoogleCalendarList plugin retrieves the authenticated user's list of calendars from the Google Calendar API.
It helps automation workflows discover, filter, and reference calendars without opening the Google Calendar interface.
The plugin supports authentication using either a direct OAuth access token or a stored credentials reference that is exchanged for a fresh token at runtime.
The exported calendar list is stored as JSON in a session parameter so later workflow steps can safely access calendar ids and metadata.

### Key Features and Functionality

| Feature                     | Description                                                                                    |
| --- | --- |
| Export Calendar List        | Retrieves all calendars on the authenticated user's calendar list via the Google Calendar API. |
| Access Role Filtering       | Filters results by minimum access role: freeBusyReader, owner, reader, or writer.              |
| Page Size Control           | Limits the number of entries returned per page using MaxResults (1–250, default 100).          |
| Pagination Support          | Accepts a PageToken to retrieve a specific page of results from a previous request.            |
| Show Deleted Entries        | Includes deleted calendar list entries in the response when ShowDeleted is present.            |
| Show Hidden Entries         | Includes hidden calendar list entries in the response when ShowHidden is present.              |
| Incremental Synchronization | Accepts a SyncToken to retrieve only entries that changed since the token was issued.          |
| Token Authentication        | Accepts a direct OAuth Bearer access token for API access.                                     |
| Credentials Authentication  | Uses a stored credential record to generate a fresh access token at runtime.                   |
| Session Result Storage      | Saves the full API response as JSON in the ExportGoogleCalendarList:Result session parameter.  |

### Usages in RPA

| Use Case                      | Description                                                                                       |
| --- | --- |
| Discover Calendars            | Retrieve all calendars so later steps can locate the correct calendar by id or summary.           |
| Role-Based Calendar Selection | Filter calendars by access role to find only those the user owns or has write access to.          |
| Paged Calendar Export         | Use MaxResults and PageToken to iterate over large calendar lists in controlled pages.            |
| Incremental Calendar Sync     | Pass a stored SyncToken to fetch only calendars changed since the last export, reducing API load. |
| Hidden and Deleted Auditing   | Enable ShowDeleted and ShowHidden to include all entries in auditing or compliance workflows.     |

## Examples

### Example No.1

### ExportGoogleCalendarList: Export using access token

Retrieve the authenticated user's full Google Calendar list using an OAuth access token with default options.
Store the returned JSON in the ExportGoogleCalendarList:Result session parameter.
A macro token produces a runtime token value that is substituted where the token appears, and ExportGoogleCalendarList uses that substituted value to authorize the API request.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendarList",
    Argument = "{{$ --Token:ya29.A0...}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendarList")
    .setArgument("{{$ --Token:ya29.A0...}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendarList",
    argument: "{{$ --Token:ya29.A0...}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Token:ya29.A0...}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Token:ya29.A0...}}"
}
```

### Example No.2

### ExportGoogleCalendarList: Export with access role filter and page size

Retrieve up to 25 Google Calendar entries for which the authenticated user holds at least writer access.
Resolve a stored credentials reference at runtime to obtain an OAuth access token before calling the API.
Store the filtered calendar list JSON in the ExportGoogleCalendarList:Result session parameter.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendarList",
    Argument = "{{$ --Credentials:my-google-creds --MaxResults:25 --MinAccessRole:writer}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendarList")
    .setArgument("{{$ --Credentials:my-google-creds --MaxResults:25 --MinAccessRole:writer}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendarList",
    argument: "{{$ --Credentials:my-google-creds --MaxResults:25 --MinAccessRole:writer}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Credentials:my-google-creds --MaxResults:25 --MinAccessRole:writer}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Credentials:my-google-creds --MaxResults:25 --MinAccessRole:writer}}"
}
```

### Example No.3

### ExportGoogleCalendarList: Incremental sync with ShowDeleted and ShowHidden

Retrieve only Google Calendar list entries that changed since a previously stored sync token was issued.
Enable ShowDeleted and ShowHidden so deleted and hidden calendar entries are included in the delta response.
Store the incremental result in the ExportGoogleCalendarList:Result session parameter and extract NextSyncToken from the response for use in the next sync cycle.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportGoogleCalendarList",
    Argument = "{{$ --Credentials:my-google-creds --SyncToken:CPDAleLjy... --ShowDeleted --ShowHidden}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportGoogleCalendarList")
    .setArgument("{{$ --Credentials:my-google-creds --SyncToken:CPDAleLjy... --ShowDeleted --ShowHidden}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportGoogleCalendarList",
    argument: "{{$ --Credentials:my-google-creds --SyncToken:CPDAleLjy... --ShowDeleted --ShowHidden}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Credentials:my-google-creds --SyncToken:CPDAleLjy... --ShowDeleted --ShowHidden}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportGoogleCalendarList",
    "argument": "{{$ --Credentials:my-google-creds --SyncToken:CPDAleLjy... --ShowDeleted --ShowHidden}}"
}
```

## Output Parameter

### Export Google Calendar List Result (ExportGoogleCalendarList:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the full Google Calendar list response returned by the Google Calendar API.
Contains a JSON-serialized CalendarListModel including ETag, Kind, Items (calendar entries with id, summary, accessRole, and metadata), NextPageToken, and NextSyncToken.
Allows later workflow steps to extract specific calendar ids, enumerate available calendars, or persist the NextSyncToken for incremental synchronization without repeating the API call.

## Parameters

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

### Max Results (MaxResults)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number|Expression |

Sets the maximum number of calendar list entries returned on a single result page.
Accepts integer values from 1 to 250; the default is 100 when the parameter is not specified.
Helps control API response size and memory usage when a user has many calendars.

### Min Access Role (MinAccessRole)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Filters the calendar list to entries where the authenticated user holds at least the specified access role.
Accepted values are freeBusyReader, owner, reader, and writer.
Cannot be combined with SyncToken; the Google Calendar API will return an error if both parameters are specified.

### Page Token (PageToken)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Specifies a token returned by a previous calendar list request that identifies the next page of results.
Enables pagination through large calendar lists by continuing from where the previous request left off.
Omit this parameter to start from the first page of results.

### Show Deleted (ShowDeleted)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Instructs the plugin to include deleted calendar list entries in the response when present.
Activated by the presence of the parameter key; no value is required.
Useful for auditing workflows that need to detect calendars removed from the user's list, and required alongside ShowHidden when using SyncToken.

### Show Hidden (ShowHidden)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Instructs the plugin to include hidden calendar list entries in the response when present.
Activated by the presence of the parameter key; no value is required.
Required alongside ShowDeleted when using SyncToken so that hidden entries changed since the last sync are captured in the delta.

### Sync Token (SyncToken)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the nextSyncToken value returned by a previous calendar list response to enable incremental synchronization.
When supplied, the API returns only entries that changed since the token was issued, reducing data volume and API load.
Cannot be combined with MinAccessRole. If the token has expired, the API returns 410 GONE and a full re-sync without SyncToken is required.

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
