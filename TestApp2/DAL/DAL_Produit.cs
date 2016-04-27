using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Produit
    {
        public static List<ProduitDTO> GetAll()
        {
            using (var context = new TestApp2Entities())
            {
                List<Produit> produits = context.Produit.OrderBy(x => x.Libelle).ToList();
                return produits.ToListDTO();
            }
        }

        public static ProduitDTO GetProduitById(int id)
        {
            using (var context = new TestApp2Entities())
            {
                Produit produit = context.Produit.FirstOrDefault(x => x.Produit_Id == id);
                if (produit != null)
                {
                    return produit.ToDTO();
                }
                return null;
            }
        }
    }
}