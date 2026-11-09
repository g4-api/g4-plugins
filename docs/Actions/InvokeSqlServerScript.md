# Invoke Sql Server Script (InvokeSqlServerScript)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a multi-batch SQL Server script, split on GO separator lines the same way sqlcmd splits it.
Runs deployment, migration, and seeding scripts from a .sql file or inline text, optionally inside one transaction.
Reports how many batches ran and how many rows changed so later steps can confirm the result.

### Key Features and Functionality

| Feature              | Description                                                                                          |
| --- | --- |
| Batch splitting      | Splits the script on lines that hold only `GO` or `GO n`, in any letter case.                        |
| Batch repetition     | Runs the preceding batch `n` times for a `GO n` separator.                                            |
| Script sources       | Reads the script from `CommandText`, Base64 `CommandText` with `Base64`, or the UTF-8 `CommandFile`. |
| Ordered execution    | Runs batches in script order on one connection and stops at the first failing batch.                  |
| Optional transaction | Commits after the last batch or rolls back every batch on failure when `Transaction` is present.      |
| Per-batch timeout    | Applies `CommandTimeout` to each batch separately.                                                   |
| Run totals           | Returns `BatchCount` and the summed `RowsAffected`.                                                  |
| Flexible connection  | Connects through a credentials record, a connection string, discrete values, or a Microsoft Entra token. |
| Entity control       | Omits the response entity when `NoEntity` is present while still writing session parameters.         |

### Usages in RPA

| Use Case                  | Description                                                                         |
| --- | --- |
| Deploy database changes   | Apply versioned schema scripts with `GO` separators as one transactional step.       |
| Load reference data       | Run seeding scripts that insert lookup values before a business process starts.     |
| Run maintenance scripts   | Execute cleanup or index maintenance scripts on a schedule.                          |
| Reuse existing SSMS files | Run scripts written for SQL Server Management Studio or sqlcmd without editing them. |

### Usages in Automation Testing

| Use Case                | Description                                                                        |
| --- | --- |
| Build a test database   | Create tables, views, and seed rows before a test suite runs.                      |
| Reset test data         | Truncate and reload tables between test runs to keep results repeatable.           |
| Generate load data      | Repeat an insert batch with `GO n` to create many rows for volume tests.           |
| Verify migration safety | Run a migration with `Transaction` and confirm that a failure leaves no changes.   |

### Batch Splitting

- A separator is a line that holds only `GO`, optionally followed by a repeat count, such as `GO 3`.
- `GO` is not case sensitive and may have surrounding spaces, but a separator line cannot hold other text or a comment.
- `GO n` runs the preceding batch `n` times, and each repetition counts toward `BatchCount`.
- Splitting is line based like sqlcmd, so a `GO` line inside a block comment or a multi-line string is still a separator.
- Batches that hold only white space are skipped, and sqlcmd commands such as `:setvar` or `:r` are not supported.
- With the `Base64` switch, `CommandText` is decoded from UTF-8 Base64 first and then split the same way.

### Connection Resolution

1. `Credentials` selects a stored SQL Server credentials record by name or id.
2. When no record matches, a `Credentials` value that contains `=` is used as a raw connection string, and any other value is used as a raw Microsoft Entra access token.
3. Without `Credentials`, `ConnectionString` supplies the baseline connection.
4. `Server`, `Port`, `Database`, `Authentication`, `Username`, `Password`, `Encrypt`, `TrustServerCertificate`, and `Token` override the baseline values they set.
5. The step fails when no server is resolved.

Session parameters are named `InvokeSqlServerScript:<Name>` and are Base64-encoded, so decode them before use.

## Examples

### Example No.1

### Deploy a script file in one transaction

