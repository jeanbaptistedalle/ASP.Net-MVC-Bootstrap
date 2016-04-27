using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;

namespace TestApp2.Views
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected UtilisateurPrincipal CurrentUser
        {
            get
            {
                return new UtilisateurPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}