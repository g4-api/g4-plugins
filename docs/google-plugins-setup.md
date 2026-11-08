# Google Plugins Setup

[Home](./Home.md)

This page explains what you need before the 17 Google plugins can call Google. Every fact below comes from the plugin code in `src/G4.Plugins.Google` and the credentials code in the G4 engine. Where the code does not say, the page says so.

## What the plugins do

| API | Plugins | Calls made (from `Clients/*.cs`) |
| --- | --- | --- |
| Google Calendar | [ExportGoogleCalendar](./Actions/ExportGoogleCalendar.md), [ExportGoogleCalendarList](./Actions/ExportGoogleCalendarList.md), [NewGoogleCalendarEvent](./Actions/NewGoogleCalendarEvent.md), [RemoveGoogleCalendarEvent](./Actions/RemoveGoogleCalendarEvent.md) | `https://www.googleapis.com/calendar/v3` (`calendarList`, `calendars/{id}`, `calendars/{id}/events`) |
| Gmail | [ReadGmailMessage](./Actions/ReadGmailMessage.md), [EditGmailMessage](./Actions/EditGmailMessage.md), [SendGmailMessage](./Actions/SendGmailMessage.md), [SendGmailMessageReply](./Actions/SendGmailMessageReply.md) | `https://gmail.googleapis.com/gmail/v1` (`users/me/messages`, `messages/send`, `messages/{id}/modify`, `labels`) |
| Google Tasks | [ExportGoogleTaskLists](./Actions/ExportGoogleTaskLists.md), [ExportGoogleTasks](./Actions/ExportGoogleTasks.md), [MoveGoogleTask](./Actions/MoveGoogleTask.md), [NewGoogleTask](./Actions/NewGoogleTask.md), [NewGoogleTaskList](./Actions/NewGoogleTaskList.md), [RemoveGoogleTask](./Actions/RemoveGoogleTask.md), [RemoveGoogleTaskList](./Actions/RemoveGoogleTaskList.md), [UpdateGoogleTask](./Actions/UpdateGoogleTask.md), [UpdateGoogleTaskList](./Actions/UpdateGoogleTaskList.md) | `https://tasks.googleapis.com/tasks/v1` (`lists/{list}/tasks`, `users/@me/lists`) |

Source: `src/G4.Plugins.Google/Clients/ClientBase.cs:30-40`, `CalendarAdapter.cs`, `GmailAdapter.cs`, `TasksAdapter.cs`.

## Two ways to authenticate

Every Google plugin takes two optional parameters. Give one of them.

| Parameter | What you pass | When to use it |
| --- | --- | --- |
| `Credentials` | The name or id of a stored credential record | Long runs and repeat runs. The plugin swaps the stored refresh token for a fresh access token each time it calls Google. |
| `Token` | A raw OAuth access token | Quick tests. The token is short-lived, so the run stops working when it expires. |

If you pass both, `Credentials` wins and `Token` is ignored. Source: `Extensions/LocalExtensions.cs:415-423`.

When the plugin gets a `Credentials` value that matches no stored record by name or id, it treats the value as a raw access token. A misspelled credential name therefore fails later as a rejected token, not as "credential not found". Source: `Clients/ClientBase.cs:90-104`.

## What you need before you start

