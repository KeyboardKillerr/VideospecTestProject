using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class PaymentAgentInfo : EntityBase
    {
        public string AgentType { get; set; }
        public string TransferAgentPhone { get; set; }
        public string TransferAgentName { get; set; }
        public string TransferAgentAddress { get; set; }
        public string TransferAgentINN { get; set; }
        public string PaymentAgentOperation { get; set; }
        public string PaymentAgentPhone { get; set; }
        public string ReceiverPhone { get; set; }
        public string SupplierInn { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
    }
}
