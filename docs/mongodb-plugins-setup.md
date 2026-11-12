# MongoDB Plugins Setup

[Home](./Home.md)

This page explains what you need before the 8 MongoDB plugins can reach a deployment. Every fact below comes from the
plugin code in `src/G4.Plugins.MongoDb` and the test fixture in `src/G4.UnitTests`. Where the code does not say, the
page says so.

## What the plugins do

| Plugin | Type | What it does |
| --- | --- | --- |
| [TestMongoDbConnection](./Actions/TestMongoDbConnection.md) | Action | Sends `ping` and reports `Connected`, `Database`, `ServerVersion` and `Error`. It never fails on a login error. |
| [GetMongoDbScalar](./Actions/GetMongoDbScalar.md) | Action | Returns one value as `Value`: a document count, the distinct values of a field, or one field of the first match. |
| [ExportMongoDbQuery](./Actions/ExportMongoDbQuery.md) | Action | Runs a `find` and returns `Result`, `Columns` and `DocumentCount`. |
| [InvokeMongoDbWrite](./Actions/InvokeMongoDbWrite.md) | Action | Inserts, updates, replaces or deletes documents and returns every write count. |
| [InvokeMongoDbAggregate](./Actions/InvokeMongoDbAggregate.md) | Action | Runs an aggregation pipeline and returns `Result`, `Columns`, `DocumentCount` and `StageCount`. |
| [InvokeMongoDbCommand](./Actions/InvokeMongoDbCommand.md) | Action | Runs any database command and returns the whole response as `Result`, with `Ok` and `Database`. |
| [ImportMongoDbData](./Actions/ImportMongoDbData.md) | Action | Inserts documents from inline JSON, a JSON file or a CSV file and returns `DocumentsInserted`. |
| [MongoDbDataCollector](./DataCollectors/MongoDbDataCollector.md) | Data collector | Writes every extracted entity to a collection as one document, with nested content as real subdocuments. |

Source: `Actions/*.cs`, `DataCollectors/MongoDbDataCollector.cs`. The plugin pages are generated from the plugin
manifests.

## What you need before you start

1. A reachable MongoDB deployment. The actions work on any topology. The `Transaction` switch needs a replica set or a
   sharded cluster, because MongoDB rejects multi-document transactions on a standalone server. Source:
   `Extensions/LocalExtensions.cs`.
2. Network access from the machine that runs G4 to the deployment port, which is `27017` unless the deployment uses
   another one. Source: `Clients/MongoDbClient.cs`.
3. A user that holds the roles your operations need. `InvokeMongoDbCommand` runs with the rights of that user, so
   restrict the user rather than trusting the command text.
4. Nothing else to install. `MongoDB.Driver` is the only database dependency, and it comes in as a package dependency
   of the plugins.

## Two ways to connect

Every plugin takes the connection inputs below. All of them are optional, but together they must name a host.

| Input | What you pass | When to use it |
| --- | --- | --- |
| `Credentials` | A stored MongoDB credentials record, by name or id | Production, because the secret stays out of the rule |
| `Credentials` | A connection URI, which the plugin recognizes by its `://` scheme | A one-off target that no record describes |
| `ConnectionString` | A connection URI | The usual way to pass a URI, used when `Credentials` is not set |
| Discrete inputs | `Host`, `Port`, `Database`, `ReplicaSet`, `Username`, `Password`, `AuthenticationDatabase`, `AuthenticationMechanism`, `Tls`, `AllowInvalidCertificates`, `DirectConnection` | Composing a target from flow parameters, or overriding part of a record |

### Stored credentials records

A record carries either a complete URI or the discrete parts, and the plugins read it from the MongoDB partition of the
engine credentials cache. The stored `Password` and `ConnectionString` are persisted in protected form and restored on
read. Source: `G4.Credentials` in the engine repository.

> The engine package that carries the MongoDB credential type is not released yet. Until it ships,
> `src/G4.Plugins.MongoDb/Models/MongoDbCredentialModels.cs` stands in for it, member for member, and the file header
> lists the two steps that replace it.

### Resolution order

1. `Credentials` names a stored record. Its URI is the baseline, and its own discrete parts override it.
2. `Credentials` carries `://`. The value is the baseline URI.
3. `Credentials` matches no record and carries no scheme. The step fails and names the value, so a typed record name
   never reads as a host name.
4. Without `Credentials`, `ConnectionString` is the baseline.
5. The discrete step inputs override whatever the baseline resolved. A `Port` without a `Host` re-targets the baseline
   host, and a `Host` without a `Port` keeps the baseline port.

Source: `Extensions/LocalExtensions.cs`.

### Authentication values

`AuthenticationMechanism` takes the `authMechanism` values of the drivers: `SCRAM-SHA-256`, `SCRAM-SHA-1`,
`MONGODB-X509`, `MONGODB-AWS`, `MONGODB-OIDC`, `PLAIN` and `GSSAPI`. Leave it unset to let the server and the driver
negotiate, which selects `SCRAM-SHA-256` on a modern deployment. `AuthenticationDatabase` names the database that holds
the user record, which is usually `admin`.

