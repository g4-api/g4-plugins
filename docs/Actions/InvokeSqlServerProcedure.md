# Invoke Sql Server Procedure (InvokeSqlServerProcedure)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a SQL Server stored procedure with named input values and returns its result sets, output parameters, and return value.
Reads the procedure signature from the server, so output parameters work without declaring their types.
Stores every result as a session parameter for later steps and, by default, also returns it in the response entity.

### Key Features and Functionality

| Feature                 | Description                                                                                                  |
| --- | --- |
| Signature discovery     | Reads input parameters, output parameters, and the return value of `Procedure` from the server.               |
| Named input values      | Binds `Parameters` JSON properties to procedure inputs by name, without regard to case or the `@` prefix.     |
| Strict input matching   | Fails before execution when `Parameters` names an input the procedure does not declare.                      |
| NULL for omitted inputs | Sends every input that `Parameters` leaves out as NULL.                                                      |
| All result sets         | Returns the first result set as `Result` and every result set as `ResultSets`.                               |
| Output parameters       | Returns output parameters as one JSON object in `OutputParameters`.                                          |
| Return value            | Returns the procedure status code in `ReturnValue`.                                                          |
| Optional transaction    | Commits on success and rolls back on failure when `Transaction` is present.                                  |
| Flexible connection     | Connects through a credentials record, a connection string, or a Microsoft Entra access token.               |
| Entity control          | Omits the response entity when `NoEntity` is present while still writing session parameters.                 |

### Usages in RPA

| Use Case                    | Description                                                                                 |
| --- | --- |
| Look up business records    | Call a lookup procedure, such as orders for a customer, and feed the rows into later steps. |
| Run business operations     | Call procedures that post invoices, close orders, or archive data inside a transaction.     |
| Read status codes           | Branch the workflow on the return value or an output parameter set by the procedure.        |
| Trigger batch jobs          | Start nightly refresh or cleanup procedures with a longer `CommandTimeout`.                 |

### Usages in Automation Testing

| Use Case                 | Description                                                                                  |
| --- | --- |
| Verify backend results   | Compare procedure rows or output parameters with values shown in the application under test. |
| Prepare test data        | Call seeding or reset procedures before a test and roll back failures with `Transaction`.    |
| Validate procedure logic | Assert return codes and output parameters for known inputs.                                  |
| Check data after actions | Confirm that a user action in the UI produced the expected database state.                   |

### Connection Resolution

1. `Credentials` selects a stored SQL Server credentials record by name or id.
2. When no record matches, a `Credentials` value that contains `=` is used as a raw connection string, and any other value is used as a raw Microsoft Entra access token.
3. Without `Credentials`, `ConnectionString` supplies the connection.
4. `Token` supplies a raw Microsoft Entra access token, for a connection that carries no password or `Authentication` keyword.
5. The step fails when no server is resolved.

### Output Shapes

| Output             | Shape                                                                                       |
| --- | --- |
| `Result`           | JSON array of row objects from the first result set, such as `[{"OrderId":1001,"Total":250.00}]`. |
| `ResultSets`       | JSON array of row arrays, one per result set, such as `[[{"OrderId":1001}],[{"Lines":3}]]`.   |
| `OutputParameters` | JSON object of output parameters without the `@` prefix, such as `{"TotalCount":12}`.          |
| `ReturnValue`      | Plain integer text, such as `0`.                                                              |

Session parameters are named `InvokeSqlServerProcedure:<Name>` and are Base64-encoded, so decode them before use.
JSON values map NULL to null, dates to ISO 8601 text, binary data to Base64, and unique identifiers to strings.

## Examples

### Example No.1

### Call a lookup procedure with stored credentials

