using Services.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Payments;

namespace Services.Models.Receipt
{
    public class CustomerReceipt
    {
        public string TaxationSystem { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AutomaticDeviceNumber { get; set; }
        public int PaymentType { get; set; }
        public PaymentAgentInfo PaymentAgentInfo { get; set; }
        public CorrectionInfo CorrectionInfo { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public PaymentItems PaymentItems { get; set; }
        public CustomUserProperty CustomUserProperty { get; set; }
    }
}
