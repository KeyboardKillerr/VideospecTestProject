namespace ReceiptService.Models.Error
{
    public class ErrorResponse
    {
        public string Status { get; set; }
        public ErrorResponseData Error { get; set; }
    }
}
