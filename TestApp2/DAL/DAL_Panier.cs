using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Panier : BaseDAL
    {
        public PanierDTO GetOrCreatePanierByUser(string User_Id)
        {
            using (var context = base.GetContext())
            {
                Panier panier = context.Panier.FirstOrDefault(x => x.User_Id == User_Id);
                if (panier != null)
                {
                    return panier.ToDTO();
                }
                return CreatePanier(User_Id);
            }
        }

        public PanierDTO CreatePanier(string User_Id)
        {
            using (var context = base.GetContext())
            {
                Panier panier = new Panier();
                panier.User_Id = User_Id;
                context.Panier.Add(panier);
                context.SaveChanges();
                return panier.ToDTO();
            }
        }
    }
}