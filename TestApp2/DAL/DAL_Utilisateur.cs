using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Utilisateur
    {

        public static AspNetUsers GetUtilisateur(string User_Id)
        {
            using (var context = new TestApp2Entities())
            {
                AspNetUsers user = context.AspNetUsers.FirstOrDefault(x => x.Id == User_Id);
                return user;
            }
        }

        public static bool IsAdmin(string User_Id)
        {
            using (var context = new TestApp2Entities())
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