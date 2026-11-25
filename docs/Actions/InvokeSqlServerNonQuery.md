# Invoke Sql Server Non Query (InvokeSqlServerNonQuery)

[Table of Content](../Home.md)

~29 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs one SQL statement that changes data or schema on Microsoft SQL Server, such as INSERT, UPDATE, DELETE, MERGE, or CREATE TABLE.
Returns the number of affected rows so later steps can confirm that the change happened.
Binds every input value as a typed SQL parameter, which keeps the statement safe from SQL injection.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Data and schema changes | Runs INSERT, UPDATE, DELETE, MERGE, and DDL statements and returns the affected row count. |
| Flexible connection | Connects through a stored credentials record, a raw connection string, or a raw Microsoft Entra access token. |
| Entra token sign-in | Signs in with the raw access token from Token, next to a connection that carries no password or Authentication keyword. |
| Parameter binding | Binds the properties of a Parameters JSON object to named placeholders such as @Id, keeping strings, numbers, booleans, and null typed. |
| Inline or file SQL | Reads the statement from CommandText, a Base64-encoded CommandText with the Base64 switch, or a UTF-8 CommandFile, for SQL that contains ' --' or '}}'. |
| Transaction | Wraps the statement in one transaction that commits on success and rolls back on failure. |
| Command timeout | Limits the statement run time in seconds, with 30 as the default and 0 for no limit. |
| Session and entity output | Stores RowsAffected as the Base64-encoded session parameter InvokeSqlServerNonQuery:RowsAffected and as plain text in the response entity unless NoEntity is set. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Update record status | Marks orders, tickets, or invoices as processed after a bot finishes its work. |
| Clean staging tables | Deletes or archives staging rows before or after a data load. |
| Write audit entries | Inserts a log or audit row for every handled business case. |
| Run maintenance scripts | Runs a stored SQL file, such as an archive or purge job, inside a transaction. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Seed test data | Inserts known rows before a UI or API test runs. |
| Reset state | Deletes or restores test rows after a test so the next run starts clean. |
| Verify change size | Compares RowsAffected with the expected count to confirm that a change touched the right rows. |
| Prepare schema | Creates or alters test tables before an integration test suite. |

### Outputs

RowsAffected holds the total number of rows changed by the statement as text, such as 1.
The value -1 means that SQL Server reported no row count, which happens for DDL statements or when SET NOCOUNT ON is active.
Session parameters are Base64-encoded, so decode InvokeSqlServerNonQuery:RowsAffected before comparing it.

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

### Update rows with stored credentials in a transaction

The argument uses parameter syntax that binds Credentials, CommandText, Parameters, and the Transaction switch.
The UPDATE runs with @Status and @Id bound from the Parameters JSON and commits only when it succeeds.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction}}"
}
```

### Example No.2

### Delete rows with a raw connection string

The argument uses parameter syntax that binds a full ADO.NET ConnectionString, the DELETE statement, its @BatchId value, and a 120-second CommandTimeout.
The statement runs without a transaction and reports how many staging rows it removed.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{\"BatchId\":\"2026-11-09\"} --CommandTimeout:120}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{\"BatchId\":\"2026-11-09\"} --CommandTimeout:120}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{\"BatchId\":\"2026-11-09\"} --CommandTimeout:120}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{\"BatchId\":\"2026-11-09\"} --CommandTimeout:120}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{\"BatchId\":\"2026-11-09\"} --CommandTimeout:120}}"
}
```

### Example No.3

### Insert a row with a connection string

The argument uses parameter syntax that binds a `ConnectionString`, the Parameters JSON object, and the INSERT statement.
The connection comes from that string, and the bound @Event and @Success values become one new audit row.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;Encrypt=Mandatory;TrustServerCertificate=True --Parameters:{\"Event\":\"InvoiceExported\",\"Success\":true} --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success)}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;Encrypt=Mandatory;TrustServerCertificate=True --Parameters:{\"Event\":\"InvoiceExported\",\"Success\":true} --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success)}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;Encrypt=Mandatory;TrustServerCertificate=True --Parameters:{\"Event\":\"InvoiceExported\",\"Success\":true} --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success)}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;Encrypt=Mandatory;TrustServerCertificate=True --Parameters:{\"Event\":\"InvoiceExported\",\"Success\":true} --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success)}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;Encrypt=Mandatory;TrustServerCertificate=True --Parameters:{\"Event\":\"InvoiceExported\",\"Success\":true} --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success)}}"
}
```

### Example No.4

### Run a SQL file without a response entity

The argument uses parameter syntax that binds Credentials, a CommandFile path, and the Transaction and NoEntity switches.
The file content runs as one statement batch inside a transaction, and only the session parameter receives the row count.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --Credentials:sql-production --CommandFile:C:\\automation\\sql\\archive-closed-orders.sql --Transaction --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandFile:C:\\automation\\sql\\archive-closed-orders.sql --Transaction --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandFile:C:\\automation\\sql\\archive-closed-orders.sql --Transaction --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandFile:C:\\automation\\sql\\archive-closed-orders.sql --Transaction --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandFile:C:\\automation\\sql\\archive-closed-orders.sql --Transaction --NoEntity}}"
}
```

### Example No.5

### Archive closed orders with a Base64-encoded statement

