using G4.Plugins.SqlServer.Models;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace G4.Plugins.SqlServer.Clients
{
    /// <summary>
    /// Provides the SQL Server operations shared by every SQL Server plugin: connection setup, command execution
    /// helpers, result-set to JSON conversion, batch splitting, and bulk-copy table preparation.
    /// </summary>
    /// <remarks>
    /// Every member is stateless. Callers own the connections, commands, and transactions they create and dispose
    /// them; the helpers never cache a connection, so one plugin step never leaks state into another.
    /// </remarks>
    internal static partial class SqlServerClient
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the command timeout, in seconds, used when the step does not set <c>CommandTimeout</c>.
        /// </summary>
        public const int DefaultCommandTimeoutSeconds = 30;

        /// <summary>
        /// Specifies the maximum identifier length SQL Server accepts for a schema, table, or column name.
        /// </summary>
        public const int MaximumIdentifierLength = 128;

        /// <summary>
        /// Specifies the schema used when a table name carries no schema part.
        /// </summary>
        public const string DefaultSchema = "dbo";

        // Serializes result sets as minified JSON with relaxed escaping, so stored values stay compact and readable
        // (non-ASCII text is not escaped) when a later step decodes them from session parameters.
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Converts RFC 4180 CSV text with a header row into a string-typed <see cref="DataTable"/> for bulk copy.
        /// </summary>
        /// <remarks>
        /// Quoted fields can contain commas, line breaks, and doubled quotes. An empty unquoted field becomes
        /// <c>DBNull</c>; SQL Server converts the text values to the destination column types during the bulk copy.
        /// </remarks>
        /// <param name="csv">The CSV text whose first record holds the column names.</param>
        /// <returns>The populated table.</returns>
        /// <exception cref="FormatException">Thrown when the CSV has no header row.</exception>
        public static DataTable ConvertCsvToDataTable(string csv)
        {
            // Parse every record so the header and the data rows share one tokenizer.
            var records = ReadCsvRecords(csv: csv ?? string.Empty);

            if (records.Count == 0)
            {
                throw new FormatException("The import CSV data must contain a header row.");
            }

            // Map each data record to a dictionary keyed by the header names; short records leave missing cells null.
            var header = records[0].Select(i => i ?? string.Empty).ToArray();

            var rows = records.Skip(1).Select(record =>
            {
                var row = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                for (var i = 0; i < header.Length; i++)
                {
                    row[header[i]] = i < record.Count ? record[i] : null;
                }

                return (IDictionary<string, string>)row;
            });

            // Create the string-typed table so SQL Server owns the conversion to the destination types.
            return NewDataTable(columns: header, rows);
        }

        /// <summary>
        /// Converts a SQL script into its batches by splitting on <c>GO</c> separator lines.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A separator is a line that holds only <c>GO</c> (any case), optionally followed by a positive repeat count
        /// and a trailing line comment, such as <c>GO 3 -- seed</c>. A repeated batch appears once per repetition.
        /// Empty batches are dropped. A line such as <c>GO 0</c> is not a separator and stays in the batch, so the
        /// server reports it.
        /// </para>
        /// <para>
        /// The splitter is line based: a <c>GO</c> line inside a block comment or a multi-line string literal is
        /// treated as a separator, which matches the behavior of <c>sqlcmd</c>.
        /// </para>
        /// </remarks>
        /// <param name="script">The script text.</param>
        /// <returns>The batches in execution order.</returns>
        public static List<string> ConvertToBatches(string script)
        {
            // Normalize line endings so the separator pattern matches scripts authored on any platform.
            var lines = (script ?? string.Empty)
                .Replace("\r\n", "\n")
                .Split('\n');

            var batches = new List<string>();
            var current = new StringBuilder();

            // Walk the lines, closing the current batch at every separator line.
            foreach (var line in lines)
            {
                var match = GetBatchSeparatorPattern().Match(line);

                if (!match.Success)
                {
                    current.AppendLine(line);
                    continue;
                }

                // Repeat the closed batch as many times as the separator count requests (at least once).
                var countGroup = match.Groups["count"];
                var count = countGroup.Success
                    ? int.Parse(countGroup.Value, CultureInfo.InvariantCulture)
                    : 1;

                AddBatch(batches, batch: current.ToString(), count);
                current.Clear();
            }

            // Close the trailing batch, which has no separator after it.
            AddBatch(batches, batch: current.ToString(), count: 1);

            return batches;

            // Adds a batch the requested number of times, skipping batches that hold only whitespace.
            // Mutates only the caller-owned batch list.
            static void AddBatch(List<string> batches, string batch, int count)
            {
                // Drop empty batches so blank separators never send an empty command.
                if (string.IsNullOrWhiteSpace(batch))
                {
                    return;
                }

                // Append one copy per repetition to preserve the GO n contract.
                for (var i = 0; i < count; i++)
                {
                    batches.Add(batch.Trim());
                }
            }
        }

        /// <summary>
        /// Converts a JSON array of flat objects into a string-typed <see cref="DataTable"/> for bulk copy.
        /// </summary>
        /// <remarks>
        /// The columns are the union of the object keys, in first-seen order. Values keep their JSON text form
        /// (strings unquoted, <c>null</c> as <c>DBNull</c>), and SQL Server converts them to the destination column
        /// types during the bulk copy.
        /// </remarks>
        /// <param name="json">The JSON array of row objects.</param>
        /// <returns>The populated table.</returns>
        /// <exception cref="FormatException">Thrown when the JSON is not an array of objects.</exception>
        public static DataTable ConvertToDataTable(string json)
        {
            // Parse the payload once so shape errors are reported before any rows are copied.
            var node = JsonNode.Parse(json);

            if (node is not JsonArray array)
            {
                throw new FormatException("The import data must be a JSON array of row objects.");
            }

            // Require an object per item so every row maps to named columns.
            var rows = new List<JsonObject>();

            foreach (var item in array)
            {
                if (item is not JsonObject row)
                {
                    throw new FormatException("Every item of the import data array must be a JSON object.");
                }

                rows.Add(row);
            }

            // Collect the union of keys so rows with different shapes still map to one table.
            var columns = rows
                .SelectMany(i => i.Select(j => j.Key))
                .Distinct(StringComparer.OrdinalIgnoreCase);

            // Map each JSON object into cell texts, keeping text values raw and other values as JSON text.
            var cells = rows.Select(row => (IDictionary<string, string>)row.ToDictionary(
                keySelector: i => i.Key,
                elementSelector: i => ConvertToCellText(node: i.Value),
                comparer: StringComparer.OrdinalIgnoreCase));

            // Create the string-typed table so SQL Server owns the conversion to the destination types.
            return NewDataTable(columns, rows: cells);
        }

        /// <summary>
        /// Converts row collections into minified JSON.
        /// </summary>
        /// <param name="value">The value to serialize, typically one result set or a list of result sets.</param>
        /// <returns>The minified JSON text.</returns>
        public static string ConvertToJson(object value)
        {
            // Serialize with the shared minified options so every plugin emits the same JSON shape.
            return JsonSerializer.Serialize(value, JsonOptions);
        }

        /// <summary>
        /// Converts a database value into a value that serializes to stable, documented JSON.
        /// </summary>
        /// <remarks>
        /// <c>DBNull</c> becomes <c>null</c>; strings, booleans, numbers, dates, <see cref="Guid"/>, binary values, and
        /// <see cref="TimeSpan"/> keep their CLR type (dates serialize as ISO 8601, binary as Base64, decimal as an
        /// exact number). Any other provider type, such as spatial or hierarchy values, serializes as its text form.
        /// </remarks>
        /// <param name="value">The database value read from a reader, a scalar, or an output parameter.</param>
        /// <returns>The JSON-ready value.</returns>
        public static object ConvertToJsonValue(object value)
        {
            // Map database nulls to JSON null so absent values stay distinguishable from empty strings.
            if (value is null or DBNull)
            {
                return null;
            }

            // Keep the CLR types whose System.Text.Json form is stable and documented.
            var isSupported = value is string
                or bool
                or byte
                or short
                or int
                or long
                or float
                or double
                or decimal
                or DateTime
                or DateTimeOffset
                or TimeSpan
                or Guid
                or byte[];

            // Fall back to the invariant text form for provider-specific types.
            return isSupported
                ? value
                : Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a schema and table pair into a bracket-quoted, two-part name for <see cref="SqlBulkCopy"/>.
        /// </summary>
        /// <remarks>
        /// The quoting escapes closing brackets the same way the server-side <c>QUOTENAME</c> function does, so the
        /// name addresses exactly the identifier the caller supplied.
        /// </remarks>
        /// <param name="schema">The schema name.</param>
        /// <param name="table">The table name.</param>
        /// <returns>The quoted two-part name.</returns>
        public static string ConvertToQuotedName(string schema, string table)
        {
            // Quote each part independently so dots and brackets inside a part never change the name structure.
            return $"[{schema.Replace("]", "]]")}].[{table.Replace("]", "]]")}]";
        }

        /// <summary>
        /// Converts every remaining result set of a data reader into JSON-ready row collections.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Each row becomes an ordered dictionary of column name to JSON-ready value. Unnamed columns are named
        /// <c>Column{ordinal}</c> and repeated names receive a numeric suffix, so every row object has unique keys.
        /// </para>
        /// <para>
        /// The reader is consumed to its end; output parameters and return values become readable after the caller
        /// disposes it.
        /// </para>
        /// </remarks>
        /// <param name="reader">The open data reader positioned before its first result set.</param>
        /// <returns>
        /// One result set per server result, in server order; empty when the command returns no result set.
        /// </returns>
        public static List<SqlServerResultSetModel> ConvertToResultSets(SqlDataReader reader)
        {
            // Collect every result set so multi-statement queries and procedures keep all their outputs.
            var resultSets = new List<SqlServerResultSetModel>();

            do
            {
                // Skip the empty result a non-query statement leaves, which has no columns to report.
                if (reader.FieldCount == 0)
                {
                    continue;
                }

                // Resolve unique column names once per result set so every row uses the same keys.
                var columns = GetColumnNames(reader);
                var rows = new List<Dictionary<string, object>>();

                // Map each row to an ordered dictionary of JSON-ready values.
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>(capacity: columns.Length);

                    for (var i = 0; i < columns.Length; i++)
                    {
                        row[columns[i]] = ConvertToJsonValue(value: reader.GetValue(i));
                    }

                    rows.Add(row);
                }

                // Keep the columns with the rows so an empty result set still reports its schema.
                resultSets.Add(new SqlServerResultSetModel { Columns = columns, Rows = rows });
            }
            while (reader.NextResult());

            return resultSets;
        }

        /// <summary>
        /// Converts a table name of the form <c>table</c>, <c>schema.table</c>, or a bracketed equivalent into its
        /// schema and table parts.
        /// </summary>
        /// <remarks>
        /// A name without a schema part uses <see cref="DefaultSchema"/>. Square brackets around a part are removed and
        /// doubled closing brackets are restored, so <c>[dbo].[My]]Table]</c> yields <c>dbo</c> and <c>My]Table</c>.
        /// </remarks>
        /// <param name="tableName">The table name to split.</param>
        /// <returns>The schema and table parts.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the name is empty or a part exceeds the identifier limit.
        /// </exception>
        public static (string Schema, string Table) ConvertToTableParts(string tableName)
        {
            // Require a name so the destination table is never empty.
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("The table name cannot be empty.", nameof(tableName));
            }

            // Split on the dots outside brackets so bracketed names can contain dots.
            var parts = SplitIdentifier(identifier: tableName.Trim());

            // Treat the first part as the schema only when a second part exists; later parts stay in the table name.
            var schema = parts.Count > 1 ? parts[0] : DefaultSchema;
            var table = parts.Count > 1 ? string.Join('.', parts.Skip(1)) : parts[0];

            // Reject parts SQL Server cannot address so the failure names the offending identifier.
            AssertIdentifier(identifier: schema, parameterName: nameof(tableName));
            AssertIdentifier(identifier: table, parameterName: nameof(tableName));

            return (schema, table);
        }

        /// <summary>
        /// Converts a JSON-ready value into the text stored for a scalar or output session parameter.
        /// </summary>
        /// <remarks>
        /// Strings are returned unchanged and <c>null</c> becomes an empty string; every other value uses its minified
        /// JSON form, so numbers, booleans, and dates read the same way they appear in exported result sets.
        /// </remarks>
        /// <param name="value">The database value to convert.</param>
        /// <returns>The text form of the value.</returns>
        public static string ConvertToText(object value)
        {
            // Normalize the value first so database nulls and provider types follow the JSON conversion rules.
            var jsonValue = ConvertToJsonValue(value);

            // Map a null value to empty text so an absent scalar never reads as the word "null".
            if (jsonValue is null)
            {
                return string.Empty;
            }

            // Keep strings raw so a scalar text value is not wrapped in JSON quotes.
            if (jsonValue is string text)
            {
                return text;
            }

            // Serialize every other value so its text matches the exported JSON representation.
            return JsonSerializer.Serialize(jsonValue, JsonOptions).Trim('"');
        }

        /// <summary>
        /// Opens a new SQL Server connection for the resolved connection settings.
        /// </summary>
        /// <remarks>
        /// The caller owns and disposes the returned connection. When
        /// <see cref="SqlServerConnectionModel.AccessToken"/> is set, the token authenticates the connection, so the
        /// connection string must not also carry a password or an <c>Authentication</c> keyword; the provider rejects
        /// that combination when the connection opens.
        /// </remarks>
        /// <param name="connectionModel">The resolved connection string and optional access token.</param>
        /// <returns>The open connection.</returns>
        public static SqlConnection OpenConnection(SqlServerConnectionModel connectionModel)
        {
            // Require the resolved settings before allocating a connection.
            ArgumentNullException.ThrowIfNull(argument: connectionModel);

            // Create the connection and attach the token before opening, as the provider requires.
            var connection = new SqlConnection(connectionString: connectionModel.ConnectionString);

            if (!string.IsNullOrEmpty(connectionModel.AccessToken))
            {
                connection.AccessToken = connectionModel.AccessToken;
            }

            try
            {
                // Open the connection so the caller receives a ready-to-use session.
                connection.Open();

                return connection;
            }
            catch
            {
                // Release the connection when opening fails so a failed step never leaks a pooled handle.
                connection.Dispose();
                throw;
            }
        }

        // Asserts that an identifier part is addressable by SQL Server, reporting the failure against the owning
        // parameter so the diagnostic names the argument the caller passed.
        private static void AssertIdentifier(string identifier, string parameterName)
        {
            // Reject empty parts so a name such as "dbo." never addresses an unnamed object.
            if (string.IsNullOrWhiteSpace(identifier))
            {
                var message = "The table name contains an empty schema or table part.";
                throw new ArgumentException(message, parameterName);
            }

            // Reject parts longer than the server limit, which QUOTENAME cannot quote.
            if (identifier.Length > MaximumIdentifierLength)
            {
                var message = $"The identifier '{identifier}' exceeds {MaximumIdentifierLength} characters.";
                throw new ArgumentException(message, parameterName);
            }
        }

        // Converts a JSON node into the text stored in a bulk-copy cell: raw text for strings, null for JSON null,
        // and the minified JSON text for numbers, booleans, objects, and arrays.
        private static string ConvertToCellText(JsonNode node)
        {
            // Map JSON null to a database null.
            if (node is null)
            {
                return null;
            }

            // Keep string values raw so text columns receive the value without JSON quotes.
            if (node is JsonValue value && value.TryGetValue<string>(out var text))
            {
                return text;
            }

            // Keep every other value as its JSON text so SQL Server converts it to the destination type.
            return node.ToJsonString(JsonOptions);
        }

        // Matches a GO batch separator line with an optional positive repeat count (up to nine digits, so the count
        // always fits an int) and an optional trailing line comment, such as "GO 3 -- seed".
        [GeneratedRegex(@"^\s*GO(?:\s+(?<count>[1-9]\d{0,8}))?\s*(?:--.*)?$", RegexOptions.IgnoreCase)]
        private static partial Regex GetBatchSeparatorPattern();

        // Returns unique column names for the current result set: unnamed columns become Column{ordinal} and
        // repeated names receive a numeric suffix, so every serialized row object has unique keys.
        private static string[] GetColumnNames(SqlDataReader reader)
        {
            // Track used names case-insensitively, matching SQL Server column-name comparison.
            var names = new string[reader.FieldCount];
            var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (var i = 0; i < reader.FieldCount; i++)
            {
                // Name unnamed expression columns by their ordinal.
                var name = reader.GetName(i);
                var candidate = string.IsNullOrEmpty(name) ? $"Column{i + 1}" : name;
                var suffix = 2;

                // Suffix repeated names until the key is unique.
                while (!used.Add(candidate))
                {
                    candidate = $"{name}{suffix}";
                    suffix++;
                }

                names[i] = candidate;
            }

            return names;
        }

        // Creates a string-typed table with the given columns and rows. Every column is a string so SQL Server owns
        // the conversion to the destination types; missing cells become DBNull.
        private static DataTable NewDataTable(
            IEnumerable<string> columns,
            IEnumerable<IDictionary<string, string>> rows)
        {
            // Declare one string column per name, rejecting names SQL Server cannot address.
            var table = new DataTable();

            foreach (var column in columns)
            {
                AssertIdentifier(identifier: column, parameterName: nameof(columns));
                table.Columns.Add(columnName: column, type: typeof(string));
            }

            // Copy each row, mapping missing and null cells to DBNull.
            foreach (var row in rows)
            {
                var dataRow = table.NewRow();

                foreach (DataColumn column in table.Columns)
                {
                    var hasValue = row.TryGetValue(column.ColumnName, out var cell) && cell is not null;
                    dataRow[column] = hasValue ? cell : DBNull.Value;
                }

                table.Rows.Add(dataRow);
            }

            return table;
        }

        // Tokenizes RFC 4180 CSV text into records. Quoted fields keep commas, line breaks, and doubled quotes; an
        // empty unquoted field becomes null so it maps to DBNull. Owns no state beyond the returned records.
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

            // Closes the current field into the open record, mapping an empty unquoted field to null so it becomes
            // DBNull. Mutates the caller-owned record, clears the field buffer, and resets the field quoting state.
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

        // Splits a possibly bracket-quoted multi-part identifier on dots outside brackets and removes the quoting.
        // Compute-only: it owns no state beyond the returned parts.
        private static List<string> SplitIdentifier(string identifier)
        {
            // Track the parts, the open part, and the bracket state of the single pass.
            var parts = new List<string>();
            var current = new StringBuilder();
            var isBracketed = false;

            // Walk the characters, treating "]]" inside brackets as an escaped closing bracket.
            for (var i = 0; i < identifier.Length; i++)
            {
                var character = identifier[i];

                if (isBracketed)
                {
                    var isEscapedBracket = character == ']' && i + 1 < identifier.Length && identifier[i + 1] == ']';

                    if (isEscapedBracket)
                    {
                        current.Append(']');
                        i++;
                    }
                    else if (character == ']')
                    {
                        isBracketed = false;
                    }
                    else
                    {
                        current.Append(character);
                    }

                    continue;
                }

                // Outside brackets, an opening bracket starts a quoted part and a dot closes the current part.
                if (character == '[')
                {
                    isBracketed = true;
                }
                else if (character == '.')
                {
                    parts.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(character);
                }
            }

            // Close the final part.
            parts.Add(current.ToString());

            return parts;
        }
        #endregion
    }
}
