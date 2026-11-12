# Invoke Mongo Db Aggregate (InvokeMongoDbAggregate)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Runs an aggregation pipeline on a MongoDB collection.
Covers the work a relational flow would give to a stored procedure or a grouped query: grouping, joining, reshaping, and writing results into another collection.
Stores the produced documents as relaxed Extended JSON, which keeps the BSON types plain JSON cannot express.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                        |
| --- | --- |
| Pipeline as data           | Reads the stages from CommandText, CommandFile, or Base64-encoded text and binds them as BSON.                                                     |
| One or many stages         | Accepts a JSON array of stages, or a single stage object with no array wrapper.                                                                     |
| Writing pipelines          | A pipeline that ends in `$merge` or `$out` writes its result and then reports the documents of the written collection.                             |
| Large pipelines            | The AllowDiskUse switch lets a stage spill to disk when it exceeds the server memory limit.                                                          |
| Field names                | Reports the union of the top-level field names of the produced documents, in first-seen order.                                                       |
| Session and entity outputs | Stores outputs as Base64 session parameters named `InvokeMongoDbAggregate:<Name>` and returns them in the response entity unless `NoEntity` is set.  |

### Usages in RPA

| Use Case             | Description                                                                               |
| --- | --- |
| Daily rollup         | Group the documents of a day into totals and write them into a summary collection.        |
| Joined extract       | Join two collections with `$lookup` and export the joined documents a bot processes.      |
| Deduplication        | Group by a business key to find and report duplicate documents.                           |

### Usages in Automation Testing

| Use Case            | Description                                                                          |
| --- | --- |
| Aggregate assertion | Compare a grouped total with the value the system under test displays.               |
| Fixture shaping     | Reshape stored fixtures into the document shape a test needs.                         |
| Data audit          | Group the documents a test wrote to confirm the expected distribution.                |

### Notes

An empty pipeline fails the step, because an aggregation without stages has nothing to run.
A pipeline that ends in `$merge` or `$out` returns no documents of its own, so the driver reads the written collection instead and the step reports those documents.
The server rejects `$merge` and `$out` inside a transaction, so a writing pipeline runs without the Transaction switch and is not rolled back.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Group documents into totals

The argument names the collection and passes a two-stage pipeline that matches and groups.
The pipeline is Base64-encoded, because its nested stages contain `}}`, which would end the inline argument value; the decoded text is `[{"$match":{"status":"open"}},{"$group":{"_id":"$sku","total":{"$sum":"$total"}}}]`.
The step stores the grouped documents as relaxed Extended JSON.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbAggregate",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbAggregate")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbAggregate",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}"
}
```

### Example No.2

### Write a rollup into another collection

The argument passes a pipeline that groups and then merges the result into a summary collection.
The pipeline is Base64-encoded, because its nested stages contain `}}`; the decoded text is `[{"$group":{"_id":"$sku","total":{"$sum":"$total"}}},{"$merge":{"into":"sku-totals"}}]`.
The step runs without the `Transaction` switch, because MongoDB rejects `$merge` inside a transaction.
After the merge, the driver reads the written collection, so the step reports the merged documents instead of an empty result.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbAggregate",
    Argument = "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:W3siJGdyb3VwIjp7Il9pZCI6IiRza3UiLCJ0b3RhbCI6eyIkc3VtIjoiJHRvdGFsIn19fSx7IiRtZXJnZSI6eyJpbnRvIjoic2t1LXRvdGFscyJ9fV0= --Base64 --CommandTimeout:300}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbAggregate")
    .setArgument("{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:W3siJGdyb3VwIjp7Il9pZCI6IiRza3UiLCJ0b3RhbCI6eyIkc3VtIjoiJHRvdGFsIn19fSx7IiRtZXJnZSI6eyJpbnRvIjoic2t1LXRvdGFscyJ9fV0= --Base64 --CommandTimeout:300}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbAggregate",
    argument: "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:W3siJGdyb3VwIjp7Il9pZCI6IiRza3UiLCJ0b3RhbCI6eyIkc3VtIjoiJHRvdGFsIn19fSx7IiRtZXJnZSI6eyJpbnRvIjoic2t1LXRvdGFscyJ9fV0= --Base64 --CommandTimeout:300}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:W3siJGdyb3VwIjp7Il9pZCI6IiRza3UiLCJ0b3RhbCI6eyIkc3VtIjoiJHRvdGFsIn19fSx7IiRtZXJnZSI6eyJpbnRvIjoic2t1LXRvdGFscyJ9fV0= --Base64 --CommandTimeout:300}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:W3siJGdyb3VwIjp7Il9pZCI6IiRza3UiLCJ0b3RhbCI6eyIkc3VtIjoiJHRvdGFsIn19fSx7IiRtZXJnZSI6eyJpbnRvIjoic2t1LXRvdGFscyJ9fV0= --Base64 --CommandTimeout:300}}"
}
```

### Example No.3

### Run a pipeline from a file

The argument reads the stages from a UTF-8 file, raises the time budget, and allows disk use.
The file content is always read as plain text, so the Base64 switch never applies to it.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbAggregate",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --CommandFile:C:\flows\pipelines\daily-rollup.json --CommandTimeout:300 --AllowDiskUse}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbAggregate")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --CommandFile:C:\flows\pipelines\daily-rollup.json --CommandTimeout:300 --AllowDiskUse}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbAggregate",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --CommandFile:C:\flows\pipelines\daily-rollup.json --CommandTimeout:300 --AllowDiskUse}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandFile:C:\flows\pipelines\daily-rollup.json --CommandTimeout:300 --AllowDiskUse}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbAggregate",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandFile:C:\flows\pipelines\daily-rollup.json --CommandTimeout:300 --AllowDiskUse}}"
}
```

## Output Parameter

### Invoke Mongo Db Aggregate Columns (InvokeMongoDbAggregate:Columns)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the union of the top-level field names of the produced documents, as a JSON array.
Reports the field names in the order they were first seen, which follows the last projecting stage.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Aggregate Document Count (InvokeMongoDbAggregate:DocumentCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of documents the pipeline produced.
A writing pipeline that ends in `$merge` or `$out` reports the documents of the written collection, because the driver reads it once the pipeline completed.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Aggregate Result (InvokeMongoDbAggregate:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the produced documents as a minified relaxed Extended JSON array.
Keeps the BSON types plain JSON cannot express, such as `{"$date":"..."}` for a date.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Aggregate Stage Count (InvokeMongoDbAggregate:StageCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of pipeline stages the step ran.
Confirms that a Base64-encoded or file-based pipeline was parsed as expected.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Parameters

### Allow Disk Use (AllowDiskUse)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Lets a pipeline stage write temporary files when it exceeds the server memory limit.
Set it for a large group or sort stage, which otherwise fails with a memory-limit error.

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

### Collection (Collection)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the collection the step operates on, such as `orders` or `shop.orders`.
A name qualified as `database.collection` selects its own database and overrides the Database parameter.
The name is split on its first dot only, so `shop.price.history` addresses the collection `price.history`.

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

Supplies the pipeline as a JSON array of stage objects, such as `[{"$match":{"status":"open"}},{"$count":"open"}]`.
A single stage object is accepted too, so a one-stage pipeline needs no array wrapper.
Required, because an aggregation without stages has nothing to run.

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

### Transaction (Transaction)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Runs the pipeline inside a multi-document transaction, so it reads one consistent snapshot.
MongoDB rejects the `$merge` and `$out` stages inside a transaction, so a writing pipeline runs without this switch.
MongoDB supports transactions only on a replica set or a sharded cluster; a standalone server fails the step.

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
