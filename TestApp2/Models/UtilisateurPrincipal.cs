using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace TestApp2.Models
{
    public class UtilisateurPrincipal : ClaimsPrincipal
    {
        public UtilisateurPrincipal(ClaimsPrincipal principal) : base(principal)
        {

        }

        public string Name
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Country
        {
            get
            {
                return this.FindFirst(ClaimTypes.Country).Value;
            }
        }
    }
}