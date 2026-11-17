# Get Mongo Db Scalar (GetMongoDbScalar)

[Table of Content](../Home.md)

~23 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Reads a single value from a MongoDB collection instead of a document set.
Counts the matching documents, collects the distinct values of one field, or reads one field of the first matching document.
Stores the value as text, so a condition or a report can use it directly.

### Key Features and Functionality

| Feature                    | Description                                                                                                                                |
| --- | --- |
| Three modes                | Count counts the matching documents, Distinct collects the values of one field, and Field reads one field of the first match.               |
| Filter as data             | Reads the filter from CommandText, CommandFile, or Base64-encoded text and binds it as BSON.                                               |
| Dot paths                  | Field follows a dot path, so `address.city` reads the city of the address subdocument.                                                      |
| Missing values             | A mode that finds no document or no field stores an empty value instead of failing.                                                         |
| Raw text for strings       | A string value is stored unquoted, while every other value uses its relaxed Extended JSON form.                                            |
| Session and entity outputs | Stores the value as the Base64 session parameter `GetMongoDbScalar:Value` and returns it in the response entity unless `NoEntity` is set.    |

### Usages in RPA

| Use Case           | Description                                                                             |
| --- | --- |
| Queue depth check  | Count the pending documents and skip a run when the queue is empty.                     |
| Lookup value       | Read one field, such as a customer tier, and bind it into a later step.                 |
| Category discovery | Collect the distinct values of a field to drive a loop over categories.                 |

### Usages in Automation Testing

| Use Case          | Description                                                                        |
| --- | --- |
| Row-count assert  | Count the documents a flow wrote and compare the count with the expected number.   |
| Field assert      | Read one field of a written document and compare it with the expected value.       |
| Uniqueness check  | Collect the distinct values of a key and confirm the expected set.                  |

### Notes

Mode accepts Count, Distinct, and Field, case-insensitively, and defaults to Count.
Distinct and Field require the Field parameter; Count ignores it.
Outputs are plain text in the response entity and Base64-encoded in the session parameters.

## Examples

### Example No.1

### Count the documents a filter matches

The argument names the collection and passes the filter as a JSON object.
The step stores the count, which a later condition can compare with a threshold.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetMongoDbScalar",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetMongoDbScalar")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetMongoDbScalar",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:{"status":"open"}}}"
}
```

### Example No.2

### Read one field of the first match

The argument selects Field mode, names the dot path, and sorts so the newest document is first.
A string value is stored unquoted, so a later step can use it directly.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetMongoDbScalar",
    Argument = "{{$ --Credentials:mongo-production --Collection:shop.customers --Mode:Field --Field:address.city --CommandText:{"tier":"gold"} --Sort:{"createdAt":-1}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetMongoDbScalar")
    .setArgument("{{$ --Credentials:mongo-production --Collection:shop.customers --Mode:Field --Field:address.city --CommandText:{"tier":"gold"} --Sort:{"createdAt":-1}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetMongoDbScalar",
    argument: "{{$ --Credentials:mongo-production --Collection:shop.customers --Mode:Field --Field:address.city --CommandText:{"tier":"gold"} --Sort:{"createdAt":-1}}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.customers --Mode:Field --Field:address.city --CommandText:{"tier":"gold"} --Sort:{"createdAt":-1}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:shop.customers --Mode:Field --Field:address.city --CommandText:{"tier":"gold"} --Sort:{"createdAt":-1}}}"
}
```

### Example No.3

### Collect the distinct values of a field

