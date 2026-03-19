using System;
using System.Collections.Generic;
using System.Text;

namespace G4.Plugins.Google.Models
{
    internal class ClassificationLabelValueModel
    {
        public string LabelId { get; set; }
        public ClassificationLabelFieldValueModel[] Fields { get;set; }
    }
}
