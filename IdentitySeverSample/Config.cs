using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySeverSample
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId ="mvc",
                    ClientName="MVC Demo",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris ={ "http://localhost:62531/signin-oidc" },
                    AllowedScopes={ "openid","email","office","profile"},
                    PostLogoutRedirectUris = { "http://localhost:62531/signout-callback-oidc" },
                }

            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="office",
                    DisplayName ="office details",
                    UserClaims = {"office_Id"}
                }

            };
        }


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {

            };
        }
    }
}
