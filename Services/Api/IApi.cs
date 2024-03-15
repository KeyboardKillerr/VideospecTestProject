using Services.Models.Receipt;
using System.Threading.Tasks;

namespace Services.Api
{
    public interface IApi
    {
        Task<bool> AuthAsync(string username, string password);
        Task AddReceiptAsync(ReceiptData receiptData);
    }
}
