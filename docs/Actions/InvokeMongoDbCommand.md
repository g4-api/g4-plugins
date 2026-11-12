# Invoke Mongo Db Command (InvokeMongoDbCommand)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs a raw MongoDB database command, which is the escape hatch of the suite.
Covers the administrative and diagnostic work the typed plugins do not model, such as creating an index, reading collection statistics, or validating a collection.
Stores the whole server response, so a flow reads exactly what the server returned.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                      |
| --- | --- |
| Any database command       | Runs the command the first field of the command document names, such as `createIndexes` or `collStats`.                                          |
| Command as data            | Reads the command from CommandText, CommandFile, or Base64-encoded text and binds it as BSON.                                                    |
| Database selection         | Runs on the Database argument, then on the database the connection resolved, so the command never guesses its target.                             |
| Whole response             | Stores the complete response document, not a selected field, so nothing the server reports is lost.                                               |
| Branchable result          | Reports the `ok` flag separately, so a flow can branch without parsing the response.                                                             |
| Session and entity outputs | Stores outputs as Base64 session parameters named `InvokeMongoDbCommand:<Name>` and returns them in the response entity unless `NoEntity` is set.  |

### Usages in RPA

| Use Case            | Description                                                                             |
| --- | --- |
| Index provisioning  | Create the indexes a later extraction needs, before the data arrives.                   |
| Capacity reporting  | Read collection statistics and report the stored size of a warehouse.                   |
| Maintenance         | Run a validation or a compaction command on a maintenance schedule.                     |

### Usages in Automation Testing

| Use Case             | Description                                                                        |
| --- | --- |
| Environment setup    | Create the collections and indexes a suite expects before it runs.                 |
| Server capability    | Read the server parameters a test depends on and skip the test when they differ.   |
| Teardown             | Drop a test collection in one call after the suite finished.                       |

### Notes

The command runs with the rights of the connected login, so it can also drop data; restrict the login instead of the command.
A command document with no field fails the step, because nothing names the command to run.
A server that rejects the command fails the step, so `Ok` reports `false` only for a command that answered without success.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Create an index

The argument passes a `createIndexes` command that indexes the status field.
The step stores the whole response, which reports how many indexes the collection now has.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"createIndexes":"orders","indexes":[{"key":{"status":1},"name":"status_1"}]}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:{"createIndexes":"orders","indexes":[{"key":{"status":1},"name":"status_1"}]}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"createIndexes":"orders","indexes":[{"key":{"status":1},"name":"status_1"}]}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"createIndexes":"orders","indexes":[{"key":{"status":1},"name":"status_1"}]}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"createIndexes":"orders","indexes":[{"key":{"status":1},"name":"status_1"}]}}}"
}
```

### Example No.2

### Read collection statistics

The argument passes a `collStats` command and names the database explicitly.
The step stores the whole statistics document for a report to read.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"collStats":"orders"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:{"collStats":"orders"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"collStats":"orders"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"collStats":"orders"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{"collStats":"orders"}}}"
}
```

### Example No.3

### Run a command from a file

