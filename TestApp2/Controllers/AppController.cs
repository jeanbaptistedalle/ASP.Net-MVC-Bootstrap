using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;

namespace TestApp2.Controllers
{
    public abstract class AppController : _Controller
    {
        public UtilisateurPrincipal CurrentUser
        {
            get
            {
                return new UtilisateurPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}