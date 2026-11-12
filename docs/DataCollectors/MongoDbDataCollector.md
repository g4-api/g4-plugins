# Mongo Db Data Collector (MongoDbDataCollector)

[Table of Content](../Home.md)

~14 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Writes the entities of an ExportData extraction into a MongoDB collection.
Each entity becomes one document, and nested extracted content becomes real subdocuments and arrays.
MongoDB creates the database and the collection on the first insert, so the collector needs no schema step.

### Key Features and Functionality

| Feature             | Description                                                                                                                   |
| --- | --- |
| No schema step      | The database and the collection are created by the first insert, so nothing has to be declared in advance.                     |
| Nested content      | Dictionaries become subdocuments and sequences become arrays, so nested content stays queryable by dot path.                   |
| Qualified target    | Repository names the destination as `collection` or `database.collection`, split on the first dot only.                        |
| Default destination | An empty Repository writes to the `default-warehouse` collection, matching the SQLite collector default.                       |
| Unordered insert    | Entities are inserted unordered, so one rejected document still lets the rest of the extraction land.                           |
| Key validation      | An empty content key, a key that starts with `$`, or a key that contains `.` fails the collector by name.                      |

### Usages in RPA

| Use Case            | Description                                                                              |
| --- | --- |
| Web scraping sink   | Collect scraped rows into a collection a later aggregation reports on.                   |
| Document harvesting | Collect nested content, such as a product with its variants, as one queryable document.  |
| Daily data feed     | Append the entities of each run to a warehouse collection without any schema migration.  |

### Usages in Automation Testing

| Use Case          | Description                                                                         |
| --- | --- |
| Extraction assert | Collect extracted entities and assert on them with ExportMongoDbQuery.              |
| Shape regression  | Compare the field names of a collected run with the expected extraction shape.      |
| Evidence store    | Keep the entities of each test run for later inspection, addressed by a run field.   |

### Notes

The collector rule carries no discrete connection overrides, so the whole target comes from Source and Repository.
Nested content is stored as BSON rather than as JSON text, which is the deliberate difference from the SQL Server collector.
Create the indexes a later query needs with InvokeMongoDbCommand, because an inserted collection has only its default index.

## Examples

### Example No.1

### Collect extracted rows into MongoDB

The ExportData rule extracts one entity per table row and names the MongoDB collector as its `dataCollector`.
Repository is qualified as `shop.leads`, so the database is explicit, and `forEntity` is false, so every entity is written together at the end.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportData",
    Argument = "{{$ --Scope:Elements}}",
    OnElement = "//table[@id='leads']//tr[td]",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = "./td[1]"
        },
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = "./td[2]"
        }
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = "./td[3]"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportData")
    .setArgument("{{$ --Scope:Elements}}")
    .setOnElement("//table[@id='leads']//tr[td]")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement("./td[1]"),

        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement("./td[2]"))
        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement("./td[3]");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportData",
    argument: "{{$ --Scope:Elements}}",
    onElement: "//table[@id='leads']//tr[td]",
    rules: [,
        {
            pluginName: "",
            onElement: "./td[1]"
        },
        {
            pluginName: "",
            onElement: "./td[2]"
        }
        {
            pluginName: "",
            onElement: "./td[3]"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "ExportData",
    "argument": "{{$ --Scope:Elements}}",
    "onElement": "//table[@id='leads']//tr[td]",
    "rules": [,
        {
            "pluginName": "",
            "onElement": "./td[1]"
        },
        {
            "pluginName": "",
            "onElement": "./td[2]"
        }
        {
            "pluginName": "",
            "onElement": "./td[3]"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportData",
    "argument": "{{$ --Scope:Elements}}",
    "onElement": "//table[@id='leads']//tr[td]",
    "rules": [,
        {
            "pluginName": "",
            "onElement": "./td[1]"
        },
        {
            "pluginName": "",
            "onElement": "./td[2]"
        }
        {
            "pluginName": "",
            "onElement": "./td[3]"
        }
    ]
}
```

### Example No.2

### Collect each entity as it is extracted

The rule passes a connection URI as its `source`, which suits a local or containerized deployment.
`forEntity` is true, so each entity is inserted as soon as it is extracted.

**CSharp:**

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "ExportData",
    Argument = "{{$ --Scope:Elements}}",
    OnElement = "//div[@class='product']",
    Rules = new[]
    {,
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = ".//span[@class='sku']"
        }
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = ".//span[@class='price']"
        }
    }
};
```

**Java:**

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("ExportData")
    .setArgument("{{$ --Scope:Elements}}")
    .setOnElement("//div[@class='product']")
    .setActions(,

        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement(".//span[@class='sku']"))
        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement(".//span[@class='price']");
```

**Javascript:**

```js
var actionRule = {
    pluginName: "ExportData",
    argument: "{{$ --Scope:Elements}}",
    onElement: "//div[@class='product']",
    rules: [,
        {
            pluginName: "",
            onElement: ".//span[@class='sku']"
        }
        {
            pluginName: "",
            onElement: ".//span[@class='price']"
        }
    ]
};
```

**JSON:**

```js
{
    "pluginName": "ExportData",
    "argument": "{{$ --Scope:Elements}}",
    "onElement": "//div[@class='product']",
    "rules": [,
        {
            "pluginName": "",
            "onElement": ".//span[@class='sku']"
        }
        {
            "pluginName": "",
            "onElement": ".//span[@class='price']"
        }
    ]
}
```

**Python:**

```python
action_rule = {
    "pluginName": "ExportData",
    "argument": "{{$ --Scope:Elements}}",
    "onElement": "//div[@class='product']",
    "rules": [,
        {
            "pluginName": "",
            "onElement": ".//span[@class='sku']"
        }
        {
            "pluginName": "",
            "onElement": ".//span[@class='price']"
        }
    ]
}
```

## Properties

### For Entity (ForEntity)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Boolean           |

Set to true to write each extracted entity to the collection as soon as it is extracted.
Set to false to write all extracted entities together after the extraction finishes, in one insert.
Writing per entity keeps documents flowing during long extractions, while writing at the end needs fewer round trips.

### Repository (Repository)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | default-warehouse |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the destination as collection or database.collection, such as `shop.leads`.
A name without a database uses the database the Source resolved, and an empty value uses the collection default-warehouse.
The database and the collection are created automatically on the first insert.

### Source (Source)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names a stored MongoDB credentials record by its name or id, so the login stays out of the automation definition.
A value that carries a URI scheme, such as `mongodb://`, is used as a raw connection URI instead.
Any other value that matches no record is rejected, so a typed record name never reads as a host name.

### Type (Type)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Enter MongoDbDataCollector so the extracted data is written to MongoDB by this collector.
A different value sends the data to another collector, such as a file, SQLite, or SQL Server collector.

## Scope

* Any
