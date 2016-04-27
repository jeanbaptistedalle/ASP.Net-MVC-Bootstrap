using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using TestApp2.Models;
using TestApp2.App_Start;

namespace TestApp2.App_Start
{
    public class Startup
    {
        public static Func<UserManager<Utilisateur>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // this is the same as before
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/auth/login")
            });

            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<Utilisateur>(new UserStore<Utilisateur>(new AppDbContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<Utilisateur>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                usermanager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();
                
                return usermanager;
            };
        }
    }
}