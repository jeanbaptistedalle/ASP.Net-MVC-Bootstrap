using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_Produit : _DAL
    {
        public List<ProduitDTO> GetAll(bool fruitOnly)
        {
            using (var context = base.GetContext())
            {
                List<Produit> produits;
                if (fruitOnly)
                {
                    produits = context.Produit.Where(x => x.Fruit).OrderBy(x => x.Libelle).ToList();
                }
                else
                {
                    produits = context.Produit.OrderBy(x => x.Libelle).ToList();
                }
                return produits.ToListDTO();
            }
        }

        public ProduitDTO GetProduitById(int id)
        {
            using (var context = base.GetContext())
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