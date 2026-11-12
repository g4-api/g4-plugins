# Invoke Mongo Db Write (InvokeMongoDbWrite)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Changes the documents of a MongoDB collection.
One Operation argument selects the write, so a flow uses one step for inserts, updates, replacements, and deletes.
Reports every write count, so a later step can verify the change without reading the collection again.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                    |
| --- | --- |
| Seven operations           | InsertOne, InsertMany, UpdateOne, UpdateMany, ReplaceOne, DeleteOne, and DeleteMany, named case-insensitively.                                  |
| Values as data             | The filter comes from CommandText and the document from Document, both bound as BSON rather than composed text.                                 |
| Deliberate scope           | An update, replace, or delete without a filter fails, so a step always states which documents it changes.                                       |
| Upsert                     | The Upsert switch inserts a document when an update or a replace matches nothing, and reports its identifier.                                   |
| Transactions               | The Transaction switch wraps the write and commits only on success, on a replica set or a sharded cluster.                                       |
| Session and entity outputs | Stores outputs as Base64 session parameters named `InvokeMongoDbWrite:<Name>` and returns them in the response entity unless `NoEntity` is set.  |

### Usages in RPA

| Use Case          | Description                                                                              |
| --- | --- |
| Status update     | Mark the documents a bot processed, and verify the modified count before continuing.     |
| Result write-back | Insert the documents a bot produced, in one call.                                        |
| Cleanup           | Delete the documents of a finished run inside a transaction.                             |

### Usages in Automation Testing

| Use Case         | Description                                                                       |
| --- | --- |
| Test data setup  | Insert the fixtures a test needs before it runs.                                  |
| State mutation   | Update one document to put the system under test into a known state.              |
| Teardown         | Delete the documents a test created, addressed by a run identifier.               |

### Notes

An update document must carry update operators, such as `{"$set":{...}}`; a replacement must not.
Pass `{"_id":{"$exists":true}}` to address every document on purpose, which the empty-filter guard rejects.
InsertOne and InsertMany share one path, so the Document argument decides how many documents are inserted.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Insert documents

The argument names the collection, selects InsertMany, and passes the documents as a JSON array.
The step reports the inserted count and the generated identifiers.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbWrite",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --Operation:InsertMany --Document:[{"sku":"A-1","total":10},{"sku":"B-2","total":20}]}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbWrite")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --Operation:InsertMany --Document:[{"sku":"A-1","total":10},{"sku":"B-2","total":20}]}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbWrite",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --Operation:InsertMany --Document:[{"sku":"A-1","total":10},{"sku":"B-2","total":20}]}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:InsertMany --Document:[{"sku":"A-1","total":10},{"sku":"B-2","total":20}]}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:InsertMany --Document:[{"sku":"A-1","total":10},{"sku":"B-2","total":20}]}}"
}
```

### Example No.2

### Update documents, inserting when none match

The argument selects UpdateMany, passes the filter and the update operators, and sets `Upsert`.
The update document is Base64-encoded, because a nested JSON object ends in `}}`, which would end the inline argument value; the decoded text is `{"$set":{"status":"processed"}}`.
The step reports what it matched, modified, and upserted.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbWrite",
    Argument = "{{$ --Credentials:mongo-production --Collection:shop.orders --Operation:UpdateMany --CommandText:{"status":"open"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64 --Upsert}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbWrite")
    .setArgument("{{$ --Credentials:mongo-production --Collection:shop.orders --Operation:UpdateMany --CommandText:{"status":"open"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64 --Upsert}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbWrite",
    argument: "{{$ --Credentials:mongo-production --Collection:shop.orders --Operation:UpdateMany --CommandText:{"status":"open"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64 --Upsert}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --Operation:UpdateMany --CommandText:{"status":"open"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64 --Upsert}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --Operation:UpdateMany --CommandText:{"status":"open"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64 --Upsert}}"
}
```

### Example No.3

### Delete documents inside a transaction

