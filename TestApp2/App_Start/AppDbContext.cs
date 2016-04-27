using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.App_Start
{
    public class AppDbContext : IdentityDbContext<Utilisateur>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }
    }
}