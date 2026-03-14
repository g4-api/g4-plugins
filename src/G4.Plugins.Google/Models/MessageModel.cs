using System;
using System.Collections.Generic;
using System.Text;

namespace G4.Plugins.Google.Models
{
    internal class MessageModel
    {
        public string Id { get; set; }
        public string ThreadId { get; set; }
        public string[] LabelIds { get; set; }
        public string Snippet { get; set; }
        public string HistoryId { get; set; }
        public string InternalDate { get; set; }

        public MessagePartModel Payload { get; set; }

        public int SizeEstimate { get; set; }
        public string Raw { get; set; }
        public object[] ClassificationLabelValues {  get; set; }
    }
}
