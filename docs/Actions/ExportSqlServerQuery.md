# Export Sql Server Query (ExportSqlServerQuery)

[Table of Content](../Home.md)

~25 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

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
| Flexible connection       | Connects through a stored credentials record, a raw connection string, or a raw Microsoft Entra access token.                                                                 |
| Entra token sign-in       | Signs in with the raw access token from Token, next to a connection that carries no password or Authentication keyword.                                                       |
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

### Read filtered rows from a table with stored credentials

The argument uses parameter syntax that binds Credentials, the SELECT statement, its @Country value, and a 60-second CommandTimeout.
The matching rows of the Customers table are returned as JSON together with the column names and row count.

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

### Get several result sets with a raw connection string

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

The argument uses parameter syntax that binds Credentials, a CommandFile path, and the NoEntity switch.
The query from the file runs in the Reporting database, and only the session parameters receive the results.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --Credentials:sql-reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --Credentials:sql-reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --Credentials:sql-reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-reporting --CommandFile:C:\automation\sql\monthly-sales.sql --NoEntity}}"
}
```

### Example No.4

### Select rows with a Base64-encoded query that has a comment

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

### Example No.5

### Export today's orders with a Base64 query that holds a macro

The argument binds the `sql-production` credentials, a Base64 CommandText, and the Base64 switch at runtime.
The decoded SQL holds a ` --` comment and a New-Date macro; the macro is resolved after decoding, so the server receives the current date: `SELECT Id, Status FROM dbo.Orders -- orders created today` and the lines after it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportSqlServerQuery",
    Argument = "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBTdGF0dXMgRlJPTSBkYm8uT3JkZXJzIC0tIG9yZGVycyBjcmVhdGVkIHRvZGF5CldIRVJFIENyZWF0ZWRPbiA+PSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyBPUkRFUiBCWSBJZA== --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportSqlServerQuery")
    .setArgument("{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBTdGF0dXMgRlJPTSBkYm8uT3JkZXJzIC0tIG9yZGVycyBjcmVhdGVkIHRvZGF5CldIRVJFIENyZWF0ZWRPbiA+PSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyBPUkRFUiBCWSBJZA== --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportSqlServerQuery",
    argument: "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBTdGF0dXMgRlJPTSBkYm8uT3JkZXJzIC0tIG9yZGVycyBjcmVhdGVkIHRvZGF5CldIRVJFIENyZWF0ZWRPbiA+PSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyBPUkRFUiBCWSBJZA== --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBTdGF0dXMgRlJPTSBkYm8uT3JkZXJzIC0tIG9yZGVycyBjcmVhdGVkIHRvZGF5CldIRVJFIENyZWF0ZWRPbiA+PSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyBPUkRFUiBCWSBJZA== --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIElkLCBTdGF0dXMgRlJPTSBkYm8uT3JkZXJzIC0tIG9yZGVycyBjcmVhdGVkIHRvZGF5CldIRVJFIENyZWF0ZWRPbiA+PSAne3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19JyBPUkRFUiBCWSBJZA== --Base64}}"
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

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Decodes the CommandText value from UTF-8 Base64 before the query runs.
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

## Scope

* Any
