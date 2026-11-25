# Invoke Mongo Db Command (InvokeMongoDbCommand)

[Table of Content](../Home.md)

~26 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

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
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"createIndexes\":\"orders\",\"indexes\":[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}}}"
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
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"collStats\":\"orders\"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"collStats\":\"orders\"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"collStats\":\"orders\"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"collStats\":\"orders\"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:{\"collStats\":\"orders\"}}}"
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
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\\flows\\commands\\validate-orders.json --CommandTimeout:600 --NoEntity}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\\flows\\commands\\validate-orders.json --CommandTimeout:600 --NoEntity}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\\flows\\commands\\validate-orders.json --CommandTimeout:600 --NoEntity}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\\flows\\commands\\validate-orders.json --CommandTimeout:600 --NoEntity}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandFile:C:\\flows\\commands\\validate-orders.json --CommandTimeout:600 --NoEntity}}"
}
```

### Example No.4

### Drop a collection with a connection URI

The argument passes a complete MongoDB connection URI instead of a stored credentials record, which suits a local or containerized deployment.
The `drop` command removes the orders collection with its documents and indexes, so a teardown step can reset a test deployment.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandText:{\"drop\":\"orders\"}}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandText:{\"drop\":\"orders\"}}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandText:{\"drop\":\"orders\"}}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandText:{\"drop\":\"orders\"}}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --ConnectionString:mongodb://localhost:27017/shop --CommandText:{\"drop\":\"orders\"}}}"
}
```

### Example No.5

### Set a validator with a Base64-encoded command

The `collMod` command nests a JSON schema, and the Base64 encoding keeps the whole document as one argument value.
The command is encoded as UTF-8 Base64 and the `Base64` switch marks it, which also keeps a command with a space followed by two dashes intact.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb2xsTW9kIjoib3JkZXJzIiwidmFsaWRhdG9yIjp7IiRqc29uU2NoZW1hIjp7ImJzb25UeXBlIjoib2JqZWN0IiwicmVxdWlyZWQiOlsic2t1Il19fX0= --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb2xsTW9kIjoib3JkZXJzIiwidmFsaWRhdG9yIjp7IiRqc29uU2NoZW1hIjp7ImJzb25UeXBlIjoib2JqZWN0IiwicmVxdWlyZWQiOlsic2t1Il19fX0= --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb2xsTW9kIjoib3JkZXJzIiwidmFsaWRhdG9yIjp7IiRqc29uU2NoZW1hIjp7ImJzb25UeXBlIjoib2JqZWN0IiwicmVxdWlyZWQiOlsic2t1Il19fX0= --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb2xsTW9kIjoib3JkZXJzIiwidmFsaWRhdG9yIjp7IiRqc29uU2NoZW1hIjp7ImJzb25UeXBlIjoib2JqZWN0IiwicmVxdWlyZWQiOlsic2t1Il19fX0= --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb2xsTW9kIjoib3JkZXJzIiwidmFsaWRhdG9yIjp7IiRqc29uU2NoZW1hIjp7ImJzb25UeXBlIjoib2JqZWN0IiwicmVxdWlyZWQiOlsic2t1Il19fX0= --Base64}}"
}
```

### Example No.6

### Count today's orders with a Base64 command that holds a macro

The argument binds the `mongo-production` credentials, a Base64 CommandText, and the Base64 switch at runtime.
The decoded payload is `{"count":"orders","query":{"createdOn":{"$gte":"{{$New-Date --Format:yyyy-MM-dd}}"}}}`; the New-Date macro is resolved after decoding, so the server receives the current date.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "InvokeMongoDbCommand",
    Argument = "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb3VudCI6Im9yZGVycyIsInF1ZXJ5Ijp7ImNyZWF0ZWRPbiI6eyIkZ3RlIjoie3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19In19fQ== --Base64}}"
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("InvokeMongoDbCommand")
    .setArgument("{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb3VudCI6Im9yZGVycyIsInF1ZXJ5Ijp7ImNyZWF0ZWRPbiI6eyIkZ3RlIjoie3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19In19fQ== --Base64}}");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "InvokeMongoDbCommand",
    argument: "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb3VudCI6Im9yZGVycyIsInF1ZXJ5Ijp7ImNyZWF0ZWRPbiI6eyIkZ3RlIjoie3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19In19fQ== --Base64}}"
};
```

**JSON:**

```js
{
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb3VudCI6Im9yZGVycyIsInF1ZXJ5Ijp7ImNyZWF0ZWRPbiI6eyIkZ3RlIjoie3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19In19fQ== --Base64}}"
}
```

**Python:**

```python
action_rule = {
    "pluginName": "InvokeMongoDbCommand",
    "argument": "{{$ --Credentials:mongo-production --Database:shop --CommandText:eyJjb3VudCI6Im9yZGVycyIsInF1ZXJ5Ijp7ImNyZWF0ZWRPbiI6eyIkZ3RlIjoie3skTmV3LURhdGUgLS1Gb3JtYXQ6eXl5eS1NTS1kZH19In19fQ== --Base64}}"
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

### Base64 (Base64)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Reads CommandText as UTF-8 Base64 and decodes it before use.
After decoding, the macros in the decoded value are resolved, because the engine resolves the macros of a rule before the plugin runs and cannot see them while the value is encoded.
Use it for a payload that contains ` --` or `}}`, which end an inline argument value.
Invalid Base64 fails the step, so an encoded payload never reaches the server as text.

### Command File (CommandFile)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

Reads the payload from a UTF-8 file, such as `C:\flows\filter.json`.
Applies only when CommandText is not set, so an inline payload always takes priority.
The Base64 switch never applies here; file content is always read as plain text.

### Command Text (CommandText)

| Attribute          | Value              |
| ------------------ | ------------------ |
| **Default Value**  | Null               |
| **Depends On**     | None               |
| **Mandatory**      | No                 |
| **Multiple**       | No                 |
| **Value Type**     | String\|Expression |

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
