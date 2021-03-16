using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotbookApp.IdentityServerApp.Settings
{
    public static class Config
    {
        public static List<TestUser> Users =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString("d"),
                    Username = "User 1",
                    Password = "pa$$w0rd123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Mazdak"),
                        new Claim(JwtClaimTypes.FamilyName, "Shojaie")
                    }
                },
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString("d"),
                    Username = "User 2",
                    Password = "pa$$w0rd123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "User"),
                        new Claim(JwtClaimTypes.FamilyName, "Family")
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

            };
    }
}
