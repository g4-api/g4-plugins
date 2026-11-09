# Sql Server Data Collector (SqlServerDataCollector)

[Table of Content](../Home.md)

~15 min · DataCollector Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

SqlServerDataCollector saves the results of an extraction rule into a SQL Server table.
Each extracted entity becomes one row, and each content key becomes a column, so scraped or captured data is ready for SQL queries and reports.
It removes manual table preparation because it creates the schema, the table, and new columns on demand.

### Key Features and Functionality

| Feature | Description |
| --- | --- |
| Extraction integration | Receives the entities of an extraction rule through its dataCollector setting and writes them to the Repository table. |
| Automatic table creation | Creates the schema and the table when they do not exist, with one NVARCHAR(MAX) NULL column per content key. |
| Schema growth | Adds NVARCHAR(MAX) NULL columns for new content keys and never alters or drops existing columns or rows. |
| Bulk insert | Inserts all entities of a write in one bulk copy, using the union of the content keys of every entity. |
| Value storage | Stores text values as-is, missing values as NULL, and numbers, booleans, objects, and arrays as minified JSON text. |
| Flexible connection | Resolves Source as a stored credentials record by name or id, or as a raw connection string. |
| Write modes | Writes each entity as soon as it is extracted (ForEntity true) or all entities once at the end (ForEntity false). |

### Usages in RPA

| Use Case | Description |
| --- | --- |
| Web scraping to SQL Server | Stores listings, prices, or contacts scraped from pages directly in a database table. |
| Lead and record capture | Collects leads or records from web portals into a shared sales or operations table. |
| Central data store | Gives other services and reports one SQL Server table to query instead of local files. |
| Incremental collection | Appends new rows on every run and grows the table when pages start showing new fields. |

### Usages in Automation Testing

| Use Case | Description |
| --- | --- |
| UI data snapshots | Saves values read from the application under test so later SQL queries can compare them with expected data. |
| Cross-run comparison | Keeps extraction results from several runs in one table to spot changes between builds. |

### Requirements and Limitations

| Item | Description |
| --- | --- |
| SQL Server version | Requires SQL Server 2017 or later, or Azure SQL, because table preparation uses STRING_AGG and OPENJSON. |
| Permissions | The login needs rights to create schemas, create and alter tables, and insert rows when those objects are missing. |
| Text columns | Every column the collector creates is NVARCHAR(MAX) NULL; convert values in SQL when typed columns are needed. |
| Column names | A content key longer than 128 characters is rejected, because SQL Server cannot name such a column. |
| Empty extraction | An extraction without entities writes nothing and does not open a connection. |

## Examples

### Example No.1

### Collect extracted leads into a SQL Server table

The extraction rule reads the name, email, and company from each lead row matched by the XPath `//table[@id='leads']//tr[td]`.
The `dataCollector` setting sends the entities to `SqlServerDataCollector`, which writes them to `sales.Leads` through the stored credentials record `sql-production` once the extraction finishes (`forEntity` is `false`).

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

### Stream extracted entities into the default table

The extraction rule reads the title and price of each product card matched by the XPath `//div[@class='product']`.
With `forEntity` set to `true` and no `repository`, every entity is written right away to the `default-warehouse` table in `dbo` through a raw connection string.

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
            OnElement = ".//span[@class='price']"
        }
        new ActionRuleModel
        {
            PluginName = "",
            OnElement = ".//h2"
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
            .setOnElement(".//span[@class='price']"))
        new ActionRuleModel()        
            .setPluginName("")
            .setOnElement(".//h2");
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
            onElement: ".//span[@class='price']"
        }
        {
            pluginName: "",
            onElement: ".//h2"
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
            "onElement": ".//span[@class='price']"
        }
        {
            "pluginName": "",
            "onElement": ".//h2"
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
            "onElement": ".//span[@class='price']"
        }
        {
            "pluginName": "",
            "onElement": ".//h2"
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

Set to true to write each extracted entity to the table as soon as it is extracted.
Set to false to write all extracted entities together after the extraction finishes, in one bulk insert.
Writing per entity keeps rows flowing during long extractions, while writing at the end needs fewer round trips.

### Repository (Repository)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | default-warehouse |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names the destination table, as table, schema.table, or a bracketed name such as [sales].[Leads].
A name without a schema uses the dbo schema, and an empty value uses the table default-warehouse.
The schema and the table are created automatically when they do not exist.

### Source (Source)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

Names a stored SQL Server credentials record by its name or id, so the login stays out of the automation definition.
When no record matches, a value that contains an equals sign is used as a raw ADO.NET connection string.
Any other unmatched value is used as a raw Microsoft Entra access token, which has no server of its own and is therefore rejected.

### Type (Type)

| Attribute         | Value             |
| ----------------- | ----------------- |
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | DataCollector     |

Enter SqlServerDataCollector so the extracted data is written to SQL Server by this collector.
A different value sends the data to another collector, such as a file or SQLite collector.

## Scope

* Any
