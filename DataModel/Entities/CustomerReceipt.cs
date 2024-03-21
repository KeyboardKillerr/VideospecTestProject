using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class CustomerReceipt : EntityBase
    {
        public string TaxationSystem { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AutomaticDeviceNumber { get; set; }
        public int PaymentType { get; set; }
        public PaymentAgentInfo PaymentAgentInfo { get; set; }
        public CorrectionInfo CorrectionInfo { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public PaymentItem PaymentItems { get; set; }
        public CustomUserProperty CustomUserProperty { get; set; }
    }
}
