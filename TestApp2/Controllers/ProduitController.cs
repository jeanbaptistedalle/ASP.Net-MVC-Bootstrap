using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Start;
using TestApp2.Models;
using TestApp2.ViewsModels.Produit;
using TestApp2.DAL;
using Microsoft.AspNet.Identity;

namespace TestApp2.Controllers
{
    public class ProduitController : _Controller
    {
        [HttpGet]
        public ActionResult ListeProduit()
        {
            ListeProduitModel model = new ListeProduitModel()
            {
                ListeProduit = DAL_produit.GetAll(false),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ListeProduit(bool chkFruit)
        {
            ListeProduitModel model = new ListeProduitModel()
            {
                ListeProduit = DAL_produit.GetAll(chkFruit),
            };
            return View("ListeProduit", model);
        }

        [HttpGet]
        public PartialViewResult AcheterProduit(int produit_Id)
        {
            ProduitDTO produit = DAL_produit.GetProduitById(produit_Id);
            SelectList list = GetQuantiteSelectList(5);
            BuyModalModel model = new BuyModalModel()
            {
                Produit = produit,
                Produit_Id = produit_Id,
                Quantite = 1,
                QuantitesDisponibles = list,
            };
            return PartialView("_BuyProduit", model);
        }

        [HttpGet]
        public ActionResult Produit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ListeProduit", "Produit");
            }
            ProduitDTO produit = DAL_produit.GetProduitById(id.Value);
            if (produit == null)
            {
                return RedirectToAction("ListeProduit", "Produit");
            }
            SelectList quantitesDisponibles = GetQuantiteSelectList(5);
            ProduitModel model = new ProduitModel()
            {
                produit_Id = produit.Produit_Id,
                produit = produit,
                quantiteSelectionnee = 1,
                quantitesDisponibles = quantitesDisponibles,
            };
            return View(model);
        }

        private SelectList GetQuantiteSelectList(int max)
        {
            List<int> ints = new List<int>();
            for (int i = 1; i <= max; i++)
            {
                ints.Add(i);
            }
            return new SelectList(ints.Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            }), "Value", "Text");
        }

        [HttpPost]
        public ActionResult Produit(ProduitModel model)
        {
            PanierDTO panier = DAL_panier.GetOrCreatePanierByUser(User.Identity.GetUserId());
            DAL_panierProduit.AjouterProduit(panier.Panier_Id, model.produit_Id, model.quantiteSelectionnee);
            return RedirectToAction("Produit", "Produit", new { id = model.produit_Id });
        }
    }
}