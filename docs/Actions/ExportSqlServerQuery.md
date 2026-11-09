# Export Sql Server Query (ExportSqlServerQuery)

[Table of Content](../Home.md)

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a query on Microsoft SQL Server and exports the returned rows as JSON.
Gives later steps the rows, every result set, the column names, and the row count without writing any parsing code.
Binds every input value as a typed SQL parameter, which keeps the query safe from SQL injection.

### Key Features and Functionality

| Feature                   | Description                                                                                                                                                                   |
| --- | --- |
| Query export              | Runs a SELECT query, or any batch that returns rows, and exports the rows of the first result set as JSON.                                                                    |
| Multiple result sets      | Keeps every result set of a multi-statement query in ResultSets, in server order.                                                                                             |
| Result shape              | Reports the column names of the first result set even when the query returns no rows.                                                                                         |
| Flexible connection       | Connects through a stored credentials record, a raw connection string, a raw Microsoft Entra access token, or discrete Server, Port, and Database values.                     |
| Connection overrides      | Server, Port, Database, Authentication, Username, Password, Encrypt, and TrustServerCertificate replace the parts of the base connection they set.                            |
| Parameter binding         | Binds the properties of a Parameters JSON object to named placeholders such as @Country, keeping strings, numbers, booleans, and null typed.                                  |
| Inline or file SQL        | Reads the query from CommandText, a Base64-encoded CommandText with the Base64 switch, or a UTF-8 CommandFile, for SQL that contains ' --' or '}}'.                           |
| Stable JSON values        | Writes nulls as null, dates as ISO 8601, binary as Base64, decimals as exact numbers, and uniqueidentifier values as strings.                                                 |
| Session and entity output | Stores Result, ResultSets, Columns, and RowCount as Base64-encoded ExportSqlServerQuery:* session parameters and as plain text in the response entity unless NoEntity is set. |

### Usages in RPA

| Use Case               | Description                                                                           |
| --- | --- |
| Load work items        | Reads pending orders, tickets, or invoices that a bot processes one by one.           |
| Look up reference data | Fetches customer, product, or account details needed to fill a form or a document.    |
| Export reports         | Pulls report rows from a stored SQL file and hands them to a file, mail, or API step. |
| Feed data loops        | Supplies a JSON array of rows to a later loop or data-driven step.                    |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Verify persisted data   | Reads back the rows an application saved and compares them with the expected values. |
| Check result size       | Uses RowCount to assert that a query returns the expected number of rows or no rows. |
| Validate schema         | Uses Columns to confirm that a view or query exposes the expected columns.           |
| Drive data-driven tests | Reads test input rows from a database table and passes them to test steps.           |

### Output Shapes

Result, ResultSets, and Columns hold minified JSON text, and RowCount holds a number as text.
The sample below lists each value for a query that returns two customers, after Base64 decoding of the session parameters.

```text
Result     = [{"Id":1,"Name":"Contoso"},{"Id":2,"Name":"Fabrikam"}]
ResultSets = [[{"Id":1,"Name":"Contoso"},{"Id":2,"Name":"Fabrikam"}]]
Columns    = ["Id","Name"]
RowCount   = 2
```

When the query returns no result set at all, Result, ResultSets, and Columns are [] and RowCount is 0.
Session parameters are Base64-encoded, so decode an ExportSqlServerQuery:* value before parsing it.

## Examples

### Example No.1

### Export filtered rows with stored credentials

The argument uses parameter syntax that binds Credentials, the SELECT statement, its @Country value, and a 60-second CommandTimeout.
The matching customer rows are exported as JSON together with the column names and row count.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{"Country":"Germany"} --CommandTimeout:60}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{"Country":"Germany"} --CommandTimeout:60}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{"Country":"Germany"} --CommandTimeout:60}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{"Country":"Germany"} --CommandTimeout:60}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{"Country":"Germany"} --CommandTimeout:60}}"
}
```

### Example No.2

### Export several result sets with a raw connection string

The argument uses parameter syntax that binds a full ADO.NET ConnectionString and a CommandText with two SELECT statements.
Both result sets are kept in ResultSets, while Result keeps the first one.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT Id, Name FROM dbo.Customers; SELECT Id, Total FROM dbo.Orders WHERE Total > 1000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT Id, Name FROM dbo.Customers; SELECT Id, Total FROM dbo.Orders WHERE Total > 1000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT Id, Name FROM dbo.Customers; SELECT Id, Total FROM dbo.Orders WHERE Total > 1000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT Id, Name FROM dbo.Customers; SELECT Id, Total FROM dbo.Orders WHERE Total > 1000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT Id, Name FROM dbo.Customers; SELECT Id, Total FROM dbo.Orders WHERE Total > 1000}}"
}
```

