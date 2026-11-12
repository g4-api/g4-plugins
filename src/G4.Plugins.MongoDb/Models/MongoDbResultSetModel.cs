using MongoDB.Bson;

using System.Collections.Generic;

namespace G4.Plugins.MongoDb.Models
{
    /// <summary>
    /// Represents one set of documents read from MongoDB, ready for Extended JSON serialization.
    /// </summary>
    /// <remarks>
    /// MongoDB documents are schemaless, so the columns are the union of the top-level field names of the documents
    /// rather than a declared schema. An empty set therefore reports no columns.
    /// </remarks>
    internal sealed class MongoDbResultSetModel
    {
        #region *** Properties   ***
        /// <summary>
        /// Gets or sets the distinct top-level field names of the documents, in the order they were first seen.
        /// </summary>
        public string[] Columns { get; set; } = [];

        /// <summary>
        /// Gets or sets the documents of the set, in server order.
        /// </summary>
        public List<BsonDocument> Documents { get; set; } = [];
        #endregion
    }
}
