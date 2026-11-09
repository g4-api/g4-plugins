# Import Sql Server Data (ImportSqlServerData)

[Table of Content](../Home.md)

~21 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

ImportSqlServerData loads rows into an existing SQL Server table during an automation run.
It reads the rows from a CSV file, a JSON file, or an inline JSON array and sends them with SQL Server bulk copy, which is much faster than inserting rows one by one.
It helps workflows seed test data, load exported records, and move files into a database without writing SQL.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Bulk copy import | Sends all rows to the destination table with SQL Server bulk copy, optionally in batches set by BatchSize. |
| Flexible data input | Accepts inline JSON through Data, or a file through DataFile: .csv files are read as RFC 4180 CSV with a header row, other files as JSON. |
| Column matching by name | Maps each data field to the table column with the same name, so the field order does not matter. |
| Type conversion | Sends values as text and converts them to the destination column types during the copy; empty unquoted CSV fields and JSON null become NULL. |
| Flexible connection | Resolves the connection from a stored credentials record, a connection string, or individual values such as Server, Database, and Authentication. |
| Optional transaction | The Transaction switch commits the import only after every row is copied and rolls everything back on failure. |
| Row count output | Stores the copied row count as the session parameter ImportSqlServerData:RowsCopied (Base64) and, unless NoEntity is set, in the response entity. |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Load exported files | Imports CSV or JSON exports from other systems into a staging or reporting table. |
| Save collected records | Writes records gathered earlier in the run, passed as an inline JSON array, into a database table. |
| Scheduled data feeds | Loads a daily or hourly file into SQL Server as one all-or-nothing transaction. |
| Cross-system migration | Moves rows between systems by exporting them to a file and importing that file into SQL Server. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| Seed test data | Loads known rows into tables before a test so the application under test starts from a predictable state. |
| Data-driven fixtures | Imports a CSV fixture per scenario, so testers change data without changing the automation. |
| Import volume checks | Compares ImportSqlServerData:RowsCopied with the expected row count to confirm a complete load. |

### Requirements and Limitations

| Item | Description |
| --- | --- |
| Existing table | The destination table must already exist; the import never creates tables or columns. |
| Matching column names | Every data field must match a column in the table, or the copy fails. |
| Flat rows | Nested JSON objects or arrays are stored as JSON text in the matching column. |
| Bulk copy defaults | Check and foreign key constraints are not checked, triggers do not fire, and values supplied for identity columns are replaced by new server-generated values. |
| Partial imports | Without Transaction, batches that were already sent stay in the table when a later batch fails. |

## Examples

### Example No.1

### Import a CSV file into a table inside a transaction

The parameter syntax binds `Credentials` to the stored record `sql-production`, `Table` to `dbo.Customers`, and `DataFile` to `C:\data\customers.csv`.
The `Transaction` switch commits the rows only after all of them are copied.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportSqlServerData",
    Argument = "{{$ --Credentials:sql-production --Table:dbo.Customers --DataFile:C:\data\customers.csv --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportSqlServerData")
    .setArgument("{{$ --Credentials:sql-production --Table:dbo.Customers --DataFile:C:\data\customers.csv --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportSqlServerData",
    argument: "{{$ --Credentials:sql-production --Table:dbo.Customers --DataFile:C:\data\customers.csv --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Credentials:sql-production --Table:dbo.Customers --DataFile:C:\data\customers.csv --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Credentials:sql-production --Table:dbo.Customers --DataFile:C:\data\customers.csv --Transaction}}"
}
```

### Example No.2

### Import inline JSON rows with a connection string

The parameter syntax binds `ConnectionString` to a full ADO.NET connection string and `Table` to `Customers` in the default `dbo` schema.
The `Data` value is an inline JSON array, and each object becomes one row.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportSqlServerData",
    Argument = "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Table:Customers --Data:[{"Id":1,"Name":"Ada"},{"Id":2,"Name":"Grace"}]}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportSqlServerData")
    .setArgument("{{$ --ConnectionString:Server=sql01.contoso.local;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Table:Customers --Data:[{"Id":1,"Name":"Ada"},{"Id":2,"Name":"Grace"}]}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportSqlServerData",
    argument: "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Table:Customers --Data:[{"Id":1,"Name":"Ada"},{"Id":2,"Name":"Grace"}]}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Table:Customers --Data:[{"Id":1,"Name":"Ada"},{"Id":2,"Name":"Grace"}]}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --ConnectionString:Server=sql01.contoso.local;Database=Sales;Integrated Security=true;TrustServerCertificate=true --Table:Customers --Data:[{"Id":1,"Name":"Ada"},{"Id":2,"Name":"Grace"}]}}"
}
```

