using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class CorrectionInfo : EntityBase
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptId { get; set; }
    }
}
