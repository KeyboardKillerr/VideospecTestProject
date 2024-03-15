using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Receipt
{
    public class ReceiptData
    {
        public string Inn { get; set; }
        public string Type { get; set; }
        public string InvoiceId { get; set; }
        public string CallbackUrl { get; set; }
        public CustomerReceipt CustomerReceipt { get; set; }
    }
}
