# Import Mongo Db Data (ImportMongoDbData)

[Table of Content](../Home.md)

~17 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Loads documents into a MongoDB collection from a payload the flow already holds.
Accepts inline JSON, a JSON file, and a CSV file with a header row, so an import needs no conversion step.
Parses the payload before it connects, so a malformed payload fails without touching the server.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                 |
| --- | --- |
| Three payload forms        | Inline JSON in Data, a JSON file in DataFile, or a CSV file in DataFile, selected by the `.csv` extension.                                   |
| CSV as text                | Every CSV cell is inserted as a string, and an empty unquoted field is omitted from its document.                                            |
| Batching                   | BatchSize splits the payload into fixed-size inserts, so one oversized payload never travels as a single command.                            |
| Unordered by default       | An insert continues past a rejected document unless the `Ordered` switch is set.                                                             |
| Transactions               | The Transaction switch wraps every batch and commits only on success, on a replica set or a sharded cluster.                                  |
| Session and entity outputs | Stores the count as the Base64 session parameter `ImportMongoDbData:DocumentsInserted` and returns it in the entity unless `NoEntity` is set. |

### Usages in RPA

| Use Case          | Description                                                                             |
| --- | --- |
| File intake       | Load a CSV a partner delivered into a staging collection for later processing.          |
| Result write-back | Insert the documents a bot produced, in one step, after the run.                        |
| Seed data         | Load reference documents a flow needs before its first step.                            |

### Usages in Automation Testing

| Use Case         | Description                                                                        |
| --- | --- |
| Fixture loading  | Load the documents a data-driven suite iterates.                                   |
| Bulk setup       | Load a large payload in batches to build a realistic test collection.              |
| Negative tests   | Load a payload with duplicates to confirm the unordered insert reports partial work. |

### Notes

Data wins over DataFile, and a DataFile extension other than `.csv` is parsed as JSON.
A BatchSize of 0 sends every document in one call and lets the driver split it.
An unordered insert that rejects a document still fails the step, after the other documents landed.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Import inline JSON documents

The argument names the collection and passes the documents as a JSON array.
The step reports how many documents it sent.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportMongoDbData",
    Argument = "{{$ --Credentials:mongo-production --Collection:customers --Data:[{"name":"Ada","tier":"gold"},{"name":"Linus","tier":"silver"}]}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportMongoDbData")
    .setArgument("{{$ --Credentials:mongo-production --Collection:customers --Data:[{"name":"Ada","tier":"gold"},{"name":"Linus","tier":"silver"}]}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportMongoDbData",
    argument: "{{$ --Credentials:mongo-production --Collection:customers --Data:[{"name":"Ada","tier":"gold"},{"name":"Linus","tier":"silver"}]}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --Data:[{"name":"Ada","tier":"gold"},{"name":"Linus","tier":"silver"}]}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:customers --Data:[{"name":"Ada","tier":"gold"},{"name":"Linus","tier":"silver"}]}}"
}
```

### Example No.2

### Import a CSV file in batches

The argument reads a CSV file, whose first record holds the field names, and batches the insert.
Batching keeps each command small for a large file.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportMongoDbData",
    Argument = "{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\data\customers.csv --BatchSize:1000}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportMongoDbData")
    .setArgument("{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\data\customers.csv --BatchSize:1000}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportMongoDbData",
    argument: "{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\data\customers.csv --BatchSize:1000}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\data\customers.csv --BatchSize:1000}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.customers --DataFile:C:\data\customers.csv --BatchSize:1000}}"
}
```

### Example No.3

### Import a JSON file as one transaction

The argument reads a JSON file, inserts in payload order, and wraps the import in a transaction.
Nothing lands when any document is rejected.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ImportMongoDbData",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --DataFile:C:\data\orders.json --Ordered --Transaction}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ImportMongoDbData")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --DataFile:C:\data\orders.json --Ordered --Transaction}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ImportMongoDbData",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --DataFile:C:\data\orders.json --Ordered --Transaction}}"
};
```

**JSON:**

```js
{
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --DataFile:C:\data\orders.json --Ordered --Transaction}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ImportMongoDbData",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --DataFile:C:\data\orders.json --Ordered --Transaction}}"
}
```

## Output Parameter

### Import Mongo Db Data Documents Inserted (ImportMongoDbData:DocumentsInserted)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the number of documents the step sent to the collection.
Lets a flow compare the loaded count with the expected payload size.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Parameters

### Batch Size (BatchSize)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | 0                 |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Splits the payload into inserts of this many documents, such as `1000`.
The value 0 sends every document in one call and lets the driver split it.

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
Every connection setting, such as the host, the login, the replica set, and the TLS mode, is written into the URI itself.

### Credentials (Credentials)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names a stored MongoDB credentials record by name or id, such as `mongo-production`, so secrets stay out of the rule.
The record carries the host, port, login, replica set, and TLS settings, so the step never repeats them.
A value that carries a URI scheme, such as `mongodb://`, is used as a raw connection URI instead, and any other value that matches no record fails the step.

### Data (Data)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Supplies the documents inline, as a JSON array of objects or a single JSON object.
Takes priority over DataFile, so a step can override a shared data file.

### Data File (DataFile)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Reads the documents from a file, such as `C:\data\customers.csv`.
A `.csv` extension is parsed as RFC 4180 CSV with a header row; every other extension is parsed as JSON.
Applies only when Data is not set.

### Database (Database)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

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

### Ordered (Ordered)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Inserts the documents in payload order and stops at the first rejected document.
Leave it unset to insert unordered, so one rejected document does not stop the rest.

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

## Scope

* Any
