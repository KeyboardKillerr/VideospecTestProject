using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Items
{
    public class Item
    {
        public string Label { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }
        public float Amount { get; set; }
        public string Vat { get; set; }
        public string MarkingCode { get; set; }
        public int PaymentMethod { get; set; }
    }
}
