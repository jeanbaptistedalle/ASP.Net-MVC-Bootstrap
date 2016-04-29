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
            Guid guid = Guid.NewGuid();
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
        public PartialViewResult AjoutePanierProduit(int PanierProduit_Id)
        {
            PanierProduitDTO p = DAL_PanierProduit.AddQtePanierProduit(PanierProduit_Id, 1);
            if (p == null)
            {
                return PartialView("_EmptyPanierProduit");
            }
            else
            {
                return PartialView("_PanierProduit", p);
            }
        }

        [HttpGet]
        public PartialViewResult RetirePanierProduit(int PanierProduit_Id)
        {
            PanierProduitDTO p = DAL_PanierProduit.AddQtePanierProduit(PanierProduit_Id, -1);
            if (p == null)
            {
                return PartialView("_EmptyPanierProduit") ;
            }
            else
            {
                return PartialView("_PanierProduit", p);
            }
        }

        [HttpGet]
        public PartialViewResult SupprimerPanierProduit(int PanierProduit_Id)
        {
            DAL_PanierProduit.SupprimerPanierProduit(PanierProduit_Id);
            return PartialView("_EmptyPanierProduit");
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