Runs C:\Scripts\deploy.sql through the stored credentials record sql-production, batch by batch in script order.
Transaction commits after the last batch succeeds and rolls back every batch when one fails.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerScript",
    Argument = "{{$ --CommandFile:C:\Scripts\deploy.sql --Credentials:sql-production --Transaction --CommandTimeout:120}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerScript")
    .setArgument("{{$ --CommandFile:C:\Scripts\deploy.sql --Credentials:sql-production --Transaction --CommandTimeout:120}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerScript",
    argument: "{{$ --CommandFile:C:\Scripts\deploy.sql --Credentials:sql-production --Transaction --CommandTimeout:120}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --CommandFile:C:\Scripts\deploy.sql --Credentials:sql-production --Transaction --CommandTimeout:120}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --CommandFile:C:\Scripts\deploy.sql --Credentials:sql-production --Transaction --CommandTimeout:120}}"
}
```

### Example No.2

### Repeat an inline batch with a raw connection string

Creates dbo.LoadProbe when missing, then repeats a single-row insert five times with a `GO 5` separator.
The Credentials value is a raw connection string to localhost,1433, and NoEntity omits the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerScript",
    Argument = "{{$ --Credentials:Server=localhost,1433;Database=QaSandbox;Integrated Security=true;TrustServerCertificate=true --CommandText:IF OBJECT_ID(N'dbo.LoadProbe') IS NULL CREATE TABLE dbo.LoadProbe (Id INT IDENTITY PRIMARY KEY, CreatedAt DATETIME2 NOT NULL);
GO
INSERT INTO dbo.LoadProbe (CreatedAt) VALUES (SYSUTCDATETIME());
GO 5 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerScript")
    .setArgument("{{$ --Credentials:Server=localhost,1433;Database=QaSandbox;Integrated Security=true;TrustServerCertificate=true --CommandText:IF OBJECT_ID(N'dbo.LoadProbe') IS NULL CREATE TABLE dbo.LoadProbe (Id INT IDENTITY PRIMARY KEY, CreatedAt DATETIME2 NOT NULL);
GO
INSERT INTO dbo.LoadProbe (CreatedAt) VALUES (SYSUTCDATETIME());
GO 5 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerScript",
    argument: "{{$ --Credentials:Server=localhost,1433;Database=QaSandbox;Integrated Security=true;TrustServerCertificate=true --CommandText:IF OBJECT_ID(N'dbo.LoadProbe') IS NULL CREATE TABLE dbo.LoadProbe (Id INT IDENTITY PRIMARY KEY, CreatedAt DATETIME2 NOT NULL);
GO
INSERT INTO dbo.LoadProbe (CreatedAt) VALUES (SYSUTCDATETIME());
GO 5 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --Credentials:Server=localhost,1433;Database=QaSandbox;Integrated Security=true;TrustServerCertificate=true --CommandText:IF OBJECT_ID(N'dbo.LoadProbe') IS NULL CREATE TABLE dbo.LoadProbe (Id INT IDENTITY PRIMARY KEY, CreatedAt DATETIME2 NOT NULL);
GO
INSERT INTO dbo.LoadProbe (CreatedAt) VALUES (SYSUTCDATETIME());
GO 5 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --Credentials:Server=localhost,1433;Database=QaSandbox;Integrated Security=true;TrustServerCertificate=true --CommandText:IF OBJECT_ID(N'dbo.LoadProbe') IS NULL CREATE TABLE dbo.LoadProbe (Id INT IDENTITY PRIMARY KEY, CreatedAt DATETIME2 NOT NULL);
GO
INSERT INTO dbo.LoadProbe (CreatedAt) VALUES (SYSUTCDATETIME());
GO 5 --NoEntity}}"
}
```

### Example No.3

### Run a Base64-encoded two-batch script with comments

