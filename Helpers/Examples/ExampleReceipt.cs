using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Examples
{
    public class ExampleReceipt : Receipt
    {
        public ExampleReceipt()
        {
            var item = new Item();
            item.Label = "Оплата услуг по страхованию.";
            item.Price = 5328.53f;
            item.Quantity = 1.0f;
            item.Amount = 5328.53f;
            item.Vat = "VatNo";
            item.MarkingCode = "444D0436038939FC53784D476F72764E757136576B";
            item.PaymentMethod = 0;

            var customerReceipt = new CustomerReceipt();
            customerReceipt.TaxationSystem = "Common";
            customerReceipt.Email = "example@ya.ru";
            customerReceipt.Phone = "+79000000001";
            customerReceipt.PaymentType = 4;
            customerReceipt.Items = new List<Item>() { item };
            customerReceipt.PaymentItems = null;
            customerReceipt.CustomUserProperty = null;

            var id = Guid.NewGuid();
            Id = id;
            Total = 0;
            Inn = "0123456789";
            Type = "Income";
            InvoiceId = id.ToString();
            CallbackUrl = null;
            CustomerReceipt = customerReceipt;
        }
    }
}