### Example No.3

### Export a report from a SQL file without a response entity

The argument uses parameter syntax that binds Credentials, a Database override, a CommandFile path, and the NoEntity switch.
The query from the file runs in the Reporting database, and only the session parameters receive the results.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --Credentials:sql-production --Database:Reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --Credentials:sql-production --Database:Reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --Credentials:sql-production --Database:Reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --Database:Reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --Database:Reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
}
```

### Example No.4

### Export rows from a Base64-encoded query with a comment

The argument uses parameter syntax that binds Credentials, a Base64 CommandText, its @Country value, and the Base64 switch.
The decoded SQL is `SELECT Id, Name FROM dbo.Customers -- customers in the requested country` followed by a `WHERE Country = @Country ORDER BY Name` line.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBOYW1lIEZST00gZGJvLkN1c3RvbWVycyAtLSBjdXN0b21lcnMgaW4gdGhlIHJlcXVlc3RlZCBjb3VudHJ5CldIRVJFIENvdW50cnkgPSBAQ291bnRyeSBPUkRFUiBCWSBOYW1l --Parameters:{"Country":"Germany"} --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBOYW1lIEZST00gZGJvLkN1c3RvbWVycyAtLSBjdXN0b21lcnMgaW4gdGhlIHJlcXVlc3RlZCBjb3VudHJ5CldIRVJFIENvdW50cnkgPSBAQ291bnRyeSBPUkRFUiBCWSBOYW1l --Parameters:{"Country":"Germany"} --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBOYW1lIEZST00gZGJvLkN1c3RvbWVycyAtLSBjdXN0b21lcnMgaW4gdGhlIHJlcXVlc3RlZCBjb3VudHJ5CldIRVJFIENvdW50cnkgPSBAQ291bnRyeSBPUkRFUiBCWSBOYW1l --Parameters:{"Country":"Germany"} --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBOYW1lIEZST00gZGJvLkN1c3RvbWVycyAtLSBjdXN0b21lcnMgaW4gdGhlIHJlcXVlc3RlZCBjb3VudHJ5CldIRVJFIENvdW50cnkgPSBAQ291bnRyeSBPUkRFUiBCWSBOYW1l --Parameters:{"Country":"Germany"} --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBOYW1lIEZST00gZGJvLkN1c3RvbWVycyAtLSBjdXN0b21lcnMgaW4gdGhlIHJlcXVlc3RlZCBjb3VudHJ5CldIRVJFIENvdW50cnkgPSBAQ291bnRyeSBPUkRFUiBCWSBOYW1l --Parameters:{"Country":"Germany"} --Base64}}"
}
```

## Output Parameter

### Export Sql Server Query Columns (ExportSqlServerQuery:Columns)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the column names of the first result set as a Base64-encoded minified JSON array, such as ["Id","Name"] after decoding.
Columns are reported even when the query returns no rows, so later steps can still check the result shape.

### Export Sql Server Query Result (ExportSqlServerQuery:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the rows of the first result set as a Base64-encoded minified JSON array of row objects keyed by column name.
Gives later steps the main query result in one value that is easy to decode, parse, loop over, or assert.

### Export Sql Server Query Result Sets (ExportSqlServerQuery:ResultSets)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores every result set of the query as a Base64-encoded minified JSON array of row arrays, in server order.
Keeps all results of a multi-statement query, while ExportSqlServerQuery:Result keeps only the first one.

### Export Sql Server Query Row Count (ExportSqlServerQuery:RowCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Stores the number of rows in the first result set as a Base64-encoded number, such as 2 after decoding.
Lets later steps check for an empty result or an expected size without parsing the JSON.

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

Decodes the CommandText value from UTF-8 Base64 before the query runs.
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