The argument binds the stored credentials record sql-production, a Base64 CommandText, and the Base64 and Transaction switches.
The decoded script creates dbo.DeployLog when missing and then inserts one row, with a ` --` comment after each statement and a GO line closing each batch.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerScript",
    Argument = "{{$ --Credentials:sql-production --CommandText:SUYgT0JKRUNUX0lEKE4nZGJvLkRlcGxveUxvZycpIElTIE5VTEwgQ1JFQVRFIFRBQkxFIGRiby5EZXBsb3lMb2cgKElkIElOVCBJREVOVElUWSBQUklNQVJZIEtFWSwgTm90ZSBOVkFSQ0hBUigxMDApIE5PVCBOVUxMKTsgLS0gZmlyc3QgYmF0Y2ggY3JlYXRlcyB0aGUgdGFibGUKR08KSU5TRVJUIElOVE8gZGJvLkRlcGxveUxvZyAoTm90ZSkgVkFMVUVTIChOJ1NjcmlwdCBhcHBsaWVkJyk7IC0tIHNlY29uZCBiYXRjaCByZWNvcmRzIHRoZSBydW4KR08= --Base64 --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerScript")
    .setArgument("{{$ --Credentials:sql-production --CommandText:SUYgT0JKRUNUX0lEKE4nZGJvLkRlcGxveUxvZycpIElTIE5VTEwgQ1JFQVRFIFRBQkxFIGRiby5EZXBsb3lMb2cgKElkIElOVCBJREVOVElUWSBQUklNQVJZIEtFWSwgTm90ZSBOVkFSQ0hBUigxMDApIE5PVCBOVUxMKTsgLS0gZmlyc3QgYmF0Y2ggY3JlYXRlcyB0aGUgdGFibGUKR08KSU5TRVJUIElOVE8gZGJvLkRlcGxveUxvZyAoTm90ZSkgVkFMVUVTIChOJ1NjcmlwdCBhcHBsaWVkJyk7IC0tIHNlY29uZCBiYXRjaCByZWNvcmRzIHRoZSBydW4KR08= --Base64 --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerScript",
    argument: "{{$ --Credentials:sql-production --CommandText:SUYgT0JKRUNUX0lEKE4nZGJvLkRlcGxveUxvZycpIElTIE5VTEwgQ1JFQVRFIFRBQkxFIGRiby5EZXBsb3lMb2cgKElkIElOVCBJREVOVElUWSBQUklNQVJZIEtFWSwgTm90ZSBOVkFSQ0hBUigxMDApIE5PVCBOVUxMKTsgLS0gZmlyc3QgYmF0Y2ggY3JlYXRlcyB0aGUgdGFibGUKR08KSU5TRVJUIElOVE8gZGJvLkRlcGxveUxvZyAoTm90ZSkgVkFMVUVTIChOJ1NjcmlwdCBhcHBsaWVkJyk7IC0tIHNlY29uZCBiYXRjaCByZWNvcmRzIHRoZSBydW4KR08= --Base64 --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --Credentials:sql-production --CommandText:SUYgT0JKRUNUX0lEKE4nZGJvLkRlcGxveUxvZycpIElTIE5VTEwgQ1JFQVRFIFRBQkxFIGRiby5EZXBsb3lMb2cgKElkIElOVCBJREVOVElUWSBQUklNQVJZIEtFWSwgTm90ZSBOVkFSQ0hBUigxMDApIE5PVCBOVUxMKTsgLS0gZmlyc3QgYmF0Y2ggY3JlYXRlcyB0aGUgdGFibGUKR08KSU5TRVJUIElOVE8gZGJvLkRlcGxveUxvZyAoTm90ZSkgVkFMVUVTIChOJ1NjcmlwdCBhcHBsaWVkJyk7IC0tIHNlY29uZCBiYXRjaCByZWNvcmRzIHRoZSBydW4KR08= --Base64 --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --Credentials:sql-production --CommandText:SUYgT0JKRUNUX0lEKE4nZGJvLkRlcGxveUxvZycpIElTIE5VTEwgQ1JFQVRFIFRBQkxFIGRiby5EZXBsb3lMb2cgKElkIElOVCBJREVOVElUWSBQUklNQVJZIEtFWSwgTm90ZSBOVkFSQ0hBUigxMDApIE5PVCBOVUxMKTsgLS0gZmlyc3QgYmF0Y2ggY3JlYXRlcyB0aGUgdGFibGUKR08KSU5TRVJUIElOVE8gZGJvLkRlcGxveUxvZyAoTm90ZSkgVkFMVUVTIChOJ1NjcmlwdCBhcHBsaWVkJyk7IC0tIHNlY29uZCBiYXRjaCByZWNvcmRzIHRoZSBydW4KR08= --Base64 --Transaction}}"
}
```

## Output Parameter

### Invoke Sql Server Script Batch Count (InvokeSqlServerScript:BatchCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the number of batches the script ran, as plain integer text.
Counts each repetition of a GO n separator as a separate batch, and empty batches are not counted.
Helps confirm that the whole script was split and executed as expected.
Stored as a Base64-encoded session parameter, so decode it before use.

### Invoke Sql Server Script Rows Affected (InvokeSqlServerScript:RowsAffected)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the total number of rows changed by INSERT, UPDATE, DELETE, and MERGE statements across all batches, as plain integer text.
Batches that report no row count, such as DDL statements or batches under SET NOCOUNT ON, add 0 to the total.
Stored as a Base64-encoded session parameter, so decode it before use.

## Parameters

### Authentication (Authentication)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects the sign-in method used to connect to SQL Server.
Overrides the method from the credentials record or the connection string, so one target can switch between SQL logins, Windows sign-in, and Microsoft Entra sign-in.
Leave it empty to keep the method the baseline connection already defines.

#### Values

##### Sql Password

Signs in with a SQL Server login name and password.
Supply the login through Username and Password or through the credentials record.

##### Integrated

Signs in with the Windows account that runs the automation.
No user name or password is sent to the server.

##### Active Directory Default

Signs in with the Microsoft Entra default credential chain, such as environment settings, a managed identity, or a developer tool sign-in.
Fits services that already carry a Microsoft Entra identity.

##### Active Directory Integrated

Signs in with the Microsoft Entra identity of the current domain-joined Windows user.
No password is passed in the step.

##### Active Directory Interactive

Signs in through an interactive Microsoft Entra prompt.
Fits attended runs where a person can complete multi-factor sign-in.

##### Active Directory Managed Identity

Signs in with the managed identity of the Azure host that runs the automation.
Username can carry the client id of a user-assigned identity.

##### Active Directory Password

Signs in with a Microsoft Entra user name and password.
Accounts that require multi-factor authentication cannot use this method.

##### Active Directory Service Principal

Signs in as a Microsoft Entra application.
Username carries the application client id and Password carries the client secret.

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Decodes the CommandText value from UTF-8 Base64 before the script is split into batches.
Encoding the SQL as Base64 lets inline text that contains a space followed by two dashes or a double closing brace travel safely, because those sequences otherwise end an inline argument value.
Only CommandText is decoded, so CommandFile content is always read as plain text.
Invalid Base64 fails the step before anything is sent to SQL Server, so encoded text never runs as SQL.

### Command File (CommandFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Points to a UTF-8 .sql file that holds the script, such as C:\Scripts\deploy.sql.
Supports long multi-line scripts, SQL comments, and characters that cannot travel inside an inline argument.
Used only when CommandText is empty, and a missing file fails the step.

### Command Text (CommandText)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides the script inline, with batches separated by lines that hold only GO or GO followed by a repeat count.
Takes priority over CommandFile, and one of the two is required.
When the SQL contains a space followed by two dashes or two closing braces, use CommandFile or pass the script as UTF-8 Base64 with the Base64 switch, because those characters end an inline argument value.

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 30                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many seconds each batch of the script may run before the step fails with a timeout error.
Defaults to 30 seconds per batch, and the value 0 waits without a time limit.
Missing, negative, or non-numeric values fall back to the 30-second default.

### Connection String (ConnectionString)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a full ADO.NET connection string, such as Server=localhost,1433;Database=Sales;Integrated Security=true.
Used only when Credentials is not set, and discrete values such as Server or Database still override its parts.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored SQL Server credentials record by its name or id, such as sql-production.
Keeps server addresses, logins, and secrets out of the flow because the record supplies the connection at runtime.
When no record matches, a value that contains an equals sign is used as a raw connection string and any other value is used as a raw Microsoft Entra access token.
Takes priority over ConnectionString when both are set.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the database the connection opens, overriding the database from the credentials record or the connection string.
Lets one stored login reach several databases on the same server.

### Encrypt (Encrypt)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets how the connection encrypts traffic between the automation and SQL Server.
Overrides the encryption mode from the credentials record or the connection string.

#### Values

##### Mandatory

Requires an encrypted connection and validates the server certificate unless TrustServerCertificate is set.
Matches the default of the Microsoft SQL Server data provider.

##### Optional

Encrypts traffic only when the server asks for it.
Suits older or internal servers that do not offer encryption.

##### Strict

Uses TDS 8.0 strict encryption, where the secure handshake happens before any login data is sent.
Requires SQL Server 2022 or Azure SQL and always validates the server certificate.

### No Entity (NoEntity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Omits the response entity so the step returns its results only as session parameters.
Keeps the response small when results are large and only later steps read them.
Session parameters such as InvokeSqlServerScript:BatchCount are still written.

### Password (Password)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the password for the SQL Server or Microsoft Entra login, overriding the password from the credentials record or the connection string.
Prefer Credentials over an inline password so secrets stay out of the flow definition.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the TCP port added to Server, such as 1433 for a default SQL Server instance.
Applies only when Server is set in the same step, and values of 0 or less are ignored.

### Server (Server)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the SQL Server host name, address, or named instance, such as localhost or db01\SQLEXPRESS.
Overrides the server from the credentials record or the connection string and is required when neither supplies one.
Combine it with Port to reach a specific TCP port.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a raw Microsoft Entra access token that authenticates the connection.
Fits pipelines that already hold a token for the database resource, and needs Server or a connection string because a token carries no server address.
Do not combine it with Password or an Authentication value, because the data provider rejects a connection that sets both.

### Transaction (Transaction)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Runs every batch of the script inside one transaction that commits after the last batch succeeds.
Rolls back all earlier batches when any batch fails, so the database never keeps a half-applied script.
Statements that SQL Server does not allow inside a transaction, such as CREATE DATABASE, fail when the switch is present.

### Trust Server Certificate (TrustServerCertificate)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Accepts the server certificate without checking it against a trusted certificate authority.
Needed for local or test servers that use a self-signed certificate, such as a developer instance on localhost,1433.
Avoid it on production servers because it removes protection against impersonated servers.

### Username (Username)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the login name used with Password, overriding the user from the credentials record or the connection string.
For a Microsoft Entra service principal, the value carries the application client id.

## Scope

* Any