Runs dbo.GetCustomerOrders with CustomerId 7 through the stored credentials record sql-production.
The orders, the TotalCount output parameter, and the return value are written to session parameters and the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerProcedure",
    Argument = "{{$ --Procedure:dbo.GetCustomerOrders --Parameters:{"CustomerId":7} --Credentials:sql-production}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerProcedure")
    .setArgument("{{$ --Procedure:dbo.GetCustomerOrders --Parameters:{"CustomerId":7} --Credentials:sql-production}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerProcedure",
    argument: "{{$ --Procedure:dbo.GetCustomerOrders --Parameters:{"CustomerId":7} --Credentials:sql-production}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.GetCustomerOrders --Parameters:{"CustomerId":7} --Credentials:sql-production}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.GetCustomerOrders --Parameters:{"CustomerId":7} --Credentials:sql-production}}"
}
```

### Example No.2

### Archive orders in a transaction with a connection string

Runs dbo.ArchiveClosedOrders with a cutoff date and batch size through a raw connection string.
Transaction commits the work only on success, and NoEntity returns the results only as session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerProcedure",
    Argument = "{{$ --Procedure:dbo.ArchiveClosedOrders --Parameters:{"BeforeDate":"2026-01-01","BatchSize":500} --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Transaction --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerProcedure")
    .setArgument("{{$ --Procedure:dbo.ArchiveClosedOrders --Parameters:{"BeforeDate":"2026-01-01","BatchSize":500} --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Transaction --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerProcedure",
    argument: "{{$ --Procedure:dbo.ArchiveClosedOrders --Parameters:{"BeforeDate":"2026-01-01","BatchSize":500} --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Transaction --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.ArchiveClosedOrders --Parameters:{"BeforeDate":"2026-01-01","BatchSize":500} --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Transaction --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.ArchiveClosedOrders --Parameters:{"BeforeDate":"2026-01-01","BatchSize":500} --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Transaction --NoEntity}}"
}
```

### Example No.3

### Run a parameterless procedure with a connection string

Runs dbo.RefreshDailyTotals on localhost,1433 with Windows sign-in and a 120-second timeout.
No Parameters value is passed, so any procedure inputs are sent as NULL.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeSqlServerProcedure",
    Argument = "{{$ --Procedure:dbo.RefreshDailyTotals --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandTimeout:120}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeSqlServerProcedure")
    .setArgument("{{$ --Procedure:dbo.RefreshDailyTotals --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandTimeout:120}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeSqlServerProcedure",
    argument: "{{$ --Procedure:dbo.RefreshDailyTotals --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandTimeout:120}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.RefreshDailyTotals --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandTimeout:120}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeSqlServerProcedure",
    "argument": "{{$ --Procedure:dbo.RefreshDailyTotals --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --CommandTimeout:120}}"
}
```

## Output Parameter

### Invoke Sql Server Procedure Output Parameters (InvokeSqlServerProcedure:OutputParameters)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the procedure output parameters as a minified JSON object keyed by parameter name without the @ prefix, such as {"TotalCount":12}.
Values follow the same JSON mapping as result rows, so NULL becomes null and dates use ISO 8601 text.
Holds an empty object {} when the procedure declares no output parameters.
Stored as a Base64-encoded session parameter, so decode it before use.

### Invoke Sql Server Procedure Result (InvokeSqlServerProcedure:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the rows of the first result set as a minified JSON array of row objects keyed by column name.
Holds an empty array [] when the procedure returns no result set.
Gives later steps the main query output without parsing every result set.
Stored as a Base64-encoded session parameter, so decode it before use.

### Invoke Sql Server Procedure Result Sets (InvokeSqlServerProcedure:ResultSets)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds every result set the procedure returns as a minified JSON array of row arrays, in server order.
Lets later steps read the second and later result sets that Result does not include.
Stored as a Base64-encoded session parameter, so decode it before use.

### Invoke Sql Server Procedure Return Value (InvokeSqlServerProcedure:ReturnValue)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Holds the integer status the procedure returns with RETURN, as plain text such as 0.
SQL Server returns 0 when the procedure has no explicit RETURN statement.
Lets later steps branch on success or failure codes defined by the procedure.
Stored as a Base64-encoded session parameter, so decode it before use.

## Parameters

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 30                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many seconds the procedure may run before the step fails with a timeout error.
Defaults to 30 seconds, and the value 0 waits without a time limit.
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
Session parameters such as InvokeSqlServerProcedure:Result are still written.

### Parameters (Parameters)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides input values as a JSON object whose property names match procedure parameter names, such as {"CustomerId":7}.
Names match without regard to case and with or without the @ prefix, and a name the procedure does not declare fails the step before anything runs.
Inputs left out are sent as NULL, so declared parameter defaults do not apply.
Values are bound as typed parameters and are never joined into SQL text.

### Procedure (Procedure)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the stored procedure to run, optionally with its schema, such as dbo.GetCustomerOrders.
The parameter list, output parameters, and return value are read from the server, so no parameter types need to be declared.
The step fails before connecting when the name is empty.

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

Runs the procedure inside one transaction that commits when the call succeeds and rolls back when it fails.
Protects data from partial changes when the procedure does not manage its own transaction.

## Scope

* Any
