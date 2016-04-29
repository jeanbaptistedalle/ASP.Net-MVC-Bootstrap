using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class Utilisateur : IdentityUser
    {
        public string Country { get; set; }
        public int? Age { get; set; }
    }
}