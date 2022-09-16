using IdentityServer4.Models;
using System.Security.Claims;

namespace Server
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }

                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("BookAPI.read"), new ApiScope("BookAPI.write"), };
        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("BookAPI")
                {
                    Scopes = new List<string> { "BookAPI.read", "BookAPI.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };
        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    Claims = new ClientClaim[]
                    {
                        new ClientClaim("role", "admin")
                    },
                    AllowedScopes = { "BookAPI.read", "BookAPI.write", "role" }
                },
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7031/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:7031/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:7031/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "opneid", "profile", "BookAPI.read", "role" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },
            };
    }
}
