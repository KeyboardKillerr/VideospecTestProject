using Services.Models.Items;
using Services.Models.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Examples
{
    public class ExampleReceipt : ReceiptData
    {
        public ExampleReceipt()
        {
            var item = new Item();
            item.Label = "Оплата услуг по страхованию.";
            item.Price = 5328.53f;
            item.Quantity = 1.0f;
            item.Amount = 5328.53f;
            item.Vat = "VatNo";
            item.MarkingCode = null;
            item.PaymentMethod = 0;

            var customerReceipt = new CustomerReceipt();
            customerReceipt.TaxationSystem = "Common";
            customerReceipt.Email = "example@ya.ru";
            customerReceipt.Phone = "+79000000001";
            customerReceipt.PaymentType = 4;
            customerReceipt.Items = new List<Item>() { item };
            customerReceipt.PaymentItems = null;
            customerReceipt.CustomUserProperty = null;

            Inn = "0123456789";
            Type = "Income";
            InvoiceId = Guid.NewGuid().ToString();
            CallbackUrl = null;
            CustomerReceipt = customerReceipt;
        }
    }
}
