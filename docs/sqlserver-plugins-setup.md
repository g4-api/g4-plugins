# SQL Server Plugins Setup

[Home](./Home.md)

This page explains what you need before the 8 SQL Server plugins can reach a database. Every fact below comes from the
plugin code in `src/G4.Plugins.SqlServer` and the test fixture in `src/G4.UnitTests`. Where the code does not say, the
page says so.

## What the plugins do

| Plugin | Type | What it does |
| --- | --- | --- |
| [TestSqlServerConnection](./Actions/TestSqlServerConnection.md) | Action | Opens a connection and reports `Connected`, `Database`, `ServerVersion` and `Error`. It never fails on a login error. |
| [GetSqlServerScalar](./Actions/GetSqlServerScalar.md) | Action | Returns the first column of the first row as `Value`. |
| [InvokeSqlServerNonQuery](./Actions/InvokeSqlServerNonQuery.md) | Action | Runs an `INSERT`, `UPDATE`, `DELETE` or DDL command and returns `RowsAffected`. |
| [ExportSqlServerQuery](./Actions/ExportSqlServerQuery.md) | Action | Runs a query and returns `Result`, `ResultSets`, `Columns` and `RowCount`. |
| [InvokeSqlServerProcedure](./Actions/InvokeSqlServerProcedure.md) | Action | Calls a stored procedure and returns `Result`, `ResultSets`, `OutputParameters` and `ReturnValue`. |
| [InvokeSqlServerScript](./Actions/InvokeSqlServerScript.md) | Action | Splits a script on `GO` lines like `sqlcmd` and returns `BatchCount` and `RowsAffected`. |
| [ImportSqlServerData](./Actions/ImportSqlServerData.md) | Action | Bulk copies JSON or CSV rows into an existing table and returns `RowsCopied`. |
| [SqlServerDataCollector](./DataCollectors/SqlServerDataCollector.md) | Data collector | Writes every extracted entity to a table and creates the schema, table and missing columns. |

Source: `Actions/*.cs`, `DataCollectors/SqlServerDataCollector.cs`. The plugin pages are generated from the plugin
manifests.

## What you need before you start

1. A reachable SQL Server instance. The actions use plain T-SQL. The data collector needs SQL Server 2017 or later,
   because it uses `STRING_AGG` and `OPENJSON`. Source: `DataCollectors/SqlServerDataCollector.cs`.
2. Network access from the machine that runs G4 to the server port, which is `1433` unless the instance uses another
   one.
3. A login that holds the permissions your SQL needs. The data collector also needs permission to create schemas,
   tables and columns when they are missing.
4. Nothing else to install. `Microsoft.Data.SqlClient` is the only database dependency, and it comes in as a package
   dependency of the plugins.

## Three ways to connect

Every plugin takes the connection inputs below. All of them are optional, but together they must name a server.

| Input | What you pass | When to use it |
| --- | --- | --- |
| `Credentials` | The name or id of a stored SQL Server credentials record | Shared logins. The login stays out of the automation definition. |
| `ConnectionString` | A full ADO.NET connection string | Quick tests and servers with special connection keywords. |
| Discrete overrides | `Server`, `Port`, `Database`, `Authentication`, `Username`, `Password`, `Encrypt`, `TrustServerCertificate`, `Token` | Changing one part of a stored login, such as the database, for one step. |

### Stored credentials records

A SQL Server credentials record holds these fields.

| Field | Meaning |
| --- | --- |
| `Name` | The friendly name you pass as `Credentials`. The record id works too. |
| `Server` | The host, host with instance name, or network address. |
| `Port` | The TCP port. `0` means no explicit port, so the server name decides the endpoint. |
| `Database` | The initial database. Empty keeps the login default database. |
| `Authentication` | One of the authentication values listed below. Empty lets the connection string or the provider decide. |
| `Username` | The login name or principal identifier. |
| `Password` | The password or secret for password-based methods. |
| `Encrypt` | One of the `Encrypt` values listed below. Empty keeps the provider default. |
| `TrustServerCertificate` | `true` accepts the server certificate without validating its trust chain. |
| `ConnectionString` | An optional baseline connection string. The fields above that are set override it. |