The argument uses parameter syntax that binds Credentials, a Base64 CommandText, and the Base64 and Transaction switches.
The decoded SQL is `UPDATE dbo.Orders SET Status = 'Archived' -- archive closed orders` followed by a `WHERE Status = 'Closed'` line.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFN0YXR1cyA9ICdBcmNoaXZlZCcgLS0gYXJjaGl2ZSBjbG9zZWQgb3JkZXJzCldIRVJFIFN0YXR1cyA9ICdDbG9zZWQn --Base64 --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFN0YXR1cyA9ICdBcmNoaXZlZCcgLS0gYXJjaGl2ZSBjbG9zZWQgb3JkZXJzCldIRVJFIFN0YXR1cyA9ICdDbG9zZWQn --Base64 --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFN0YXR1cyA9ICdBcmNoaXZlZCcgLS0gYXJjaGl2ZSBjbG9zZWQgb3JkZXJzCldIRVJFIFN0YXR1cyA9ICdDbG9zZWQn --Base64 --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFN0YXR1cyA9ICdBcmNoaXZlZCcgLS0gYXJjaGl2ZSBjbG9zZWQgb3JkZXJzCldIRVJFIFN0YXR1cyA9ICdDbG9zZWQn --Base64 --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFN0YXR1cyA9ICdBcmNoaXZlZCcgLS0gYXJjaGl2ZSBjbG9zZWQgb3JkZXJzCldIRVJFIFN0YXR1cyA9ICdDbG9zZWQn --Base64 --Transaction}}"
}
```

### Example No.6

### Stamp open orders with a Base64 update that holds a macro

The argument binds the `sql-production` credentials, a Base64 CommandText, and the Base64 switch at runtime.
The decoded SQL holds a ` --` comment and a New-Date macro; the macro is resolved after decoding, so the server receives the current date: `UPDATE dbo.Orders SET ReviewedOn = '{{$New-Date --Format:yyyy-MM-dd}}' -- stamp the review date` and the lines after it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFJldmlld2VkT24gPSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyAtLSBzdGFtcCB0aGUgcmV2aWV3IGRhdGUKV0hFUkUgU3RhdHVzID0gJ09wZW4n --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFJldmlld2VkT24gPSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyAtLSBzdGFtcCB0aGUgcmV2aWV3IGRhdGUKV0hFUkUgU3RhdHVzID0gJ09wZW4n --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFJldmlld2VkT24gPSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyAtLSBzdGFtcCB0aGUgcmV2aWV3IGRhdGUKV0hFUkUgU3RhdHVzID0gJ09wZW4n --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFJldmlld2VkT24gPSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyAtLSBzdGFtcCB0aGUgcmV2aWV3IGRhdGUKV0hFUkUgU3RhdHVzID0gJ09wZW4n --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:VVBEQVRFIGRiby5PcmRlcnMgU0VUIFJldmlld2VkT24gPSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyAtLSBzdGFtcCB0aGUgcmV2aWV3IGRhdGUKV0hFUkUgU3RhdHVzID0gJ09wZW4n --Base64}}"
}
```

## Output Parameter

### Invoke Sql Server Non Query Rows Affected (InvokeSqlServerNonQuery:RowsAffected)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Stores the number of rows the statement changed as a Base64-encoded session parameter.
Lets later steps confirm or branch on the size of the change after decoding the value.
The value -1 means that SQL Server reported no row count, such as for DDL statements.

## Parameters

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Decodes the CommandText value from UTF-8 Base64 before the statement runs.
After decoding, the macros in the decoded value are resolved, because the engine resolves the macros of a rule before the plugin runs and cannot see them while the value is encoded.
A macro result becomes part of the SQL text, so values that come from outside the automation belong in the Parameters argument instead.
Encoding the SQL as Base64 lets inline text that contains a space followed by two dashes or a double closing brace travel safely, because those sequences otherwise end an inline argument value.
Only CommandText is decoded, so CommandFile content is always read as plain text and the Parameters JSON stays plain.
Invalid Base64 fails the step before anything is sent to SQL Server, so encoded text never runs as SQL.

### Command File (CommandFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Gives the path of a UTF-8 text file whose content is the SQL statement to run.
Use it for SQL with comments, `--` sequences, or `}}`, because file content never passes through the inline argument parser.
CommandText wins when both are set, and the step fails when the file does not exist.
Sends the whole file as one batch, so a `GO` separator line fails with a syntax error; use InvokeSqlServerScript for files that contain `GO`.

### Command Text (CommandText)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the SQL statement to run inline; CommandText or CommandFile is required, and CommandText wins when both are set.
Reference input values as named placeholders such as @Id and supply them through Parameters instead of joining them into the text.
Sends the text to SQL Server as one batch, so a `GO` separator line fails with a syntax error; use InvokeSqlServerScript for scripts that contain `GO`.
For SQL with `}}`, or with a space or line break followed directly by two dashes and a letter, digit, or one of `, / . $ *` (such as `--note`), use CommandFile or pass the text as UTF-8 Base64 with the Base64 switch, because those sequences can end the inline argument early so the rest of the SQL never runs.

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 30                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many seconds the statement may run before SQL Server cancels it.
Raise it for long statements so they finish, or keep it low to fail fast on blocked queries.
The value 0 waits without limit, and a missing or invalid value falls back to 30 seconds.

### Connection String (ConnectionString)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

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
| **Value Type**    | String            |

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

Leaves the response entity empty while the session parameters are still written.
Use it for large results or sensitive data that should not travel in the response payload.

### Parameters (Parameters)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds a JSON object whose properties are bound to the named placeholders of the statement, such as {"Id":42} for @Id.
Values are sent as typed SQL parameters and never joined into the SQL text, which blocks SQL injection.
Strings, booleans, numbers, and null keep their type, and nested objects or arrays are sent as JSON text.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

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

Runs the statement inside one transaction that commits on success and rolls back on failure.
Keeps the data unchanged when the statement fails partway, so a failed step leaves no partial update.

## Scope

* Any
