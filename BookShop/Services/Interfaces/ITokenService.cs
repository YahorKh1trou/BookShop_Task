using IdentityModel.Client;

namespace BookShop.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
