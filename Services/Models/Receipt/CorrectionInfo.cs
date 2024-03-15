using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Receipt
{
    public class CorrectionInfo
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptId { get; set; }
    }
}
