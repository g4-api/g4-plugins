using System;
using System.Collections.Generic;
using System.Text;

namespace G4.Plugins.Google.Models
{
    internal class MessagePartModel
    {
        public string PartId { get; set; }
        public string MimeType { get; set; }
        public string Filename { get; set; }
        public MessagePartBodyModel Body { get; set; }
        public HeaderModel[] Headers { get; set; }
        public MessagePartModel[] Parts { get; set; }
    }
}
