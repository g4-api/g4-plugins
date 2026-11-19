# Get Sql Server Scalar (GetSqlServerScalar)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a SQL Server query and returns a single value from the first column of the first row.
Gives automations a quick way to read counts, totals, flags, or lookup values without exporting a full result set.
Keeps input safe by sending values as typed SQL parameters instead of joining them into the query.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                 |
| --- | --- |
| Single-value query         | Returns the first column of the first row, such as the result of `SELECT COUNT(*)`.                                                         |
| Inline or file query       | Reads the query from CommandText, a Base64-encoded CommandText with the Base64 switch, or a UTF-8 `.sql` file in CommandFile.               |
| Typed parameters           | Binds JSON object properties to `@` placeholders as typed SQL parameters.                                                                   |
| Consistent value text      | Stores strings as they are and other types as JSON text, such as `42`, `true`, or `2024-01-01T00:00:00`.                                    |
| Empty result handling      | Stores an empty value when the query returns no row or NULL.                                                                                |
| Flexible connection input  | Resolves the target from a credentials name or id, a raw connection string, or a raw Microsoft Entra access token.                          |
| Command timeout            | Limits query run time in seconds, with a default of 30 seconds and 0 for no limit.                                                          |
| Session and entity outputs | Stores the value as the Base64 session parameter `GetSqlServerScalar:Value` and returns it in the response entity unless `NoEntity` is set. |

### Usages in RPA

| Use Case          | Description                                                                           |
| --- | --- |
| Work queue sizing | Count open orders or pending requests to decide how much work a bot should take.      |
| Lookup values     | Read a customer id, price, or status by key and reuse it in later form-filling steps. |
| Run guards        | Read the last processed date or a control flag before a job starts.                   |

### Usages in Automation Testing

| Use Case               | Description                                                                      |
| --- | --- |
| Back-end verification  | Confirm that a UI action wrote the expected row count or status to the database. |
| Test data checks       | Verify that seed data exists before a test suite runs.                           |
| Before and after delta | Compare a count before and after a test step to prove one record was added.      |

### Notes

Use CommandFile, or encode CommandText as UTF-8 Base64 and add the Base64 switch, for SQL that contains ` --` or `}}`, because those sequences end an inline argument value.
The value is plain text in the response entity and Base64-encoded in the session parameter.

## Examples

### Example No.1

### Count open orders with a parameterized query

The argument binds the `sql-production` credentials, a `SELECT COUNT(*)` query, and the JSON parameters `{"Status":"Open"}` at runtime.
The `@Status` placeholder receives `Open` as a typed value, and the count becomes the stored value.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetSqlServerScalar",
    Argument = "{{$ --Credentials:sql-production --CommandText:SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status --Parameters:{"Status":"Open"} --CommandTimeout:60}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetSqlServerScalar")
    .setArgument("{{$ --Credentials:sql-production --CommandText:SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status --Parameters:{"Status":"Open"} --CommandTimeout:60}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetSqlServerScalar",
    argument: "{{$ --Credentials:sql-production --CommandText:SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status --Parameters:{"Status":"Open"} --CommandTimeout:60}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-production --CommandText:SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status --Parameters:{"Status":"Open"} --CommandTimeout:60}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-production --CommandText:SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status --Parameters:{"Status":"Open"} --CommandTimeout:60}}"
}
```

### Example No.2

### Read the latest order date from a connection string

The argument binds a full connection string, a parameterless `SELECT MAX(OrderDate)` query, and the `NoEntity` switch.
The step stores the value only as a session parameter.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetSqlServerScalar",
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT MAX(OrderDate) FROM dbo.Orders --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetSqlServerScalar")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT MAX(OrderDate) FROM dbo.Orders --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetSqlServerScalar",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT MAX(OrderDate) FROM dbo.Orders --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT MAX(OrderDate) FROM dbo.Orders --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandText:SELECT MAX(OrderDate) FROM dbo.Orders --NoEntity}}"
}
```

### Example No.3

### Read a stock level from a SQL file

