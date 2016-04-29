using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Utilisateur : BaseDAL
    {
        public AspNetUsers GetUtilisateur(string User_Id)
        {
            using (var context = base.GetContext())
            {
                AspNetUsers user = context.AspNetUsers.FirstOrDefault(x => x.Id == User_Id);
                return user;
            }
        }

        public bool IsAdmin(string User_Id)
        {
            using (var context = base.GetContext())
            {
                AspNetUsers user = context.AspNetUsers.FirstOrDefault(x => x.Id == User_Id);
                if (user != null)
                {
                    return user.AspNetRoles.Any(x => x.Id == GeneralVariables.Role_Id.Admin);
                }
                return false;
            }
        }
    }
}