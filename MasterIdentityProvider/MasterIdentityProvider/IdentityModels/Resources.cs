using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterIdentityProvider.IdentityModels
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "API number 1",
                    Description = "Allow the application to access API number 1",
                    Scopes = new List<string> { "api.read", "api1.write" },
                    ApiSecrets = new List<Secret> { new Secret { Value = "ScopeSecret".Sha256()} },
                    UserClaims = new List<string>{ "role" }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API number 1"),
                new ApiScope("api1.write", "Write Access to API number 1")
            };

        }


    }
}
