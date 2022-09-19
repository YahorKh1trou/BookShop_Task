using BookShop.Services.Interfaces;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace BookShop.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        private readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            this.identityServerSettings = identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync
                (this.identityServerSettings.Value.DiscoveryUrl).Result;
            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to get discovery document",
                    discoveryDocument.Exception);
            }
        }

        // you don't have to pass scope as parameters in such methods,
        // scope is smth like ClientId, it persistent value that assosiated with your client
        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = identityServerSettings.Value.ClientName,
                ClientSecret = identityServerSettings.Value.ClientPassword,
                Scope = scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }
            return tokenResponse;
        }
    }
}