The engine stores the secrets of a record in its protected form: signed and Base64URL encoded. This form is not
encryption, so treat the credentials database as sensitive.

The engine saves records with `CredentialsManager.SaveSqlServerCredentials` and caches them in the `SqlServer` partition
of the engine credentials cache. The plugins read only that partition. They match the record id first, then the name,
and ignore case in both. A new or changed record reaches the plugins after the next cache synchronization. An engine
restart or a call to `GET /api/v4/g4/integration/cache/sync` on the hub runs that synchronization. Source:
`Extensions/LocalExtensions.cs` (`FindCredential`).

### Raw input

The plugins accept raw values when you do not use a stored record.

1. A `Credentials` value that matches no record and contains `=` is used as a raw connection string.
2. A `Credentials` value that matches no record and contains no `=` is used as a raw Microsoft Entra access token.
3. `ConnectionString` is used as the connection string when `Credentials` is empty.
4. `Token` sets a Microsoft Entra access token explicitly. A raw token in `Credentials` replaces it.

When an access token is set, the connection string must not carry a password or an `Authentication` keyword. Source:
`Models/SqlServerConnectionModel.cs`.

### Resolution order

The plugins build the connection in this order. Source: `Extensions/LocalExtensions.cs` (`ResolveConnection`).

1. A stored record that matches `Credentials` by id or name supplies the baseline.
2. Otherwise, a `Credentials` value with `=` is the baseline connection string.
3. Otherwise, a non-empty `Credentials` value becomes the access token, and the baseline stays empty.
4. Otherwise, `ConnectionString` is the baseline.
5. The discrete overrides that are set replace the matching baseline values. Unset overrides never erase a baseline
   value.
6. The `TrustServerCertificate` switch turns certificate trust on.
7. The step fails with "No SQL Server target was resolved. Set 'Credentials', 'ConnectionString', or 'Server'." when no
   server results.

`Server` and `Port` combine into `server,port`. One stored login can therefore target several databases through the
`Database` override.

### Authentication values

| Value | Signs in with |
| --- | --- |
| `Sql Password` | A SQL Server login name and password. |
| `Integrated` | The Windows identity of the running process. G4 maps it to `Integrated Security`. |
| `Active Directory Default` | A Microsoft Entra identity from the default credential chain. |
| `Active Directory Integrated` | The Microsoft Entra identity of the current Windows session. |
| `Active Directory Interactive` | A Microsoft Entra account through an interactive sign-in. |
| `Active Directory Managed Identity` | The managed identity of the hosting Azure resource. |
| `Active Directory Password` | A Microsoft Entra user name and password. |
| `Active Directory Service Principal` | A Microsoft Entra application id and secret. |

The values match the `Authentication` keyword of `Microsoft.Data.SqlClient`, so G4 passes them unchanged. Source: the
engine type `G4.Credentials.Models.SqlServerAuthenticationTypes`.

### Encrypt values

| Value | Effect |
| --- | --- |
| `Mandatory` | Requires TLS encryption for the connection. |
| `Optional` | Encrypts only when the server requires it. |
| `Strict` | Requires Tabular Data Stream (TDS) 8.0 strict encryption, where TLS starts before any TDS traffic. |

## Send SQL to the server

### Command inputs

`GetSqlServerScalar`, `InvokeSqlServerNonQuery`, `ExportSqlServerQuery` and `InvokeSqlServerScript` read their SQL from
`CommandText` or `CommandFile`. The `Base64` switch changes how the plugin reads `CommandText`.

| Input | What you pass |
| --- | --- |
| `CommandText` | The SQL inline in the rule argument. It wins when both `CommandText` and `CommandFile` are set. |
| `CommandFile` | The path to a UTF-8 `.sql` file. |
| `Base64` | A switch. It marks `CommandText` as UTF-8 Base64, which the plugin decodes before it runs the SQL. |

Inline arguments are CLI values, so ` --` starts the next argument and `}}` closes the argument block. A SQL comment
such as ` -- note` therefore cuts the inline command short. SQL that contains ` --` or `}}` reaches the server in one of
two ways.

1. Pass it in `CommandText` as UTF-8 Base64 and set the `Base64` switch. Base64 text never contains ` --` or `}}`.
2. Save it in a `CommandFile`. The argument parser never reads the file content.

