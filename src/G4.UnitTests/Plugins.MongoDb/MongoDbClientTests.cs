using G4.Plugins.MongoDb.Clients;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("MongoDbClient")]
    [TestCategory("UnitTest")]
    public class MongoDbClientTests
    {
        // Field names expected from the union of two differently shaped documents, in first-seen order.
        private static readonly string[] ExpectedUnionColumns = ["b", "a", "c"];

        // Field names expected from a result set whose documents share one field and differ in another.
        private static readonly string[] ExpectedResultSetColumns = ["a", "b"];

        [TestMethod(DisplayName = "Verify that ConvertCsvToDocuments keeps quoted commas, doubled quotes, and line " +
            "breaks and omits empty unquoted fields from their documents.")]
        public void ConvertCsvToDocumentsQuotedFieldsTest()
        {
            // Arrange: build RFC 4180 text with CRLF records, a quoted comma, doubled quotes, an embedded line break,
            // an empty unquoted field, and an empty quoted field.
            var csv = "Id,Name,Note\r\n" +
                "1,\"Doe, Jane\",\"She said \"\"hi\"\"\"\r\n" +
                "2,,\"line1\nline2\"\r\n" +
                "3,\"\",plain\r\n";

            // Act: parse the text into documents.
            var documents = MongoDbClient.ConvertCsvToDocuments(csv);

            // Assert: every data record becomes one document, and the header record is not one of them.
            Assert.HasCount(expected: 3, collection: documents);

            // Assert: a quoted field keeps its comma and its doubled quotes become single ones.
            Assert.AreEqual(expected: "Doe, Jane", actual: documents[0]["Name"].AsString);
            Assert.AreEqual(expected: "She said \"hi\"", actual: documents[0]["Note"].AsString);

            // Assert: an empty unquoted field is omitted, while a quoted empty field is stored as an empty string.
            Assert.IsFalse(condition: documents[1].Contains("Name"));
            Assert.AreEqual(expected: "line1\nline2", actual: documents[1]["Note"].AsString);
            Assert.AreEqual(expected: string.Empty, actual: documents[2]["Name"].AsString);
        }

        [TestMethod(DisplayName = "Verify that ConvertCsvToDocuments rejects CSV text without a header row.")]
        public void ConvertCsvToDocumentsWithoutHeaderTest()
        {
            // Act and Assert: an empty payload carries no field names, so it cannot become documents.
            Assert.ThrowsExactly<FormatException>(() => MongoDbClient.ConvertCsvToDocuments(csv: string.Empty));
        }

        [TestMethod(DisplayName = "Verify that ConvertToBsonValue maps nested dictionaries and sequences to " +
            "subdocuments and arrays and keeps primitive types.")]
        public void ConvertToBsonValueNestedTest()
        {
            // Arrange: build content with a nested map, a nested sequence, a primitive, and a missing value.
            var content = new Dictionary<string, object>
            {
                ["Address"] = new Dictionary<string, object> { ["City"] = "Haifa" },
                ["Tags"] = new List<object> { "a", 1 },
                ["Count"] = 7,
                ["Missing"] = null
            };

            // Act: convert the whole map, which converts its values recursively.
            var value = MongoDbClient.ConvertToBsonValue(content);

            // Assert: the map becomes a document whose nested values keep their BSON shape.
            var document = value.AsBsonDocument;
            Assert.AreEqual(expected: "Haifa", actual: document["Address"]["City"].AsString);
            Assert.AreEqual(expected: BsonType.Array, actual: document["Tags"].BsonType);
            Assert.AreEqual(expected: 2, actual: document["Tags"].AsBsonArray.Count);
            Assert.AreEqual(expected: 7, actual: document["Count"].AsInt32);
            Assert.AreEqual(expected: BsonNull.Value, actual: document["Missing"]);
        }

        [TestMethod(DisplayName = "Verify that ConvertToColumns reports the union of the top-level field names in " +
            "first-seen order.")]
        public void ConvertToColumnsOrderTest()
        {
            // Arrange: build documents whose shapes differ, as schemaless documents do.
            var documents = new List<BsonDocument>
            {
                BsonDocument.Parse("{ \"b\": 1, \"a\": 2 }"),
                BsonDocument.Parse("{ \"a\": 3, \"c\": 4 }")
            };

            // Act: collect the field names.
            var columns = MongoDbClient.ConvertToColumns(documents);

            // Assert: every field appears once, in the order it was first seen.
            Assert.AreSequenceEqual(expected: ExpectedUnionColumns, actual: columns);
        }

        [TestMethod(DisplayName = "Verify that ConvertToDocument accepts both Extended JSON forms and treats a " +
            "missing value as an empty document.")]
        public void ConvertToDocumentExtendedJsonTest()
        {
            // Act: parse an Extended JSON object identifier and a missing value.
            var document = MongoDbClient.ConvertToDocument(
                json: "{ \"_id\": { \"$oid\": \"6553f1c2a1b2c3d4e5f60718\" } }",
                argumentName: "CommandText");
            var empty = MongoDbClient.ConvertToDocument(json: null, argumentName: "CommandText");

            // Assert: the Extended JSON wrapper becomes a real object identifier, not a nested document.
            Assert.AreEqual(expected: BsonType.ObjectId, actual: document["_id"].BsonType);

            // Assert: a missing value is an empty document, which matches every document as a filter.
            Assert.AreEqual(expected: 0, actual: empty.ElementCount);
        }

        [TestMethod(DisplayName = "Verify that ConvertToDocument reports the argument name when the payload is not " +
            "a JSON object.")]
        public void ConvertToDocumentInvalidTest()
        {
            // Act: parse a payload that is not an object and capture the rejection.
            var exception = Assert.ThrowsExactly<FormatException>(
                () => MongoDbClient.ConvertToDocument(json: "not json", argumentName: "Projection"));

            // Assert: the message names the argument that carried the payload.
            Assert.Contains(substring: "Projection", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ConvertToDocuments accepts a single object and an array and rejects " +
            "an array item that is not an object.")]
        public void ConvertToDocumentsShapesTest()
        {
            // Act: parse a single object and an array of objects.
            var single = MongoDbClient.ConvertToDocuments(json: "{ \"a\": 1 }", argumentName: "Data");
            var many = MongoDbClient.ConvertToDocuments(json: "[{ \"a\": 1 }, { \"a\": 2 }]", argumentName: "Data");

            // Assert: a single object needs no array wrapper, and an array maps item by item.
            Assert.HasCount(expected: 1, collection: single);
            Assert.HasCount(expected: 2, collection: many);

            // Assert: an array of non-objects cannot become documents.
            Assert.ThrowsExactly<FormatException>(
                () => MongoDbClient.ConvertToDocuments(json: "[1, 2]", argumentName: "Data"));

            // Assert: an empty payload has no documents to insert.
            Assert.ThrowsExactly<FormatException>(
                () => MongoDbClient.ConvertToDocuments(json: " ", argumentName: "Data"));
        }

        [TestMethod(DisplayName = "Verify that ConvertToJson serializes documents, text values, and scalars as " +
            "minified relaxed Extended JSON.")]
        public void ConvertToJsonFormsTest()
        {
            // Arrange: build one document with a typed value and a list of field names.
            var documents = new List<BsonDocument> { BsonDocument.Parse("{ \"a\": 1 }") };
            var columns = new[] { "a", "b" };

            // Act: serialize each supported input form.
            var documentsJson = MongoDbClient.ConvertToJson(documents);
            var columnsJson = MongoDbClient.ConvertToJson(columns);
            var scalarJson = MongoDbClient.ConvertToJson(value: new BsonInt64(42));
            var objectIdJson = MongoDbClient.ConvertToJson(
                value: new BsonObjectId(ObjectId.Parse("6553f1c2a1b2c3d4e5f60718")));
            var nullJson = MongoDbClient.ConvertToJson(value: BsonNull.Value);

            // Assert: documents and field names serialize as JSON arrays.
            Assert.StartsWith(expectedPrefix: "[", value: documentsJson);
            Assert.Contains(substring: "\"a\"", value: documentsJson);
            Assert.Contains(substring: "\"b\"", value: columnsJson);

            // Assert: a scalar keeps its JSON literal and a BSON-only type keeps its Extended JSON wrapper.
            Assert.AreEqual(expected: "42", actual: scalarJson);
            Assert.Contains(substring: "$oid", value: objectIdJson);
            Assert.AreEqual(expected: "null", actual: nullJson);
        }

        [TestMethod(DisplayName = "Verify that ConvertToNamespaceParts splits on the first dot only and reports no " +
            "database for an unqualified name.")]
        #region *** Data Set ***
        [DataRow("orders", "", "orders", DisplayName = "Collection only")]
        [DataRow("shop.orders", "shop", "orders", DisplayName = "Qualified name")]
        [DataRow("shop.price.history", "shop", "price.history", DisplayName = "Collection with dots")]
        [DataRow("  shop.orders  ", "shop", "orders", DisplayName = "Surrounding whitespace")]
        #endregion
        public void ConvertToNamespacePartsTest(string collectionName, string expectedDatabase, string expectedCollection)
        {
            // Act: split the name into its parts.
            var (database, collection) = MongoDbClient.ConvertToNamespaceParts(collectionName);

            // Assert: the first dot separates the database, and later dots stay in the collection name.
            Assert.AreEqual(expected: expectedDatabase, actual: database);
            Assert.AreEqual(expected: expectedCollection, actual: collection);
        }

        [TestMethod(DisplayName = "Verify that ConvertToNamespaceParts rejects names MongoDB cannot address.")]
        #region *** Data Set ***
        [DataRow("", DisplayName = "Empty name")]
        [DataRow("   ", DisplayName = "Whitespace name")]
        [DataRow("shop.", DisplayName = "Empty collection part")]
        [DataRow("shop.or$ders", DisplayName = "Dollar sign in collection")]
        [DataRow("shop.system.users", DisplayName = "System namespace")]
        #endregion
        public void ConvertToNamespacePartsInvalidTest(string collectionName)
        {
            // Act and Assert: an unaddressable name fails before any client is opened.
            Assert.ThrowsExactly<ArgumentException>(() => MongoDbClient.ConvertToNamespaceParts(collectionName));
        }

        [TestMethod(DisplayName = "Verify that ConvertToNamespaceParts rejects a database name that carries an " +
            "illegal character or exceeds the length limit.")]
        public void ConvertToNamespacePartsDatabaseLimitsTest()
        {
            // Arrange: compose a database name one byte past the limit.
            var longName = new string('a', MongoDbClient.MaximumDatabaseNameLength + 1);

            // Act and Assert: both the illegal character and the oversized name are rejected by name.
            Assert.ThrowsExactly<ArgumentException>(
                () => MongoDbClient.ConvertToNamespaceParts("sh op.orders"));
            Assert.ThrowsExactly<ArgumentException>(
                () => MongoDbClient.ConvertToNamespaceParts($"{longName}.orders"));
        }

        [TestMethod(DisplayName = "Verify that ConvertToText keeps a string raw, maps a missing value to empty " +
            "text, and serializes every other value as JSON.")]
        public void ConvertToTextFormsTest()
        {
            // Act: convert each documented value form.
            var text = MongoDbClient.ConvertToText(value: new BsonString("Ada"));
            var number = MongoDbClient.ConvertToText(value: new BsonInt32(7));
            var missing = MongoDbClient.ConvertToText(value: BsonNull.Value);
            var absent = MongoDbClient.ConvertToText(value: null);

            // Assert: a string is unquoted, a number keeps its literal, and a missing value is empty text.
            Assert.AreEqual(expected: "Ada", actual: text);
            Assert.AreEqual(expected: "7", actual: number);
            Assert.AreEqual(expected: string.Empty, actual: missing);
            Assert.AreEqual(expected: string.Empty, actual: absent);
        }

        [TestMethod(DisplayName = "Verify that ConvertToValue parses a top-level array and reports the argument " +
            "name for invalid JSON.")]
        public void ConvertToValueArrayTest()
        {
            // Act: parse a top-level array, which a BSON document cannot hold on its own.
            var value = MongoDbClient.ConvertToValue(json: "[1, 2, 3]", argumentName: "CommandText");

            // Assert: the array is parsed as a BSON array.
            Assert.AreEqual(expected: BsonType.Array, actual: value.BsonType);
            Assert.AreEqual(expected: 3, actual: value.AsBsonArray.Count);

            // Assert: invalid JSON names the argument that carried it.
            var exception = Assert.ThrowsExactly<FormatException>(
                () => MongoDbClient.ConvertToValue(json: "{ broken", argumentName: "CommandText"));
            Assert.Contains(substring: "CommandText", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that NewResultSet reports the documents together with their field names.")]
        public void NewResultSetTest()
        {
            // Arrange: build two documents with one shared and one distinct field.
            var documents = new[]
            {
                BsonDocument.Parse("{ \"a\": 1 }"),
                BsonDocument.Parse("{ \"a\": 2, \"b\": 3 }")
            };

            // Act: build the result set from the documents.
            var result = MongoDbClient.NewResultSet(documents);

            // Assert: the set holds every document and the union of their field names.
            Assert.HasCount(expected: 2, collection: result.Documents);
            Assert.AreSequenceEqual(expected: ExpectedResultSetColumns, actual: result.Columns);
        }

        [TestMethod(DisplayName = "Verify that NewResultSet treats a missing document collection as an empty set.")]
        public void NewResultSetEmptyTest()
        {
            // Act: build the set from no documents at all.
            var result = MongoDbClient.NewResultSet(documents: null);

            // Assert: the set is empty rather than null, so callers need no null check.
            Assert.IsEmpty(collection: result.Documents);
            Assert.IsEmpty(collection: result.Columns);
        }

        [TestMethod(DisplayName = "Verify that GetDatabase rejects an empty database name with a message that " +
            "names the inputs that resolve it.")]
        public void GetDatabaseMissingNameTest()
        {
            // Arrange: open a client against an address the test never contacts, because the name fails first.
            using var client = new MongoDB.Driver.MongoClient("mongodb://127.0.0.1:27017");

            // Act: resolve an empty database name and capture the rejection.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => MongoDbClient.GetDatabase(client, databaseName: " "));

            // Assert: the message names the inputs a flow can set.
            Assert.Contains(substring: "No MongoDB database was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that OpenClient requires the resolved connection settings.")]
        public void OpenClientNullTest()
        {
            // Act and Assert: a missing settings model fails before a client is allocated.
            var exception = Assert.ThrowsExactly<ArgumentNullException>(
                () => MongoDbClient.OpenClient(connectionModel: null));

            Assert.AreEqual(expected: "connectionModel", actual: exception.ParamName);
        }
    }
}
