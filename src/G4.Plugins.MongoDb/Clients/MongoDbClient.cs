using G4.Plugins.MongoDb.Models;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace G4.Plugins.MongoDb.Clients
{
    /// <summary>
    /// Provides the client, namespace, and value conversions shared by the MongoDB plugins.
    /// </summary>
    /// <remarks>
    /// Every plugin opens its client, addresses its collection, parses its JSON arguments, and serializes its outputs
    /// through these members, so one data contract applies to the whole suite and each plugin stays focused on its own
    /// MongoDB operation. Documents are read and written as <see cref="BsonDocument"/> values and serialized as
    /// relaxed Extended JSON, so types that JSON cannot express, such as object identifiers and dates, survive a round
    /// trip through a session parameter.
    /// </remarks>
    internal static class MongoDbClient
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the command timeout, in seconds, used when a step sets no <c>CommandTimeout</c> argument.
        /// </summary>
        public const int DefaultCommandTimeoutSeconds = 30;

        /// <summary>
        /// Specifies the TCP port used when neither the connection string nor the <c>Port</c> argument names one.
        /// </summary>
        public const int DefaultPort = 27017;

        /// <summary>
        /// Specifies the maximum length, in UTF-8 bytes, of a MongoDB database name.
        /// </summary>
        public const int MaximumDatabaseNameLength = 63;

        /// <summary>
        /// Specifies the maximum length, in UTF-8 bytes, of a fully qualified <c>database.collection</c> namespace.
        /// </summary>
        public const int MaximumNamespaceLength = 255;

        // Names the characters MongoDB rejects inside a database name, including the dot that separates the namespace.
        private const string InvalidDatabaseNameCharacters = "/\\. \"$*<>:|?";

        // Serializes documents as minified relaxed Extended JSON, so stored values stay compact and readable while
        // BSON types that JSON cannot express keep their type wrapper.
        private static readonly JsonWriterSettings JsonSettings = new()
        {
            Indent = false,
            OutputMode = JsonOutputMode.RelaxedExtendedJson
        };
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Converts RFC 4180 CSV text with a header row into documents for an insert.
        /// </summary>
        /// <remarks>
        /// Quoted fields can contain commas, line breaks, and doubled quotes. Every cell is inserted as a string, so
        /// the documents mirror the CSV text exactly; an empty unquoted field is omitted from its document rather than
        /// stored as an empty string.
        /// </remarks>
        /// <param name="csv">The CSV text whose first record holds the field names.</param>
        /// <returns>One document per data record.</returns>
        /// <exception cref="FormatException">Thrown when the CSV has no header row.</exception>
        public static List<BsonDocument> ConvertCsvToDocuments(string csv)
        {
            // Parse every record so the header and the data records share one tokenizer.
            var records = ReadCsvRecords(csv: csv ?? string.Empty);

            if (records.Count == 0)
            {
                throw new FormatException("The import CSV data must contain a header row.");
            }

            // Read the field names once; an unnamed header cell is named by its position so every cell is addressable.
            var header = records[0]
                .Select((name, index) => string.IsNullOrWhiteSpace(name) ? $"Field{index + 1}" : name)
                .ToArray();

            // Map each data record to a document, skipping the cells the record does not carry.
            var documents = new List<BsonDocument>();

            foreach (var record in records.Skip(1))
            {
                var document = new BsonDocument();

                for (var i = 0; i < header.Length; i++)
                {
                    // Omit a missing or empty unquoted cell so the document carries only the fields the record has.
                    var hasValue = i < record.Count && record[i] is not null;

                    if (hasValue)
                    {
                        document[header[i]] = record[i];
                    }
                }

                documents.Add(document);
            }

            return documents;
        }

        /// <summary>
        /// Converts an argument value into a BSON value for a document field or a parameter.
        /// </summary>
        /// <remarks>
        /// <c>null</c> becomes BSON null; strings, booleans, numbers, dates, and <see cref="Guid"/> keep their type;
        /// a dictionary becomes a subdocument and any other sequence becomes an array, both converted recursively. Any
        /// other value becomes its invariant text, so a value always has a BSON form.
        /// </remarks>
        /// <param name="value">The value to convert.</param>
        /// <returns>The BSON value.</returns>
        public static BsonValue ConvertToBsonValue(object value)
        {
            // Map a missing value to BSON null so absent values stay distinguishable from empty strings.
            if (value is null)
            {
                return BsonNull.Value;
            }

            // Pass a BSON value through unchanged so an already-converted field is never re-encoded.
            if (value is BsonValue bson)
            {
                return bson;
            }

            // Keep text as text before the sequence check, because a string is itself a character sequence.
            if (value is string text)
            {
                return new BsonString(text);
            }

            // Convert a keyed map into a subdocument so nested content stays addressable by dot path.
            if (value is IDictionary<string, object> map)
            {
                return new BsonDocument(map.ToDictionary(i => i.Key, i => ConvertToBsonValue(i.Value)));
            }

            // Convert any other sequence into an array so list content stays queryable element by element.
            if (value is IEnumerable sequence)
            {
                return new BsonArray(sequence.Cast<object>().Select(ConvertToBsonValue));
            }

            // Keep the primitive types the driver maps to a native BSON type.
            var isSupported = value is bool
                or byte
                or short
                or int
                or long
                or float
                or double
                or decimal
                or DateTime
                or Guid;

            // Fall back to the invariant text form for every other type, which always has a BSON form.
            return isSupported
                ? BsonValue.Create(value)
                : new BsonString(Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Converts the documents into their distinct top-level field names, in the order they were first seen.
        /// </summary>
        /// <param name="documents">The documents to read.</param>
        /// <returns>The field names; empty when no document carries a field.</returns>
        public static string[] ConvertToColumns(IEnumerable<BsonDocument> documents)
        {
            // Treat a missing collection as no fields so a caller never needs a null check.
            if (documents is null)
            {
                return [];
            }

            // Preserve the first-seen order so the columns of a projected query match the projection order.
            return [.. documents
                .SelectMany(i => i.Names)
                .Distinct(StringComparer.Ordinal)];
        }

        /// <summary>
        /// Converts a <c>database.collection</c> value into its parts.
        /// </summary>
        /// <remarks>
        /// The value is split on its first dot, so <c>shop.price.history</c> addresses the collection
        /// <c>price.history</c> of the database <c>shop</c>. A value without a dot names the collection alone, and the
        /// database then comes from the resolved connection.
        /// </remarks>
        /// <param name="collectionName">The collection name, optionally qualified by its database.</param>
        /// <returns>The database part, empty when the value carries none, and the collection part.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is empty or a part is not a legal MongoDB name.
        /// </exception>
        public static (string Database, string Collection) ConvertToNamespaceParts(string collectionName)
        {
            // Require a value so the addressed collection is never empty.
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                throw new ArgumentException("The collection name cannot be empty.", nameof(collectionName));
            }

            // Split on the first dot only, because a collection name may itself contain dots.
            var value = collectionName.Trim();
            var separatorIndex = value.IndexOf('.');
            var hasDatabase = separatorIndex > 0;

            var database = hasDatabase ? value[..separatorIndex] : string.Empty;
            var collection = hasDatabase ? value[(separatorIndex + 1)..] : value;

            // Reject names the server cannot address so the failure names the offending part.
            if (hasDatabase)
            {
                AssertDatabaseName(database, parameterName: nameof(collectionName));
            }

            AssertCollectionName(collection, parameterName: nameof(collectionName));

            return (database, collection);
        }

        /// <summary>
        /// Parses a JSON object argument into a document.
        /// </summary>
        /// <remarks>
        /// Accepts plain JSON and both Extended JSON forms, so <c>{"_id":{"$oid":"..."}}</c> addresses an object
        /// identifier instead of a nested object. A missing or blank value yields an empty document, which matches
        /// every document when it is used as a filter.
        /// </remarks>
        /// <param name="json">The JSON object text.</param>
        /// <param name="argumentName">The argument name reported when the text is not a JSON object.</param>
        /// <returns>The parsed document.</returns>
        /// <exception cref="FormatException">Thrown when the text is not a single JSON object.</exception>
        public static BsonDocument ConvertToDocument(string json, string argumentName)
        {
            // Treat a missing value as an empty document so a parameterless operation needs no placeholder.
            if (string.IsNullOrWhiteSpace(json))
            {
                return [];
            }

            // Parse the text and report the argument by name, so a shape error names the step input that carries it.
            try
            {
                return BsonDocument.Parse(json);
            }
            catch (Exception exception) when (exception is FormatException or BsonSerializationException)
            {
                var message = $"The '{argumentName}' argument must be a JSON object: {exception.Message}";
                throw new FormatException(message, exception);
            }
        }

        /// <summary>
        /// Parses a JSON argument into documents.
        /// </summary>
        /// <remarks>
        /// Accepts an array of objects or a single object, so one document needs no array wrapper. Both Extended JSON
        /// forms are accepted, so declared BSON types survive the parse.
        /// </remarks>
        /// <param name="json">The JSON array or object text.</param>
        /// <param name="argumentName">The argument name reported when the text has the wrong shape.</param>
        /// <returns>The parsed documents.</returns>
        /// <exception cref="FormatException">
        /// Thrown when the text is neither an array of objects nor a single object.
        /// </exception>
        public static List<BsonDocument> ConvertToDocuments(string json, string argumentName)
        {
            // Reject an empty value so an insert never runs without documents.
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new FormatException($"The '{argumentName}' argument must carry at least one document.");
            }

            // Read the text as a single document first, which is the common single-document case.
            var value = ConvertToValue(json, argumentName);

            if (value is BsonDocument document)
            {
                return [document];
            }

            // Require an array of documents for every other shape so each item maps to one document.
            if (value is not BsonArray array)
            {
                throw new FormatException($"The '{argumentName}' argument must be a JSON array or a JSON object.");
            }

            var documents = new List<BsonDocument>();

            foreach (var item in array)
            {
                if (item is not BsonDocument itemDocument)
                {
                    var message = $"Every item of the '{argumentName}' argument must be a JSON object.";
                    throw new FormatException(message);
                }

                documents.Add(itemDocument);
            }

            return documents;
        }

        /// <summary>
        /// Converts documents into minified relaxed Extended JSON.
        /// </summary>
        /// <param name="documents">The documents to serialize.</param>
        /// <returns>The JSON array text; <c>[]</c> when no document is supplied.</returns>
        public static string ConvertToJson(IEnumerable<BsonDocument> documents)
        {
            // Serialize through a BSON array so one writer setting shapes every output of the suite.
            return ConvertToJson(value: new BsonArray(documents ?? []));
        }

        /// <summary>
        /// Converts text values, such as field names, into minified JSON.
        /// </summary>
        /// <param name="values">The values to serialize.</param>
        /// <returns>The JSON array text; <c>[]</c> when no value is supplied.</returns>
        public static string ConvertToJson(IEnumerable<string> values)
        {
            // Serialize through a BSON array so the output matches the document serialization of the suite.
            return ConvertToJson(value: new BsonArray((values ?? []).Select(i => new BsonString(i))));
        }

        /// <summary>
        /// Converts a BSON value into minified relaxed Extended JSON.
        /// </summary>
        /// <remarks>
        /// A value the JSON grammar cannot express at the top level, such as an object identifier, is wrapped by its
        /// Extended JSON type form, so <c>{"$oid":"..."}</c> keeps the value addressable by a later step.
        /// </remarks>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The JSON text; <c>null</c> for a missing value.</returns>
        public static string ConvertToJson(BsonValue value)
        {
            // Map a missing value to JSON null so an absent result reads as a value, not as empty text.
            if (value is null or BsonNull)
            {
                return "null";
            }

            // Wrap the value in a document so every BSON type serializes, including the ones JSON has no literal for,
            // then return only the wrapped value by reading it back from the written document.
            var wrapper = new BsonDocument(name: "value", value);
            var json = wrapper.ToJson(JsonSettings);

            // Strip the wrapper, whose exact text is fixed by the minified writer settings used above.
            const string prefix = "{ \"value\" : ";
            const string suffix = " }";

            var isWrapped = json.StartsWith(prefix, StringComparison.Ordinal)
                && json.EndsWith(suffix, StringComparison.Ordinal);

            return isWrapped
                ? json[prefix.Length..^suffix.Length]
                : json;
        }

        /// <summary>
        /// Converts a BSON value into the text stored for a scalar session parameter.
        /// </summary>
        /// <remarks>
        /// Strings are returned unchanged and a missing or BSON null value becomes an empty string; every other value
        /// uses its relaxed Extended JSON form, so numbers, booleans, dates, and object identifiers read the same way
        /// they appear inside exported documents.
        /// </remarks>
        /// <param name="value">The value to convert.</param>
        /// <returns>The text form of the value.</returns>
        public static string ConvertToText(BsonValue value)
        {
            // Map a missing value to empty text so an absent scalar never reads as the word "null".
            if (value is null or BsonNull)
            {
                return string.Empty;
            }

            // Keep strings raw so a scalar text value is not wrapped in JSON quotes.
            if (value is BsonString text)
            {
                return text.AsString;
            }

            // Serialize every other value so its text matches the exported document representation.
            return ConvertToJson(value);
        }

        /// <summary>
        /// Parses a JSON argument into a BSON value.
        /// </summary>
        /// <remarks>
        /// Accepts any JSON value, including an array and a scalar, so a pipeline and a document argument share one
        /// parser. Both Extended JSON forms are accepted.
        /// </remarks>
        /// <param name="json">The JSON text.</param>
        /// <param name="argumentName">The argument name reported when the text is not valid JSON.</param>
        /// <returns>The parsed value.</returns>
        /// <exception cref="FormatException">Thrown when the text is not valid JSON.</exception>
        public static BsonValue ConvertToValue(string json, string argumentName)
        {
            // Wrap the value so the parser accepts a top-level array or scalar, which BSON documents cannot hold.
            var wrapped = $"{{ \"value\": {json} }}";

            try
            {
                return BsonDocument.Parse(wrapped)["value"];
            }
            catch (Exception exception) when (exception is FormatException or BsonSerializationException)
            {
                var message = $"The '{argumentName}' argument is not valid JSON: {exception.Message}";
                throw new FormatException(message, exception);
            }
        }

        /// <summary>
        /// Gets the collection the step operates on.
        /// </summary>
        /// <remarks>
        /// The database of the <paramref name="collectionName"/> value wins over
        /// <see cref="MongoDbConnectionModel.Database"/>, so one stored credentials record can address several
        /// databases.
        /// </remarks>
        /// <param name="client">The open client.</param>
        /// <param name="connectionModel">The resolved connection settings, which carry the default database.</param>
        /// <param name="collectionName">The collection name, optionally qualified by its database.</param>
        /// <returns>The collection, read and written as <see cref="BsonDocument"/> values.</returns>
        /// <exception cref="ArgumentException">Thrown when the collection name is empty or not legal.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no database is resolved.</exception>
        public static IMongoCollection<BsonDocument> GetCollection(
            IMongoClient client,
            MongoDbConnectionModel connectionModel,
            string collectionName)
        {
            // Split the name so a qualified value selects its own database.
            var (database, collection) = ConvertToNamespaceParts(collectionName);

            // Prefer the database the name carries, then the one the connection resolved.
            var databaseName = string.IsNullOrWhiteSpace(database)
                ? connectionModel?.Database
                : database;

            // Address the database first so a missing database fails before the collection is resolved.
            return GetDatabase(client, databaseName)
                .GetCollection<BsonDocument>(name: collection);
        }

        /// <summary>
        /// Gets the database the step operates on.
        /// </summary>
        /// <param name="client">The open client.</param>
        /// <param name="databaseName">The database name.</param>
        /// <returns>The database.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the name is empty.</exception>
        /// <exception cref="ArgumentException">Thrown when the name is not a legal MongoDB database name.</exception>
        public static IMongoDatabase GetDatabase(IMongoClient client, string databaseName)
        {
            // Require the client before addressing anything on it.
            ArgumentNullException.ThrowIfNull(argument: client);

            // Require a database so the failure names the missing input instead of a driver namespace error.
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                var message = "No MongoDB database was resolved. Set 'Database', qualify the collection as " +
                    "'database.collection', or store the database in the credentials record.";
                throw new InvalidOperationException(message);
            }

            // Reject a name the server cannot address so the failure names the offending input.
            AssertDatabaseName(databaseName.Trim(), parameterName: nameof(databaseName));

            return client.GetDatabase(name: databaseName.Trim());
        }

        /// <summary>
        /// Creates a result set from the documents, including their field names.
        /// </summary>
        /// <param name="documents">The documents read from the server.</param>
        /// <returns>The result set.</returns>
        public static MongoDbResultSetModel NewResultSet(IEnumerable<BsonDocument> documents)
        {
            // Materialize the documents once so the field names and the documents describe one snapshot.
            var items = documents?.ToList() ?? [];

            return new MongoDbResultSetModel
            {
                Columns = ConvertToColumns(documents: items),
                Documents = items
            };
        }

        /// <summary>
        /// Opens a new MongoDB client for the resolved connection settings.
        /// </summary>
        /// <remarks>
        /// The caller owns and disposes the returned client. The client is created without contacting the server, so a
        /// configuration error surfaces here and an unreachable server surfaces on the first operation, bounded by the
        /// server-selection timeout the settings carry.
        /// </remarks>
        /// <param name="connectionModel">The resolved client settings.</param>
        /// <returns>The client.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="connectionModel"/> is null.</exception>
        public static MongoClient OpenClient(MongoDbConnectionModel connectionModel)
        {
            // Require the resolved settings before allocating a client.
            ArgumentNullException.ThrowIfNull(argument: connectionModel);

            // Create the client from the resolved settings so every plugin opens its deployment the same way.
            return new MongoClient(settings: connectionModel.ClientSettings);
        }

        // Asserts that a collection name is addressable by MongoDB, reporting the failure against the owning
        // parameter so the diagnostic names the argument the caller passed.
        private static void AssertCollectionName(string collection, string parameterName)
        {
            // Reject an empty part so a name such as "shop." never addresses an unnamed collection.
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new ArgumentException("A collection name part cannot be empty.", parameterName);
            }

            // Reject the dollar sign, which the server reserves for its own namespaces.
            if (collection.Contains('$'))
            {
                var message = $"The collection name '{collection}' cannot contain '$'.";
                throw new ArgumentException(message, parameterName);
            }

            // Reject the system prefix, which addresses the internal collections of the server.
            if (collection.StartsWith("system.", StringComparison.OrdinalIgnoreCase))
            {
                var message = $"The collection name '{collection}' addresses a system namespace.";
                throw new ArgumentException(message, parameterName);
            }

            // Reject a name the server cannot store, measured in the bytes the limit counts.
            if (Encoding.UTF8.GetByteCount(collection) >= MaximumNamespaceLength)
            {
                var message = $"The collection name '{collection}' exceeds {MaximumNamespaceLength} bytes.";
                throw new ArgumentException(message, parameterName);
            }
        }

        // Asserts that a database name is addressable by MongoDB, reporting the failure against the owning parameter
        // so the diagnostic names the argument the caller passed.
        private static void AssertDatabaseName(string database, string parameterName)
        {
            // Reject an empty part so a name such as ".orders" never addresses an unnamed database.
            if (string.IsNullOrWhiteSpace(database))
            {
                throw new ArgumentException("A database name cannot be empty.", parameterName);
            }

            // Reject the characters the server rejects, including the namespace separator itself.
            var invalidCharacter = database.FirstOrDefault(InvalidDatabaseNameCharacters.Contains);

            if (invalidCharacter != default)
            {
                var message = $"The database name '{database}' cannot contain '{invalidCharacter}'.";
                throw new ArgumentException(message, parameterName);
            }

            // Reject a name the server cannot store, measured in the bytes the limit counts.
            if (Encoding.UTF8.GetByteCount(database) > MaximumDatabaseNameLength)
            {
                var message = $"The database name '{database}' exceeds {MaximumDatabaseNameLength} bytes.";
                throw new ArgumentException(message, parameterName);
            }
        }

        // Tokenizes RFC 4180 CSV text into records. Quoted fields keep commas, line breaks, and doubled quotes; an
        // empty unquoted field becomes null so it is omitted from its document. Owns no state beyond the records.
        private static List<List<string>> ReadCsvRecords(string csv)
        {
            // Track the records, the open record and field, and the quoting state of the single pass.
            var records = new List<List<string>>();
            var record = new List<string>();
            var field = new StringBuilder();
            var isQuoted = false;
            var isFieldQuoted = false;

            // Walk the characters once, switching between quoted and unquoted states.
            for (var i = 0; i < csv.Length; i++)
            {
                var character = csv[i];

                // Inside quotes, a doubled quote is a literal quote and a single quote closes the field.
                if (isQuoted)
                {
                    var isEscapedQuote = character == '"' && i + 1 < csv.Length && csv[i + 1] == '"';

                    if (isEscapedQuote)
                    {
                        field.Append('"');
                        i++;
                    }
                    else if (character == '"')
                    {
                        isQuoted = false;
                    }
                    else
                    {
                        field.Append(character);
                    }

                    continue;
                }

                // Outside quotes, separators close fields and line breaks close records.
                switch (character)
                {
                    case '"':
                        isQuoted = true;
                        isFieldQuoted = true;
                        break;
                    case ',':
                        CloseField(record, field, ref isFieldQuoted);
                        break;
                    case '\r':
                        break;
                    case '\n':
                        CloseField(record, field, ref isFieldQuoted);
                        records.Add(record);
                        record = [];
                        break;
                    default:
                        field.Append(character);
                        break;
                }
            }

            // Close the trailing record unless the text ended with a line break.
            var hasTrailingRecord = field.Length > 0 || isFieldQuoted || record.Count > 0;

            if (hasTrailingRecord)
            {
                CloseField(record, field, ref isFieldQuoted);
                records.Add(record);
            }

            return records;

            // Closes the current field into the open record, mapping an empty unquoted field to null so it is omitted
            // from its document. Mutates the caller-owned record, clears the field buffer, and resets the quoting
            // state.
            static void CloseField(List<string> record, StringBuilder field, ref bool isFieldQuoted)
            {
                // Distinguish an empty unquoted field (null) from an explicitly quoted empty string.
                var isNullField = field.Length == 0 && !isFieldQuoted;

                record.Add(isNullField ? null : field.ToString());

                // Reset the buffer and the quoting state for the next field.
                field.Clear();
                isFieldQuoted = false;
            }
        }
        #endregion
    }
}