The argument selects Distinct mode and names the field.
The step stores the values as a JSON array, which a later loop can iterate.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetMongoDbScalar",
    Argument = "{{$ --Credentials:mongo-production --Collection:products --Mode:Distinct --Field:category}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetMongoDbScalar")
    .setArgument("{{$ --Credentials:mongo-production --Collection:products --Mode:Distinct --Field:category}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetMongoDbScalar",
    argument: "{{$ --Credentials:mongo-production --Collection:products --Mode:Distinct --Field:category}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:products --Mode:Distinct --Field:category}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:products --Mode:Distinct --Field:category}}"
}
```

### Example No.4

### Count documents with a connection URI

The argument passes a complete MongoDB connection URI instead of a stored credentials record, which suits a local or containerized deployment.
The database comes from the URI path, so the step names only the collection and the filter to count.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetMongoDbScalar",
    Argument = "{{$ --ConnectionString:mongodb://localhost:27017/shop --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetMongoDbScalar")
    .setArgument("{{$ --ConnectionString:mongodb://localhost:27017/shop --Collection:orders --CommandText:{"status":"open"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetMongoDbScalar",
    argument: "{{$ --ConnectionString:mongodb://localhost:27017/shop --Collection:orders --CommandText:{"status":"open"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --Collection:orders --CommandText:{"status":"open"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --Collection:orders --CommandText:{"status":"open"}}}"
}
```

### Example No.5

### Count documents with a Base64-encoded filter

The filter holds a space followed by two dashes, which would end the inline argument value, so it is encoded as UTF-8 Base64 and the `Base64` switch marks it.
The decoded filter is `{"status":"open","note":{"$ne":"draft -- legacy"}}`, and the step counts the documents it matches.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "GetMongoDbScalar",
    Argument = "{{$ --Credentials:mongo-production --Collection:orders --CommandText:eyJzdGF0dXMiOiJvcGVuIiwibm90ZSI6eyIkbmUiOiJkcmFmdCAtLSBsZWdhY3kifX0= --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("GetMongoDbScalar")
    .setArgument("{{$ --Credentials:mongo-production --Collection:orders --CommandText:eyJzdGF0dXMiOiJvcGVuIiwibm90ZSI6eyIkbmUiOiJkcmFmdCAtLSBsZWdhY3kifX0= --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "GetMongoDbScalar",
    argument: "{{$ --Credentials:mongo-production --Collection:orders --CommandText:eyJzdGF0dXMiOiJvcGVuIiwibm90ZSI6eyIkbmUiOiJkcmFmdCAtLSBsZWdhY3kifX0= --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:eyJzdGF0dXMiOiJvcGVuIiwibm90ZSI6eyIkbmUiOiJkcmFmdCAtLSBsZWdhY3kifX0= --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "GetMongoDbScalar",
    "argument": "{{$ --Credentials:mongo-production --Collection:orders --CommandText:eyJzdGF0dXMiOiJvcGVuIiwibm90ZSI6eyIkbmUiOiJkcmFmdCAtLSBsZWdhY3kifX0= --Base64}}"
}
```

## Output Parameter

### Get Mongo Db Scalar Value (GetMongoDbScalar:Value)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Stores the value the selected mode read: a count, a JSON array of distinct values, or one field value.
A string value is stored unquoted, a missing value as an empty string, and every other value in its relaxed Extended JSON form.
The session value is Base64-encoded, so decode it before comparing or displaying it.

## Parameters

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
An omitted filter matches every document, which counts the whole collection in Count mode.
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

### Field (Field)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Names the field the step reads, such as `status` or `address.city`.
Required for the Distinct and Field modes and ignored by the Count mode.
A dot path reads into subdocuments, and a missing segment yields an empty value.

### Mode (Mode)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Count             |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Selects which single value the step reads.
Defaults to Count, which needs no Field parameter.

#### Values

##### Count

Counts the documents the filter matches, which the server evaluates without returning them.
Use it for queue depth checks and row-count assertions.

##### Distinct

Collects the distinct values of the named field across the matching documents, as an array.
Mixed types are preserved, because the values are read as raw BSON.

##### Field

Reads the named field of the first matching document, following a dot path into subdocuments.
Pair it with Sort, which decides which document is first.

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

### Sort (Sort)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Orders the documents before the Field mode reads the first one, as a JSON object such as `{"createdAt":-1}`.
Applies to the Field mode only; Count and Distinct ignore it.

## Scope

* Any
