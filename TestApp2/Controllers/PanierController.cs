using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.DAL;
using Microsoft.AspNet.Identity;
using TestApp2.ViewsModels.Panier;

namespace TestApp2.Controllers
{
    public class PanierController : Controller
    {
        [HttpGet]
        public ActionResult Panier()
        {
            PanierDTO panier = DAL_Panier.GetOrCreatePanierByUser(User.Identity.GetUserId());
            PanierModel model = new PanierModel()
            {
                Panier_Id = panier.Panier_Id,
                PrixTotal = panier.PrixTotal,
                PanierProduits = panier.PanierProduits,
            };
            return View(model);
        }

        [HttpPost]
        [MultipleButton(Name = "Panier", Argument = "ViderPanier")]
        public ActionResult ViderPanier(PanierModel model)
        {
            DAL_PanierProduit.ViderPanier(User.Identity.GetUserId());
            return RedirectToAction("Panier", "Panier");
        }

        [HttpGet]
        public ActionResult AjoutePanierProduit(int PanierProduit_Id)
        {
            DAL_PanierProduit.AjoutePanierProduit(PanierProduit_Id, 1);
            return RedirectToAction("Panier", "Panier");
        }

        [HttpGet]
        public ActionResult RetirePanierProduit(int PanierProduit_Id)
        {
            DAL_PanierProduit.RetirePanierProduit(PanierProduit_Id, 1);
            return RedirectToAction("Panier", "Panier");
        }
        
        [HttpGet]
        public ActionResult SupprimerPanierProduit(int PanierProduit_Id)
        {
            DAL_PanierProduit.SupprimerPanierProduit(PanierProduit_Id);
            return RedirectToAction("Panier", "Panier");
        }
        
        [HttpPost]
        [MultipleButton(Name = "Panier", Argument = "SupprimerSelection")]
        public ActionResult SupprimerSelection(PanierModel model)
        {
            DAL_PanierProduit.Supprimer(model.PanierProduits.Where(x => x.selectionne).Select(x => x.PanierProduit_Id).ToList());
            return RedirectToAction("Panier", "Panier");
        }
    }
}