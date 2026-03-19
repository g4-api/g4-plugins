using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace G4.Plugins.Google.Models
{
    internal class MessagePartBodyModel
    {
        public string AttachmentId { get; set; }
        public string Data { get; set; }
        public int Size { get; set; }
    }
}
