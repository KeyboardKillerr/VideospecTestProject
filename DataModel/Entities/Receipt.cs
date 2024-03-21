using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel.Entities
{
    public class Receipt : EntityBase
    {
        public float Total { get; set; }
        [NotMapped]
        public string Inn { get; set; }
        [NotMapped]
        public string Type { get; set; }
        [NotMapped]
        public string CallbackUrl { get; set; }
        [NotMapped]
        public string InvoiceId { get; set; }

        [NotMapped]
        public CustomerReceipt CustomerReceipt { get; set; }
    }
}