### Example No.3

### Import a large JSON file in batches without an entity

The parameter syntax binds `Table` to the bracketed name `[sales].[Leads]`, `DataFile` to a JSON file, `BatchSize` to 5000 rows, and `CommandTimeout` to 300 seconds.
The `NoEntity` switch leaves the response entity empty.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportSqlServerData",
    Argument = "{{$ --Credentials:sql-production --Table:[sales].[Leads] --DataFile:C:\data\leads.json --BatchSize:5000 --CommandTimeout:300 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportSqlServerData")
    .setArgument("{{$ --Credentials:sql-production --Table:[sales].[Leads] --DataFile:C:\data\leads.json --BatchSize:5000 --CommandTimeout:300 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportSqlServerData",
    argument: "{{$ --Credentials:sql-production --Table:[sales].[Leads] --DataFile:C:\data\leads.json --BatchSize:5000 --CommandTimeout:300 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Credentials:sql-production --Table:[sales].[Leads] --DataFile:C:\data\leads.json --BatchSize:5000 --CommandTimeout:300 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Credentials:sql-production --Table:[sales].[Leads] --DataFile:C:\data\leads.json --BatchSize:5000 --CommandTimeout:300 --NoEntity}}"
}
```

### Example No.4

### Import a CSV file with individual connection values

The parameter syntax binds `Server`, `Database`, `Authentication`, and `Encrypt` instead of a stored record or connection string.
The rows from `C:\data\orders.csv` are copied into `dbo.Orders`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportSqlServerData",
    Argument = "{{$ --Server:sales-db.database.windows.net --Database:Sales --Authentication:Active Directory Default --Encrypt:Strict --Table:dbo.Orders --DataFile:C:\data\orders.csv}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportSqlServerData")
    .setArgument("{{$ --Server:sales-db.database.windows.net --Database:Sales --Authentication:Active Directory Default --Encrypt:Strict --Table:dbo.Orders --DataFile:C:\data\orders.csv}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportSqlServerData",
    argument: "{{$ --Server:sales-db.database.windows.net --Database:Sales --Authentication:Active Directory Default --Encrypt:Strict --Table:dbo.Orders --DataFile:C:\data\orders.csv}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Server:sales-db.database.windows.net --Database:Sales --Authentication:Active Directory Default --Encrypt:Strict --Table:dbo.Orders --DataFile:C:\data\orders.csv}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportSqlServerData",
    "argument": "{{$ --Server:sales-db.database.windows.net --Database:Sales --Authentication:Active Directory Default --Encrypt:Strict --Table:dbo.Orders --DataFile:C:\data\orders.csv}}"
}
```

## Output Parameter

### Import Sql Server Data Rows Copied (ImportSqlServerData:RowsCopied)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Stores the number of rows copied into the table as a Base64-encoded session parameter.
Later steps decode the value to confirm the import size or drive reporting.

## Properties

### Argument (Argument)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Carries every input of the import, such as Table, Data or DataFile, and the connection values, in the G4 parameter syntax {{$ --Name:Value --Switch}}.
Values can come from macros or data columns, so one rule can import different files or target different tables on each run.

## Parameters

### Authentication (Authentication)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects the sign-in method used for the connection, such as a SQL login or a Microsoft Entra identity.
Replaces the method from the stored credentials or the connection string for this step only.
Integrated signs in with the Windows identity that runs the automation.

#### Values

##### Active Directory Default

Signs in with the first Microsoft Entra identity found on the machine, such as an Azure CLI login or a managed identity.
Suits automation hosts that already carry a signed-in identity.

##### Active Directory Integrated

Signs in with the Microsoft Entra identity of the current Windows user.
Works on domain-joined machines that are federated with Microsoft Entra ID.

##### Active Directory Interactive

