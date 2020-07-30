using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MasterIdentityProvider.IdentityModels
{
    public class Clients
    {
        public static IEnumerable<Client> Get() =>
           new List<Client>
           {
               new Client
               {
                   ClientId = "oauthClient",
                   ClientName = "Demo client",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                   ClientSecrets = new List<Secret>{ new Secret { Value = "secret".Sha256()}},
                   AllowedScopes = new List<string>{ "api1.read" }
               },
               new Client
               {
                ClientId = "oidcClient",
                ClientName = "Example",
                ClientSecrets = new List<Secret>{ new Secret { Value = "secret".Sha256()}},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string>{"https://localhost/signin-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "api.read"
                },
                RequirePkce = true,
                AllowPlainTextPkce = false
               }
           };
    }
}
