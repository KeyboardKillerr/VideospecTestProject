namespace ReceiptService.Models.Auth
{
    public class AuthResponseData
    {
        public string AuthToken { get; set; }
        public string ExpirationDateUtc { get; set; }
    }
}
