# Invoke Sql Server Non Query (InvokeSqlServerNonQuery)

[Table of Content](../Home.md)

~24 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs one SQL statement that changes data or schema on Microsoft SQL Server, such as INSERT, UPDATE, DELETE, MERGE, or CREATE TABLE.
Returns the number of affected rows so later steps can confirm that the change happened.
Binds every input value as a typed SQL parameter, which keeps the statement safe from SQL injection.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Data and schema changes | Runs INSERT, UPDATE, DELETE, MERGE, and DDL statements and returns the affected row count. |
| Flexible connection | Connects through a stored credentials record, a raw connection string, a raw Microsoft Entra access token, or discrete Server, Port, and Database values. |
| Connection overrides | Server, Port, Database, Authentication, Username, Password, Encrypt, and TrustServerCertificate replace the parts of the base connection they set. |
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
    Argument = "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{"Status":"Closed","Id":42} --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{"Status":"Closed","Id":42} --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{"Status":"Closed","Id":42} --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{"Status":"Closed","Id":42} --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{"Status":"Closed","Id":42} --Transaction}}"
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
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{"BatchId":"2026-11-09"} --CommandTimeout:120}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{"BatchId":"2026-11-09"} --CommandTimeout:120}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{"BatchId":"2026-11-09"} --CommandTimeout:120}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{"BatchId":"2026-11-09"} --CommandTimeout:120}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:DELETE FROM dbo.ImportStaging WHERE BatchId = @BatchId --Parameters:{"BatchId":"2026-11-09"} --CommandTimeout:120}}"
}
```

### Example No.3

### Insert a row with discrete connection parts

The argument uses parameter syntax that binds Server, Port, Database, Authentication, the TrustServerCertificate switch, the INSERT statement, and its Parameters.
The connection is composed from those parts, and the bound @Event and @Success values become one new audit row.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerNonQuery",
    Argument = "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --TrustServerCertificate --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success) --Parameters:{"Event":"InvoiceExported","Success":true} --Encrypt:Mandatory}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --TrustServerCertificate --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success) --Parameters:{"Event":"InvoiceExported","Success":true} --Encrypt:Mandatory}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --TrustServerCertificate --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success) --Parameters:{"Event":"InvoiceExported","Success":true} --Encrypt:Mandatory}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --TrustServerCertificate --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success) --Parameters:{"Event":"InvoiceExported","Success":true} --Encrypt:Mandatory}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --TrustServerCertificate --CommandText:INSERT INTO dbo.AuditLog (Event, Success) VALUES (@Event, @Success) --Parameters:{"Event":"InvoiceExported","Success":true} --Encrypt:Mandatory}}"
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
    Argument = "{{$ --Credentials:sql-production --CommandFile:C:\automation\sql\archive-closed-orders.sql --Transaction --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerNonQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandFile:C:\automation\sql\archive-closed-orders.sql --Transaction --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerNonQuery",
    argument: "{{$ --Credentials:sql-production --CommandFile:C:\automation\sql\archive-closed-orders.sql --Transaction --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandFile:C:\automation\sql\archive-closed-orders.sql --Transaction --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --CommandFile:C:\automation\sql\archive-closed-orders.sql --Transaction --NoEntity}}"
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

### Authentication (Authentication)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Chooses how the connection signs in to SQL Server, such as a SQL login, the Windows identity, or a Microsoft Entra method.
Overrides the sign-in method of the stored credentials or connection string, so one target can be reached with a different identity.
Leave it empty to keep the method that the credentials or connection string already define.

#### Values

##### Active Directory Default

Signs in with the first Microsoft Entra identity found in the environment, such as a managed identity or a developer login.
Suits pipelines that run under different identities without code changes.

##### Active Directory Integrated

Signs in with the Microsoft Entra identity of the signed-in Windows user.
Suits domain-joined machines that are federated with Microsoft Entra ID.

##### Active Directory Interactive

Opens an interactive Microsoft Entra sign-in prompt for the user named in Username.
Suits attended runs where a person can complete multi-factor sign-in.

##### Active Directory Managed Identity

Signs in with the Azure managed identity of the host; Username can carry a user-assigned identity client id.
Suits unattended runs on Azure hosts without any stored secret.

##### Active Directory Password

Signs in with a Microsoft Entra user name and password taken from Username and Password.
Suits accounts that do not require multi-factor sign-in.

##### Active Directory Service Principal

Signs in as a Microsoft Entra application, with the client id in Username and the client secret in Password.
Suits unattended service runs that use an app registration.

##### Integrated

Signs in with the Windows identity that runs the automation (Integrated Security).
Avoids storing any password when the runner account has database access.

##### Sql Password

Signs in with a SQL Server login taken from Username and Password.
Suits servers that use SQL Server authentication.

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Decodes the CommandText value from UTF-8 Base64 before the statement runs.
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
Use it for SQL that contains a space followed by two dashes or a double closing brace, because those sequences end an inline argument value.
CommandText wins when both are set, and the step fails when the file does not exist.

### Command Text (CommandText)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the SQL statement to run, written inline in the step argument.
Reference input values as named placeholders such as @Id and supply them through Parameters instead of joining them into the text.
Either CommandText or CommandFile is required, and CommandText wins when both are set.
For SQL that contains a space followed by two dashes or a double closing brace, use CommandFile or pass the text as UTF-8 Base64 together with the Base64 switch.

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

Holds a full ADO.NET connection string, such as Server=localhost,1433;Database=Sales;Integrated Security=True.
Use it when no stored credentials record is set, because Credentials takes priority over it.
Server, Database, and the other connection parameters still override the parts they set.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names a stored SQL Server credentials record by name or id, so the login never appears in the automation definition.
A value that matches no record and contains an equals sign is used as a raw connection string.
Any other unmatched value is used as a raw Microsoft Entra access token, and Credentials takes priority over ConnectionString.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the database the statement runs in, overriding the database of the credentials or connection string.
Lets one stored login reach several databases on the same server.

### Encrypt (Encrypt)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets how the connection encrypts traffic to SQL Server.
Overrides the encryption mode of the credentials or connection string, so security rules can be met per step.

#### Values

##### Mandatory

Requires an encrypted connection and validates the server certificate unless TrustServerCertificate is set.
Matches the provider default for new connections.

##### Optional

Encrypts only when the server requires it.
Suits older servers on trusted networks.

##### Strict

Uses TDS 8.0 strict encryption, where the connection is encrypted before any sign-in data is sent.
Requires SQL Server 2022 or Azure SQL and always validates the server certificate.

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

### Password (Password)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the password or client secret used with Username, overriding the value of the credentials or connection string.
Prefer a stored credentials record so the secret stays out of the automation definition.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the TCP port of SQL Server, such as 1433.
Applies together with Server, which receives the port as server,port.

### Server (Server)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the SQL Server host name or address, such as localhost or db01.contoso.local\SQLEXPRESS.
Overrides the server of the credentials or connection string, so one stored login can target another server.
The step fails when no server results from Credentials, ConnectionString, or Server.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Supplies a raw Microsoft Entra access token that signs in the connection.
Do not combine it with a password or an Authentication method, because SQL Server rejects that combination.

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

### Trust Server Certificate (TrustServerCertificate)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Accepts the server certificate without validating it against a trusted authority.
Use it only for local or test servers with self-signed certificates, because it weakens protection against impersonation.

### Username (Username)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the login name, Microsoft Entra user, or application client id used to sign in.
Overrides the user of the credentials or connection string.

## Scope

* Any
