using G4.Plugins.SqlServer.Clients;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Data;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("SqlServerClient")]
    [TestCategory("UnitTest")]
    public class SqlServerClientTests
    {
        [TestMethod(DisplayName = "Verify that ConvertCsvToDataTable keeps quoted commas, doubled quotes, and line " +
            "breaks and maps empty unquoted fields to DBNull.")]
        public void ConvertCsvToDataTableQuotedFieldsTest()
        {
            // Arrange: build RFC 4180 text with CRLF records, a quoted comma, doubled quotes, an embedded line break,
            // an empty unquoted field, and an empty quoted field.
            var csv = "Id,Name,Note\r\n" +
                "1,\"Doe, Jane\",\"She said \"\"hi\"\"\"\r\n" +
                "2,,\"line1\nline2\"\r\n" +
                "3,\"\",plain\r\n";

            // Act: tokenize the text into a string-typed table.
            var table = SqlServerClient.ConvertCsvToDataTable(csv);

            // Assert: the header becomes three string columns and every data record becomes a row.
            Assert.HasCount(expected: 3, collection: table.Columns);
            Assert.AreEqual(expected: typeof(string), actual: table.Columns["Name"].DataType);
            Assert.HasCount(expected: 3, collection: table.Rows);

            // Assert: quoted fields keep their separators, quotes, and line breaks verbatim.
            Assert.AreEqual(expected: "Doe, Jane", actual: table.Rows[0]["Name"]);
            Assert.AreEqual(expected: "She said \"hi\"", actual: table.Rows[0]["Note"]);
            Assert.AreEqual(expected: "line1\nline2", actual: table.Rows[1]["Note"]);

            // Assert: only an empty unquoted field is a database null; an empty quoted field stays empty text.
            Assert.AreEqual(expected: DBNull.Value, actual: table.Rows[1]["Name"]);
            Assert.AreEqual(expected: string.Empty, actual: table.Rows[2]["Name"]);
            Assert.AreEqual(expected: "plain", actual: table.Rows[2]["Note"]);
        }

        [TestMethod(DisplayName = "Verify that ConvertCsvToDataTable rejects text without a header row.")]
        #region *** Data Set ***
        [DataRow("")]
        [DataRow(null)]
        #endregion
        public void ConvertCsvToDataTableNoHeaderTest(string csv)
        {
            // Act and Assert: empty input has no header to name the columns.
            Assert.ThrowsExactly<FormatException>(() => SqlServerClient.ConvertCsvToDataTable(csv));
        }

        [TestMethod(DisplayName = "Verify that ConvertToBatches keeps lines that are not whole GO separator lines " +
            "inside the batch text.")]
        #region *** Data Set ***
        [DataRow("SELECT N'GO' AS Word;\nSELECT 1;", "SELECT N'GO' AS Word;")]
        [DataRow("GOTO Done;\nDone: SELECT 1;", "GOTO Done;")]
        [DataRow("SELECT 1;\nGO 0\nSELECT 2;", "GO 0")]
        [DataRow("SELECT 1;\nGO 1234567890\nSELECT 2;", "GO 1234567890")]
        [DataRow("SELECT 1;\nGO -1\nSELECT 2;", "GO -1")]
        [DataRow("SELECT 1; GO\nSELECT 2;", "SELECT 1; GO")]
        #endregion
        public void ConvertToBatchesNotSeparatorTest(string script, string expectedLine)
        {
            // Act: split a script whose GO-like line is not a valid separator.
            var batches = SqlServerClient.ConvertToBatches(script);

            // Assert: no line is a separator, so the script stays one batch with the line intact; a zero or
            // out-of-range count is not a separator and travels to the server as text.
            Assert.HasCount(expected: 1, collection: batches);
            Assert.Contains(substring: expectedLine, value: batches[0]);
        }

        [TestMethod(DisplayName = "Verify that ConvertToBatches splits a script on GO separator lines, repeats GO n " +
            "batches, allows a trailing line comment, and drops empty batches.")]
        #region *** Data Set ***
        [DataRow("SELECT 1\nGO\nSELECT 2", "SELECT 1|SELECT 2")]
        [DataRow("SELECT 1\r\ngo\r\nSELECT 2\r\n", "SELECT 1|SELECT 2")]
        [DataRow("SELECT 1\n  Go  \nSELECT 2\nGO\n", "SELECT 1|SELECT 2")]
        [DataRow("SELECT 1\nGO 3\n", "SELECT 1|SELECT 1|SELECT 1")]
        [DataRow("SELECT 1\nGO 2\nSELECT 2", "SELECT 1|SELECT 1|SELECT 2")]
        [DataRow("SELECT 1\nGO 3 -- seed\n", "SELECT 1|SELECT 1|SELECT 1")]
        [DataRow("SELECT 1\nGO -- end of batch\nSELECT 2", "SELECT 1|SELECT 2")]
        [DataRow("SELECT 1\nGO--tight\nSELECT 2", "SELECT 1|SELECT 2")]
        [DataRow("\nGO\n\nGO\nSELECT 1\nGO\n   \n", "SELECT 1")]
        [DataRow("SELECT 1", "SELECT 1")]
        [DataRow("", "")]
        [DataRow(null, "")]
        #endregion
        public void ConvertToBatchesTest(string script, string expected)
        {
            // Act: split the script into its batches.
            var batches = SqlServerClient.ConvertToBatches(script);

            // Assert: the batches appear in execution order, trimmed, once per repetition.
            Assert.AreEqual(expected, actual: string.Join('|', batches));
        }

        [TestMethod(DisplayName = "Verify that ConvertToDataTable maps a JSON array to the union of the object keys " +
            "with text cells and DBNull for missing and null values.")]
        public void ConvertToDataTableUnionTest()
        {
            // Arrange: use rows with different shapes, a JSON null, and non-string values.
            var json = "[{\"Id\":1,\"Name\":\"Ada\"},{\"Id\":2,\"Active\":true,\"Tags\":[\"a\"]},{\"Name\":null}]";

            // Act: convert the array into a string-typed table.
            var table = SqlServerClient.ConvertToDataTable(json);

            // Assert: the columns are the union of the keys in first-seen order.
            Assert.HasCount(expected: 4, collection: table.Columns);
            Assert.AreEqual(expected: "Id", actual: table.Columns[0].ColumnName);
            Assert.AreEqual(expected: "Name", actual: table.Columns[1].ColumnName);
            Assert.AreEqual(expected: "Active", actual: table.Columns[2].ColumnName);
            Assert.AreEqual(expected: "Tags", actual: table.Columns[3].ColumnName);

            // Assert: strings stay raw and every other value keeps its minified JSON text.
            Assert.AreEqual(expected: "Ada", actual: table.Rows[0]["Name"]);
            Assert.AreEqual(expected: "2", actual: table.Rows[1]["Id"]);
            Assert.AreEqual(expected: "true", actual: table.Rows[1]["Active"]);
            Assert.AreEqual(expected: "[\"a\"]", actual: table.Rows[1]["Tags"]);

            // Assert: missing keys and JSON null both become database nulls.
            Assert.AreEqual(expected: DBNull.Value, actual: table.Rows[0]["Active"]);
            Assert.AreEqual(expected: DBNull.Value, actual: table.Rows[2]["Id"]);
            Assert.AreEqual(expected: DBNull.Value, actual: table.Rows[2]["Name"]);
        }

        [TestMethod(DisplayName = "Verify that ConvertToDataTable rejects JSON that is not an array of objects.")]
        #region *** Data Set ***
        [DataRow("[{\"Id\":1},2]")]
        [DataRow("[\"Ada\"]")]
        [DataRow("{\"Id\":1}")]
        #endregion
        public void ConvertToDataTableInvalidShapeTest(string json)
        {
            // Act and Assert: the shape error is reported before any row is copied.
            Assert.ThrowsExactly<FormatException>(() => SqlServerClient.ConvertToDataTable(json));
        }

        [TestMethod(DisplayName = "Verify that ConvertToQuotedName bracket-quotes each part and escapes closing " +
            "brackets.")]
        #region *** Data Set ***
        [DataRow("dbo", "Orders", "[dbo].[Orders]")]
        [DataRow("sales", "a.b", "[sales].[a.b]")]
        [DataRow("my]schema", "c]d", "[my]]schema].[c]]d]")]
        #endregion
        public void ConvertToQuotedNameTest(string schema, string table, string expected)
        {
            // Act: quote the schema and table pair.
            var actual = SqlServerClient.ConvertToQuotedName(schema, table);

            // Assert: dots stay inside their part and closing brackets are doubled like QUOTENAME.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertToTableParts splits plain, schema-qualified, and bracketed " +
            "names and applies the default schema.")]
        #region *** Data Set ***
        [DataRow("Orders", "dbo", "Orders")]
        [DataRow("sales.Orders", "sales", "Orders")]
        [DataRow("[a.b].[c]]d]", "a.b", "c]d")]
        [DataRow("  [dbo].[Orders]  ", "dbo", "Orders")]
        #endregion
        public void ConvertToTablePartsTest(string tableName, string expectedSchema, string expectedTable)
        {
            // Act: split the table name into its parts.
            var (schema, table) = SqlServerClient.ConvertToTableParts(tableName);

            // Assert: brackets are removed, escaped brackets are restored, and a missing schema uses dbo.
            Assert.AreEqual(expected: expectedSchema, actual: schema);
            Assert.AreEqual(expected: expectedTable, actual: table);
        }

        [TestMethod(DisplayName = "Verify that ConvertToTableParts rejects empty names, empty parts, and parts " +
            "longer than the identifier limit.")]
        #region *** Data Set ***
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        [DataRow("dbo.")]
        [DataRow(".Orders")]
        #endregion
        public void ConvertToTablePartsInvalidTest(string tableName)
        {
            // Act and Assert: the failure names the table name parameter.
            var exception = Assert.ThrowsExactly<ArgumentException>(
                () => SqlServerClient.ConvertToTableParts(tableName));
            Assert.AreEqual(expected: "tableName", actual: exception.ParamName);
        }

        [TestMethod(DisplayName = "Verify that ConvertToTableParts rejects a part longer than 128 characters and " +
            "accepts a part of exactly 128 characters.")]
        public void ConvertToTablePartsIdentifierLengthTest()
        {
            // Arrange: build names at and beyond the SQL Server identifier limit.
            var longestTable = new string('a', SqlServerClient.MaximumIdentifierLength);
            var tooLongTable = new string('a', SqlServerClient.MaximumIdentifierLength + 1);

            // Act: split the name that sits exactly at the limit.
            var (_, table) = SqlServerClient.ConvertToTableParts($"dbo.{longestTable}");

            // Assert: the limit itself is accepted and one more character is rejected.
            Assert.AreEqual(expected: longestTable, actual: table);
            Assert.ThrowsExactly<ArgumentException>(() => SqlServerClient.ConvertToTableParts($"dbo.{tooLongTable}"));
        }

        [TestMethod(DisplayName = "Verify that ConvertToText returns strings raw, null as empty text, and other " +
            "primitive values as their JSON text.")]
        #region *** Data Set ***
        [DataRow(null, "")]
        [DataRow("Ada", "Ada")]
        [DataRow("\"quoted\"", "\"quoted\"")]
        [DataRow(42, "42")]
        [DataRow(true, "true")]
        #endregion
        public void ConvertToTextPrimitiveTest(object value, string expected)
        {
            // Act: convert the value into its session text.
            var actual = SqlServerClient.ConvertToText(value);

            // Assert: the text matches the scalar output contract.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertToText maps DBNull, decimals, dates, unique identifiers, and " +
            "binary values to their documented text forms.")]
        public void ConvertToTextProviderTypesTest()
        {
            // Arrange: use the provider values that attributes cannot express.
            var date = new DateTime(2024, 1, 1);
            var identifier = Guid.Parse("6F9619FF-8B86-D011-B42D-00C04FC964FF");

            // Act and Assert: database nulls become empty text.
            Assert.AreEqual(expected: string.Empty, actual: SqlServerClient.ConvertToText(DBNull.Value));

            // Act and Assert: decimals keep their scale and dates use ISO 8601 without JSON quotes.
            Assert.AreEqual(expected: "12.50", actual: SqlServerClient.ConvertToText(12.50m));
            Assert.AreEqual(expected: "2024-01-01T00:00:00", actual: SqlServerClient.ConvertToText(date));

            // Act and Assert: unique identifiers use their lowercase text and binary values use Base64.
            Assert.AreEqual(
                expected: "6f9619ff-8b86-d011-b42d-00c04fc964ff",
                actual: SqlServerClient.ConvertToText(identifier));
            Assert.AreEqual(expected: "AQI=", actual: SqlServerClient.ConvertToText(new byte[] { 1, 2 }));
        }
    }
}
