using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptService.Api
{
    public interface IApi
    {
        Task<bool> AuthAsync(string username, string password);
        Task AddReceiptAsync(Receipt receiptData);
    }
}
