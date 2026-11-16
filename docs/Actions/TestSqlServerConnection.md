# Test Sql Server Connection (TestSqlServerConnection)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Tests whether an automation can open a connection to a SQL Server database.
Reports the result as data instead of failing the step, so a flow can check database availability before it reads or writes data.
Supports a stored credentials record or a full connection string, so every connection detail stays in one place.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                          |
| --- | --- |
| Connection check           | Opens and immediately closes a connection to confirm that the server accepts the login.                                                              |
| Non-failing result         | Reports `Connected` as `false` with the client error message when SQL Server rejects the login or cannot be reached.                                 |
| Flexible connection input  | Resolves the target from a credentials name or id, a raw connection string, or a raw Microsoft Entra access token.                                   |
| Entra token sign-in        | Signs in with a raw Microsoft Entra access token from `Token`, next to a connection that carries no password.                                        |
| Server details             | Returns the database name and server version reported by the opened connection.                                                                      |
| Session and entity outputs | Stores outputs as Base64 session parameters named `TestSqlServerConnection:<Name>` and returns them in the response entity unless `NoEntity` is set. |

### Usages in RPA

| Use Case                 | Description                                                                                  |
| --- | --- |
| Pre-run health check     | Confirm that the reporting database is reachable before a bot starts a long data job.        |
| Conditional fallback     | Branch to a retry, a notification, or a secondary server when `Connected` is `false`.        |
| Environment verification | Confirm that a credentials record reaches the expected database before deployment steps run. |

### Usages in Automation Testing

| Use Case                   | Description                                                                 |
| --- | --- |
| Test environment readiness | Verify that the test database is up before data-driven test suites run.     |
| Credentials validation     | Check that stored test credentials still sign in after a password rotation. |
| Version gating             | Skip or adapt tests based on the reported SQL Server version.               |

### Notes

A step that resolves no server from Credentials or ConnectionString fails instead of reporting `Connected` as `false`.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Test a connection with a credentials name

The `{{$ --Credentials:sql-production}}` argument binds the stored credentials record named `sql-production` at runtime.
The step reports whether the connection opened and stores the result in session parameters and the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestSqlServerConnection",
    Argument = "{{$ --Credentials:sql-production}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestSqlServerConnection")
    .setArgument("{{$ --Credentials:sql-production}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestSqlServerConnection",
    argument: "{{$ --Credentials:sql-production}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --Credentials:sql-production}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --Credentials:sql-production}}"
}
```

### Example No.2

### Test a connection string without a response entity

The argument binds a full connection string to `localhost,1433` with Windows sign-in and the `NoEntity` switch.
The outputs are stored only as session parameters.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestSqlServerConnection",
    Argument = "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestSqlServerConnection")
    .setArgument("{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestSqlServerConnection",
    argument: "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --ConnectionString:Server=localhost,1433;Database=Sales;Integrated Security=True;TrustServerCertificate=True --NoEntity}}"
}
```

### Example No.3

### Test a connection with a Microsoft Entra access token

The argument binds a connection string that names the server and the database only, plus the `Token` value that signs in the connection.
The step signs in with the access token and reports the result.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestSqlServerConnection",
    Argument = "{{$ --ConnectionString:Server=sql01.database.windows.net;Database=Sales;Encrypt=Mandatory --Token:eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestSqlServerConnection")
    .setArgument("{{$ --ConnectionString:Server=sql01.database.windows.net;Database=Sales;Encrypt=Mandatory --Token:eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestSqlServerConnection",
    argument: "{{$ --ConnectionString:Server=sql01.database.windows.net;Database=Sales;Encrypt=Mandatory --Token:eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --ConnectionString:Server=sql01.database.windows.net;Database=Sales;Encrypt=Mandatory --Token:eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --ConnectionString:Server=sql01.database.windows.net;Database=Sales;Encrypt=Mandatory --Token:eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9}}"
}
```

## Output Parameter

### Test Sql Server Connection Connected (TestSqlServerConnection:Connected)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores `true` when the connection opened and `false` when SQL Server rejected the login or could not be reached.
Lets later steps branch on database availability without failing the flow.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Sql Server Connection Database (TestSqlServerConnection:Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the name of the database the connection opened in.
Confirms which database the login reached, including the login default database when none was requested.
Stays empty when the connection fails.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Sql Server Connection Error (TestSqlServerConnection:Error)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the SQL Server client message when the connection fails, such as a login failure or a network error.
Stays empty when the connection succeeds.
Gives reports and logs a clear reason for an unreachable server.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Sql Server Connection Server Version (TestSqlServerConnection:ServerVersion)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the SQL Server version reported by the server, such as `16.00.1000`.
Helps checks confirm that a server meets a version requirement.
Stays empty when the connection fails.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Parameters

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
