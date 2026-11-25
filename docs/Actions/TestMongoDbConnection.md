# Test Mongo Db Connection (TestMongoDbConnection)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Tests whether an automation can reach a MongoDB deployment.
Reports the result as data instead of failing the step, so a flow can check availability before it reads or writes documents.
Supports a stored credentials record or a full connection URI, so every connection detail stays in one place.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                       |
| --- | --- |
| Connection check           | Sends the `ping` command and reports whether the deployment answered this client.                                                                 |
| Non-failing result         | Reports `Connected` as `false` with the driver message when MongoDB rejects the login or cannot be reached.                                        |
| Flexible connection input  | Resolves the target from a credentials name or id, or from a raw connection URI.                                                                   |
| Database probe             | Probes the database named by `Database`, then the one the connection carries, then `admin`, which every deployment holds.                          |
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

A step that resolves no host from Credentials or ConnectionString fails instead of reporting `Connected` as `false`.
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

### Probe another database of a stored deployment

The argument binds the stored credentials record `mongo-production` and the `reporting` database.
The step pings that database and reports which one it reached.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "TestMongoDbConnection",
    Argument = "{{$ --Credentials:mongo-production --Database:reporting}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("TestMongoDbConnection")
    .setArgument("{{$ --Credentials:mongo-production --Database:reporting}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "TestMongoDbConnection",
    argument: "{{$ --Credentials:mongo-production --Database:reporting}}"
};
```

**JSON:**

```js
{
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Credentials:mongo-production --Database:reporting}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "TestMongoDbConnection",
    "argument": "{{$ --Credentials:mongo-production --Database:reporting}}"
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

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Supplies a full MongoDB connection URI, such as `mongodb://localhost:27017/shop`.
Applies only when Credentials is not set, so a stored credentials reference always takes priority.
Every connection setting, such as the host, the login, the replica set, and the TLS mode, is written into the URI itself.

### Credentials (Credentials)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names a stored MongoDB credentials record by name or id, such as `mongo-production`, so secrets stay out of the rule.
The record carries the host, port, login, replica set, and TLS settings, so the step never repeats them.
A value that carries a URI scheme, such as `mongodb://`, is used as a raw connection URI instead, and any other value that matches no record fails the step.

### Database (Database)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Names the database the step operates on, such as `shop`.
Selects the database next to the collection, and replaces the database the credentials record or the connection URI carries.
A collection named as `database.collection` overrides this parameter in turn.

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

## Scope

* Any
