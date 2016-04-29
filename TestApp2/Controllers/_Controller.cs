using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.DAL;
using System.Web.Mvc;

namespace TestApp2.Controllers
{
    public class _Controller : Controller
    {
        private DAL_Utilisateur _DAL_utilisateur;
        protected DAL_Utilisateur DAL_utilisateur
        {
            get
            {
                if (_DAL_utilisateur == null)
                {
                    _DAL_utilisateur = new DAL_Utilisateur();
                }
                return _DAL_utilisateur;
            }
        }
        private DAL_PanierProduit _DAL_panierProduit;
        protected DAL_PanierProduit DAL_panierProduit
        {
            get
            {
                if (_DAL_panierProduit == null)
                {
                    _DAL_panierProduit = new DAL_PanierProduit();
                }
                return _DAL_panierProduit;
            }
        }
        private DAL_Produit _DAL_produit;
        protected DAL_Produit DAL_produit
        {
            get
            {
                if (_DAL_produit == null)
                {
                    _DAL_produit = new DAL_Produit();
                }
                return _DAL_produit;
            }
        }
        private DAL_Panier _DAL_panier;
        protected DAL_Panier DAL_panier
        {
            get
            {
                if (_DAL_panier == null)
                {
                    _DAL_panier = new DAL_Panier();
                }
                return _DAL_panier;
            }
        }
    }
}