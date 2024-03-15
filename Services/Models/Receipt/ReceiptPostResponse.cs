using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Receipt
{
    public class ReceiptPostResponse
    {
        public string Status { get; set; }
        public ReceiptPostResponseData Data { get; set; }
    }
}