Opens an interactive Microsoft Entra sign-in prompt.
Fits attended runs where a person can complete the sign-in.

##### Active Directory Managed Identity

Signs in with the managed identity assigned to the Azure host.
Keeps secrets out of the automation on Azure-hosted runners.

##### Active Directory Password

Signs in with a Microsoft Entra user name and password.
Requires the Username and Password values.

##### Active Directory Service Principal

Signs in as a Microsoft Entra application, using the client id as Username and the client secret as Password.
Suits unattended service accounts.

##### Integrated

Signs in with the Windows identity that runs the automation.
Turns on integrated security instead of sending a user name and password.

##### Sql Password

Signs in with a SQL Server login name and password.
Requires the Username and Password values.

### Batch Size (BatchSize)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many rows are sent to SQL Server in each batch.
Smaller batches keep memory and log use low when importing very large files.
Leaving the value at 0 sends all rows in a single batch.

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 30                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets how many seconds the bulk copy may run before it is stopped.
A longer limit helps large imports finish on slow or busy servers.
The value 0 removes the time limit, and a missing or invalid value falls back to 30 seconds.

### Connection String (ConnectionString)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Provides a complete ADO.NET connection string for the target SQL Server database.
Used only when Credentials is not set, so a stored record always takes priority.
Individual values such as Server or Database can still replace parts of it.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored SQL Server credentials record by its name or id, so the login stays out of the automation definition.
When no record matches, a value that contains an equals sign is used as a raw connection string.
Any other unmatched value is used as a raw Microsoft Entra access token, which still needs a Server value.

### Data (Data)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the rows to import inline as a JSON array of flat objects, such as [{"Id":1,"Name":"Ada"}].
Each object becomes one row, and object properties are matched to table columns by name.
Takes priority over DataFile when both are set.
Use DataFile instead when the JSON contains the text " --" or "}}", because those end an inline value.

### Data File (DataFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Points to a file that holds the rows to import.
A .csv file is read as RFC 4180 CSV with a header row, and any other extension is read as a JSON array of objects.
Keeps large or complex data out of the rule argument.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Selects the database that the connection opens.
Lets one stored login import into several databases by changing only this value.

### Encrypt (Encrypt)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Controls whether the connection to SQL Server is encrypted.
Replaces the encryption mode from the stored credentials or the connection string for this step only.

#### Values

##### Mandatory

Requires an encrypted connection and validates the server certificate unless TrustServerCertificate is set.
Matches the default of current SQL Server client libraries.

##### Optional

Encrypts the connection only when the server requires it.
Fits older servers that do not support encryption.

##### Strict

Uses TDS 8.0 strict encryption and always validates the server certificate.
Requires SQL Server 2022 or Azure SQL.

### No Entity (NoEntity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Leaves the response entity empty so the plugin returns only session parameters.
Keeps responses small when no later step reads the entity.

### Password (Password)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the password for password-based sign-in methods.
Replaces the stored password for this step only.
Prefer a stored credentials record so secrets do not appear in the automation definition.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the TCP port of the SQL Server instance.
Is appended to the Server value as server,port and is needed only when the instance does not use the default port 1433.

### Server (Server)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the SQL Server host or instance, such as sql01.contoso.local or sql01\SQLEXPRESS.
Replaces the server from the stored credentials or the connection string for this step only.
The step fails with a clear message when no server is resolved from any connection input.

### Table (Table)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the existing destination table, as table, schema.table, or a bracketed name such as [sales].[Order Lines].
A name without a schema uses the dbo schema.
The table must already exist, because the import never creates or changes tables.

### Token (Token)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a raw Microsoft Entra access token that authenticates the connection.
Useful when another step already obtained a token for the database.
Do not combine it with a password or an Authentication value, because SQL Server rejects that combination.

### Transaction (Transaction)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Wraps the whole import in one transaction that is committed only after every row is copied.
Rolls back all rows when any row fails, so the table never keeps a partial import.

### Trust Server Certificate (TrustServerCertificate)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Accepts the server certificate without validating it.
Helps with development servers that use self-signed certificates.
Avoid it in production, because it weakens protection against impersonated servers.

### Username (Username)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the login name, or the client id for service principal sign-in.
Replaces the stored login name for this step only.

## Scope

* Any
