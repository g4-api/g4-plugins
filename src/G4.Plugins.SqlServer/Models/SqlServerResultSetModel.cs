using System.Collections.Generic;

namespace G4.Plugins.SqlServer.Models
{
    /// <summary>
    /// Represents one result set read from SQL Server, ready for minified JSON serialization.
    /// </summary>
    /// <remarks>
    /// The columns come from the reader schema, so a result set without rows still reports its columns.
    /// </remarks>
    internal sealed class SqlServerResultSetModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets the unique column names of the result set, in server order.
        /// </summary>
        /// <remarks>
        /// Unnamed columns are named <c>Column{ordinal}</c> and repeated names receive a numeric suffix.
        /// </remarks>
        public string[] Columns { get; set; } = [];

        /// <summary>
        /// Gets or sets the rows of the result set, each an ordered map of column name to JSON-ready value.
        /// </summary>
        public List<Dictionary<string, object>> Rows { get; set; } = [];
        #endregion
    }
}
