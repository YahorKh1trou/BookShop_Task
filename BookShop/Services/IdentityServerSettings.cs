namespace BookShop.Services
{
    public class IdentityServerSettings
    {
        public string DiscoveryUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientPassword { get; set; }
        public bool UseHtpps { get; set; }
    }
}
