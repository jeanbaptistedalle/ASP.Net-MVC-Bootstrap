using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Panier
    {
        public static PanierDTO GetOrCreatePanierByUser(string User_Id)
        {
            using (var context = new TestApp2Entities())
            {
                Panier panier = context.Panier.FirstOrDefault(x => x.User_Id == User_Id);
                if (panier != null)
                {
                    return panier.ToDTO();
                }
                return CreatePanier(User_Id);
            }
        }

        public static PanierDTO CreatePanier(string User_Id)
        {
            using (var context = new TestApp2Entities())
            {
                Panier panier = new Panier();
                panier.User_Id = User_Id;
                context.Panier.Add(panier);
                context.SaveChanges();
                return panier.ToDTO();
            }
        }

        public static void AjouterProduit(string User_Id, int produit_Id, int quantiteSelectionnee)
        {
            PanierDTO panier = GetOrCreatePanierByUser(User_Id);
            DAL_PanierProduit.AjouterProduit(panier.Panier_Id, produit_Id, quantiteSelectionnee);
        }
    }
}