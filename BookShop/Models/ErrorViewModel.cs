namespace BookShop.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        // better use IsNullOrWhiteSpace method
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}