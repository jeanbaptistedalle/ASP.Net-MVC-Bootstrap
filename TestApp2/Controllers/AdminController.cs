using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TestApp2.DAL;

namespace TestApp2.Controllers
{
    public class AdminController : _Controller
    {

        [AllowAnonymous]
        public ActionResult LienAdministration()
        {
            if (DAL_utilisateur.IsAdmin(User.Identity.GetUserId()))
            {
                return PartialView("_LienAdministration");
            }
            else
            {
                return Content("");
            }
        }

        [Authorize(Roles = GeneralVariables.Role_Name.Admin)]
        public ActionResult Admin()
        {
            return View();
        }
    }
}