With the `Base64` switch, the plugin decodes only `CommandText`. `CommandFile` content is always plain text, and
`Parameters` is never decoded. When `CommandText` is not valid Base64, the step fails with "'CommandText' is not valid
Base64. Encode the SQL as UTF-8 Base64 or remove the 'Base64' switch." The undecoded text never reaches the server.
Source: `Extensions/LocalExtensions.cs` (`ResolveCommandText`).

`CommandTimeout` sets the timeout in seconds. The default is `30`, and `0` means no timeout. `InvokeSqlServerScript`
applies it to each batch, and `ImportSqlServerData` applies it to the bulk copy.

### Parameters

`Parameters` takes a JSON object. Each property becomes one bound SQL parameter, and G4 adds the `@` prefix when it is
missing. Values are never concatenated into the SQL text.

| JSON value | Bound as |
| --- | --- |
| String | `string` |
| `true` or `false` | `bool` |
| Integer number | `bigint` |
| Other number | `decimal` |
| `null` | `DBNull` |
| Object or array | Its JSON text |

`InvokeSqlServerProcedure` reads the procedure signature from the server, so you declare no types. Input names match
case-insensitively, an unknown name fails the step, and unassigned inputs are sent as `NULL`.

### Transactions

`InvokeSqlServerNonQuery`, `InvokeSqlServerProcedure`, `InvokeSqlServerScript` and `ImportSqlServerData` take the
`Transaction` switch. With it, the plugin wraps its work in one transaction. It commits when the work succeeds and rolls
back when any part fails. For `InvokeSqlServerScript`, a failing batch also rolls back every earlier batch.

## Read the outputs

Each output is stored as the session parameter `<Key>:<Name>`, for example `ExportSqlServerQuery:Result`. The value is
Base64 encoded. Returned data such as `Result`, `ResultSets`, `Columns` and `OutputParameters` is minified JSON before
encoding.

By default, the plugin also returns the same outputs in the response entity, with unqualified names and plain text.
The `NoEntity` switch omits the entity.

The JSON uses these value forms: `null` for database nulls, ISO 8601 for dates, Base64 for binary values, exact numbers
for decimals and text for `uniqueidentifier` values.

For example, a query that returns one row stores `ExportSqlServerQuery:Result` as
`W3siSWQiOjEsIk5hbWUiOiJBZGEifV0=`. Decoding it gives the JSON text.

```powershell
[System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String('W3siSWQiOjEsIk5hbWUiOiJBZGEifV0='))
# [{"Id":1,"Name":"Ada"}]
```

Inside an automation, the [DecodeBase64](./Transformers/DecodeBase64.md) transformer decodes a session parameter.

## Use the plugins in a rule

### Check the connection

```json
{
    "$type": "Action",
    "pluginName": "TestSqlServerConnection",
    "argument": "{{$ --Credentials:sql-production }}"
}
```

### Run a query with parameters

```json
{
    "$type": "Action",
    "pluginName": "ExportSqlServerQuery",
    "argument": "{{$ --Credentials:sql-production --CommandText:SELECT Id, Name FROM dbo.Customers WHERE Country = @Country --Parameters:{\"Country\":\"US\"} }}"
}
```

### Change one database inside a transaction

```json
{
    "$type": "Action",
    "pluginName": "InvokeSqlServerNonQuery",
    "argument": "{{$ --Credentials:sql-production --Database:Sales --CommandText:UPDATE dbo.Orders SET Status = @Status WHERE Id = @Id --Parameters:{\"Status\":\"Closed\",\"Id\":42} --Transaction --NoEntity }}"
}
```

### Connect with a raw connection string

```json
{
    "$type": "Action",
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --ConnectionString:Server=db01,1433;Database=Sales;User ID=g4;Password=<password>;Encrypt=Mandatory --CommandText:SELECT COUNT(*) FROM dbo.Orders }}"
}
```

### Run Base64-encoded SQL

The `CommandText` value is the Base64 form of `SELECT COUNT(*) FROM dbo.Orders -- every status`. The trailing comment
would cut a plain inline value short.

