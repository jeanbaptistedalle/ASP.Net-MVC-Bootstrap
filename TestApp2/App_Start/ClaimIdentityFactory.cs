using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TestApp2.Models;

namespace TestApp2.App_Start
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<Utilisateur, string>
    {
        public async override Task<ClaimsIdentity> CreateAsync(UserManager<Utilisateur, string> manager, Utilisateur user, string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            if (!String.IsNullOrWhiteSpace(user.Country))
            {
                identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));
            }
            return identity;
        }
    }
}