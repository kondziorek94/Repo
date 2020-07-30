using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MasterIdentityProvider.IdentityModels
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "2328774F-1D88-4304-914E-03F8C04F3944",
                    Username = "bryan",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "bryan@bryansmith.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