The argument reads the command document from a UTF-8 file and raises the time budget.
NoEntity keeps the response in session parameters only.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\flows\commands\validate-orders.json --CommandTimeout:600 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\flows\commands\validate-orders.json --CommandTimeout:600 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\flows\commands\validate-orders.json --CommandTimeout:600 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\flows\commands\validate-orders.json --CommandTimeout:600 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\flows\commands\validate-orders.json --CommandTimeout:600 --NoEntity}}"
}
```

## Output Parameter

### Invoke Mongo Db Command Database (InvokeMongoDbCommand:Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the name of the database the command ran on.
Confirms whether the Database argument or the resolved connection selected the target.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Command Ok (InvokeMongoDbCommand:Ok)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores `true` when the server reported the command as successful and `false` otherwise.
Lets a flow branch without parsing the response document.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Command Result (InvokeMongoDbCommand:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the whole response document as minified relaxed Extended JSON.
Keeps every field the server reported, including the ones a typed plugin would drop.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Parameters

### Allow Invalid Certificates (AllowInvalidCertificates)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Accepts the server certificate without validating its trust chain.
Intended for development servers and containers that use a self-signed certificate.
Leave it unset for any deployment that holds real data.

### Authentication Database (AuthenticationDatabase)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the database that holds the user record, such as `admin`.
Overrides the authentication source from the credentials or the connection URI for this step only.
Set it when the login lives in a different database than the data.

### Authentication Mechanism (AuthenticationMechanism)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects how the driver proves the identity of the login.
Overrides the mechanism from the credentials or the connection URI for this step only.
Leave it unset to let the server and the driver negotiate, which selects SCRAM-SHA-256.

#### Values

##### Scramsha256

Signs in with a user name and password over SCRAM using SHA-256.
This is the modern default, so leave the parameter unset unless a server needs another mechanism.

##### Scramsha1

Signs in with a user name and password over SCRAM using SHA-1.
Use it for servers older than 4.0, which do not offer SHA-256.

##### Mongodbx509

Signs in with the client TLS certificate instead of a password.
Set Username to the certificate subject, or leave it unset to let the server read it.

##### Mongodbaws

Signs in with AWS Identity and Access Management credentials.
Use it for an Atlas cluster that trusts an AWS role.

##### Mongodboidc

Signs in with an OpenID Connect access token, such as a workload identity token.
Use it for a deployment that federates its logins to an identity provider.

##### Plain

Signs in through an external LDAP or operating-system directory in plain text over TLS.
Set Tls to Enabled, because the password travels unhashed.

##### Gssapi

Signs in with a Kerberos principal.
Use it for an enterprise deployment that authenticates through Kerberos.

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Reads CommandText as UTF-8 Base64 and decodes it before use.
Use it for a payload that contains ` --` or `}}`, which end an inline argument value.
Invalid Base64 fails the step, so an encoded payload never reaches the server as text.

### Command File (CommandFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Reads the payload from a UTF-8 file, such as `C:\flows\filter.json`.
Applies only when CommandText is not set, so an inline payload always takes priority.
The Base64 switch never applies here; file content is always read as plain text.

### Command Text (CommandText)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the command as a JSON object whose first field names the command, such as `{"collStats":"orders"}`.
Required, because a step without a command has nothing to run.
Both Extended JSON forms are accepted, so declared BSON types survive the parse.

### Command Timeout (CommandTimeout)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 30                |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the time budget, in seconds, for connecting, selecting a server, and running the operation.
The value 0 means no operation timeout, so the step waits until the server answers.
Raise it for a long aggregation and lower it for a health check that must fail fast.

### Connection String (ConnectionString)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies a full MongoDB connection URI, such as `mongodb://localhost:27017/shop`.
Applies only when Credentials is not set, so a stored credentials reference always takes priority.
Discrete parameters such as Host or Database still override the matching parts of the URI.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored MongoDB credentials record by name or id, such as `mongo-production`, so secrets stay out of the rule.
A value that carries a URI scheme, such as `mongodb://`, is used as a raw connection URI instead.
Any other value that matches no record fails the step, so a typed record name never reads as a host.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the database the step operates on, such as `shop`.
Overrides the database from the credentials or the connection URI, so one stored login can reach several databases.
A collection named as `database.collection` overrides this parameter in turn.

### Direct Connection (DirectConnection)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Connects to the named host directly instead of discovering the deployment topology.
Set it when a replica-set member is reached through a forwarded port, where the advertised host name is unreachable.
A direct connection cannot run multi-document transactions.

### Host (Host)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the MongoDB host or network address, such as `localhost`.
Overrides the host from the credentials or the connection URI for this step only.
A multi-host seed list travels in ConnectionString instead.

### No Entity (NoEntity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Omits the response entity, so the step reports its outputs only as session parameters.
Use it when a later step reads the outputs by name and no data transfer is needed.

### Password (Password)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the password used with a password-based mechanism.
Overrides the password from the credentials or the connection URI for this step.
Prefer a stored credentials record, so the secret never appears in the rule.

### Port (Port)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Sets the TCP port of the MongoDB instance, such as `27017`.
Overrides the port from the credentials or the connection URI, and keeps the resolved host.
An unset port keeps the resolved port, which is 27017 for a plain URI.

### Replica Set (ReplicaSet)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Requires the client to join the named replica set, such as `rs0`.
Overrides the replica set from the credentials or the connection URI for this step.
A replica set is required for multi-document transactions.

### Tls (Tls)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Sets the transport encryption mode of the connection.
Overrides the mode from the credentials or the connection URI, which a URI scheme otherwise decides implicitly.

#### Values

##### Enabled

Requires TLS encryption for the connection.
Use it for a deployment that accepts only encrypted clients, such as MongoDB Atlas.

##### Disabled

Connects without TLS.
Use it for a loopback or private-network deployment that serves plain connections.

### Username (Username)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Sets the login name used with Password, such as a database user or a certificate subject.
Overrides the user name from the credentials or the connection URI for this step.

## Scope

* Any
