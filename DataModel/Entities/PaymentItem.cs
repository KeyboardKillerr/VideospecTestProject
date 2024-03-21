using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class PaymentItem : EntityBase
    {
        public int PaymentType { get; set; }
        public float Sum { get; set; }
    }
}
