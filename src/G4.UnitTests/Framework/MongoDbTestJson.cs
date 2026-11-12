using MongoDB.Bson;
using MongoDB.Bson.Serialization;

using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Reads the Extended JSON outputs of the MongoDB plugins back into BSON for assertions.
    /// </summary>
    /// <remarks>
    /// The plugins store their outputs as minified relaxed Extended JSON text, so a scenario parses the text here
    /// instead of comparing strings, and therefore asserts on values and BSON types rather than on formatting.
    /// </remarks>
    public static class MongoDbTestJson
    {
        #region *** Methods      ***
        /// <summary>
        /// Parses a stored JSON array of documents.
        /// </summary>
        /// <param name="json">The Extended JSON array text.</param>
        /// <returns>The documents of the array.</returns>
        public static List<BsonDocument> ToDocuments(string json)
        {
            // Parse the array and read every item as a document, which is what the plugins store.
            return [.. ToValues(json).Select(i => i.AsBsonDocument)];
        }

        /// <summary>
        /// Parses a stored JSON array of text values, such as the reported field names.
        /// </summary>
        /// <param name="json">The JSON array text.</param>
        /// <returns>The values of the array.</returns>
        public static string[] ToStrings(string json)
        {
            // Parse the array and read every item as text.
            return [.. ToValues(json).Select(i => i.AsString)];
        }

        /// <summary>
        /// Parses a stored JSON array into its raw BSON values.
        /// </summary>
        /// <param name="json">The Extended JSON array text.</param>
        /// <returns>The values of the array.</returns>
        public static BsonArray ToValues(string json)
        {
            // Deserialize through the BSON serializer so both Extended JSON forms are accepted.
            return BsonSerializer.Deserialize<BsonArray>(json);
        }
        #endregion
    }
}