### TLS values

`Tls` takes `Enabled` or `Disabled`, so a record states the mode instead of leaving it to the URI scheme. The
`AllowInvalidCertificates` switch accepts a certificate without validating its trust chain, which suits a development
container and nothing else.

## Send payloads to the server

### Payload inputs

| Input | Carries |
| --- | --- |
| `CommandText` | The primary payload: the filter, the pipeline or the command document, depending on the plugin |
| `CommandFile` | The same payload, read from a UTF-8 file, used when `CommandText` is not set |
| `Base64` | Marks `CommandText` as UTF-8 Base64 |
| `Document` | The secondary payload of `InvokeMongoDbWrite`: the documents to insert, the update operators, or the replacement |
| `DocumentFile` | The same payload, read from a UTF-8 file |
| `DocumentBase64` | Marks `Document` as UTF-8 Base64 |
| `Data` and `DataFile` | The payload of `ImportMongoDbData`, as inline JSON, a JSON file or a `.csv` file |

An inline argument value ends at ` --` and at `}}`, so a nested JSON object such as `{"$set":{"status":"open"}}` cannot
travel inline: it ends in two closing braces. Pass it Base64-encoded with the matching switch, or through the file
argument. Invalid Base64 fails the step, so an encoded payload never reaches the server as text. Source:
`Extensions/LocalExtensions.cs`.

Both Extended JSON forms are accepted, so `{"_id":{"$oid":"6553f1c2a1b2c3d4e5f60718"}}` addresses an object identifier
rather than a nested object.

### Transactions

The `Transaction` switch of `InvokeMongoDbWrite`, `ImportMongoDbData` and `InvokeMongoDbAggregate` opens a session
transaction and commits it only after the operation succeeded. Two limits come from the server, not from the plugins:

- A standalone deployment rejects transactions. The step then fails with a message that names the requirement.
- The `$merge` and `$out` aggregation stages cannot run inside a transaction, so a writing pipeline runs without the
  switch and is not rolled back.

### Timeouts

`CommandTimeout` is one budget in seconds for connecting, selecting a server and running the operation. It defaults to
`30`, and `0` means no operation timeout. Lower it for a health check that must fail fast, and raise it for a heavy
aggregation.

## Read the outputs

Every plugin publishes its outputs twice:

- As session parameters named `{PluginKey}:{Output}`, Base64-encoded by the engine. Decode them before comparing.
- As the response entity, in plain text, unless the `NoEntity` switch is set.

Documents are stored as minified relaxed Extended JSON, so BSON types that JSON cannot express keep their type
wrapper. A scalar string is stored raw, and a missing value is stored as an empty string.

```json
[{ "_id" : { "$oid" : "6553f1c2a1b2c3d4e5f60718" }, "sku" : "A-1", "total" : 10 }]
```

Because MongoDB documents declare no schema, `Columns` is the union of the top-level field names of the returned
documents, in the order they were first seen.

## Use the plugins in a rule

### Check the connection

```json
{
  "$type": "Action",
  "pluginName": "TestMongoDbConnection",
  "argument": "{{$ --Credentials:mongo-production --CommandTimeout:5}}"
}
```

### Export the documents a filter matches

```json
{
  "$type": "Action",
  "pluginName": "ExportMongoDbQuery",
  "argument": "{{$ --Credentials:mongo-production --Collection:shop.orders --CommandText:{\"status\":\"open\"} --Projection:{\"total\":1,\"_id\":0} --Sort:{\"createdAt\":-1} --Limit:100}}"
}
```

### Count the matching documents

```json
{
  "$type": "Action",
  "pluginName": "GetMongoDbScalar",
  "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{\"status\":\"open\"}}}"
}
```

### Update documents with an encoded update

The decoded `Document` is `{"$set":{"status":"processed"}}`, which cannot travel inline.

```json
{
  "$type": "Action",
  "pluginName": "InvokeMongoDbWrite",
  "argument": "{{$ --Credentials:mongo-production --Collection:orders --Operation:UpdateMany --CommandText:{\"status\":\"open\"} --Document:eyIkc2V0Ijp7InN0YXR1cyI6InByb2Nlc3NlZCJ9fQ== --DocumentBase64}}"
}
```

### Group documents with a pipeline

The decoded `CommandText` is `[{"$match":{"status":"open"}},{"$group":{"_id":"$sku","total":{"$sum":"$total"}}}]`.

```json
{
  "$type": "Action",
  "pluginName": "InvokeMongoDbAggregate",
  "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:W3siJG1hdGNoIjp7InN0YXR1cyI6Im9wZW4ifX0seyIkZ3JvdXAiOnsiX2lkIjoiJHNrdSIsInRvdGFsIjp7IiRzdW0iOiIkdG90YWwifX19XQ== --Base64}}"
}
```

### Create an index

```json
{
  "$type": "Action",
  "pluginName": "InvokeMongoDbCommand",
  "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}"
}
```

### Import a CSV file in batches

```json
{
  "$type": "Action",
  "pluginName": "ImportMongoDbData",
  "argument": "{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\\data\\customers.csv --BatchSize:1000}}"
}
```

