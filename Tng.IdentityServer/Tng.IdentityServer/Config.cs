using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Tng.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("CoreApi", "Mdp.Core API"),
                new ApiResource("AnalyticsApi", "Mdp.Analytics API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Mdp.MyHome",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("C2100E9D-CFCF-428C-914A-F72FC7EC1BDD".Sha256())
                    },
                    AllowedScopes = { "CoreApi", "AnalyticsApi" },
                    AccessTokenLifetime = 14400 //4 hours
                },

                new Client
                {
                    ClientId = "Next.mdpweb.net",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("8ACFCF8C-EB8F-4787-A878-6FE4D505702B".Sha256())
                    },
                    AllowedScopes = { "CoreApi", "AnalyticsApi" },
                    AccessTokenLifetime = 14400 //4 hours
                },

                 new Client
                {
                    ClientId = "Mdp.PatientPortal",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("53799BE0-6641-42DE-8232-865DA178B120".Sha256())
                    },
                    AllowedScopes = { "CoreApi"},
                    AccessTokenLifetime = 14400 //4 hours
                }

                //// resource owner password grant client
                //new Client
                //{
                //    ClientId = "ro.client",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "CoreApi", "AnalyticsApi" }
                //},

                //// OpenID Connect implicit flow client (MVC)
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",
                //    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    RequireConsent =false,
                //    //RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                //    AllowAccessTokensViaBrowser = true,
                //    AllowOfflineAccess  = true,
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.Email,
                //        "CoreApi", "AnalyticsApi"
                //    }
                //}





            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                //new TestUser
                //{
                //    SubjectId = "1",
                //    Username = "alice",
                //    Password = "password",

                //    Claims = new List<Claim>
                //    {
                //        new Claim("name", "Alice"),
                //        new Claim("website", "https://alice.com")
                //    }
                //},
                //new TestUser
                //{
                //    SubjectId = "2",
                //    Username = "bob",
                //    Password = "password",

                //    Claims = new List<Claim>
                //    {
                //        new Claim("name", "Bob"),
                //        new Claim("website", "https://bob.com")
                //    }
                //}
            };
        }

    }
}
