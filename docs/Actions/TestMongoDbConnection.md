# Test Mongo Db Connection (TestMongoDbConnection)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Tests whether an automation can reach a MongoDB deployment.
Reports the result as data instead of failing the step, so a flow can check availability before it reads or writes documents.
Supports stored credentials, full connection URIs, and discrete host, database, and sign-in settings.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                       |
| --- | --- |
| Connection check           | Sends the `ping` command and reports whether the deployment answered this client.                                                                 |
| Non-failing result         | Reports `Connected` as `false` with the driver message when MongoDB rejects the login or cannot be reached.                                        |
| Flexible connection input  | Resolves the target from a credentials name or id, or from a raw connection URI.                                                                   |
| Discrete overrides         | Applies Host, Port, Database, ReplicaSet, Username, Password, authentication, and TLS settings on top of the resolved connection.                  |
| Server details             | Returns the reached database and the server version reported by `buildInfo`.                                                                       |
| Session and entity outputs | Stores outputs as Base64 session parameters named `TestMongoDbConnection:<Name>` and returns them in the response entity unless `NoEntity` is set. |

### Usages in RPA

| Use Case                 | Description                                                                                   |
| --- | --- |
| Pre-run health check     | Confirm that the warehouse cluster is reachable before a bot starts a long collection job.    |
| Conditional fallback     | Branch to a retry, a notification, or a secondary cluster when `Connected` is `false`.        |
| Environment verification | Confirm that a credentials record reaches the expected database before deployment steps run.  |

### Usages in Automation Testing

| Use Case                   | Description                                                                  |
| --- | --- |
| Test environment readiness | Verify that the test cluster is up before data-driven test suites run.       |
| Credentials validation     | Check that stored test credentials still sign in after a password rotation.  |
| Version gating             | Skip or adapt tests based on the reported MongoDB version.                   |

### Notes

A step that resolves no host from Credentials, ConnectionString, or Host fails instead of reporting `Connected` as `false`.
The probe runs on the resolved database, or on `admin` when none is resolved, because every deployment carries it.
A deployment that withholds `buildInfo` from the login still reports as connected, with an empty `ServerVersion`.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Test a connection with a credentials name

The `{{$ --Credentials:mongo-production}}` argument binds the stored credentials record named `mongo-production` at runtime.
The step reports whether the deployment answered and stores the result in session parameters and the response entity.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestMongoDbConnection",
    Argument = "{{$ --Credentials:mongo-production}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestMongoDbConnection")
    .setArgument("{{$ --Credentials:mongo-production}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestMongoDbConnection",
    argument: "{{$ --Credentials:mongo-production}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Credentials:mongo-production}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Credentials:mongo-production}}"
}
```

### Example No.2

### Test a connection with a connection URI

The argument passes a complete MongoDB connection URI, which suits a local or containerized deployment.
A short CommandTimeout makes an unreachable deployment fail fast instead of waiting for the driver default.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestMongoDbConnection",
    Argument = "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandTimeout:5}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestMongoDbConnection")
    .setArgument("{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandTimeout:5}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestMongoDbConnection",
    argument: "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandTimeout:5}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandTimeout:5}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandTimeout:5}}"
}
```

### Example No.3

### Test a connection with discrete settings

The argument binds Host, Port, Database, and the login, plus the TLS mode and the `AllowInvalidCertificates` switch.
The step signs in with the named user and reports the result.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestMongoDbConnection",
    Argument = "{{$ --Host:mongo.internal --Port:27017 --Database:shop --Username:reporter --Password:P@ssw0rd --Tls:Enabled --AllowInvalidCertificates}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestMongoDbConnection")
    .setArgument("{{$ --Host:mongo.internal --Port:27017 --Database:shop --Username:reporter --Password:P@ssw0rd --Tls:Enabled --AllowInvalidCertificates}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestMongoDbConnection",
    argument: "{{$ --Host:mongo.internal --Port:27017 --Database:shop --Username:reporter --Password:P@ssw0rd --Tls:Enabled --AllowInvalidCertificates}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Host:mongo.internal --Port:27017 --Database:shop --Username:reporter --Password:P@ssw0rd --Tls:Enabled --AllowInvalidCertificates}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Host:mongo.internal --Port:27017 --Database:shop --Username:reporter --Password:P@ssw0rd --Tls:Enabled --AllowInvalidCertificates}}"
}
```

## Output Parameter

### Test Mongo Db Connection Connected (TestMongoDbConnection:Connected)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores `true` when the deployment answered the ping and `false` when it rejected the login or could not be reached.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Mongo Db Connection Database (TestMongoDbConnection:Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the name of the database the probe ran on.
Confirms which database the login reached, including the `admin` fallback when none was requested.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Mongo Db Connection Error (TestMongoDbConnection:Error)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the driver message when the connection fails, such as an authentication failure or a server selection timeout.
Stays empty when the connection succeeds.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Test Mongo Db Connection Server Version (TestMongoDbConnection:ServerVersion)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the MongoDB version reported by the server, such as `8.0.4`.
Helps checks confirm that a deployment meets a version requirement.
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