### Collect extracted data into a collection

```json
{
  "$type": "Extraction",
  "pluginName": "ExportData",
  "argument": "{{$ --Scope:Elements}}",
  "locator": "Xpath",
  "onElement": "//table[@id='leads']//tr[td]",
  "dataCollector": {
    "type": "MongoDbDataCollector",
    "source": "mongo-production",
    "repository": "shop.leads",
    "forEntity": false
  },
  "rules": [
    { "$type": "Content", "key": "Name", "locator": "Xpath", "onElement": "./td[1]" },
    { "$type": "Content", "key": "Email", "locator": "Xpath", "onElement": "./td[2]" }
  ]
}
```

`Repository` is `collection` or `database.collection`, split on the first dot only, so `shop.price.history` addresses
the collection `price.history`. An empty value writes to `default-warehouse`. A content key may not be empty, start
with `$`, or contain `.`, because the collector stores it as a field name. Source:
`DataCollectors/MongoDbDataCollector.cs`.

## Run the tests locally

The live tests start one disposable `mongo:8` container on a free loopback port and initiate it as a single-member
replica set, so the transaction scenarios are real. The container publishes its port unchanged, because a replica-set
member advertises the address it was initiated with and that address must resolve both inside the container and on the
host. The container is removed when the test process exits. Source:
`src/G4.UnitTests/Framework/MongoDbTestContainer.cs`.

1. Start Docker. Docker Desktop and Docker under WSL both work on Windows.
2. Run the live tests.

    ```powershell
    dotnet test src/G4.UnitTests/G4.UnitTests.csproj --filter "TestCategory=MongoDbLive"
    ```

3. Read the result. Without Docker, the live tests report Inconclusive instead of failing.

Two environment variables change this behavior.

| Variable | Effect |
| --- | --- |
| `G4_MONGODB_CONNECTION` | Uses an existing deployment instead of a container. The URI must point to a database the tests may write to, and to a replica set or a sharded cluster for the transaction tests. |
| `G4_MONGODB_REQUIRED` | When `true`, a missing deployment fails the tests instead of reporting Inconclusive. |

CI runs the live tests on a Linux job named `InvokeMongoDbTests`, with `G4_MONGODB_REQUIRED` set to `true`. The main
test job excludes them with `TestCategory!=MongoDbLive`.

## If it fails

| Symptom | Likely cause | What to do |
| --- | --- | --- |
| "Authentication failed" | Wrong user name or password, or the user lives in another database | Check the login with `TestMongoDbConnection` and read its `Error` output, then set `AuthenticationDatabase`. |
| "A timeout occurred after 30000ms selecting a server" | The host, the port or the topology is wrong, or the deployment is down | Probe with `TestMongoDbConnection` and a low `CommandTimeout`. For a single member behind a forwarded port, add `DirectConnection`. |
| "No MongoDB target was resolved" | No `Credentials`, `ConnectionString` or `Host` named a deployment | Pass one of the three inputs. |
| "No MongoDB credentials record matches '...'" | A misspelled record name, or a record that is not cached | Check the record name, and remember that the cache is rebuilt on synchronization. |
| "No MongoDB database was resolved" | Neither the connection, the `Database` input nor a qualified collection named a database | Set `Database`, or name the collection as `database.collection`. |
| "The 'CommandText' argument must be a JSON object" | The payload was cut by ` --` or `}}`, or it is not an object | Encode it as UTF-8 Base64 and add the matching switch, or move it to the file argument. |
| "'Document' is not valid Base64." | `DocumentBase64` is set, but `Document` is plain JSON or damaged Base64 | Encode the document, or remove the switch. |
| "The 'CommandText' argument must carry a filter for this operation." | An update, replace or delete named no filter | Pass a filter, or `{"_id":{"$exists":true}}` to address every document on purpose. |
| "Transaction numbers are only allowed on a replica set member or mongos" | The `Transaction` switch was used against a standalone server | Remove the switch, or use a replica set. |
| "$merge cannot be used in a transaction" | A writing pipeline ran with the `Transaction` switch | Remove the switch; the server does not allow those stages in a transaction. |

## Good to know

- `TestMongoDbConnection` reports `Connected` as `false` instead of failing, so a rule can branch on it. It probes the
  resolved database, or `admin` when none is resolved.
- `ExportMongoDbQuery` reports an empty `Result` and a `DocumentCount` of `0` for a filter that matches nothing, which
  is data rather than a failure.
- `InvokeMongoDbWrite` rejects an empty filter on an update, replace or delete, so a step always states its scope.
- An aggregation that ends in `$merge` or `$out` returns no documents of its own, so the driver reads the written
  collection and the step reports those documents.
- `ImportMongoDbData` inserts every CSV cell as a string and omits an empty unquoted field, so a later query can tell a
  missing value from an empty one.
- The collector needs no schema step at all: MongoDB creates the database and the collection on the first insert. Create
  the indexes a later query needs with `InvokeMongoDbCommand`.
- The MongoDB plugin pages are generated by `src/G4.DocumentsGenerator`, like every other plugin page.
