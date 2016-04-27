using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Start;
using TestApp2.Models;
using TestApp2.ViewsModels.Produit;

namespace TestApp2.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Product
        public ActionResult ListeProduit()
        {
            using (var context = new TestApp2Entities())
            {
                List<Produit> produits = context.Produit.OrderBy(x => x.Libelle).ToList();
                ListeProduitModel model = new ListeProduitModel()
                {
                    ListeProduit = produits.ToListDTO(),
                };
                return View(model);
            }
        }

        public ActionResult Produit(int id)
        {
            using (var context = new TestApp2Entities())
            {
                Produit produit = context.Produit.FirstOrDefault(x => x.Produit_Id == id);
                if (produit == null)
                {
                    return View("Index", "Produit");
                }
                ProduitModel model = new ProduitModel()
                {
                    produit = produit.ToDTO(),
                };
                return View(model);
            }
        }
    }
}