The argument selects DeleteMany, passes the filter, and sets `Transaction`.
The transaction commits only after the delete succeeded.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbWrite",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --Operation:DeleteMany --CommandText:{"runId":"2026-11-12-001"} --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbWrite")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --Operation:DeleteMany --CommandText:{"runId":"2026-11-12-001"} --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbWrite",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --Operation:DeleteMany --CommandText:{"runId":"2026-11-12-001"} --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:DeleteMany --CommandText:{"runId":"2026-11-12-001"} --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:DeleteMany --CommandText:{"runId":"2026-11-12-001"} --Transaction}}"
}
```

### Example No.4

### Replace one document

The argument selects ReplaceOne, addresses the document by its object identifier, and passes the replacement.
The filter is Base64-encoded, because its nested `$oid` object ends in `}}`, which would end the inline argument value; the decoded text is `{"_id":{"$oid":"6553f1c2a1b2c3d4e5f60718"}}`.
The Extended JSON `$oid` form addresses the identifier as an object identifier, not as text.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbWrite",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --Operation:ReplaceOne --CommandText:eyJfaWQiOnsiJG9pZCI6IjY1NTNmMWMyYTFiMmMzZDRlNWY2MDcxOCJ9fQ== --Base64 --Document:{"sku":"A-1","total":12,"status":"processed"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbWrite")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --Operation:ReplaceOne --CommandText:eyJfaWQiOnsiJG9pZCI6IjY1NTNmMWMyYTFiMmMzZDRlNWY2MDcxOCJ9fQ== --Base64 --Document:{"sku":"A-1","total":12,"status":"processed"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbWrite",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --Operation:ReplaceOne --CommandText:eyJfaWQiOnsiJG9pZCI6IjY1NTNmMWMyYTFiMmMzZDRlNWY2MDcxOCJ9fQ== --Base64 --Document:{"sku":"A-1","total":12,"status":"processed"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:ReplaceOne --CommandText:eyJfaWQiOnsiJG9pZCI6IjY1NTNmMWMyYTFiMmMzZDRlNWY2MDcxOCJ9fQ== --Base64 --Document:{"sku":"A-1","total":12,"status":"processed"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbWrite",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:ReplaceOne --CommandText:eyJfaWQiOnsiJG9pZCI6IjY1NTNmMWMyYTFiMmMzZDRlNWY2MDcxOCJ9fQ== --Base64 --Document:{"sku":"A-1","total":12,"status":"processed"}}}"
}
```

## Output Parameter

### Invoke Mongo Db Write Deleted Count (InvokeMongoDbWrite:DeletedCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of deleted documents, and `0` for every other operation.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Write Inserted Count (InvokeMongoDbWrite:InsertedCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of inserted documents, and `0` for every other operation.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Write Inserted Ids (InvokeMongoDbWrite:InsertedIds)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the identifiers of the inserted documents as a JSON array, including the ones the driver generated.
Stays an empty array for every other operation.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Write Matched Count (InvokeMongoDbWrite:MatchedCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of documents the filter matched in an update or a replace.
Differs from ModifiedCount when a matched document already held the new values.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Write Modified Count (InvokeMongoDbWrite:ModifiedCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of documents an update or a replace actually changed.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Invoke Mongo Db Write Upserted Ids (InvokeMongoDbWrite:UpsertedIds)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the identifier of an upserted document as a one-item JSON array.
Stays an empty array when nothing was upserted, so the output shape never changes.
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

Supplies the filter as a JSON object, such as `{"status":"open"}`.
Required for UpdateOne, UpdateMany, ReplaceOne, DeleteOne, and DeleteMany, and ignored by the insert operations.
An empty filter is rejected, so pass `{"_id":{"$exists":true}}` to address every document on purpose.

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

### Document (Document)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the document the operation writes: the documents to insert, the update operators to apply, or the replacement.
An insert accepts a single object or an array of objects; an update must carry operators such as `{"$set":{...}}`.
Required for every operation except a delete, and encodable through DocumentBase64 because a nested update document ends in two closing braces.

### Document Base64 (DocumentBase64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Reads Document as UTF-8 Base64 and decodes it before use.
An update document such as `{"$set":{...}}` ends in two closing braces, which end an inline argument value, so it travels encoded or through DocumentFile.
Invalid Base64 fails the step, so an encoded document never reaches the server as text.

### Document File (DocumentFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Reads the written document from a UTF-8 file, such as `C:\flows\update.json`.
Applies only when Document is not set, so an inline document always takes priority.
The DocumentBase64 switch never applies here; file content is always read as plain text.

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

### Operation (Operation)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects the write the step performs.
Compared case-insensitively, like every other argument value.

#### Values

##### Insert One

Inserts the single document of the Document argument.
The driver generates an `_id` when the document carries none, and reports it in InsertedIds.

##### Insert Many

Inserts every document of the Document array, in order.
A rejected document stops the ones after it, so the insert is ordered.

##### Update One

Applies the update operators to the first matching document.
Requires a filter in CommandText and operators in Document.

##### Update Many

Applies the update operators to every matching document.
Requires a filter in CommandText and operators in Document.

##### Replace One

Replaces the first matching document with the Document argument.
The replacement must not carry update operators.

##### Delete One

Deletes the first matching document.
Requires a filter in CommandText.

##### Delete Many

Deletes every matching document.
Requires a filter in CommandText, so a delete never clears a collection by an omission.

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

Runs the operation inside a multi-document transaction and commits it only on success.
A failure rolls back every change the step made.
MongoDB supports transactions only on a replica set or a sharded cluster; a standalone server fails the step.

### Upsert (Upsert)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Inserts a document when an update or a replace matches nothing.
The identifier of the inserted document is reported in UpsertedIds.
Ignored by the insert and delete operations.

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
