# Invoke Sql Server Script (InvokeSqlServerScript)

[Table of Content](../Home.md)

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

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
| Flexible connection  | Connects through a credentials record, a connection string, or a Microsoft Entra access token.       |
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
3. Without `Credentials`, `ConnectionString` supplies the connection.
4. `Token` supplies a raw Microsoft Entra access token, for a connection that carries no password or `Authentication` keyword.
5. The step fails when no server is resolved.

Session parameters are named `InvokeSqlServerScript:<Name>` and are Base64-encoded, so decode them before use.

### Choosing InvokeSqlServerNonQuery or InvokeSqlServerScript

| Need | Use |
| --- | --- |
| Insert or change rows with values from earlier steps or macros | InvokeSqlServerNonQuery, because Parameters binds the values as typed SQL parameters. |
| Run a script with `GO` lines, such as a file from SSMS or sqlcmd | InvokeSqlServerScript, because only it splits the text into batches on `GO`. |
| Keep `USE` or `SET` options across batches | InvokeSqlServerScript, because every batch runs on one shared connection. |
| Get the exact row count of one statement | InvokeSqlServerNonQuery, because it reports the server count, including -1 for DDL. |
| Insert explicit IDENTITY values with a bound value | InvokeSqlServerNonQuery, with `SET IDENTITY_INSERT ... ON`, the INSERT, and `SET IDENTITY_INSERT ... OFF` in one batch separated by semicolons. |

InvokeSqlServerNonQuery sends its text as one batch, so SQL Server rejects a `GO` line with a syntax error.
InvokeSqlServerScript takes no Parameters, because SQL Server runs a parameterized command in its own scope and undoes `USE` and most `SET` options when that scope ends.

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

### Repeat an inline batch with a connection string in Credentials

Creates dbo.LoadProbe when missing, then repeats a single-row insert five times with a `GO 5` separator.
The Credentials value is a raw connection string to localhost,1433, which the step accepts because it contains equals signs, and NoEntity omits the response entity.

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

### Example No.4

### Run a script file with a connection string

The argument passes a complete connection string through the ConnectionString parameter instead of a stored credentials record.
The nightly load script runs in one transaction with a five-minute timeout, so a failing batch leaves the database unchanged.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerScript",
    Argument = "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Warehouse;Integrated Security=true;TrustServerCertificate=true --CommandFile:C:\Scripts\nightly-load.sql --Transaction --CommandTimeout:300}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerScript")
    .setArgument("{{$ --ConnectionString:Server=sql01.contoso.local;Database=Warehouse;Integrated Security=true;TrustServerCertificate=true --CommandFile:C:\Scripts\nightly-load.sql --Transaction --CommandTimeout:300}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerScript",
    argument: "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Warehouse;Integrated Security=true;TrustServerCertificate=true --CommandFile:C:\Scripts\nightly-load.sql --Transaction --CommandTimeout:300}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Warehouse;Integrated Security=true;TrustServerCertificate=true --CommandFile:C:\Scripts\nightly-load.sql --Transaction --CommandTimeout:300}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Warehouse;Integrated Security=true;TrustServerCertificate=true --CommandFile:C:\Scripts\nightly-load.sql --Transaction --CommandTimeout:300}}"
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
Macros inside the file are not resolved, because the file is read only when the step runs.

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
For SQL with `}}`, or with a space or line break followed directly by two dashes and a letter, digit, or one of `, / . $ *` (such as `--note`), use CommandFile or pass the text as UTF-8 Base64 with the Base64 switch, because those sequences can end the inline argument early so the rest of the SQL never runs.
The script takes no Parameters, and macros resolve only in plain CommandText because Base64 text is decoded after macro resolution, so use InvokeSqlServerNonQuery to bind values from earlier steps.

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

Supplies a full ADO.NET connection string, such as `Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True`.
Applies only when Credentials is not set, so a stored credentials reference always takes priority.
Every connection setting, such as the server, the database, the login, and the encryption mode, is written into the string itself.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored SQL Server credentials record by name or id, such as `sql-production`, so secrets stay out of the rule.
The record carries the server, port, database, login, and encryption settings, so the step never repeats them.
When no record matches, a value that contains `=` is used as a raw connection string and any other value is used as a raw Microsoft Entra access token.

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

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a raw Microsoft Entra access token that signs in the connection.
Enables token sign-in without a stored password, next to a Credentials record or a ConnectionString that carries no password.
Do not combine it with a connection string that carries a password or an Authentication keyword, because the SQL Server client rejects that mix when the connection opens.

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

## Scope

* Any