```json
{
    "$type": "Action",
    "pluginName": "GetSqlServerScalar",
    "argument": "{{$ --Credentials:sql-production --CommandText:U0VMRUNUIENPVU5UKCopIEZST00gZGJvLk9yZGVycyAtLSBldmVyeSBzdGF0dXM= --Base64 }}"
}
```

### Run a script from a file

```json
{
    "$type": "Action",
    "pluginName": "InvokeSqlServerScript",
    "argument": "{{$ --Credentials:sql-production --CommandFile:C:\\scripts\\seed.sql --Transaction }}"
}
```

### Collect extracted data into a table

The data collector reads `source` as a credentials name or id, a raw connection string or a raw token. It reads
`repository` as the table, with `default-warehouse` in `dbo` as the default.

```json
{
    "$type": "Extraction",
    "dataCollector": {
        "forEntity": true,
        "repository": "dbo.HotelLocations",
        "source": "sql-production",
        "type": "SqlServerDataCollector"
    },
    "extractionScope": "Elements",
    "onElement": "//div[@class='hotel']",
    "pluginName": "ExportData",
    "rules": [
        {
            "$type": "Content",
            "key": "Location",
            "onElement": ".//p[starts-with(.,'Location:')]"
        }
    ]
}
```

New tables and columns are `NVARCHAR(MAX) NULL`. Existing columns are never altered. Strings are stored raw, and other
values are stored as minified JSON.

## Run the tests locally

The live tests start one disposable `mcr.microsoft.com/mssql/server:2022-latest` container on a free loopback port and
create the `G4Tests` database. The container is removed when the test process exits. Source:
`src/G4.UnitTests/Framework/SqlServerTestContainer.cs`.

1. Start Docker. Docker Desktop and Docker under WSL both work on Windows.
2. Run the live tests.

    ```powershell
    dotnet test src/G4.UnitTests/G4.UnitTests.csproj --filter "TestCategory=SqlServerLive"
    ```

3. Read the result. Without Docker, the live tests report Inconclusive instead of failing.

Two environment variables change this behavior.

| Variable | Effect |
| --- | --- |
| `G4_SQLSERVER_CONNECTION` | Uses an existing server instead of a container. The connection string must point to a database the tests may write to. |
| `G4_SQLSERVER_REQUIRED` | When `true`, a missing server fails the tests instead of reporting Inconclusive. |

CI runs the live tests on a Linux job named `InvokeSqlServerTests`, with `G4_SQLSERVER_REQUIRED` set to `true`. The main
test job excludes them with `TestCategory!=SqlServerLive`.

## If it fails

| Symptom | Likely cause | What to do |
| --- | --- | --- |
| "Login failed for user" | Wrong user name or password, or the login has no access to the database | Check the login with `TestSqlServerConnection`, and read its `Error` output. |
| "The certificate chain was issued by an authority that is not trusted" | The server uses a self-signed or private certificate | Add the `TrustServerCertificate` switch for test servers, or install the issuing certificate. `--Encrypt:Optional` also avoids the check when the server allows it. |
| "No SQL Server target was resolved" | No `Credentials`, `ConnectionString` or `Server` named a server, or a misspelled record name was used as a token | Pass one of the three inputs, and check the record name. |
| "The procedure has no input parameter named '@Name'" | A `Parameters` property matches no procedure input | Use the input names from the procedure signature. |
| "Incorrect syntax near ..." on SQL that runs elsewhere | The inline SQL was cut by ` --` or `}}` | Encode the SQL as UTF-8 Base64 and add the `Base64` switch, or move it to a `CommandFile`. |
| "'CommandText' is not valid Base64." | The `Base64` switch is set, but `CommandText` is plain SQL or damaged Base64 | Encode the SQL as UTF-8 Base64, or remove the `Base64` switch. |
| "Either 'CommandText' or 'CommandFile' is required." | No SQL was given | Pass `CommandText` or `CommandFile`. |

## Good to know

- `TestSqlServerConnection` reports `Connected` as `false` instead of failing, so a rule can branch on it.
- `ExportSqlServerQuery` reports `Columns` even when the query returns no rows.
- `ImportSqlServerData` maps columns by name, needs an existing table and lets the server convert text to column types.
- The SQL Server plugin pages are generated by `src/G4.DocumentsGenerator`. See the note at the top of
  [Home](./Home.md).
