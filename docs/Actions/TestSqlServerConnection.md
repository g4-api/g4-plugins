# Test Sql Server Connection (TestSqlServerConnection)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Tests whether an automation can open a connection to a SQL Server database.
Reports the result as data instead of failing the step, so a flow can check database availability before it reads or writes data.
Supports stored credentials, full connection strings, and discrete server, database, and sign-in settings.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                          |
| --- | --- |
| Connection check           | Opens and immediately closes a connection to confirm that the server accepts the login.                                                              |
| Non-failing result         | Reports `Connected` as `false` with the client error message when SQL Server rejects the login or cannot be reached.                                 |
| Flexible connection input  | Resolves the target from a credentials name or id, a raw connection string, or a raw Microsoft Entra access token.                                   |
| Discrete overrides         | Applies Server, Port, Database, Authentication, Username, Password, Encrypt, TrustServerCertificate, and Token on top of the resolved connection.    |
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

A step that resolves no server from Credentials, ConnectionString, or Server fails instead of reporting `Connected` as `false`.
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

### Test a connection with discrete settings

The argument binds Server, Port, Database, Authentication, and Encrypt values plus the `TrustServerCertificate` switch.
The step signs in with the Windows identity and reports the result.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestSqlServerConnection",
    Argument = "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --Encrypt:Mandatory --TrustServerCertificate}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestSqlServerConnection")
    .setArgument("{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --Encrypt:Mandatory --TrustServerCertificate}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestSqlServerConnection",
    argument: "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --Encrypt:Mandatory --TrustServerCertificate}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --Encrypt:Mandatory --TrustServerCertificate}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --Server:localhost --Port:1433 --Database:Sales --Authentication:Integrated --Encrypt:Mandatory --TrustServerCertificate}}"
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

### Authentication (Authentication)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the connection signs in to SQL Server, such as a SQL login, the Windows identity, or a Microsoft Entra method.
Overrides the authentication method from the credentials or the connection string for this step only.
Choosing the right method avoids login failures on servers that accept only certain sign-in types.

#### Values

##### Sql Password

Signs in with a SQL Server login name and password.
Use it together with the Username and Password parameters.

##### Integrated

Signs in with the Windows identity of the account that runs the automation.
No user name or password is sent with the connection.

##### Active Directory Default

Signs in with the first available Microsoft Entra identity on the machine, such as a managed identity or developer tool sign-in.
Suits automation that moves between local machines and cloud hosts.

##### Active Directory Integrated

Signs in with the Microsoft Entra identity of the signed-in Windows user.
Works on domain-joined or Entra-joined machines without a password.

##### Active Directory Interactive

Opens a Microsoft Entra sign-in prompt for the user.
Fits attended runs where a person can complete the sign-in, including multi-factor prompts.

##### Active Directory Managed Identity

Signs in with the managed identity of the Azure resource that runs the automation.
Keeps stored secrets out of cloud-hosted runs.

##### Active Directory Password

Signs in with a Microsoft Entra user name and password.
Use it together with the Username and Password parameters.

##### Active Directory Service Principal

Signs in as a Microsoft Entra application.
Pass the application id as Username and the client secret as Password.

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
Discrete parameters such as Server or Database still override the matching parts of the string.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored SQL Server credentials record by name or id, such as `sql-production`, so secrets stay out of the rule.
When no record matches, a value that contains `=` is used as a raw connection string and any other value is used as a raw Microsoft Entra access token.
Takes priority over ConnectionString, while discrete parameters such as Database still override the resolved values.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the database the connection opens in, such as `Sales`.
Overrides the database from the credentials or connection string, so one stored login can reach several databases.

### Encrypt (Encrypt)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the transport encryption mode of the connection.
Overrides the encryption setting from the credentials or connection string when a server requires a specific mode.

#### Values

##### Mandatory

Requires an encrypted connection and validates the server certificate unless TrustServerCertificate is set.
Fits most production servers.

##### Optional

Encrypts the connection only when the server requires it.
Suits local development servers without a trusted certificate.

##### Strict

Encrypts the connection before login and always validates the server certificate.
Requires a server that supports TDS 8.0, such as SQL Server 2022 or Azure SQL Database.

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

### Password (Password)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the password used with the Username login.
Overrides the password from the credentials or connection string for this step.
Prefer Credentials over a plain password so secrets are not stored in the rule.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the TCP port of the server, such as `1433`, and joins it to Server as `server,port`.
Applies only when Server is set in the same step, because the port is combined with that server name.

### Server (Server)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the SQL Server host name or address, such as `localhost` or `db01\SQLEXPRESS`.
Overrides the server from the credentials or connection string.
The step fails when no server is resolved from Credentials, ConnectionString, or Server.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a raw Microsoft Entra access token that signs in the connection.
Enables token sign-in without a stored password.
Do not combine it with Password or Authentication, because the SQL Server client rejects that mix when the connection opens.

### Trust Server Certificate (TrustServerCertificate)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Accepts the server certificate without validating it against a trusted authority.
Helps connect to development servers that use a self-signed certificate.
Avoid it in production, because it removes protection against a spoofed server.

### Username (Username)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the login name used with Password, such as a SQL login or a Microsoft Entra user or application id.
Overrides the user name from the credentials or connection string for this step.

## Scope

* Any
