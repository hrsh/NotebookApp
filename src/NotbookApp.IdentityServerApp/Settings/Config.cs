using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NotbookApp.IdentityServerApp.Settings
{
    public static class Config
    {
        public static List<TestUser> Users =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1081",
                    Username = "User 1",
                    Password = "pa$$w0rd123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Mazdak"),
                        new Claim(JwtClaimTypes.FamilyName, "Shojaie"),
                        new Claim(JwtClaimTypes.Role, "Admin"),
                        new Claim("role", "Admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "2081",
                    Username = "User 2",
                    Password = "pa$$w0rd123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "User"),
                        new Claim(JwtClaimTypes.FamilyName, "Family"),
                        new Claim(JwtClaimTypes.Role, "Mom"),
                        new Claim("role", "Admin")
                    }
                }
            };

        public static List<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static List<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =
                    {
                        "https://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5001/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "imagegalleryapi"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = true
                }
            };

        public static List<ApiScope> Scopes =>
            new List<ApiScope>
            {
                new ApiScope(
                    "imagegalleryapi",
                    "Image Gallery API",
                    new[] { "role" })
            };
    }
}
