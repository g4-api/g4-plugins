# Export Mongo Db Query (ExportMongoDbQuery)

[Table of Content](../Home.md)

~20 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Reads the documents of a MongoDB collection into an automation.
The filter, the projection, and the sort travel as BSON, so no value is ever composed into a query.
Stores the documents as relaxed Extended JSON, which keeps the BSON types that plain JSON cannot express.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                  |
| --- | --- |
| Filter as data             | Reads the filter from CommandText, CommandFile, or Base64-encoded text and binds it as BSON.                                                 |
| Match-all default          | An omitted filter matches every document, so a step can export a whole collection.                                                           |
| Result shaping             | Applies Projection, Sort, Limit, and Skip only when the step sets them, so unset options keep the server default.                             |
| Field names                | Reports the union of the top-level field names, in first-seen order, because documents are schemaless.                                        |
| Extended JSON              | Serializes object identifiers, dates, and decimals through their Extended JSON type form, so a later step can address them.                   |
| Session and entity outputs | Stores outputs as Base64 session parameters named `ExportMongoDbQuery:<Name>` and returns them in the response entity unless `NoEntity` is set. |

### Usages in RPA

| Use Case             | Description                                                                              |
| --- | --- |
| Work queue intake    | Read the pending documents a bot must process, sorted by priority and limited per run.   |
| Reporting extract    | Export the documents of a date range, projected to the fields a report needs.            |
| Reference lookup     | Read the configuration documents a later step binds into its own arguments.               |

### Usages in Automation Testing

| Use Case          | Description                                                                         |
| --- | --- |
| Data-driven tests | Read the test cases of a collection and iterate the exported documents.             |
| Result assertion  | Read the documents a flow wrote and compare them with the expected content.         |
| State inspection  | Read one document by its identifier to confirm a prior step changed it as expected.  |

### Notes

CommandText wins over CommandFile, and the Base64 switch decodes only CommandText.
A limit of 0 and a skip of 0 mean the option is not set, which matches the server default.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Export the documents a filter matches

The argument names the collection and passes the filter as a JSON object.
The step stores the documents as relaxed Extended JSON.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportMongoDbQuery",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportMongoDbQuery")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportMongoDbQuery",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
}
```

### Example No.2

### Export a projected, sorted page

The argument shapes the result with a projection, a sort, a limit, and a skip.
The projection keeps the exported documents small, which matters for a session parameter.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportMongoDbQuery",
    Argument = "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{"status":"open"} --Projection:{"total":1,"createdAt":1,"_id":0} --Sort:{"createdAt":-1} --Limit:100 --Skip:0}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportMongoDbQuery")
    .setArgument("{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{"status":"open"} --Projection:{"total":1,"createdAt":1,"_id":0} --Sort:{"createdAt":-1} --Limit:100 --Skip:0}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportMongoDbQuery",
    argument: "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{"status":"open"} --Projection:{"total":1,"createdAt":1,"_id":0} --Sort:{"createdAt":-1} --Limit:100 --Skip:0}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{"status":"open"} --Projection:{"total":1,"createdAt":1,"_id":0} --Sort:{"createdAt":-1} --Limit:100 --Skip:0}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{"status":"open"} --Projection:{"total":1,"createdAt":1,"_id":0} --Sort:{"createdAt":-1} --Limit:100 --Skip:0}}"
}
```

### Example No.3

### Export with a Base64-encoded filter

The `Base64` switch marks CommandText as UTF-8 Base64, so a filter with special sequences survives the inline argument.
The decoded filter is `{"name":{"$regex":"^A"}}`.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportMongoDbQuery",
    Argument = "{{$ --Credentials:mongo-production --Collection:customers --CommandText:eyJuYW1lIjp7IiRyZWdleCI6Il5BIn19 --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportMongoDbQuery")
    .setArgument("{{$ --Credentials:mongo-production --Collection:customers --CommandText:eyJuYW1lIjp7IiRyZWdleCI6Il5BIn19 --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportMongoDbQuery",
    argument: "{{$ --Credentials:mongo-production --Collection:customers --CommandText:eyJuYW1lIjp7IiRyZWdleCI6Il5BIn19 --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --CommandText:eyJuYW1lIjp7IiRyZWdleCI6Il5BIn19 --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --CommandText:eyJuYW1lIjp7IiRyZWdleCI6Il5BIn19 --Base64}}"
}
```

### Example No.4

### Export with a filter from a file

The argument reads the filter from a UTF-8 file, which suits a long or reused filter.
NoEntity keeps the outputs in session parameters only.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportMongoDbQuery",
    Argument = "{{$ --Credentials:mongo-production --Collection:customers --CommandFile:C:\flows\filters\active-customers.json --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportMongoDbQuery")
    .setArgument("{{$ --Credentials:mongo-production --Collection:customers --CommandFile:C:\flows\filters\active-customers.json --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportMongoDbQuery",
    argument: "{{$ --Credentials:mongo-production --Collection:customers --CommandFile:C:\flows\filters\active-customers.json --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --CommandFile:C:\flows\filters\active-customers.json --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportMongoDbQuery",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --CommandFile:C:\flows\filters\active-customers.json --NoEntity}}"
}
```

## Output Parameter

### Export Mongo Db Query Columns (ExportMongoDbQuery:Columns)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the union of the top-level field names of the exported documents, as a JSON array.
Reports the field names in the order they were first seen, which follows the projection order.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Export Mongo Db Query Document Count (ExportMongoDbQuery:DocumentCount)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of exported documents.
Lets a flow branch on an empty result without parsing the documents.
The session value is Base64-encoded, so decode it before comparing or displaying it.

### Export Mongo Db Query Result (ExportMongoDbQuery:Result)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the exported documents as a minified relaxed Extended JSON array.
Keeps the BSON types plain JSON cannot express, such as `{"$oid":"..."}` for an object identifier.
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

Supplies the query filter as a JSON object, such as `{"status":"open"}`.
An omitted filter matches every document, so the step exports the whole collection.
Both Extended JSON forms are accepted, so `{"_id":{"$oid":"..."}}` addresses an object identifier.

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

### Limit (Limit)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Limits the number of exported documents, such as `100`.
The value 0 means no limit, so the step exports every matching document.

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

### Projection (Projection)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Selects the fields the server returns, as a JSON object such as `{"name":1,"_id":0}`.
An omitted projection returns the whole document.

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

### Skip (Skip)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Skips the first documents of the result, such as `50` for the second page of fifty.
The value 0 means no skip, and a skip without a sort has no stable meaning.

### Sort (Sort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Orders the documents before the limit and the skip apply, as a JSON object such as `{"createdAt":-1}`.
An omitted sort leaves the order to the server, which is not stable across runs.

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