1. A Google Cloud project with the Calendar, Gmail or Tasks API turned on for the APIs you plan to use. The code calls those three APIs and nothing else.
2. An OAuth client in that project. You need its client id and client secret.
3. A redirect URL registered on that OAuth client. G4 sends your `redirectUrl` to Google unchanged, so the value in Google Cloud and the value you give G4 must match. Source: `g4-engine/src/G4.Credentials/CredentialsManager.cs:606-626`.
4. A running G4 Hub. The Hub stores the credential and receives the Google callback. See the [Credentials API](https://github.com/g4-api/g4-services/blob/main/docs/rest-api/credentials.md).
5. The OAuth scopes for the API calls you make. The code does not choose scopes for you. You pass them in the `scope` field when you create the credential. A scope that is too narrow shows up as "Insufficient OAuth scopes" in the plugin pages' error lists.

## Create a stored credential

The flow has three steps: create, consent, callback. The engine uses the `google` provider key and the token address `https://oauth2.googleapis.com/token`. Source: `CredentialsManager.cs:68-71`.

1. Create the credential. Replace the angle-bracket values.

    ```bash
    curl -X POST "http://localhost:9944/api/v4/g4/credentials/oauth/google" \
        -H "Content-Type: application/json" \
        -d '{"name": "my-google-creds", "clientId": "<client-id>", "clientSecret": "<client-secret>", "redirectUrl": "http://localhost:9944/api/v4/g4/credentials/callback", "scope": "<scope-1>,<scope-2>"}'
    ```

    The `scope` and `domains` fields take a comma-separated list. G4 turns the commas into spaces and removes duplicates. Source: `CredentialsManager.cs:164-172`.

2. Read `consentUrl` from the response and open it in a browser. G4 builds it with `access_type=offline` and `prompt=consent`, so Google returns a refresh token. Source: `CredentialsManager.cs:606-626`.
3. Approve access. Google sends the browser to your redirect URL with `code` and `state`. When the redirect URL is the Hub callback route, the Hub finishes the exchange for you: it checks the state, trades the code for tokens and saves the record. Source: `CredentialsManager.cs:234-284`.
4. Check that the record exists.

    ```bash
    curl "http://localhost:9944/api/v4/g4/credentials/my-google-creds"
    ```

Only the fields you need are described here. The full model is `OAuthCredentialModel` in `g4-engine/src/G4.Credentials/Models/OAuthCredentialModel.cs`: `name`, `clientId`, `clientSecret`, `redirectUrl` and `scope` are the ones you set.

## Use the credential in a rule

Pass the credential name as `--Credentials`.

```json
{
    "$type": "Action",
    "pluginName": "ExportGoogleTasks",
    "argument": "{{$ --TaskList:task-list-id --credentials:my-google-creds}}"
}
```

The same shape appears on the [ExportGoogleTasks](./Actions/ExportGoogleTasks.md) page.

## Verify

1. Run a read-only plugin first, such as [ExportGoogleTaskLists](./Actions/ExportGoogleTaskLists.md) or [ExportGoogleCalendarList](./Actions/ExportGoogleCalendarList.md).
2. Open the session parameters of the run. The plugin writes its result to a parameter named after the plugin, for example `ExportGoogleTasks:Result`, as Base64-encoded JSON.

## If it fails

The plugin pages list the failure cases each plugin expects. These are the ones that point back to setup:

| Symptom | Likely cause | What to do |
| --- | --- | --- |
| Google answers 401 | The `Token` expired, or a misspelled `Credentials` name was sent as a raw token | Use a stored credential, and check the name with the `GET` call above. |
| The stored record has no refresh token | The consent step was skipped or did not finish | Create the credential again and complete the consent step. |
| "Insufficient OAuth scopes" | The credential was created without the scope the call needs | Create a new credential with the right scopes. |
| Google rejects the redirect | The redirect URL in Google Cloud differs from the one in the credential | Make the two values identical. |
| Token exchange fails | Wrong client id or secret | Check both values on the OAuth client. |

## Good to know

- The credential store keeps the client secret, the access token and the refresh token in the engine's credentials database. The values are protected with a fixed key compiled into the engine, so treat that database as sensitive. Source: `g4-engine/src/G4.Credentials/Extensions/PublicExtensions.cs:15-70`.
- TODO(verify): the exact Google scope string each plugin needs. The code never sets one, and the manifests only say the scopes must be sufficient. Check Google's API reference for the methods listed in the table at the top.
- The Google plugin pages are generated by `src/G4.DocumentsGenerator`. See the note at the top of [Home](./Home.md).