The argument binds the `sql-inventory` credentials, the JSON parameters `{"Sku":"SKU-1042"}`, and the `C:\Sql\stock-level.sql` file.
The query in the file uses the `@Sku` placeholder, and its first value becomes the stored value.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetSqlServerScalar",
    Argument = "{{$ --Credentials:sql-inventory --Parameters:{"Sku":"SKU-1042"} --CommandFile:C:\Sql\stock-level.sql}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetSqlServerScalar")
    .setArgument("{{$ --Credentials:sql-inventory --Parameters:{"Sku":"SKU-1042"} --CommandFile:C:\Sql\stock-level.sql}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetSqlServerScalar",
    argument: "{{$ --Credentials:sql-inventory --Parameters:{"Sku":"SKU-1042"} --CommandFile:C:\Sql\stock-level.sql}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-inventory --Parameters:{"Sku":"SKU-1042"} --CommandFile:C:\Sql\stock-level.sql}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-inventory --Parameters:{"Sku":"SKU-1042"} --CommandFile:C:\Sql\stock-level.sql}}"
}
```

### Example No.4

### Count open orders with a Base64-encoded query

The argument binds the `sql-production` credentials, a Base64 CommandText, and the Base64 switch at runtime.
The decoded SQL is `SELECT COUNT(*) FROM dbo.Orders -- open orders only` followed by a `WHERE Status = 'Open'` line, and the count becomes the stored value.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetSqlServerScalar",
    Argument = "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBvcGVuIG9yZGVycyBvbmx5CldIRVJFIFN0YXR1cyA9ICdPcGVuJw== --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetSqlServerScalar")
    .setArgument("{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBvcGVuIG9yZGVycyBvbmx5CldIRVJFIFN0YXR1cyA9ICdPcGVuJw== --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetSqlServerScalar",
    argument: "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBvcGVuIG9yZGVycyBvbmx5CldIRVJFIFN0YXR1cyA9ICdPcGVuJw== --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBvcGVuIG9yZGVycyBvbmx5CldIRVJFIFN0YXR1cyA9ICdPcGVuJw== --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBvcGVuIG9yZGVycyBvbmx5CldIRVJFIFN0YXR1cyA9ICdPcGVuJw== --Base64}}"
}
```

## Output Parameter

### Get Sql Server Scalar Value (GetSqlServerScalar:Value)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the first column of the first row returned by the query.
Strings are stored as they are, other types as JSON text such as `42`, `true`, or `2024-01-01T00:00:00`, and a NULL value or an empty result is stored as an empty value.
Lets later steps reuse a count, total, or lookup value without running another query.
The session value is Base64-encoded, so decode it before use.

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
| **Value Type**    | String|Expression |

Points to a UTF-8 `.sql` file that holds the query, such as `C:\Sql\stock-level.sql`.
Applies when CommandText is empty, and the step fails when the file does not exist.
Lets queries that contain comments or braces run without breaking the inline argument.
Sends the whole file as one batch, so a `GO` separator line fails with a syntax error; use InvokeSqlServerScript for files that contain `GO`.

### Command Text (CommandText)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Holds the SQL query to run, such as `SELECT COUNT(*) FROM dbo.Orders WHERE Status = @Status`.
Takes priority over CommandFile, and the step fails when neither one is set.
Sends the text to SQL Server as one batch, so a `GO` separator line fails with a syntax error; use InvokeSqlServerScript for scripts that contain `GO`.
For SQL with `}}`, or with a space or line break followed directly by two dashes and a letter, digit, or one of `, / . $ *` (such as `--note`), use CommandFile or pass the text as UTF-8 Base64 with the Base64 switch, because those sequences can end the inline argument early so the rest of the SQL never runs.

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many seconds the query may run before the step fails with a timeout error, with a default of 30 seconds.
A value of 0 waits without a time limit, and an invalid or negative value falls back to the default.

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

Omits the response entity, so the outputs are stored only as session parameters.
Keeps responses small when later steps read only the session parameters.

### Parameters (Parameters)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies query parameter values as a JSON object, such as `{"Status":"Open"}`, where each property binds to the matching `@` placeholder.
Values are sent as typed SQL parameters and never joined into the query text, which protects against SQL injection.
Strings, booleans, numbers, and null keep their type, while nested objects and arrays are sent as JSON text.
The `@` prefix is added automatically when a property name omits it.

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

## Scope

* Any
